/// <reference path="jQuery.1.2.6.zh-cn-vsdoc.js" />
//全选
function chkall(ckbox, checkboxname) {
    $(":checkbox").each(function() {if (this.name.lastIndexOf(checkboxname) != -1) { this.checked = ckbox.checked; }});
}
function chkGridViewCheckBox(ckbox, checkboxname)
{
    $(":input[name*='chkAll']").attr('checked',ckbox.checked);
    chkall(ckbox,checkboxname);
}

//全选可用的复选框
function chkallenable(ckbox, checkboxname) {
    $(":checkbox").each(function() { if (this.name.lastIndexOf(checkboxname) != -1 && this.disabled == false) { this.checked = ckbox.checked; } });
}
//全选GridView中可用的复选框
function chkGridViewEnableCheckBox(ckbox, checkboxname) {
    $(":input[name*='chkAll']").attr('checked', ckbox.checked);
    chkallenable(ckbox, checkboxname);
}

//选中GridView中的一行中的复选框
function checkOneRow(ckbox,chkOpeations)
{
    var chkboxid=ckbox.id;
    var chkOneAllPrefix;//ckbox前缀
    var index=ckbox.id.lastIndexOf('_');
    if(index!=-1)
    {
        chkOneAllPrefix=chkboxid.substring(0,index);
        var aa=chkOneAllPrefix+'_'+chkOpeations;
        $(":input[id*='"+aa+"']").attr('checked',ckbox.checked);
    }
}

//选中当前栏目下的复选框
function checkRow(ckbox,checkboxname)
{
    var chkboxid=ckbox.id;
    var chkOneAllPrefix;//ckbox前缀
    var index=ckbox.id.lastIndexOf('_');
    if(index!=-1){
        chkOneAllPrefix=chkboxid.substring(0,index);
        var aa=chkOneAllPrefix+'_'+"rptRole_";
        $(":input[id*='"+aa+"']").attr('checked',ckbox.checked);
    }
}

//选中当前栏目下的子复选框
function checkRow2(ckbox, checkboxname) {
    var chkboxid = ckbox.id;
    var chkOneAllPrefix; //ckbox前缀
    var index = ckbox.id.lastIndexOf('_');
    if (index != -1) {
        chkOneAllPrefix = chkboxid.substring(0, index);
        var aa = chkOneAllPrefix + '_';
        $(":input[id*='" + aa + "']").attr('checked', ckbox.checked);
    }
}


//添加文件上传
function addFile() {
    var str = '<div><input type="file" name="File" id="File" size="40" /></div>'
    if ($(":input[name*='File']").length == 10) {
        alert("最多只能上传10个文件！");
        return;
    }
    document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", str);
}
//移除文件上传
function RemoveFile() {
    var item = document.getElementById("MyFile");
    if ($(":input[name*='File']").length == 1) {
        alert("无法继续删除！");
        return;
    }
    item.removeChild(item.lastChild);
}


//验证上传的文件格式
function CheckFile() {
//    var items = $(":input[name*='file_img']");
//    for (var i = 0; i < items.length; i++) {
//        if (items[i].value == "") {
//            alert("您还未选择要上传的图片！");
//            return false;
//        } else {
//            var type = items[i].value.substring(items[i].value.lastIndexOf("."), items[i].value.length);
//            if (type != ".jpg" && type != ".gif") {
//                alert("图片格式错误,必须是.jpg或.gif");
//                return false;
//            }
//        }
//    }
    var item = document.getElementById("file_img");
    if (item.value == "") {
        alert("您还未选择要上传的产品图片");
        return false;
    } else {
        var type = item.value.substring(item.value.lastIndexOf("."), item.value.length);
        if(type!=".jpg" && type!=".gif"){
            alert("图片格式错误,必须是.jpg或.gif");
            return false;
        }
    }
    return true;
}


function keyboard_monitor() {
    try {

        var argv = keyboard_monitor.arguments; if (argv.length < 2) { return; } var obj = argv[0]; var length = argv[1]; var keycode = null;
        if (typeof (window.event) != "undefined") { var keycode = window.event.keyCode; } else if (typeof (argv[2]) != "undefined") { var keycode = argv[2].which; }
        if (keycode == null) { return; }
        //alert(keycode);
        if (keycode == 86 && !detect_msie_version(7)) {//CTRL+V
            obj.value = ""; var data = window.clipboardData.getData("text"); data = data.toString(); var regex = /^\d{0,10}$/;
            if (regex.test(data) == false) { window.clipboardData.setData("text", ""); }
        }
        //Enter:13,CTRL:17,CTRL+V:86,Backspace:8,Delete:46
        if (keycode == 13 || keycode == 17 || keycode == 86 || keycode == 8 || keycode == 46 || keycode == 37 || keycode == 38 || keycode == 39 || keycode == 40) { return true; }
        if (obj.value.length >= length) { return false; }
        else if ((keycode >= 48 && keycode <= 57) || keycode >= 96 && keycode <= 105) { return true; }
        return false;
    } catch (x) { }
}

//验证只能输入数字
function checkNumber(field) {
    //定义正则表达式部分 
    var reg = /^\d+$/;
    if (field.value.constructor === String) {
        var re = field.value.match(reg);
        var str = field.value.substring(0, field.value.length - 1);
        //alert(str);
        if (re == null && str.match(reg) == null) { re = ""; } //屏蔽粘贴或一次键入词组
        else if (re == null && str.match(reg) != null) { re = str; } //保留已录入的数字
        field.value = re;
    }
}

var maxH = 768;
var maxW = 1024;
function DrawImage(ImgD) {
    var preW = 150;
    var preH = 150;
    var image = new Image();
    image.src = ImgD.src;
    if (image.width > maxW || image.height > maxH) {
        alert("图片尺寸过大，请选择" + maxW + "*" + maxH + "的图片！");
        return;
    }
    if (image.width > 0 && image.height > 0) {
        //flag = true;
        if (image.width / image.height >= preW / preH) {
            if (image.width > preW) {
                ImgD.width = preW;
                ImgD.height = (image.height * preW) / image.width;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = image.width + "×" + image.height;
        }
        else {
            if (image.height > preH) {
                ImgD.height = preH;
                ImgD.width = (image.width * preH) / image.height;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = image.width + "×" + image.height;
        }
    }
}
function checkFormat(filePath,obj_id) {
    var html = document.getElementById(obj_id).innerHTML; 
    var i = filePath.lastIndexOf('.');
    var len = filePath.length;
    var str = filePath.substring(len, i + 1);
    var extName = "JPG,GIF,PNG,JPEG,BMP";
    if (extName.indexOf(str.toUpperCase()) < 0) {
        alert("请选择正确的图片文件!");
        document.getElementById(obj_id).innerHTML = html; 
        return false;
    }
    return true;
}

function FileChange(Value) {
    if (checkFormat(Value)) {
        //flag = false;
//        document.getElementById("uploadimage").width = 150;
//        document.getElementById("uploadimage").height = 150;
//        document.getElementById("uploadimage").alt = "";
//        document.getElementById("uploadimage").src = Value;
//        alert(Value);
    }
}