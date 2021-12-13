using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class LongProjectsNewIdManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsNewIdManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                #region
                DataTable dt = bus.SelectByRankId("Rank_SelectByRankId", RankId).Tables[0];
                if (dt.Rows[0]["RBL2"].ToString() == "是")
                {
                    DataSet department = bus.Select("Department_Select");
                    foreach (DataRow dr in department.Tables[0].Rows)
                    {
                        ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                        DlDepartment.Items.Add(li);
                    }
                }
                else
                {
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    ListItem li = new ListItem(dt.Rows[0]["DepartmentName"].ToString(), dt.Rows[0]["DepartmentName"].ToString());
                    DlDepartment.Items.Add(li);
                }
            
           
                DataSet From = bus.Select("ProjectsFrom_Select");
                foreach (DataRow dr in From.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromExplain"].ToString());
                    DLFrom.Items.Add(li);
                }
              

                #endregion

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        public void dataGriviewBD()
        {
            string ProjectsId = "";
            string ProjectsName = txtProjectsName.Text.Trim();
            string UserName = txtUserName.Text.Trim().ToString();
            string DepartmentName = DlDepartment.SelectedValue.ToString();
            string ApplyYear = "0";
            string Subject = "0";
            string Level = "0";
            string From = DLFrom.SelectedValue.ToString();
            string Declare = "0";
            string Stand = "0";
            string Inspect = "0";
            string Ends = "0";
            if (DepartmentName == "0")
            {
                DepartmentName = "";
            }
            if (ApplyYear == "0")
            {
                ApplyYear = "";
            } if (Subject == "0")
            {
                Subject = "";
            } if (Level == "0")
            {
                Level = "";
            } if (From == "0")
            {
                From = "";
            } if (Declare == "0")
            {
                Declare = "";
            } if (Stand == "0")
            {
                Stand = "";
            } if (Inspect == "0")
            {
                Inspect = "";
            } if (Ends == "0")
            {
                Ends = "";
            }

            DataTable dt = bus.SelectsLongProjects("LongProjectsView_Selects", ProjectsId, ProjectsName, UserName, DepartmentName, ApplyYear, Subject, Level, From, Declare, Stand, Inspect, Ends).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("LongProjectsInformationUpd.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf"));
        }
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsDeclareDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsStandDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsInspectDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsEndDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
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
            Response.Redirect("LongProjectsManage.aspx");
        }
    }
}