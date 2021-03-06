<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentAdd.aspx.cs" Inherits="HumanManage_Web.DepartmentAdd" %>

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
    <strong>&nbsp;&nbsp;&nbsp;新增行政隶属管理</strong> 
</div>

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
                        <td align="right" class="auto-style1">
                            <strong>部门名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtDepartmentName"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入部门名称" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>编制人数：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPreparedNumber"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入编制人数" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>岗位管理编制数量：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPreparedPost"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入岗位管理编制数量" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>专业技术岗位编制数量：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPreparedProfession"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入专业技术岗位编制数量" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>工勤技能岗位编制数量：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtPreparedWorkers"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入工勤技能岗位编制数量" CssClass="input6" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
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



