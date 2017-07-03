<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="incident.aspx.cs" Inherits="pages_incident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../js/datetimepicker/jquery.datetimepicker.css"/ >
    <script src="../js/datetimepicker/jquery.js"></script>
    <script src="../js/datetimepicker/build/jquery.datetimepicker.full.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container" style="padding:20px;">
            <div class="row">                                
                <div class="col-lg-10">
                    <h2 style="text-align:center;">Online CPB User Incident Form</h2>                    
                    <div class="row" style="padding-left:20px;margin-top:20px;text-align:center;">
                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Requestor Info</h3>
                          </div>
                          <div class="panel-body">                              
                                <table style="width:100%;text-align:left;height:112px;">
                                    <tr>
                                        <td><strong>Incident SR</strong></td>
                                        <td>
                                            <asp:Label ID="IncID" runat="server" Font-Bold="True"></asp:Label>
                                            <asp:HiddenField ID="txtHidden" runat="server" />
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">Employee ID*:</td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlID" runat="server" AutoPostBack="True" style="width:161px;" OnSelectedIndexChanged="ddlID_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            Contact No.:
                                        </td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="txtContact" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Khmer Name:</td>
                                        <td>
                                            <asp:TextBox ID="txtKhmerName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <%--<td>
                                            Date*:
                                        </td>
                                        <td>                                            
                                            <input type="text" id="datetimepicker1" runat="server" Enabled="false" BackColor="#EAEAEA" />
                                        </td>--%>
                                        <td>
                                            Latin Name*:
                                        </td>
                                        <td>                                            
                                            <asp:TextBox ID="txtEngName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Position:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtPos" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            Department/Branch:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDep" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td>
                                            Date*:
                                        </td>
                                        <td colspan="3">                                            
                                            <input type="text" id="datetimepicker1" runat="server" Enabled="false" BackColor="#EAEAEA" />
                                        </td>
                                    </tr>
                                </table>                                  
                          </div>
                        </div>     
                        
                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Incident Detail</h3>
                          </div>
                          <div class="panel-body">
                            <table border="0" style="width:100%;text-align:left;height:264px;">
                                <tr>
                                    <td style="width:147px;">Category*:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCat" runat="server" style="width:161px;" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" AutoPostBack="true">                                            
                                        </asp:DropDownList>
                                    </td>
                                    <td>Subcategory 1*:</td>
                                    <td><asp:DropDownList ID="ddlSubCat1" runat="server" style="width:161px;" OnSelectedIndexChanged="ddlSubCat1_SelectedIndexChanged" AutoPostBack="true">                                            
                                        </asp:DropDownList>
                                    </td>
                                    <td>Subtcategory 2*:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSubCat2" runat="server" style="width:161px;" >                                            
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="6">Description:</td>                                    
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="txtDesc" TextMode="MultiLine" runat="server" Rows="10" style="width:100%;"></asp:TextBox>
                                    </td>                                    
                                </tr>
                            </table>
                            </div>                            
                          </div>
                        </div>

                    <%
                        if(Session["admin"]!=null){
                         %>
                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Response Person Info</h3>
                          </div>
                          <div class="panel-body">                            
                            <div>
                                <table border="0" style="width:100%;height:339px;">
                                    <tr>
                                        <td style="width:156px;">ID No.*</td>
                                        <td>
                                            <asp:DropDownList ID="ddlIT_ID" style="width:161px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIT_ID_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td>
                                            Latin Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Khmer Name:</td>
                                        <td>
                                            <asp:TextBox ID="txtNameKh" TextMode="SingleLine" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            Position:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtPosIT" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Priority Type:</td>
                                        <td>
                                            <asp:DropDownList ID="ddlPriority" runat="server" style="width:161px;">
                                                <asp:ListItem Selected="True">-Choose One-</asp:ListItem>
                                                <asp:ListItem>High</asp:ListItem>
                                                <asp:ListItem>Medium</asp:ListItem>
                                                <asp:ListItem>Low</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Request Status:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" style="width:161px;">
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Processing</asp:ListItem>
                                                <asp:ListItem>Complete</asp:ListItem>
                                                <asp:ListItem>Closed</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Solution Team:</td>
                                        <td>
                                            <asp:DropDownList ID="ddlTeam" runat="server" style="width:161px;">
                                                <asp:ListItem Selected="True">-Choose One-</asp:ListItem>
                                                <asp:ListItem>Infra</asp:ListItem>
                                                <asp:ListItem>Solution</asp:ListItem>
                                                <asp:ListItem>Infra &amp; Solution</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Closed Date:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="datetimepicker2" runat="server" ReadOnly="true" BackColor="#EAEAEA"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Root Cause*:</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtRootCause" TextMode="MultiLine" runat="server" Rows="5" style="width:100%;"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Solution*:</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtSolution" TextMode="MultiLine" runat="server" Rows="5" style="width:100%;"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Comment/Remark:</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtComment" TextMode="Singleline" runat="server" style="width:100%;"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>                            
                          </div>
                        </div>
                    <% }%>
                        

                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Upload Files</h3>
                          </div>
                          <div class="panel-body">
                              <%
                                  if (Request["action"] == null)
                                  {
                                  
                                   %>
                            <table>
                                <tr>
                                    <td>File Upload</td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left:81px;" />
                                    </td>
                                </tr>
                            </table>
                              <%}else{ %>

                              <asp:GridView ID="gvUpload" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Vertical">
                                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                  <Columns>
                                      <asp:TemplateField HeaderText="No.">
                                          <ItemTemplate>
                                              <%# Container.DataItemIndex + 1 %>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:BoundField DataField="attachment" HeaderText="Attachments" />
                                      <asp:TemplateField HeaderText="Action">
                                          <ItemTemplate>
                                              <asp:HyperLink ID="linkAction" runat="server" Text="Download"  NavigateUrl='<%# String.Concat("../Uploads/", Eval("attachment"))%>'></asp:HyperLink>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                  </Columns>
                                  <EditRowStyle BackColor="#999999" />
                                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                  <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                  <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                  <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                  <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                              </asp:GridView>

                              <%} %>
                          </div>
                        </div>


                         <%--<div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Line Manager</h3>
                          </div>
                          <div class="panel-body">                            
                            <div>
                                <table style="width:100%;text-align:left;height:131px;">                                    
                                    <tr>
                                        <td>Certifier</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCertifier" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td>Authorizer</td>
                                        <td>
                                            <asp:DropDownList ID="ddlAuthorize" runat="server" AutoPostBack="True"></asp:DropDownList>                                            
                                        </td>
                                    </tr>                                                                                               
                                </table>
                            </div>                            
                          </div>
                        </div>--%>


                        <div style="text-align:right;">
                            <%if(Request["action"]==null || Request["action"]==""){ %>
                                <asp:Button ID="btnSubmit" class="btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click" />                
                            <%}
                              else if (Request["action"] == "certify")
                              {%>
                            <%} %>
                            <%
                            else if(Request["action"]=="authorize"){
                                 %>
                            <%} %>
                            <%else if(Request["action"]=="edit"){ %>
                            <%} %>
                            <%else if(Request["action"]=="authorizeHIT"){ %>
                            <%}else if(Request["action"]=="pickup"){ %>                                
                                <asp:Button ID="btnPickup" class="btn-default" runat="server" Text="Pickup" OnClick="btnPickup_Click"   />
                            <%}else if(Request["action"]=="view"&&ddlStatus.SelectedValue!="Complete"){ %>
                                <asp:Button ID="btnComplete" class="btn-default" runat="server" Text="Complete" OnClick="btnComplete_Click"  />
                            <%} %>

                            <asp:Button ID="btnCancel" class="btn-default" runat="server" Text="Cancel" OnClick="btnCancel_Click" />                
                        </div>                        
                    </div>                    
                </div>
            </div>
        </div>
    <%
        if (Request["id"] != null)
        {
            string id = Request["id"];
            incidentByID(id);
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

        jQuery('#ContentPlaceHolder1_datetimepicker2').datetimepicker({
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
    </script>    
</asp:Content>

