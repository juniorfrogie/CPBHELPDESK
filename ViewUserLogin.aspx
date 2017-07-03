<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewUserLogin.aspx.cs" Inherits="users_ViewUserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellspacing="1" >
        <tr>
            <td colspan="11">
                <div class="HeaderStypeTitle">
                    ពត៌មាន អ្នកប្រើប្រាស់ តាមប្រព័ន្ធអេឡិចត្រូនិក<br />
                    LIST OF USER LOGIN INFORMATION
                </div>
            </td>
        </tr>
        <tr>
            <td class="tableTitel">User Login</td>
            <td class="tableTitel">Position</td>
            <td class="tableTitel">User Group</td>
            <td class="tableTitel">Location</td>
            <td class="tableTitel">Edit</td>
            <td class="tableTitel">Delete</td>
        </tr>
        <%
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from s in db.tbluserLogins
                        select s;
            foreach (var r in query) {
                Response.Write("<tr class='rows'><td class='datarows'>" + r.USERLOGIN + "</td>");
                Response.Write("<td class='datarows'>" + r.POSITION + "</td>");
                Response.Write("<td class='datarows'>" + r.USERGROUP + "</td>");
                Response.Write("<td class='datarows'>" + r.LOCATION + "</td>");
        %>
              <td style="text-align: left">
                  <a class='datarows' style="text-align: center; color: #f00" href="CreateUserLogin.aspx?id=<% Response.Write(r.ID); %>">Edit</a>
              </td>
              <td style="text-align: left">
                  <a class='datarows' style="text-align: center; color: #f00" href="CreateUserLogin.aspx?id=<% Response.Write(r.ID); %>">Delete</a>
              </td>
        </tr>
        <%
            }  
     %>
       
    </table>
</asp:Content>

