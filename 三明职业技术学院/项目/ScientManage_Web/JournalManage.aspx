<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalManage.aspx.cs" Inherits="sanmingScientManage_Web.JournalManage" %>

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
                          <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >日志查看</div></div></div><br />

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
                            <asp:TextBox ID="txtUserName" runat="server"  CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                        
                         <td width="10%" align="right">
                                <strong>操作时间：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:DropDownList ID="DlYear" runat="server" CssClass="select1" Width="80px">
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
                               <asp:DropDownList ID="DlMonth" runat="server" CssClass="select1" Width="80px">
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
                                                             <asp:DropDownList ID="DLDay" runat="server" CssClass="select1" Width="80px">
                               <asp:ListItem Value="0">选择日期</asp:ListItem>
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
                                       <asp:ListItem Value="13">13</asp:ListItem>
                                       <asp:ListItem Value="14">14</asp:ListItem>
                                       <asp:ListItem Value="15">15</asp:ListItem>
                                       <asp:ListItem Value="16">16</asp:ListItem>
                                       <asp:ListItem Value="17">17</asp:ListItem>
                                       <asp:ListItem Value="18">18</asp:ListItem>
                                       <asp:ListItem Value="19">19</asp:ListItem>
                                       <asp:ListItem Value="20">20</asp:ListItem>
                                       <asp:ListItem Value="21">21</asp:ListItem>
                                       <asp:ListItem Value="22">22</asp:ListItem>
                                       <asp:ListItem Value="23">23</asp:ListItem>
                                       <asp:ListItem Value="24">24</asp:ListItem>
                                       <asp:ListItem Value="25">25</asp:ListItem>
                                       <asp:ListItem Value="26">26</asp:ListItem>
                                       <asp:ListItem Value="27">27</asp:ListItem>
                                       <asp:ListItem Value="28">28</asp:ListItem>
                                       <asp:ListItem Value="29">29</asp:ListItem>
                                       <asp:ListItem Value="30">30</asp:ListItem>
                                       <asp:ListItem Value="31">31</asp:ListItem>

                                      </asp:DropDownList>日
                            </td>
                       <td width="10%" align="right">
                                <strong>操作位置：</strong>
                            </td>
                         <td width="10%" align="left">
                            <asp:TextBox ID="TextBox1" runat="server"  CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                           
                    </tr>
                           <tr>
                               <td width="10%" align="right">
                                <strong>操作内容：</strong>
                            </td>
                         <td width="10%" align="left">
                            <asp:TextBox ID="TextBox2" runat="server"  CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                          <td align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="查 找" />
                             </td>
                           </tr>
                </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong"  runat="server" AllowPaging="True" AllowSorting="True"
                      ShowHeaderWhenEmpty="true"     OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="20" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="UserCardId" HeaderText="工号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="FollDate" HeaderText="操作时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                <asp:BoundField DataField="Position" HeaderText="操作位置">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                <asp:BoundField DataField="Events" HeaderText="操作内容">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                                
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