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
    public partial class A_UserAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int Id;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Id = Convert.ToInt32(Request.QueryString["Abc_User"]);

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
                if (Request.QueryString["Abc_User"] != null)
                {

                    try
                    {
                        Id = Convert.ToInt32(Request.QueryString["Abc_User"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    DataSet ds = bus.Abc_UserById("Abc_User_SelectById", Id);
                    txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtUserPwd.Text = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                    jiayan();
                    mimajiaoyan();
                }
                else
                {
                    Button2.Visible = false;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string UserPwd = txtUserPwd.Text.Trim().ToString();

        
            UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPwd.Text.Trim(), "MD5");
            if (bus.Abc_UserInsert("Abc_User_Insert", UserName, UserPwd))
            {
                AlertMsgAndNoFlush("添加成功！");
               
            }
            else
            {
                AlertMsgAndNoFlush("添加失败,检查账号是否应经存在！");
               
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserName = txtUserName.Text;
            string UserPwd = txtUserPwd.Text.Trim().ToString();
            string CheckCode = TextBox1.Text;
            //Id = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Abc_User"], "asdfasdf"));
            Id = Convert.ToInt32(Request.QueryString["Abc_User"]);
            UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPwd.Text.Trim(), "MD5");
            if (bus.Abc_UserUpdate("Abc_User_Update", Id,UserName, UserPwd))
            {
                AlertMsgAndNoFlush("修改成功！");
                
            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        public void jiayan() {
            string UserName = txtUserName.Text;
            string CheckCode = FormsAuthentication.HashPasswordForStoringInConfigFile(pwds.EncryptDES(UserName, "asdfasdf"), "MD5");
            TextBox1.Text = CheckCode;

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            jiayan();
        }
        public void mimajiaoyan()
        {
            string UserPwd = txtUserPwd.Text;
            string CheckCode = FormsAuthentication.HashPasswordForStoringInConfigFile(UserPwd, "MD5");
            TextBox2.Text = CheckCode;

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            mimajiaoyan();
        }
    }
}