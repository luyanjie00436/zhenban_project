using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class CooperationUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int CooperationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            CooperationId = Convert.ToInt32(Request.QueryString["Cooperation"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/CooperationManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByCooperationId("Cooperation_SelectByCooperationId", CooperationId);
                txtCooperationName.Text = ds.Tables[0].Rows[0]["CooperationName"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CooperationName = txtCooperationName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (CooperationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写合作形式名称");
                return;
            }
            CooperationId = Convert.ToInt32(Request.QueryString["Cooperation"]);
            if (bus.CooperationUpdate("Cooperation_Update", CooperationId, CooperationName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("CooperationManage.aspx");
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