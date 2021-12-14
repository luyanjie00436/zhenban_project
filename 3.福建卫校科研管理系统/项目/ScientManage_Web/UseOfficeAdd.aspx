<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseOfficeAdd.aspx.cs" Inherits="ScientManage_Web.UseOfficeAdd" %>

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
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                    <strong>&nbsp;&nbsp;&nbsp;新增任职管理</strong>
                </div>
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
                                <td align="right" class="auto-style1">
                                    <strong>工号：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>部门：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:DropDownList ID="txtDepartment" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>职务：</strong>
                                </td>
                                <td width="70%" align="left">

                                    <asp:DropDownList ID="txtRole" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>职级：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtLevel" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请输入职级" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>开始时间：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtStartDate" data-toggle="tooltip" data-placement="top" ToolTip="请选择开始时间" onfocus="WdatePicker()" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>结束时间：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:TextBox ID="txtEndDate" onfocus="WdatePicker()" data-toggle="tooltip" data-placement="top" ToolTip="请选择结束时间" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>是否当前任职：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:RadioButtonList ID="txtCurrent" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="是">是</asp:ListItem>
                                        <asp:ListItem Value="否">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>是否代理：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <asp:RadioButtonList ID="txtAgent" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="是">是</asp:ListItem>
                                        <asp:ListItem Value="否">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr class="tr10">
                                <td height="80" align="right" style="background: none;" class="auto-style1">&nbsp;
                                </td>
                                <td width="70%" height="80" align="left" valign="middle" style="background: none;">
                                    <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top" ToolTip="点击添加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                        ID="Button2" runat="server" Text="重 置" data-toggle="tooltip" data-placement="top" ToolTip="点击重新输入" OnClick="Button2_Click" CssClass="btn" />
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
