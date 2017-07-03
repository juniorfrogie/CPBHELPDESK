<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="view_mantis.aspx.cs" Inherits="pages_view_mantis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Mantis Info</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="panel panel-default">
                  <div class="panel-body">
                    <div class="form-group">
                            <label for="exampleInputEmail1">Ticket Code</label>                            
                            <asp:TextBox ID="txtTicketCode" class="form-control" runat="server" placeholder="Ticket Code" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Mantis</label>
                            <asp:TextBox ID="txtMantis" class="form-control" runat="server" placeholder="Matis" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Issue</label>
                            <asp:TextBox ID="txtIssue" class="form-control" runat="server" placeholder="Issue" readonly></asp:TextBox>
                          </div>
                     <div class="form-group">
                            <label for="exampleInputEmail1">Description</label>
                            <textarea id="txtDesc" class="form-control" rows="20" placeholder="Type issue description here...." runat="server" readonly></textarea>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Branch</label>
                            <asp:TextBox ID="txtBranch" class="form-control" runat="server" placeholder="Branch" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Solution</label>
                            <textarea id="txtSolution" runat="server" class="form-control" rows="20" placeholder="Type the solution description here...." readonly></textarea>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Issue Date</label>
                            <asp:TextBox ID="txtIssueDate" class="form-control" runat="server" placeholder="Issue Date" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Status</label>
                            <asp:TextBox ID="txtStatus" class="form-control" runat="server" placeholder="Status" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1"># of Due Day</label>
                            <asp:TextBox ID="txtNoDueDay" runat="server" CssClass="form-control" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Risk Level</label>
                            <asp:TextBox ID="txtRiskLevel" class="form-control" runat="server" placeholder="Risk Level" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Impact Assessment</label>
                            <asp:TextBox ID="txtImpactAssessment" runat="server" CssClass="form-control" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Target Date</label>
                            <asp:TextBox ID="txtTargetDate" class="form-control" runat="server" placeholder="Target Date" readonly></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Comment</label>
                            <textarea id="txtComment" runat="server" class="form-control" rows="5" placeholder="Comment here....." readonly></textarea>
                          </div>                          
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

