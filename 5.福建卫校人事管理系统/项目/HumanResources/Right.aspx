<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Right.aspx.cs" Inherits="HumanManage_Web.Right" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        a {
            text-decoration:none;
            font-family:微软雅黑;
           font-size:14px;
        }
        * {
            margin:0px;
            padding:0px;
        }
        .wrap { width:100%;
                height:400px;
               margin-top:10px;
              
        }
        .zuo {
            width:98%;
            height:auto;
           text-align:center;
           /* background:#d4d2d2;
            border:1px solid #d4d2d2;*/
            margin:0 auto;
            /*border-radius:10px;
             margin-left:10px;*/
             padding-bottom:30px;
        }
        .you {
            width: 98%;
            height:auto;
            text-align:center;
          /*  background: #d4d2d2;
             border:1px solid #d4d2d2;*/
             margin:0 auto;
            /*border-radius:10px;
            margin-right:10px;*/
            padding-bottom:30px;
        }
        .nav1 {
            width:100%;
            height:24px;
            background-image:url(/images/nav_small.png);
            background-size:cover;
            border-top:1px solid #2774c7;
            border-radius:5px;
        }
          .nav2 {
            width:100%;
            height:24px;
            background-image:url(/images/nav_small.png);
            background-size:cover;
            border-top:1px solid #2774c7;
            border-radius:5px;
        }
        .nav_text {
            margin-top:5px;
            text-align:center;
            font-family:华文中宋;
            font-weight:bold;
        }
      
        .wrapa {
            width:98%;
            height:25px;
            margin:0px auto;
            background-color:#bfbdbd;
            margin-top:10px;
        }
         .wrapb {
            width:98%;
            height:25px;
            margin:0px auto;
            text-align:center;
            font-family:微软雅黑;
           background-color:#d4d2d2;
           font-size:14px;
           border-top:1px solid #d4d2d2;
        }
          .wrapb:nth-child(odd) {
            background-color:#bfbdbd;

        }

        .wrapa_zuo {
            width:50%;
            height:25px;
            float:left;
            margin-left:4%;
            text-align:center;
            line-height:25px;
            border-right:1px solid #dddddd;
           
        }
          .wrapa_you {
            width:40%;
            height:25px;
            float:right;
            margin-left:4%;
            text-align:center;
            line-height:25px;
            
        }
        .zong {
            width:98%;
            background-color:#dfdfdf;
            height:auto;
            border:1px solid #dfdfdf;
            margin:0px auto;
            padding-bottom:10px;
             border-radius:13px;
           
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <%--   <div class="wrap">
      <div class="zuo" id="divzuo" runat="server">
         
          <div class="nav_text"><h4>个人进行中项目数量</h4></div>
           <div  class="zong">
               <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
                 <div id="divMyTransfer" runat="server" class="wrapb">
                   <div  class="wrapa_zuo">人员调配</div>
                    <div class="wrapa_you"><a id="aMyTransfer" runat="server" href="MyTransferManage.aspx"></a></div>
                  </div>
                  <div id="divMyQuit" runat="server" class="wrapb">
                   <div class="wrapa_zuo">离职退休</div>
                    <div class="wrapa_you"><a id="aMyQuit" runat="server" href="MyQuitManage.aspx"></a></div>
                  </div>
                  <div id="divMyDelayQuit" runat="server" class="wrapb">
                   <div class="wrapa_zuo">延迟退休</div>
                    <div class="wrapa_you"><a  id="aMyDelayQuit" runat="server" href="MyDelayQuitManage.aspx"></a></div>
                  </div>
               <div id="divMyReward" runat="server" class="wrapb">
                   <div class="wrapa_zuo">奖惩信息</div>
                    <div class="wrapa_you"><a  id="aMyReward" runat="server" href="MyRewardManage.aspx"></a></div>
                  </div>
               <div id="divMyLeave" runat="server" class="wrapb">
                   <div class="wrapa_zuo">请假信息</div>
                    <div class="wrapa_you"><a id="aMyLeave" runat="server" href="MyLeaveManage.aspx"></a></div>
                  </div>
               <div id="divMyReduction" runat="server" class="wrapb">
                   <div class="wrapa_zuo">减免工作量</div>
                    <div class="wrapa_you"><a id="aMyReduction" runat="server" href="MyReductionManage.aspx"></a></div>
                  </div>
               <div id="divMyTraning" runat="server" class="wrapb">
                   <div class="wrapa_zuo">进修培训</div>
                    <div class="wrapa_you"><a id="aMyTraning" runat="server" href="MyTraningManage.aspx"></a></div>
                  </div>
               <div id="divMyAbroad" runat="server" class="wrapb">
                   <div class="wrapa_zuo">出国信息</div>
                    <div class="wrapa_you"><a id="aMyAbroad" runat="server" href="MyAbroadManage.aspx"></a></div>
                  </div>
               <div id="divMyApplyTitleManagePersonal" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">职称考核</div>
                    <div class="wrapa_you"><a   id="aMyApplyTitleManagePersonal" runat="server" href="ApplyTitleManagePersonal.aspx"></a></div>
                  </div>
           </div>
    
          
      </div>
      <div class="you" id="divyou" runat="server">
         
           <div class="nav_text"><h4>需审批数量</h4></div>
           <div  class="zong">
               <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
                 <div id="divTransferExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">人员调配</div>
                    <div class="wrapa_you"><a id="aTransferExamine" runat="server" href="TransferExamineManage.aspx"></a></div>
                  </div>
                  <div id="divQuitExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">离职退休</div>
                    <div class="wrapa_you"><a id="aQuitExamine" runat="server" href="QuitExamineManage.aspx"></a></div>
                  </div>
                  <div id="divDelayQuitExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">延迟退休</div>
                    <div class="wrapa_you"><a id="aDelayQuitExamine" runat="server" href="DelayQuitExamineManage.aspx"></a></div>
                  </div>
               <div id="divRewardExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">奖惩信息</div>
                    <div class="wrapa_you"><a id="aRewardExamine" runat="server" href="RewardExamineManage.aspx"></a></div>
                  </div>
               <div id="divLeaveExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">请假信息</div>
                    <div class="wrapa_you"><a  id="aLeaveExamine" runat="server" href="LeaveExamineManage.aspx"></a></div>
                  </div>
               <div id="divReductionExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">减免工作量</div>
                    <div class="wrapa_you"><a  id="aReductionExamine" runat="server" href="ReductionExamineManage.aspx"></a></div>
                  </div>
               <div id="divTraningExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">进修培训</div>
                    <div class="wrapa_you"><a  id="aTraningExamine" runat="server" href="TraningExamineManage.aspx"></a></div>
                  </div>
               <div id="divAbroadExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">出国信息</div>
                    <div class="wrapa_you"><a  id="aAbroadExamine" runat="server" href="AbroadExamineManage.aspx"></a></div>
                  </div>
               <div id="divApplyTitleExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">职称考核</div>
                    <div class="wrapa_you"><a id="aApplyTitleExamine" runat="server" href="ApplyTitleExamineManage.aspx"></a></div>
                  </div>
                  </div>
              
           </div>
    
      </div>--%>

    </form>
</body>
</html>
