<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobMangeAdd.aspx.cs" Inherits="Recruitment.JobMangeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     
    <title></title>
        <link href="css/master.css" rel="Stylesheet" type="text/css" />

    <style type="text/css">
        body {
            background:#fafafa;
        }
        .auto-style1 {
            width: 100%;
        }
        * {
            margin:0px;
            padding:0px;
        }
.bwbk2 {
    width:70%;
    height:30px;
    background:#fafafa;
    border:none;
}
    </style>
    <script src="common/Common.js" type="text/javascript"></script>
        <script type="text/javascript">
        function jiancha() {
            var jobcode1 = document.getElementById("txtJobCode");
         
         
            if (Empty(jobcode1)) {
                alter("请输入岗位代码2");
                return false;
            }
            else {
                alter("请输入岗位代码3");
                return false;
            }
            alter("请输入岗位代码4");
            return true;
        }
     
    </script>
</head>
<body>
    <form id="form1" runat="server">
     
    <div>
     <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2">新增岗位</div></div></div>
         <div class="page_main01">
           
                    <table class="uua" cellspacing="0" cellpadding="0">

                        <tr>
                            <td>岗位代码：</td>
                            <td>
                                <asp:TextBox ID="txtJobCode" CssClass="bwbk" runat="server"></asp:TextBox>
                            </td>
                            <td>岗位名称：</td>
                            <td>
                                <asp:TextBox ID="txtJobName" CssClass="bwbk" runat="server"></asp:TextBox>
                            </td>
                            <td>招收：</td>
                            <td>
                                <asp:TextBox ID="txtEnrollment" CssClass="bwbk2"  runat="server"></asp:TextBox>
                                人</td>
                            <td>年龄：</td>
                            <td>
                                <asp:TextBox ID="txtAge" CssClass="bwbk2" runat="server"></asp:TextBox>
                                周岁及以下</td>
                        </tr>
                        <tr>
                            <td>学历类别：</td>
                            <td>
                                <asp:DropDownList ID="DEducation" CssClass="bwbk" runat="server" class="input1">
                                
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="全日制普通院校">全日制普通院校</asp:ListItem>      
                                </asp:DropDownList>
                            </td>
                            <td>文化程度：</td>
                            <td>
                                 <asp:DropDownList ID="DCulture" CssClass="bwbk" runat="server" >
                               
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="初中">初中</asp:ListItem>    
                                   <asp:ListItem Value="中专及以上">中专及以上</asp:ListItem>
                                   <asp:ListItem Value="高中及以上">高中及以上</asp:ListItem> 
                                   <asp:ListItem Value="大专及以上">大专及以上</asp:ListItem>  
                                   <asp:ListItem Value="本科及以上">本科及以上</asp:ListItem>  
                                   <asp:ListItem Value="硕士研究生及以上">硕士研究生及以上</asp:ListItem>  
                                   <asp:ListItem Value="博士研究生及以上">博士研究生及以上</asp:ListItem>     
                                </asp:DropDownList>
                            </td>
                            <td>学位要求：</td>
                            <td>
                                <asp:DropDownList ID="DDegree" runat="server" CssClass="bwbk">
                                  
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="学士学位及以上">学士学位及以上</asp:ListItem>    
                                   <asp:ListItem Value="硕士学位及以上">硕士学位及以上</asp:ListItem>     
                                   <asp:ListItem Value="博士学位">博士学位</asp:ListItem>     
                                </asp:DropDownList>
                            </td>
                            <td>性别要求：</td>
                            <td>
                                <asp:DropDownList ID="DGender" runat="server" CssClass="bwbk">
                            
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="男">男</asp:ListItem>  
                                   <asp:ListItem Value="女">女</asp:ListItem>    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>民族要求：</td>
                            <td>
                                <asp:DropDownList ID="DNation" runat="server" CssClass="bwbk">
                                 
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="少数民族">少数民族</asp:ListItem>      
                                </asp:DropDownList>
                            </td>
                            <td>政治面貌：</td>
                            <td>
                                <asp:DropDownList ID="DPolitical" runat="server" CssClass="bwbk">
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="无党派">无党派</asp:ListItem>    
                                   <asp:ListItem Value="共青团员含中共党员">共青团员含中共党员</asp:ListItem>  
                                   <asp:ListItem Value="无党派含民主党派">无党派含民主党派</asp:ListItem>
                                   <asp:ListItem Value="中共党员">中共党员</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>是否应届：</td>
                            <td>
                                <asp:DropDownList ID="DShould" runat="server" CssClass="bwbk">
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                   <asp:ListItem Value="应届生">应届生</asp:ListItem>     
                                   <asp:ListItem Value="非应届生">非应届生</asp:ListItem> 
                                </asp:DropDownList>
                            </td>
                            <td>户籍要求：</td>
                            <td>
                                <asp:DropDownList ID="DRecruitment" runat="server" CssClass="bwbk">
                                  
                                   <asp:ListItem Value="本设区市">本设区市</asp:ListItem> 
                                   <asp:ListItem Value="省内">省内</asp:ListItem>   
                                   <asp:ListItem Value="不限">不限</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>职位类型：</td>
                            <td>
                                <asp:DropDownList ID="DPosition" runat="server" CssClass="bwbk">
                                  
                                   <asp:ListItem Value="非专门岗位">非专门岗位</asp:ListItem>
                                   <asp:ListItem Value="专门岗位">专门岗位</asp:ListItem>   
                                </asp:DropDownList>
                            </td>
                            <td>工作年数：</td>
                            <td>
                                <asp:DropDownList ID="DJobsYears" runat="server" CssClass="bwbk">
                                
                                   <asp:ListItem Value="不限">不限</asp:ListItem>    
                                </asp:DropDownList>
                            </td>
                            <td>笔试科目：</td>
                            <td>
                                <asp:DropDownList ID="DSubject" runat="server" CssClass="bwbk">
                                  
                                   <asp:ListItem Value="综合基础知识">综合基础知识</asp:ListItem>
                                   <asp:ListItem Value="免笔试">免笔试</asp:ListItem>   
                                   <asp:ListItem Value="专业考试2">专业考试2</asp:ListItem>   
                                </asp:DropDownList>
                            </td>
                            <td>报考费用：</td>
                            <td>
                                <asp:TextBox ID="txtApplyCost" CssClass="bwbk" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>专业要求：</td>
                            <td colspan="7">
                                <asp:TextBox Height="50" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtProfession" runat="server" CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>其他要求：</td>
                            <td colspan="7">
                                <asp:TextBox Height="50" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtOthers" runat="server" CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                            </td>
                        </tr>
                        <tr>
                            <td>备注：</td>
                            <td colspan="7">
                                <asp:TextBox Height="50" data-toggle="tooltip" data-placement="top"  style="overflow-y:auto" ID="txtRemarks" runat="server" CssClass="bwbk" Columns="1" MaxLength="400" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding:4px;" align="right">
                                &nbsp;<asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" CssClass="btn" OnClientClick="return jiancha()" />
                            </td>
                            <td colspan="4" style="padding:4px;" align="left">
                                <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" CssClass="btn" OnClientClick="return jiancha()" />
                                 <input id="Button3" runat="server"　class="btn"  onclick="javascript: window.history.go(-1);" type="button" value="返回"  /></td>
                        </tr>

                        </table>
                 
             </div>
    </div>
    </form>
</body>
</html>
