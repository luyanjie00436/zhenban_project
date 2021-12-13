<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalPlaceAdd.aspx.cs" Inherits="ScientManage_Web2.LongCapitalPlaceAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >经费到位</div></div></div><br />
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
            <ContentTemplate>
                <div style="margin-bottom: 10px">
                    <table class="bgcolor" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                               <td  align="right">
                                项目名称
                            </td>
                            <td>
                               <asp:Label ID="LProjectsName" runat="server"></asp:Label>
                                <asp:Label ID="LProjectsId" runat="server" Visible="false"></asp:Label>
                            </td>
                                
                            <td  align="right">
                                到位金额
                            </td>
                            <td>
                                <asp:TextBox ID="txtPlaceMoney" runat="server" CssClass="select1"></asp:TextBox>
                            </td>
                                 <td align="left">
                                <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />
                            </td>
                       </tr>
                        <tr>
                            <td  align="right">
                                到位时间
                            </td>
                            <td>
                                 <input id="txtPlaceDate" runat="server" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1">
                            </td>
                             <td  align="right">
                               到位说明
                            </td>
                            <td>
                                <asp:TextBox ID="txtPlaceExplain" runat="server" CssClass="select1" Width="197px"></asp:TextBox>
                            </td>
                           
                            <td align="left">
                                <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                </div>

             
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr13">
                        <td align="center" valign="middle">
                            您已经添加的经费到位信息如下
                        </td>
                    </tr>
                </table>
                <div style="margin: 5px 0px 0px 0px; text-align: center;">
                    <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AutoGenerateColumns="False" Width="98%">
                        <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                            <asp:BoundField DataField="PlaceMoney" HeaderText="到位金额">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PlaceDate" HeaderText="到位时间">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>   
                             <asp:BoundField DataField="PlaceExplain" HeaderText="到位说明">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                           
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="link02">
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("LongCapitalPlaceId") %>'
                                            OnCommand="LinkButton6_Command">编辑</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("LongCapitalPlaceId") %>'
                                            OnClientClick="return confirm(&quot;你确定删除吗？&quot;);" OnCommand="LinkButton7_Command">删除</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
         <table width="100%">
                   <tr>
                       <td  align="right" width="80%">
                                总金额:
                            </td>
                            <td>
                             <asp:TextBox ID="txtSumMoney" runat="server" Enabled="false" CssClass="select1"></asp:TextBox>
                            </td>
                   </tr>
               </table>
                
              
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>
    </form>
</body>
</html>
