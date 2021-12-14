<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoPwd.aspx.cs" Inherits="ScientManage_Web.UserInfoPwd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        table {
            margin: 0px auto;
        }
        .auto-style2 {
            width: 47%;
        }
        .auto-style3 {
            width: 44%;
        }
    </style>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div>
                <div class="aa">
                    <div class="parallelogram">
                        <div class="parallelogram2">用户密码重置</div>
                    </div>
                </div>
            </div>
            <div class="page_main01">
                <div style="display: none">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right" class="auto-style3">
                                    <strong>工号：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtUserCardId" runat="server" Enabled="True" CssClass="input1" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入工号"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style3">
                                    <strong>身份证号码：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txUserIdCard" runat="server" Enabled="True" CssClass="input1" Height="27px" Width="137px" MaxLength="18" data-toggle="tooltip" data-placement="top" ToolTip="输入18位中国公民身份证号码"></asp:TextBox>
                                    <span style="color: red;">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style3">
                                    <strong>新密码：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtNewPwd" runat="server" Enabled="True" CssClass="input1" Height="27px" Width="137px" TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top" ToolTip="输入新密码"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style3">
                                    <strong>确认密码：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtNewPwd2" runat="server" Enabled="True" CssClass="input1" Height="27px" Width="137px" TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top" ToolTip="输入确认密码"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tr10">
                                <td height="80" align="right" class="auto-style3">&nbsp;
                                </td>
                                <td width="70%" height="80" align="left" valign="middle">
                                    <asp:Button ID="Button1" runat="server" Text="重 置" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击重置进行修改" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="rightMain">
                <br />
            </div>
        </div>
    </form>
</body>
</html>
