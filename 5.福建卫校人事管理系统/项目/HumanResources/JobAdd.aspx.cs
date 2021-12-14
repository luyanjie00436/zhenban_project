using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class JobAdd : System.Web.UI.Page
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/JobAdd.aspx") == 0)
                //{
                //    Response.Redirect("Login.aspx");
                //}
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobName = txtJobName.Text.Trim().ToString();
            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名称");

                return;
            }

            if (JobIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的职称已存在");
                return;
            }


            if (bus.JobInsert("Job_Insert", JobName))
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