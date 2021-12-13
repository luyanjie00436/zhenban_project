<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Right.aspx.cs" Inherits="ningdeScientManage_Web.Right" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
<link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <style type="text/css">

        .btn {
         width:72px; height:34px; line-height:34px; display:inline-block; text-align:center; color:#404040; background:url(images/btn001.gif) no-repeat; font-weight:bold; border:none; cursor:pointer;
        }
    </style>
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
              
              
        }
        .zuo {
            width:100%;
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
               border:1px solid #542e6a;
              border-radius:8px;
              padding:5px;
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
          
            text-align:center;
            font-family:华文中宋;
            font-weight:bold;
            font-size:18px;
        }
      
        .wrapa {
            width:99%;
            height:25px;
            margin:0px auto;
            background-color:#bfbdbd;
            
        }
         .wrapb {
            width:99%;
            height:25px;
            margin:0px auto;
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
          .float_left {
              width:63%;
              float:left;
             
                 border:1px solid #542e6a;
              border-radius:8px;
              padding:5px;
          }
              .float_right {
              width:35%;
              float:right;
              
             
          }
          .juzhong {
              float:left;
          }
          .xx {
                 border:1px solid #542e6a;
              border-radius:8px;
           padding:1px;
          }
    </style>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        
    <div class="page_main01">
        <div style="width:98%;margin:0px auto;" >
           
            <div class="float_left" style="border:none;">
              <div class="nav_text"><h4>通知</h4></div>
       
                      

                <div class="float_left" style="width:100%;" >
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"  CssClass="juzhong"  Width="100%" AllowPaging="True"
                      ShowHeaderWhenEmpty="true"     OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                           OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="30" >
                       <AlternatingRowStyle BackColor="#bfbdbd" />
                         <Columns>
                   
                            <asp:BoundField DataField="NoticeExplain" HeaderText="通知">
                                <HeaderStyle CssClass="gridview_HeaderStyle" Width="80%" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>                     

                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                         <asp:LinkButton ID="LinkButton8" CommandArgument='<%# Eval("FileUrl") %>' runat="server"
                                         OnCommand="LinkButton8_Command">附件下载</asp:LinkButton>    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        
                         <PagerStyle CssClass="str001" />
                        <PagerTemplate>
                            当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            页/共:
                            <%--//得到分页页面的总数--%>
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                            页
                            <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                            <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                            转到第
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                            <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                CommandName="Page" Text="GO" />
                        </PagerTemplate>
                    </asp:GridView>
              </div>
             </div>

              <div id="divzuo" runat="server" class="zuo">
      <div class="float_right">   
          <div class="nav_text"><h4>个人进行中项目数量</h4></div>
          <div id="divcg" runat="server" class="xx" >         
               <div class="nav_text"><h5>成果</h5></div>
<div  class="zong">
               <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
               <div id="divMyGuidance" runat="server" class="wrapb">
                   <div class="wrapa_zuo">教学质量工程</div>
                    <div class="wrapa_you"><a id="aMyGuidance" runat="server" href="MyGuidanceManage.aspx"></a></div>
                  </div>
                 <div id="divMyCompetition" runat="server" class="wrapb">
                   <div class="wrapa_zuo">技能竞赛</div>
                    <div class="wrapa_you"><a id="aMyCompetition" runat="server" href="MyCompetitionManage.aspx"></a></div>
                  </div>
                 <div id="divMyTeaching" runat="server" class="wrapb">
                   <div  class="wrapa_zuo">著作教材</div>
                    <div class="wrapa_you"><a id="aMyTeaching" runat="server" href="MyTeachingManage.aspx"></a></div>
                  </div>
                <div id="divMyPaper" runat="server" class="wrapb">
                   <div class="wrapa_zuo">论文</div>
                    <div class="wrapa_you"><a  id="aMyPaper" runat="server" href="MyPaperManage.aspx"></a></div>
                  </div>
               
               <div id="divMyWorkLoadProjects" runat="server" class="wrapb">
                   <div class="wrapa_zuo">科研项目</div>
                    <div class="wrapa_you"><a id="aMyWorkLoadProjects" runat="server" href="MyWorkLoadProjectsManage.aspx"></a></div>
                  </div>
                  <div id="divMyPatent" runat="server" class="wrapb">
                   <div class="wrapa_zuo">专利</div>
                    <div class="wrapa_you"><a  id="aMyPatent" runat="server" href="MyPatentManage.aspx"></a></div>
                  </div>
                <div id="divMyHarvest" runat="server" class="wrapb">
                   <div class="wrapa_zuo">科技成果</div>
                    <div class="wrapa_you"><a id="aMyHarvest" runat="server" href="MyHarvestManage.aspx"></a></div>
                  </div>
              <div id="divMyOtherResults" runat="server" class="wrapb">
                   <div class="wrapa_zuo">其他成果</div>
                    <div class="wrapa_you"><a id="aMyOtherResults" runat="server" href="MyOtherResultsManage.aspx"></a></div>
                  </div>
                <div id="divMyActivity" runat="server" class="wrapb">
                   <div class="wrapa_zuo">学术活动</div>
                    <div class="wrapa_you"><a id="aMyActivity" runat="server" href="MyActivityManage.aspx"></a></div>
                  </div>
          

                  <div id="divMyWinning" runat="server" class="wrapb">
                   <div class="wrapa_zuo">获奖</div>
                 
                    <div class="wrapa_you"><a id="aMyWinning" runat="server" href="MyWinningManage.aspx"></a></div>
                  </div>
               </div>
               </div>
            <br />
               <div id="divxuehui" runat="server" class="xx">  <div class="nav_text"><h5>学术活动</h5></div>
                   <div  class="zong">
                       <div id="divMyAssciation" runat="server" class="wrapb">
                   <div class="wrapa_zuo">团体学会</div>
                    <div class="wrapa_you"><a id="aMyAssciation" runat="server" href="MyAssciationManage.aspx"></a></div>
                  </div>
                <div id="divMyLcture" runat="server" class="wrapb">
                   <div class="wrapa_zuo">学术讲座</div>
                    <div class="wrapa_you"><a id="aMyLcture" runat="server" href="MyLctureManage.aspx"></a></div>
                  </div>
                       </div>
                    </div>
          <br />
               <div id="divxm" runat="server" class="xx">  
                   
                   <div class="nav_text"><h5>项目</h5></div>
                   <div  class="zong">
                    <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
               <div id="divMyLongDeclare" runat="server" class="wrapb">
                   <div class="wrapa_zuo">纵向项目申报</div>
                    <div class="wrapa_you"><a id="aMyLongDeclare" runat="server" href="LongProjectsDeclareManage.aspx"></a></div>
                  </div>
               <div id="divMyLongStand" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目立项</div>
                    <div class="wrapa_you"><a   id="aMyLongStand" runat="server" href="LongProjectsStandManage.aspx"></a></div>
                  </div>
                <div id="divMyLongInspect" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目中检</div>
                    <div class="wrapa_you"><a   id="aMyLongInspect" runat="server" href="LongProjectsInspectManage.aspx"></a></div>
                  </div>
                <div id="divMyLongEnd" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目结题</div>
                    <div class="wrapa_you"><a   id="aMyLongEnd" runat="server" href="LongProjectsEndManage.aspx"></a></div>
                  </div>
                <div id="divMyShortStand" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向项目立项</div>
                    <div class="wrapa_you"><a   id="aMyShortStand" runat="server" href="ShortProjectsStandManage.aspx"></a></div>
                  </div>
                <div id="divMyShortEnd" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向项目结题</div>
                    <div class="wrapa_you"><a   id="aMyShortEnd" runat="server" href="ShortProjectsEndManage.aspx"></a></div>
                  </div>
                       </div>
             </div>
          <br />
              <div id="divzj" runat="server" class="xx">  <div class="nav_text"><h5>经费</h5></div>
                 <div  class="zong">
                    <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
                 <div id="divMyLongPlan" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费预算</div>
                    <div class="wrapa_you"><a   id="aMyLongPlan" runat="server" href="LongCapitalPlanManage.aspx"></a></div>
                  </div>
                <div id="divMyLongChange" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费预算变更</div>
                    <div class="wrapa_you"><a   id="aMyLongChange" runat="server" href="LongCapitalChangeManage.aspx"></a></div>
                  </div>
                <div id="divMyLongClose" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费决算</div>
                    <div class="wrapa_you"><a   id="aMyLongClose" runat="server" href="LongCapitalCloseManage.aspx"></a></div>
                  </div>
               <div id="divMyShortPlan" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费预算</div>
                    <div class="wrapa_you"><a   id="aMyShortPlan" runat="server" href="ShortCapitalPlanManage.aspx"></a></div>
                  </div>
                <div id="divMyShortChange" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费预算变更</div>
                    <div class="wrapa_you"><a   id="aMyShortChange" runat="server" href="ShortCapitalChangeManage.aspx"></a></div>
                  </div>
                <div id="divMyShortClose" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费决算</div>
                    <div class="wrapa_you"><a   id="aMyShortClose" runat="server" href="ShortCapitalCloseManage.aspx"></a></div>
                  </div>
                     </div>
           </div>
          <br />
   
                   <div id="divyou" runat="server" class="you">
         
           <div class="nav_text"><h4>需审批数量</h4></div>
           <div  class="zong">
               <div class="wrapa">
                   <div class="wrapa_zuo">名称</div>
                    <div class="wrapa_you">数量</div>
                  </div>
                
               <div id="divApproval" runat="server" class="wrapb">
                   <div class="wrapa_zuo">科研成果</div>
                    <div class="wrapa_you"><a id="aApproval" runat="server" href="Approval.aspx"></a></div>
                  </div>
                <div id="divAssciationExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">团体学会</div>
                    <div class="wrapa_you"><a id="AAssciationExamine" runat="server" href="AssciationExamineManage.aspx"></a></div>
                  </div>
                <div id="divLctureExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">学术讲座</div>
                    <div class="wrapa_you"><a id="aLctureExamine" runat="server" href="LctureExmaineManage.aspx"></a></div>
                  </div>
               <div id="divLongDeclareExamine" runat="server" class="wrapb">
                   <div class="wrapa_zuo">纵向项目申报</div>
                    <div class="wrapa_you"><a id="aLongDeclareExamine" runat="server" href="LongProjectsDeclareExamineManage.aspx"></a></div>
                  </div>
               <div id="divLongStandExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目立项</div>
                    <div class="wrapa_you"><a   id="aLongStandExamine" runat="server" href="LongProjectsStandExamineManage.aspx"></a></div>
                  </div>
                <div id="divLongInspectExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目中检</div>
                    <div class="wrapa_you"><a   id="aLongInspectExamine" runat="server" href="LongProjectsInspectExamineManage.aspx"></a></div>
                  </div>
                <div id="divLongEndExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向项目结题</div>
                    <div class="wrapa_you"><a   id="aLongEndExamine" runat="server" href="LongProjectsEndExamineManage.aspx"></a></div>
                  </div>
                <div id="divShortStandExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向项目立项</div>
                    <div class="wrapa_you"><a   id="aShortStandExamine" runat="server" href="ShortProjectsStandExamineManage.aspx"></a></div>
                  </div>
                <div id="divShortEndExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向项目结题</div>
                    <div class="wrapa_you"><a   id="aShortEndExamine" runat="server" href="ShortProjectsEndExamineManage.aspx"></a></div>
                  </div>
                 <div id="divLongPlanExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费预算</div>
                    <div class="wrapa_you"><a   id="aLongPlanExamine" runat="server" href="LongCapitalPlanExamineManage.aspx"></a></div>
                  </div>
                <div id="divLongChangeExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费预算变更</div>
                    <div class="wrapa_you"><a   id="aLongChangeExamine" runat="server" href="LongCapitalChangeExamineManage.aspx"></a></div>
                  </div>
                <div id="divLongCloseExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">纵向经费决算</div>
                    <div class="wrapa_you"><a   id="aLongCloseExamine" runat="server" href="LongCapitalCloseExamineManage.aspx"></a></div>
                  </div>
               <div id="divShortPlanExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费预算</div>
                    <div class="wrapa_you"><a   id="aShortPlanExamine" runat="server" href="ShortCapitalPlanExamineManage.aspx"></a></div>
                  </div>
                <div id="divShortChangeExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费预算变更</div>
                    <div class="wrapa_you"><a   id="aShortChangeExamine" runat="server" href="ShortCapitalChangeExamineManage.aspx"></a></div>
                  </div>
                <div id="divShortCloseExamine" runat="server"  class="wrapb">
                   <div class="wrapa_zuo">横向经费决算</div>
                    <div class="wrapa_you"><a   id="aShortCloseExamine" runat="server" href="ShortCapitalCloseExamineManage.aspx"></a></div>
                  </div>
              
           </div>
    
      </div>
    </div> 
          
      </div>
        </div>
    </div>
         </form>
</body>
</html>

