<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsInformationUpd.aspx.cs" Inherits="ScientManage_Web.LongProjectsInformationUpd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >项目信息修改</div></div></div><br />
    <div class="page_main01" >
         <div style="display: none">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
        <table   cellspacing="0" cellpadding="0"  style="width:800px;margin:0 auto;border:0px;">
                
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="3">
                            <asp:TextBox ID="txtProjectsName" CssClass="select1" runat="server" Height="27px" Width="384px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" >
                            <strong>新项目编号：</strong>
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtProjectsNewId" CssClass="select1" runat="server" Height="27px" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                          <td width="20%" align="right">
                            <strong>项目级别：</strong>
                        </td>
                        <td width="30%" align="left">
                            <asp:DropDownList ID="DLLevel" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>     

                        </td>
                        <td width="20%" align="right">
                            <strong>项目类别：</strong>
                        </td>
                        <td width="30%" align="left">
                             <asp:DropDownList ID="DLSubject" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>  
                         </td>
                    </tr>
                   
                     <tr>
                        <td width="20%" align="right">
                            <strong>项目来源：</strong>
                        </td>
                        <td width="30%" align="left">
                             <asp:DropDownList ID="DLFrom" height="30px" CssClass="select1" Width="137px" runat="server">
                          </asp:DropDownList>    </td>
                        <td width="20%" align="right">
                            <strong>项目协作单位：</strong>
                        </td>
                        <td width="30%" align="left">
                            <asp:TextBox ID="txtCompany"  Height="27px" CssClass="select1" Width="137px"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                           <tr>
                               <td align="right">
                                    <strong>  研究内容摘要(限300字内)：</strong>
                               </td>
                               <td colspan="3"  align="left">
                                   <textarea  id="txtProjectsContent"   runat="server" class="select1" style="height:120px;width:90%;"  maxlength="300"  ></textarea>
                               </td>
                                </tr>
              <tr>
                          <td width="20%" align="right">
                            <strong>申报状态：</strong>
                        </td>
                        <td width="30%" align="left">
                            <asp:DropDownList ID="DlDeclareStatus" height="30px" CssClass="select1" Width="137px" runat="server">
                                 <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                 <asp:ListItem Value="1">未审批</asp:ListItem>
                                 <asp:ListItem Value="2">审批中</asp:ListItem>
                                 <asp:ListItem Value="3">审批通过</asp:ListItem>
                                 <asp:ListItem Value="4">审批未通过</asp:ListItem>
                                 
                          </asp:DropDownList> 

                        </td>
                        <td width="20%" align="right">
                            <strong>立项状态：</strong>
                        </td>
                        <td width="30%" align="left">
                             <asp:DropDownList ID="DlStandStatus" height="30px" CssClass="select1" Width="137px" runat="server">
                           <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                 <asp:ListItem Value="1">未立项</asp:ListItem>
                                 <asp:ListItem Value="1">未审批</asp:ListItem>
                                 <asp:ListItem Value="2">审批中</asp:ListItem>
                                 <asp:ListItem Value="3">审批通过</asp:ListItem>
                                 <asp:ListItem Value="4">审批未通过</asp:ListItem>
                             </asp:DropDownList>  
                         </td>
                    </tr>
              <tr>
                          <td width="20%" align="right">
                            <strong>中检状态：</strong>
                        </td>
                        <td width="30%" align="left">
                            <asp:DropDownList ID="DlInspectStatus" height="30px" CssClass="select1" Width="137px" runat="server">
                           <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                 <asp:ListItem Value="1">未中检</asp:ListItem>
                                 <asp:ListItem Value="1">未审批</asp:ListItem>
                                 <asp:ListItem Value="2">审批中</asp:ListItem>
                                 <asp:ListItem Value="3">审批通过</asp:ListItem>
                                 <asp:ListItem Value="4">审批未通过</asp:ListItem>
                            
                            </asp:DropDownList>     

                        </td>
                        <td width="20%" align="right">
                            <strong>结题状态：</strong>
                        </td>
                        <td width="30%" align="left">
                             <asp:DropDownList ID="DlEndStatus" height="30px" CssClass="select1" Width="137px" runat="server">
                          <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                 <asp:ListItem Value="1">未结题</asp:ListItem>
                                 <asp:ListItem Value="1">未审批</asp:ListItem>
                                 <asp:ListItem Value="2">审批中</asp:ListItem>
                                 <asp:ListItem Value="3">审批通过</asp:ListItem>
                                 <asp:ListItem Value="4">审批未通过</asp:ListItem>
                                  </asp:DropDownList>  
                         </td>
                    </tr>
                    <tr class="tr10" >
                       
                        <td  height="80" style="text-align:center;" colspan="4">
                            <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" CssClass="btn" />
                            
                        </td>
                    </tr>
                </table>
                     </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    <div class="rightMain">
        <br />
    </div>
    </form>
</body>
</html>
