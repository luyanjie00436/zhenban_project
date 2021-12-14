<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalBasicAdd.aspx.cs" Inherits="ScientManage_Web.LongCapitalBasicAdd" %>

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
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
    <style type="text/css">
        .auto-style4 {
            height: 30px;
        }

        .auto-style5 {
            width: 50%;
        }

        .auto-style6 {
            height: 30px;
            width: 11%;
        }

        .auto-style7 {
            width: 11%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="div_main">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">经费基础信息设置</div>
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right" class="auto-style7">
                                    <strong>项目编号:</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LProjectsId" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>项目名称:</strong> </td>
                                <td align="left" width="12%">
                                    <asp:Label ID="LProjectsName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>项目来源:</strong> </td>
                                <td align="left" width="12%">
                                    <asp:Label ID="LProjectsFromExplain" runat="server"></asp:Label>
                                </td>                               
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>中标金额:</strong> </td>
                                <td align="left" width="12%">
                                    <input id="txtBidMoney" runat="server" data-toggle="tooltip" data-placement="top" title="请输入中标金额" class="input1" type="" onblur="javascript:xzyzszfw1(this,0,99999999);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style6"><strong>配套金额:</strong> </td>
                                <td align="left" width="12%" class="auto-style4">
                                    <input id="txtSupportMoney" runat="server" class="input1" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入配套金额"></input>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>其他资助金额:</strong> </td>
                                <td align="left" width="12%">
                                    <input id="txtOtherMoney" runat="server" class="input1" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入其他资助金额"></input>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>经费下达单位:</strong> </td>
                                <td align="left" width="12%">
                                    <asp:TextBox ID="txtSuedCompany" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入经费下达单位"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"><strong>经费使用期限:</strong> </td>
                                <td align="left" width="12%">
                                    <input id="txtServicelife" onfocus="WdatePicker()" data-toggle="tooltip" data-placement="top" title="请输入经费使用期限" runat="server" class="input1" cssclass="Wdate" />
                                </td>
                            </tr>
                            <tr class="tr10">
                                <td align="right" class="auto-style7" style="background: none;"></td>
                                <td align="left" style="background: none;">
                                    <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保 存" data-toggle="tooltip" data-placement="top" ToolTip="点击进行保存" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
