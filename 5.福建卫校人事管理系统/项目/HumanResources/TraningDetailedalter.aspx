<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraningDetailedalter.aspx.cs" Inherits="HumanManage_Web.TraningDetailedalter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
 <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <meta name="keywords" content="jQuery日历控件,jQuery日历插件,jQuery日期控件,JS日历控件,JS日期插件,JS日期区间选择插件" />
<meta name="description" content="JS代码网提供jQuery日历控件,JS日历插件特效代码下载" />		
<script type="text/javascript" src="js/jquery-1.3.1.min.js"></script>		
<script type="text/javascript" src="js/jquery-ui-1.7.1.custom.min.js"></script>		
<script type="text/javascript" src="js/daterangepicker.jQuery.js"></script>		
<link rel="stylesheet" href="css/ui.daterangepicker.css" type="text/css" />		
<link rel="stylesheet" href="css/redmond/jquery-ui-1.7.1.custom.css" type="text/css"data-toggle="tooltip" data-placement="top"  title="ui-theme" />		
<script type="text/javascript">
    $(function () {
        $('#DTtxtLearningTime').daterangepicker({
            presetRanges: [
            //{text:'最近一周', dateStart:'yesterday-7days', dateEnd:'yesterday' },
            //{text:'最近一月', dateStart:'yesterday-1month', dateEnd:'yesterday' },
            //{text:'最近一年', dateStart:'yesterday-1year', dateEnd:'yesterday' }
            ],
            presets: {
                dateRange: '自定义时间'
            },
            rangeStartTitle: '起始日期',
            rangeEndTitle: '结束日期',
            nextLinkText: '下月',
            prevLinkText: '上月',
            doneButtonText: '确定',
            cancelButtonText: '取消',
            earliestDate: '',
            latestDate: Date.parse('today'),
            constrainDates: true,
            rangeSplitter: '-',
            dateFormat: 'yy-mm-dd',
            closeOnSelect: false,
            onOpen: function () {
                $('.ui-daterangepicker-dateRange').click().parent().hide();
            }
        }
                        );

    });
		</script>
    <style type="text/css">
       
        .bgcolor {
             width:98%;
            border:2px solid #808080;
        
        }
          .auto-style3 {
            width: 176px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >教职工在职进修学习申请表</div></div></div>
        <div class="page_main01">
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0" >
                        <tr>
                            <td align="right" class="auto-style3">
                                <strong>
                                <asp:Label ID="Label1" runat="server" Text="姓名:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style22">
                            
                                <asp:Label ID="txtUserName" runat="server" ></asp:Label>
                               
                            </td>
                           <td align="right" class="auto-style5">
                                <strong>
                                <asp:Label ID="Label3" runat="server" Text="性别:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style27">
                               
                            <asp:Label ID="txtSex" runat="server"></asp:Label>
                              
                                 </td>
                            
                         <td align="right" class="auto-style26">
                                <strong>
                                <asp:Label ID="Label5" runat="server" Text="出生年月:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style3">
                             
                                 <asp:Label ID="txtBirthday" runat="server" ></asp:Label>
                               
                            </td>
                            </tr>
                        <tr>
                             
                             
                            <td align="right" class="auto-style3">
                                <strong>
                                <asp:Label ID="Label7" runat="server" Text="学历:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style23">
                              
                                <asp:Label ID="txtUserEducation" runat="server" ></asp:Label>
                                 </td>
                             <td align="right" class="auto-style6">
                                 <strong>
                                 <asp:Label ID="Label9" runat="server" Text="专业:"></asp:Label>
                                 </strong>
                            </td>
                            <td align="left" class="auto-style27">
                                
                                <asp:Label ID="txtUserSpecialty" runat="server"></asp:Label>
                            
                                  </td>
                           <td align="right" class="auto-style26">
                                <strong>
                                <asp:Label ID="Label11" runat="server" Text="毕业学校:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left">
                               
                            <asp:Label ID="txtUserSchool" runat="server"  ></asp:Label>
                              
                            </td>
                            </tr>                    
                        <tr>
                             
                              <td align="right" class="auto-style3">
                                  <strong>
                                  <asp:Label ID="Label13" runat="server" Text="入校时间:"></asp:Label>
                                  </strong>
                            </td>
                            <td align="left" class="auto-style22">
                                <asp:Label ID="txtUserSchoolTime" runat="server"></asp:Label>

                            </td>
                        
                         
                            <td align="right" class="auto-style26">
                                         <strong>
                                         <asp:Label ID="Label17" runat="server" Text="专业技术职务:"></asp:Label>
                                         </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style3">
                               <asp:Label ID="txtProfessional" runat="server"></asp:Label>
                            </td>
                    
                            </tr>
                          <tr>
                              <td class="auto-style3" align="right"><strong>申请在职进修学习类型:</strong></td>
                              <td class="auto-style23"><asp:DropDownList ID="RadioButtonList1" runat="server" class="select1">
                                   <asp:ListItem Value="在职攻读学位研究生（硕士、博士）">在职攻读学位研究生（硕士、博士）</asp:ListItem>
                                   <asp:ListItem Value="委培（或定向）研究生（硕士、博士）">委培（或定向）研究生（硕士、博士）</asp:ListItem>                                  
                                   <asp:ListItem Value="同等学力申请硕士学位研究生课程进修班">同等学力申请硕士学位研究生课程进修班</asp:ListItem>
                                   <asp:ListItem Value="本科及以下学历教育">本科及以下学历教育；</asp:ListItem>
                                     <asp:ListItem Value="实践进修">实践进修；</asp:ListItem>
                                   <asp:ListItem Value="专业培训">专业培训</asp:ListItem>                                  
                                   <asp:ListItem Value="访问学者（国内、省内）">访问学者（国内、省内）</asp:ListItem>
                                   <asp:ListItem Value="骨干教师培训（国内、省内、企业顶岗）">骨干教师培训（国内、省内、企业顶岗）</asp:ListItem>
                                   <asp:ListItem Value="出国进修">出国进修</asp:ListItem>
                                   <asp:ListItem Value="其它">其它</asp:ListItem>
                                      </asp:DropDownList></td>
                              <td align="right" class="auto-style15"><strong>进修学习方式:</strong></td>
                              <td class="auto-style10" ><asp:DropDownList ID="RadioButtonList2" runat="server" class="select1">
                                   <asp:ListItem Value="脱产">脱产</asp:ListItem>
                                   <asp:ListItem Value="非脱产">非脱产</asp:ListItem>                                  
                                      </asp:DropDownList></td>
                              <td align="right" class="auto-style26"><strong>是否取得高校教师资格证或参加管理课程进修班：</strong></td>
                            <td class="auto-style3">
                                <asp:RadioButtonList ID="IsCertficateOrUnit1" RepeatLayout="Flow" runat="server" ReadOnly="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>

                             </tr>
                        <tr>
                          
                            <td align="right" class="auto-style1" >
                               <strong> 进修开始时间:</strong>
                               </td>
                            <td>
                                <input ID="DTtxtStartDate" data-toggle="tooltip" data-placement="top"  title="请输入进修开始时间 例如（2015-01-01）" runat="server" class="select1" onfocus="WdatePicker()"></input>
                            </td>
                             <td align="right" class="auto-style1" >
                               <strong> 进修结束时间:</strong>
                               </td>
                            <td>
                                <input ID="DTtxtEndDate" data-toggle="tooltip" data-placement="top"  title="请输入进修结束时间 例如（2015-12-30）" runat="server" class="select1" onfocus="WdatePicker()"></input>
                            </td>
                             <td class="auto-style24" align="right"><strong>拟前往进修学习单位名称:</strong></td>
                            <td  colspan="3">   
                                  <asp:TextBox ID="DTtxtLearningUnit"  data-toggle="tooltip" data-placement="top"  ToolTip="拟前往进修学习单位名称" runat="server" CssClass="select1" Width="80%"></asp:TextBox>

                            </td> 
                          
                        </tr>
                        <tr >
                              <td align="right" class="auto-style3"><strong>经费预算:</strong></td>
                            <td   style="text-align:left; "  colspan="5">
                                &nbsp;<asp:Label ID="Label23" runat="server" Text="预算"></asp:Label>
                                &nbsp;<asp:TextBox ID="DTtxtysFee" data-toggle="tooltip" data-placement="top"  ToolTip="请输入预算金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                <asp:Label ID="Label24" runat="server" Text="元"></asp:Label>
                                <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt; mso-font-kerning:1.0000pt;">
                                    其中：培养费（学费）:<asp:TextBox ID="DTtxtpyFee" data-toggle="tooltip" data-placement="top"  ToolTip="请输入培养费（学费）金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>元
                                </span>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt; mso-font-kerning:1.0000pt;">
                                   差旅费、住宿费:<asp:TextBox ID="DTtxtclFee" data-toggle="tooltip" data-placement="top"  ToolTip="请输入差旅费、住宿费金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>元
                                    </span>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt; mso-font-kerning:1.0000pt;">
                                 其它 <asp:TextBox ID="DTtxtotFee" data-toggle="tooltip" data-placement="top"  ToolTip="请输入其它金额" runat="server" CssClass="select1" Width="33px"></asp:TextBox>元
                                  </span>              
                                    </td>
                                  
                          
                        </tr>
                                 <tr >
                           
                                <td colspan="6"  style="text-align:center; height:20px; ">1.上级部门资助:<asp:TextBox ID="DTtxtFund1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入上级部门资助金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 2.学院资助:<asp:TextBox ID="DTtxtFund2" data-toggle="tooltip" data-placement="top"  ToolTip="请输入学院资助金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 3.部门资助:
                                    <asp:TextBox ID="DTtxtFund3" data-toggle="tooltip" data-placement="top"  ToolTip="请输入部门资助金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 4.负责人认可签名:<asp:TextBox ID="DTtxtFund4" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 5.其他渠道（请具体说明）:<asp:TextBox ID="DTtxtFund5" runat="server" Width="37px" data-toggle="tooltip" data-placement="top"  ToolTip="请输入其他聚到金额" CssClass="select1"></asp:TextBox>
                                    元</td>

                        </tr>
                        <br />
                           <caption>
                            <br />
                            <tr>
                                <td colspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="修改" />
                                </td>
                            </tr>
                        </caption>
                      
                    </table> 
                    <br /> 
                      &nbsp;&nbsp;&nbsp;<span>近三年进修情况如下：</span>
                   
                      <div style="margin-top: 20px">  
                    <asp:GridView HorizontalAlign="Center"  BackColor=" #d4d2d2"   CssClass="juzhong" ID="GridViewEmployee" runat="server" Width="98%"
                AutoGenerateColumns="False" AllowPaging="True" ShowFooter="True"
                OnRowCancelingEdit="GridViewEmployee_RowCancelingEdit" OnRowEditing="GridViewEmployee_RowEditing"
                OnRowDeleting="GridViewEmployee_RowDeleting" OnRowUpdating="GridViewEmployee_RowUpdating" >
                <AlternatingRowStyle BackColor="#bfbdbd" />
                <Columns>
                   <%-- <asp:TemplateField HeaderText="时间" HeaderStyle-Width="10%">

                        <EditItemTemplate>--%>
                            <%--编辑项模版
                            <asp:TextBox ID="TextTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' Width="25" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="编号" HeaderStyle-Width="10%">
                        <EditItemTemplate>
                            <%--编辑项模版--%>
                            <asp:Label ID="TextTraningFurId" runat="server" Text='<%# Bind("TraningFurId") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--普通显示模版--%>
                            <asp:Label ID="LabelTraningFurId" runat="server" Text='<%# Bind("TraningFurId") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="Button2" runat="server" Text="增  加" OnClick="Button2_Click" />
                        </FooterTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="时间" HeaderStyle-Width="15%">
                        <EditItemTemplate>
                            <%--编辑项模版--%>
                            <Asp:TextBox ID="TextTraningFurTime" runat="server" onfocus="WdatePicker()" Text='<%# Bind("TraningFurTime") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--普通显示模版--%>
                            <asp:Label ID="LabelTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <Asp:TextBox ID="TextTraningFurTime2" runat="server" onfocus="WdatePicker()" Width="90%" />
                        </FooterTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进修单位" HeaderStyle-Width="15%">
                        <EditItemTemplate>
                            <%--编辑项模版--%>
                            <asp:TextBox ID="TextTraningFurUnit" runat="server" Text='<%# Bind("TraningFurUnit") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--普通显示模版--%>
                            <asp:Label ID="LabelTraningFurUnit" runat="server" Text='<%# Bind("TraningFurUnit") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurUnit2" runat="server" Width="90%" />
                        </FooterTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进修内容" HeaderStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextTraningFurContent" runat="server" Text='<%# Bind("TraningFurContent") %>' Width="30%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelTraningFurContent" runat="server" Text='<%# Bind("TraningFurContent") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurContent2" runat="server" Width="60%" />
                        </FooterTemplate>
                        <HeaderStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进修形式" HeaderStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextTraningFurShape" runat="server" Text='<%# Bind("TraningFurShape") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelTraningFurShape" runat="server" Text='<%# Bind("TraningFurShape") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurShape2" runat="server" Width="50%" /> 
                        </FooterTemplate>

                        <HeaderStyle Width="20%" />

                    </asp:TemplateField>
                    
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" HeaderText="操作" HeaderStyle-Width="20%"  ButtonType="Button">
                    <HeaderStyle Width="20%" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView> 
        </div>
    
    </div>
    </form>
</body>
    </html>
