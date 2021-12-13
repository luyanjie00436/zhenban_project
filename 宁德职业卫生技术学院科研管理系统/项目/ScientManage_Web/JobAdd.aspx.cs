using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{

    public partial class JobAdd : System.Web.UI.Page
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/JobManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobName = txtJobName.Text.Trim().ToString();
            string txJobValue = txtJobValue.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int JobValue = 0;
            if (JobName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称名称");

                return;
            }
            if (txJobValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称分值");
                return;
            }
            try
            {
                JobValue = Convert.ToInt32(txJobValue);


            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职称分值应为正整数");
                return;
            }
            if (JobValue < 1)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职称分值应为正整数");
                return;
            }
            if (JobIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的职称已存在");
                return;
            }


            if (bus.JobInsert("Job_Insert", JobName, JobValue,UserCardId))
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
            txtJobValue.Text = "";
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