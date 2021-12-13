<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchManage.aspx.cs" Inherits="ScientManage_Web2.ResearchManage" %>

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
            width: 2%;
        }
        .auto-style5 {
            width: 3%;
        }
        .auto-style6 {
            width: 2%;
            height: 30px;
        }
        .auto-style7 {
            width: 3%;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

 <div class="min_height">
              <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >科研分值管理</div></div></div><br />


    <div class="page_main01">
        <div style="margin-top: 10px">

                      <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style4">
                            <strong>内容：</strong>
                        </td>
                        <td align="left" class="auto-style5">
                            <asp:DropDownList ID="DLContent" runat="server" CssClass="select1" AutoPostBack="True"  Height="25px" Width="150px" OnSelectedIndexChanged="DLContent_SelectedIndexChanged">
                              <asp:ListItem Value="0">请选择</asp:ListItem>
                            </asp:DropDownList>
                              
                              <a href="ResearchContentAdd.aspx?Rank=1&Father=0&keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox" style="  
   width:150px; height:50px;  border:1px solid #989898; color:#fff; background:#542e6a;border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
>添加内容</a>

                        </td>                      
                       
                                <td align="right" class="auto-style4">
                                    <strong>类别：</strong>
                        </td>
                        <td align="left" class="auto-style5">
                            <asp:DropDownList ID="DLCategory" runat="server" AutoPostBack="True"  CssClass="select1" Width="150px" Height="25px" OnSelectedIndexChanged="DLCategory_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                          
                              <a runat="server" id="AButton2" class="fLink thickbox" style="  
   width:150px; height:50px;  border:1px solid #989898; color:#fff; background:#542e6a;border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
>添加类别</a>
                                </td>
                      
                                <td align="left" class="auto-style6">
                                     <a runat="server" id="AButton3" class="fLink thickbox" style="  
   width:150px; height:50px;  border:1px solid #989898; color:#fff; background:#542e6a;border-radius:13px; margin-right:20px; text-align:center;  line-height:30px; padding:6px 15px 6px 15px; "
>添加级别</a>
                        </td>
                       
                          
                       
                        
                             
                            
                             
                          </tr>
                </table>

                    <br />
                    <br />
                     <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                         <Columns>
                             <asp:BoundField DataField="WorkCategoryId" HeaderText="编号">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                           <asp:BoundField DataField="WorkCategoryName" HeaderText="名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                              
                               <asp:BoundField DataField="WorkValue" HeaderText="分值">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                              <asp:BoundField DataField="b_Name" HeaderText="上级名称">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                          <a href='ResearchInformationUpd.aspx?CategoryId=<%# Eval("WorkCategoryId")%>&keepThis=true&TB_iframe=true&height=300&width=500
'  class="fLink thickbox"> 修改</a>  
                                    <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("WorkCategoryId") %>'>删除</asp:LinkButton>
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
              
    </div>
    </form>
</body>
</html>
