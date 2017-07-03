using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_authorizer_list : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBranch();
            gridLoader();
        }
    }

    protected void getBranch()
    {
        try
        {
            var query = (from s in dc.tblStaffinfos select new { s.Location }).Distinct();
            query = query.OrderBy(x=>x.Location);
            ddlBranch.Items.Insert(0, new ListItem("- Choose location -", ""));
            ddlBranch.DataSource = query;
            ddlBranch.DataValueField = "Location";
            ddlBranch.DataTextField = "Location";
            ddlBranch.DataBind();
            Session["ChooseBranch"] = ddlBranch.Text;
            if (Session["Location"].ToString() != null)
            {
                ddlBranch.SelectedValue = Session["Location"].ToString();
            }
            else
            {
                ddlBranch.Items.Insert(0,new ListItem("All location","all"));
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"')");
        }
    }
    protected void gridLoader(string str="")
    {
        try
        {
            IQueryable query = null;
            if (str == "")
            {
                query = from q in dc.tblRequests
                        join s in dc.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                        where q.approve == 0 && q.status!="Canceled" && q.certify==1
                        select new { q.req_no, q.requestor_id,s.Name, q.position, s.Location, q.tel, q.email, q.req_date, q.user_crea, q.date_crea, q.user_updt, q.date_updt, q.certify, q.authorize, q.certifier, q.authorizer, q.approve,q.approver };
            }
            else
            {
                query = (from q in dc.tblRequests
                         join s in dc.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                         where q.approve == null && s.Location == str && q.status!="Canceled"
                         select new { q.req_no, q.requestor_id, q.position, s.Location, q.tel, q.email, q.req_date, q.user_crea, q.date_crea, q.user_updt, q.date_updt, q.certify, q.authorize, q.certifier, q.authorizer, q.approve,q.approver });
            }
            GridView1.DataSource = query;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("<script>alert('" + ex.Message + "');</script>");
        }
    }
}