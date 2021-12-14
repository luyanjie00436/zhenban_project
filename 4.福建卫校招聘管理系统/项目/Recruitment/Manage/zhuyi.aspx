<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuyi.aspx.cs" Inherits="Recruitment.Manage.zhuyi" %>

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
            height:30px;

        }
        .input6 { border:1px solid #c5c5c5;     }
        .ww { width:80%;
              
            border-top:1px solid #c5c5c5;
             border-left:1px solid #c5c5c5;

            margin:0px auto;
        }
            .ww td {
               
                border-bottom:1px solid #c5c5c5;
             border-right:1px solid #c5c5c5;
             padding:2px;
             
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2">注意事项</div></div></div><br />

    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />

                <table width="98%" class="ww"   cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left" height="30px"　style="font-size:25px; " >
                            <strong>请在下面输入框输入注意事项：</strong>
                        </td>
                     </tr> <tr>
                        <td  align="left">
                            <asp:TextBox ID="txtZhuyi" CssClass="input6" runat="server"  data-toggle="tooltip" data-placement="top" ToolTip="输入考室号" Height="424px" TextMode="MultiLine" Width="99.86%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="tr10">
                       
                        <td width="70%"  align="center" valign="middle" style="background:none;">
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
