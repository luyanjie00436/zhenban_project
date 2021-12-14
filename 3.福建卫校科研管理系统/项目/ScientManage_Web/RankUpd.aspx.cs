using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class RankUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int RankId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            RankId = Convert.ToInt32(Request.QueryString["Rank"]);
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

                DataSet ds = bus.SelectByRankId("Rank_SelectByRankId", RankId);
                txtRankName.Text = ds.Tables[0].Rows[0]["RankName"].ToString();
                RBList1.SelectedValue = ds.Tables[0].Rows[0]["RBL"].ToString();
                RBList2.SelectedValue = ds.Tables[0].Rows[0]["RBL2"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string RankName = txtRankName.Text.Trim().ToString();
            string RBL1 = RBList1.SelectedValue;
            string RBL2 = RBList2.SelectedValue;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (RankName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写角色名称");
                return;
            }
            if (RBL1 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否可修改个人信息");
                return;
            }
            if (RBL2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否可查看所有用户申报信息");
                return;
            }
            RankId = Convert.ToInt32(Request.QueryString["Rank"]);
            if (bus.RankUpdate("Rank_Update", RankId, RankName,UserCardId,RBL1,RBL2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
              //  Response.Redirect("RankManage.aspx");
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