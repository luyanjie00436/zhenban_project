using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class AssessRankAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        string UserCardId;
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                clearIfo();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
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

            if (bus.AssessRankInsert("AssessRank_Insert", RankName, MinValue, MaxValue, Explain,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public void clearIfo()
        {
            txtRankName.Text = "";
            txtMinValue.Text = "";
            txtMaxValue.Text = "";
            txtExplain.Text = "";

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}