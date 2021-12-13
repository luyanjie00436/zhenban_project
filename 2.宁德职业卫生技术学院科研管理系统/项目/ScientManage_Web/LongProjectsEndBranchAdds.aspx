<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsEndBranchAdds.aspx.cs" Inherits="ningdeScientManage_Web.LongProjectsEndBranchAdds" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style4 {
            width: 24%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div class="swn">
    <strong>&nbsp;&nbsp;&nbsp;项目结题</strong> 
</div><br />    <div class="page_main01" >
        <table   cellspacing="0" cellpadding="0"  style="width:800px;margin:0 auto;border:0px;">
          
         
             
                    <tr>
                        <td align="right" class="auto-style4">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:Label ID="txtLongProjectsName" runat="server" ></asp:Label>
                        </td>
                    </tr>
                           <tr>
                        <td align="right" class="auto-style4">
                            <strong>  选择上传结题评审文件：</strong>
                        </td>
                        <td width="80%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" CssClass="select1" runat="server" Width="203px" />
                            <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                                   
                      
                              </td>
                              
                               
                    </tr>
                    <tr class="tr10">
                        <td height="80" align="right" class="auto-style4">
                            &nbsp;  
                        </td>
                        <td  height="80" align="left" valign="middle" colspan="5">
                         <asp:Button   ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" CssClass="btn1" />
                            
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
