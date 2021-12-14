<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="HumanManage_Web.RoleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
<div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >职务管理</div></div></div>

      <br />
           <div style="float:right;margin-right:20px;">
     <a href="RoleAdd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox" style="  
   width:150px; height:50px; border:1px solid #000; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
  data-toggle="tooltip" data-placement="top"  title="点击添加进入新增职务页面"  >添 加</a>
         <asp:LinkButton ID="LinkButton9"  data-toggle="tooltip" data-placement="top"  ToolTip="点击刷新当前页面" runat="server" CssClass="btn_right"  OnClick="LinkButton9_Click">刷 新</asp:LinkButton>
                </div><br />
    <div class="page_main01">
        <div style="margin-top: 10px">

                   
                   
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                      ShowHeaderWhenEmpty="True"   OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="RoleId" HeaderText="职务编号">
                                <HeaderStyle Width="33%" CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoleName" HeaderText="职务名称">
                                <HeaderStyle Width="33%" CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                          <a href='RoleUpd.aspx?Role=<%# Eval("RoleId")%>&keepThis=true&TB_iframe=true&height=300&width=500'   class="fLink thickbox">
                                            修改</a>  
                                        <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("RoleId") %>' runat="server"
                                            OnCommand="LinkButton9_Command">删除</asp:LinkButton>
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



