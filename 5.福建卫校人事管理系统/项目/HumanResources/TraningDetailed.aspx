<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraningDetailed.aspx.cs" Inherits="HumanManage_Web.TraningDetailed" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style3 {
            width: 353px;
        }
        .auto-style4 {
            height: 30px;
            width: 353px;
        }
        .auto-style5 {
            width: 420px;
        }
        .auto-style6 {
            height: 30px;
            width: 420px;
        }
        .auto-style7 { 
            width: 365px;
        }
        .auto-style8 {
            width: 132px;
        }
        .auto-style9 {
            width: 46px;
        }
        .auto-style13 {
            width: 285px;
        }
        .auto-style14 {
            width: 288px;
        }
        .auto-style15 {
            width: 311px;
        }
        .bgcolor {
             
            border:2px solid #808080;
        
        }
      
        </style>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >教职工在职进修学习申请表</div></div></div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0" >
                        <tr>
                            <td align="right" class="auto-style15">
                                <strong>
                                <asp:Label ID="Label1" runat="server" Text="姓名:"></asp:Label>
                                 </strong>
                            </td>
                            <td align="left" class="auto-style8">
                            
                                <asp:Label ID="txtUserName" runat="server"></asp:Label>
                                
                            </td>
                           <td align="right" class="auto-style5">
                                <strong>
                                <asp:Label ID="Label3" runat="server" Text="性别:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style4">
                               
                            <asp:Label ID="txtSex" runat="server" ></asp:Label>
                            
                                 </td>
                            
                         <td align="right" class="auto-style7">
                                <strong>
                                <asp:Label ID="Label5" runat="server" Text="出生年月:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style3">
                                 
                                 <asp:Label ID="txtBirthday" runat="server" ></asp:Label>
                             
                            </td>
                            </tr>
                        <tr>
                             
                             
                            <td align="right" class="auto-style15">
                                <strong>
                                <asp:Label ID="Label7" runat="server" Text="学历:"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" class="auto-style8">
                             
                                <asp:Label ID="txtUserEducation" runat="server"  ></asp:Label>
                               </td>
                             <td align="right" class="auto-style6">
                                 <strong>
                                 <asp:Label ID="Label9" runat="server" Text="专业:"></asp:Label>
                                 </strong>
                            </td>
                            <td align="left" class="auto-style1">
                               
                                <asp:Label ID="txtUserSpecialty" runat="server"  ></asp:Label>
                               
                                  </td>
                           <td align="right" class="auto-style7">
                                <strong>
                                <asp:Label ID="Label11" runat="server" Text="毕业学校:"></asp:Label>
                                </strong>
                            </td>
                            <td width="12%" align="left">
                               
                            <asp:Label ID="txtUserSchool" runat="server"></asp:Label>
                               
                                 </strong>
                            </td>
                            </tr>                    
                        <tr>
                             
                              <td align="right" class="auto-style15">
                                  <strong>
                                  <asp:Label ID="Label13" runat="server" Text="入校时间:"></asp:Label>
                                  </strong>
                            </td>
                            <td align="left" class="auto-style8">
                                <asp:Label ID="txtUserSchoolTime" runat="server" ></asp:Label>

                            </td>
                      
                            <td align="right" class="auto-style7">
                                         <strong>
                                         <asp:Label ID="Label17" runat="server" Text="专业技术职务:"></asp:Label>
                                         </strong>
                            </td>
                            <td width="12%" align="left" class="auto-style3">
                               <asp:Label ID="txtProfessional" runat="server"></asp:Label>
                            </td>
                    
                            </tr>
                          <tr>
                            <td align="right" class="auto-style15">
                            <strong>  <asp:Label ID="Label19" runat="server" Text="申请在职进修学习类型:"></asp:Label></strong> 

                            <td class="auto-style8" >
                                <asp:Label ID="RadioButtonList1" runat="server"></asp:Label>

  
                            </td>
                                </td><td align="right"> 
                                    <strong>  
                                         <asp:Label ID="Label20" runat="server" Text="进修学习方式:"></asp:Label>    </strong> 
                                    </td><td class="auto-style4">
                               <asp:Label ID="RadioButtonList2" runat="server"></asp:Label>
                               
                       </td>
                               <td align="right" class="auto-style15"><strong>是否取得高校教师资格证或参加管理课程进修班：</strong></td>
                            <td class="auto-style8">
                                <asp:RadioButtonList ID="IsCertficateOrUnit1" RepeatLayout="Flow" runat="server" ReadOnly="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                                </tr>  
                            <tr >
                            <td align="right" class="auto-style1" >
                              <strong> <asp:Label ID="Label52" runat="server" Text="进修开始时间:"></asp:Label></strong></td><td>
                                <asp:Label ID="DTtxtStartDate" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style1" >
                              <strong> <asp:Label ID="Label2" runat="server" Text="进修结束时间:"></asp:Label></strong></td><td>
                                <asp:Label ID="DTtxtEndDate" runat="server"></asp:Label>
                            </td>
                      
                            <td align="right" class="auto-style15">
                           <strong>  <asp:Label ID="Label21" runat="server" Text="拟前往进修学习单位名称:"></asp:Label></strong>
                            </td>
                            <td class="auto-style1" colspan="3">
                                <asp:Label ID="DTtxtLearningUnit" runat="server"></asp:Label>
                            </td>
                            
                            
                        </tr>
                        <tr >
                             <td  align="right"   style="text-align:right;"  >
                              <strong>经费预算:</strong>
                               </td>
                            <td  style="text-align:left;"  colspan="5">
                                  &nbsp;<asp:Label ID="Label23" runat="server" Text="预算"></asp:Label>
                                &nbsp;<asp:Label ID="DTtxtysFee" runat="server"></asp:Label>
                                <asp:Label ID="Label24" runat="server" Text="元"></asp:Label>
                                <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt; mso-font-kerning:1.0000pt;">
                                    <asp:Label ID="Label25" runat="server" Text="其中：培养费（学费）"></asp:Label>
                                    <asp:Label ID="DTtxtpyFee" runat="server"></asp:Label>
                                    <asp:Label ID="Label27" runat="server" Text="元"></asp:Label>
                                    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt;mso-font-kerning:1.0000pt;">
                                <asp:Label ID="Label26" runat="server" Text="差旅费、住宿费"></asp:Label>
                                <asp:Label ID="DTtxtclFee" runat="server" ></asp:Label>
                                <asp:Label ID="Label28" runat="server" Text="元"></asp:Label>
                                </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <span style="mso-spacerun:'yes';font-family:宋体;font-size:10.5000pt; mso-font-kerning:1.0000pt;">&nbsp;&nbsp;<asp:Label ID="Label36" runat="server" Text="其他"></asp:Label>
                                    <asp:Label ID="DTtxtotFee" runat="server"></asp:Label>
                                    <asp:Label ID="Label29" runat="server" Text="元"></asp:Label></span></td>
                                  
                          
                        </tr>
                         <tr >
                           
                                <td colspan="6"  style="text-align:center;">  <asp:Label ID="Label37" runat="server" Text="1.上级部门资助"></asp:Label>
                                    &nbsp;<asp:Label ID="DTtxtFund1" runat="server"></asp:Label>
                                    <asp:Label ID="Label35" runat="server" Text="元"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Label ID="Label38" runat="server" Text="2.学院资助"></asp:Label>
                                    &nbsp;<asp:Label ID="DTtxtFund2" runat="server"></asp:Label>
                                    <asp:Label ID="Label34" runat="server" Text="元"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Label ID="Label39" runat="server" Text="3.部门资助"></asp:Label>
                                    &nbsp; 
                                    <asp:Label ID="DTtxtFund3" runat="server"></asp:Label>
                                    <asp:Label ID="Label33" runat="server" Text="元"></asp:Label>
                                 &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label43" runat="server" Text="4.负责人认可签名"></asp:Label>
                                    &nbsp;<asp:Label ID="DTtxtFund4" runat="server"></asp:Label>
                                    <asp:Label ID="Label32" runat="server" Text="元"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label42" runat="server" Text="5.其他渠道（请具体说明）"></asp:Label>
                                    &nbsp;<asp:Label ID="DTtxtFund5" runat="server"></asp:Label>
                                    <asp:Label ID="Label53" runat="server" Text="元"></asp:Label></td>

                        </tr>
                         
                               
                       
                           

