using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RoleApplyManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/RoleApplyManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleId"].ToString());
                    DlRole.Items.Add(li);
                }
                DataSet FollDate = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in FollDate.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DlFollDate.Items.Add(li);
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            int RoleId = Convert.ToInt32(DlRole.SelectedItem.Value);
            string Assessment = txtAssessmentName.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int ApplyYearId = Convert.ToInt32(DlFollDate.SelectedItem.Value);
            DataTable dt = bus.SelectRoleApply("RoleApply_Select", Assessment, RoleId, ApplyYearId,UserName).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("RoleApplyDetailed.aspx?RoleApply=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("RoleApplyAdd.aspx?RoleApply=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            if (bus.RoleApplyDelete("RoleApply_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
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
            Response.Redirect("RoleRegistrationAdd.aspx");
        }
    }
}