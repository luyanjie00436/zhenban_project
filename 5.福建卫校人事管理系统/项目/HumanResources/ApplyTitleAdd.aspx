<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyTitleAdd.aspx.cs" Inherits="HumanManage_Web.ApplyTitleAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function smallChange(obj) {
            if (obj.checked == true) {
                document.getElementById("DlStartHH").style.display = "none"
                document.getElementById("DlStartMM").style.display = "none"
                document.getElementById("DlEndHH").style.display = "none"
                document.getElementById("DlEndMM").style.display = "none"
            }
            else {
                document.getElementById("DlStartHH").style.display = "block"
                document.getElementById("DlStartMM").style.display = "block"
                document.getElementById("DlEndHH").style.display = "block"
                document.getElementById("DlEndMM").style.display = "block"
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
         <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >职称申请</div></div></div>
            
            
            <div class="page_main01">
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12%" align="right">
                                    <strong>工号：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请输入工号"></asp:TextBox>
                                </td>

                                <td width="12%" align="right">
                                    <strong>姓名：</strong>
                                </td>
                                <td width="12%" align="left">
                                      <asp:TextBox ID="txtUserName" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入姓名"></asp:TextBox> 
                                   <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                                </td>
                                  <td align="right" class="auto-style1">
                                选择人员:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </td>
                                <td width="12%" align="right">
                                    <strong>性别：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LGender" runat="server"></asp:Label>
                                </td>
                              
                            </tr>
                            <tr>
                                  <td width="12%" align="right">
                                    <strong>民族：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LNation" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>出生日期：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LBirthday" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>入校时间：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LStartWork" runat="server"></asp:Label>
                                </td>



                            </tr>
                            <tr>
                            
                                <td width="12%" align="right">
                                    <strong>第一学位：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LDegree" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>第一学历：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LEducation" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>政治面貌：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <asp:Label ID="LPolitical" runat="server"></asp:Label>
                                </td>
                              
                            </tr>
                            <tr>

                                <td width="12%" align="right">
                                    <strong>申请部门：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:DropDownList ID="DLDepartment" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请部门"  AppendDataBoundItems="true" runat="server" CssClass="select1" Width="130px">
                                        <asp:ListItem Value="0">--请选择部门--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请职称：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:DropDownList AppendDataBoundItems="true" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请职称"  ID="DLApplyTitle" runat="server" CssClass="select1" Width="130px">
                                        <asp:ListItem Value="0">--请选择职称--</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请职级：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:DropDownList ID="DLPost" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请职级"  runat="server" AppendDataBoundItems CssClass="select1" Width="130px">
                                        <asp:ListItem Value="0">--请选择职级--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请时间：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="LBApplyDate"></asp:Label>

                                </td>
                            </tr>
                            <tr style="height: 60px">

                                <td width="12%" align="right">
                                    <strong>职称系列：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <input id="txtTitleSeries" data-toggle="tooltip" data-placement="top"  title="请填写职称系列" runat="server" cssclass="Wdate" class="select1" />
                                </td>
                                <td width="12%" align="right">
                                    <strong>专业：</strong>
                                </td>
                                <td width="12%" align="left" style="height: 60px">
                                    <input id="txtMajor" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写专业信息" cssclass="Wdate" class="select1" />
                                </td>


                                <td width="12%" align="right">
                                    <strong>申报年度：</strong>
                                </td>
                                
                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="LBApplyYear"></asp:Label>
                                </td>

                                <td width="12%" align="left" style="height: 60px">
                                    
                                </td>
                                <td width="12%" align="left" style="height: 60px">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td width="12%" align="right">
                                    <strong>申请理由：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyReason"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写申请理由" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                            <tr class="tr10">
                                <td width="12%" align="right"></td>
                                <td colspan="3" align="right">
                                    <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" Text="添 加" CssClass="btn" />
                                </td>
                                <td colspan="3" align="left">
                                    <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行保存" Text="保 存" CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
