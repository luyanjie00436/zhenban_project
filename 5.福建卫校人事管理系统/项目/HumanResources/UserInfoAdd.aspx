<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoAdd.aspx.cs" Inherits="HumanManage_Web.UserInfoAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
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
        .LB {
            background:#d4d2d2;
        }
        .auto-style1 {
            height: 100%;
            width: 19%;
            text-align: right;
            background: #d4d2d2;
        }
        .auto-style2 {
            width: 18%;
        }
        .auto-style3 {
            height: 100%;
            width: 18%;
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
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >用户添加</div></div></div>
        <div class="page_main01">
       
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="auto-style3">
                                <strong>用户工号：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserCardId" MaxLength="15" runat="server" Enabled="True" CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="输入用户工号 例如（119999）"></asp:TextBox>
                            </td>
                              </tr>
                          <tr>
                              <td class="auto-style3">
                                <strong>用户密码：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserPwd" MaxLength="18" runat="server" Enabled="True" CssClass="input1"  TextMode="Password" data-toggle="tooltip" data-placement="top"  ToolTip="输入用户密码"></asp:TextBox>
                            </td>
                                </tr>
                          <tr>
                             <td class="auto-style3">
                                <strong>姓名：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserName" runat="server"   CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="输入用户姓名 例如（张三）"></asp:TextBox>
                            </td>
                            </tr>
                    
                       
                                        <tr>
                             <td class="left"><strong>来源信息：</strong></td>
                            <td class="right">
                                <asp:DropDownList ID="DlUserSource" RepeatLayout="Flow" runat="server"   RepeatDirection="Horizontal" class="input1" >
                                    <asp:ListItem Value="应届高等学校毕业生">应届高等学校毕业生</asp:ListItem>
                                    <asp:ListItem Value="应届中等专业学校毕业生">应届中等专业学校毕业生</asp:ListItem>
                                    <asp:ListItem Value="军转干部安置">军转干部安置</asp:ListItem>
                                    <asp:ListItem Value="调入">调入</asp:ListItem>
                                    <asp:ListItem Value="其他">其他</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                            <tr>
                             <td colspan="2">
                                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                                 <div style="width:600px;margin:0 auto;">
                                     <div style="float:left;width:300px;">
                                         <div style="float:left;width:200px;">
                                             <asp:ListBox ID="LBRank1" runat="server" CssClass="LB" Font-Size="15px" Height="200px" Rows="6" SelectionMode="Multiple" Width="150px" data-toggle="tooltip" data-placement="top"  ToolTip="现有的行政隶属类别"></asp:ListBox>
                                         </div>
                                         <div style=" float:right;text-align:center;width:100px;">
                                             <br />
                                             <br />
                                             <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="添  加&gt;&gt;" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" />
                                             <br />
                                             <br />
                                             <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" Text="&lt;&lt;删  除" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行删除" />
                                         </div>
                                     </div>
                                     <div style="float:right;width:200px;">
                                         <asp:ListBox ID="LBRank2" runat="server" CssClass="LB" Font-Size="15px" Height="200px" Rows="6" SelectionMode="Multiple" Width="150px" data-toggle="tooltip" data-placement="top"  ToolTip="已添加的行政隶属"></asp:ListBox>
                                     </div>
                                 </div>
                    </ContentTemplate></asp:UpdatePanel>
                                </td>

                        </tr>
                          <tr class="tr10">
                            
                            <td class="auto-style2" style="text-align:right;">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="保 存" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行保存" />
                              </td>
                             <td>
                                 <asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="Button5_Click" Text="返 回" data-toggle="tooltip" data-placement="top"  ToolTip="点击返回上一页" />
                              </td>
                        </tr>
                    </table>

        </div>
    </div>
    </form>
</body>
</html>
