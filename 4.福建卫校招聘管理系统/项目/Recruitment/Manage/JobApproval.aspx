<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobApproval.aspx.cs" Inherits="Recruitment.JobApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <title></title>
    <style type="text/css">
        body {
            background:#fafafa;
        }
        .uua {
            width:50%;
        }
        .auto-style3 {
            width: 231px;
        }
        .auto-style4 {
            width: 406px;
        }
        .auto-style5 {
            width: 351px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellpadding="0" cellspacing="0" class="uua">
                     <tr><td align="center" class="auto-style5">岗位信息</td><td width="80%" align="center" colspan="4">个人信息</td></tr>
                  
          <tr>   <td class="auto-style5" >岗位代码：<asp:Label ID="LAJobCode" runat="server"  ></asp:Label></td>
                   
                     <td class="auto-style4" >报名序号：<asp:Label ID="LNumber" runat="server"    ></asp:Label></td>
                     <td rowspan="7">
                        <div class="photo" style="width:75px; overflow:hidden;">
                            <img  id="Image2" runat="server" src="~/imgs.aspx" style="width:71px; padding:0; margin:0;" />
                            </div>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >岗位名称：<asp:Label ID="LAJobName" runat="server" ></asp:Label></td>
                     <td class="auto-style4" > 姓 名：<asp:Label ID="LName" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >学历类别：<asp:Label ID="LAEducation" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 学历类别：<asp:Label ID="LEducation" runat="server"></asp:Label>
                               
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >文化程度：<asp:Label ID="LACulture" runat="server" ></asp:Label></td>
                     <td class="auto-style4" > 学 历： <asp:Label ID="LCulture" runat="server"></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >学位要求：<asp:Label ID="LADegree" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 学 位： <asp:Label ID="LDegree" runat="server"></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >性别要求：<asp:Label ID="LAGender" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 性 别：<asp:Label ID="LGender" runat="server"></asp:Label>
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >民族要求：<asp:Label ID="LANation" runat="server" ></asp:Label></td>
                     <td class="auto-style4" >民 族：<asp:Label ID="LNation" runat="server"></asp:Label>
                                
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5">政治面貌：<asp:Label ID="LAPolitical" runat="server"></asp:Label></td>
                     <td class="auto-style4"> 政治面貌：<asp:Label ID="LPolitical" runat="server"></asp:Label>
                              
                            </td>
                     <td class="auto-style8">电子邮箱：<asp:Label ID="LEmail" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >是否应届：<asp:Label ID="LAShould" runat="server" ></asp:Label></td>
                     <td class="auto-style4" > 毕业时间： <asp:Label id="LGraduationData" runat="server" ></asp:Label>
                        </td>
                     <td class="auto-style8">
                         籍 贯：<asp:Label ID="LOrigin" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr><td class="auto-style5" >户籍要求：<asp:Label ID="LARecruitment" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 户籍所在地：<asp:Label ID="Lcensus" runat="server"></asp:Label>
                            
                            </td>
                     <td class="auto-style8">
                         身份证号：<asp:Label ID="LCardId" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" ><span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">职位类型</span>：<asp:Label ID="LAPosition" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 毕业院校： <asp:Label ID="LInstitutions" runat="server"></asp:Label>
                     </td>
                     <td class="auto-style8">
                           考生来源：<asp:Label ID="LSource" runat="server"></asp:Label>
                             
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >笔试科目：<asp:Label ID="LASubject" runat="server"  ></asp:Label></td>
                     
                 <td class="auto-style4">婚姻状况：<asp:Label ID="LMarriage" runat="server"></asp:Label>
                           
                            </td> 
                     <td class="auto-style8">
                           联系电话：<asp:Label ID="LContactPhone" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5" >报考费用：<asp:Label ID="LAApplyCost" runat="server" ></asp:Label></td>
                     <td class="auto-style4" > 有何专长： <asp:Label ID="LExpertise" runat="server"></asp:Label> 
                     </td>
                     <td class="auto-style8">
                         家庭电话：<asp:Label ID="LFamilyPhone" runat="server"></asp:Label>
                     </td>
                                 </tr>
                 <tr>
                     <td class="auto-style5" >年龄要求：<asp:Label ID="LAAge" runat="server"  ></asp:Label>周岁及以下</td>
                     <td class="auto-style4" > 出生日期：<asp:Label ID="LBirthday" runat="server"></asp:Label> </td>
                     <td class="auto-style8">
                           其他电话：<asp:Label ID="LOtherPhone" runat="server"></asp:Label>
                             
                            </td>
                 </tr>
          <tr>
              <td class="auto-style5">工作年限：<asp:Label ID="LAJobsYears" runat="server"  ></asp:Label> </td>
              <td class="auto-style4" > 参加工作时间：<asp:Label ID="LJobsData" runat="server"></asp:Label> </td>
                     <td class="auto-style3"> 家庭住址： <asp:Label ID="LFamilyAddress" runat="server" ></asp:Label></td>
          </tr>
                 <tr>
                     <td class="auto-style5" >招收人数：<asp:Label ID="LAEnrollment" runat="server"  ></asp:Label></td>
                    <td class="auto-style4">邮 编：<asp:Label ID="LZipCode" runat="server"></asp:Label>
                     </td> 
                     <td class="auto-style3"> 主要简历：<asp:Label ID="LResume" runat="server"></asp:Label></td>
                    
                 </tr>
                 <tr>
                     <td class="auto-style5"  >专业要求：<asp:Label ID="LAProfession" runat="server"  ></asp:Label></td>
                     <td class="auto-style4" > 专业名称：<asp:Label ID="LProfessionName" runat="server" ></asp:Label>
                     </td>
                     <td colspan="2" >
                               家庭成员： <asp:Label ID="LFamilyMember" runat="server"></asp:Label>
                               </td>
                 </tr>
                 <tr>
                     <td  colspan="2">其他要求：<asp:Label ID="LAOthers" runat="server"  ></asp:Label></td>
                     <td  colspan="3">主要业绩：  <asp:Label ID="LPerformance" runat="server" ></asp:Label></td>
                     
                 </tr>
                 <tr>
                     <td  colspan="2">备 注：<asp:Label ID="LARemarks" runat="server"  ></asp:Label></td>
                     <td  colspan="3">备 注：  <asp:Label ID="LRemarks" runat="server" ></asp:Label></td>
                    
                 </tr>
              <tr><td style="text-align: center ;padding:10px; "  colspan="4"> 
                  <asp:Button ID="Button1" runat="server" Text="同 意" CssClass="btn" OnClick="Button1_Click" />
                  <asp:Button ID="Button2" runat="server" Text="拒 绝" CssClass="btn" OnClick="Button2_Click" />
                  </td></tr>
             </table>
    </div>
    </form>
</body>
</html>
