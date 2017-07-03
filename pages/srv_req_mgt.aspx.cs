using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_srv_req_mgt : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["del"] != null)
            {
                deleteService(Request["del"].ToString());
            }
            else if (Request["detID"] != null)
            {
                deleteServiceDet(Request["detID"].ToString());
            }
        }
    }
    protected void deleteServiceDet(string id)
    {
        if (id != "")
        {
            var query = from q in dc.tblSR_Project_Details
                        where q.sr_det_id.ToString() == id
                        select q;
            dc.tblSR_Project_Details.DeleteAllOnSubmit(query);
            dc.SubmitChanges();
        }
    }
    protected void deleteService(string id)
    {
        try
        {
            var query = from q in dc.tblSR_Projects
                        where q.No.ToString() == id
                        select q;
            dc.tblSR_Projects.DeleteAllOnSubmit(query);
            dc.SubmitChanges();
            Panel1.Visible = true;
            lblMsg.Text = "This service request has been deleted successfully!";
        }
        catch (Exception)
        {
            
            throw;
        }        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add_service.aspx");
    }
    protected void btnAddDetail_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Response.Redirect(string.Concat("add_srv_req_detail.aspx?id=", Request["id"].ToString()));
        }
        else
        {
            lblError.Text = "Please select Service Request first.";
        }
    }
}