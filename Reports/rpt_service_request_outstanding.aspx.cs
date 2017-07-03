using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rpt_service_request_outstanding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string reportName = "RPT_SR_PROJECT_INCIDENT_OUTSTANDING";
            this.ReportViewer1.ServerReport.ReportPath = Registors.reportPath + reportName;
            this.ReportViewer1.ServerReport.ReportServerCredentials = new ConnectingReportServer(Registors.username, Registors.password, Registors.domain);
            this.ReportViewer1.ServerReport.ReportServerUrl = new Uri(Registors.reportURL);
            this.ReportViewer1.ServerReport.Refresh();
        }
    }
}