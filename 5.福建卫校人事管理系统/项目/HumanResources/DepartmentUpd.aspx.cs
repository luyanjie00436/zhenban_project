using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class DepartmentUpd : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        int DepartmentId;
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
                DepartmentId = Convert.ToInt32(Request.QueryString["Department"]);
                DataSet ds = bus.SelectByDepartmentId("Department_SelectByDepartmentId", DepartmentId);
                txtDepartmentName.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                txtPreparedNumber.Text = ds.Tables[0].Rows[0]["PreparedNumber"].ToString();
                txtPreparedPost.Text = ds.Tables[0].Rows[0]["PreparedPost"].ToString();
                txtPreparedProfession.Text = ds.Tables[0].Rows[0]["PreparedProfession"].ToString();
                txtPreparedWorkers.Text = ds.Tables[0].Rows[0]["PreparedWorkers"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string DepartmentName = txtDepartmentName.Text.Trim().ToString();
            string PreparedNumber = txtPreparedNumber.Text.Trim().ToString();
            string PreparedPost = txtPreparedPost.Text.Trim().ToString();
            string PreparedProfession = txtPreparedProfession.Text.Trim().ToString();
            string PreparedWorkers = txtPreparedWorkers.Text.Trim().ToString();
            DepartmentId = Convert.ToInt32(Request.QueryString["Department"]);
            if (DepartmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写部门名称");
                return;
            }
            if (PreparedNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写编制人数");
                return;
            }
            if (PreparedPost == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写岗位管理编制数量");
                return;
            }
            if (PreparedProfession == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写专业技术岗位编制数量");
                return;
            }
            if (PreparedWorkers == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写工勤技能岗位编制数量");
                return;
            }

            if (bus.DepartmentUpdate("Department_Update", DepartmentId, DepartmentName, PreparedNumber, PreparedPost, PreparedProfession, PreparedWorkers))
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