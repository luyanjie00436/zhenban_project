<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoManage.aspx.cs" Inherits="ningdeScientManage_Web.UserInfoManage" %>

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
        .auto-style5 {
            width: 59px;
        }
        .auto-style6 {
            width: 15%;
        }
        .auto-style7 {
            width: 1%;
        }
        .auto-style8 {
            width: 5%;
        }
        .auto-style10 {
            width: 10%;
        }
        .auto-style11 {
            width: 6%;
        }
        .auto-style12 {
            width: 11%;
        }
        .auto-style13 {
            width: 97px;
        }
        .auto-style14 {
            width: 9%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
                      <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >人员信息管理</div></div></div><br />

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
                        <td align="left" class="auto-style6">
                            <asp:TextBox ID="txtUserName" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                         <td align="right" class="auto-style10">
                                <strong>所属系(部)：</strong>
                            </td>
                            <td align="left" class="auto-style7">
                                 <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="90px">
                               <asp:ListItem Value="0">选择系(部)</asp:ListItem>
                                      </asp:DropDownList>
                            </td>
                         <td align="right" class="auto-style11">
                                <strong>职称：</strong>
                            </td>
                            <td align="left" class="auto-style12">
                            <asp:DropDownList ID="DlJob" runat="server" CssClass="select1" Width="80%">
                            <asp:ListItem Value="0">选择职称</asp:ListItem>    
                            </asp:DropDownList>  </td>
                              <td align="right" class="auto-style8">
                                <strong>职级：</strong>
                            </td>
                            <td align="left" class="auto-style13">
                                <asp:DropDownList ID="DlPost" runat="server" CssClass="select1" Width="80%">
                                <asp:ListItem Value="0">选择职级</asp:ListItem>
                                </asp:DropDownList>
                                  </td>
                        <td align="right" class="auto-style14">
                                <strong>在职：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlStatus" runat="server" CssClass="select1" Width="90%">
                                <asp:ListItem Value="0">选择在职</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                    </tr>
                    <tr>
                          
                         <td width="10%" align="right">
                            <strong>年龄段：</strong>
                        </td>
                        <td align="left" class="auto-style6">
                            <asp:TextBox ID="txtStartYear" runat="server" CssClass="select1" Height="27px" Width="37px"></asp:TextBox>~
                            <asp:TextBox ID="txtEndYear" runat="server" CssClass="select1" Height="27px" Width="37px"></asp:TextBox>
                        </td>
                        <td align="right" class="auto-style10">
                                <strong>性别：</strong>
                            </td>
                            <td align="left" class="auto-style7">
                               <asp:DropDownList ID="DlGender" runat="server" CssClass="select1" Width="80%">
                                    <asp:ListItem >请选择</asp:ListItem>
                                   <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                            <td align="right" class="auto-style11">
                                <strong>政治面貌：</strong>
                            </td>
                            <td align="left" class="auto-style12">
                               <asp:DropDownList ID="DlPolitical" runat="server" CssClass="select1" Width="80%">
                               <asp:ListItem Value="0">选择政治面貌</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                         <td width="10%" align="right">
                                <strong>职务：</strong>
                            </td>
                            <td align="left" class="auto-style6">
                                <asp:DropDownList ID="DlRole" runat="server" CssClass="select1" Width="80%">
                                <asp:ListItem Value="0">选择职务</asp:ListItem>
                                </asp:DropDownList>
                             </td>   
                        <td align="right" style="text-align:right;"><a href="UserInfoAdd.aspx" style="  
   width:150px; height:50px;border:1px solid #000; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
>添 加</a></td>
                        <td align="left"><asp:Button ID="Button1" runat="server" Text="查 找" OnClick="Button1_Click" CssClass="btn" /></td>
                     
                    </tr>
                </table>
                   
                    <br>
                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                       ShowHeaderWhenEmpty="true"    OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                    
                         
                            <asp:BoundField DataField="JobName" HeaderText="职称">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                 <asp:BoundField DataField="PostName" HeaderText="职级">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="PoliticalName" HeaderText="政治面貌">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StatusName" HeaderText="在职">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BirthDay" HeaderText="出生年月">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Age" HeaderText="年龄">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <a href="UserRankManage.aspx?UserCardId=<%# Eval("UserCardId")%>"  >权限管理</a>
    
                                         <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("UserCardId") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("UserCardId") %>' OnClientClick="return confirm(&quot;删除将导致该用户所有数据清楚，是否删除？&quot;);">删除</asp:LinkButton>

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
