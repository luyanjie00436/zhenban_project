<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssessYear.aspx.cs" Inherits="ScientManage_Web.AssessYear" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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

    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
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
                    <div class="parallelogram2">科研工作量核算</div>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <br>
                            <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="10" Width="100%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:TemplateField HeaderText="申报年份">
                                        <ItemTemplate>
                                            <asp:Label ID="LReportDate" runat="server" Text='<%# Eval("ReportDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UserName" HeaderText="姓名">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DepartmentName" HeaderText="行政隶属">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OldReserve" HeaderText="去年预留分值">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ShouldValue" HeaderText="应完成分值">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="kyNowValue" HeaderText="已完成科研分值">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jyNowValue" HeaderText="已完成教研分值">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NowReserve" HeaderText="今年预留分值">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <a href='AssessValueReserve.aspx?AssessValue=<%# Eval("AssessValueId")%>&keepThis=true&TB_iframe=true&height=300&width=500' class="fLink thickbox">
                                                    <asp:Label ID="A7" runat="server">修改预留</asp:Label></a>
                                                <asp:LinkButton ID="LinkButton8" runat="server" CommandArgument='<%# Eval("ApplyYearId") %>' OnCommand="LinkButton8_Command" ToolTip="查看本季度或本年度教师工作量信息">科研详细</asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ApplyYearId") %>' OnCommand="LinkButton9_Command" ToolTip="查看本季度或本年度教师工作量信息">教研详细</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="str001" />
                                <PagerTemplate>
                                    当前第: <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                                    <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>" ToolTip="当前页"></asp:Label>
                                    页/共: <%--//得到分页页面的总数--%>
                                    <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>" ToolTip="总用页"></asp:Label>
                                    页 <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Visible="<%#((GridView)Container.NamingContainer).PageIndex != 0 %>" ToolTip="点击跳转到首页">首页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page" Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" ToolTip="点击跳转到上一页">上一页</asp:LinkButton>
                                    <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" ToolTip="点击跳转到下一页">下一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" ToolTip="点击跳转到尾页">尾页</asp:LinkButton>
                                    转到第 
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>" Width="20px" ToolTip="输入要跳转到的页数" />
                                    页 <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" ToolTip="点击跳转" />
                                </PagerTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
