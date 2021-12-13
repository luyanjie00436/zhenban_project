<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KJProjectStatusAdd.aspx.cs" Inherits="ningdeScientManage_Web.KJprojectAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <style type="text/css">
         html {
         overflow-x:auto;

         }
.bgcolor{ margin:0px auto; border:1px solid #bcbaba; margin-top:10px; padding-bottom:10px; }

.fed1{ width:10px;}
.fed2{ width:50px;}
.biaoti{ text-align:center; font-size:16px; font-family:宋体;}
th{border:0px; font-size:10px;font-family:微软雅黑; font-weight:normal; }
caption{ font-size:30px; font-family:宋体; font-weight:bold;}
.zihao{ width:1000; font-size:12px; font-family:宋体;}
.select1     { border:1px solid #c3cdd4; background:none; width:180px;   height:24px; line-height:24px; color:#333; margin-top:2px}

           .btn { width:60px; height:30px;   color:#000;     border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer; }
         body{color:#000;font-size:12px;font-family:'Microsoft YaHei', Verdana; background:#dfdfdf;}

         .auto-style1 {
             width: 204px;
         }
         .auto-style2 {
             width: 143px;
         }
         .auto-style4 {
             width: 137px;
         }

         .auto-style5 {
             width: 165px;
         }

         </style>
    <script type="text/javascript">
        function Sum() {

            var sum = 0;
            var test1 = document.getElementById("txtFunding5").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtFunding6").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtFunding7").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtFunding9").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtFunding10").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtFunding11").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum = parseFloat(sum) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            document.getElementById("txtFunding4").value = sum;

           
        }

        function Sum1() {

            var sum1 = 0;
            var test1 = document.getElementById("txtFunding8").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    sum1 = parseFloat(sum1) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            document.getElementById("txtFunding7").value = sum1;
        } 
        
        function Sum2() {

            var Sum2 = 0;
            var test1 = document.getElementById("txtPersonnel3").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum2 = parseFloat(Sum2) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtPersonnel4").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum2 = parseFloat(Sum2) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtPersonnel5").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum2 = parseFloat(Sum2) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtPersonnel6").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum2 = parseFloat(Sum2) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            document.getElementById("txtPersonnel1").value = Sum2;
        }

        function Sum3() {

            var Sum3 = 0;
            var test1 = document.getElementById("txtQuantity2").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum3 = parseFloat(Sum3) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            var test1 = document.getElementById("txtQuantity3").value;
            if (test1 != "") {
                if (!isNaN(test1)) {
                    Sum3 = parseFloat(Sum3) + parseFloat(test1);

                }
                else {
                    alert("输入错误");
                    return;
                }
            }
            document.getElementById("txtQuantity1").value = Sum3;
        }
        </script>
   


</head>
<body>
    <form id="form1" runat="server">
     
    <table width="80%"  class="bgcolor" cellspacing="0">
<caption>福建宁德职业技术学院科技项目情况申请表</caption>
    <tr>
        <th colspan="9">
             
            <br />
            </th>
      </tr>
        <tr>
        <td align="right" class="auto-style4">项目编号:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtKJProjectId" runat="server"/></td>
        <td align="right" class="auto-style2">项目名称:</td>
        <td ><input class="select1" type="text"  id="txtKJProjectName" runat="server"/></td>
        <td align="right" class="auto-style5">主持人:</td>
        <td><input class="select1" type="text"  id="txtUserName" runat="server" readonly="true"  /></td>
    </tr>
        <tr>
        <td align="right" class="auto-style4">申报年份:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtApplyYear" runat="server"/></td>
        <td align="right" class="auto-style2">项目批准时间:</td>
        <td ><input class="select1" type="text"   onfocus="WdatePicker()" id="txtApprovalDate" runat="server"/></td>
        <td align="right" class="auto-style5">批准总金额:</td>
        <td "><input class="select1" type="text"  id="txtFunding1" runat="server"/></td>
    </tr>
   
    <tr>
        <td align="right" class="auto-style4">去年底结转经费:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtFunding2" runat="server"/></td>
        <td align="right" class="auto-style2">当年拨入经费:</td>
        <td ><input class="select1" type="text"  id="txtFunding3" runat="server"/></td>
        <td class="auto-style5" >&nbsp;</td>
    </tr>
    <tr style="background:#bcbaba; width:100%; ">
         <td  colspan="6" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 以下为当年支出经费：</td>
    </tr>
   <tr>
        <td align="right" class="auto-style4">人员劳务费:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtFunding5" onblur="javascript:Sum();" runat="server"/></td>
        <td align="right" class="auto-style2">业务费:</td>
        <td ><input class="select1" type="text"  id="txtFunding6" onblur="javascript:Sum();" runat="server"/></td>
        <td align="right" class="auto-style5">上缴税金:</td>
        <td><input class="select1" type="text"  id="txtFunding9" onblur="javascript:Sum();" runat="server"/></td>
    </tr>
           <tr>
        <td align="right" class="auto-style4">管理费:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtFunding10" onblur="javascript:Sum();" runat="server"/></td>
        <td align="right" class="auto-style2">其他支出:</td>
        <td > <input class="select1" type="text"  id="txtFunding11" onblur="javascript:Sum();"  runat="server"/></td>
       <td></td><td></td>
    </tr>
    <tr>
        
                 <td align="right" class="auto-style2"> 固定资产购置费:合计:</td>
        <td ><input class="select1" type="text"  id="txtFunding7" onblur="javascript:Sum();" runat="server"/></td>
        <td align="right" class="auto-style4">其中：仪器设备费:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtFunding8"  runat="server"/></td>
     <td></td><td></td>
       
    </tr>
        <tr>
         <td align="right" class="auto-style5">合计:</td>
        <td><input class="select1" type="text"  id="txtFunding4"  readonly="true" runat="server"/></td>
                 <td align="right" class="auto-style5">去年年底结余经费:</td>
        <td><input class="select1" type="text" id="txtFunding12" onblur="javascript:Sum();"  runat="server"/></td>
            <td></td><td></td>
    </tr>
        <tr style="background:#bcbaba; width:100%; ">
         <td  colspan="6" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 以下为当年投入人员：</td>
    </tr>

          <tr>
        <td align="right" class="auto-style4">高级职称(男女都算）:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtPersonnel3" onblur="javascript:Sum2();"  runat="server"/></td>
        <td align="right" class="auto-style2">中级职称(男女都算）:</td>
        <td ><input class="select1" type="text"  id="txtPersonnel4" onblur="javascript:Sum2();"  runat="server"/></td>
        <td align="right" class="auto-style5">初级职称(男女都算）:</td>
        <td><input class="select1" type="text"  id="txtPersonnel5" onblur="javascript:Sum2();"  runat="server"/></td>
    </tr>
 

          <tr>
        <td align="right" class="auto-style4">其他(男女都算）:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtPersonnel6" onblur="javascript:Sum2();"  runat="server"/></td>
        <td align="right" class="auto-style2">其中女:</td>
        <td ><input class="select1" type="text"  id="txtPersonnel2" runat="server"/></td>
        <td align="right" class="auto-style5">合计:</td>
        <td><input class="select1" type="text"  id="txtPersonnel1" readonly="true" runat="server"/></td>
    </tr>
    
         <tr style="background:#bcbaba; width:100%; ">
         <td  colspan="6" align="left">以下为参与项目研究生数：</td>
    </tr>
         <tr>
        <td align="right" class="auto-style4">博士生:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtQuantity2" onblur="javascript:Sum3();" runat="server"/></td>
        <td align="right" class="auto-style2">硕士生:</td>
        <td ><input class="select1" type="text"  id="txtQuantity3" onblur="javascript:Sum3();" runat="server"/></td>
        <td align="right" class="auto-style5">合计:</td>
        <td><input class="select1" type="text"  id="txtQuantity1" readonly="true" runat="server"/></td>
    </tr>

   
    
  
    <tr style="background:#bcbaba; width:100%; ">
        <td colspan="6">&nbsp;</td>
    </tr>
         <tr>
        <td align="right" class="auto-style4">学科分类代码:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtClass1" runat="server"/></td>
        <td align="right" class="auto-style2">学科分类:</td>
        <td ><input class="select1" type="text"  id="txtClass2" runat="server"/></td>
        <td align="right" class="auto-style5">活动类型代码:</td>
        <td><input class="select1" type="text"  id="txtClass3" runat="server"/></td>
    </tr>
            <tr>
        <td align="right" class="auto-style4">活动类型:</td>
        <td class="auto-style1" ><asp:DropDownList ID="DlClass4" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
            <%-- <asp:ListItem Value="1">1基础研究</asp:ListItem>
             <asp:ListItem Value="2">2应用研究</asp:ListItem>
             <asp:ListItem Value="3">3实验发展</asp:ListItem>--%>
         </asp:DropDownList></td>
        <td align="right" class="auto-style2">项目来源代码:</td>
        <td ><input class="select1" type="text"  id="txtClass5" runat="server"/></td>
        <td align="right" class="auto-style5">项目来源:</td>
        <td><asp:DropDownList ID="DlClass6" runat="server" CssClass="select1" >
                <asp:ListItem Value="0">==请选择==</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
               <tr>
        <td align="right" class="auto-style4">组织形式代码:</td>
        <td class="auto-style1" ><input class="select1" type="text"  id="txtClass7" runat="server"/></td>
        <td align="right" class="auto-style2">组织形式:</td>
        <td ><asp:DropDownList ID="DlClass8" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
             <%--<asp:ListItem Value="1">1牵头单位</asp:ListItem>
             <asp:ListItem Value="2">2合作单位</asp:ListItem>--%>
         </asp:DropDownList></td>
        <td align="right" class="auto-style5">合作形式代码:</td>
        <td><input class="select1" type="text"  id="txtClass9" runat="server"/></td>
    </tr>
         <tr>
        <td align="right" class="auto-style4">合作形式:</td>
        <td class="auto-style1" >
            <asp:DropDownList ID="DlClass10" runat="server" CssClass="select1" >
                <asp:ListItem Value="0">==请选择==</asp:ListItem>
            </asp:DropDownList>
             </td>
        <td align="right" class="auto-style2">社会经济目标分类与代码:</td>
             <td>
        <asp:DropDownList ID="DlAims1" runat="server" Style="margin-left: 0px; "
                   AutoPostBack="True"      CssClass="select1" OnSelectedIndexChanged="DlAims1_SelectedIndexChanged">
                         <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
    </td>
            <td>
                   <asp:DropDownList ID="DlAims2" runat="server" Style="margin-left: 0px; "
                     AutoPostBack="True"    CssClass="select1" OnSelectedIndexChanged="DlAims2_SelectedIndexChanged">
                      
                    </asp:DropDownList>
            </td>
             <td>
                    <asp:DropDownList ID="DlAims3" runat="server" Style="margin-left: 0px; "
                      CssClass="select1" >
                      
                    </asp:DropDownList>
             </td>
    </tr>

        <tr>
        <td align="right" class="auto-style4">服务的国民经济行业:</td>
      <td width="100" align="left" >
       <asp:DropDownList ID="DlServiceIndustry1" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged1" >
           <asp:ListItem Value="0">请选择</asp:ListItem>
       </asp:DropDownList>
    </td>
    <td width="100" align="right"  > 
          <asp:DropDownList ID="DlServiceIndustry2" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged2" >
         
       </asp:DropDownList></td>
    <td width="100" align="left" >
            <asp:DropDownList ID="DlServiceIndustry3" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged3" >
        
       </asp:DropDownList></td>
    <td width="100" align="left" >
            <asp:DropDownList ID="DlServiceIndustry4" runat="server"  CssClass="select1" >
       
       </asp:DropDownList></td>
        <td align="right" class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    
    
    
    
<%--    <tr>
        <td colspan="3" width="100">业务部门负责人（签章）：</td>
        <td colspan="3" width="100">复核人（签章）： </td>
        <td colspan="3" width="100">填表人（签章）：</td>
       
    </tr>
    <tr>
        <td colspan="3" height="200"><input class="select1" type="text"  id="Text1" runat="server"/></td>
        <td colspan="3"><input class="select1" type="text"  id="Text2" runat="server"/></td>
        <td colspan="3"><input class="select1" type="text"  id="Text3" runat="server"/></td>
     
    </tr>--%>
        </table><br />
        <div style="width:100%; height:100%; text-align:center;"> 
                <asp:Button ID="Button1" runat="server" Text="添 加" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="保 存" CssClass="btn" OnClick="Button2_Click" />
            </div>
    </form>
</body>
</html>
