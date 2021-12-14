<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeDeliveryDetailed.aspx.cs" Inherits="HumanManage_Web.ResumeDeliveryDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >用户简历</div></div></div>
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
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="right"><strong>简历名称：</strong></td>
                            <td colspan="3">
                            <asp:TextBox ID="txtResumeName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入简历名称" runat="server"  CssClass="select1" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" align="right">
                                &nbsp;<strong>姓名：</strong></td>
                            <td width="20%" align="left">
                                <asp:TextBox ID="txtName" data-toggle="tooltip" data-placement="top"  ToolTip="请输入姓名 例如（张三）" runat="server" CssClass="select1"></asp:TextBox>
                            </td>
                           
                           <td width="10%" align="right">
                                &nbsp;<strong>性别：</strong></td>
                            <td width="20%" align="left">
                                <asp:DropDownList ID="DlGender" data-toggle="tooltip" data-placement="top"  ToolTip="点击选择性别" runat="server" CssClass="select1" Width="40%">
                                    <asp:ListItem>女</asp:ListItem>
                                    <asp:ListItem>男</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                         
                            
                              </tr>
                    
                        <tr>
                             
                            <td width="10%" align="right">
                                <strong>出生日期：</strong>
                            </td>
                            <td width="20%" align="left">
                               <input id="txtBirthday"  data-toggle="tooltip" data-placement="top"  ToolTip="请选择出生日期 例如（2015-11-12）" runat="server" cssclass="Wdate" readonly="true" onfocus="WdatePicker()"
                                    class="select1"/>

                            </td>
                           
                             
                            <td width="10%" align="right">
                                &nbsp;<strong>籍贯：</strong>
                            </td>
                            <td width="20%" align="left">
                                 <asp:TextBox ID="txtOrigin" data-toggle="tooltip" data-placement="top"  ToolTip="请输入籍贯" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                           
                        </tr>
                           <tr>
                             
                              <td width="10%" align="right">
                                <strong>电话号码：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:TextBox ID="txtPhone" data-toggle="tooltip" data-placement="top"  ToolTip="请输入电话号码 例如（13174535174）" runat="server"  CssClass="select1" MaxLength="18" ></asp:TextBox>
                            </td>
                            <td width="10%" align="right">
                                <strong>邮箱：</strong>
                            </td>
                            <td width="20%" align="left">
                               <asp:TextBox ID="txtEmail" runat="server"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入邮箱 例如（xxx@
                                    qq.com）139邮箱也可" CssClass="select1" MaxLength="18"></asp:TextBox>
                                    </td>
                     
                          
                               </tr>
                        <tr>
                              <td width="10%" align="right">
                                  &nbsp;<strong>学历：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:TextBox ID="txtEducation" data-toggle="tooltip" data-placement="top"  ToolTip="请输入学历 例如（本科）" runat="server" CssClass="select1" ></asp:TextBox>
                                    </td>
                            <td width="10%" align="right">
                                <strong>工作年限</strong></td>
                            <td width="20%" align="left">
                               <asp:TextBox ID="txtWorkLife" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入工作年限 例如（2）" CssClass="select1"></asp:TextBox>

                            </td>
                            </tr>  
                        <tr>
                            <td width="10%" align="right">
                                 &nbsp;<strong>求职意向：</strong></td>
                             <td width="20%" align="left" colspan="3">
                                 <asp:TextBox ID="txtJobIntention" data-toggle="tooltip" data-placement="top"  ToolTip="请输入求职意向 例如（软件方面）" runat="server" CssClass="select1"></asp:TextBox>
                             </td>
                         

                        </tr>
                         <tr>
                            <td width="10%" align="right">
                                 <strong>地址</strong></td>
                             <td width="20%" align="left" colspan="3">
                              <asp:TextBox ID="txtAddress" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入地址 例如（xx省xx市xx县xx镇xx村）" CssClass="select1" Width="80%"></asp:TextBox>

                             </td>
                            

                        </tr>


                        <tr>
                            <td width="25%" align="right">
                                <strong>主修课程：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtCourse"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入主修课程"  style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>个人能力：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtAbility"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入个人能力"  style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>获得证书：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtCertificate"   style="overflow-y:auto" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写获得证书" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                个人<strong>经历：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtPractice"  style="overflow-y:auto" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写个人经历" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>兴趣爱好：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtHobbies"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" data-toggle="tooltip" data-placement="top"  ToolTip="请填写兴趣爱好" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>
                         <tr>
                            <td width="25%" align="right">
                                <strong>获奖情况：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtReward"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  ToolTip="请填写获奖情况" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                         <tr>
                            <td width="25%" align="right">
                                <strong>批评情况：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtCriticism"    style="overflow-y:auto" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="请填写批评情况" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                              
                          <tr>
                            <td width="25%" align="right">
                                <strong>自我评价：</strong>
                            </td>
                            <td align="left" colspan="3" >
                           <asp:TextBox Height="80px" ID="txtEvaluation"    style="overflow-y:auto" runat="server" CssClass="select1" data-toggle="tooltip" data-placement="top"  ToolTip="请填写自我评价" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
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


