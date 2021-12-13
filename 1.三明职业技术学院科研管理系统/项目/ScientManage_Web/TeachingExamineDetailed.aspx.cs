using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class TeachingExamineDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int TeachingId;
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
                if (Request.QueryString["TeachingId"] != null)
                {
                    try
                    {
                        TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByTeachingId("Teaching_SelectByTeachingId", TeachingId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LBookName.Text = dt.Tables[0].Rows[0]["BookName"].ToString();
                    LPressName.Text = dt.Tables[0].Rows[0]["PressName"].ToString();
                    LDCategory.Text = dt.Tables[0].Rows[0]["DCateGory"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    LPressDate.Text = dt.Tables[0].Rows[0]["PressDate"].ToString();
                    LRevision.Text = dt.Tables[0].Rows[0]["Revision"].ToString();
                    LTotalNumber.Text = dt.Tables[0].Rows[0]["TotalNumber"].ToString();
                    LTeachingValue.Text = dt.Tables[0].Rows[0]["TeachingValue"].ToString();
                    LTeachingDate.Text = dt.Tables[0].Rows[0]["TeachingDate"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable Partdt = bus.SelectByTeachingId("TeachingPartner_SelectByTeachingId", TeachingId).Tables[0];
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
                            LPartner.Text += Partdt.Rows[i]["EditedSequence"].ToString() + Partdt.Rows[i]["UserName"].ToString() + "(" + Partdt.Rows[i]["PartnerValue"] + ")";
                        }
                        else
                        {
                            LPartner.Text += Partdt.Rows[i]["EditedSequence"].ToString() + Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")" + ",";
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
            DataSet dy = bus.SelectByTeachingId("TeachingExamine_Select", Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf")));
            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();
            dy.Dispose();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf"));
            if (bus.TeachingExamineInsert("TeachingExamine_Insert", TeachingId, ExamineOpinion, UserCardId, "同意",RankId))
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
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf"));
            if (bus.TeachingExamineInsert("TeachingExamine_Insert", TeachingId, ExamineOpinion, UserCardId, "拒绝",RankId))
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