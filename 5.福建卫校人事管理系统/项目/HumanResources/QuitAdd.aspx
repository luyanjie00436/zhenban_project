<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuitAdd.aspx.cs" Inherits="HumanManage_Web.QuitAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>


<script>
    $(function () { $("[data-toggle='tooltip']").tooltip(); });
</script>

     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >离职退休申请</div></div></div>
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
                            </tr>  <tr>
                             <td width="12%" align="right">
                                <strong>离职/退休：</strong>
                            </td>
                            <td width="12%" align="left">
                                 <asp:DropDownList ID="DlStatus"  data-toggle="tooltip" data-placement="top"  ToolTip="点击选择离职/退休"  runat="server" CssClass="select1" Width="80%" >
                                 <asp:ListItem>请选择离职/退休</asp:ListItem>
                                     <asp:ListItem>离职</asp:ListItem>
                                 <asp:ListItem>退休</asp:ListItem>      
                                 </asp:DropDownList>
                            </td>
                      
                           
                              <td width="12%" align="right">
                                <strong>离职时间：</strong>
                            </td>
                            <td width="12%" align="left">
                                <input id="txtQuitDate" data-toggle="tooltip" data-placement="top" title="请选择或者输入离职时间 例如（2015-11-12）" runat="server" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1">
                                 </td>
                               </tr>  
                        <tr>
                            <td width="12%" align="right">
                                <strong>离职理由：</strong>
                            </td>
                            <td colspan="7">
                                 <asp:TextBox Height="200" style="overflow-y:auto" ID="txtQuitReason" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="请填写离职理由" width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                          
                            </td>
                        </tr>  
                        
                        <tr class="tr10">
                            
                            
                              
                            
                               <td colspan="8" style="text-align:center;">
                                     <asp:Button ID="Button1" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加信息" OnClick="Button1_Click" Text="添 加" CssClass="btn" />
                                   &nbsp;
                                <asp:Button ID="Button2" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击保存信息" OnClick="Button2_Click" Text="保 存" CssClass="btn" />
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
