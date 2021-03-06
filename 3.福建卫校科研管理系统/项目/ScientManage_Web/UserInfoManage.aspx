<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoManage.aspx.cs" Inherits="ScientManage_Web.UserInfoManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        .auto-style1 {
            width: 17%;
        }

        .auto-style2 {
            width: 31%;
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
                    <div class="parallelogram2">人员信息管理</div>
                </div>
            </div>
            <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10%" align="right">
                                <strong>用户姓名：</strong>
                            </td>
                            <td align="left" class="auto-style1">
                                <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top" ToolTip="请输入所需查找的用户姓名" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                           <td width="10%" align="right">
                                <strong>行政隶属：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择行政隶属" CssClass="select1" Width="137px">
                                    <asp:ListItem Value="0">选择行政隶属</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="10%" align="right">
                                <strong>在职：</strong>
                            </td>
                            <td align="left" width="10%">
                                <asp:DropDownList ID="DlStatus" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择在职" CssClass="select1" Width="137px">
                                    <asp:ListItem Value="0">选择在职</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             <td width="10%" align="right">
                                <strong>年龄段：</strong>
                            </td>
                            <td align="left" class="auto-style1">
                                <asp:TextBox ID="txtStartYear" CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请输入所需查找的年龄范围" runat="server" Height="27px" Width="37px" TextMode="Number"></asp:TextBox>~
                            <asp:TextBox ID="txtEndYear" CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请输入所需查找的年龄范围" runat="server" Height="27px" Width="37px" TextMode="Number"></asp:TextBox>
                            </td>
                          
                             </tr>
                        <tr>
                              <td width="10%" align="right">
                                <strong>性别：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlGender" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择性别" CssClass="select1" Width="137px">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                           
                            <td width="10%" align="right">
                                <strong>政治面貌：</strong>
                            </td>
                            <td align="left" width="10%">
                                <asp:DropDownList ID="DlPolitical" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择政治面貌" CssClass="select1" Width="137px">
                                    <asp:ListItem Value="0">选择政治面貌</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                              <td>
                                <asp:Button ID="Button1" runat="server" Text="查 找" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" OnClick="Button1_Click" CssClass="btn" /></td>
                     
                            <td><a href="UserInfoAdd.aspx" style="width: 150px; height: 50px; border: 1px solid #000; border-radius: 13px; margin-right: 20px; text-align: center; line-height: 30px; padding: 6px 15px 6px 15px;">添 加</a></td>

                        </tr>
                    </table>
                    <br/>
                    <br/>
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="工号" HeaderText="工号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="现任职部门" HeaderText="任职部门">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="姓名" HeaderText="姓名">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                       
                            <asp:BoundField DataField="性别" HeaderText="性别">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="政治面貌" HeaderText="政治面貌">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="在职状态" HeaderText="在职状态">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="出生年月" HeaderText="出生年月">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="年龄" HeaderText="年龄">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="是否启用" HeaderText="是否启用">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="应完成教科研分" HeaderText="应完成教科研分">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <a href="UserRankManage.aspx?UserCardId=<%# Eval("工号")%>">权限管理</a>
                                        <a href='UserEnable.aspx?UserCardId=<%# Eval("工号")%>&keepThis=true&TB_iframe=true&height=300&width=500' class="fLink thickbox">修改用户状态</a>
                                        <a href='UserWork.aspx?UserCardId=<%# Eval("工号")%>&keepThis=true&TB_iframe=true&height=300&width=500' class="fLink thickbox">修改工作量分值</a>

                                        <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("工号") %>'>修改用户信息</asp:LinkButton>

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
                    <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

