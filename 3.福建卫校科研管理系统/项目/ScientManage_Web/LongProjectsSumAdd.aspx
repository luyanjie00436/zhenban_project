<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsSumAdd.aspx.cs" Inherits="ScientManage_Web.LongProjectsSumAdd" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div>
                <div class="aa">
                    <div class="parallelogram">
                        <div class="parallelogram2">项目申报</div>
                    </div>
                </div>
            </div>
            <div class="page_main01">
                <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr14">
                        <td style="padding: 0 0 9px 0; margin: 0; float: right; margin-right: 155px;">
                            <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"
                                class="btn1" />
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" style="width: 800px; margin: 0 auto; border: 0px; background-color: #d4d2d2;">
                    <tr>
                        <td colspan="8">申报人基本信息
                        </td>
                    </tr>
                    <tr>
                        <td align="right">工号：</td>
                        <td align="left">
                            <asp:Label ID="txtUserCardId" runat="server"></asp:Label>
                        </td>
                        <td align="right" colspan="2">姓名：</td>
                        <td align="left">
                            <asp:Label ID="txtUserName" runat="server"></asp:Label>
                        </td>
                       <%-- <td align="right">所在院（系）：</td>
                        <td align="left">
                            <asp:Label ID="txtDepartmentName" runat="server"></asp:Label>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">职称：</td>
                        <td align="left">
                            <asp:Label ID="txtUserJob" runat="server"></asp:Label>
                        </td>
                        <td align="right" colspan="2">职级：</td>
                        <td align="left">
                            <asp:Label ID="txtUserPost" runat="server"></asp:Label>
                        </td>
                        <td align="right" colspan="2">出生年月：</td>
                        <td align="left">
                            <asp:Label ID="txtBirthday" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">项目基本信息
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td  align="left" colspan="3">
                            <asp:TextBox ID="txtLongProjectsName" CssClass="input6" runat="server" Height="27px" Width="384px" data-toggle="tooltip" data-placement="top" ToolTip="输入项目名称"></asp:TextBox>
                        </td>
                 
                        <td  align="right">
                            <strong>所在院系：</strong></td>
                        <td  align="left" colspan="3">
                            <asp:DropDownList ID="DlDepartmentId" CssClass="select1" Height="30px" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="选择所在院系">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>是否校内项目：</strong>
                        </td>
                        <td width="30%" align="left" colspan="3">
                            <asp:DropDownList ID="DlIsSchool" CssClass="select1" Height="30px" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="选择项目级别">
                                <asp:ListItem>校内</asp:ListItem>
                                <asp:ListItem>校外</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <strong>项目年份：</strong>
                        </td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="DLApply" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择申请年份">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目级别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="3">
                            <asp:DropDownList ID="DLLevel" CssClass="select1" Height="30px" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="选择项目级别">
                            </asp:DropDownList>
                        </td>
                        <td width="20%" align="right">
                            <strong>项目类别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="3">
                            <asp:DropDownList ID="DLSubject" CssClass="select1" Height="30px" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="选择项目类别">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="30%" align="left" colspan="3">
                            <asp:DropDownList ID="DLFrom" Height="30px" CssClass="select1" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="选择项目来源">
                            </asp:DropDownList>
                        </td>
                        <td width="20%" align="right">
                            <strong>项目协作单位：</strong>
                        </td>
                        <td width="30%" align="left" colspan="3">
                            <asp:TextBox ID="txtCompany" CssClass="input6" Height="27px" Width="137px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="输入协作单位"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>申报状态：</strong></td>
                        <td colspan="3">
                            <asp:DropDownList ID="DLDeclare" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择申报状态">
                                <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                            </asp:DropDownList></td>

                        <td align="right">
                            <strong>立项状态：</strong></td>
                        <td colspan="3">
                            <asp:DropDownList ID="DLStand" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择立项状态">
                                <asp:ListItem Value="未立项">未立项</asp:ListItem>
                                <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>中检状态：</strong></td>
                            <td colspan="3">
                                <asp:DropDownList ID="DLInspect" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择中检状态">
                                    <asp:ListItem Value="未中检">未中检</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                <strong>结题状态：</strong></td>
                            <td colspan="3">
                                <asp:DropDownList ID="DLEnd" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择结题状态">
                                    <asp:ListItem Value="未结题">未结题</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr class="tr10">
                            <td width="20%" height="80" align="right" style="background: none;">&nbsp;  
                            </td>
                            <td height="80" align="left" valign="middle" colspan="7" style="background: none;">
                                <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />&nbsp;<asp:Button
                                    ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行保存" />
                            </td>
                        </tr>
                </table>
            </div>
            <div class="rightMain">
                <br />
            </div>
        </div>
    </form>
</body>
</html>
