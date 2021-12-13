using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LongCapitalPlanProcess : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongCapitalPlanProcess.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet Rank = bus.Select("Rank_Select");
                foreach (DataRow dr in Rank.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                    DlRank.Items.Add(li);
                }
                DataSet Department = bus.Select("Department_Select");
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            int RankId = Convert.ToInt32(DlRank.SelectedItem.Value);
            int ProcessOrder = Convert.ToInt32(DlProcessOrder.SelectedItem.Value);
            string DepartmentName = DlDepartment.SelectedItem.Text;

            if (bus.LongProjectsProcessInsert("LongCapitalPlanProcess_Insert", RankId, ProcessOrder, DepartmentName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "增加成功");
                dataGriviewBD();
                return;
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "增加失败");
                return;
            }

        }

        public void dataGriviewBD()
        {

            GridView1.DataSource = bus.Select("LongCapitalPlanProcess_Select").Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
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
            Response.Redirect("LctureProcess.aspx");
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.LongCapitalPlanProcessDelete("LongCapitalPlanProcess_Delete", Convert.ToInt32(e.CommandArgument.ToString()), UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
        }
    }
}