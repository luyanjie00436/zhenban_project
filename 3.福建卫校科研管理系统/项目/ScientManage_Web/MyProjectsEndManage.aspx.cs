using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class MyProjectsEndManage : System.Web.UI.Page
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
            GridView1.DataSource = bus.SelectByUserCardId("LongProjectscanEnd_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
            GridView2.DataSource = bus.SelectByUserCardId("LongProjectsEnd_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView2.DataBind();

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "window.open('" + message + "');", true);
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
             string url = "/LongProjectsEnds.aspx?Proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            
            Response.Redirect(url);
            //Response.Write("<script>window.open('/ProjectsAdds.aspx?proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "')</script>");

        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("MyProjectsApprovalManage.aspx");
        }
       
    }
}