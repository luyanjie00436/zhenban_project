<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPhone.aspx.cs" Inherits="ningdeScientManage_Web.UserPhone" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
              <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;个人电话设置</strong> 
</div><br />
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style4">
                            <strong>个人号码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="select1" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style4">
                            <strong>家庭号码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtHomeNumber" runat="server" CssClass="select1"  Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style4">
                            <strong>工作号码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtWorkNumber" runat="server" CssClass="select1"  Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" CssClass="btn" />&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
