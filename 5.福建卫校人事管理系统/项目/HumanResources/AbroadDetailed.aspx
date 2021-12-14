<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbroadDetailed.aspx.cs" Inherits="HumanManage_Web.AbroadDetailed" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
<div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >出国留学申请表</div></div></div>
        <div class="page_main01">
             <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 9px 0 0 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <tr>
                            <td width="12%" align="right">
                                <strong>工号：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                            </td>
                          
                             <td width="12%" align="right">
                                <strong>姓名：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LUserName" runat="server" ></asp:Label> </td>
                          
                          <td width="12%" align="right">
                                <strong>性别：</strong>
                            </td>
                            <td width="12%" align="left">
                               <asp:Label ID="LGender" runat="server" ></asp:Label>
                                    </td>
                          <td width="12%" align="right">
                                <strong>民族：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LNation" runat="server" ></asp:Label>
                            </td>
                             </tr>
                        <tr>
                             <td width="12%" align="right">
                                <strong>出生日期：</strong>
                            </td>
                            <td width="12%" align="left">
                           <asp:Label ID="LBirthday" runat="server" ></asp:Label>   </td>
                             <td width="12%" align="right">
                                <strong>入校时间：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LStartWork" runat="server" ></asp:Label>
                                 </td>
                            </tr>                    
                        <tr>
                             
                            
                            
                                  
                           <td width="12%" align="right">
                                <strong>第一学位：</strong>
                            </td>
                            <td width="12%" align="left">
                               <asp:Label ID="LDegree" runat="server" ></asp:Label>
                            </td>
                             <td width="12%" align="right">
                                <strong>第一学历：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LEducation" runat="server" ></asp:Label>
                            </td>
                             <td width="12%" align="right">
                                <strong>政治面貌：</strong>
                            </td>

                            <td width="12%" align="left">
                            <asp:Label ID="LPolitical" runat="server" ></asp:Label> </td>
                            </tr>
                          <tr>
                           
                             
                              <td width="12%" align="right">
                                <strong>专业名称：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtProfessional" runat="server" CssClass="select1" Enabled="False" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入专业名称"></asp:TextBox>
                            </td>
                              <td width="12%" align="right">
                                <strong>研究方向：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtDirection" data-toggle="tooltip" data-placement="top"  ToolTip="请输入研究方向" runat="server" CssClass="select1" Enabled="False" MaxLength="18"></asp:TextBox>
                            </td>
                              
                               </tr> 
                          <tr>
                           
                              <td width="12%" align="right">
                                <strong>第一外语：</strong>
                            </td>

                                 <td width="12%" align="left">
                                <asp:TextBox ID="txtOneLanguage" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第一外语" runat="server" CssClass="select1" Enabled="False" MaxLength="18"></asp:TextBox>
                            </td>
                               <td width="12%" align="right">
                                <strong>第一外语水平：</strong>
                            </td>
                             <td width="12%" align="left">
                                <asp:TextBox ID="txtOneLanguageDegree" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第一外语水平" runat="server" CssClass="select1" Enabled="False" MaxLength="18"></asp:TextBox>
                            </td>
                              <td width="12%" align="right">
                                <strong>第二外语：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTwoLanguage" data-toggle="tooltip" data-placement="top"  ToolTip="第二外语" runat="server" CssClass="select1" Enabled="False" MaxLength="18"></asp:TextBox>
                            </td>
                              <td width="12%" align="right">
                                <strong>第二外语水平：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTwoLanguageDegree" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第二外语水平" runat="server" CssClass="select1" Enabled="False" MaxLength="18"></asp:TextBox>
                            </td>
                              
                               </tr>   
                          <tr>
                            <td width="12%" align="right">
                                <strong>出国（境）时间：</strong>
                            </td>
                            <td colspan="7">
                                
                                 <input  ID="txtCountryDate" style="overflow-y:auto" onfocus="WdatePicker()" runat="server" class="input1" width="40%"   data-toggle="tooltip" data-placement="top"  ToolTip="请在文本框内输入出国（境）时间"></input>
                            </td>
                        </tr>  
                          <tr>
                            <td width="12%" align="right">
                                <strong>国家地区：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox  ID="txtCountryName" style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1"  Rows="5"  data-toggle="tooltip" data-placement="top"  ToolTip="请在文本框内输入国家地区"></asp:TextBox>
                            </td>
                        </tr> 
                        <tr>
                            <td width="12%" align="right">
                                <strong>出国（境）项目名称：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="400" style="overflow-y:auto" data-toggle="tooltip" data-placement="top"  ToolTip="请输入主要著作" ReadOnly="true" ID="txtMainWord" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                         <tr>
                            <td width="12%" align="right">
                                <strong>预期取得成果：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="400" style="overflow-y:auto" ReadOnly="true" data-toggle="tooltip" data-placement="top"  ToolTip="请输入获得成果" ID="txtReward" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                         <tr>
                            <td width="12%" align="right">
                                <strong>出国计划：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="400" style="overflow-y:auto" ReadOnly="true" data-toggle="tooltip" data-placement="top"  ToolTip="请输入出国计划" ID="txtAbroadPlan" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>

