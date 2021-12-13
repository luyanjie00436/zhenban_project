<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KJProjectStatusExamineDetailed.aspx.cs" Inherits="ningdeScientManage_Web.KJprojectExamineDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
         body{color:#000;font-size:12px;font-family:'Microsoft YaHei', Verdana; background:#dfdfdf;}

         html {
         overflow-x:auto;

         }
table{ margin:0px auto;}
td{ border:1px solid #333; text-align:center; font-size:12px; font-family:微软雅黑;}
.wghg{ width:100%; height:100%; border:0px; margin:0px; padding:0px;}
.fed1{ width:10px;}
.fed2{ width:50px;}
.biaoti{ text-align:center; font-size:16px; font-family:宋体;}
th{border:0px; font-size:10px;font-family:微软雅黑; font-weight:normal; }
caption{ font-size:30px; font-family:宋体; font-weight:bold;}
.zihao{ width:1000; font-size:12px; font-family:宋体;}
  .btn { width:60px; height:30px;   color:#000;     border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer; }

         .auto-style1 {
             height: 21px;
         }
         .select1     { border:1px; background:none; width:208px;  border-color:#fff; height:24px; line-height:24px; color:#333; margin-top:2px}

         </style>
</head>
<body>
    <form id="form1" runat="server">
         <div> 
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate> 

   <table width="100%" height="100%"  cellspacing="0">
<caption>福建宁德职业技术学院科技项目情况审批表</caption>
    <tr>
        <th colspan="9">
             
            <br />
            </th>
      </tr>
        <tr>
        <td width="120">项目编号</td>
        <td colspan="2">
            <asp:Label ID="LKJProjectId" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">项目名称</td>
        <td colspan="2">
            <asp:Label ID="LKJProjectName" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">主持人</td>
        <td colspan="2">
            <asp:Label ID="LUserName" CssClass="wghg" runat="server" ></asp:Label>
        </td>
    </tr>
        <tr>
        <td width="120">申报年份</td>
        <td colspan="2">
            <asp:Label ID="LApplyYear" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">项目批准时间</td>
        <td colspan="2">
            <asp:Label ID="LApprovalDate" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">批准总金额</td>
        <td colspan="2">
            <asp:Label ID="LFunding1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td width="120">去年底结转经费</td>
        <td colspan="2">
            <asp:Label ID="LFunding2" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">当年拨入经费</td>
        <td colspan="2">
            <asp:Label ID="LFunding3" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td colspan="3">&nbsp;</td>
    </tr>
    <tr>
         <td colspan="9">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="8">当年支出经费</td>
        <td rowspan="3">去年年底结余经费</td>
    </tr>
    <tr>
        <td rowspan="2">人员劳务费</td>
        <td rowspan="2">业务费</td>
        <td colspan="2">固定资产购置费</td>
        <td rowspan="2">上缴税金</td>
        <td rowspan="2">管理费</td>
        <td rowspan="2">其他支出</td>
        <td rowspan="2">合计</td>
    </tr>
    <tr>
        <td width="120">其中：仪器设备费</td>
        <td width="120">合计</td>
    </tr>
    <tr>
        <td width="120">
            <asp:Label ID="LFunding5" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding6" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding8" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding7" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding9" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding10" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding11" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding4" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LFunding12" CssClass="wghg" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
         <td colspan="9">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6">当年投入人员（人年）</td>
        <td colspan="3">参与项目的研究生数</td>
    </tr>
    <tr>
        <td width="120">高级职称(男女都算）</td>
        <td width="120">中级职称(男女都算）</td>
        <td width="120">初级职称(男女都算）</td>
        <td width="120">其他(男女都算）</td>
        <td width="120">其中：女</td>
        <td width="120">合计</td>
        <td width="120">博士生</td>
        <td width="120">硕士生</td>
        <td width="120">合计</td>
    </tr>
    <tr>
        <td width="120">
            <asp:Label ID="LPersonnel3" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LPersonnel4" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LPersonnel5" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LPersonnel6" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LPersonnel2" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LPersonnel1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LQuantity2" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LQuantity3" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LQuantity1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="9">&nbsp;</td>
    </tr>
    <tr>
        <td rowspan="4">&nbsp;</td>
        <td width="120">学科分类代码</td>
        <td width="120">学科分类</td>
        <td width="120">活动类型代码</td>
        <td width="120">活动类型</td>
        <td width="120">项目来源代码</td>
        <td width="120">项目来源</td>
        <td width="120">组织形式代码</td>
        <td width="120">组织形式</td>
    </tr>
    <tr>
        <td width="120">
            <asp:Label ID="LClass1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass2" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass3" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass4" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass5" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
                <asp:Label ID="LClass6" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass7" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass8" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td width="120">合作形式代码</td>
        <td width="120">合作形式</td>
           <td width="120">项目的社会经济目标1</td>
        <td width="120">项目的社会经济目标2</td>
         <td width="120">项目的社会经济目标3</td>
        <td width="120">服务的国民经济行业1</td>
        <td width="120">服务的国民经济行业2</td>
        <td width="120">服务的国民经济行业3</td>
        
    </tr>
    <tr>
        <td width="120">
            <asp:Label ID="LClass9" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LClass10" CssClass="wghg" runat="server" ></asp:Label>
        </td>
          <td width="120">
            <asp:Label ID="LAims1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LAims2" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LAims3" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120">
            <asp:Label ID="LServiceIndustry1" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td width="120"><asp:Label ID="LServiceIndustry2" CssClass="wghg" runat="server" ></asp:Label></td>
        <td width="120"><asp:Label ID="LServiceIndustry3" CssClass="wghg" runat="server" ></asp:Label></td>
    </tr>
   <%-- <tr>
        <td colspan="9">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" width="100">业务部门负责人（签章）：</td>
        <td colspan="3" width="100">复核人（签章）： </td>
        <td colspan="3" width="100">填表人（签章）：</td>
       
    </tr>
    <tr>
        <td colspan="3" height="200">
            <asp:Label ID="Label40" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="Label41" CssClass="wghg" runat="server" ></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="Label42" CssClass="wghg" runat="server" ></asp:Label>
        </td>
     
    </tr>--%>
        </table>
        <br />
        <asp:DataList ID="dataOfYear" runat="server" Width="100%" 
              style=" margin:0 auto" >
              <ItemTemplate>
                  <table style="width:100%; margin-top:5px; border:none;">
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
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <strong>审批意见：</strong>&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="select1" Height="80" MaxLength="400" Rows="5" TextMode="MultiLine" width="98%" ToolTip="审批人填写意见"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="3">
                        &nbsp;</td>
                    <td height="28" class="page_title_txt" >
                        <br />
                       <asp:Button ID="Button1" runat="server" Text="同 意" OnClick="Button1_Click" CssClass="btn" ToolTip="点击同意审批" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="拒 绝" OnClick="Button2_Click" CssClass="btn" ToolTip="点击拒绝审批" />
                  <br /><br />
                    </td>
                    <td width="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
                  </ContentTemplate>
            </asp:UpdatePanel>
        </div> 
    </form>
</body>
</html>

