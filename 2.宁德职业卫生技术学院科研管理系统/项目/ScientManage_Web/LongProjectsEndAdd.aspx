<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsEndAdd.aspx.cs" Inherits="ningdeScientManage_Web.LongProjectsEndAdd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目结题</div></div></div><br />
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
            <tr><td colspan="6">
                项目基本信息
                </td></tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目编号：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:Label ID="LNewLongProjectsId" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:Label ID="LLongProjectsName" runat="server" ></asp:Label>
                        </td>
                    </tr>
                     
                     <tr>
                          <td width="20%" align="right">
                            <strong>项目级别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                         <asp:Label ID="LLevel" runat="server" ></asp:Label> 

                        </td>
                        <td width="20%" align="right">
                            <strong>项目类别：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                             <asp:Label ID="LSubject" runat="server" ></asp:Label>
                         </td>
                    </tr>
                   
                     <tr>
                        <td width="20%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LFrom" runat="server" ></asp:Label>   </td>
                        <td width="20%" align="right">
                            <strong>项目协作单位：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:Label ID="LCompany"  runat="server"></asp:Label>
                        </td>
                    </tr>
            <tr>
                               <td align="right">

                                 <strong>研究内容摘要：</strong> 

                               </td>
                               <td colspan="5"  align="left">
                                   <asp:Label ID="LProjectsContent" runat="server" ></asp:Label>
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
                        <td width="20%" align="right">
                            <strong>  上传结题文件：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" CssClass="select1" runat="server" Width="203px" />
                          
                                   
                      
                              </td>
                               <td>
                                    &nbsp;</td>
                               <td colspan="2">
                                     <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                               </td>
                               
                    </tr>
                    <tr class="tr10">
                       
                        <td  height="80" align="center" valign="middle" colspan="6">
                            &nbsp;<asp:Button
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
