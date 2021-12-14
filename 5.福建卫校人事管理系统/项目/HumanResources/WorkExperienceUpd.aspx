<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkExperienceUpd.aspx.cs" Inherits="HumanResources.WorkExperienceUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
           <script type="text/javascript">
        function panduan()
        {
            var StartDate = document.getElementById("txtStartDate");
            if (StartDate.value.length < 1) {
                alert("请填写开始时间！");
                return false;
            }
            var EndDate = document.getElementById("txtEndDate");
            if (EndDate.value.length < 1) {
                alert("请填结束时间！");
                return false;
            }
            var Department = document.getElementById("DlDepartmentId");
            if (Department.selectedIndex < 0) {
                alert("请选择部门！");
                return false;
            }
            var Role = document.getElementById("DlRoleId");       
            if (Role.selectedIndex < 0) {
                alert("请选择职务！");
                return false;
            }
            var rbl = document.getElementById("RlIsNow");
            var rbls = rbl.getElementsByTagName('input');
            var result = false;
            for (var i = 0; i < rbls.length; i++) {
                if (rbls[i].checked) {
                    result = true;
                    return true;
                }
            }
            if (!result) {
                alert("请选择是否当前任职！");
                return false;
            }           
            var rbl = document.getElementById("RlTransferStatus");
            var rbls = rbl.getElementsByTagName('input');
            var result = false;
            for (var i = 0; i < rbls.length; i++) {
                if (rbls[i].checked) {
                    result = true;
                    return true;
                }
            }
            if (!result) {
                alert("请填写审核状态！");
                return false;
            }
            return true;
        }

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 38%;
        }
        .auto-style2 {
            width: 38%;
            height: 32px;
        }
        .auto-style3 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
 <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;修改工作经历</strong> 
</div>
    </div>
    <div class="page_main01">
        <div style="display: none">
           
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 
                   
                  
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>开始时间：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtStartDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写开始时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                       <tr>
                        <td align="right" class="auto-style2">
                            <strong>结束时间：</strong>
                        </td>
                        <td width="70%" align="left" class="auto-style3">
                            <asp:TextBox ID="txtEndDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写结速时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>部门：</strong>
                        </td>
                        <td width="70%" align="left">
                          
                             <asp:DropDownList ID="DlDepartmentId" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择专业技术资格名称" Height="27px" Width="137px" ></asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>职务：</strong>
                        </td>
                        <td width="70%" align="left">
                          
                             <asp:DropDownList ID="DlRoleId" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择专业技术资格名称" Height="27px" Width="137px" ></asp:DropDownList>
                        </td>
                    </tr>
                   
                     <tr>
                         
                        <td align="right" class="auto-style1">
                          <strong>是否当前任职</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:RadioButtonList ID="RlIsNow" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="是">是</asp:ListItem>
                                <asp:ListItem Value="否">否</asp:ListItem>
                            </asp:RadioButtonList>
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
                     <tr id="tr1" runat="server">
                         
                        <td align="right" class="auto-style1">
                          <strong>审核状态</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:RadioButtonList ID="RlTransferStatus" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="有效">有效</asp:ListItem>
                                <asp:ListItem Value="无效">无效</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                   
                    <tr class="tr10">
                        <td height="80" align="right" style=" background:none;" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" style=" background:none;">
                          <asp:Button ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改" OnClientClick=" return panduan()" OnClick="Button2_Click" CssClass="btn" />
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
