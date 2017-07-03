<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="users_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table > tbody .rows:odd").css("background-color", "#DDD");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellspacing="0" >
        <tr>
            <td colspan="11">
                <div class="HeaderStypeTitle">
                    ពត៌មាន អ្នកប្រើប្រាស់ តាមប្រព័ន្ធអេឡិចត្រូនិក<br />
                    LIST OF STAFF INFORMATION
                </div>
            </td>
        </tr>
        <tr>
            <td class="tableTitel">IDCard</td>
            <td class="tableTitel">Name KH</td>
            <td class="tableTitel">Name EN</td>
            <td class="tableTitel">Sex</td>
            <td class="tableTitel">Status</td>
            <td class="tableTitel">Position</td>
            <td class="tableTitel">Department</td>
            <td class="tableTitel">Location</td>
            <td class="tableTitel">StartDate</td>
            <td class="tableTitel">Phone</td>
            <td class="tableTitel">Edit</td>
            <td class="tableTitel">View</td>
            <td class="tableTitel">Delete</td>
        </tr>
       
        <%
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from s in db.tblStaffinfos
                        where s.IDCard != ""
                        select s;
            foreach (var r in query) {
                Response.Write("<tr class='rows'><td class='datarows' style='text-align: center'>" + r.IDCard + "</td>");
                Response.Write("<td class='datarows'>" + r.NameKhmer + "</td>");
                Response.Write("<td class='datarows'>" + r.Name + "</td>");
                Response.Write("<td class='datarows' style='text-align: center'>" + r.Sex + "</td>");
                Response.Write("<td class='datarows'>" + r.Status + "</td>");
                Response.Write("<td class='datarows'>" + r.Position + "</td>");
                Response.Write("<td class='datarows'>" + r.Department + "</td>");
                Response.Write("<td class='datarows'>" + r.Location + "</td>");
                Response.Write("<td class='datarows'>" + Convert.ToDateTime(r.StartingDate).ToString("dd/MM/yyyy") + "</td>");
                Response.Write("<td class='datarows'>" + r.PhoneNumber + "</td>");
                %>
              <td style="text-align: center">
                  <a class='datarows' style="text-align: center; color: #f00" href="Create.aspx?id=<% Response.Write(r.IDCard); %>">Edit</a>
              </td>
              <td style="text-align: center">
                  <a class='datarows' style="text-align: center; color: #f00" href="ListDetail.aspx?id=<% Response.Write(r.IDCard); %>">View</a>
              </td>
              <td style="text-align: center">
                  <a class='datarows' style="text-align: center; color: #f00" href="Create.aspx?id=<% Response.Write(r.IDCard); %>">Delete</a>
              </td>
        </tr>
        <%
            }  
     %>
       
    </table>
</asp:Content>

      