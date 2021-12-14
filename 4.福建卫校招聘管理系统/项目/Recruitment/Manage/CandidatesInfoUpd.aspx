<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidatesInfoUpd.aspx.cs" Inherits="Recruitment.CandidatesInfoUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <style type="text/css">
        body {
            background:#fafafa;
        }
  
    
    .input1      { width:150px; border:1px solid #c3cdd4; padding-left:3px; height:24px; line-height:24px; color:#333; margin-top:2px; background:#dfdfdf;}

 .bwbkk2 {
    float:left;
    width:80%;
    height:50px;
    background:#fafafa;
    border:none;
}  
.lblTip
{
    padding-left:2px;
    font-size:12px;
    color:Gray;
}
.lblTip1
{
    float:left;
    padding-left:2px;
    font-size:12px;
    color:Gray;
}
 .fileup {
          visibility: hidden;
          width:75px;
         }

    </style>
     <script>
function fileSizeLimit() {

        var uploadSize = document.getElementById("FileUpload1").files[0].size;
        var filename = document.getElementById("FileUpload1").value;
        var prefix = filename.substr(filename.lastIndexOf('.') + 1).toLowerCase();
        if (prefix == "jpg" || prefix == "png" || prefix == "gif") {
            if (uploadSize > 1024*100) {
                alert("文件大小不能超过100k");
                document.getElementById("FileUpload1").value = "";
              
            }
        } else {
            alert("文件格式限制为：jpg,png,gif");
            document.getElementById("FileUpload1").value = "";
          
        }
           }
        </script>
</head>
<body>
     <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
     <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2">考生信息</div></div></div>
         <div class="page_main01">
             <table cellpadding="0" cellspacing="0" class="uuaa">
                 <tr>
                     <td align="right">报名序号：</td>
                     <td ><asp:Label ID="txtNumber" runat="server"   ReadOnly="false"  ></asp:Label></td>
                     <td align="right" colspan="2">电子邮箱：</td>
                     <td colspan="2" >
                         <asp:TextBox ID="txtEmail" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                     <td rowspan="7">
                        <div class="photo" style="width:75px; overflow:hidden;">
                            <img  id="Image2" runat="server" src="~/imgs.aspx" style="width:71px; padding:0; margin:0;" />
                             <asp:FileUpload ID="FileUpload1" CssClass="fileup" Width="75px"  runat="server" onchange="fileSizeLimit()" />
                            </div>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;">  *</span>姓 名：</td>
                     <td >
                         <asp:TextBox ID="txtName" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;">  *</span>性 别：</td>
                     <td colspan="2" >
                                <asp:DropDownList CssClass="bwbk" ID="DGender" runat="server" >
                                   <asp:ListItem Value="男">男</asp:ListItem>  
                                   <asp:ListItem Value="女">女</asp:ListItem>    
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 籍 贯：</td>
                     <td >
                         <asp:TextBox ID="txtOrigin" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 民 族：</td>
                     <td colspan="2" >
                                <asp:DropDownList CssClass="bwbk" ID="DNation" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="汉族">汉族</asp:ListItem>
                                   <asp:ListItem Value="少数民族">少数民族</asp:ListItem>  
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 出生日期：</td>
                     <td >
                         <input id="txtBirthday" class="bwbk" runat="server"   data-placement="top" data-toggle="tooltip"  onfocus="WdatePicker()"/></td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 身份证号：</td>
                     <td colspan="2" >
                         <asp:TextBox ID="txtCardID" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 户籍所在地：</td>
                     <td>
                                <asp:DropDownList ID="Dcensus" CssClass="bwbk" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="福州">福州</asp:ListItem>
                                   <asp:ListItem Value="莆田">莆田</asp:ListItem>  
                                   <asp:ListItem Value="泉州">泉州</asp:ListItem>    
                                   <asp:ListItem Value="厦门">厦门</asp:ListItem> 
                                   <asp:ListItem Value="漳州">漳州</asp:ListItem> 
                                   <asp:ListItem Value="龙岩">龙岩</asp:ListItem> 
                                   <asp:ListItem Value="三明">三明</asp:ListItem> 
                                   <asp:ListItem Value="南平">南平</asp:ListItem> 
                                   <asp:ListItem Value="宁德">宁德</asp:ListItem> 
                                   <asp:ListItem Value="省外">省外</asp:ListItem> 
                                   <asp:ListItem Value="港澳台">港澳台</asp:ListItem> 
                                </asp:DropDownList>
                            </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 政治面貌：</td>
                     <td colspan="2" >
                                <asp:DropDownList CssClass="bwbk" ID="DPolitical" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="无党派">无党派</asp:ListItem>    
                                   <asp:ListItem Value="共青团员含中共党员">共青团员（含中共党员）</asp:ListItem>  
                                   <asp:ListItem Value="无党派含民主党派">无党派（含民主党派）</asp:ListItem>
                                   <asp:ListItem Value="中共党员">中共党员（含预备党员）</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 考生来源：</td>
                     <td >
                                <asp:DropDownList CssClass="bwbk" ID="DSource" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="应届毕业生">应届毕业生</asp:ListItem>
                                   <asp:ListItem Value="往届未就业毕业生">往届未就业毕业生</asp:ListItem>  
                                   <asp:ListItem Value="不足两年工作经历毕业生">不足两年工作经历毕业生</asp:ListItem>   
                                   <asp:ListItem Value="两年及以上工作经历毕业生">两年及以上工作经历毕业生</asp:ListItem>    
                                   <asp:ListItem Value="三支一扶计划毕业生">三支一扶计划毕业生</asp:ListItem>    
                                   <asp:ListItem Value="服务欠发达计划毕业生">服务欠发达计划毕业生</asp:ListItem>    
                                   <asp:ListItem Value="西部志愿者项目计划毕业生">西部志愿者项目计划毕业生</asp:ListItem>    
                                   <asp:ListItem Value="选聘生">选聘生</asp:ListItem>    
                                   <asp:ListItem Value="退役士兵">退役士兵</asp:ListItem>    
                                   <asp:ListItem Value="服务社区计划">服务社区计划</asp:ListItem>     
                                </asp:DropDownList>
                            </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 联系电话：</td>
                     <td colspan="2" >
                         <asp:TextBox ID="txtContactPhone" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right">家庭电话：</td>
                     <td >
                         <asp:TextBox ID="txtFamilyPhone" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                     <td align="right" colspan="2">其他电话：</td>
                     <td colspan="2" >
                         <asp:TextBox ID="txtOtherPhone" CssClass="bwbk" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 家庭住址：</td>
                     <td colspan="2"align="left" >
                         <asp:TextBox ID="txtFamilyAddress" CssClass="bwbk" runat="server" Width="376px"></asp:TextBox></td>
                     <td colspan="2"align="left" >
                         邮 编：</td>
                     <td colspan="2"align="left" >
                         <asp:TextBox ID="txtZipCode" CssClass="bwbk" Width="100px" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 学 历：</td>
                     <td >
                                 <asp:DropDownList ID="DCulture"  CssClass="bwbk" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="初中">初中</asp:ListItem>    
                                   <asp:ListItem Value="中专">中专</asp:ListItem>
                                   <asp:ListItem Value="高中">高中</asp:ListItem> 
                                   <asp:ListItem Value="大专">大专</asp:ListItem>  
                                   <asp:ListItem Value="本科生">本科生</asp:ListItem>  
                                   <asp:ListItem Value="双学士">双学士</asp:ListItem>  
                                   <asp:ListItem Value="硕士研究生">硕士研究生</asp:ListItem>  
                                   <asp:ListItem Value="博士研究生">博士研究生</asp:ListItem>     
                                </asp:DropDownList>
                            </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 学 位：</td>
                     <td colspan="3">
                                <asp:DropDownList ID="DDegree"  CssClass="bwbk" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="无">无</asp:ListItem>
                                   <asp:ListItem Value="学士">学士</asp:ListItem>    
                                   <asp:ListItem Value="硕士">硕士</asp:ListItem>     
                                   <asp:ListItem Value="博士">博士</asp:ListItem>     
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 学历类别：</td>
                     <td>
                                <asp:DropDownList  CssClass="bwbk" ID="DEducation" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="其他">其他</asp:ListItem>
                                   <asp:ListItem Value="全日制普通院校">全日制普通院校</asp:ListItem>      
                                </asp:DropDownList>
                            </td>
                     <td align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 婚姻状况：</td>
                     <td colspan="3">
                                <asp:DropDownList ID="DMarriage"  CssClass="bwbk" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="未婚">未婚</asp:ListItem>
                                   <asp:ListItem Value="已婚">已婚</asp:ListItem>  
                                   <asp:ListItem Value="离异">离异</asp:ListItem>    
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 毕业院校：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtInstitutions"   runat="server" CssClass="bwbkk2"></asp:TextBox>
                         <span class="lblTip">(20个字内) </span></td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;" > *</span> 专业名称：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtProfessionName" runat="server"   CssClass="bwbkk2"></asp:TextBox>
                         <span class="lblTip">(20个字内) </span></td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 毕业时间：</td>
                     <td >
                         <input id="txtGraduationData" runat="server" class="bwbk"   data-placement="top" data-toggle="tooltip" onfocus="WdatePicker()" title="请输入参加工作时间" /></td>
                     <td align="right" colspan="2">参加工作时间：</td>
                     <td colspan="3">
                         <input id="txtJobsData" runat="server" class="bwbk"  data-placement="top" data-toggle="tooltip" onfocus="WdatePicker()" title="请输入参加工作时间" /></td>
                 </tr>
                 <tr>
                     <td align="right">有何专长：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtExpertise" runat="server" Height="35px"   CssClass="bwbkk2"></asp:TextBox>
                         <span class="lblTip">(50个字内) </span></td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 主要简历：</td>
                     <td colspan="6">
                     <asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtResume" runat="server"  CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                         <br />
                           <span class="lblTip1" title="主要简历请按如下格式填写：
1993.9-1996.7 XX市XXX中学（高中）学生；
1996.9-2007.7 XXXXX大学（本科）工商管理专业 学生；
2000.9-2001.3 待业；
2001.4-2004.8 XXXXX有限公司（私营企业）总务科 后勤；
2004.9-2007.6 XX市XX单位（事业单位）在编人员 总务；
2005.9-2008.7 XX省XXX大学（在职研究生）工商管理专业 学生；
2007.8-至今 XX省XXX单位（参公事业单位）在编 总务；
说明：
1、对机关事业单位工作的，应注明单位性质（机关、参公事业单位、事业单位），及是否为在编人员。
2、对在职学习的，应注明。
                              ">查看简历格式&nbsp; 字数（500个字以内）</span></td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 家庭成员：</td>
                     <td colspan="6">
                                <asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtFamilyMember" runat="server"  CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <span class="lblTip1">家庭主要成员及社会关系的姓名、现工作单位、职务(含子女、夫妻双方父母、双方兄弟姐妹，200个字内)</span> </td>
                 </tr>
                 <tr>
                     <td align="right">主要业绩：</td>
                     <td colspan="6">
                                <asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtPerformance" runat="server"  CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <span class="lblTip1">主要业绩、及奖惩情况(120个字内) </span></td>
                 </tr>
                 <tr>
                     <td align="right">备 注：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtRemarks" runat="server"  CssClass="bwbk"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                    
                     <td colspan="7"  >
                         <%--<asp:Button ID="Button1" runat="server" CssClass="btnn" Text="保存" OnClick="Button1_Click" />--%>
                     </td>
                    
                 </tr>
             </table>
             </div>
    </div>
    </form>
</body>
</html>
