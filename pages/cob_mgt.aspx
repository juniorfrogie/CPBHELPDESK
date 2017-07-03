<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cob_mgt.aspx.cs" Inherits="pages_cob_mgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="HeaderStypeTitle">
	            Cut of Business Management
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-7">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
            <div class="col-lg-3">
                <div class="row">
                    <div class="col-lg-12">
                    <div class="input-group">
                      <input type="text" id="txtReportDate" class="form-control" placeholder="Filter By Date..." runat="server"/>
                      <span class="input-group-btn">                        
                          <asp:Button ID="btnFilter" runat="server" Text="Go!" CssClass="btn btn-default" OnClick="btnFilter_Click" />
                      </span>
                    </div><!-- /input-group -->
                  </div><!-- /.col-lg-6 -->
                </div>                
                                
            </div>
        </div>
        <div class="row">
            <div class="col-lg-10">
                <table class="table table-striped">
                    <thead>
                        <tr>                            
                            <th>Items</th>
                            <th>Start Time</th>
                            <th>End Time</th>
                            <th>Status</th>
                            <th>Submit Date</th>                            
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            DataClassesDataContext dc = new DataClassesDataContext();
                            var query = from q in dc.tblSysDatas
                                        where q.key_type == "COB"
                                        select q;
                            if (Request["src"] != null && Request["src"]!="")
                            {
                                query = from q in dc.tblSysDatas
                                        where q.key_type == "COB" && q.key_desc == Request["src"].ToString()
                                        select q;
                            }
                            int i = 0;
                            foreach (var q in query)
                            {                            
                             %>
                        <tr>                            
                            <td><%Response.Write(q.user_updt); %></td>
                            <td><%Response.Write(q.key_data); %></td>
                            <td><%Response.Write(q.key_data1); %></td>
                            <td><%Response.Write(q.key_data2); %></td>
                            <td><%Response.Write(q.key_desc); %></td>                            
                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

