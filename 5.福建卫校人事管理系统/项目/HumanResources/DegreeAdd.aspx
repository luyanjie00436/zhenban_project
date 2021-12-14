<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DegreeAdd.aspx.cs" Inherits="HumanManage_Web.DegreeAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
 <div>
        <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增学位</strong> 
</div>

    </div>
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager  ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="30%" align="right">
                            <strong>学位名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtDegreeName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入学位名称" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr class="tr10">
                        <td width="30%" height="80" align="right">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置"  data-toggle="tooltip" data-placement="top"  ToolTip="点击重新输入" OnClick="Button2_Click" CssClass="btn" />
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

