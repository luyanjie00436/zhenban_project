using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UseOfficeUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int UseOfficeId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            UseOfficeId = Convert.ToInt32(Request.QueryString["UseOffice"]);
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
                DataSet Department = bus.Select("Department_Select");
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                    txtDepartment.Items.Add(li);
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleName"].ToString());
                    txtRole.Items.Add(li);
                }
                DataSet ds = bus.SelectByUseOfficeId("UseOffice_SelectByUseOfficeId", UseOfficeId);

                LUserCardId.Text = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                txtDepartment.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                txtRole.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                txtLevel.Text = ds.Tables[0].Rows[0]["LevelName"].ToString();
                txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate"].ToString();
                txtCurrent.Text = ds.Tables[0].Rows[0]["IsCurrent"].ToString();
                txtAgent.Text = ds.Tables[0].Rows[0]["IsAgent"].ToString();


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text.Trim().ToString();
            string DepartmentName = txtDepartment.Text.Trim().ToString();
            string RoleName = txtRole.Text.Trim().ToString();
            string LevelName = txtLevel.Text.Trim().ToString();
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            string IsCurrent = txtCurrent.Text.Trim().ToString();
            string IsAgent = txtAgent.Text.Trim().ToString();
            if (UserCardId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写工号");
                return;
            }
            if (DepartmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写部门");
                return;
            }
            if (RoleName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职务");
                return;
            }
            if (LevelName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职级");
                return;
            }
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择开始时间");
                return;
            }

            if (IsCurrent == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否当前任职");
                return;
            }
            if (IsAgent == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否代理");
                return;
            }
            UseOfficeId = Convert.ToInt32(Request.QueryString["UseOffice"]);
            if (bus.UseOfficeUpdate("UseOffice_Update", UseOfficeId, UserCardId, DepartmentName, RoleName, LevelName, StartDate, EndDate, IsCurrent, IsAgent))
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