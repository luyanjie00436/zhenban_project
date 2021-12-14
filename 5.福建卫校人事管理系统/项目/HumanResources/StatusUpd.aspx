<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusUpd.aspx.cs" Inherits="HumanManage_Web.StatusUpd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
         <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;修改状态</strong> 
</div>

    </div>
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate><br />
                <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>状态名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtStatusName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入状态名称" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改" OnClick="Button1_Click" CssClass="btn" />
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


