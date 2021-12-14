using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class Login : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet Rank = bus.Select("Rank_Select");
            }
        }
    

      

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            if (txtLoginUserCardId.Value == "" || txtLoginUserPwd.Value.Trim() == "")
            {
                RegisterStartupScript("true", "<script>alert('用户名或密码不能为空')</script>");
                return;
            }
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtLoginUserPwd.Value.Trim().ToString(), "MD5");
            int message = bus.Login(txtLoginUserCardId.Value.Trim(), pwd, this);
            if (message.Equals(0)) //登陆成功
            {
                //DataSet ds = bus.userInfoS(txtLoginUserCardId.Text);
                //Response.Cookies["selectUserCardId"].Value = txtLoginUserCardId.Text.Trim();
                //Response.Cookies["UserRoleId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
                //Response.Cookies["UserCardId"].Value = txtLoginUserCardId.Text.Trim();
                //Response.Cookies["UserRoleId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
                //Response.Cookies["UserName"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserName"].ToString());
                //Response.Cookies["UserDepartmentId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserDepartmentId"].ToString());
                //Response.Cookies["selectUserCardId"].Expires = DateTime.Now.AddDays(1);
                //Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                //Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["UserCardId"].Value = HttpUtility.UrlEncode(txtLoginUserCardId.Value);
                Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
                HttpCookie cok3 = new HttpCookie("RankId");
                cok3.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cok3);
                Response.Redirect("Default.aspx");
            }
            else //登陆失败
            {
                if (message.Equals(1))
                {
                    RegisterStartupScript("true", "<script>alert('密码错误')</script>");
                }
                else if (message.Equals(2))
                {

                    RegisterStartupScript("true", "<script>alert('用户不存在')</script>");
                }
                else if (message.Equals(3))
                {

                    RegisterStartupScript("true", "<script>alert('用户已被锁定，禁止登陆')</script>");
                }
                else if (message.Equals(5))
                {

                    RegisterStartupScript("true", "<script>alert('您的账号禁止登陆此系统，请联系人事处进行登陆')</script>");
                }
                else
                {
                    RegisterStartupScript("true", "<script>alert('系统错误')</script>");
                }
                txtLoginUserPwd.Value = "";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            txtLoginUserCardId.Value = "";
            txtLoginUserPwd.Value = "";
        }

    }
}