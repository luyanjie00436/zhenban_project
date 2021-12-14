<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTransfer.aspx.cs" Inherits="Recruitment.Manage.UserTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/master.css" rel="Stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
     <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jss.js"></script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
    <style type="text/css">
       .caozuo {width:100%;height:25px; background-image: url('image/caozuo.png'); border:1px solid #99bbe8; border-top:none;overflow:hidden;           }
.sousuo { width:95%;height:auto; border:1px solid #6c6c6c; box-shadow:0px 0px 3px #c0c0c0; margin:0px auto; margin-top:20px; position:relative; padding-bottom:10px; }

        .auto-style3 {
            width: 78px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div  class="linerlow"></div>
      <div class="wrap" >

        <div class="zuo" >
          <div class="zong">
            <div class="caozuo"  ><div class="caozuowz">操作</div></div>
             
              <div class="xiala">
                <asp:DropDownList Width="95%" ID="DSort" runat="server" >
                  <asp:ListItem Value="FollDateDesc">按注册时间倒序排列</asp:ListItem>
                  <asp:ListItem Value="FollDateAsc">按注册时间正序排列</asp:ListItem>  
                  <asp:ListItem Value="NumberDesc">按报名序号倒序排列</asp:ListItem>    
                  <asp:ListItem Value="NumberAsc">按报名序号正序排列</asp:ListItem> 

                </asp:DropDownList>
              </div>
              <div class="suowz" >搜索考生</div>
                <div class="sousuo" >
                  <table border="0" class="bgg" width="100%" >
                    <tr><td align="right" class="auto-style3" >报名序号：</td><td  align="left" > <asp:TextBox ID="txtNumber" runat="server"  Width="80%"></asp:TextBox></td></tr>

                    <tr>
                      <td align="right" class="auto-style3" >姓名：</td><td  align="left" > <asp:TextBox ID="txtName" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>

                    <tr>
                      <td align="right" class="auto-style3" >身份证号：</td><td  align="left" > <asp:TextBox ID="txtIdCard" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >联系电话：</td><td  align="left" > <asp:TextBox ID="txtPhone" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >电子邮箱：</td><td  align="left" > <asp:TextBox ID="txtEmail" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right" class="auto-style3" >毕业院校：</td><td  align="left" > <asp:TextBox ID="txtInstitutions" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>  
                    <tr>
                      <td align="right" class="auto-style3" >专业名称：</td><td  align="left" > <asp:TextBox ID="txtProfessionName" runat="server" Width="80%"></asp:TextBox></td>
                   </tr>                                                 
                                                               
                      <tr><td align="right" class="auto-style3" ></td><td  align="right" style="padding-right:19px;" > <asp:Button ID="Button10" runat="server" Text="搜 索" OnClick="Button10_Click" style="height: 21px"  />
                    </td></tr> 
                  </table>
                </div>       
              </div>
             </div>
            <div class="you" > 
                         <asp:DataList ID="dataOfYear" runat="server" Width="100%"
                              onupdatecommand="DataList1_UpdateCommand"
                  
                              >    
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="uua">
                <tr>
                    <td  rowspan="8" style="width:75px;">
                        <div class="photo" style="width:75px; overflow:hidden;">
                            <%--<img  id="Image2" runat="server" src="~/imgs.aspx?id='<%# Eval("Number") %>'" style="width:71px; padding:0; margin:0;" />--%>
                  <img  id="Image2" runat="server" src='<%# string.Format("~/imgs.aspx?id={0}", Eval("Number"))%>' style="width:71px; padding:0; margin:0;" />
                              
                                </div>
                    </td>
                    <td >报名序号：<asp:Label ID="Label2" runat="server" Text='<%# Eval("Number") %>' ></asp:Label></td>
                    <td >身份证号：<asp:Label ID="Label3" runat="server" Text='<%# Eval("CardID") %>' ></asp:Label></td>
                    <td >电子邮箱：<asp:Label ID="Label19" runat="server" Text='<%# Eval("Email") %>' ></asp:Label></td>
                </tr>
                <tr>
                    <td >姓名：<asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' ></asp:Label></td>
                    <td >生日：<asp:Label ID="Label4" runat="server" Text='<%# Eval("Birthday") %>' ></asp:Label></td>
                    <td >联系电话：<asp:Label ID="Label5" runat="server" Text='<%# Eval("ContactPhone") %>' ></asp:Label></td>
                </tr>
                <tr>
                     <td >籍贯：<asp:Label ID="Label6" runat="server" Text='<%# Eval("census") %>' ></asp:Label></td>
                    <td >民族：<asp:Label ID="Label7" runat="server" Text='<%# Eval("Nation") %>' ></asp:Label></td>
                    <td >考生来源：<asp:Label ID="Label8" runat="server" Text='<%# Eval("Sources") %>' ></asp:Label></td>
                </tr>
                <tr>
                     <td >文化程度：<asp:Label ID="Label9" runat="server" Text='<%# Eval("Culture") %>' ></asp:Label></td>
                    <td >学位：<asp:Label ID="Label10" runat="server" Text='<%# Eval("Degree") %>' ></asp:Label></td>
                    <td >学历类别：<asp:Label ID="Label11" runat="server" Text='<%# Eval("Education") %>' ></asp:Label></td>
                </tr>
                <tr>
                    <td >毕业院校：<asp:Label ID="Label13" runat="server" Text='<%# Eval("Institutions") %>' ></asp:Label></td>
                    <td >专业名称：<asp:Label ID="Label14" runat="server" Text='<%# Eval("ProfessionName") %>' ></asp:Label></td>
                    <td >毕业时间：<asp:Label ID="Label20" runat="server" Text='<%# Eval("GraduationData") %>' ></asp:Label></td>
                </tr>
                        <tr>
                    <td  colspan="3">备 注：<asp:Label ID="Label17" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label></td>
                </tr>
                <tr>
                   <td >审核状态：<asp:Label ID="Label12" runat="server" Text='<%# Eval("TransferStatus") %>' ></asp:Label></td>
                   <td >&nbsp;</td> <td >&nbsp;</td>
                </tr>
                
                <tr>
                    
                    <td  colspan="3" align="right" style="padding-right:10px;" > 
                       <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btnn" CommandArgument='<%#Eval("JobId") %>' CommandName="Update">审核</asp:LinkButton>
                          
                    </td>
                </tr>
     </table>
                   
                 </ItemTemplate>
            </asp:DataList>            
           </div>
         </div>
    </form>
</body>
</html>