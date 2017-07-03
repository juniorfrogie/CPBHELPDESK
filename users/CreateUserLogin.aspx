<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUserLogin.aspx.cs" Inherits="users_CreateUserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="HeaderStypeTitle">
                    ពត៌មាន បង្កើត អ្នកប្រើប្រាស់ តាមប្រព័ន្ធអេឡិចត្រូនិក​ <br />
                    CREATE USER LOGIN
                </div>
    <table style="margin: 10px auto">
        <tr>
            <td colspan="2">
                
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="+ Required" ForeColor="Red" runat="server" />
            </td>
        </tr>
        <tr>
            <td>User Login</td>
            <td>
                <asp:TextBox ID="txtLogin" onblur ="this.value=this.value.toUpperCase()" CssClass="txtSize160" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLogin" ForeColor="Red" runat="server" ErrorMessage="Required Field User Name !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" CssClass="txtSize160" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ForeColor="Red" runat="server" ErrorMessage="Required Field Password !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirm" CssClass="txtSize160" TextMode="Password" runat="server"></asp:TextBox>
                <asp:CompareValidator  ID="CompareValidator1" ControlToValidate="txtPassword" ControlToCompare="txtConfirm" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Compare new Password and Confirm Password is Wrong!">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Position</td>
            <td>
                <asp:DropDownList ID="ddlPosition" CssClass="ddlSize128" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="0" ControlToValidate="ddlPosition" ForeColor="Red" runat="server" ErrorMessage="Required Field Position !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>User Group</td>
            <td>
                <asp:DropDownList ID="ddlUserGroup" CssClass="ddlSize128" runat="server">
                    <asp:ListItem Value="0">- Choose -</asp:ListItem>
                    <asp:ListItem Value="1">- Administrator -</asp:ListItem>
                    <asp:ListItem Value="2">- Certifier -</asp:ListItem>
                    <asp:ListItem Value="3">- Authorizer -</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" ControlToValidate="ddlUserGroup" ForeColor="Red" runat="server" ErrorMessage="Required Field User Group !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Location</td>
            <td>
                <asp:DropDownList ID="ddlLocation" CssClass="ddlSize128" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ControlToValidate="ddlUserGroup" ForeColor="Red" runat="server" ErrorMessage="Required Field User Group !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cmdSumit" CssClass="btnSize100" runat="server" Text="Submit" OnClick="cmdSumit_Click" />
                <asp:Button ID="cmdEdit" CssClass="btnSize100" runat="server" Text="Edit" OnClick="cmdEdit_Click" />
                <asp:Button ID="cmdDelete" CssClass="btnSize100" OnClientClick="return confirm('Do you want to Delete ?.');" runat="server" Text="Delete" OnClick="cmdDelete_Click" />
            </td>
            
        </tr>
    </table>
</asp:Content>

