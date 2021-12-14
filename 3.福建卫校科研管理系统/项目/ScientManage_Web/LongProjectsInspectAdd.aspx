<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsInspectAdd.aspx.cs" Inherits="ScientManage_Web.LongProjectsInspectAdd" %>

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
                        <div class="parallelogram2">项目中检</div>
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
                <table cellspacing="0" cellpadding="0" style="width: 800px; margin: 0 auto; border: 0px; background: #d4d2d2;">
                    <tr>
                        <td colspan="6">申报人基本信息
                        </td>
                    </tr>
                    <tr>
                        <td align="right">工号：</td>
                        <td align="left">
                            <asp:Label ID="txtUserCardId" runat="server"></asp:Label>
                        </td>
                        <td align="right">姓名：</td>
                        <td align="left">
                            <asp:Label ID="txtUserName" runat="server"></asp:Label>
                        </td>
                     <%--   <td align="right">所在院（系）：</td>
                        <td align="left">
                            <asp:Label ID="txtDepartmentName" runat="server"></asp:Label>

                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">职称：</td>
                        <td align="left">
                            <asp:Label ID="txtUserJob" runat="server"></asp:Label>
                        </td>
                        <td align="right">职级：</td>
                        <td align="left">
                            <asp:Label ID="txtUserPost" runat="server"></asp:Label>
                        </td>
                        <td align="right">出生年月：</td>
                        <td align="left">
                            <asp:Label ID="txtBirthday" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">项目基本信息
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:Label ID="LLongProjectsName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目级别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LLevel" runat="server"></asp:Label>
                        </td>
                        <td width="20%" align="right">
                            <strong>项目类别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LSubject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LFrom" runat="server"></asp:Label>
                        </td>
                        <td width="20%" align="right">
                            <strong>项目协作单位：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LCompany" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>模板：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:DropDownList ID="DlCategory" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="点击选择模板">
                                <asp:ListItem Value="0">请选择</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;        
                            <asp:LinkButton runat="server" ForeColor="Blue" ID="LinkButton1" Text="下载模板" OnClick="LinkButton1_Click" ToolTip="点击下载模板"></asp:LinkButton>
                        </td>
                        <td width="20%" align="right">
                            <asp:Label ID="LLongProjectsId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Lxiugai" runat="server" Visible="False" Text="是否修改附件：" Font-Bold="True"></asp:Label>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:RadioButtonList ID="RBL1" runat="server" RepeatDirection="Horizontal" ToolTip="点击选择是否修改附件">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>上传中检文件：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" CssClass="input6" runat="server" Width="203px" data-toggle="tooltip" data-placement="top" ToolTip="点击上传中检文件" />
                        </td>
                        <td>&nbsp;</td>
                        <td colspan="2">
                            <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击下载附件"></asp:LinkButton>

                            <asp:Label runat="server" ID="LFileUrl" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td width="20%" height="80" align="right" style="background: none;">&nbsp;  
                        </td>
                        <td height="80" align="left" valign="middle" colspan="5" style="background: none;">&nbsp;<asp:Button
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
