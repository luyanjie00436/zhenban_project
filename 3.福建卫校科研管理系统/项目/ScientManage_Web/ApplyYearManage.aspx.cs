using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ApplyYearManage : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ApplyYearManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            DataTable dt = bus.Select("ApplyYear_Select").Tables[0];
            string isApply = "";
            string isApplyProject = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["isApply"].ToString() == "1")
                {
                    isApply = dr["ApplyYearId"].ToString();
                    break;
                }
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["isApplyProject"].ToString() == "1")
                {
                    isApplyProject = dr["ApplyYearId"].ToString();
                    break;
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label num = (Label)GridView1.Rows[i].FindControl("Year_Num");  //获取gridview中的编号控件
                    if (num.Text == isApply)
                    {
                        Label applyTime = (Label)GridView1.Rows[i].FindControl("applyTime");  //获取gridview中是否是申报时间的隐藏控件
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton1");
                        lb.Visible = false;
                        applyTime.Visible = true;

                    }
                    if (num.Text == isApplyProject)
                    {
                        Label ApplyProject = (Label)GridView1.Rows[i].FindControl("LApplyProject");  //获取gridview中是否是申报时间的隐藏控件
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton2");
                        lb.Visible = false;
                        ApplyProject.Visible = true;

                    }
                }
                catch 
                {
                   
                }
            }
          
        }


        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ApplyYearDelete("ApplyYear_UpdateIsApply", Convert.ToInt32(e.CommandArgument.ToString()),UserCardId))
            {
                Response.Write("<script>alert('设置默认成功');</script>");
                dataGriviewBD();
            }
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ApplyYearDelete("ApplyYear_UpdateIsApplyProject", Convert.ToInt32(e.CommandArgument.ToString()), UserCardId))
            {

                Response.Write("<script>alert('设置默认成功');</script>");

                dataGriviewBD();
            }
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            Response.Cookies["ApplyYearId"].Value = e.CommandArgument.ToString();
            DataSet ds = bus.SelectByApplyYearId("ApplyYear_SelectByApplyYearId", Convert.ToInt32(e.CommandArgument.ToString()));
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ApplyYearDelete("ApplyYear_Delete", Convert.ToInt32(e.CommandArgument.ToString()),UserCardId))
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
            Response.Cookies["selectApplyYearId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ApplyYearManage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}