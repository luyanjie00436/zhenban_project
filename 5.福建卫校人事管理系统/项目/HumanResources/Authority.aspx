<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authority.aspx.cs" Inherits="HumanManage_Web.Authority" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
      <style type="text/css">
        .auto-style1 {
              width: 395px;
              height: 29px;
          }
        .auto-style2 {
            height: 29px;
        }
          .auto-style3 {
              width: 395px;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div>
    <div>
            <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >角色权限管理</div></div></div>
      
        <div class="page_main01">
          
            <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                 
       <tr>
          <td style="text-align:right; " class="auto-style1" >
              <strong>角色名称:</strong></td>
           <td style="text-align:left;  " class="auto-style2" >
               <asp:TextBox ID="txtRoleName" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请输入角色名称" CssClass="select1" Height="27px" Width="137px" ReadOnly="True"></asp:TextBox>
           </td>
        </tr>
         <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>个人中心:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              
               <asp:CheckBoxList ID="CBPersonal" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                     <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>人员调配管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBTransfer" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>    
                  <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>离职退休管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBQuit" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>延迟退休管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBDelayQuit" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>奖惩信息管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBReward" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>请假信息管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBLeave" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>进修培训管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBTraning" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     

                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>出国信息管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBAbroad" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     

                               <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>职级考核管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBPostApply" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>   

                   <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>职称考核管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBJobApply" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>   
                  <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>综合查询:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBzonghe" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>人员考核管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBRoleApply" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>   
                                   <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>招聘职级管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBRecruitment" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
                                       </tr>
                   <tr>
               <td style="text-align:right; " class="auto-style3" >
                    <strong>简历管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBResume" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>   
        <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>人员编制管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBStaffing" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>人员聘任管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
               <asp:CheckBoxList ID="CBUsePerApp" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                    <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>学时申报管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBApplyPeriod" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>减免工作量管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBReduction" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>基本信息管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBUse1" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>基本信息审批:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBUse2" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr> <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>基本信息修改管理:</strong>
             </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBUse3" runat="server" RepeatDirection="Horizontal" TabIndex="6">
               </asp:CheckBoxList></td>
        </tr> 
       <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>系统管理:</strong>
           </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBSystem" runat="server" RepeatDirection="Horizontal" TabIndex="6" RepeatColumns="8">
               </asp:CheckBoxList></td>
        </tr>

           
           
                
                <tr>
                    <td align="right" class="auto-style3">
                        <asp:Button ID="Search" runat="server" Text="保 存" OnClick="Save_Click" CssClass="btn" />
                        </td>
                    <td width="70%" align="left">
                       
                        &nbsp;
                        &nbsp;
                        <asp:Button ID="Reset" runat="server" Text="返 回" OnClick="Return_Click" Visible="False"
                            CssClass="btn" />
                      
                    </td>
                </tr>
            </table>
              
        </div>
    </div>

    </div>
               
                            
      
    </form>
</body>
</html>

