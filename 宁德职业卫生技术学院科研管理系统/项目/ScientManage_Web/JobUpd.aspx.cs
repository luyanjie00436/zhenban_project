using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{

    public partial class JobUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int JobId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            JobId = Convert.ToInt32(Request.QueryString["Job"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/JobManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet ds = bus.SelectByJobId("Job_SelectByJobId", JobId);
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
                txtJobValue.Text = ds.Tables[0].Rows[0]["JobValue"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobName = txtJobName.Text.Trim().ToString();
            string txJobValue = txtJobValue.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int JobValue = 0;
            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名");

                return;
            }
            if (txJobValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称分值");
                return;
            }
            try
            {
                JobValue = Convert.ToInt32(txJobValue);


            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职称分值应为正整数");
                return;
            }
            if (JobValue < 1)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职称分值应为正整数");
                return;
            }


            if (bus.JobUpdate("Job_Update", JobId, JobName, JobValue,UserCardId))
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