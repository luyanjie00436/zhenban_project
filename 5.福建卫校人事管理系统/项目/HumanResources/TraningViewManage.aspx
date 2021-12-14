﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraningViewManage.aspx.cs" Inherits="HumanManage_Web.TraningViewManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style>
        a {
            text-decoration:none;
        }
        * {
            margin: 0;
            padding: 0;
        }
      .table1{ border-top:1px solid #a9a9a9; border-left:1px solid #a9a9a9; margin:0px auto; margin-top:10px; font-size:18px; }
      .table1 td{ border-right:1px solid #a9a9a9; border-bottom:1px solid #a9a9a9;}
        .sec2 { 
            margin-bottom:2px;
            float:right;
            
        }
        .sec3 {
            width:80%;
            margin:0px auto;
            margin-top:15px;

        }
     .botm {
            width:100%;
            height:300px;
            margin:0px auto;
            border:1px solid #a9a9a9;
        }
        .esp {
            width:100%;
            margin:0px auto;
            padding:6px;
        }
                   .btn { width:60px; height:30px;    background:none;     border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer; }
        body{color:#000;font-size:12px;font-family:'Microsoft YaHei', Verdana; background:#dfdfdf;}
                   .parallelogram {
   border-bottom:1px solid #959595; height:20px;
    
} 
.parallelogram2 {
font-size:18px; width:200px;padding-right:20px;
     font-family:微软雅黑; font-size:16px; border-right:1px solid #959595; text-align:right;
     
     
     

    
} 
.aa{ height:20px;width:100%;
}
    </style>
     <script type="text/javascript">
         function showid(txt) {
             alert(txt.id);
         }
         function saves() {
             try {
                 var tab = document.getElementById("signFrame");
                 var rowslength = tab.rows.length;
                 var sql2 = "";
                 var sql1 = "*";

                 for (var i = 1; i < rowslength; i++) {
                     var cell1 = "";
                     if (i != 1) {
                         cell1 = tab.rows[i].cells[0].children(0).value;
                     }
                     var cell2 = tab.rows[i].cells[1].children(0).value;
                     var cell3 = tab.rows[i].cells[2].children(0).value;
                     var cell4 = tab.rows[i].cells[3].children(0).value;
                     if (cell4 != "") {
                         if (cell3 == "like") {
                             cell4 = "%" + cell4 + "%";
                         }
                         cell4 = "'" + cell4 + "'";
                         sql2 = sql2 + wheres(cell1, cell2, cell3, cell4);
                     }
                 }
                 var checkobj = document.getElementById("CBlist1");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist2");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist3");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist4");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist5");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist6");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist7");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 var checkobj = document.getElementById("CBlist8");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox" && checks[n].checked == true) {
                         if (sql1 == "*") {
                             sql1 = checks[n].value;
                         }
                         else {
                             sql1 = sql1 + "," + checks[n].value;
                         }
                     }
                 }
                 document.getElementById("Text1").value = sql1;
                 document.getElementById("Text2").value = sql2;
                 return true;
             } catch (e) {
                 return false;
             }


         }
         function wheres(cell1, cell2, cell3, cell4) {
             var s = " " + cell1 + " isnull( " + cell2 + ", '')" + cell3 + " " + cell4 + " ";
             return s;
         }
         //添加方法
         function addtr() {
             //var trid=0;
             var tab = document.getElementById("signFrame");
             //添加行
             var newTR = tab.insertRow(tab.rows.length);
             //  alert(tab.rows.length);
             //trid++;

             //获取序号=行索引
             var xuhao = newTR.rowIndex.toString();
             //   alert(xuhao);
             newTR.id = "tr" + xuhao;
             //添加列:序号
             var newNameTD = newTR.insertCell(0);
             //添加列内容
             newNameTD.innerHTML = "<select style='width:70px;' name='way" + xuhao + "' id='way" + xuhao + "'><option  value='and'>且</option><option value='or'>或</option> </select>";
             //添加列:日期
             var newNameTD = newTR.insertCell(1);
             //添加列内容
             newNameTD.innerHTML = tab.rows[1].cells[1].innerHTML;

             //添加列:方式
             var newEmailTD = newTR.insertCell(2);
             //添加列内容
             newEmailTD.innerHTML = tab.rows[1].cells[2].innerHTML;


             //添加列:备注
             var newTelTD = newTR.insertCell(3);
             //添加列内容
             newTelTD.innerHTML = tab.rows[1].cells[3].innerHTML;

             //添加列:删除按钮
             var newDeleteTD = newTR.insertCell(4);
             //添加列内容
             newDeleteTD.innerHTML = "<div align='center' style='width:40px'><a href='javascript:;' onclick=\"deltr('tr" + xuhao + "')\">删除</a></div>";

         }
         //全选
         function checks() {

             var CB1 = document.getElementById("CheckBox1");

             if (CB1.checked == true) {
                 var checkobj = document.getElementById("CBlist1");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist2");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist3");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist4");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist5");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist6");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist7");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
                 var checkobj = document.getElementById("CBlist8");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = true;
                     }
                 }
             }
             else {
                 var checkobj = document.getElementById("CBlist1");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist2");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist3");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist4");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist5");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist6");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist7");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
                 var checkobj = document.getElementById("CBlist8");
                 var checks = checkobj.getElementsByTagName("input");
                 for (var n = 0; n < checks.length; n++) {
                     if (checks[n].type == "checkbox") {
                         checks[n].checked = false;
                     }
                 }
             }
         }
         //删除其中一行
         function deltr(trid) {    //alert(trid);
             var tab = document.getElementById("signFrame");
             var row = document.getElementById(trid);
             var index = row.rowIndex;//rowIndex属性为tr的索引值，从0开始  
             tab.deleteRow(index);  //从table中删除
         }

