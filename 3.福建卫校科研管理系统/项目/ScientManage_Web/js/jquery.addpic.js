$(document).ready(function() {
    var objid = $("#hiddenid").val();
    var pics = parent.document.getElementById("pic" + objid).value;
    var texts = parent.document.getElementById("text" + objid).value;
    if (pics.indexOf(",") >= 0) {
        var piclist = pics.split(",");
        var textlist = texts.split(",");
        var str = "";
        for (var i = 0; i < piclist.length - 1; i++) {
            str += "<li><img src='/" + piclist[i] + "' bigimg='" + piclist[i] + "' title='" + textlist[i] + "' /><a href=\"javascript:;\" onclick=\"deleteitem(this,'" + piclist[i] + "')\">[删除]</a></li>";
        }
        $("#imglist").append(str);
    }
});

function uploaditem() {
    var html = $("#spfile").html();
    var title = $("#txttitle").val();
    var filename = $("#FileUpload").val();
    var i = filename.lastIndexOf('.');
    var len = filename.length;
    var str = filename.substring(len, i + 1);
    var extName = "JPG,GIF,PNG,JPEG";
    if (filename==""|| extName.indexOf(str.toUpperCase()) < 0) {
        alert("请选择正确的图片文件!");
        $("#spfile").html(html);
        return;
    }
    $("#form1").ajaxSubmit({
        url: "/ashx/UploadImg.ashx?action=add&filename=" + filename + "&A=" + Math.random(),
        type: "post",
        success: function(data) {
            $("#txttitle").val('');
            $("#spfile").html(html);
            var imgstr = data.toLowerCase().replace("<pre>", "").replace("</pre>", "");
            var str = "<li><img src='/" + imgstr + "' bigimg='" + imgstr + "' title='" + title + "' /><a href=\"javascript:;\" onclick=\"deleteitem(this,'" + imgstr + "')\">[删除]</a></li>";
            $("#imglist").append(str);
        },
        error: function(e) {
            alert("上传失败，错误信息：" + e);
            $("#txttitle").val('');
            $("#spfile").html(html);
        }
    });
}

function deleteitem(obj, _imgsrc) {
    if (ShowConfirm("您确定要删除吗？")) {
        $.ajax({
            type: "POST",
            url: '/ashx/UploadImg.ashx?action=delete&filename=' + _imgsrc + '&A=' + Math.random(),
            success: function(data) {
                if (data == "1") {
                    $(obj).parent().remove();
                }
            },
            error: function(e) {
                alert("删除文件失败:" + e);
            }
        });
    }
}

function ShowConfirm(text) {
    return confirm(text);
}

function submitpic() {
    var objid = $("#hiddenid").val();
    var str = "";
    var text = "";
    $("#imglist li img").each(function() {
        str += $(this).attr("bigimg") + ",";
        text += $(this).attr("title") + ",";
    }); 
    parent.document.getElementById("pic" + objid).value = str;
    parent.document.getElementById("text" + objid).value = text;
    parent.tb_remove();
}