using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_add_request_detail : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                getPosition();
                loadDdlAccess();
                ddlAccess.Items.Insert(0, new ListItem("Choose One","0"));
                ddlRole.Items.Insert(0, new ListItem("Choose One","0"));
            }                
        }catch(Exception ex)
        {}
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
	    var sortedQuery = pos.OrderBy(x => x.name);
            ddlRole.DataSource = sortedQuery;
            ddlRole.DataTextField = "name";
            ddlRole.DataValueField = "code";
            ddlRole.DataBind();     
        }
        catch (Exception ex)
        {

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
	Response.Redirect("request_new.aspx?id=" + Request["req_no"] + "&action=addTmpReq&sid=" + Request["sid"]);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlAccess.SelectedIndex != 0 && ddlAction.SelectedIndex != 0 && Request["req_no"]!=null && Request["sid"]!=null)
        {
            try
            {

                if (FileUpload1.HasFile)
                {
                    Boolean fileOK = false;
                    String path = Server.MapPath("../Uploads/");
                    if (FileUpload1.HasFile)
                    {
                        String fileExtension =
                            System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        String[] allowedExtensions = { ".docx", ".doc",".txt",".xls",".xlsx",".pdf",".png",".bmp",".gif" };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                fileOK = true;
                            }
                        }
                    }

                    if (fileOK)
                    {
                        try
                        {
                            FileUpload1.PostedFile.SaveAs(path
                                + FileUpload1.FileName);                            
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }                    
                }

                tblUpload newUpload = new tblUpload();
                int? maxID = dc.GET_MAX_UPLOAD_ID();
                newUpload.upID = Int32.Parse(maxID.ToString());
                newUpload.ReqNo = Request["req_no"];
                newUpload.staffID = Request["sid"];
                newUpload.attachment = FileUpload1.FileName;
                newUpload.desc = null;
                newUpload.user_crea = Request["sid"];
                newUpload.date_crea = DateTime.Now;
                newUpload.type = "request";
                newUpload.date_updt = null;
                newUpload.user_updt = null;
                dc.tblUploads.InsertOnSubmit(newUpload);

                tblRequestDetail2 newReqDet = new tblRequestDetail2();
                newReqDet.req_det_id = Int32.Parse(dc.GET_MAX_REQUEST_DETAIL_ID().ToString());
                newReqDet.req_no = Int64.Parse(Request["req_no"]);
                newReqDet.action = ddlAction.SelectedValue;
                newReqDet.system = ddlAccess.SelectedValue;
                newReqDet.role = ddlRole.SelectedValue;
                newReqDet.purpose = txtPurpose.Text;
                newReqDet.progress = 0;
                newReqDet.priority = "N/A";
                newReqDet.status = "Pending";
                newReqDet.response_by = "N/A";
                newReqDet.user_crea = Request["sid"];
                newReqDet.date_crea = DateTime.Now;
                newReqDet.user_updt = null;
                newReqDet.date_updt = null;

                dc.tblRequestDetail2s.InsertOnSubmit(newReqDet);
                dc.SubmitChanges();

                Response.Redirect("request_new.aspx?id="+Request["req_no"]+"&action=addTmpReq&sid="+Request["sid"]);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    
}