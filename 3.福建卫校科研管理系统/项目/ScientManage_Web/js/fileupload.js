$(function() {
    $("#FileUpload").bind("change", function() {
        var filename = $("#FileUpload").val();
        var i = filename.lastIndexOf('.');
        var len = filename.length;
        var str = filename.substring(len, i + 1);
        var extName = "JPG,GIF,PNG,JPEG";
        if (extName.indexOf(str.toUpperCase()) < 0) {
            alert("请选择正确的图片文件!");
            $("#FileUpload").val('');
            return;
        }
        $("#form1").ajaxSubmit({
            url: "/ashx/UploadImg.ashx?action=add&filename=" + filename + "&A=" + Math.random(),
            type: "post",
            beforeSend: function() { $(".upfiles").hide(); $("#idProcess").show(); },
            complete: function() { $(".upfiles").show(); $("#idProcess").hide(); $("#FileUpload").val(''); },
            success: function(data) {
                var imgstr = data.toLowerCase().replace("<pre>", "").replace("</pre>", "").replace("<pre style=\"word-wrap: break-word; white-space: pre-wrap;\">","");
                var str = "<li><img src='/upload/images/l_" + imgstr + "' bigimg='" + imgstr + "' rel='/upload/images/s_" + imgstr + "' onmouseover=\"ImagePreview('/upload/images/s_" + imgstr + "');\" /><a href=\"javascript:;\" onclick=\"deleteitem(this,'" + imgstr + "')\">[删除]</a></li>";
                $("#imglist").append(str);
                ImagePreview("/upload/images/s_" + imgstr);
                SetHiddenValue();
            },
            error: function(e) {
                alert("上传失败，错误信息：" + e);
                $(".upfiles").show();
                $("#idProcess").hide();
            }
        });
    });
});

function deleteitem(obj, _imgsrc) {
    if (ShowConfirm("您确定要删除吗？")) {
        $.ajax({
            type: "post",
            url: '/ashx/UploadImg.ashx?action=delete&filename=' + _imgsrc + '&A=' + Math.random(),
            success: function(data) {
                if (data == "1") {
                    $(obj).parent().remove();
                    var firstImgurl = $("#imglist li img").eq(0).attr("rel");
                    if (firstImgurl == null) {
                        $("#imgview").html("");
                    } else {
                        ImagePreview(firstImgurl);
                    }
                }
                SetHiddenValue();
            },
            error: function(e) {
                alert("删除文件失败:" + e);
            }
        });
    }
}

function SetHiddenValue() {
    var str = "";
    $("#imglist li img").each(function() {
        str += $(this).attr("bigimg") + ",";
    });
    $("#hiddenfile").val(str);
}

function ImagePreview(imgurl) {
    $("#imgview").html("<img src=\"" + imgurl + "\" />");
}

function ShowConfirm(text) {
    return confirm(text);
}