<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearAssessmentAdd.aspx.cs" Inherits="HumanResources.YearAssessmentAdd" %>

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
            var Year = document.getElementById("txtYear");
            if (Year.value.length < 1) {
                alert("请填年度！");
                return false;
            }
            var Completion = document.getElementById("txtWorkCompletion");
            if (Completion.value.length < 1) {
                alert("请填写工作量完成情况！");
                return false;
            }
            var Grade = document.getElementById("txtAssessmentGrade");
            if (Grade.value.length < 1) {
                alert("请填写考核等次！");
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
    <strong>&nbsp;&nbsp;&nbsp;新增年度考核</strong> 
</div>
    </div>
    <div class="page_main01">
        <div style="display: none">
           
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                   <tr>
                        <td align="right" class="auto-style1">
                            <strong>年度：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtYear" data-toggle="tooltip" data-placement="top"  ToolTip="请填写年度" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>工作量完成情况：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtWorkCompletion" data-toggle="tooltip" data-placement="top"  ToolTip="请填写工作量完成情况" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style1">
                            <strong>考核等次：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtAssessmentGrade" data-toggle="tooltip" data-placement="top"  ToolTip="请填写考核等次" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr
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
                            <asp:Button ID="Button1" runat="server" Text="添 加" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" OnClientClick=" return panduan()" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="修 改" data-toggle="tooltip" data-placement="top"  ToolTip="点击修改" OnClientClick=" return panduan()" OnClick="Button2_Click" CssClass="btn" />
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
