<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalPlaceAdd.aspx.cs" Inherits="ScientManage_Web.LongCapitalPlaceAdd" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main" class="min_height">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">资金到位</div>
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
                        <div style="margin-bottom: 10px">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right">项目名称
                                    </td>
                                    <td>
                                        <asp:Label ID="LProjectsName" runat="server"></asp:Label>
                                        <asp:Label ID="LProjectsId" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td align="right">到位金额
                                    </td>
                                    <td>
                                        <input id="txtPlaceMoney" runat="server" class="input1" type="" onblur="javascript:yzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入到位金额"></input>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">到位时间
                                    </td>
                                    <td>
                                        <input id="txtPlaceDate" data-toggle="tooltip" data-placement="top" title="请输入到位时间" runat="server" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                            class="input1">
                                    </td>
                                    <td align="right">到位说明
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPlaceExplain" runat="server" CssClass="input1" Width="197px" data-toggle="tooltip" data-placement="top" ToolTip="输入到位说明"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行修改" />
                                    </td>
                                </tr>
                            </table>
                        </div>
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
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("LongCapitalPlaceId") %>'
                                                    OnCommand="LinkButton6_Command" ToolTip="点击编辑进行修改">编辑</asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("LongCapitalPlaceId") %>'
                                                    OnClientClick="return confirm(&quot;你确定删除吗？&quot;);" OnCommand="LinkButton7_Command" ToolTip="点击进行删除">删除</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="right" width="80%">总金额:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumMoney" runat="server" Enabled="false" CssClass="input1" ToolTip="资金到位总金额"></asp:TextBox>
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
