using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class JobCertificateUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int JobCertificateId;
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

                if (Request.QueryString["JobCertificate"] != null)
                {
                    try
                    {
                        JobCertificateId = Convert.ToInt32(Request.QueryString["JobCertificate"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                  
                    DataSet ds = bus.SelectByJobCertificateId("JobCertificate_SelectByJobCertificateId", JobCertificateId);
                    txtJobQualificationName.Text = ds.Tables[0].Rows[0]["JobQualificationName"].ToString();
                    txtIsssueUnit.Text = ds.Tables[0].Rows[0]["IsssueUnit"].ToString();
                    txtJobDate.Text = ds.Tables[0].Rows[0]["JobDate"].ToString();                 
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();                   
                    tr_sczp.Visible = false;
                    tr_sfzg.Visible = false;

                }
                else
                {
                   
                    Button2.Visible = false;
                    RlGL_Management.Visible = false;
                }


            }
        }
     

        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            JobCertificateId = Convert.ToInt32(Request.QueryString["JobCertificate"]);
            string JobQualificationName = txtJobQualificationName.Text.Trim();
            string IsssueUnit = txtIsssueUnit.Text.Trim();
            string JobDate = txtJobDate.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedValue;


          

            if (bus.JobCertificateStayusUpdate("JobCertificate_Update", JobCertificateId, UserCardId, JobQualificationName, IsssueUnit, JobDate, Remarks, TransferStatus))
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