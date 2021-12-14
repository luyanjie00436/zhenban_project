<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyPeriodNotes.aspx.cs" Inherits="HumanManage_Web.ApplyPeriodNotes" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >学时申报记录</div></div></div>
            <div>
                <br />
            </div>
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
                            <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入用户姓名 例如（张三）" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                         <td width="10%" align="right">
                                <strong>年份：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:DropDownList ID="DlYear" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请年份" CssClass="select1" Width="80px">
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
                              
                            </td>
                      
                          <td>
                                <asp:Button ID="Button1" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行查找" CssClass="btn" OnClick="Button1_Click" Text="查 找" />
                             </td>
                    </tr>
                </table>
                            <br />
                            <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" 
                              ShowHeaderWhenEmpty="True"  AllowSorting="True" AutoGenerateColumns="False"
                                 Width="98%" >
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                      <asp:TemplateField HeaderText="编号" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemTemplate>
                                            <asp:Label ID="LEducationId" runat="server" Text='<%# Bind("bianhao") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年份" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelReportDate" runat="server" Text='<%# Bind("Year") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="工号">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%--普通显示模版--%>
                                            <asp:Label ID="LabelUserCardId" runat="server" Text='<%# Bind("UserCardId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="姓名">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%--普通显示模版--%>
                                            <asp:Label ID="LabelUserName" runat="server" Text='<%# Bind("UserName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="年度总申报学时">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="LabelDeclarePeriod" runat="server" Text='<%# Bind("sumDP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年度总核定学时">
                                        <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="LabelInspectPeriod" runat="server" Text='<%# Bind("sumIP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <div class="link02">
                                             <a href="ApplyPeriodItem.aspx?userCardId=<%# Eval("UserCardId")%>&Year=<%# Eval("Year")%>" target="_blank">查看详情</a>
                                                 <a href="ApplyPeriodManage.aspx?userCardId=<%# Eval("UserCardId")%>&Year=<%# Eval("Year")%>">修改</a>
                                               <%-- <a href="?userCardId=<%# Eval("UserCardId")%>&Year=<%# Eval("Year")%>" target="_blank">删除</a>--%>
                                             <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("bianhao")%> ' runat="server" OnCommand="LinkButton9_Command">删除</asp:LinkButton>
                                                 </div>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
