<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="users_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="HeaderStypeTitle">
                    ពត៌មាន បង្កើត អ្នកប្រើប្រាស់ តាមប្រព័ន្ធអេឡិចត្រូនិក​ <br />
                    CREATE STAFF INFORMATION
                </div>
    <table class="Tables" style=" margin: 5px auto;">
        <tr>
            <td colspan="2" width="">
                <div style="width: 85%; margin: 10px auto">
                <asp:ValidationSummary ID="ValidationSummary1" HeaderText=" + Required " Font-Bold="true" Font-Size="Medium" ForeColor="Red" runat="server" />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="userTitle">ID Card</td>
            <td>
                <asp:TextBox ID="txtIDCard" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtIDCard" ForeColor="Red" runat="server" ErrorMessage="Required Field ID Card !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Name KH</td>
            <td>
                <asp:TextBox ID="txtNameKH" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNameKH" ForeColor="Red" runat="server" ErrorMessage="Required Field Name KH !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Name EN</td>
            <td>
                <asp:TextBox ID="txtNameEN" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNameEN" ForeColor="Red" runat="server" ErrorMessage="Required Field Name EN !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Gender</td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Value="0">-- Choose --</asp:ListItem>
                    <asp:ListItem Value="M">M</asp:ListItem>
                    <asp:ListItem Value="F">F</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ControlToValidate="ddlGender" ForeColor="Red" runat="server" ErrorMessage="Required Field Gender !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Status</td>
            <td>
                <asp:TextBox ID="txtStatus" CssClass="txtSize220" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Position</td>
            <td>
                <asp:TextBox ID="txtPosition" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtPosition" ForeColor="Red" runat="server" ErrorMessage="Required Field Position !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Department</td>
            <td>
                <asp:DropDownList ID="ddlDeparment" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ControlToValidate="ddlDeparment" ForeColor="Red" runat="server" ErrorMessage="Required Field Department !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Loacation</td>
            <td>
                <asp:TextBox ID="txtLocation" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtLocation" ForeColor="Red" runat="server" ErrorMessage="Required Field Location !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Start Date</td>
            <td>
                <asp:TextBox ID="txtStartDate" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtStartDate" ForeColor="Red" runat="server" ErrorMessage="Required Field Start Date !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Pass Probation Date</td>
            <td>
                <asp:TextBox ID="txtProbation" CssClass="txtSize220" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Phone Num</td>
            <td>
                <asp:TextBox ID="txtPhoneNum" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPhoneNum" ForeColor="Red" runat="server" ErrorMessage="Required Field Phone Number !.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="userTitle">Email Address</td>
            <td>
                <asp:TextBox ID="txtEmail" CssClass="txtSize220" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtEmail" ForeColor="Red" runat="server" ErrorMessage="Required Field Email Address !.">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="userTitle" ID="RegularExpressionValidator1" runat="server" ControlToValidate = "txtEmail" Display ="none" ValidationExpression="^\w+([-+.']\w+)*@cambodiapostbank.com$"
                ErrorMessage="Please enter valid email address. Eg. Something@cambodiapostbank.com"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="cmdSave" runat="server" CssClass="btnSize100" Text="Submit" OnClick="cmdSave_Click" />
                <asp:Button ID="cmdEdit" runat="server" CssClass="btnSize100" Text="Edit" OnClick="cmdEdit_Click" />
                <asp:Button ID="cmdDelte" runat="server" CssClass="btnSize100" Text="Delete" OnClientClick="return confirm('Do you want to Delete ?.');" OnClick="cmdDelte_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
	