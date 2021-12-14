using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class Right : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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
                //DataTable dt3 =  bus.SelectByRoleId("AuthorityView_Select", RankId).Tables[0];
                //DataTable dt1 = bus.SelectByUserCardId("Right_SelectByLeftUserCardId", UserCardId).Tables[0];
                //int zuodiv = 0;
                //int youdiv = 0;
                //#region 个人拥有记录
                ////人员调配
                //if (dt3.Select("ModelUrl='~/MyTransferManage.aspx'").Count() == 0)
                //{
                //    divMyTransfer.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyTransfer.InnerText = dt1.Rows[0]["TransferNum"].ToString();
                //    zuodiv += 1;
                //}
                ////离职退休
          
                //    if (dt3.Select("ModelUrl='~/MyQuitManage.aspx'").Count() == 0)
                //{
                //    divMyQuit.Style.Add("display", "none");
                //}
                //else
                //{
                //     aMyQuit.InnerText = dt1.Rows[0]["QuitNum"].ToString();
                //    zuodiv += 1;
                //}
                ////延迟退休
                //    if (dt3.Select("ModelUrl='~/MyDelayQuitManage.aspx'").Count() == 0)
                //{
                //    divMyDelayQuit.Style.Add("display", "none");
                //}
                //else
                //{

                //    aMyDelayQuit.InnerText = dt1.Rows[0]["DelayQuitNum"].ToString();
                //    zuodiv += 1;
                //}
                ////奖惩
                //    if (dt3.Select("ModelUrl='~/MyRewardManage.aspx'").Count() == 0)
                //{
                //    divMyReward.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyReward.InnerText = dt1.Rows[0]["RewardNum"].ToString();
                //    zuodiv += 1;
                //}
                ////请假
                //    if (dt3.Select("ModelUrl='~/MyLeaveManage.aspx'").Count() == 0)
                //{
                //    divMyLeave.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyLeave.InnerText = dt1.Rows[0]["LeaveNum"].ToString();
                //    zuodiv += 1;
                //}
                ////减免工作量
                //    if (dt3.Select("ModelUrl='~/MyReductionManage.aspx'").Count() == 0)
                //{
                //    divMyReduction.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyReduction.InnerText = dt1.Rows[0]["ReductionNum"].ToString();
                //    zuodiv += 1;
                //}
                ////进修培训
                //    if (dt3.Select("ModelUrl='~/MyTraningManage.aspx'").Count() == 0)
                //{
                //    divMyTraning.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyTraning.InnerText = dt1.Rows[0]["TraningNum"].ToString();
                //    zuodiv += 1;
                //}
                ////出国信息
                //    if (dt3.Select("ModelUrl='~/MyAbroadManage.aspx'").Count() == 0)
                //{
                //    divMyAbroad.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyAbroad.InnerText = dt1.Rows[0]["AbroadNum"].ToString();
                //    zuodiv += 1;
                //}
                ////职称考核
                //    if (dt3.Select("ModelUrl='~/ApplyTitleManagePersonal.aspx'").Count() == 0)
                //{
                //    divMyApplyTitleManagePersonal.Style.Add("display", "none");
                //}
                //else
                //{
                //    aMyApplyTitleManagePersonal.InnerText = dt1.Rows[0]["ApplyTitleNum"].ToString();
                //    zuodiv += 1;
                //}
                //if (zuodiv==0)
                //{
                //    divzuo.Style.Add("display", "none");
                //}
                //#endregion
                //#region 需审批数量
                //DataTable dt2 = bus.SelectByUserCardId("Right_SelectByRightUserCardId", UserCardId).Tables[0];
                ////人员调配
                //    if (dt3.Select("ModelUrl='~/TransferExamineManage.aspx'").Count() == 0)
                //{
                //    divTransferExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aTransferExamine.InnerText = dt2.Rows[0]["TransferNum"].ToString();
                //    youdiv += 1;
                //}
                ////离职退休
                //    if (dt3.Select("ModelUrl='~/QuitExamineManage.aspx'").Count() == 0)
                //{
                //    divQuitExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aQuitExamine.InnerText = dt2.Rows[0]["QuitNum"].ToString();
                //    youdiv += 1;
                //}
                ////延迟退休
                //    if (dt3.Select("ModelUrl='~/DelayQuitExamineManage.aspx'").Count() == 0)
                //{
                //    divDelayQuitExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aDelayQuitExamine.InnerText = dt2.Rows[0]["DelayQuitNum"].ToString();
                //    youdiv += 1;
                //}
                ////奖惩
                //    if (dt3.Select("ModelUrl='~/RewardExamineManage.aspx'").Count() == 0)
                //{
                //    divRewardExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aRewardExamine.InnerText = dt2.Rows[0]["RewardNum"].ToString();
                //    youdiv += 1;
                //}
                ////请假
                //    if (dt3.Select("ModelUrl='~/LeaveExamineManage.aspx'").Count() == 0)
                //{
                //    divLeaveExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aLeaveExamine.InnerText = dt2.Rows[0]["LeaveNum"].ToString();
                //    youdiv += 1;
                //}
                ////减免工作量
                //    if (dt3.Select("ModelUrl='~/ReductionExamineManage.aspx'").Count() == 0)
                //{
                //    divReductionExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aReductionExamine.InnerText = dt2.Rows[0]["ReductionNum"].ToString();
                //    youdiv += 1;
                //}
                ////进修培训
                //    if (dt3.Select("ModelUrl='~/TraningExamineManage.aspx'").Count() == 0)
                //{
                //    divTraningExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //    aTraningExamine.InnerText = dt2.Rows[0]["TraningNum"].ToString();
                //    youdiv += 1;
                //}
                ////出国信息
                //    if (dt3.Select("ModelUrl='~/AbroadExamineManage.aspx'").Count() == 0)
                //{
                //    divAbroadExamine.Style.Add("display", "none");
                //}
                //else
                //{

                //   aAbroadExamine.InnerText = dt2.Rows[0]["AbroadNum"].ToString();
                //    youdiv += 1;
                //}
                ////职称考核
                //    if (dt3.Select("ModelUrl='~/ApplyTitleExamineManage.aspx'").Count() == 0)
                //{
                //    divApplyTitleExamine.Style.Add("display", "none");
                //}
                //else
                //{
                //   aApplyTitleExamine.InnerText = dt2.Rows[0]["ApplyTitleNum"].ToString();
                //    youdiv += 1;
                //}
                //if (youdiv==0)
                //    if (dt3.Select("ModelUrl='~/MyQuitManage.aspx'").Count() == 0)
                //{
                //    divyou.Style.Add("display", "none");
                //}
                //#endregion
            }
        }
    }
}