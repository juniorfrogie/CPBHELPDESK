using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_myIssue : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            getBranch();
            gridLoader(GridView1);
            gridLoader(GridView2);
            //WindowsIdentity identity = HttpContext.Current.Request.LogonUserIdentity;
            //string user = identity.Name.ToString();
            //string user = User.Identity.Name;
            //Response.Write(user);
            string loggedOnUser = string.Empty;
            loggedOnUser = Request.ServerVariables.Get("AUTH_USER");                        
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
            ddlBranch.Items.Insert(0,new ListItem("All Location", "0"));
            ddlBranch.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Response.Write("alert('" + ex.Message + "')");
        }
    }

    protected void gridLoader(GridView gd, string str="")
    {
        try
        {
            if (gd.ID=="GridView1" && str == "" || gd.ID=="GridView1" && str=="0")
            {
                var query = (from q in dc.tblRequests
                            join s in dc.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                            join rd in dc.tblRequestDetail2s on q.req_no equals rd.req_no
                            where q.status!="Canceled"
                            select new { q.req_no, q.requestor_id,s.Name, s.Location, q.req_date, rd.status }).Distinct();
                var sortedQuery = query.OrderByDescending(x => x.req_no);
                GridView1.DataSource = sortedQuery;
                GridView1.DataBind();
            }
            else if(gd.ID=="GridView2" && str=="")
            {
                var query = from q in dc.tblIncidents
                            join s in dc.tblStaffinfos on q.initiator_id.ToString() equals s.IDCard
                            select new { q.inc_no, q.initiator_id,s.Name, q.branch, q.submit_date, q.status,q.response_by };
                var sortedQuery = query.OrderByDescending(x=>x.inc_no);
                GridView2.DataSource = sortedQuery;
                GridView2.DataBind();
            }
            else if (gd.ID == "GridView1" && str != "")
            {
                var query = (from q in dc.tblRequests
                            join s in dc.tblStaffinfos on q.requestor_id.ToString() equals s.IDCard
                            join qd in dc.tblRequestDetail2s on q.req_no equals qd.req_no
                            where s.Location==str
                            select new { q.req_no, q.requestor_id,s.Name, s.Location, q.req_date, q.status, qd.response_by }).Distinct();
                var sortedQuery = query.OrderByDescending(x=>x.req_no);
                GridView1.DataSource = sortedQuery;
                GridView1.DataBind();
            }
            else if (gd.ID == "GridView2" && str != "")
            { 
                var query = from q in dc.tblIncidents
                            join s in dc.tblStaffinfos on q.initiator_id equals s.IDCard
                            where s.Location == str
                            select new { q.inc_no, q.initiator_id,s.Name, q.branch, q.submit_date, q.status, q.response_by };
                var sortedQuery = query.OrderByDescending(x=>x.inc_no);
                GridView2.DataSource = query;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {

        }        
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {            
                //getBranch();
                gridLoader(GridView1, ddlBranch.SelectedValue);
                gridLoader(GridView2, ddlBranch.SelectedValue);            
        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        //if (txtSearch.Text != "")
        //{
        //    var query = from q in dc.tblRequests
        //                join s in dc.tblStaffinfos on q.requestor_id equals s.IDCard
        //                join qd in dc.tblRequestDetails on q.req_no equals decimal.Parse(qd.req_no)
        //                where q.requestor_id==txtSearch.Text
        //                select new { q.req_no, q.requestor_id, s.Location, q.req_date, q.status, qd.response_by };
        //    GridView1.DataSource = query;
        //    GridView1.DataBind();

        //    var query2 = from q in dc.tblIncidents
        //                 join s in dc.tblStaffinfos on q.initiator_id equals s.IDCard
        //                 where s.IDCard == q.initiator_id
        //                 select new { q.inc_no, q.initiator_id, q.branch, q.submit_date, q.status, q.response_by };
        //    GridView2.DataSource = query2;
        //    GridView2.DataBind();

        //}
        //else
        //{
        //    gridLoader(GridView1);
        //    gridLoader(GridView2);
        //}
    }
    
}