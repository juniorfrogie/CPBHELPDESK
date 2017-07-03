using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_edit_req_detail : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null && !IsPostBack)
            {
                string id = Request["id"];
                loadDdlAccess();
                getPosition();
                loadReqDetail(id);
                txtHidden.Value = Request["sid"];
            }
        }
        catch(Exception ex)
        {

        }        
    }

    protected void loadReqDetail(string id)
    {
        var reqDet = from r in dc.tblRequestDetail2s
                     where r.req_det_id.ToString() == id
                     select r;
        foreach (var r in reqDet)
        {
            ddlAccess.SelectedValue = r.system;
            ddlAction.SelectedValue = r.action;
            ddlRole.SelectedValue = r.role;
            txtPurpose.Text = r.purpose;
        }
    }
    protected void loadDdlAccess()
    {
        try
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var system = from s in dc.tblSysDatas
                         where s.key_type == "system_type"
                         select new { name = s.key_data, code = s.key_code };
            ddlAccess.DataSource = system;
            ddlAccess.DataTextField = "name";
            ddlAccess.DataValueField = "code";
            ddlAccess.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void getPosition()
    {
        try
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var pos = (from p in dc.tblPositions
                       select new { name = p.PostName, code = p.PostID }).ToList();
            ddlRole.DataSource = pos;
            ddlRole.DataTextField = "name";
            ddlRole.DataValueField = "code";
            ddlRole.DataBind();
        }
        catch (Exception ex)
        {

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if(Request["id"]!=null)
            {
                string id = Request["id"];
                var reqDet = from r in dc.tblRequestDetail2s
                             where r.req_det_id.ToString() == id
                             select r;
                foreach(var r in reqDet)
                {
                    r.action = ddlAction.SelectedValue;
                    r.system = ddlAccess.SelectedValue;
                    r.role = ddlRole.SelectedValue;
                    r.purpose = txtPurpose.Text;
                }
                dc.SubmitChanges();
                Response.Redirect("request_new.aspx?id=" + Request["reqID"] + "&action=addTmpReq&sid=" + txtHidden.Value);
            }            
        }catch(Exception ex)
        {}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("request_new.aspx?id=" + Request["reqID"] + "&action=addTmpReq&sid=" + txtHidden.Value);
    }
}