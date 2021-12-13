<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeUpd.aspx.cs" Inherits="ScientManage_Web2.NoticeUpd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
           <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;修改通知公告</strong> 
</div><br />

    <div class="page_main01">
        <div style="display: none">
        </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="30%" align="right">
                            <strong>内容：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtNoticeExplain" runat="server" CssClass="input6"  Height="40px" Width="355px" TextMode="MultiLine"></asp:TextBox>
                    </tr>
                     <tr>
                        <td width="30%" align="right">
                            <strong>附件：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:FileUpload ID="fupFileSend" runat="server"  CssClass="input6"  Width="203px"  />
                            &nbsp;
                            <asp:Label ID="LFileUrl" runat="server" Visible="false" />
                            &nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="附件下载"  ForeColor="blue" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </td>
                    </tr>
                       <tr>
                        <td width="30%" align="right">
                            <strong>是否修改附件：</strong>
                        </td>
                        <td width="70%" align="left">
                          <asp:RadioButtonList runat="server" ID="RBL1" OnSelectedIndexChanged="RBL1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" >
                              <asp:ListItem>是</asp:ListItem>
                              <asp:ListItem Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr class="tr10">
                        <td height="80" align="center" colspan="2">
                       
                            <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" CssClass="btn" />
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
