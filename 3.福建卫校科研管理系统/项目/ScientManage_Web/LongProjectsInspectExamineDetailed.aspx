<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsInspectExamineDetailed.aspx.cs" Inherits="ScientManage_Web.LongProjectsInspectExamineDetailed" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
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
            height: 24px;
            line-height: 24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom: 1px solid #000000;
        }

        table {
            width: 98%;
            margin: 0px auto;
            text-align: center;
        }

            table tbody tr th {
                border: 1px solid #000;
            }

            table tbody tr td {
                border: 1px solid #000;
            }

        .page_main01 table tr td {
            line-height: 30px;
            color: #333;
            padding: 5px 0px;
        }
    </style>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">项目中检审批表</div>
                </div>
            </div>
            <div class="page_main01">
                <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr14">
                        <td style="padding: 0 0 9px 0; margin: 0; float: right; margin-right: 155px; border: none;">
                            <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"
                                class="btn1" />
                        </td>
                    </tr>
                </table>
                <div style="width: 1024px; height: 297mm; margin: 0 auto">
                    <div>
                        <table class="biaoa">
                            <tr>
                                <td class="td3" colspan="6">申报人基本信息
                                </td>
                            </tr>
                            <tr>
                                <td align="right">工号：</td>
                                <td align="left">
                                    <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                                </td>
                                <td align="right">姓名：</td>
                                <td align="left">
                                    <asp:Label ID="LUserName" runat="server"></asp:Label>
                                </td>
                                <td align="right">所在院（系）：</td>
                                <td align="left">
                                    <asp:Label ID="LDepartmentName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">职称：</td>
                                <td align="left">
                                    <asp:Label ID="LUserJob" runat="server"></asp:Label>
                                </td>
                                <td align="right">职级：</td>
                                <td align="left">
                                    <asp:Label ID="LUserPost" runat="server"></asp:Label>
                                </td>
                                <td align="right">出生年月：</td>
                                <td align="left">
                                    <asp:Label ID="LBirthday" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="td3" colspan="6" style="border-bottom: none;">详细列表</td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table class="biaob">
                            <tr>
                                <td align="right">项目编号：</td>
                                <td>
                                    <asp:Label runat="server" ID="LLongProjectsId"></asp:Label>
                                </td>
                                <td align="right">项目名称：</td>
                                <td>
                                    <asp:Label runat="server" ID="LLongProjectsName"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right">项目类别：</td>
                                <td>
                                    <asp:Label runat="server" ID="LProjectsSubject"></asp:Label>
                                </td>
                                <td align="right">项目级别：</td>
                                <td>
                                    <asp:Label runat="server" ID="LProjectsLevel"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right">项目来源：</td>
                                <td class="td5">
                                    <asp:Label ID="LProjectsFrom" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="right">协作单位：</td>
                                <td class="td5">
                                    <asp:Label ID="LCompany" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="td5" align="right">中检附件：</td>
                                <td class="td5">
                                    <asp:Label ID="LFileUrl" runat="server" Visible="false"></asp:Label>
                                    <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" ID="LinkButton1" OnClick="LinkButton1_Click" ToolTip="点击下载中检附件"></asp:LinkButton>
                                </td>
                                <td class="td5" align="right">项目申报详细：</td>
                                <td class="td5">
                                    <asp:LinkButton ForeColor="blue" Text="查看详细" runat="server" ID="LinkButton2" OnClick="LinkButton2_Click" ToolTip="点击跳转到项目申请审批表"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">项目立项详细：</td>
                                <td colspan="3" style="text-align: left; padding-left: 20px;">
                                    <asp:LinkButton ForeColor="blue" Text="查看详细" runat="server" ID="LinkButton3" OnClick="LinkButton3_Click" ToolTip="点击跳转到项目立项审批表"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <asp:DataList ID="dataOfYear" runat="server" Width="98%" CssClass="jj" BorderStyle="None">
                            <ItemTemplate>
                                <table class="biaoc">
                                    <tr>
                                        <td rowspan="2" style="border: 1px solid #000000; height: auto; width: 40px;">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("RankName") %>'></asp:Label>审批
                                        </td>
                                        <td colspan="3" style="border: 1px solid #000000; text-align: left; padding-left: 20px; vertical-align: top;">意见： 
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExamineOpinion") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid #000000;">审批人：  
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #000000;">审批日期： 
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ExamineDate") %>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #000000;">审批结果;
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ExamineResult") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        </asp:DataList>
                        <table class="biaoe" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 10%;" rowspan="2">
                                    <strong>审批意见：</strong>&nbsp;</td>
                                <td colspan="6">
                                    <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="input1" Height="80" MaxLength="400" Rows="5" TextMode="MultiLine" Width="98%" ToolTip="输入审批意见"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="28">
                                    <div class="page_title_txt">
                                        <asp:Button ID="Button1" runat="server" Text="同 意" OnClick="Button1_Click" CssClass="btn" ToolTip="点击同意申请" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="拒 绝" OnClick="Button2_Click" CssClass="btn" ToolTip="点击拒绝申请" />
                                    </div>
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
