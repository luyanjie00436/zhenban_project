<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchInformationUpd.aspx.cs" Inherits="ScientManage_Web2.ResearchInformationUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 3%;
        }
        .auto-style5 {
            width: 8%;
        }
        .auto-style6 {
            width: 7%;
            height: 30px;
        }
        .auto-style7 {
            width: 8%;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
        .auto-style9 {
            width: 12%;
            height: 30px;
        }
        .auto-style10 {
            width: 12%;
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
                            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >修改科研信息</div></div></div><br />
<br />


    <div class="page_main01">
        <div style="margin-top: 10px">

                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                <td align="right" class="auto-style9">
                                    <strong>内容：</strong>
                        </td>
                        <td align="left" class="auto-style7">
                            <asp:TextBox ID="txtWorkCategoryName" CssClass="select1" runat="server" Height="25px" Width="200px"></asp:TextBox>
                                              </td>
                        <td width="10%"  class="auto-style8">
                                            &nbsp;</tr>
                          <tr>
                              <td  align="right" class="auto-style10">
                                  <strong>分值：</strong>
                              </td>
                              <td class="auto-style5">

                                  <asp:TextBox ID="txtWorkValue" CssClass="select1" runat="server" Height="25px"></asp:TextBox>

                              </td>
                              <td width="10%" >
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style10">

                              </td>
                              <td class="auto-style5">

                             <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" />
                        &nbsp;&nbsp;
                           <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" CssClass="btn" />

                              </td>
                              <td>

                              </td>
                          </tr>
                </table>

                    <br />
                    <br />

        </div>
    </div>
    </div>
                </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
