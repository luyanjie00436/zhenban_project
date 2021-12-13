<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachingAdd.aspx.cs" Inherits="ningdeScientManage_Web.TeachingAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
<div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >著作教材添加</div></div></div><br />
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
                               </tr>  
                           <tr>
                           
                              <td width="12%" align="right">
                                <strong>填报日期:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtFollDate" runat="server"  CssClass="input1" ReadOnly="True"></asp:TextBox>
                            </td>
                               </tr>
                             <tr>
                           
                              <td width="12%" align="right">
                                <strong>著作申请人:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtUserName" runat="server"  CssClass="input1" ReadOnly="true"></asp:TextBox>
                            </td>
                               </tr>
                             <tr>
                           
                              <td width="12%" align="right">
                                <strong>著作教材名称:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtBookName" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>


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
                                       <asp:DropDownList ID="DLLevel" runat="server" AutoPostBack="True"  CssClass="input1" Width="200px" Height="25px" OnSelectedIndexChanged="DLLevel_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                                          </td>
                                   </tr>
                      
                          
                           <tr>
                           
                              <td width="12%" align="right">
                                <strong>出版社:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtPressName" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>
                           <tr>
                              <td width="12%" align="right">
                                <strong>出版日期:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtPressDate" runat="server"  onfocus="WdatePicker()" CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>
                                  <tr>
                           
                              <td width="12%" align="right">
                                <strong>主编顺序:</strong>
                              </td>
                            <td width="12%" align="left">
                              <asp:DropDownList ID="DlEditedSequence" runat="server" Width="140px" CssClass="input1">
                                        <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                   <asp:ListItem Value="第一主编">第一主编</asp:ListItem>
                                   <asp:ListItem Value="第二主编">第二主编</asp:ListItem>
                                 <asp:ListItem Value="参编">参编</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                               </tr>
                           <tr>
                           
                              <td width="12%" align="right" class="auto-style1">
                                <strong>版次:</strong>
                              </td>
                            <td width="12%" align="left" class="auto-style1">
                                <asp:TextBox ID="txtRevision" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>
                           <tr>
                           
                              <td width="12%" align="right">
                                <strong>字数（万）:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTotalNumber" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>
                          <tr>
                              <td  align="right">
                                <strong>成果获得时间:</strong>
                              </td>
                            <td  align="left">
                                <input ID="txtTeachingDate" runat="server"  onfocus="WdatePicker()" class="input1"></input>
                            </td>
                               </tr>
                         <tr>
                           
                              <td width="12%" align="right">
                                <strong>备注:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtRemarks" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>

                           <tr>
                           
                              <td width="12%" align="right">
                                <strong>成果分值:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtTeachingValue" runat="server"  CssClass="input1" ReadOnly="true"></asp:TextBox>
                            </td>
                               </tr>
                           <tr>
                           
                              <td width="12%" align="right">
                                <strong>本人排名:</strong>
                              </td>
                            <td width="12%" align="left">
                              <asp:DropDownList ID="DlPartnerRank" runat="server" Width="140px" CssClass="input1">
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
                           
                              <td width="12%" align="right">
                                <strong>本人得分:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtPartnerValue" runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                               </tr>
                        <tr class="tr10">
                          
                            <td  align="right">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添 加" CssClass="btn" />
                            </td>
                               <td  align="left">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="保 存" CssClass="btn" />
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
