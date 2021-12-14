<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseOfficeAdd.aspx.cs" Inherits="HumanManage_Web.UseOfficeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 38%;
        }
    </style>
    <script type="text/javascript">
        function  panduantxt()
        {
            var AppointmentDate = document.getElementById("txtAppointmentDate");
            if (AppointmentDate.value.length < 1) {
                alert("请填写聘任时间");
                return false;
            }
            var Profession = document.getElementById("txtProfession");
            if (Profession.value.length < 1) {
                alert("请填写专业");
                return false;
            }
            var ProfessionName = document.getElementById("txtProfessionQualificationName");
            var index = ProfessionName.seletedIndex;
            var Value = ProfessionName.options[index].value;

            if (Value < 1) {
                alert("请选择专业技术资格名称！");
                return false;
            }
         
            return true;
        }
        function panduanzhaop() {
            var Photo = document.getElementById("FileUpload1");
            var size = Photo.files[0].size;
            if (Photo.value !== "") {
                if (/\.(gif|jpg|png|bmp)$/.test(Photo.value)) {
                    if (size > 1024 * 1024) {
                        alert("文件超过1M大小！");
                        return false;
                    }
                }
                else {
                    alert("图片类型必须是.gif,bmp,jpg,png中的一种")
                    return false;
                }
            }
            else {
                alert("上传照片不vv能为空!");
                return false;
            }
            return true;
        }
        function tianjia()
        {
            if (!panduantxt()) {
                return false
            }
            if (!panduanzhaop()) {
                return false
            }
            return true;
        }

        function xiugai()
        {
            if (!panduantxt()) {
                return false
            }
            var obj = document.getElementsByTagName("RlGL_Management");
            for(var i=0; i<obj.length; i ++){
                if(obj[i].checked){
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
</head>
<body>
    <form id="form1" runat="server">
 <div>
 <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增职称任聘</strong> 
</div>
    </div>
    <div class="page_main01">
        <div style="display: none">
           
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>聘任时间：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtAppointmentDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写聘任时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>专业：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtProfession" data-toggle="tooltip" data-placement="top"  ToolTip="请填写专业" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>专业技术资格名称：</strong>
                        </td>
                        <td width="70%" align="left">
                          
                             <asp:DropDownList ID="txtProfessionQualificationName" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择专业技术资格名称" Height="27px" Width="137px" ></asp:DropDownList>
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
                             <asp:RadioButtonList ID="RlGL_Management" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RlGL_Management_SelectedIndexChanged">
                                <asp:ListItem Value="是">是</asp:ListItem>
                                <asp:ListItem Value="否" Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" style=" background:none;" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" style=" background:none;">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加"   OnClientClick=" return tianjia()" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改"  OnClientClick=" return xiugai()" OnClick="Button2_Click" CssClass="btn" />
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