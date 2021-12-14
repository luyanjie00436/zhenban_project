<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsDeclareProcess.aspx.cs" Inherits="ScientManage_Web.LongProjectsDeclareProcess" %>

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
                    <div class="parallelogram2">纵向项目流程</div>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="0" cellspacing="0" cellpadding="0" class="bgcolor ">
                                <tr>
                                    <td width="9%" align="right">
                                        <strong>类型：</strong>
                                    </td>
                                    <td width="11%" align="left">
                                        <asp:DropDownList ID="DLSubject" runat="server" CssClass="select1" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="DLSubject_SelectedIndexChanged" data-toggle="tooltip" data-placement="top" ToolTip="选择类型">
                                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                            <asp:ListItem Value="Declare">申报</asp:ListItem>
                                            <asp:ListItem Value="Stand">立项</asp:ListItem>
                                            <asp:ListItem Value="Inspect">中检</asp:ListItem>
                                            <asp:ListItem Value="End">结题</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="9%" align="right">
                                        <strong>审批系(部)：</strong>
                                    </td>
                                    <td width="11%" align="left">
                                        <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="80%" data-toggle="tooltip" data-placement="top" ToolTip="选择审批系部">
                                            <asp:ListItem Value="0">当前系(部)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="9%" align="right">
                                        <strong>审批角色：</strong>
                                    </td>
                                    <td width="11%" align="left">
                                        <asp:DropDownList ID="DlRank" runat="server" CssClass="select1" Width="80%" data-toggle="tooltip" data-placement="top" ToolTip="选择审批角色">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="9%" align="right">
                                        <strong>审批顺序：</strong>
                                    </td>
                                    <td width="11%" align="left">
                                        <asp:DropDownList ID="DlProcessOrder" runat="server" CssClass="select1" Width="80%" data-toggle="tooltip" data-placement="top" ToolTip="选择审批顺序">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="14%" height="80" align="left">
                                        <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <br>
                            <asp:GridView ID="GridView1" BackColor=" #d4d2d2" CssClass="juzhong" runat="server" Width="98%" AllowPaging="True"
                                ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                                OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="10">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:BoundField DataField="ProcessDepartment" HeaderText="审批系(部)">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcessRankName" HeaderText="审批角色">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcessOrder" HeaderText="审批顺序">
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("LongProjectsProcessId") %>' runat="server"
                                                    OnCommand="LinkButton9_Command" ToolTip="点击进行删除">删除</asp:LinkButton>
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
