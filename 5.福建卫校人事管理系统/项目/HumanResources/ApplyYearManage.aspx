﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyYearManage.aspx.cs" Inherits="HumanManage_Web.ApplyYearManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >申报年份管理</div></div></div>
   
            <br />
            <div style="float:right;margin-right:20px;">
                <a href="ApplyYearAdd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox"style="  
   width:150px; height:50px; border:1px solid #000; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
 data-toggle="tooltip" data-placement="top"  title="点击进入新增申报年份管理页面"  >添 加</a>
                <asp:LinkButton ID="LinkButton9" runat="server" CssClass="btn_right" OnClick="LinkButton9_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击刷新当前页面">刷 新</asp:LinkButton>
            </div><br />
            <div class="page_main01">
                <div style="margin-top: 10px">
                         
                            <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server"  Width="98%" AllowPaging="True"
                            ShowHeaderWhenEmpty="True"     OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                                OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="10">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:TemplateField HeaderText="编号">
                                        <ItemTemplate>
                                            <asp:Label ID="Year_Num" runat="server" Text='<%# Eval("ApplyYearId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StartDate" HeaderText="起始时间">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EndDate" HeaderText="终止时间">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ApplyYearId") %>'
                                                    OnCommand="LinkButton1_Command" data-toggle="tooltip" data-placement="top"  ToolTip="点击设置为申报时间">点击设置为申报时间</asp:LinkButton>
                                                <asp:Label ID="applyTime" runat="server" Text="当前时间为申报时间" Visible="False" data-toggle="tooltip" data-placement="top"  ToolTip="显示当前时间为申报时间"></asp:Label>
                                                <a href='ApplyYearUpd.aspx?ApplyYear=<%# Eval("ApplyYearId")%>&keepThis=true&TB_iframe=true&height=300&width=500'  class="fLink thickbox">修改</a>
                                                <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("ApplyYearId") %>' runat="server"
                                                    OnCommand="LinkButton9_Command" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行删除">删除</asp:LinkButton>
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
                </div>
            </div>
        </div>
    </form>
</body>
</html>

