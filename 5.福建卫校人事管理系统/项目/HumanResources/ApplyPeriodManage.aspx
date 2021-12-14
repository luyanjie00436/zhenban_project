<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyPeriodManage.aspx.cs" Inherits="HumanManage_Web.ApplyPeriodManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/master.css" rel="Stylesheet" type="text/css" />

   
    <style type="text/css">
        /*TextBox显示为横线*/
        .txtTransverseLine {
            text-align: center;
            background: none;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: none;
            border-right-style: none;
            border-bottom-style: solid;
            border-left-style: none;
            border-top-color: #000000;
            border-right-color: #000000;
            border-bottom-color: #000000;
            border-left-color: #000000;
            width: 100px;
        }
    </style>
    <style type="text/css">
        /*Label显示为横线*/
        .labelTransverseLine {
            /*border-bottom:#000000 solid 1px;*/
            /*同等于下*/
            border-bottom-color: #000000;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            height: 20px;
            width: 100px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="min_height">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >学时申报</div></div></div>
            <div style="text-align: center">
               
                <h2>专业技术人员继续教育学时统计表</h2>
            </div>
            <div>
                <br />
            </div>
            <div style="text-align: center" class="page_main01">
                <asp:Label runat="server" Text="" ID="HiddenYearId" Visible="false"></asp:Label>
                <asp:Label runat="server" Text="" ID="labelUserCardId" Visible="false"></asp:Label>
                <br />
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                            <td align="right" class="auto-style1">
                                <strong>工号：</strong>
                            </td>
                            <td align="left">
                              <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请输入工号"></asp:TextBox>
                            </td>
                          
                             <td align="right">
                                <strong>姓名：</strong>
                            </td>
                            <td  align="left">
                                 <asp:TextBox ID="txtUserName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入姓名"></asp:TextBox> 
                                   <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                            </td>
                                 <td align="right" class="auto-style1">
                                选择年份:
                            </td>
                                  <td>
                                 <asp:DropDownList ID="DlYear" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="Year_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择年份">
                                </asp:DropDownList>
                            </td>
                           <td align="right" class="auto-style1">
                                选择人员:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </td>
                                 
                       </tr>
                    </table>
               
            </div>
            <div>
                <br />
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <asp:GridView ID="GridView1" BackColor=" #d4d2d2"   CssClass="juzhong" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" Width="98%" ShowFooter="true"
                                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>
                                    <asp:TemplateField HeaderText="数据编号" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="10%" CssClass="gridview_HeaderStyle" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("EducationId") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" Text="增  加" OnClick="Button1_Click" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="继续教育项目">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <%--编辑项模版--%>
                                            <asp:TextBox ID="TextBoxEditProject" runat="server" Text='<%# Bind("Project") %>' Width="90%" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <%--普通显示模版--%>
                                            <asp:Label ID="LabelProject" runat="server" Text='<%# Bind("Project") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBoxProject" runat="server" Width="90%" data-toggle="tooltip" data-placement="top"  ToolTip="输入您的继续教育项目" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="继续教育情况<br/>（参加天数、课程学时数、论文和科研立项情况、获得证书等）">
                                        <HeaderStyle Width="30%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxEditEduSituation" runat="server" Text='<%# Bind("EducationSituation") %>' Width="95%" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelEduSituation" runat="server" Text='<%# Bind("EducationSituation") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBoxEduSituation" runat="server" Width="95%" data-toggle="tooltip" data-placement="top"  ToolTip="参加天数、课程学时数、论文和科研立项情况、获得证书等" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申报学时">
                                        <HeaderStyle Width="10%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxEditDeclarePeriod" runat="server" Text='<%# Bind("DeclarePeriod") %>' Width="90%" TextMode="Number" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelDeclarePeriod" runat="server" Text='<%# Bind("DeclarePeriod") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBoxDeclarePeriod" runat="server" Width="90%" TextMode="Number" data-toggle="tooltip" data-placement="top"  ToolTip="请输入您的申报学时" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="核定学时">
                                        <HeaderStyle Width="10%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxEditInspectPeriod" runat="server" Text='<%# Bind("InspectPeriod") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelInspectPeriod" runat="server" Text='<%# Bind("InspectPeriod") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBoxInspectPeriod" runat="server"  Width="90%" TextMode="Number" data-toggle="tooltip" data-placement="top"  ToolTip="请输入您的核定学时"  />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" HeaderText="操作" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#0000cc" HeaderStyle-CssClass="gridview_HeaderStyle" />

                                  
                                </Columns>
                            </asp:GridView>

                            <asp:GridView ID="GridView2" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong" AllowSorting="True"
                                AutoGenerateColumns="False" Width="98%" ShowHeader="false">
                                <AlternatingRowStyle BackColor="#bfbdbd" />
                                <Columns>

                                    <asp:TemplateField HeaderText="合计学时:" ItemStyle-Width="55%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpPeriod" runat="server" Text="合计学时："/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总申报学时" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpDeclarePeriod" runat="server" Text='<%# Bind("sumDP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总核定学时" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpInspectPeriod" runat="server" Text='<%# Bind("sumIP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <table>
                                
                            </table>
                              <br />
                        
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
