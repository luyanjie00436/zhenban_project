using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ProjectsSubjectUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int ProjectsSubjectId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectsSubjectId = Convert.ToInt32(Request.QueryString["ProjectsSubject"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectsSubjectManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet ds = bus.SelectByProjectsSubjectId("ProjectsSubject_SelectByProjectsSubjectId", ProjectsSubjectId);
                txtProjectsSubjectExplain.Text = ds.Tables[0].Rows[0]["ProjectsSubjectExplain"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProjectsSubjectExplain = txtProjectsSubjectExplain.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (ProjectsSubjectExplain == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写项目类别");
                return;
            }
            ProjectsSubjectId = Convert.ToInt32(Request.QueryString["ProjectsSubject"]);
            if (bus.ProjectsSubjectUpdate("ProjectsSubject_Update", ProjectsSubjectId, ProjectsSubjectExplain, UserCardId))
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