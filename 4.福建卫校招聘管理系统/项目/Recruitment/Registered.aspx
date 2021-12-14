<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="Recruitment.Registered" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jss.js"></script>
     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <style type="text/css">
        .youu { width:100%;  height:660px; background:#fafafa; margin:0px auto; overflow:hidden;   }
        .you_kuangg {
            width:50%;
            border:1px solid #697986;
            height:500px;
            margin:0px auto;
            margin-top:10px;
        }
        table {
            margin:0px auto;
            margin-top:20px;
            margin-left:40px;
        }
        table td {
           height:40px;
           font-size:16px;
        }
        table tr span {
            color:red;font-weight:bold; font-size:14px;
           
        }
        .zhuce {
            width:100%;
            height:29px;
            background-image:url(/image/zhuce.png);
        }
            .zhue {
                width:100px;
                float:left;
                margin-top:8px;
                font-weight:bold;
                color:#333333;
            }
        /*.youy {
            width:100%;
            background:#f2f2f2;
            margin-top:10px;
            border:1px solid #ccc ;
        }*/
        .wrapp { width:100% ; height:700px;    }

    </style>
     <script type="text/javascript">
        function jiancha()
        {
            var val = document.getElementById('txtNumber').value;
            if (/.*?[\u4E00-\u9FFF]+.*/gi.test(val))
            {
                alert('用户名不能含有中文字符，请重填');
                return false;
            }
            else if (val == "")
            {
                alert('用户名不能为空');
                return false;
            }
            var vals = document.getElementById('txtName').value;
            reg = /^[a-zA-Z\u4e00-\u9fa5]+$/;
            if (vals == "") {
                alert('姓名不能为空');
                return false;
            }
            else if (!reg.test(vals)) {
                alert('姓名不能含有数字和特殊字符，请重填');
                return false;
            }
            var vala = document.getElementById('txtCardID').value;
            //rea = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//15位
            rea = /^[0-9]{6}[12][09][0-9]{2}(([0][1-9])|([1][0-2]))(([0][1-9])|([12][0-9])|([3][01]))[0-9]{3}[0-9X]$/;//18位
            //rea = /^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/;
            if (vala == "") {
                alert('身份证号不能为空');
                return false;
            }
            else if (!rea.test(vala)) {
                alert('身份证号不符合规则，请重填');
                return false;
            }
            var vall = document.getElementById('txtBirthday').value;
            if (vall == "") {
                alert('生日不能为空');
                return false;
            }
            var Email = document.getElementById('txtEmail').value;
            filter = /^[A-Za-zd0-9\u4e00-\u9fa5]+([-_.][A-Za-zd0-9]+)*@([A-Za-zd0-9]+[-.])+[A-Za-zd]{2,5}$/;
            //filter = /^[a-zA-Z0-9\u4e00-\u9fa5]|[a-zA-Z0-9]+[_-]+[a-zA-Z0-9]{1,18}@[a-zA-Z0-9]{1,5}\.[a-zA-Z0-9]{1,5}\.[a-zA-Z0-9]{1,5}$/;

            if (Email == "") {
                alert('电子邮箱不能为空');
                return false;
            } 
            else if (!filter.test(Email)) {
                alert('您的电子邮箱格式不正确，请重填');
                return false;
            }
            var phone = document.getElementById('txtContactPhone').value;
            if (phone == "") {
                alert('手机号码不能为空');
                return false;
            }
           
            else if (!(/^1[34578]\d{9}$/.test(phone))) {
                alert("手机号码有误，请重填");
                return false;
            }
            var pwd1 = document.getElementById('txtPwd1').value;
            if (pwd1 == "") {
                alert('登录密码不能为空');
                return false;
            }
            var pwd2 = document.getElementById('txtPwd2').value;
            if (pwd1 == "") {
                alert('确认密码不能为空');
                return false;
            }
            return true;
          
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="wrapp" >
        <div class="youu" >
<%--            <div class="youy" ></div>--%>
            <div class="you_kuangg" >
                <div class="zhuce"><span class="zhue" >注册页面</span></div>
               <table width="100%" border="0">
                    <tr><td align="right" ><span>*</span>用户名：</td><td align="left" ><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox></td></tr>
                   <tr><td align="right" ><span>*</span>姓名：</td><td align="left" ><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
                   <tr><td align="right" ><span>*</span>身份证号:</td><td align="left" > <asp:TextBox ID="txtCardID" runat="server"></asp:TextBox></td></tr>
                   <tr><td align="right" ><span>*</span>生日:</td><td align="left" ><input id="txtBirthday" runat="server"  data-placement="top" data-toggle="tooltip"  onfocus="WdatePicker()" /></td></tr>
                   <tr><td align="right" ><span>*</span>性别:</td><td align="left" >
                       <asp:DropDownList Width="155px" ID="DGender" runat="server" >
                                   <asp:ListItem Value="男">男</asp:ListItem>  
                                   <asp:ListItem Value="女">女</asp:ListItem>    
                                </asp:DropDownList></td></tr>
                   <tr><td align="right" ><span>*</span>电子邮箱:</td  ><td align="left"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
                   <tr><td  align="right"><span>*</span>手机号码:</td   ><td align="left" ><asp:TextBox ID="txtContactPhone" runat="server"></asp:TextBox></td></tr>
                   <tr><td align="right" ><span>*</span>登录密码:</td ><td align="left" ><asp:TextBox ID="txtPwd1" runat="server" TextMode="Password"></asp:TextBox></td></tr>
                   <tr><td align="right" ><span>*</span>确认密码:</td  ><td align="left" ><asp:TextBox ID="txtPwd2" runat="server"  TextMode="Password"></asp:TextBox></td></tr>
<tr><td   align="right" style="height:20px;" ><asp:Button ID="Button10" runat="server" Text="确认注册" OnClick="Button10_Click" OnClientClick="return jiancha()" /><td  align="left"  style="height:20px;" ><asp:Button ID="Button1" runat="server" Text="返回登录" OnClick="Button9_Click"  /></td></tr>
               </table>
            </div>
        </div>
      </div>
    </div>
    </form>
</body>
</html>
