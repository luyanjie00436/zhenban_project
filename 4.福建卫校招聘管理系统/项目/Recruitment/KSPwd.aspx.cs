using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class KSPwd : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        string Number;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='index.aspx'<" + "/script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
            string Pwd = txtPwd1.Text.Trim().ToString();
            string Pwd1 = txtPwd2.Text.Trim().ToString();
            string Pwd2 = txtPwd3.Text.Trim().ToString();
            if (Pwd== "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入原密码");
                return;
            }
            if (Pwd1 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入密码");
                return;
            }
            if (Pwd2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入确认密码");
                return;
            }
            if (Pwd1.Length < 6)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码长度太短");
                return;
            }
            if (Pwd1 == "" || Pwd2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码不能为空");
                return;
            }
            if (Pwd1 != Pwd2)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "输入密码不一致");
                return;
            }
            Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd1.Text.Trim(), "MD5");
            Pwd2 = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd2.Text.Trim(), "MD5");
            if (bus.UserInfoPwdUpdate("CandidatesInfo_InsertByPwd", Number, Pwd,Pwd2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                return;
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
                return;
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}