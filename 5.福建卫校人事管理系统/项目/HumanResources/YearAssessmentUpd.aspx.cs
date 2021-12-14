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
    public partial class YearAssessmentUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int YearAssessmentId;
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
               
                if (Request.QueryString["YearAssessment"] != null)
                {
                    try
                    {
                        YearAssessmentId = Convert.ToInt32(Request.QueryString["YearAssessment"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    DataSet ds = bus.SelectByYearAssessmentId("YearAssessment_SelectByYearAssessmentId", YearAssessmentId);
                    txtYear.Text = ds.Tables[0].Rows[0]["Year"].ToString();
                    txtWorkCompletion.Text = ds.Tables[0].Rows[0]["WorkCompletion"].ToString();
                    txtAssessmentGrade.Text = ds.Tables[0].Rows[0]["AssessmentGrade"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    try
                    {
                        RlTransferStatus.SelectedValue = ds.Tables[0].Rows[0]["TransferStatus"].ToString();
                    }
                    catch
                    {
                    }

                }
                else
                {                   
                    Button2.Visible = false;                  
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            YearAssessmentId = Convert.ToInt32(Request.QueryString["YearAssessment"]);
            string Year = txtYear.Text.Trim();
            string WorkCompletion = txtWorkCompletion.Text.Trim();
            string AssessmentGrade = txtAssessmentGrade.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedValue;

           
            if (bus.YearAssessmentUpdate("YearAssessment_Update", YearAssessmentId, UserCardId, Year, WorkCompletion, AssessmentGrade, Remarks,TransferStatus))
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