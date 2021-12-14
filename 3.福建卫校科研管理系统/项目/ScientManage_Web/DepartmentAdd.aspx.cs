using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class DepartmentAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string DepartmentName = txtDepartmentName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
          
            if (DepartmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写行政隶属名称");
                return;
            }
            if (DepartmentIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的行政隶属已存在");
                return;
            }
            if (bus.DepartmentInsert("Department_Insert", DepartmentName, UserCardId))
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