<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankUpd.aspx.cs" Inherits="sanmingScientManage_Web.RankUpd" %>

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
    <strong>&nbsp;&nbsp;&nbsp;修改角色</strong> 
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
                            <strong>角色名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtRankName" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style4">
                            <strong>修改个人资料权限：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:RadioButtonList ID="RBList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem>否</asp:ListItem>
                            </asp:RadioButtonList>
                             </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style4">
                            <strong>查看所有用户申报信息权限：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:RadioButtonList ID="RBList2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem>否</asp:ListItem>
                            </asp:RadioButtonList>
                             </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" />
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
