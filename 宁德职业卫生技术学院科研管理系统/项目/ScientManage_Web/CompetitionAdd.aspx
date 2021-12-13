<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompetitionAdd.aspx.cs" Inherits="ningdeScientManage_Web.CompetitionAdd" %>

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
    <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >技能竞赛添加</div></div></div>
        <br />
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
                                <strong>申报年份:</strong>
                              </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtApplyYear" runat="server"  CssClass="input1" ReadOnly="True"></asp:TextBox>
                            </td>
                              </tr>  
                         <tr>
                                       <td align="right" width="12%"><strong>技能竞赛名称:</strong> </td>
                                       <td align="left" >
                                           <asp:TextBox ID="txtCompetitionName" runat="server" CssClass="input1" Width="301px"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>
                           <tr>
                                   <td align="right" width="12%"><strong>类别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLCategory" runat="server" AutoPostBack="True"  CssClass="input1" Width="200px" Height="25px" OnSelectedIndexChanged="DLCategory_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                                          </td>
                                   </tr>
                             <tr>
                                   <td align="right" width="12%"><strong>级别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLLevel" runat="server" AutoPostBack="True" CssClass="input1"  Width="200px" Height="25px" OnSelectedIndexChanged="DLLevel_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                                          </td>
                                   </tr>
                        
                                    <tr>
                                       <td align="right" width="12%"><strong>技能竞赛负责人:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtUserName" runat="server"  CssClass="input1"  ReadOnly="true"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>
                          <tr>
                           
                              <td width="12%" align="right">
                                  <strong>竞赛组织单位:</strong>
                              </td>
                            <td  align="left">
                                <asp:TextBox ID="txtAppraisalCompany"   runat="server"  CssClass="input1"></asp:TextBox>
                            </td>
                              </tr>
                               <tr>
                                   <td align="right" width="12%"><strong>参赛教师姓名:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:TextBox ID="txtTeacherName"  runat="server" CssClass="input1" ></asp:TextBox>
                                   </td>
                                   </tr>
                                     <tr>
                                   <td align="right" width="12%"><strong>参赛学生姓名:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:TextBox ID="txtStudentName"  runat="server" CssClass="input1"></asp:TextBox>
                                   </td>
                                   </tr>
                                     <tr>
                                   <td align="right" width="12%"><strong>指导教师姓名:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:TextBox ID="txtMentor" runat="server" CssClass="input1" ></asp:TextBox>
                                   </td>
                                   </tr>
                                    <tr>
                              <td width="12%" align="right">
                                <strong>成果获得时间:</strong>
                              </td>
                            <td width="12%" align="left">
                                <input ID="txtCompetitionDate" runat="server"  onfocus="WdatePicker()" class="input1"></input>
                            </td>
                               </tr>
                                       <tr>
                                           <td align="right" width="12%"><strong>成果分值:</strong> </td>
                                           <td align="left" width="12%">
                                               <asp:TextBox ID="txtCompetitionValue" runat="server" CssClass="input1"  ReadOnly="true"></asp:TextBox>
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