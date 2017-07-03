<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Change Password.aspx.cs" Inherits="users_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 187px;
        }
        .txt_Size {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="tableForm TableWidth">
<tr>
    <td>
    <table class="subTabls">
    <tbody>
        <asp:ValidationSummary ID="ValidationSummary1" CssClass="Errors" Font-Names="arial" HeaderText="All Error Message" Font-Bold="true" ForeColor="Red" runat="server" />
        <asp:Label ID="ErrorPassword" runat="server" CssClass="Errors" />
    </tbody>
    <tr>
       <td>
        <fieldset>
          <legend>User</legend>
            <table width="100%">    
            <tr>
                <td>
                <table style="width: 458px">
                   
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="Current Password" CssClass="labels"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
               
                            <asp:TextBox ID="txtCurrentPassword" TextMode="Password" CssClass="txt_Size" runat="server" Width="227px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCurrentPassword" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Required Old Password!">*</asp:RequiredFieldValidator>
                           
                        </td>
                    </tr>    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="New Password" CssClass="labels"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="txt_Size" runat="server" Width="227px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Required New Password!">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" 
                             ValidationExpression=".{6}.*" 
                             Display="Static" ForeColor="Red" 
                             ErrorMessage="Password must be 6-15 Characters and Number Long!">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="Confirm Password" CssClass="labels"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                             <asp:TextBox ID="txtConfirmPassword" TextMode="Password" CssClass="txt_Size" runat="server" Width="227px"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Required Confirm Password!">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Compare new Password and Confirm Password is Wrong!"></asp:CompareValidator>
                        </td>
                    </tr>    
                </table> 
                </td>
                <td valign="top" class="ButtomWidth">
                    <asp:Button ID="Submit" runat="server" CssClass="bbSize" Text="CHANGE" OnClick="Submit_Click"/>
                 </td>
             </tr>             
            </table>  
        </fieldset>
       </td>
    </tr>  
    </table>
    </td>
</tr>
</table>

</asp:Content>


