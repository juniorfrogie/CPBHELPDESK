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

public partial class pages_incident : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack && Request["id"] == null)
            {
               
                ddlCat.Items.Insert(0, new ListItem("-Choose One-", "0"));
                ddlSubCat1.Items.Insert(0, new ListItem("-Choose One-", "0"));
                ddlSubCat2.Items.Insert(0, new ListItem("-Choose One-", "0"));
                var sr = dc.GET_MAX_INCIDENT_ID();
                //IncID.Text = string.Format("{0:000000}", sr);
                txtHidden.Value = string.Format("{0:000000}", sr);
                IncID.Text = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now);
                getCat(ddlCat, 1, 0);
                getID();
                getID_IT();
                DateTime dateSubmit = DateTime.Now;
                datetimepicker1.Value = string.Format("{0:d/M/yyyy}", dateSubmit);
            }
            else if (Request["id"] != null && !IsPostBack)
            {                
                if (Request["action"] == "pickup")
                {
                    ddlCat.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    //ddlSubCat1.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    //ddlSubCat2.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    getID();
                    getID_IT();
                    getCat(ddlCat, 1, 0);
                    string id = Request["id"];
                    IncID.Text = id;                    
                    incidentByID(id);
                    disableControl("pickup");

                }
                else if (Request["action"] == "view")
                {
                    ddlCat.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    ddlSubCat1.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    ddlSubCat2.Items.Insert(0, new ListItem("-Choose One-", "0"));
                    disableControl("view");
                    getID();
                    getID_IT();
                    getCat(ddlCat, 1, 0);
                    string id = Request["id"];
                    IncID.Text = id;
                    incidentByID(id);
                }
                loadGridUpload();
            }
        }
        catch (Exception ex)
        { }        
    }

    private void loadGridUpload()
    {
        try
        {
            var upload = from u in dc.tblUploads
                         where u.ReqNo == IncID.Text
                         select u;
            gvUpload.DataSource = upload;
            gvUpload.DataBind();
        }
        catch (Exception ex)
        {

        }        
    }

    private void getCat(DropDownList ddl, int lvl,int parent)
    {
        var cat = from c in dc.tbl_categories
                  where c.cat_level == lvl && c.parent==parent
                  select c;
        ddl.DataSource = cat;
        ddl.DataTextField = "cat_name";
        ddl.DataValueField = "cat_code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-Choose One-", "0"));
    }

    protected void incidentByID(string id)
    {
        try
        {
            if (id != "" || id != null)
            {
                string idCard = "", itID = "";
                var query = from q in dc.tblIncidents
                            where q.no == decimal.Parse(id)
                            select q;

                foreach (var q in query)
                {
                    ddlID.SelectedValue = q.initiator_id;
                    idCard = q.initiator_id;
                    datetimepicker1.Value = q.submit_date.ToString();                    
                    ddlSubCat1.Items.Insert(0, new ListItem(dc.GET_CAT_NAME_BY_ID(q.catID_lvl2).ToString(), "0"));                    
                    ddlSubCat2.Items.Insert(0, new ListItem(dc.GET_CAT_NAME_BY_ID(q.catID_lvl3).ToString(), "0"));                    
                    txtDesc.Text = q.desc;
                    txtRootCause.Text = q.root_cause;
                    txtSolution.Text = q.solution;
                    txtComment.Text = q.remark;
                    ddlIT_ID.SelectedValue = q.response_by;
                    itID = q.response_by;
                    ddlCat.SelectedValue = q.catID_lvl1;
                    ddlPriority.SelectedValue = q.priority;
                    ddlStatus.SelectedValue = q.status;
                    ddlTeam.SelectedValue = q.action;
                }

                var staff = from s in dc.tblStaffinfos
                            where s.IDCard == idCard
                            select s;
                foreach (var s in staff)
                {
                    txtContact.Text = s.PhoneNumber;
                    txtKhmerName.Text = s.NameKhmer;
                    txtEngName.Text = s.Name;
                    txtPos.Text = s.Position;
                    txtDep.Text = s.Location;
                }

                var it = from i in dc.tblStaffinfos
                         where i.IDCard == itID
                         select i;
                foreach (var i in it)
                {
                    ddlIT_ID.SelectedValue = i.IDCard;
                    txtName.Text = i.Name;
                    txtNameKh.Text = i.NameKhmer;
                    txtPosIT.Text = i.Position;
                }
            }
        }
        catch (Exception ex)
        { }        
    }

    protected void disableControl(string val)
    {
        if (val == "view")
        {
            ddlID.Enabled = false;
            datetimepicker1.Disabled = true;
            ddlCat.Enabled = false;
            txtDesc.Enabled = false;
            ddlSubCat1.Enabled = false;
            ddlSubCat2.Enabled = false;
        }
        else if (val == "pickup")
        {
            ddlID.Enabled = false;
            datetimepicker1.Disabled = true;
            ddlCat.Enabled = false;
            txtDesc.Enabled = false;
            ddlSubCat1.Enabled = false;
            ddlSubCat2.Enabled = false;
        }
    }

    void getID()
    {
        try
        {
            var query = from q in dc.tblStaffinfos
                        select q;
            
            ddlID.DataSource = query;
            ddlID.DataTextField = "IDCard";
            ddlID.DataValueField = "IDCard";
            ddlID.DataBind();
            ddlID.Items.Insert(0, new ListItem("-Choose One-", "0"));
        }
        catch (Exception ex)
        { Response.Write("alert('"+ex.Message+"');"); }        
    }

    void getID_IT()
    {
        try
        { 
            var query = from q in dc.tblStaffinfos
                        where q.Department == "IT"
                        select q;

            ddlIT_ID.DataSource = query;
            ddlIT_ID.DataTextField = "IDCard";
            ddlIT_ID.DataValueField = "IDCard";
            ddlIT_ID.DataBind();
            ddlIT_ID.Items.Insert(0, new ListItem("-Choose One-","0"));
        }
        catch(Exception ex)
        {
            Response.Write("alert('" + ex.Message + "');");
        }
    }
    protected void ddlID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
                string id = ddlID.SelectedValue;
                var query = from q in dc.tblStaffinfos
                            where q.IDCard == id
                            select q;

                foreach (var q in query)
                {
                    txtContact.Text = q.PhoneNumber;
                    txtKhmerName.Text = q.NameKhmer;
                    txtPos.Text = q.Position;
                    txtDep.Text = q.Department;
                    txtEngName.Text = q.Name;
                }                            
            
        }
        catch (Exception ex)
        {
            Response.Write("alert('"+ex.Message+"');");
        }        
    }
    protected void ddlIT_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = ddlIT_ID.SelectedValue;
            var query = from q in dc.tblStaffinfos
                        where q.IDCard == id
                        select q;

            foreach (var q in query)
            {
                txtName.Text = q.Name;
                txtNameKh.Text = q.NameKhmer;
                txtPosIT.Text = q.Position;
            }
        }
        catch (Exception ex)
        {
            Response.Write("alert('" + ex.Message + "');");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try 
        {
            if (ddlID.SelectedIndex != 0 && datetimepicker1.Value != "" && ddlCat.SelectedIndex != 0)
            {
                tblIncident newIncident = new tblIncident();
                newIncident.no = Int64.Parse(IncID.Text);
                newIncident.inc_no = IncID.Text;
                newIncident.catID_lvl1 = ddlCat.SelectedValue;
                newIncident.catID_lvl2 = ddlSubCat1.SelectedValue;
                newIncident.catID_lvl3 = ddlSubCat2.SelectedValue;
                newIncident.initiator_id = ddlID.SelectedValue;
                newIncident.desc = txtDesc.Text;
                newIncident.branch = txtDep.Text;
                newIncident.priority = ddlPriority.SelectedValue;
                newIncident.submit_date = DateTime.Parse(datetimepicker1.Value);
                newIncident.status = "Pending";
                newIncident.action = ddlIT_ID.SelectedValue;
                newIncident.tel = txtContact.Text;
                newIncident.user_crea = ddlID.SelectedValue;
                newIncident.date_crea = DateTime.Now;
                newIncident.sr_num = txtHidden.Value;

                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                        tblUpload newUpload = new tblUpload();
                        newUpload.upID = Int32.Parse(dc.GET_MAX_UPLOAD_ID().ToString());
                        newUpload.ReqNo = IncID.Text;
                        newUpload.staffID = ddlID.SelectedValue;
                        newUpload.attachment = FileUpload1.FileName;
                        newUpload.desc = null;
                        newUpload.user_crea = ddlID.SelectedValue;
                        newUpload.date_crea = DateTime.Now;
                        newUpload.type = "Incident";

                        dc.tblUploads.InsertOnSubmit(newUpload);
                        dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error uploading file!');</script>");
                    }
                }

                dc.tblIncidents.InsertOnSubmit(newIncident);

                dc.SubmitChanges();
                Response.Redirect("~/Default.aspx");
            }         
        }
        catch(Exception ex)
        {
        
        }        
    }
    protected void btnPickup_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlIT_ID.SelectedIndex != 0 && Session["UserLogin"]!=null)
            {
                var incident = from i in dc.tblIncidents
                               where i.no == decimal.Parse(IncID.Text)
                               select i;
                foreach(var i in incident)
                {
                    i.priority = ddlPriority.SelectedValue;
                    i.open_date = DateTime.Now;
                    i.response_by = ddlIT_ID.SelectedValue;
                    i.root_cause = txtRootCause.Text;
                    i.solution = txtSolution.Text;
                    i.status = ddlStatus.SelectedValue;
                    ////i.status = "Processing";
                    i.action = ddlTeam.SelectedValue;
                    i.user_updt = Session["UserLogin"].ToString();
                    i.date_updt = DateTime.Now;
                    i.catID_lvl1 = ddlCat.SelectedValue;                    
                }

                dc.SubmitChanges();
                Response.Redirect("issue_listing.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please Choose an ID first!');</script>");
            }
        }
        catch (Exception ex)
        {

        }        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../default.aspx");
    }
    protected void btnComplete_Click(object sender, EventArgs e)
    {
        if (Request["id"] != "")
        {
            string id = Request["id"];            
            var query = from q in dc.tblIncidents
                        where q.no == decimal.Parse(id)
                        select q;
            foreach (var q in query)
            {
                q.status = "Complete";
                q.solution = txtSolution.Text;
                q.remark = txtComment.Text;
            }            
            dc.SubmitChanges();
            Response.Redirect("issue_listing.aspx");
        }
    }
    protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCat.SelectedIndex != 0)
        {
            try
            {
                int? parent = dc.GET_CAT_PARENT(ddlCat.SelectedValue);
                getCat(ddlSubCat1, 2, Int32.Parse(parent.ToString()));
                ddlSubCat2.Items.Clear();
                ddlSubCat2.Items.Insert(0, new ListItem("-Choose One-", "0"));
            }
            catch (Exception ex)
            { }
        }
        else
        {
            ddlSubCat1.Items.Clear();
            ddlSubCat1.Items.Insert(0, new ListItem("-Choose One-", "0"));
            ddlSubCat2.Items.Clear();
            ddlSubCat2.Items.Insert(0, new ListItem("-Choose One-", "0"));
        }
    }
    protected void ddlSubCat1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubCat1.SelectedIndex != 0)
        {
            try
            {
                int? parent = dc.GET_CAT_PARENT(ddlSubCat1.SelectedValue);
                getCat(ddlSubCat2, 3, Int32.Parse(parent.ToString()));
            }
            catch (Exception ex)
            { }
        }
        else
        {
            ddlSubCat2.Items.Clear();
            ddlSubCat2.Items.Insert(0,new ListItem("-Choose One-","0"));
        }
    }
}