<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Photo_dyxl.aspx.cs" Inherits="HumanManage_Web.Photo_dyxl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .fileup {
              visibility: hidden;
              width:75px;
             }
        .ee {
            width:60%;
            border:1px solid #a9a9a9;
            margin:0px auto;
            margin-top:10px;
            height:300px;
            padding:10px;

        }
        .auto-style2 {
            width: 595px;
            height: 213px;
        }
        .auto-style3 {
            width: 600px;
            overflow: hidden;
            margin-top:-190px;
        }
        .auto-style5 {
            height: 210px;
        }
        .auto-style6 {
            height: 37px;
        }
        .auto-style7 {
            width: 600px;
        }
    </style>
     


   
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
        <table cellpadding="0" cellspacing="0" class="ee">
            <tr>
                <td class="auto-style5">
                    <div style=" margin-top:-110px; LINE-HEIGHT: 24px" class="auto-style7">
                        <p class="auto-style7">
                            <span style="FONT-WEIGHT: bold">照片的要求</span><br />
                            <font face="Arial" style="font-size:15px; text-align:center; color:red; line-height:1;" >证书照，清晰，明亮；<br />
                            必须是图片格式(文件扩展名为.jpg/.gif/.bmp/.png)；<br />
                            一寸个人照大小在100k以下，证照大小必须在1M以下(查看照片的属性)。
                          </font></p>
                    </div>
                </td>
            
            </tr>
            <tr>
                <td class="auto-style5">
                    <div id="div3" runat="server" class="auto-style3">
                        <%--style="padding:0; margin:0;"--%>
                        <img alt="" id="Image2" runat="server" src="imga_dyxl.aspx" style="diplay:none" class="auto-style2" onclick="F_Open_dialog()"/>
                    </div>
                </td>
              
            </tr>
            <tr>
                <td colspan="2"  ><div style="margin-top:-70px;" class="auto-style6" >
                  
                     <asp:FileUpload ID="FileUpload1" runat="server" />  
                <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />  
                     <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" />
                     
                 
                </div>
                    </td>
            </tr>
        </table>
    
    </div>



    </form>
</body>
</html>
