<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobApplication.aspx.cs" Inherits="Recruitment.JobApplication" %>

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
    width:60%;
    margin:0px auto;
    margin-top:10px;
    border-top:1px solid #c4c4c4;
    border-left:1px solid #c4c4c4;
}
.uua  td{
    height:25px;
    border-bottom:1px solid #c4c4c4;
    border-right:1px solid #c4c4c4;
}
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 33px;
        }
        .auto-style3 {
            height: 42px;
        }
    </style>
    <script type="text/javascript">
       function jiancha()
        {
           var duibia = document.getElementById("LAEducation").innerText;
           var duibib = document.getElementById("LEducation").innerText;

            if (duibia=="全日制普通院校") {
                if (duibib != "全日制普通院校") {
                
                    alert('学历类别不符合要求，无法报名')
                    return false;
                }
            }
            duibia = document.getElementById("LACulture").innerText;
            duibib = document.getElementById("LCulture").innerText;
            var a;
            var b;
            switch (duibia) {
                case "不限":
                    a = -1;
                    break;
                case "初中":
                    a = 1;
                    break;
                case "中专及以上":
                    a = 2;
                    break;
                case "高中及以上":
                    a = 3;
                    break;
                case "大专及以上":
                    a = 4;
                    break;
                case "本科及以上":
                    a = 5;
                    break;
                case "硕士研究生及以上":
                    a = 6;
                    break;
                default:
                    a = 7;   
            }
            switch (duibib) {
              
                case "初中":
                    b = 1;
                    break;
                case "中专":
                    b = 2;
                    break;
                case "高中":
                    b = 3;
                    break;
                case "大专":
                    b = 4;
                    break;
                case "本科生":
                    b = 5;
                    break;
                case "双学士":
                    b = 5.5;
                    break;
                case "硕士研究生":
                    b = 6;
                    break;
                case "博士研究生":
                    b = 7;
                    break;
                default:
                    b = 0;
            }
            if (b<a) {
                                 
                    alert('文化程度不符合要求，无法报名')
                    return false;
            }
            duibia = document.getElementById("LADegree").innerText;
            duibib = document.getElementById("LDegree").innerText;
            switch (duibia) {
                case "不限":
                    a = 0;
                    break;
                case "学士学位及以上":
                    a = 1;
                    break;
                case "硕士学位及以上":
                    a = 2;
                    break;
                default:
                    a = 3;
            }
            switch (duibib) {

                case "无":
                    b = 0;
                    break;
                case "学士":
                    b = 1;
                    break;
                case "硕士":
                    b = 2;
                    break;
                case "博士":
                    b =3;
                    break;
                default:
                    b = 0;
             
            }
            if (b < a) {

                alert('学位不符合要求，无法报名')
                return false;

            }
            duibia = document.getElementById("LAGender").innerText;
            duibib = document.getElementById("LGender").innerText;
             if (duibia != "不限" && duibia!=duibib) {
                 alert('性别不符合要求，无法报名')
                 return false;

           }
           

             duibia = document.getElementById("LANation").innerText; 
             duibib = document.getElementById("LNation").innerText;
             //if (duibia == "少数名族" && duibia != duibib) {
             //    alert('民族不符合要求，无法报名')
             //    return false;
             //}

           //else  
            
             if (duibia == "少数民族") {
                 if (duibib != "少数民族") {
                    
                     alert('民族不符合要求，无法报名')
                     return false;
                 }
             }
             duibia = document.getElementById("LAPolitical").innerText;
             duibib = document.getElementById("LPolitical").innerText;
              if (duibia == "无党派" || duibia == "无党派含民主党派") {
                  if (duibib=="共青团员含中共党员"||duibib=="中共党员") {
                      alert('政治面貌不符合要求，无法报名')
                      return false;
                  }               
              }else  if (duibia == "共青团员含中共党员" || duibia == "中共党员") {
                  if (duibib=="无党派"||duibib=="无党派含民主党派") {
                      alert('政治面貌不符合要求，无法报名')
                      return false;
                  }               
              }
              duibia = document.getElementById("LAAge").innerText;
              duibib = document.getElementById("LBirthday").innerText;
              var date = new Date();
              var seperator1 = "-";
              var year = date.getYear();
              var month = date.getMonth();
              var day = date.getDay();
              year = year - duibia;
              var dates = year + seperator1 + month + seperator1 + day;
              if (Date.parse(dates)>Date.parse(duibib)) {
                  alert('年龄不符合要求，无法报名')
                  return false;
              }


            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2">岗位申请</div></div></div>

    <div>
    
        <table cellpadding="0" cellspacing="0" class="auto-style1" Width="100%">
            
            <tr>
              
              
            </tr>
            <tr align="center"><td colspan="2"></td></tr>
        </table>
      <table cellpadding="0" cellspacing="0" class="uua">
                     <tr><td align="center">岗位信息</td><td width="50%" align="center" colspan="4">个人信息</td></tr>
                     <td >岗位代码：<asp:Label ID="LAJobCode" runat="server" Text='<%# Eval("JobCode") %>' ></asp:Label></td>
                   
                     <td >报名序号：<asp:Label ID="LNumber" runat="server"    ></asp:Label></td>
                     <td rowspan="7">
                        <div class="photo" style="width:75px; overflow:hidden;">
                            <img  id="Image2" runat="server" src="~/imgs.aspx" style="width:71px; padding:0; margin:0;" />
                            </div>
                     </td>
                
                 <tr>
                     <td >岗位名称：<asp:Label ID="LAJobName" runat="server" ></asp:Label></td>
                     <td > 姓 名：<asp:Label ID="LName" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td >学历类别：<asp:Label ID="LAEducation" runat="server" Text='<%# Eval("Education") %>' ></asp:Label></td>
                     <td > 学历类别：<asp:Label ID="LEducation" runat="server"></asp:Label>
                               
                            </td>
                 </tr>
                 <tr>
                     <td >文化程度：<asp:Label ID="LACulture" runat="server" ></asp:Label></td>
                     <td > 学 历： <asp:Label ID="LCulture" runat="server"></asp:Label></td>
                 </tr>
                 <tr>
                     <td >学位要求：<asp:Label ID="LADegree" runat="server"  ></asp:Label></td>
                     <td > 学 位： <asp:Label ID="LDegree" runat="server"></asp:Label></td>
                 </tr>
                 <tr>
                     <td >性别要求：<asp:Label ID="LAGender" runat="server"  ></asp:Label></td>
                     <td > 性 别：<asp:Label ID="LGender" runat="server"></asp:Label>
                            </td>
                 </tr>
                 <tr>
                     <td >民族要求：<asp:Label ID="LANation" runat="server" ></asp:Label></td>
                     <td >民 族：<asp:Label ID="LNation" runat="server"></asp:Label>
                                
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style3">政治面貌：<asp:Label ID="LAPolitical" runat="server"></asp:Label></td>
                     <td class="auto-style3"> 政治面貌：<asp:Label ID="LPolitical" runat="server"></asp:Label>
                              
                            </td>
                     <td class="auto-style8">电子邮箱：<asp:Label ID="LEmail" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td >是否应届：<asp:Label ID="LAShould" runat="server" ></asp:Label></td>
                     <td > 毕业时间： <asp:Label id="LGraduationData" runat="server" ></asp:Label>
                        </td>
                     <td class="auto-style8">
                         籍 贯：<asp:Label ID="LOrigin" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr><td >户籍要求：<asp:Label ID="LARecruitment" runat="server" Text='<%# Eval("Recruitment") %>' ></asp:Label></td>
                     <td > 户籍所在地：<asp:Label ID="Lcensus" runat="server"></asp:Label>
                            </td>
                     <td class="auto-style8">
                         身份证号：<asp:Label ID="LCardId" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td ><span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">职位类型</span>：<asp:Label ID="LAPosition" runat="server"  ></asp:Label></td>
                     <td > 毕业院校： <asp:Label ID="LInstitutions" runat="server"></asp:Label>
                     </td>
                     <td class="auto-style8">
                           考生来源：<asp:Label ID="LSource" runat="server"></asp:Label>
                            </td>
                 </tr>
                 <tr>
                     <td >笔试科目：<asp:Label ID="LASubject" runat="server"  ></asp:Label></td>
                 <td>婚姻状况：<asp:Label ID="LMarriage" runat="server"></asp:Label>
                            </td> 
                     <td class="auto-style8">
                           联系电话：<asp:Label ID="LContactPhone" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td >报考费用：<asp:Label ID="LAApplyCost" runat="server" Text='<%# Eval("") %>' ></asp:Label></td>
                     <td > 有何专长： <asp:Label ID="LExpertise" runat="server"></asp:Label> 
                     </td>
                     <td class="auto-style8">
                         家庭电话：<asp:Label ID="LFamilyPhone" runat="server"></asp:Label>
                     </td>
                  </tr>
                 <tr>
                     <td >年龄要求：<asp:Label ID="LAAge" runat="server"  ></asp:Label>周岁及以下</td>
                     <td > 出生日期：<asp:Label ID="LBirthday" runat="server"></asp:Label> </td>
                     <td class="auto-style8">
                           其他电话：<asp:Label ID="LOtherPhone" runat="server"></asp:Label>
                             
                            </td>
                 </tr>
          <tr>
              <td>工作年限：<asp:Label ID="LAJobsYears" runat="server"  ></asp:Label> </td>
              <td > 参加工作时间：<asp:Label ID="LJobsData" runat="server"></asp:Label> </td>
                     <td class="auto-style3"> 家庭住址： <asp:Label ID="LFamilyAddress" runat="server" ></asp:Label></td>
          </tr>
                 <tr>
                     <td >招收人数：<asp:Label ID="LAEnrollment" runat="server" Text='<%# Eval("") %>' ></asp:Label></td>
                    <td>邮 编：<asp:Label ID="LZipCode" runat="server"></asp:Label>
                     </td> 
                     <td class="auto-style3"> 主要简历：<asp:Label ID="LResume" runat="server"></asp:Label></td>
                    
                 </tr>
                 <tr>
                     <td  >专业要求：<asp:Label ID="LAProfession" runat="server"  ></asp:Label></td>
                     <td > 专业名称：<asp:Label ID="LProfessionName" runat="server" ></asp:Label>
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
              <tr><td style="text-align: center" colspan="4"> <asp:Button ID="Button1" runat="server" Text="申 请" CssClass="link" OnClick="Button1_Click"  OnClientClick="return jiancha()"/></td></tr>
             </table>
       
    </div>
    </form>
</body>
</html>
