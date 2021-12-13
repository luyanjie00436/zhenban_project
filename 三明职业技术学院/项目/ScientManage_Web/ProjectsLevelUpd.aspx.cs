using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class ProjectsLevelUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int ProjectsLevelId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectsLevelId = Convert.ToInt32(Request.QueryString["ProjectsLevel"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectsLevelManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet ds = bus.SelectByProjectsLevelId("ProjectsLevel_SelectByProjectsLevelId", ProjectsLevelId);
                txtProjectsLevelExplain.Text = ds.Tables[0].Rows[0]["ProjectsLevelExplain"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProjectsLevelExplain = txtProjectsLevelExplain.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (ProjectsLevelExplain == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写项目级别");
                return;
            }
            ProjectsLevelId = Convert.ToInt32(Request.QueryString["ProjectsLevel"]);
            if (bus.ProjectsLevelUpdate("ProjectsLevel_Update", ProjectsLevelId, ProjectsLevelExplain, UserCardId))
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