<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel.aspx.cs" Inherits="pages_cancel" %>

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
                q.status = "Canceled";                
            }

            dc.SubmitChanges();
            Response.Redirect("~/pages/myIssue.aspx");
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
                q.status = "Canceled";
            }

            dc.SubmitChanges();
            Response.Redirect("~/pages/myIssue.aspx");
        }
    }
    catch (Exception ex)
    { }    
    %>
