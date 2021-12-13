using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class UserPhone : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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
                if (Request.QueryString["UserCardId"] == null)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                DataSet de = bus.SelectByUserCardId("Phone_SelectByUserCardId", UserCardId);
                if (de.Tables[0].Rows.Count > 0)
                {
                    txtPhone.Text = de.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                    txtHomeNumber.Text = de.Tables[0].Rows[0]["HomeNumber"].ToString();
                    txtWorkNumber.Text = de.Tables[0].Rows[0]["WorkNumber"].ToString();
                }
                else
                {
                    txtPhone.Text = "";
                    txtHomeNumber.Text = "";
                    txtWorkNumber.Text = "";
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string IndividuaNumber = txtPhone.Text.Trim().ToString();
            string UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string HomeNumber = txtHomeNumber.Text.Trim().ToString();
            string WorkNumber = txtWorkNumber.Text.Trim().ToString();
            string UserCardId = UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
            if (bus.PhoneUpdate("Phone_Update", UserCardId, IndividuaNumber, HomeNumber, WorkNumber,UserCardId2))
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