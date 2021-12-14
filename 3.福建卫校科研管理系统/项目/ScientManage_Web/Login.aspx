<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ScientManage_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>科研工作管理系统</title>
       <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1"/>
      <meta name="renderer" content="webkit"/>
    <link href="images/login.css" rel="stylesheet" type="text/css" media="all" />
    <link type="text/css" rel="stylesheet" href="css/master.css" />
    <style type="text/css">
        
         body {
          background:none;
         
        }
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
         .input01{ width:200px; height:20px; border-radius:15px; margin-top:10px; background:#202020;color:white; }
        span {
            font-size:16px;
            font-family:宋体;
        }
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
        }
        .login_center {
            position:relative;
        }
</style>
         
 <script language="javascript">
           document.getElementById('txtLoginUserPwd').value = '';
           document.getElementById('txtLoginUserCardId').value = '';
    
</script>

</head>
<body>
    <form id="form1" runat="server">

        <div style="width:119px; height:29px;  background-image:url(/images/login_logo_biaoti.png); float:right; position:absolute; margin-top:510px; margin-left:1200px; z-index:500; float:right;"></div>
       
    <div class="login_topdiv"> </div>
       
    <div class="login_center">
       
       
            <div class="login_login">
                
                 
                <div class="wrap">
                <div class="login_h2"">
                  <span>用户名:</span>
                    <div style="padding-left:90px;" >
                         <input  ID="txtLoginUserCardId" class="input01" runat="server" />                                                     
                    </div>
                </div>
                 <div class="login_h5"  style="margin-top:20px;">
                     <span>密</span><span> 码:</span>
                     <div style="padding-left:20px;"">
                         <input type="password" ID="txtLoginUserPwd" class="input01" runat="server" aria-checked="undefined" aria-live="off" onfocus="this.type='password'" />  
                     </div>
                </div>
                  <div class="login_h4" style="margin-top:30px;">   
                                     
                        <div  class="login_btn" style="margin:0px auto; text-align:center; ">
                            <div style="margin:0px auto; text-align:center; height:30px; width:200px;">
                             <div class="login_btnleft">
                             <asp:LinkButton ID="LinkButton9"  runat="server" style="font-size:16px; " OnClick="LinkButton9_Click" > 登 录</asp:LinkButton>
                               </div>
                            <div class="login_btnright " style="border-left:1px solid #fff;">
                                    <asp:LinkButton ID="LinkButton1"  runat="server" style="font-size:16px; " OnClick="LinkButton10_Click" > 重 置</asp:LinkButton>
                               <%-- <asp:LinkButton ID="LinkButton0"  runat="server"   OnClick="reset_Click" style="color:yellow;font-size:16px;" >重置</asp:LinkButton>--%>
                               </div>
                                </div>
                        </div>
                  
                    </div>

            </div>
      
     </div>
        <div style="text-align:center; color:#fff;">   
         <span style="color:#fff; font-size:12px; font-family:微软雅黑;">忘记密码？请联系 Tel:15159430496&nbsp;&nbsp;&nbsp;&nbsp; QQ:154058934
         </span> 
                 <br /> 
                <asp:LinkButton ID="LinkButton2" ForeColor="White" runat="server" OnClick="LinkButton1_Click1">申报人员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton3" ForeColor="White"  runat="server" OnClick="LinkButton2_Click1">系部管理员手册</asp:LinkButton>
       <br />    <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="White"  OnClick="LinkButton3_Click1">学院领导手册</asp:LinkButton>   
       
           &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton5" ForeColor="White"  runat="server" OnClick="LinkButton4_Click1">系统管理员手册</asp:LinkButton>
         &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton6" ForeColor="White"  runat="server" OnClick="LinkButton5_Click1">专家手册</asp:LinkButton>
         <br /> <br />   
            </div>
            
    </div> 
               
    </form>
</body>
</html>
