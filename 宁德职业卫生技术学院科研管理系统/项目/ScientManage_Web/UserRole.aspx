<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="ningdeScientManage_Web.UserRole" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style>
        .left {
        width:10%;
        text-align:right
        }
        .right {
        width:20%;
        text-align:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div class="min_height">
         <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >用户职务管理</div></div></div><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page_main01">
        <div style="margin-top: 10px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                     <td class="left"> <strong>工号：</strong></td>
                     <td class="right"><asp:TextBox ID="txtUserCardId" Enabled="false" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                       </td>            
                                    
                    
                     <td class="left"> <strong>所属系(部)：</strong></td>
                           <td class="right">
                                    <asp:DropDownList ID="DlDepartment" Height="27px"  runat="server" CssClass="select1" >
                                </asp:DropDownList>
                            </td>
                         <td class="left"> <strong>行政职务：</strong></td>
                            <td class="right">
                                  <asp:DropDownList ID="DlRole" Height="27px"  runat="server" CssClass="select1" >
                                </asp:DropDownList>
                                 </td>
                         <td class="left"> <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />
                   <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" Visible="False" />
                        </td>
                    </tr>
                </table>
                    <br>
                    <br>
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong"  Width="98%" AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="10">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                              <asp:BoundField DataField="UserName" HeaderText="用户姓名">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                         
                            <asp:BoundField DataField="DepartmentName" HeaderText="所属系(部)">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoleName" HeaderText="行政职务">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                          <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("UserRoleId") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("UserRoleId") %>' runat="server"
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