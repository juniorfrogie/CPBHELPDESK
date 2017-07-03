using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_add_service : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    string newTaskType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                loadTaskType();
                loadReqType();
                loadStaffInfo();
                loadDepartment();
                loadLevelType();
                loadStatus();
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    loadServiceReq(Request["id"].ToString());
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }                             
            }        
        }
        catch (Exception)
        {            
            throw;
        }        
    }
    protected void loadServiceReq(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            try
            {
                var query = from q in dc.tblSR_Projects
                            where q.No.ToString() == id
                            select q;
                foreach (var q in query)
                {
                    txtID.Text = q.ID;
                    txtReqName.Text = q.REQUEST_NAME;
                    ddlTask.SelectedValue = q.TASK_TYPE;
                    ddlReqType.SelectedValue = q.REQUEST_TYPE;
                    txtDesc.Text = q.DESCRIPTION;
                    ddlRequestor.SelectedValue = q.REQUESTOR;
                    txtReportDate.Value = string.Format("{0:dd/MM/yyyy}", q.REQUESTED_DATE);
                    ddlDept.SelectedValue = q.DEPARTMENT;
                    txtApplyFor.Text = q.APPLY_FOR;
                    txtProposedDeliDate.Value = string.Format("{0:dd/MM/yyyy}",q.PROPOSTED_DELIVERY.ToString());
                    ddlLvlType.SelectedValue = q.LEVEL_TYPE;
                    ddlResponse.SelectedValue = q.RESPONSIBLE;
                    txtStartDate.Value = string.Format("{0:dd/MM/yyyy}", q.START_DATE.ToString());
                    txtEndDate.Value = string.Format("{0:dd/MM/yyyy}", q.END_DATE.ToString());
                    ddlStatus.SelectedValue = q.STATUS;
                    txtNumDay.Text = q.NUMBER_DAY.ToString();
                    txtClosedDate.Value = string.Format("{0:dd/MM/yyyy}", q.CLOSED_DATE.ToString());
                    txtRemark.Text = q.REMARK;
                    txtComment.Text = q.COMMEND;
                    txtReason.Text = q.REASON;
                    txtPercent.Text = q.PERCENTAGE;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;           
            }
            
        }
    }
    protected void loadStaffInfo()
    {
        var query = (from q in dc.tblStaffinfos
                    select q).Distinct();
        query = query.OrderBy(x => x.Name);
        ddlRequestor.DataSource = query;
        ddlRequestor.DataTextField = "Name";
        ddlRequestor.DataValueField = "Name";
        ddlRequestor.DataBind();

        ddlResponse.DataSource = query;
        query = query.OrderBy(x=>x.Name);
        ddlResponse.DataTextField = "Name";
        ddlResponse.DataValueField = "Name";
        ddlResponse.DataBind();

        addDropdownlistDefaultValue(ddlRequestor);
        addDropdownlistDefaultValue(ddlResponse);
    }
    protected void loadReqType()
    {
        var query = from q in dc.tblSysDatas
                    where q.key_type == "new request type"
                    select q;
        ddlReqType.DataSource = query;
        ddlReqType.DataTextField = "key_data";
        ddlReqType.DataValueField = "key_data";
        ddlReqType.DataBind();
        addDropdownlistDefaultValue(ddlReqType);
    }
    protected void btnAddTaskType_Click(object sender, EventArgs e)
    {
        if (txtAddNewTaskType.Text != "")
        {
            try
            {
                tblSysData newSys = new tblSysData();
                newSys.key_type = "New Task Type";
                newSys.key_code = dc.GET_MAX_SYSDATA_KEY_CODE();
                newSys.key_data = txtAddNewTaskType.Text;
                dc.tblSysDatas.InsertOnSubmit(newSys);
                dc.SubmitChanges();
                txtAddNewTaskType.Text = "";
                loadTaskType();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
    protected void addDropdownlistDefaultValue(DropDownList ddlName)
    {
        if (ddlName != null)
        {
            ddlName.Items.Insert(0,new ListItem("Choose One","0"));
        }
    }
    protected void loadTaskType()
    {
        var query = from q in dc.tblSysDatas
                    where q.key_type == "New Task Type"
                    select q;
        ddlTask.DataSource = query;
        ddlTask.DataTextField = "key_data";
        ddlTask.DataValueField = "key_data";
        ddlTask.DataBind();
        addDropdownlistDefaultValue(ddlTask);
    }
    protected void loadLevelType()
    {
        var query = from q in dc.tblSysDatas
                    where q.key_type == "LEVEL_TYPE"
                    select q;
        ddlLvlType.DataSource = query;
        ddlLvlType.DataTextField = "key_data";
        ddlLvlType.DataValueField = "key_data";
        ddlLvlType.DataBind();
        addDropdownlistDefaultValue(ddlLvlType);
    }
    protected void loadDepartment()
    {
        var query = dc.FN_GET_DISTINCT_DEPARTMENT();
        ddlDept.DataSource = query;
        ddlDept.DataTextField = "DEPARTMENT";
        ddlDept.DataValueField = "DEPARTMENT";
        ddlDept.DataBind();
        addDropdownlistDefaultValue(ddlDept);
    }    
    protected void btnAddNewLvlType_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtAddNewLvlType.Text))
        {
            try
            {
                tblSysData newSys = new tblSysData();
                newSys.key_type = "LEVEL_TYPE";
                newSys.key_code = dc.GET_MAX_SYSDATA_KEY_CODE();
                newSys.key_data = txtAddNewLvlType.Text;
                dc.tblSysDatas.InsertOnSubmit(newSys);
                dc.SubmitChanges();
                btnAddNewLvlType.Text = "";
                loadLevelType();
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
    protected void loadStatus()
    {
        try
        {
            var query = from q in dc.tblSysDatas
                        where q.key_type == "new status"
                        select q;
            ddlStatus.DataSource = query;
            ddlStatus.DataTextField = "key_data";
            ddlStatus.DataValueField = "key_data";
            ddlStatus.DataBind();
            addDropdownlistDefaultValue(ddlStatus);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

            ClearInputs(ctrl.Controls);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            tblSR_Project newSR = new tblSR_Project();
            newSR.ID = txtID.Text;
            newSR.REQUEST_NAME = txtReqName.Text;
            newSR.DESCRIPTION = txtDesc.Text;
            newSR.TASK_TYPE = ddlTask.SelectedValue;
            newSR.REQUEST_TYPE = ddlReqType.SelectedValue;
            newSR.REQUESTOR = ddlRequestor.SelectedValue;
            newSR.REQUESTED_DATE = txtReportDate.Value != "" ? DateTime.Parse(txtReportDate.Value) : default(DateTime);
            newSR.DEPARTMENT = ddlDept.SelectedValue;
            newSR.APPLY_FOR = txtApplyFor.Text;
            newSR.PROPOSTED_DELIVERY = txtProposedDeliDate.Value != "" ? DateTime.Parse(txtProposedDeliDate.Value) : default(DateTime);
            newSR.LEVEL_TYPE = ddlLvlType.SelectedValue;
            newSR.RESPONSIBLE = ddlResponse.SelectedValue;
            newSR.START_DATE = txtStartDate.Value != "" ? DateTime.Parse(txtStartDate.Value) : default(DateTime);
            newSR.END_DATE = txtEndDate.Value!=""?DateTime.Parse(txtEndDate.Value):default(DateTime);
            newSR.STATUS = ddlStatus.SelectedValue;
            newSR.NUMBER_DAY = Int32.Parse(txtNumDay.Text);
            newSR.CLOSED_DATE = txtClosedDate.Value != "" ? DateTime.Parse(txtClosedDate.Value) : default(DateTime);
            newSR.REMARK = txtRemark.Text;
            newSR.COMMEND = txtComment.Text;
            newSR.REASON = txtReason.Text;
            newSR.INPUTER = Session["UserLogin"] != null ? Session["UserLogin"].ToString() : "N/A";
            newSR.INPUT_DATE = DateTime.Now;
            newSR.PERCENTAGE = txtPercent.Text;
            dc.tblSR_Projects.InsertOnSubmit(newSR);
            dc.SubmitChanges();
            ClearInputs(Page.Controls);
            Panel2.Visible = false;
            Panel1.Visible = true;
            lblMsg.Text = "This Service Request has been saved successfully!";
        }
        catch (Exception ex)
        {
            Panel2.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnAddReqType_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtAddNewReqType.Text))
        {
            try
            {
                tblSysData newSys = new tblSysData();
                newSys.key_type = "new request type";
                newSys.key_code = dc.GET_MAX_SYSDATA_KEY_CODE();
                newSys.key_data = txtAddNewReqType.Text;
                dc.tblSysDatas.InsertOnSubmit(newSys);
                dc.SubmitChanges();
                txtAddNewReqType.Text = "";
                loadReqType();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                Panel2.Visible = true;
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            try
            {
                var query = from q in dc.tblSR_Projects
                            where q.No.ToString() == Request["id"].ToString()
                            select q;
                foreach (var q in query)
                {
                    q.ID = txtID.Text;
                    q.REQUEST_NAME = txtReqName.Text;
                    q.DESCRIPTION = txtDesc.Text;
                    q.TASK_TYPE = ddlTask.SelectedValue;
                    q.REQUEST_TYPE = ddlReqType.SelectedValue;
                    q.REQUESTOR = ddlRequestor.SelectedValue;
                    q.REQUESTED_DATE = txtReportDate.Value != "" ? DateTime.Parse(txtReportDate.Value) : default(DateTime);
                    q.DEPARTMENT = ddlDept.SelectedValue;
                    q.APPLY_FOR = txtApplyFor.Text;
                    q.PROPOSTED_DELIVERY = txtProposedDeliDate.Value != "" ? DateTime.Parse(txtProposedDeliDate.Value) : default(DateTime);
                    q.LEVEL_TYPE = ddlLvlType.SelectedValue;
                    q.RESPONSIBLE = ddlResponse.SelectedValue;
                    q.START_DATE = txtStartDate.Value != "" ? DateTime.Parse(txtStartDate.Value) : default(DateTime);
                    q.END_DATE = txtEndDate.Value != "" ? DateTime.Parse(txtEndDate.Value) : default(DateTime);
                    q.STATUS = ddlStatus.SelectedValue;
                    q.NUMBER_DAY = Int32.Parse(txtNumDay.Text);
                    q.CLOSED_DATE = txtClosedDate.Value != "" ? DateTime.Parse(txtClosedDate.Value) : default(DateTime);
                    q.REMARK = txtRemark.Text;
                    q.COMMEND = txtComment.Text;
                    q.REASON = txtReason.Text;
                    q.INPUTER = Session["UserLogin"] != null ? Session["UserLogin"].ToString() : "N/A";
                    q.INPUT_DATE = DateTime.Now;
                    q.PERCENTAGE = txtPercent.Text;
                    ClearInputs(Page.Controls);
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                    lblMsg.Text = "This Service Request has been saved successfully!";
                }
                dc.SubmitChanges();

            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message; 
            }
        }
    }
    
    protected void btnAddNewStatus_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNewStatus.Text))
        {
            try
            {
                tblSysData newSys = new tblSysData();
                newSys.key_type = "new status";
                newSys.key_code = dc.GET_MAX_SYSDATA_KEY_CODE();
                newSys.key_data = txtNewStatus.Text;
                dc.tblSysDatas.InsertOnSubmit(newSys);
                dc.SubmitChanges();
                txtNewStatus.Text = "";
                loadStatus();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                Panel2.Visible = true;
            }
        }
    }
}