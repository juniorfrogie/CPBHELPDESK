﻿using System;
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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //getGroupData();
        }
    }

    //protected void getGroupData()
    //{
    //    // collect the user domain and identity
    //    string[] arr = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');

    //    PrincipalContext domain = new PrincipalContext(ContextType.Domain);
    //    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domain, arr[1].ToString());
    //    Session["UserGroup"] = userPrincipal.GetgroupPriority();
    //    if (userPrincipal.GetDepartment() == "Admin and Procurement" || userPrincipal.GetDepartment() == "IT Department")
    //    {
    //        Session["Location"] = "HQ";            
    //    }
    //    else
    //    {
    //        Session["Location"] = userPrincipal.GetDepartment();
    //    }

    //    // update the display to show
    //    // the captured domain and user
    //    if (arr.Length > 0)
    //    {
    //        Session["UserLogin"] = arr[1].ToString().ToUpper();
    //    }
    //}
}