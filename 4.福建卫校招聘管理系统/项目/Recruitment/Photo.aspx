<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="Recruitment.Photo" %>

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
{
    line-height: 1.5;
}
        .ee {
            width:60%;
            border:1px solid #0094ff;
            margin:0px auto;
            margin-top:30px;
            height:300px;
            padding:50px;

        }
        .auto-style2 {
            width: 94px;
            height: 132px;
        }
    </style>
       <script>
function fileSizeLimit() {

        var uploadSize = document.getElementById("FileUpload1").files[0].size;
        var filename = document.getElementById("FileUpload1").value;
        var prefix = filename.substr(filename.lastIndexOf('.') + 1).toLowerCase();
        if (prefix == "jpg" || prefix == "png" || prefix == "gif") {
            if (uploadSize > 1024*100) {
                alert("文件大小不能超过100k");
                document.getElementById("FileUpload1").value = "";
              
            }
        } else {
            alert("文件格式限制为：jpg,png,gif");
            document.getElementById("FileUpload1").value = "";
          
        }
           }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" cellspacing="0" class="ee">
            <tr>
                <td>
                    <div style="MARGIN-BOTTOM: 20px; LINE-HEIGHT: 24px" class="">
                        <p>
                            <span style="FONT-WEIGHT: bold">照片的要求</span><br />
                            <font face="Arial" style="font-size:15px; text-align:center; color:red; line-height:1;" >证件照，清晰，明亮，无背景，头像占画面70％左右；<br />
                            必须是图片格式(文件扩展名为.jpg/.gif/.bmp/.png)；<br />
                            照片大小必须在100K以下(查看照片的属性)；<br />
                            照片必须是IE可以识别的格式(您可以在本机上用IE浏览器先打开看一下是否可以显示)；<br />
                            照片要求统一底色，蓝、红、白底色均可；<br />
                            照片上传成功后点击“请确认并提交”，即可开始缴费报考。</font></p>
                        <p>
                            <font face="Arial" style="font-size:15px; text-align:center; color:red; line-height:1;" >照片若显示不合格请对照上述标准重新上传。<br />
                            如照片不合格，其主要原因有：面部模糊，头像不够大。</font></p>
                    </div>
                </td>
                <td>
                    <div class="photo" style="width:75px; overflow:hidden;">
                        <img id="Image2" runat="server" src="imgs.aspx" style="padding:0; margin:0;" class="auto-style2" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%--<asp:FileUpload ID="fupFileSend" runat="server" CssClass="input6" data-placement="top" data-toggle="tooltip" ToolTip="点击选择要上传的文件" Width="292px" />--%>
                    <input id="Button10" runat="server" type="button" value="选择文件" data-toggle="tooltip" data-placement="top"  class="btn" Width="75px"  onclick="FileUpload1.click()" />
                    <asp:Button ID="Button1" runat="server" Text="上传照片" OnClick="Button1_Click" />
                     <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页"/>
                    <asp:FileUpload ID="FileUpload1" CssClass="fileup" Width="75px"  runat="server" onchange="fileSizeLimit()" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
