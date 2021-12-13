<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="ningdeScientManage_Web.Left" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">
       <link href="css/master.css" rel="Stylesheet" type="text/css" />
   
     	<style type="text/css">
	*{margin: 0;padding: 0}
	body{font-size: 12px;font-family: "宋体","微软雅黑";}
	ul,li{list-style: none;}
	a:link,a:visited{text-decoration: none;color: #fff;}
	.list{width: 190px;border-bottom:solid 1px #316a91;margin:3px auto 0 auto;}
	.list >ul >li{
        background-color:#467ca2; border:solid 1px #316a91; border-bottom:0;
  background-image:url(/images/left_menu.png);
          /*cursor: pointer;

  border-bottom: 1px solid #4c4e53;*/
	}
	.list ul li a{
        padding-left: 30px;color: #fff; font-size:12px; display: block; font-weight:bold; height:30px;line-height: 30px;
        /*position: relative;
      line-height: 30px;
 padding: 6px 0px 6px 20px;
  min-width:187px;
  text-align:left;
  color:#fff;*/
        }
	.list ul li .inactive{ background:url(images/off.png) no-repeat 184px center;}
	.list ul li .inactives{background:url(images/on.png) no-repeat 184px center;} 
	.list ul li ul{display: none;}
	.list ul li ul li { border-left:0; border-right:0; background-color:#ddeef8; border-color:#467ca2;}
	.list ul li ul li ul{display: none;}
	.list ul li ul li a{ padding-left:20px; color:#6e7174}
	.list ul li ul li ul li { background-color:#d6e6f1; border-color:#6196bb; }
	.last{ background-color:#d6e6f1; border-color:#6196bb; }
	.list ul li ul li ul li a{ color:#316a91; padding-left:30px;}
	</style>
  <script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('.inactive').click(function () {
	            if ($(this).siblings('ul').css('display') == 'none') {
	                $(this).parent('li').siblings('li').removeClass('inactives');
	                $(this).addClass('inactives');
	                $(this).siblings('ul').slideDown(100).children('li');
	                if ($(this).parents('li').siblings('li').children('ul').css('display') == 'block') {
	                    $(this).parents('li').siblings('li').children('ul').parent('li').children('a').removeClass('inactives');
	                    $(this).parents('li').siblings('li').children('ul').slideUp(100);

	                }
	            } else {
	                //控制自身变成+号
	                //  $(this).removeClass('inactives');
	                //控制自身菜单下子菜单隐藏
	                $(this).siblings('ul').slideUp(100);

	                //控制自身子菜单变成+号
	                //  $(this).siblings('ul').children('li').children('ul').parent('li').children('a').addClass('inactives');
	                //控制自身菜单下子菜单隐藏
	                $(this).siblings('ul').children('li').children('ul').slideUp(100);

	                //控制同级菜单只保持一个是展开的（-号显示）
	                $(this).siblings('ul').children('li').children('a').removeClass('inactives');

	            }
	        })
	    });
	</script>

</head>
<body>
     <form id="form1" runat="server">
    <div  class="list">
            <%=MenuStr %>
    </div>
    </form>
</body>
</html>
