using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class EducationUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int EducationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EducationId = Convert.ToInt32(Request.QueryString["Education"]);
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

                DataSet ds = bus.SelectByEducationId("Education_SelectByEducationId", EducationId);
                txtEducationName.Text = ds.Tables[0].Rows[0]["EducationName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string EducationName = txtEducationName.Text.Trim().ToString();
            if (EducationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写学历名称");
                return;
            }
            EducationId = Convert.ToInt32(Request.QueryString["Education"]);
            if (bus.EducationUpdate("Education_Update", EducationId, EducationName))
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