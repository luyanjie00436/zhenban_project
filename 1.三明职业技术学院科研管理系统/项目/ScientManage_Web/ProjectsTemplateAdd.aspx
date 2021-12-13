<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsTemplateAdd.aspx.cs" Inherits="ScientManage_Web2.ProjectsTemplateAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>项目模板添加</title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
                   <div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;新增项目模板</strong> 
</div><br />

         <div class="page_main01">
             <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style4" >
                            <strong>类别：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:DropDownList ID="DLCategory" CssClass="select1" Width="137px" runat="server">
                                             <asp:ListItem Value="纵向项目申报">纵向项目申报</asp:ListItem>
                                             <asp:ListItem Value="纵向项目中检">纵向项目中检</asp:ListItem>
                                             <asp:ListItem Value="纵向项目结题">纵向项目结题</asp:ListItem>
                                  <asp:ListItem Value="横向项目立项">横向项目立项</asp:ListItem>
                                  <asp:ListItem Value="横向项目立项">横向项目结题</asp:ListItem>
                                  <asp:ListItem Value="经费预算">经费预算</asp:ListItem> 
                                  <asp:ListItem Value="经费变更">经费变更</asp:ListItem>
                                  <asp:ListItem Value="经费决算">经费决算</asp:ListItem>

                                        </asp:DropDownList>   </td>
                    </tr>
                      <tr>
                        <td align="right" class="auto-style4" >
                            <strong >名称：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtTemplateName" runat="server" CssClass="input6" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style4">
                            <strong >选择上传文件：</strong>
                        </td>
                        <td width="70%" align="left">
                          <asp:FileUpload ID="fupFileSend" runat="server" CssClass="input6" Width="203px" />
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
             </div>
    </form>
</body>
</html>
