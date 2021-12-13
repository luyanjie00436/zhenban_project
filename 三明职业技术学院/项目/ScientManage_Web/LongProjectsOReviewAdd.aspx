<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsOReviewAdd.aspx.cs" Inherits="ScientManage_Web2.LongProjectsOReviewAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />

     <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >其他项目添加</div></div></div>
        
        <br />
         <div>        <asp:Button ID="Button3" runat="server" Text="返回上一页" OnClick="Button3_Click" class="btn11" Height="25px" Width="89px" />
</div>
    <div class="page_main01" >
        <table   cellspacing="0" cellpadding="0"  style="width:800px;margin:0 auto;border:0px;">
            <tr><td colspan="6">其他项目基本信息</td></tr>
            <tr>
                <td width="20%" align="right">
                    <strong>  选择上传文件：</strong>
                </td>
                <td width="30%" align="left" colspan="2">
                    <asp:FileUpload ID="ReviewFile" runat="server" CssClass="select1" Width="203px" />
                </td>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                    <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                </td>
            </tr>
             <tr>
               <td width="20%" align="right">
                            <strong>开始时间：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                           <input ID="txtStarttime" runat="server"  onfocus="WdatePicker()" class="input1"></input>
                        </td>
                        <td width="20%" align="right">
                            <strong>结束时间：</strong>
                        </td>
                        <td width="30%" align="left" colspan="2">
                           <input ID="txtEndtime" runat="server"  onfocus="WdatePicker()" class="input1"></input>
                         </td>
                    </tr>
                     <tr>
                        <td width="20%" align="right">
                            <strong>备注：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:TextBox ID="txtRemarks" CssClass="select1" runat="server" Height="27px" Width="384px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td width="20%" align="right">
                          <asp:Label ID="LOReviewId" runat="server" Visible="false"></asp:Label>
                              <asp:Label ID="Lxiugai" runat="server" Visible="False" Text="是否修改附件：" Font-Bold="True" ></asp:Label>
                         </td>
                        <td width="30%" align="left" colspan="2">
                            <asp:RadioButtonList ID="RBL1" RepeatLayout="Flow"  runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="是">是</asp:ListItem>
                                <asp:ListItem Value="否">否</asp:ListItem>
                            </asp:RadioButtonList>
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
