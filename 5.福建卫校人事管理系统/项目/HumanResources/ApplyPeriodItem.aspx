<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyPeriodItem.aspx.cs" Inherits="HumanManage_Web.ApplyPeriodItem" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
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

        .auto-style1 {
            background: url('images/page_title_bg.gif') repeat-x;
            font-size: 12px;
            text-align: center;
            font-weight: bold;
            white-space: nowrap;
            padding: 0 15px;
            width: 144px;
        }
    </style>
      <script type="text/javascript">
          //-----  下面是打印控制语句  ----------
          window.onbeforeprint = beforePrint;
          window.onafterprint = afterPrint;
          //打印之前隐藏不想打印出来的信息
          function beforePrint() {
              div4.style.display = 'none';
              div3.style.display = 'none';
              div2.style.display = 'none';

          }
          //打印之后将隐藏掉的信息再显示出来
          function afterPrint() {
              div4.style.display = '';
              div3.style.display = '';
              div2.style.display = '';
          }
          function printPage() {
              //  parent.iprint.style.display = "none";
              div4.style.display = "none";
              div2.style.display = "none";
              //   $("div3").css("display", "none");
              window.print();
              div4.style.display = "block";
              div2.style.display = "block";
              //  $("div3").css("display", "");
              return false;
          }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="min_height" style="width:800px; text-align:center; margin:0 auto;">
            <div >
                <table>
                    <tr>
                        <td style="padding: 0 0 9px 0; margin: 0">
                            <input id="div4" onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"
                                class="link04" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center">
                <h2>福建卫生职业技术学院&nbsp<asp:Label runat="server" Text="" ID="lableApplyYear"></asp:Label>&nbsp年度</h2>
                <h2>专业技术人员继续教育学时统计表</h2>
            </div>
            <div>
                <br />
            </div>
            <div style="text-align: center">
                <asp:Label runat="server" Text="" ID="HiddenYearId" Visible="false"></asp:Label>
                <asp:Label runat="server" Text="" ID="labelUserCardId" Visible="false"></asp:Label>
                <br />
             
                
                <asp:Label runat="server" Text="姓&nbsp名："></asp:Label>
                <asp:TextBox runat="server" ID="labelPersonName" class="txtTransverseLine" ReadOnly="true"></asp:TextBox>
                <asp:Label runat="server" Width="200px"></asp:Label>
                <asp:Label runat="server" Text="职&nbsp称："></asp:Label>
                <asp:TextBox runat="server" ID="labelPosition" class="txtTransverseLine" ReadOnly="true"></asp:TextBox>
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


                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" Width="100%">
                                <Columns>

                                    <%--<asp:TemplateField HeaderText="编号">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("EducationId") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" Text="增  加" OnClick="Button1_Click" />
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Center"/>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="继续教育项目">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />


                                        <ItemTemplate>
                                            <%--普通显示模版--%>
                                            <asp:Label ID="LabelProject" runat="server" Text='<%# Bind("Project") %>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="继续教育情况<br/>（参加天数、课程学时数、论文和科研立项情况、获得证书等）">
                                        <HeaderStyle Width="55%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />

                                        <ItemTemplate>
                                            <asp:Label ID="LabelEduSituation" runat="server" Text='<%# Bind("EducationSituation") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申报学时">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelDeclarePeriod" runat="server" Text='<%# Bind("DeclarePeriod") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="核定学时">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelInspectPeriod" runat="server" Text='<%# Bind("InspectPeriod") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                </Columns>
                            </asp:GridView>

                            <asp:GridView ID="GridView2" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" Width="100%" ShowHeader="false">
                                <Columns>

                                    <asp:TemplateField HeaderText="合计学时:" ItemStyle-Width="70%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpPeriod" runat="server" Text="合计学时：" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总申报学时" ItemStyle-Width="15%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpDeclarePeriod" runat="server" Text='<%# Bind("sumDP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总核定学时" ItemStyle-Width="15%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAddUpInspectPeriod" runat="server" Text='<%# Bind("sumIP") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                                <br />
                         <div style="width:100%; text-align:left;">
    <asp:Label runat="server" Text="部门负责人审核签字："></asp:Label><asp:Label runat="server" Width="100px"></asp:Label><asp:Label runat="server" Text="（公章）"></asp:Label>
                         <br />
                               <br />
                               <br />
                            <asp:Label runat="server" Width="50%" Text="复核：__________________________"></asp:Label><asp:Label runat="server" Width="50%" Style="text-align: right" Text="填表日期：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp年&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp月&nbsp&nbsp&nbsp&nbsp&nbsp日&nbsp&nbsp&nbsp&nbsp&nbsp"></asp:Label>

                         </div>
                           
                            <div>
                                <br />
                            </div>
                            <div>
                                <br />
                            </div>
                            <div>
                                <br />
                            </div>
                            <%--<script language="javascript">
                                function printsetup() {
                                    web.execwb(8, 1); // 打印页面设置 
                                }
                                function printpreview() {
                                    web.execwb(7, 1); //打印页面预览
                                }
                                function copyToClipBoard() {
                                    var clipBoardContent = "";
                                    clipBoardContent += document.title;
                                    clipBoardContent += "\n";
                                    clipBoardContent += this.location.href;
                                    window.clipboardData.setData("Text", clipBoardContent);
                                    alert("复制成功，粘贴即可！");
                                }
                            </script>



                            <div class="msg" id="webprint" style="text-align:right">
                                <object classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" id="web" name="web" height="0" width="0"></object>
                                <input type="button" value="打印" onclick="javascript: window.print();" />
                                <input type="button" value="页面设置" onclick="javascript: printsetup();" />
                                <input type="button" value="打印预览" onclick="javascript: printpreview();" />
                                <input type="button" value="复制本文链接和标题到剪贴板" onclick="copyToClipBoard()" />
                            </div>--%>
                            <object id="WebBrowser" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0" width="0">
                            </object>

                            <style media="print" type="text/css">
                                　　 .Noprint {
                                    display:none;
                                }

                                　　 .PageNext {
                                    page-break-after: always;
                                }
                            </style>

                            <div class="msg" id="webprint" style="text-align:right">
                          
                           <input id="div2" type="button" value="打印" onclick=" printPage() " style="width: 60px;
                height: 27px;" />
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
