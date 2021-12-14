<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Recruitment.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="https://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css">  
	<script src="https://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style type="text/css">
body {background:#fafafa; }
 .xian {width:500px; height:200px; border:1px solid #a9a9a9; margin:0px auto; margin-top:180px;         }
.xiana { width:100%; height:29px; background-image:url(/image/zhuce.png); }
span { width:100px; float:left; margin-left:10px; margin-top:5px;font-weight:500; }
.work {  width:480px;  height:45px;  margin:0px auto; margin-top:10px;  }
 .input-group{ margin:0px auto;position: relative;width: 375px; }                
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="xian" >
    <div class="xiana"><span>考生登录页面</span></div>
        <div class="work" >
          <div  class="input-group">
                  <span style="float:left; color:#000; text-align:right; width:75px; height:38px;margin-top:10px; font-size:15px;  " >
                      用户名:</span>  
              <input id="txtNumber" type="text" runat="server" style="width:250px; float:right; height:25px;margin-top:10px; border-radius:5px; " class="form-control"/>  <%--placeholder="请输入账号"--%>
                </div>
            </div>
        <div class="work" >
                <div  class="input-group">       
                  <span style="float:left;color:#000; text-align:right; width:75px; height:38px;margin-top:20px; font-size:15px; " >密&nbsp;码:</span>
                   
                  
                     <input id="txtPwd" type="password" runat="server" aria-live="off" onfocus="this.type='password'" style="width:250px; float:right; height:25px;margin-top:10px; border-radius:5px; " class="form-control"/>   <%-- placeholder="请输入密码"--%>             
                </div>   
             </div>
        <div>
            <asp:LinkButton ID="LinkButton1"  runat="server" style="width:60px;float:right;  margin-right:85px; margin-top:10px; " OnClick="LinkButton1_Click" > 登 录</asp:LinkButton>
           <asp:LinkButton ID="LinkButton2"  runat="server" style="width:60px;float:right;  margin-right:85px; margin-top:10px; " OnClick="LinkButton2_Click" >注 册</asp:LinkButton>
            
              <%--<input style="width:60px; float:right; margin-right:85px; margin-top:10px; " type="button" value="登 录" />--%></div>                         
    </div>
    </form>
</body>
</html>
