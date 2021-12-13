<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssessDetailed.aspx.cs" Inherits="sanmingScientManage_Web.AssessDetailed" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        //-----  下面是打印控制语句  ----------
        window.onbeforeprint = beforePrint;
        window.onafterprint = afterPrint;
        //打印之前隐藏不想打印出来的信息
        function beforePrint() {
            div2.style.display = 'none';
            div3.style.display = 'none';

        }
        //打印之后将隐藏掉的信息再显示出来
        function afterPrint() {
            div2.style.display = '';
            div3.style.display = '';
        }
        function printPage() {
            //  parent.iprint.style.display = "none";
            div2.style.display = "none";
            //   $("div3").css("display", "none");
            window.print();
            div2.style.display = "block";
            //  $("div3").css("display", "");
            return false;
        }


</script>
    
    <style>
.tablew{ border-top:1px solid #000; border-left:1px solid #000; text-align:center; font-size:14px;  margin:0px auto}
.tablew td{ border-bottom:1px solid #000; border-right:1px solid #000; height:20px;}
.zi{ text-align:left;}
.tablee{  margin:0px auto; text-align:left;}

        .btn {       width:60px; height:30px; border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer; }

    </style>

</head>
<body>
    <form id="form1" runat="server">
  <div class="min_height" id="tableExcel"  style="width:100%;text-align:left;  margin :0 auto;">
 
  <br /><br /><br />
     
        <div  class="list">
            <%=MenuStr %>
    </div>
        <div id="div2"  style="text-align: center; margin-top:10px ">
            <input id="div3" type="button" value="打 印" onclick=" printPage() " style="    width:60px; height:30px;     border:1px solid #989898; color:#fff; background:#542e6a; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer;" />
            <%--<asp:Button ID="打印" runat="server" Text="导 出" OnClick="Button1_Click" CssClass="btn"  />--%>
        </div>
    </div>
    </form>

</body>
</html>
