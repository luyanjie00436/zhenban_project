<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teaching_TeamExamineDetailed.aspx.cs" Inherits="ScientManage_Web.Teaching__TeamExamineDetailed" %>

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
            width: 80px;
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
                    <div class="parallelogram2">教学团队建设审批表</div>
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
                <div style="width: 1024px; height: 297mm; margin: 0 auto; margin-top: 5px;">
                    <div>
                        <table class="biaoa">
                            <tr>
                                <td class="td3" colspan="6" style="border-bottom: none;">详细列表</td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table class="biaob">
                            <tr>
                                <td class="td1">姓名</td>
                                <td class="td5">项目名称</td>
                                <td class="td5">级别</td>
                                <td class="td5">负责人</td>
                                <td class="td5">完成情况</td>
                                <td class="td5">起止时间</td>
                                <td class="td5">项目总分值</td>
                            </tr>
                            <tr>
                                <td class="td2">
                                    <asp:Label ID="LUserName" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LTeaching_TeamName" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LLeve" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LPrincipal" runat="server"></asp:Label>
                                </td>
                                <td class="td4">
                                    <asp:Label ID="LCompletion" runat="server"></asp:Label>
                                </td>
                                <td class="td5">
                                    <asp:Label ID="LStartEndDate" runat="server"></asp:Label>
                                </td>
                                <td class="td5">
                                    <asp:Label ID="LTotal_Project" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="td5">项目总分值说明</td>
                                <td class="td5">本年度项目总分值</td>
                                <td class="td5">本年度项目总分值说明</td>
                                <td class="td5">本年度个人工作量分值</td>
                                <td class="td4">备注</td>
                                <td class="td5">审核状态</td>
                                <td class="td5"></td>
                            </tr>
                            <tr>
                                <td class="td5" align="center">
                                    <asp:Label ID="LDescription_Project" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LAnnual" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LDescription_year" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LTeaching_TeamValue" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center" style="word-break: break-all; width: 100px;">
                                    <asp:Label ID="LRemarks" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="center">
                                    <asp:Label ID="LTransferStatus" runat="server"></asp:Label>
                                </td>
                                <td class="td5"></td>
                            </tr>
                            <tr>
                                <td class="td4">合作者列表</td>
                                <td class="td4" colspan="4" style="text-align: left; padding-left: 20px; width: 730px">
                                    <asp:Label ID="LPartner" runat="server"></asp:Label>
                                </td>
                                <td class="td5" align="right">申请附件：</td>
                                <td class="td5">
                                    <asp:Label ID="LFileUrl" runat="server" Visible="false"></asp:Label>
                                    <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" ID="LinkButton1" OnClick="LinkButton1_Click" ToolTip="点击下载申报附件"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <asp:DataList ID="dataOfYear" runat="server" Width="98%" CssClass="jj" BorderStyle="None">
                            <ItemTemplate>
                                <table class="biaoc">
                                    <tr>
                                        <td rowspan="2" style="border: 1px solid #000000; height: auto; width: 40px;">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                            审批
                                        </td>
                                        <td colspan="3"
                                            style="border: 1px solid #000000; text-align: left; padding-left: 20px; vertical-align: top;">意见：  
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExamineOpinion") %>' ToolTip="审批人填写意见"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid #000000;">审批人：  
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>' ToolTip="审批人姓名"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #000000;">审批日期： 
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ExamineDate") %>' ToolTip="审批日期"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #000000;">审批结果;
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ExamineResult") %>' ToolTip="审批结果"></asp:Label>
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
                                <td colspan="2">
                                    <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="input1" Height="80" MaxLength="400" Rows="5" TextMode="MultiLine" Width="98%" data-toggle="tooltip" data-placement="top" ToolTip="审批人填写意见"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td height="28">
                                    <br />
                                    <div class="page_title_txt">
                                        <asp:Button ID="Button1" runat="server" Text="同 意" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击同意申请" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="拒 绝" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击拒绝申请" />
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

