using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_add_mantis : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBranch();
        }        
    }
    protected void getBranch()
    {
        var branch = dc.GET_BRANCH_CODE();
        ddlBranch.DataSource = branch;
        ddlBranch.DataTextField = "abbreviation";
        ddlBranch.DataValueField = "abbreviation";
        ddlBranch.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtTicketCode.Text) && !string.IsNullOrEmpty(txtIssue.Text))
            {
                tblManti newMantis = new tblManti();
                newMantis.autonum = 1;
                newMantis.ticket_code = txtTicketCode.Text;
                newMantis.mantis = txtMantis.Text;
                newMantis.issue = txtIssue.Text;
                newMantis.issue_desc = txtDesc.Value;
                newMantis.branch = ddlBranch.SelectedValue;
                newMantis.solution = txtSolution.Value;
                newMantis.issue_date = issueDate.Value!=""?DateTime.Parse(issueDate.Value):default(DateTime);
                newMantis.status = ddlStatus.SelectedValue;
                newMantis.num_due_day = Int32.Parse(txtNoDueDay.Text);
                newMantis.risk_level = ddlRiskLevel.SelectedValue;
                newMantis.impact_assessment = txtImpactAssessment.Text;
                newMantis.target_date = targetDate.Value!=""?DateTime.Parse(targetDate.Value):default(DateTime);
                newMantis.comment = txtComment.Value;
                newMantis.user_crea = Session["UserLogin"].ToString();
                newMantis.date_crea = DateTime.Now;
                newMantis.user_updt = "";
                newMantis.date_updt = DateTime.Now;

                dc.tblMantis.InsertOnSubmit(newMantis);
                dc.SubmitChanges();
                Response.Redirect("mantis_mgt.aspx");
            }
        }
        catch (Exception ex)
        { }        
    }
}