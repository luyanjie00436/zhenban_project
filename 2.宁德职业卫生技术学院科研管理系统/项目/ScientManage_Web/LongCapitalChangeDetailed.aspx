<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongCapitalChangeDetailed.aspx.cs" Inherits="ningdeScientManage_Web.LongCapitalChangeDetailed" %>

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
           width:25px;
            height:24px;
            line-height:24px;
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-top: 1px solid #000000;
            border-bottom:1px solid #000000;
            }
      
        .auto-style4 {
            width: 90px;
        }
      
        .auto-style5 {
            width: 211px;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目经费预算审批表</div></div></div><br />

        <div class="page_main01">
                    <div style="width:1024px;height:297mm;margin:0 auto">
                        <div>
                          <table style="margin-left:-1px">
                               <tr>
                                   <td align="right" class="auto-style4">项目编号：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsId"></asp:Label> </td>
                                   <td align="right" class="auto-style5">项目名称：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsName"></asp:Label></td>
                                   
                               </tr>
                         <tr>
                              <td  align="right" class="auto-style4" >
                                  项目来源：</td>
                            
                         <td class="td5">
                                  <asp:Label ID="LProjectsFrom" runat="server" ></asp:Label>
                              </td>
                                <td align="right" class="auto-style5"  >
                                  中标金额：</td>
                                
                                 <td class="td5" >
                                  <asp:Label ID="LBidMoney" runat="server" ></asp:Label>
                              </td>
                           
                          
                          </tr>
                              <tr>
                                   <td align="right" class="auto-style4">配套金额：</td>
                                   <td><asp:Label runat="server" ID="LSupportMoney"></asp:Label> </td>
                                   <td align="right" class="auto-style5">其他资助金额：</td>
                                   <td><asp:Label runat="server" ID="LOtherMoney"></asp:Label></td>
                                   
                               </tr>
                              <tr>
                                   <td align="right" class="auto-style4">经费下达单位：</td>
                                   <td><asp:Label runat="server" ID="LSuedCompany"></asp:Label> </td>
                                   <td align="right" class="auto-style5">经费使用期限：</td>
                                   <td><asp:Label runat="server" ID="LServicelife"></asp:Label></td>
                                   
                               </tr>
                              <tr>
                                   <td align="right" class="auto-style4">总经费：</td>
                                   <td><asp:Label runat="server" ID="LSumMoney"></asp:Label> </td>
                                   
                              <td  align="right" class="auto-style5">
                                  预算附件：</td>
                               <td class="td5">
                                  <asp:Label ID="LFileUrl" runat="server" Visible="false" ></asp:Label>
                                   <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" Id="LinkButton1" OnClick="LinkButton1_Click"></asp:LinkButton>
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
        </div>
    </div>
    </form>
</body>
</html>