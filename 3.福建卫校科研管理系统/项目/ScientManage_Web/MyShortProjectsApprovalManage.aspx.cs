using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class MyShortProjectsApprovalManage : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("ShortProjects_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        //项目添加
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string proid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmm");
            string url = "/ShortProjectsDeclareAdds.aspx?Proid=" + pwds.EncryptDES(proid, "asdfasdf");
            Response.Redirect(url);
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "window.open('" + message + "');", true);
        }
        public static void AlertMsgAndNoFlush1(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
      
        //刷新
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        //查看项目详情
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
             string url = "/ShortProjectsDeclareAdds.aspx?Proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
               Response.Redirect(url);
         //   Response.Write("<script>window.open('/ProjectsAdds.aspx?proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "')</script>");

        }
        //删除项目
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            if (bus.ShortProjectsDelete("ShortProjects_Delete", e.CommandArgument.ToString()))
            {
                AlertMsgAndNoFlush1(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush1(UpdatePanel1, "调配流程已经启动，禁止删除");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("MyProjectsManage.aspx");
        }
    }
}