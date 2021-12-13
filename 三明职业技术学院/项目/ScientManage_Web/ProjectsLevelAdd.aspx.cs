using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class ProjectsLevelAdd : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectsLevelManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                clearIfo();
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
            if (ProjectsLevelIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的项目级别已存在");
                return;
            }
            if (bus.ProjectsLevelInsert("ProjectsLevel_Insert", ProjectsLevelExplain, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtProjectsLevelExplain.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool ProjectsLevelIf()
        {
            DataSet department = bus.Select("ProjectsLevel_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["ProjectsLevelExplain"].ToString() == txtProjectsLevelExplain.Text.Trim().ToString())
                {

                    return true;
                }


            }
            return false;
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();

        }
        public void clearIfo()
        {
            txtProjectsLevelExplain.Text = "";

        }
    }
}