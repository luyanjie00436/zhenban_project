<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortProjectsEndAdd.aspx.cs" Inherits="ScientManage_Web2.ShortProjectsEndAdd" %>

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
          width:20%;
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
    <div>
               <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目结题</div></div></div><br />

        <div class="page_main01">
                    <div style="width:1024px;height:297mm;margin:0 auto">
                    <div>
                  <table  class="bgcolor" >
             <tr>
                <td class="td3" colspan="6">
                    申报人基本信息
                </td>
            </tr>
              <tr>
                <td align="right">工号：</td>
                <td align="left">
                    <asp:Label ID="LUserCardId" runat="server" ></asp:Label>
                </td>
                 <td align="right">姓名：</td>
                <td align="left">
                     <asp:Label ID="LUserName" runat="server"></asp:Label>
                    
                </td>
                 <td align="right">所在系（部）：</td>
                <td align="left">
                      <asp:Label ID="LDepartmentName" runat="server" ></asp:Label>
                  
                </td>
            </tr>
               <tr>
                <td align="right">职称：</td>
                <td align="left">
                     <asp:Label ID="LUserJob" runat="server" ></asp:Label>
                </td>
                 <td align="right">职级：</td>
                <td align="left">
                     <asp:Label ID="LUserPost" runat="server" ></asp:Label>
                </td>
                 <td align="right">出生年月：</td>
                <td align="left">
                     <asp:Label ID="LBirthday" runat="server" ></asp:Label>
                </td>
            </tr>

              <tr>
                  <td class="td3" colspan="6">
                      详细列表</td>
              </tr>
          </table>
                    </div>
                        <div>
                          <table class="bgcolor">
                               <tr>
                                   <td align="right">合同编号：</td>
                                   <td><asp:Label runat="server" ID="LShortProjectsId" Visible="false"></asp:Label> 
                                       <asp:Label runat="server" ID="LContractId"></asp:Label>
                                   </td>
                                   <td align="right" class="td5">合同名称：</td>
                                   <td><asp:Label runat="server" ID="LContractName"></asp:Label></td>
                                   
                               </tr>
                               <tr>
                                   <td align="right">合作单位：</td>
                                   <td><asp:Label runat="server" ID="LCompany"></asp:Label> </td>
                                   <td align="right">合同金额：</td>
                                   <td> <asp:Label runat="server" ID="LContractMoney"></asp:Label></td>
                                  
                               </tr>
                          <tr>
                              
                                <td width="20%" align="right">
                          <asp:Label ID="LLongProjectsId" runat="server" Visible="false"></asp:Label>
                              <asp:Label ID="Lxiugai" runat="server" Visible="False" Text="是否修改附件：" Font-Bold="True" ></asp:Label>
                         </td>
                        <td width="30%" align="left" >
                            <asp:RadioButtonList ID="RBL1" Width="100px" runat="server"  RepeatDirection="Horizontal">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                             <td width="20%" align="right">
                            <strong>模板：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                              <asp:DropDownList ID="DlCategory" CssClass="select1" runat="server">
                             <asp:ListItem Value="0">请选择</asp:ListItem>
                             </asp:DropDownList>    
                            &nbsp;&nbsp;&nbsp;        
                            <asp:LinkButton runat="server" ForeColor="Blue" ID="LinkButton1" Text="下载模板" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </td>

                          </tr>
                           <tr>
                        <td width="20%" align="right">
                            <strong>  上传结题文件：</strong>
                        </td>
                        <td width="30%" align="left" >
                            <asp:FileUpload ID="fupFileSend" CssClass="select1" runat="server" Width="203px" />
                          
                                   
                      
                              </td>
                               <td>
                                    &nbsp;</td>
                               <td >
                                     <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                               </td>
                               
                    </tr>
                    <tr class="tr10">
                       
                        <td  height="80" colspan="4" align="center" valign="middle" >
                            &nbsp;<asp:Button
                                ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" CssClass="btn" />
                            
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