<%--                        <tr>
                            <td colspan="6">
                               <asp:GridView ID="GridViewEmployee" runat="server" AutoGenerateColumns="False" Height="234px" Width="100%" 
                                                        OnRowEditing="GridViewEmployee_RowEditing"
                                                        OnRowUpdating="GridViewEmployee_RowUpdating"
                                                   OnRowCancelingEdit="GridViewEmployee_RowCancelingEdit"
                                                    OnRowDeleting="GridViewEmployee_RowDeleting">
                                   <Columns>
                                       <asp:BoundField HeaderText="UserCardId" Visible="False" />
                                       <asp:BoundField DataField="TraningFurTime" HeaderText="时间" />
                                       <asp:BoundField DataField="TraningFurUnit" HeaderText="进修单位" />
                                       <asp:BoundField DataField="TraningFurContent" HeaderText="进修内容" />
                                       <asp:BoundField DataField="TraningFurShape" HeaderText="进修形式" />
                                       <asp:BoundField DataField="TraningFurId" HeaderText="TraningFurId" ReadOnly="True" />
                                       
                                       
                        

                                       <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" HeaderText="操作" />
                                   </Columns>
                                                         
                           
                
                                </asp:GridView>
                            </td>
                        </tr>--%>
                        
<%--                        <tr>
                            <td colspan="6">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加保存" CssClass="link01" />
                            </td>

                        </tr>--%>
                    </table> 

                    <br /> 
                      &nbsp;&nbsp;&nbsp;<span>近三年进修情况如下：</span>
                   
                      <div style="margin-top: 20px">
                    <asp:GridView HorizontalAlign="Center" BackColor=" #d4d2d2"   CssClass="juzhong"  ID="GridViewEmployee" runat="server" Width="98%"
                AutoGenerateColumns="False" AllowPaging="True" ShowFooter="True"
                 ><%--OnRowCancelingEdit="GridViewEmployee_RowCancelingEdit" OnRowEditing="GridViewEmployee_RowEditing"
                OnRowDeleting="GridViewEmployee_RowDeleting" OnRowUpdating="GridViewEmployee_RowUpdating"--%>
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
<%--                        <FooterTemplate>
                            <asp:Button ID="Button2" runat="server" Text="增  加" OnClick="Button2_Click" />
                        </FooterTemplate>--%>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="时间" HeaderStyle-Width="15%">
                        <EditItemTemplate>
                            <%--编辑项模版--%>
                            <asp:Label ID="TextTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--普通显示模版--%>
                            <asp:Label ID="LabelTraningFurTime" runat="server" Text='<%# Bind("TraningFurTime") %>' />
                        </ItemTemplate>
