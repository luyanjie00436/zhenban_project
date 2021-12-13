<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HarvestAdd.aspx.cs" Inherits="ningdeScientManage_Web.HarvestAdd" %>

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
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
     <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >科技成果添加</div></div></div><br />

        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <tr>
                           
                              <td width="12%" align="right">
                                <strong>成果申报起止时间:</strong>
                                
                              </td>
                            <td width="12%" align="left">
                                <asp:label  runat="server" ID="LStartDate"></asp:label>
                                至
                                 <asp:label  runat="server" ID="LEndDate"></asp:label>
                            </td>
                              </tr> 
                          <tr>
                           
                              <td width="12%" align="right">
                                <strong>年份:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtApplyYear" runat="server"  CssClass="input1" ReadOnly="True"></asp:TextBox>
                            </td>
                               <tr>
                                   <td align="right" width="12%"><strong>填报日期:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:TextBox ID="txtFollDate" runat="server" CssClass="input1" ReadOnly="True"></asp:TextBox>
                                   </td>
                                   
                                <tr>
                                   <td align="right" width="12%"><strong>类别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLCategory" runat="server" CssClass="input1" AutoPostBack="True"  Width="200px" Height="25px" OnSelectedIndexChanged="DLCategory_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                                          </td>
                                 </tr>
                             <tr>
                                   <td align="right" width="12%"><strong>级别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLLevel" runat="server" CssClass="input1" AutoPostBack="True"  Width="200px" Height="25px" OnSelectedIndexChanged="DLLevel_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                                          </td>
                                   </tr>
                                     <tr>
                                       <td align="right" width="12%"><strong>成果负责人:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtUserName" runat="server"  CssClass="input1"  ReadOnly="true"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>成果名称:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtHarvestName" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>鉴定水平:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtAppraisalLevel" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       <tr>
                                           <td align="right" width="12%"><strong>发奖日期:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtAwardsDate" onfocus="WdatePicker()" runat="server" CssClass="input1"></asp:TextBox>
                                           </td>
                                       </tr>
                                               <tr>
                                           <td align="right" width="12%"><strong>备注:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1"></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td align="right" width="12%"><strong>成果分值:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtHarvestValue" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td align="right" width="12%"><strong>本人排名:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:DropDownList ID="DlPartnerRank" CssClass="input1" runat="server"  Width="140px">
                                                   <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                                   <asp:ListItem Value="1">1</asp:ListItem>
                                                   <asp:ListItem Value="2">2</asp:ListItem>
                                                   <asp:ListItem Value="3">3</asp:ListItem>
                                                   <asp:ListItem Value="4">4</asp:ListItem>
                                                   <asp:ListItem Value="5">5</asp:ListItem>
                                                   <asp:ListItem Value="6">6</asp:ListItem>
                                                   <asp:ListItem Value="7">7</asp:ListItem>
                                                   <asp:ListItem Value="8">8</asp:ListItem>
                                                   <asp:ListItem Value="9">9</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td align="right" width="12%"><strong>本人得分:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtPartnerValue" runat="server" CssClass="input1"></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr class="tr10">
                                          
                                           <td align="right">
                                               <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="添 加" />
                                           </td>
                                           <td align="left">
                                               <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保 存" />
                                           </td>
                                       </tr>
                                   </tr>
                              </tr>
                             
                               </tr>  
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>