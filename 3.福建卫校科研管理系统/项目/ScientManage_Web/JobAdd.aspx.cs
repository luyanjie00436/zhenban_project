using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{

    public partial class JobAdd : System.Web.UI.Page
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
            string JobName = txtJobName.Text.Trim().ToString();
          
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int JobValue = 0;
            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名称");

                return;
            }
         
            if (bus.JobInsert("Job_Insert", JobName,UserCardId))
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
            txtJobName.Text = "";
        }
        public bool JobIf()
        {
            DataSet department = bus.Select("Job_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {
                if (item["JobName"].ToString() == txtJobName.Text.Trim().ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}