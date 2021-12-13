<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectStatusExamineDetailed.aspx.cs" Inherits="ningdeScientManage_Web.ProjectStatusExamineDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
      <style type="text/css">
         html {
         overflow-x:auto;

         }
table{ margin:0px auto;}
td{ border:1px solid #333; text-align:center; font-size:12px; height:30px; font-family:微软雅黑;}
.wghg{ width:100%; height:100%; border:0px; margin:0px; padding:0px;}
.fed1{ width:10px;}
.fed2{ width:50px;}
.biaoti{ text-align:center; font-size:16px; font-family:宋体;}
th{border:0px; font-size:10px;font-family:微软雅黑; font-weight:normal; }
caption{ font-size:30px; font-family:宋体; font-weight:bold;}
.zihao{ width:1000; font-size:12px; font-family:宋体;}

 Table
        {
         border-collapse: collapse;
         width:1024px;
         margin-top:-1px;
            }
        .td1
        {
            width:133px;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }

        .td2
        {
            width:133px;
            text-align:center;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }
        .td3
        {
            width:100%;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
            background-color:Gray;
        }
        .td4
        {
            width:100px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            line-height:24px;
            }
        .td5
        {
           width:80px;
            height:24px;
            line-height:24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            }
          .auto-style4 {
              width: 63px;
          }
      </style>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate> 
            <table>
                <table cellspacing="0" height="100%" width="80%">
                    <caption>
                        福建宁德职业技术学院项目情况审批表</caption>
                    <tr>
                        <th colspan="6">
                            <br />
                           </th>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">项目名称</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LProjectStatusName" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">项目编号</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LProjectStatusId" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">项目来源</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LSource" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">项目负责人</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LUserName" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">所属院系</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LDepartment" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">工作量</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LPersonnel" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">学科分类</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LSubject" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">合作形式</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCooperation" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">批准经费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LFunding1" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">去年年底转经费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LFunding2" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">今年拨入经费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LFunding3" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">今年支出经费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LFunding4" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                       <td class="auto-style1" width="120">研究类别</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCategory" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">最终成果形式</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LResults" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                         <td class="auto-style1" width="120">社会经济目标</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LAims1" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                          <td class="auto-style1" width="120">
                            <asp:Label ID="LAims2" runat="server" CssClass="wghg"></asp:Label>
                        </td> <td class="auto-style1" width="120">
                            <asp:Label ID="LAims3" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">服务的国民经济行业</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LServiceIndustry1" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    <td class="auto-style1" width="120">
                            <asp:Label ID="LServiceIndustry2" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LServiceIndustry3" runat="server" CssClass="wghg"></asp:Label>
                        </td><td class="auto-style1" width="120">
                            <asp:Label ID="LServiceIndustry4" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">立项时间</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LProjectDate" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">结题时间</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LResultsDate" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">项目状态</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LStatus" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">本年支出经费</td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">转拨给外单位</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LTransferUnit" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">备注：转拨方</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LTransferName" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">业务费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost1" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">仪器设备费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost2" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">其中单价在一万以上的设备费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost3" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">图书资料费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost4" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" width="120">管理费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost5" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">其他支出</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost6" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                        <td class="auto-style1" width="120">2015年结余经费</td>
                        <td class="auto-style1" width="120">
                            <asp:Label ID="LCost7" runat="server" CssClass="wghg"></asp:Label>
                        </td>
                    </tr>
                </table>
                <tr></tr>
                <tr>
                    <table width="80%" border="0" cellspacing="0" cellpadding="0">
                        
                         <asp:DataList ID="dataOfYear" runat="server" style=" margin:0 auto" >
              <ItemTemplate>
                  <table style="width:100%; margin-top:5px; border:none;text-align:left">
                      <tr>
                          <td  rowspan="2"  style=" border: 1px solid #000000;  height:auto ;width:40px;" >
                               <asp:Label ID="Label5" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                              <asp:Label ID="Label4" runat="server" Text='<%# Eval("RankName") %>'></asp:Label>审批
                          </td>
                           <td  colspan="3" style=" border: 1px solid #000000; vertical-align: top;" >
                          意见：  <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExamineOpinion") %>'></asp:Label>
                          </td>
                        </tr>
                      <tr>      
                          <td  style=" border: 1px solid #000000;">
                           审批人：   <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                          </td>
                          <td style=" border: 1px solid #000000;">
                            审批日期：  <asp:Label ID="Label3" runat="server" Text='<%# Eval("ExamineDate") %>'></asp:Label>
                          </td>
                          <td  style=" border: 1px solid #000000;">
                             审批结果; <asp:Label ID="Label6" runat="server" Text='<%# Eval("ExamineResult") %>'></asp:Label>
                          </td>
                      </tr>
                  </table>
              </ItemTemplate>
              <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
          </asp:DataList>

                    </table>
                </tr>
                <tr>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td widht="10px;" class="auto-style4">
                        <strong>审批意见：</strong>&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="select1" Height="100" MaxLength="400" Rows="5" TextMode="MultiLine" width="98%" ToolTip="审批人填写意见"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" >
                        &nbsp;</td>
                    <td height="28"  >
                        <br />
                        <div class="page_title_txt">
                       <asp:Button ID="Button1" runat="server" Text="同意 " OnClick="Button1_Click" CssClass="btn" ToolTip="点击同意审批" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="拒 绝" OnClick="Button2_Click" CssClass="btn" ToolTip="点击拒绝审批" />
                  </div>
                        <br />
                    </td>
                    <td width="3">
                        &nbsp;
                    </td>
                </tr>
                         
            </table>
                </tr>
            </table> 
 </ContentTemplate>
            </asp:UpdatePanel>
        </div>   
         
       
                  
    

        
         
             
                        
               
           
    </form>
</body>
</html>

