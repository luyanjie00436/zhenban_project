<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamInfoManage.aspx.cs" Inherits="Recruitment.ExamInfoManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        /*TextBox显示为横线*/
        .txtTransverseLine {
            text-align: center;
            background: none;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: none;
            border-right-style: none;
            border-bottom-style: solid;
            border-left-style: none;
            border-top-color: #000000;
            border-right-color: #000000;
            border-bottom-color: #000000;
            border-left-color: #000000;
            width: 100px;
        }
    </style>
    <style type="text/css">
        /*Label显示为横线*/
        .labelTransverseLine {
            /*border-bottom:#000000 solid 1px;*/
            /*同等于下*/
            border-bottom-color: #000000;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            height:20px;
            width: 100px;
            display: block;
             
        }
        .juzhong {
    margin:0px auto;
    padding:10px 0px 10px 0px;
     border:1px solid #c5c5c5;
}
        .zengjia {
            margin:1px 0px 1px 0px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="min_height">
       <div class="aa"  ><div class="parallelogram"> <div  class="parallelogram2"   >考试科目信息</div></div></div>
            <div style="text-align: center">
            </div>
            <div>
                <br />
            </div>
            <div style=" width:98%; margin:0px auto;text-align: center;border:1px solid #c5c5c5;">

                <asp:Label runat="server" Text="岗位代码："></asp:Label>
                <asp:Label ID="LJobCode" runat="server" Text="岗位代码："></asp:Label>
                <asp:Label runat="server" Width="100px">   </asp:Label>
                <asp:Label runat="server" Text="岗位名称："></asp:Label>
                 <asp:Label ID="LJobName"  runat="server" Text="岗位名称："></asp:Label>
            </div>
            <div>
                <br />
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="page_main01">
                <div style="margin-top: 10px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>


                            <asp:GridView ID="GridView1"    CssClass="juzhong" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" Width="98%" Height="30px" ShowFooter="true"
                                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                               
                                <Columns>

                                  
                                    <asp:TemplateField HeaderText="数据编号" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="10%" CssClass="gridview_HeaderStyle" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LExamInfoId" runat="server" Text='<%# Bind("ExamInfoId") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate >
                                            <asp:Button ID="Button1" runat="server" CssClass="zengjia" Text="增  加" OnClick="Button1_Click" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="考试科目">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <%--编辑项模版--%>
                                            <asp:TextBox ID="TxtEditExamSubject" runat="server" Text='<%# Bind("ExamSubject") %>' Width="90%" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <%--普通显示模版--%>
                                            <asp:Label ID="LExamSubject" runat="server" Text='<%# Bind("ExamSubject") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtExamSubject" runat="server" Width="100%" BorderStyle="None" data-toggle="tooltip" data-placement="top"  ToolTip="输入考试科目" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="考试日期">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditExamDate" runat="server" onfocus="WdatePicker()" Text='<%# Bind("ExamDate") %>' Width="95%" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LExamDate" runat="server" Text='<%# Bind("ExamDate") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtExamDate" runat="server" Width="100%" BorderStyle="None" onfocus="WdatePicker()" data-toggle="tooltip" data-placement="top"  ToolTip="请输入考试日期" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="考试时间">
                                        <HeaderStyle Width="15%" CssClass="gridview_HeaderStyle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditExamTime" runat="server" Text='<%# Bind("ExamTime") %>' Width="90%"  />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LExamTime" runat="server" Text='<%# Bind("ExamTime") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtExamTime" runat="server"  Width="100%" BorderStyle="None"  data-toggle="tooltip" data-placement="top"  ToolTip="请输入考试时间" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                            
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" HeaderText="操作" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#0000cc" HeaderStyle-CssClass="gridview_HeaderStyle" />

                                  
                                </Columns>
                            </asp:GridView>
                     
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
