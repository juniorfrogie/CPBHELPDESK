using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using MyExtensions;
using System.Security.Principal;

public partial class UserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserID.Focus();            
        }        
    }


    protected void getGroupData()
    {
        // collect the user domain and identity
        string[] arr = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');

        PrincipalContext domain = new PrincipalContext(ContextType.Domain);
        UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domain, arr[1].ToString());
        Session["UserGroup"] = userPrincipal.GetgroupPriority();
        if (userPrincipal.GetDepartment() == "Admin and Procurement" || userPrincipal.GetDepartment() == "IT Department")
        {
            Session["Location"] = "HQ";
        }
        else
        {
            Session["Location"] = userPrincipal.GetDepartment();
        }

        // update the display to show
        // the captured domain and user
        if (arr.Length > 0)
        {
            Session["UserLogin"] = arr[1].ToString().ToUpper();
        }
    }


    protected void cmdlogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataClassesDataContext db = new DataClassesDataContext();
            var userloin = (from u in db.tbluserLogins
                            //where u.UserName == this.UserID.Text.Trim() && u.Password == this.Password.Text
                            where (u.USERLOGIN.Equals(this.UserID.Text.Trim())) && (u.PASSWORD.Equals(Registors.Encrypt(this.Password.Text)))
                            select u).Count();
            var qChecked = (from u in db.tbluserLogins
                            //where u.UserName == this.UserID.Text.Trim() && u.Password == this.Password.Text
                            where (u.USERLOGIN.Equals(this.UserID.Text.Trim())) && (u.PASSWORD.Equals(Registors.Encrypt(this.Password.Text)))
                            select u).Single();
            
            if (userloin > 0)
            {
                Session["UserLogin"] = this.UserID.Text;
                Session["UserGroup"] = qChecked.USERGROUP;
                Session["Location"] = qChecked.LOCATION;
                Response.Redirect("Default.aspx");
            }
            else {
                lblMsg.Text = "Invalid user name and password !." + "<br/>";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Invalid user name and password!." + "<br/>" + ex.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
}