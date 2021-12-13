<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoUpd.aspx.cs" Inherits="ningdeScientManage_Web.UserInfoUpd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    
    <title>修改个人信息</title>
     <%--<meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">--%>
    <meta name="renderer" content="webkit" >
<meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1" >
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
<style>
    .left {
        width: 10%;
        text-align: right;
    }
    .right
    {
        width:22%;
        text-align:left;    
    }
    .input1      {height:24px; border:1px solid #c3cdd4; padding-left:3px; line-height:24px; color:#333; margin-top:2px;
}
    a:hover{text-decoration:none;color:#000;}

</style>
</head>
<body>
    <form id="form1" runat="server" >
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >个人信息</div></div></div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table  width="98%" border="0" cellspacing="0" cellpadding="0" style="margin:0px auto;">
                        <tr>
                            <td class="left">
                                <strong>用户工号：</strong>
                               
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserCardId" runat="server"  CssClass="input1" ReadOnly="True"></asp:TextBox>
                            </td>
                             <td class="left">
                                <strong>姓名：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true" CssClass="input1"></asp:TextBox>
                            </td>
                           <td class="left">
                                <strong>性别：</strong>
                            </td>
                            <td class="right">
                                <asp:RadioButtonList ID="radioGender" runat="server"   RepeatDirection="Horizontal">
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </tr>
                        <tr>
                            <td class="left">
                                <strong>在职：</strong></td>
                            <td class="right">
                                 <asp:DropDownList ID="DlStatus" runat="server" CssClass="input1" >
                                </asp:DropDownList> &nbsp; <strong style="color:red; font-size:20px;">*</strong>  
                                      </td>
                            <td class="left"><strong>民族：</strong></td>
                            <td class="right">
                                 <asp:DropDownList ID="DlNation" runat="server" CssClass="input1"  >
                                </asp:DropDownList>
                            </td>
                              <td class="left"><strong>政治面貌：</strong></td>
                            <td class="right">
                                <asp:DropDownList ID="DlPolitical" runat="server" CssClass="input1"  >
                                </asp:DropDownList>
                            </td>
                             
                               </tr>
                        <tr>
                            <td class="left"><strong>学历：</strong></td>
                            <td class="right">
                                 <asp:DropDownList ID="DlEducation" runat="server" CssClass="input1"   >
                                </asp:DropDownList>
                            </td>
                            <td class="left"><strong>学位：</strong></td>
                            <td class="right">
                                  <asp:DropDownList ID="DlDegree" runat="server" CssClass="input1" >
                                </asp:DropDownList>
                            </td>
                            <td class="left"><strong>婚姻状况：</strong></td>
                            <td class="right">
                                 <asp:DropDownList ID="DlMarriage" runat="server" CssClass="input1">
                                   <asp:ListItem Value="未婚">未婚</asp:ListItem>
                                   <asp:ListItem Value="已婚">已婚</asp:ListItem>                                  
                                   <asp:ListItem Value="离异">离异</asp:ListItem>
                                   <asp:ListItem Value="丧偶">丧偶</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                               </tr>
                        <tr>
                             <td class="left"><strong>身份证号码：</strong></td>
                            <td class="right">
                                 <asp:TextBox ID="txtUserIdCard" runat="server"  CssClass="input1" MaxLength="18" ToolTip="填写身份证号码"></asp:TextBox>
                        
                            </td>
                                  <td class="left"><strong>出生日期：</strong></td>
                            <td class="right">
                                 <input id="txtBirthday" onfocus="WdatePicker()" runat="server" cssclass="Wdate" 
                                    class="input1">
                           &nbsp; <strong style="color:red; font-size:20px;">*</strong>  
                            </td>
                            <td class="left">
                                 <strong>籍贯</strong></td>
                            <td class="right">
                                 <asp:TextBox ID="txtOrigin" runat="server"  CssClass="input1" ></asp:TextBox>
                           
                            </td>
                                 
                               </tr>
                        <tr>
                            <td class="left">
                                <strong>邮箱：</strong>
                            </td>
                            <td class="right">
                               <asp:TextBox ID="txtEmail" runat="server"  CssClass="input1" MaxLength="18"></asp:TextBox>
                            <a id="AOtherEmail" runat="server"  href="UserEmail.aspx"  class="fLink thickbox" style="  
   width:70px; height:20px; border:1px solid #000; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px;  padding:3px 7px;"
>其他邮箱</a>            </td>
                              <td class="left">
                                <strong>电话号码：</strong>
                            </td>
                            <td class="right">
                                <asp:TextBox ID="txtPhone" runat="server"  CssClass="input1" MaxLength="18"></asp:TextBox>
                                <a id="AOtherPhone" runat="server"  href="UserPhone.aspx"  class="fLink thickbox" style="  
   width:70px; height:20px; border:1px solid #000; border-radius:13px; margin-right:20px; text-align:center;  line-height:30px;  padding:3px 7px ;"
>其他号码</a>  </td>
                         <td class="left"><strong>聘任时间：</strong></td>
                            <td class="right">
                                <input onfocus="WdatePicker()" id="txtStartWork" runat="server" class="input1"  />
                                 </td>
                            </tr>
                        <tr>
                             <td class="left"><strong>教学系列：</strong></td>
                            <td class="right">
                                <asp:RadioButtonList ID="radioTeachers" runat="server"   RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                             <td class="left"><strong>管理人员：</strong></td>
                            <td class="right">
                                <asp:RadioButtonList ID="radioManagement" runat="server"   RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                               <td class="left"><strong>地址：</strong></td>
                            <td class="right" >
                                 <asp:TextBox ID="txtAddress" runat="server" CssClass="input1" ></asp:TextBox>
                           
                            </td>
                        </tr>
                        </table>
                    <br />
                    <br />
                    <br />
                    <div>
                    <table border="0" cellpadding="0" cellspacing="0" width="98%" style="margin:0px auto; background: #d4d2d2; ">
                        <tr>
                             <td class="left"><strong>所属系(部)：</strong></td>
                            <td class="right">
                                    <asp:DropDownList ID="DlDepartment" runat="server" CssClass="input1" Enabled="False">
                                </asp:DropDownList> &nbsp; <strong style="color:red; font-size:20px;">*</strong>  
                            </td>
                             <td class="left"><strong>师资隶属：</strong></td>
                            <td class="right">
                                    <asp:DropDownList ID="DlDepartment2" runat="server" CssClass="input1" >
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label id="txtUserRole" runat="server" style="font-weight: bold">隶属职务：无</label>
                            </td>
                            <td>
                                 <asp:Button ID="Button5" runat="server"  CssClass="btn11"  Enabled="false" OnClick="Button5_Click" Text="隶属职务管理"  Width="90px" Height="20px" />
                           </td>
                        </tr>
                            <tr>
                            <td class="left"><strong>行政职级：</strong></td>
                            <td class="right">
                                <asp:TextBox ID="txtRemuneration" runat="server" CssClass="input1" ></asp:TextBox>
                                </td>
                             <td class="left"><strong>获得时间：</strong></td>
                            <td class="right">
                                <input id="txtRanktime" onfocus="WdatePicker()" Class="input1" runat="server"   />
                            </td>
                                 <td class="left"><strong>行政系列：</strong></td>
                            <td class="right">
                           <asp:CheckBoxList ID="CBAdminSeries" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            <td colspan="6">
                                <strong>任职：</strong>
                            </td>
                        </tr>
                           </table>                  
                           <asp:GridView ID="GridView1" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong"  Width="98%" AllowPaging="True" Visible="false"
                         AutoGenerateColumns="False"  PageSize="10">
                               <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                               <asp:BoundField DataField="DepartmentName" HeaderText="隶属">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoleName" HeaderText="职务">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作" >
                                <ItemTemplate>
                                    <div  class="link02" runat="server" >                                      
                                          <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Command" CommandArgument='<%# Eval("UserRoleId") %>'>管理</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            </Columns>
                             <PagerStyle CssClass="str001" />
                        <PagerTemplate>
                            当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            页/共:
                            <%--//得到分页页面的总数--%>
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                            页
                            <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                            <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                            转到第
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                            <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                CommandName="Page" Text="GO" />
                        </PagerTemplate>
                        
                    </asp:GridView>
                          <asp:GridView ID="GridView2" runat="server" BackColor=" #d4d2d2"   CssClass="juzhong"  Width="98%" AllowPaging="True" 
                         AutoGenerateColumns="False"  PageSize="10">
                              <AlternatingRowStyle BackColor="#bfbdbd" />
                        <Columns>
                               <asp:BoundField DataField="DepartmentName" HeaderText="隶属">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoleName" HeaderText="职务">
                                <HeaderStyle CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                        
                            </Columns>
                             <PagerStyle CssClass="str001" />
                        <PagerTemplate>
                            当前第:
                            <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            页/共:
                            <%--//得到分页页面的总数--%>
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                            页
                            <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                            <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                            转到第
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                            <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                CommandName="Page" Text="GO" />
                        </PagerTemplate>
                        
                    </asp:GridView>
                    </div>
                           <br />
                    <br />
                    <br />
                    <table border="0" cellpadding="0" cellspacing="0" width="98%" style="margin:0px auto; background: #d4d2d2; ">
                          <tr>
                        
                             <td class="left"><strong>职称：</strong></td>
                            <td class="right">
                                 <asp:DropDownList ID="DlJob" runat="server" CssClass="input1"  >
                                </asp:DropDownList> &nbsp; <strong style="color:red; font-size:20px;">*</strong>  
                            </td>
                             <td class="left"><strong>获得时间：</strong></td>
                            <td class="right">
                                <input id="txtJobTime" onfocus="WdatePicker()" runat="server" class="input1" cssclass="Wdate" /> 
                               
                            </td>
                              <td class="left"><strong>职称系列：</strong></td>
                            <td class="right">
                                <asp:TextBox ID="txtJobSeries" runat="server" CssClass="input1" ></asp:TextBox>
                                </td>
                        </tr>
                            <tr>
                            
                             <td class="left"><strong>职级：</strong></td>
                            <td class="right">
                                <asp:DropDownList ID="DlPost" runat="server" CssClass="input1" >
                                </asp:DropDownList>
                                 &nbsp; <strong style="color:red; font-size:20px;">*</strong>  
                            </td>
                             <td class="left"><strong>获得时间：</strong></td>
                            <td class="right">
                                <input onfocus="WdatePicker()" id="txtPostTime" runat="server" class="input1" >
                            </td>                      
                            <td class="left"><strong>级别：</strong></td>
                            <td class="right">
                                <asp:TextBox ID="txtWorkLevel" runat="server" CssClass="input1" ></asp:TextBox>
                                </td>
                            
                        </tr>                            
                            
                              <tr>
                            <td class="left"><strong>简介：</strong></td>
                            <td class="right" colspan="5">
                                <asp:TextBox Height="80" ID="txtIntroDucation" runat="server" CssClass="input1" width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                         
                            </td>                      
                        </tr>
                 
                             
                                        
                        <tr class="tr10">
                           
                            <td colspan="6" style="text-align:center;">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修 改" CssClass="btn" />&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返 回" CssClass="btn" />
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