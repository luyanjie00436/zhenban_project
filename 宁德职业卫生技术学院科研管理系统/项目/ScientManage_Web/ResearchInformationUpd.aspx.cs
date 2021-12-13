
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ResearchInformationUpd : System.Web.UI.Page
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
                int WorkCategoryId;
                if (Request.QueryString["CategoryId"]!=null)
                {
                    try
                    {
                        Convert.ToInt32(Request.QueryString["CategoryId"]);
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    WorkCategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
                    DataTable dt = bus.SelectByWorkCategoryId("WorkCategory_SelectByWorkCategoryId", WorkCategoryId).Tables[0];
                    txtWorkCategoryName.Text = dt.Rows[0]["WorkCategoryName"].ToString();
                    txtWorkValue.Text = dt.Rows[0]["WorkValue"].ToString();
                }
               
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          int  WorkCategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
          string WorkCategoryName = txtWorkCategoryName.Text;
          string WorkValue = txtWorkValue.Text;
          if (WorkCategoryName=="")
          {
              AlertMsgAndNoFlush(UpdatePanel1, "请输入名称");
              return;
          }
         
          if (bus.WorkCategoryUpdate("WorkCategory_Update",WorkCategoryId,WorkCategoryName, WorkValue))
          {
              AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
              Response.Redirect("ResearchManage.aspx");
              return;
          }
          else
          {
              AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
              return;
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
    }
}