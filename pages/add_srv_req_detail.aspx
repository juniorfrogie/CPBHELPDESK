<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_srv_req_detail.aspx.cs" Inherits="pages_add_srv_req_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"> Add Service Request Detail</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Person Incharge</label>
                    <asp:DropDownList ID="ddlPid" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Action Planned</label>                    
                    <asp:DropDownList ID="txtActionPlanned" CssClass="form-control" runat="server">
                        <asp:ListItem>Choose One</asp:ListItem>
                        <asp:ListItem>Solution</asp:ListItem>
                        <asp:ListItem>Execution and Coding</asp:ListItem>
                        <asp:ListItem>Unit Test (IT Test)</asp:ListItem>
                        <asp:ListItem>UAT and Defect support</asp:ListItem>
                        <asp:ListItem>Sign Off &amp; Change Request to Production</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Status</label>
                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                        <asp:ListItem>Choose One</asp:ListItem>
                        <asp:ListItem>Open</asp:ListItem>
                        <asp:ListItem>Complete</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Canceled</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Man Days</label>
                    <asp:TextBox ID="txtManDays" CssClass="form-control" placeholder="Enter your Action Planned here..." runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Planned Start Date</label>
                    <input type="text" id="txtPlannedStartDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Planned Complete Date</label>
                    <input type="text" id="txtPlannedCompleteDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Complete Percent</label>
                    <asp:TextBox ID="txtCompetePercent" CssClass="form-control" placeholder="Please enter complete percent here..." runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <div class="form-group">
                    <label>Remark</label>
                    <asp:TextBox ID="txtRemark" CssClass="form-control" placeholder="Please enter your remark here..." runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row" style="margin-bottom:20px;">
            <div class="col-lg-5">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" Visible="false" OnClick="btnUpdate_Click" />
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </div>  
     
</asp:Content>

