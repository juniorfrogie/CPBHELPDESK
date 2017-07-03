using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Registors
/// </summary>
public class Registors
{
    public static string username = "CPBDEPLOY"; // server name :CPBDEPLOY
    public static string password = "cp@DepSql"; // server password:cp@DepSql
    public static string domain = "adcpbank";  // domain mane
    public static string reportURL = "http://10.18.1.150/ReportServer";   // location report store 
    public static string reportPath = "/T24Reports/";  // report path name /T24Reports/
    public static int reportWidth = 95;
    public static int reportHeight = 407;

    public static string Encrypt(string clearText)
    {
        string EncryptionKey = "CHEABORIN2014";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}