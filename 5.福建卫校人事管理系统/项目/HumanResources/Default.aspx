<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HumanManage_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人力资源管理系统</title>
     <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
     <link href="css/thickboxx.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
<script type="text/javascript">

    startInit('iframepage', 460);
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
        window.setInterval("reinitIframe('" + iframeId + "'," + minHeight + ")", 0);
    }
</script>
    <style type="text/css">
       html {
overflow-x:hidden;
overflow-y:auto;
}
        #top {
             background-image: url('../images/topp.png');   position:relative;
            width:100%; height:67px; z-index:200; background-repeat:space; background-size:100% 100%;
            margin:0px; 
        }
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
         padding:0px 0px 10px 230px;
       
         
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
             text-align:center;
             margin:0px auto;
            

        }
        .zihao > ul > li{
            padding:1px 20px;
            border-right:dashed 1px #fff;
        }
    </style>
</head>
    <body>
 <form id="form1" runat="server">
     <div id="top">
         <div style="width:40%; padding-left:20px;  float:left; margin-top:8px;"><img src="Images/default_logo.png" /></div>
         <div style="float:right; padding-right:33px; margin-top:1px; padding-top:35px;  font-size:14px; font-family:黑体;  ">
          <div style=" float:left; color:#ffffff; padding-right:15px; "> <a href="UserMyPwd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox" style="   
       color:white; text-decoration:none;  ">密码修改</a></div>
          <div style=" float:left;   color:#ffffff; padding-left:20px; padding-right:15px; border-left:1px solid #fff;"><a href="Login.aspx"  style="color:white; text-decoration:none;  ">退出登录</a></div>
             <div style="  float:left;  color:#ffffff; padding-left:20px; border-left:1px solid #fff;"><a href="Default.aspx"  style="color:white; text-decoration:none;  ">返回首页</a></div>
      </div>
     </div>
   
       <div  class="top_menu">
           <div style=" float:left;">
        <asp:Menu ID="top_menu" Width="80%" runat="server"  Font-Size="11"  CssClass="zihao" Orientation="Horizontal"    
                     ForeColor="White" StaticEnableDefaultPopOutImage="False">
             <DynamicMenuItemStyle BorderStyle="None" />
            <StaticMenuStyle BorderStyle="None" />
                </asp:Menu>
               </div>
                   <div style=" float:right; margin-right:32px;margin-top:1px;" >
                       
                       <div style=" float:left; padding-top:4px;">
  <span style="font-family:黑体; font-size:16px; color:#fff;">角色：</span>
                    
                       </div>
                       <div class="input01" style=" float:right; padding-top:1px;">
                           <asp:DropDownlist ID="DlRank" runat="server" CssClass="select1" Width="100px"  data-toggle="tooltip" data-placement="top"  ToolTip="选择登陆角色" AutoPostBack="True" OnSelectedIndexChanged="DlRank_SelectedIndexChanged">
                           </asp:DropDownlist>                                                    
                                        </div>
             
                   </div>          
        </div>

                <iframe  src="Right.aspx"  style="height:auto;width:100%;height: 1000px;"" name="center" id="iframepage" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" onLoad="iFrameHeight()"></iframe>
          
     <div class="bton_text">
    <div style="text-align:center;">   
         <span style="color:#000; font-size:12px; font-family:微软雅黑;">技术人员联系方式： Tel:15159430496
       
        &nbsp;&nbsp;&nbsp;&nbsp; 
           QQ:154058934
         </span> 
            </div> 
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">申报人员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1">系部管理员手册</asp:LinkButton>--%>
         <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click1">学院领导手册</asp:LinkButton>   
       
           &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click1">系统管理员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <%--<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click1">专家手册</asp:LinkButton>--%>
         <br /> <br /> 
    </div>
     </form>
    </body>    
</html>