<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortCapitalPlanAdd.aspx.cs" Inherits="ScientManage_Web.ShortCapitalPlanAdd" %>

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
        .auto-style4 {
            height: 30px;
        }

        .auto-style5 {
            width: 50%;
        }

        .auto-style6 {
            height: 30px;
            width: 50%;
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
                    <div class="parallelogram2">经费预算</div>
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
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style5">
                            <strong>合同编号:</strong>
                        </td>
                        <td align="left">
                            <asp:Label ID="LContractId" runat="server"></asp:Label>
                            <asp:Label ID="LProjectsId" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>合同名称:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LContractName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>合作单位:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LCompany" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>合同金额:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LContractMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>中标金额:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LBidMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6"><strong>配套金额:</strong> </td>
                        <td align="left" class="auto-style4">
                            <asp:Label ID="LSupportMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>其他资助金额:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LOtherMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>经费下达单位:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LSuedCompany" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>经费使用期限:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LServicelife" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"><strong>总经费:</strong> </td>
                        <td align="left">
                            <asp:Label ID="LSumMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5">
                            <strong>模板：</strong>
                        </td>
                        <td align="left" colspan="2">
                            <asp:DropDownList ID="DlCategory" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="选择模板">
                                <asp:ListItem Value="0">请选择</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;        
                            <asp:LinkButton runat="server" ForeColor="Blue" ID="LinkButton1" Text="下载模板" OnClick="LinkButton1_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击下载模板"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5">
                            <strong>上传预算文件：</strong>
                        </td>
                        <td align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请上传预算文件" Width="203px" CssClass="input6" />
                            <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                            <asp:Label runat="server" ID="LFileUrl" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td align="right" class="auto-style5" style="background: none;"></td>
                        <td align="left" style="background: none;">
                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击保存" Text="保 存" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
