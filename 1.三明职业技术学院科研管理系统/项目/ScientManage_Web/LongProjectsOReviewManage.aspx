<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsOReviewManage.aspx.cs" Inherits="ScientManage_Web2.LongProjectsOReviewManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <style type="text/css">
    <style>

         .btn10 { width:120px; height:34px; line-height:34px; display:inline-block; text-align:center; color:#404040; background:url(../images/btn003.gif) no-repeat;  background-size: cover; font-weight:bold; border:none; cursor:pointer; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
         <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >纵向其他项目管理</div></div></div><br />

     <br />
      <div class="page_main01">
           <div style="margin-top: 10px">
               <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td> <asp:LinkButton ID="LinkButton3"  runat="server" CssClass="btn_right"   OnClick="LinkButton3_Click">其他项目添加</asp:LinkButton></td>
                        <td align="right" class="auto-style5">
                            <strong>备注：</strong>
                        </td>
                        <td width="10%" align="left">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                          <td align="left">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="查 找" />
                          </td>
                    </tr>
                </table>
                </div>
         </div>
     <br />
    <div class="page_main01">
        <div style="margin-top: 10px">

                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                      ShowHeaderWhenEmpty="true"   OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                       <AlternatingRowStyle BackColor="#bfbdbd" />
                         <Columns>                             
                              <asp:BoundField DataField="OReviewId" HeaderText="其他项目编号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                 <asp:BoundField DataField="Starttime" HeaderText="开始时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Endtime" HeaderText="结束时间">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Remarks" HeaderText="备注">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                  <asp:BoundField DataField="countNum" HeaderText="评审人数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                  <asp:BoundField DataField="SumNum" HeaderText="评审总分">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                  <asp:BoundField DataField="avgNum" HeaderText="平均分">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                           <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                      <asp:LinkButton ID="LinkButton6" runat="server" OnCommand="LinkButton6_Command" CommandArgument='<%# Eval("OReviewId") %>'>查看详情</asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Command" CommandArgument='<%# Eval("OReviewId") %>'>修改</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton9" CommandArgument='<%# Eval("OReviewId") %>' runat="server" OnCommand="LinkButton9_Command">删除</asp:LinkButton>
                                 
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
