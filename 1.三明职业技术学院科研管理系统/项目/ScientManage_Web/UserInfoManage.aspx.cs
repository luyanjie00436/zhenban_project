using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class UserInfoManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoManage.aspx") == 0)
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
                DataSet Status = bus.Select("Status_Select");
                foreach (DataRow dr in Status.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["StatusName"].ToString(), dr["StatusId"].ToString());
                    DlStatus.Items.Add(li);
                }
                DataSet Job = bus.Select("Job_Select");
                foreach (DataRow dr in Job.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["JobName"].ToString(), dr["JobId"].ToString());
                    DlJob.Items.Add(li);
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleId"].ToString());
                    DlRole.Items.Add(li);
                }


                DataSet Post = bus.Select("Post_Select");
                foreach (DataRow dr in Post.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PostName"].ToString(), dr["PostId"].ToString());
                    DlPost.Items.Add(li);
                }
                DataSet Political = bus.Select("Political_Select");
                foreach (DataRow dr in Political.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalId"].ToString());
                    DlPolitical.Items.Add(li);
                }
                #endregion
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();

            }

        }
        public void dataGriviewBD()
        {
            string UserName = txtUserName.Text.Trim().ToString();
            int DepartmentId = Convert.ToInt32(DlDepartment.SelectedItem.Value);
            int JobId = Convert.ToInt32(DlJob.SelectedItem.Value);
            int PostId = Convert.ToInt32(DlPost.SelectedItem.Value);
            int StatusId = Convert.ToInt32(DlStatus.SelectedItem.Value);
            int PoliticalId = Convert.ToInt32(DlPolitical.SelectedItem.Value);
            int RoleId = Convert.ToInt32(DlRole.SelectedItem.Value);
            string Gender = DlGender.SelectedItem.Text;
            string StartYear = txtStartYear.Text.Trim().ToString();
            string EndYear = txtEndYear.Text.Trim().ToString();
            if (Gender == "请选择")
            {
                Gender = "";
            }
            if (StartYear != "")
            {
                try
                {
                    int Start = Convert.ToInt32(StartYear);
                }
                catch (Exception)
                {

                    AlertMsgAndNoFlush(UpdatePanel1, "年龄请输入数字");
                    return;
                }
            }
            if (EndYear != "")
            {
                try
                {
                    int End = Convert.ToInt32(EndYear);
                }
                catch (Exception)
                {

                    AlertMsgAndNoFlush(UpdatePanel1, "年龄请输入数字");
                    return;
                }
            }

            GridView1.DataSource = bus.UserInfoSelect("UserMailList_Select", UserName, DepartmentId, JobId, PostId, StatusId, StartYear, EndYear, Gender, PoliticalId, RoleId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("UserInfoUpd.aspx?UserCardId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            if (bus.DeleteByUserCardId("UserInfo_Delete",e.CommandArgument.ToString()))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
                return;
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败");
                return;
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
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("UserInfoManage.aspx");
        }
    }
}