<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructionsForUse.aspx.cs" Inherits="ScientManage_Web.InstructionsForUse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div>

                <div class="aa">
                    <div class="parallelogram">
                        <div class="parallelogram2">使用说明</div>
                    </div>
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
                                    <strong>普通教职工使用说明：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <a href="InstructionsForUse/OrdinaryStaff.mht" target="blank">预览</a></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>系部领导使用说明：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <a href="InstructionsForUse/DepartmentMinistryLeadership.mht" target="blank">预览</a></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>院领导使用说明：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <a href="InstructionsForUse/CollegeLeadership.mht" target="blank">预览</a></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <strong>系统管理员使用说明：</strong>
                                </td>
                                <td width="70%" align="left">
                                    <a href="InstructionsForUse/SystemAdministrator.mht" target="blank">预览</a></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="rightMain">
                <br />
            </div>
        </div>
    </form>
</body>
</html>
