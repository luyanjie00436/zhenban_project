using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ProjectStatusExamineDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int ProjectStatusId;
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
                if (Request.QueryString["ProjectStatusId"] != null)
                {
                    try
                    {
                        ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByProjectStatusId("ProjectStatus_SelectByProjectStatusId", ProjectStatusId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LProjectStatusName.Text = dt.Tables[0].Rows[0]["ProjectStatusName"].ToString();
                    LProjectStatusId.Text = dt.Tables[0].Rows[0]["ProjectId"].ToString();
                    LSource.Text = dt.Tables[0].Rows[0]["Source"].ToString();
                    LPersonnel.Text = dt.Tables[0].Rows[0]["Personnel"].ToString();
                    LSubject.Text = dt.Tables[0].Rows[0]["SubjectName"].ToString();
                    LCooperation.Text = dt.Tables[0].Rows[0]["CooperationName"].ToString();
                    LAims1.Text = dt.Tables[0].Rows[0]["Aims1"].ToString();
                    LAims2.Text = dt.Tables[0].Rows[0]["Aims2"].ToString();
                    LAims3.Text = dt.Tables[0].Rows[0]["Aims3"].ToString();

                    LFunding1.Text = dt.Tables[0].Rows[0]["Funding1"].ToString();
                    LFunding2.Text = dt.Tables[0].Rows[0]["Funding2"].ToString();
                    LFunding3.Text = dt.Tables[0].Rows[0]["Funding3"].ToString();
                    LFunding4.Text = dt.Tables[0].Rows[0]["Funding4"].ToString();
                    LServiceIndustry1.Text = dt.Tables[0].Rows[0]["Service1"].ToString();
                    LServiceIndustry2.Text = dt.Tables[0].Rows[0]["Service2"].ToString();
                    LServiceIndustry3.Text = dt.Tables[0].Rows[0]["Service3"].ToString();
                    LServiceIndustry4.Text = dt.Tables[0].Rows[0]["Service4"].ToString();
                    LCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    LResults.Text = dt.Tables[0].Rows[0]["Results"].ToString();
                    LProjectDate.Text = dt.Tables[0].Rows[0]["ProjectDate"].ToString();
                    LResultsDate.Text = dt.Tables[0].Rows[0]["ResultsDate"].ToString();
                    LStatus.Text = dt.Tables[0].Rows[0]["Status"].ToString();
                    LTransferUnit.Text = dt.Tables[0].Rows[0]["TransferUnit"].ToString();
                    LTransferName.Text = dt.Tables[0].Rows[0]["TransferName"].ToString();
                    LCost1.Text = dt.Tables[0].Rows[0]["Cost1"].ToString();
                    LCost2.Text = dt.Tables[0].Rows[0]["Cost2"].ToString();
                    LCost3.Text = dt.Tables[0].Rows[0]["Cost3"].ToString();
                    LCost4.Text = dt.Tables[0].Rows[0]["Cost4"].ToString();
                    LCost5.Text = dt.Tables[0].Rows[0]["Cost5"].ToString();
                    LCost6.Text = dt.Tables[0].Rows[0]["Cost6"].ToString();
                    LCost7.Text = dt.Tables[0].Rows[0]["Cost7"].ToString();
                }
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LDepartment.Text = dt1.Rows[0]["DepartmentName"].ToString();
                DataSet dy = bus.SelectByProjectStatusId("ProjectStatusExamine_Select", ProjectStatusId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }
            }
        }
             public void dataGriviewBD()
        {
            ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
            DataSet dy = bus.SelectByProjectStatusId("ProjectStatusExamine_Select", ProjectStatusId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }
        }
         protected void Button1_Click(object sender, EventArgs e)
        {
            ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ProjectStatusExamineInsert("ProjectStatusExamine_Insert", ProjectStatusId, ExamineOpinion, UserCardId, "同意", RankId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批失败");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ProjectStatusExamineInsert("ProjectStatusExamine_Insert", ProjectStatusId, ExamineOpinion, UserCardId, "拒绝", RankId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}