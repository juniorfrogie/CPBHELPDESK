<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListDetail.aspx.cs" Inherits="users_ListDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    <%--<asp:DetailsView ID="DetailsView1" runat="server" CellSpacing="0" CellPadding="5" Height="50px" Width="100%" GridLines="None" AlternatingRowStyle-BackColor="#E2E2E2" BackColor="#F0F0F0" AlternatingRowStyle-ForeColor="#555555"></asp:DetailsView>--%>
    <%
       
            DataClassesDataContext db = new DataClassesDataContext();
            var q = (from s in db.tblStaffinfos
                         where s.IDCard == Request.QueryString["id"]
                         select s).Single();
     %>
    <style>
        table tr td {
            background: #EEE;
        }
    </style>
     <div class="HeaderStypeTitle">
                    ពត៌មាន អ្នកប្រើប្រាស់ តាមប្រព័ន្ធអេឡិចត្រូនិក<br />
                    VIEW STAFF INFORMATION
                </div>
    <table cellspacing="1" cellpadding="5" style=" margin: 10px auto; width: 100%;">
      
        <tr>
            <td class="">ID Card</td>
            <td><% Response.Write(q.IDCard); %></td>
        </tr>
        <tr>
            <td class="">Name KH</td>
            <td><% Response.Write(q.NameKhmer); %></td>
        </tr>
        <tr>
            <td class="">Name EN</td>
            <td><% Response.Write(q.Name); %></td>
        </tr>
        <tr>
            <td class="">Sex</td>
            <td><% Response.Write(q.Sex); %></td>
        </tr>
        <tr>
            <td class="">Status</td>
            <td><% Response.Write(q.Status); %></td>
        </tr>
        <tr>
            <td class="">Position</td>
            <td><% Response.Write(q.Position); %></td>
        </tr>
        <tr>
            <td class="">Department</td>
            <td><% Response.Write(q.Department); %></td>
        </tr>
        <tr>
            <td class="">Location</td>
            <td><% Response.Write(q.Location); %></td>
        </tr>
        <tr>
            <td class="">Start Date</td>
            <td><% Response.Write(Convert.ToDateTime(q.StartingDate).ToString("dd/MM/yyyy")); %></td>
        </tr>
         <tr>
            <td class="">Pass Probation Date</td>
            <td><% Response.Write(Convert.ToDateTime(q.ProbationDate).ToString("dd/MM/yyyy")); %></td>
        </tr>
        <tr>
            <td class="">Phone Num</td>
            <td><% Response.Write(q.PhoneNumber); %></td>
        </tr>
        <tr>
            <td class="">Email Address</td>
            <td><% Response.Write(q.Email); %></td>
        </tr>
        <tr>
            <td></td>
            <td><a class='datarows' style="text-align: center; color: #f00" href="Create.aspx?id=<% Response.Write(q.IDCard); %>">EDIT</a></td>
        </tr>
    </table>
</asp:Content>

