<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_service.aspx.cs" Inherits="pages_add_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Add Service Request</h1>
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
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="row">
                <div class="col-lg-12">
                    <div class="alert alert-danger alert-dismissible" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <strong>Attention!</strong> <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </asp:Panel>
        
        <div class="row">
            <div class="col-lg-8">
                <div class="panel panel-default">
                  <div class="panel-heading">
                    <h3 class="panel-title">Service Request Info</h3>
                  </div>
                  <div class="panel-body">
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>ID</label>
                                  <asp:TextBox ID="txtID" CssClass="form-control" placeholder="Enter ID here..." runat="server"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Request Name</label>
                                  <asp:TextBox ID="txtReqName" CssClass="form-control" placeholder="Enter Request Name here..." runat="server" ></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Task Type</label>
                                  <asp:DropDownList ID="ddlTask" runat="server" CssClass="form-control"></asp:DropDownList>
                              </div>
                          </div>
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Add New Task Type</label>
                                 
                                    <div class="input-group">                                      
                                        <asp:TextBox ID="txtAddNewTaskType" CssClass="form-control"  placeholder="Enter new task type here..." runat="server"></asp:TextBox>
                                      <span class="input-group-btn">                                        
                                          <asp:Button ID="btnAddTaskType" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="btnAddTaskType_Click" />
                                      </span>
                                    </div><!-- /input-group -->
                                 
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Request Type</label>
                                  <asp:DropDownList ID="ddlReqType" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                              </div>
                          </div>
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Add New Request Type</label>
                                 
                                    <div class="input-group">                                      
                                        <asp:TextBox ID="txtAddNewReqType" CssClass="form-control"  placeholder="Enter new request type here..." runat="server"></asp:TextBox>
                                      <span class="input-group-btn">                                        
                                          <asp:Button ID="btnAddReqType" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="btnAddReqType_Click" />
                                      </span>
                                    </div><!-- /input-group -->
                                 
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Description</label>
                                  <asp:TextBox ID="txtDesc" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Enter your description here..." runat="server"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Requestor Name</label>
                                  <asp:DropDownList ID="ddlRequestor" CssClass="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>
                              </div>
                          </div>                          
                      </div>
                       <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Request Date</label>
                                  <input type="text" id="txtReportDate" class="form-control" placeholder="Click here to pick a date" runat="server" />
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Department</label>
                                  <asp:DropDownList ID="ddlDept" CssClass="form-control" runat="server"></asp:DropDownList>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Apply for</label>
                                  <asp:TextBox ID="txtApplyFor" runat="server" CssClass="form-control" placeholder="Enter Apply for here..."></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Proposed Delivery Date</label>
                                  <input type="text" id="txtProposedDeliDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Level Type</label>
                                  <asp:DropDownList ID="ddlLvlType" CssClass="form-control" runat="server"></asp:DropDownList>
                              </div>
                          </div>
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Add New Level Type</label>
                                 
                                    <div class="input-group">                                      
                                        <asp:TextBox ID="txtAddNewLvlType" CssClass="form-control"  placeholder="Enter new level type here..." runat="server"></asp:TextBox>
                                      <span class="input-group-btn">                                        
                                          <asp:Button ID="btnAddNewLvlType" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="btnAddNewLvlType_Click" />
                                      </span>
                                    </div><!-- /input-group -->
                                 
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Responsible</label>
                                  <asp:DropDownList ID="ddlResponse" CssClass="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>
                              </div>
                          </div>                          
                      </div>
                      <div class="row">
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Start Date</label>
                                  <input type="text" id="txtStartDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                              </div>
                          </div>
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>End Date</label>
                                  <input type="text" id="txtEndDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Status</label>
                                  <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                              </div>
                          </div>
                          <div class="col-lg-6">
                              <div class="form-group">
                                  <label>Add New Status</label>                                 
                                    <div class="input-group">                                      
                                        <asp:TextBox ID="txtNewStatus" CssClass="form-control"  placeholder="Enter new status here..." runat="server"></asp:TextBox>
                                      <span class="input-group-btn">                                        
                                          <asp:Button ID="btnAddNewStatus" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="btnAddNewStatus_Click" />
                                      </span>
                                    </div><!-- /input-group -->
                                 
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Number of day</label>
                                  <asp:TextBox ID="txtNumDay" CssClass="form-control" runat="server" placeholder="Enter Number of day here..."></asp:TextBox>
                              </div>
                          </div>
                      </div>

                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Closed Date</label>
                                  <input type="text" id="txtClosedDate" class="form-control" placeholder="Click here to pick a date" runat="server"/>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Remark</label>
                                  <asp:TextBox ID="txtRemark" CssClass="form-control" placeholder="Enter your remark here..." runat="server"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Comment</label>
                                  <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" placeholder="Enter your comment here..."></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Reason</label>
                                  <asp:TextBox ID="txtReason" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Enter your reason here..." runat="server"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <div class="form-group">
                                  <label>Percentage</label>
                                  <asp:TextBox ID="txtPercent" CssClass="form-control" placeholder="Enter percentage here..." runat="server"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-lg-12">
                              <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
                              <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" Visible="false" OnClick="btnUpdate_Click" />
                          </div>
                      </div>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

