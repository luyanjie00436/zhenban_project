<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KSPwd.aspx.cs" Inherits="Recruitment.KSPwd" %>

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
.bejj {
    width:100%;height:28px; background:#15428b;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div class="bejj" ></div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table  border="0" cellspacing="0" cellpadding="0" class="uua">
                    <tr>
                        <td align="right" >
                            原密码：
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPwd1" data-toggle="tooltip" data-placement="top"   ToolTip="请输入原密码" runat="server" Enabled="True" TextMode="Password" MaxLength="18" class="bwbk"></asp:TextBox>
                            </td>
                    </tr>
                   
                      <tr>
                        <td align="right" >
                            新密码：
                        </td>
                        <td width="70%" align="left">
                           <asp:TextBox ID="txtPwd2"  runat="server" Enabled="True" class="bwbk" TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请输入密码"></asp:TextBox>
                           </td>
                    </tr>
                     <tr>
                        <td align="right" >
                           确认密码：
                        </td>
                        <td width="70%" align="left">
                          <asp:TextBox ID="txtPwd3" runat="server" Enabled="True" CssClass="bwbk"  TextMode="Password" MaxLength="18" data-toggle="tooltip" data-placement="top"  ToolTip="请再次输入密码"></asp:TextBox>
                           </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right"  >
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" >
                            <asp:Button ID="Button1" runat="server" Text="确定并提交修改"  OnClick="Button1_Click" CssClass="btnn" data-toggle="btn" data-placement="top"  ToolTip="点击确定并提交修改进行修改" />&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
