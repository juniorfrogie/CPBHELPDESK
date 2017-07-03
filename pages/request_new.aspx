<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="request_new.aspx.cs" Inherits="pages_request_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../js/datetimepicker/jquery.datetimepicker.css"/ >
    <script src="../js/datetimepicker/jquery.js"></script>
    <script src="../js/datetimepicker/build/jquery.datetimepicker.full.min.js"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div class="container" style="padding:20px;">
            <div class="row">                                
                <div class="col-lg-10">
                    <h2 style="text-align:center;">Online CPB User Access Form</h2>                    
                    <div class="row" style="padding-left:20px;margin-top:20px;text-align:center;">
                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Requestor Info</h3>
                          </div>
                          <div class="panel-body">                              
                            <table style="height:165px;width:100%;">
                            <tr style="text-align:left;">
                                <td>
                                    <strong>SR Number:</strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblSR" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="lblHidden" runat="server" Text="" Font-Bold="true" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align:left;">
                                <td>Employee ID</td>
                                <td>
                                    <asp:DropDownList ID="ddlReqID" runat="server" Width="161" AutoPostBack="True" DataSourceID="LinqStaff" DataTextField="IDCard" DataValueField="IDCard"  AppendDataBoundItems="True" OnSelectedIndexChanged="ddlReqID_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:LinqDataSource ID="LinqStaff" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" Select="new (IDCard)" TableName="tblStaffinfos">
                                    </asp:LinqDataSource>
                                </td>
                                <td>Latin Name</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" readonly="true"></asp:TextBox>
                                </td>
                                 <td>Khmer Name</td>
                                <td>
                                    <asp:TextBox ID="txtKhName" runat="server" readonly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="text-align:left;">
                                <td>
                                    Position
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPos" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                                <td>Department/Branch</td>
                                <td>
                                    <asp:TextBox ID="txtDept" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                                <td>Tel</td>
                                <td>
                                    <asp:TextBox ID="txtTel" runat="server" Enabled="false" ></asp:TextBox>
                                </td>
                            </tr>
                           
                            <tr style="text-align:left;">                                
                                <%--<td>Employee Status</td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                                        <asp:ListItem Value="0">New</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1">Existing</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>--%>
                                <td>Date Create</td>
                                <td>
                                    <asp:TextBox ID="datetimepicker1" runat="server" ReadOnly="true" BackColor="#EAEAEA"></asp:TextBox>
                                </td>
                                <td>Email</td>
                                <td>
                                    <%--<asp:TextBox ID="txtEmail" runat="server" Enabled="false"></asp:TextBox>--%>
                                    <asp:Label ID="txtEmail" runat="server" Text=""></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>                            
                            
                        </table>                                                
                          </div>
                        </div>                                                    

                        <div class="panel panel-default">
                          <!-- Default panel contents -->
                          <div class="panel-heading"><h3 class="panel-title">Service Detail</h3></div>
                          <div class="panel-body">                                                        
                            <div class="col-lg-12">
                                <div class="pull-left">                                    
                                    <%--<button type="button" disabled="disabled" class="btn btn-default" data-toggle="modal" data-target="#myModal" id="btnAdd" runat="server">
                                      Add
                                    </button>   --%>      
                                    <asp:Button ID="btnAdd" Enabled="false" CssClass="btn btn-primary" runat="server" Text="Add Request" OnClick="btnAdd_Click" />                                    
                                </div>                                                               
                            </div>
                            <div class="col-lg-12" style="margin-top:20px;">
                                <div>

                                  <!-- Nav tabs -->
                                  <ul class="nav nav-tabs" role="tablist">
                                    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Current Request Detail</a></li>
                                    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">History</a></li>                                    
                                  </ul>

                                  <!-- Tab panes -->
                                  <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="home">
                                        <asp:HiddenField ID="txtHidden" runat="server" />                                              
                                        <asp:GridView ID="GridView1" runat="server" border="0" CssClass="table table-striped" AutoGenerateColumns="False" EmpyDataText="No Service Detail Found" style="margin-top:20px;" DataKeyNames="autonum" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >                                                
                                                <Columns>                                                
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>                                                                                                                             
                                                        <%if (Request["action"] != "addTmpReq" && Request["action"] != "certify" && Request["action"] != "authorize" && Request["action"] != "authorizeHIT" && Request["action"]!="view" && Request["ua"]!="canceled")
                                                          { %>
                                                            <asp:HyperLink ID="Pickup" runat="server" NavigateUrl='<%# string.Concat("request_new.aspx?id="+txtHidden.Value+"&action=Userpickup&sid="+Request["sid"]+"&auto="+Eval("autonum")) %>' Text='<%#(Eval("response_by").ToString()!="N/A"?"":"Pickup") %>'></asp:HyperLink>
                                                        <%}else if(Request["action"]=="addTmpReq"){ %>
                                                            <asp:HyperLink ID="Edit" runat="server" NavigateUrl='<%# string.Concat("edit_req_detail.aspx?id=",Eval("autonum"),"&reqID=",lblSR.Text,"&sid=",Request["sid"]) %>' Text='<%#(Request["ua"]=="Canceled" ||Request["action"]=="authorize"||Request["action"]=="certify"||Request["action"]=="authorizeHIT"||Request["action"]=="pickup"|| Request["ua"]=="Processing"||Eval("status").ToString()=="Pending"&&Request["action"].ToString()!="addTmpReq"||Request["action"].ToString()=="Userpickup"?"":"Edit |") %>'></asp:HyperLink>
                                                            <asp:HyperLink ID="Delete" runat="server" NavigateUrl='<%# string.Concat("delete_req_detail.aspx?id=",Eval("autonum"),"&reqID=",lblSR.Text,"&sid=",Request["sid"]) %>' Text='<%#(Request["ua"]=="Canceled" ||Request["action"]=="authorize"||Request["action"]=="certify"||Request["action"]=="authorizeHIT"||Request["action"]=="pickup"|| Request["ua"]=="Processing"||Eval("status").ToString()=="Pending"&&Request["action"].ToString()!="addTmpReq"||Request["action"].ToString()=="Userpickup"?"":" Delete") %>'></asp:HyperLink>
                                                        <%} %>
                                                    </ItemTemplate>
                                                                                                        
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RowNumber">   
                                                     <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>   
                                                     </ItemTemplate>
                                                 </asp:TemplateField>                                                
                                                <asp:BoundField HeaderText="Request Action" DataField="action" />
                                                <asp:BoundField HeaderText="Access to System" DataField="system" />
                                                <asp:BoundField HeaderText="Assign to Role" DataField="role" />
                                                <asp:BoundField HeaderText="Purpose/Reason" DataField="purpose" />
                                                <asp:BoundField DataField="autonum" HeaderText="autonum" Visible="False" />
                                                <asp:BoundField DataField="progress" HeaderText="Progress" Visible="False"  />                                                
                                                <asp:BoundField DataField="response_by" HeaderText="Response By" Visible="False" />                                                
                                                    <asp:BoundField DataField="status" HeaderText="status" Visible="false" />
                                            </Columns>
                                        </asp:GridView>                                      

                                        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataClassesDataContext" EnableDelete="True" EntityTypeName="" TableName="tblTmpReqDetails">
                                        </asp:LinqDataSource>                                        

                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="profile">
                                        <asp:GridView ID="GridView2" runat="server" border="0" CssClass="table table-striped" EmptyDataText="No Service Detail Found" style="margin-top:20px;" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="RowNumber">   
                                                     <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>   
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="action" HeaderText="Request Action" />
                                                <asp:BoundField DataField="system" HeaderText="Access to System" />
                                                <asp:BoundField DataField="role" HeaderText="Assign to Role" />
                                                <asp:BoundField DataField="purpose" HeaderText="Purpose/Justification" />
                                                
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    
                                  </div>

                                </div>                                


                            </div>
                          </div>                         
                        </div>

                        <asp:Panel ID="pnlUpload" runat="server">
                            <div class="panel panel-default">
                              <div class="panel-heading">
                                <h3 class="panel-title">Attached File</h3>
                              </div>
                              <div class="panel-body">
                                   <table class="table table-bordered">
                                        <tr>
                                            <th>#</th>
                                            <th>Attachment</th>                                            
                                            <th>Action</th>
                                        </tr>
                                       <%
                                           DataClassesDataContext dc = new DataClassesDataContext();
                                           var attach = from a in dc.tblUploads
                                                        where a.ReqNo == lblSR.Text
                                                        select a;
                                           int i=1;
                                           foreach (var a in attach)
                                           {
                                               Response.Write("<tr>");
                                               Response.Write("<td>"+i+"</td>");
                                               Response.Write("<td>"+a.attachment+"</td>");                                               
                                               Response.Write("<td><a href='../Uploads/"+a.attachment+"'>Download</a></td>");
                                               Response.Write("</tr>");
                                               i = i+1;
                                           }
                                            %>

                                   </table>
                              </div>
                            </div>                        
                        </asp:Panel>                            

                         <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Line Manager</h3>
                          </div>
                          <div class="panel-body">                            
                            <div>
                                <table style="width:100%;text-align:left;height:131px;">                                    
                                    <tr>
                                        <td>Certifier</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCertifier" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>Authorizer</td>
                                        <td>
                                            <asp:DropDownList ID="ddlAuthorize" runat="server"></asp:DropDownList>                                            
                                        </td>
                                    </tr>                                                                                               
                                </table>
                            </div>                            
                          </div>
                        </div>


                        <div style="text-align:right;">
                            <%if (Request["action"] == null || Request["action"] == "" || Request["action"] == "addTmpReq")
                              { %>
                                <asp:Button ID="btnSubmit" class="btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />                
                            <%}
                              else if (Request["action"] == "certify")
                              {%>
                                <asp:Button ID="btnCertify" class="btn-default" runat="server" Text="Certify" OnClick="btnCertify_Click"/>                
                            <%} %>
                            <%
                            else if(Request["action"]=="authorize"){
                                 %>
                            <asp:Button ID="btnAuthorize" class="btn-default" runat="server" Text="Approve" OnClick="btnAuthorize_Click" />
                            <%} %>
                            <%else if(Request["action"]=="edit"){ %>
                                <asp:Button ID="btnEdit" class="btn-default" runat="server" Text="Update"  />
                            <%} %>
                            <%else if(Request["action"]=="authorizeHIT"){ %>
                                <asp:Button ID="btnAuthHit" class="btn-default" runat="server" Text="Authorize" OnClick="btnAuthHit_Click" />
                            <%}%>
                             <asp:Button ID="btnComplete" class="btn-default" runat="server" Text="Complete" Visible="false" OnClick="btnComplete_Click" />
                            <asp:Button ID="btnCancel" class="btn-default" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>                
                        </div>                        
                    </div>                    
                </div>
            </div>
        </div>    
    <%
        if (Request["id"] != null && Request["action"]=="view")
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var request = from r in dc.tblRequests
                          where r.req_no.ToString() == Request["id"]
                          select r;
            foreach (var r in request)
            {
                ddlReqID.SelectedValue = r.requestor_id;
            }
        }
         %>
    <script>       
        //jQuery.datetimepicker.setLocale('de');

        jQuery('#ContentPlaceHolder1_datetimepicker1').datetimepicker({
            i18n: {
                de: {
                    months: [
                     'January', 'February', 'March', 'April',
                     'May', 'June', 'July', 'August',
                     'September', 'October', 'November', 'December',
                    ],

                }
            },
            timepicker: false,
            format: 'd.m.Y'
        });
        function pickUp() {
            window.location.assign('../default.aspx');
        }
    </script>        

    
</asp:Content>