<%--                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurTime2" runat="server" Width="90%" />
                        </FooterTemplate>--%>
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
<%--                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurUnit2" runat="server" Width="90%" />
                        </FooterTemplate>--%>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进修内容" HeaderStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextTraningFurContent" runat="server" Text='<%# Bind("TraningFurContent") %>' Width="30%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelTraningFurContent" runat="server" Text='<%# Bind("TraningFurContent") %>' />
                        </ItemTemplate>
<%--                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurContent2" runat="server" Width="60%" />
                        </FooterTemplate>--%>
                        <HeaderStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进修形式" HeaderStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextTraningFurShape" runat="server" Text='<%# Bind("TraningFurShape") %>' Width="90%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelTraningFurShape" runat="server" Text='<%# Bind("TraningFurShape") %>' />
                        </ItemTemplate>
<%--                        <FooterTemplate>
                            <asp:TextBox ID="TextTraningFurShape2" runat="server" Width="50%" /> 
                        </FooterTemplate>--%>

                        <HeaderStyle Width="20%" />

                    </asp:TemplateField>
                    
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" HeaderText="操作" HeaderStyle-Width="20%"  ButtonType="Button" Visible="False">
                    <HeaderStyle Width="20%" />
                    </asp:CommandField>
                </Columns>

            </asp:GridView> 
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    
    </div>
    </form>
</body>
    </html>
