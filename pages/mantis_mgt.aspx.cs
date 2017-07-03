using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_mantis_mgt : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                loadStatus();
            }
        }catch(Exception ex)
        {}        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add_mantis.aspx");
    }
    protected void loadStatus()
    {
        var status = dc.FN_GET_MANTIS_STATUS();
        ddlStatus.DataSource = status;
        ddlStatus.DataTextField = "status";
        ddlStatus.DataValueField = "status";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("All", "all"));
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}