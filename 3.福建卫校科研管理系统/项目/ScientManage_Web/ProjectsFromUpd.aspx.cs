using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ProjectsFromUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int ProjectsFromId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectsFromId = Convert.ToInt32(Request.QueryString["ProjectsFrom"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectsFromManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                DataSet ds = bus.SelectByProjectsFromId("ProjectsFrom_SelectByProjectsFromId", ProjectsFromId);
                txtProjectsFromExplain.Text = ds.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProjectsFromExplain = txtProjectsFromExplain.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (ProjectsFromExplain == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写项目来源");
                return;
            }
            ProjectsFromId = Convert.ToInt32(Request.QueryString["ProjectsFrom"]);
            if (bus.ProjectsFromUpdate("ProjectsFrom_Update", ProjectsFromId, ProjectsFromExplain, UserCardId))
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