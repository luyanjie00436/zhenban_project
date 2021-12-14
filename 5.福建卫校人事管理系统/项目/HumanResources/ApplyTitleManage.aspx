<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyTitleManage.aspx.cs" Inherits="HumanManage_Web.ApplyTitleManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="min_height">
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >职称申请记录</div></div></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
         
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="10%" align="right">
                                        <strong>用户姓名：</strong>
                                    </td>
                                    <td width="10%" align="left">
                                        <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入用户姓名 例如（张三）" runat="server" Height="27px" CssClass="select1" Width="137px"></asp:TextBox>
                                    </td>
                                  
                                    <td width="10%" align="right">
                                        <strong>申请时间：</strong>
                                    </td>
                                    <td width="20%" align="left">
                                        <asp:DropDownList ID="DlYear" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请年份"  CssClass="select1" Width="80px">
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
                               <asp:DropDownList ID="DlMonth" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请月份"  Width="80px">
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
                                 
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击查找" OnClick="Button1_Click" Text="查 找" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                              ShowHeaderWhenEmpty="True"   OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                                PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:BoundField DataField="ApplyTitleId" HeaderText="申请编号">
                                        <HeaderStyle Width="7%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserCardId" HeaderText="工号">
                                        <HeaderStyle Width="7%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserName" HeaderText="姓名">
                                        <HeaderStyle Width="7%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                 
                                    <asp:BoundField DataField="DepartmentName" HeaderText="申请部门">
                                        <HeaderStyle Width="9%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Job" HeaderText="申请职称">
                                        <HeaderStyle Width="9%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Post" HeaderText="申请职级">
                                        <HeaderStyle Width="7%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TitleSeries" HeaderText="职称系列">
                                        <HeaderStyle Width="9%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Major" HeaderText="专业">
                                        <HeaderStyle Width="9%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApplyDate" HeaderText="申请日期">
                                        <HeaderStyle Width="9%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("ApplyTitleId") %>'>查看详情<br/></asp:LinkButton>
                                             <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("ApplyTitleId") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("ApplyTitleId") %>' runat="server" OnCommand="LinkButton9_Command">删除</asp:LinkButton>

                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" Width="7%" />
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
