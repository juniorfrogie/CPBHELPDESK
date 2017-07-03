<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="issue_listing.aspx.cs" Inherits="pages_issue_listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 5px auto;">
    <div class="HeaderStypeTitle">
        ការបង្ហាញបញ្ជីសំណើរដែលទទួលបាន	<br />	
	            View Issue List

    </div>
<%-- List Take Leave --%>
    <div style="float: right; font-size: 15px; font-weight: bold; margin-bottom: 10px;">   
                
    </div>
      
        <style>
            .GridStyle1 {
                margin: 35px 0 5px 0;
                padding: 3px;
            }
        </style>      
       <div>

  <!-- Nav tabs -->           

          <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#request" aria-controls="home" role="tab" data-toggle="tab">Request</a></li>
            <li role="presentation"><a href="#incident" aria-controls="profile" role="tab" data-toggle="tab">Incident</a></li>

          </ul>

  <!-- Tab panes -->
  
  <div class="tab-content">
    <div role="tabpanel" class="tab-pane active" id="request">
        <div class="row" style="margin-top:20px;">                      
                      <div class="col-lg-4 col-lg-offset-1">
                        <div class="input-group">
                          <input type="text" id="txtSearch" name="txtSearch" runat="server" class="form-control" placeholder="Search by:Name, ID, Branch, Date,....">
                          <span class="input-group-btn">
                            <%--<button class="btn btn-default" type="button">Go!</button>--%>
                            <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Text="Go!" OnClick="btnSearch_Click" />
                          </span>
                        </div><!-- /input-group -->
                      </div><!-- /.col-lg-6 -->                     
           </div>
         <asp:GridView CssClass="GridStyle1" ID="gridReq" EmptyDataText="Data Not Found ... " runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="3" Font-Names="Calibri">
            <AlternatingRowStyle BackColor="#FFFFFF" />
               <Columns>
                   <asp:TemplateField HeaderText="No.">
                       <ItemTemplate>
                           <%# Container.DataItemIndex + 1 %>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="req_no" HeaderText="Serial No" />
                   <asp:BoundField DataField="requestor_id" HeaderText="Requestor" />
                   <asp:BoundField DataField="Name" HeaderText="Name" />
                   <asp:BoundField DataField="Location" HeaderText="Branch" />
                   <asp:BoundField DataField="category" HeaderText="Category" />
                   <asp:BoundField DataField="priority" HeaderText="Priority" Visible="False" />                                      
                   <asp:BoundField DataField="req_date" HeaderText="Request Date" DataFormatString="{0:dd/MM/yyyy}" />
                   <asp:BoundField DataField="response_by" HeaderText="Response By" />
                   <asp:BoundField DataField="open_date" HeaderText="Open Date" DataFormatString="{0:dd/MM/yyyy}" />
                   <asp:BoundField DataField="close_date" HeaderText="Close Date" DataFormatString="{0:dd/MM/yyyy}" />
                   <asp:BoundField DataField="user_action" HeaderText="User Action" />
                   <asp:TemplateField HeaderText="Action">
                       <ItemTemplate>   
                           <%if (!string.IsNullOrEmpty(Session["UserLogin"] as String)){ %>                           
                           <asp:HyperLink ID="HyperLink2" runat="server" text='<%# Convert.ToString(Eval("status"))=="Pending"?"View":"View" %>' NavigateUrl='<%# Convert.ToString(Eval("status")) =="Pending" || (Convert.ToString(Eval("status")) =="Processing" && Convert.ToString(Eval("response_by")).ToUpper() == Session["UserLogin"].ToString().ToUpper()) ? String.Concat("~/pages/request_new.aspx?id=", Eval("req_no"),"&action=pickup&ua=",Eval("user_action"),"&sid=",Eval("requestor_id")):String.Concat("~/pages/request_new.aspx?id=", Eval("req_no"),"&action=view&ua=",Eval("user_action"),"&sid=",Eval("requestor_id")) %>'></asp:HyperLink>
                           <%} %>
                       </ItemTemplate>                       
                   </asp:TemplateField>
                   <asp:BoundField DataField="pending_serv" HeaderText="Pending Services" />
               </Columns>
            <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#d9d9d9" />
        </asp:GridView>  
    </div>
    <div role="tabpanel" class="tab-pane" id="incident">
        <div class="row" style="margin-top:20px;">                      
                      <div class="col-lg-4 col-lg-offset-1">
                        <div class="input-group">
                          <input type="text" id="txtSearch2" name="txtSearch" runat="server" class="form-control" placeholder="Search by:Name, ID, Branch, Date,....">
                          <span class="input-group-btn">
                            <%--<button class="btn btn-default" type="button">Go!</button>--%>
                            <asp:Button ID="btnSearch2" CssClass="btn btn-default" runat="server" Text="Go!" OnClick="btnSearch2_Click" />
                          </span>
                        </div><!-- /input-group -->
                      </div><!-- /.col-lg-6 -->                     
         </div>

        <asp:GridView CssClass="GridStyle1" ID="gridInc" EmptyDataText="Data Not Found ... " runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="3" Font-Names="Calibri">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>                
                <asp:BoundField DataField="no" HeaderText="Incident No." DataFormatString="{0:000000}" >
                </asp:BoundField>
                <asp:BoundField DataField="initiator_id" HeaderText="Submitted by" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                
                <asp:BoundField DataField="branch" HeaderText="Branch">
                </asp:BoundField>
                <asp:BoundField DataField="priority" HeaderText="Priority" ItemStyle-Width="79px" >
<ItemStyle Width="79px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="catID_lvl1" HeaderText="Category" />
                <asp:BoundField DataField="submit_date" HeaderText="Date Submit" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="response_by" HeaderText="Response by" />
                <asp:BoundField DataField="open_date" HeaderText="Date Open" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="close_date" HeaderText="Date Close" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                         <%if (!string.IsNullOrEmpty(Session["UserLogin"] as String)){ %>                       
                           <asp:HyperLink ID="HyperLink2" runat="server" text='<%# Convert.ToString(Eval("status"))=="Pending"?"View":"View" %>' NavigateUrl='<%# Convert.ToString(Eval("status")) =="Pending" || (Convert.ToString(Eval("status")) =="Processing" && Convert.ToString(Eval("response_by")) == Session["UserLogin"].ToString()) ? String.Concat("~/pages/incident.aspx?id=", string.Format("{0:000000}",Eval("no")),"&action=pickup"):String.Concat("~/pages/incident.aspx?id=", string.Format("{0:000000}",Eval("no")),"&action=view") %>'></asp:HyperLink>
                           <%} %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#999999" />
        </asp:GridView>           
    </div>
  </div>   


</div>
           
</div>    
<link rel="stylesheet" type="text/css" href="../js/datetimepicker/jquery.datetimepicker.css" />
    <script src="../js/datetimepicker/jquery.js"></script>    
    <script src="../js/datetimepicker/jquery.datetimepicker.js"></script>    
    <script type="text/javascript">         
        jQuery('#ContentPlaceHolder1_datetimepicker1').datetimepicker({ timepicker: false });
        jQuery('#ContentPlaceHolder1_datetimepicker2').datetimepicker({ timepicker: false });
    </script>     
</asp:Content>

