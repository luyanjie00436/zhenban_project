<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P_constructionAdd.aspx.cs" Inherits="ScientManage_Web.P_constructionAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <script src="js/yanzheng.js" type="text/javascript"></script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
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
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">专业建设添加</div>
                </div>
            </div>
            <div class="page_main01">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%" align="right">
                            <strong>年份:</strong>
                        </td>
                        <td width="12%" align="left">
                            <asp:TextBox ID="txtApplyYear" runat="server" CssClass="input1" ReadOnly="True" data-toggle="tooltip" data-placement="top" ToolTip="年份日期 例如(2015-11-02)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>填报日期:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtFollDate" runat="server" CssClass="input1" ReadOnly="True" data-toggle="tooltip" data-placement="top" ToolTip="填报日期 例如(2015-11-02)"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td width="12%" align="right">
                            <strong>所在院系:</strong>
                        </td>
                        <td width="12%" align="left">
                            <asp:DropDownList ID="DlDepartmentId" runat="server" CssClass="input1" ReadOnly="True" data-toggle="tooltip" data-placement="top" ToolTip="选择所在院系"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>项目名称:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtP_constructionName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入项目的名称"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>级别:</strong> </td>
                        <td align="left" width="12%">
                            <asp:DropDownList ID="DlLeve" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入项目的级别">
                                <asp:ListItem>请选择项目级别</asp:ListItem>
                                <asp:ListItem>国家级</asp:ListItem>
                                <asp:ListItem>省级</asp:ListItem>
                                <asp:ListItem>行指委或出版社</asp:ListItem>
                                <asp:ListItem>院级</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>负责人:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtPrincipal" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入负责人"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>完成情况:</strong> </td>
                        <td align="left" width="12%">
                            <asp:DropDownList ID="DlCompletion" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入完成情况">
                                <asp:ListItem>请选择完成情况</asp:ListItem>
                                <asp:ListItem>申报未立项</asp:ListItem>
                                <asp:ListItem>申报并立项</asp:ListItem>
                                <asp:ListItem>立项</asp:ListItem>
                                <asp:ListItem>验收合格</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>项目迄止时间:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtStartEndDate" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入项目的迄止时间 例如：（2016-01-01至2016-12-31）"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>项目总分值:</strong> </td>
                        <td align="left" width="12%">
                            <input id="txtTotal_Project" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="请输入项目总分值"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%" class="auto-style2"><strong>项目总分值说明:</strong> </td>
                        <td align="left" width="12%" class="auto-style2">
                            <asp:TextBox ID="txtDescription_Project" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入项目总分值说明"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>本年度项目总分值:</strong> </td>
                        <td align="left" width="12%">
                            <input id="txtAnnual" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="本年度项目总分值"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%" class="auto-style2"><strong>本年度项目总分值说明:</strong> </td>
                        <td align="left" width="12%" class="auto-style2">
                            <asp:TextBox ID="txtDescription_year" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入本年度项目总分值说明"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>本年度个人工作量分值:</strong> </td>
                        <td align="left" width="12%">
                            <input id="txtP_constructionValue" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="本年度个人工作量分值"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%" class="auto-style1"><strong>备注:</strong> </td>
                        <td align="left" width="12%" class="auto-style1">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入备注，充当说明使用"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" align="right">
                            <strong>选择上传文件：</strong>
                        </td>
                        <td width="12%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" runat="server" CssClass="input6" Width="203px" data-toggle="tooltip" data-placement="top" ToolTip="点击选择要上传的文件" />
                            <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击下载附件"></asp:LinkButton>
                            <asp:Label runat="server" ID="LFileUrl" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" align="right">
                            <asp:Label ID="Lxiugai" runat="server" Visible="False" Text="是否修改附件：" Font-Bold="True"></asp:Label>
                        </td>
                        <td width="12%" align="left" colspan="2">
                            <asp:RadioButtonList ID="RBL1" runat="server" RepeatDirection="Horizontal" data-toggle="tooltip" data-placement="top" ToolTip="点击选择是否修改附件">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td align="right">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="添加" Height="32px" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                        </td>
                        <td align="left">
                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保存" data-toggle="tooltip" data-placement="top" ToolTip="点击进行保存" />
                        </td>
                    </tr>                           
                </table>
            </div>
        </div>
    </form>
</body>
</html>
