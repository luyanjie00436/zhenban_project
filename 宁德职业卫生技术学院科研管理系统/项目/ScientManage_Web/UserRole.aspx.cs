using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class UserRole : System.Web.UI.Page
    {
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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

                #region bd
                DataSet department = bus.Select("Department_Select");
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleId"].ToString());
                    DlRole.Items.Add(li);
                }
                #endregion
                if (Request.QueryString["UserCardId"] != null)
                {
                    try
                    {
                        txtUserCardId.Text = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");

                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                Button2.Visible = false;
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
            GridView1.DataSource = bus.SelectByUserCardId("UserRole_SelectByUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text;
            int DepartmentId = Convert.ToInt32(DlDepartment.SelectedItem.Value);
            int RoleId = Convert.ToInt32(DlRole.SelectedItem.Value);
           string   UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.UserRoleInsert("UserRole_Insert", UserCardId, DepartmentId, RoleId,UserCardId2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int UserRoleId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["UserRoleId"].Value));
            int DepartmentId = Convert.ToInt32(DlDepartment.SelectedItem.Value);
            int RoleId = Convert.ToInt32(DlRole.SelectedItem.Value);
            string UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.UserRoleUpdate("UserRole_Update", UserRoleId, DepartmentId, RoleId,UserCardId2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Button2.Visible = false;
                Button1.Visible = true;
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            int UserRoleId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Cookies["UserRoleId"].Value = e.CommandArgument.ToString();
            DataSet ds = bus.UserRoleSelect("UserRole_SelectByUserRoleId", UserRoleId);
            DlDepartment.SelectedValue = ds.Tables[0].Rows[0]["DepartmentId"].ToString();
            DlRole.SelectedValue = ds.Tables[0].Rows[0]["RoleId"].ToString();
            Button1.Visible = false;
            Button2.Visible = true;
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            UserCardId = txtUserCardId.Text;
            DataTable tb = bus.SelectByUserCardId("UserRole_SelectByUserCardId", UserCardId).Tables[0];
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (tb.Rows.Count == 1)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最后一条记录无法删除！");
                return;
            }
            int UserRoleId = Convert.ToInt32(e.CommandArgument.ToString());
            if (bus.UserRoleDelete("UserRole_Delete", UserRoleId,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败");
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
            Response.Redirect("RoleManage.aspx");
        }
    }
}