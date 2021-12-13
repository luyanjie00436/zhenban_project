<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoAdd.aspx.cs" Inherits="ningdeScientManage_Web.UserInfoAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style>
    .left {
        width: 10%;
        text-align: right;
    }
    .right
    {
        width:22%;
        text-align:left;    
    }
        .auto-style4 {
            height: 100%;
            width: 15%;
            text-align: right;
            background: #d4d2d2;
        }
        .auto-style5 {
            height: 100%;
            width: 20%;
            text-align: right;
            background: #d4d2d2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >用户添加</div></div></div><br />
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="auto-style5">
                                <strong>用户工号：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserCardId" MaxLength="15" Height="27px" Width="137px" runat="server" Enabled="True" CssClass="input6"></asp:TextBox>
                            </td>
                              </tr>
                          <tr>
                              <td class="auto-style5">
                                <strong>用户密码：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserPwd" MaxLength="18" runat="server" Enabled="True" Height="27px" Width="137px" CssClass="input6"  TextMode="Password"></asp:TextBox>
                            </td>
                                </tr>
                          <tr>
                             <td class="auto-style5">
                                <strong>姓名：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserName" runat="server"  Height="27px" Width="137px"  CssClass="input6"></asp:TextBox>
                            </td>
                            </tr>
                    
                        <tr>
                             <td class="auto-style5"><strong>所属系(部)：</strong></td>
                            <td class="right">
                                    <asp:DropDownList ID="DlDepartment" runat="server" CssClass="input6" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                             <td colspan="2">
                                 <br />
                                 <div style="width:500px;margin:0 auto;">
                                     <div style="float:left;width:300px;">
                                         <div style="float:left;width:200px; ">
                                             <asp:ListBox ID="LBRank1" runat="server" CssClass="input6" Font-Size="15px" Height="200px" Rows="6" SelectionMode="Multiple" Width="150px"></asp:ListBox>
                                         </div>
                                         <div style=" float:right;text-align:center;width:100px;">
                                             <br />
                                             <br />
                                             <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="添  加&gt;&gt;" />
                                             <br />
                                             <br />
                                             <asp:Button ID="Button3" runat="server"  CssClass="btn" OnClick="Button3_Click" Text="&lt;&lt;删  除" />
                                         </div>
                                     </div>
                                     <div style="float:right;width:200px;">
                                         <asp:ListBox ID="LBRank2" runat="server" CssClass="input6" Font-Size="15px" Height="200px" Rows="6" SelectionMode="Multiple" Width="150px"></asp:ListBox>
                                     </div>
                                 </div>
                                </td>

                        </tr>
                          <tr class="tr10">
                            
                          
                             <td colspan="2" align="center">
                               
                              <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="保 存" />
                                 &nbsp;
                                 <asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="Button5_Click" Text="返 回" />
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
