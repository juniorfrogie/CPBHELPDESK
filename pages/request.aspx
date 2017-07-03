<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="request.aspx.cs" Inherits="pages_request" %>

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
                                    <asp:Label ID="lblSR" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align:left;">
                                <td>Staff ID</td>
                                <td>
                                    <asp:DropDownList ID="ddlReqID" runat="server" Width="161" AutoPostBack="True" DataSourceID="LinqStaff" DataTextField="IDCard" DataValueField="IDCard" OnSelectedIndexChanged="ddlReqID_SelectedIndexChanged" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                    <asp:LinqDataSource ID="LinqStaff" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" Select="new (IDCard)" TableName="tblStaffinfos">
                                    </asp:LinqDataSource>
                                </td>
                                <td>Latin Name</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                                 <td>Khmer Name</td>
                                <td>
                                    <asp:TextBox ID="txtKhName" runat="server" Enabled="false"></asp:TextBox>
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
                                <td>Employee Status</td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem Value="0">New</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1">Existing</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>Date Create</td>
                                <td>
                                    <asp:TextBox ID="datetimepicker1" runat="server" ReadOnly="true" BackColor="#EAEAEA"></asp:TextBox>
                                </td>
                                <td>Email</td>
                                <td>
                                    <%--<asp:TextBox ID="txtEmail" runat="server" Enabled="false"></asp:TextBox>--%>
                                    <asp:Label ID="txtEmail" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>                            
                            
                        </table>                                                
                          </div>
                        </div>     
                        
                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Service Required (For T24 Sign-On User Only)</h3>
                          </div>
                          <div class="panel-body">
                            <table>
                                <tr>
                                    <td>T24 ID</td>
                                    <td>
                                        <asp:DropDownList ID="ddlPosition" runat="server" style="margin-left:83px;"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                          </div>
                        </div>

                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Solution Team</h3>
                          </div>
                          <div class="panel-body">                            
                            <div>
                                <table style="width:100%;text-align:left;height:131px;">                                    
                                    <tr>
                                        <td width="150">T24 System Web App</td>
                                        <td>
                                            <asp:DropDownList ID="ddlT24" runat="server">
                                                <asp:ListItem>Add</asp:ListItem>
                                                <asp:ListItem>Delete</asp:ListItem>
                                                <asp:ListItem>Modify</asp:ListItem>
                                                <%--<asp:ListItem>Unlock</asp:ListItem>--%>
                                                <asp:ListItem>Reset Password</asp:ListItem>
                                                <asp:ListItem>Disable</asp:ListItem>
                                                <asp:ListItem>Enable</asp:ListItem>
                                                <asp:ListItem Selected="True">Not</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:250px;">Purpose/Additional Information</td>
                                        <td>
                                            <asp:TextBox ID="txtT24Desc" runat="server" Rows="1" style="width:100%;" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>           
                                     <tr>
                                        <td width="100">Internal Web App</td>
                                        <td>
                                            <asp:DropDownList ID="ddlInternal" runat="server">
                                                <asp:ListItem>Add</asp:ListItem>
                                                <asp:ListItem>Delete</asp:ListItem>
                                                <asp:ListItem>Modify</asp:ListItem>
                                                <%--<asp:ListItem>Unlock</asp:ListItem>--%>
                                                <asp:ListItem>Reset Password</asp:ListItem>
                                                <asp:ListItem>Disable</asp:ListItem>
                                                <asp:ListItem>Enable</asp:ListItem>
                                                <asp:ListItem Selected="True">Not</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Purpose/Additional Information</td>
                                        <td>
                                            <asp:TextBox ID="txtInternalDesc" runat="server" style="width:100%;" Rows="1" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td width="100">CP Stock Web App</td>
                                        <td>
                                            <asp:DropDownList ID="ddlStock" runat="server">
                                                <asp:ListItem>Add</asp:ListItem>
                                                <asp:ListItem>Delete</asp:ListItem>
                                                <asp:ListItem>Modify</asp:ListItem>
                                                <%--<asp:ListItem>Unlock</asp:ListItem>--%>
                                                <asp:ListItem>Reset Password</asp:ListItem>
                                                <asp:ListItem>Disable</asp:ListItem>
                                                <asp:ListItem>Enable</asp:ListItem>
                                                <asp:ListItem Selected="True">Not</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Purpose/Additional Information</td>
                                        <td>
                                            <asp:TextBox ID="txtStockDesc" runat="server" Rows="1" style="width:100%;" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>                             
                                </table>
                            </div>                            
                          </div>
                        </div>

                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Infra Team</h3>
                          </div>
                          <div class="panel-body">                            
                            <div>
                                <table style="width:100%;text-align:left;height:131px;">                                    
                                    <tr>
                                        <td width="150">Windows & Mail</td>
                                        <td>
                                            <asp:DropDownList ID="ddlWindow" runat="server">
                                                <asp:ListItem>Add</asp:ListItem>
                                                <asp:ListItem>Delete</asp:ListItem>
                                                <asp:ListItem>Modify</asp:ListItem>
                                                <%--<asp:ListItem>Unlock</asp:ListItem>--%>
                                                <asp:ListItem>Reset Password</asp:ListItem>
                                                <asp:ListItem>Disable</asp:ListItem>
                                                <asp:ListItem>Enable</asp:ListItem>
                                                <asp:ListItem Selected="True">Not</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:250px;">Purpose/Additional Information</td>
                                        <td>
                                            <asp:TextBox ID="txtWindowDesc" runat="server" Rows="1" style="width:100%;" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>           
                                     <tr>
                                        <td width="100">Internet</td>
                                        <td>
                                            <asp:DropDownList ID="ddlInternet" runat="server">
                                                <asp:ListItem>Add</asp:ListItem>
                                                <asp:ListItem>Delete</asp:ListItem>
                                                <asp:ListItem>Modify</asp:ListItem>
                                                <%--<asp:ListItem>Unlock</asp:ListItem>--%>
                                                <asp:ListItem>Reset Password</asp:ListItem>
                                                <asp:ListItem>Disable</asp:ListItem>
                                                <asp:ListItem>Enable</asp:ListItem>
                                                <asp:ListItem Selected="True">Not</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Purpose/Additional Information</td>
                                        <td>
                                            <asp:TextBox ID="txtInternetDesc" runat="server" style="width:100%;" Rows="1" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                                          
                                </table>
                            </div>                            
                          </div>
                        </div>

                        <div class="panel panel-default">
                          <div class="panel-heading">
                            <h3 class="panel-title">Upload Files</h3>
                          </div>
                          <div class="panel-body">
                            <table>
                                <tr>
                                    <td>File Upload</td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left:81px;" />
                                    </td>
                                </tr>
                            </table>
                          </div>
                        </div>


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
                        </div>


                        <div style="text-align:right;">
                            <%if(Request["action"]==null || Request["action"]==""){ %>
                                <asp:Button ID="btnSubmit" class="btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click" />                
                            <%}
                              else if (Request["action"] == "certify")
                              {%>
                                <asp:Button ID="btnCertify" class="btn-default" runat="server" Text="Certify" OnClick="btnCertify_Click" />                
                            <%} %>
                            <%
                            else if(Request["action"]=="authorize"){
                                 %>
                            <asp:Button ID="btnAuthorize" class="btn-default" runat="server" Text="Authorize" OnClick="btnAuthorize_Click" />
                            <%} %>
                            <%else if(Request["action"]=="edit"){ %>
                                <asp:Button ID="btnEdit" class="btn-default" runat="server" Text="Update" OnClick="btnEdit_Click" />
                            <%} %>
                            <%else if(Request["action"]=="authorizeHIT"){ %>
                                <asp:Button ID="btnAuthHit" class="btn-default" runat="server" Text="Authorize" OnClick="btnAuthHit_Click" />
                            <%}
                              else if (Request["action"] == "pickup" && Request["ua"]!="Canceled" || Request["action"] == "view" && Request["ua"] != "Canceled")
                              { %>
                                <asp:Button ID="btnComplete" class="btn-default" runat="server" Text="Complete" OnClick="btnComplete_Click" />
                                <asp:Button ID="btnPickup" class="btn-default" runat="server" Text="Pickup" OnClick="btnPickup_Click"  />                            
                            <%} %>

                            <asp:Button ID="btnCancel" class="btn-default" runat="server" Text="Cancel" OnClick="btnCancel_Click" />                
                        </div>                        
                    </div>                    
                </div>
            </div>
        </div>
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
    </script>    
</asp:Content>

