using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UseOfficeAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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
                LUserCardId.Text = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                clearIfo();
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
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text;
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
            if (bus.UseOfficeInsert("UseOffice_Insert", UserCardId, DepartmentName, RoleName, LevelName, StartDate, EndDate, IsCurrent, IsAgent))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        //public bool StatusIf()
        //{
        //    DataSet department = bus.Select("Status_Select");
        //    foreach (DataRow item in department.Tables[0].Rows)
        //    {

        //        if (item["StatusName"].ToString() == txtStatusName.Text.Trim().ToString())
        //        {

        //            return true;
        //        }


        //    }
        //    return false;
        //}
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

            //txtDepartment.Text= "";
            //txtRole.Text= "";
            txtLevel.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            //txtCurrent.Text= "";
            //txtAgent.Text = "";

        }
    }
}