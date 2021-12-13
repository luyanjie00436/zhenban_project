//document.write("script language='javascript' src='css\base.js'></script");
$(document).ready(function () {
    if (menu != "") {
        var menu = $('#TextBox1').val().toString();
        var menuStatic = $('#TextBox2').val().toString();
        //        $("#cate li").siblings("ul").hide();
        //        $("#" + menu).next().toggle();
    } else {
        //        $("#cate li").siblings("ul").hide();
    }
    $("#cate li").click(function () {
        //        $("#cate li").siblings("ul").hide();
        //        $(this).next().toggle();
        //        $("#TextBox1").val($(this).attr('id').toString());
        menu = $("#TextBox1").val().toString();
    });

    static();
    function static() {
        if (menuStatic == "普通用户") {
            $(".users").show();
            $(".userslead").hide();
            $(".manager").hide();
            $(".lead").hide();
            $(".userslead").hide(); //user lead
        } else {
            if (menuStatic == "管理员") {
                $(".manager").show();
                $(".userslead").show();
                $(".users").show();
                $(".lead").show();
            } else {
                $(".lead").show();
                $(".userslead").show();
                $(".manager").hide();
                $(".userslead").show(); //user lead
                $(".users").show();
            }

        }


    }

    function show(ss, ii, aa, openimg, closeimg) /** 第一级树杈 **/
    {
        if (ss.style.display == "none") {
            ss.style.display = "";
            ii.src = "images/open.gif";
            ii.alt = "关闭菜单";
            aa.src = "images/" + openimg;
            aa.alt = "关闭菜单";
        }
        else {
            ss.style.display = "none";
            ii.src = "images/close.gif";
            ii.alt = "展开菜单";
            aa.src = "images/" + closeimg;
            aa.alt = "展开菜单";
        }
    }

//    var menu = "ky";
    function mu() {
    }
    $("#cate dt dd ul li a").click(function () {
        alert("ddfdd");
        $("#cate dt").siblings("dd").hide();
        $(this).next().toggle();
        $("#TextBox1").val($(this).attr('id').toString());
        menu = $("#TextBox1").val().toString();
        alert($("#TextBox1").val().toString());
    });
});


