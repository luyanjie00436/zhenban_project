<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEmail.aspx.cs" Inherits="ScientManage_Web.UserEmail" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style3 {
            width: 50%;
        }

        .auto-style4 {
            width: 50%;
        }
    </style>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div>
                <div class="swn">
                    <strong>&nbsp;&nbsp;&nbsp;其他邮箱设置</strong>
                </div>
                <br />
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
                                <td align="right" class="auto-style4">
                                    <strong>个人邮箱：</strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEmail" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请输入个人邮箱" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style4">
                                    <strong>家庭邮箱：</strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtHomeNumber" data-toggle="tooltip" data-placement="top" ToolTip="点请输入家庭邮箱" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style4">
                                    <strong>工作邮箱：</strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtWorkNumber" runat="server" CssClass="input6" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="请输入工作邮箱"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tr10">
                                <td height="80" align="center" valign="middle" colspan="2">
                                    <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" CssClass="btn" ToolTip="点击进行保存" />
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

