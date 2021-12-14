<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsTemplateAdd.aspx.cs" Inherits="ScientManage_Web.ProjectsTemplateAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目模板添加</title>
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
                    <strong>&nbsp;&nbsp;&nbsp;新增项目模板</strong>
                </div>
                <br />
            </div>
            <div class="page_main01">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>类别：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:DropDownList data-toggle="tooltip" data-placement="top" ToolTip="请选择类别" CssClass="select1" ID="DLCategory" Width="137px" runat="server">
                                <asp:ListItem Value="纵向项目申报">纵向项目申报</asp:ListItem>
                                <asp:ListItem Value="纵向项目中检">纵向项目中检</asp:ListItem>
                                <asp:ListItem Value="纵向项目结题">纵向项目结题</asp:ListItem>
                                <asp:ListItem Value="横向项目立项">横向项目立项</asp:ListItem>
                                <asp:ListItem Value="横向项目结题">横向项目结题</asp:ListItem>
                                <asp:ListItem Value="经费预算">经费预算</asp:ListItem>
                                <asp:ListItem Value="经费预算变更">经费预算变更</asp:ListItem>
                                <asp:ListItem Value="经费决算">经费决算</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtTemplateName" data-toggle="tooltip" data-placement="top" ToolTip="请输入名称" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>选择上传文件：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:FileUpload ID="fupFileSend" data-toggle="tooltip" data-placement="top" ToolTip="请上传文件" CssClass="input6" runat="server" Width="203px" />
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" style="background: none;" class="auto-style1">&nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" style="background: none;">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top" ToolTip="点击添加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击重置" CssClass="btn" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
