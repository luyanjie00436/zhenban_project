using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{

    public partial class RoleUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet ds = bus.SelectByRoleId("Role_SelectByRoleId", RoleId);
                txtRoleName.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string RoleName = txtRoleName.Text.Trim().ToString();
            if (RoleName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职务名称");
                return;
            }
            RoleId = Convert.ToInt32(Request.QueryString["Role"]);
            if (bus.RoleUpdate("Role_Update", RoleId, RoleName,UserCardId))
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