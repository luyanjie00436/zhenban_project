using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class Approval : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/GuidanceExamineManage.aspx") == 0)
                //{
                //      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                //}
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            //教学质量工程
            DataTable dt1=bus.GuidanceExamineSelectUser("Guidance_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView1.DataSource = dt1.DefaultView;
            GridView1.DataBind();
            if (dt1.Rows.Count<1)
            {
                tbs1.Style.Add("display", "none");
            }
           
            //技能竞赛
            DataTable dt2 = bus.CompetitionExamineSelectUser("Competition_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView2.DataSource =dt2.DefaultView;
            GridView2.DataBind();
            if(dt2.Rows.Count<1)
            {
                tbs2.Style.Add("display","none");
            }
            //著作教材
            DataTable dt3= bus.TeachingExamineSelectUser("Teaching_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView3.DataSource =dt3.DefaultView;
            GridView3.DataBind();
            if (dt3.Rows.Count < 1)
            {
                tbs3.Style.Add("display", "none");
            }
            //论文
            DataTable dt4 = bus.PaperExamineSelectUser("Paper_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView4.DataSource = dt4.DefaultView;
            GridView4.DataBind();
             if(dt4.Rows.Count<1)
            {
                tbs4.Style.Add("display","none");
            }
            //科研项目
             DataTable dt5 = bus.WorkLoadProjectsExamineSelectUser("WorkLoadProjects_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView5.DataSource = dt5.DefaultView;
            GridView5.DataBind();
             if(dt5.Rows.Count<1)
            {
                tbs5.Style.Add("display","none");
            }
            //专利
             DataTable dt6 = bus.PatentExamineSelectUser("Patent_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView6.DataSource =dt6.DefaultView;
            GridView6.DataBind();
             if(dt6.Rows.Count<1)
            {
                tbs6.Style.Add("display","none");
            }
            //成果奖
            DataTable dt7=bus.HarvestExamineSelectUser("Harvest_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView7.DataSource = dt7.DefaultView;
            GridView7.DataBind();
             if(dt7.Rows.Count<1)
            {
                tbs7.Style.Add("display","none");
            }
            //其他成果
             DataTable dt8 = bus.OtherResultsExamineSelectUser("OtherResults_SelectByUserCardId", UserCardId, RankId).Tables[0];
            GridView8.DataSource = dt8.DefaultView;
            GridView8.DataBind();
             if(dt8.Rows.Count<1)
            {
                tbs8.Style.Add("display","none");
            }
            //学术活动
            DataTable dt9= bus.ActivityExamineSelectUser("Activity_SelectByUserCardId", UserCardId, RankId).Tables[0];
             GridView9.DataSource =dt9.DefaultView;
             GridView9.DataBind();
             if (dt9.Rows.Count < 1)
             {
                 tbs9.Style.Add("display", "none");
             }
           
             //获奖成果
             DataTable dt12 = bus.GuidanceExamineSelectUser("Winning_SelectByUserCardId", UserCardId, RankId).Tables[0];
             GridView12.DataSource = dt12.DefaultView;
             GridView12.DataBind();
             if (dt12.Rows.Count < 1)
             {
                 tbs12.Style.Add("display", "none");
             }
        }

        //教学质量工程
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("GuidanceExamineDetailed.aspx?GuidanceId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
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
            Response.Redirect("GuidanceExamineManage.aspx");
        }

        //技能竞赛
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("CompetitionExamineDetailed.aspx?CompetitionId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView2.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView2.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView2.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView2.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("CompetitionExamineManage.aspx");
        }
        //著作教材
        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("TeachingExamineDetailed.aspx?TeachingId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView3.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView3.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView3.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView3.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("TeachingExamineManage.aspx");
        }
        //论文
        protected void LinkButton4_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("PaperExamineDetailed.aspx?PaperId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView4.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView4.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView4.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView4_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView4.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("PaperExamineManage.aspx");
        }
        //科研项目
        protected void LinkButton5_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("WorkLoadProjectsExamineDetailed.aspx?WorkLoadProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView5.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView5.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView5.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView5_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView5.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("WorkLoadProjectsExamineManage.aspx");
        }
        //专利
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("PatentExamineDetailed.aspx?PatentId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView6.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView6.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView6.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView6_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView6.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("PatentExamineManage.aspx");
        }
        //成果奖
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("HarvestExamineDetailed.aspx?HarvestId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView7_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView7.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView7.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView7.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView7_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView7.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("HarvestExamineManage.aspx");
        }
        //其他成果
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("OtherResultsExamineDetailed.aspx?OtherResultsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView8_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView8.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView8.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView8.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView8_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView8.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("OtherResultsExamineManage.aspx");
        }
       //学术活动
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("ActivityExamineDetailed.aspx?ActivityId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView9_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView9.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView9.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView9.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView9_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView9.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ActivityExamineManage.aspx");
        }
      
        //获奖成果
        protected void LinkButton12_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("WinningExamineDetailed.aspx?WinningId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void GridView12_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView12.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView12.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView12.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView12_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView12.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("WinningExamineManage.aspx");
        }
    }
}