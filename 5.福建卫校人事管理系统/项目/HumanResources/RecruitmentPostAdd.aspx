<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecruitmentPostAdd.aspx.cs" Inherits="HumanManage_Web.RecruitmentPostAdd" %>

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
 <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >岗位招聘申请</div></div></div>
        <div class="page_main01">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%" align="right">
                                <strong>申请人工号：</strong>
                            </td>
                            <td width="12%" align="left">
                                <asp:Label ID="txtUserCardId" runat="server" data-toggle="tooltip"  data-placement="top"  ToolTip="请填写申请人工号"  Enabled="False" CssClass="select1" ReadOnly="True"></asp:Label>
                            </td>
                      
                            </tr>
                        <tr>
                   
                            
                            </tr>  
                        <tr>                            
                            <td width="12%" align="right">
                                <strong>岗位名称：</strong>
                                 </td>
                               <td align="left" width="12%">
                                   <asp:TextBox ID="txtPostName" data-toggle="tooltip" data-placement="top"  ToolTip="填写岗位名称 例如（软件工程师）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                               </tr>  
                        <tr>
                            <td align="right" width="12%">
                                <strong>专业要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtProfessional" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写专业要求 例如（软件、硬件）" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>学历要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtEducation" data-toggle="tooltip" data-placement="top"  ToolTip="请填写学历要求 例如（本科）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>其他要求：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtOther" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="填写表格标题未涉及的要求 例如（有ps技术的优先）" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="12%">
                                <strong>招聘人数：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtNumber" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="请填写招聘人数 例如（10人）" CssClass="select1"></asp:TextBox>
                            </td>
                        </tr>

                           <tr>
                            <td align="right" width="12%">
                                <strong>月薪：</strong> </td>
                            <td align="left" width="12%">
                                <asp:TextBox ID="txtMoney" data-toggle="tooltip" data-placement="top"  ToolTip="请填写月薪 例如（3000元）" runat="server" CssClass="select1" ></asp:TextBox>
                            </td>
                        </tr>
                        
                       
                        <tr class="tr10">
                       
                            <td  align="right">
                                <asp:Button ID="Button1" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行添加" OnClick="Button1_Click" Text="添 加" CssClass="btn" />
                            </td>
                               <td>
                                <asp:Button ID="Button2" runat="server" data-toggle="tooltip" data-placement="top"  ToolTip="点击进行保存" OnClick="Button2_Click" Text="保 存" CssClass="btn" />
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


