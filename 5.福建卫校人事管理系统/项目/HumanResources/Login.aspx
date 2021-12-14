<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HumanManage_Web.Login" %>

<!DOCTYPE html>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1">
      <meta name="renderer" content="webkit">
    <title>人力资源管理系统</title>
    <link href="images/login.css" rel="stylesheet" type="text/css" media="all" />
    <link type="text/css" rel="stylesheet" href="css/master.css" />
    <style type="text/css">
            * {
        margin:0px;
        padding:0px;
        }
     html {
           background-image: url('images/login_bj9.png'); 
             position:relative;
            width:100%; height:100%; 
            z-index:2; background-repeat:space; background-size:100% 100%;
            margin:0px; 

            }

      body {
            background:none;
        }
       span {
            font-size:16px;
            font-family:宋体;
        }
       .input01{ width:200px; height:20px; border-radius:15px; margin-top:10px; background:#202020;color:white; }
         .wrap {
            margin-top:90px;
           
        }
          .forgetcs {
            text-align:center; 
            color:#fff;
        }
            .forgetcs a {
                color:#fff;
            }
        .login_btnleft a:hover {
            color:red;
        }
        #LinkButton9 {
            color:#fff;
             font-size:16px;
        }
            #LinkButton9:hover {
                color:yellow;
                text-decoration:none;
            }
        #LinkButton1 {
             color:#fff;
             font-size:16px;
        }
        #LinkButton1:hover {
            color:yellow;
                text-decoration:none;
        }
        .a_l {
            color:#fff; font-size:12px;
            text-shadow:3px 2px 10px #000000; 
        }
        .login_topdiv {
            position:relative;
            top: 0px;
            left: 0px;
        }
        .login_center {
            position:relative;
        }
        .login_logo {
            width:508px;
            height:71px;
            background-image:url(Images/login_logo.png);
            margin:0px auto;
            margin-top:80px;
        }

</style>
</head>
<body>
    <form id="form1" runat="server">
                <div style="width:119px; height:29px;  background-image:url(/images/login_logo_biaoti.png); float:right; position:absolute; margin-top:450px; margin-left:1200px; z-index:500; float:right; overflow:hidden;"></div>

    <div class="login_logo"></div>
    <div class="login_center">
           <div class="login_login">
               
                <div class="wrap">
                 <div class="login_h2">
               <span>用户名:</span>
                          <div  style="padding-left:90px;" > <input  ID="txtLoginUserCardId" class="input01" runat="server" type="text"/>  </div>  
               </div>
                 <div class="login_h5" style="margin-top:20px;">
                                                                      
                     <span>密</span><span> 码:</span>
                   
                         <div style="padding-left:20px;" >
                         
                           <input type="password" ID="txtLoginUserPwd" class="input01" runat="server" aria-checked="undefined" aria-live="off" onfocus="this.type='password'" />  
                </div>
                
                  <div class="login_h4" style="margin-top:30px;" >   
                                     
                        <div class="login_btn" style="margin:0px auto; text-align:center; " >
                            <div style="margin:0px auto; text-align:center; height:30px; width:200px;">
                           <div class="login_btnleft">
                             <asp:LinkButton ID="LinkButton9"  runat="server" style="font-size:16px; " OnClick="LinkButton9_Click" > 登 录</asp:LinkButton>

                               </div>
                            <div class="login_btnright "style="border-left:1px solid #fff;" >
                             <asp:LinkButton ID="LinkButton1"  runat="server" style="font-size:16px; " OnClick="LinkButton1_Click" > 重 置</asp:LinkButton>

                            </div>
                                </div>
                        </div>
                          
                    </div>

            </div>
                </div>
       
     </div>
        <div style="text-align:center;">   
         <span style="color:#fff; font-size:12px; font-family:微软雅黑;"><a class="a_l" href="#">忘记密码？请联系 Tel:15159430496     QQ:154058934</a></span> 
            </div>
    </form>
</body>
</html>
