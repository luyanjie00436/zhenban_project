using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UserInfoManage : System.Web.UI.Page
    {
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                #region bd
            
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
                    //[UserDepartment_SelectByUserCardId]
                    dt = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem li = new ListItem(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["DepartmentName"].ToString());
                        DlDepartment.Items.Add(li);
                    }
                }
                DataSet Status = bus.Select("Status_Select");
                foreach (DataRow dr in Status.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["StatusName"].ToString(), dr["StatusName"].ToString());
                    DlStatus.Items.Add(li);
                }
                DataSet Political = bus.Select("Political_Select");
                foreach (DataRow dr in Political.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalName"].ToString());
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
            string DepartmentId = DlDepartment.SelectedItem.Value;
            if (DepartmentId == "0")
            {
                DepartmentId = "";
            }
            string StatusId = DlStatus.SelectedItem.Value;
            if (StatusId == "0")
            {
                StatusId = "";
            }
            string PoliticalId = DlPolitical.SelectedItem.Value;
            if (PoliticalId == "0")
            {
                PoliticalId = "";
            }
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
                    Response.Write("<script>alert('年龄请输入数字');</script>");
                   // AlertMsgAndNoFlush(UpdatePanel1, "年龄请输入数字");
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
                    Response.Write("<script>alert('年龄请输入数字');</script>");
                    return;
                }
            }
            DataTable dt = bus.UserInfoSelect("UserMailList_Select", UserName,DepartmentId,  StatusId, StartYear, EndYear, Gender, PoliticalId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            foreach (DataColumn dc in dt.Columns)
            {
                var c = dc.ColumnName.ToString();
                var c2 = c;
            }
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