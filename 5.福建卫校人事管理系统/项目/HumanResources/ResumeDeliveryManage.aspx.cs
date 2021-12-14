using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ResumeDeliveryManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ResumeDeliveryManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("ResumeDeliveryDetailed.aspx?ResumeDelivery=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
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
            DataTable dt = bus.SelectResumeDelivery("ResumeDelivery_SelectByUserCardId", UserCardId, UserName, Year, Month).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
           
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
            Response.Redirect("ResumeDeliveryManage.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}