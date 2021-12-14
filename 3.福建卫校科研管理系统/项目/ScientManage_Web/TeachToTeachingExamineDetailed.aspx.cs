using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class TeachToTeachingExamineDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int TeachToTeachingId;
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
                if (Request.QueryString["TeachToTeachingId"] != null)
                {
                    try
                    {
                        TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByTeachToTeachingId("TeachToTeaching_SelectByTeachToTeachingId", TeachToTeachingId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LQuantity.Text = dt.Tables[0].Rows[0]["Quantity"].ToString();
                    LTotalScore.Text = dt.Tables[0].Rows[0]["TotalScore"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
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
            TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
            DataSet dy = bus.SelectByTeachToTeachingId("TeachToTeachingExamine_Select", TeachToTeachingId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.TeachToTeachingExamineInsert("TeachToTeachingExamine_Insert", TeachToTeachingId, ExamineOpinion, UserCardId, "同意", RankId))
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
            TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.TeachToTeachingExamineInsert("TeachToTeachingExamine_Insert", TeachToTeachingId, ExamineOpinion, UserCardId, "拒绝", RankId))
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