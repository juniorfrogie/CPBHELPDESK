using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Create : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            txtProbation.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            if(!string.IsNullOrEmpty(Session["UserLogin"] as String)){
                LoadUser();
                LoadDepartment();
            }else{
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        try {
            db.SP_INSERT_STAFFINFO(txtIDCard.Text, txtNameEN.Text, txtNameKH.Text, ddlGender.Text, txtStatus.Text, txtPosition.Text, ddlDeparment.Text, txtLocation.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtProbation.Text), txtPhoneNum.Text,txtEmail .Text);
            db.SubmitChanges();
            Response.Redirect("ListDetail.aspx?id=" + txtIDCard.Text);
        }
        catch(Exception ex){
            lblMsg.Text = "";
            lblMsg.Text = "Save Block " + ex.Message;
        }
    }
    private void Cleartxt()
    {
        try
        {
            txtIDCard.Text ="";
            txtNameEN.Text="";
            txtNameKH.Text="";
            ddlGender.Text =null;
            txtStatus.Text="";
            txtPosition.Text=null;
            ddlDeparment.Text="";
            txtLocation.Text="";
            txtStartDate.Text="";
            txtPhoneNum.Text = "";
        }
        catch (Exception ex) {
            lblMsg.Text = "";
            lblMsg.Text = "Clear Block " + ex.Message;
        }
    }
    private void LoadUser()
    {
        try
        {
            var rows = (from l in db.tblStaffinfos where l.IDCard == Request.QueryString["id"] select l).Single();
            txtIDCard.Text = rows.IDCard;
            txtNameEN.Text = rows.Name;
            txtNameKH.Text = rows.NameKhmer;
            ddlGender.Text = rows.Sex;
            txtStatus.Text = rows.Status;
            txtPosition.Text = rows.Position;
            ddlDeparment.Text = rows.Department;
            txtLocation.Text = rows.Location;
            txtStartDate.Text = Convert.ToDateTime(rows.StartingDate).ToString("dd/MM/yyyy");
            txtProbation.Text = Convert.ToDateTime(rows.ProbationDate).ToString("dd/MM/yyyy");
            txtPhoneNum.Text = rows.PhoneNumber;
            txtEmail.Text = rows.Email;
            txtIDCard.Enabled = false;
            cmdSave.Enabled = false;
            cmdEdit.Enabled = true;
        }
        catch (Exception ex) {
            lblMsg.Text = "";
        }
    }
    protected void cmdEdit_Click(object sender, EventArgs e)
    {
        try {
            db.SP_UPDATE_STAFFINFO(txtIDCard.Text, txtNameEN.Text, txtNameKH.Text, ddlGender.Text, txtStatus.Text, txtPosition.Text, ddlDeparment.Text, txtLocation.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtProbation .Text ), txtPhoneNum.Text,txtEmail .Text );
            db.SubmitChanges();
            Response.Redirect("ListDetail.aspx?id="+ Request.QueryString["id"]);
        }
        catch (Exception ex) {
            lblMsg.Text = "";
            lblMsg.Text = "Edit Staff Block " + ex.Message;
        }
    }
    private void LoadDepartment()
    {
        try
        {
            var query2 = (from p in db.tblStaffinfos where p.Department != "" && p.Department != "12" select new { p.Department }).Distinct();
            ddlDeparment.DataSource = query2;
            ddlDeparment.DataTextField = "Department";
            ddlDeparment.DataValueField = "Department";
            ddlDeparment.DataBind();
            ddlDeparment.Items.Insert(0, new ListItem("- Choose -", "0"));
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            lblMsg.Text = "Load Post" + ex.Message;
        }
    }
    protected void cmdDelte_Click(object sender, EventArgs e)
    {
        try {
            db.tblStaffinfos.DeleteOnSubmit(db.tblStaffinfos.Single(u=> u.IDCard == Request.QueryString["id"].ToString()));
            db.SP_Ledger((txtIDCard.Text + " " + txtNameEN.Text), Session["UserLogin"].ToString(), DateTime.Now, Request.Url.ToString(), null, null, null, null, null);
            db.SubmitChanges();
            Response.Redirect("~/users/Default.aspx");
        }
        catch (Exception ex) {
            lblMsg.Text = ex.Message;
        }
    }
}

