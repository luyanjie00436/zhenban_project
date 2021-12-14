<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReductionAdd.aspx.cs" Inherits="HumanManage_Web.ReductionAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
        .bgcolor {
            width:80%;
            border:2px solid  #cfd1d2;
            margin:0px auto;
            border-right:2px solid  #cfd1d2;
          
        }
    </style>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
      <style type="text/css">
          .auto-style5 {
              height: 31px;
          }
    </style>
    <script>
        function One() {
            
            var Num1 = document.getElementById("txtRatedOne").value;
            var Num2 = document.getElementById("txtReductionOne").value;
            if (Num1 != "" && Num2 != "") {
                if (parseFloat(Num1)<0) {
                    alert("额定工作量应大于0");
                    document.getElementById("txtRatedOne").focus();
                    return;
                }
                if (parseFloat(Num2) < 0) {
                    alert("减免后工作量应大于0");
                    document.getElementById("txtReductionOne").focus();
                    return; 
                }
                var Num3 = parseInt((parseFloat(Num1) - parseFloat(Num2)) / parseFloat(Num1) * 100);
                document.getElementById("txtProportionOne").value = Num3 + "%";
            }
        }
        function Two() {
            var Num1 = document.getElementById("txtRatedTwo").value;
            var Num2 = document.getElementById("txtReductionTwo").value;
            if (Num1 != "" && Num2 != "")
            {
                if (parseFloat(Num1) < 0) {
                    alert("额定工作量应大于0");
                    document.getElementById("txtRatedTwo").focus();
                    return;
                }
                if (parseFloat(Num2) < 0) {
                    alert("减免后工作量应大于0");
                    document.getElementById("txtReductionTwo").focus();
                    return;
                }
            var Num3 = parseInt((parseFloat(Num1) - parseFloat(Num2)) / parseFloat(Num1) * 100);
            document.getElementById("txtProportionTwo").value = Num3 + "%";
        }

        }
        function Three() {
            var Num1 = document.getElementById("txtRatedThree").value;
            var Num2 = document.getElementById("txtReductionThree").value;
            if (Num1 != "" && Num2 != "") {
                if (parseFloat(Num1) < 0) {
                    alert("额定工作量应大于0");
                    document.getElementById("txtRatedThree").focus();
                    return;
                }
                if (parseFloat(Num2) < 0) {
                    alert("减免后工作量应大于0");
                    document.getElementById("txtReductionThree").focus();
                    return;
                }
                var Num3 = parseInt((parseFloat(Num1) - parseFloat(Num2)) / parseFloat(Num1) * 100);
                document.getElementById("txtProportionThree").value = Num3 + "%";

            }
        }
        function bili() {
            var Num1 = document.getElementById("txtStopProportion").value;
            var patt1 = new RegExp(/^\d+\.{0,1}\d+%$/);

            var result = patt1.test(Num1);
            if (!result) {
                alert('停发比例应为百分数且为0%~100%之间！');
                return;
            }

            var str = Num1.replace("%", "");
            str = str / 100;
            if (parseFloat(str) < 0 || parseFloat(str) > 1) {
                alert('停发比例应为百分数且为0%~100%之间！');
                return;
            }
           
        }

    </script>
    </head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >减免工作量添加</div></div></div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                              <td align="right" class="auto-style1">
                                <strong>工号：</strong>
                            </td>
                            <td align="left">
                              <asp:TextBox ID="txtUserCardId" runat="server" CssClass="input1" data-toggle="tooltip" data-placement="top" ToolTip="请输入工号"></asp:TextBox>
                            </td>

                               <td align="right" ><strong>姓名:</strong> </td>
                                       <td align="left" >
                                           <asp:TextBox ID="txtUserName" data-toggle="tooltip" data-placement="top"  ToolTip="请填写姓名 例如（张三）" runat="server" CssClass="select1"></asp:TextBox>
                                           <asp:Button ID="Button3" runat="server" Text="查找人员" OnClick="Button3_Click" CssClass="btn" data-toggle="tooltip" data-placement="top" ToolTip="点击进行查找" />
                                       </td>
                             <td align="right" class="auto-style1">
                                选择人员:
                            </td>
                            <td>
                                 <asp:DropDownList ID="DlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserName_SelectedIndexChanged"
                                    CssClass="select1" data-toggle="tooltip" data-placement="top" ToolTip="请选择人员">
                                </asp:DropDownList>
                            </td>
                        </tr>
               <tr>
                           
                              <td align="right" class="auto-style1">
                                <strong>年份:</strong>
                              </td>
                            <td  align="left" class="auto-style1">
                                <asp:TextBox ID="txtApplyYear" runat="server"   CssClass="select1" ReadOnly="True"></asp:TextBox>
                            </td>
                            
                                
                        
                              </tr>
                         <tr>
                           <td align="center" colspan="7" class="auto-style5"><strong>申请减免工作量情况</strong> </td>  
                              </tr>
                        <tr>
                           <td align="Left" colspan="7"><strong>教学工作量</strong> </td>  
                              </tr>
                         <tr>
                            <td align="center" colspan="2"><strong>额定工作量</strong></td> 
                            <td align="Left"><input ID="txtRatedOne" runat="server"  data-toggle="tooltip" data-placement="top"  title="请填写额定工作量" class="select1" onblur="javascript:One();"></input></td>
                            <td align="center"><strong>减免后工作量</strong></td>
                            <td align="Left"><input ID="txtReductionOne" runat="server"  data-toggle="tooltip" data-placement="top"  title="请填写减免后工作量" class="select1" onblur="javascript:One();"></input></td>
                            <td align="center"><strong>减免比例</strong></td>
                            <td align="Left"><input ID="txtProportionOne" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写减免比例"  class="select1" ReadOnly="True"></input></td>
                         </tr>      
                        <tr>          
                           <td align="Left" colspan="7"><strong>教学建设与研究类工作量</strong> </td>  
                        </tr>  
                        <tr>          
                            <td align="center" colspan="2"><strong>额定工作量</strong></td> 
                              <td align="Left"><input ID="txtRatedTwo" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写额定工作量"  class="select1" onblur="javascript:Two();" ></input></td>
                              <td align="center"><strong>减免后工作量</strong></td>
                             <td align="Left"><input ID="txtReductionTwo" runat="server"  data-toggle="tooltip" data-placement="top"  title="请填写减免后工作量" class="select1" onblur="javascript:Two();" ></input></td>
                            <td align="center"><strong>减免比例</strong></td>
                             <td align="Left"><input id="txtProportionTwo" data-toggle="tooltip" data-placement="top"  title="请填写减免比例"  runat="server"  class="select1" readonly="true"></input></td>
                              </tr>
                        <tr>         
                           <td align="Left" colspan="7"><strong>社会工作量</strong> </td>  
                              </tr>
                         <tr>         
                           <td align="center" colspan="2"><strong>额定工作量</strong></td> 
                              <td align="Left"><input ID="txtRatedThree" runat="server"  data-toggle="tooltip" data-placement="top"  title="请填写额定工作量"  class="select1" onblur="javascript:Three();"></input></td>
                              <td align="center"><strong>减免后工作量</strong></td>
                             <td align="Left"><input ID="txtReductionThree" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写减免后工作量"   class="select1" onblur="javascript:Three();"></input></td>
                            <td align="center"><strong>减免比例</strong></td>
                             <td align="Left"><input ID="txtProportionThree" data-toggle="tooltip" data-placement="top"  title="请填写减免后工作量"  runat="server"  class="select1" ReadOnly="True"></input></td>
                              </tr>
                          <tr>         
                           <td align="center" colspan="2"><strong>是否停发相应岗位津贴</strong></td> 
                              <td align="Left">
                                   <asp:RadioButtonList ID="txtWhetherStop" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请选择是否停发相应岗位津贴" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="是">是</asp:ListItem>
                                    <asp:ListItem Value="否">否</asp:ListItem>
                                </asp:RadioButtonList>
                              </td>
                              <td align="center"><strong>停发比例</strong></td>
                             <td align="Left"><input ID="txtStopProportion" runat="server" data-toggle="tooltip" data-placement="top"  title="请填写停发比例"  class="select1"  onblur="javascript:bili();"></input></td>
                            <td align="center"><strong>停发时间</strong></td>
                             <td align="Left"><asp:TextBox ID="txtStopDate" runat="server" onfocus="WdatePicker()" data-toggle="tooltip" data-placement="top"  ToolTip="请点击选择也可手动输入停发时间日期 例如（2015-11-12）" CssClass="select1"></asp:TextBox></td>
                              </tr>
                       <tr>          
                           <td align="Left" colspan="2"><strong>申请减免工作量理由</strong> </td>  
                              <td align="Left" colspan="5"> <asp:TextBox ID="txtReason" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="申请减免工作量理由" CssClass="select1" Height="200px" TextMode="MultiLine" Width="694px"></asp:TextBox></td>
                              </tr>  
           
                         <tr>   
                           
                           <td align="right" colspan="4">
                                       <br />  
                               <asp:Button ID="Button1" runat="server" CssClass="btn" data-toggle="tooltip" data-placement="top"  ToolTip="点击添加" OnClick="Button1_Click" Text="添 加" /> </td>  
                                     
                              <td align="Left" colspan="3"><br /> <asp:Button ID="Button2" data-toggle="tooltip" data-placement="top"  ToolTip="点击保存" runat="server" CssClass="btn" OnClick="Button2_Click" Text="保 存" /></td>
                              </tr>  
                     
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
