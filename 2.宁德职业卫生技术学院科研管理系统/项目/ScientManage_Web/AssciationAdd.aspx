<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssciationAdd.aspx.cs" Inherits="ningdeScientManage_Web.AssciationAdd" %>

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
     <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >团体学会添加</div></div></div><br />

        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        
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
                                       <td align="right" width="12%"><strong>团体学会名称:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtAssciationName" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>申请单位:</strong> </td>
                                       <td align="left" width="12%">
                                             <asp:DropDownList ID="DLCompany" runat="server" AutoPostBack="True" CssClass="input1"  Width="200px" Height="25px" >
                                
                            </asp:DropDownList>  

                                       </td>
                                       </tr>

                                         <tr>
                                              <td align="right" width="12%"><strong>所需费用:</strong> </td>
                                              <td align="left" width="12%">
                                                  <asp:TextBox ID="txtCapital" runat="server" CssClass="input1"></asp:TextBox>
                                              </td>
                          <tr>
                              <td align="right" width="12%"><strong>团体学会简介:</strong> </td>
                              <td align="left" width="12%">
                                  <asp:TextBox ID="txtExplain" runat="server" CssClass="input1" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
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