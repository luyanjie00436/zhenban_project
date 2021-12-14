<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherUpd.aspx.cs" Inherits="HumanResources.OtherUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
        function panduan()
        {
            var UserSource = document.getElementById("DlUserSource");
            if (UserSource.selectedIndex < 0) {
                alert("请选择来源信息！");
                return false;
            }
            var WorkLeave = document.getElementById("DlWorkLeave");
            if (WorkLeave.selectedIndex < 0) {
                alert("请选择离校原因！");
                return false;
            }
            var rbl = document.getElementById("RlPrepared");
            var rbls = rbl.getElementsByTagName('input');
            var result = false;
            for (var i = 0; i < rbls.length; i++){
                if (rbls[i].type == 'radio'){
                    if (rbls[i].checked){
                    result = true;
                    return true;
                    } 
                }
            }
            if (!result){
            alert("请选择编制信息！");
            return false;
        }
            var rbl = document.getElementById("RlForeignStaff");
            var rbls = rbl.getElementsByTagName('input');
            var result = false;
            for (var i = 0; i < rbls.length; i++){
                if (rbls[i].type == 'radio'){
                    if (rbls[i].checked) {
                    result = true;
                    return true;
                    }
                }
            }
            if (!result){
            alert("请选择是否外籍人员！");
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
    <strong>&nbsp;&nbsp;&nbsp;修改其他信息</strong> 
</div>
    </div>
    <div class="page_main01">
        <div style="display: none">
           
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 
                   
                   <tr>
                        <td align="right" class="auto-style1">
                            <strong>来源信息：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:DropDownList id="DlUserSource" data-toggle="tooltip" data-placement="top"  ToolTip="请选择来源信息" runat="server" CssClass="input6" Height="27px" Width="137px">
                                <asp:ListItem>应届高等学校毕业生</asp:ListItem>
                                <asp:ListItem>应届中等学校毕业生</asp:ListItem>
                                <asp:ListItem>军转干部安置</asp:ListItem>
                                <asp:ListItem>调入</asp:ListItem>
                                <asp:ListItem>其他</asp:ListItem>
                            </asp:DropDownList>
                      
                              </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <strong>离校时间：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtSchoolDate"  onfocus="WdatePicker()" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写离校时间" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     
                     <tr>
                        <td align="right" class="auto-style1">
                            <strong>离校原因：</strong>
                        </td>
                        <td width="70%" align="left">
                          
                             <asp:DropDownList ID="DlWorkLeave" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="请选择离校原因" Height="27px" Width="137" >
                                 <asp:ListItem>退休</asp:ListItem>
                                 <asp:ListItem>辞职</asp:ListItem>
                                 <asp:ListItem>辞退</asp:ListItem>
                                 <asp:ListItem>开除</asp:ListItem>
                                 <asp:ListItem>解聘</asp:ListItem>
                                 <asp:ListItem>调出</asp:ListItem>
                                 <asp:ListItem>其他</asp:ListItem>
                             </asp:DropDownList>
                        </td>
                    </tr>
                     <tr >
                         
                        <td align="right" class="auto-style1">
                          <strong>编制信息</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:RadioButtonList ID="RlPrepared" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="编制内">编制内</asp:ListItem>
                                <asp:ListItem Value="编制外">编制外</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                      <tr >
                         
                        <td align="right" class="auto-style1">
                          <strong>是否外籍人员</strong>
                        </td>
                        <td width="70%" align="left">
                             <asp:RadioButtonList ID="RlForeignStaff" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
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
                            &nbsp;<asp:Button
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
