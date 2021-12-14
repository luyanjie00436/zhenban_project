<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeAdd.aspx.cs" Inherits="HumanManage_Web.ResumeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >简历添加</div></div></div>
        <div class="page_main01">
               <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" data-toggle="tooltip" data-placement="top"   title="点击返回上一页" type="button" value="返回上一页" 

class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10%" align="right">
                                <strong>用户工号：</strong>
                            </td>
                            <td width="20%" align="left">
                              <asp:Label ID="LUserCardId" runat="server"></asp:Label>
                                 </td>
                           
                           <td width="10%" align="right">
                                <strong>姓名：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:Label ID="LUserName" runat="server"></asp:Label>  </td>
                             <td width="10%" align="right">
                                <strong>性别：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:Label ID="LGender" runat="server"></asp:Label> 
                                    </td>
                         
                            
                              </tr>
                    
                        <tr>
                             
                            <td width="10%" align="right">
                                <strong>出生日期：</strong>
                            </td>
                            <td width="20%" align="left">
                            <asp:Label ID="LBirthday" runat="server"></asp:Label> 

                            </td>
                           
                             
                            <td width="10%" align="right">
                                <strong>民族：</strong>
                            </td>
                            <td width="20%" align="left">
                                 <asp:Label ID="LNation" runat="server"></asp:Label> 
                            </td><td width="10%" align="right">
                                <strong>籍贯：</strong>
                            </td>
                            <td width="20%" align="left">
                            <asp:Label ID="LOrigin" runat="server"></asp:Label> 
                                </td>
                        </tr>
                           <tr>
                             
                              <td width="10%" align="right">
                                <strong>电话号码：</strong>
                            </td>
                            <td width="20%" align="left">
                                 <asp:TextBox ID="txtPhone" runat="server" data-toggle="tooltip" data-placement="top"  title="请输入电话号码"  CssClass="select1" ></asp:TextBox>
                           
                            </td>
                            <td width="10%" align="right">
                                <strong>邮箱：</strong>
                            </td>
                            <td width="20%" align="left">
                               <asp:TextBox ID="txtEmail" runat="server" data-toggle="tooltip" data-placement="top"  title="请输入邮箱"  CssClass="select1" ></asp:TextBox>
                           
                                    </td>
                     
                          
                              <td width="10%" align="right">
                                <strong>政治面貌：</strong>
                            </td>

                            <td width="20%" align="left">
                           <asp:Label ID="LPolitical" runat="server"></asp:Label>   </td>
                             
                               </tr>
                        <tr>
                              <td width="10%" align="right">
                                <strong>婚姻状况：</strong>
                            </td>
                            <td width="20%" align="left">
                                 <asp:TextBox ID="txtMarriage" runat="server" data-toggle="tooltip" data-placement="top"  title="请输入电话号码"  CssClass="select1" ></asp:TextBox>
                           
                                    </td>
                            <td width="10%" align="right">
                                <strong>最高学历：</strong>
                            </td>
                            <td width="20%" align="left">
                                <asp:Label ID="LEducation" runat="server"></asp:Label> 
                            </td>
                              <td width="10%" align="right">
                                <strong>最高学位：</strong>
                            </td>
                            <td width="20%" align="left">
                                 <asp:Label ID="LDegree" runat="server"></asp:Label> 
                            </td>
                            </tr>  
                        <tr>
                            <td width="10%" align="right" class="auto-style1">
                                 <strong>专业：</strong>
                                 </td>
                             <td width="20%" align="left" class="auto-style1">
                                 <asp:TextBox ID="txtProfessional" data-toggle="tooltip" data-placement="top"  title="请输入专业信息" runat="server"  CssClass="select1" ></asp:TextBox>
                             </td>
                            <td width="10%" align="right" class="auto-style1">
                                 <strong>身高：</strong>
                            </td>
                             <td width="20%" align="left" class="auto-style1">
                                  <asp:TextBox ID="txtHeight" runat="server"  data-toggle="tooltip" data-placement="top"  title="请输入身高信息 例如（158cm）" CssClass="select1" ></asp:TextBox>
                             </td>
                            <td width="10%" align="right" class="auto-style1">
                                 <strong>健康情况：</strong>
                            </td>
                             <td width="20%" align="left" class="auto-style1">
                                  <asp:TextBox ID="txtHealthy" runat="server"  data-toggle="tooltip" data-placement="top"  title="请输入健康状况 例如（健康或者不健康）" CssClass="select1" ></asp:TextBox>
                             </td>

                        </tr>
                         <tr>
                            <td width="10%" align="right">
                                 <strong>求职意向：</strong>
                                 </td>
                             <td width="20%" align="left">
                                 <asp:TextBox ID="txtJobIntention" runat="server" data-toggle="tooltip" data-placement="top"  title="请输入求职意向"  CssClass="select1" ></asp:TextBox>
                             </td>
                            <td width="10%" align="right">
                                 <strong>毕业院校：</strong>
                            </td>
                             <td width="20%" align="left">
                                  <asp:TextBox ID="txtGraduated" runat="server"  data-toggle="tooltip" data-placement="top"  title="请输入毕业院校 例如（福建信息职业技术学院）" CssClass="select1" ></asp:TextBox>
                             </td>
                            <td width="10%" align="right">
                                
                            </td>
                             <td width="20%" align="left"></td>

                        </tr>


                        <tr>
                            <td width="25%" align="right">
                                <strong>主修课程：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtCourse"  data-toggle="tooltip" data-placement="top"  title="请填写主修课程"  style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>个人能力：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtAbility"   style="overflow-y:auto" runat="server" CssClass="select1" width="98%" data-toggle="tooltip" data-placement="top"  title="请填写个人能力" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>获得证书：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtCertificate"   style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  title="请填写获得证书" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>个人经历：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtPractice"  style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  title="请填写个人经历" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                          <tr>
                            <td width="25%" align="right">
                                <strong>兴趣爱好：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtHobbies"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  title="请填写兴趣爱好" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>
                         <tr>
                            <td width="25%" align="right">
                                <strong>获奖情况：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtReward"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  title="请填写获奖情况" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                         <tr>
                            <td width="25%" align="right">
                                <strong>批评情况：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtCriticism"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" Columns="1" data-toggle="tooltip" data-placement="top"  title="请填写批评情况" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>      
                              
                          <tr>
                            <td width="25%" align="right">
                                <strong>自我评价：</strong>
                            </td>
                            <td align="left" colspan="5" >
                           <asp:TextBox Height="80px" ID="txtEvaluation"    style="overflow-y:auto" runat="server" CssClass="select1" width="98%" data-toggle="tooltip" data-placement="top"  title="请填写自我评价" Columns="1" MaxLength="2000" Rows="5" TextMode="MultiLine"></asp:TextBox>
                             </td>
                            </tr>                          
                        <tr class="tr10">
                           
                            <td colspan="6" style="text-align:center;">
                                <asp:Button ID="Button1" runat="server"  data-toggle="tooltip" data-placement="top"  title="点击进行添加" OnClick="Button1_Click" Text="添 加" CssClass="btn" />&nbsp;
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"  data-toggle="tooltip" data-placement="top"  title="点击进行修改" Text="修 改" CssClass="btn" />
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


