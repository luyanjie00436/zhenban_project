using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class LongProjectsOReviewManage : System.Web.UI.Page
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        public void dataGriviewBD()
        {

            string Remarks = txtRemarks.Text.Trim();
            DataTable dt = bus.SelectsOReview("LongProjectsOReview_Select", Remarks).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();

        }
    
        //项目添加
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string url = "/LongProjectsOReviewAdd.aspx";
            Response.Redirect(url);
        }

      
        //查看项目详情
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsOReviewDetaileds.aspx?OReviewId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");

            Response.Redirect(url);

        }
        //修改
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsOReviewAdd.aspx?OReviewId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }

        //删除项目
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            if (bus.LongProjectsOReviewDelete("LongProjectsOReview_Delete", e.CommandArgument.ToString()))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                dataGriviewBD();
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
            Response.Redirect("LongProjectsOReviewManage.aspx");
        }
    }
}