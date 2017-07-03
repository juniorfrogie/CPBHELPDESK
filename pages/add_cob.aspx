<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_cob.aspx.cs" Inherits="pages_add_cob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-5">
                <h1 class="page-header">Add COB Info</h1>
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="row">
                <div class="col-lg-8">
                    <div class="alert alert-success alert-dismissible" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <strong>Congratulation!</strong> <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-lg-2">
                Create Date:
                <input type="text" id="txtReportDate" class="form-control" placeholder="Filter By Date..." runat="server" required/>
            </div>
        </div>
        <div class="row" style="margin-top:20px;">
            <div class="col-lg-8">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Items</th>
                            <th>Start Time</th>
                            <th>End Time</th>
                            <th>Status</th>                            
                        </tr>
                    </thead>
                    <tbody>
                        <tr>                            
                            <td>
                                <asp:Label ID="lblCob" runat="server" Text="Cut of Business(COB)"></asp:Label></td>
                            <td><asp:TextBox ID="txtStart1" runat="server" CssClass="form-control" placeholder="Start Time" required></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEnd1" runat="server" CssClass="form-control" placeholder="End Time" required></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="ddlstatus1" runat="server" CssClass="form-control">
                                    <asp:ListItem>OK</asp:ListItem>
                                    <asp:ListItem>Error</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>                            
                            <td>
                                <asp:Label ID="lblNBC" runat="server" Text="Upload NBC Report"></asp:Label></td>
                            <td><asp:TextBox ID="txtStart2" runat="server" CssClass="form-control" placeholder="Start Time" required></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEnd2" runat="server" CssClass="form-control" placeholder="End Time" required></asp:TextBox></td>
                            <td><asp:DropDownList ID="ddlStatus2" runat="server" CssClass="form-control">
                                    <asp:ListItem>OK</asp:ListItem>
                                    <asp:ListItem>Error</asp:ListItem>
                                </asp:DropDownList></td></td>
                        </tr>
                        <tr>                            
                            <td>
                                <asp:Label ID="lblSystemOnline" runat="server" Text="System Online"></asp:Label></td>
                            <td><asp:TextBox ID="txtStart3" runat="server" CssClass="form-control" placeholder="Start Time" required></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEnd3" runat="server" CssClass="form-control" placeholder="End Time" required></asp:TextBox></td>
                            <td><asp:DropDownList ID="ddlStatus3" runat="server" CssClass="form-control">
                                    <asp:ListItem>OK</asp:ListItem>
                                    <asp:ListItem>Error</asp:ListItem>
                                </asp:DropDownList></td></td>
                        </tr>
                        <tr>                            
                            <td>
                                <asp:Label ID="lblDailyGenerate" runat="server" Text="Daily Generate Report"></asp:Label></td>
                            <td><asp:TextBox ID="txtStart4" runat="server" CssClass="form-control" placeholder="Start Time" required></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEnd4" runat="server" CssClass="form-control" placeholder="End Time" required></asp:TextBox></td>
                            <td><asp:DropDownList ID="ddlStatus4" runat="server" CssClass="form-control">
                                    <asp:ListItem>OK</asp:ListItem>
                                    <asp:ListItem>Error</asp:ListItem>
                                </asp:DropDownList></td></td>
                        </tr>                        
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />                
            </div>
        </div>
    </div>
</asp:Content>

