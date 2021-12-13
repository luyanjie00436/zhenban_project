using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{

    public partial class PostManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/PostManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {

            GridView1.DataSource = bus.Select("Post_Select").Tables[0].DefaultView;
            GridView1.DataBind();
        }

       
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            int countpost = bus.PostSum("UserInfo_SelectPostSum", Convert.ToInt32(e.CommandArgument.ToString()));
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);


            if (countpost > 0)
            {
                Response.Write("<script>alert('您要删除的职级已有" + countpost + "位用户在使用，不能删除该职级！');</script>");
            }
            else if (bus.PostDelete("Post_Delete", Convert.ToInt32(e.CommandArgument.ToString()),UserCardId))
            {
                Response.Write("<script>alert('删除成功');</script>");
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
            Response.Cookies["selectPostId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("PostManage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}