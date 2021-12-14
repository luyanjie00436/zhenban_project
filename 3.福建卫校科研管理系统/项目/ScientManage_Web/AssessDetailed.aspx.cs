using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class AssessDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int ApplyYearId;
        protected string MenuStr = "";
        DataSet dy1, dy2, dy3, dy4, dy5, dy6, dy7, dy8;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["UserCardId"] == null)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                try
                {
                    UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["ApplyYearId"] == null)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                try
                {
                    ApplyYearId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyYearId"], "asdfasdf"));
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                #region
               dy1 = bus.SelectByApplyUserCardId("Teaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy1.Tables[0].Rows.Count < 2)
                {
                    dy1.Tables[0].Rows.Add(dy1.Tables[0].NewRow());
                }
                 dy2 = bus.SelectByApplyUserCardId("Paper_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy2.Tables[0].Rows.Count < 2)
                {
                    dy2.Tables[0].Rows.Add(dy2.Tables[0].NewRow());
                }
               dy3 = bus.SelectByApplyUserCardId("Patent_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy3.Tables[0].Rows.Count < 2)
                {
                    dy3.Tables[0].Rows.Add(dy3.Tables[0].NewRow());
                }
                dy4 = bus.SelectByApplyUserCardId("Harvest_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy4.Tables[0].Rows.Count < 2)
                {
                    dy4.Tables[0].Rows.Add(dy4.Tables[0].NewRow());
                }
                dy5 = bus.SelectByApplyUserCardId("Winning_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy5.Tables[0].Rows.Count < 2)
                {
                    dy5.Tables[0].Rows.Add(dy5.Tables[0].NewRow());
                }
               dy6 = bus.SelectByApplyUserCardId("Guidance_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy6.Tables[0].Rows.Count < 2)
                {
                    dy6.Tables[0].Rows.Add(dy6.Tables[0].NewRow());
                }
                 dy7 = bus.SelectByApplyUserCardId("WorkLoadProjects_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy7.Tables[0].Rows.Count < 2)
                {
                    dy7.Tables[0].Rows.Add(dy7.Tables[0].NewRow());
                }
                 dy8 = bus.SelectByApplyUserCardId("AssessValue_SelectByApplyYearId", UserCardId, ApplyYearId);
             //   LNowValue.Text = dy8.Tables[0].Rows[0]["NowValue"].ToString();
             //   LYearReport.Text = dy8.Tables[0].Rows[0]["ReportDate"].ToString() + "年度福建卫生职业技术学院科研工作量核算表";//福建//卫生职业技术学院
             //   LDepartment.Text = dy8.Tables[0].Rows[0]["DepartmentName"].ToString();
             //   LUserName.Text = dy8.Tables[0].Rows[0]["UserName"].ToString();
                #endregion
                 #region
                 StringBuilder text = new StringBuilder();
                int RowCount =7+ dy1.Tables[0].Rows.Count + dy2.Tables[0].Rows.Count + dy3.Tables[0].Rows.Count + dy4.Tables[0].Rows.Count + dy5.Tables[0].Rows.Count + dy6.Tables[0].Rows.Count + dy7.Tables[0].Rows.Count;
                text.Append("<table id=\"IsTabel\" runat=\"server\" cellspacing=\"0\" cellpadding=\"0\" >");
                text.Append("<tr><td colspan=\"14\"   style=\"border:0px;\">" + dy8.Tables[0].Rows[0]["年份"].ToString() + "年度福建卫生职业技术学院科研工作量核算表" + "</td></tr>");
                text.Append("<tr><td colspan=\"3\"    style=\"border:0px; text-align:right\"> 系、部:</td> <td colspan=\"5\"  style=\"border:0px;text-align:left;\"> " + dy8.Tables[0].Rows[0]["部门"].ToString() + "</td> <td colspan=\"4\"   style=\"border:0px;text-align:right;\"> 填表教师（签名）：  </td> <td colspan=\"2\"  style=\"border:0px;text-align:left;\" > " + dy8.Tables[0].Rows[0]["姓名"].ToString() + "</td></tr>");
                text.Append("<tr><td rowspan=\"" + RowCount.ToString() + "\"  style=\" border-left:1px solid #000000;   border-bottom:1px solid #000000;   border-right:1px solid #000000;\">科<br>研<br>工<br>作<br>量</td><td rowspan=\"" + (dy7.Tables[0].Rows.Count + 1).ToString() + "\">科研<br>项目</td><td>项目<br>类别</td> <td colspan=\"2\">项目名称</td> <td>编号</td> <td colspan=\"2\">来源及类别（或项目委托方）</td> <td>起止时间</td><td>到校经费</td> <td>本年度可分配工作量分值</td><td>排名</td> <td>工作量分值</td><td  style=\" max-width:200px;\">备注</td></tr>");
                for (int i = 0; i < dy7.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\"  >" + dy7.Tables[0].Rows[i]["CateGory"].ToString() + "</td> <td colspan=\"2\" class=\"td2\">" + dy7.Tables[0].Rows[i]["WorkLoadProjectsName"].ToString() + "</td> <td class=\"td2\" >" + dy7.Tables[0].Rows[i]["ProjectsId"].ToString() + "</td> <td colspan=\"2\"  class=\"td2\" >" + dy7.Tables[0].Rows[i]["WorkLoadFrom"].ToString() + "</td> <td  class=\"td2\" >" + dy7.Tables[0].Rows[i]["StartEndDate"].ToString() + "</td><td  class=\"td2\" >" + dy7.Tables[0].Rows[i]["WorkLoadCapital"].ToString() + "</td> <td  class=\"td2\" >" + dy7.Tables[0].Rows[i]["ProjectsValue"].ToString() + "</td><td  class=\"td2\" >" + dy7.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td> <td  class=\"td2\" >" + dy7.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td style=\" max-width:200px;\"  class=\"td2\" >" + dy7.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");

                }
                text.Append("<tr><td rowspan=\"" + (dy1.Tables[0].Rows.Count + 1).ToString() + "\">著<br>作</td> <td colspan=\"3\">著作名称</td> <td colspan=\"1\">出版类别</td> <td colspan=\"2\">出版社</td><td >出版时间</td> <td>版次</td><td>字数（万）</td><td></td>  <td></td><td>备注</td></tr>");
                for (int i = 0; i < dy1.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr>  <td class=\"td2\"  colspan=\"3\" >" + dy1.Tables[0].Rows[i]["BookName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"1\">" + dy1.Tables[0].Rows[i]["PressCategory"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy1.Tables[0].Rows[i]["PressName"].ToString() + "</td> <td class=\"td2\"  >" + dy1.Tables[0].Rows[i]["PressDate"].ToString() + "</td>  <td class=\"td2\" >" + dy1.Tables[0].Rows[i]["Revision"].ToString() + "</td> <td class=\"td2\" >" + dy1.Tables[0].Rows[i]["TotalNumber"].ToString() + "</td> <td class=\"td2\" >" + dy1.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td>  <td class=\"td2\" >" + dy1.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td class=\"td2\"  style=\" max-width:200px;\">" + dy1.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }

                text.Append("<tr><td rowspan=\"" + (dy2.Tables[0].Rows.Count + 1).ToString() + "\">论<br>文</td> <td colspan=\"3\">论文题目</td> <td colspan=\"2\">期刊名称及刊号</td> <td colspan=\"2\">期刊级别</td> <td colspan=\"2\">年月、期</td><td></td>  <td></td> <td>备注</td></tr>");
                for (int i = 0; i < dy2.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr>  <td class=\"td2\"  colspan=\"3\">" + dy2.Tables[0].Rows[i]["PaperSubject"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy2.Tables[0].Rows[i]["PaperName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy2.Tables[0].Rows[i]["PaperLevel"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy2.Tables[0].Rows[i]["PaperYears"].ToString() + "</td> <td class=\"td2\" >" + dy2.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td> <td class=\"td2\" >" + dy2.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td>  <td class=\"td2\"  style=\" max-width:200px;\">" + dy2.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td rowspan=\"" + (dy3.Tables[0].Rows.Count + 1).ToString() + "\">专<br>利</td> <td colspan=\"3\">专利名称</td> <td colspan=\"2\">专利类别</td> <td colspan=\"2\">专利获奖级别</td> <td colspan=\"2\">奖级</td><td></td>   <td></td><td>备注</td></tr>");
                for (int i = 0; i < dy3.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr> <td class=\"td2\"  colspan=\"3\">" + dy3.Tables[0].Rows[i]["PatentName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy3.Tables[0].Rows[i]["PatentCateGory"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy3.Tables[0].Rows[i]["PatentLevel"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy3.Tables[0].Rows[i]["PatentPrizes"].ToString() + "</td> <td class=\"td2\" >" + dy3.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td>  <td class=\"td2\" >" + dy3.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td class=\"td2\"  style=\" max-width:200px;\">" + dy3.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td rowspan=\"" + (dy4.Tables[0].Rows.Count + 1).ToString() + "\">成<br>果</td> <td colspan=\"3\">成果获奖名称</td> <td colspan=\"2\">鉴定水平</td> <td colspan=\"4\">鉴定单位</td><td></td>    <td></td><td>备注</td></tr>");
                for (int i = 0; i < dy4.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr>  <td class=\"td2\"  colspan=\"3\">" + dy4.Tables[0].Rows[i]["HarvestName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy4.Tables[0].Rows[i]["AppraisalLevel"].ToString() + "</td>  <td class=\"td2\"  colspan=\"4\">" + dy4.Tables[0].Rows[i]["AppraisalCompany"].ToString() + "</td>   <td class=\"td2\" >" + dy4.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td> <td class=\"td2\" >" + dy4.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td class=\"td2\"  style=\" max-width:200px;\">" + dy4.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }

                text.Append("<tr><td rowspan=\"" + (dy5.Tables[0].Rows.Count + 1).ToString() + "\">获<br>奖</td> <td colspan=\"3\">获奖名称</td> <td colspan=\"2\">获奖项目时间、类别</td> <td colspan=\"4\">获奖等级</td><td></td>    <td></td><td>备注</td></tr>");

                for (int i = 0; i < dy5.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr>  <td class=\"td2\"  colspan=\"3\">" + dy5.Tables[0].Rows[i]["WinningName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"2\">" + dy5.Tables[0].Rows[i]["WinningCateGory"].ToString() + "</td>  <td class=\"td2\"  colspan=\"4\">" + dy5.Tables[0].Rows[i]["WinningLevel"].ToString() + "</td>   <td class=\"td2\" >" + dy5.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td> <td class=\"td2\" >" + dy5.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td class=\"td2\"  style=\" max-width:200px;\">" + dy5.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td rowspan=\"" + (dy6.Tables[0].Rows.Count + 1).ToString() + "\">指导<br>学生</td><td colspan=\"5\">成果或调研报告名称</td> <td colspan=\"4\">成果或采用级别</td> <td></td>   <td></td><td >备注</td></tr>");
               
                for (int i = 0; i < dy6.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr> <td class=\"td2\"  colspan=\"5\">" + dy6.Tables[0].Rows[i]["GuidanceName"].ToString() + "</td>  <td class=\"td2\"  colspan=\"4\">" + dy6.Tables[0].Rows[i]["GuidanceLevel"].ToString() + "</td>  <td class=\"td2\" >" + dy6.Tables[0].Rows[i]["PartnerRank"].ToString() + "</td>  <td class=\"td2\" >" + dy6.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td class=\"td2\"  style=\" max-width:200px;\">" + dy6.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
               
                }

                text.Append("<tr><td colspan=\"12\"  style=\" border-left:1px solid #000000;   border-bottom:1px solid #000000;   border-right:1px solid #000000;\">已完成科研工作量总分值</td><td >" + dy8.Tables[0].Rows[0]["实际完成科研工作量"].ToString() + "</td><td ></td></tr>");
           //     text.Append("<tr><td colspan=\"3\" style=\"border:0px;\">系部审核意见：<br>（加盖公章）</td style=\"border:0px;\"><td colspan=\"2\"  style=\"border:0px;\"></td><td colspan=\"2\" style=\"border:0px;\">系、部 <br> 审核人（签名）：</td> <td colspan=\"2\" style=\"border:0px;\"></td><td colspan=\"3\" style=\"border:0px;\">科研处审核意见：<br>（加盖公章）</td> <td colspan=\"2\" style=\"border:0px;\"></td> </tr>");

                text.Append("</table>");
                MenuStr = text.ToString();
                 #endregion
            }
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
            ApplyYearId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyYearId"], "asdfasdf"));
        //    string TempletFileName = Server.MapPath("File/Template/Work.xls");
           string ReportFileName = Server.MapPath("out.xls");
        //    FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            //    HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);//打开工作薄
            //  HSSFSheet mySheet = (HSSFSheet)hssfworkbook.GetSheet("Sheet3");  //获取工作表
     
             #region 获取数据
            dy1 = bus.SelectByApplyUserCardId("Teaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy1.Tables[0].Rows.Count < 2)
            {
                dy1.Tables[0].Rows.Add(dy1.Tables[0].NewRow());
            }
            dy2 = bus.SelectByApplyUserCardId("Paper_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy2.Tables[0].Rows.Count < 2)
            {
                dy2.Tables[0].Rows.Add(dy2.Tables[0].NewRow());
            }
            dy3 = bus.SelectByApplyUserCardId("Patent_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy3.Tables[0].Rows.Count < 2)
            {
                dy3.Tables[0].Rows.Add(dy3.Tables[0].NewRow());
            }
            dy4 = bus.SelectByApplyUserCardId("Harvest_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy4.Tables[0].Rows.Count < 2)
            {
                dy4.Tables[0].Rows.Add(dy4.Tables[0].NewRow());
            }
            dy5 = bus.SelectByApplyUserCardId("Winning_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy5.Tables[0].Rows.Count < 2)
            {
                dy5.Tables[0].Rows.Add(dy5.Tables[0].NewRow());
            }
            dy6 = bus.SelectByApplyUserCardId("Guidance_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy6.Tables[0].Rows.Count < 2)
            {
                dy6.Tables[0].Rows.Add(dy6.Tables[0].NewRow());
            }
            dy7 = bus.SelectByApplyUserCardId("WorkLoadProjects_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy7.Tables[0].Rows.Count < 2)
            {
                dy7.Tables[0].Rows.Add(dy7.Tables[0].NewRow());
            }
            dy8 = bus.SelectByApplyUserCardId("AssessValue_SelectByApplyYearId", UserCardId, ApplyYearId);

            #endregion
            
            int RowCount = 7 + dy1.Tables[0].Rows.Count + dy2.Tables[0].Rows.Count + dy3.Tables[0].Rows.Count + dy4.Tables[0].Rows.Count + dy5.Tables[0].Rows.Count + dy6.Tables[0].Rows.Count + dy7.Tables[0].Rows.Count;
          
            #region 设置行高列宽
            mySheet.SetColumnWidth(0, 1121);
            mySheet.SetColumnWidth(1, 1121);
            mySheet.SetColumnWidth(2, 5 * 256);
            mySheet.SetColumnWidth(3, 25 * 256);
            mySheet.SetColumnWidth(4, 15 * 256);
            mySheet.SetColumnWidth(5, 3480);
            mySheet.SetColumnWidth(6, 2209);
            mySheet.SetColumnWidth(7, 10 * 256);
            mySheet.SetColumnWidth(8, 1953);
            mySheet.SetColumnWidth(9, 1844);
            mySheet.SetColumnWidth(10, 1856);
            mySheet.SetColumnWidth(11, 1612);
            mySheet.SetColumnWidth(12, 4129);
            //mySheet.GetRow(0).Height = 20 * 26;
            //  mySheet.GetRow(1).Height = 20 * 24;
            #endregion
            #region 第一行
            HSSFCellStyle style6 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
           

            style6.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style6.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style6.WrapText = true;//自动换行

            NPOI.SS.UserModel.Font f = hssfworkbook.CreateFont();  //定义文字
            f.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD; //文字加粗
            f.FontHeightInPoints = 16;  //文字大小

            f.FontName = "Times New Roman"; //字体
            style6.SetFont(f);
            for (int j = 0; j < 13; j++)
            {
                mySheet.CreateRow(0).CreateCell(j).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, 0, 0, 0, 12);
            mySheet.GetRow(0).Height = 20 * 26;
           // mySheet.GetRow(0).GetCell(0).SetCellValue(dy8.Tables[0].Rows[0]["年份"].ToString() + "年度福建卫生职业技术学院科研工作量核算表");//插入年份
           mySheet.GetRow(0).CreateCell(0).SetCellValue(dy8.Tables[0].Rows[0]["年份"].ToString() + "年度福建卫生职业技术学院科研工作量核算表");//插入年份
            mySheet.GetRow(0).GetCell(0).CellStyle = style6;


            //  mySheet.GetRow(0).GetCell(0).CellStyle = style6;

            #endregion
            #region 第二行
            SetCellRangeAddress(mySheet, 1, 1, 0, 2);
            SetCellRangeAddress(mySheet, 1, 1, 3, 7);
            SetCellRangeAddress(mySheet, 1, 1, 8, 9);
            SetCellRangeAddress(mySheet, 1, 1, 10, 12);
            HSSFCellStyle style1 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;//水平靠左  
            style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style1.WrapText = true;//自动换行
            NPOI.SS.UserModel.Font fb = hssfworkbook.CreateFont();  //定义文字
            fb.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.NORMAL; //文字加粗
            fb.FontHeightInPoints = 10;  //文字大小
            fb.FontName = "宋体"; //字体
            style1.SetFont(fb);
            mySheet.CreateRow(1).CreateCell(0).CellStyle = style1;
            mySheet.GetRow(1).GetCell(0).SetCellValue("系、部：");
            mySheet.GetRow(1).CreateCell(3).CellStyle = style1;
            mySheet.GetRow(1).GetCell(3).SetCellValue(dy8.Tables[0].Rows[0]["部门"].ToString());
            mySheet.GetRow(1).CreateCell(8).CellStyle = style1;
            mySheet.GetRow(1).GetCell(8).SetCellValue("填表教师（签名）：");
            mySheet.GetRow(1).CreateCell(10).CellStyle = style1;
            mySheet.GetRow(1).GetCell(10).SetCellValue(dy8.Tables[0].Rows[0]["姓名"].ToString());
   
          
           
            mySheet.GetRow(1).Height = 20 * 24;
      
         
            #endregion

            HSSFCellStyle style7 =(HSSFCellStyle) hssfworkbook.CreateCellStyle();
         
            style7.BorderBottom = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderLeft = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderRight =(NPOI.SS.UserModel.CellBorderType) NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderTop = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style7.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style7.WrapText = true;//自动换行
            style7.LeftBorderColor = HSSFColor.BLACK.index;
            style7.RightBorderColor = HSSFColor.BLACK.index;
            style7.TopBorderColor = HSSFColor.BLACK.index;
            style7.BottomBorderColor = HSSFColor.BLACK.index;
            SetCellRangeAddress(mySheet, 2, 1 + RowCount, 0, 0);
            for (int i = 0; i <= RowCount; i++)
            {
                mySheet.CreateRow(2 + i).CreateCell(0).CellStyle = style7;
            }
         
            mySheet.GetRow(2).GetCell(0).SetCellValue("科n研n工n作n量".Replace("n", Environment.NewLine));




            #region 科研项目
            int StartRow = 2, EndRow = 2 + dy7.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(2).GetCell(1).SetCellValue("科研项目");
            mySheet.GetRow(2).GetCell(2).SetCellValue("项目类别");
            mySheet.GetRow(2).GetCell(3).SetCellValue("项目名称");
            mySheet.GetRow(2).GetCell(4).SetCellValue("编号");
            SetCellRangeAddress(mySheet, 2, 2, 5, 6);
            mySheet.GetRow(2).GetCell(5).SetCellValue("来源及类别（或项目委托方）");
            mySheet.GetRow(2).GetCell(7).SetCellValue("迄止时间");
            mySheet.GetRow(2).GetCell(8).SetCellValue("到校经费（万元）");
            mySheet.GetRow(2).GetCell(9).SetCellValue("项目总分值");
            mySheet.GetRow(2).GetCell(10).SetCellValue("排名");
            mySheet.GetRow(2).GetCell(11).SetCellValue("工作量分值");
            mySheet.GetRow(2).GetCell(12).SetCellValue("备注");
            for (int i = 0; i < dy7.Tables[0].Rows.Count; i++)
            {

                mySheet.GetRow(3 + i).GetCell(2).SetCellValue(dy7.Tables[0].Rows[i]["CateGory"].ToString());
                mySheet.GetRow(3 + i).GetCell(3).SetCellValue(dy7.Tables[0].Rows[i]["WorkLoadProjectsName"].ToString());
                mySheet.GetRow(3 + i).GetCell(4).SetCellValue(dy7.Tables[0].Rows[i]["ProjectsId"].ToString());
                SetCellRangeAddress(mySheet, 3 + i, 3 + i, 5, 6);
                mySheet.GetRow(3 + i).GetCell(5).SetCellValue(dy7.Tables[0].Rows[i]["WorkLoadFrom"].ToString());
                mySheet.GetRow(3 + i).GetCell(7).SetCellValue(dy7.Tables[0].Rows[i]["StartEndDate"].ToString());
                mySheet.GetRow(3 + i).GetCell(8).SetCellValue(dy7.Tables[0].Rows[i]["WorkLoadCapital"].ToString());
                mySheet.GetRow(3 + i).GetCell(9).SetCellValue(dy7.Tables[0].Rows[i]["ProjectsValue"].ToString());
                mySheet.GetRow(3 + i).GetCell(10).SetCellValue(dy7.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(3 + i).GetCell(11).SetCellValue(dy7.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(3 + i).GetCell(12).SetCellValue(dy7.Tables[0].Rows[i]["Remarks"].ToString());
            }
            #endregion
            #region 著作
            StartRow = EndRow + 1;
            EndRow = StartRow + dy1.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("著作");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 3);
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("著作名称");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("出版类别");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("出版社");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("出版时间");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 7, 8);
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("版次");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("字数（万）");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");
            for (int i = 0; i < dy1.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 3);
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy1.Tables[0].Rows[i]["BookName"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy1.Tables[0].Rows[i]["PressCategory"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy1.Tables[0].Rows[i]["PressName"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy1.Tables[0].Rows[i]["PressDate"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 7, 8);
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy1.Tables[0].Rows[i]["Revision"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy1.Tables[0].Rows[i]["TotalNumber"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy1.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy1.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy1.Tables[0].Rows[i]["Remarks"].ToString());
            }

            #endregion
            #region 论文
            StartRow = EndRow + 1;
            EndRow = StartRow + dy2.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("论文");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 3);
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("论文题目");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 4, 6);
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("期刊名称及刊号");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("期刊级别");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 8, 9);
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("年月、期");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");

            for (int i = 0; i < dy2.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 3);
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy2.Tables[0].Rows[i]["PaperSubject"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 4, 6);
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy2.Tables[0].Rows[i]["PaperName"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy2.Tables[0].Rows[i]["PaperLevel"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 8, 9);
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy2.Tables[0].Rows[i]["PaperYears"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy2.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy2.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy2.Tables[0].Rows[i]["Remarks"].ToString());

            }
           
            #endregion
            #region 专利
            StartRow = EndRow + 1;
            EndRow = StartRow + dy3.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("专利");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 3);
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("专利名称");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 4, 5);
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("专利类别");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 6, 8);
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("专利获奖级别");

            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("奖级");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");

            for (int i = 0; i < dy3.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 3);
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy3.Tables[0].Rows[i]["PatentName"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 4, 5);
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy3.Tables[0].Rows[i]["PatentCateGory"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 6, 8);
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy3.Tables[0].Rows[i]["PatentLevel"].ToString());

                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy3.Tables[0].Rows[i]["PatentPrizes"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy3.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy3.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy3.Tables[0].Rows[i]["Remarks"].ToString());


            }
          
            #endregion
            #region 成果
            StartRow = EndRow + 1;
            EndRow = StartRow + dy4.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("成果");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 3);
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("成果名称");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 4, 5);
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("鉴定水平");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 6, 9);
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("鉴定单位");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");

            for (int i = 0; i < dy4.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 3);
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy4.Tables[0].Rows[i]["HarvestName"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 4, 5);
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy4.Tables[0].Rows[i]["AppraisalLevel"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 6, 9);
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy4.Tables[0].Rows[i]["AppraisalCompany"].ToString());

                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy4.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy4.Tables[0].Rows[i]["PartnerValue"].ToString());

                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy4.Tables[0].Rows[i]["Remarks"].ToString());

            }
         
            #endregion
            #region 获奖
            StartRow = EndRow + 1;
            EndRow = StartRow + dy5.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("获奖");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 4);
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("获奖项目名称");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 5, 7);
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("获奖项目时间、类别");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 8, 9);
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("获奖等级");


            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");

            for (int i = 0; i < dy5.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 4);
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy5.Tables[0].Rows[i]["WinningName"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 5, 7);
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy5.Tables[0].Rows[i]["WinningCateGory"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 8, 9);
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy5.Tables[0].Rows[i]["WinningLevel"].ToString());


                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy5.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy5.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy5.Tables[0].Rows[i]["Remarks"].ToString());


            }
          
            #endregion
            #region 指导学生取得研究成果或调研报告
            StartRow = EndRow + 1;
            EndRow = StartRow + dy6.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 3);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("指导学生取得研究成果或调研报告");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 4, 6);
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("成果或调研报告名称");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 7, 9);
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("成果或采用级别");


            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("备注");

            for (int i = 0; i < dy6.Tables[0].Rows.Count; i++)
            {
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 4, 6);
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy6.Tables[0].Rows[i]["GuidanceName"].ToString());
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 7, 9);
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy6.Tables[0].Rows[i]["GuidanceLevel"].ToString());


                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy6.Tables[0].Rows[i]["PartnerRank"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy6.Tables[0].Rows[i]["PartnerValue"].ToString());
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy6.Tables[0].Rows[i]["Remarks"].ToString());


            }
            #endregion
            #region 已完成科研工作量总分值
            StartRow = EndRow + 1;
            EndRow = StartRow;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 0, 10);
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            mySheet.GetRow(StartRow).GetCell(0).SetCellValue("已完成科研工作量总分值");

            mySheet.GetRow(StartRow).GetCell(11).SetCellValue(dy8.Tables[0].Rows[0]["实际完成科研工作量"].ToString());
          

            #endregion

            //#region 系部审核意见：（加盖公章）
            //StartRow = EndRow + 1;
            //EndRow = StartRow;
            //SetCellRangeAddress(mySheet, StartRow, EndRow, 0, 2);
            //mySheet.GetRow(StartRow).GetCell(0).SetCellValue("系部审核意见：n（加盖公章）".Replace("n", Environment.NewLine));
            //HSSFCellStyle style5 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();


            //style5.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            //style5.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            //style5.WrapText = true;//自动换行

            //NPOI.SS.UserModel.Font f2 = hssfworkbook.CreateFont();  //定义文字
            //f2.FontHeightInPoints = 10;  //文字大小

            //f2.FontName = "宋体"; //字体
            //style5.SetFont(f2);
            //mySheet.GetRow(StartRow).Height = 855;
            //SetCellRangeAddress(mySheet, StartRow, StartRow, 4, 5);
            //mySheet.GetRow(StartRow).GetCell(4).SetCellValue("系、部  审核人 n（签名）：".Replace("n", Environment.NewLine));
            //SetCellRangeAddress(mySheet, StartRow, StartRow, 6, 7);
            //SetCellRangeAddress(mySheet, StartRow, StartRow, 8, 9);
            //mySheet.GetRow(StartRow).GetCell(8).SetCellValue("科研处审核意见： n（加盖公章）".Replace("n", Environment.NewLine));

            //SetCellRangeAddress(mySheet, StartRow, StartRow, 10, 11);
            //for (int j = 0; j <= 12; j++)
            //{
            //    mySheet.GetRow(StartRow).GetCell(j).CellStyle = style5;
            //}
            //#endregion

            System.Data.DataTable dt = new System.Data.DataTable();

            mySheet.ForceFormulaRecalculation = true;

            using (FileStream filess = File.OpenWrite(ReportFileName))
            {
                hssfworkbook.Write(filess);
            }

          


            System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("科研工作量.xls"));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
            Response.AddHeader("Content-Length", filet.Length.ToString());

            // 指定返回的是一个不能被客户端读取的流，必须被下载   
            Response.ContentType = "application/ms-excel";

            // 把文件流发送到客户端   
            Response.WriteFile(filet.FullName);
            // 停止页面的执行   
            Response.End();

        }
      
        
        //合并单元格
        public static void SetCellRangeAddress(HSSFSheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }
        private void MyInsertRow(HSSFSheet sheet, int InsertRows, int CountRows, HSSFRow OldRows)
        {
            #region 批量移动行
                        sheet
                .ShiftRows
                (
                InsertRows,                                 //--开始行
                sheet
                .LastRowNum,                            //--结束行
                CountRows,                             //--移动大小(行数)--往下移动
                true,                                   //是否复制行高
                false,                                  //是否重置行高
                true                                    //是否移动批注
                );
            #endregion

            #region 对批量移动后空出的空行插，创建相应的行，并以插入行的上一行为格式源(即：插入行-1的那一行)
                        for (int i = InsertRows; i < InsertRows + CountRows - 1; i++)
            {
                HSSFRow targetRow = null;
                HSSFCell sourceCell = null;
                HSSFCell targetCell = null;

                targetRow = (HSSFRow)sheet.CreateRow(i + 1);

                for (int m = OldRows.FirstCellNum; m < OldRows.LastCellNum; m++)
                {
                    sourceCell = (HSSFCell)OldRows.GetCell(m);
                    if (sourceCell == null)
                        continue;
                    targetCell = (HSSFCell)targetRow.CreateCell(m);

                    targetCell.Encoding = sourceCell.Encoding;
                    targetCell.CellStyle = sourceCell.CellStyle;
                    targetCell.SetCellType(sourceCell.CellType);
                }
                //CopyRow(sourceRow, targetRow);

                //Util.CopyRow(sheet, sourceRow, targetRow);
            }

                        HSSFRow firstTargetRow = (HSSFRow)sheet.GetRow(InsertRows);
            HSSFCell firstSourceCell = null;
            HSSFCell firstTargetCell = null;

            for (int m = OldRows.FirstCellNum; m < OldRows.LastCellNum; m++)
            {
                firstSourceCell = (HSSFCell)OldRows.GetCell(m);
                if (firstSourceCell == null)
                    continue;
                firstTargetCell = (HSSFCell)firstTargetRow.CreateCell(m);

                firstTargetCell.Encoding = firstSourceCell.Encoding;
                firstTargetCell.CellStyle = firstSourceCell.CellStyle;
                firstTargetCell.SetCellType(firstSourceCell.CellType);
            }
            #endregion
        }
        /// <summary>
        /// 单元格样式
        /// </summary>
        /// <param name="workbook">工作表</param>
        /// <param name="fontStyleName">字体名称</param>
        /// <param name="fontHeight">字体大小</param>
        /// <param name="isBold">是否加粗</param>
        ///  <param name="isBorder">是否添加边框</param>
        /// <returns>字体</returns>
        public HSSFCellStyle setCellStyle(HSSFWorkbook workbook, string fontStyleName, short fontHeight, bool isBold, bool isBorder)
        {
            HSSFCellStyle fCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont ffont = (HSSFFont)workbook.CreateFont();
            ffont.FontName = fontStyleName;     //字体名称，默认宋体
            ffont.FontHeightInPoints = fontHeight;  //字体大小
            if (isBold)
            {                             //加粗字体
                ffont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
            }
            fCellStyle.SetFont(ffont);
            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐  

            fCellStyle.WrapText = true;//自动换行
            //设置当一个边框
            if (isBorder)
            {
                fCellStyle.BorderBottom = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
                fCellStyle.BorderLeft = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
                fCellStyle.BorderRight = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
                fCellStyle.BorderTop = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
                fCellStyle.LeftBorderColor = HSSFColor.BLACK.index;
                fCellStyle.RightBorderColor = HSSFColor.BLACK.index;
                fCellStyle.TopBorderColor = HSSFColor.BLACK.index;
                fCellStyle.BottomBorderColor = HSSFColor.BLACK.index;
            }


            return fCellStyle;
        }


    }
}