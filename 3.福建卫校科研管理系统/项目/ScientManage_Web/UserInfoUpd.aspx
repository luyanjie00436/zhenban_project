<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoUpd.aspx.cs" Inherits="ScientManage_Web.UserInfoUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
        $(document).ready(function () {
         
        });
    </script>
    
     <script type="text/javascript">
         $(document).ready(function () {
             var _h = div_main.offsetHeight + 40;
             var _ifm = parent.document.getElementById("iframepage");
             $(_ifm).attr("height", _h);
             
            yingc("#GridView1");
            yingc("#GridView2");
            yingc("#GridView5");
            yingc("#GridView6");
        });

        function yingc(ViewId) {
            var tabrows = $(ViewId).find("tr").length;
            var tabcel = $(ViewId).find("tr").eq(tabrows - 1).find("td").length;
            if (tabcel == 1) {
                tabrows = tabrows - 1;
            }
            if (ViewId == "#GridView5") {
                for (var i = 1; i < tabrows; i++) {

                    if ($(ViewId).find("tr").eq(i).find("td").eq(2).text().length <= 1) {
                        $(ViewId).find("tr").eq(i).find("td").eq(4).find("a").remove();
                    }
                }
            }
            else {
                for (var i = 1; i < tabrows; i++) {
                    if ($(ViewId).find("tr").eq(i).find("td").eq(3).text().length <= 1) {
                        $(ViewId).find("tr").eq(i).find("td").eq(4).find("a").remove();
                    }
                }
            }
        }
    </script>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style>
        ..page_main01{padding:0px;}
        .fileup {
            visibility: hidden;
            width: 75px;
        }

        .left {
            width: 10%;
            text-align: right;
        }

        .right {
            width: 22%;
            text-align: left;
        }

        .rightt {
            text-align: center;
        }


        .photo {
            width: 71px;
            height: 99px;
            background-color: #cacbcc;
            margin: 0px auto;
        }

        table {
            width: 98%;
            border: 2px solid #d4d2d2;
        }

        .input1 {
            width: 150px;
            border: 1px solid #c3cdd4;
            padding-left: 3px;
            height: 24px;
            line-height: 24px;
            color: #333;
            margin-top: 2px;
            background: #dfdfdf;
        }

        .auto-style1 {
            width: 77px;
        }

        .auto-style2 {
            width: 50px;
            text-align: right;
        }
        .gridview_HeaderStyle {
            background:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div  id="div_main">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server">
                <div class="page_main01" style="width:100%; margin:0px auto; " >
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="9" align="center" style="width: 100%; height: 1px; background: #c5c5c7;">
                                <strong>个人基本信息</strong>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4" style="padding: 0; width: 80px; margin: 0;" class="auto-style1">
                                <div class="photo" style="width: 75px; overflow: hidden;">
                                    <img id="Image2" runat="server" src="~/imgs.aspx" style="width: 71px; padding: 0; margin: 0;" />
                                </div>
                                <div style="margin-top: 3px;">
                                    <a id="A1" style="text-align: center;" runat="server" href="Photo_dyxl.aspx?leibie=Photo">上传个人照片</a>
                                </div>
                            </td>
                            <td class="auto-style2">
                                <strong>工号：</strong>
                            </td>
                            <td class="ritht">
                                <asp:Label ID="txtUserCardId" runat="server" Enabled="false"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <strong>姓名：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top" runat="server" ToolTip="必填项请输入个人姓名" CssClass="input1" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <strong>性别：</strong>
                            </td>
                            <td class="ritht">
                                <asp:RadioButtonList ID="RBUserGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style2">
                                <strong>籍贯：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtOrigin" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="输入格式为:XX省XX市(县、区)" CssClass="input1"></asp:TextBox>
                            </td>



                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <strong>民族：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="DlNation" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请选择民族" runat="server"></asp:DropDownList>
                            </td>
                            <td width="150px" align="right">
                                <strong>出生年月：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtBirthday" runat="server" data-toggle="tooltip" data-placement="top" tooltip="出生日期自动获取身份证号码上的日期，无需输入" class="input1" disabled="disabled" onfocus="WdatePicker()" />
                            </td>
                            <td width="110px" align="right">
                                <strong>身份证号：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtIdCardNo" data-toggle="tooltip" data-placement="top" ToolTip="请输入公民18位身份证号码" runat="server" CssClass="input1"></asp:TextBox>
                            </td>

                            <td width="150px" align="right">
                                <strong>政治面貌：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="DlPolitical" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请选择政治面貌" runat="server"></asp:DropDownList>
                            </td>



                        </tr>
                        <tr>

                            <td width="100px" align="right">
                                <strong>在职状态：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="DlStatusName" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请选择在职状态" class="input1">
                                </asp:DropDownList>
                            </td>
                            <td width="100px" align="right">
                                <strong>入党时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtPartyDate" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>

                            <td width="150px" align="right">
                                <strong>入职学院时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtEntryDate" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>
                            <td width="150px" align="right">
                                <strong>参加工作时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtTakeWorkDate" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>





                        </tr>


                        <tr>
                            <td width="100px" align="right">
                                <strong>家庭住址：</strong>
                            </td>
                            <td class="ritht" colspan="3">
                                <asp:TextBox ID="txtAddress" Width="300px" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="请输入居住地址" CssClass="input1"></asp:TextBox>
                            </td>




                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <table width="100%" style="margin-top: 10px;" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="6" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                        <strong>管理干部信息</strong>
                                    </td>
                                </tr>
                                <tr style="text-align: center;">
                                    <td width="150px">
                                        <strong>是否管理干部：</strong>
                                    </td>
                                    <td width="100px">
                                        <strong>干部职级：</strong>
                                    </td>
                                    <td width="100px">
                                        <strong>现任职务：</strong>
                                    </td>
                                    <td width="100px">
                                        <strong>所在院系：</strong>
                                    </td>
                                    <td width="150px">
                                        <strong>任现职务时间：</strong>
                                    </td>
                                    <td width="100px">
                                        <strong>管理职级：</strong>
                                    </td>


                                </tr>
                                <tr style="align-content: center;">
                                    <td align="center">
                                        <asp:RadioButtonList ID="RlGL_Management" RepeatLayout="Flow" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RlGL_Management_SelectedIndexChanged">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td align="center">
                                        <asp:DropDownList ID="DlGL_CadreLevelName" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="副厅">副厅</asp:ListItem>
                                            <asp:ListItem Value="正处">正处</asp:ListItem>
                                            <asp:ListItem Value="副处">副处</asp:ListItem>
                                            <asp:ListItem Value="正科">正科</asp:ListItem>
                                            <asp:ListItem Value="副科">副科</asp:ListItem>
                                            <asp:ListItem Value="科员">科员</asp:ListItem>
                                            <asp:ListItem Value="办事员">办事员</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtGL_RoleName" runat="server" CssClass="input1"></asp:TextBox>
                                    </td>
                                    <td align="center">

                                        <asp:DropDownList ID="DlGL_Department" CssClass="input1" runat="server">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">

                                        <input id="txtGL_StartDate" runat="server" class="input1" onfocus="WdatePicker()" />

                                    </td>
                                    <td align="center">
                                        <asp:DropDownList ID="DlGL_ManagerLevelName" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="四级职员">四级职员</asp:ListItem>
                                            <asp:ListItem Value="五级职员">五级职员</asp:ListItem>
                                            <asp:ListItem Value="六级职员">六级职员</asp:ListItem>
                                            <asp:ListItem Value="七级职员">七级职员</asp:ListItem>
                                            <asp:ListItem Value="八级职员">八级职员</asp:ListItem>
                                            <asp:ListItem Value="九级职员">九级职员</asp:ListItem>
                                            <asp:ListItem Value="十级职员">十级职员</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <table width="100%" style="margin-top: 10px;" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="6" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                        <strong>专业技术职称信息</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <strong>有无具有专业技术职称</strong>
                                    </td>
                                    <td align="center">
                                        <strong>职称系列</strong>
                                    </td>
                                    <td align="center">
                                        <strong>职称等级</strong>
                                    </td>
                                    <td align="center">
                                        <strong>专技职级</strong>
                                    </td>
                                    <td align="center">
                                        <strong>所属部门</strong>
                                    </td>
                                    <td align="center">
                                        <strong>任现职称时间</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="rithtt" align="center">

                                        <asp:RadioButtonList ID="RlZY_SkillTitle" runat="server" AutoPostBack="true" ReadOnly="True" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RlZY_SkillTitle_SelectedIndexChanged">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>


                                    <td class="rithtt" align="center">

                                        <asp:DropDownList ID="DlZY_JobSeries" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="教师">教师</asp:ListItem>
                                            <asp:ListItem Value="实验">实验</asp:ListItem>
                                            <asp:ListItem Value="教育管理">教育管理</asp:ListItem>
                                            <asp:ListItem Value="图书档案">图书档案</asp:ListItem>
                                            <asp:ListItem Value="卫生">卫生</asp:ListItem>
                                            <asp:ListItem Value="会计">会计</asp:ListItem>
                                            <asp:ListItem Value="工程">工程</asp:ListItem>
                                            <asp:ListItem Value="科研">科研</asp:ListItem>
                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td class="rithtt">

                                        <asp:DropDownList ID="DlZY_TitleLevelName" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="正高">正高</asp:ListItem>
                                            <asp:ListItem Value="副高">副高</asp:ListItem>
                                            <asp:ListItem Value="中级">中级</asp:ListItem>
                                            <asp:ListItem Value="初级">初级</asp:ListItem>
                                            <asp:ListItem Value="试用期">试用期</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td class="rithtt">

                                        <asp:DropDownList ID="DlZY_SpecialSkills" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="专技二级">专技二级</asp:ListItem>
                                            <asp:ListItem Value="专技三级">专技三级</asp:ListItem>
                                            <asp:ListItem Value="专技四级">专技四级</asp:ListItem>
                                            <asp:ListItem Value="专技五级">专技五级</asp:ListItem>
                                            <asp:ListItem Value="专技六级">专技六级</asp:ListItem>
                                            <asp:ListItem Value="专技七级">专技七级</asp:ListItem>
                                            <asp:ListItem Value="专技八级">专技八级</asp:ListItem>
                                            <asp:ListItem Value="专技九级">专技九级</asp:ListItem>
                                            <asp:ListItem Value="专技十级">专技十级</asp:ListItem>
                                            <asp:ListItem Value="专技十一级">专技十一级</asp:ListItem>
                                            <asp:ListItem Value="专技十二级">专技十二级</asp:ListItem>
                                            <asp:ListItem Value="专业初期">专业初期</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td class="rithtt">

                                        <asp:DropDownList ID="DlZY_Department" CssClass="input1" runat="server">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td class="rithtt">

                                        <input id="txtZY_StartDate" runat="server" class="input1" onfocus="WdatePicker()" />

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <table width="100%" style="margin-top: 10px;" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="6" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                        <strong>教师系列信息</strong>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <strong>是否属于教师系列：</strong>
                                    </td>
                                    <td>
                                        <strong>教师类别：</strong>
                                    </td>
                                    <td>
                                        <strong>高校教师资格证书获取时间：</strong>
                                    </td>
                                    <td>
                                        <strong>现是否为专业带头人或负责人：</strong>
                                    </td>
                                    <td>
                                        <strong>现是否为骨干教师：</strong>
                                    </td>
                                    <td>
                                        <strong>现是否为双师型教师：</strong>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="center">

                                        <asp:RadioButtonList ID="RlJS_TeachersSeries" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RlJS_TeachersSeries_SelectedIndexChanged">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>

                                    <td align="center">

                                        <asp:DropDownList ID="DlJS_TeacherCategory" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="专任教师">专任教师</asp:ListItem>
                                            <asp:ListItem Value="兼课教师">兼课教师</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td align="center">

                                        <input id="txtJS_CertificateDate" runat="server" class="input1" onfocus="WdatePicker()" />

                                    </td>

                                    <td align="center">

                                        <asp:RadioButtonList ID="RlJS_MajorLeading" runat="server" ReadOnly="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>

                                    <td align="center">

                                        <asp:RadioButtonList ID="RlJS_BoneTeacher" runat="server" ReadOnly="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>

                                    <td align="center">

                                        <asp:RadioButtonList ID="RlJS_DoubleTeacher" runat="server" ReadOnly="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="5" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                        <strong>工勤信息</strong>
                                    </td>
                                </tr>
                                <tr style="text-align: center;">
                                    <td>
                                        <strong>是否工勤人员：</strong>
                                    </td>
                                    <td>
                                        <strong>职级：</strong>
                                    </td>
                                    <td>
                                        <strong>任现职级：</strong>
                                    </td>
                                    <td>
                                        <strong>任现职级时间：</strong>
                                    </td>
                                    <td>
                                        <strong>所在院系：</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:RadioButtonList ID="RlGQ_WorkersPeople" runat="server" AutoPostBack="true" ReadOnly="True" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RlGQ_WorkersPeople_SelectedIndexChanged">
                                            <asp:ListItem Value="是">是</asp:ListItem>
                                            <asp:ListItem Value="否">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td align="center">

                                        <asp:DropDownList ID="DlGQ_PostName" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="高级工">高级工</asp:ListItem>
                                            <asp:ListItem Value="中级工">中级工</asp:ListItem>
                                            <asp:ListItem Value="初级工">初级工</asp:ListItem>
                                            <asp:ListItem Value="普通工">普通工</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>

                                    <td align="center">

                                        <asp:DropDownList ID="DlGQ_Appointment" runat="server" class="input1">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="技术工一级">技术工一级</asp:ListItem>
                                            <asp:ListItem Value="技术工二级">技术工二级</asp:ListItem>
                                            <asp:ListItem Value="技术工三级">技术工三级</asp:ListItem>
                                            <asp:ListItem Value="技术工四级">技术工四级</asp:ListItem>
                                            <asp:ListItem Value="技术工五级">技术工五级</asp:ListItem>
                                            <asp:ListItem Value="普通工">普通工</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>

                                    <td align="center">

                                        <input id="txtGQ_StartDate" runat="server" class="input1" onfocus="WdatePicker()" />

                                    </td>

                                    <td align="center">

                                        <asp:DropDownList ID="DlGQ_Department" CssClass="input1" runat="server">
                                            <asp:ListItem Value="">-请选择-</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="9" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                <strong>学历信息</strong>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td rowspan="5">
                                <strong>学历学位信息：</strong>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <strong>第一学历：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="Dl_DYXL" CssClass="input1" runat="server">
                                    <asp:ListItem Value="">-请选择-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>获得时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtDYXL_Date" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>
                            <td class="auto-style2">
                                <strong>毕业院校：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtDYXL_School" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <strong>专业：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtDYXL_Profession" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <a id="Image_dyxl" runat="server" href="Photo_dyxl.aspx?leibie=FirstProfession">证书照片上传</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>最高学历：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="Dl_ZGXL" CssClass="input1" runat="server">
                                    <asp:ListItem Value="">-请选择-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>获得时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtZGXL_Date" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>
                            <td class="auto-style2">
                                <strong>毕业院校：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtZGXL_School" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <strong>专业：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtZGXL_Profession" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <a id="Image_zgxl" runat="server" href="Photo_dyxl.aspx?leibie=HeighestProfession">证书照片上传</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="width: 100%; text-align: center; height: 1px; background: #c5c5c7;">
                                <strong>学位信息</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>第一学位：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="Dl_DYXW" CssClass="input1" runat="server">
                                    <asp:ListItem Value="">-请选择-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>获得时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtDYXW_Date" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>
                            <td class="auto-style2">
                                <strong>毕业院校：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtDYXW_School" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <strong>专业：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtDYXW_Profession" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <a id="Image_dyxw" runat="server" href="Photo_dyxl.aspx?leibie=FirstDegree">证书照片上传</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>最高学位：</strong>
                            </td>
                            <td class="ritht">
                                <asp:DropDownList ID="Dl_ZGXW" CssClass="input1" runat="server">
                                    <asp:ListItem Value="">-请选择-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>获得时间：</strong>
                            </td>
                            <td class="ritht">
                                <input id="txtZGXW_Date" runat="server" class="input1" onfocus="WdatePicker()" />
                            </td>
                            <td class="auto-style2">
                                <strong>毕业院校：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtZGXW_School" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <strong>专业：</strong>
                            </td>
                            <td class="ritht">
                                <asp:TextBox ID="txtZGXW_Profession" runat="server" CssClass="input1"></asp:TextBox>
                            </td>
                            <td>
                                <a id="Image_zgxw" runat="server" href="Photo_dyxl.aspx?leibie=HeighestDegree">证书照片上传</a>
                            </td>
                        </tr>
                    </table>

                </div>
            </asp:Panel>
            <div class="page_main01">
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">职称聘任情况</div>
                <asp:GridView ID="GridView1" runat="server"  CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="UseOfficeId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProfessionQualificationName" HeaderText="专业技术资格名称">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Profession" HeaderText="专业">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AppointmentDate" HeaderText="聘任时间">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="查看照片">
                            <ItemTemplate>
                                <div class="link02">
                                    <a href='UsePhoto.aspx?UseOffice=<%# Eval("UseOfficeId")%>&keepThis=true&TB_iframe=true&height=400&width=500' class="fLink thickbox">查看照片</a>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="str001" />
                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">职业资格证书</div>

                <asp:GridView ID="GridView2" runat="server" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="JobCertificateId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobQualificationName" HeaderText="职业资格名称">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsssueUnit" HeaderText="发证单位">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobDate" HeaderText="获得时间">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="查看照片">
                            <ItemTemplate>
                                <div class="link02">
                                    <a href='JobCertificatePhoto.aspx?JobCertificate=<%# Eval("JobCertificateId")%>&keepThis=true&TB_iframe=true&height=400&width=500' class="fLink thickbox">查看照片</a>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="str001" />

                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">工作经验</div>

                <asp:GridView ID="GridView3" runat="server"  CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="WorkExperienceId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="在何部门担任何职务">
                            <ItemTemplate>
                                <div class="link02">
                                    <asp:Label runat="server" Text='<%# Eval("DepartmentName")%>'></asp:Label>-
                                      <asp:Label runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="IsNow" HeaderText="是否当前任职">
                            <HeaderStyle CssClass="gridview_HeaderStyle" Width="25%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="时间">
                            <ItemTemplate>
                                <div class="link02">
                                    <asp:Label runat="server" Text='<%# Eval("StartDate")%>'></asp:Label>-
                                      <asp:Label runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Remarks" HeaderText="备注">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="str001" />

                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">社会兼职情况</div>

                <asp:GridView ID="GridView4" runat="server" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ParttimejobId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="在何部门担任何职务">
                            <ItemTemplate>
                                <div class="link02">
                                    <asp:Label runat="server" Text='<%# Eval("DepartmentName")%>'></asp:Label>-
                                      <asp:Label runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="UnitName" HeaderText="单位名称">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="时间">
                            <ItemTemplate>
                                <div class="link02">
                                    <asp:Label runat="server" Text='<%# Eval("StartDate")%>'></asp:Label>-
                                      <asp:Label runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Remarks" HeaderText="备注">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="str001" />
                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">培训进修情况</div>

                <asp:GridView ID="GridView5" runat="server"  CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="StudyTrainId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TrainProjectName" HeaderText="培训项目名称">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TrainUnit" HeaderText="培训单位">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="时间">
                            <ItemTemplate>
                                <div class="link02">
                                    <asp:Label runat="server" Text='<%# string.Format("{0}-{1}",Eval("TrainStartDate"),Eval("TrainEndDate"))%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="查看照片">
                            <ItemTemplate>
                                <div class="link02">
                                    <a href='StudyTrainPhoto.aspx?StudyTrain=<%# Eval("StudyTrainId")%>&keepThis=true&TB_iframe=true&height=400&width=500' class="fLink thickbox">查看照片</a>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="str001" />
                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">历年获奖情况</div>

                <asp:GridView ID="GridView6" runat="server"  CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="PastAwardsId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AwardProjectName" HeaderText="获奖项目名称">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GrantUnit" HeaderText="授予单位">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AwardDate" HeaderText="获奖时间">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="查看照片">
                            <ItemTemplate>
                                <div class="link02">
                                    <a href='PastAwardsPhoto.aspx?PastAwards=<%# Eval("PastAwardsId")%>&keepThis=true&TB_iframe=true&height=400&width=500' class="fLink thickbox">查看照片</a>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="str001" />
                </asp:GridView>
                <div style="width:100%; height:28px; background:#c5c5c7; font-size:14px;  line-height:2; text-align:center;">年度考核情况</div>

                <asp:GridView ID="GridView7" runat="server" CssClass="juzhong" AllowPaging="True" AllowSorting="True"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" PageSize="10" Width="100%">
                
                    <Columns>
                        <asp:BoundField DataField="YearAssessmentId" HeaderText="编号">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Year" HeaderText="年度">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WorkCompletion" HeaderText="工作量完成情况">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AssessmentGrade" HeaderText="考核等次">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Remarks" HeaderText="备注">
                            <HeaderStyle CssClass="gridview_HeaderStyle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="str001" />
                </asp:GridView>
            </div>
            <div style="text-align: center;">
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="修 改" />
                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="返 回" />
            </div>
        </div>
    </form>
</body>
</html>
