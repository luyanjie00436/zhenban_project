using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class TypeActivityUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int TypeActivityId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            TypeActivityId = Convert.ToInt32(Request.QueryString["TypeActivity"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TypeActivityManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByTypeActivityId("TypeActivity_SelectByTypeActivityId", TypeActivityId);
                txtTypeActivityName.Text = ds.Tables[0].Rows[0]["TypeActivityName"].ToString();
      
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string TypeActivityName = txtTypeActivityName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (TypeActivityName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写活动类型名称");
                return;
            }
            TypeActivityId = Convert.ToInt32(Request.QueryString["TypeActivity"]);
            if (bus.TypeActivityUpdate("TypeActivity_Update", TypeActivityId, TypeActivityName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("TypeActivityManage.aspx");
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