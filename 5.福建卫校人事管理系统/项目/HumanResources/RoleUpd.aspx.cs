using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RoleUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int RoleId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleId = Convert.ToInt32(Request.QueryString["Role"]);
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

                DataSet ds = bus.SelectByRoleId("Role_SelectByRoleId", RoleId);
                txtRoleName.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string RoleName = txtRoleName.Text.Trim().ToString();
            if (RoleName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职务名称");
                return;
            }
            RoleId = Convert.ToInt32(Request.QueryString["Role"]);
            if (bus.RoleUpdate("Role_Update", RoleId, RoleName))
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