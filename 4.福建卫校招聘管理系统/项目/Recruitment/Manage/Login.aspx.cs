using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class Login : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtLoginUserPwd.Value.Trim().ToString(), "MD5");
            int message = bus.Login(txtLoginUserCardId.Value.Trim(), pwd);
            if (message.Equals(0)) //登陆成功
            {
                
                HttpCookie cok3 = new HttpCookie("RankId");
                cok3.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cok3);
                Response.Cookies["UserCardId"].Value = HttpUtility.UrlEncode(txtLoginUserCardId.Value);
                Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
                Response.Redirect("Default.aspx");
            }
            else //登陆失败
            {
                if (message.Equals(1))
                {

                    Response.Write("<script>alert('密码错误')</script>");
                }
                else if (message.Equals(2))
                {
                    Response.Write("<script>alert('用户不存在')</script>");
                }
                else if (message.Equals(3))
                {

                    Response.Write("<script>alert('用户已被锁定，禁止登陆')</script>");
                }
                else if (message.Equals(5))
                {
                    Response.Write("<script>alert('您的账号禁止登陆此系统，请联系科研处进行登陆！')</script>");

                }
                else
                {
                    Response.Write("<script>alert('系统错误')</script>");
                }
                txtLoginUserPwd.Value = "";
            }
        }
        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    txtLoginUserCardId.Value = "";
        //    txtLoginUserPwd.Value = "";
        //}
    }
}