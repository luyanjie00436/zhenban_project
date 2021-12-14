<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyYearAdd.aspx.cs" Inherits="HumanManage_Web.ApplyYearAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
    <strong>&nbsp;&nbsp;&nbsp;新增申报年份</strong> 
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
                                <strong>起始时间：</strong>
                            </td>
                            <td width="70%" align="left">
                                <input id="txtStartDate" data-toggle="tooltip" data-placement="top"  title="点击选择起始时间" runat="server" cssclass="Wdate" class="input6" style="height: 25px;" onfocus="WdatePicker()" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style1">
                                <strong>终止时间：</strong>
                            </td>
                            <td width="70%" align="left">
                                <input id="txtEndDate" runat="server" data-toggle="tooltip" data-placement="top"  title="点击选择终止时间" cssclass="Wdate" class="input6" style="height: 25px" readonly="true" onfocus="WdatePicker()" />
                            </td>
                        </tr>
                        <tr class="tr10">
                            <td height="80" align="right" class="auto-style1">&nbsp;
                            </td>
                            <td width="70%" height="80" align="left" valign="middle">
                                <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" />&nbsp;<asp:Button
                                    ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击重新输入" />
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
