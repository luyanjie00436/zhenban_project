<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraningAdd.aspx.cs" Inherits="HumanManage_Web.TraningAdd" %>

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
<link rel="stylesheet" href="css/bootstrap.min.css" />
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script>
    $(function () { $("[data-toggle='tooltip']").tooltip(); });
</script>

<script type="text/javascript">
    $(function () {
        $('#txtLearningTime').daterangepicker({
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
        .auto-style1 {
            height: 30px;
        }
        .auto-style3 {
            width: 353px;
        }
        .auto-style5 {
            width: 420px;
        }
        .auto-style6 {
            height: 30px;
            width: 420px;
        }
        .auto-style9 {
            width: 15%;
        }
        .auto-style10 {
            height: 30px;
            width: 15%;
        }
        .bgcolor {
            
        }
        .auto-style13 {
            width: 174px;
        }
        .weizhi {
            text-align:right;
        }
        .auto-style14 {
            width: 311px;
        }
        .auto-style16 {
            height: 30px;
            width: 347px;
        }
        .auto-style17 {
            height: 30px;
            width: 346px;
        }
        .auto-style19 {
            width: 311px;
            height: 30px;
        }
        .bgcolor {
            border:2px solid #808080;
        }
        .bgcolor td {
            border-right:2px solid #808080;
        }
          .auto-style20 {
              width: 174px;
              height: 30px;
          }
          .auto-style21 {
              width: 353px;
              height: 30px;
          }
          .auto-style22 {
              width: 361px;
          }
          .auto-style23 {
              width: 361px;
              height: 30px;
          }
        </style>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >进修培训申请</div></div></div>
        <div class="page_main01">
                    <table class="bgcolor" border="1" cellspacing="0" cellpadding="0" style="height: 300px">
                        <tr>
                             <td align="right" class="auto-style13">
                                <strong>工号：</strong>
                            </td>
                            <td  align="left" >
                              <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请输入工号"></asp:TextBox>
                            </td>
                              <td align="right" class="auto-style5">
                                <strong>
                                <asp:Label ID="Label1" runat="server" Text="姓名:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left">
                               <asp:TextBox ID="txtUserName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入姓名"></asp:TextBox> 
                                   <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                            </td>
                             <td align="right" class="auto-style22">
                                选择人员:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                          <%--  <td align="right" class="auto-style13">
                                <strong>
                                <asp:Label ID="Label1" runat="server" Text="姓名:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left">
                              
                                <asp:Label ID="txtUserName" runat="server"></asp:Label>
                            
                            </td>--%>
                           <td align="right" class="auto-style5">
                                <strong>
                                <asp:Label ID="Label3" runat="server" Text="性别:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style14">
                           
                            <asp:Label ID="txtSex" runat="server" ></asp:Label>
                            
                                 </td>
                            
                         <td align="right" class="auto-style3">
                                <strong>
                                <asp:Label ID="Label5" runat="server" Text="出生年月:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style3">
                                 <asp:Label ID="txtBirthday" runat="server" ></asp:Label>
                            </td>
                            </tr>
                        <tr>
                             
                            <td align="right" class="auto-style13">
                                <strong>
                                <asp:Label ID="Label7" runat="server" Text="学历:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style17">
                              
                                <asp:Label ID="txtUserEducation" runat="server"></asp:Label>
                                </td>
                             <td align="right" class="auto-style6">
                                 <strong>
                                 <asp:Label ID="Label9" runat="server" Text="专业:"></asp:Label>
                                 </strong>
                            </td>
                            <td align="left" class="auto-style19">
                              
                                <asp:Label ID="txtUserSpecialty" runat="server"></asp:Label>
                             
                                  </td>
                           <td align="right" class="auto-style22">
                                <strong>
                                <asp:Label ID="Label11" runat="server" Text="毕业学校:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left">
                             
                            <asp:Label ID="txtUserSchool" runat="server" ></asp:Label>
                             
                            </td>
                            </tr>                    
                        <tr>
                             
                              <td align="right" class="auto-style20">
                                  <strong>
                                  <asp:Label ID="Label13" runat="server" Text="入校时间:"></asp:Label>
                                  </strong>
                            </td>
                            <td align="left" class="auto-style16">
                                <asp:Label ID="txtUserSchoolTime" runat="server"></asp:Label>

                            </td>
                         
                            <td align="right" class="auto-style23">
                                         <strong>
                                         <asp:Label ID="Label17" runat="server" Text="专业技术职务:"></asp:Label>
                                         </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style21">
                               <asp:Label ID="txtProfessional" runat="server" ></asp:Label>
                            </td>

                   
                            </tr>
                          
                        <tr>
                            <td align="right" class="auto-style13">
                               <strong> 申请在职进修学习类型: </strong>

                            <td >
                                <asp:DropDownList ID="RadioButtonList1" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请在职进修学习类型"  runat="server" class="select1">
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
                                      </asp:DropDownList>
                            </td>
                            </td>
                            <td align="right"><strong>进修学习方式:</strong></td>
                            <td class="auto-style14" >
                               <asp:DropDownList ID="RadioButtonList2" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择进修学习方式"  class="select1">
                                   <asp:ListItem Value="脱产">脱产</asp:ListItem>
                                   <asp:ListItem Value="非脱产">非脱产</asp:ListItem>                                  
                                      </asp:DropDownList>
                               
                       </td>
                             <td align="right" class="auto-style22"><strong>是否取得高校教师资格证或参加管理课程进修班：</strong></td>
                            <td class="auto-style14">
                                <asp:RadioButtonList ID="IsCertficateOrUnit1" RepeatLayout="Flow" runat="server" ReadOnly="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                           
                        </tr>  
      <%--                  <tr>
                             <td class="left"><strong>是否取得高校教师资格证或参加管理kehceng：</strong></td>
                            <td class="right">
                                <asp:RadioButtonList ID="radioTeachers" RepeatLayout="Flow" runat="server" ReadOnly="True" Enabled="false" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                        </tr>--%>
                                
                        <tr >
                           
                               <td align="right" class="auto-style1" >
                               <strong> 进修开始时间:</strong>
                               </td>
                            <td>
                                <input ID="txtStartDate" data-toggle="tooltip" data-placement="top"  title="请输入进修开始时间 例如（2015-01-01）" runat="server" class="select1" onfocus="WdatePicker()"></input>
                            </td>
                             <td align="right" class="auto-style1" >
                               <strong> 进修结束时间:</strong>
                               </td>
                            <td>
                                <input ID="txtEndDate" data-toggle="tooltip" data-placement="top"  title="请输入进修结束时间 例如（2015-12-30）" runat="server" class="select1" onfocus="WdatePicker()"></input>
                            </td>
                             <td align="right" class="auto-style10" >
                             <strong> 拟前往进修学习单位名称:</strong>
                            </td>
                            <td class="auto-style1" colspan="3">
                                <asp:TextBox ID="txtLearningUnit" runat="server"  data-toggle="tooltip" data-placement="top"  title="请输入拟前往进修学习单位名称" CssClass="select1" Width="80%"></asp:TextBox>
                            </td>
                           
                            
                        </tr>
                          <tr>
                                <td  align="right"  class="auto-style9"  >
                               <strong>经费预算:</strong> 
                                &nbsp;</td>
                            <td  style="text-align:left;"  colspan="5">
                                  预算
                               <asp:TextBox ID="txtysFee" data-toggle="tooltip" data-placement="top"  ToolTip="请填写预算金额" runat="server" Width="33px" CssClass="select1"></asp:TextBox>
                                元 &nbsp; &nbsp;
                                其中：培养费（学费）:<asp:TextBox ID="txtpyFee" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写培养费（学费）金额" Width="33px" CssClass="select1"></asp:TextBox>元&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           差旅费、住宿费:<asp:TextBox ID="txtclFee" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写差旅费、住宿费金额" Width="33px" CssClass="select1"></asp:TextBox>元&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 其它 <asp:TextBox ID="txtotFee"  data-toggle="tooltip" data-placement="top"  ToolTip="请写填其它金额"  runat="server" CssClass="select1" Width="33px"></asp:TextBox>
                                                元</td>
                                  
                          
                        </tr>
                            <tr >
                           
                                <td colspan="6"  style="text-align:center;">1.上级部门资助:<asp:TextBox ID="txtFund1" data-toggle="tooltip" data-placement="top"  ToolTip="请写填上级部门资助金额" runat="server" CssClass="select1" Width="33px"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 2.学院资助:<asp:TextBox ID="txtFund2" data-toggle="tooltip" data-placement="top"  ToolTip="请写填学院资助金额" runat="server" CssClass="select1" Width="33px"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 3.部门资助:
                                    <asp:TextBox ID="txtFund3" data-toggle="tooltip" data-placement="top"  ToolTip="请填写部门资助金额" runat="server" CssClass="select1" Width="33px"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 4.本人自理:<asp:TextBox ID="txtFund4" runat="server" CssClass="select1" Width="33px"></asp:TextBox>
                                    元&nbsp;&nbsp;&nbsp;&nbsp; 5.其他渠道（请具体说明）:<asp:TextBox ID="txtFund5" data-toggle="tooltip" data-placement="top"  ToolTip="请填写其它渠道金额" runat="server" CssClass="select1" Width="37px"></asp:TextBox>
                                    元</td>

                        </tr>
               


                      
                        <caption>
                            <br />
                            <tr>
                                <td  align="center" colspan="6">
                                    <asp:Button ID="Button1" data-toggle="tooltip" data-placement="top"  ToolTip="点击提交申请"  runat="server" CssClass="btn11" OnClick="Button1_Click" Text="提交申请" />
                                </td>
                            </tr>
                        </caption>
                    </table> <br />
                    &nbsp;&nbsp;&nbsp;<span>近三年进修情况如下：</span>
                      <div style="margin-top: 20px">
            <asp:GridView HorizontalAlign="Center" BackColor=" #d4d2d2"   CssClass="juzhong" ID="GridViewEmployee" runat="server" Width="98%"
                AutoGenerateColumns="False" AllowPaging="True" ShowFooter="True"
                OnRowCancelingEdit="GridViewEmployee_RowCancelingEdit" OnRowEditing="GridViewEmployee_RowEditing"
                OnRowDeleting="GridViewEmployee_RowDeleting" OnRowUpdating="GridViewEmployee_RowUpdating" >
                <AlternatingRowStyle BackColor="#bfbdbd" />
                <Columns>
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
                            <%--<input ID="TextTraningFurTime" runat="server" onfocus="WdatePicker()"  Value='<%# Bind("TraningFurTime") %>' Width="90%" />--%>
                       <Asp:TextBox ID="TextTraningFurTime" runat="server" onfocus="WdatePicker()"  Text='<%# Bind("TraningFurTime") %>' Width="90%" />
                             </EditItemTemplate>
                        <ItemTemplate>
                            <%--普通显示模版--%>
                            <asp:Label ID="LabelTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                             <Asp:TextBox ID="TextTraningFurTime2" runat="server"  onfocus="WdatePicker()"  Width="90%" />
                           <%-- <input ID="TextTraningFurTime2" runat="server"  onfocus="WdatePicker()"  Width="90%" />--%>
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
    
    </div>
    </form>
</body>
    </html>