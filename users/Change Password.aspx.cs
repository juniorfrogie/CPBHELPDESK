using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Change_Password : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            tbluserLogin uc = db.tbluserLogins.Single(u => u.USERLOGIN == (string)Session["UserLogin"].ToString());
            if (uc.PASSWORD == Registors.Encrypt(this.txtCurrentPassword.Text))
            {
                uc.PASSWORD = Registors.Encrypt(this.txtPassword.Text);
                db.SubmitChanges();
                ErrorPassword.Text = "Password changed successful, Thanks!";
                ErrorPassword.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                ErrorPassword.Text = "Sorry you are wrong old password!, Please try agian!";
                ErrorPassword.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            ErrorPassword.Text = "";
            ErrorPassword.Text = ex.Message;
            ErrorPassword.ForeColor = System.Drawing.Color.Red;
        }
    }
}