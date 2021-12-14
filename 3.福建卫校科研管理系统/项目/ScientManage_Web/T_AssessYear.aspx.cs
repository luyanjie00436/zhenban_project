
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class T_AssessYear : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/T_AssessYear.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DataTable dt = bus.SelectByUserCardId("T_AssessValue_SelectByUserCardId", UserCardId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            string ApplyYear = bus.Select("ApplyYear_SelectisApply").Tables[0].Rows[0]["ReportDate"].ToString();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label LReportDate = (Label)GridView1.Rows[i].FindControl("LReportDate");  //获取gridview中的年份控件
                    if (LReportDate.Text == ApplyYear)
                    {
                        GridView1.Rows[i].FindControl("A7").Visible = true;                      
                    }
                    else
                    {
                      GridView1.Rows[i].FindControl("A7").Visible = false;
                    }
                }
                catch
                {

                }
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
            Response.Cookies["selectCapitalId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("T_AssessYear.aspx");
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            Response.Redirect("T_AssessDetailed.aspx?ApplyYearId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "&UserCardId=" + pwds.EncryptDES(UserCardId, "asdfasdf"));
        }
    }
}