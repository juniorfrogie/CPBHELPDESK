using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_add_srv_req_detail : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadStaffName();
            if (Request["ReqDetID"] != null)
            {
                loadDetailInfo(Request["ReqDetID"].ToString());
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
    }
    protected void loadStaffName()
    {
        var query = from q in dc.tblStaffinfos
                    where q.Department == "IT"
                    select q;
        query = query.OrderBy(x=>x.Name);
        ddlPid.DataSource = query;
        ddlPid.DataTextField = "name";
        ddlPid.DataValueField = "name";
        ddlPid.DataBind();
        ddlPid.Items.Insert(0,new ListItem("Choose One","0"));
    }
    protected void loadDetailInfo(string id)
    {
        if (id != "")
        {
            var query = from q in dc.tblSR_Project_Details
                        where q.sr_det_id.ToString() == id
                        select q;
            foreach (var q in query)
            {
                ddlPid.SelectedValue = q.pic;
                txtActionPlanned.SelectedValue = q.action_planned;
                ddlStatus.SelectedValue = q.ind_status;
                txtManDays.Text = q.man_days.ToString();
                txtPlannedStartDate.Value = q.planned_start_date.ToString();
                txtPlannedCompleteDate.Value = q.planned_complete_date.ToString();
                txtCompetePercent.Text = q.complete_percent;
                txtRemark.Text = q.remark;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            tblSR_Project_Detail newSR = new tblSR_Project_Detail();
            newSR.no = Int32.Parse(Request["id"].ToString());
            newSR.pic = ddlPid.SelectedValue;
            newSR.ind_status = ddlStatus.SelectedValue;
            newSR.action_planned = txtActionPlanned.SelectedValue;
            newSR.man_days = Int32.Parse(txtManDays.Text);
            newSR.planned_start_date = txtPlannedStartDate.Value!=""? DateTime.Parse(txtPlannedStartDate.Value):default(DateTime);
            newSR.planned_complete_date = txtPlannedCompleteDate.Value!=""? DateTime.Parse(txtPlannedCompleteDate.Value):default(DateTime);
            newSR.complete_percent = txtCompetePercent.Text;
            newSR.remark = txtRemark.Text;
            dc.tblSR_Project_Details.InsertOnSubmit(newSR);
            dc.SubmitChanges();
            Response.Redirect("srv_req_mgt.aspx");
        }
        catch (Exception)
        {
            
            throw;
        }        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request["ReqDetID"] != null)
        {
            try
            {
                var query = from q in dc.tblSR_Project_Details
                            where q.sr_det_id.ToString() == Request["ReqDetID"].ToString()
                            select q;
                foreach (var q in query)
                {
                    q.pic = ddlPid.SelectedValue;
                    q.action_planned = txtActionPlanned.SelectedValue;
                    q.ind_status = ddlStatus.SelectedValue;
                    q.man_days = Int32.Parse(txtManDays.Text);
                    q.planned_start_date = txtPlannedStartDate.Value!=""? DateTime.Parse(txtPlannedStartDate.Value):default(DateTime);
                    q.planned_complete_date = txtPlannedCompleteDate.Value!=""? DateTime.Parse(txtPlannedCompleteDate.Value):default(DateTime);
                    q.complete_percent = txtCompetePercent.Text;
                    q.remark = txtRemark.Text;
                }
                dc.SubmitChanges();
                Response.Redirect("srv_req_mgt.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }            

        }
    }
}