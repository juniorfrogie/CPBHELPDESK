<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mantis_mgt.aspx.cs" Inherits="pages_mantis_mgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="HeaderStypeTitle">
	            Mantis Management
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-7">                
                <asp:Button ID="btnAdd" runat="server" Text="Add Issue" CssClass="btn btn-primary" OnClick="btnAdd_Click" />               
            </div>            
            <div class="col-lg-1">
                <label>Status:</label>
            </div>
            <div class="col-lg-3">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>        
        <div class="row">
            <div class="col-lg-12">
                
                    <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>No.</th>
                            <th>Action</th>
                            <th>Ticket Code</th>
                            <th>Status</th>
                            <th>Issue</th>
                            
                            <th>Branch</th>
                            
                            <th>Issue Date</th>                            
                            <th># of Due Day</th>
                            <th>Risk Level</th>                           
                        </tr>
                    </thead>
                    <tbody>
                        <%                            
                            DataClassesDataContext dc = new DataClassesDataContext();
                            
                                                        
                            var query = from q in dc.tblMantis
                                        select q;
                            if (ddlStatus.SelectedIndex!=0)
                            {
                                query = from q in dc.tblMantis
                                        where q.status == ddlStatus.SelectedValue
                                        select q;
                            }
                            int n = 0;                                        
                            foreach(var q in query)                                        
                            {
                                string date = string.Format("{0:dd-MM-yyyy}",q.issue_date);
                             %>
                                <tr>
                                    <td><% Response.Write(n+1); %></td>
                                    <td>
                                        
                                        <a href="view_mantis.aspx?id=<%Response.Write(q.autonum); %>"  >View | </a>
                                        <a href="edit_mantis.aspx?id=<%Response.Write(q.autonum); %>" >Edit</a>
                                    </td>
                                    <td><% Response.Write(q.ticket_code); %></td>
                                    <td><% Response.Write(q.status); %></td>
                                    <td><% Response.Write(q.issue); %></td>
                                    
                                    <td><% Response.Write(q.branch); %></td>
                                    
                                    <td><% Response.Write(date); %></td>
                                    
                                    <td><% Response.Write(q.num_due_day); %></td>
                                    <td><% Response.Write(q.risk_level); %></td>                                                                        
                                </tr>

                        <% n = n + 1;
                            } %>                        
                    </tbody>
                </table>
                 
            </div>
        </div>
    </div>
</asp:Content>

