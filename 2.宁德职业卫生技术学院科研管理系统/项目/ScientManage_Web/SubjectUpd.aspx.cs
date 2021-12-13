using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class SubjectUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int SubjectId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            SubjectId = Convert.ToInt32(Request.QueryString["Subject"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/SubjectManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectBySubjectId("Subject_SelectBySubjectId", SubjectId);
                txtSubjectName.Text = ds.Tables[0].Rows[0]["SubjectName"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string SubjectName = txtSubjectName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (SubjectName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写学科分类名称");
                return;
            }
            SubjectId = Convert.ToInt32(Request.QueryString["Subject"]);
            if (bus.SubjectUpdate("Subject_Update", SubjectId, SubjectName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("SubjectManage.aspx");
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