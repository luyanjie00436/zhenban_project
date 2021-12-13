<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTeachingManage.aspx.cs" Inherits="sanmingScientManage_Web.MyTeachingManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >个人著作教材记录</div></div></div><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page_main01">
        <div style="margin-top: 10px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                      ShowHeaderWhenEmpty="true"     OnPageIndexChanging="GridView1_PageIndexChanging" BackColor=" #d4d2d2"   CssClass="juzhong" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>   
                             <asp:BoundField DataField="姓名" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>     
                                   <asp:BoundField DataField="系(部)" HeaderText="系(部)">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>       
                              <asp:BoundField DataField="类别" HeaderText="类别">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField> 
                             <asp:BoundField DataField="级别" HeaderText="级别">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>           
                                  <asp:BoundField DataField="著作教材名称" HeaderText="著作教材名称">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             
                              <asp:BoundField DataField="出版社" HeaderText="出版社">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="出版日期" HeaderText="出版日期">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="成员" HeaderText="成员信息">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                          <asp:BoundField DataField="版次" HeaderText="版次">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="字数(万)" HeaderText="字数(万)">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="成果获得时间" HeaderText="成果获得时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="成果分值" HeaderText="成果分值">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="申报时间" HeaderText="申报时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="审批状态">
                                    <ItemTemplate>
                                        <asp:Label ID="LTransferStatus" runat="server" Text='<%# Eval("审核状态") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridview_HeaderStyle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                           <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                      <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("编号") %>'>查看详情</asp:LinkButton>
                                       
                                          <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("编号") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("编号") %>' runat="server"
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
