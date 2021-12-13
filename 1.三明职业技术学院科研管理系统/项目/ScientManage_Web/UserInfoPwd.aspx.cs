using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class UserInfoPwd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoPwd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim().ToString();
            string UserIdCard = txUserIdCard.Text.Trim().ToString();
            string NewPwd = txtNewPwd.Text.Trim().ToString();
            string NewPwd2 = txtNewPwd2.Text.Trim().ToString();
            if (UserCardId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入工号");
                return;
            }
            if (UserIdCard == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入身份证号码");
                return;
            }
            if (!CheckIDCard(UserIdCard))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入正确的身份证号码");
                return;
            }
            if (NewPwd.Length < 6)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码长度太短");
                return;
            }
            if (NewPwd == "" || NewPwd2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码不能为空");
                return;
            }
            if (NewPwd != NewPwd2)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "输入密码不一致");
                return;
            }
            string UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPwd.Text.Trim(), "MD5");
            if (bus.UserInfoPwdUpdate("UserInfo_UpdatePwd", UserCardId, UserIdCard, UserPwd))
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
        public void clearIfo()
        {
            txtUserCardId.Text = "";
            txUserIdCard.Text = "";
            txtNewPwd.Text = "";
            txtNewPwd2.Text = "";
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