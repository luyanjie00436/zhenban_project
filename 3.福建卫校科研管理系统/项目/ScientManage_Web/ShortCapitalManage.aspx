<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortCapitalManage.aspx.cs" Inherits="ScientManage_Web.ShortCapitalManage" %>

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
    <style type="text/css">
        .auto-style4 {
            width: 137px;
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
        <div id="div_main" class="min_height">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">横向资金基本情况</div>
                </div>
            </div>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <table border="0" cellspacing="0" cellpadding="0" class="bgcolor">
                        <tr>
                            <td align="right">
                                <strong>合同编号:</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContractId" data-toggle="tooltip" data-placement="top" ToolTip="请输入合同编号" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <strong>合同名称：</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContractName" data-toggle="tooltip" data-placement="top" ToolTip="请输入合同名称" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                            <td>
                                <strong>经费下达单位：</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompany" data-toggle="tooltip" data-placement="top" ToolTip="请输入经费下达单位" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <strong>总经费：</strong>
                            </td>
                            <td align="left">
                                <input id="txtMoney1" runat="server" class="select1" height="27px" width="37px" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入查找经费范围"></input>~
                                <input id="txtMoney2" runat="server" class="select1" height="27px" width="37px" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入查找经费范围"></input>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击查找" Text="查 找" />
                            </td>
                            <td>
                                <br />
                                <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击导出" Text="导 出" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor=" #d4d2d2" CssClass="juzhong" AllowSorting="True"
                        ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="100%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="合同编号" HeaderText="合同编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="合同名称" HeaderText="合同名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="经费下达单位" HeaderText="经费下达单位">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="总经费" HeaderText="总经费">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="经费使用期限" HeaderText="经费使用期限">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="到位金额">
                                <ItemTemplate>
                                    <asp:Label ID="LPlace" runat="server" Text='<%# Eval("到位金额") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="预算状态">
                                <ItemTemplate>
                                    <asp:Label ID="LPlan" runat="server" Text='<%# Eval("预算状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="变更状态">
                                <ItemTemplate>
                                    <asp:Label ID="LChange" runat="server" Text='<%# Eval("变更状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="结算状态">
                                <ItemTemplate>
                                    <asp:Label ID="LClose" runat="server" Text='<%# Eval("结算状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <asp:LinkButton ID="LinkButton6" runat="server" Visible="false"
                                            OnCommand="LinkButton6_Command" CommandArgument='<%# Eval("项目编号") %>'>到位详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton7" runat="server" Visible="false"
                                            OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("项目编号") %>'>预算详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton8" runat="server" Visible="false"
                                            OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("项目编号") %>'>变更详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" runat="server" Visible="false"
                                            OnCommand="LinkButton9_Command" CommandArgument='<%# Eval("项目编号") %>'>结算详情</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="str001" />
                        <PagerTemplate>
                            当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            页/共:
                            <%--//得到分页页面的总数--%>
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                            页
                            <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                            <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                            转到第
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                            <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                CommandName="Page" Text="GO" />
                        </PagerTemplate>
                    </asp:GridView>
                    <asp:GridView ID="gvExcel" runat="server" Height="95px" OnRowDataBound="gvExcel_RowDataBound" Visible="false"></asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
