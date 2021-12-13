<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectStatusDetailed.aspx.cs" Inherits="ningdeScientManage_Web.ProjectStatusDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style type="text/css">
         html {
         overflow-x:auto;

         }
                  body{color:#000;font-size:12px;font-family:'Microsoft YaHei', Verdana; background:#dfdfdf;}

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
</style>
</head>
<body>
    <form id="form1" runat="server">
            
    <table width="80%" height="100%"  cellspacing="0">
<caption>福建宁德职业技术学院项目情况记录表</caption>
    <tr>
        <th colspan="6">
            <br />
            </th>
      </tr>
  <tr>
    <td width="120" class="auto-style1" >项目名称</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LProjectStatusName" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">项目编号</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LProjectStatusId" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">项目来源</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LSource" CssClass="wghg" runat="server" ></asp:Label></td>
  </tr>
  <tr>
    
    <td width="120" class="auto-style1">项目负责人</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LUserName" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">所属院系</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LDepartment" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1" >工作量</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LPersonnel" CssClass="wghg" runat="server" ></asp:Label></td>

  </tr>
    <tr>
    <td width="120" class="auto-style1">学科分类</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LSubject" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">合作形式</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LCooperation" CssClass="wghg" runat="server" ></asp:Label></td>
  

  </tr>
   <tr>
    <td width="120" class="auto-style1" >批准经费</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LFunding1" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">去年年底转经费</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LFunding2" CssClass="wghg" runat="server" ></asp:Label></td>
    <td width="120" class="auto-style1">今年拨入经费</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LFunding3" CssClass="wghg" runat="server" ></asp:Label></td>
    
  </tr>
  <tr>
      <td width="120" class="auto-style1">今年支出经费</td>
      <td width="120" class="auto-style1">
          <asp:Label ID="LFunding4" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1" >研究类别</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LCategory" CssClass="wghg" runat="server" ></asp:Label></td>
   <td width="120" class="auto-style1">最终成果形式</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LResults" CssClass="wghg" runat="server" ></asp:Label></td>
  </tr>
        <tr>
              <td width="120" class="auto-style1">社会经济目标</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LAims1" CssClass="wghg" runat="server" ></asp:Label></td>
             <td width="120" class="auto-style1">
        <asp:Label ID="LAims2" CssClass="wghg" runat="server" ></asp:Label></td>
             <td width="120" class="auto-style1">
        <asp:Label ID="LAims3" CssClass="wghg" runat="server" ></asp:Label></td>
        </tr>
    <tr>
        
    <td width="120" class="auto-style1">服务的国民经济行业</td>
    <td width="120" class="auto-style1">
        <asp:Label ID="LServiceIndustry1" CssClass="wghg" runat="server" ></asp:Label></td>
  <td width="120" class="auto-style1">
        <asp:Label ID="LServiceIndustry2" CssClass="wghg" runat="server" ></asp:Label></td>
         <td width="120" class="auto-style1">
        <asp:Label ID="LServiceIndustry3" CssClass="wghg" runat="server" ></asp:Label></td>
         <td width="120" class="auto-style1">
        <asp:Label ID="LServiceIndustry4" CssClass="wghg" runat="server" ></asp:Label></td>
    </tr>
     <tr>
        <td width="120" class="auto-style1">立项时间</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LProjectDate" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">结题时间</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LResultsDate" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">项目状态</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LStatus" CssClass="wghg" runat="server" ></asp:Label></td>
      </tr>
    <tr>
        <td colspan="6">本年支出经费</td>
    </tr>
    <tr>
        <td width="120" class="auto-style1" >转拨给外单位</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LTransferUnit" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">备注：转拨方</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LTransferName" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">业务费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost1" CssClass="wghg" runat="server" ></asp:Label></tr>
    <tr>
        <td width="120" class="auto-style1">仪器设备费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost2" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">其中单价在一万以上的设备费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost3" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">图书资料费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost4" CssClass="wghg" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td width="120" class="auto-style1">管理费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost5" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">其他支出</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost6" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120" class="auto-style1">2015年结余经费</td>
        <td width="120" class="auto-style1">
            <asp:Label ID="LCost7" CssClass="wghg" runat="server" ></asp:Label></td>
    </tr> 
        </table>
        <br />
        <asp:DataList ID="dataOfYear" runat="server" Width="80%" 
              style=" margin:0 auto; " >
              <ItemTemplate>
                  <table style="width:100%; padding:25px; margin-top:2px;  border:none;">
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
    </form>
</body>
</html>
