<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityDetailed.aspx.cs" Inherits="sanmingScientManage_Web.ActivityDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="OE=edge,chrome=1" >
      <meta name="renderer" content="webkit">
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
            text-align:left;
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
              <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >查看详情</div></div></div><br />
        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td class="btn_left1">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" class="btn11" />
                      <asp:Button  runat="server" ID="buttom2"  CssClass="btn" Text="导 出" OnClick="buttom2_Click"/>
                    </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width:1024px;height:297mm;margin:0 auto">
                    <div>
                  <table  >
              <tr>
                  <td class="td3" colspan="6">
                      个人基本信息</td>
              </tr>
              <tr>
                  <td class="td1" >
                      姓名:</td>
                  <td class="td2">
                      <asp:Label ID="LUserName" runat="server"></asp:Label>
                  </td>
                  <td class="td1">
                      聘任职称:</td>
                  <td class="td2">
                      <asp:Label ID="LUserJob" runat="server"></asp:Label>
                  </td>
                  <td class="td1">
                      职级信息:</td>
                  <td class="td2">
                      <asp:Label ID="LUserPost" runat="server"></asp:Label>
                  </td>
              </tr>
             
              <tr>
                  <td class="td3" colspan="6">
                      详细列表</td>
              </tr>
          </table>
                    </div>
                        <div>
                              <table style="margin-left:-1px">
                         <tr>
                            
                             <td class="auto-style4">类别</td>
                             <td class="auto-style4">级别</td>
                              <td class="td5"> 学术活动名称</td>
                               <td class="td5"> 主办单位</td>
                             <td class="td5">开始时间</td>
                             <td class="td5">结束时间</td>
                             <td class="td5">总科研分值</td>
                             <td class="td5">审核状态</td>
                          </tr>
                          <tr>
                             
                               <td class="td5"  align="left">
                                  <asp:Label ID="LDCategory" runat="server" ></asp:Label>
                              </td>
                                <td class="td5"  align="left">
                                  <asp:Label ID="LDLevel" runat="server" ></asp:Label>
                              </td>
                                <td class="td5"  align="left">
                                  <asp:Label ID="AssociationName" runat="server" ></asp:Label>
                              </td>
                              <td class="td5"  align="left">
                                  <asp:Label ID="CompanyName" runat="server" ></asp:Label>
                              </td>
                              <td class="td5"  align="left">
                                  <asp:Label ID="StartDate" runat="server" ></asp:Label>
                              </td>
                                <td class="td5"  align="left">
                                  <asp:Label ID="EndDate" runat="server" ></asp:Label>
                              </td>
                              <td class="td5">
                                  <asp:Label ID="ActivityValue" runat="server" ></asp:Label>
                              </td>                        
                               <td class="td5">
                                  <asp:Label ID="LTransferStatus" runat="server" ></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              
                              <td class="td4">
                                  合作者列表</td>
                              <td class="td4" colspan="6" style=" width:730px">
                                  <asp:Label ID="LPartner" runat="server" ></asp:Label>
                              </td>
                          </tr>
                      </table>
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
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
