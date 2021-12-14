<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_UserAdd.aspx.cs" Inherits="HumanManage_Web.A_UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
    <script>
        function yanzheng()
        {
            
            var U_Name = document.getElementById("txtUserName").value;
            
         
            if (U_Name.length<6) {
                alert("用户名长度不能小于6位");
                return false;
            }
          
            var U_Pass = document.getElementById("txtUserPwd").value;
            if (U_Pass.length < 6) {
                alert("密码长度不能小于6位");
                return false;
            }
            var U_Key = document.getElementById("TextBox1").value;
            if (U_Key.length < 6) {
                alert("请点击获取校验码，并保存用户名、校验密码、校验码等信息发送给客户");
                return false;
            }
            var U_Key2 = document.getElementById("TextBox2").value;
            if (U_Key2.length < 6) {
                alert("请点击获取校验密码，并保存用户名、校验密码、校验码等信息发送给客户");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
 <div>
        <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;接口人员信息</strong> 
</div>

    </div>
    <div class="page_main01">
        <div style="display: none">
        
        </div>
     <br />
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                   
                      <tr>
                <td  align="right" >
                     <strong>用户名：</strong>
                </td>
                <td  align="left">
                    
                 <asp:TextBox ID="txtUserName"  runat="server"  CssClass="input6"  Height="27px" Width="137px"  ImeMode="On" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入用户名" ></asp:TextBox>
                     <asp:Button ID="Button3" runat="server" Text="获得校验码" data-toggle="tooltip" data-placement="top"  ToolTip="获得校验码" OnClick="Button3_Click" CssClass="btn" Width="100" />&nbsp;
                </td>
            </tr>
            <tr>
                <td  align="right" class="auto-style1">
                    
                     <strong>密&nbsp; 码：</strong>
                </td>
                <td  align="left">
                   
                    <asp:TextBox ID="txtUserPwd"  runat="server" Enabled="True" CssClass="input6"  Height="27px" Width="137px"  ImeMode="On" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入密码" ></asp:TextBox>
                     <asp:Button ID="Button4" runat="server" Text="获得校验密码" data-toggle="tooltip" data-placement="top"  ToolTip="获得校验密码" OnClick="Button4_Click" CssClass="btn" Width="100" />
                </td>
            </tr>
  <tr>
                <td  align="right" class="auto-style1">
                    
                     <strong>校验码：</strong>
                </td>
                <td  align="left">
                   
                    <asp:TextBox ID="TextBox1"  runat="server" Enabled="True" CssClass="input6"  Height="81px" Width="400px" ImeMode="On" MaxLength="18" data-toggle="tooltip" data-placement="top"  ReadOnly="true" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
  <tr>
                <td  align="right" class="auto-style1">
                    
                     <strong>校验密码：</strong>
                </td>
                <td  align="left">
                   
                    <asp:TextBox ID="TextBox2"  runat="server" Enabled="True" CssClass="input6"  Height="81px" Width="400px" ImeMode="On" MaxLength="18" data-toggle="tooltip" data-placement="top"  ReadOnly="true" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
                    
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" OnClick="Button1_Click" CssClass="btn" OnClientClick="return yanzheng()" />&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改" OnClick="Button2_Click" CssClass="btn" OnClientClick="return yanzheng()" />

                        </td>
                         </tr>
                </table>
         
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
