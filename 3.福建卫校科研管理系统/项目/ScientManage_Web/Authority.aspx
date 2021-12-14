<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authority.aspx.cs" Inherits="ScientManage_Web.Authority" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 374px;
        }

        .auto-style2 {
            height: 29px;
        }

        .auto-style3 {
            width: 374px;
            height: 29px;
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
            <div>
                <div class="aa">
                    <div class="parallelogram">
                        <div class="parallelogram2">角色权限管理</div>
                    </div>
                </div>
                <div class="page_main01">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="text-align: right;" class="auto-style3">
                                <strong>角色名称:</strong></td>
                            <td style="text-align: left;" class="auto-style2">
                                <asp:TextBox ID="txtRoleName" runat="server" Height="27px" CssClass="input6" Width="137px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>个人中心:</strong> </td>
                            <td style="text-align: left; height: 29px;">

                                <asp:CheckBoxList ID="CBPersonal" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>纵向项目管理:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBDeclare" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>横向项目管理:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBShort" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>纵向资金管理:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBLongCapital" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>横向资金管理:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBShortCapital" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <%--<tr>
               <td style="text-align:right; " class="auto-style1" >
                    <strong>教科研工作管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBResults" runat="server" RepeatDirection="Horizontal"  RepeatColumns="8" >
               </asp:CheckBoxList></td>
        </tr> --%>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>科研资源:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBSituation" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>专家信息管理:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBExpert" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>著作信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBTeaching" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>获奖信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBWinning" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>专利信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBWorkLoad" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>论文信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBPaper" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>指导学生信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBGuidance" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>科研项目信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBWorkLoadProjects" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>科研成果信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBHarvest" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>教材建设信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBT_Teaching" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>教学团队建设信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBTeaching_Team" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>专业建设信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBP_construction" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>课程建设信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBC_construction" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>竞赛获奖信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBC_winners" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>教学成果获奖信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBResults" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                          <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>专项分值信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBSpecial" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                         <tr>
                            <td style="text-align: right;" class="auto-style1">
                                <strong>教学工作量转化教研分信息:</strong> </td>
                            <td style="text-align: left; height: 29px;">
                                <asp:CheckBoxList ID="CBTeachToTeaching" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" class="auto-style3">
                                <strong>系统管理:</strong>                            </td>
                            <td style="text-align: left;" class="auto-style2">
                                <asp:CheckBoxList ID="CBSystem" runat="server" RepeatDirection="Horizontal" RepeatColumns="8">
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style1">&nbsp;
                            </td>
                            <td width="70%" align="left">&nbsp;<asp:Button ID="Search" runat="server" Text="保 存" OnClick="Save_Click" CssClass="btn" ToolTip="点击进行保存" />
                                &nbsp;
                        <asp:Button ID="Reset" runat="server" Text="返 回" OnClick="Return_Click" Visible="False"
                            CssClass="btn" ToolTip="点击返回上一页" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
