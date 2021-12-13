<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSeriesAdd.aspx.cs" Inherits="ningdeScientManage_Web.AdminSeriesAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
<%--    <style type="text/css">
        .auto-style2 {
            width: 40px;
        }
        .auto-style3 {
            width: 113px;
        }
    </style>--%>
    <style type="text/css">
        .auto-style4 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
         <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增行政系列</strong> 
</div><br />

    </div>
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
                            <strong>行政系列名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtAdminSeriesName" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" CssClass="btn" />
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