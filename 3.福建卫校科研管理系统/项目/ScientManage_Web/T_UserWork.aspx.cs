using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class T_UserWork : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCardId = Request.QueryString["UserCardId"];
            if (!IsPostBack)
            {
                try
                {
                    HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                DataSet ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                txtUserCardId.Text = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                txtWorkValue.Text = ds.Tables[0].Rows[0]["T_UserValue"].ToString();


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim().ToString();
            string WorkValue = txtWorkValue.Text;
            if (bus.UserWorkValueUpdate("UserTValue_Update", UserCardId, WorkValue))
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