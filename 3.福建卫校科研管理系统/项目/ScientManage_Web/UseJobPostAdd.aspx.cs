using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UseJobPostAdd : System.Web.UI.Page
    {

        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data .pwd();
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

                    Response.Redirect("Login.aspx");
                }

                clearIfo();

                LUserCardId.Text = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                DataSet Department = bus.Select("Department_Select");
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    txtDepartment.Items.Add(li);
                }

                DataSet Job = bus.Select("Job_Select");
                foreach (DataRow dr in Job.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["JobName"].ToString(), dr["JobId"].ToString());
                    txtJob.Items.Add(li);
                }
                DataSet Post = bus.Select("Post_Select");
                foreach (DataRow dr in Post.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PostName"].ToString(), dr["PostId"].ToString());
                    txtPost.Items.Add(li);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text;
            string DepartmentId = txtDepartment.Text.Trim().ToString();
            string JobId = txtJob.Text.Trim().ToString();
            string PostId = txtPost.Text.Trim().ToString();
            string JobDate = txtJobDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            string JobSeries = txtJobSeries.Text.Trim().ToString();
            string WorkLevel = txtWorkLevel.Text.Trim().ToString();
            string IsCurrent = txtIsCurrent.Text.Trim().ToString();
            if (UserCardId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写工号");
                return;
            }
            if (DepartmentId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写部门");
                return;
            }
            if (JobId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称");
                return;
            }
            if (PostId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职级");
                return;
            }

            if (JobDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择获得时间");
                return;
            }
            if (JobSeries == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称系列");
                return;
            }
            if (WorkLevel == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写级别");
                return;
            }
            if (IsCurrent == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否当前任职");
                return;
            }
            if (bus.UseJobPostInsert("UseJobPost_Insert", UserCardId, DepartmentId, JobId, PostId, JobDate, EndDate, JobSeries, WorkLevel, IsCurrent))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
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

          
            txtJobDate.Text = "";
            txtJobSeries.Text = "";
            txtWorkLevel.Text = "";
         

        }
    }
}