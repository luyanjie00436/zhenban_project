<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AimsAdd.aspx.cs" Inherits="ningdeScientManage_Web.AimsAdd" %>

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
    <strong>&nbsp;&nbsp;&nbsp;新增社会经济目标</strong> 
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
                            <strong>社会经济目标代码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtId" runat="server" CssClass="input6" Height="27px" Width="137px" ToolTip="输入社会经济代码"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style4">
                            <strong>社会经济目标名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtAimsName" runat="server" CssClass="input6" Height="27px" Width="137px" ToolTip="输入社会经济目标名称"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style4">
                            <strong>上级代码：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtFatherId" runat="server" CssClass="input6" Height="27px" Width="137px" ToolTip="输入上级代码"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style4">
                            <strong>说明：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtExplain" runat="server" CssClass="input6" Height="27px" Width="137px" ToolTip="输入说明"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                           <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" ToolTip="点击进行添加" />
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            &nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" CssClass="btn" ToolTip="点击重新输入" />
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
