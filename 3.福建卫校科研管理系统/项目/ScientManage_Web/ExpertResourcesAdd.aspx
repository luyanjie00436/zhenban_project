<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpertResourcesAdd.aspx.cs" Inherits="ScientManage_Web.ExpertResourcesAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-1.8.2.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 38%;
        }

        .auto-style5 {
            width: 38%;
            height: 32px;
        }

        .auto-style6 {
            height: 32px;
        }

        .auto-style1 {
            text-align: right;
        }

        .page_main01 {
            width: 400px;
            margin: 0px auto;
        }

        .select2 {
            width: 112px;
            height: 27px;
            background: #eae9e9;
        }
    </style>
    <script type="text/javascript">
        function show() {

            var inputs = document.getElementById("RSchoolOutside").getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    if (inputs[i].value == "校内") {
                        $("#Button3").css("visibility", "visible");
                        $("#xuanze").css("display", "block");
                        $("#xuanze2").css("display", "none");
                    }
                    else {
                        $("#Button3").css("visibility", "hidden");
                        $("#xuanze").css("display", "none");
                        $("#xuanze2").css("display", "block");
                    }
                }
            }
        }
    </script>
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
                <div class="swn">
                    <strong>&nbsp;&nbsp;&nbsp;新增专家资源库</strong>
                </div>
            </div>
            <div class="page_main01" style="width: 40%; margin: 0px auto;">
                <div style="display: none">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <div width="100%" border="0" cellspacing="0" cellpadding="0">
                            <div>
                                <label>校内/外:</label>
                                <asp:RadioButtonList ID="RSchoolOutside" RepeatLayout="Flow" AutoPostBack="false" onclick="show()" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="校内">校内</asp:ListItem>
                                    <asp:ListItem Value="校外">校外</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div style="margin-top: 10px; height: 30px;" id="xuanze" runat="server">
                                <label>选择人员:</label>
                                <asp:DropDownList ID="DlName" CssClass="select2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </div>
                            <div style="width: 230px; height: 30px; margin: 10px 0;">
                                <div style="width: 180px; float: left;">
                                    姓名:
                            <asp:TextBox ID="txtExpertName" runat="server" CssClass="input6" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入姓名"></asp:TextBox>
                                </div>
                                <div style="width: 30px; float: left;">
                                    <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                                </div>
                            </div>
                            <div style="clear: left; height: 30px; margin-top: 10px;">
                                <label>账号:</label>
                                <asp:TextBox ID="txtExpertNumber" runat="server" CssClass="input6" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入账号"></asp:TextBox>
                            </div>
                            <div style="margin-top: 10px; height: 30px;" id="xuanze2" runat="server">
                                <label>密码:</label>
                                <asp:TextBox ID="txtExpertPassword" TextMode="Password" data-toggle="tooltip" data-placement="top" ToolTip="输入密码" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                            </div>
                            <div style="margin-top: 10px; height: 30px; text-align: center;" class="tr10">
                                <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击添加" />&nbsp;<asp:Button
                                    ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top" ToolTip="保存" CssClass="btn" />
                            </div>
                        </div>
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
