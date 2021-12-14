<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyTitleAppendix.aspx.cs" Inherits="HumanManage_Web.ApplyTitleAppendix" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
    </style>
</head>
<body>

    <form id="form2" runat="server">
        <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >附件管理</div></div></div>
        </div>
        <div class="page_main01">
            <div style="display: none">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">

                        <tr>
                            <td align="right" class="auto-style1">上传附件</td>
                            <td width="70%" align="left">
                                <asp:FileUpload ID="fupFileSend" runat="server" Width="230px" data-toggle="tooltip" data-placement="top"  ToolTip="选择要上传文件的路径" BackColor="#ccccff" />
                            </td>
                        </tr>
                        <tr class="tr10">
                            <td  align="right" class="auto-style1">&nbsp;
                            </td>
                            <td width="70%"  align="left"  valign="middle">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="上  传" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行上传" CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div >
            <span style="font-size:14px;">上传列表</span>
        </div>
        <div class="rightMain">
            <div class="page_main01">
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
                                    <asp:LinkButton ID="LinkButton7" CommandArgument='<%# Eval("fileid") %>' runat="server"
                                        OnCommand="LinkButton7_Command">下载</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton10" CommandArgument='<%# Eval("fileid") %>' runat="server"
                                        OnCommand="LinkButton10_Command" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行删除">删除</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <div   style="text-align:center;">
                    <asp:LinkButton ID="LinkButton9" runat="server" CssClass="btn_right" OnClick="LinkButton9_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击刷新当前页面">刷 新</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
