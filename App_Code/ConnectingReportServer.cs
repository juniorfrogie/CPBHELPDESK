using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for ConnectingReportServer
/// </summary>
public class ConnectingReportServer : Microsoft.Reporting.WebForms.IReportServerCredentials
{
    private string _username;
    private string _password;
    private string _domain;

    public static string username = "CPBDEPLOY";
    public static string password = "cp@DepSql";
    public static string domain = "adcpbank";
    public ConnectingReportServer(string username, string password, string domain)
	{
		//
		// TODO: Add constructor logic here
		//
        _username = username;
        _password = password;
        _domain = domain;
	}
    public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
    {
        authCookie = null;
        userName = null;
        password = null;
        authority = null;
        // Not using form credentials
        return false;
    }

    public System.Security.Principal.WindowsIdentity ImpersonationUser
    {
        get { return null; }
    }

    public System.Net.ICredentials NetworkCredentials
    {
        get { return new NetworkCredential(_username, _password, _domain); }
    }
}