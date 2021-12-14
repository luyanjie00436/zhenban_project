<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsManage.aspx.cs" Inherits="ScientManage_Web.LongProjectsManage" %>

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
                    <div class="parallelogram2">纵向项目情况</div>
                </div>
            </div>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <table border="0" cellspacing="0" cellpadding="0" class="bgcolor">
                        <tr>
                            <td align="right">
                                <strong>项目编号：</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProjectsId" runat="server" CssClass="select1" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入项目编号"></asp:TextBox>
                            </td>
                            <td align="right">
                                <strong>项目名称：</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProjectsName" runat="server" CssClass="select1" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入项目名称"></asp:TextBox>
                            </td>
                            <td align="right">
                                <strong>负责人：</strong></td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Height="27px" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入负责人"></asp:TextBox>
                            </td>

                            <td align="right">
                                <strong>所属院系：</strong>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择所属院系">
                                    <asp:ListItem Value="0">选择院系</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="查 找" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>申请年份：</strong>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DLApply" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择申请年份">
                                    <asp:ListItem Value="0">选择时间</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <strong>类 别：</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="DLSubject" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择类别">
                                    <asp:ListItem Value="0">选择类别</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <strong>级别：</strong>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DLLevel" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择级别">
                                    <asp:ListItem Value="0">选择级别</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <strong>来 源：</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="DLFrom" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择来源">
                                    <asp:ListItem Value="0">选择来源</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" Text="导 出" data-toggle="tooltip" data-placement="top" ToolTip="点击进行导出到Excle" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>申报状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLDeclare" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择申报状态">
                                    <asp:ListItem Value="0">申报状态</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                <strong>立项状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLStand" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择立项状态">
                                    <asp:ListItem Value="0">立项状态</asp:ListItem>
                                    <asp:ListItem Value="未立项">未立项</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                <strong>中检状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLInspect" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择中检状态">
                                    <asp:ListItem Value="0">中检状态</asp:ListItem>
                                    <asp:ListItem Value="未中检">未中检</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                <strong>结题状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLEnd" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择结题状态">
                                    <asp:ListItem Value="0">结题状态</asp:ListItem>
                                    <asp:ListItem Value="未结题">未结题</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                        ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="项目编号" HeaderText="项目编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目名称" HeaderText="项目名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目类别" HeaderText="项目类别">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="项目级别" HeaderText="项目级别">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目来源" HeaderText="项目来源">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="负责人" HeaderText="负责人">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="所属院系" HeaderText="所属院系">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="申报年份" HeaderText="申报年份">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="协作单位" HeaderText="协作单位">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="申报状态">
                                <ItemTemplate>
                                    <asp:Label ID="LDeclareStatus" runat="server" Text='<%# Eval("申报状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="立项状态">
                                <ItemTemplate>
                                    <asp:Label ID="LStandStatus" runat="server" Text='<%# Eval("立项状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="中检状态">
                                <ItemTemplate>
                                    <asp:Label ID="LInspectStatus" runat="server" Text='<%# Eval("中检状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="结题状态">
                                <ItemTemplate>
                                    <asp:Label ID="LEndStatus" runat="server" Text='<%# Eval("结题状态") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <asp:LinkButton ID="LinkButton6" runat="server" 
                                            OnCommand="LinkButton6_Command" CommandArgument='<%# Eval("项目编号") %>' ToolTip="点击跳转到项目申请审批表">申报详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton7" runat="server" Visible="false"
                                            OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("项目编号") %>' ToolTip="点击跳转到项目立项审批表">立项详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton8" runat="server" Visible="false"
                                            OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("项目编号") %>' ToolTip="点击跳转到项目中检审批表">中检详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" runat="server" Visible="false"
                                            OnCommand="LinkButton9_Command" CommandArgument='<%# Eval("项目编号") %>' ToolTip="点击跳转到项目结题审批表">结题详情</asp:LinkButton>
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
