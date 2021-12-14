using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{

    public partial class PostUpd : System.Web.UI.Page
    {
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        int PostId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            PostId = Convert.ToInt32(Request.QueryString["Post"]);
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

                DataSet ds = bus.SelectByPostId("Post_SelectByPostId", PostId);
                txtPostName.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
                txtPlanPeople.Text = ds.Tables[0].Rows[0]["PlanPeople"].ToString();
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
        
            if (bus.PostUpdate("Post_Update", PostId, PostName, PlanPeople,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
               // Response.Redirect("PostManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");

            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}