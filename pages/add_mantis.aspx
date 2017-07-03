<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_mantis.aspx.cs" Inherits="pages_add_mantis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <h1 class="page-header" style="margin-left:20px;">Add Issue Info</h1>
            <div class="col-lg-8">
                <div class="panel panel-default" style="margin-top:10px;">
                  <div class="panel-heading">
                    <h3 class="panel-title">Issue Info</h3>
                  </div>
                  <div class="panel-body">
                    
                          <div class="form-group">
                            <label for="exampleInputEmail1">Ticket Code</label>                            
                            <asp:TextBox ID="txtTicketCode" class="form-control" runat="server" placeholder="Ticket Code"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Mantis</label>
                            <asp:TextBox ID="txtMantis" class="form-control" runat="server" placeholder="Matis"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Issue</label>
                            <asp:TextBox ID="txtIssue" class="form-control" runat="server" placeholder="Issue"></asp:TextBox>
                          </div>                          
                          <div class="form-group">
                            <label for="exampleInputEmail1">Description</label>
                            <textarea id="txtDesc" class="form-control" rows="10" placeholder="Type issue description here...." runat="server"></textarea>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Branch</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Solution</label>
                            <textarea id="txtSolution" runat="server" class="form-control" rows="10" placeholder="Type the solution description here...."></textarea>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Issue Date</label>
                            <%--<asp:Calendar ID="issueDate" runat="server"></asp:Calendar>--%>
                            <input type="text" id="issueDate" class="form-control" placeholder="Click here to pick a date" runat="server" />
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Status</label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                <asp:ListItem>In Progress</asp:ListItem>
                                <asp:ListItem>Cancelled</asp:ListItem>
                                <asp:ListItem>Open</asp:ListItem>
                                <asp:ListItem>Communication</asp:ListItem>
                                <asp:ListItem>Pending Closure</asp:ListItem> 
                              </asp:DropDownList>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1"># of Due Day</label>
                            <asp:TextBox ID="txtNoDueDay" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Risk Level</label>
                            <asp:DropDownList ID="ddlRiskLevel" CssClass="form-control" runat="server">
                                <asp:ListItem>Low</asp:ListItem>
                                <asp:ListItem>Medium</asp:ListItem>
                                <asp:ListItem>High</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Impact Assessment</label>
                            <asp:TextBox ID="txtImpactAssessment" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Target Date</label>
                            <%--<asp:Calendar ID="targetDate" runat="server"></asp:Calendar>--%>
                            <input type="text" id="targetDate" class="form-control" placeholder="Click here to pick a date" runat="server" />
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Comment</label>
                            <textarea id="txtComment" runat="server" class="form-control" rows="5" placeholder="Comment here....."></textarea>
                          </div>
                          <div class="pull-right">
                              <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                          </div>                          
  
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

