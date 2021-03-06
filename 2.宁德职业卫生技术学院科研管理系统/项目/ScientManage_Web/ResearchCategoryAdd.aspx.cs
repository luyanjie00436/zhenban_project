using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ResearchCategoryAdd : System.Web.UI.Page
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

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string WorkCategoryName = txtWorkCategoryName.Text.Trim().ToString();
            string txWorkValue = txtWorkValue.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int Rank = Convert.ToInt32(Request.QueryString["Rank"]);
            int FatherId = Convert.ToInt32(Request.QueryString["Father"]);
            if (WorkCategoryName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写科研类别");

                return;
            }
   




            if (bus.WorkCategoryInsert("WorkCategory_Insert", WorkCategoryName, txWorkValue, FatherId, Rank))
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
            Response.Redirect("ResearchManage.aspx");

        }
        public void clearIfo()
        {
            txtWorkCategoryName.Text = "";
            txtWorkValue.Text = "";
        }
      
    }
}