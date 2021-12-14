<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DelayQuitDetailed.aspx.cs" Inherits="HumanManage_Web.DelayQuitDetailed" %>

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
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >延迟退休申请表</div></div></div>
        <div class="page_main01">
             <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
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
                                <strong>延迟退休理由：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="120"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入延迟退休的理由" ID="txtDelayQuitReason" runat="server" CssClass="select1" width="98%" 
style="overflow-y:auto" ReadOnly="true" Enabled="False" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine" ></asp:TextBox>
                          
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


