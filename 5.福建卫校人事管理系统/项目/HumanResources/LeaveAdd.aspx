<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAdd.aspx.cs" Inherits="HumanManage_Web.LeaveAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
  <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >请假信息申请</div></div></div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                               <asp:Label ID="LGender" runat="server" ></asp:Label>
                                    </td>
                      
                            </tr>
                        <tr>
                                <td width="12%" align="right">
                                <strong>民族：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LNation" runat="server" ></asp:Label>
                            </td>
                             <td width="12%" align="right">
                                <strong>出生日期：</strong>
                            </td>
                            <td width="12%" align="left">
                           <asp:Label ID="LBirthday" runat="server" ></asp:Label>   </td>
                             <td width="12%" align="right">
                                <strong>入校时间：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LStartWork" runat="server" ></asp:Label>
                                 </td>
                            
                       
                          
                            </tr>                    
                        <tr>
                             
                           <td width="12%" align="right">
                                <strong>第一学位：</strong>
                            </td>
                            <td width="12%" align="left">
                               <asp:Label ID="LDegree" runat="server" ></asp:Label>
                            </td>
                             <td width="12%" align="right">
                                <strong>第一学历：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="LEducation" runat="server" ></asp:Label>
                            </td>
                             <td width="12%" align="right">
                                <strong>政治面貌：</strong>
                            </td>

                            <td width="12%" align="left">
                            <asp:Label ID="LPolitical" runat="server" ></asp:Label> </td>
                            </tr>
                          <tr>
                           
                              <td width="12%" align="right">
                                <strong>全天事件：</strong>
                            </td>
                            <td width="12%" align="left" colspan="3">
                         <asp:CheckBox runat="server" Text="将此项设置为不在特定时间开始或结束的全天活动" ID="check" onclick="smallChange(this)" />
                                   </td>
                              
                               </tr>  
                         <tr style="height:60px">
                           
                              <td width="12%" align="right">
                                <strong>开始时间：</strong>
                            </td>

                            <td width="12%" align="left" >
                            <input id="txtStartDate" runat="server" data-toggle="tooltip" data-placement="top"  title="点击选择请假开始日期也可输入日期 例如（2015-11-12）" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/> 
                                </td>
                             <td>
                                <asp:DropDownList ID="DlStartHH" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择请假开始所在日期的时间（小时）" CssClass="select1" Width="60px">
                                    <asp:ListItem>00:</asp:ListItem>
                                    <asp:ListItem>01:</asp:ListItem>
                                    <asp:ListItem>02:</asp:ListItem>
                                    <asp:ListItem>03:</asp:ListItem>
                                    <asp:ListItem>04:</asp:ListItem>
                                    <asp:ListItem>05:</asp:ListItem>
                                    <asp:ListItem>06:</asp:ListItem>
                                    <asp:ListItem>07:</asp:ListItem>
                                    <asp:ListItem>08:</asp:ListItem>
                                    <asp:ListItem>09:</asp:ListItem>
                                    <asp:ListItem>10:</asp:ListItem>
                                    <asp:ListItem>11:</asp:ListItem>
                                    <asp:ListItem>12:</asp:ListItem>
                                    <asp:ListItem>13:</asp:ListItem>
                                    <asp:ListItem>14:</asp:ListItem>
                                    <asp:ListItem>15:</asp:ListItem>
                                    <asp:ListItem>16:</asp:ListItem>
                                    <asp:ListItem>17:</asp:ListItem>
                                    <asp:ListItem>18:</asp:ListItem>
                                    <asp:ListItem>19:</asp:ListItem>
                                    <asp:ListItem>20:</asp:ListItem>
                                    <asp:ListItem>21:</asp:ListItem>
                                    <asp:ListItem>22:</asp:ListItem>
                                    <asp:ListItem>23:</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                             <td>
                              <asp:DropDownList ID="DlStartMM" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择请假开始所在日期的时间（分钟）" runat="server" CssClass="select1" Width="40px" >
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                               <td width="12%" align="right">
                                <strong>结束时间：</strong>
                            </td>
                            <td width="12%" align="left"  style="height:60px">
                               <input id="txtEndDate" data-toggle="tooltip" data-placement="top"  title="请点击选择或者手动输入请假结束的日期 例如（2015-11-12）" runat="server" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>
                                   </td>
                             <td>
                             <asp:DropDownList ID="DlEndHH" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择请假结束所在日期的时间（小时）" CssClass="select1" Width="60px" >
                                 <asp:ListItem>00:</asp:ListItem> 
                                   <asp:ListItem>01:</asp:ListItem>
                                    <asp:ListItem>02:</asp:ListItem>
                                    <asp:ListItem>03:</asp:ListItem>
                                    <asp:ListItem>04:</asp:ListItem>
                                    <asp:ListItem>05:</asp:ListItem>
                                    <asp:ListItem>06:</asp:ListItem>
                                    <asp:ListItem>07:</asp:ListItem>
                                    <asp:ListItem>08:</asp:ListItem>
                                    <asp:ListItem>09:</asp:ListItem>
                                    <asp:ListItem>10:</asp:ListItem>
                                    <asp:ListItem>11:</asp:ListItem>
                                    <asp:ListItem>12:</asp:ListItem>
                                    <asp:ListItem>13:</asp:ListItem>
                                    <asp:ListItem>14:</asp:ListItem>
                                    <asp:ListItem>15:</asp:ListItem>
                                    <asp:ListItem>16:</asp:ListItem>
                                    <asp:ListItem>17:</asp:ListItem>
                                    <asp:ListItem>18:</asp:ListItem>
                                    <asp:ListItem>19:</asp:ListItem>
                                    <asp:ListItem>20:</asp:ListItem>
                                    <asp:ListItem>21:</asp:ListItem>
                                    <asp:ListItem>22:</asp:ListItem>
                                    <asp:ListItem>23:</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                             <td>
                             <asp:DropDownList ID="DlEndMM" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择请假结束所在日期的时间（分钟）" CssClass="select1" Width="40px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             
                              
                               </tr> 


                        <tr>
                            <td width="12%" align="right">
                                <strong>请假理由：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="120" ID="txtLeaveReason" data-toggle="tooltip" data-placement="top"  ToolTip="请填写请假理由" style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                                
                        <tr class="tr10">
                            
                            
                          
                               <td colspan="8" style="text-align:center;">
                                                                   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" Text="添 加" CssClass="btn" />
                                   &nbsp;
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="保 存" data-toggle="tooltip" data-placement="top"  ToolTip="点击保存" CssClass="btn" />
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

