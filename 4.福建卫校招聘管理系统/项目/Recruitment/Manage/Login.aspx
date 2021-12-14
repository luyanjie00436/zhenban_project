<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recruitment.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
              <link href="css/slideshow.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css"/>  
	<script src="https://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js" ></script>
	<script src="https://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title></title>
    <style type="text/css">
.bg {width:80%; height:400px;background:#eeeeee; border:1px solid #eeeeee; border-radius:10px; margin:0px auto; margin-top:100px; overflow:hidden;}
.zuo { width:600px; height:300px; margin:0px auto;background:#337ab7; margin-top:60px;   border-radius:5px; border:1px solid #337ab7;  position:relative; z-index:9999; }      
.zuoshang { width:100%; height:260px;background-image: url('image/kuangg.png'); margin-top:-2px;           }
.input-group{ margin:0px auto;position: relative;width: 395px; height:100px;}                
.icon-user{position: absolute;z-index:5; left:180px;margin-top:22px;/*background-image: url('images/login_jt.png'); /*引入图片图片*/background-repeat: no-repeat; /*设置图片不重复*/background-position: 0px 0px; float:left;/*图片显示的位置*/width: 34px; /*设置图片显示的宽*/height: 34px; /*图片显示的高*/}
.work {  margin:0px auto; margin-top:0px; height:200px; }
 .input01{ width:250px;float:right; height:35px; border-radius:15px; margin-top:10px;color:white; }
    </style>
    <script type="text/javascript">
        function jiancha()
        {
            var val = document.getElementById('txtLoginUserCardId').value;
            if (val == null || val == undefined || val == '')
            {
                alert('账号不能为空');
                return false;
            }
            if (/.*?[\u4E00-\u9FFF]+.*/gi.test(val))
            {
                alert('账号不能含有中文字符');
                return false;
            }
            
            var val2 = document.getElementById('txtLoginUserPwd').value;
            if (val2 == null || val2 == undefined || val2 == '') {
                alert('密码不能为空');
                return false;
            }
        
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="bg">     
        <div class="zuo" >
            <div style="width:99%;height:40px;background:#337ab7;">
  <div style="margin-top:5px; margin-left:20px; font-size:20px; color:#fff; position:absolute;z-index:200; ">福建卫生职业技术学院考试报名网</div>
            </div>
        
            <div class="zuoshang" >
              <div class="work" >
                <div  class="input-group">
                  <span style="float:left; color:#000; text-align:right; width:105px; height:38px;margin-top:50px; font-size:25px;  " >用户名:</span> 
                     <input id="txtLoginUserCardId" type="text" runat="server" style="width:250px; float:right; height:35px;margin-top:50px; border-radius:5px; " class="form-control" /> <%--placeholder="请输入账号"--%>
                </div>
                <div  class="input-group">       
                  <span style="float:left;color:#000; text-align:right; width:105px; height:38px;margin-top:30px; font-size:25px; " >密&nbsp;码:</span>
                    <input id="txtLoginUserPwd" type="password" runat="server" aria-live="off" onfocus="this.type='password'"  style="width:250px; float:right; height:35px;margin-top:30px; border-radius:5px; " class="form-control" />    <%-- placeholder="请输入密码"--%>   
                    <asp:LinkButton ID="LinkButton1"  runat="server" style="width:60px;float:right;  margin-left:5px; margin-top:30px; " OnClick="LinkButton1_Click"  OnClientClick="return jiancha()" > 登 录</asp:LinkButton>         
                  <%--<input style="width:60px; margin-left:5px; margin-top:30px; " type="button" value="登 录" />--%>
                </div>        
             </div>
           </div>
         </div>
      </div>
    </form>
</body>
</html>
