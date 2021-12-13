<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchContentAdd.aspx.cs" Inherits="ScientManage_Web2.ResearchAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        html {
        height:290px;
        }
        .auto-style4 {
            width: 2%;
        }
        .auto-style5 {
            width: 3%;
        }
        .auto-style6 {
            width: 2%;
            height: 30px;
        }
        .auto-style7 {
            width: 3%;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
        .auto-style9 {
            width: 11%;
        }
        .auto-style10 {
            width: 11%;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
 <div class="min_height">
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >新增科研内容</div></div></div><br />

    <div class="page_main01">
        <div style="margin-top: 10px">

                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" class="auto-style9">
                            <strong>科研内容：</strong>
                        </td>
                        <td align="left" class="auto-style5">
                            <asp:TextBox ID="txtWorkCategoryName" CssClass="select1" runat="server" Height="25px" Width="250px"></asp:TextBox>
                        </td>                      
                          <td width="10%">
                              &nbsp;</td>
                    </tr>
                          <tr>
                                <td align="right" class="auto-style9">
                                    <strong>分值：</strong>
                        </td>
                        <td align="left" class="auto-style5">
                            <asp:TextBox ID="txtWorkValue" runat="server" CssClass="select1" Height="25px" Width="150px"></asp:TextBox>
                                </td>
                        <td width="10%" >
                            &nbsp;</td>
                       
                          </tr>
                                          <tr>
                                <td align="right" class="auto-style10">
                                    &nbsp;</td>
                        <td align="left" class="auto-style7">
                            <br />
                           <asp:Button ID="Button2" runat="server" Text="确 定" OnClick="Button1_Click" CssClass="btn" />
                                &nbsp;
                                            <asp:Button ID="Button3" runat="server" Text="取 消" OnClick="Button2_Click" CssClass="btn" />
                       
                                              </td>
                        <td width="10%"  class="auto-style8">
                                            &nbsp;</tr>
                         
                </table>

        </div>
    </div>
    </div>
                </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
