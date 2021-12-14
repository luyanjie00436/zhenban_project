using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class LeaveManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LeaveManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

              

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("LeaveDetailed.aspx?Leave=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        public void dataGriviewBD()
        {
            string UserName = txtUserName.Text.Trim().ToString();
            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            try
            {
                Year = Convert.ToInt32(seYear);
            }
            catch (Exception)
            {

                Year = 0;
            }
            try
            {
                Month = Convert.ToInt32(seMonth);
            }
            catch (Exception)
            {

                Month = 0;
            }
          
            DataTable dt = bus.SelectTransfer("Leave_Selects", UserName,  Year, Month).Tables[0];
            GridView1.DataSource = dt.DefaultView;
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
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("LeaveManage.aspx");
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("LeaveAdd.aspx?Leave=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");

        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            if (bus.LeaveDelete("Leave_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败！请联系系统管理员解决问题");
            }
        }
    }
}