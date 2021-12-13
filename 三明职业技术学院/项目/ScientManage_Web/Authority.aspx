<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authority.aspx.cs" Inherits="sanmingScientManage_Web.Authority" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
      <style type="text/css">
        .auto-style1 {
            width: 94px;
            height: 29px;
        }
        .auto-style2 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div>
    <div>
          <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >角色权限管理</div></div></div><br />
        <div class="page_main01">
          
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 
       <tr>
          <td style="text-align:right; " class="auto-style1" >
              <strong>角色名称:</strong></td>
           <td style="text-align:left;  " class="auto-style2" >
               <asp:TextBox ID="txtRoleName" runat="server"  CssClass="input6" Height="27px" Width="137px" ReadOnly="True"></asp:TextBox>
           </td>
        </tr>
         <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>个人中心:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              
               <asp:CheckBoxList ID="CBPersonal" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                     <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>学术讲座:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBResources" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>    
                <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>团体学会:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBAssciation" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>    
                  <tr>

               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>纵向项目管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
               <asp:CheckBoxList ID="CBDeclare" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
          
        </tr>     
            
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>横向项目管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
               <asp:CheckBoxList ID="CBShort" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList>
            </td>
        </tr>     
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>纵向经费管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBLongCapital" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>    
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>横向经费管理:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBShortCapital" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>   
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>成果添加:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBResults" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>     
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>成果申请记录:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBGuidance" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
                
                  <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>个人成果申请记录:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBTeaching" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
                    <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>成果合作者信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBWinning" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
                
                    <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>成果审批:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBWorkLoad" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
                     <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>成果审批流程:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBPaper" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
                  <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>科研情况:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBSituation" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>     
              <%--    <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>技能竞赛信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBCompetition" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>  
      <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>科研项目信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBWorkLoadProjects" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>学术团体信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBAssociation" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>学术讲座信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBLcture" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                 <tr>
               <td style="text-align:right; height: 29px; width: 94px;" >
                    <strong>学术活动信息:</strong> </td>
           <td style="text-align:left;  height: 29px;" >
              <asp:CheckBoxList ID="CBActivity" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>--%>


       <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>系统管理:</strong>
           </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBSystem" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
   <tr>
          <td style="text-align:right; " class="auto-style1" >
               <strong>系统管理项目:</strong>
           </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBSysPro" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                <td style="text-align:right; " class="auto-style1" >
               <strong>系统管理成果:</strong>
           </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBSysHar" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>
                <td style="text-align:right; " class="auto-style1" >
               <strong>系统管理其他设置:</strong>
           </td>
           <td style="text-align:left;  " class="auto-style2" >
              
               <asp:CheckBoxList ID="CBSysOrd" runat="server" RepeatDirection="Horizontal">
               </asp:CheckBoxList></td>
        </tr>


           
           
                
                <tr>
                    <td width="30%" align="right">
                        &nbsp;
                    </td>
                    <td width="70%" align="left">
                       
                        &nbsp;<asp:Button ID="Search" runat="server" Text="保 存" OnClick="Save_Click" CssClass="btn" />
                        &nbsp;
                        <asp:Button ID="Reset" runat="server" Text="返 回" OnClick="Return_Click" Visible="False"
                            CssClass="btn" />
                      
                    </td>
                </tr>
            </table>
              
        </div>
    </div>

    </div>
               
                            
        </div>
    </div>
    </form>
</body>
</html>
