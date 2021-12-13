using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{

    public partial class PostUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet ds = bus.SelectByPostId("Post_SelectByPostId", PostId);
                txtPostName.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
                txtPlanPeople.Text = ds.Tables[0].Rows[0]["PlanPeople"].ToString();
                txtPostValue.Text = ds.Tables[0].Rows[0]["PostValue"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string PostName = txtPostName.Text.Trim().ToString();
            string PlanPeople = txtPlanPeople.Text.Trim().ToString();
            string txPostValue = txtPostValue.Text.Trim().ToString();
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
            if (txPostValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职级分值");
                return;
            }
            try
            {
                PostValue = Convert.ToInt32(txPostValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职级分值应为整数");
                return;
            }
            if (PostValue < 1)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "职级分值应为正整数");
                return;
            }
            if (bus.PostUpdate("Post_Update", PostId, PostName, PlanPeople, PostValue,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
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