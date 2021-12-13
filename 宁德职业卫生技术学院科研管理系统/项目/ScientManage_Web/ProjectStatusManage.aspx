<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectStatusManage.aspx.cs" Inherits="ningdeScientManage_Web.ProjectStatusManage" %>

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
          <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目情况记录表</div></div></div><br />
    <div class="page_main01">
        <div style="margin-top: 10px">
      
                      <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="10%" align="right">
                            <strong>申请人：</strong>
                        </td>
                        <td width="10%" align="left">
                            <asp:TextBox ID="txtUserName" CssClass="select1" runat="server" Height="27px" Width="137px" ToolTip="输入申请人"></asp:TextBox>
                        </td>
                         <td width="6%" align="right">
                                <strong>所属系部：</strong>
                            </td>
                            <td width="10%" align="left">
                                 <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="137px" ToolTip="选择系部">
                               <asp:ListItem Value="0">选择系部</asp:ListItem>
                                      </asp:DropDownList>
                            </td>
                        <td width="10%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="10%" align="left">
                            <asp:TextBox ID="txtProjectStatusName" runat="server"  CssClass="select1"  Height="27px" Width="137px" ToolTip="输入项目名称"></asp:TextBox>
                        </td>
                         <td width="10%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="10%" align="left">
                            <asp:TextBox ID="txtSource" runat="server"  CssClass="select1" Height="27px" Width="137px" ToolTip="输入项目来源"></asp:TextBox>
                        </td>
                    </tr>
                          <tr>
                                
                        
                               <td width="10%" align="right">
                                <strong>审核状态：</strong>
                            </td>
                            <td width="10%" align="left">
                                  <asp:DropDownList ID="DlStatus" runat="server" CssClass="select1" Width="137px" ToolTip="选择审核状态">
                               <asp:ListItem Value="0">审批状态</asp:ListItem>
                                       <asp:ListItem Value="1">未审批</asp:ListItem>
                                       <asp:ListItem Value="2">审批中</asp:ListItem>
                                       <asp:ListItem Value="3">同意</asp:ListItem>
                                       <asp:ListItem Value="4">拒绝</asp:ListItem>
                                      </asp:DropDownList>
                            </td>
                              <td align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="查 找" ToolTip="点击进行查找" />
                             </td>
                               <td>
                                  <asp:Button ID="Button3" runat="server" CssClass="btn"  OnClick="Button3_Click" Text="导 出" ToolTip="数据导出到Excel" />
                              </td> 
                          </tr>
                </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" ShowHeaderWhenEmpty="true" runat="server" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <Columns>
                            <asp:BoundField DataField="姓名" HeaderText="申请人">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="所属系部" HeaderText="所属系部">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="项目名称" HeaderText="项目名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                <asp:BoundField DataField="项目来源" HeaderText="项目来源">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                <asp:BoundField DataField="审核状态" HeaderText="审核状态">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="立项时间" HeaderText="立项时间">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                   
                           
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                      <asp:LinkButton ID="LinkButton7" runat="server" 
OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("编号") %>' ToolTip="跳转到成果项目申请表">查看详情</asp:LinkButton>
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
