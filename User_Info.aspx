<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Info.aspx.cs" Inherits="Users_Info_task._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>User Information</title>
    <style type="text/css">
        .style1 {
            width: 286px;
        }
    </style>
    <style type="text/css">
   table {
  background-color: #696969;
  color: white;
  
  
}

btn_adduser 
{  
   background-color: #04AA6D;   
   color: white;  
}
    </style>
    
</head>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("[id*=txtDate]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'images/calendar.png'
        });
    });
</script>
<script type="text/javascript">
    $(function() {
    $("[id*=txtdob1]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'images/calendar.png'
        });
    });
</script>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tab_user" >
    <tr>
   <td>
       <asp:Label ID="lbl_Name" runat="server" Text="Name:"></asp:Label>
        </td>
        
        <td class="style1">
        <asp:TextBox ID="txt_Name" runat="server" ></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbl_dob" runat="server" Text="DOB:"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>
        
        </td></tr>
        <tr>
        <td>
            <asp:Label ID="lbl_des" runat="server" Text="Designation:"></asp:Label>
        </td>
        <td class="style1">
        <asp:TextBox ID="txt_des" runat="server" ></asp:TextBox> 
        </td></tr>
        <tr>
        <td>
            <asp:Label ID="lbl_skills" runat="server" Text="Skills"></asp:Label>
        </td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem >Effective communication</asp:ListItem>
            <asp:ListItem >Teamwork</asp:ListItem>
            <asp:ListItem >Problem Solving</asp:ListItem>
            <asp:ListItem >Creativity</asp:ListItem>
            <asp:ListItem >Time Management</asp:ListItem>
            </asp:CheckBoxList>
        </td></tr>
        <tr>
   <td></td>
     <td>
         <asp:Button ID="btn_adduser" runat="server" Text="Add User" Width="115px" OnClick="btn_adduser_Click"/>
          <asp:Button runat="server" ID="btnUpdate" Text="Update" class="button button4" OnClick="btnUpdate_Click" Visible=false/>  
          <asp:Button runat="server" ID="btnReset" Text="Reset"  class="button button4" OnClick="btnReset_Click"/>  
                        
      </td>
        </tr>
      </table>
    </div>
    
    
    
    
    <div>
    <h4>Show User Date</h4>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  DataKeyNames="Id"
 OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
 OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added.">
<Columns>
<asp:TemplateField HeaderText="Id" Visible=false>  
                                         <HeaderStyle HorizontalAlign="Left" />  
                                        <ItemStyle HorizontalAlign="Left" />  
                                        <ItemTemplate>  
                                            <asp:Label runat="server" ID="lblId" Text='<%#Eval("Id") %>'></asp:Label>  
                                        </ItemTemplate>  
                                    </asp:TemplateField>
    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
        <ItemTemplate>

            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:TemplateField>
        <asp:TemplateField HeaderText="DOB" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="Lbldob1" runat="server" Text='<%# Eval("Dob") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lbldes" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
        </ItemTemplate>
      
    </asp:TemplateField>
        <asp:TemplateField HeaderText="Skills" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lbisk" runat="server" Text='<%# Eval("Skills") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:TemplateField>
    
    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" ControlStyle-ForeColor="white"/>
</Columns>
</asp:GridView>

    </div>
    </form>
</body>
</html>
