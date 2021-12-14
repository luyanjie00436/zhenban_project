<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PastAwardsExamineManage.aspx.cs" Inherits="HumanResources.PastAwardsExamineManage" %>

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
<div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >历年获奖审批</div></div></div>
 
      <br />
     

    <div class="page_main01">
        <div style="margin-top: 10px">

                    
                   
                    <asp:GridView ID="GridView1" runat="server"  BackColor=" #d4d2d2"   CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                       ShowHeaderWhenEmpty="True"   OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:TemplateField>
                                  <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbMore" runat="server" CommandArgument='<%# Eval("PastAwardsId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="编号">
                                  <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="LOfficeId" runat="server" Text='<%#Eval("PastAwardsId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                         <%--  <asp:BoundField DataField="UseOfficeId" HeaderText="编号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="UserCardId" HeaderText="工号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="UserName" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AwardProjectName" HeaderText="获奖项目名称">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AwardDate" HeaderText="获奖时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GrantUnit" HeaderText="授予单位">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="备注">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="TransferStatus" HeaderText="是否有效">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:TemplateField HeaderText="查看照片">
                                <ItemTemplate>
                                    <div class="link02">
                                          <a href='PastAwardsPhoto.aspx?PastAwards=<%# Eval("PastAwardsId")%>&keepThis=true&TB_iframe=true&height=400&width=500'  class="fLink thickbox" >
                                            查看照片</a>  
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>       
                              <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("PastAwardsId") %>' OnClientClick="return confirm('确认同意审批吗？');">同意</asp:LinkButton>
                                                 <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="LinkButton2_Command" CommandArgument='<%# Eval("PastAwardsId") %>' OnClientClick="return confirm('确认拒绝审批吗？');">拒绝</asp:LinkButton>
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
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="全选/反选" AutoPostBack="True" />
                    <asp:Button ID="Button1" runat="server" Text="同意" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="拒绝" OnClick="Button2_Click" />
        </div>
    </div>
    </div>
    </form>
</body>
</html>
