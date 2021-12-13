﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachingPartnerManage.aspx.cs" Inherits="ningdeScientManage_Web.TeachingPartnerManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 49%;
        }
        .auto-style5 {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="min_height">
      <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >著作教材合作者</div></div></div><br />

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
                            <td align="right" class="auto-style5">
                                请选择您申报的著作教材:
                            </td>
                            <td>
                                <asp:DropDownList ID="DlTeaching" CssClass="input1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Partner_SelectedIndexChanged"
                                    >
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                            <td align="right" class="auto-style5">
                                合作者工号:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style5">
                                合作者姓名:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                           
                              <td align="right" class="auto-style5">
                                主编顺序:
                              </td>
                            <td  align="left">
                              <asp:DropDownList ID="DlEditedSequence" runat="server" Width="140px" CssClass="input1">
                                        <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                   <asp:ListItem Value="第一主编">第一主编</asp:ListItem>
                                   <asp:ListItem Value="第二主编">第二主编</asp:ListItem>
                                 <asp:ListItem Value="参编">参编</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                               </tr>
                        <tr>
                            <td align="right" class="auto-style5">
                                排名:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlPartnerRank" runat="server" Width="140px" CssClass="input1">
                                   <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                   <asp:ListItem Value="1">1</asp:ListItem>
                                   <asp:ListItem Value="2">2</asp:ListItem>
                                   <asp:ListItem Value="3">3</asp:ListItem>
                                   <asp:ListItem Value="4">4</asp:ListItem>
                                   <asp:ListItem Value="5">5</asp:ListItem>
                                   <asp:ListItem Value="6">6</asp:ListItem>
                                   <asp:ListItem Value="7">7</asp:ListItem>
                                   <asp:ListItem Value="8">8</asp:ListItem>
                                   <asp:ListItem Value="9">9</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style5">
                                分配分值:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPartnerValue" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style5">
                                <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                </div>

                <asp:Panel ID="Panel2" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr13">
                        <td align="center" valign="middle">
                            您已经添加的合作者信息如下
                        </td>
                    </tr>
                </table>
                <div style="margin: 5px 0px 0px 0px; text-align: center;">
                    <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong"   ShowHeaderWhenEmpty="true"  AutoGenerateColumns="False" Width="98%">
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
                             <asp:BoundField DataField="EditedSequence" HeaderText="主编顺序">
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
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("TeachingPartnerId") %>'
                                            OnCommand="LinkButton6_Command">编辑</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("TeachingPartnerId") %>'
                                            OnClientClick="return confirm(&quot;你确定删除吗？&quot;);" OnCommand="LinkButton7_Command">删除</asp:LinkButton>
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
