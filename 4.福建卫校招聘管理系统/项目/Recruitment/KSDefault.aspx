<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KSDefault.aspx.cs" Inherits="Recruitment.KSDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
        <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jss.js"></script>
       <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>


    <title></title>
    <style type="text/css">
        .headerae { width:100%; height:30px;  background:#d6e2f3; border-bottom:1px solid #79b8f7; }


        .wrapt {
            width:100%;
        }
        .ws {
            float:left;
            margin-left:10px;
        }
        .ww {
            float:right;
            margin-right:20px;
            margin-top:8px;
        }
        .wt {
            float:left;
            margin-left:10px;
        }
        .ww a:hover {
            color:red;
        }
    </style>
    <script type="text/javascript">
        function iFrameHeight() {
            var ifm = document.getElementById("iframepage");
            var subWeb = document.frames ? document.frames["iframepage"].document : ifm.contentDocument;


            if (ifm != null && subWeb != null) {
                ifm.height = subWeb.body.scrollHeight;
            }


        }
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
</head>
<body>
    <form id="form1" runat="server">
      <div class="header" ><span>卫生职业技术学院招聘报考网</span></div>
      <div class="headerae">
          <div class="wrapt">
          <div class="ws">
          <%--以下为首页部分--%>
          <ul id="webmenu" class="first-menu">
            <li class="ttt"><a href="KsCandidatesInfoAdd.aspx" class="tt" target="center">个人信息</a>
             
            </li>
          </ul> 
          <%--以下为岗位查询部分--%>
           <ul id="webmenu" class="first-menu">
             <li class="ttt"><a href="JobApp.aspx" class="tt" target="center">岗位查询</a>
             </li>
           </ul>
               <ul id="webmenu" class="first-menu">
             <li class="ttt"><a href="ApplyEvent.aspx" class="tt" target="center">岗位报名查询</a>
             </li>
           </ul>
               <ul id="webmenu" class="first-menu">
             <li class="ttt"><a href="UserGrade.aspx" class="tt" target="center">成绩查询</a>
             </li>
           </ul>
      
 </div>
          <div class="ww">
                   <span class="wt"><a href="KSPwd.aspx?keepThis=true&TB_iframe=true&height=300&width=500"  class="fLink thickbox">修改密码</a></span>
             <span class="wt"><a href="index.aspx">退出</a></span>
          </div>
        </div>
      </div>
         <iframe   style="height:auto;width:100%; height: 1000px;"" name="center" id="iframepage" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" onLoad="iFrameHeight()"></iframe>
     
    </form>
</body>
</html>
