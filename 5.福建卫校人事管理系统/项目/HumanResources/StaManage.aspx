<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaManage.aspx.cs" Inherits="HumanManage_Web.StaManage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>

    <style>
        * {
            margin:0px;
            padding:0px;
        }
       table {
            
         
            margin:0px auto;
            border-top:1px solid #000;
            border-left:1px solid #000; 
        }
            table td {              
                border-bottom:1px solid  #000;
                border-right:1px solid #000;                
            }
       
        </style>
</head>
<body>
   
  
 <form id="form1" runat="server">
     <div style="width:600px; margin:0px auto;  margin-top:10px; margin-bottom:10px;">
         <asp:Button ID="Button1" runat="server" Text="年度人员查询" OnClick="Button1_Click" />
         <asp:Button ID="Button2" runat="server" Text="人员学历及年龄查询" OnClick="Button2_Click" />
         <asp:Button ID="Button3" runat="server" Text="岗位等级查询" OnClick="Button3_Click" />
         <asp:Button ID="Button4" runat="server" Text="签订聘用合同查询" OnClick="Button4_Click" />
         <asp:Button ID="Button5" runat="server" Text="管理人员岗位等级查询" OnClick="Button5_Click" />
         <asp:Button ID="Button6" runat="server" Text="专业技术人员岗位等级查询" OnClick="Button6_Click" />
         <asp:Button ID="Button7" runat="server" Text="工勤技能人员岗位等级查询" OnClick="Button7_Click"/>
         <asp:Button ID="Button8" runat="server" Text="专业技术人员学历及年龄查询" OnClick="Button8_Click"/>
         <asp:Button ID="Button9" runat="server" Text="专业技术人员教师职称查询" OnClick="Button9_Click"/>
         <asp:Button ID="Button10" runat="server" Text="人员进修培训查询" OnClick="Button10_Click" />
     </div>
    <div id="biaoa" runat="server" >
       <table  width="696px"   border="0" cellpadding="0" cellspacing="0" >
           <tr>
               <td rowspan="2" width="200px"  align="center" >项&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目</td>
               <td rowspan="2" width="31px;" align="center" >上年末教职工总数</td>
               <td colspan="5">本年度增加</td>
               <td colspan="7">本年度减少</td>
               <td rowspan="2"  width="31px;" align="center" >本年末教职工实有数</td>
               <td rowspan="2" width="31px;" align="center" >实有数与应有数之差</td>
               <td rowspan="2"  width="31px;" align="center">本年末实有退休人员总数</td>             
           </tr>
           <tr>
               <td class="auto-style1"  width="31px;" align="center">应届高等学校毕业生</td>
               <td class="auto-style2"  width="31px;" align="center">应届中等专业学校毕业生</td>
               <td class="auto-style4"  width="31px;" align="center">军转干部安置</td>
               <td class="auto-style3"  width="31px;" align="center">调入</td>
               <td class="auto-style3" width="31px;" align="center">其他</td>
               <td class="auto-style1" width="31px;" align="center">退休</td>
               <td class="auto-style5" width="31px;" align="center">辞职</td>
               <td class="auto-style6" width="31px;" align="center">辞退</td>
               <td class="auto-style6" width="31px;" align="center">开除</td>
               <td class="auto-style5" width="31px;" align="center">解聘</td>
               <td class="auto-style7" width="31px;" align="center">调出</td>
               <td width="31px;" align="center">其他</td>
           </tr>
           <tr>
               <td rowspan="2" width="200px"  align="center" >总&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;计</td>
               <td>
                    <a id="A_a1" runat="server" href="StaDetailed.aspx?biao=a1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a2" runat="server" href="StaDetailed.aspx?biao=a2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
               <td>
                    <a id="A_a3" runat="server" href="StaDetailed.aspx?biao=a3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
               <td>
                    <a id="A_a4" runat="server" href="StaDetailed.aspx?biao=a4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a5" runat="server" href="StaDetailed.aspx?biao=a5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a6" runat="server" href="StaDetailed.aspx?biao=a6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a7" runat="server" href="StaDetailed.aspx?biao=a7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a8" runat="server" href="StaDetailed.aspx?biao=a8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a9" runat="server" href="StaDetailed.aspx?biao=a9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
               <td>
                    <a id="A_a10" runat="server" href="StaDetailed.aspx?biao=a10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a11" runat="server" href="StaDetailed.aspx?biao=a11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a12" runat="server" href="StaDetailed.aspx?biao=a12&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a13" runat="server" href="StaDetailed.aspx?biao=a13&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a14" runat="server" href="StaDetailed.aspx?biao=a14&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a15" runat="server" href="StaDetailed.aspx?biao=a15&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="A_a16" runat="server" href="StaDetailed.aspx?biao=a16&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
           </tr>
       </table>
   <br />
        <div style="width:900px; margin:0px auto; " >
               <asp:Chart ID="Charta1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="增加人员统计表">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
        <asp:Chart ID="Charta2" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
             <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="减少人员统计表">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
     </div>
       </div>
    <div id="biaob" runat="server" >
        <table width="727px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0">
            <tr>
               <td  width="200px;" align="center" rowspan="2" >项&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目</td>
               <td  width="31px;" align="center" colspan="6" >教职工</td>
               <td  width="31px;" align="center" colspan="5" >最高学历</td>
               <td  width="31px;" align="center" colspan="6" >年龄</td>
            </tr>
            <tr>
               <td  width="31px;" align="center">女</td>
               <td  width="31px;" align="center">少数民族</td>
               <td  width="31px;" align="center">中共党员</td>
               <td  width="31px;" align="center">博士</td>
               <td  width="31px;" align="center">硕士</td>
               <td  width="31px;" align="center">港澳台及外籍人士</td>
               <td  width="31px;" align="center">研究生</td>
               <td  width="31px;" align="center">大学本科</td>
               <td  width="31px;" align="center">大学专科</td>
               <td  width="31px;" align="center">中专</td>
               <td  width="31px;" align="center">高中及以下</td>
               <td  width="31px;" align="center">35岁及以下</td>
               <td  width="31px;" align="center">36岁至40岁</td>
               <td  width="31px;" align="center">41至45岁</td>
               <td  width="31px;" align="center">46岁至50岁</td>
               <td  width="31px;" align="center">51岁至54岁</td>
               <td  width="31px;" align="center">55岁及以上</td>
            </tr>
            <tr>
               <td  width="200px;" align="center" >总&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;计</td>
                <td>
                    <a id="B_b1" runat="server" href="StaDetailed.aspx?biao=b1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b2" runat="server" href="StaDetailed.aspx?biao=b2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b3" runat="server" href="StaDetailed.aspx?biao=b3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b4" runat="server" href="StaDetailed.aspx?biao=b4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b5" runat="server" href="StaDetailed.aspx?biao=b5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b6" runat="server" href="StaDetailed.aspx?biao=b6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b7" runat="server" href="StaDetailed.aspx?biao=b7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b8" runat="server" href="StaDetailed.aspx?biao=b8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b9" runat="server" href="StaDetailed.aspx?biao=b9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b10" runat="server" href="StaDetailed.aspx?biao=b10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b11" runat="server" href="StaDetailed.aspx?biao=b11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b12" runat="server" href="StaDetailed.aspx?biao=b12&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b13" runat="server" href="StaDetailed.aspx?biao=b13&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b14" runat="server" href="StaDetailed.aspx?biao=b14&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b15" runat="server" href="StaDetailed.aspx?biao=b15&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b16" runat="server" href="StaDetailed.aspx?biao=b16&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="B_b17" runat="server" href="StaDetailed.aspx?biao=b17&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
         <br /><div style="width:900px; margin:0px auto; " >
               <asp:Chart ID="Chartb1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9"  >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="最高学历统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
        <asp:Chart ID="Chartb2" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
             <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="年龄统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
             </div>
  </div>

    <div id="biaoc" runat="server" >
        <table width="696px"  style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td  align="center" colspan="7">岗位等级</td>
            </tr>
            <tr>
                <td  align="center" colspan="2">管理岗位</td>
                <td  align="center" colspan="3">专业技术岗位</td>
                <td  align="center" colspan="2">工勤技能岗位</td>
            </tr>
            <tr>
                <td  align="center" >编制数量</td>
                <td  align="center" >现有在岗人数</td>
                <td  align="center" >编制数量</td>
                <td  align="center" >现有在岗人数</td>
                <td  align="center" >在管理岗位的</td>
                <td  align="center" >编制数量</td>
                <td  align="center" >现有在岗人数</td>
            </tr>
            <tr>
                <td>
                    <a id="C_c1" runat="server" href="StaDetailed.aspx?biao=c5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c2" runat="server" href="StaDetailed.aspx?biao=c1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c3" runat="server" href="StaDetailed.aspx?biao=c6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c4" runat="server" href="StaDetailed.aspx?biao=c2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c5" runat="server" href="StaDetailed.aspx?biao=c3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c6" runat="server" href="StaDetailed.aspx?biao=c7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="C_c7" runat="server" href="StaDetailed.aspx?biao=c4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
        <br/><div style="width:900px; margin:0px auto; " >
               <asp:Chart ID="Chartc1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9"  >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="编制数量统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
             <asp:Chart ID="Chartc2" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
             <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="现有在岗人数统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
            </div>

 
    </div>
    
    <div id="biaod" runat="server" >
        <table width="696px"  style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td align="center" colspan="4">签订聘用合同</td>
            </tr>
            <tr>
                <td align="center" >上年末已签订聘用合同人数</td>
                <td align="center" >新签订聘用合同数</td>
                <td align="center" >未签订聘用合同人数</td>
                <td align="center" >本年末已签订聘用合同人数</td>
            </tr>
            <tr>
                 <td>
                    <a id="D_d1" runat="server" href="StaDetailed.aspx?biao=d1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="D_d2" runat="server" href="StaDetailed.aspx?biao=d2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="D_d3" runat="server" href="StaDetailed.aspx?biao=d3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="D_d4" runat="server" href="StaDetailed.aspx?biao=d4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
    </div>

    <div id="biaoe" runat="server" >
        <table width="620px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td align="center" colspan="13">管理人员</td>
            </tr>
            <tr>
                <td rowspan="2">小计</td>
                <td   align="center"  colspan="12">岗位等级</td>
            </tr>
            <tr>
                <td align="center">一级职员</td>
                <td align="center">二级职员</td>
                <td align="center">三级职员</td>
                <td align="center">四级职员</td>
                <td align="center">五级职员</td>
                <td align="center">六级职员</td>
                <td align="center">七级职员</td>
                <td align="center">八级职员</td>
                <td align="center">九级职员</td>
                <td align="center">十级职员</td>
                <td align="center">其他等级人员</td>
                <td align="center">其他从业人员</td>
            </tr>
            <tr>
                 <td>
                     <asp:Label id="E_xj" runat="server" Text="Label"></asp:Label>
                 </td>
                <td>
                    <a id="E_e1" runat="server" href="StaDetailed.aspx?biao=e1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e2" runat="server" href="StaDetailed.aspx?biao=e2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e3" runat="server" href="StaDetailed.aspx?biao=e3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e4" runat="server" href="StaDetailed.aspx?biao=e4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e5" runat="server" href="StaDetailed.aspx?biao=e5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e6" runat="server" href="StaDetailed.aspx?biao=e6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e7" runat="server" href="StaDetailed.aspx?biao=e7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e8" runat="server" href="StaDetailed.aspx?biao=e8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e9" runat="server" href="StaDetailed.aspx?biao=e9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e10" runat="server" href="StaDetailed.aspx?biao=e10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e11" runat="server" href="StaDetailed.aspx?biao=e11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="E_e12" runat="server" href="StaDetailed.aspx?biao=e12&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
           <div style="width:450px; margin:0px auto; " >
               <asp:Chart ID="Charte1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="管理人员统计表">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
   
     </div>
    </div>

    <div id="biaof" runat="server" >
        <table width="620px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td align="center" colspan="16">专业技术人员</td>
            </tr>
            <tr>
                <td rowspan="3">小计</td>
                <td   align="center"  colspan="15">岗位等级</td>
            </tr>
            <tr>
                
                <td   align="center"   colspan="7">高级</td>
                <td   align="center"   colspan="3">中级</td>
                <td   align="center"   colspan="3">初级</td>
                <td rowspan="2">其他等级人员</td>
                <td rowspan="2">其他从业人员</td>
       
            </tr>

            <tr>
             
                <td align="center">专技一级</td>
                <td align="center">专技二级</td>
                <td align="center">专技三级</td>
                <td align="center">专技四级</td>
                <td align="center">专技五级</td>
                <td align="center">专技六级</td>
                <td align="center">专技七级</td>
                <td align="center">专技八级</td>
                <td align="center">专技九级</td>
                <td align="center">专技十级</td>
                <td align="center">专技十一级</td>
                <td align="center">专技十二级</td>
                <td align="center">专技十三级</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="F_xj" runat="server" Text="Label"></asp:Label>
                </td>
               <td>
                    <a id="F_f1" runat="server" href="StaDetailed.aspx?biao=f1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f2" runat="server" href="StaDetailed.aspx?biao=f2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f3" runat="server" href="StaDetailed.aspx?biao=f3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f4" runat="server" href="StaDetailed.aspx?biao=f4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f5" runat="server" href="StaDetailed.aspx?biao=f5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f6" runat="server" href="StaDetailed.aspx?biao=f6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f7" runat="server" href="StaDetailed.aspx?biao=f7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f8" runat="server" href="StaDetailed.aspx?biao=f8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f9" runat="server" href="StaDetailed.aspx?biao=f9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f10" runat="server" href="StaDetailed.aspx?biao=f10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f11" runat="server" href="StaDetailed.aspx?biao=f11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f12" runat="server" href="StaDetailed.aspx?biao=f14&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f13" runat="server" href="StaDetailed.aspx?biao=f15&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f14" runat="server" href="StaDetailed.aspx?biao=f12&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="F_f15" runat="server" href="StaDetailed.aspx?biao=f13&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
              
            </tr>
        </table>
           <div style="width:430px; margin:0px auto; " >
               <asp:Chart ID="Chartf1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="专业技术人员统计表">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
      
     </div>
    </div>

    <div id="biaog" runat="server" >
        <table  width="727px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0">
          <tr>
              <td colspan="9" align="center" >工勤技能人员</td>
          </tr>
             <td rowspan="2"  align="center" >小计</td>
            <td colspan="8"  align="center" >岗位等级</td>
          <tr>
                <td align="center">一级（高级技师）</td>
                <td align="center">二级（技师）</td>
                <td align="center">三级（高级工）</td>
                <td align="center">四级（中级工）</td>
                <td align="center">五级（初级工）</td>
                <td align="center">普通工</td>
                <td align="center">其他等级人员</td>
                <td align="center">其他从业人员</td>
          </tr>
          <tr>
              <td>
                    <asp:Label id="G_xj" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <a id="G_g1" runat="server" href="StaDetailed.aspx?biao=g1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g2" runat="server" href="StaDetailed.aspx?biao=g2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g3" runat="server" href="StaDetailed.aspx?biao=g3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g4" runat="server" href="StaDetailed.aspx?biao=g4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g5" runat="server" href="StaDetailed.aspx?biao=g5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g6" runat="server" href="StaDetailed.aspx?biao=g6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g7" runat="server" href="StaDetailed.aspx?biao=g7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="G_g8" runat="server" href="StaDetailed.aspx?biao=g8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
            <div style="width:430px; margin:0px auto; " >
               <asp:Chart ID="Chartg1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="工勤技能人员统计表">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
      
     </div>
    </div>
    
    <div id="biaoh" runat="server" >
        <table  width="727px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" colspan="13">专业技术人员</td>
            </tr>
            <tr>
                <td align="center" colspan="5">学历</td>
                <td align="center" colspan="7">年龄</td>
                <td rowspan="2" >在管理岗位工作的</td>

            </tr>
            <tr>
                <td align="center" >研究生</td>
                <td align="center" >大学本科</td>
                <td align="center" >大学专科</td>
                <td align="center" >中专</td>
                <td align="center" >高中及以下</td>
                <td  align="center">35岁及以下</td>
                <td align="center" >36岁至40岁</td>
                <td align="center" >41岁至45岁</td>
                <td align="center" >46岁至50岁</td>
                <td align="center" >51岁至54岁</td>
                <td align="center" >55岁至59岁</td>
                <td align="center" >60岁及以上</td>
            </tr>
            <tr>
               <td>
                    <a id="H_h1" runat="server" href="StaDetailed.aspx?biao=h1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h2" runat="server" href="StaDetailed.aspx?biao=h2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h3" runat="server" href="StaDetailed.aspx?biao=h3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h4" runat="server" href="StaDetailed.aspx?biao=h4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h5" runat="server" href="StaDetailed.aspx?biao=h5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h6" runat="server" href="StaDetailed.aspx?biao=h6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h7" runat="server" href="StaDetailed.aspx?biao=h7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h8" runat="server" href="StaDetailed.aspx?biao=h8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h9" runat="server" href="StaDetailed.aspx?biao=h9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h10" runat="server" href="StaDetailed.aspx?biao=h10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h11" runat="server" href="StaDetailed.aspx?biao=h11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h12" runat="server" href="StaDetailed.aspx?biao=h12&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="H_h13" runat="server" href="StaDetailed.aspx?biao=h13&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
         <br/><div style="width:900px; margin:0px auto; " >
               <asp:Chart ID="Charth1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9"  >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="学历统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
             <asp:Chart ID="Charth2" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
             <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="年龄统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
            </div>
    </div>

    <div id="biaoi" runat="server" >
        <table  width="727px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" colspan="11">专业技术人员</td>
            </tr>
            <tr>
                <td align="center" colspan="5">教师职称</td>
                <td align="center" colspan="5">其他系列职称</td>
                <td rowspan="2" >具有职业资格的</td>

            </tr>
            <tr>
                <td align="center" >教授</td>
                <td align="center" >副教授</td>
                <td align="center" >讲师</td>
                <td align="center" >助教</td>
                <td align="center" >未定级</td>
                <td  align="center">正高</td>
                <td align="center" >副高</td>
                <td align="center" >中级</td>
                <td align="center" >初级</td>
                <td align="center" >未定级</td>
            </tr>
            <tr>
               <td>
                    <a id="I_i1" runat="server" href="StaDetailed.aspx?biao=i1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i2" runat="server" href="StaDetailed.aspx?biao=i2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i3" runat="server" href="StaDetailed.aspx?biao=i3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i4" runat="server" href="StaDetailed.aspx?biao=i4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i5" runat="server" href="StaDetailed.aspx?biao=i5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i6" runat="server" href="StaDetailed.aspx?biao=i6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i7" runat="server" href="StaDetailed.aspx?biao=i7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i8" runat="server" href="StaDetailed.aspx?biao=i8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i9" runat="server" href="StaDetailed.aspx?biao=i9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i10" runat="server" href="StaDetailed.aspx?biao=i10&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="I_i11" runat="server" href="StaDetailed.aspx?biao=i11&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>


            </tr>
        </table>
         <br/><div style="width:900px; margin:0px auto; " >
               <asp:Chart ID="Charti1" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9"  >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
                   <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="教师职称统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
             <asp:Chart ID="Charti2" runat="server" Width="400px" Height="400px"  BackColor="#E9E9E9" >
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Label="#VALX:#VAL"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
             <Titles>
                       <asp:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Title1" Text="其他系列职称统计图">
                       </asp:Title>
                   </Titles>
        </asp:Chart>
            </div>
    </div>

    <div id="biaoj" runat="server" >
        <table width="727px" style="margin-top:10px;"  border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" rowspan="2">参加培训人员合计</td>
                <td align="center" rowspan="2">出国出境培训</td>
                <td align="center" colspan="4">累计培训时间</td>
                <td align="center" colspan="3">培训人员类型</td>
            </tr>
            <tr>
                <td align="center"  >15天以内</td>
                <td align="center"  >15天至不满1个月</td>
                <td align="center"  >1个月至不满3个月</td>
                <td align="center"  >3个月及以上</td>
                <td align="center"  >管理人员</td>
                <td align="center"  >专业技术人员</td>
                <td align="center"  >工勤技能人员</td>
            </tr>
            <tr>
               <td>
                    <a id="J_j1" runat="server" href="StaDetailed.aspx?biao=j1&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j2" runat="server" href="StaDetailed.aspx?biao=j9&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j3" runat="server" href="StaDetailed.aspx?biao=j2&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j4" runat="server" href="StaDetailed.aspx?biao=j3&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j5" runat="server" href="StaDetailed.aspx?biao=j4&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j6" runat="server" href="StaDetailed.aspx?biao=j5&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j7" runat="server" href="StaDetailed.aspx?biao=j6&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j8" runat="server" href="StaDetailed.aspx?biao=j7&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
                <td>
                    <a id="J_j9" runat="server" href="StaDetailed.aspx?biao=j8&keepThis=true&TB_iframe=true&height=600&width=400"  class="fLink thickbox" data-toggle="tooltip" data-placement="top"  ></a>
               </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
