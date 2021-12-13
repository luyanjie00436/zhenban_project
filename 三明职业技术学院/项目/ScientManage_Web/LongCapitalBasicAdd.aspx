<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalBasicAdd.aspx.cs" Inherits="ScientManage_Web2.LongCapitalBasicAdd" %>

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
        .auto-style5 {
            width: 9%;
        }
        .auto-style6 {
            height: 30px;
            width: 9%;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
              <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >经费基础信息设置</div></div></div><br />
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       
                          <tr>
                           
                              <td align="right" class="auto-style5">
                                <strong>项目编号:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LProjectsId" runat="server" ></asp:Label>
                                  </td>
                              </tr>
                               <tr>
                                   <td align="right" class="auto-style5"><strong>项目名称:</strong> </td>
                                   <td align="left" width="12%">
                                   <asp:Label ID="LProjectsName" runat="server"></asp:Label>
                                         </td>
                                   </tr>
                                   <tr>
                                       <td align="right" class="auto-style5"><strong>项目来源:</strong> </td>
                                       <td align="left" width="12%">
                                       <asp:Label ID="LProjectsFromExplain" runat="server"></asp:Label>
                                              </td>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td align="right" class="auto-style5"><strong>中标金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtBidMoney" runat="server"   CssClass="select1" TextMode="Number"></asp:TextBox>
                                       </td>
                                       </tr>
                                      <tr>
                                       <td align="right" class="auto-style6"><strong>配套金额:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                             <asp:TextBox ID="txtSupportMoney" runat="server"  CssClass="select1" TextMode="Number"></asp:TextBox>
                                    
                                       </td>
                                       </tr>
                                         <tr>
                                       <td align="right" class="auto-style5"><strong>其他资助金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtOtherMoney" runat="server" CssClass="select1" TextMode="Number"></asp:TextBox>
                                       </td>
                                       </tr>
                                       <tr>
                                       <td align="right" class="auto-style5"><strong>经费下达单位:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:DropDownList ID="DLFrom" height="30px" CssClass="select1" Width="137px" runat="server"></asp:DropDownList>
                                           <%--<asp:TextBox ID="txtSuedCompany" runat="server" CssClass="select1"></asp:TextBox>--%>
                                       </td>
                                       </tr>
                                        <tr>
                                       <td align="right" class="auto-style5"><strong>经费使用期限:</strong> </td>
                                       <td align="left" width="12%">
                                          <input id="txtServicelife" onfocus="WdatePicker()" runat="server" class="select1" cssclass="Wdate"  /> 
                                        </td>
                                       </tr>
                                         
                                    
                                       <tr class="tr10">
                                          
                                           <td align="right" class="auto-style5">
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