using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UserMyPwd : System.Web.UI.Page
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
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string OldPwd = txtOldPwd.Text.Trim().ToString();
            string NewPwd = txtNewPwd.Text.Trim().ToString();
            string NewPwd2 = txtNewPwd2.Text.Trim().ToString();
            if (NewPwd.Length < 6)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码长度太短");
                return;
            }
            if (NewPwd == "" || NewPwd2 == "" || OldPwd == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码不能为空");
                return;
            }
            if (NewPwd != NewPwd2)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "输入密码不一致");
                return;
            }
            string UserNewPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPwd.Text.Trim(), "MD5");
            string UserOldPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPwd.Text.Trim(), "MD5");
            if (bus.UserPwdUpdate("UserInfo_UpdatePwd", UserCardId, UserOldPwd, UserNewPwd))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                return;
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码输入错误");
                return;
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        public void clearIfo()
        {
            txtOldPwd.Text = "";
            txtNewPwd.Text = "";
            txtNewPwd2.Text = "";
        }
    }
}