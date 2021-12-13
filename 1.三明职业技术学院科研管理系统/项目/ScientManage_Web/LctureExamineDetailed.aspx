<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LctureExamineDetailed.aspx.cs" Inherits="sanmingScientManage_Web.LctureExamineDetailed" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        Table
        {
         border-collapse: collapse;
         width:1024px;
         margin-top:-1px;
            }
        .td1
        {
            width:133px;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }

        .td2
        {
            width:133px;
            text-align:center;
            height:24px;
            line-height:24px;
            border: 1px solid #000000;
        }
       
        .td4
        {
            width:100px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            line-height:24px;
            }
        .td5
        {
           width:80px;
            height:24px;
            line-height:24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >讲座审批表</div></div></div><br />

        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td class="btn_left1">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn11" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width:1024px;height:297mm;margin:0 auto">
                    <div>
                       <table class="bg">

                                   
                            <tr>
                                <td align="right"> 讲座（报告）题目:</td>
                                <td colspan="6" align="left">
                                     <asp:Label ID="LLctureName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right"> 承办单位:</td>
                                <td colspan="6" align="left">
                                     <asp:Label ID="LCompany" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" rowspan="2">
                                    主讲人基本情况:
                                </td>
                                  <td align="right" class="td1" >
                                        姓名:</td>
                                    <td align="left" >
                                        <asp:Label ID="LUserName" runat="server"></asp:Label>
                                    </td>
                                    <td class="td1">
                                        性别:</td>
                                    <td align="left" >
                                        <asp:Label ID="LUserGender" runat="server"></asp:Label>
                                    </td>
                                 <td class="td1">
                                        职称:</td>
                                    <td align="left" >
                                        <asp:Label ID="LUserJob" runat="server"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                               
                                  <td align="right" class="td1" >
                                        职务:</td>
                                    <td align="left" >
                                        <asp:Label ID="LUserRole" runat="server"></asp:Label>
                                    </td>
                                    <td class="td1">
                                        工作单位:</td>
                                    <td align="left" colspan="3" >
                                        <asp:Label ID="LUserCompany" runat="server"></asp:Label>
                                    </td>
                                   
                            </tr>
                            <tr>
                                  <td align="right"> 级别:</td>
                                <td colspan="2" align="left">
                                     <asp:Label ID="LDLevel" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    讲座时间:
                                </td>
                                <td colspan="3" align="left">
                                    <asp:Label ID="LLctureDate" runat="server"></asp:Label>
                                </td>
                                 </tr>
                             <tr>
                                <td align="right">讲座地点:</td>
                                <td colspan="2" align="left">
                                    <asp:Label ID="LAddress" runat="server"></asp:Label>
                                </td>
                           
                              
                                <td align="right">参加人数:</td>
                                <td colspan="3" align="left">
                                    <asp:Label ID="LLctureNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    讲座内容简介:
                                </td>
                                <td colspan="6" align="left">
                                      <asp:Label ID="LLctureExplain" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                   设备需求:
                                </td>
                                <td colspan="6" align="left">
                                      <asp:Label ID="LEquipment" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    组织人:
                                </td>
                                <td colspan="2" align="left">
                                    <asp:Label ID="LOrganName" runat="server"></asp:Label>
                                </td>
                                <td align="right">联系电话:</td>
                                <td colspan="3" align="left">
                                    <asp:Label ID="LPhoneNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td align="right">
                                   拟发酬金标准:
                                </td>
                                <td colspan="6" align="left">
                                      <asp:Label ID="LCapital" runat="server"></asp:Label>
                                </td>
                            </tr>
                         
                            <tr>
                                <td align="right">
                                  备注:
                                </td>
                                <td colspan="6" align="left">
                                      <asp:Label ID="LRemarks" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
               
                    </div>
                        <div>
                   <asp:DataList ID="dataOfYear" runat="server" Width="100%" 
              style=" margin:0 auto" >

                    
              <ItemTemplate>
                  <table style="width:100%; margin-top:5px; border:none;">
                      <tr>
                          <td  rowspan="2"  style=" border: 1px solid #000000;  height:auto ;width:40px;" >
                               <asp:Label ID="Label5" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                              <asp:Label ID="Label4" runat="server" Text='<%# Eval("RankName") %>'></asp:Label>审批
                          </td>
                           <td  colspan="3" style=" border: 1px solid #000000; vertical-align: top;" >
                          意见：  <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExamineOpinion") %>'></asp:Label>
                          </td>
</tr>
                      <tr>      
                         
                          <td  style=" border: 1px solid #000000;">
                           审批人：   <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                          </td>
                          <td style=" border: 1px solid #000000;">
                            审批日期：  <asp:Label ID="Label3" runat="server" Text='<%# Eval("ExamineDate") %>'></asp:Label>
                          </td>
                          <td  style=" border: 1px solid #000000;">
                             审批结果; <asp:Label ID="Label6" runat="server" Text='<%# Eval("ExamineResult") %>'></asp:Label>
                          </td>
                      </tr>
                     
                  </table>
              </ItemTemplate>
              <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
          </asp:DataList>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        
                        <strong>审批意见：</strong>&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtExamineOpinion" runat="server" Columns="1" CssClass="select1" Height="80" MaxLength="400" Rows="5" TextMode="MultiLine" width="98%"></asp:TextBox>
                  
                    </td>
                </tr>
                <tr>
                    <td width="3">
                        
                        &nbsp;</td>
                    <td height="28" >
                        <div class="page_title_txt">
                       <asp:Button ID="Button1" runat="server" Text="同 意" OnClick="Button1_Click" CssClass="btn" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" Text="拒 绝" OnClick="Button2_Click" CssClass="btn" />
                  </div>
                    </td>
                    <td width="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>