using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_issue_listing : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try {                
                gridLoader(gridReq);
                gridLoader(gridInc);
            }
            catch (Exception ex)
            { Response.Write("alert('"+ex.Message+"');"); }
        }
    }

    protected void gridLoader(GridView gd, string str = "")
    {
        try
        {
            if (str == "")
            {
                if (gd.ID == "gridReq")
                {
                    var query = dc.SELECT_REQUEST_2();
                    var q = query.OrderByDescending(o=>o.req_no);
                    gd.DataSource = q;
                    gd.DataBind();
                }
                else if (gd.ID == "gridInc")
                {
                    var query1 = dc.SELECT_INCIDENT();
                    var sortedQuery = query1.OrderByDescending(x=>x.no);
                    gd.DataSource = sortedQuery;
                    gd.DataBind();
                }
            }
            else { }
        }
        catch (Exception ex)
        { }        
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Value != "")
        {
            string search = txtSearch.Value;
            var query = dc.SEARCH_REQUEST(search);
            gridReq.DataSource = query;
            gridReq.DataBind();
        }
        else
        {
            var query = dc.SEARCH_REQUEST("");
            gridReq.DataSource = query;
            gridReq.DataBind();
        }
    }

    protected void btnSearch2_Click(object sender, EventArgs e)
    {
        if (txtSearch2.Value != "")
        {
            string search = txtSearch2.Value;
            var query = dc.SEARCH_INCIDENT(search);
            gridInc.DataSource = query;
            gridInc.DataBind();
        }
        else
        {
            var query = dc.SEARCH_INCIDENT("");
            gridInc.DataSource = query;
            gridInc.DataBind();
        }
    }
    
    protected void gridReq_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridReq.PageIndex = e.NewPageIndex;
        gridReq.DataBind();
    }
}