<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LctureAdd.aspx.cs" Inherits="ningdeScientManage_Web.LctureAdd" %>
                                              
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
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >学术讲座添加</div></div></div><br />

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
                                   <td align="right" width="12%"><strong>级别:</strong> </td>
                                   <td align="left" width="12%">
                                       <asp:DropDownList ID="DLLevel" runat="server" AutoPostBack="True" CssClass="input1"  Width="200px" Height="25px" >
                                
                            </asp:DropDownList>
                                          </td>
                                 </tr><tr>
                                       <td align="right" width="12%"><strong>讲座(报告)名称:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtLctureName" runat="server" CssClass="input1" Width="400px"></asp:TextBox>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td align="right" width="12%"><strong>承办单位:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:DropDownList ID="DLCompany" runat="server" AutoPostBack="True" CssClass="input1"  Width="200px" Height="25px">
                            </asp:DropDownList>  
                                       </td>
                                       </tr>

                        <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座人姓名:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                              <asp:TextBox ID="txtLctureUserName" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                            <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座人性别:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                             <asp:RadioButtonList ID="RBLctureUserGender" runat="server"   RepeatDirection="Horizontal">
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                </asp:RadioButtonList>
                                       </td>
                                       </tr>
                         <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座人职称:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                              <asp:TextBox ID="txtLctureUserJob" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                            <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座人职务:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                              <asp:TextBox ID="txtLctureUserRole" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                            <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座人工作单位:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                              <asp:TextBox ID="txtLctureUserCompany" runat="server" CssClass="input1" Width="200px" ></asp:TextBox>
                                       </td>
                                       </tr>
                           
                                      <tr>
                                       <td align="right" width="12%" class="auto-style4"><strong>讲座时间:</strong> </td>
                                       <td align="left" width="12%" class="auto-style4">
                                             <input id="txtLctureDate" onfocus="WdatePicker()" runat="server" class="input1" cssclass="Wdate"  /> 
                               
                                       </td>
                                       </tr>
                                         <tr>
                                       <td align="right" width="12%"><strong>讲座地点:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtAddress" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                                    
                                        <tr>
                                       <td align="right" width="12%"><strong>参加人数:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtLctureNumber" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                                            <tr>
                                       <td align="right" width="12%"><strong>讲座内容简介:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtLctureExplain" Width="400px" runat="server" CssClass="input1" Height="200px" TextMode="MultiLine"></asp:TextBox>
                                       </td>
                                       </tr>
                                            <tr>
                                       <td align="right" width="12%"><strong>设备需求:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtEquipment" runat="server" CssClass="input1" Width="400px"></asp:TextBox>
                                       </td>
                                       </tr>
                                            <tr>
                                       <td align="right" width="12%"><strong>组织人:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtOrganName" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                                            <tr>
                                       <td align="right" width="12%"><strong>联系电话:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="input1"></asp:TextBox>
                                       </td>
                                       </tr>
                                            <tr>
                                       <td align="right" width="12%"><strong>拟发酬金标准:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtCapital" runat="server" CssClass="input1" Width="400px"></asp:TextBox>
                                       </td>
                                       </tr>
                                   
                                                          <tr>
                                       <td align="right" width="12%"><strong>备注:</strong> </td>
                                       <td align="left" width="12%">
                                           <asp:TextBox ID="txtRemarks" runat="server" CssClass="input1" Width="400px"></asp:TextBox>
                                       </td>
                                       </tr>
                                    
                                       <tr class="tr10">
                                          
                                           <td align="right">
                                               <asp:Button ID="Button1" runat="server" CssClass=" btn" OnClick="Button1_Click" Text="添 加" />
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