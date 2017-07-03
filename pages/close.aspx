<%@ Page Language="C#" AutoEventWireup="true" CodeFile="close.aspx.cs" Inherits="pages_close" %>

<%
    try
    {
        if (Request["id"] != "" && Request["val"]!="" && Request["val"]=="req")
        {
            string id = Request["id"];
            DataClassesDataContext dc = new DataClassesDataContext();
            var query = from q in dc.tblRequests
                        where q.req_no == decimal.Parse(id)
                        select q;

            foreach (var q in query)
            {
                q.status = "Closed";
                q.close_date = DateTime.Now;
            }

            var query2 = from q in dc.tblRequestDetail2s
                         where q.req_no == decimal.Parse(id)
                         select q;

            foreach (var q in query2)
            {
                q.status = "Closed";
            }

            dc.SubmitChanges();
            Response.Redirect("myIssue.aspx");

        }
        else if (Request["id"] != "" && Request["val"] != "" && Request["val"] == "inc")
        {
            string id = Request["id"];
            DataClassesDataContext dc = new DataClassesDataContext();
            var query = from q in dc.tblIncidents
                        where q.inc_no == id
                        select q;

            foreach (var q in query)
            {
                q.status = "Closed";
            }

            dc.SubmitChanges();
            Response.Redirect("~/default.aspx");
        }
    }
    catch (Exception ex)
    { }    
     %>