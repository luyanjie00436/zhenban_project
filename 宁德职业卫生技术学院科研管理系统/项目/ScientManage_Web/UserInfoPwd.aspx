﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoPwd.aspx.cs" Inherits="ningdeScientManage_Web.UserInfoPwd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style5 {
            width: 45%;
        }
        .auto-style6 {
            width: 43%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >用户密码重置</div></div></div><br />
    </div>
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style6">
                            <strong>工号：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtUserCardId" runat="server" Enabled="True" CssClass="input1"></asp:TextBox>
                            </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style6">
                            <strong>身份证号码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txUserIdCard" runat="server" Enabled="True" CssClass="input1" MaxLength="18"></asp:TextBox>
                            <strong style="color:red; font-size:20px;">*</strong>
                            </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style6">
                            <strong>新密码：</strong>
                        </td>
                        <td width="70%" align="left">
                           <asp:TextBox ID="txtNewPwd"  runat="server" Enabled="True" CssClass="input1"  TextMode="Password" MaxLength="18"></asp:TextBox>
                           </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style6">
                            <strong>确认密码：</strong>
                        </td>
                        <td width="70%" align="left">
                          <asp:TextBox ID="txtNewPwd2" runat="server" Enabled="True" CssClass="input1"  TextMode="Password" MaxLength="18"></asp:TextBox>
                           </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style6">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="重 置" OnClick="Button1_Click" CssClass="btn" />&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
