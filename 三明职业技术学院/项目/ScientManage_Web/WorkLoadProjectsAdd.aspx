<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkLoadProjectsAdd.aspx.cs" Inherits="sanmingScientManage_Web.WorkLoadProjectsAdd" %>

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
 <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >科研项目成果添加</div></div></div><br />

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
                                   <td align="right" width="12%"><strong>填报日期:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:TextBox ID="txtFollDate" runat="server" CssClass="input1" ReadOnly="True"></asp:TextBox>
                                   </td>
                                   </tr>
                   
                                    <tr>
                                   <td align="right" width="12%"><strong>类别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLCategory" runat="server" AutoPostBack="True" CssClass="input1"   Width="200px" Height="25px" OnSelectedIndexChanged="DLCategory_SelectedIndexChanged">
                                
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
                                       <td align="right" width="12%"><strong>科研项目申请人:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtUserName" runat="server"  CssClass="input1"  ReadOnly="true"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>

                                   <tr>

                                       <td align="right" width="12%"><strong>项目名称:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtWorkLoadProjectsName" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>项目编号:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtProjectsId" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                   </tr>
                               <tr>
                                       <td align="right" width="12%"><strong>项目来源:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:DropDownList ID="DLWorkLoadFrom"  CssClass="input1" height="30px" Width="200px" runat="server">
                          </asp:DropDownList> 
                                       </td>
                                </tr>
                                <tr>
                                       <td align="right" width="12%"><strong>立项日期:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtProjectDate" runat="server"  onfocus="WdatePicker()" CssClass="input1"></asp:TextBox>
                                       </td>
                                </tr>
                              <tr>
                                       <td align="right" width="12%"><strong>结题日期:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtConcludingDate" runat="server"  onfocus="WdatePicker()"  CssClass="input1"></asp:TextBox>
                                       </td>
                                </tr>
                           <tr>
                                       <td align="right" width="12%"><strong>到校经费（万元）:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtWorkLoadCapital" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                </tr>
                                      
                                        <tr>
                                           <td align="right" width="12%"><strong>备注:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1"></asp:TextBox>
                                           </td>
                                       </tr>
                                       
                                       <tr>
                                           <td align="right" width="12%"><strong>项目总分值:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtWorkLoadProjectsValue" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
                                           </td>
                                       </tr>
                                         <tr>
                                           <td align="right" width="12%"><strong>本人排名:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:DropDownList ID="DlPartnerRank" runat="server" CssClass="input1" Width="140px">
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
                                           <td align="right" width="12%"><strong>个人立项分值:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtPartnerValue" runat="server" CssClass="input1" ></asp:TextBox>
                                           </td>
                                       </tr>
                                            <tr>
                                           <td align="right" width="12%"><strong>个人结题分值:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtConcludingValue" runat="server" CssClass="input1" ></asp:TextBox>
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
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>