<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsOReviewScore.aspx.cs" Inherits="ScientManage_Web2.LongProjectsOReviewScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        Table {
            border-collapse: collapse;
            width: 1024px;
            margin-top: -1px;
        }

        .td1 {
            width: 133px;
            height: 24px;
            line-height: 24px;
            border: 1px solid #000000;
        }

        .td2 {
            width: 133px;
            text-align: center;
            height: 24px;
            line-height: 24px;
            border: 1px solid #000000;
        }

        .td4 {
            width: 100px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom: 1px solid #000000;
            line-height: 24px;
        }

        .td5 {
            width: 80px;
            height: 24px;
            line-height: 24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            text-align: right;
            border-bottom: 1px solid #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">其他项目评分</div>
                </div>
            </div>
            <br />
            <div class="page_main01">

                <table width="100%" class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr14">
                        <td class="btn_left1">
                            <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" class="btn11" />
                        </td>
                    </tr>
                </table>
                <div style="width: 1024px; height: 297mm; margin: 0 auto">
                    <div>
                        <table>
                            <tr>
                                <td class="td3" colspan="8">详细列表</td>
                            </tr>
                        </table>
                    </div>
                    <div>
                       
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">附件：</td>
                                <td style="text-align: left">
                                    <asp:Label ID="LFileUrl" runat="server" Visible="false"></asp:Label>
                                    <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" ID="LinkButton1" OnClick="LinkButton1_Click"></asp:LinkButton>
                                </td>
                                <td align="right">
                                    <strong>评审分值：</strong>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtScore" runat="server" Columns="1" CssClass="select1" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>评审意见：</strong>&nbsp;</td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="select1" Height="80" MaxLength="100" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" CssClass="btn" />
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
