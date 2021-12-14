<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobMangeCount.aspx.cs" Inherits="Recruitment.Manage.JobMangeCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="年份："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                            <asp:GridView ID="GridView1"    CssClass="juzhong" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" Width="98%" ShowFooter="true" >
                               
                           <AlternatingRowStyle BackColor="#dddddd" />
                        <Columns>
                            <asp:BoundField DataField="年份" HeaderText="年份">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="岗位编号" HeaderText="岗位编号">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                         <asp:BoundField DataField="岗位名称" HeaderText="岗位名称">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="笔试科目" HeaderText="笔试科目">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="招考人数" HeaderText="招考人数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="总报名人数" HeaderText="总报名人数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="审核通过人数" HeaderText="审核通过人数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="未审核人数" HeaderText="未审核人数">
                                <HeaderStyle  CssClass="gridview_HeaderStyle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                            </asp:GridView>
    </div>
    </form>
</body>
</html>
