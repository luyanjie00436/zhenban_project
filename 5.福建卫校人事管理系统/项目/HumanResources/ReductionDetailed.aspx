<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReductionDetailed.aspx.cs" Inherits="HumanManage_Web.ReductionDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 12%;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >个人减免工作量申请表</div></div></div>
        <div class="page_main01">
            
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                               <td align="right" class="auto-style1">
                                <strong>年份：</strong>
                            </td>
                            <td align="left" colspan="2"  >
                               <asp:Label ID="LApplyYear" runat="server" ></asp:Label>
                                    </td>
                             <td  align="right" >
                                <strong>姓名：</strong>
                            </td>
                            <td  align="left">
                                <asp:Label ID="LUserName" runat="server" ></asp:Label>

                            </td>
                    
                            </tr>
                        <tr>
                            <td align="right" style="width:250px;"> <strong>教学额定工作量：</strong></td>
                            <td colspan="2"><asp:Label ID="LRatedOne" runat="server" ></asp:Label>   </td>
                            <td  align="right"> <strong>教学减免后工作量：</strong></td>
                            <td colspan="2" > <asp:Label ID="LReductionOne" runat="server" ></asp:Label></td>
                            <td  align="right"> <strong>教学减免比例：</strong></td>
                            <td colspan="2"><asp:Label ID="LProportionOne" runat="server" ></asp:Label></td>
                            </tr>                    
                        <tr>
                             <td  align="right"> <strong>教学建设与研究类额定工作量：</strong></td>
                            <td colspan="2"><asp:Label ID="LRatedTwo" runat="server" ></asp:Label>   </td>
                            <td  align="right"> <strong>教学建设与研究类减免后工作量：</strong></td>
                            <td colspan="2" > <asp:Label ID="LReductionTwo" runat="server" ></asp:Label></td>
                            <td  align="right" > <strong>教学建设与研究类减免比例：</strong></td>
                            <td colspan="2"><asp:Label ID="LProportionTwo" runat="server" ></asp:Label></td>
                            </tr>
                         <tr>
                            <td  align="right"> <strong>社会额定工作量：</strong></td>
                            <td colspan="2"><asp:Label ID="LRatedThree" runat="server" ></asp:Label>   </td>
                            <td  align="right"> <strong>社会减免后工作量：</strong></td>
                            <td colspan="2" > <asp:Label ID="LReductionThree" runat="server" ></asp:Label></td>
                            <td  align="right" > <strong>社会减免比例：</strong></td>
                            <td colspan="2"><asp:Label ID="LProportionThree" runat="server" ></asp:Label></td>
                            </tr> 
                         <tr>
                            <td  align="right"> <strong>是否停发相应岗位津贴：</strong></td>
                            <td colspan="2"><asp:Label ID="LWhetherStop" runat="server" ></asp:Label>   </td>
                            <td  align="right"> <strong>停发比例：</strong></td>
                            <td colspan="2" > <asp:Label ID="LStopProportion" runat="server" ></asp:Label></td>
                            <td  align="right" > <strong>停发时间：</strong></td>
                            
                              <td  align="left" colspan="2">
                                <input id="txtStopDate" runat="server" cssclass="Wdate" readonly="true" 
                                    class="input1" aria-readonly="True">
                                 </td>
                            </tr> 

                           
                        <tr>
                            <td align="right" class="auto-style1">
                                <strong>停发理由：</strong>
                            </td>
                            <td colspan="8">
                                 <asp:Label Height="200" data-toggle="tooltip" data-placement="top"  ToolTip="请输入停发理由" style="overflow-y:auto" ReadOnly="true" ID="txtReason" runat="server" CssClass="input1" width="98%" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine" Enabled="false"></asp:Label>
                          
                            </td>
                        </tr>  
                    </table>
                                
                       
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
