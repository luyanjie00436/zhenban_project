using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ExpertReviewMembers : System.Web.UI.Page
    {
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        string UserCardId;
        int ExpertReviewId;
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
                    return;
                }
                if (Request.QueryString["ExpertReviewId"] != null)
                {
                    ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);
                    btn_Add.HRef = "ExpertReviewMembersAdd.aspx?ExpertReviewId="+ExpertReviewId.ToString()+"&keepThis=true&TB_iframe=true&height=300&width=500";
                    GridView1.AutoGenerateColumns = false;
                    dataGriviewBD();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    return;
                }

                  
            }
        }
        public void dataGriviewBD()
        {
            ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);
        
            GridView1.DataSource = bus.SelectByExpertReviewId("ExpertReviewMembers_SelectByExpartReviewId", ExpertReviewId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        //删除
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);         
            if (bus.ExpertReviewMembersDelete("ExpertReviewMembers_Delete", e.CommandArgument.ToString(), UserCardId))
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
            Response.Cookies["selectJobId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ExpertReviewMembers.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}