using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class WorkLoadProjectsExamineDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int WorkLoadProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["WorkLoadProjectsId"] != null)
                {
                    try
                    {
                        WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByWorkLoadProjectsId("WorkLoadProjects_SelectByWorkLoadProjectsId", WorkLoadProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    //LCateGory.Text=dt.Tables[0].Rows[0]["CateGory"].ToString();
                    LDCategory.Text = dt.Tables[0].Rows[0]["DCateGory"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    LProjectsId.Text = dt.Tables[0].Rows[0]["ProjectsId"].ToString();
                    LWorkLoadProjectsFrom.Text = dt.Tables[0].Rows[0]["WorkLoadFrom"].ToString();

                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LWorkLoadProjectsName.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsName"].ToString();
                    LProjectDate.Text = dt.Tables[0].Rows[0]["ProjectDate"].ToString();
                    LConcludingDate.Text = dt.Tables[0].Rows[0]["ConcludingDate"].ToString();
                    LWorkLoadProjectsCapital.Text = dt.Tables[0].Rows[0]["WorkLoadCapital"].ToString();
                    LWorkLoadProjectsValue.Text = dt.Tables[0].Rows[0]["ProjectsValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable Partdt = bus.SelectByWorkLoadProjectsId("WorkLoadProjectsPartner_SelectByWorkLoadProjectsId", WorkLoadProjectsId).Tables[0];
                if (Partdt.Rows.Count == 0)
                {
                    LPartner.Text = "无";
                }
                else
                {
                    for (int i = 0; i < Partdt.Rows.Count; i++)
                    {
                        if (i == Partdt.Rows.Count - 1)
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")";
                        }
                        else
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")" + ",";
                        }
                    }
                }
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LUserJob.Text = dt1.Rows[0]["JobName"].ToString();
                LUserPost.Text = dt1.Rows[0]["PostName"].ToString();
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
            DataSet dy = bus.SelectByWorkLoadProjectsId("WorkLoadProjectsExamine_Select", WorkLoadProjectsId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.WorkLoadProjectsExamineInsert("WorkLoadProjectsExamine_Insert", WorkLoadProjectsId, ExamineOpinion, UserCardId, "同意", RankId))
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
            WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.WorkLoadProjectsExamineInsert("WorkLoadProjectsExamine_Insert", WorkLoadProjectsId, ExamineOpinion, UserCardId, "拒绝", RankId))
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