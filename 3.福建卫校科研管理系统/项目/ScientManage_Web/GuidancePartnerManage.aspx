<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuidancePartnerManage.aspx.cs" Inherits="ScientManage_Web.GuidancePartnerManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <script src="js/yanzheng.js" type="text/javascript"></script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 50%;
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
        <div id="div_main" class="min_height">
            <div class="aa">
                <div class="parallelogram">
                    <div class="parallelogram2">指导学生合作者</div>
                </div>
            </div>
            <div class="page_main01">
                <div style="display: none">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="margin-bottom: 10px">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" class="auto-style1">请选择您申报的指导学生项目:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DlGuidance" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Partner_SelectedIndexChanged"
                                            CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="选择您申报的指导学生项目">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">合作者工号:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入合作者工号"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">合作者姓名:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="输入合作者姓名"></asp:TextBox>
                                        <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">选择人员:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                            CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择您的合作伙伴">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">排名:
                                    </td>
                                    <td>
                                        <input id="txtPartnerRank" runat="server" type="number" onblur="javascript:yzszfw1(this,0,100);" class="input1" data-toggle="tooltip" data-placement="top" title="输入本人排名 例如（1、2、3......）"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">分配分值:
                                    </td>
                                    <td>
                                        <input id="txtPartnerValue" runat="server" onblur="javascript:yzszfw1(this,0,99999999);" class="input1" data-toggle="tooltip" data-placement="top" title="输入分配分值 例如（1、2、3......）"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style1">
                                        <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行添加" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行修改" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="Panel2" runat="server">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr class="tr13">
                                    <td align="center" valign="middle">您已经添加的合作者信息如下
                                    </td>
                                </tr>
                            </table>
                            <div style="margin: 5px 0px 0px 0px; text-align: center;">
                                <asp:GridView ID="GridView1" BackColor=" #d4d2d2" CssClass="juzhong" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <AlternatingRowStyle BackColor="#bfbdbd" />
                                    <Columns>
                                        <asp:BoundField DataField="PartnerUserCardId" HeaderText="合作者工号">
                                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserName" HeaderText="合作者姓名">
                                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PartnerRank" HeaderText="排名">
                                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PartnerValue" HeaderText="分配分值">
                                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <div class="link02">
                                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("GuidancePartnerId") %>'
                                                        OnCommand="LinkButton6_Command" ToolTip="点击进行修改">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("GuidancePartnerId") %>'
                                                        OnClientClick="return confirm(&quot;你确定删除吗？&quot;);" OnCommand="LinkButton7_Command" ToolTip="点击进行删除">删除</asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
