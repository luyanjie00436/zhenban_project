<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T_UserWork.aspx.cs" Inherits="ScientManage_Web.T_UserWork" %>

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

    <style type="text/css">
        .auto-style1 {
            width: 38%;
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
                    <strong>&nbsp;&nbsp;&nbsp;修改教研工作量分值</strong>
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
                                <td align="right" class="auto-style1">
                                    <strong>用户工号：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtUserCardId" CssClass="input6" data-toggle="tooltip" data-placement="top" ToolTip="请输入用户工号" runat="server" Height="27px" Width="137px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>用户姓名：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input6" data-toggle="tooltip" data-placement="top" ToolTip="请输入用户姓名" Height="27px" Width="137px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>工作量分值：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtWorkValue" data-toggle="tooltip" data-placement="top" ToolTip="请输入工作量分值" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr class="tr10">
                                <td height="80" align="right" class="auto-style1">&nbsp;
                                </td>
                                <td width="70%" height="80" align="left" valign="middle">
                                    <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行修改" />
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
