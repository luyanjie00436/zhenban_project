<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KsCandidatesInfoAdd.aspx.cs" Inherits="Recruitment.KsCandidatesInfoAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <title></title>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        body {
            background:#fafafa;
        }
      
    .input1      { width:150px; border:1px solid #c3cdd4; padding-left:3px; height:24px; line-height:24px; color:#333; margin-top:2px; background:#dfdfdf;}
   
    * {
    margin:0px;
    padding:0px;
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
.bwbkk {
    width:100%;
    height:25px;
    background:#fafafa;
    border:none;
}
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

        .auto-style4 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 100%;
            height: 70px;
            background: #fafafa;
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
<script type="text/javascript">
        function jiancha()
        {
            var vala = document.getElementById('txtCardID').value;
            rea = /^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/;
            if (!rea.test(vala)) {
                alert('身份证号不符合规则');
                return false;
            }
            return true;
        }
    </script>

<%--<script>
    var maxstrlen = 20;
    function Q(s) { return document.getElementById(s); }
    function checkWord(c) {
        len = maxstrlen;
        var str = c.value;
        myLen = getStrleng(str);
        var wck = Q("wordCheck");
        if (myLen > len * 2) {
            c.value = str.substring(0, i + 1);
        }
        else {
            wck.innerHTML = Math.floor((len * 2 - myLen) / 2);
        }
    }
    function getStrleng(str) {
        myLen = 0;
        i = 0;
        for (; (i < str.length) && (myLen <= maxstrlen * 2) ; i++) {
            if (str.charCodeAt(i) > 0 && str.charCodeAt(i) < 128)
                myLen++;
            else
                myLen += 2;
        }
        return myLen;
    }
</script>
<script>
    var maxstrlen1 = 20;
    function Q(s) { return document.getElementById(s); }
    function checkWord1(c) {
        len = maxstrlen1;
        var str = c.value;
        myLen = getStrleng(str);
        var wck = Q("wordCheck1");
        if (myLen > len * 2) {
            c.value = str.substring(0, i + 1);
        }
        else {
            wck.innerHTML = Math.floor((len * 2 - myLen) / 2);
        }
    }
    function getStrleng(str) {
        myLen = 0;
        i = 0;
        for (; (i < str.length) && (myLen <= maxstrlen1 * 2) ; i++) {
            if (str.charCodeAt(i) > 0 && str.charCodeAt(i) < 128)
                myLen++;
            else
                myLen += 2;
        }
        return myLen;
    }
</script>--%>
   <script >
function checktext(text)
{
    allValid = true;
    for (i = 0;  i < text.length;  i++)
    {
      if (text.charAt(i) != " ")
      {
        allValid = false;
        break;
      }
    }
return allValid;
}

function gbcount(message,total,used,remain)
{
  var max;
  max = total.value;

  if (message.value.length > max) {
  message.value = message.value.substring(0,max);
  used.value = max;
  remain.value = 0;
  }
  else {
  used.value = message.value.length;
  remain.value = max - used.value;
  }
}
function gbcount1(message1, total1, used1, remain1) {
    var max;
    max = total1.value;

    if (message1.value.length > max) {
        message1.value = message1.value.substring(0, max);
        used1.value = max;
        remain1.value = 0;
    }
    else {
        used1.value = message1.value.length;
        remain1.value = max - used1.value;
    }
}
function gbcount2(message2, total2, used2, remain2) {
    var max;
    max = total2.value;

    if (message2.value.length > max) {
        message2.value = message2.value.substring(0, max);
        used1.value = max;
        remain2.value = 0;
    }
    else {
        used2.value = message2.value.length;
        remain2.value = max - used2.value;
    }
}
function gbcount3(message3, total3, used3, remain3) {
    var max;
    max = total3.value;

    if (message3.value.length > max) {
        message3.value = message3.value.substring(0, max);
        used3.value = max;
        remain3.value = 0;
    }
    else {
        used3.value = message3.value.length;
        remain3.value = max - used3.value;
    }
}
</script>
<style type="text/css">
<!--
* {padding:0; margin:0;}

fieldset {padding:10px; width:550px; margin:0 auto;}
legend {font-size:14px; font-weight:bold;}
.inputtext {border:none; background:#fafafa;}
 .inputtext1 {border:none; background:#fafafa; width:20px;}
  .inputtext2 {border:none; background:#fafafa; width:25px;}
-->
</style>
</head>
<body>
     <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
  <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2">考生信息</div></div></div>
         <div class="page_main01">
             <table cellpadding="0" cellspacing="0" class="uua">
                 <tr>
                     <td align="right">报名序号：</td>
                     <td class="auto-style8"><asp:Label ID="txtNumber" CssClass="bwbkk" runat="server"   ReadOnly="false"  ></asp:Label></td>
                     <td class="auto-style5" align="right" colspan="2">电子邮箱：</td>
                     <td class="auto-style7" colspan="2">
                         <asp:TextBox ID="txtEmail" CssClass="bwbkk" runat="server"></asp:TextBox>
                     </td>
                     <td rowspan="7">
                        <div class="photo" style="width:75px; overflow:hidden;">
                            <img  id="Image2" runat="server" src="~/imgs.aspx" style="width:71px; padding:0; margin:0;" />
                             <asp:FileUpload ID="FileUpload1" CssClass="fileup" Width="75px"  runat="server" onchange="fileSizeLimit()" />
                              </div>
                            <a id="ImageUpd" runat="server" href="Photo.aspx" > 上传照片</a>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;">  *</span>姓 名：</td>
                     <td class="auto-style8">
                         <asp:TextBox ID="txtName" CssClass="bwbkk" runat="server"></asp:TextBox>
                     </td>
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;">  *</span>性 别：</td>
                     <td class="auto-style7" colspan="2">
                                <asp:DropDownList ID="DGender" CssClass="bwbkk"  runat="server" >
                                   <asp:ListItem Value="男">男</asp:ListItem>  
                                   <asp:ListItem Value="女">女</asp:ListItem>    
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 籍 贯：</td>
                     <td class="auto-style8">
                         <asp:TextBox ID="txtOrigin" CssClass="bwbkk" runat="server"></asp:TextBox>
                     </td>
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 民 族：</td>
                     <td class="auto-style7" colspan="2">
                                <asp:DropDownList ID="DNation" CssClass="bwbkk"  runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="汉族">汉族</asp:ListItem>
                                   <asp:ListItem Value="少数民族">少数民族</asp:ListItem>  
                                </asp:DropDownList>
                            </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 出生日期：</td>
                     <td class="auto-style8">
                         <input id="txtBirthday"  class="bwbkk" runat="server"  data-placement="top" data-toggle="tooltip"  onfocus="WdatePicker()"/></td>
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 身份证号：</td>
                     <td class="auto-style7" colspan="2">
                         <asp:TextBox ID="txtCardID" CssClass="bwbkk"  runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 户籍所在地：</td>
                     <td class="auto-style8">
                                <asp:DropDownList ID="Dcensus" CssClass="bwbkk" runat="server" >
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
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 政治面貌：</td>
                     <td class="auto-style7" colspan="2">
                                <asp:DropDownList ID="DPolitical" CssClass="bwbkk"  runat="server" >
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
                     <td class="auto-style8">
                                <asp:DropDownList ID="DSource"  CssClass="bwbkk"  runat="server" >
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
                     <td class="auto-style5" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 联系电话：</td>
                     <td class="auto-style7" colspan="2">
                         <asp:TextBox ID="txtContactPhone" CssClass="bwbkk"  runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right">家庭电话：</td>
                     <td class="auto-style8">
                         <asp:TextBox ID="txtFamilyPhone"  CssClass="bwbkk"  runat="server"></asp:TextBox>
                     </td>
                     <td class="auto-style5" align="right" colspan="2">其他电话：</td>
                     <td class="auto-style7" colspan="2">
                         <asp:TextBox ID="txtOtherPhone"  CssClass="bwbkk"  runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 家庭住址：</td>
                     <td colspan="2" align="left" >
                         <asp:TextBox ID="txtFamilyAddress" runat="server"  CssClass="bwbkk"  Width="276px"></asp:TextBox></td>
                     <td colspan="2" align="right" >
                         邮 编：</td>
                     <td colspan="2" align="left" >
                         <asp:TextBox ID="txtZipCode"  CssClass="bwbkk" Width="100px"  runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 学 历：</td>
                     <td class="auto-style8">
                                 <asp:DropDownList ID="DCulture" CssClass="bwbkk"  runat="server" >
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
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 学 位：</td>
                     <td colspan="3">
                                <asp:DropDownList ID="DDegree" CssClass="bwbkk"  runat="server" >
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
                     <td class="auto-style8">
                                <asp:DropDownList ID="DEducation"  CssClass="bwbkk" runat="server" >
                                   <asp:ListItem Value="">---请选择---</asp:ListItem>
                                   <asp:ListItem Value="其他">其他</asp:ListItem>
                                   <asp:ListItem Value="全日制普通院校">全日制普通院校</asp:ListItem>      
                                </asp:DropDownList>
                            </td>
                     <td class="auto-style5" align="right" colspan="2"> <span style="color:red;font-size:18px;"> *</span> 婚姻状况：</td>
                     <td colspan="3">
                                <asp:DropDownList  CssClass="bwbkk"  ID="DMarriage" runat="server" >
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
                         <asp:TextBox ID="txtInstitutions" runat="server" Height="40"  CssClass="bwbkk2" maxLength="20" ></asp:TextBox>
                         <br /><br /><span class="lblTip">(20个字内) </span>
                         <%--<span style="color:red" id="wordCheck">20</span><span style="color:red">/20</span>--%>

                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 专业名称：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtProfessionName" Height="40" runat="server"  CssClass="bwbkk2" maxLength="20" ></asp:TextBox>
                          <br /><br /><span class="lblTip">(20个字内) </span>
                         <%--<span style="color:red" id="wordCheck1">20</span><span style="color:red">/20</span>--%>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 毕业时间：</td>
                     <td class="auto-style8">
                         <input id="txtGraduationData" runat="server"  class="bwbkk" data-placement="top" data-toggle="tooltip" onfocus="WdatePicker()" title="请输入参加工作时间" /></td>
                     <td class="auto-style5" colspan="2">参加工作时间：</td>
                     <td colspan="3">
                         <input id="txtJobsData" runat="server" class="bwbkk"  data-placement="top" data-toggle="tooltip" onfocus="WdatePicker()" title="请输入参加工作时间" /></td>
                 </tr>
                 <tr>
                     <td align="right">有何专长：</td>
                     <td colspan="6">
                         <textarea name="Memo1" id="txtExpertise" runat="server" class="auto-style4" rows="50" cols="75" onkeydown="gbcount1(this,this.form.total1,this.form.used1,this.form.remain1);" onkeyup="gbcount1(this,this.form.total1,this.form.used1,this.form.remain1);"></textarea>
                     
                        <%-- <asp:TextBox ID="txtExpertise" runat="server" CssClass="bwbkk2"    onKeyUp="javascript:checkWord2(this);" onMouseDown="javascript:checkWord2(this);"  TextMode="MultiLine" MaxLength="50"></asp:TextBox>--%>
                         <span class="lblTip">（<input disabled maxlength="4" name="total1" size="1" value="50" class="inputtext2"/>个字以内）<span ><input disabled maxlength="4"  class="inputtext1" name="used1"  value="0" style="color:red;"/></span><span style="color:red">/</span><span><input disabled maxlength="4" name="remain1" size="3" value="50" class="inputtext" style="color:red"/></span></span>
                             <%--(50个字内) </span><span style="color:red" id="wordCheck2">50</span><span style="color:red">/50</span>--%>
                     </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 主要简历：</td>
                     <td colspan="6">
                      
                     <%--<asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtResume" runat="server"  CssClass="bwbkk"   Columns="1" MaxLength="500" Rows="5" TextMode="MultiLine" onKeyUp="javascript:checkWord3(this);" onMouseDown="javascript:checkWord3(this);"></asp:TextBox>--%>
                         <textarea name="Memo" id="txtResume" runat="server" class="auto-style4" rows="500" cols="75" onkeydown="gbcount(this,this.form.total,this.form.used,this.form.remain);" onkeyup="gbcount(this,this.form.total,this.form.used,this.form.remain);"></textarea>
                     
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
                              ">查看简历格式&nbsp; 字数（<input disabled maxlength="4" name="total" size="1" value="500" class="inputtext2"/>个字以内）<span ><input disabled maxlength="4"  class="inputtext1" name="used"  value="0" style="color:red;"/></span><span style="color:red">/</span><span><input disabled maxlength="4" name="remain" size="3" value="500" class="inputtext" style="color:red"/></span>
                               </span>
                           <%--</span>已有字数： <input id=b size=5 value="0" disabled>剩余字数：<input id=c size=5 value="500" disabled>--%>
                        <%-- <span style="color:red" id="wordCheck3">0</span><span style="color:red">/500</span>--%>
                   </td>
                 </tr>
                 <tr>
                     <td align="right"> <span style="color:red;font-size:18px;"> *</span> 家庭成员：</td>
                     <td colspan="6">
                         <textarea name="Memo2" id="txtFamilyMember" runat="server" class="auto-style4" rows="200" cols="75" onkeydown="gbcount2(this,this.form.total2,this.form.used2,this.form.remain2);" onkeyup="gbcount2(this,this.form.total2,this.form.used2,this.form.remain2);"></textarea>
                                <%--<asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtFamilyMember" runat="server"  CssClass="bwbkk"   Columns="1" MaxLength="200" Rows="5" TextMode="MultiLine" onKeyUp="javascript:checkWord4(this);" onMouseDown="javascript:checkWord4(this);"></asp:TextBox>--%>
                                <br />
                                <span class="lblTip1">家庭主要成员及社会关系的姓名、现工作单位、职务(含子女、夫妻双方父母、双方兄弟姐妹，<input disabled maxlength="4" name="total2" size="1" value="200" class="inputtext2"/>个字内)</span><span ><input disabled maxlength="4"  class="inputtext1" name="used2"  value="0" style="color:red;"/></span><span style="color:red">/</span><span><input disabled maxlength="4" name="remain2" size="3" value="200" class="inputtext" style="color:red"/></span></td>
                 </tr>
                 <tr>
                     <td align="right">主要业绩：</td>
                     <td colspan="6">
                         <textarea name="Memo3" id="txtPerformance" runat="server" class="auto-style4" rows="120" cols="75" onkeydown="gbcount3(this,this.form.total3,this.form.used3,this.form.remain3);" onkeyup="gbcount3(this,this.form.total3,this.form.used3,this.form.remain3);"></textarea>
                        
                                <%--<asp:TextBox Height="70" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtPerformance" runat="server"  CssClass="bwbkk"  Columns="1" MaxLength="120" Rows="5" TextMode="MultiLine" onKeyUp="javascript:checkWord5(this);" onMouseDown="javascript:checkWord5(this);"></asp:TextBox>--%>
                                <br />
                                <span class="lblTip1">主要业绩、及奖惩情况(<input disabled maxlength="4" name="total3" size="1" value="120" class="inputtext2"/>个字内) </span><span ><input disabled maxlength="4"  class="inputtext1" name="used3"  value="0" style="color:red;"/></span><span style="color:red">/</span><span><input disabled maxlength="4" name="remain3" size="3" value="120" class="inputtext" style="color:red"/></span>

                     </td>
                 </tr>
                 <tr>
                     <td align="right">备 注：</td>
                     <td colspan="6">
                         <asp:TextBox ID="txtRemarks" runat="server"  CssClass="bwbkk"  ></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="7">
                         <asp:Button ID="Button1" CssClass="link" runat="server" Text="保 存" OnClick="Button1_Click" OnClientClick="return jiancha()" />
                     </td>
                     
                    
                 </tr>
             </table>
             </div>
    </div>
    </form>
</body>
</html>
