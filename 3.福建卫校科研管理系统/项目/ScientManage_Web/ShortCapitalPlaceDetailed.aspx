<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortCapitalPlaceDetailed.aspx.cs" Inherits="ScientManage_Web.ShortCapitalPlaceDetailed" %>

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
        <div id="div_main" class="min_height">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">资金到位表</div>
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
                <div style="display: none">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr class="tr13">
                                <td align="center" valign="middle">您已经添加的资金到位信息如下
                                </td>
                            </tr>
                        </table>
                        <div style="margin: 5px 0px 0px 0px; text-align: center;">
                            <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AutoGenerateColumns="False" Width="100%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:BoundField DataField="PlaceMoney" HeaderText="到位金额">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PlaceDate" HeaderText="到位时间">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PlaceExplain" HeaderText="到位说明">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="right" width="80%">总金额:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumMoney" runat="server" Enabled="false" CssClass="input1"></asp:TextBox>
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
