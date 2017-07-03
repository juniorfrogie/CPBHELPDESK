using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_add_cob : System.Web.UI.Page
{
    DataClassesDataContext dc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                                
            }
        }
    }
    
    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

            ClearInputs(ctrl.Controls);
        }
    }
    protected void deleteDuplicate(DateTime date)
    {
        if (date != null)
        {            
            var query = from q in dc.tblSysDatas
                        where q.key_type == "COB" && q.key_desc == date.ToShortDateString()
                        select q;
            dc.tblSysDatas.DeleteAllOnSubmit(query);
            dc.SubmitChanges();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string[] lblSystem = new string[5];
        deleteDuplicate(DateTime.Parse(txtReportDate.Value));
        lblSystem[0] = "Cut of Business (COB)";
        lblSystem[1] = "Upload NBC Report";
        lblSystem[2] = "System Online";
        lblSystem[3] = "Daily Generate Report";
        
        int j = 0;
        for(int i=0;i<=3;i++)
        {
            j = i+1;
            tblSysData newSys = new tblSysData();
            TextBox start = (TextBox)FindControl(string.Concat("ctl00$ContentPlaceHolder1$txtStart", j.ToString()));
            TextBox end = (TextBox)FindControl(string.Concat("ctl00$ContentPlaceHolder1$txtEnd", j.ToString()));
            DropDownList status = (DropDownList)FindControl(string.Concat("ctl00$ContentPlaceHolder1$ddlStatus", j.ToString()));
            newSys.key_code = dc.GET_MAX_SYSDATA_KEY_CODE();
            newSys.key_type = "COB";
            newSys.key_desc = txtReportDate.Value;
            newSys.key_data = start.Text;
            newSys.key_data1 = end.Text;
            newSys.key_data2 = status.SelectedValue;
            newSys.user_updt = lblSystem[i];
            dc.tblSysDatas.InsertOnSubmit(newSys);
            dc.SubmitChanges();            
        }
        ClearInputs(Page.Controls);
        lblMsg.Text = "You have successfully saved this COB info!";
        Panel1.Visible = true;        
    }
    
}