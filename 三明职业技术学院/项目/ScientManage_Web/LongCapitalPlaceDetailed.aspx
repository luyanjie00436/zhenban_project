<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalPlaceDetailed.aspx.cs" Inherits="ScientManage_Web2.LongCapitalPlaceDetailed" %>

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
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >经费到位表</div></div></div><br />
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
            <ContentTemplate>
                <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr13">
                        <td align="center" valign="middle">
                            您已经添加的经费到位信息如下
                        </td>
                    </tr>
                </table>
                <div style="margin: 5px 0px 0px 0px; text-align: center;">
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AutoGenerateColumns="False" Width="98%">
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