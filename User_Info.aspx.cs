using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Users_Info_task
{
    public partial class _Default : System.Web.UI.Page
    {
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        DataSet _dtSet; 
        public void CreateConnection()
        {
            SqlConnection _sqlConnection = new SqlConnection("Data Source=AMCCS-P-L-77;Initial Catalog =User_info_db;User ID=sa;Password=APP@2k21;Connect Timeout=360000");
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }
        public void OpenConnection()
        {
            _sqlCommand.Connection.Open();
        }
        public void CloseConnection()
        {
            _sqlCommand.Connection.Close();
        }
        public void DisposeConnection()
        {
            _sqlCommand.Connection.Dispose();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid_User_data();
        }

        private static void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }

        public void ClearControls()
        {
            txt_Name.Text = "";
            txtDate.Text = "";
            txt_des.Text = "";
            CheckBoxList1.ClearSelection();

        }


        protected void btn_adduser_Click(object sender, EventArgs e)
        {
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user_crud_operation";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@Action", "INSERT");
                _sqlCommand.Parameters.AddWithValue("@Name", Convert.ToString(txt_Name.Text));
                _sqlCommand.Parameters.AddWithValue("@Dob", (txtDate.Text));
                _sqlCommand.Parameters.AddWithValue("@Designation", Convert.ToString(txt_des.Text));
                string lst = "";

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        lst = lst + "'" + CheckBoxList1.Items[i].Value + "' ,";
                    }
                }
                _sqlCommand.Parameters.AddWithValue("@Skills", Convert.ToString(lst));

                int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());


                ShowAlertMessage("Record Is Inserted Successfully");
                BindGrid_User_data();
                ClearControls();

            }
            catch (Exception ex)
            {

                ShowAlertMessage("Check your input data");

            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        } 

        private void BindGrid_User_data()
        {
            


           
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user_crud_operation_select";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = _sqlCommand;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
          
           
                CloseConnection();
                DisposeConnection();
            

        }




        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid_User_data();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btn_adduser.Visible = false;
            btnUpdate.Visible = true;

            int RowIndex = e.NewEditIndex;
            Label empid = (Label)GridView1.Rows[RowIndex].FindControl("lblId");
            Session["id"] = empid.Text;

            txt_Name.Text = ((Label)GridView1.Rows[RowIndex].FindControl("lblName")).Text.ToString();
            txtDate.Text = ((Label)GridView1.Rows[RowIndex].FindControl("Lbldob1")).Text.ToString();
            txt_des.Text = ((Label)GridView1.Rows[RowIndex].FindControl("lbldes")).Text.ToString();
            CheckBoxList1.Text = ((Label)GridView1.Rows[RowIndex].FindControl("lbisk")).Text.ToString();

        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        { 
             try  
    {  
               
        CreateConnection();  
        OpenConnection(); 
                   
                    _sqlCommand.CommandText = "user_crud_operation";
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.Parameters.AddWithValue("@Action", "UPDATE");
                    _sqlCommand.Parameters.AddWithValue("@Name", Convert.ToString(txt_Name.Text));
                    _sqlCommand.Parameters.AddWithValue("@Dob", (txtDate.Text));
                    _sqlCommand.Parameters.AddWithValue("@Designation", Convert.ToString(txt_des.Text));
                    string lst = "";

                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        if (CheckBoxList1.Items[i].Selected)
                        {
                            lst = lst + "'" + CheckBoxList1.Items[i].Value + "' ,";
                        }
                    }
                    _sqlCommand.Parameters.AddWithValue("@Skills", Convert.ToString(lst));
                    _sqlCommand.Parameters.AddWithValue("@Id", Convert.ToDecimal(Session["Id"]));  
  

                    int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
                  
                        ShowAlertMessage("Record Is Updated Successfully");
                        GridView1.EditIndex = -1;
                        BindGrid_User_data();
                        ClearControls();
                  
    }

             catch (Exception ex)
             {
                 ShowAlertMessage("Check your input data");
             }
             finally
             {
                 CloseConnection();
                 DisposeConnection();
             }  
                
            
           
        }



        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            CreateConnection();
            
                using (SqlCommand cmd = new SqlCommand("user_crud_operation"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    OpenConnection();
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                   
                }
            
            this.BindGrid_User_data();



        }



        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid_User_data();
        }  
    }


}
