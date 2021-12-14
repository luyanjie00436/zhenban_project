using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class UseOfficeUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int UseOfficeId;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Role = bus.Select("ProfessionQualification_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProfessionQualificationName"].ToString(), dr["ProfessionQualificationId"].ToString());
                    txtProfessionQualificationName.Items.Add(li);
                }

                if (Request.QueryString["UseOffice"] != null)
                {
                    try
                    {
                        UseOfficeId = Convert.ToInt32(Request.QueryString["UseOffice"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                   
                    DataSet ds = bus.SelectByUseOfficeId("UseOffice_SelectByUseOfficeId", UseOfficeId);
                    txtAppointmentDate.Text=ds.Tables[0].Rows[0]["AppointmentDate"].ToString();
                    txtProfession.Text= ds.Tables[0].Rows[0]["Profession"].ToString();
                    txtProfessionQualificationName.SelectedValue= ds.Tables[0].Rows[0]["ProfessionQualificationId"].ToString();
                    txtRemarks.Text= ds.Tables[0].Rows[0]["Remarks"].ToString();
                    try
                    {
                        RlTransferStatus.SelectedValue = ds.Tables[0].Rows[0]["TransferStatus"].ToString();
                    }
                    catch 
                    {

                       
                    }
                    tr_sczp.Visible = false;
                    tr_sfzg.Visible = false;

                }
                else
                {                   
                    Button2.Visible= false;
                    RlGL_Management.Visible = false;
                }

               
            }
        }
      

      
      
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value); ;
            UseOfficeId = Convert.ToInt32(Request.QueryString["UseOffice"]);
            string AppointmentDate = txtAppointmentDate.Text.Trim();
            string Profession = txtProfession.Text.Trim();
            int ProfessionQualificationId = Convert.ToInt32(txtProfessionQualificationName.SelectedValue);
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedValue;
            

            if (bus.UseOfficeStatusUpdate("UseOfficeStayus_Update", UseOfficeId, UserCardId, AppointmentDate, Profession, ProfessionQualificationId, Remarks, TransferStatus))
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");

            }
        }
     
    }
}