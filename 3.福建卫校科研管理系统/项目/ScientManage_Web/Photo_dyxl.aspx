<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Photo_dyxl.aspx.cs" Inherits="ScientManage_Web.Photo_dyxl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .fileup {
            visibility: hidden;
            width: 75px;
        }

        {
            line-height: 1.5;
        }

        .ee {
            width: 60%;
            border: 1px solid #a9a9a9;
            margin: 0px auto;
            margin-top: 10px;
            height: 300px;
            padding: 10px;
        }

        .auto-style2 {
            width: 595px;
            height: 213px;
        }

        .auto-style3 {
            width: 600px;
            overflow: hidden;
            margin-top: -190px;
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
    <script>
function fileSizeLimit() {

        var uploadSize = document.getElementById("FileUpload1").files[0].size;
        var filename = document.getElementById("FileUpload1").value;

        var prefix = filename.substr(filename.lastIndexOf('.') + 1).toLowerCase();
        if (prefix == "jpg" || prefix == "png" || prefix == "gif") {
            if (uploadSize > 1024*1024) {
                alert("文件大小不能超过1M");
                document.getElementById("FileUpload1").value = "";
                return;
              
            }
        } else {
            alert("文件格式限制为：jpg,png,gif");
            document.getElementById("FileUpload1").value = "";
            return;
          
        }
        //document.getElementById("Image2").src = filename;       
           }
    </script>
    <%--<script type="text/javascript">
        function F_Open_dialog() 
       { 
            document.getElementById("Button10").click(); 
       } 
    </script>--%>
    <script>
        $(document).ready(function () {
            var _h = div_main.offsetHeight + 30;              //div_main 为子页面中form中的div的id 
            var _ifm = parent.document.getElementById("iframepage"); //ifm 为default 页面中iframe 控件id
            $(_ifm).attr("height", _h);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_main">
            <table cellpadding="0" cellspacing="0" class="ee">
                <tr>
                    <td class="auto-style5">
                        <div style="margin-top: -110px; line-height: 24px" class="auto-style7">
                            <p class="auto-style7">
                                <span style="font-weight: bold">照片的要求</span><br />
                                <font face="Arial" style="font-size: 15px; text-align: center; color: red; line-height: 1;">证书照，清晰，明亮；<br />
                            必须是图片格式(文件扩展名为.jpg/.gif/.bmp/.png)；<br />
                            一寸个人照大小在100k以下，证照大小必须在1M以下(查看照片的属性)。
                          </font>
                            </p>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <div class="auto-style3">
                            <%--style="padding:0; margin:0;"--%>
                            <img id="Image2" runat="server" src="imga_dyxl.aspx" style="diplay: none" class="auto-style2" onclick="F_Open_dialog()" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="margin-top: -70px;" class="auto-style6">
                            <%--<asp:FileUpload ID="fupFileSend" runat="server" CssClass="input6" data-placement="top" data-toggle="tooltip" ToolTip="点击选择要上传的文件" Width="292px" />--%>
                            <input id="Button10" name="doc" runat="server" type="button" value="选择文件" data-toggle="tooltip" data-placement="top" class="btn" width="75px" onclick="FileUpload1.click();" />
                            <asp:Button ID="Button1" runat="server" Text="上传照片" OnClick="Button1_Click" />
                            <asp:FileUpload ID="FileUpload1" CssClass="fileup" Width="75px" runat="server" onchange="fileSizeLimit()" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
