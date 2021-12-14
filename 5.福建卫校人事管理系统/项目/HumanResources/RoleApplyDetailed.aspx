<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleApplyDetailed.aspx.cs" Inherits="HumanManage_Web.RoleApplyDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .bggcolor {
            width:80%;
            border:2px solid  #cfd1d2;
            margin:0px auto;
          
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >干部考核申请表</div></div></div>
            <div class="page_main01">

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="tr14">
                        <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                            <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"
                                class="btn1" />
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12%" align="right">
                                    <strong>工号：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                                </td>

                                <td width="12%" align="right">
                                    <strong>姓名：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LUserName" runat="server"></asp:Label>
                                </td>

                                <td width="12%" align="right">
                                    <strong>性别：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LGender" runat="server"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>民族：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label ID="LNation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
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
                                <td width="12%" align="right"></td>

                                <td width="12%" align="left"></td>
                            </tr>
                            <tr>

                                <td width="12%" align="right">
                                    <strong>考核名称：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="txtAssessmentName"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申报部门：</strong>
                                </td>
                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="DlDepartment"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申报职务：</strong>
                                </td>
                                <td width="12%" align="left">

                                    <asp:Label runat="server" ID="DlRole"></asp:Label>
                                </td>
                                <td width="12%" align="right">
                                    <strong>申请年份：</strong>
                                </td>

                                <td width="12%" align="left">
                                    <asp:Label runat="server" ID="DLFollDate"></asp:Label>

                                </td>
                            </tr>
                          
                            <tr>
                                <td width="12%" align="right">
                                    <strong>申报内容：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyContent" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入申请职称理由"  MaxLength="400" Rows="5" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                             
                            <tr>
                                <td width="12%" align="right">
                                    <strong>申报详细：</strong>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox Height="120" ID="txtApplyDetailed" Style="overflow-y: auto" runat="server" CssClass="select1" Width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  ToolTip="请输入申请职称理由"  MaxLength="400" Rows="5" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>
                        </table>
                        <br />
                        

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
   <%-- <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
     <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >人员考核申请表</div></div></div>
        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <table class="bggcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                           <td  align="right">
                                考核名称</td>
                            <td  align="left">
                                <asp:TextBox ID="txtAssessmentName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写考核名称" Enabled="false" style="overflow-y:auto" runat="server" CssClass="select1" Height="27px" Width="137px"  Columns="1" MaxLength="100" ></asp:TextBox>
                          </td>
                            
                            </tr>
                           <tr>
                             
                            <td  align="right">
                                申报部门</td>
                            <td  align="left">
                                <asp:DropDownList ID="DlDepartment" runat="server" Enabled="false"  CssClass="select1"  Width="80px">
                                <asp:ListItem Value="0">请选择部门</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                            
                            </tr>     
                        <tr>
                             
                            <td  align="right">
                                申报人员</td>
                            <td  align="left">
                                <asp:DropDownList ID="DlRole" Enabled="false" runat="server" CssClass="select1"  Width="80px">
                                </asp:DropDownList>
                             </td>
                            
                            </tr>                    
                        <tr>
                             
                            <td  align="right">
                                开始报名日期</td>
                            <td  align="left">
                                <input id="txtStartDate" data-toggle="tooltip" data-placement="top"  title="请选择开始报名日期"  Enabled="false" runat="server" cssclass="Wdate" readonly="true" 
                                    class="select1"/> 

                            </td>
                            </tr>
                          <tr>
                           
                               <td  align="right">
                                   截止报名日期</td>
                            <td  align="left">
                                <input id="txtEndDate" Enabled="false" data-toggle="tooltip" data-placement="top"  title="请选择截止报名日期" runat="server" cssclass="Wdate" readonly="true" 
                                    class="select1"/> 

                            </td>
                              
                               </tr> 
                          <tr>
                             
                            <td  align="right">
                                开始投票日期</td>
                            <td  align="left">
                                <input id="txtStartVoteDate" data-toggle="tooltip" data-placement="top"  title="请选择开始投票日期" Enabled="false" runat="server" cssclass="Wdate" readonly="true" 
                                    class="select1"/> 

                            </td>
                            </tr>
                          <tr>
                           
                               <td  align="right">
                                   截止投票日期</td>
                            <td  align="left">
                                <input id="txtEndVoteDate" data-toggle="tooltip" data-placement="top"  title="请选择截止投票日期" Enabled="false" runat="server" cssclass="Wdate" readonly="true" 
                                    class="select1"/> 

                            </td>
                              
                               </tr> 
                         <tr>
                            <td align="right">
                                <strong>申报内容：</strong>
                            </td>
                            <td width="80%">
                                 <asp:TextBox Height="400"  data-toggle="tooltip" data-placement="top"  ToolTip="请填写申报内容" ReadOnly="True" ID="txtApplyContent" style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                         <tr>
                            <td align="right">
                                <strong>申报详细：</strong>
                            </td>
                            <td >
                                 <asp:TextBox Height="400"  ReadOnly="true" style="overflow-y:auto" ID="txtApplyDetailed" runat="server" CssClass="select1" width="98%" data-toggle="tooltip" data-placement="top"  ToolTip="请填写申报详细" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>--%>
</body>
</html>


