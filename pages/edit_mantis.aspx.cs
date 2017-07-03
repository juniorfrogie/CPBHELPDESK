using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_edit_mantis : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Int32.Parse(Request["id"].ToString());
            setControl();
            getBranch();
            getData(id);
        }        
    }
    private void setControl()
    {
        txtTicketCode.ReadOnly = true;
    }
    private void getBranch()
    {
        var branch = dc.GET_BRANCH_CODE();
        ddlBranch.DataSource = branch;
        ddlBranch.DataTextField = "abbreviation";
        ddlBranch.DataValueField = "abbreviation";
        ddlBranch.DataBind();
    }
    private void getData(int id)
    {
        try
        {
            if (id != 0)
            {
                txtHidden.Value = Request["id"].ToString();
                var query = from q in dc.tblMantis
                            where q.autonum == id
                            select q;
                foreach (var q in query)
                {
                    txtTicketCode.Text = q.ticket_code;
                    txtMantis.Text = q.mantis;
                    txtIssue.Text = q.issue;
                    txtDesc.Value = q.issue_desc;
                    ddlBranch.SelectedValue = q.branch;
                    txtSolution.Value = q.solution;
                    datetimepicker.Value = q.issue_date.ToString();
                    ddlStatus.SelectedValue = q.status;
                    txtNoDueDay.Text = q.num_due_day.ToString();
                    ddlRiskLevel.SelectedValue = q.risk_level;
                    txtImpactAssessment.Text = q.impact_assessment;
                    datetimepicker2.Value = q.target_date.ToString();
                    txtComment.Value = q.comment;
                }
            }
        }catch(Exception ex)
        {}        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData(Request["id"].ToString());
    }
    private void saveData(string id)
    {
        try
        {
            if (txtHidden.Value != "")
            {
                int mantisID = Int32.Parse(txtHidden.Value);
                var query = from q in dc.tblMantis
                            where q.autonum == mantisID
                            select q;
                foreach (var q in query)
                {
                    q.mantis = txtMantis.Text;
                    q.issue = txtIssue.Text;
                    q.issue_desc = txtDesc.Value;
                    q.branch = ddlBranch.SelectedValue;
                    q.solution = txtSolution.Value;
                    q.issue_date = DateTime.Parse(datetimepicker.Value);
                    q.status = ddlStatus.SelectedValue;
                    q.num_due_day = Int32.Parse(txtNoDueDay.Text);
                    q.risk_level = ddlRiskLevel.SelectedValue;
                    q.impact_assessment = txtImpactAssessment.Text;
                    q.target_date = DateTime.Parse(datetimepicker2.Value);
                    q.comment = txtComment.Value;
                }
                dc.SubmitChanges();
                Response.Redirect("mantis_mgt.aspx");
            }
        }catch(Exception ex)
        {}
    }
}