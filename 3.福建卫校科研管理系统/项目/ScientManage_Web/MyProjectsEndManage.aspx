<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProjectsEndManage.aspx.cs" Inherits="ScientManage_Web.MyProjectsEndManage" %>

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
    <style>
        .btn10 {
            width: 120px;
            height: 34px;
            line-height: 34px;
            display: inline-block;
            text-align: center;
            color: #404040;
            background: url(../images/btn003.gif) no-repeat;
            background-size: cover;
            font-weight: bold;
            border: none;
            cursor: pointer;
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
                    <div class="parallelogram2">个人项目结题表</div>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <br />
                            <p style="font-size: 20px;">可结题项目</p>
                            <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                                ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" PageSize="10" Width="98%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:BoundField DataField="LongProjectsName" HeaderText="项目名称">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LongProjectsCategory" HeaderText="项目类别">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TransferStatus" HeaderText="完成情况">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("LongProjectsId") %>'>结题</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="str001" />
                            </asp:GridView>
                            <br />
                            <p style="font-size: 20px;">已申请结题项目</p>
                            <asp:GridView ID="GridView2" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                                OnPageIndexChanging="GridView2_PageIndexChanging" AutoGenerateColumns="False"
                                OnSelectedIndexChanging="GridView2_SelectedIndexChanging" PageSize="10" Width="98%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:BoundField DataField="LongProjectsName" HeaderText="项目名称">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LongProjectsCategory" HeaderText="项目类别">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TransferStatus" HeaderText="完成情况">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("LongProjectsId") %>'>查看详情</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="str001" />
                                <PagerTemplate>
                                    当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
