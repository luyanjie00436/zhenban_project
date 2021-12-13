using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AdminSeriesUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AdminSeriesManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet ds = bus.SelectByAdminSeriesId("AdminSeries_SelectByAdminSeriesId", AdminSeriesId);
                txtAdminSeriesName.Text = ds.Tables[0].Rows[0]["AdminSeriesName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string AdminSeriesName = txtAdminSeriesName.Text.Trim().ToString();
            if (AdminSeriesName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写行政系列名称");
                return;
            }
            AdminSeriesId = Convert.ToInt32(Request.QueryString["AdminSeries"]);
            if (bus.AdminSeriesUpdate("AdminSeries_Update", AdminSeriesId, AdminSeriesName,UserCardId))
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