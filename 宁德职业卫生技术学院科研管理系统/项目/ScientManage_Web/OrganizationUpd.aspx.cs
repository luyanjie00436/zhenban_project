using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class OrganizationUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int OrganizationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            OrganizationId = Convert.ToInt32(Request.QueryString["Organization"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/OrganizationManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByOrganizationId("Organization_SelectByOrganizationId", OrganizationId);
                txtOrganizationName.Text = ds.Tables[0].Rows[0]["OrganizationName"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string OrganizationName = txtOrganizationName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (OrganizationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写社会经济目标名称");
                return;
            }
            OrganizationId = Convert.ToInt32(Request.QueryString["Organization"]);
            if (bus.OrganizationUpdate("Organization_Update", OrganizationId, OrganizationName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("OrganizationManage.aspx");
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