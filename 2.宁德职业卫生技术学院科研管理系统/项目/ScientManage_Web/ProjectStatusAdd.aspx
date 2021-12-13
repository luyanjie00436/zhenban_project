<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectStatusAdd.aspx.cs" Inherits="ningdeScientManage_Web.ProjectStatusAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
   <style type="text/css">
         html {
         overflow-x:auto;

         }
         body{color:#000;font-size:12px;font-family:'Microsoft YaHei', Verdana; background:#dfdfdf;}

.bgcolor{ margin:0px auto; border:1px solid #bcbaba; margin-top:10px; padding-bottom:10px; }
.select1{ width:100%; height:100%; border:0px; margin:0px; padding:0px; }
.fed1{ width:10px;}
.fed2{ width:50px;}
.biaoti{ text-align:center; font-size:16px; font-family:宋体;}
th{border:0px; font-size:10px;font-family:微软雅黑; font-weight:normal; }
caption{ font-size:30px; font-family:宋体; font-weight:bold;}
.zihao{ width:1000; font-size:12px; font-family:宋体;}
  .btn { width:60px; height:30px;   color:#000;     border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer; }
.select1     { border:1px solid #c3cdd4; background:none; width:180px;   height:24px; line-height:24px; color:#333; margin-top:2px}
.input6 {
    background:#eae9e9;
    /*border:1px solid #d4d2d2;*/
}
</style>
</head>
<body>
    <form id="form1" runat="server">
           
    <table width="80%" height="100%" class="bgcolor"  cellspacing="0">
<caption>福建宁德职业技术学院项目情况申请表</caption>
    
    <tr>
        <th colspan="6">
             
            <br />

            </th>
      </tr>
  <tr>
    <td style="width:100px;" align="right"  >项目名称:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtProjectStatusName" runat="server"/></td>
    <td width="100px" align="right" >项目编号:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtProjectId" runat="server"/></td>
    <td width="100px"align="right" >项目来源:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtSource" runat="server"/></td>
  </tr>
  <tr>
    
    <td width="100px" align="right" >项目负责人:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtUserName" runat="server" readonly="true" /></td>
    <td width="100px" align="right" >所属系部:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtDepartment" runat="server" readonly="true" />
       <%-- <asp:DropDownList ID="DlDepartment" runat="server" CssClass="select1"  ToolTip="选择系部">
                               <asp:ListItem Value="0">选择系部</asp:ListItem>
                                      </asp:DropDownList>--%>
    </td>
    <td width="100px" align="right"  >工作量:</td>
    <td width="100px" ><input class="select1" type="text"  id="txtPersonnel" runat="server"/></td>

  </tr>
    <tr>
    <td width="100px" align="right" >学科分类:</td>
    <td width="100px" align="left" >
        <asp:DropDownList ID="DlSubject" runat="server" CssClass="select1" >
            <asp:ListItem Value="0">==请选择==</asp:ListItem>
        </asp:DropDownList>

    </td>
    <td width="100px" align="right" >合作形式:</td>
    <td width="100px" >
         <asp:DropDownList ID="DlCooperation" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
             <asp:ListItem Value="1">与境内注册其他企业合作</asp:ListItem>
             <asp:ListItem Value="2">独立完成</asp:ListItem>
             <asp:ListItem Value="3">其他</asp:ListItem>
         </asp:DropDownList>
    </td>
   

  </tr>
   <tr>
    <td width="100px" align="right"  >批准经费:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtFunding1" runat="server"/></td>
    <td width="100px" align="right" >去年年底转经费:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtFunding2" runat="server"/></td>
    <td width="100px" align="right" >今年拨入经费:</td>
    <td width="100px" align="left" ><input class="select1" type="text"  id="txtFunding3" runat="server"/></td>
    
  </tr>
        <tr>
            <td width="100" align="right" >今年支出经费:</td>
            <td width="100" align="left" ><input class="select1" type="text"  id="txtFunding4" runat="server"/></td>
             <td width="100" align="right">研究类别:</td>
             <td >
         <asp:DropDownList ID="DlCategory" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
             <asp:ListItem Value="基础研究">基础研究</asp:ListItem>
             <asp:ListItem Value="应用研究">应用研究</asp:ListItem>
             <asp:ListItem Value="实验与发展">实验与发展</asp:ListItem>
         </asp:DropDownList>
             </td>
             <td width="100" align="right" >最终成果形式:</td>
    <td width="100" align="left" >
         <asp:DropDownList ID="DlResults" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
             <asp:ListItem Value="论文">论文</asp:ListItem>
             <asp:ListItem Value="研究或咨询报告">研究或咨询报告</asp:ListItem>
             <asp:ListItem Value="电子出版物">电子出版物</asp:ListItem>
             <asp:ListItem Value="译文">译文</asp:ListItem>
         </asp:DropDownList>
    </td>
        </tr>
        <tr>
             <td width="100" align="right" >社会经济目标分类与代码:</td>
    <td width="100" >
        <asp:DropDownList ID="DlAims1" runat="server" Style="margin-left: 0px; "
                   AutoPostBack="True"      CssClass="select1" OnSelectedIndexChanged="DlAims1_SelectedIndexChanged">
                         <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
    </td>
            <td>
                   <asp:DropDownList ID="DlAims2" runat="server" Style="margin-left: 0px; "
                     AutoPostBack="True"    CssClass="select1" OnSelectedIndexChanged="DlAims2_SelectedIndexChanged">
                      
                    </asp:DropDownList>
            </td>
             <td>
                    <asp:DropDownList ID="DlAims3" runat="server" Style="margin-left: 0px; "
                      CssClass="select1" >
                      
                    </asp:DropDownList>
             </td>
          
        </tr>
    <tr>
        
    <td width="100" align="right" >服务的国民经济行业:</td>
    <td width="100" align="left" >
       <asp:DropDownList ID="DlServiceIndustry1" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged1" >
           <asp:ListItem Value="0">请选择</asp:ListItem>
       </asp:DropDownList>
    </td>
    <td width="100" align="right"  > 
          <asp:DropDownList ID="DlServiceIndustry2" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged2" >
         
       </asp:DropDownList></td>
    <td width="100" align="left" >
            <asp:DropDownList ID="DlServiceIndustry3" runat="server" AutoPostBack="True" CssClass="select1" OnSelectedIndexChanged="DlServiceIndustry_SelectedIndexChanged3" >
        
       </asp:DropDownList></td>
    <td width="100" align="left" >
            <asp:DropDownList ID="DlServiceIndustry4" runat="server"  CssClass="select1" >
       
       </asp:DropDownList></td>
    </tr>
     <tr>
        <td width="100" align="right" >立项时间:</td>
        <td width="100" align="left" ><input class="select1" type="text"  onfocus="WdatePicker()"  id="txtProjectDate" runat="server"/></td>
        <td width="100" align="right" >结题时间:</td>
        <td width="100"  align="left"><input class="select1" type="text"  onfocus="WdatePicker()"  id="txtResultsDate" runat="server"/></td>
        <td width="100" align="right" >项目状态:</td>
        <td width="100" align="left" >
        <asp:DropDownList ID="DlStatus" runat="server" CssClass="select1" >
             <asp:ListItem Value="0">==请选择==</asp:ListItem>
             <asp:ListItem Value="进行">进行</asp:ListItem>
             <asp:ListItem Value="完成">完成</asp:ListItem>
         </asp:DropDownList>
        </td>
      </tr>
    <tr style="background:#bcbaba; width:100%; padding:none;">
        
        <td align="left" colspan="6">&nbsp;&nbsp;&nbsp;本年支出经费如下：</td>
    </tr>
         
    <tr>
        <td width="100" align="right"  >转拨给外单位:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtTransferUnit" runat="server"/></td>
        <td width="100" align="right" >备注：转拨方:</td>
        <td width="100" ><input class="select1" type="text"  id="txtTransferName" runat="server"/></td>
        <td width="100" align="right" >业务费:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost1" runat="server"/></td>
    </tr>
    <tr>
        <td width="100" align="right" >仪器设备费:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost2" runat="server"/></td>
        <td width="100" align="right" >单价在一万以上的设备费:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost3" runat="server"/></td>
        <td width="100" align="right" >图书资料费:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost4" runat="server"/></td>
    </tr>
    <tr>
        <td width="100" align="right" >管理费:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost5" runat="server"/></td>
        <td width="100" align="right" >其他支出:</td>
        <td width="100" align="left" ><input class="select1" type="text"  id="txtCost6" runat="server"/></td>
        <td width="100" align="right" >2015年结余经费:</td>
        <td width="100"  align="left"><input class="select1" type="text"  id="txtCost7" runat="server"/></td>
    </tr>  

    </table> <br />
        <div style="width:100%; height:100%; text-align:center; "> 
                <asp:Button ID="Button1" runat="server" Text="添 加" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="保 存" CssClass="btn" OnClick="Button2_Click" />
            </div>         
    </form>
</body>
</html>
