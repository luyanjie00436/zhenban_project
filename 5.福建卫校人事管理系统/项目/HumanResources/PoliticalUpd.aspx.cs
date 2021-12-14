using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class PoliticalUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int PoliticalId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            PoliticalId = Convert.ToInt32(Request.QueryString["Political"]);
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

                DataSet ds = bus.SelectByPoliticalId("Political_SelectByPoliticalId", PoliticalId);
                txtPoliticalName.Text = ds.Tables[0].Rows[0]["PoliticalName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string PoliticalName = txtPoliticalName.Text.Trim().ToString();
            if (PoliticalName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写政治面貌名称");
                return;
            }
            PoliticalId = Convert.ToInt32(Request.QueryString["Political"]);
            if (bus.PoliticalUpdate("Political_Update", PoliticalId, PoliticalName))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
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