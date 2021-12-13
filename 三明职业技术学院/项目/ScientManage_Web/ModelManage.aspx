<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelManage.aspx.cs" Inherits="sanmingScientManage_Web.ModelManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style4 {
            width: 17%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
                         <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >目录信息</div></div></div><br />

    <div class="page_main01">
                <table class="bgcolor" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" class="auto-style4">
                    目录：
                </td>
                <td width="20%">
                    <asp:DropDownList ID="DlModel" runat="server" Style="margin-left: 0px; width: 80px;"
                        CssClass="select1">
                         <asp:ListItem Value="0">选择目录</asp:ListItem>
                        <asp:ListItem Value="9999">无上级目录</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="查 询" OnClick="Button1_Click" CssClass="btn" />
                </td>
            </tr>
           
        </table>
          <div class="btn_left2">
     <a href="ModelAdd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox" style="  
   width:150px; height:50px;  border:1px solid #989898; color:#fff; background:#542e6a; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
>添 加</a>
         <asp:LinkButton ID="LinkButton9"  runat="server" CssClass="btn_right"  OnClick="LinkButton9_Click">刷 新</asp:LinkButton>
                </div><br /><br />
        <div style="margin-top: 10px">
                    <asp:GridView ID="GridView1"  runat="server" BackColor=" #d4d2d2"   CssClass="juzhong"  Width="98%" AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                           OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="10">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                             <asp:BoundField DataField="ModelId" HeaderText="目录编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ModelName" HeaderText="目录名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ModelUrl" HeaderText="目录路径">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ModelFatherName" HeaderText="上级目录">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                   <asp:BoundField DataField="ModelNum" HeaderText="排序">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                            <a href='ModelUpd.aspx?Model=<%# Eval("ModelId")%>&keepThis=true&TB_iframe=true&height=300&width=500'  class="fLink thickbox">
                                            修改</a>  
                                          <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("ModelId") %>' runat="server"
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
                            <asp:LinkButton ID="btnGo" runat="server" 
           causesvalidation="False" commandargument="-1"                              CommandName="Page" Text="GO" />
                        </PagerTemplate>
                    </asp:GridView>
        </div>
    </div>
    </div>
    </form>
</body>
</html>