<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_request_detail.aspx.cs" Inherits="pages_add_request_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header">
        <h2 style="margin-left:10px;">Add Request Detail</h2>
    </div>
    <div style="margin-left:20px;">        
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancel_Click"  />
        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <div class="col-lg-4" style="margin-top:15px;">
                                                  <div class="form-group">
                                                      <label class="pull-left">Access to System</label>
                                                      <asp:DropDownList ID="ddlAccess" runat="server" CssClass="form-control"></asp:DropDownList>
                                                  </div>
                                                                                                                                        
                                                    <div class="form-group">
                                                    <label class="pull-left">Request Action</label>
                                                    <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control" >
                                                        <asp:ListItem>Choose One</asp:ListItem>
                                                        <asp:ListItem>Add</asp:ListItem>
                                                        <asp:ListItem>Delete</asp:ListItem>
                                                        <asp:ListItem>Modify</asp:ListItem>
                                                        <asp:ListItem>Reset Password</asp:ListItem>
                                                        <asp:ListItem>Disable</asp:ListItem>
                                                        <asp:ListItem>Enable</asp:ListItem>
                                                        <asp:ListItem>Not</asp:ListItem>
                                                    </asp:DropDownList>                                                      
                                                    </div>
                                                                                            
                                                    <div class="form-group">
                                                      <label class="pull-left">Assign to Role</label>
                                                      <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                                                            
                                                    <div class="form-group">
                                                      <label class="pull-left">Purpose/Reason</label>
                                                        <asp:TextBox ID="txtPurpose" Rows="5" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="pull-left">Upload Files</label>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                                                    </div>
    </div>
</asp:Content>

