<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperAdd.aspx.cs" Inherits="ScientManage_Web.PaperAdd" %>

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
        .auto-style5 {
            width: 664px;
        }

        .auto-style6 {
            width: 647px;
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
                    <div class="parallelogram2">论文添加</div>
                </div>
            </div>
            <div class="page_main01">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style6">
                            <strong>年份:</strong>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtApplyYear" runat="server" CssClass="input1" ReadOnly="True" data-toggle="tooltip" data-placement="top" ToolTip="年份日期"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>填报日期:</strong> </td>
                        <td align="left">
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
                        <td align="right" class="auto-style6"><strong>论文题目:</strong> </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaperSubject" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入论文题目"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>期刊名称及刊号:</strong> </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaperName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入期刊名称及刊号 例如(9-787115-183392)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>论文级别:</strong> </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaperLevel" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入级别 例如（CN级、核心、权威、SCI、EI...）"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>年月、期:</strong> </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaperYears" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入年月、期 例如（2015-11-02 13期）"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>备注:</strong> </td>
                        <td align="left">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入备注，充当说明使用"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>成果分值:</strong> </td>
                        <td align="left">
                            <input id="txtPaperValue" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="成果分值应为正数  例如（0.1,1.1,1.5.....）"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>本人排名:</strong> </td>
                        <td align="left">
                            <input id="txtPartnerRank" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,100);" data-toggle="tooltip" data-placement="top" title="本人排名应为正数 例如（1,2,3......）"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>本人得分:</strong> </td>
                        <td align="left">
                            <input id="txtPartnerValue" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="本人得分应为正数  例如（0.1,1.1,1.5.....）"></input>
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
                        <td align="right" style="background: none;" class="auto-style6">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="添 加" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                        </td>
                        <td align="left" style="background: none;">
                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保 存" data-toggle="tooltip" data-placement="top" ToolTip="点击进行保存" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
