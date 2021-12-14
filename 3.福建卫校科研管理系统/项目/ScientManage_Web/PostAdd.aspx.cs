using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{

    public partial class PostAdd : System.Web.UI.Page
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
            string PostName = txtPostName.Text.Trim().ToString();
            string PlanPeople = txtPlanPeople.Text.Trim().ToString();
        
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
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


            if (bus.PostInsert("Post_Insert", PostName, PlanPeople,UserCardId))
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