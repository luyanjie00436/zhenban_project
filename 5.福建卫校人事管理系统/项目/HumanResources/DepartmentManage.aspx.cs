using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class DepartmentManage : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DepartmentManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
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
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("DepartmentUpd.aspx?Department=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
      
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

           if (bus.DepartmentDelete("Department_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
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