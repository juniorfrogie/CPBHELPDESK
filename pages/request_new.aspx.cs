using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public partial class pages_request_new : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    string id = "", action = "", staffID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            
            if (!IsPostBack)
            {
                if (Request["auto"] != null)
                {
                    updateReqStatus(lblSR.Text, Request["auto"].ToString());
                }
                
                getAuthorizer();
                getCertifier();
                loadAttachment("");
                pnlUpload.Visible = false;
                txtHidden.Value = Request["id"];
                ddlReqID.Items.Insert(0, new ListItem("-- Choose One --", "0"));
                //ddlAccess.Items.Insert(0, new ListItem("Choose One"));
                //ddlRole.Items.Insert(0, new ListItem("Choose One"));
                if (Request["id"] == null && Request["action"] == null)
                {
                   
                    getDate();                  
                    DataClassesDataContext dc = new DataClassesDataContext();
                    int? sr = dc.GET_MAX_REQUEST_ID();
                    lblSR.Text = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now);                    
                }
                else if (Request["id"] != null)
                {
                    getDate();
                    id = Request["id"];
                    action = Request["action"];
                    if (action == "view")
                    {
                        if (Request["ua"] != null && Request["ua"].ToString() == "Canceled")
                        {
                            btnComplete.Visible = false;
                        }
                        else
                        {
                            btnComplete.Visible = true;
                        }
                        btnAdd.Visible = false;                        
                        ddlReqID.Enabled = false;                        
                        //RadioButtonList1.Enabled = false;
                        GridView1.Columns[8].Visible = true;
                        //GridView1.Columns[7].Visible = true;
                        string sid = "";
                        lblSR.Text = id;
                        pnlUpload.Visible = true;

                        loadRequestHeader2(id, Request["sid"]);
                        loadRequestDetail(id, Request["sid"]);                                               
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "certify" && Request["id"] != null && Request["sid"] != null)
                    {
                        pnlUpload.Visible = true;
                        btnAdd.Visible = false;                        
                        lblSR.Visible = true;
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        loadRequestDetail(Request["id"], Request["sid"]);

                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "authorize" && Request["id"] != null && Request["sid"] != null)
                    {
                        loadRequestDetail(Request["id"], Request["sid"]);
                        btnAdd.Visible = false;                        
                        lblSR.Visible = true;
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        pnlUpload.Visible = true;
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "authorizeHIT" && Request["id"] != null && Request["sid"] != null)
                    {
                        loadRequestDetail(Request["id"], Request["sid"]);
                        btnAdd.Visible = false;                        
                        lblSR.Visible = true;
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        pnlUpload.Visible = true;
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "pickup" && Request["id"] != null && Request["sid"] != null)
                    {
                        //GridView1.Columns[6].Visible = true;
                        //GridView1.Columns[7].Visible = true;     
                        if (Request["ua"]!=null && Request["ua"].ToString() == "Processing")
                        {
                            btnComplete.Visible = true;
                        }
                        loadRequestDetail(Request["id"], Request["sid"]);
                        btnAdd.Visible = false;                        
                        lblSR.Visible = true;
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        pnlUpload.Visible = true;                        
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "Userpickup" && Request["id"] != null && Request["sid"] != null && Request["auto"]!=null)
                    {
                        btnComplete.Visible = true;
                        loadRequestDetail(Request["id"], Request["sid"]);
                        var reqDet = from r in dc.tblRequestDetail2s
                                     where r.req_det_id.ToString() == Request["auto"]
                                     select r;
                        foreach (var r in reqDet)
                        {
                            r.response_by = Session["UserLogin"].ToString();
                            r.status = "Processing";
                        }
                        var req = from r in dc.tblRequests
                                  where r.req_no.ToString() == Request["id"]
                                  select r;
                        foreach(var r in req)
                        {
                            r.open_date = DateTime.Now;
                            r.status = "Processing";                            
                        }
                        
                        dc.SubmitChanges();
                        btnAdd.Visible = false;
                        lblSR.Visible = true;
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        pnlUpload.Visible = true;
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["action"] == "addTmpReq" && Request["id"] != null)
                    {
                        lblSR.Text = Request["id"];
                        loadRequestHeader(lblSR.Text, Request["sid"]);
                        loadRequestDetail(Request["id"], Request["sid"]);
                        lblSR.Text = Request["id"];
                        ddlCertifier.Enabled = true;
                        ddlAuthorize.Enabled = true;
                        btnSubmit.Visible = true;
                    }
                    else if ((Request["action"] != null || Request["action"] != "") && Request["ua"] == "pickup")
                    {
                        if (Request["id"] != null && Request["reqID"] != null && Session["UserLogin"] != null)
                        {
                            string reqDetID = Request["id"];
                            string reqNo = Request["reqID"];
                            var reqDet = from rd in dc.tblRequestDetail2s
                                         where rd.req_det_id.ToString() == reqDetID
                                         select rd;
                            foreach (var rd in reqDet)
                            {
                                rd.status = "Processing";
                                rd.response_by = Session["UserLogin"].ToString();
                            }

                            var req = from r in dc.tblRequests
                                      where r.req_no.ToString() == reqNo
                                      select r;
                            foreach (var r in req)
                            {
                                r.open_date = DateTime.Now;
                            }
                            dc.SubmitChanges();
                        }
                    }
                }
            }
            else
            {
                
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void updateReqStatus(string req_no,string autonum)
    {
        if (req_no != "" && autonum != "")
        {
            var query = from q in dc.tblRequestDetail2s
                        where q.req_no.ToString() == req_no && q.req_det_id.ToString() == autonum
                        select q;
            foreach (var q in query)
            {
                if (q.status == "Pending")
                {
                    q.status = "Processing";
                }                
            }
            dc.SubmitChanges();
        }        
    }

    private void loadAttachment(string id)
    {
        var attch = from a in dc.tblUploads
                    where a.ReqNo == Request[""]
                    select a;
    }

    private void loadRequestHeader2(string req_no,string sid)
    {
        try
        {
            if (req_no != null)
            {
                var request = dc.GET_REQUEST_HEADER(req_no);
                foreach (var r in request)
                {
                    ddlReqID.SelectedValue = r.requestor_id;
                    txtName.Text = r.name.ToUpper();
                    txtKhName.Text = r.name_kh;
                    txtPos.Text = r.position;
                    txtEmail.Text = r.email;
                    txtTel.Text = r.tel;
                    txtDept.Text = r.Location;
                    ddlAuthorize.SelectedValue = r.approver;
                    ddlCertifier.SelectedValue = r.certifier;
                    ddlAuthorize.Enabled = false;
                    ddlCertifier.Enabled = false;
                }

            }
        }
        catch (Exception ex)
        { }
    }
    private void loadRequestHeader(string id, string sid)
    {
        try
        {
            //var request = from r in dc.tblRequests
            //              where r.req_no == decimal.Parse(id)
            //              select r;
            string trimSid = sid.TrimStart(new Char[] { '0' });
            var request = from r in dc.tblRequests
                          where r.req_no == decimal.Parse(id) && r.requestor_id.ToString() == sid
                          select r;
            ddlReqID.Enabled = false;
            //RadioButtonList1.Enabled = false;
            foreach (var r in request)
            {
                //ddlReqID.SelectedValue = r.requestor_id.ToString();
                sid = r.requestor_id.ToString();
                staffID = r.requestor_id.ToString();
                //datetimepicker1.Text = r.date_crea.ToString();
                ddlAuthorize.Enabled = false;
                ddlCertifier.Enabled = false;
                ddlAuthorize.SelectedValue = r.approver;
                ddlCertifier.SelectedValue = r.certifier;
            }

            var staff = from s in dc.tblStaffinfos
                        where s.IDCard == Request["sid"]
                        select s;
            foreach (var s in staff)
            {
                txtName.Text = s.Name.ToUpper();
                txtKhName.Text = s.NameKhmer;
                txtPos.Text = s.Position;
                txtDept.Text = s.Location;
                txtTel.Text = s.PhoneNumber;
                //RadioButtonList1.SelectedValue = s.Status;
                txtEmail.Text = s.Email;
                ddlReqID.SelectedValue = Request["sid"];
                btnAdd.Enabled = true;
            }
        }
        catch (Exception ex)
        { }
    }

    private void loadRequestDetail(string reqID, string sid)
    {
        try
        {
            decimal req_no = decimal.Parse(reqID);
            var reqDet = dc.GET_REQUEST_DETAIL_BY_ID(sid,req_no).ToList();
            GridView1.DataSource = reqDet;
            GridView1.DataBind();
        }
        catch (Exception ex)
        { }
    }

    private void loadGridHistory()
    {
        try
        {
            var history = (from h in dc.tblRequestDetail2s
                           where h.user_crea == ddlReqID.SelectedValue
                           select new { h.action, h.system, h.role, h.purpose }).AsEnumerable().Select(x => new { action = x.action, system = dc.GET_SYSTEM_BY_ID(x.system).ToString(), role = dc.GET_ROLE_BY_ID(Int32.Parse(x.role)).ToString(), purpose = x.purpose });
            GridView2.DataSource = history;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    //protected void getPosition()
    //{
    //    try
    //    {
    //        DataClassesDataContext dc = new DataClassesDataContext();
    //        var pos = (from p in dc.tblPositions
    //                   select new { name = p.PostName, code = p.PostID }).ToList();
    //        ddlRole.DataSource = pos;
    //        ddlRole.DataTextField = "name";
    //        ddlRole.DataValueField = "code";
    //        ddlRole.DataBind();

    //        ddlRole2.DataSource = pos;
    //        ddlRole2.DataTextField = "name";
    //        ddlRole2.DataValueField = "code";
    //        ddlRole2.DataBind();
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}

    //protected void loadDdlAccess()
    //{
    //    try
    //    {
    //        DataClassesDataContext dc = new DataClassesDataContext();
    //        var system = from s in dc.tblSysDatas
    //                     where s.key_type == "system_type"
    //                     select new { name = s.key_data, code = s.key_code };
    //        ddlAccess.DataSource = system;
    //        ddlAccess.DataTextField = "name";
    //        ddlAccess.DataValueField = "code";
    //        ddlAccess.DataBind();

    //        ddlSystem2.DataSource = system;
    //        ddlSystem2.DataTextField = "name";
    //        ddlSystem2.DataValueField = "code";
    //        ddlSystem2.DataBind();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    protected void getAuthorizer()
    {
        try
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var staff = from c in dc.tblStaffinfos
                        where c.IDCard != ""
                        orderby c.Name ascending
                        select new { c.Name };
            ddlAuthorize.DataSource = staff;
            ddlAuthorize.DataTextField = "Name";
            ddlAuthorize.DataValueField = "Name";
            ddlAuthorize.DataBind();
            ddlAuthorize.Items.Insert(0, new ListItem("-- Choose One --", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
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

    protected void getDate()
    {
        try
        {
            DateTime dt = DateTime.Now;
            datetimepicker1.Text = String.Format("{0:dd.MM.yyyy}", dt);
        }
        catch (Exception ex)
        {
            Response.Write("alert('" + ex.Message + "');");
        }
    }


    protected void ddlReqID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = ddlReqID.SelectedValue;
            if (id != "0")
            {
                DataClassesDataContext dc = new DataClassesDataContext();
                loadGridHistory();
                var staff = from s in dc.tblStaffinfos
                            where s.IDCard == id
                            select s;
                foreach (var s in staff)
                {
                    txtName.Text = s.Name.ToUpper();
                    txtKhName.Text = s.NameKhmer;
                    txtDept.Text = s.Location;
                    txtPos.Text = s.Position;
                    txtEmail.Text = s.Email;
                    txtTel.Text = s.PhoneNumber;
                }
                btnAdd.Enabled = true;
                    
            }
            else
            {
                btnAdd.Enabled = false;
                
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (ddlAccess.SelectedIndex != 0 && ddlAction.SelectedIndex != 0 && ddlRole.SelectedIndex != 0 && ddlReqID.SelectedIndex!=0)
        //{
        //    try
        //    {               
        //            tblTmpReqDetail newReq = new tblTmpReqDetail();
        //            newReq.autonum = Int32.Parse(dc.GET_MAX_TMPREQDETAIL_ID().ToString());
        //            newReq.req_no = Int64.Parse(lblSR.Text);
        //            newReq.requestor_id = Int32.Parse(ddlReqID.SelectedValue);
        //            newReq.action = ddlAction.SelectedValue;
        //            newReq.system = ddlAccess.SelectedValue;
        //            newReq.role = ddlRole.SelectedValue;
        //            newReq.purpose = txtPurpose.Text;
        //            dc.tblTmpReqDetails.InsertOnSubmit(newReq);
        //            dc.SubmitChanges();
        //            loadExistingRequest(GridView1);
        //            GridView1.DataBind();
        //            ddlAccess.SelectedIndex = 0;
        //            ddlAction.SelectedIndex = 0;
        //            ddlRole.SelectedIndex = 0;
        //            txtPurpose.Text = "";            

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}
    }

    //private void loadDataEdit()
    //{
    //    try
    //    {
    //        if (GridView1.SelectedValue != null)
    //        {
    //            string reqNo = lblSR.Text.TrimStart(new Char[] { '0' });
    //            string reqID = ddlReqID.SelectedValue.TrimStart(new Char[] { '0' });
    //            var reqDetail = from rd in dc.tblTmpReqDetails
    //                            where rd.req_no.ToString() == reqNo && rd.requestor_id.ToString() == reqID && rd.autonum.ToString() == GridView1.SelectedValue.ToString()
    //                            select new { rd.action, rd.system, rd.role, rd.purpose };
    //            foreach (var rd in reqDetail)
    //            {
    //                ddlAction2.SelectedValue = rd.action;
    //                ddlSystem2.SelectedValue = rd.system;
    //                ddlRole2.SelectedValue = rd.role;
    //                txtPurpose2.Text = rd.purpose;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    private void loadExistingRequest(GridView gd)
    {
        //try
        //{
        //    var existingReq = dc.GET_REQUEST_DETAIL_BY_ID(ddlReqID.SelectedValue, Int64.Parse(lblSR.Text));
        //    gd.DataSource = existingReq;
        //    gd.DataBind();
        //}catch(Exception ex)
        //{

        //}        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlReqID.SelectedValue != "0" && GridView1.Rows.Count > 0)
            {
                string email = "";
                DataClassesDataContext dc = new DataClassesDataContext();
                int? sr = dc.GET_MAX_REQUEST_ID();
                lblHidden.Text = string.Format("{0:000000}", sr);
                tblRequest newReq = new tblRequest();
                string reqNo = lblSR.Text.TrimStart(new Char[] { '0' });
                string reqID = ddlReqID.SelectedValue.TrimStart(new Char[] { '0' });
                newReq.no = Int32.Parse(dc.GET_MAX_REQUEST_ID().ToString());
                newReq.req_no = decimal.Parse(lblSR.Text);
                newReq.requestor_id = ddlReqID.SelectedValue;
                newReq.position = txtPos.Text;
                newReq.branch = txtDept.Text;
                newReq.tel = txtTel.Text;
                newReq.email = txtEmail.Text;
                newReq.request_type = null;
                newReq.req_date = DateTime.Parse(datetimepicker1.Text);
                newReq.approver = ddlAuthorize.SelectedValue;
                newReq.approve = 0;
                newReq.certifier = ddlCertifier.SelectedValue;
                newReq.certify = 0;
                newReq.user_crea = ddlReqID.SelectedValue;
                newReq.date_crea = DateTime.Now;
                newReq.user_updt = null;
                newReq.date_updt = null;
                //newReq.emp_state = Int32.Parse(RadioButtonList1.SelectedValue);
                newReq.open_date = null;
                newReq.close_date = null;
                newReq.status = "Pending";
                newReq.sr_num = lblHidden.Text;
                dc.tblRequests.InsertOnSubmit(newReq);

                var reqDetail = from rd in dc.tblTmpReqDetails
                                where rd.requestor_id.ToString() == reqID && rd.req_no.ToString() == reqNo
                                select rd;

                foreach (var rd in reqDetail)
                {
                    tblRequestDetail2 newReqDetail = new tblRequestDetail2();
                    newReqDetail.req_det_id = Int32.Parse(dc.GET_MAX_REQUEST_DETAIL_ID().ToString());
                    newReqDetail.req_no = rd.req_no;
                    newReqDetail.action = rd.action;
                    newReqDetail.system = rd.system;
                    newReqDetail.role = rd.role;
                    newReqDetail.purpose = rd.purpose;
                    newReqDetail.priority = null;
                    newReqDetail.status = "Pending";
                    newReqDetail.response_by = "N/A";
                    newReqDetail.user_crea = ddlReqID.SelectedValue;
                    newReqDetail.date_crea = DateTime.Now;
                    newReqDetail.user_updt = null;
                    newReqDetail.date_updt = null;
                    dc.tblRequestDetail2s.InsertOnSubmit(newReqDetail);
                }


                var tmpReqDetail = from rd in dc.tblTmpReqDetails
                                   select rd;
                dc.tblTmpReqDetails.DeleteAllOnSubmit(tmpReqDetail);
                dc.SubmitChanges();
                email = getCertifierMail(dc.GET_STAFF_ID_BY_NAME(ddlCertifier.SelectedValue));
                sendMail(email, lblSR.Text, txtName.Text.ToUpper(), ddlReqID.SelectedValue, txtPos.Text, txtDept.Text);

                Response.Redirect("../default.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please Check Mandatory Field Again!');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    string getCertifierMail(string id)
    {
        string email = "";
        try 
        {
            var mail = (from m in dc.tblStaffinfos
                       where m.IDCard == id
                       select new { email = m.Email }).SingleOrDefault();
            email = mail.email;
        }
        catch(Exception)
        {}        
        return  email;
    }

    void sendMail(string certifyEmail, string id, string name, string IDCard, string position, string branch)
    {
        
        //from leave
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(certifyEmail);
            mailMessage.From = new MailAddress("leavesystemmanagement@cambodiapostbank.com");
            mailMessage.Subject = "Mail from Leave Online";
            string htmlBody = "Dear HIT, <br/><br/>Please kindly authorize for <b>Mr/Ms. " + name + "</b>, ID: <b>" + IDCard + "</b>, Position: <b>" + position + "</b>, Branch: <b>" + branch + "</b>. Please click link : https://intranet.cambodiapostbank.com/CPBHELPDESK/pages/request_new.aspx?action=authorizeHIT&id=" + id + "<br/><br/> Best Regards,";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("webmail.cambodiapostbank.com");
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            //lblMsg.Text = "";
            //lblMsg.Text = "{ Save Block } " + ex.Message;
            lblSR.Text = ex.Message.ToString();
        }


        
        
        
        //try
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.To.Add(certifyEmail);
        //    mailMessage.From = new MailAddress("leavesystemmanagement@cambodiapostbank.com");
        //    mailMessage.Subject = "Mail from IT Helpdesk";
        //    mailMessage.Body = "Dear Management, <br/><br/>Please kindly certify in IT Helpdesk for <b>Mr/Ms. " + name + "</b>, ID: <b>" + IDCard + "</b>, Position: <b>" + position + "</b>, Branch: <b>" + branch + "</b>. Please click link : http://inet.adcpbank.com/CPBHELPDESK/Certifier List.aspx?id=" + id + "<br/><br/> Best Regards, <br/> IT Helpdesk";
        //    mailMessage.IsBodyHtml = true;
        //    SmtpClient smtpClient = new SmtpClient("webmail.cambodiapostbank.com");
        //    smtpClient.Send(mailMessage);
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message.ToString());
        //}

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            var tmpReqDetail = from rd in dc.tblTmpReqDetails
                               select rd;
            dc.tblTmpReqDetails.DeleteAllOnSubmit(tmpReqDetail);
            dc.SubmitChanges();

            Response.Redirect("../default.aspx");  //========= request_new.aspx​​ is used multiple times.
        }
        catch (Exception ex)
        { }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (GridView1.SelectedValue != null)
        //{
        //    loadDataEdit();
        //}
    }
    protected void btnPickup_Click(object sender, EventArgs e)
    {                        
        try
        {            
                
            var reqDet = from rd in dc.tblRequestDetail2s
                             where rd.req_det_id.ToString() == GridView1.SelectedValue
                             select rd;
                foreach (var rd in reqDet)
                {
                    rd.response_by = Session["UserLogin"].ToString();
                    rd.status = "Processing";
                }

                var request = from r in dc.tblRequests
                              where r.req_no == decimal.Parse(lblSR.Text)
                              select r;
                foreach (var r in request)
                {
                    r.open_date = DateTime.Now;
                }

                dc.SubmitChanges();
                Response.Redirect("issue_listing.aspx");            
        }
        catch (Exception ex)
        { }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedValue != null)
        {
            try
            {
                var reqDetail = from rd in dc.tblTmpReqDetails
                                where rd.autonum.ToString() == GridView1.SelectedValue
                                select rd;
                dc.tblTmpReqDetails.DeleteAllOnSubmit(reqDetail);
                dc.SubmitChanges();

                var tmp = (from t in dc.tblTmpReqDetails
                           where t.req_no == decimal.Parse(lblSR.Text)
                           select new { autonum = t.autonum, req_no = t.req_no, request_id = t.requestor_id, action = t.action, system = t.system, role = t.role, purpose = t.purpose, status = "", response_by = "" })
                          .AsEnumerable()
                          .Select(x => new { autonum = x.autonum, req_no = x.req_no, requestor_id = x.request_id, action = x.action, system = dc.GET_SYSTEM_BY_ID(x.system), role = dc.GET_ROLE_BY_ID(Int32.Parse(x.role)), purpose = x.purpose, status = x.status, response_by = x.response_by });
                GridView1.DataSource = tmp.ToList();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }


    //protected void btnSave2_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (GridView1.SelectedValue != null)
    //        {
    //            var reqDet = from rd in dc.tblTmpReqDetails
    //                         where rd.autonum.ToString() == GridView1.SelectedValue
    //                         select rd;
    //            foreach (var rd in reqDet)
    //            {
    //                rd.action = ddlAction2.SelectedValue;
    //                rd.system = ddlSystem2.SelectedValue;
    //                rd.role = ddlRole2.SelectedValue;
    //                rd.purpose = txtPurpose2.Text;
    //            }
    //            dc.SubmitChanges();

    //            //var tmp = (from t in dc.tblTmpReqDetails
    //            //           where t.req_no == decimal.Parse(lblSR.Text)
    //            //           select new { autonum = t.autonum, req_no = t.req_no, request_id = t.requestor_id, action = t.action, system = t.system, role = t.role, purpose = t.purpose,status="",response_by="" })
    //            //           .AsEnumerable()
    //            //           .Select(x => new { autonum = x.autonum, req_no = x.req_no, requestor_id = x.request_id, action = x.action, system = dc.GET_SYSTEM_BY_ID(x.system), role = dc.GET_ROLE_BY_ID(Int32.Parse(x.role)), purpose = x.purpose, status = x.status, response_by = x.response_by });
    //            //GridView1.DataSource = tmp.ToList();
    //            //GridView1.DataBind();                
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    protected void btnCertify_Click(object sender, EventArgs e)
    {
        try
        {
            var request = from r in dc.tblRequests
                          where r.req_no == decimal.Parse(lblSR.Text)
                          select r;
            foreach (var r in request)
            {
                r.status = "Pending";
                r.certify = 1;
            }
            dc.SubmitChanges();
            Response.Redirect("Certifier List.aspx");
        }
        catch (Exception ex)
        { }
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        try
        {
            var request = from r in dc.tblRequests
                          where r.req_no == decimal.Parse(lblSR.Text)
                          select r;
            foreach (var r in request)
            {
                r.approve = 1;
            }

	    sendingMail("chanthol.krouch@cambodiapostbank.com", lblSR.Text, txtName.Text, ddlReqID.Text, txtPos.Text, txtDept.Text);
            dc.SubmitChanges();
            Response.Redirect("authorizer list.aspx");
        }
        catch (Exception ex)
        { }
    }
    void sendingMail(string certifyEmail, string id, string name, string IDCard, string position, string branch)
    {
        ServicePointManager.ServerCertificateValidationCallback =
        delegate(object s, X509Certificate certificate,
                 X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };

        try
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "webmail.cambodiapostbank.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(certifyEmail);
            mailMessage.From = new MailAddress("ITHelpdesk@cambodiapostbank.com");
            mailMessage.Subject = "Mail from IT Help Desk";
            mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            string htmlBody = "Dear HIT, <br/><br/>Please kindly authorize for <b>Mr/Ms. " + name + "</b>, ID: <b>" + IDCard + "</b>, Position: <b>" + position + "</b>, Branch: <b>" + branch + "</b>. Please click link : https://intranet.cambodiapostbank.com/CPBHELPDESK/pages/request_new.aspx?action=authorizeHIT&id=" + id + "<br/><br/> Best Regards, <br/> IT Help Desk";
            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString
            (System.Text.RegularExpressions.Regex.Replace(htmlBody, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            //string htmlView = "hello world";
            mailMessage.AlternateViews.Add(plainView);
            mailMessage.AlternateViews.Add(htmlView);
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mailMessage);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);   //Should print stacktrace + details of inner exception

            if (ex.InnerException != null)
            {
                Console.WriteLine("InnerException is: {0}", ex.InnerException);
            }
        }

    }
    protected void btnAuthHit_Click(object sender, EventArgs e)
    {
        try
        {
            var request = from r in dc.tblRequests
                          where r.req_no == decimal.Parse(lblSR.Text) && r.authorize == null
                          select r;
            foreach (var r in request)
            {
                r.authorize = 1;
                r.authorizer = Session["UserLogin"].ToString();
            }
            dc.SubmitChanges();
            Response.Redirect("authorizer_hit.aspx");
        }
        catch (Exception ex)
        { }
    }
   
    protected void btnComplete_Click(object sender, EventArgs e)
    {
        try
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            string reqNo = lblSR.Text.TrimStart(new Char[] { '0' });
            var reqDet = from rd in dc.tblRequestDetail2s
                         where rd.req_no.ToString() == reqNo
                         select rd;
            foreach (var rd in reqDet)
            {
                rd.status = "Complete";
            }
            if (dc.CHECK_REQUEST_COMPLETE(reqNo)==true)
            {
                var req = from r in dc.tblRequests
                          where r.req_no.ToString() == reqNo
                          select r;
                foreach (var r in req)
                {
                    r.close_date = DateTime.Now;
                    r.status = "Complete";
                }
            }            
            dc.SubmitChanges();
            Response.Redirect("issue_listing.aspx");
        }
        catch (Exception ex)
        { }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Write(GridView1.EditIndex);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("add_request_detail.aspx?req_no=" + lblSR.Text + "&sid=" + ddlReqID.SelectedValue);
        }
        catch (Exception ex)
        { }
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        Response.Write(GridView1.EditIndex);
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
    }
}