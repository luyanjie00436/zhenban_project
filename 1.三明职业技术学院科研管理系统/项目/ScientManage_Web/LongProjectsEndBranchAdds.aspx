<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongProjectsEndBranchAdds.aspx.cs" Inherits="ScientManage_Web2.LongProjectsEndBranchAdds" %>

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
          
         
            
            <tr><td colspan="6">
                项目基本信息
                </td></tr>
             
                    <tr>
                        <td width="20%" align="right">
                            <strong>项目名称：</strong>
                        </td>
                        <td width="80%" align="left" colspan="5">
                            <asp:Label ID="txtLongProjectsName" runat="server" ></asp:Label>
                        </td>
                    </tr>
                           <tr>
                        <td width="20%" align="right">
                            <strong>  选择上传结题评审文件：</strong>
                        </td>
                        <td width="80%" align="left" colspan="2">
                            <asp:FileUpload ID="fupFileSend" CssClass="select1" runat="server" Width="203px" />
                            <asp:LinkButton runat="server" ID="LinkButton2" ForeColor="blue" Text="下载附件" OnClick="LinkButton2_Click"></asp:LinkButton>
                     
                      <asp:Label runat="server" ID="LFileUrl" Visible="false" ></asp:Label>
                                   
                      
                              </td>
                              
                               
                    </tr>
                    <tr class="tr10">
                        <td width="20%" height="80" align="right">
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
