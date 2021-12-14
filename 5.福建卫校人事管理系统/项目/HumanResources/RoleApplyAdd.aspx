<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleApplyAdd.aspx.cs" Inherits="HumanManage_Web.RoleApplyAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        .select1     { border:1px; background:none; width:208px;  border-color:#fff; height:24px; line-height:24px; color:#333; margin-top:2px}
        .bggcolor {
            width:80%;
            border:2px solid  #cfd1d2;
            margin:0px auto;
          
        }
    </style>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >人员考核方案</div></div></div>
        
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
                                    <strong>考核名称：</strong>
                                </td>

                                <td width="12%" align="left">
                                   <asp:TextBox  ID="txtAssessmentName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写考核名称" style="overflow-y:auto" Height="27px" Width="137px" runat="server" CssClass="select1"  Columns="1" MaxLength="100" ></asp:TextBox>
                                </td>
                            
                                <td width="12%" align="right">
                                    <strong>申报职务：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:DropDownList AppendDataBoundItems="true" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请职称"  ID="DlRole" runat="server" CssClass="select1" Width="130px">
                                        <asp:ListItem Value="0">--请选择职务--</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                            
                                <td width="12%" align="right">
                                    <strong>申请年份：</strong>
                                </td>

                                <td width="12%" align="left">
                                   <%-- <asp:Label runat="server" ID="LBApplyDate"></asp:Label>--%>
                                     <asp:DropDownList AppendDataBoundItems="true" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择申请年份"  ID="DlFollDate" runat="server" CssClass="select1" Width="130px">
                                        <asp:ListItem Value="0">--请选择年份--</asp:ListItem>

                                    </asp:DropDownList>

                                </td>
                           
                            </tr>
                           
                            <tr>
                                <td width="12%" align="right">
                                    <strong>申报内容：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyContent"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写申报内容" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                              <tr>
                                <td width="12%" align="right">
                                    <strong>申报详细：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyDetailed"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写申报详细" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                            <tr class="tr10">
                                <td width="12%" align="right"></td>
                                <td colspan="3" align="right">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" Text="添 加" CssClass="btn" />
                                </td>
                                <td colspan="3" align="left">
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行保存" Text="保 存" CssClass="btn" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

<%--        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bggcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                           <td  align="right">
                                考核名称</td>
                            <td  align="left">
                                <asp:TextBox  ID="txtAssessmentName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写考核名称" style="overflow-y:auto" Height="27px" Width="137px" runat="server" CssClass="select1"  Columns="1" MaxLength="100" ></asp:TextBox>
                          </td>
                            </tr>
                         <tr>
                            <td  align="right">
                                申报部门</td>
                            <td  align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1"  Width="80px">
                                <asp:ListItem Value="0">请选择部门</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                            
                            </tr>                    
                        <tr>
                            <td align="right">申报职务</td>
                            <td align="left">
                                <asp:DropDownList ID="DlRole" runat="server" CssClass="select1" Width="80px">
                                    <asp:ListItem Value="0">请选择职务</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        <tr>
                            <td align="right">开始报名日期</td>
                            <td align="left">
                                <input id="txtStartDate" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写开始报名日期" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">截止报名日期</td>
                            <td align="left">
                                <input id="txtEndDate" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写截止报名日期" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">开始投票日期</td>
                            <td align="left">
                                <input id="txtStartVoteDate" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写开始投票日期" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">截止投票日期</td>
                            <td align="left">
                                <input id="txtEndVoteDate" runat="server" cssclass="Wdate" data-toggle="tooltip" data-placement="top"  title="请填写截止投票日期" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="right"><strong>申报内容：</strong> </td>
                            <td width="80%">
                                <asp:TextBox ID="txtApplyConten1t" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写申报内容" Columns="1" CssClass="select1" Height="400" MaxLength="2000" Rows="5" style="overflow-y:auto" TextMode="MultiLine" width="98%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right"><strong>申报详细：</strong> </td>
                            <td>
                                <asp:TextBox ID="txtApplyDetailed1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入申报详细" runat="server" Columns="1" CssClass="select1" Height="400" MaxLength="2000" Rows="5" style="overflow-y:auto" TextMode="MultiLine" width="98%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tr10">
                            <td colspan="2" style="text-align:center;">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" OnClick="Button1_Click" Text="添 加" />
                                &nbsp;
                                <asp:Button ID="Button2" runat="server" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击保存" OnClick="Button2_Click" Text="保 存" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>--%>
    </div>
    </form>
</body>
</html>


