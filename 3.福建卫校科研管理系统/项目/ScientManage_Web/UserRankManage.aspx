<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRankManage.aspx.cs" Inherits="ScientManage_Web.UserRankManage" %>

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
    <script type="text/javascript" language="javascript">
        function add(res, sel) {
            var objres = document.getElementById(res);
            var objsel = document.getElementById(sel);
            var customOptions;
            for (var i = 0; i < objres.options.length; i++) {
                if (objres.options[i].selected) {
                    customOptions = document.createElement("OPTION");
                    customOptions.text = objres.options[i].text.replace(/├/g, "").replace(/　/g, "");
                    customOptions.value = objres.options[i].value;

                    for (var i = 0; i < objsel.options.length; i++) {
                        if (customOptions.value == objsel.options[i].value) {
                            return true;
                        }
                    }
                    objsel.add(customOptions, 0);
                }
            }
            return false;
        }

        function del(dels) {
            var objdel = document.getElementById(dels);
            for (var i = objdel.options.length - 1; i >= 0; i--) {
                if (objdel.options[i].selected) {
                    objdel.remove(i);
                }
            }
        }
    </script>
    <style type="text/css">
        .LB {
            background-color: #d4d2d2;
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
    <form id="form2" runat="server">
        <div id="div_main">
            <div>
                <div class="aa">
                    <div class="parallelogram">
                        <div class="parallelogram2">用户权限配置</div>
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
                        <br />
                        <div style="width: 500px; margin: 0px auto; margin-left: 500px;">
                            <div style="float: left; width: 200px;">
                                <strong>工号：</strong>
                                <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input6" Height="27px" Width="137px" ReadOnly="true" data-toggle="tooltip" data-placement="top" ToolTip="用户工号"></asp:TextBox>
                            </div>
                            <div style="float: left; width: 200px;">
                                <strong>姓名：</strong>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input6" Height="27px" Width="137px" ReadOnly="true" data-toggle="tooltip" data-placement="top" ToolTip="用户姓名"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div style="height: auto; width: 100%; text-align: center;">
                            <div style="width: 600px; margin: 0 auto;">
                                <div style="float: left; width: 300px; padding-left: 80px;">
                                    <div style="float: left; width: 200px;">
                                        <asp:ListBox ID="LBRank1" runat="server" CssClass="LB" Font-Size="15px" Width="150px" Height="200px" SelectionMode="Multiple" Rows="6" data-toggle="tooltip" data-placement="top" ToolTip="现有角色"></asp:ListBox>
                                    </div>
                                    <div style="float: right; text-align: center; width: 100px;">
                                        <%--   <INPUT onclick="add('LBRank1', 'LBRank2')" tabIndex="8" type="button"   value="添  加>>" name="Input"/> 
            <INPUT onclick="del('LBRank2')" tabIndex="8" type="button"   value="<<删  除" name="Input"/> --%>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button2" runat="server" Text="添  加>>" CssClass="btn" OnClick="Button1_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button3" runat="server" Text="<<删  除" CssClass="btn" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top" ToolTip="点击进行删除" />
                                    </div>
                                </div>
                                <div style="float: right; width: 200px;">
                                    <asp:ListBox ID="LBRank2" CssClass="LB" Font-Size="15px" Width="150px" Height="200px" runat="server" SelectionMode="Multiple" Rows="6" data-toggle="tooltip" data-placement="top" ToolTip="已添加角色"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div>
                            <br />
                            <div style="width: 49%; float: left; text-align: right;">
                                <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行保存" />
                            </div>
                            <div style="width: 49%; float: right; text-align: left;">
                                <asp:Button ID="Button4" runat="server" Text="返 回" OnClick="Button4_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击返回上一页" />
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