</script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >进修培训综合查询</div></div></div>

     <br />
     
                       <div>
 <table  class="table1" width="80%" id="signFrame" border="0"  cellspacing="0"   >
     <tr >
          <td width="50px" ><strong>关系</strong></td>
         <td width="200px" ><strong>对比列</strong></td>
         <td width="170px" ><strong>对比方式</strong></td>
         <td width="100px"><strong>对比数据</strong></td>
         <td width="80px" ><strong>操作</strong></td>
     </tr>
      <tr>
          <td > </td>
         <td width="200px" height="30px;" >
             <asp:DropDownList ID="DLlie" runat="server" Width="200px" BackColor="#efefef"></asp:DropDownList>

         </td>
         <td width="170px"><asp:DropDownList ID="DropDownList1" runat="server" BackColor="#efefef" Width="170px">
             <asp:ListItem Value=">">大于</asp:ListItem>
             <asp:ListItem Value="<">小于</asp:ListItem>
             <asp:ListItem Value="=">等于</asp:ListItem>
             <asp:ListItem Value="<>">不等于</asp:ListItem>
             <asp:ListItem Value="like">包含</asp:ListItem>
                           </asp:DropDownList>
</td>
         <td width="100px">  <asp:TextBox ID="TextBox2" runat="server" BackColor="#efefef" Width="100px" ></asp:TextBox></td>
         <td width="80px"> <input type="button" class="btn" value="添 加" onclick="addtr()" /></td>
     </tr>
 </table>
          

   </div>
        <input id="Text1" runat="server" type="text" value="*" style="display:none" /> <input id="Text2" runat="server" type="text"  style="display:none" />
         
    <div class="sec3">
      <div style="font-size:16px; font-family:微软雅黑;float:left; margin-bottom:2px;">请您勾选如下所需导出的信息：</div> 
           <div class="sec2">
                           
                           <asp:Button ID="Button12" class="btn" runat="server" Text="导 出" OnClientClick="return saves()"  OnClick="Button12_Click"  />
       

                          <input id="CheckBox1" type="checkbox" value="全选" onclick="checks()" />全选
       </div>
         </div> 
        <div class="sec3">      
     <p>基础信息</p>
              <asp:CheckBoxList ID="CBlist1" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                  <asp:ListItem>工号</asp:ListItem>
                  <asp:ListItem>姓名</asp:ListItem>
                  <asp:ListItem>性别</asp:ListItem>
                  <asp:ListItem>身份证号码</asp:ListItem>
                  <asp:ListItem>出生年月</asp:ListItem>
                  <asp:ListItem>年龄</asp:ListItem>
                   <asp:ListItem>民族</asp:ListItem>
                  <asp:ListItem>政治面貌</asp:ListItem>
                   <asp:ListItem>籍贯</asp:ListItem>
                    <asp:ListItem>家庭地址</asp:ListItem>
                   <asp:ListItem>在职状态</asp:ListItem>
                      <asp:ListItem>入党时间</asp:ListItem>
                  <asp:ListItem>入党年限</asp:ListItem>
                    <asp:ListItem>参加工作时间</asp:ListItem>
                  <asp:ListItem>参加工作年限</asp:ListItem>
                     <asp:ListItem>入职院校时间</asp:ListItem>
                  <asp:ListItem>离校时间</asp:ListItem>
                  <asp:ListItem>入职院校年限</asp:ListItem>
                   
                  
        </asp:CheckBoxList>
               <p>管理干部</p>
              <asp:CheckBoxList ID="CBlist2" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                <asp:ListItem>是否管理干部</asp:ListItem>
                  <asp:ListItem>干部职级</asp:ListItem>
                  <asp:ListItem>现任职务</asp:ListItem>
                  <asp:ListItem>所在部门</asp:ListItem>
                  <asp:ListItem>任现职务时间</asp:ListItem>
                  <asp:ListItem>任现职务年限</asp:ListItem>
                  <asp:ListItem>管理职级</asp:ListItem>
        </asp:CheckBoxList>
                <p>学位</p>
              <asp:CheckBoxList ID="CBlist3" runat="server" CssClass="esp" RepeatColumns="6" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                 <asp:ListItem>第一学位</asp:ListItem>
                  <asp:ListItem>第一学位获得时间</asp:ListItem>
                  <asp:ListItem>第一学位获得年限</asp:ListItem>
                  <asp:ListItem>第一学位专业</asp:ListItem>
                  <asp:ListItem>第一学位毕业院校</asp:ListItem>
                  <asp:ListItem>最高学位</asp:ListItem>
                  <asp:ListItem>最高学位获得时间</asp:ListItem>
                  <asp:ListItem>最高学位获得年限</asp:ListItem>
                  <asp:ListItem>最高学位专业</asp:ListItem>
                  <asp:ListItem>最高学位毕业院校</asp:ListItem>
        </asp:CheckBoxList>
                <p>学历</p>
              <asp:CheckBoxList ID="CBlist4" runat="server" CssClass="esp" RepeatColumns="6" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
       <asp:ListItem>第一学历</asp:ListItem>
                  <asp:ListItem>第一学历获得时间</asp:ListItem>
                  <asp:ListItem>第一学历获得年限</asp:ListItem>
                  <asp:ListItem>第一学历专业</asp:ListItem>
                  <asp:ListItem>第一学历毕业院校</asp:ListItem>
                  <asp:ListItem>最高学历</asp:ListItem>
                  <asp:ListItem>最高学历获得时间</asp:ListItem>
                  <asp:ListItem>最高学历获得年限</asp:ListItem>
                  <asp:ListItem>最高学历专业</asp:ListItem>
                  <asp:ListItem>最高学历毕业院校</asp:ListItem>
                     </asp:CheckBoxList>
                <p>专业技术职称</p>
              <asp:CheckBoxList ID="CBlist5" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                  <asp:ListItem>有无具有专业技术职称</asp:ListItem>
                  <asp:ListItem>职称系列</asp:ListItem>
                  <asp:ListItem>职称等级</asp:ListItem>
                  <asp:ListItem>专技职级</asp:ListItem>
                  <asp:ListItem>所属部门</asp:ListItem>
                  <asp:ListItem>任现职称时间</asp:ListItem>
                  <asp:ListItem>任现职称年限</asp:ListItem>
                    </asp:CheckBoxList>
              <p>教师系列</p>
              <asp:CheckBoxList ID="CBlist6" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                  <asp:ListItem>是否属于教师系列</asp:ListItem>
                  <asp:ListItem>教师类别</asp:ListItem>
                  <asp:ListItem>高校教师资格证书获取时间</asp:ListItem>
                  <asp:ListItem>高校教师资格证书获取年限</asp:ListItem>
                  <asp:ListItem>现是否为专业带头人或负责人</asp:ListItem>
                  <asp:ListItem>现是否为骨干教师</asp:ListItem>
                  <asp:ListItem>现是否为双师型教师</asp:ListItem>
                    </asp:CheckBoxList>
              <p>教师系列</p>
              <asp:CheckBoxList ID="CBlist7" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                  <asp:ListItem>是否工勤人员</asp:ListItem>
                  <asp:ListItem>职级</asp:ListItem>
                  <asp:ListItem>任现职级</asp:ListItem>
                  <asp:ListItem>任现职级时间</asp:ListItem>
                  <asp:ListItem>任现职级年限</asp:ListItem>
                  <asp:ListItem>工勤人员所在部门</asp:ListItem>
                    </asp:CheckBoxList>
              <p>进修培训</p>
              <asp:CheckBoxList ID="CBlist8" runat="server" CssClass="esp" RepeatColumns="7" RepeatDirection="Horizontal" OnSelectedIndexChanged="CBlist1_SelectedIndexChanged" Font-Size="16px" Font-Names="微软雅黑" BorderColor="#a9a9a9" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2">
                  <asp:ListItem>进修类型</asp:ListItem>
                  <asp:ListItem>进修方式</asp:ListItem>
                  <asp:ListItem>学习单位</asp:ListItem>
                  <asp:ListItem>进修开始时间</asp:ListItem>
                  <asp:ListItem>进修结束时间</asp:ListItem>
                  <asp:ListItem>预算金额</asp:ListItem>
                  <asp:ListItem>预算培养费</asp:ListItem>
                  <asp:ListItem>预算差旅费</asp:ListItem>
                  <asp:ListItem>其他预算</asp:ListItem>
                  <asp:ListItem>上级部门资助</asp:ListItem>
                  <asp:ListItem>学院资助</asp:ListItem>
                  <asp:ListItem>部门资助</asp:ListItem>
                  <asp:ListItem>本人自理</asp:ListItem>
                  <asp:ListItem>其他渠道</asp:ListItem>
                  <asp:ListItem>是否取得高校教师资格证或参加管理课程进修班</asp:ListItem>
                  <asp:ListItem>申请日期</asp:ListItem>
                    </asp:CheckBoxList>
        </div>   
      
      
        
         <asp:GridView ID="gvExcel" runat="server" Visible="false"></asp:GridView> 
        c<style>
            #CBlist tr {
            height:70px;
            line-height:50px;
            }
        </style></form>
</body>
</html>
