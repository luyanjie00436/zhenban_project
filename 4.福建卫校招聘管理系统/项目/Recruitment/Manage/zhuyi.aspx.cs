using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Manage
{
    public partial class zhuyi : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        int JobMangeId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
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

                DataSet ds = bus.JobMange_SelectByJobMangeId("JobMange_SelectByJobMangeId", JobMangeId);
                txtZhuyi.Text = ds.Tables[0].Rows[0]["zhuyi"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string Zhuyi = txtZhuyi.Text.Trim().ToString();
            if (Zhuyi == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写注意事项");
                return;
            }
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
            if (bus.JobMangeUpdatezhuyi("JobMange_Updatezhuyi", JobMangeId, Zhuyi))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("ExamGradeManage.aspx");
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