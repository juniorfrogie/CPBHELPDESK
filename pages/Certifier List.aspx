<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Certifier List.aspx.cs" Inherits="Certifier_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 5px auto;">
    <div class="HeaderStypeTitle">
        ការបង្ហាញបញ្ជីឈ្មោះអ្នកត្រួតពិនិត្យសំណើរ	<br />	
	            View List Certifier	

    </div>
<%-- List Take Leave --%>
    <div style="float: right; font-size: 15px; font-weight: bold; margin-bottom: 10px;">   
        Choose Branch :  <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" >
                            <asp:ListItem Text="----Choose One----" Value=""></asp:ListItem>
                         </asp:DropDownList>
        Staff Name : <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="cmdSearch" runat="server" Text="Search" />
    </div>
      
        <style>
            .GridStyle1 {
                margin: 35px 0 5px 0;
                padding: 3px;
            }
        </style>
        <asp:GridView CssClass="GridStyle1" ID="GridView1" EmptyDataText="Data Not Found ... " runat="server" Width="100%"  AutoGenerateColumns="False" CellPadding="3" Font-Names="Calibri">
            <AlternatingRowStyle BackColor="#FFFFFF" />
            <Columns>
                
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="req_no" HeaderText="Request No." ItemStyle-Width="29px">
                <HeaderStyle HorizontalAlign="Center" />
<ItemStyle Width="29px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="requestor_id" HeaderText="Staff ID" >
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="position" HeaderText="Position" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Location" HeaderText="Branch">
                </asp:BoundField>
                <asp:BoundField DataField="req_date" HeaderText="Request Date" ItemStyle-Width="79px" DataFormatString="{0:dd/MM/yyyy}" >
<ItemStyle Width="79px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Certify">
                     <ItemTemplate>
                         <% if (!string.IsNullOrEmpty(Session["UserLogin"] as String)) { %>    
                         <%--<asp:Label ID="Label2" runat="server" Text='<%# Convert.ToString(Eval("certifier")).ToUpper() %>'></asp:Label>
                         <asp:Label ID="Label3" runat="server" Text='<%# Session["UserLogin"].ToString().ToUpper() %>'></asp:Label>--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Convert.ToString(Eval("certify")) == "" ? "Pending" : "View" %>' NavigateUrl='<%# Convert.ToString(Eval("certifier")).ToUpper()==Session["UserLogin"].ToString().ToUpper()? String.Concat("~/pages/request_new.aspx?id=", Eval("req_no"),"&action=certify&sid=",Eval("requestor_id")):"" %>'><%# Convert.ToString(Eval("certify")) == null ? "certifier" : "" %></asp:HyperLink>
                         <% } %>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Authorize">
                     <ItemTemplate>
                        <% if (!string.IsNullOrEmpty(Session["UserLogin"] as String)) { %>                                                    
                         <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToString(Eval("authorize")) == null ? "View" : "Pending" %>'></asp:Label>
                         <% } %>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                     <ItemTemplate>
                       <% if (!string.IsNullOrEmpty(Session["UserLogin"] as String)) { %>                                                    
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Convert.ToString(Eval("certify")) == "" && Convert.ToString(Eval("approve")) == "" ? "Edit" : "" %>' NavigateUrl='<%# String.Concat("~/pages/request.aspx?id=", Eval("req_no"),"&action=edit") %>'><%# Convert.ToString(Eval("certify")) == null ? "certifier" : "" %></asp:HyperLink>                          
                         <% } %> 
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="certifier" HeaderText="Certifier" Visible="False" />
                <asp:BoundField DataField="approver" HeaderText="Authorizer" Visible="False" />
                <asp:BoundField DataField="authorizer" HeaderText="AuthorizeHIT" Visible="False" />
            </Columns>
            <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#d9d9d9" />
        </asp:GridView>
</div>
</asp:Content>