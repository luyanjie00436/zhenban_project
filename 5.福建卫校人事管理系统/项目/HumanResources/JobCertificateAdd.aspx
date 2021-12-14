<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobCertificateAdd.aspx.cs" Inherits="HumanResources.JobCertificateAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>

     <script type="text/javascript">
         function panduan() {
             var JobName = document.getElementById("txtJobQualificationName");
             if (JobName.value.length < 1) {
                 alert("请填写职业资格名ks称！");
                 return false;
             }
             var Unit = document.getElementById("txtIsssueUnit");
             if (Unit.value.length < 1) {
                 alert("请填写发证单位！");
                 return false;
             }
             var Date = document.getElementById("txtJobDate");
             if (Date.value.length < 1) {
                 alert("请填写获取时间！");
                 return false;
             }

         
            return true;
         }
         function panduanzhaop()
         {
             var Photo = document.getElementById("FileUpload1");
             var size = Photo.files[0].size;
             if (Photo.value !== "") {
                 if (/\.(gif|jpg|png|bmp)$/.test(Photo.value)) {
                     if (size > 1024 * 1024) {
                         alert("文件超过1M大小！");
                         return false;
                     }
                 } else {
                     alert("图片类型必须是.gif,bmp,jpg,png中的一种")
                     return false;
                 }
             } else {
                 alert("上传照片不为空！！");
             }

             return true;
         }
         function tianjia() {
             if (!panduan()) {
                 return false
             }
             if (!panduanzhaop()) {
                 return false
             }
             return true;
         }
         function xiugai(){
             if (!panduantxt()) {
                 return false
             }
             var obj = document.getElementsByTagName("RlGL_Management");
             for (var i = 0; i < obj.length; i++) {
                 if (obj[i].checked) {
                     if (obj[i].value == "是") {
                         if (!panduanzhaop()) {
                             return false
                         }
                     }
                 }
             }
             return true;
         }
    </script>

    <script type="text/javascript">
        function findSize(FileUpload1) {
    var dom = document.getElementById("FileUpload1");
        var fileSize = dom.files[0].size;
        alert(fileSize);
    }
</script>

    <style type="text/css">
        .auto-style1 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
 <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增职业资格证书</strong> 
</div>
    </div>
    <div class="page_main01">
        <div style="display: none">
           
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">     
                       <tr>
                        <td align="right" class="auto-style1">
                            <strong>职业资格名称：</strong>
                        </td>
                         <td width="70%" align="left">
                            <asp:TextBox ID="txtJobQualificationName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写职业资格名称" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>   
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>发证单位：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtIsssueUnit" data-toggle="tooltip" data-placement="top"  ToolTip="请填写发证单位" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                  
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>获取时间：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtJobDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写获取时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>备注：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtRemarks" data-toggle="tooltip" data-placement="top"  ToolTip="请填写备注" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                          <strong>上传证书照片：</strong>
                        </td>
                        <td width="70%" align="left">
                           <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr> 
                     <tr id="tr_sfzg" runat="server">
                         
                        <td align="right" class="auto-style1">
                          <strong>是否修改照片</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:RadioButtonList ID="RlGL_Management" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="是">是</asp:ListItem>
                                <asp:ListItem Value="否">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                   
                    
                    <tr class="tr10">
                        <td height="80" align="right" style=" background:none;" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" style=" background:none;">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加"  OnClientClick=" return tianjia()" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改"  OnClientClick=" return xiugai()"  OnClick="Button2_Click" CssClass="btn" />
                        </td>
                    </tr>
                  
                </table>

    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
