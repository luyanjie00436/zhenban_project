<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Useatransfer.aspx.cs" Inherits="Recruitment.Manage.Useatransfer" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
     <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jss.js"></script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
       .caozuo {width:100%;height:25px; background-image: url('image/caozuo.png'); border:1px solid #99bbe8; border-top:none;overflow:hidden;           }
.sousuo { width:95%;height:auto; border:1px solid #6c6c6c; box-shadow:0px 0px 3px #c0c0c0; margin:0px auto; margin-top:20px; position:relative; padding-bottom:10px; }

        .auto-style3 {
            width: 78px;
        }
        html {
        font-size:12px;
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
                  <asp:ListItem Value="FollDateDesc">按注册时间倒序排列</asp:ListItem>
                  <asp:ListItem Value="FollDateAsc">按注册时间正序排列</asp:ListItem>  
                  <asp:ListItem Value="NumberDesc">按报名序号倒序排列</asp:ListItem>    
                  <asp:ListItem Value="NumberAsc">按报名序号正序排列</asp:ListItem> 

                </asp:DropDownList>
              </div>
              <div class="suowz" >搜索考生</div>
                <div class="sousuo" >
                  <table border="0" class="bgg" width="100%" >
                    <tr><td align="right" class="auto-style3" >报名序号：</td><td  align="left" > <asp:TextBox ID="txtNumber" runat="server"  Width="80%"></asp:TextBox></td></tr>

                    <tr>
                      <td align="right" class="auto-style3" >姓名：</td><td  align="left" > <asp:TextBox ID="txtName" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>

                    <tr>
                      <td align="right" class="auto-style3" >身份证号：</td><td  align="left" > <asp:TextBox ID="txtIdCard" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >联系电话：</td><td  align="left" > <asp:TextBox ID="txtPhone" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >电子邮箱：</td><td  align="left" > <asp:TextBox ID="txtEmail" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >毕业院校：</td><td  align="left" > <asp:TextBox ID="txtInstitutions" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>  
                    <tr>
                      <td align="right" class="auto-style3" >专业名称：</td><td  align="left" > <asp:TextBox ID="txtProfessionName" runat="server" Width="80%"></asp:TextBox></td>
                   </tr>                                                 
                                                               
                      <tr><td align="right" class="auto-style3" ></td><td  align="right" style="padding-right:19px;" > <asp:Button ID="Button10" runat="server" Text="搜 索" OnClick="Button10_Click" style="height: 21px"  />
                    </td></tr> 
                  </table>
                </div>       
              </div>
             </div>
            <div style="width:84.5%;  background:#fafafa; border:1px solid #8db2e3; float:right; overflow:scroll;" > 
                         <asp:DataList ID="dataOfYear" runat="server" Width="100%"
                              onupdatecommand="DataList1_UpdateCommand"
                               OnDeleteCommand="dataOfYear_DeleteCommand"
                              OnItemCommand="dataOfYear_ItemCommand"
                              OnCancelCommand="dataOfYear_CancelCommand"
                              OnEditCommand="dataOfYear_EditCommand"
                              >    
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="uua" style="text-align:left;">
               
                <tr><td align="center" class="auto-style5">岗位信息</td><td width="80%" align="center" colspan="4">个人信息</td></tr>
                  
          <tr>   <td class="auto-style5" >岗位代码：<asp:Label ID="LAJobCode" runat="server" Text='<%# Eval("岗位编号") %>' ></asp:Label></td>
                   
                     <td class="auto-style4" >报名序号：<asp:Label ID="LNumber" runat="server"   Text='<%# Eval("考生账号") %>'   ></asp:Label></td>
                     <td rowspan="7">
                          <div class="photo" style="width:175px; overflow:hidden;">
                            <%--<img  id="Image2" runat="server" src="~/imgs.aspx?id='<%# Eval("Number") %>'" style="width:71px; padding:0; margin:0;" />--%>
                  <img  id="Image2" runat="server" src='<%# string.Format("~/imgs.aspx?id={0}", Eval("考生账号"))%>' style="width:171px;  height:200px;padding:0; margin:0;" />
                              
                                </div>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >岗位名称：<asp:Label ID="LAJobName" runat="server"  Text='<%# Eval("岗位名称") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 姓 名：<asp:Label ID="LName" runat="server"  Text='<%# Eval("考生姓名") %>' ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >学历类别：<asp:Label ID="LAEducation" runat="server"  Text='<%# Eval("岗位学历类别") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 学历类别：<asp:Label ID="LEducation" runat="server"  Text='<%# Eval("考生学历类别") %>' ></asp:Label>
                               
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >文化程度：<asp:Label ID="LACulture" runat="server"  Text='<%# Eval("岗位文化程度") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 学 历： <asp:Label ID="LCulture" runat="server"  Text='<%# Eval("考生学历") %>' ></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >学位要求：<asp:Label ID="LADegree" runat="server"  Text='<%# Eval("岗位学位要求") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 学 位： <asp:Label ID="LDegree" runat="server"  Text='<%# Eval("考生学位") %>' ></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >性别要求：<asp:Label ID="LAGender" runat="server"  Text='<%# Eval("岗位性别要求") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 性 别：<asp:Label ID="LGender" runat="server"  Text='<%# Eval("考生性别") %>' ></asp:Label>
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >民族要求：<asp:Label ID="LANation" runat="server"  Text='<%# Eval("岗位民族要求") %>' ></asp:Label></td>
                     <td class="auto-style4" >民 族：<asp:Label ID="LNation" runat="server"  Text='<%# Eval("考生民族") %>' ></asp:Label>
                                
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5">政治面貌：<asp:Label ID="LAPolitical" runat="server"  Text='<%# Eval("岗位政治面貌要求") %>' ></asp:Label></td>
                     <td class="auto-style4"> 政治面貌：<asp:Label ID="LPolitical" runat="server"  Text='<%# Eval("考生政治面貌") %>' ></asp:Label>
                              
                            </td>
                     <td class="auto-style8">电子邮箱：<asp:Label ID="LEmail" runat="server"  Text='<%# Eval("考生邮箱") %>' ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" style="background-color:orange"  >是否应届：<asp:Label ID="LAShould" runat="server"  Text='<%# Eval("岗位是否应届") %>' ></asp:Label></td>
                     <td class="auto-style4" style="background-color:orange"  > 毕业时间： <asp:Label id="LGraduationData" runat="server"   Text='<%# Eval("考生毕业时间") %>' ></asp:Label>
                        </td>
                     <td class="auto-style8">
                         籍 贯：<asp:Label ID="LOrigin" runat="server"  Text='<%# Eval("考生籍贯") %>' ></asp:Label>
                     </td>
                 </tr>
                 <tr><td class="auto-style5" style="background-color:orange" >户籍要求：<asp:Label ID="LARecruitment" runat="server"  Text='<%# Eval("岗位户籍要求") %>'  ></asp:Label></td>
                     <td class="auto-style4" style="background-color:orange"  > 户籍所在地：<asp:Label ID="Lcensus" runat="server"  Text='<%# Eval("考生户籍所在地") %>' ></asp:Label>
                            
                            </td>
                     <td class="auto-style8">
                         身份证号：<asp:Label ID="LCardId" runat="server"  Text='<%# Eval("考生身份证号码") %>' ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >职位类型：<asp:Label ID="LAPosition" runat="server"  Text='<%# Eval("岗位职位类型") %>'  ></asp:Label></td>
                     <td class="auto-style4" > 毕业院校： <asp:Label ID="LInstitutions" runat="server"  Text='<%# Eval("考生毕业院校") %>' ></asp:Label>
                     </td>
                     <td class="auto-style8">
                           考生来源：<asp:Label ID="LSource" runat="server"  Text='<%# Eval("考生来源") %>' ></asp:Label>
                             
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >笔试科目：<asp:Label ID="LASubject" runat="server"  Text='<%# Eval("岗位笔试科目") %>'  ></asp:Label></td>
                     
                 <td class="auto-style4">婚姻状况：<asp:Label ID="LMarriage" runat="server"  Text='<%# Eval("考生婚姻状况") %>' ></asp:Label>
                           
                            </td> 
                     <td class="auto-style8">
                           联系电话：<asp:Label ID="LContactPhone" runat="server"  Text='<%# Eval("考生联系电话") %>' ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >报考费用：<asp:Label ID="LAApplyCost" runat="server"  Text='<%# Eval("岗位报考费用") %>' ></asp:Label></td>
                     <td class="auto-style4" > 有何专长： <asp:Label ID="LExpertise" runat="server"  Text='<%# Eval("考生专长") %>' ></asp:Label> 
                     </td>
                     <td class="auto-style8">
                         家庭电话：<asp:Label ID="LFamilyPhone" runat="server"  Text='<%# Eval("考生家庭电话") %>' ></asp:Label>
                     </td>
                                 </tr>
                 <tr>
                     <td class="auto-style5" >年龄要求：<asp:Label ID="LAAge" runat="server"  Text='<%# Eval("岗位年龄限制") %>'  ></asp:Label>周岁及以下</td>
                     <td class="auto-style4" > 出生日期：<asp:Label ID="LBirthday" runat="server"  Text='<%# Eval("考生生日") %>' ></asp:Label> </td>
                     <td class="auto-style8">
                           其他电话：<asp:Label ID="LOtherPhone" runat="server"  Text='<%# Eval("考生家庭电话") %>' ></asp:Label>
                             
                            </td>
                 </tr>
          <tr>
              <td class="auto-style5">工作年限：<asp:Label ID="LAJobsYears" runat="server"  Text='<%# Eval("岗位工作年数") %>'  ></asp:Label> </td>
              <td class="auto-style4" > 参加工作时间：<asp:Label ID="LJobsData" runat="server"  Text='<%# Eval("考生参加工作时间") %>' ></asp:Label> </td>
                     <td class="auto-style8"> 家庭住址： <asp:Label ID="LFamilyAddress" runat="server"  Text='<%# Eval("考生家庭地址") %>'  ></asp:Label></td>
          </tr>
                 <tr>
                     <td class="auto-style5" >招收人数：<asp:Label ID="LAEnrollment" runat="server"  Text='<%# Eval("岗位招收人数") %>'  ></asp:Label></td>
                    <td class="auto-style4">邮 编：<asp:Label ID="LZipCode" runat="server"  Text='<%# Eval("考生邮编") %>' ></asp:Label>
                     </td> 
                     <td class="auto-style8"> 主要简历：<asp:Label ID="LResume" runat="server"  Text='<%# Eval("考生简历") %>' ></asp:Label></td>
                    
                 </tr>
                 <tr>
                     <td class="auto-style5"  style="background-color:orange"  >专业要求：<asp:Label ID="LAProfession" runat="server"  Text='<%# Eval("岗位专业要求") %>'  ></asp:Label></td>
                     <td class="auto-style4"  style="background-color:orange" > 专业名称：<asp:Label ID="LProfessionName" runat="server"  Text='<%# Eval("考生专业名称") %>' ></asp:Label>
                     </td>
                     <td colspan="2" >
                               家庭成员： <asp:Label ID="LFamilyMember" runat="server" Text='<%# Eval("考生家庭成员") %>' ></asp:Label>
                               </td>
                 </tr>
                 <tr>
                     <td   style="background-color:orange" >其他要求：<asp:Label ID="LAOthers" runat="server"  Text='<%# Eval("其他要求") %>'  ></asp:Label></td>
                      <td  style="background-color:orange" >报考审核状态：<asp:Label  runat="server"  Text='<%# Eval("报考审核状态") %>'  ></asp:Label>
                         
                      </td>
                     
                     <td  colspan="3">主要业绩：  <asp:Label ID="LPerformance" runat="server"  Text='<%# Eval("主要业绩") %>' ></asp:Label></td>
                     
                 </tr>
                 <tr>
                     <td  colspan="2">备 注：<asp:Label ID="LARemarks" runat="server"  Text='<%# Eval("岗位备注") %>'  ></asp:Label></td>
                     <td  colspan="3">备 注：  <asp:Label ID="LRemarks" runat="server"  Text='<%# Eval("考生备注") %>' ></asp:Label></td>
                    
                 </tr>
           
                        <tr>
                            <td colspan="4" style="align-content:center; text-align:center;">
                                 <asp:Button ID="Button3" runat="server" Text="全部合格" CommandArgument='<%#Eval("报名序号") %>'  CommandName="qbhg" />
                                
                                <asp:Button ID="Button4" runat="server" Text="条件合格照片不合格"  CommandArgument='<%#Eval("报名序号") %>' CommandName="zpbhg" />
                                <asp:Button ID="Button5" runat="server" Text="专业不符合"  CommandArgument='<%#Eval("报名序号") %>' CommandName="zybfh" />
                            </td>
                        </tr>
                          <tr>
                            <td colspan="4" style="align-content:center; text-align:center;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                                 <asp:Button ID="Button6" runat="server" CommandArgument='<%#Eval("报名序号") %>' Text="条件不符合" CommandName="tjbfh"  />
                                <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                                <asp:Button ID="Button7" runat="server" CommandArgument='<%#Eval("报名序号") %>' Text="资料不全退回补充"  CommandName="zlbqthbc" />
                            </td>
                        </tr>
     </table> 
                   
                 </ItemTemplate>
            </asp:DataList>            
           </div>
         </div>
    </form>
</body>
</html>