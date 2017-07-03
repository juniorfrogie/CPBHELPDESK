using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Net.Mime;

public partial class pages_request : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack && Request["id"]==null)
            {

//====================================FROM REQUEST==================================

                getAuthorizer();
                getCertifier();
                getPosition();
                getDate();
                DataClassesDataContext dc = new DataClassesDataContext();
                int? sr = dc.GET_MAX_REQUEST_ID();
                lblSR.Text = string.Format("{0:000000}", sr);
                ddlReqID.Items.Add("--Choose One--");
            }
            else if(Request["id"]!=null && !IsPostBack)
            {

//====================================FROM CERTIFY=================================
                if (Request["action"] == "certify" || Request["action"] == "authorize" || Request["action"]=="authorizeHIT" || Request["action"] == "pickup" || Request["action"]=="view")
                {
                    getAuthorizer();
                    getCertifier();
                    getPosition();
                    string id = Request["id"];
                    getRequestByID(id);
                    ddlReqID.Enabled = false;
                    ddlT24.Enabled = false;
                    ddlPosition.Enabled = false;
                    txtT24Desc.Enabled = false;
                    ddlInternal.Enabled = false;
                    txtInternalDesc.Enabled = false;
                    ddlStock.Enabled = false;
                    txtStockDesc.Enabled = false;
                    ddlWindow.Enabled = false;
                    txtWindowDesc.Enabled = false;
                    ddlInternet.Enabled = false;
                    txtInternetDesc.Enabled = false;
                    ddlAuthorize.Enabled = false;
                    ddlCertifier.Enabled = false;
                    FileUpload1.Enabled = false;
                    datetimepicker1.Enabled = false;
                }
                else if (Request["action"] == "edit")
                {
                    getAuthorizer();
                    getCertifier();
                    getPosition();
                    string id = Request["id"];
                    getRequestByID(id);
                    ddlReqID.Enabled = false;
                }
                          
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }
             
    }

    protected void getRequestByID(string id)
    {
        try
        {
            string staff_id = "";
            string t24ID = "";
            DateTime? req_date = null;

//==============================================REQUEST==============================================

            var request = from r in dc.tblRequests
                          where r.req_no == decimal.Parse(id)
                          select r;
            foreach (var r in request)
            {
                lblSR.Text = id.ToString();
                ddlReqID.SelectedValue = r.requestor_id.ToString();
                staff_id = r.requestor_id;
                req_date = r.req_date;
                txtEmail.Text = r.email;
                RadioButtonList1.SelectedValue = r.emp_state.ToString();
                t24ID = r.T24ID;
                ddlCertifier.SelectedValue = r.certifier;
                ddlAuthorize.SelectedValue = r.approver;
            }

//==============================================STAFF INFO==============================================

            var staff = from s in dc.tblStaffinfos
                        where s.IDCard == staff_id.ToString()
                        select s;
            foreach (var s in staff)
            {
                txtName.Text = s.Name;
                txtKhName.Text = s.NameKhmer;
                txtPos.Text = s.Position;
                txtDept.Text = s.Department;
                txtTel.Text = s.PhoneNumber;
                datetimepicker1.Text = String.Format("{0:dd.MM.yyyy}", req_date.ToString());
            }
            ddlPosition.SelectedValue = t24ID;

//==============================================REQUEST DETAIL==============================================

            var requestDetail = from r in dc.tblRequestDetails
                                where r.req_no == id
                                select r;
            
            foreach (var r in requestDetail)
            {
                if (r.catID_lvl2 == "T24")
                {                    
                    ddlT24.SelectedValue = r.action;
                    txtT24Desc.Text = r.desc;
                }
                else if (r.catID_lvl2 == "Internal Report")
                {
                    ddlInternal.SelectedValue = r.action;
                    txtInternalDesc.Text = r.desc;
                }
                else if (r.catID_lvl2 == "Stock")
                {
                    ddlStock.SelectedValue = r.action;
                    txtStockDesc.Text = r.desc;
                }
                else if (r.catID_lvl2 == "Windows")
                {
                    ddlWindow.SelectedValue = r.action;
                    txtWindowDesc.Text = r.desc;
                }
                else if (r.catID_lvl2 == "Internet")
                {
                    ddlInternet.SelectedValue = r.action;
                    txtInternetDesc.Text = r.desc;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }        
    }

    protected void getDate()
    {
        try
        {
            DateTime dt = DateTime.Now;
            datetimepicker1.Text = String.Format("{0:dd.MM.yyyy}", dt);             
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }
    }

    protected void getPosition()
    {
        try 
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var pos = from p in dc.tblPositions
                      select new { p.PostName,p.PostID };
            ddlPosition.DataSource = pos;
            ddlPosition.DataTextField = "PostName";
            ddlPosition.DataValueField = "PostName";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0,new ListItem("-Choose One-","0"));
        }catch(Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }
    }

    protected void getCertifier()
    {
        try
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var staff = from c in dc.tblStaffinfos
                        where c.IDCard != ""
                        orderby c.Name ascending
                        select new { c.Name };
            ddlCertifier.DataSource = staff;
            ddlCertifier.DataTextField = "Name";
            ddlCertifier.DataValueField = "Name";
            ddlCertifier.DataBind();
            ddlCertifier.Items.Insert(0, new ListItem("- Choose -", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }        
    }

    protected void getAuthorizer()
    {
        try {
            DataClassesDataContext dc = new DataClassesDataContext();
            var staff = from c in dc.tblStaffinfos
                        where c.IDCard != ""
                        orderby c.Name ascending
                        select new { c.Name };
            ddlAuthorize.DataSource = staff;
            ddlAuthorize.DataTextField = "Name";
            ddlAuthorize.DataValueField = "Name";
            ddlAuthorize.DataBind();
            ddlAuthorize.Items.Insert(0, new ListItem("- Choose -", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }        
    }

   
    protected void ddlReqID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = ddlReqID.SelectedValue;
            if (id != "--Choose One--")
            {
                DataClassesDataContext dc = new DataClassesDataContext();
                var staff = from s in dc.tblStaffinfos
                            where s.IDCard == id
                            select s;
                foreach (var s in staff)
                {
                    txtName.Text = s.Name;
                    txtKhName.Text = s.NameKhmer;
                    txtDept.Text = s.Department;
                    txtPos.Text = s.Position;
                    txtEmail.Text = s.Email;
                    txtTel.Text = s.PhoneNumber;
                }
            }
            else
            {
               
            }
            
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected DataClassesDataContext insertRequestDetai(DataClassesDataContext dt)
    {
        try
        {
            tblRequestDetail newReqDet = new tblRequestDetail();
            int? reqDetID = dt.GET_MAX_REQUEST_DETAIL_ID();

            //===================================================INSERT T24 REQUEST============================================
            if (ddlT24.SelectedValue != "Not")
            {
                newReqDet.req_no_detail = Int32.Parse(reqDetID.ToString());
                newReqDet.req_no = lblSR.Text;
                newReqDet.priority = null;
                newReqDet.catID_lvl1 = "Solution";
                newReqDet.catID_lvl2 = "T24";
                newReqDet.catID_lvl3 = null;
                newReqDet.desc = txtT24Desc.Text;                
                newReqDet.status = "Pending";
                newReqDet.remark = null;
                newReqDet.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                newReqDet.date_crea = DateTime.Now;
                newReqDet.user_updt = null;
                newReqDet.date_updt = null;
                newReqDet.action = ddlT24.SelectedValue;
                reqDetID = reqDetID + 1;
                dt.tblRequestDetails.InsertOnSubmit(newReqDet);
            }

            //===================================================INSERT INTERNAL WEB REPORT REQUEST============================================
            if (ddlInternal.SelectedValue != "Not")
            {
                tblRequestDetail Internal_req = new tblRequestDetail();
                Internal_req.req_no_detail = Int32.Parse(reqDetID.ToString());
                Internal_req.req_no = lblSR.Text;
                Internal_req.priority = null;
                Internal_req.catID_lvl1 = "Solution";
                Internal_req.catID_lvl2 = "Internal Report";
                Internal_req.catID_lvl3 = null;
                Internal_req.desc = txtInternalDesc.Text;                
                Internal_req.status = "Pending";
                Internal_req.remark = null;
                Internal_req.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                Internal_req.date_crea = DateTime.Now;
                Internal_req.user_updt = null;
                Internal_req.date_updt = null;
                Internal_req.action = ddlInternal.SelectedValue;
                reqDetID = reqDetID + 1;
                dt.tblRequestDetails.InsertOnSubmit(Internal_req);
            }

            //===================================================INSERT STOCK REQUEST============================================
            if (ddlStock.SelectedValue != "Not")
            {
                tblRequestDetail stock_req = new tblRequestDetail();
                stock_req.req_no_detail = Int32.Parse(reqDetID.ToString());
                stock_req.req_no = lblSR.Text;
                stock_req.priority = null;
                stock_req.catID_lvl1 = "Solution";
                stock_req.catID_lvl2 = "Stock";
                stock_req.catID_lvl3 = null;
                stock_req.desc = txtStockDesc.Text;               
                stock_req.status = "Pending";
                stock_req.remark = null;
                stock_req.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                stock_req.date_crea = DateTime.Now;
                stock_req.user_updt = null;
                stock_req.date_updt = null;
                stock_req.action = ddlStock.SelectedValue;
                reqDetID = reqDetID + 1;
                dt.tblRequestDetails.InsertOnSubmit(stock_req);
            }

            //===================================================INSERT WINDOWS&MAIL REQUEST============================================
            if (ddlWindow.SelectedValue != "Not")
            {
                tblRequestDetail win_req = new tblRequestDetail();
                win_req.req_no_detail = Int32.Parse(reqDetID.ToString());
                win_req.req_no = lblSR.Text;
                win_req.priority = null;
                win_req.catID_lvl1 = "Infra";
                win_req.catID_lvl2 = "Windows";
                win_req.catID_lvl3 = null;
                win_req.desc = txtWindowDesc.Text;                
                win_req.status = "Pending";
                win_req.remark = null;
                win_req.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                win_req.date_crea = DateTime.Now;
                win_req.user_updt = null;
                win_req.date_updt = null;
                win_req.action = ddlWindow.SelectedValue;
                reqDetID = reqDetID + 1;
                dt.tblRequestDetails.InsertOnSubmit(win_req);
            }

            //===================================================INSERT INTERNET REQUEST============================================
            if (ddlInternet.SelectedValue != "Not")
            {
                tblRequestDetail internet_req = new tblRequestDetail();
                internet_req.req_no_detail = Int32.Parse(reqDetID.ToString());
                internet_req.req_no = lblSR.Text;
                internet_req.priority = null;
                internet_req.catID_lvl1 = "Infra";
                internet_req.catID_lvl2 = "Internet";
                internet_req.catID_lvl3 = null;
                internet_req.desc = txtInternetDesc.Text;                              
                internet_req.status = "Pending";
                internet_req.remark = null;
                internet_req.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                internet_req.date_crea = DateTime.Now;
                internet_req.user_updt = null;
                internet_req.date_updt = null;
                internet_req.action = ddlInternet.SelectedValue;
                reqDetID = reqDetID + 1;
                dt.tblRequestDetails.InsertOnSubmit(internet_req);
            }            
        }
        catch(Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }
        return dt;        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlReqID.SelectedIndex != 0)
            {
                if (ddlAuthorize.SelectedIndex != 0 && ddlCertifier.SelectedIndex != 0)
                {


//============================================INSERT NEW REQUEST=======================================

                    DataClassesDataContext dt = new DataClassesDataContext();
                    int? no = dt.GET_MAX_REQUEST_ID();
                    tblRequest newReq = new tblRequest();
                    newReq.no = Int32.Parse(no.ToString());
                    newReq.req_no = decimal.Parse(lblSR.Text);
                    newReq.requestor_id = ddlReqID.SelectedValue;
                    newReq.position = txtPos.Text;
                    newReq.branch = txtDept.Text;
                    newReq.tel = txtTel.Text;
                    newReq.email = txtEmail.Text;
                    newReq.req_date = DateTime.Parse(datetimepicker1.Text);
                    newReq.authorize = null;
                    newReq.user_crea = dt.GET_STAFF_NAME(Int32.Parse(ddlReqID.SelectedValue));
                    newReq.date_crea = DateTime.Now;
                    newReq.user_updt = null;
                    newReq.date_updt = null;
                    newReq.emp_state = Int32.Parse(RadioButtonList1.SelectedValue);
                    newReq.approve = null;
                    newReq.certify = null;
                    newReq.T24ID = ddlPosition.SelectedValue;
                    newReq.authorizer = null;
                    newReq.certifier = ddlCertifier.SelectedValue;
                    newReq.approver = ddlAuthorize.SelectedValue;
                    
                    newReq.open_date = null;
                    newReq.close_date = null;
                    newReq.status = "Pending";                    
                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                            tblUpload newUpload = new tblUpload();
                            newUpload.upID = Int32.Parse(dc.GET_MAX_UPLOAD_ID().ToString());
                            newUpload.ReqNo = no.ToString();
                            newUpload.staffID = ddlReqID.SelectedValue;
                            newUpload.attachment = FileUpload1.FileName;
                            newUpload.desc = null;
                            newUpload.type = "Request";
                            newUpload.user_crea = ddlReqID.SelectedValue;
                            newUpload.date_crea = DateTime.Now;

                            dc.tblUploads.InsertOnSubmit(newUpload);
                            dc.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Error uploading file!');</script>");
                        }
                    }
                    dt.tblRequests.InsertOnSubmit(newReq);

//=======================================INSERT REQUEST DETAIL============================================
                    dt = insertRequestDetai(dt);
                    

//======================================SEND MAIL=================================================
                    var query = (from s in dt.tblStaffinfos where this.ddlCertifier.SelectedValue == s.Name select new { s.Name, s.Location, s.Email }).Single();
                    //get the last record of tblLeavings
                    var qry = dt.tblRequests
                             .OrderByDescending(m => m.req_no)
                             .FirstOrDefault();
                   // sendMail(query.Email, qry.req_no.ToString(), txtName.Text, ddlReqID.Text, txtPos.Text, txtDept.Text);


                    dt.SubmitChanges();
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Please Choose an Authorizer and a Certifier first!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Choose your staff ID first!');</script>");
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }
    }

    void sendMail(string certifyEmail, string id, string name, string IDCard, string position, string branch)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(certifyEmail);
            mailMessage.From = new MailAddress("samnang.chheng@cambodiapostbank.com");
            //mailMessage.From = new MailAddress("leavesystemmanagement@cambodiapostbank.com");
            mailMessage.Subject = "Mail from IT Helpdesk";
            mailMessage.Body = "Dear Management, <br/><br/>Please kindly certify in IT Helpdesk for <b>Mr/Ms. " + name + "</b>, ID: <b>" + IDCard + "</b>, Position: <b>" + position + "</b>, Branch: <b>" + branch + "</b>. Please click link : http://inet.adcpbank.com/HELPDESK/Request_Certifier_Form.aspx?id=" + id + "<br/><br/> Best Regards, <br/> IT Helpdesk";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("webmail.cambodiapostbank.com");
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"');</script>");
        }

    }
    protected void btnCertify_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null || Request["id"] != "" && Session["UserLogin"] != null)
            {
                string id = Request["id"];
                var request = from r in dc.tblRequests
                              where r.req_no == decimal.Parse(id)
                              select r;
                foreach (var r in request)
                {
                    r.certify = 1;
                    //r.certifier = Session["UserLogin"].ToString();
                }
                dc.SubmitChanges();
                Response.Redirect("~/Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }        
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null || Request["id"] != "" && Session["UserLogin"] != null)
            {
                string id = Request["id"];
                var request = from r in dc.tblRequests
                              where r.req_no == decimal.Parse(id)
                              select r;
                foreach (var r in request)
                {
                    r.approve = 1;
                    //r.approver = Session["UserLogin"].ToString();
                }
                dc.SubmitChanges();
                Response.Redirect("~/pages/authorizer list.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('" + ex.Message + "');");
        }        
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null)
            {
                string id = Request["id"];
                var request = from r in dc.tblRequests
                              where r.req_no == decimal.Parse(id)
                              select r;
                foreach (var r in request)
                {
                    r.T24ID = ddlPosition.SelectedValue;
                    r.approver = ddlAuthorize.SelectedValue;
                    r.certifier = ddlCertifier.SelectedValue;
                }

                var requestDetail = from r in dc.tblRequestDetails
                                    where r.req_no == id
                                    select r;
                foreach (var r in requestDetail)
                {
                    if (r.catID_lvl2 == "T24")
                    {
                        r.action = ddlT24.SelectedValue;
                        r.desc = txtT24Desc.Text;
                    }
                    else if (r.catID_lvl2 == "Internal Report")
                    {
                        r.action = ddlInternal.SelectedValue;
                        r.desc = txtInternalDesc.Text;
                    }
                    else if (r.catID_lvl2 == "Stock")
                    {
                        r.action = ddlStock.SelectedValue;
                        r.desc = txtStockDesc.Text;
                    }
                    else if (r.catID_lvl2 == "Windows")
                    {
                        r.action = ddlWindow.SelectedValue;
                        r.desc = txtWindowDesc.Text;
                    }
                    else if (r.catID_lvl2 == "Internet")
                    {
                        r.action = ddlInternet.SelectedValue;
                        r.desc = txtInternalDesc.Text;
                    }
                    r.user_updt = Session["UserLogin"].ToString();
                    r.date_updt = DateTime.Now;
                }
                dc.SubmitChanges();
                Response.Redirect("~/Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }        
    }
    protected void btnAuthHit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["id"] != null || Request["id"] != "" && Session["UserLogin"] != null)
            {
                string id = Request["id"];
                var request = from r in dc.tblRequests
                              where r.req_no == decimal.Parse(id)
                              select r;
                foreach (var r in request)
                {
                    r.authorize = 1;
                    //r.authorizer = Session["UserLogin"].ToString();
                }
                dc.SubmitChanges();
                Response.Redirect("~/pages/authorizer_hit.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('" + ex.Message + "');");
        }  
    }
    protected void btnComplete_Click(object sender, EventArgs e)
    {
        try {
            if (Request["id"] != "")
            {
                string id = Request["id"];
                string reqDet = Request["reqDet"];                
                
                var query2 = from rd in dc.tblRequestDetails
                        where rd.req_no == id && rd.req_no_detail.ToString()==reqDet
                        select rd;

                foreach (var q in query2)
                {
                    q.status = "Complete";
                    q.user_updt = Session["UserLogin"].ToString();
                    q.date_updt = DateTime.Now;
                }

                bool? req_cnt = dc.CHECK_REQUEST_COMPLETE(id);

                var query = from q in dc.tblRequests
                            where q.req_no == decimal.Parse(id)
                            select q;
                foreach (var q in query)
                {
                    if (req_cnt == true)
                    {
                        q.status = "Complete";
                    }
                }
                dc.SubmitChanges();
                Response.Redirect("issue_listing.aspx");
            }
        }
        catch(Exception ex)
        {}        
        
    }
    protected void btnPickup_Click(object sender, EventArgs e)
    {
        try {
            if (Request["id"] != "")
            {
                DateTime dateCrea = DateTime.Now;
                string id = Request["id"];
                bool escalade=false;
                int reqDet_id = Int32.Parse(Request["reqDet"]);
                var query = from q in dc.tblRequestDetails
                            where q.req_no == id && q.req_no_detail == reqDet_id
                            select q;
                foreach (var q in query)
                {
                    if (q.status == "Processing")
                    {
                        q.response_by = Session["UserLogin"].ToString();
                        escalade=true;
                    }
                    else if(q.status=="Pending")
                    {
                        q.status = "Processing";
                        q.response_by = Session["UserLogin"].ToString();
                    }                    
                }

                var query2 = from q in dc.tblRequests
                             where q.req_no == decimal.Parse(id.ToString())
                             select q;
                if (escalade == false)
                {
                    foreach (var q in query2)
                    {                        
                        q.open_date = dateCrea;
                        q.status = "Processing";
                    }
                }
                
                dc.SubmitChanges();
                Response.Redirect("issue_listing.aspx");
            }
            else
            {
                Response.Write("<script>alert('There's a problem!');</script>");
            }
        }
        catch (Exception ex)
        {

        }        
    }
}