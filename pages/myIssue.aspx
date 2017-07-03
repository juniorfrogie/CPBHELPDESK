<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="myIssue.aspx.cs" Inherits="pages_myIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 5px auto;">
    <div class="HeaderStypeTitle">
        ការបង្ហាញបញ្ជីសំណើររបស់អ្នកប្រើប្រាស់	<br />	
	            View My Issue List

    </div>
<%-- List Take Leave --%>
    <div style="float: right; font-weight: bold; margin-bottom: 10px;">   
        Choose Branch :  <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"  >
                         </asp:DropDownList>
        <%--Staff ID : <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>--%>
        <asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-default" Text="Search" Visible="false" Font-Size="8pt" OnClick="cmdSearch_Click" />
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
        <asp:GridView CssClass="GridStyle1" ID="GridView1" EmptyDataText="Data Not Found ... " runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="3" Font-Names="Calibri" Font-Size="10pt">
            <AlternatingRowStyle BackColor="#FFFFFF" />
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="req_no" HeaderText="No." ItemStyle-Width="29px">
                <HeaderStyle HorizontalAlign="Center" />
<ItemStyle Width="29px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="requestor_id" HeaderText="Staff ID" >
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="Location" HeaderText="Branch">
                </asp:BoundField>
                <asp:BoundField DataField="req_date" HeaderText="Request Date" ItemStyle-Width="79px" DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle Width="79px"></ItemStyle>
                </asp:BoundField>                
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>                        
                        <%--<asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Convert.ToString(Eval("status"))=="Complete"?"Close Request | ":Convert.ToString(Eval("status"))=="Closed"?"":"Cancel | " %>' NavigateUrl='<%# Convert.ToString(Eval("status"))=="Complete"? String.Concat("~/pages/close.aspx?id=", Eval("req_no"),"&val=req"):(Convert.ToString(Eval("requestor_id"))==Session["sid"].ToString())? String.Concat("~/pages/cancel.aspx?id=", Eval("req_no"),"&val=req"):""%>'></asp:HyperLink>--%>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Convert.ToString(Eval("status"))=="Complete"?"Close Request | ":Convert.ToString(Eval("status"))=="Closed"?"":"Cancel | " %>' NavigateUrl='<%# Convert.ToString(Eval("status"))=="Complete"&&Convert.ToString(Eval("requestor_id"))==Session["sid"].ToString()? String.Concat("~/pages/close.aspx?id=", Eval("req_no"),"&val=req"):(Convert.ToString(Eval("requestor_id"))==Session["sid"].ToString())? String.Concat("~/pages/cancel.aspx?id=", Eval("req_no"),"&val=req"):""%>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Convert.ToString(Eval("status"))=="Complete"?"View":"View" %>' NavigateUrl='<%# Convert.ToString(Eval("requestor_id"))==Session["sid"].ToString()?String.Concat("~/pages/request_new.aspx?id=", Eval("req_no"),"&action=view&ua=Canceled&sid=",Eval("requestor_id")):""%>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#d9d9d9" />
        </asp:GridView>
    </div>
    <div role="tabpanel" class="tab-pane" id="incident">
      <asp:GridView ID="GridView2" runat="server" CssClass="GridStyle1" EmptyDataText="Data Not Found ... " Width="100%" AutoGenerateColumns="False" CellPadding="3" Font-Names="Calibri" Font-Size="10pt">
        <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>

                <asp:BoundField DataField="inc_no" HeaderText="ID" />
                <asp:BoundField DataField="initiator_id" HeaderText="Staff ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="branch" HeaderText="Branch" />
                <asp:BoundField DataField="submit_date" HeaderText="Submit Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="response_by" HeaderText="Response By" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Convert.ToString(Eval("status"))=="Complete"?"Close Request |":Convert.ToString(Eval("status"))=="Closed"?"":"Cancel |" %>' NavigateUrl='<%# Convert.ToString(Eval("status"))=="Complete"? String.Concat("~/pages/close.aspx?id=", Eval("inc_no"),"&val=inc"):String.Concat("~/pages/cancel.aspx?id=", Eval("inc_no"),"&val=inc")%>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Convert.ToString(Eval("status"))=="Complete"?"View":"View" %>' NavigateUrl='<%# String.Concat("~/pages/incident.aspx?id=", Eval("inc_no"),"&action=view&ua=Canceled")%>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#999999" />
    </asp:GridView>  
    </div>    
  </div>



<!-- Button trigger modal -->
<%--<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Launch demo modal
</button>--%>

</div>        
</div>    
</asp:Content>

