//验证数字
function yzshuzi(Num1)  
{
    if (!isNaN(Num1)){    //验证是否是数字
        return true;  //是数字
}else{
        return false;  //不是数字
}

}
//验证范围性数字 大于1 小于2
function yzshuzifw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (parseFloat(Num1)>Fw1&& parseFloat(Num1)<Fw2) {
        return true;//返回 2  验证成功
    }
    else {
        return false;// 返回3 不在范围内
    }

}
//验证范围性数字 大于等于1 小于等于2
function yzshuzifw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
   
    if (parseFloat(Num1) >= Fw1 && parseFloat(Num1) <= Fw2) {
        return true;//返回 2  验证成功
    }
    else {
        return false;// 返回3 不在范围内
    }

}


//验证百分数
function yzbaifenshu(Num1)
{
    var patt1 = new RegExp(/^\d+\.{0,1}\d+%$/); //验证百分数正则表达式
    var result = patt1.test(Num1);
    if (!result) {  
       
        return false;  //验证不是百分数返回 false
    }

}

//验证百分数范围 大于1 小于2
function yzbaifenshufw1(Num1, Fw1, Fw2)
{
    var str = Num1.replace("%", "");
    str = str / 100;

    Fw1 = Fw1.replace("%", "");
    Fw1 = Fw1 / 100;
    Fw2 = Fw2.replace("%", "");
    Fw2 = Fw2 / 100;

    if (parseFloat(str) <= parseFloat(Fw1) || parseFloat(str) >= parseFloat(Fw2)) {
        return false;
    }
    else {
        return true;
    }
}
//验证百分数范围 大于等于1 小于等于2
function yzbaifenshufw2(Num1, Fw1, Fw2) {
    var str = Num1.replace("%", "");
    str = str / 100;
    Fw1 = Fw1.replace("%", "");
    Fw1 = Fw1 / 100;
    Fw2 = Fw2.replace("%", "");
    Fw2 = Fw2 / 100;
    if (parseFloat(str) < parseFloat(Fw1) || parseFloat(str) > parseFloat(Fw2)) {
        return false;
    }
    else {
        return true;
    }
}









//验证数字范围 大于1 小于2
function yzszfw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (!yzshuzi(Num1.value)) {
        alert('请输入数字');
        Num1.value = Fw1+1;
       // Num1.focus();
        return;
    }
    if (!yzshuzifw1(Num1.value, Fw1, Fw2)) {
        alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的数字！');
        Num1.value = Fw1 +1;
      //  Num1.focus();
        return;
    }
}
//选择验证数字范围 大于1 小于2
function xzyzszfw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (Num1.value!="" ) {
        if (!yzshuzi(Num1.value)) {
            alert('请输入数字');
            Num1.value = Fw1 +1;
          //  Num1.focus();
            return;
        }
        if (!yzshuzifw1(Num1.value, Fw1, Fw2)) {
            alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的数字！');
            Num1.value = Fw1 +1;
           // Num1.focus();
            return;
        }
    }
   
}
//验证数字范围 大于等于1 小于等于2
function yzszfw2(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (!yzshuzi(Num1.value)) {
        alert('请输入数字');
        Num1.value = Fw1 + 1;
       // Num1.focus();
        return;
    }
    if (!yzshuzifw2(Num1.value, Fw1, Fw2)) {
        alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的数字！');
        Num1.value = Fw1 + 1;
       // Num1.focus();
        return;
    }
}
//选择验证数字范围 大于等于1 小于等于2
function xzyzszfw2(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (Num1.value != "") {
        if (!yzshuzi(Num1.value)) {
            alert('请输入数字');
            Num1.value = Fw1 + 1;
        //    Num1.focus();
            return;
        }
        if (!yzshuzifw2(Num1.value, Fw1, Fw2)) {
            alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的数字！');
            Num1.value = Fw1 + 1;
         //   Num1.focus();
            return;
        }
    }
   
}
//验证百分数范围 大于1 小于2
function yzbfsfw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (!yzbaifenshu(Num1.value)) {
        alert('请输入百分数');
        Num1.value = Fw1 + 1;
       // Num1.focus();
        return;
    }
    if (!zbaifenshu(Num1.value, Fw1, Fw2)) {
        alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的百分数！');
        Num1.value = Fw1 + 1;
       // Num1.focus();
        return;
    }
}
//选择验证百分数范围 大于1 小于2
function xzyzbfsfw1(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (Num1.value != "") {
        if (!yzbaifenshu(Num1.value)) {
            alert('请输入百分数');
            Num1.value = Fw1 + 1;
        //    Num1.focus();
            return;
        }
        if (!zbaifenshu(Num1.value, Fw1, Fw2)) {
            alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的百分数！');
            Num1.value = Fw1 + 1;
         //   Num1.focus();
            return;
        }
    }
  
}
//验证百分数范围 大于等于1 小于等于2
function yzbfsfw2(Num1, Fw1, Fw2) //(被验证数字，小的范围，大的范围) 需在两个范围内的数据
{
    if (!yzbaifenshu(Num1.value)) {

        alert('请输入百分数');
        Num1.value = Fw1 + 1;
      //  Num1.focus();
        return;
    }
    if (!yzbaifenshufw(Num1.value, Fw1, Fw2)) {
        alert('请输入范围为大于' + Fw1 + '且小于' + Fw2 + '的百分数！');
        Num1.value = Fw1 + 1;
       // Num1.focus();
        return;
    }
}
