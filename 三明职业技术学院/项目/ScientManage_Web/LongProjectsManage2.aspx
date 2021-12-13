<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsManage2.aspx.cs" Inherits="ScientManage_Web.LongProjectsManage" %>

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
           <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >纵向项目情况</div></div></div><br />

    <div class="page_main01">
        <div style="margin-top: 10px">

                    <table class="bgcolor"  border="0" cellspacing="0" cellpadding="0">
                    <tr>
                         <td  align="right">
                               <strong>项目编号：</strong>

                         </td>
                        <td>
                            <asp:TextBox ID="txtProjectsId" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                          <td  align="right">
                           
                              <strong>项目名称：</strong>
                          </td>
                        <td  align="left">
                           <asp:TextBox ID="txtProjectsName" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>

                        </td>
                          <td align="right">
                              <strong>负责人：</strong>
                                  </td>
                       <td>
                              <asp:TextBox ID="txtUserName" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                  
                              <td  align="right">
                                <strong>所属系部：</strong>
                            </td>
                            <td align="left">
                                 <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1" Width="137px">
                               <asp:ListItem Value="0">选择系(部)</asp:ListItem>
                                      </asp:DropDownList>
                            </td>

                         <td align="right">
                       <strong>类别：</strong> 
                     </td>
                        <td>
                 <asp:DropDownList ID="DLSubject" runat="server" CssClass="select1" Width="137px">
                               <asp:ListItem Value="0">选择类别</asp:ListItem>
             </asp:DropDownList>
                        </td>
                        
                       
                          
                           </tr>
                        <tr>
                            
                              
                
                          <td  align="right">
                            <strong>级别：</strong>
                        </td>
                        <td  align="left">
                            <asp:DropDownList ID="DLLevel" runat="server" CssClass="select1" Width="137px">
                                <asp:ListItem Value="0">选择级别</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                          <td  align="right">
                            <strong>来源：</strong>
                        </td>
                        <td>
                 <asp:DropDownList ID="DLFrom" runat="server" CssClass="select1" Width="137px">
                               <asp:ListItem Value="0">选择来源</asp:ListItem>
             </asp:DropDownList>
                        </td>
                               <td align="right" class="auto-style4">
                                <strong>项目申报时间：</strong>
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
                              
                            </td>
                             <td  align="right">
                                <strong>申请年份：</strong>
                            </td>
                            <td  align="left">
                         <asp:DropDownList ID="DLApply" runat="server" CssClass="select1" Width="137px">
                               <asp:ListItem Value="0">选择时间</asp:ListItem>
                                      </asp:DropDownList>
                              
                            </td>

                             <td align="right">
                                                             <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="查 找" />

                               </td>
                        <td>

                            &nbsp;</td>
   <td align="right">
                                &nbsp;</td>
                        <td>

                            &nbsp;</td>
                        </tr>                       
                      
                        </table>
                 
                    <br />
           <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" 
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                             <asp:BoundField DataField="项目编号" HeaderText="项目编号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                              <asp:BoundField DataField="新项目编号" HeaderText="新项目编号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="项目名称" HeaderText="项目名称">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            
                             <asp:BoundField DataField="项目类别" HeaderText="项目类别">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                              
                            <asp:BoundField DataField="项目级别" HeaderText="项目级别">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>   
                              <asp:BoundField DataField="项目来源" HeaderText="项目来源">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>   
                            <asp:BoundField DataField="负责人" HeaderText="负责人">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="所属系部" HeaderText="所属系部">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="项目申报时间" HeaderText="项目申报时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="申报年份" HeaderText="申报年份">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                               <asp:BoundField DataField="协作单位" HeaderText="协作单位">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="申报状态">
                                    <ItemTemplate>
                                        <asp:Label ID="LDeclareStatus" runat="server" Text='<%# Eval("申报状态") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridview_HeaderStyle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="立项状态">
                                    <ItemTemplate>
                                        <asp:Label ID="LStandStatus" runat="server" Text='<%# Eval("立项状态") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridview_HeaderStyle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="中检状态">
                                    <ItemTemplate>
                                        <asp:Label ID="LInspectStatus" runat="server" Text='<%# Eval("中检状态") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridview_HeaderStyle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="结题状态">
                                    <ItemTemplate>
                                        <asp:Label ID="LEndStatus" runat="server" Text='<%# Eval("结题状态") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridview_HeaderStyle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                         <asp:LinkButton ID="LinkButton6" runat="server" Visible="false" OnCommand="LinkButton6_Command" CommandArgument='<%# Eval("项目编号") %>'>申报详情</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton7" runat="server" Visible="false" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("项目编号") %>'>立项详情</asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton8" runat="server" Visible="false" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("项目编号") %>'>中检详情</asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton9" runat="server"   OnCommand="LinkButton9_Command" CommandArgument='<%# Eval("项目编号") %>'>跳过中检</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server"   OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("项目编号") %>'>中检重置</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="str001" />
                        <PagerTemplate>
                            当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件
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

        </div>
    </div>
     </form>
</body>
</html>