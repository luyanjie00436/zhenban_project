using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class EducationAdd : System.Web.UI.Page
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
            string EducationName = txtEducationName.Text.Trim().ToString();
            if (EducationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写学历名称");
                return;
            }
            if (EducationIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的学历已存在");
                return;
            }
            if (bus.EducationInsert("Education_Insert", EducationName))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtEducationName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool EducationIf()
        {
            DataSet department = bus.Select("Education_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["EducationName"].ToString() == txtEducationName.Text.Trim().ToString())
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
            txtEducationName.Text = "";

        }

    }
}