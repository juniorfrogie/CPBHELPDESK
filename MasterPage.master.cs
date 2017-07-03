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
using System.Configuration;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getGroupData();
            DataClassesDataContext dc = new DataClassesDataContext();
            Session["sid"] = dc.GET_STAFF_ID_BY_NAME(Session["UserLogin"].ToString());
        }
    }

    protected void getGroupData()
    {
        // collect the user domain and identity
        string[] arr = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');

        PrincipalContext domain = new PrincipalContext(ContextType.Domain);
        UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domain, arr[1].ToString());

        Session["UserGroup"] = userPrincipal.GetgroupPriority();

        if (userPrincipal.GetDepartment() == "Credit" || userPrincipal.GetDepartment() == "Auditor" || userPrincipal.GetDepartment() == "MIS" || userPrincipal.GetDepartment() == "Management" || userPrincipal.GetDepartment() == "Finance" || userPrincipal.GetDepartment() == "HR" || userPrincipal.GetDepartment() == "Admin and Procurement" || userPrincipal.GetDepartment() == "Operation" || userPrincipal.GetDepartment() == "Marketing" || userPrincipal.GetDepartment() == "IT Department")
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
            Session["User"] = arr[1].ToString().ToUpper();
        }

        string[] str = arr[1].ToString().Split('.');
        if (arr.Length > 0)
        {
            foreach (string s in str)
            {
                Session["UserLogin"] = str[1] + " " + str[0].ToString();
                if (Session["UserLogin"].ToString() == "kann samrech")
                {
                    Session["UserLogin"] = "toch chaochek";
                }
            }
        }
		SqlConnection con = new SqlConnection();
	        con.ConnectionString = ConfigurationManager.ConnectionStrings["DBREPORTConnectionString"].ConnectionString;
        	con.Open();	
        
        string query = "select user_group_id from tblUserGroupID where user_name = '" + Session["User"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.Text;
        //SqlDataReader dr = new SqlDataReader();
        SqlDataReader dr = cmd.ExecuteReader();
	
        while (dr.Read())
        {
            if (dr["user_group_id"].ToString().Trim() == "Leave Online-Admins" || dr["user_group_id"].ToString().Trim() == "IT Administrator")
            {
                pnlAdmin.Attributes.Add("style", "display:block");
                pnlSimpleUser.Attributes.Add("style", "display:block");
                pnlReport.Attributes.Add("style", "display:block");
                TreeView2.Nodes[0].Text = "CPBANK MENU REQUEST";
                Session["admin"] = true;
                break;
            }
            else if (dr["user_group_id"].ToString().Trim() == "Leave Online-Users")
            {
                pnlSimpleUser.Attributes.Add("style", "display:none");
                pnlCertifierAuthorizer.Attributes.Add("style", "display:block");
                break;
            }
	    else if (dr["user_group_id"].ToString().Trim() == "IT Super Activity")
            {
                pnlSimpleUser.Attributes.Add("style", "display:none");
                pnlCertifierAuthorizer.Attributes.Add("style", "display:block");
		pnlReport.Attributes.Add("style", "display:block");
                break;
            }	
            else
            {
                pnlSimpleUser.Attributes.Add("style", "display:block");
            }
        }

        con.Close();

        // update the display to show
        // the captured domain and user

        //if (arr.Length > 0)
        //{
        //    Session["UserLogin"] = arr[1].ToString().ToUpper();            
        //}

        //// create an arraylist and populate
        //// it with the list of groups that
        //// the current user belongs to
        //ArrayList al = new ArrayList();
        //al = GetGroups();

        //// ArrayList idList = (ArrayList)Session["Group"];
        //foreach (string s in al)
        //{
        //    if (s.Contains(@"ADCPBANK\Intranet"))
        //    {
        //        if (s != @"ADCPBANK\Intranet Groups")
        //        {
        //            if (s.Replace(@"ADCPBANK\Intranet", "").Trim() == "Leave Online-Admins" || s.Replace(@"ADCPBANK\Intranet", "").Trim() == "IT Administrator" || Session["UserLogin"].ToString()=="HENG DARA")
        //            {
        //                pnlAdmin.Attributes.Add("style", "display:block");
        //                pnlSimpleUser.Attributes.Add("style", "display:block");
        //                pnlReport.Attributes.Add("style","display:block");
        //                TreeView2.Nodes[0].Text = "CPBANK MENU REQUEST";
        //                Session["admin"] = true;
        //                break;
        //            }
        //            else if (s.Replace(@"ADCPBANK\Intranet", "").Trim() == "Leave Online-Users")
        //            {                        
        //                pnlSimpleUser.Attributes.Add("style", "display:none");
        //                pnlCertifierAuthorizer.Attributes.Add("style", "display:block");
        //                break;
        //            }
        //            else
        //            {
        //                pnlSimpleUser.Attributes.Add("style", "display:block");
        //            }
        //        }
        //    }
        //}
    }

    /// <summary>
    /// Get a list of all of the groups the current
    /// user is a member of to support test of 
    /// MyLifeSpaceAdmin membership
    /// </summary>
    /// <returns></returns>
    public ArrayList GetGroups()
    {
        ArrayList groups = new ArrayList();
        foreach (System.Security.Principal.IdentityReference group in
            System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
        {
            try
            {
                groups.Add(group.Translate(typeof(System.Security.Principal.NTAccount)).ToString());
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        return groups;
    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
