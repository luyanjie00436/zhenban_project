using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LongProjectsDeclareManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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
            GridView1.DataSource = bus.SelectByUserCardId("LongProjects_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label num = (Label)GridView1.Rows[i].FindControl("LDeclareStatus");  //获取gridview中的编号控件
                    if (num.Text == "审批通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton7");
                        LinkButton lb1 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton9");
                        lb.Visible = false;
                        lb1.Visible = false;
                        continue;
                    }
                }
                catch
                {

                }
            }

        }
        //项目添加
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            DataSet dt2 = bus.Select("ProjectsDate_SelectisApply");
          DateTime  StartDate = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString());
          DateTime EndDate= Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString());
         DateTime NowDate = Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd"));
          if (NowDate < StartDate || NowDate > EndDate)
          {
              Response.Write("<script>alert('未在申报的有效时间内，禁止申报！')</script>");
           
              return;
          }
            string url = "/LongProjectsDeclareAdd.aspx";
          
            Response.Redirect(url);
        }
      
        //刷新
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        //查看项目详情
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsDeclareDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
           
            Response.Redirect(url);
           
        }
        //修改
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsDeclareAdd.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }
       
        //删除项目
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            if (bus.LongProjectsDelete("LongProjects_Delete", e.CommandArgument.ToString()))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('调配流程已经启动，禁止删除！')</script>");
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
            Response.Redirect("LongProjectsDeclareManage.aspx");
        }
    }
}