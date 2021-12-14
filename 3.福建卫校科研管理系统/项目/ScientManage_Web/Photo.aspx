<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="ScientManage_Web.Photo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style>
        embed {
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var heig = window.screen.availHeight;

            document.getElementById('png').style.minHeight = heig + "px";
            document.getElementById('png').minHeight = heig + "px";
            document.getElementById('png').style.Height = heig + "px";
            document.getElementById('png').Height = heig + "px";
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
    <form id="form1" runat="server" style="height: 100%;">
        <div id="div_main" style="height: 100%;">
            <embed style="height: 100%; width: 100%;" runat="server" id="png" />
        </div>
    </form>
</body>
</html>
