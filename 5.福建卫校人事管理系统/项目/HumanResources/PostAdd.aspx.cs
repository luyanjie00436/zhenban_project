using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class PostAdd : System.Web.UI.Page
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/PostAdd.aspx") == 0)
                //{
                //    Response.Redirect("Login.aspx");
                //}
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string PostName = txtPostName.Text.Trim().ToString();
            string PlanPeople = txtPlanPeople.Text.Trim().ToString();

            int PostValue = 0;
            if (PostName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职级名称");

                return;
            }
            if (PlanPeople == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职级大类");
                return;
            }

            if (PostIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的职级已存在");
                return;
            }


            if (bus.PostInsert("Post_Insert", PostName, PlanPeople))
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
            txtPostName.Text = "";
            txtPlanPeople.Text = "";

        }
        public bool PostIf()
        {
            DataSet department = bus.Select("Post_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["PostName"].ToString() == txtPostName.Text.Trim().ToString())
                {

                    return true;
                }


            }
            return false;
        }
    }
}