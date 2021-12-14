<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParttimejobAdd.aspx.cs" Inherits="HumanResources.ParttimejobAdd" %>

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
                alert("请填写开始时间 ！");
                return false;
            }
            var EndDate = document.getElementById("txtEndDate");
            if (EndDate.value.length < 1) {
                alert("请填写结束时间！");
                return false;
            }
            var DepartmentName = document.getElementById("txtDepartmentName");
            if (DepartmentName.value.length < 1) {
                alert("请填写部门！");
                return false;
            }
            var RoleName = document.getElementById("txtRoleName");
            if (RoleName.value.length < 1) {
                alert("请填写职务！");
                return false;
            }
            var UnitName = document.getElementById("txtUnitName");
            if (UnitName.value.length < 1) {
                alert("请填写单位！");
                return false;
            }
            return true;
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
        <strong>&nbsp;&nbsp;&nbsp;新增社会兼职情况</strong> 
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
                            <asp:TextBox ID="txtStartDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="开始时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>结束时间：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtEndDate" onfocus="WdatePicker()"  runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="结束时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
             <tr>
                        <td align="right" class="auto-style1">
                            <strong>部门：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtDepartmentName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写部门" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
             <tr>
                        <td align="right" class="auto-style1">
                            <strong>职务：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtRoleName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写职务" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
             <tr>
                        <td align="right" class="auto-style1">
                            <strong>单位名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtUnitName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写单位名称" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
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
                  
                   
                    
                    <tr class="tr10">
                        <td height="80" align="right" style=" background:none;" class="auto-style1">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle" style=" background:none;">
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加"  OnClientClick=" return panduan()" OnClick="Button1_Click" CssClass="btn" />&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改"  OnClientClick=" return panduan()" OnClick="Button2_Click" CssClass="btn" />
                        </td>
                    </tr>
                 
                </table>
   </div>
    </form>
</body>
</html>
