using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class JournalManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/JournalManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
               
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
            string UserName = txtUserName.Text.Trim().ToString();
            string Position = TextBox1.Text.Trim().ToString();
            string Events = TextBox2.Text.Trim().ToString();
            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            string seDay = DLDay.SelectedItem.ToString();
            int Day;
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
            try
            {
                Day = Convert.ToInt32(seDay);
            }
            catch (Exception)
            {

                Day = 0;
            }
          
            GridView1.DataSource = bus.SelectJournal("Journal_Selects", UserName, Year.ToString(), Month.ToString(),Day.ToString(),Position,Events).Tables[0].DefaultView;
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
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("JournalManage.aspx");
        }
    }
}