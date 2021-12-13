<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="sanmingScientManage_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>科研管理系统</title>
  <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">

    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>

    

<script type="text/javascript">

    startInit('iframepage', 560);
    var browserVersion = window.navigator.userAgent.toUpperCase();
    var isOpera = browserVersion.indexOf("OPERA") > -1 ? true : false;
    var isFireFox = browserVersion.indexOf("FIREFOX") > -1 ? true : false;
    var isChrome = browserVersion.indexOf("CHROME") > -1 ? true : false;
    var isSafari = browserVersion.indexOf("SAFARI") > -1 ? true : false;
    var isIE = (!!window.ActiveXObject || "ActiveXObject" in window);
    var isIE9More = (! -[1, ] == false);
    function reinitIframe(iframeId, minHeight) {
        try {
            var iframe = document.getElementById(iframeId);
            var bHeight = 0;
            if (isChrome == false && isSafari == false)
                bHeight = iframe.contentWindow.document.body.scrollHeight;

            var dHeight = 0;
            if (isFireFox == true)
                dHeight = iframe.contentWindow.document.documentElement.offsetHeight + 2;
            else if (isIE == false && isOpera == false)
                dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
            else if (isIE == true && isIE9More) {//ie9+
                var heightDeviation = bHeight - eval("window.IE9MoreRealHeight" + iframeId);
                if (heightDeviation == 0) {
                    bHeight += 3;
                } else if (heightDeviation != 3) {
                    eval("window.IE9MoreRealHeight" + iframeId + "=" + bHeight);
                    bHeight += 3;
                }
            }
            else//ie[6-8]、OPERA
                bHeight += 3;

            var height = Math.max(bHeight, dHeight);
            if (height < minHeight) height = minHeight;
            iframe.style.height = height + "px";
        } catch (ex) { }
    }
    function startInit(iframeId, minHeight) {
        eval("window.IE9MoreRealHeight" + iframeId + "=0");
        window.setInterval("reinitIframe('" + iframeId + "'," + minHeight + ")", 100);
    }
</script>
    <style type="text/css">
       
     

     
         #top_menu ul {
         height:auto;
      
         margin:auto;
         font-size:medium;
       
        
        
        }
         #top_menu li {
         height:auto;
        padding:0 10px 0 10px;
         margin:auto;
         font-size:large;
         border-right:dashed 1px #ffffff;
      
       
        }
            #top_menu li a {
                text-align:left;
            }
          #top_menu  {
   padding:5px 0px 5px 10px;
        }
h1,h2,p{margin: 0 10px;}
h1{
 font-size: 250%;
 color: #FFF;
}
h2{font-size: 200%;color: #f0f0f0;}

div#nifty{

 background: #ffffff;
 width:979px;

}
b.rtop, b.rbottom{
 display:block;
}
b.rtop b, b.rbottom b{display:block;height: 1px;
                      overflow: hidden;  }
b.r1{
 margin: 0 5px;
 background-color: #0084b6;
}
b.r2{margin: 0 3px}
b.r3{margin: 0 2px}
b.r1,b.r2,b.r3,b.r4
{
 border-right-width: 1px;
 border-left-width: 1px;
 border-right-style: solid;
 border-left-style: solid;
 border-right-color: #0084b6;
 border-left-color: #0084b6;
 }

b.rtop b.r1,b.rtop b.r1{

 border-top-color: #0084b6;
}

#nifty .main {
 width: 100%;
 border-right-width: 1px;
 border-left-width: 1px;
 border-right-style: solid;
 border-left-style: solid;
 border-right-color: #0084b6;
 border-left-color: #0084b6;
}
#zong{ width:95.8%; height:507px; background-color:#d4eff9; padding:1px 5px 1px 1px; margin-left:8px;  }

        #top_menu ul {
         height:30px;
      
         margin:auto;
         font-size:large;
        }
         #top_menu li >ul> li:hover {
         
         background-color:#542e6a;
         color:#000;
     
        }
           #top_menu li > ul > li > a:hover {
            
         color:#fff;
        font-family:微软雅黑;
         BACKGROUND: #542e6a;
          font-size:14px;
              
        }
            #top_menu li > ul > li > a {
           
          color:black;
          font-family:微软雅黑;
           font-size:14px;
            
              
        }
         #top_menu li >ul> li{
        
         WHITE-SPACE: nowrap; BACKGROUND: #dbbfec; HEIGHT: auto;
         height:30px;
         padding:0 10px 0 10px;
         margin:auto;
         font-size:10px;
         width:100%
         
         
        
        }
              #top_menu  {
         padding:0px 0px 10px 150px;
       
         
         line-height:25px;
         color:#000;
        }
        .select1 {
            background-color:#dbbfec;
            height:17px;
        }
        .login_h5 {
        float:right;
        }
        .bton_text {
            text-align:center;
                   margin-left:30px;
        }
          .zihao {
             font-family:微软雅黑;
            
             margin:0px auto;
            

        }
        .zihao > ul > li{
            padding:1px 20px;
            border-right:dashed 1px #fff;
        }
        .bton_text {
            text-align:center;
                   margin-left:30px;
        }

    </style>

</head>
    <body>
 <form id="form1" runat="server">
  <div id="top">
      <div style="width:40%;  padding-left:18px;  float:left; margin-top:18px;"><img src="Images/default_logo.png" /></div>
            <%--<div class="logo">           
                <img alt="" src="images/default_logo.png"  height="100%"/></div>--%>
          
                 
                      <div style="float:right; padding-right:28px; margin-top:1px; padding-top:35px;  font-size:14px; font-family:黑体;  ">
                          <div style="  float:left;  color:#ffffff;padding-right:15px;  border-right:1px solid #fff;"><a href="Default.aspx"  style="color:white; text-decoration:none;  ">返回首页</a></div>

          <div style=" float:left;  padding-left:20px;  color:#ffffff; padding-right:15px; "> <a href="UserMyPwd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox" style="   
       color:white; text-decoration:none;  ">密码修改</a></div>
          <div style=" float:left;   color:#ffffff; padding-left:20px; border-left:1px solid #fff;"><a href="Login.aspx"  style="color:white; text-decoration:none;  ">退出登录</a></div>
      </div>
                      
                 
  

      
            
    </div>
       <div  class="top_menu" >
            <div style="text-align:center; float:left; width:90%; padding-right:15px;" >
        <asp:Menu ID="top_menu" Width="100%" Font-Size="11" CssClass="zihao"  ForeColor="White" runat="server"  Orientation="Horizontal"  StaticEnableDefaultPopOutImage="False">
                   <DynamicMenuItemStyle BorderStyle="None" />
            <StaticMenuStyle BorderStyle="None" />
                </asp:Menu>
            </div>
           <div  style="float:right; width:8%; color:white; font-size:11px;">
               <span>欢迎您：</span>
               <asp:Label ID="LUserName" runat="server" ></asp:Label>
           </div>
        </div>
     <frameset id="frame" frameborder="0" style="width:100%">
           <iframe  src="Right.aspx" width="100%" style="min-height:450px;" name="center" id="iframepage" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" onLoad="iFrameHeight()"></iframe>
 </frameset>

        <div class="bton_text">
 
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">申报人员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1">系部领导手册</asp:LinkButton>
       <br />    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click1">职能部门领导手册</asp:LinkButton>   
       
           &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click1">系统管理员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click1">评审专家手册</asp:LinkButton>
         <br /> <br /> 
    </div>

     </form>
    </body>    
</html>