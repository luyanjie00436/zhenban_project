<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yl.aspx.cs" Inherits="HumanManage_Web.yl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style>
        embed {
        
        }
    </style>
<script type="text/javascript">
    window.onload = function () {
        var heig = window.screen.availHeight;
        document.getElementById('png').style.minHeight = heig + "px";
        document.getElementById('png').minHeight = heig + "px";
        document.getElementById('png').style.Height = heig + "px";
        document.getElementById('png').Height = heig + "px";
    }
</script>
</head>
<body>
    <form id="form1" runat="server"  style="height:100%;">
    <div style="height:100%;">

        
           
                    <embed  style="height:100%;   width:100%;" runat="server" id="png"/>   
             

       
   

    </div>
    </form>
</body>
</html>