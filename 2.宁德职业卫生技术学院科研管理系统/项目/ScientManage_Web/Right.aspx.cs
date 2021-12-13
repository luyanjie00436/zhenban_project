using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class Right : System.Web.UI.Page
    {
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                DataTable dt3 = bus.SelectByRankId("AuthorityView_Select", RankId).Tables[0];
                #region 个人拥有记录
                DataTable dt = bus.SelectByUserCardId("Right_SelectByleftUserCardId", UserCardId).Tables[0];
                int zuo = 0;
                int zuo1 = 0;
                int zuo2 = 0;
                int zuo3 = 0;
                #region 教学质量工程
                if (dt3.Select("ModelUrl='~/MyGuidanceManage.aspx'").Count() == 0)
                {
                    divMyGuidance.Visible = false;
                  
                }
                else
                {
                    if ( Convert.ToInt32( dt.Rows[0]["GuidanceNum"].ToString())>0)
                    {
                        aMyGuidance.InnerText = dt.Rows[0]["GuidanceNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyGuidance.Visible = false;
                    }
                }
                #endregion
                #region 技能竞赛
                if (dt3.Select("ModelUrl='~/MyCompetitionManage.aspx'").Count() == 0)
                {
                    divMyCompetition.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["CompetitionNum"].ToString()) > 0)
                    {
                        aMyCompetition.InnerText = dt.Rows[0]["CompetitionNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyCompetition.Visible = false;
                    }
                }
                #endregion

                #region 著作教材
                if (dt3.Select("ModelUrl='~/MyTeachingManage.aspx'").Count() == 0)
                {
                    divMyTeaching.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["TeachingNum"].ToString()) > 0)
                    {
                        aMyTeaching.InnerText = dt.Rows[0]["TeachingNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyTeaching.Visible = false;
                    }
                }
                #endregion
                #region 论文
                if (dt3.Select("ModelUrl='~/MyPaperManage.aspx'").Count() == 0)
                {
                    divMyPaper.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["PaperNum"].ToString()) > 0)
                    {
                        aMyPaper.InnerText = dt.Rows[0]["PaperNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyPaper.Visible = false;
                    }
                }
                #endregion
                #region 科研项目
                if (dt3.Select("ModelUrl='~/MyWorkLoadProjectsManage.aspx'").Count() == 0)
                {
                    divMyWorkLoadProjects.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["WorkLoadProjectsNum"].ToString()) > 0)
                    {
                        aMyWorkLoadProjects.InnerText = dt.Rows[0]["WorkLoadProjectsNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyWorkLoadProjects.Visible = false;
                    }
                }
                #endregion
                #region 专利
                if (dt3.Select("ModelUrl='~/MyPatentManage.aspx'").Count() == 0)
                {
                    divMyPatent.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["PatentNum"].ToString()) > 0)
                    {
                        aMyPatent.InnerText = dt.Rows[0]["PatentNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyPatent.Visible = false;
                    }
                }
                #endregion
                #region 科技成果
                if (dt3.Select("ModelUrl='~/MyHarvestManage.aspx'").Count() == 0)
                {
                    divMyHarvest.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["HarvestNum"].ToString()) > 0)
                    {
                        aMyHarvest.InnerText = dt.Rows[0]["HarvestNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyHarvest.Visible = false;
                    }
                }
                #endregion
                #region 其他成果
                if (dt3.Select("ModelUrl='~/MyOtherResultsManage.aspx'").Count() == 0)
                {
                    divMyOtherResults.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["OtherResultsNum"].ToString()) > 0)
                    {
                        aMyOtherResults.InnerText = dt.Rows[0]["OtherResultsNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyOtherResults.Visible = false;
                    }
                }
                #endregion
                #region 学术活动
                if (dt3.Select("ModelUrl='~/MyActivityManage.aspx'").Count() == 0)
                {
                    divMyActivity.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ActivityNum"].ToString()) > 0)
                    {
                        aMyActivity.InnerText = dt.Rows[0]["ActivityNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyActivity.Visible = false;
                    }
                }
                #endregion
              
                #region 获奖成果
                if (dt3.Select("ModelUrl='~/MyWinningManage.aspx'").Count() == 0)
                {
                    divMyWinning.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["WinningNum"].ToString()) > 0)
                    {
                        aMyWinning.InnerText = dt.Rows[0]["WinningNum"].ToString();
                        zuo = zuo + 1;
                    }
                    else
                    {
                        divMyWinning.Visible = false;
                    }
                }
                #endregion

                if (zuo == 0)
                {
                    divcg.Visible = false;
                }
                #region 团体学会
                if (dt3.Select("ModelUrl='~/MyAssciationManage.aspx'").Count() == 0)
                {
                    divMyAssciation.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["AssociationNum"].ToString()) > 0)
                    {
                        aMyAssciation.InnerText = dt.Rows[0]["AssociationNum"].ToString();
                        zuo3 = zuo3 + 1;
                    }
                    else
                    {
                        divMyAssciation.Visible = false;
                    }
                }

                #endregion
                #region 学术讲座
                if (dt3.Select("ModelUrl='~/MyLctureManage.aspx'").Count() == 0)
                {
                    divMyLcture.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LctureNum"].ToString()) > 0)
                    {
                        aMyLcture.InnerText = dt.Rows[0]["LctureNum"].ToString();
                        zuo3 = zuo3 + 1;
                    }
                    else
                    {
                        divMyLcture.Visible = false;
                    }
                }
                #endregion
                if (zuo3 == 0)
                {
                    divxuehui.Visible = false;
                }
                #region 纵向项目申报
                if (dt3.Select("ModelUrl='~/LongProjectsDeclareManage.aspx'").Count() == 0)
                {
                    divMyLongDeclare.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongDeclareNum"].ToString()) > 0)
                    {
                        aMyLongDeclare.InnerText = dt.Rows[0]["LongDeclareNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyLongDeclare.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目立项
                if (dt3.Select("ModelUrl='~/LongProjectsStandManage.aspx'").Count() == 0)
                {
                    divMyLongStand.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongStandNum"].ToString()) > 0)
                    {
                        aMyLongStand.InnerText = dt.Rows[0]["LongStandNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyLongStand.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目中检
                if (dt3.Select("ModelUrl='~/LongProjectsInspectManage.aspx'").Count() == 0)
                {
                    divMyLongInspect.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongInspectNum"].ToString()) > 0)
                    {
                        aMyLongInspect.InnerText = dt.Rows[0]["LongInspectNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyLongInspect.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目结题
                if (dt3.Select("ModelUrl='~/LongProjectsEndManage.aspx'").Count() == 0)
                {
                    divMyLongEnd.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongEndNum"].ToString()) > 0)
                    {
                        aMyLongEnd.InnerText = dt.Rows[0]["LongEndNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyLongEnd.Visible = false;
                    }
                }
                #endregion
                #region 横向项目立项
                if (dt3.Select("ModelUrl='~/ShortProjectsStandManage.aspx'").Count() == 0)
                {
                    divMyShortStand.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ShortStandNum"].ToString()) > 0)
                    {
                        aMyShortStand.InnerText = dt.Rows[0]["ShortStandNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyShortStand.Visible = false;
                    }
                }
                #endregion
                #region 横向项目结题
                if (dt3.Select("ModelUrl='~/ShortProjectsEndManage.aspx'").Count() == 0)
                {
                    divMyShortEnd.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ShortEndNum"].ToString()) > 0)
                    {
                        aMyShortEnd.InnerText = dt.Rows[0]["ShortEndNum"].ToString();
                        zuo1 = zuo1 + 1;
                    }
                    else
                    {
                        divMyShortEnd.Visible = false;
                    }
                }
                #endregion
                if (zuo1 == 0)
                {
                    divxm.Visible = false;
                }
                #region 纵向经费预算
                if (dt3.Select("ModelUrl='~/LongCapitalPlanManage.aspx'").Count() == 0)
                {
                    divMyLongPlan.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongPlanNum"].ToString()) > 0)
                    {
                        aMyLongPlan.InnerText = dt.Rows[0]["LongPlanNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyLongPlan.Visible = false;
                    }
                }
                #endregion
                #region 纵向经费变更
                if (dt3.Select("ModelUrl='~/LongCapitalChangeManage.aspx'").Count() == 0)
                {
                    divMyLongChange.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongChangeNum"].ToString()) > 0)
                    {
                        aMyLongChange.InnerText = dt.Rows[0]["LongChangeNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyLongChange.Visible = false;
                    }
                }
                #endregion
                #region 纵向经费预算
                if (dt3.Select("ModelUrl='~/LongCapitalCloseManage.aspx'").Count() == 0)
                {
                    divMyLongClose.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["LongCloseNum"].ToString()) > 0)
                    {
                        aMyLongClose.InnerText = dt.Rows[0]["LongCloseNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyLongClose.Visible = false;
                    }
                }
                #endregion
                #region 横向经费预算
                if (dt3.Select("ModelUrl='~/ShortCapitalPlanManage.aspx'").Count() == 0)
                {
                    divMyShortPlan.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ShortPlanNum"].ToString()) > 0)
                    {
                        aMyShortPlan.InnerText = dt.Rows[0]["ShortPlanNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyShortPlan.Visible = false;
                    }
                }
                #endregion
                #region 横向经费变更
                if (dt3.Select("ModelUrl='~/ShortCapitalChangeManage.aspx'").Count() == 0)
                {
                    divMyShortChange.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ShortChangeNum"].ToString()) > 0)
                    {
                        aMyShortChange.InnerText = dt.Rows[0]["ShortChangeNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyShortChange.Visible = false;
                    }
                }
                #endregion
                #region 横向经费预算
                if (dt3.Select("ModelUrl='~/ShortCapitalCloseManage.aspx'").Count() == 0)
                {
                    divMyShortClose.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ShortCloseNum"].ToString()) > 0)
                    {
                        aMyShortClose.InnerText = dt.Rows[0]["ShortCloseNum"].ToString();
                        zuo2 = zuo2 + 1;
                    }
                    else
                    {
                        divMyShortClose.Visible = false;
                    }
                }
                #endregion
                if (zuo2 == 0)
                {
                    divzj.Visible = false;
                }
                if (zuo == 0&&zuo1==0&&zuo2==0&&zuo3==0)
                {
                    divzuo.Visible = false;
                }
                #endregion
                #region 需审批数量
                DataTable dt2 = bus.PaperExamineSelectUser("Right_SelectByrightUserCardId", UserCardId, RankId).Tables[0];
                int you = 0;

                #region 成果
                if (dt3.Select("ModelUrl='~/Approval.aspx'").Count() == 0)
                {
                    divApproval.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ApprovalNum"].ToString()) > 0)
                    {
                        aApproval.InnerText = dt2.Rows[0]["ApprovalNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divApproval.Visible = false;
                    }
                }
                #endregion
                #region 学术活动
                if (dt3.Select("ModelUrl='~/AssciationExamineManage.aspx'").Count() == 0)
                {
                    divAssciationExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["AssciationNum"].ToString()) > 0)
                    {
                        AAssciationExamine.InnerText = dt2.Rows[0]["AssciationNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divAssciationExamine.Visible = false;
                    }
                }
                #endregion
                #region 学术讲座
                if (dt3.Select("ModelUrl='~/LctureExamineManage.aspx'").Count() == 0)
                {
                    divLctureExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LctureNum"].ToString()) > 0)
                    {
                        aLctureExamine.InnerText = dt2.Rows[0]["LctureNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLctureExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目申报
                if (dt3.Select("ModelUrl='~/LongProjectsDeclareExamineManage.aspx'").Count() == 0)
                {
                    divLongDeclareExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongDeclareNum"].ToString()) > 0)
                    {
                        aLongDeclareExamine.InnerText = dt2.Rows[0]["LongDeclareNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongDeclareExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目立项
                if (dt3.Select("ModelUrl='~/LongProjectsStandExamineManage.aspx'").Count() == 0)
                {
                    divLongStandExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongStandNum"].ToString()) > 0)
                    {
                        aLongStandExamine.InnerText = dt2.Rows[0]["LongStandNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongStandExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目中检
                if (dt3.Select("ModelUrl='~/LongProjectsInspectExamineManage.aspx'").Count() == 0)
                {
                    divLongInspectExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongInspectNum"].ToString()) > 0)
                    {
                        aLongInspectExamine.InnerText = dt2.Rows[0]["LongInspectNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongInspectExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向项目结题
                if (dt3.Select("ModelUrl='~/LongProjectsEndExamineManage.aspx'").Count() == 0)
                {
                    divLongEndExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongEndNum"].ToString()) > 0)
                    {
                        aLongEndExamine.InnerText = dt2.Rows[0]["LongEndNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongEndExamine.Visible = false;
                    }
                }
                #endregion
                #region 横向项目立项
                if (dt3.Select("ModelUrl='~/ShortProjectsStandExamineManage.aspx'").Count() == 0)
                {
                    divShortStandExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ShortStandNum"].ToString()) > 0)
                    {
                        aShortStandExamine.InnerText = dt2.Rows[0]["ShortStandNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divShortStandExamine.Visible = false;
                    }
                }
                #endregion
                #region 横向项目结题
                if (dt3.Select("ModelUrl='~/ShortProjectsEndExamineManage.aspx'").Count() == 0)
                {
                    divShortEndExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ShortEndNum"].ToString()) > 0)
                    {
                        aShortEndExamine.InnerText = dt2.Rows[0]["ShortEndNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divShortEndExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向经费预算
                if (dt3.Select("ModelUrl='~/LongCapitalPlanExamineManage.aspx'").Count() == 0)
                {
                    divLongPlanExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongPlanNum"].ToString()) > 0)
                    {
                        aLongPlanExamine.InnerText = dt2.Rows[0]["LongPlanNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongPlanExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向经费变更
                if (dt3.Select("ModelUrl='~/LongCapitalChangeExamineManage.aspx'").Count() == 0)
                {
                    divLongChangeExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongChangeNum"].ToString()) > 0)
                    {
                        aLongChangeExamine.InnerText = dt2.Rows[0]["LongChangeNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongChangeExamine.Visible = false;
                    }
                }
                #endregion
                #region 纵向经费决算
                if (dt3.Select("ModelUrl='~/LongCapitalCloseExamineManage.aspx'").Count() == 0)
                {
                    divLongCloseExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["LongCloseNum"].ToString()) > 0)
                    {
                        aLongCloseExamine.InnerText = dt2.Rows[0]["LongCloseNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divLongCloseExamine.Visible = false;
                    }
                }
                #endregion

                #region 横向经费预算
                if (dt3.Select("ModelUrl='~/ShortCapitalPlanExamineManage.aspx'").Count() == 0)
                {
                    divShortPlanExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ShortPlanNum"].ToString()) > 0)
                    {
                        aShortPlanExamine.InnerText = dt2.Rows[0]["ShortPlanNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divShortPlanExamine.Visible = false;
                    }
                }
                #endregion
                #region 横向经费变更
                if (dt3.Select("ModelUrl='~/ShortCapitalChangeExamineManage.aspx'").Count() == 0)
                {
                    divShortChangeExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ShortChangeNum"].ToString()) > 0)
                    {
                        aShortChangeExamine.InnerText = dt2.Rows[0]["ShortChangeNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divShortChangeExamine.Visible = false;
                    }
                }
                #endregion
                #region 横向经费决算
                if (dt3.Select("ModelUrl='~/ShortCapitalCloseExamineManage.aspx'").Count() == 0)
                {
                    divShortCloseExamine.Visible = false;
                }
                else
                {
                    if (Convert.ToInt32(dt2.Rows[0]["ShortCloseNum"].ToString()) > 0)
                    {
                        aShortCloseExamine.InnerText = dt2.Rows[0]["ShortCloseNum"].ToString();
                        you = you + 1;
                    }
                    else
                    {
                        divShortCloseExamine.Visible = false;
                    }
                }
                #endregion
                if (you == 0)
                {
                    divyou.Visible = false;
                }
                #endregion




                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }

        public void dataGriviewBD()
        {
            GridView1.DataSource = bus.Select("Notice_Select").Tables[0].DefaultView;
            GridView1.DataBind();

        }

        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {


            if (e.CommandArgument.ToString() != "")
            {
                string path = Server.MapPath("./") + e.CommandArgument.ToString();
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Length", fi.Length.ToString());
                    Response.ContentType = "application/application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                    Response.WriteFile(fi.FullName);
                    Response.End();
                    Response.Flush();
                    Response.Clear();

                }
            }
            else
            {
                Response.Write("<script>alert('未上传附件，无法下载！')</script>");
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
         //   Response.Cookies["selectNoticeId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
       //  Response.Redirect("NoticeManage.aspx");
        }
    }
}