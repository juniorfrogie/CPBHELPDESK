using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_view_mantis : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadData(Request["id"].ToString());
    }

    protected void loadData(string val)
    {
        if (!string.IsNullOrEmpty(val))
        {
            var query = from q in dc.tblMantis
                        where q.autonum == Int32.Parse(Request["id"].ToString())
                        select q;

            foreach (var q in query)
            {
                txtTicketCode.Text = q.ticket_code;
                txtMantis.Text = q.mantis;
                txtIssue.Text = q.issue;
                txtDesc.Value = q.issue_desc;
                txtBranch.Text = q.branch;
                txtSolution.Value = q.solution;
                txtIssueDate.Text = q.issue_date.ToString();
                txtStatus.Text = q.status;
                txtNoDueDay.Text = q.num_due_day.ToString();
                txtRiskLevel.Text = q.risk_level;
                txtImpactAssessment.Text = q.impact_assessment;
                txtTargetDate.Text = q.target_date.ToString();
                txtComment.Value = q.comment;
            }
        }        
    }
}