function switchSysBar() {
    //var locate=location.href.replace('Main.aspx','');
    //var ssrc = document.all("img1").src.replace(locate, '');
    var ssrc=document.all("img1").src;
    var ssrc_1 = ssrc.substring(ssrc.indexOf("images"),ssrc.length);

    //var ssrc_1 = locate.replace('Main.aspx', '');
    //var ssrc_2 = ssrc.replace(ssrc_1, '');

    if (ssrc_1 == "images/close_left.gif")
    { 
    document.all("img1").src="images/open_left.gif";
    document.all("frmTitle").style.display="none" 
    } 
    else
    { 
    document.all("img1").src="images/close_left.gif";
    document.all("frmTitle").style.display="" 
    }

}


//function show(ss, ii,openimg, closeimg) /** 第一级树杈 **/
//{
///*
//    if (ss.style.display == "none") {
//        ss.style.display = "";
//        ii.src = "images/open.gif";
//        ii.alt = "关闭菜单";
//        aa.src = "images/" + openimg;
//        aa.alt = "关闭菜单";
//    }
//    else {
//        ss.style.display = "none";
//        ii.src = "images/close.gif";
//        ii.alt = "展开菜单";
//        aa.src = "images/" + closeimg;
//        aa.alt = "展开菜单";
//    }
//      */

//    if (document.all(ss).style.display == "none") {
//        document.all(ss).style.display = "";
//        document.all(ii).src = "images/open.gif";
//        document.all(ii).alt = "关闭菜单";
//        //document.all(aa).src = "images/" + openimg;
//        //document.all(aa).alt = "关闭菜单";
//    }
//    else {
//        document.all(ss).style.display = "none";
//        document.all(ii).src = "images/close.gif";
//        document.all(ii).alt = "展开菜单";
//        //document.all(aa).src = "images/" + closeimg;
//        //document.all(aa).alt = "展开菜单";
//    }
//}

//function sub_show(ss, ii, aa, openimg, closeimg) /** 第二级树杈 **/
//{
//    if (ss.style.display == "none") {
//        ss.style.display = "";
//        ii.src = "images/open.gif";
//        ii.alt = "关闭菜单";
//        aa.src = "images/" + openimg;
//        aa.alt = "关闭菜单";
//    }
//    else {
//        ss.style.display = "none";
//        ii.src = "images/close.gif";
//        ii.alt = "展开菜单";
//        aa.src = "images/" + closeimg;
//        aa.alt = "展开菜单";
//    }
//}





//如何使用js来获取cookie的值

//读取属于当前文档的所有cookies

var allcookies = document.cookie;

//定义一个函数，用来读取特定的cookie值。

function getCookie(cookie_name) {

    var allcookies = document.cookie;

    var cookie_pos = allcookies.indexOf(cookie_name);   //索引的长度



    // 如果找到了索引，就代表cookie存在，

    // 反之，就说明不存在。

    if (cookie_pos != -1) {

        // 把cookie_pos放在值的开始，只要给值加1即可。

        cookie_pos += cookie_name.length + 1;      //这里我自己试过，容易出问题，所以请大家参考的时候自己好好研究一下。。。

        var cookie_end = allcookies.indexOf(";", cookie_pos);



        if (cookie_end == -1) {

            cookie_end = allcookies.length;

        }



        var value = unescape(allcookies.substring(cookie_pos, cookie_end)); //这里就可以得到你想要的cookie的值了。。。

    }



    return value;

}



// 调用函数

//function loads() {
//    var cookie_val = getCookie("userMenu");
//    //    alert(cookie_val);
//    if (cookie_val == "ky") {
//        show("show_1", "img_1", 'open.gif', 'close.gif');
//    }
//    else if (cookie_val == "xx") {
//        show("show_2", "img_2", 'open.gif', 'close.gif')
//    }
//    else if (cookie_val == "sh") {
//        show("show_3", "img_3", 'open.gif', 'close.gif')
//    }
//    else if (cookie_val == "sz") {
//        show("show_5", "img_5", 'open.gif', 'close.gif')
//    }
//    else {
//        show("show_1", "img_1", 'open.gif', 'close.gif');
//    }

//}


