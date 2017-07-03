using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Certifier_List : System.Web.UI.Page
{   
    DataClassesDataContext db =new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            GetBranch();
            GridLoader();
        }
    }
    private void GetBranch()
    {
        try
        {
            var query = (from s in db.tblStaffinfos select new { s.Location}).Distinct();
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
            else {
                ddlBranch.Items.Insert(0,new ListItem("All location","all"));
            }
        }
        catch (Exception ex) { 
            
        }
    }

    private void ListItem(string p1, string p2)
    {
        throw new NotImplementedException();
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    static string UppercaseFirst(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }
    private void GridLoader(string str="")
    {        
        try
        {
            IQueryable query = null;
            if (str == "")
            {
                query = from q in db.tblRequests
                        join s in db.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                        where q.certify == 0 && q.status == "Pending"
                        select new { q.req_no, q.requestor_id,s.Name, q.position, s.Location, q.tel, q.email, q.req_date, q.user_crea, q.date_crea, q.user_updt, q.date_updt, q.certify, q.authorize, q.certifier, q.authorizer, q.approve,q.approver };
            }
            else
            {
                query = (from q in db.tblRequests                        
                         join s in db.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                        where q.certify == 0 && s.Location==str && s.Status!="Pending"
                        select new { q.req_no, q.requestor_id,s.Name, q.position, s.Location, q.tel, q.email, q.req_date, q.user_crea, q.date_crea, q.user_updt, q.date_updt, q.certify, q.authorize, q.certifier, q.authorizer, q.approve,q.approver });
            }
            GridView1.DataSource = query;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridLoader();
        //GridView1.PageIndex = e.NewPageIndex;
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {            
                string val = ddlBranch.SelectedValue;
                GridLoader(val);            
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }        
    }
}