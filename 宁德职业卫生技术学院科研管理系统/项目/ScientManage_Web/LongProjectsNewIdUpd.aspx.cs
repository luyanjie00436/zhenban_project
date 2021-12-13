using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class LongProjectsNewIdUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string LongProjectsId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            LongProjectsId = Request.QueryString["LongProjectsId"];
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsNewIdManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                LProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                txtProjectsNewId.Text = ds.Tables[0].Rows[0]["NewLongProjectsId"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string NewLongProjectsId = txtProjectsNewId.Text;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (NewLongProjectsId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写新项目编号");
                return;
            }
            LongProjectsId = Request.QueryString["LongProjectsId"];
            if (bus.NewLongProjectsIdUpdate("LongProjectsNewId_Update", LongProjectsId, NewLongProjectsId, UserCardId))
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