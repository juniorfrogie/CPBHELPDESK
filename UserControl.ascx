<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControl.ascx.cs" Inherits="UserControl" %>
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="images/cambodiapostbank.ico" />
<center>

<table class="styleTable" cellpadding="0" cellspacing="0">
    <tr class="loghead">
        <td colspan="3" class="loghead">
            <asp:Image ID="Image2" ImageUrl="~/images/lock.png" runat="server" />
       
         Login your Application
        </td>
        
    </tr>
    <tr>
        <td colspan="3" align="left" class="errorMsg">
            <asp:Image ID="Image1" ImageUrl="~/images/logo_title_top.png" runat="server" CssClass="Logo" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText=" " ForeColor="Red" runat="server" />
            <br />
            <asp:Label ID="lblMsg" CssClass="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td width="100px"><div class="Label">User ID</div></td>
        <td>
            <asp:TextBox ID="UserID" onblur ="this.value=this.value.toUpperCase()" CssClass="txt_Size" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Static" ForeColor="Red" ControlToValidate="userID" runat="server" ErrorMessage="The Field is Required">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td><div class="Label">Password</div></td>
        <td>
            <asp:TextBox ID="Password" CssClass="txt_Size" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Static" ForeColor="Red" ControlToValidate="Password" runat="server" ErrorMessage="The Field is Required">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="1"></td>
        <td><asp:Button ID="cmdlogin" CssClass="cmdlogin" runat="server" Text="Login" 
                onclick="cmdlogin_Click" />             
        </td>        
    </tr>
</table>
</center>