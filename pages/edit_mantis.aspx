<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="edit_mantis.aspx.cs" Inherits="pages_edit_mantis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../datetimepicker/jquery.datetimepicker.css"/>
    <script src="../datetimepicker/jquery.js"></script>
    <script src="../datetimepicker/jquery.datetimepicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <h1 class="page-header" style="margin-left:20px;">Edit Issue Info</h1>
            <div class="col-lg-8">
                <div class="panel panel-default" style="margin-top:10px;">
                  <div class="panel-heading">
                    <h3 class="panel-title">Issue Info</h3>
                  </div>
                  <div class="panel-body">
                      <asp:HiddenField ID="txtHidden" runat="server" />
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
                            <input type="text" value="" id="datetimepicker" runat="server" class="form-control"/>
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
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>Medium</asp:ListItem>
                                <asp:ListItem>High</asp:ListItem>
                                <asp:ListItem>Critical</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Impact Assessment</label>
                            <asp:TextBox ID="txtImpactAssessment" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Target Date</label>
                            <input type="text" value="" id="datetimepicker2" runat="server" class="form-control"/>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputEmail1">Comment</label>
                            <textarea id="txtComment" runat="server" class="form-control" rows="5" placeholder="Comment here....."></textarea>
                          </div>
                          <div class="pull-right">
                              <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                          </div>                          
  
                  </div>
                </div>
            </div>
        </div>
    </div>    
    <script>
        $('#ContentPlaceHolder1_datetimepicker').datetimepicker({
            
            lang: 'en',
            timepicker: false,
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            
        });
        $('#ContentPlaceHolder1_datetimepicker2').datetimepicker({
            lang: 'en',
            timepicker: false,
            format: 'd/m/Y',
            formatDate: 'Y/m/d',            
        });
    </script>
</asp:Content>

