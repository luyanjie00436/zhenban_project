<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbroadAdd.aspx.cs" Inherits="HumanManage_Web.AbroadAdd" %>

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
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >出国信息申请</div></div></div>

    <div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%" align="right">
                                <strong>工号：</strong>
                            </td>
                            <td width="12%" align="left">
                              <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请输入工号"></asp:TextBox>
                            </td>
                          
                             <td width="12%" align="right">
                                <strong>姓名：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入姓名"></asp:TextBox> 
                                   <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                                </td>
                              <td align="right" class="auto-style1">
                                选择人员:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </td>
                          <td width="12%" align="right">
                                <strong>性别：</strong>
                            </td>
                            <td width="12%" align="left">
                               <asp:Label ID="LGender" runat="server" ></asp:Label>
                                    </td>
                        
                            </tr>
                        <tr>
                              <td width="12%" align="right">
                                <strong>民族：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LNation" runat="server" ></asp:Label>
                            </td>
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
                                <asp:TextBox ID="txtProfessional" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="必填项请输入专业名称"></asp:TextBox><span style="color:red;">*</span>
                            </td>
                              <td width="12%" align="right">
                                <strong>研究方向：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtDirection" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入研究方向"></asp:TextBox>
                            </td>
                              
                               </tr> 
                          <tr>
                           
                              <td width="12%" align="right">
                                <strong>第一外语：</strong>
                            </td>

                                 <td width="12%" align="left">
                                <asp:TextBox ID="txtOneLanguage" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第一外语"></asp:TextBox>
                            </td>
                               <td width="12%" align="right">
                                <strong>第一外语水平：</strong>
                            </td>
                             <td width="12%" align="left">
                                <asp:TextBox ID="txtOneLanguageDegree" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第一外语水平"></asp:TextBox>
                            </td>
                              <td width="12%" align="right">
                                <strong>第二外语：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTwoLanguage" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第二外语"></asp:TextBox>
                            </td>
                              <td width="12%" align="right">
                                <strong>第二外语水平：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTwoLanguageDegree" runat="server" CssClass="select1" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入第二外语水平"></asp:TextBox>
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
                                 <asp:TextBox Height="400" ID="txtMainWord" style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine" data-toggle="tooltip" data-placement="top"  ToolTip="请在文本框内输入出国（境）项目名称"></asp:TextBox>
                            </td>
                        </tr> 
                        
                         <tr>
                            <td width="12%" align="right">
                                <strong>预期取得成果：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="400" ID="txtReward" style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine" data-toggle="tooltip" data-placement="top"  ToolTip="请输入获得预期取得成果"></asp:TextBox>
                          
                            </td>
                        </tr>  
                         <tr>
                            <td width="12%" align="right">
                                <strong>出国计划：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="400" style="overflow-y:auto" ID="txtAbroadPlan" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine" data-toggle="tooltip" data-placement="top"  ToolTip="请输入出国计划内容"></asp:TextBox>
                          
                            </td>
                        </tr>  
                                  
                        <tr class="tr10">
                            <td width="12%" align="right">
                            </td>
                            <td colspan="3" align="right" >
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" Text="添 加" CssClass="btn" />
                            </td>
                               <td colspan="3" align="left" >
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行保存" Text="保 存" CssClass="btn" />
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

