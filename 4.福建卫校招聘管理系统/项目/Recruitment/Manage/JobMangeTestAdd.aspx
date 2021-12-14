<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobMangeTestAdd.aspx.cs" Inherits="Recruitment.Manage.JobMangeTestAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 42%;
        }
        .auto-style2 {
            width: 38%;
        }
        .swn {
            height:25px;
            font-size:16px;
            background-color:#1c3e7e;
;
            color:#fff;
            text-align:left;
            line-height:1.5
        }
        table {
            border-top:1px solid #c5c5c5;
            border-left:1px solid #c5c5c5;
        }
            table td {
                padding:2px;
                border-bottom:1px solid  #c5c5c5;
                border-right:1px solid #c5c5c5;
            }
        .auto-style3 {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div>
      

          <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;修改考室信息</strong> 
    </div>
    </div>
    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                 
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style3" >
                            <strong>考室：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtTestAdd" CssClass="input6" runat="server" Height="27px" Width="137px" data-toggle="tooltip" data-placement="top" ToolTip="输入考室号"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="tr10">
                      <td class="auto-style3"></td>
                        <td   height="30" align="left"  style="background:none; ">
                            <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行修改" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
