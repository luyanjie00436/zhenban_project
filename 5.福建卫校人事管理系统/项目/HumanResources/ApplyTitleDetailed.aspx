<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyTitleDetailed.aspx.cs" Inherits="HumanManage_Web.ApplyTitleDetailed" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >职称申请表</div></div></div>
            <div class="page_main01">

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr14">
                        <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                            <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"
                                class="btn1" />
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12%" align="right">
                                    <strong>工号：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                                </td>

                                <td width="12%" align="right">
                                    <strong>姓名：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LUserName" runat="server"></asp:Label>
                                </td>

                                <td width="12%" align="right">
                                    <strong>性别：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LGender" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>民族：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LNation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="12%" align="right">
                                    <strong>出生日期：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LBirthday" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>入校时间：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LStartWork" runat="server"></asp:Label>
                                </td>

                             


                            </tr>
                            <tr>




                                <td width="12%" align="right">
                                    <strong>第一学位：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LDegree" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>第一学历：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LEducation" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>政治面貌：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <asp:Label ID="LPolitical" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right"></td>

                                <td width="12%" align="left"></td>
                            </tr>
                            <tr>

                                <td width="12%" align="right">
                                    <strong>申请部门：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="DLDepartment"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请职称：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="DLApplyTitle"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请职级：</strong>
                                </td>
                                <td width="12%" align="left">

                                    <asp:Label runat="server" ID="DLPost"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请时间：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="LBApplyDate"></asp:Label>

                                </td>
                            </tr>
                            <tr style="height: 60px">

                                <td width="12%" align="right">
                                    <strong>职称系列：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <input id="txtTitleSeries" data-toggle="tooltip" data-placement="top"  title="职称系列" runat="server" cssclass="Wdate" class="select1" readonly="true" />
                                </td>
                                <td width="12%" align="right">
                                    <strong>专业：</strong>
                                </td>
                                <td width="12%" align="left" style="height: 60px">
                                    <input id="txtMajor" runat="server" cssclass="Wdate" data-toggle="tooltip" data-placement="top"  title="请输入专业信息" class="select1" readonly="true" />
                                </td>


                                <td width="12%" align="right">
                                    <strong>平均分值：</strong>
                                </td>
                                <td width="12%" align="left" style="height: 60px">
                                    <asp:TextBox ID="txtAverageFraction" runat="server" Columns="1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入平均分值" CssClass="select1" Rows="5" Height="19px" Width="50px" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td width="12%" align="right">
                                    <strong>评分人数：</strong>
                                </td>
                                <td width="12%" align="left" style="height: 60px">
                                    <asp:TextBox ID="textScorePerNum" runat="server" Columns="1" CssClass="select1" Rows="5" data-toggle="tooltip" data-placement="top"  ToolTip="请输入平均人数" Height="19px" Width="50px"  ReadOnly="true"></asp:TextBox>
                                </td>


                            </tr>
                            <tr>
                                <td width="12%" align="right">
                                    <strong>申请职称理由：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyReason" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入申请职称理由"  MaxLength="400" Rows="5" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AutoGenerateColumns="False" Width="98%">
                           <AlternatingRowStyle BackColor="#bfbdbd" />
                             <Columns>

                                <asp:BoundField DataField="filename" HeaderText="名称">
                                    <HeaderStyle />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="filetype" HeaderText="文档类型">
                                    <HeaderStyle />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <div class="link02">
                                            <asp:LinkButton ID="LinkButton8" CommandArgument='<%# Eval("fileid") %>' runat="server"
                                                OnCommand="LinkButton8_Command" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行预览">预览</asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
