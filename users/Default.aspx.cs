using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Default : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
          if(string.IsNullOrEmpty(Session["UserLogin"] as String)){
              Response.Redirect("~/Login.aspx");
          }
        }
    }
}