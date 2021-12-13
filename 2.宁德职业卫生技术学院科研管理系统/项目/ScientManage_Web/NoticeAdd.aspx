<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeAdd.aspx.cs" Inherits="ningdeScientManage_Web.NoticeAdd" %>

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
    <strong>&nbsp;&nbsp;&nbsp;新增通知公告</strong> 
</div><br />

    <div class="page_main01">
        <div style="display: none">
        </div>

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style4">
                            <strong>内容：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtNoticeExplain" CssClass="input6" runat="server" Height="40px" Width="355px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style4">
                            <strong>附件：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:FileUpload ID="fupFileSend" runat="server"  CssClass="input6"  Width="203px" />
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
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
