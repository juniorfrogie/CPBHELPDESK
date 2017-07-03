using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_cob_mgt : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add_cob.aspx");
    }


    protected void btnFilter_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Concat("cob_mgt.aspx?src=",txtReportDate.Value));      
    }
}