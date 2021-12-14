using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Right : System.Web.UI.Page
    {
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
                DataTable dt3 = bus.SelectByRankId("AuthorityView_Select", RankId).Tables[0];
                #region 个人拥有记录
                DataTable dt = bus.SelectByUserCardId("Right_SelectByUserCardId", UserCardId).Tables[0];
                int zuo = 0;
                //著作
                if (dt3.Select("ModelUrl='~/MyTeachingManage.aspx'").Count() == 0)
                {
                    divMyTeaching.Style.Add("display", "none");
                }

                else
                {
                    aMyTeaching.InnerText = dt.Rows[0]["TeachingNum"].ToString();
                    zuo = zuo + 1;
                }
                //获奖
                if (dt3.Select("ModelUrl='~/MyWinningManage.aspx'").Count() == 0)
                {
                    divMyWinning.Style.Add("display", "none");
                }
                else
                {

                    aMyWinning.InnerText = dt.Rows[0]["WinningNum"].ToString();
                    zuo = zuo + 1;
                }
                //专利
                if (dt3.Select("ModelUrl='~/MyPatentManage.aspx'").Count() == 0)
                {
                    divMyPatent.Style.Add("display", "none");
                }
                else
                {
                    aMyPatent.InnerText = dt.Rows[0]["PatentNum"].ToString();
                    zuo = zuo + 1;
                }

                //论文
                if (dt3.Select("ModelUrl='~/MyPaperManage.aspx'").Count() == 0)
                {
                    divMyPaper.Style.Add("display", "none");
                }
                else
                {

                    aMyPaper.InnerText = dt.Rows[0]["PaperNum"].ToString();
                    zuo = zuo + 1;
                }
                //指导学生
                if (dt3.Select("ModelUrl='~/MyGuidanceManage.aspx'").Count() == 0)
                {
                    divMyGuidance.Style.Add("display", "none");
                }
                else
                {
                    aMyGuidance.InnerText = dt.Rows[0]["GuidanceNum"].ToString();
                    zuo = zuo + 1;
                }
                //科研项目
                if (dt3.Select("ModelUrl='~/MyWorkLoadProjectsManage.aspx'").Count() == 0)
                {
                    divMyWorkLoadProjects.Style.Add("display", "none");
                }
                else
                {
                    aMyWorkLoadProjects.InnerText = dt.Rows[0]["WorkLoadProjectsNum"].ToString();
                    zuo = zuo + 1;
                }
                //科研成果
                if (dt3.Select("ModelUrl='~/MyHarvestManage.aspx'").Count() == 0)
                {
                    divMyHarvest.Style.Add("display", "none");
                }
                else
                {
                    aMyHarvest.InnerText = dt.Rows[0]["HarvestNum"].ToString();
                    zuo = zuo + 1;
                }


                //教材建设信息
                if (dt3.Select("ModelUrl='~/MyT_TeachingManage.aspx'").Count() == 0)
                {
                    divMyT_Teaching.Style.Add("display", "none");
                }
                else
                {
                    aMyT_Teaching.InnerText = dt.Rows[0]["T_TeachingNum"].ToString();
                    zuo = zuo + 1;
                }
                //教学团队建设信息
                if (dt3.Select("ModelUrl='~/MyTeaching_TeamManage.aspx'").Count() == 0)
                {
                    divMyTeaching_Team.Style.Add("display", "none");
                }
                else
                {
                    aMyTeaching_Team.InnerText = dt.Rows[0]["Teaching_TeamNum"].ToString();
                    zuo = zuo + 1;
                }
                //专业建设信息
                if (dt3.Select("ModelUrl='~/MyP_constructionManage.aspx'").Count() == 0)
                {
                    divMyP_construction.Style.Add("display", "none");
                }
                else
                {
                    aMyP_construction.InnerText = dt.Rows[0]["P_constructionNum"].ToString();
                    zuo = zuo + 1;
                }
                //课程建设信息
                if (dt3.Select("ModelUrl='~/MyC_constructionManage.aspx'").Count() == 0)
                {
                    divMyC_construction.Style.Add("display", "none");
                }
                else
                {
                    aMyC_construction.InnerText = dt.Rows[0]["C_constructionNum"].ToString();
                    zuo = zuo + 1;
                }
                //竞赛获奖信息
                if (dt3.Select("ModelUrl='~/MyC_winnersManage.aspx'").Count() == 0)
                {
                    divMyC_winners.Style.Add("display", "none");
                }
                else
                {

                    aMyC_winners.InnerText = dt.Rows[0]["C_winnersNum"].ToString();
                    zuo = zuo + 1;
                }
                //教学成果获奖信息
                if (dt3.Select("ModelUrl='~/MyResultsManage.aspx'").Count() == 0)
                {
                    divMyResults.Style.Add("display", "none");
                }
                else
                {
                    aMyResults.InnerText = dt.Rows[0]["ResultsNum"].ToString();
                    zuo = zuo + 1;
                }
                //专项分值信息
                if (dt3.Select("ModelUrl='~/MySpecialManage.aspx'").Count() == 0)
                {
                    divMySpecial.Style.Add("display", "none");
                }
                else
                {
                    aMySpecial.InnerText = dt.Rows[0]["SpecialNum"].ToString();
                    zuo = zuo + 1;
                }
                //教学工作量转化教研分信息
                if (dt3.Select("ModelUrl='~/MyTeachToTeachingManage.aspx'").Count() == 0)
                {
                    divMyTeachToTeaching.Style.Add("display", "none");
                }
                else
                {
                    aMyTeachToTeaching.InnerText = dt.Rows[0]["TeachToTeachingNum"].ToString();
                    zuo = zuo + 1;
                }

                //纵向项目申报
                if (dt3.Select("ModelUrl='~/LongProjectsDeclareManage.aspx'").Count() == 0)
                {
                    divMyLongDeclare.Style.Add("display", "none");
                }
                else
                {
                    aMyLongDeclare.InnerText = dt.Rows[0]["LongDeclareNum"].ToString();
                    zuo = zuo + 1;
                }
                //纵向项目立项
                if (dt3.Select("ModelUrl='~/LongProjectsStandManage.aspx'").Count() == 0)
                {
                    divMyLongStand.Style.Add("display", "none");
                }
                else
                {
                    aMyLongStand.InnerText = dt.Rows[0]["LongStandNum"].ToString();
                    zuo = zuo + 1;
                }
                // 纵向项目中检
                if (dt3.Select("ModelUrl='~/LongProjectsInspectManage.aspx'").Count() == 0)
                {
                    divMyLongInspect.Style.Add("display", "none");
                }
                else
                {
                    aMyLongInspect.InnerText = dt.Rows[0]["LongInspectNum"].ToString();
                    zuo = zuo + 1;
                }
                // 纵向项目结题
                if (dt3.Select("ModelUrl='~/LongProjectsEndManage.aspx'").Count() == 0)
                {
                    divMyLongEnd.Style.Add("display", "none");
                }
                else
                {
                    aMyLongEnd.InnerText = dt.Rows[0]["LongEndNum"].ToString();
                    zuo = zuo + 1;
                }
                // 横向项目立项
                if (dt3.Select("ModelUrl='~/ShortProjectsStandManage.aspx'").Count() == 0)
                {
                    divMyShortStand.Style.Add("display", "none");
                }
                else
                {
                    aMyShortStand.InnerText = dt.Rows[0]["ShortStandNum"].ToString();
                    zuo = zuo + 1;
                }
                //横向项目结题
                if (dt3.Select("ModelUrl='~/ShortProjectsEndManage.aspx'").Count() == 0)
                {
                    divMyShortEnd.Style.Add("display", "none");
                }
                else
                {
                    aMyShortEnd.InnerText = dt.Rows[0]["ShortEndNum"].ToString();
                    zuo = zuo + 1;
                }

                zuo = 0;
                //纵向经费预算
                if (dt3.Select("ModelUrl='~/LongCapitalPlanManage.aspx'").Count() == 0)
                {
                    divMyLongPlan.Style.Add("display", "none");
                }
                else
                {
                    aMyLongPlan.InnerText = dt.Rows[0]["LongPlanNum"].ToString();
                    zuo = zuo + 1;
                }
                //纵向经费预算变更
                if (dt3.Select("ModelUrl='~/LongCapitalChangeManage.aspx'").Count() == 0)
                {
                    divMyLongChange.Style.Add("display", "none");
                }
                else
                {
                    aMyLongChange.InnerText = dt.Rows[0]["LongChangeNum"].ToString();
                    zuo = zuo + 1;
                }
                //纵向经费结算
                if (dt3.Select("ModelUrl='~/LongCapitalCloseManage.aspx'").Count() == 0)
                {
                    divMyLongClose.Style.Add("display", "none");
                }
                else
                {
                    aMyLongClose.InnerText = dt.Rows[0]["LongCloseNum"].ToString();
                    zuo = zuo + 1;
                }
                //横向经费预算
                if (dt3.Select("ModelUrl='~/ShortCapitalPlanManage.aspx'").Count() == 0)
                {
                    divMyShortPlan.Style.Add("display", "none");
                }
                else
                {
                    aMyShortPlan.InnerText = dt.Rows[0]["ShortPlanNum"].ToString();
                    zuo = zuo + 1;
                }
                //横向经费预算变更
                if (dt3.Select("ModelUrl='~/ShortCapitalChangeManage.aspx'").Count() == 0)
                {
                    divMyShortChange.Style.Add("display", "none");
                }
                else
                {
                    aMyShortChange.InnerText = dt.Rows[0]["ShortChangeNum"].ToString();
                    zuo = zuo + 1;
                }
                //横向经费结算
                if (dt3.Select("ModelUrl='~/ShortCapitalCloseManage.aspx'").Count() == 0)
                {
                    divMyShortClose.Style.Add("display", "none");
                }
                else
                {
                    aMyShortClose.InnerText = dt.Rows[0]["ShortCloseNum"].ToString();
                    zuo = zuo + 1;
                }

                if (zuo == 0)
                {
                    baqic.Style.Add("display", "none");
                    baqib.Style.Add("display", "none");
                    baqia.Style.Add("display", "none");
                    baqid.Style.Add("display", "none");
                }
                zuo = 0;

                #endregion
                #region 需审批数量
                DataTable dt2 = bus.PaperExamineSelectUser("Right_SelectByRankUserCardId", UserCardId, RankId).Tables[0];
                int you = 0;

                //著作
                if (dt3.Select("ModelUrl='~/TeachingExamineManage.aspx'").Count() == 0)
                {
                    divTeachingExamine.Style.Add("display", "none");
                }
                else
                {
                    aTeachingExamine.InnerText = dt2.Rows[0]["TeachingNum"].ToString();
                    you = you + 1;
                }
                //获奖
                if (dt3.Select("ModelUrl='~/WinningExamineManage.aspx'").Count() == 0)
                {
                    divWinningExamine.Style.Add("display", "none");
                }
                else
                {
                    aWinningExamine.InnerText = dt2.Rows[0]["WinningNum"].ToString();
                    you = you + 1;
                }
                //专利
                if (dt3.Select("ModelUrl='~/PatentExamineManage.aspx'").Count() == 0)
                {
                    divPatentExamine.Style.Add("display", "none");
                }
                else
                {
                    aPatentExamine.InnerText = dt2.Rows[0]["PatentNum"].ToString();
                    you = you + 1;
                }
                //论文
                if (dt3.Select("ModelUrl='~/PaperExamineManage.aspx'").Count() == 0)
                {
                    divPaperExamine.Style.Add("display", "none");
                }
                else
                {
                    aPaperExamine.InnerText = dt2.Rows[0]["PaperNum"].ToString();
                    you = you + 1;
                }
                //指导学生
                if (dt3.Select("ModelUrl='~/GuidanceExamineManage.aspx'").Count() == 0)
                {
                    divGuidanceExamine.Style.Add("display", "none");
                }
                else
                {
                    aGuidanceExamine.InnerText = dt2.Rows[0]["GuidanceNum"].ToString();
                    you = you + 1;
                }
                //科研项目
                if (dt3.Select("ModelUrl='~/WorkLoadProjectsExamineManage.aspx'").Count() == 0)
                {
                    divWorkLoadProjectsExamine.Style.Add("display", "none");
                }
                else
                {
                    aWorkLoadProjectsExamine.InnerText = dt2.Rows[0]["WorkLoadProjectsNum"].ToString();
                    you = you + 1;
                }
                //科研成果
                if (dt3.Select("ModelUrl='~/HarvestExamineManage.aspx'").Count() == 0)
                {
                    divHarvestExamine.Style.Add("display", "none");
                }
                else
                {
                    aHarvestExamine.InnerText = dt2.Rows[0]["HarvestNum"].ToString();
                    you = you + 1;
                }


                //教材建设信息
                if (dt3.Select("ModelUrl='~/T_TeachingExamineManage.aspx'").Count() == 0)
                {
                    divT_TeachingExamine.Style.Add("display", "none");
                }
                else
                {
                    aT_TeachingExamine.InnerText = dt2.Rows[0]["T_TeachingNum"].ToString();
                    you = you + 1;
                }
                //教学团队建设信息
                if (dt3.Select("ModelUrl='~/Teaching_TeamExamineManage.aspx'").Count() == 0)
                {
                    divTeaching_TeamExamine.Style.Add("display", "none");
                }
                else
                {
                    aTeaching_TeamExamine.InnerText = dt2.Rows[0]["Teaching_TeamNum"].ToString();
                    you = you + 1;
                }
                //专业建设信息
                if (dt3.Select("ModelUrl='~/P_constructionExamineManage.aspx'").Count() == 0)
                {
                    divP_constructionExamine.Style.Add("display", "none");
                }
                else
                {
                    aP_constructionExamine.InnerText = dt2.Rows[0]["P_constructionNum"].ToString();
                    you = you + 1;
                }
                //课程建设信息
                if (dt3.Select("ModelUrl='~/C_constructionExamineManage.aspx'").Count() == 0)
                {
                    divC_constructionExamine.Style.Add("display", "none");
                }
                else
                {
                    aC_constructionExamine.InnerText = dt2.Rows[0]["C_constructionNum"].ToString();
                    you = you + 1;
                }
                //竞赛获奖信息
                if (dt3.Select("ModelUrl='~/C_winnersExamineManage.aspx'").Count() == 0)
                {
                    divC_winnersExamine.Style.Add("display", "none");
                }
                else
                {
                    aC_winnersExamine.InnerText = dt2.Rows[0]["C_winnersNum"].ToString();
                    you = you + 1;
                }
                //教学成果获奖信息
                if (dt3.Select("ModelUrl='~/ResultsExamineManage.aspx'").Count() == 0)
                {
                    divResultsExamine.Style.Add("display", "none");
                }
                else
                {
                    aResultsExamine.InnerText = dt2.Rows[0]["ResultsNum"].ToString();
                    you = you + 1;
                }
                //专项分值信息
                if (dt3.Select("ModelUrl='~/SpecialExamineManage.aspx'").Count() == 0)
                {
                    divSpecialExamine.Style.Add("display", "none");
                }
                else
                {
                    aSpecialExamine.InnerText = dt2.Rows[0]["SpecialNum"].ToString();
                    you = you + 1;
                }
                //教学工作量转化教研分信息
                if (dt3.Select("ModelUrl='~/TeachToTeachingExamineManage.aspx'").Count() == 0)
                {
                    divTeachToTeachingExamine.Style.Add("display", "none");
                }
                else
                {
                    aTeachToTeachingExamine.InnerText = dt2.Rows[0]["TeachToTeachingNum"].ToString();
                    you = you + 1;
                }

                //纵向项目申报
                if (dt3.Select("ModelUrl='~/LongProjectsDeclareExamineManage.aspx'").Count() == 0)
                {
                    divLongDeclareExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongDeclareExamine.InnerText = dt2.Rows[0]["LongDeclareNum"].ToString();
                    you = you + 1;
                }
                //纵向项目立项
                if (dt3.Select("ModelUrl='~/LongProjectsStandExamineManage.aspx'").Count() == 0)
                {
                    divLongStandExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongStandExamine.InnerText = dt2.Rows[0]["LongStandNum"].ToString();
                    you = you + 1;
                }
                //纵向项目中检
                if (dt3.Select("ModelUrl='~/LongProjectsInspectExamineManage.aspx'").Count() == 0)
                {
                    divLongInspectExamine.Style.Add("display", "none");
                }
                else
                {

                    aLongInspectExamine.InnerText = dt2.Rows[0]["LongInspectNum"].ToString();
                    you = you + 1;
                }
                //纵向项目结题
                if (dt3.Select("ModelUrl='~/LongProjectsEndExamineManage.aspx'").Count() == 0)
                {
                    divLongEndExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongEndExamine.InnerText = dt2.Rows[0]["LongEndNum"].ToString();
                    you = you + 1;
                }
                //横向项目立项
                if (dt3.Select("ModelUrl='~/ShortProjectsStandExamineManage.aspx'").Count() == 0)
                {
                    divShortStandExamine.Style.Add("display", "none");
                }
                else
                {
                    aShortStandExamine.InnerText = dt2.Rows[0]["ShortStandNum"].ToString();
                    you = you + 1;
                }
                //横向项目结题
                if (dt3.Select("ModelUrl='~/ShortProjectsEndExamineManage.aspx'").Count() == 0)
                {
                    divShortEndExamine.Style.Add("display", "none");
                }
                else
                {
                    aShortEndExamine.InnerText = dt2.Rows[0]["ShortEndNum"].ToString();
                    you = you + 1;
                }

                //纵向经费预算
                if (dt3.Select("ModelUrl='~/LongCapitalPlanExamineManage.aspx'").Count() == 0)
                {
                    divLongPlanExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongPlanExamine.InnerText = dt2.Rows[0]["LongPlanNum"].ToString();
                    you = you + 1;
                }
                //纵向经费变更
                if (dt3.Select("ModelUrl='~/LongCapitalChangeExamineManage.aspx'").Count() == 0)
                {
                    divLongChangeExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongChangeExamine.InnerText = dt2.Rows[0]["LongChangeNum"].ToString();
                    you = you + 1;
                }
                //纵向经费决算
                if (dt3.Select("ModelUrl='~/LongCapitalCloseExamineManage.aspx'").Count() == 0)
                {
                    divLongCloseExamine.Style.Add("display", "none");
                }
                else
                {
                    aLongCloseExamine.InnerText = dt2.Rows[0]["LongCloseNum"].ToString();
                    you = you + 1;
                }
                //横向经费预算
                if (dt3.Select("ModelUrl='~/ShortCapitalPlanExamineManage.aspx'").Count() == 0)
                {
                    divShortPlanExamine.Style.Add("display", "none");
                }
                else
                {
                    aShortPlanExamine.InnerText = dt2.Rows[0]["ShortPlanNum"].ToString();
                    you = you + 1;
                }
                //横向经费变更
                if (dt3.Select("ModelUrl='~/ShortCapitalChangeExamineManage.aspx'").Count() == 0)
                {
                    divShortChangeExamine.Style.Add("display", "none");
                }
                else
                {
                    aShortChangeExamine.InnerText = dt2.Rows[0]["ShortChangeNum"].ToString();
                    you = you + 1;
                }
                //横向经费决算
                if (dt3.Select("ModelUrl='~/ShortCapitalCloseExamineManage.aspx'").Count() == 0)
                {
                    divShortCloseExamine.Style.Add("display", "none");
                }
                else
                {
                    aShortCloseExamine.InnerText = dt2.Rows[0]["ShortCloseNum"].ToString();
                    you = you + 1;
                }

                if (you == 0)
                {
                    baqig.Style.Add("display", "none");
                    baqif.Style.Add("display", "none");
                    baqie.Style.Add("display", "none");
                    baqih.Style.Add("display", "none");
                }
                you = 0;
                #endregion
                #region 部门未通过量
                DataTable dt4 = bus.SelectByUserCardId("Right_SelectByUserCardIdAndTransferStatusNo", UserCardId).Tables[0];
                //著作
                zuo = 0;
                if (dt3.Select("ModelUrl='~/TeachingManage.aspx'").Count() == 0)
                {
                    divTeaching.Style.Add("display", "none");
                }
                else
                {
                    aTeaching.InnerText = dt4.Rows[0]["TeachingNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //获奖
                if (dt3.Select("ModelUrl='~/WinningManage.aspx'").Count() == 0)
                {
                    divWinning.Style.Add("display", "none");
                }
                else
                {

                    aWinning.InnerText = dt4.Rows[0]["WinningNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //专利
                if (dt3.Select("ModelUrl='~/PatentManage.aspx'").Count() == 0)
                {
                    divPatent.Style.Add("display", "none");
                }
                else
                {
                    aPatent.InnerText = dt4.Rows[0]["PatentNumNo"].ToString();
                    zuo = zuo + 1;
                }

                //论文
                if (dt3.Select("ModelUrl='~/PaperManage.aspx'").Count() == 0)
                {
                    divPaper.Style.Add("display", "none");
                }
                else
                {

                    aPaper.InnerText = dt4.Rows[0]["PaperNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //指导学生
                if (dt3.Select("ModelUrl='~/GuidanceManage.aspx'").Count() == 0)
                {
                    divGuidance.Style.Add("display", "none");
                }
                else
                {
                    aGuidance.InnerText = dt4.Rows[0]["GuidanceNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //科研项目
                if (dt3.Select("ModelUrl='~/WorkLoadProjectsManage.aspx'").Count() == 0)
                {
                    divWorkLoadProjects.Style.Add("display", "none");

                }
                else
                {
                    aWorkLoadProjects.InnerText = dt4.Rows[0]["WorkLoadProjectsNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //科研成果
                if (dt3.Select("ModelUrl='~/HarvestManage.aspx'").Count() == 0)
                {
                    divHarvest.Style.Add("display", "none");
                }
                else
                {
                    aHarvest.InnerText = dt4.Rows[0]["HarvestNumNo"].ToString();
                    zuo = zuo + 1;
                }

                if (zuo == 0)
                {
                    baqij.Style.Add("display", "none");
                }

                zuo = 0;
                //教材建设信息
                if (dt3.Select("ModelUrl='~/T_TeachingManage.aspx'").Count() == 0)
                {
                    divT_Teaching.Style.Add("display", "none");
                }
                else
                {
                    aT_Teaching.InnerText = dt4.Rows[0]["T_TeachingNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //教学团队建设信息
                if (dt3.Select("ModelUrl='~/Teaching_TeamManage.aspx'").Count() == 0)
                {
                    divTeaching_Team.Style.Add("display", "none");
                }
                else
                {
                    aTeaching_Team.InnerText = dt4.Rows[0]["Teaching_TeamNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //专业建设信息
                if (dt3.Select("ModelUrl='~/P_constructionManage.aspx'").Count() == 0)
                {
                    divP_construction.Style.Add("display", "none");
                }
                else
                {
                    aP_construction.InnerText = dt4.Rows[0]["P_constructionNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //课程建设信息
                if (dt3.Select("ModelUrl='~/C_constructionManage.aspx'").Count() == 0)
                {
                    divC_construction.Style.Add("display", "none");
                }
                else
                {
                    aC_construction.InnerText = dt4.Rows[0]["C_constructionNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //竞赛获奖信息
                if (dt3.Select("ModelUrl='~/C_winnersManage.aspx'").Count() == 0)
                {
                    divC_winners.Style.Add("display", "none");
                }
                else
                {

                    aC_winners.InnerText = dt4.Rows[0]["C_winnersNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //教学成果获奖信息
                if (dt3.Select("ModelUrl='~/ResultsManage.aspx'").Count() == 0)
                {
                    divResults.Style.Add("display", "none");
                }
                else
                {
                    aResults.InnerText = dt4.Rows[0]["ResultsNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //专项分值信息
                if (dt3.Select("ModelUrl='~/SpecialManage.aspx'").Count() == 0)
                {
                    divSpecial.Style.Add("display", "none");
                }
                else
                {
                    aSpecial.InnerText = dt4.Rows[0]["SpecialNumNo"].ToString();
                    zuo = zuo + 1;
                }
                //教学工作量转化教研分信息
                if (dt3.Select("ModelUrl='~/TeachToTeachingManage.aspx'").Count() == 0)
                {
                    divTeachToTeaching.Style.Add("display", "none");
                }
                else
                {
                    aTeachToTeaching.InnerText = dt4.Rows[0]["TeachToTeachingNumNo"].ToString();
                    zuo = zuo + 1;
                }
                if (zuo == 0)
                {
                    baqij.Style.Add("display", "none");
                    baqii.Style.Add("display", "none");
                }

                #endregion
            }
        }
    }
} 