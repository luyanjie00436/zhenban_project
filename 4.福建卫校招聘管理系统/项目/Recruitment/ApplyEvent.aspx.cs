using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class ApplyEvent : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string Number;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='index.aspx'<" + "/script>");
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
            GridView1.DataSource = bus.SelectByNumber("Job_SelectByUser", Number).Tables[0].DefaultView;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label LStatus = (Label)GridView1.Rows[i].FindControl("LStatus");  //获取gridview中的编号控件

                    if (LStatus.Text != "全部合格")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        lb.Visible = false;
                    }
                    else
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        lb.Visible = true;
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
            Response.Cookies["selectNumber"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("PersonnelManage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            //准考证
            Response.Redirect("ZKZDetailed.aspx?JobId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");

        }
    }
}