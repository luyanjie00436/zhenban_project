<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldView.aspx.cs" Inherits="ScientManage_Web.OldView" %>

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
        body {
            color: #000;
            font-size: 12px;
            font-family: 'Microsoft YaHei', Verdana;
            background: #dfdfdf;
        }

        a {
            text-decoration: none;
        }

        * {
            margin: 0;
            padding: 0;
        }
        .table1 {
            border-top: 1px solid #a9a9a9;
            border-left: 1px solid #a9a9a9;
            margin: 0px auto;
            margin-top: 10px;
            font-size: 18px;
        }
            .table1 td {
                border-right: 1px solid #a9a9a9;
                border-bottom: 1px solid #a9a9a9;
            }
        .sec2 {
            margin-bottom: 2px;
            float: right;
        }
        .sec3 {
            width: 80%;
            margin: 0px auto;
            margin-top: 15px;
        }
        .button {
            display: inline-block;
            outline: none;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            font: 16px/100% 'Microsoft yahei',Arial, Helvetica, sans-serif;
            padding: 3px 18px 3px 18px;
            text-shadow: 0 1px 1px rgba(0,0,0,.3);
            -webkit-border-radius: .5em;
            -moz-border-radius: .5em;
            border-radius: .5em;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            box-shadow: 0 1px 2px rgba(0,0,0,.2);
        }
        .blue {
            color: #d9eef7;
            border: solid 1px #0076a3;
            background: #0095cd;
            background: -webkit-gradient(linear, left top, left bottom, from(#00adee), to(#0078a5));
            background: -moz-linear-gradient(top, #00adee, #0078a5);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#00adee', endColorstr='#0078a5');
        }
        .white {
            color: #606060;
            border: solid 1px #b7b7b7;
            background: #fff;
            background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ededed));
            background: -moz-linear-gradient(top, #fff, #ededed);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#ededed');
        }
        .botm {
            width: 100%;
            height: 300px;
            margin: 0px auto;
            border: 1px solid #a9a9a9;
        }
        .esp {
            width: 100%;
            margin: 0px auto;
            padding: 6px;
        }
        .parallelogram {
            border-bottom: 1px solid #959595;
            height: 20px;
        }
        .parallelogram2 {
            font-size: 18px;
            width: 200px;
            padding-right: 20px;
            font-family: 微软雅黑;
            font-size: 16px;
            border-right: 1px solid #959595;
            text-align: right;
        }
        .aa {
            height: 20px;
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        function showid(txt) {
            alert(txt.id);
        }
        function saves() {
            try {
                var tab = document.getElementById("signFrame");
                var rowslength = tab.rows.length;
                var sql2 = "";
                var sql1 = "*";

                for (var i = 1; i < rowslength; i++) {
                    var cell1 = "";
                    if (i != 1) {
                        cell1 = tab.rows[i].cells[0].children(0).value;
                    }
                    var cell2 = tab.rows[i].cells[1].children(0).value;
                    var cell3 = tab.rows[i].cells[2].children(0).value;
                    var cell4 = tab.rows[i].cells[3].children(0).value;
                    if (cell4 != "") {
                        if (cell3 == "like") {
                            cell4 = "%" + cell4 + "%";
                        }
                        cell4 = "'" + cell4 + "'";
                        sql2 = sql2 + wheres(cell1, cell2, cell3, cell4);
                    }
                }
                var checkobj = document.getElementById("CBlist1");
                var checks = checkobj.getElementsByTagName("input");
                for (var n = 0; n < checks.length; n++) {
                    if (checks[n].type == "checkbox" && checks[n].checked == true) {
                        if (sql1 == "*") {
                            sql1 = checks[n].value;
                        }
                        else {
                            sql1 = sql1 + "," + checks[n].value;
                        }
                    }
                }
                document.getElementById("Text1").value = sql1;
                document.getElementById("Text2").value = sql2;
                return true;
            } catch (e) {
                return false;
            }
        }
        function wheres(cell1, cell2, cell3, cell4) {
            var s = " " + cell1 + " " + cell2 + " " + cell3 + " " + cell4 + " ";
            return s;
        }
        //添加方法
        function addtr() {
            //var trid=0;
            var tab = document.getElementById("signFrame");
            //添加行
            var newTR = tab.insertRow(tab.rows.length);
            //  alert(tab.rows.length);
            //trid++;
            //获取序号=行索引
            var xuhao = newTR.rowIndex.toString();
            //   alert(xuhao);
            newTR.id = "tr" + xuhao;
            //添加列:序号
            var newNameTD = newTR.insertCell(0);
            //添加列内容
            newNameTD.innerHTML = "<select style='width:70px;' name='way" + xuhao + "' id='way" + xuhao + "'><option  value='and'>且</option><option value='or'>或</option> </select>";
            //添加列:日期
            var newNameTD = newTR.insertCell(1);
            //添加列内容
            newNameTD.innerHTML = tab.rows[1].cells[1].innerHTML;
            //添加列:方式
            var newEmailTD = newTR.insertCell(2);
            //添加列内容
            newEmailTD.innerHTML = tab.rows[1].cells[2].innerHTML;
            //添加列:备注
            var newTelTD = newTR.insertCell(3);
            //添加列内容
            newTelTD.innerHTML = tab.rows[1].cells[3].innerHTML;
            //添加列:删除按钮
            var newDeleteTD = newTR.insertCell(4);
            //添加列内容
            newDeleteTD.innerHTML = "<div align='center' style='width:40px'><a href='javascript:;' onclick=\"deltr('tr" + xuhao + "')\">删除</a></div>";

        }
        //全选
        function checks() {
            var CB1 = document.getElementById("CheckBox1");
            if (CB1.checked == true) {
                var checkobj = document.getElementById("CBlist1");
                var checks = checkobj.getElementsByTagName("input");
                for (var n = 0; n < checks.length; n++) {
                    if (checks[n].type == "checkbox") {
                        checks[n].checked = true;
                    }
                }
            }
            else {
                var checkobj = document.getElementById("CBlist1");
                var checks = checkobj.getElementsByTagName("input");
                for (var n = 0; n < checks.length; n++) {
                    if (checks[n].type == "checkbox") {
                        checks[n].checked = false;
                    }
                }
            }
        }
        //删除其中一行
        function deltr(trid) {    //alert(trid);
            var tab = document.getElementById("signFrame");
            var row = document.getElementById(trid);
            var index = row.rowIndex;//rowIndex属性为tr的索引值，从0开始  
            tab.deleteRow(index);  //从table中删除

            //重新排列序号，如果没有序号，这一步省略
            //var nextid;
            //for (i = index; i < tab.rows.length; i++) {
            //    tab.rows[i].cells[0].innerHTML = i.toString();
            //    nextid = i + 1;
            //    remark = document.getElementByIdx_x("remark" + nextid);
            //    remark.id = "remark";
            //}
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
                <table class="table1" width="80%" id="signFrame" border="0" cellspacing="0">
                    <tr>
                        <td width="50px"><strong>关系</strong></td>
                        <td width="200px"><strong>对比列</strong></td>
                        <td width="170px"><strong>对比方式</strong></td>
                        <td width="100px"><strong>对比数据</strong></td>
                        <td width="80px"><strong>操作</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td width="200px" height="30px;">
                            <asp:DropDownList ID="DLlie" runat="server" Width="200px" BackColor="#efefef"></asp:DropDownList>

                        </td>
                        <td width="170px">
                            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#efefef" Width="170px">
                                <asp:ListItem Value=">">大于</asp:ListItem>
                                <asp:ListItem Value="<">小于</asp:ListItem>
                                <asp:ListItem Value="=">等于</asp:ListItem>
                                <asp:ListItem Value="<>">不等于</asp:ListItem>
                                <asp:ListItem Value="like">包含</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="100px">
                            <asp:TextBox ID="TextBox2" runat="server" BackColor="#efefef" Width="100px"></asp:TextBox></td>
                        <td width="80px">
                            <input type="button" style="width: 60px; height: 30px; background: none; border: 1px solid #000; border-radius: 13px; text-align: center; line-height: 30px; cursor: pointer;" value="添  加" onclick="addtr()" /></td>
                    </tr>
                </table>
            </div>
            <input id="Text1" runat="server" value="*" style="display: none" />
            <input id="Text2" runat="server" style="display: none" />

            <div class="sec3">
                <div style="font-size: 16px; font-family: 微软雅黑; float: left; margin-bottom: 2px;">请您勾选如下所需导出的信息：</div>
                <div class="sec2">
                    <asp:Button ID="Button12" Style="width: 60px; height: 30px; background: none; border: 1px solid #000; border-radius: 13px; text-align: center; line-height: 30px; cursor: pointer;" runat="server" Text="导 出" OnClientClick="return saves()" OnClick="Button12_Click" />
                    <input id="CheckBox1" type="checkbox" value="全选" onclick="checks()" />全选
                </div>
            </div>
            <div class="sec3">
                <p>选择导出列</p>
                <asp:CheckBoxList ID="CBlist1" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                </asp:CheckBoxList>
            </div>
            <asp:GridView ID="gvExcel" runat="server" Visible="false"></asp:GridView>
            <style>
                #CBlist tr {
                    height: 70px;
                    line-height: 50px;
                }
            </style>
        </div>
    </form>
</body>
</html>
