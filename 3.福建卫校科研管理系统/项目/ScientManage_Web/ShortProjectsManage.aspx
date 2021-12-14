<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortProjectsManage.aspx.cs" Inherits="ScientManage_Web.ShortProjectsManage" %>

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
                    <div class="parallelogram2">横向项目情况</div>
                </div>
            </div>
            <div class="page_main01">
                <div style="margin-top: 10px">

                    <table border="0" cellspacing="0" cellpadding="0" class="bgcolor">
                        <tr>
                            <td align="right">
                                <strong>负责人：</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top" ToolTip="请输入负责人" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                            </td>

                            <td align="right">
                                <strong>所属院系：</strong>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择所属院系" CssClass="select1" Width="137px">
                                    <asp:ListItem Value="0">选择院系</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <strong>申请年份：</strong>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DLApply" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择时间" CssClass="select1" Width="65px">
                                    <asp:ListItem Value="0">选择时间</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <strong>合同编号:</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContractId" data-toggle="tooltip" data-placement="top" ToolTip="请输入合同编号" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>合作单位：</strong></td>
                            <td>
                                <asp:TextBox ID="txtCompany" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请输入合作单位" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <strong>合同金额：</strong></td>
                            <td>
                                <input id="txtMoney1" data-toggle="tooltip" data-placement="top" runat="server" class="select1" height="27px" width="40px" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" title="输入查找经费范围"></input>
                                ~<input id="txtMoney2" runat="server" class="select1" height="27px" width="40px" type="" onblur="javascript:xzyzszfw1(this,0,99999999);" data-toggle="tooltip" data-placement="top" title="输入查找经费范围"></input>
                            </td>
                            <td align="right">
                                <strong>立项状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLStand" data-toggle="tooltip" data-placement="top" ToolTip="请选择所需查找立项状态" runat="server" CssClass="select1" Width="137px">
                                    <asp:ListItem Value="0">立项状态</asp:ListItem>
                                    <asp:ListItem Value="未立项">未立项</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                <strong>结题状态：</strong></td>
                            <td>
                                <asp:DropDownList ID="DLEnd" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择所需查找的结题状态" Width="137px">
                                    <asp:ListItem Value="0">结题状态</asp:ListItem>
                                    <asp:ListItem Value="未结题">未结题</asp:ListItem>
                                    <asp:ListItem Value="未审批">未审批</asp:ListItem>
                                    <asp:ListItem Value="审批中">审批中</asp:ListItem>
                                    <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                                    <asp:ListItem Value="审批未通过">审批未通过</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>合同名称：</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContractName" data-toggle="tooltip" data-placement="top" ToolTip="请输入合同名称" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="点击查找" CssClass="btn" OnClick="Button2_Click" Text="查 找" />
                            </td>
                            <td>
                                <asp:Button ID="Button3" data-toggle="tooltip" data-placement="top" ToolTip="点击导出" runat="server" CssClass="btn" OnClick="Button3_Click" Text="导 出" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                        ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
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
                            <asp:BoundField DataField="合同编号" HeaderText="合同编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="合同名称" HeaderText="合同名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="合同金额" HeaderText="合同金额">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="合作单位" HeaderText="合作单位">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="立项状态">
                                <ItemTemplate>
                                    <asp:Label ID="LStandStatus" runat="server" Text='<%# Eval("立项状态") %>'></asp:Label>
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
                                        <asp:LinkButton ID="LinkButton7" runat="server"
                                            OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("项目编号") %>'>立项详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton8" runat="server" Visible="false"
                                            OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("项目编号") %>'>结题详情</asp:LinkButton>
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
