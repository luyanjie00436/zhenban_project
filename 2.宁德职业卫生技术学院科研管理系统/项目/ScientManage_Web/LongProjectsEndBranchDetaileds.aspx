<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsEndBranchDetaileds.aspx.cs" Inherits="ningdeScientManage_Web.LongProjectsEndBranchDetaileds" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        Table
        {
         border-collapse: collapse;
         width:1024px;
         margin-top:-1px;
            }
        .td1
        {
            width:133px;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }

        .td2
        {
            width:133px;
            text-align:center;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }
       
        .td4
        {
            width:100px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            line-height:24px;
            }
        .td5
        {
           width:80px;
            height:24px;
            line-height:24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            text-align:right;
            border-bottom:1px solid #000000;
           
            }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目结题评审详细表</div></div></div><br />

        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td class="btn_left1">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn11" />
                </td>
            </tr>
        </table>
  
                    <div style="width:1024px;height:297mm;margin:0 auto">
                    <div>
                  <table  class="bgcolor"  >
           

              <tr>
                  <td class="td3" colspan="8">
                      详细列表</td>
              </tr>
          </table>
                    </div>
                        <div>
                           <table class="bgcolor"  style="margin-left:-1px">
                               <tr>
                                   <td align="right">项目编号：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsId"></asp:Label> </td>
                                   <td align="right">项目名称：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsName"></asp:Label></td>
                                   
                               </tr>
                               <tr>
                                   <td align="right">项目类别：</td>
                                   <td><asp:Label runat="server" ID="LProjectsSubject"></asp:Label> </td>
                                   <td align="right">项目级别：</td>
                                   <td> <asp:Label runat="server" ID="LProjectsLevel"></asp:Label></td>
                                  
                               </tr>
                         <tr>
                              <td  align="right">
                                  项目来源：</td>
                            
                         <td class="td5" style="text-align:left" >
                                  <asp:Label ID="LProjectsFrom" runat="server" ></asp:Label>
                              </td>
                                <td class="td5"  style="text-align:right"  >
                                  协作单位：</td>
                                
                                 <td class="td5"  style="text-align:left">
                                  <asp:Label ID="LCompany" runat="server" ></asp:Label>
                              </td>
                           
                          
                          </tr>
                               <tr>
                               <td align="right">

                                  研究内容摘要：

                               </td>
                               <td colspan="3"  align="left">
                                   <asp:Label ID="LProjectsContent" runat="server" ></asp:Label>
                                      </td>
                                </tr>


                          <tr>
                              
                              <td class="td5" align="right">
                                  评审附件：</td>
                               <td class="td5" style="text-align:left" >
                                  <asp:Label ID="LFileUrl" runat="server" Visible="false" ></asp:Label>
                                   <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" Id="LinkButton1" OnClick="LinkButton1_Click"></asp:LinkButton>
                              </td>
                          </tr>
                        
                      </table>
                             <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False"
                        PageSize="10" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="98%">
                                 <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                             <asp:BoundField DataField="UserCardId" HeaderText="工号">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                              <asp:BoundField DataField="UserName" HeaderText="姓名">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="DepartmentName" HeaderText="部门">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="Branch" HeaderText="分数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                             <asp:BoundField DataField="Opinion" HeaderText="审批意见">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                         <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("url") %>' runat="server"
                                         OnCommand="LinkButton2_Command">附件下载</asp:LinkButton>
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
                     

                    
                            </div>
                        </div>
        </div>
    </div>
    </form>
</body>
</html>