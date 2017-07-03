<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="srv_req_mgt.aspx.cs" Inherits="pages_srv_req_mgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="row">
                <div class="col-lg-12">
                    <div class="alert alert-success alert-dismissible" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <strong>Congratulation!</strong> <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-lg-12">
                <div class="HeaderStypeTitle">
	                Service Request Management
                </div>
            </div>
        </div>
        <div class="row" style="margin-bottom:20px;">
            <div class="col-lg-7">
                
            </div>
            <div class="col-lg-3">
                <div class="row">
                    <div class="col-lg-12">
                    <div class="input-group">
                      <input type="text" id="txtReportDate" class="form-control" placeholder="Filter By Date..." runat="server"/>
                      <span class="input-group-btn">                        
                          <asp:Button ID="btnFilter" runat="server" Text="Go!" CssClass="btn btn-default"  />
                      </span>
                    </div><!-- /input-group -->
                  </div><!-- /.col-lg-6 -->
                </div>                
                                
            </div>
        </div>
        <div class="panel panel-primary">
          <div class="panel-heading">
            <h3 class="panel-title">Service Request</h3>
          </div>
          <div class="panel-body">
              <div class="row">
                  <div class="col-lg-12">
                      <asp:Button ID="btnAdd" runat="server" Text="Add Service Request" CssClass="btn btn-default" OnClick="btnAdd_Click"/>
                  </div>
              </div>
            <div class="row">
            <div class="col-lg-12" style="height:267px;overflow:scroll;">
                <table class="table table-striped" style="font-size:12px;">
                    <thead>
                        <tr>                            
                            <th>No.</th>
                            <th>Action</th>
                            <th>Service Code</th>
                            <th>Request Name</th>
                            <th>Request Type</th>
                            <th>Requestor</th>                            
                            <th>Request Date</th>
                            <th>Department</th>
<%--                            <th>Proposed Delivery Date</th>--%>
                            <th>Responsible</th>
                            <th>Status</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            DataClassesDataContext dc = new DataClassesDataContext();
                            var query = from q in dc.tblSR_Projects
                                        select q;
                            int i = 0;
                            foreach (var q in query)
                            {
                             %>
                       <tr>
                           <td>
                               <%if (Request["id"] != null && Request["id"].ToString() == q.No.ToString()) { Response.Write("<img src='../images/check.png' width='20'/>"); } else { Response.Write(i + 1); }  %>
                           </td>                            
                           <td><a href="add_service.aspx?id=<%Response.Write(q.No); %>">Edit</a>  <a href="srv_req_mgt.aspx?del=<%Response.Write(q.No); %>" onclick="return deleteService()">Delete</a></td>
                           <td><%Response.Write(q.ID); %></td> 
                           <td>
                                <a href="srv_req_mgt.aspx?id=<%Response.Write(q.No); %>"><%Response.Write(q.REQUEST_NAME); %></a>
                            </td>
                            
                           <td><%Response.Write(q.REQUEST_TYPE); %></td>
                            <td><%Response.Write(q.REQUESTOR); %></td>                            
                            <td><%Response.Write(string.Format("{0:dd/MM/yyyy}", q.REQUESTED_DATE)); %></td>
                            <td><%Response.Write(q.DEPARTMENT); %></td>
                            <%--<td><%Response.Write(string.Format("{0:dd/MM/yyyy}", q.PROPOSTED_DELIVERY)); %></td>--%>
                            <td><%Response.Write(q.RESPONSIBLE); %></td>
                            <td><%Response.Write(q.STATUS); %></td>                            
                       </tr>
                        <%i = i + 1;
                            } %>
                    </tbody>
                </table>
            </div>
        </div>
          </div>
        </div>


        <div class="panel panel-primary">
          <div class="panel-heading">
            <h3 class="panel-title">Service Request Detail</h3>
          </div>
          <div class="panel-body">
              <div class="row">
                  <div class="col-lg-12">
                      <asp:Button ID="btnAddDetail" runat="server" Text="Add Detail" CssClass="btn btn-default" OnClick="btnAddDetail_Click" />
                      <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                  </div>
              </div>
            <div class="row">
            <div class="col-lg-12" style="height:200px;overflow:scroll;">
                <table class="table table-striped" style="font-size:12px;">
                    <thead>
                        <tr>                            
                            <th>No.</th>
                            <th>Action</th>
                            <th>Percent Incharge</th>                            
                            <th>Status</th>
                            <th>Action Planned</th>                            
                            <th>Man Days</th>
                            <th>Planned Start Date</th>
                            <th>Planned Complete Date</th>
                            <th>Complete(%)</th>
                            <th>Remark</th>                            
                        </tr>
                    </thead>
                    <tbody>
                        <%                            
                            if (Request["id"] != null)
                            {
                                var query2 = from q in dc.tblSR_Project_Details
                                             where q.no.ToString() == Request["id"].ToString()
                                             select q;
                                int j = 0;
                                foreach (var q in query2)
                                {
                                                                                                        
                             %>
                                   <tr>
                                        <td><%Response.Write(j+1); %></td>
                                        <td><a href="add_srv_req_detail.aspx?ReqDetID=<%Response.Write(q.sr_det_id); %>">Edit</a> | <a href="srv_req_mgt.aspx?detID=<%Response.Write(q.sr_det_id); %>" onclick="return confirmDel()">Delete</a></td>
                                        <td><%Response.Write(q.pic); %></td>                            
                                        <td><%Response.Write(q.ind_status); %></td>
                                        <td><%Response.Write(q.action_planned); %></td>                            
                                        <td><%Response.Write(q.man_days); %></td>
                                        <td><%Response.Write(q.planned_start_date); %></td>
                                        <td><%Response.Write(q.planned_complete_date); %></td>
                                        <td><%Response.Write(q.complete_percent); %></td>
                                        <td><%Response.Write(q.remark); %></td>                            
                                   </tr>
                        <%j = j + 1;
                                }
                            }else
                            {
                                Response.Write("<tr><td>No data to display.</td></tr>");
                              
                            } %>                        
                    </tbody>
                </table>
                
            </div>
        </div>
          </div>
        </div>
        
    </div>
    <script>
        function deleteService() {
            var x = confirm("Are you sure you want to delete this service request?");
            return x;
        }
        function confirmDel() {
            var x = confirm("Are you sure you want to delete this service request detail?");
            return x;
        }
    </script>
</asp:Content>