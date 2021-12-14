using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class DepartmentManage : System.Web.UI.Page
    {
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DepartmentManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                GridView1.AutoGenerateColumns = false;

                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            GridView1.DataSource = bus.Select("Department_Select").Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            int countjob = bus.DepartmentSum("UserInfo_SelectDepartmentSum", Convert.ToInt32(e.CommandArgument.ToString()));
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (countjob > 0)
            {
               // AlertMsgAndNoFlush(UpdatePanel1, "");
                Response.Write("<script>alert('您要删除的部门已有" + countjob + "位用户，不能删除该部门！！');<" + "/script>");
            
            }
            else if (bus.DepartmentDelete("Department_Delete", Convert.ToInt32(e.CommandArgument.ToString()),UserCardId))
            {
                Response.Write("<script>alert('删除成功');</script>");
            
               // AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
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
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectDepartmentId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("DepartmentManage.aspx");
        }
    }
}