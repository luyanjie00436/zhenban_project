using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class Registered : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
                Response.Redirect("index.aspx");
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            string Number = txtNumber.Text;
            string Name = txtName.Text;
            string CardId = txtCardID.Text;
            string Birthday = txtBirthday.Value.Trim();
            string Gender = DGender.Text;
            string Email = txtEmail.Text;
            string ContactPhone = txtContactPhone.Text;
            string Pwd = txtPwd1.Text;
            string Pwd2 = txtPwd2.Text;

            if (Number == "")
            {
                AlertMsgAndNoFlush("请输入用户名");
                return;
            }
            if (Name == "")
            {
                AlertMsgAndNoFlush("请输入姓名");
                return;
            }
            if (CardId == "")
            {
                AlertMsgAndNoFlush("请输入身份证号");
                return;
            }
            if (Birthday == "")
            {
                AlertMsgAndNoFlush("请输入生日");
                return;
            }
            if (Gender == "")
            {
                AlertMsgAndNoFlush("请选择性别");
                return;
            }
            if (Email == "")
            {
                AlertMsgAndNoFlush("请输入电子邮箱");
                return;
            }
            if (ContactPhone == "")
            {
                AlertMsgAndNoFlush("请输入手机号码");
                return;
            }
            if ( Pwd== "")
            {
                AlertMsgAndNoFlush("请输入登录密码");
                return;
            }
            if (Pwd.Length < 6)
            {
                AlertMsgAndNoFlush("密码长度太短");
                return;
            }
            if (Pwd == "" || Pwd2 == "")
            {
                AlertMsgAndNoFlush( "密码不能为空");
                return;
            }
            if (Pwd2 !=Pwd )
            {
                AlertMsgAndNoFlush("两次密码不一致，请重新输入！");
                return;
            }
            string UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd1.Text.Trim(), "MD5");
            int message = bus.RegisterdeInsert("CandidatesInfo_registered", Number, Name, CardId, Birthday, Gender, Email, ContactPhone, UserPwd);
            if (message.Equals(0))
            {
                Response.Write("<script>alert('注册成功！');location.href='index.aspx';</script>");
                //AlertMsgAndNoFlush( "注册成功！");
                //Response.Redirect("index.aspx");
            }
            else 
            {
                if(message.Equals(1))
                {
                    AlertMsgAndNoFlush("注册失败,用户名已存在！");
                }
               else if(message.Equals(2))
                {
                    AlertMsgAndNoFlush("注册失败,身份证号码已被注册！");
                }
                else if(message.Equals(3))
                {
                    AlertMsgAndNoFlush("注册失败,手机号码已被注册！");
                }
                else if (message.Equals(4))
                {
                    AlertMsgAndNoFlush("注册失败,电子邮箱已被注册！");
                }
                else if (message.Equals(5))
                {

                    Response.Write("<script>alert('用户已被锁定，禁止登陆')</script>");
                }
                else if (message.Equals(6))
                {
                    Response.Write("<script>alert('您的账号禁止登陆此系统，请联系管理员进行登陆！')</script>");

                }
                else
                {
                    Response.Write("<script>alert('系统错误')</script>");
                }
            }
        
        }
        public void AlertMsgAndNoFlush(string message)
        {
            //ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        /// <summary>    
        /// 验证身份证号码    
        /// </summary>    
        /// <param name="Id">身份证号码</param>    
        /// <returns>验证成功为True，否则为False</returns>    
        public bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>     
        /// 验证18位身份证号    
        /// </summary>    
        /// <param name="Id">身份证号</param>    
        /// <returns>验证成功为True，否则为False</returns>   
        public bool CheckIDCard18(string Id)
        {

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证 
            }

            return true;//符合GB11643-1999标准 
        }
        /// <summary>    
        /// 验证15位身份证号    
        /// </summary>    
        /// <param name="Id">身份证号</param>    
        /// <returns>验证成功为True，否则为False</returns>  
        public bool CheckIDCard15(string Id)
        {

            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证 
            }
            return true;//符合15位身份证标准 
        }
    }
}