<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkLoadProjectsStatusManage.aspx.cs" Inherits="ScientManage_Web.WorkLoadProjectsStatusManage" %>

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
                    <div class="parallelogram2">科研项目审批管理</div>
                </div>
            </div>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <table class="bgcolor " border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10%" align="right">
                                <strong>参与人姓名：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:TextBox ID="txtUserName" CssClass="select1" runat="server" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入姓名"></asp:TextBox>
                            </td>
                            <td width="6%" align="right">
                                <strong>所在院系：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择部门">
                                    <asp:ListItem Value="0">选择部门</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="10%" align="right">
                                <strong>申请时间：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:DropDownList ID="DlYear" runat="server" CssClass="select1" Width="80px" data-toggle="tooltip" data-placement="top" ToolTip="选择年份">
                                    <asp:ListItem Value="0">选择年份</asp:ListItem>
                                    <asp:ListItem Value="1">2015</asp:ListItem>
                                    <asp:ListItem Value="2">2016</asp:ListItem>
                                    <asp:ListItem Value="3">2017</asp:ListItem>
                                    <asp:ListItem Value="4">2018</asp:ListItem>
                                    <asp:ListItem Value="5">2019</asp:ListItem>
                                    <asp:ListItem Value="6">2010</asp:ListItem>
                                    <asp:ListItem Value="7">2021</asp:ListItem>
                                    <asp:ListItem Value="8">2022</asp:ListItem>
                                    <asp:ListItem Value="9">2023</asp:ListItem>
                                    <asp:ListItem Value="10">2024</asp:ListItem>
                                    <asp:ListItem Value="11">2025</asp:ListItem>
                                    <asp:ListItem Value="12">2026</asp:ListItem>
                                    <asp:ListItem Value="13">2027</asp:ListItem>
                                    <asp:ListItem Value="14">2028</asp:ListItem>
                                    <asp:ListItem Value="15">2029</asp:ListItem>
                                    <asp:ListItem Value="16">2039</asp:ListItem>
                                </asp:DropDownList>年
                               <asp:DropDownList ID="DlMonth" runat="server" CssClass="select1" Width="80px" data-toggle="tooltip" data-placement="top" ToolTip="选择月份">
                                   <asp:ListItem Value="0">选择月份</asp:ListItem>
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
                                   <asp:ListItem Value="11">11</asp:ListItem>
                                   <asp:ListItem Value="12">12</asp:ListItem>
                               </asp:DropDownList>月                              
                            </td>
                            <td width="6%" align="right">
                                <strong>年份：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DLApplyYear" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择年份">
                                    <asp:ListItem Value="0">选择年份</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" align="right">
                                <strong>项目名称：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:TextBox ID="txtProjectsName" CssClass="select1" runat="server" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入项目名称"></asp:TextBox>
                            </td>
                            <td width="10%" align="right">
                                <strong>来源及类别：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:TextBox ID="txtProjectsForm" CssClass="select1" runat="server" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入来源及类别"></asp:TextBox>
                            </td>
                            <td width="10%" align="right">
                                <strong>审核状态：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlStatus" runat="server" CssClass="select1" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="选择审核状态">
                                    <asp:ListItem Value="0">审批状态</asp:ListItem>
                                    <asp:ListItem Value="1">未审批</asp:ListItem>
                                    <asp:ListItem Value="2">审批中</asp:ListItem>
                                    <asp:ListItem Value="3">同意</asp:ListItem>
                                    <asp:ListItem Value="4">拒绝</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="查 找" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" Text="导 出" data-toggle="tooltip" data-placement="top" ToolTip="记录导出来Excel" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2" CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                        ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="申请人姓名" HeaderText="姓名">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="申请人部门" HeaderText="所在院系">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="类别" HeaderText="类别">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目名称" HeaderText="项目名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目编号" HeaderText="项目编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="来源及类别" HeaderText="来源及类别">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="起止时间" HeaderText="起止时间">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="项目总分值" HeaderText="项目总分值">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="本年度可分配工作量分值" HeaderText="本年度可分配工作量分值">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="申报时间" HeaderText="申报时间">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="审核状态" HeaderText="审核状态">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="成员" HeaderText="成员">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <asp:LinkButton ID="LinkButton7" runat="server"
                                            OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("编号") %>' ToolTip="跳转到科研项目审批表">修改审批状态</asp:LinkButton>
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
                    <asp:GridView ID="gvExcel" runat="server" Height="95px" OnRowDataBound="gvExcel_RowDataBound" Visible="false"></asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
