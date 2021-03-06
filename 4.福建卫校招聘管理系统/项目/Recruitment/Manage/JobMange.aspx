<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobMange.aspx.cs" Inherits="Recruitment.JobMange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jss.js"></script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        .caozuo {width:100%;height:25px; background-image: url('image/caozuo.png'); border-bottom:1px solid #99bbe8; overflow:hidden; margin:0px auto;           }
         .sousuo { width:95%;height:543px; border:1px solid #6c6c6c; box-shadow:0px 0px 3px #c0c0c0; margin:0px auto; margin-top:20px; position:relative; padding-bottom:10px; }    

        .auto-style3 {
            width:70px;
        }
        .bgg { margin-left:10px; margin-top:20px; }
        .uua {
    width:80%;
    margin:0px auto;
    margin-top:10px;
    border-top:1px solid #c4c4c4;
    border-left:1px solid #c4c4c4;
}
.uua  td{
    height:25px;
    border-bottom:1px solid #c4c4c4;
    border-right:1px solid #c4c4c4;
    padding:4px;
}
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div  class="linerlow"></div>
      <div class="wrap" >

        <div class="zuo" >
          <div class="zong">
            <div class="caozuo"  ><div class="caozuowz">操作</div></div>
              <div class="xiala">
                <asp:DropDownList Width="95%" ID="DSort" runat="server" >
                  <asp:ListItem Value="FollDateDesc">按创建时间倒序排列</asp:ListItem>
                  <asp:ListItem Value="FollDateAsc">按创建时间正序排列</asp:ListItem>  
                  <asp:ListItem Value="JobCodeDesc">按岗位代码倒序排列</asp:ListItem>    
                  <asp:ListItem Value="JobCodeAsc">按岗位代码正序排列</asp:ListItem> 
                  <asp:ListItem Value="JobNameDesc">按岗位名称倒序排列</asp:ListItem> 
                  <asp:ListItem Value="JobNameAsc">按岗位名称正序排列</asp:ListItem> 
                </asp:DropDownList>
              </div>
              <div class="suowz" >搜索岗位</div>
                <div class="sousuo" >
                  <table border="0" class="bgg" width="100%" >
                   <tr><td align="right" class="auto-style3" >年份：</td><td  align="left" > <asp:TextBox ID="txtYears" Width="80%" runat="server"></asp:TextBox></td></tr>
                    <tr><td align="right" class="auto-style3" >岗位名称：</td><td  align="left" > <asp:TextBox ID="txtJobName" Width="80%" runat="server"></asp:TextBox></td></tr>
                    <tr>
                      <td align="right" class="auto-style3" >笔试科目：</td>
                      <td  align="left"> 
                        <asp:DropDownList Width="80%" ID="DSubjectName"   runat="server" class="input1">
                          <asp:ListItem Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="综合基础知识">综合基础知识</asp:ListItem>    
                          <asp:ListItem Value="免笔试">免笔试</asp:ListItem>  
                          <asp:ListItem Value="专业考试2">专业考试2</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>

                    <tr>
                      <td align="right" class="auto-style3" >文化程度：</td>
                      <td  align="left"> 
                        <asp:DropDownList ID="DCulture"  Width="80%"  runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem>    
                          <asp:ListItem Value="初中">初中</asp:ListItem>  
                          <asp:ListItem Value="中专及以上">中专及以上</asp:ListItem>
                          <asp:ListItem Value="高中及以上">高中及以上</asp:ListItem>
                          <asp:ListItem Value="大专及以上">大专及以上</asp:ListItem>    
                          <asp:ListItem Value="本科及以上">本科及以上</asp:ListItem>  
                          <asp:ListItem Value="硕士研究生及以上">硕士研究生及以上</asp:ListItem>
                          <asp:ListItem Value="博士研究生">博士研究生</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >政治面貌：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DPolitical" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem>
                          <asp:ListItem Value="无党派">无党派</asp:ListItem>    
                          <asp:ListItem Value="共青团员含中共党员">共青团员含中共党员</asp:ListItem>  
                          <asp:ListItem Value="无党派含民主党派">无党派含民主党派</asp:ListItem>
                          <asp:ListItem Value="中共党员">中共党员</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >户籍要求：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DRecruitment" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                        <asp:ListItem Value="不限">不限</asp:ListItem>
                          <asp:ListItem Value="本设区市">本设区市</asp:ListItem> 
                          <asp:ListItem Value="省内">省内</asp:ListItem>   
                          
                        </asp:DropDownList>
                     </td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >性别要求：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DGender" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value=""></asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem> 
                          <asp:ListItem Value="男">男</asp:ListItem>   
                          <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                    </tr>  
                   <tr>
                      <td align="right" class="auto-style3" >是否应届：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DShould" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem> 
                          <asp:ListItem Value="应届生">应届生</asp:ListItem>   
                          <asp:ListItem Value="非应届生">非应届生</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                    </tr>                                                 
                   <tr>
                      <td align="right" class="auto-style3" >民族要求：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DNation" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem> 
                          <asp:ListItem Value="少数民族">少数民族</asp:ListItem>   
                        </asp:DropDownList>
                     </td>
                    </tr>                                                 
                   <tr>
                      <td align="right" class="auto-style3" >学位要求：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DDegree" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem>
                          <asp:ListItem Value="学士学位及以上">学士学位及以上</asp:ListItem>    
                          <asp:ListItem Value="硕士学位及以上">硕士学位及以上</asp:ListItem>     
                          <asp:ListItem Value="博士学位">博士学位</asp:ListItem>     
                         </asp:DropDownList>
                     </td>
                    </tr>                                                 
                   <tr>
                      <td align="right" class="auto-style3" >专门岗位：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DPosition" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                             <asp:ListItem Value="非专门岗位">非专门岗位</asp:ListItem> 
                          <asp:ListItem Value="专门岗位">专门岗位</asp:ListItem>   
                        </asp:DropDownList>
                     </td>
                    </tr>                                                 
                   <tr>
                      <td align="right" class="auto-style3" >学历类别：</td>
                      <td  align="left">
                        <asp:DropDownList Width="80%"  ID="DEducation" runat="server" class="input1">
                          <asp:ListItem  Value="未选择">---未选择---</asp:ListItem>
                          <asp:ListItem Value="不限">不限</asp:ListItem> 
                          <asp:ListItem Value="全日制普通院校">全日制普通院校</asp:ListItem>   
                         
                        </asp:DropDownList>
                     </td>
                    </tr>                                                 
                        <tr><td align="right" class="auto-style3" >年龄要求：</td><td  align="left"> <asp:TextBox ID="txtAge" Width="80%"  runat="server"></asp:TextBox></td></tr>
                    <tr><td align="right" class="auto-style3" >所需专业：</td><td  align="left" > <asp:TextBox ID="txtProfession" Width="80%"  runat="server"></asp:TextBox></td></tr>
                    <tr><td align="right" class="auto-style3" ></td><td  align="right" style="padding-right:24px;" > <asp:Button ID="Button10" runat="server" CssClass="btn" Text="搜 索" OnClick="Button10_Click"  />
</td></tr> 
                  </table>
                </div>       
              </div>
            </div>
            <div class="you" >                      
              <div class="min_height">
                <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >查询岗位</div></div></div>
                <br />

               <asp:DataList ID="dataOfYear" runat="server" Width="100%" 
                   onupdatecommand="DataList1_UpdateCommand"
                   ondeletecommand="DataList1_DeleteCommand"
                   >    
                <ItemTemplate>
                    <table cellpadding="0"  border="0" cellspacing="0" class="uua">
                <tr>
                    <td >岗位代码：<asp:Label ID="Label2" runat="server" Text='<%# Eval("JobCode") %>' ></asp:Label></td>
                    <td >岗位名称：<asp:Label ID="Label3" runat="server" Text='<%# Eval("JobName") %>' ></asp:Label></td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >学历类别：<asp:Label ID="Label1" runat="server" Text='<%# Eval("Education") %>' ></asp:Label></td>
                    <td >文化程度：<asp:Label ID="Label4" runat="server" Text='<%# Eval("Culture") %>' ></asp:Label></td>
                    <td >学位要求：<asp:Label ID="Label5" runat="server" Text='<%# Eval("Degree") %>' ></asp:Label></td>
                </tr>
                <tr>
                     <td >性别要求：<asp:Label ID="Label6" runat="server" Text='<%# Eval("Gender") %>' ></asp:Label></td>
                    <td >民族要求：<asp:Label ID="Label7" runat="server" Text='<%# Eval("Nation") %>' ></asp:Label></td>
                    <td >政治面貌：<asp:Label ID="Label8" runat="server" Text='<%# Eval("Political") %>' ></asp:Label></td>
                </tr>
                <tr>
                     <td >是否应届：<asp:Label ID="Label9" runat="server" Text='<%# Eval("Should") %>' ></asp:Label></td>
                    <td >户籍要求：<asp:Label ID="Label10" runat="server" Text='<%# Eval("Recruitment") %>' ></asp:Label></td>
                    <td >专门岗位：<asp:Label ID="Label11" runat="server" Text='<%# Eval("Position") %>' ></asp:Label></td>
                </tr>
                <tr>
                    <td >笔试科目：<asp:Label ID="Label13" runat="server" Text='<%# Eval("SubjectName") %>' ></asp:Label></td>
                    <td >报考费用：<asp:Label ID="Label14" runat="server" Text='<%# Eval("ApplyCost") %>' ></asp:Label></td>
                  <td >年份：<asp:Label ID="Label19" runat="server" Text='<%# Eval("Years") %>' ></asp:Label></td>
                </tr>
                <tr>
                   <td >年龄要求：<asp:Label ID="Label12" runat="server" Text='<%# Eval("Age") %>' ></asp:Label></td>
                   <td >招收人数：<asp:Label ID="Label18" runat="server" Text='<%# Eval("Enrollment") %>' ></asp:Label></td>
                   <td >&nbsp;</td>
                     </tr>
                <tr>
                    <td  colspan="3">所需专业：<asp:Label ID="Label15" runat="server" Text='<%# Eval("Profession") %>' ></asp:Label></td>
                </tr>
                <tr>
                    <td  colspan="3">其他要求：<asp:Label ID="Label16" runat="server" Text='<%# Eval("Others") %>' ></asp:Label></td>
                </tr>
                <tr>
                    <td  colspan="3">备 注：<asp:Label ID="Label17" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label></td>
                </tr>
                <tr>
                    
                    <td  colspan="3" align="right"> 

                         <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btnn"  CommandArgument='<%#Eval("JobMangeId") %>' CommandName="Update">修改岗位信息</asp:LinkButton>
                          <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnn"  CommandArgument='<%#Eval("JobMangeId") %>' CommandName="Delete">删除</asp:LinkButton>
                        </tr>
     </table>
                   
                 </ItemTemplate>
            </asp:DataList>

    </div>

            

           
    </div>
            </div>
    </form>


</body>
</html>
