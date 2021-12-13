<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsDateAdd.aspx.cs" Inherits="ningdeScientManage_Web.ProjectsDateAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style4 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增项目申报时间</strong> 
</div><br />

    <div class="page_main01">
        <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style4" >
                            <strong>起始时间：</strong>
                        </td>
                        <td width="70%" align="left">
                          <input id="txtStartDate" runat="server" cssclass="Wdate"   style="height:25px;background:#eae9e9;" onfocus="WdatePicker()" readonly="readonly" />
                        </td>
                    </tr>
                    <tr  >
                        <td align="right" class="auto-style4">
                            <strong>终止时间：</strong>
                        </td>
                        <td width="70%" align="left">
                          <input id="txtEndDate" runat="server" cssclass="Wdate" style="height:25px;background:#eae9e9; " readonly="true" onfocus="WdatePicker()" />
                        </td>
                    </tr>
                    
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                            &nbsp;
                        </td>
                        <td width="70%" height="80" align="left" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="重 置" OnClick="Button2_Click" CssClass="btn" />
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

