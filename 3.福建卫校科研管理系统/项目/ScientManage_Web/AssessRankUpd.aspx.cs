using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class AssessRankUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int AssessRankId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessRankId = Convert.ToInt32(Request.QueryString["AssessRank"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                DataSet ds = bus.SelectByAssessRankId("AssessRank_SelectByAssessRankId", AssessRankId);
                txtRankName.Text = ds.Tables[0].Rows[0]["RankName"].ToString();
                txtMinValue.Text = ds.Tables[0].Rows[0]["RankMinValue"].ToString();
                txtMaxValue.Text = ds.Tables[0].Rows[0]["RankMaxValue"].ToString();
                txtExplain.Text = ds.Tables[0].Rows[0]["RankExplain"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            AssessRankId = Convert.ToInt32(Request.QueryString["AssessRank"]);
            string RankName = txtRankName.Text.Trim();
            string RankMinValue = txtMinValue.Text.Trim();
            string RankMaxValue = txtMaxValue.Text.Trim();
            string Explain = txtExplain.Text.Trim();
            double MinValue = 0;
            double MaxValue = 0;
            if (RankName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写考核等级名称");
                return;
            }
            if (RankMinValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写最小需求分值");
                return;
            }
            try
            {
                MinValue = Convert.ToDouble(RankMinValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最小需求分值请输入正整数");
                return;
            }
            if (MinValue < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最小需求分值请输入正整数");
                return;
            }
            if (RankMaxValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写最大需求分值");
                return;
            }
            try
            {
                MaxValue = Convert.ToDouble(RankMaxValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最大需求分值请输入正整数");
                return;
            }
            if (MaxValue < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最大需求分值请输入正整数");
                return;
            }

            if (Explain == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写说明");
                return;
            }
            if (bus.AssessRankUpdate("AssessRank_Update", AssessRankId, RankName, MinValue, MaxValue, Explain,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
              //  Response.Redirect("AssessRankManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}