<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssessDetailed.aspx.cs" Inherits="ScientManage_Web.AssessDetailed" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <script type="text/javascript">
        //-----  下面是打印控制语句  ----------
        window.onbeforeprint = beforePrint;
        window.onafterprint = afterPrint;
        //打印之前隐藏不想打印出来的信息
        function beforePrint() {
            div2.style.display = 'none';
            div3.style.display = 'none';

        }
        //打印之后将隐藏掉的信息再显示出来
        function afterPrint() {
            div2.style.display = '';
            div3.style.display = '';
        }
        function printPage() {
            //  parent.iprint.style.display = "none";
            div2.style.display = "none";
            //   $("div3").css("display", "none");
            window.print();
            div2.style.display = "block";
            //  $("div3").css("display", "");
            return false;
        }


    </script>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>

    <style>
        .btn {
            width: 60px;
            height: 30px;
            background: none;
            border: 1px solid #000;
            border-radius: 13px;
            text-align: center;
            line-height: 30px;
            cursor: pointer;
        }

        body {
            width: 98%;
            margin: 0px auto;
            background-color: #dfdfdf;
        }

        table {
            border-collapse: collapse;
            border: #000;
            font-size: 12px;
        }

            table td {
                height: 25px;
                min-height: 25px;
                border-top: 1px solid #000000;
                border-right: 1px solid #000000;
                border-bottom: 1px solid #000000;
                text-align: center;
            }

        .td2 {
            height: 25px;
            min-height: 25px;
            border-top: 1px solid #000000;
            border-right: 1px solid #000000;
            border-bottom: 1px solid #000000;
            text-align: center;
            color: #595758;
        }

        .btn {
            width: 60px;
            height: 30px;
            border: 1px solid #000;
            border-radius: 13px;
            text-align: center;
            line-height: 30px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main" class="min_height" id="tableExcel" style="width: 100%; text-align: left; margin: 0 0 0 10px;">
            <div class="page_title">
            </div>
            <br />
            <br />
            <br />
            <div <%--class="list"--%>>
                <%=MenuStr %>
            </div>
            <div id="div2" style="text-align: center; margin-top: 10px">
                <input id="div3" type="button" value="打 印" onclick=" printPage() " style="width: 60px; height: 30px; background: none; border: 1px solid #000; border-radius: 13px; text-align: center; line-height: 30px; cursor: pointer;" />
                <asp:Button ID="打印" runat="server" Text="导 出" OnClick="Button1_Click" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
