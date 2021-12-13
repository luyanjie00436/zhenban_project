<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sanmingScientManage_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>科研管理系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link href="images/login.css" rel="stylesheet" type="text/css" media="all" />
    <link type="text/css" rel="stylesheet" href="css/master.css" />
   <script>
    
           document.getElementById("txtLoginUserPwd").type = 'password';

   </script>
    <style type="text/css">
* {
    margin:0px;
    padding:0px;
}
a{ text-decoration:none; color:#FFF; cursor:pointer;}
#wrap{ width:100%; margin:0px auto;}
#dbj{ width:100%; height:660px; background-image:url(Images/login_bj9.png);   width:100%; z-index:200; background-repeat:space; background-size:100% 100%;overflow:hidden; position:relative;
            margin:0px;  }
#xkbj{width:100%;height:354px;margin:0 auto; background:url(../images/login_kuank2.png) no-repeat bottom;overflow:hidden;text-align:center; z-index:201;  }
#shang{ width:270px; height:200px; margin:0px auto; }
#xx{ margin-top:20px;}
#dengl{ width:268px; height:40px; background-image:url(Images/denglu.png);  margin:0px auto; margin-top:30px; letter-spacing:10px; color:#FFF; text-align:center; line-height:40px; }
.dengl{ width:268px; height:40px; background-image:url(Images/denglu.png);  margin:0px auto; margin-top:30px; letter-spacing:10px; color:#FFF; text-align:center; line-height:40px; }

#apDiv1 {
	position: absolute;
	width: 200px;
	height: 115px;
	z-index: 1;
	left: 785px;
	top: 208px;
}
 .bton_text {
            text-align:center;
                  
                
        }
        .bton_text a {
        color:black;
        }
      .login_h5   span {
            width:45px;
            font-size:16px;
            font-family:宋体;
            color:#fff;
        }
      .login_h2 span {
           width:90px;
            font-size:16px;
            font-family:宋体;
            color:#fff;
        }
  .input8{ width:200px; height:20px; border-radius:15px; margin-top:10px; background:#202020; color:#fff; }
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
              #LinkButton6 {
            color:#fff;
             font-size:16px;
        }
            #LinkButton6:hover {
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
        }
        .login_logo {
            width:508px;
            height:71px;
            background-image:url(Images/login_logo.png);
            margin:0px auto;
            margin-top:50px;
        }
</style>
         
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                <div style="width:119px; height:29px;  background-image:url(/images/login_logo_biaoti.png); float:right; position:absolute; margin-top:510px; margin-left:1200px; z-index:500; float:right;"></div>

                
<div id="wrap">
<div id="dbj">
   <div class="login_logo"></div>

  <div id="xkbj">
     
  
     <div style="margin-top:60px;">
            <div class="login_h5">
                      <span >角</span><span> 色:</span>
                       <div >
                           <asp:DropDownlist ID="DlRank" runat="server" CssClass="input8">  </asp:DropDownlist>
                       </div>
            </div>


            <div class="login_h2">
                <span>用户名:</span>
                     <div>
                         <div >
                         <input  ID="txtLoginUserCardId" class="input8" runat="server" type="text"/>                                                     
                         </div>          

                     </div>
             </div>

             <div class="login_h5">
                 <span>密</span><span> 码:</span>
                     <div >
                         <input type="password" ID="txtLoginUserPwd" class="input8" runat="server" onfocus="this.type='password'"/>                                                
                     </div>
                </div>
       <div class="login_h4" style="margin-top:30px;">   
                                     
                        <div  class="login_btn" style="margin:0px auto; text-align:center; ">
                            <div style="margin:0px auto; text-align:center; height:30px; width:200px;">
                             <div class="login_btnleft">
                             <asp:LinkButton ID="LinkButton9"  runat="server" style="font-size:16px; " OnClick="LinkButton9_Click" > 登 录</asp:LinkButton>
                               </div>
                            <div class="login_btnright " style="border-left:1px solid #fff;">
                                    <asp:LinkButton ID="LinkButton6"  runat="server" style="font-size:16px; " OnClick="LinkButton1_Click" > 重 置</asp:LinkButton>
                               <%-- <asp:LinkButton ID="LinkButton0"  runat="server"   OnClick="reset_Click" style="color:yellow;font-size:16px;" >重置</asp:LinkButton>--%>
                               </div>
                                </div>
                        </div>
                  
                    </div>
     </div>
  </div>
    <div class="bton_text" >
 
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" Font-Size="12px" ForeColor="White" >申报人员手册</asp:LinkButton>
         &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" Font-Size="12px" ForeColor="White" runat="server" OnClick="LinkButton2_Click1">系部领导手册</asp:LinkButton>
       <br />    <asp:LinkButton ID="LinkButton3" runat="server" Font-Size="12px" ForeColor="White" OnClick="LinkButton3_Click1">职能部门领导手册</asp:LinkButton>   
       
           &nbsp;&nbsp;<asp:LinkButton ID="LinkButton4" Font-Size="12px" ForeColor="White" runat="server" OnClick="LinkButton4_Click1">系统管理员手册</asp:LinkButton>
         &nbsp;&nbsp; <asp:LinkButton ID="LinkButton5" Font-Size="12px" ForeColor="White" runat="server" OnClick="LinkButton5_Click1">评审专家手册</asp:LinkButton>
         <br /> <br /> 
    </div>

</div>
</div>
                   </ContentTemplate></asp:UpdatePanel>
                    
             
    </form>
</body>
</html>
