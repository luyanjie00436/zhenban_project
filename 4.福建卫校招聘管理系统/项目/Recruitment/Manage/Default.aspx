<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Recruitment.Default" %>

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

        /*.first-menu{ float:left; margin-left:10px;  width:180px;}*/





    </style>
  
    <script type="text/javascript">
        function iFrameHeight() {
            var ifm = document.getElementById("iframepage");
            var subWeb = document.frames ? document.frames["iframepage"].document : ifm.contentDocument;
         

            if (ifm != null && subWeb != null ) {
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
      <div class="headera">
          <div class="wrapt">
             <div class="ws">
         
          <%--以下为招考管理部分--%>
           <ul id="webmenu" class="first-menu">
             <li class="ttt"><a href="#" class="tt" >岗位管理</a>
               <ul id="subNews" class="second-menu">
                 <li class="tttt" ><a href="JobMangeAdd.aspx" class="arrow"  target="center" >新增岗位</a>
                
                  </li>
                  <li class="tttt" ><a href="JobMange.aspx" class="arrow" target="center">查询岗位</a>
                  
                 </li>
               </ul>
             </li>
           </ul>
          <%--以下为考生管理部分--%>
                 <ul id="webmenu" class="first-menu">
           <li class="ttt"><a href="" class="tt" >人员管理</a>
             <ul id="subNews" class="second-menu">
               <li class="tttt" ><a href="PersonnelMange.aspx" class="arrow" target="center">人员管理</a>
               </li>
             </ul>
           </li>
         </ul>
          <%--以下为报考审核部分--%> 
               <ul id="webmenu" class="first-menu">
           <li class="ttt"><a href="#" class="tt" >考生管理</a>
             <ul id="subNews" class="second-menu">
               <li class="tttt" ><a href="CandidatesInfoMange.aspx" class="arrow" target="center">考生管理</a>
               
               </li>
             </ul>
           </li>
         </ul>
                         <ul id="webmenu" class="first-menu">
           <li class="ttt"><a href="#" class="tt" >考试信息管理</a>
             <ul id="subNews" class="second-menu">
               <li class="tttt" ><a href="ExamGradeManage.aspx" class="arrow" target="center">考试信息管理</a>
               
               </li>
             </ul>
           </li>
         </ul>


               <ul id="webmenu" class="first-menu">
           <li class="ttt"><a href="#" class="tt" >报考审核</a>
             <ul id="subNews" class="second-menu">
               <li class="tttt" ><a href="JobTransfer.aspx" class="arrow" target="center">报考初审</a>
               </li>
                   <li class="tttt" ><a href="JobGradeManage.aspx" class="arrow" target="center">成绩录入</a>
               </li>
             </ul>
           </li>
         </ul>
                  <ul id="webmenu" class="first-menu">
           <li class="ttt"><a href="#" class="tt" >岗位统计</a>
             <ul id="subNews" class="second-menu">
               <li class="tttt" ><a href="JobMangeCount.aspx" class="arrow" target="center">岗位统计</a>
               </li>
                  
             </ul>
           </li>
         </ul>
              
 </div>       
          <div class="ww">
             <span class="wt"><a href="UserPwd.aspx?keepThis=true&TB_iframe=true&height=300&width=500" class="fLink thickbox">修改密码</a></span>   <span class="wt"><a href="../index.aspx">转到前台</a></span><span class="wt"><a href="Login.aspx">退出</a></span>
          </div>
        </div>
      </div>

       <iframe   style=" height:auto; width:100%; height: 1000px;"" name="center" id="iframepage" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" onLoad="iFrameHeight()"></iframe>

    
    </form>
</body>
</html>
