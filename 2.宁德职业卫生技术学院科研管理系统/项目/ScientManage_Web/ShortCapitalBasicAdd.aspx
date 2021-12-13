<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortCapitalBasicAdd.aspx.cs" Inherits="ningdeScientManage_Web.ShortCapitalBasicAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style4 {
            height: 30px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   > 经费基础信息设置</div></div></div><br />
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       
                          <tr>
                           
                              <td width="12%" align="right">
                                  <strong>合同编号:</strong>
                              </td>
                            <td width="12%" align="left">
                                 <asp:Label ID="LContractId" runat="server" ></asp:Label>
                                <asp:Label ID="LProjectsId" runat="server"  Visible="false"></asp:Label>
                                  </td>
                              </tr>
                               <tr>
                                   <td align="right" width="12%"><strong>合同名称:</strong> </td>
                                   <td align="left" width="12%">
                                   <asp:Label ID="LContractName" runat="server"></asp:Label>
                                         </td>
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>合作单位:</strong> </td>
                                       <td align="left" width="12%">
                                       <asp:Label ID="LCompany" runat="server"></asp:Label>
                                              </td>
                                      
                                   </tr>
                          <tr>
                                       <td align="right" width="12%"><strong>合同金额:</strong> </td>
                                       <td align="left" width="12%">
                                       <asp:Label ID="LContractMoney" runat="server"></asp:Label>
                                              </td>
                                      
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>中标金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtBidMoney" runat="server"   CssClass="select1" TextMode="Number"></asp:TextBox>
                                       </td>
                                       </tr>
                                      <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>配套金额:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                             <asp:TextBox ID="txtSupportMoney" runat="server"  CssClass="select1" TextMode="Number"></asp:TextBox>
                                    
                                       </td>
                                       </tr>
                                         <tr>
                                       <td align="right" width="12%"><strong>其他资助金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtOtherMoney" runat="server" CssClass="select1" TextMode="Number"></asp:TextBox>
                                       </td>
                                       </tr>
                                       <tr>
                                       <td align="right" width="12%"><strong>经费下达单位:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtSuedCompany" runat="server" CssClass="select1"></asp:TextBox>
                                       </td>
                                       </tr>
                                        <tr>
                                       <td align="right" width="12%"><strong>经费使用期限:</strong> </td>
                                       <td align="left" width="12%">
                                          <input id="txtServicelife" onfocus="WdatePicker()" runat="server" class="select1" cssclass="Wdate"  /> 
                                        </td>
                                       </tr>
                                         
                                    
                                       <tr class="tr10">
                                          
                                           <td align="right">
                                                 </td>
                                           <td align="left">
                                               <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保 存" />
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