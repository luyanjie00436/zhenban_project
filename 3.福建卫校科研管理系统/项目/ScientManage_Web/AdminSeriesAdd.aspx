<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSeriesAdd.aspx.cs" Inherits="ScientManage_Web.AdminSeriesAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 48%;
        }

        .auto-style3 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div>
                <div class="swn">
                    <strong>&nbsp;&nbsp;&nbsp;新增行政系列</strong>
                </div>
            </div>
            <div class="page_main01">
                <div style="display: none">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right" class="auto-style3">
                                    <strong>行政系列名称：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtAdminSeriesName" runat="server" CssClass="input6" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入行政系列名称"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tr10">
                                <td height="80" align="right" style="background: none" class="auto-style3">&nbsp;
                                </td>
                                <td width="70%" height="80" align="left" valign="middle" style="background: none">
                                    <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />&nbsp;<asp:Button
                                        ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击重新输入" />
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
