using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_CreateUserLogin : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {    
            LoadddlPosition();
            LoadddlLocation();
            LoadEdit();    
        }
    }
    private void LoadddlLocation()
    {
        try
        {
            var query3 = (from p in db.tblStaffinfos where p.Position != "" && p.Position != "12" select new { p.Location }).Distinct();
            ddlLocation.DataSource = query3;
            ddlLocation.DataTextField = "LOCATION";
            ddlLocation.DataValueField = "LOCATION";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("- Choose -", "0"));
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            lblMsg.Text = "Load Post" + ex.Message;
        }
    }
    private void LoadddlPosition()
    {
        try
        {
            var query2 = (from p in db.tblStaffinfos
                          where p.Position != "" && p.Position != "12"
                          select new { p.Position }).Distinct();
            ddlPosition.DataSource = query2;
            ddlPosition.DataTextField = "Position";
            ddlPosition.DataValueField = "Position";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("- Choose -", "0"));
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            lblMsg.Text = "Load Post" + ex.Message;
        }
    }
    protected void cmdSumit_Click(object sender, EventArgs e)
    {
        try
        {
            tbluserLogin l = new tbluserLogin();
            l.USERLOGIN = txtLogin.Text;
            l.PASSWORD = Registors.Encrypt(txtPassword.Text);
            l.POSITION = ddlPosition.Text;
            l.USERGROUP = ddlUserGroup.Text;
            l.LOCATION = ddlLocation.Text;
            db.tbluserLogins.InsertOnSubmit(l);
            db.SubmitChanges();
            txtClear();
        }
        catch (Exception ex) {
            lblMsg.Text = "";
            lblMsg.Text = "Submit Block" + ex.Message;
        }
    }
    private void LoadEdit()
    {
        try {
            var qe = (from u in db.tbluserLogins where u.ID == int.Parse(Request.QueryString["id"]) select u).Single();
            txtLogin.Text = qe.USERLOGIN;
            txtPassword.Text = qe.PASSWORD;
            ddlPosition.Text = qe.POSITION;
            ddlUserGroup.Text = qe.USERGROUP;
            ddlLocation.Text = qe.LOCATION;
        }
        catch (Exception ex) { 
        
        }
    }
    private void txtClear()
    {
        txtLogin.Text = null;
        ddlPosition.Text = null;
        ddlLocation.Text = null;
    }
    protected void cmdEdit_Click(object sender, EventArgs e)
    {
        try
        {
            tbluserLogin l = db.tbluserLogins.Single(u => u.ID == int.Parse(Request.QueryString["id"]));
            l.USERLOGIN = txtLogin.Text;
            l.PASSWORD = Registors.Encrypt(txtPassword.Text);
            l.POSITION = ddlPosition.Text;
            l.USERGROUP = ddlUserGroup.Text;
            l.LOCATION = ddlLocation.Text;
            db.SubmitChanges();
            txtClear();
        }
        catch (Exception ex) {
            lblMsg.Text = ex.Message;
        }
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        try
        {
            db.tbluserLogins.DeleteOnSubmit(db.tbluserLogins.Single(u => u.ID == int.Parse(Request.QueryString["id"].ToString())));
            db.SP_Ledger(txtLogin.Text, Session["UserLogin"].ToString(), DateTime.Now, Request.Url.ToString(), null, null, null, null, null);
            db.SubmitChanges();
            Response.Redirect("~/users/ViewUserLogin.aspx");
        }
        catch (Exception ex) {
            lblMsg.Text = ex.Message;
        }
    }
}