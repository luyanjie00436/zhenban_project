<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobUpd.aspx.cs" Inherits="ningdeScientManage_Web.JobUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 37%;
        }
        .auto-style5 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;修改职称</strong> 
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
                        <td align="right" class="auto-style5">
                            <strong>职称名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtJobName" runat="server" CssClass="input6"  Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5">
                            <strong>基础分值：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtJobValue" runat="server" CssClass="input6" Height="30px" Width="145px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style5">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" />&nbsp;
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