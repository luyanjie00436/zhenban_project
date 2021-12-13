<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortCapitalPlanAdd.aspx.cs" Inherits="ningdeScientManage_Web.ShortCapitalPlanAdd" %>

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
            width: 10%;
        }
        .auto-style6 {
            height: 30px;
            width: 10%;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >经费预算</div></div></div><br />
        <div class="page_main01">

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       
                           <tr>
                           
                              <td align="right" class="auto-style5">
                                  <strong>合同编号:</strong>
                              </td>
                            <td width="12%" align="left">
                                 <asp:Label ID="LContractId" runat="server" ></asp:Label>
                                <asp:Label ID="LProjectsId" runat="server"  Visible="false"></asp:Label>
                                  </td>
                              </tr>
                               <tr>
                                   <td align="right" class="auto-style5"><strong>合同名称:</strong> </td>
                                   <td align="left" width="12%">
                                   <asp:Label ID="LContractName" runat="server"></asp:Label>
                                         </td>
                                   </tr>
                                   <tr>
                                       <td align="right" class="auto-style5"><strong>合作单位:</strong> </td>
                                       <td align="left" width="12%">
                                       <asp:Label ID="LCompany" runat="server"></asp:Label>
                                              </td>
                                      
                                   </tr>
                          <tr>
                                       <td align="right" class="auto-style5"><strong>合同金额:</strong> </td>
                                       <td align="left" width="12%">
                                       <asp:Label ID="LContractMoney" runat="server"></asp:Label>
                                              </td>
                                      
                                   </tr>
                                   <tr>
                                       <td align="right" class="auto-style5"><strong>中标金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:Label ID="LBidMoney" runat="server"></asp:Label>
                                             </td>
                                       </tr>
                                      <tr>
                                       <td align="right" class="auto-style6"><strong>配套金额:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                           <asp:Label ID="LSupportMoney" runat="server"></asp:Label>
                                         
                                       </td>
                                       </tr>
                                         <tr>
                                       <td align="right" class="auto-style5"><strong>其他资助金额:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:Label ID="LOtherMoney" runat="server"></asp:Label>
                                       </td>
                                       </tr>
                                       <tr>
                                       <td align="right" class="auto-style5"><strong>经费下达单位:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:Label ID="LSuedCompany" runat="server"></asp:Label>
                                            </td>
                                       </tr>
                                        <tr>
                                       <td align="right" class="auto-style5"><strong>经费使用期限:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:Label ID="LServicelife" runat="server"></asp:Label>
                                          </td>
                                       </tr>
                         <tr>
                                       <td align="right" class="auto-style5"><strong>总经费:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:Label ID="LSumMoney" runat="server"></asp:Label>
                                          </td>
                                       </tr>
                         <td align="right" class="auto-style5">
                            <strong>模板：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                              <asp:DropDownList ID="DlCategory" CssClass="select1" runat="server">
                             <asp:ListItem Value="0">请选择</asp:ListItem>
                             </asp:DropDownList>    
                            &nbsp;&nbsp;&nbsp;        
                            <asp:LinkButton runat="server" ForeColor="Blue" ID="LinkButton1" Text="下载模板" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </td>
                                          <tr>
                        <td align="right" class="auto-style5">
                            <strong>  上传经费预算文件：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend"  CssClass="select1" runat="server" Width="203px" />
                          
                                     <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
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
              
        </div>
    </div>
    </form>
</body>
</html>