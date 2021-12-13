<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsStandBranchDetailed.aspx.cs" Inherits="ningdeScientManage_Web.LongProjectsStandBranchDetailed" %>

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
            text-align:right;
            border-bottom:1px solid #000000;
           
            }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目立项评审表</div></div></div><br />


        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td class="btn_left1">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn11" />
                </td>
            </tr>
        </table>
  
                    <div style="width:1024px;height:297mm;margin:0 auto">
                    <div>
                  <table  >
           

              <tr>
                  <td class="td3" colspan="8">
                      详细列表</td>
              </tr>
          </table>
                    </div>
                        <div>
                           <table style="margin-left:-1px">
                               <tr>
                                   <td align="right">项目编号：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsId"></asp:Label> </td>
                                   <td align="right">项目名称：</td>
                                   <td><asp:Label runat="server" ID="LLongProjectsName"></asp:Label></td>
                                   
                               </tr>
                               <tr>
                                   <td align="right">项目类别：</td>
                                   <td><asp:Label runat="server" ID="LProjectsSubject"></asp:Label> </td>
                                   <td align="right">项目级别：</td>
                                   <td> <asp:Label runat="server" ID="LProjectsLevel"></asp:Label></td>
                                  
                               </tr>
                         <tr>
                              <td  align="right">
                                  项目来源：</td>
                            
                         <td class="td5" style="text-align:left" >
                                  <asp:Label ID="LProjectsFrom" runat="server" ></asp:Label>
                              </td>
                                <td class="td5"  style="text-align:right"  >
                                  协作单位：</td>
                                
                                 <td class="td5"  style="text-align:left">
                                  <asp:Label ID="LCompany" runat="server" ></asp:Label>
                              </td>
                           
                          
                          </tr>
                               <tr>
                               <td align="right">

                                  研究内容摘要：

                               </td>
                               <td colspan="3"  align="left">
                                   <asp:Label ID="LProjectsContent" runat="server" ></asp:Label>
                                      </td>
                                </tr>

                           <tr>
                              
                              <td class="td5" align="right">
                                  评审附件：</td>
                               <td class="td5" style="text-align:left" >
                                  <asp:Label ID="LFileUrl" runat="server" Visible="false" ></asp:Label>
                                   <asp:LinkButton ForeColor="blue" Text="附件下载" runat="server" Id="LinkButton1" OnClick="LinkButton1_Click"></asp:LinkButton>
                              </td>
                               <td width="20%" align="right">
                            <strong>模板：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                              <asp:DropDownList ID="DlCategory" runat="server">
                             <asp:ListItem Value="0">请选择</asp:ListItem>
                             </asp:DropDownList>    
                            &nbsp;&nbsp;&nbsp;        
                            <asp:LinkButton runat="server" ForeColor="Blue" ID="LinkButton2" Text="下载模板" OnClick="LinkButton2_Click"></asp:LinkButton>
                        </td>
                          </tr>
                               <tr>
                        <td width="20%" align="right">
                            <strong>  选择上传文件：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" runat="server" Width="203px" />
                              </td>
                              
                               <td colspan="2">
                                     <asp:LinkButton runat="server" ID="LinkButton3" ForeColor="blue" Text="下载附件" OnClick="LinkButton3_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl1" Visible="false" ></asp:Label>
                               </td>
                               
                    </tr>
                        
                        
                      </table>
                      <table width="80%" border="0" cellspacing="0" cellpadding="0">
                <tr>

                              <td width="20%" align="right"> 
                                    <strong>评审意见：  </strong></td>
                              <td colspan="3"  align="left">
                                  <asp:TextBox runat="server" ID="txtOpinion" CssClass="select1" Height="28px" Width="300px"></asp:TextBox>
                              </td>
                         <td width="20%" align="right"> 
                                   <strong>分值：</strong></td>
                    <td align="left" >
                        
                        
                  
                        <asp:TextBox ID="txtBranch" runat="server" Columns="1" CssClass="select1"  Rows="5" ></asp:TextBox>
                  
                    </td>
            
                </tr>
                <tr>
                  
                  <td colspan="6" align="center">
                              <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" CssClass="btn" />
                    </td>
                    
                </tr>
            </table>
           
                            </div>
                        </div>
        </div>
    </div>
    </form>
</body>
</html>