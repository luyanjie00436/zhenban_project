using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class LongProjectsEndManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }

        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("LongProjects_SelectCanEnd", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
            GridView2.DataSource = bus.SelectByUserCardId("LongProjects_SelectEndUserCardId", UserCardId).Tables[0].DefaultView;
            GridView2.DataBind();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                try
                {
                    Label num = (Label)GridView2.Rows[i].FindControl("LEndStatus");  //获取gridview中的编号控件
                    if (num.Text == "审批通过")
                    {
                        LinkButton lb = (LinkButton)GridView2.Rows[i].FindControl("LinkButton7");
                        lb.Visible = false;
                        continue;
                    }
                }
                catch
                {

                }
            }

        }
        //结题
        protected void LinkButton5_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsEndAdd.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }
        //查看详情
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsEndDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }
        //修改
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsEndAdd.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

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
            //  Response.Redirect("MyProjectsEndManage.aspx");
        }
    }
}