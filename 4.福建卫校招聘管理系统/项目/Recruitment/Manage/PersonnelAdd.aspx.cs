using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class PersonnelAdd : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
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

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string UserCardId1 = txtUserCardId.Value;
            string UserName = txtUserName.Value;
            string Pwd1 = txtPwd1.Text.Trim().ToString();
            string Pwd2 = txtPwd2.Text.Trim().ToString();

            if (UserCardId == "")
            {
                AlertMsgAndNoFlush("请输入账号！");
                return;
            }
            if (UserName == "")
            {
                AlertMsgAndNoFlush("请输入姓名！");
                return;
            }
         
            if (Pwd1 == "")
            {
                AlertMsgAndNoFlush("请输入密码！");
                return;
            }
            if (Pwd2 == "")
            {
                AlertMsgAndNoFlush("请输入确认密码！");
                return;
            }
            if (Pwd1.Length < 6)
            {
                AlertMsgAndNoFlush("密码长度太短！");
                return;
            }
            if (Pwd1 == "" || Pwd2 == "")
            {
                AlertMsgAndNoFlush("密码不能为空！");
                return;
            }
            if (Pwd1 != Pwd2)
            {
                AlertMsgAndNoFlush("输入密码不一致！");
                return;                        
            }
            Pwd1 = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd1.Text.Trim(), "MD5");
            if (bus.UserInfoInsert("UserInfo_Insert", UserCardId1,UserName,Pwd1))
            {
                AlertMsgAndNoFlush( "添加成功！");
                return;
            }
            else
            {
                AlertMsgAndNoFlush( "添加失败,检查账号是否应经存在！");
                return;
            }
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }
    }
}