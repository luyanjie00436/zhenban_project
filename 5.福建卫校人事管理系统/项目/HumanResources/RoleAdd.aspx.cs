using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RoleAdd : System.Web.UI.Page
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

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string RoleName = txtRoleName.Text.Trim().ToString();
            if (RoleName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职务名称");
                return;
            }
            if (RoleIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的职务已存在");
                return;
            }
            if (bus.RoleInsert("Role_Insert", RoleName))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtRoleName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool RoleIf()
        {
            DataSet department = bus.Select("Role_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["RoleName"].ToString() == txtRoleName.Text.Trim().ToString())
                {

                    return true;
                }


            }
            return false;
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
            txtRoleName.Text = "";

        }

    }
}