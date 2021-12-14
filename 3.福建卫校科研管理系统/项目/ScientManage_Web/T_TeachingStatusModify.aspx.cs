using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class T_TeachingStatusModify : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int T_TeachingId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["T_TeachingId"] != null)
                {
                    try
                    {
                        T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByT_TeachingId("T_Teaching_SelectByT_TeachingId", T_TeachingId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LT_TeachingName.Text = dt.Tables[0].Rows[0]["T_TeachingName"].ToString();
                    LCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    LPress.Text = dt.Tables[0].Rows[0]["Press"].ToString();
                    LTime.Text = dt.Tables[0].Rows[0]["Time"].ToString();
                    LEdition.Text = dt.Tables[0].Rows[0]["Edition"].ToString();
                    LCompiledwords.Text = dt.Tables[0].Rows[0]["Compiledwords"].ToString();
                    LEditorRanking.Text = dt.Tables[0].Rows[0]["EditorRanking"].ToString();
                    LScore.Text = dt.Tables[0].Rows[0]["Score"].ToString();
                    LReference.Text = dt.Tables[0].Rows[0]["Reference"].ToString();
                    LTotalscore.Text = dt.Tables[0].Rows[0]["Totalscore"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LPartnerValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();

                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
            DataSet dy = bus.SelectByT_TeachingId("T_TeachingExamine_Select", T_TeachingId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.T_TeachingStatusModifyInsert("T_TeachingStatusModify_Insert", T_TeachingId, ExamineOpinion, UserCardId, "同意"))
            {
                AlertMsgAndNoFlush("审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush("审批失败");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.T_TeachingStatusModifyInsert("T_TeachingStatusModify_Insert", T_TeachingId, ExamineOpinion, UserCardId, "拒绝"))
            {
                AlertMsgAndNoFlush("审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush("审批失败");
            }

        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
            //ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}