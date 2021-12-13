using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class ProjectsDateUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int ProjectsDateId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectsDateId = Convert.ToInt32(Request.QueryString["ProjectsDate"]);
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

                DataSet ds = bus.SelectByProjectsDateId("ProjectsDate_SelectByProjectsDateId", ProjectsDateId);
                txtStartDate.Value = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtEndDate.Value = ds.Tables[0].Rows[0]["EndDate"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            ProjectsDateId = Convert.ToInt32(Request.QueryString["ProjectsDate"]);
            string StartDate = txtStartDate.Value;
            string EndDate = txtEndDate.Value;
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写起始时间");
                return;
            }
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写终止时间");
                return;
            }
            if (bus.ProjectsDateUpdate("ProjectsDate_Update", ProjectsDateId, StartDate, EndDate, UserCardId))
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