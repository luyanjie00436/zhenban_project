using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class AdminSeriesUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int AdminSeriesId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminSeriesId = Convert.ToInt32(Request.QueryString["AdminSeries"]);
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

                DataSet ds = bus.SelectByAdminSeriesId("AdminSeries_SelectByAdminSeriesId", AdminSeriesId);
                txtAdminSeriesName.Text = ds.Tables[0].Rows[0]["AdminSeriesName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string AdminSeriesName = txtAdminSeriesName.Text.Trim().ToString();
            if (AdminSeriesName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写人员类别名称");
                return;
            }
            AdminSeriesId = Convert.ToInt32(Request.QueryString["AdminSeries"]);
            if (bus.AdminSeriesUpdate("AdminSeries_Update", AdminSeriesId, AdminSeriesName))
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