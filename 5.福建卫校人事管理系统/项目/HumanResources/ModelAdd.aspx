<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelAdd.aspx.cs" Inherits="HumanManage_Web.ModelAdd" %>

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
    <strong>&nbsp;&nbsp;&nbsp;新增目录</strong> 
</div>

    </div>
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>目录名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtModelName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入目录名称" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>目录路径：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtModelUrl" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入目录路径" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>同级排序：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtModelNum" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入同级排序" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>上级目录：</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:DropDownList ID="DlModel" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择上级目录" runat="server" Style="margin-left: 0px; width: 80px;"
                        CssClass="select1">
                        <asp:ListItem Value="0">无上级目录</asp:ListItem>
                    </asp:DropDownList> </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置" data-toggle="tooltip" data-placement="top"  ToolTip="点击重新输入" OnClick="Button2_Click" CssClass="btn" />
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

