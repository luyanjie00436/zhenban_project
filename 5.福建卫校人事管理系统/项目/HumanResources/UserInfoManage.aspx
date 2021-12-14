<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoManage.aspx.cs" Inherits="HumanManage_Web.UserInfoManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
          <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
     <script>
         $(function () { $("[data-toggle='tooltip']").tooltip(); });

        </script>
    <style type="text/css">
        .auto-style1 {
            width: 11%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >教职工基础信息管理</div></div></div>

    <div class="page_main01">
        <div style="margin-top: 10px">
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="10%" align="right">
                            <strong>用户姓名：</strong>
                        </td>
                        <td align="left" class="auto-style1">
                            <asp:TextBox ID="txtUserName" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入用户姓名 例如（张三）" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                     
                   
                          <td width="10%" align="right">
                                <strong>在职：</strong>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DlStatus" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择在职" runat="server" CssClass="select1" Width="80%">
                                <asp:ListItem Value="0">选择在职</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                         <td width="10%" align="right">
                            <strong>年龄段：</strong>
                        </td>
                        <td align="left" class="auto-style1">
                            <asp:TextBox ID="txtStartYear" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入最小年龄段 例如（20）" Height="27px" CssClass="select1" Width="37px" TextMode="Number"></asp:TextBox>~
                            <asp:TextBox ID="txtEndYear" runat="server" Height="27px" CssClass="select1" Width="37px" data-toggle="tooltip" data-placement="top"  ToolTip="请输入最大年龄段 例如（60）" TextMode="Number"></asp:TextBox>
                        </td>
                        <td width="10%" align="right">
                                <strong>性别：</strong>
                            </td>
                            <td width="10%" align="left">
                               <asp:DropDownList ID="DlGender" data-toggle="tooltip" data-placement="top"  ToolTip="请选择性别" runat="server" CssClass="select1" Width="80%">
                                    <asp:ListItem >请选择</asp:ListItem>
                                   <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                         
                         </tr>
                    <tr>
                        
                            <td width="10%" align="right">
                                <strong>政治面貌：</strong>
                            </td>
                            <td width="10%" align="left">
                               <asp:DropDownList ID="DlPolitical" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择政治面貌" runat="server" CssClass="select1" Width="80%">
                               <asp:ListItem Value="0">选择政治面貌</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>

                        <td>                    <a href="UserInfoAdd.aspx"  data-toggle="tooltip" data-placement="top"  title="点击添加进入用户添加页面" style="  
   width:150px; height:50px; border:1px solid #000; border-radius:13px; margin-right:20px; text-align:right;  line-height:30px; padding:6px 15px 6px 15px; "
>添 加</a>
</td>
                        <td style="text-align:left ;">  <asp:Button ID="Button1" runat="server" Text="查 找" data-toggle="tooltip" data-placement="top"  ToolTip="点击查找" OnClick="Button1_Click" CssClass="btn" /></td>
  <td style="text-align:left ;">  <asp:Button ID="Button2" runat="server" Text="信息锁定" hei data-toggle="tooltip" data-placement="top"  ToolTip="点击锁定所有人员信息" OnClick="Button2_Click" CssClass="btn" /></td>

                      
                    </tr>
                </table>
                    <br> 
    
                    <br>
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                             <asp:BoundField DataField="工号" HeaderText="工号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="姓名" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                         
                             <asp:BoundField DataField="性别" HeaderText="性别">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="政治面貌" HeaderText="政治面貌">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="在职状态" HeaderText="在职状态">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="出生年月" HeaderText="出生日期">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="年龄" HeaderText="年龄">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                         
                           <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <a href="UserRankManage.aspx?UserCardId=<%# Eval("工号")%>"  >权限管理</a>
                                     <a href='UserEnable.aspx?UserCardId=<%# Eval("工号")%>&keepThis=true&TB_iframe=true&height=300&width=500'  class="fLink thickbox">
                                            修改用户状态</a>  
                                                      
                                            
                                         <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("工号") %>'>修改用户信息</asp:LinkButton>
                                          <a href='OtherUpd.aspx?UserInfo=<%# Eval("工号")%>&keepThis=true&TB_iframe=true&height=400&width=500'  class="fLink thickbox xg ">
                                            修改其他信息</a>  
                                         <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton9_Command" CommandArgument='<%# Eval("工号") %>'>导出</asp:LinkButton>
                                       
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

