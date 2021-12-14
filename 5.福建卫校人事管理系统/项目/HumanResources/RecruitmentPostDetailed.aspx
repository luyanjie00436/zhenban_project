<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecruitmentPostDetailed.aspx.cs" Inherits="HumanManage_Web.RecruitmentPostDetailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    </head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
<div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >岗位招聘申请表</div></div></div>
        <div class="page_main01">
            
  <table class="bgcolor" border="0" cellspacing="0" cellpadding="0">
            <tr class="tr14">
                <td style="padding: 0 0 9px 0; margin: 0;float:right;  margin-right:155px;">
                    <input onclick="javascript: window.history.go(-1);" type="button" value="返回上一页" 

class="btn1" />
                </td>
            </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%" align="right">
                                <strong>申请人工号：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="txtUserCardId" data-toggle="tooltip" data-placement="top"  ToolTip="请输入申请人工号" runat="server" Enabled="False" CssClass="select1" ReadOnly="True"></asp:TextBox>
                            </td>
                      
                            </tr>
                        <tr>
                      
                            
                            </tr>  
                        <tr>                            
                            <td width="12%" align="right">
                                <strong>岗位名称：</strong>
                                 </td>
                               <td align="left" width="12%">
                                   <asp:TextBox ID="txtPostName" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="请输入岗位名称" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                               </tr>  
                        <tr>
                            <td align="right" width="12%">
                                <strong>专业要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtProfessional" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="请输入专业要求 例如（软件技术）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>学历要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtEducation" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="请输入学历要求 例如（本科）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>其他要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtOther" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="填写表格标题未涉及的要求 例如（有ps技术的优先）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>招聘人数：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtNumber" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="请输入招聘人数 例如（30）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>

                           <tr>
                            <td align="right" width="12%">
                                <strong>月薪：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtMoney" Enabled="False" data-toggle="tooltip" data-placement="top"  ToolTip="请输入月薪 例如（3000）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>