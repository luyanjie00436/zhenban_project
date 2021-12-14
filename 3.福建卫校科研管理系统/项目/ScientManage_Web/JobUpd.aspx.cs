using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{

    public partial class JobUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet ds = bus.SelectByJobId("Job_SelectByJobId", JobId);
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
              
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobName = txtJobName.Text.Trim().ToString();
         
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int JobValue = 0;
            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名");
                return;
            }
            
           
            if (bus.JobUpdate("Job_Update", JobId, JobName,UserCardId))
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