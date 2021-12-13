using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class SubjectAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/SubjectManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string SubjectName = txtSubjectName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (SubjectName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写学科分类名称");
                return;
            }
            if (CapitalItemIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的学科分类已存在");
                return;
            }
            if (bus.SubjectInsert("Subject_Insert", SubjectName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtSubjectName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }
        }
        public bool CapitalItemIf()
        {
            DataSet department = bus.Select("Subject_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {
                if (item["SubjectName"].ToString() == txtSubjectName.Text.Trim().ToString())
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
            txtSubjectName.Text = "";
        }
    }
}