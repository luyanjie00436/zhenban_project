using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class DepartmentAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DepartmentAdd.aspx") == 0)
                //{
                //    Response.Redirect("Login.aspx");
                //}

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string DepartmentName = txtDepartmentName.Text.Trim().ToString();
            string PreparedNumber = txtPreparedNumber.Text.Trim().ToString();
            string PreparedPost = txtPreparedPost.Text.Trim().ToString();
            string PreparedProfession = txtPreparedProfession.Text.Trim().ToString();
            string PreparedWorkers = txtPreparedWorkers.Text.Trim().ToString();

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
            if (DepartmentIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的部门已存在");
                return;
            }


            if (bus.DepartmentInsert("Department_Insert", DepartmentName, PreparedNumber, PreparedPost, PreparedProfession, PreparedWorkers))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                clearIfo();
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
            txtDepartmentName.Text = "";
            txtPreparedNumber.Text = "";
        }
        public bool DepartmentIf()
        {
            DataSet department = bus.Select("Department_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["DepartmentName"].ToString() == txtDepartmentName.Text.Trim().ToString())
                {

                    return true;
                }


            }
            return false;
        }
    }
}