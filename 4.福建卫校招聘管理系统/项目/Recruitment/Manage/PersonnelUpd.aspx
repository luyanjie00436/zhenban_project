<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonnelUpd.aspx.cs" Inherits="Recruitment.PersonnelUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <title></title>
    <style type="text/css">
        body {
            background:#fafafa;
        }
      
        .uua {
    width:50%;
    margin:0px auto;
    margin-top:30px;
    border-top:1px solid #c4c4c4;
    border-left:1px solid #c4c4c4;
}
.uua  td{
    height:30px;
    border-bottom:1px solid #c4c4c4;
    border-right:1px solid #c4c4c4;
}
.bwbk {
    width:100%;
    height:30px;
    background:#fafafa;
    border:none;
}
    </style>
      <script type="text/javascript">
        function jiancha()
        {
            var val = document.getElementById('txtUserCardId').value;
            if (/.*?[\u4E00-\u9FFF]+.*/gi.test(val))
            {
                alert('账号不能含有中文字符');
                return false;
            }
            var vals = document.getElementById('txtUserName').value;
            reg = /^[a-zA-Z\u4e00-\u9fa5]+$/;
            if (!reg.test(vals))
            {
                alert('姓名不能含有数字和特殊字符');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" cellspacing="0" class="uua">
 <div class="bejj"><span  style="color:#fff; width:200px;  float:left; line-height:2;font-size:14px; font-weight:bold;">人员编辑</span></div>
         
            <tr>
                <td >账&nbsp; 号：</td>
                <td align="left">
                  <asp:Label ID="txtUserCardId" class="bwbk" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td >姓&nbsp; 名：</td>
                <td>
                    <input ID="txtUserName"  class="bwbk" runat="server"/>
                </td>
            </tr>
            <tr>
                <td >密&nbsp; 码：</td>
                <td>
                    <asp:TextBox ID="txtPwd1"  runat="server" Enabled="True"   class="bwbk"  Height="27px" Width="137px" TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入密码"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >确认密码：</td>
                <td><asp:TextBox ID="txtPwd2" runat="server" Enabled="True" class="bwbk" Height="27px" Width="137px"  TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请再次输入密码"></asp:TextBox></td>
            </tr>
            <tr>
                
                <td colspan="2" align="center" >
                    <asp:Button ID="Button1" runat="server" Text="修 改" CssClass="btnn" OnClick="Button1_Click" OnClientClick="return jiancha()" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
