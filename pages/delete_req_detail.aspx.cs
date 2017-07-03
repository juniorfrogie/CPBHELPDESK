using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_delete_req_detail : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null && Request["reqID"]!=null)
            {
                txtHidden.Value = Request["reqID"];
                int id = Int32.Parse(Request["id"].ToString());
                var reqDet = from rd in dc.tblRequestDetail2s
                             where rd.req_det_id == id
                             select rd;
                dc.tblRequestDetail2s.DeleteAllOnSubmit(reqDet);
                dc.SubmitChanges();

                Response.Redirect("request_new.aspx?id=" + txtHidden.Value + "&action=addTmpReq&sid=" + Request["sid"]);
            }
        }
        catch (Exception ex)
        { }
    }
}