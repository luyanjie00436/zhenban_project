function call1(tableid) {
    var tab = $(tableid);
    var sql2 = "";
    var rowslength = tab.find("tr").length;
    for (var i = 1; i < rowslength; i++) {
        var cell1 = "";
        if (i != 1) {
            cell1 = tab.find("tr").eq(i).find("td").eq(0).children(0).val();
        }
        cell2 = tab.find("tr").eq(i).find("td").eq(1).children(0).val();
        cell3 = tab.find("tr").eq(i).find("td").eq(2).children(0).val();
        cell4 = tab.find("tr").eq(i).find("td").eq(3).children(0).val();
        if (cell4 != "") {
            if (cell3 == "like") {
                cell4 = "%" + cell4 + "%";
            }
            cell4 = "'" + cell4 + "'";
            var s = " " + cell1 + " isnull( " + cell2 + ", '')" + cell3 + " " + cell4 + " ";
            sql2 = sql2 + s;
        } else {
            cell4 = "'" + cell4 + "'";
            var s = " " + cell1 + " isnull( " + cell2 + ", '')" + cell3 + " " + cell4 + " ";
            sql2 = sql2 + s;
        }
    } return sql2;

}

function call2(cb, sql1) {

    var Chkrows = $(cb).find("input:checked").length;
    if (Chkrows > 0) {
        $(cb).find("input:checked").each(
           function () {
               if (sql1 == "*") {
                   sql1 = $(this).val();
               }
               else {
                   sql1 = sql1 + " , " + $(this).val();
               }
           }
         );
    }
    return sql1;
}

function calladd(tableid) {
    var tab = $(tableid);
    //var trid=0;
    var tab = document.getElementById("signFrame");
    //添加行
    var newTR = tab.insertRow(tab.rows.length);
    //  alert(tab.rows.length);
    //trid++;

    //获取序号=行索引
    var xuhao = newTR.rowIndex.toString();
    //  alert(xuhao);
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

    return tableid;

}