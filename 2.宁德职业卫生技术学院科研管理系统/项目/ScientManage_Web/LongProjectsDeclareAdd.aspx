<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsDeclareAdd.aspx.cs" Inherits="ningdeScientManage_Web.LongProjectsDeclareAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目申报</div></div></div><br />
    <div class="page_main01" >
        <table   cellspacing="0" cellpadding="0"  style="width:800px;margin:0 auto;border:0px;">
            <tr>
                <td colspan="6">
                    申报人基本信息
                </td>
            </tr>
            <tr>
                <td align="right">工号：</td>
                <td align="left">
                    <asp:Label ID="txtUserCardId" runat="server" ></asp:Label>
                </td>
                 <td align="right">姓名：</td>
                <td align="left">
                     <asp:Label ID="txtUserName" runat="server"></asp:Label>
                    
                </td>
                 <td align="right">所在系（部）：</td>
                <td align="left">
                      <asp:Label ID="txtDepartmentName" runat="server" ></asp:Label>
                  
                </td>
            </tr>
               <tr>
                <td align="right">职称：</td>
                <td align="left">
                     <asp:Label ID="txtUserJob" runat="server" ></asp:Label>
                </td>
                 <td align="right">职级：</td>
                <td align="left">
                     <asp:Label ID="txtUserPost" runat="server" ></asp:Label>
                </td>
                 <td align="right">出生年月：</td>
                <td align="left">
                     <asp:Label ID="txtBirthday" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr><td colspan="6">
                项目基本信息
                </td></tr>
                 <tr>
                           
                              <td width="12%" align="right">
                                <strong>项目申报起止时间:</strong>
                                
                              </td>
                            <td width="12%" align="left">
                                <asp:label  runat="server" ID="LStartDate"></asp:label>
                                至
                                 <asp:label  runat="server" ID="LEndDate"></asp:label>
                            </td>
                              </tr> 
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:TextBox ID="txtLongProjectsName" CssClass="select1" runat="server" Height="27px" Width="384px"></asp:TextBox>
                        </td>
                    </tr>
                     
                     <tr>
                          <td width="20%" align="right">
                            <strong>项目级别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:DropDownList ID="DLLevel" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>     

                        </td>
                        <td width="20%" align="right">
                            <strong>项目类别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                             <asp:DropDownList ID="DLSubject" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>  
                         </td>
                    </tr>
                   
                     <tr>
                        <td width="20%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                             <asp:DropDownList ID="DLFrom" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>    </td>
                        <td width="20%" align="right">
                            <strong>项目协作单位：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:TextBox ID="txtCompany"  Height="27px" CssClass="select1" Width="137px"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        
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
                         <td width="20%" align="right">
                          <asp:Label ID="LLongProjectsId" runat="server" Visible="false"></asp:Label>
                              <asp:Label ID="Lxiugai" runat="server" Visible="False" Text="是否修改附件：" Font-Bold="True" ></asp:Label>
                         </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:RadioButtonList ID="RBL1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                    </tr>
            
                           <tr>
                               <td align="right">

                                    <strong>  研究内容摘要(限300字内)：</strong>

                               </td>
                               <td colspan="5"  align="left">
                                   <textarea  id="txtProjectsContent"   runat="server" class="select1" style="height:120px;width:90%;"  maxlength="300"  ></textarea>
                               </td>
                                </tr>
            
                           <tr>
                        <td width="20%" align="right">
                            <strong>  选择上传文件：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" runat="server" CssClass="select1" Width="203px" />
                          
                                   
                      
                              </td>
                               <td>
                                    &nbsp;</td>
                               <td colspan="2">
                                     <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                               </td>
                               
                    </tr>
                    <tr class="tr10" >
                       
                        <td  height="80" style="text-align:center;" colspan="6">
                            <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" />&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" CssClass="btn" />
                            
                        </td>
                    </tr>
                </table>
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
