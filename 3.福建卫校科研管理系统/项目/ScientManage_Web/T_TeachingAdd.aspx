<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T_TeachingAdd.aspx.cs" Inherits="ScientManage_Web.T_TeachingAdd" %>

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

        .auto-style2 {
            height: 28px;
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
                    <div class="parallelogram2">教材建设添加</div>
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
                        <td align="right" width="12%"><strong>书名:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtT_TeachingName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入书名"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>出版类别:</strong> </td>
                        <td align="left" width="12%">
                            <asp:DropDownList ID="DlCategory" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入出版类别">
                                <asp:ListItem>请选择出版类别</asp:ListItem>
                                <asp:ListItem>省部级规划教材</asp:ListItem>
                                <asp:ListItem>创新教材</asp:ListItem>
                                <asp:ListItem>正式出版一般教材</asp:ListItem>
                                <asp:ListItem>自编教材</asp:ListItem>
                                <asp:ListItem>国家级规划教材</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>出版社:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtPress" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入出版社"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>出版时间:</strong> </td>
                        <td align="left" width="12%">
                            <input id="txtTime" onfocus="WdatePicker()" runat="server" data-toggle="tooltip" data-placement="top" title="请输入出版时间" class="input1"></input>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%" class="auto-style2"><strong>版次:</strong> </td>
                        <td align="left" width="12%" class="auto-style2">
                            <asp:TextBox ID="txtEdition" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入版次"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>主编字数:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtCompiledwords" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入主编字数"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>主编名次:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtEditorRanking" runat="server" CssClass="input1" data-toggle="tooltip" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-placement="top" ToolTip="输入主编名次"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>主编基础分得分:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtScore" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" type="" onblur="javascript:yzszfw1(this,0,99999999);" ToolTip="输入主编基础分得分"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>参编者编写字数:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtReference" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入参编者编写字数"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>字数配套得分:</strong> </td>
                        <td align="left" width="12%">
                            <asp:TextBox ID="txtTotalscore" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" type="" onblur="javascript:yzszfw1(this,0,99999999);" ToolTip="输入字数配套得分"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%" class="auto-style1"><strong>备注:</strong> </td>
                        <td align="left" width="12%" class="auto-style1">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入备注，充当说明使用"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="12%"><strong>本人得分:</strong> </td>
                        <td align="left" width="12%">
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
