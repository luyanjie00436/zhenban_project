<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Right.aspx.cs" Inherits="ScientManage_Web.Right" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });
     
    </script>
    <style type="text/css">
        a {
            text-decoration: none;
            font-family: 微软雅黑;
            font-size: 14px;
        }

        * {
            margin: 0px;
            padding: 0px;
        }

        .wrap {
            width: 98%;
            margin-top: 10px;
            background-color: #bfbdbd;
            margin: 0px auto;
        }

        .zuo {
            width: 100%;
            height: auto;
            text-align: center;
            /* background:#d4d2d2;
            border:1px solid #d4d2d2;*/
            /*border-radius:10px;
             margin-left:10px;*/
            padding-bottom: 30px;
        }

        .you {
            width: 100%;
            height: auto;
            text-align: center;
            /*  background: #d4d2d2;
             border:1px solid #d4d2d2;*/
            /*border-radius:10px;
            margin-right:10px;*/
            padding-bottom: 30px;
            float: right;
        }

        .nav1 {
            width: 100%;
            height: 24px;
            background-image: url(/images/nav_small.png);
            background-size: cover;
            border-top: 1px solid #2774c7;
            border-radius: 5px;
        }

        .nav2 {
            width: 100%;
            height: 24px;
            background-image: url(/images/nav_small.png);
            background-size: cover;
            border-top: 1px solid #2774c7;
            border-radius: 5px;
        }

        .nav_text {
            width: 100%;
            margin-top: 5px;
            text-align: center;
            font-family: 华文中宋;
            font-weight: bold;
        }

        .wrapa {
            width: 99%;
            height: 25px;
            margin: 0px auto;
            background-color: #bfbdbd;
            margin-top: 10px;
        }

        .wrapb {
            width: 99%;
            height: 25px;
            margin: 0px auto;
            font-family: 微软雅黑;
            background-color: #d4d2d2;
            font-size: 14px;
            border-top: 1px solid #d4d2d2;
        }

            .wrapb:nth-child(odd) {
                background-color: #bfbdbd;
            }

        .wrapa_zuo {
            width: 50%;
            height: 25px;
            float: left;
            margin-left: 4%;
            text-align: center;
            line-height: 25px;
            border-right: 1px solid #dddddd;
        }

        .wrapa_you {
            width: 40%;
            height: 25px;
            float: right;
            margin-left: 4%;
            text-align: center;
            line-height: 25px;
        }

        .zong {
            width: 98%;
            background-color: #dfdfdf;
            height: auto;
            border: 1px solid #dfdfdf;
            margin: 0px auto;
            padding-bottom: 10px;
            border-radius: 13px;
        }

        .a {
            width: 22%;
            margin-top: 10px;
            border: 1px solid #834ea2;
            border-radius: 15px;
            padding-bottom: 10px;
            float: left;
            height: 260px;
            margin-left: 10px;
            padding: 10px;
        }
    </style>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main" class="wrap">
            <div id="divzuo" runat="server">
                <div id="baqib" runat="server" class="a">
                    <div class="nav_text">
                        <h4>个人教学工作量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divMyT_Teaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教材建设信息</div>
                        <div class="wrapa_you"><a id="aMyT_Teaching" runat="server" href="MyT_TeachingManage.aspx"></a></div>
                    </div>
                    <div id="divMyTeaching_Team" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学团队建设信息</div>
                        <div class="wrapa_you"><a id="aMyTeaching_Team" runat="server" href="MyTeaching_TeamManage.aspx"></a></div>
                    </div>
                    <div id="divMyP_construction" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专业建设信息</div>
                        <div class="wrapa_you"><a id="aMyP_construction" runat="server" href="MyP_constructionManage.aspx"></a></div>
                    </div>
                    <div id="divMyC_construction" runat="server" class="wrapb">
                        <div class="wrapa_zuo">课程建设信息</div>
                        <div class="wrapa_you"><a id="aMyC_construction" runat="server" href="MyC_constructionManage.aspx"></a></div>
                    </div>
                    <div id="divMyC_winners" runat="server" class="wrapb">
                        <div class="wrapa_zuo">竞赛获奖信息</div>
                        <div class="wrapa_you"><a id="aMyC_winners" runat="server" href="MyC_winnersManage.aspx"></a></div>
                    </div>
                    <div id="divMyResults" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学成果获奖信息</div>
                        <div class="wrapa_you"><a id="aMyResults" runat="server" href="MyResultsManage.aspx"></a></div>
                    </div>
                     <div id="divMySpecial" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专项分值信息</div>
                        <div class="wrapa_you"><a id="aMySpecial" runat="server" href="MySpecialManage.aspx"></a></div>
                    </div>
                     <div id="divMyTeachToTeaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学工作量转化信息</div>
                        <div class="wrapa_you"><a id="aMyTeachToTeaching" runat="server" href="MyTeachToTeachingManage.aspx"></a></div>
                    </div>
                </div>

                <div id="baqid" runat="server" class="a">
                    <div class="nav_text">
                        <h4>个人科研工作量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>

                    <div id="divMyTeaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">著作</div>
                        <div class="wrapa_you"><a id="aMyTeaching" runat="server" href="MyTeachingManage.aspx"></a></div>
                    </div>
                    <div id="divMyWinning" runat="server" class="wrapb">
                        <div class="wrapa_zuo">获奖</div>
                        <div class="wrapa_you"><a id="aMyWinning" runat="server" href="MyWinningManage.aspx"></a></div>
                    </div>
                    <div id="divMyPatent" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专利</div>
                        <div class="wrapa_you"><a id="aMyPatent" runat="server" href="MyPatentManage.aspx"></a></div>
                    </div>
                    <div id="divMyPaper" runat="server" class="wrapb">
                        <div class="wrapa_zuo">论文</div>
                        <div class="wrapa_you"><a id="aMyPaper" runat="server" href="MyPaperManage.aspx"></a></div>
                    </div>
                    <div id="divMyGuidance" runat="server" class="wrapb">
                        <div class="wrapa_zuo">指导学生</div>
                        <div class="wrapa_you"><a id="aMyGuidance" runat="server" href="MyGuidanceManage.aspx"></a></div>
                    </div>
                    <div id="divMyWorkLoadProjects" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研项目</div>
                        <div class="wrapa_you"><a id="aMyWorkLoadProjects" runat="server" href="MyWorkLoadProjectsManage.aspx"></a></div>
                    </div>
                    <div id="divMyHarvest" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研成果</div>
                        <div class="wrapa_you"><a id="aMyHarvest" runat="server" href="MyHarvestManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqia" runat="server" class="a">
                    <div class="nav_text">
                        <h4>个人资金</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divMyLongPlan" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费预算</div>
                        <div class="wrapa_you"><a id="aMyLongPlan" runat="server" href="LongCapitalPlanManage.aspx"></a></div>
                    </div>
                    <div id="divMyLongChange" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费预算变更</div>
                        <div class="wrapa_you"><a id="aMyLongChange" runat="server" href="LongCapitalChangeManage.aspx"></a></div>
                    </div>
                    <div id="divMyLongClose" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费决算</div>
                        <div class="wrapa_you"><a id="aMyLongClose" runat="server" href="LongCapitalCloseManage.aspx"></a></div>
                    </div>
                    <div id="divMyShortPlan" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费预算</div>
                        <div class="wrapa_you"><a id="aMyShortPlan" runat="server" href="ShortCapitalPlanManage.aspx"></a></div>
                    </div>
                    <div id="divMyShortChange" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费预算变更</div>
                        <div class="wrapa_you"><a id="aMyShortChange" runat="server" href="ShortCapitalChangeManage.aspx"></a></div>
                    </div>
                    <div id="divMyShortClose" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费决算</div>
                        <div class="wrapa_you"><a id="aMyShortClose" runat="server" href="ShortCapitalCloseManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqic" runat="server" class="a">
                    <div class="nav_text">
                        <h4>个人项目</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divMyLongDeclare" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目申报</div>
                        <div class="wrapa_you"><a id="aMyLongDeclare" runat="server" href="LongProjectsDeclareManage.aspx"></a></div>
                    </div>
                    <div id="divMyLongStand" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目立项</div>
                        <div class="wrapa_you"><a id="aMyLongStand" runat="server" href="LongProjectsStandManage.aspx"></a></div>
                    </div>
                    <div id="divMyLongInspect" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目中检</div>
                        <div class="wrapa_you"><a id="aMyLongInspect" runat="server" href="LongProjectsInspectManage.aspx"></a></div>
                    </div>
                    <div id="divMyLongEnd" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目结题</div>
                        <div class="wrapa_you"><a id="aMyLongEnd" runat="server" href="LongProjectsEndManage.aspx"></a></div>
                    </div>
                    <div id="divMyShortStand" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向项目立项</div>
                        <div class="wrapa_you"><a id="aMyShortStand" runat="server" href="ShortProjectsStandManage.aspx"></a></div>
                    </div>
                    <div id="divMyShortEnd" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向项目结题</div>
                        <div class="wrapa_you"><a id="aMyShortEnd" runat="server" href="ShortProjectsEndManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqie" runat="server" class="a">
                    <div class="nav_text">
                        <h4>需审批科研工作量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divTeachingExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">著作</div>
                        <div class="wrapa_you"><a id="aTeachingExamine" runat="server" href="TeachingExamineManage.aspx"></a></div>
                    </div>
                    <div id="divWinningExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">获奖</div>
                        <div class="wrapa_you"><a id="aWinningExamine" runat="server" href="WinningExamineManage.aspx"></a></div>
                    </div>
                    <div id="divPatentExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专利</div>
                        <div class="wrapa_you"><a id="aPatentExamine" runat="server" href="PatentExamineManage.aspx"></a></div>
                    </div>
                    <div id="divPaperExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">论文</div>
                        <div class="wrapa_you"><a id="aPaperExamine" runat="server" href="PaperExamineManage.aspx"></a></div>
                    </div>
                    <div id="divGuidanceExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">指导学生</div>
                        <div class="wrapa_you"><a id="aGuidanceExamine" runat="server" href="GuidanceExamineManage.aspx"></a></div>
                    </div>
                    <div id="divWorkLoadProjectsExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研项目</div>
                        <div class="wrapa_you"><a id="aWorkLoadProjectsExamine" runat="server" href="WorkLoadProjectsExamineManage.aspx"></a></div>
                    </div>
                    <div id="divHarvestExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研成果</div>
                        <div class="wrapa_you"><a id="aHarvestExamine" runat="server" href="HarvestExamineManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqif" runat="server" class="a">
                    <div class="nav_text">
                        <h4>需审批教学工作量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divT_TeachingExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教材建设信息</div>
                        <div class="wrapa_you"><a id="aT_TeachingExamine" runat="server" href="T_TeachingExamineManage.aspx"></a></div>
                    </div>
                    <div id="divTeaching_TeamExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学团队建设信息</div>
                        <div class="wrapa_you"><a id="aTeaching_TeamExamine" runat="server" href="Teaching_TeamExamineManage.aspx"></a></div>
                    </div>
                    <div id="divP_constructionExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专业建设信息</div>
                        <div class="wrapa_you"><a id="aP_constructionExamine" runat="server" href="P_constructionExamineManage.aspx"></a></div>
                    </div>
                    <div id="divC_constructionExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">课程建设信息</div>
                        <div class="wrapa_you"><a id="aC_constructionExamine" runat="server" href="C_constructionExamineManage.aspx"></a></div>
                    </div>
                    <div id="divC_winnersExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">竞赛获奖信息</div>
                        <div class="wrapa_you"><a id="aC_winnersExamine" runat="server" href="C_winnersExamineManage.aspx"></a></div>
                    </div>
                    <div id="divResultsExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学成果获奖信息</div>
                        <div class="wrapa_you"><a id="aResultsExamine" runat="server" href="ResultsExamineManage.aspx"></a></div>
                    </div>
                     <div id="divSpecialExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专项分值信息</div>
                        <div class="wrapa_you"><a id="aSpecialExamine" runat="server" href="SpecialExamineManage.aspx"></a></div>
                    </div>
                     <div id="divTeachToTeachingExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学工作量转化信息</div>
                        <div class="wrapa_you"><a id="aTeachToTeachingExamine" runat="server" href="TeachToTeachingExamineManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqig" runat="server" class="a">
                    <div class="nav_text">
                        <h4>需审批项目</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divLongDeclareExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目申报</div>
                        <div class="wrapa_you"><a id="aLongDeclareExamine" runat="server" href="LongProjectsDeclareExamineManage.aspx"></a></div>
                    </div>
                    <div id="divLongStandExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目立项</div>
                        <div class="wrapa_you"><a id="aLongStandExamine" runat="server" href="LongProjectsStandExamineManage.aspx"></a></div>
                    </div>
                    <div id="divLongInspectExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目中检</div>
                        <div class="wrapa_you"><a id="aLongInspectExamine" runat="server" href="LongProjectsInspectExamineManage.aspx"></a></div>
                    </div>
                    <div id="divLongEndExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向项目结题</div>
                        <div class="wrapa_you"><a id="aLongEndExamine" runat="server" href="LongProjectsEndExamineManage.aspx"></a></div>
                    </div>
                    <div id="divShortStandExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向项目立项</div>
                        <div class="wrapa_you"><a id="aShortStandExamine" runat="server" href="ShortProjectsStandExamineManage.aspx"></a></div>
                    </div>
                    <div id="divShortEndExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向项目结题</div>
                        <div class="wrapa_you"><a id="aShortEndExamine" runat="server" href="ShortProjectsEndExamineManage.aspx"></a></div>
                    </div>
                </div>
                <div id="baqih" runat="server" class="a">
                    <div class="nav_text">
                        <h4>需审批资金</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">数量</div>
                    </div>
                    <div id="divLongPlanExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费预算</div>
                        <div class="wrapa_you"><a id="aLongPlanExamine" runat="server" href="LongCapitalPlanExamineManage.aspx"></a></div>
                    </div>
                    <div id="divLongChangeExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费预算变更</div>
                        <div class="wrapa_you"><a id="aLongChangeExamine" runat="server" href="LongCapitalChangeExamineManage.aspx"></a></div>
                    </div>
                    <div id="divLongCloseExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">纵向经费决算</div>
                        <div class="wrapa_you"><a id="aLongCloseExamine" runat="server" href="LongCapitalCloseExamineManage.aspx"></a></div>
                    </div>
                    <div id="divShortPlanExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费预算</div>
                        <div class="wrapa_you"><a id="aShortPlanExamine" runat="server" href="ShortCapitalPlanExamineManage.aspx"></a></div>
                    </div>
                    <div id="divShortChangeExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费预算变更</div>
                        <div class="wrapa_you"><a id="aShortChangeExamine" runat="server" href="ShortCapitalChangeExamineManage.aspx"></a></div>
                    </div>
                    <div id="divShortCloseExamine" runat="server" class="wrapb">
                        <div class="wrapa_zuo">横向经费决算</div>
                        <div class="wrapa_you"><a id="aShortCloseExamine" runat="server" href="ShortCapitalCloseExamineManage.aspx"></a></div>
                    </div>
                </div>
           <div id="baqii" runat="server" class="a">
                    <div class="nav_text">
                        <h4>部门教学未通过量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">未通过数量</div>
                    </div>
                    <div id="divT_Teaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教材建设信息</div>
                        <div class="wrapa_you"><a id="aT_Teaching" runat="server" href="T_TeachingManage.aspx"></a></div>
                    </div>
                    <div id="divTeaching_Team" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学团队建设信息</div>
                        <div class="wrapa_you"><a id="aTeaching_Team" runat="server" href="Teaching_TeamManage.aspx"></a></div>
                    </div>
                    <div id="divP_construction" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专业建设信息</div>
                        <div class="wrapa_you"><a id="aP_construction" runat="server" href="P_constructionManage.aspx"></a></div>
                    </div>
                    <div id="divC_construction" runat="server" class="wrapb">
                        <div class="wrapa_zuo">课程建设信息</div>
                        <div class="wrapa_you"><a id="aC_construction" runat="server" href="C_constructionManage.aspx"></a></div>
                    </div>
                    <div id="divC_winners" runat="server" class="wrapb">
                        <div class="wrapa_zuo">竞赛获奖信息</div>
                        <div class="wrapa_you"><a id="aC_winners" runat="server" href="C_winnersManage.aspx"></a></div>
                    </div>
                    <div id="divResults" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学成果获奖信息</div>
                        <div class="wrapa_you"><a id="aResults" runat="server" href="ResultsManage.aspx"></a></div>
                    </div>
                     <div id="divSpecial" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专项分值信息</div>
                        <div class="wrapa_you"><a id="aSpecial" runat="server" href="SpecialManage.aspx"></a></div>
                    </div>
                     <div id="divTeachToTeaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">教学工作量转化信息</div>
                        <div class="wrapa_you"><a id="aTeachToTeaching" runat="server" href="TeachToTeachingManage.aspx"></a></div>
                    </div>
                </div>

                <div id="baqij" runat="server" class="a">
                    <div class="nav_text">
                        <h4>部门科研未通过量</h4>
                    </div>
                    <div class="wrapb">
                        <div class="wrapa_zuo">名称</div>
                        <div class="wrapa_you">未通过数量</div>
                    </div>

                    <div id="divTeaching" runat="server" class="wrapb">
                        <div class="wrapa_zuo">著作</div>
                        <div class="wrapa_you"><a id="aTeaching" runat="server" href="TeachingManage.aspx"></a></div>
                    </div>
                    <div id="divWinning" runat="server" class="wrapb">
                        <div class="wrapa_zuo">获奖</div>
                        <div class="wrapa_you"><a id="aWinning" runat="server" href="WinningManage.aspx"></a></div>
                    </div>
                    <div id="divPatent" runat="server" class="wrapb">
                        <div class="wrapa_zuo">专利</div>
                        <div class="wrapa_you"><a id="aPatent" runat="server" href="PatentManage.aspx"></a></div>
                    </div>
                    <div id="divPaper" runat="server" class="wrapb">
                        <div class="wrapa_zuo">论文</div>
                        <div class="wrapa_you"><a id="aPaper" runat="server" href="PaperManage.aspx"></a></div>
                    </div>
                    <div id="divGuidance" runat="server" class="wrapb">
                        <div class="wrapa_zuo">指导学生</div>
                        <div class="wrapa_you"><a id="aGuidance" runat="server" href="GuidanceManage.aspx"></a></div>
                    </div>
                    <div id="divWorkLoadProjects" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研项目</div>
                        <div class="wrapa_you"><a id="aWorkLoadProjects" runat="server" href="WorkLoadProjectsManage.aspx"></a></div>
                    </div>
                    <div id="divHarvest" runat="server" class="wrapb">
                        <div class="wrapa_zuo">科研成果</div>
                        <div class="wrapa_you"><a id="aHarvest" runat="server" href="HarvestManage.aspx"></a></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
