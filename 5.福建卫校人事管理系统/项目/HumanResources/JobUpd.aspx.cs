using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class JobUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
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

                    Response.Redirect("Login.aspx");
                }

                DataSet ds = bus.SelectByJobId("Job_SelectByJobId", JobId);
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobName = txtJobName.Text.Trim().ToString();


            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名");

                return;
            }

            if (bus.JobUpdate("Job_Update", JobId, JobName))
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