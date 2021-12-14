using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.Util;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System;
namespace ScientManage_Web
{
    public partial class T_AssessDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int ApplyYearId;
        protected string MenuStr = "";
        DataSet dy1, dy2, dy3, dy4, dy5, dy6, dy7, dy8,dy9;
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
                dy1 = bus.SelectByApplyUserCardId("T_Teaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy1.Tables[0].Rows.Count < 2)
                {
                    dy1.Tables[0].Rows.Add(dy1.Tables[0].NewRow());
                }

                dy2 = bus.SelectByApplyUserCardId("Teaching_Team_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy2.Tables[0].Rows.Count < 2)
                {
                    dy2.Tables[0].Rows.Add(dy2.Tables[0].NewRow());
                }

                dy3 = bus.SelectByApplyUserCardId("P_construction_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy3.Tables[0].Rows.Count < 2)
                {
                    dy3.Tables[0].Rows.Add(dy3.Tables[0].NewRow());
                }

                dy4 = bus.SelectByApplyUserCardId("C_construction_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy4.Tables[0].Rows.Count < 2)
                {
                    dy4.Tables[0].Rows.Add(dy4.Tables[0].NewRow());
                }

                dy5 = bus.SelectByApplyUserCardId("C_winners_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy5.Tables[0].Rows.Count < 2)
                {
                    dy5.Tables[0].Rows.Add(dy5.Tables[0].NewRow());
                }

                dy6 = bus.SelectByApplyUserCardId("Results_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy6.Tables[0].Rows.Count < 2)
                {
                    dy6.Tables[0].Rows.Add(dy6.Tables[0].NewRow());
                }
                dy8 = bus.SelectByApplyUserCardId("Special_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy8.Tables[0].Rows.Count < 2)
                {
                    dy8.Tables[0].Rows.Add(dy8.Tables[0].NewRow());
                }
                dy9 = bus.SelectByApplyUserCardId("TeachToTeaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy9.Tables[0].Rows.Count < 2)
                {
                    dy9.Tables[0].Rows.Add(dy9.Tables[0].NewRow());
                }

                dy7 = bus.SelectByApplyUserCardId("AssessValue_SelectByApplyYearId", UserCardId, ApplyYearId);
                #endregion
                #region
                StringBuilder text = new StringBuilder();
                int RowCount = 8 + dy1.Tables[0].Rows.Count + dy1.Tables[0].Rows.Count + dy3.Tables[0].Rows.Count + dy4.Tables[0].Rows.Count + dy5.Tables[0].Rows.Count + dy6.Tables[0].Rows.Count+ dy8.Tables[0].Rows.Count+ dy9.Tables[0].Rows.Count;
                text.Append("<table id=\"IsTabel\" runat=\"server\" cellspacing=\"0\" cellpadding=\"0\" >");
                text.Append("<tr><td colspan=\"14\"   style=\"border:0px;\">" + dy7.Tables[0].Rows[0]["年份"].ToString() + "年度福建卫生职业技术学院教学建设项目工作量核算表" + "</td></tr>");

                text.Append("<tr><td rowspan=\"" + RowCount.ToString() + "\"  style=\" border-left:1px solid #000000;   border-bottom:1px solid #000000;   border-right:1px solid #000000; width:13px;\">教学建设项目工作量</td><td rowspan=\"" + (dy1.Tables[0].Rows.Count + 1).ToString() + "\">教材建设</td><td>书名</td> <td >出版类别</td> <td>出版社</td> <td>出版时间</td><td>版次</td><td>主编字数</td><td>主编名次</td><td>基础分得分</td><td>参编着编写字数</td><td>字数配套得分</td><td>工作量分值</td><td>备注</td> </tr>");

                for (int i = 0; i < dy1.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr> <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["T_TeachingName"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["CateGory"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Press"].ToString() + "</td> <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Time"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Edition"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Compiledwords"].ToString() + "</td> <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["EditorRanking"].ToString() + "</td> <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Score"].ToString() + "</td>  <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Reference"].ToString() + "</td> <td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Totalscore"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td  class=\"td2\"  >" + dy1.Tables[0].Rows[i]["Remarks"].ToString() + "</td>   </tr>");
                }

                text.Append("<tr> <td rowspan=\"" + (dy2.Tables[0].Rows.Count + 1).ToString() + "\">教学团队建设</td><td>项目名称</td><td>级别</td><td>负责人</td><td>完成情况</td><td>项目起止时间</td><td>项目总分值</td><td>项目总分值说明</td><td>本年度项目总分值</td> <td colspan=\"2\">本年度项目总分值说明</td><td>本年度个人工作量分值</td><td>备注</td></tr>");
                for (int i = 0; i < dy2.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr> <td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Teaching_TeamName"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Leve"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Principal"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Completion"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["StartEndDate"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Total_Project"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Description_Project"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Annual"].ToString() + "</td><td  class=\"td2\"  colspan=\"2\">" + dy2.Tables[0].Rows[i]["Description_year"].ToString() + "</td><td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td  class=\"td2\" >" + dy2.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td rowspan=\"" + (dy3.Tables[0].Rows.Count + 1).ToString() + "\">专业建设</td><td>项目名称</td><td>级别</td><td>负责人</td><td>完成情况</td><td>项目起止时间</td><td>项目总分值</td><td>项目总分值说明</td><td>本年度项目总分值</td><td colspan=\"2\">本年度项目总分值说明</td><td>本年度个人工作量分值</td><td>备注</td></tr>");
                for (int i = 0; i < dy3.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["P_constructionName"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Leve"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Principal"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Completion"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["StartEndDate"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Total_Project"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Description_Project"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Annual"].ToString() + "</td><td  class=\"td2\"  colspan=\"2\">" + dy3.Tables[0].Rows[i]["Description_year"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td  class=\"td2\" >" + dy3.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr> <td rowspan=\"" + (dy4.Tables[0].Rows.Count + 1).ToString() + "\">课程建设</td><td>项目名称</td><td>级别</td><td>负责人</td><td>完成情况</td><td>项目起止时间</td><td>项目总分值</td><td>项目总分值说明</td><td>本年度项目总分值</td><td colspan=\"2\">本年度项目总分值说明</td><td>本年度个人工作量分值</td><td>备注</td></tr>");
                for (int i = 0; i < dy4.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["C_constructionName"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Leve"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Principal"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Completion"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["StartEndDate"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Total_Project"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Description_Project"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Annual"].ToString() + "</td><td  class=\"td2\"  colspan=\"2\">" + dy4.Tables[0].Rows[i]["Description_year"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td  class=\"td2\" >" + dy4.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");

                }

                text.Append("<tr> <td rowspan=\"" + (dy5.Tables[0].Rows.Count + 1).ToString() + "\" >竞赛获奖</td><td>获奖项目名称</td><td colspan=\"2\">获奖项目级别</td><td>获奖时间</td><td>获奖等级</td><td>组织单位</td><td  colspan=\"2\">项目总分值</td><td>项目总分值说明</td><td>排名</td><td>个人工作量分值</td><td>备注</td></tr>");

                for (int i = 0; i < dy5.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["C_winnersName"].ToString() + "</td><td  class=\"td2\"  colspan=\"2\">" + dy5.Tables[0].Rows[i]["Leve"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["Time"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["Award_level"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["Organizational_Unit"].ToString() + "</td><td  class=\"td2\"   colspan=\"2\">" + dy5.Tables[0].Rows[i]["C_winnersTotal"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["C_winnersDescription"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["Ranking"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td  class=\"td2\" >" + dy5.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td rowspan=\"" + (dy6.Tables[0].Rows.Count + 1).ToString() + "\">教学成果获奖</td><td>项目名称</td><td>类别</td><td>级别</td><td>负责人</td><td>颁奖单位</td><td>获奖时间</td><td>完成情况</td><td>项目总分值</td><td colspan=\"2\">项目总分值说明</td><td>本年度个人工作量分值</td><td>备注</td></tr>");

                for (int i = 0; i < dy6.Tables[0].Rows.Count; i++)
                {
                    //text.Append("<tr><td colspan=\"5\">" + dy6.Tables[0].Rows[i]["GuidanceName"].ToString() + "</td> <td colspan=\"4\">" + dy6.Tables[0].Rows[i]["GuidanceLevel"].ToString() + "</td> <td>" + dy6.Tables[0].Rows[i][""].ToString() + "</td> <td>" + dy6.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td>" + dy6.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                    text.Append("<tr><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["ResultsName"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Category"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Awardlevel"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["ResultsPrincipal"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Awarding_unit"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Time"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Completion"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["ResultsTotal"].ToString() + "</td><td  class=\"td2\"  colspan=\"2\">" + dy6.Tables[0].Rows[i]["ResultsDescription"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td  class=\"td2\" >" + dy6.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");

                }
                text.Append("<tr><td rowspan=\"" + (dy8.Tables[0].Rows.Count + 1).ToString() + "\">专项分值</td><td colspan=\"10\">内容</td><td>分值</td><td>备注</td></tr>");

                for (int i = 0; i < dy8.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\" colspan=\"10\">" + dy8.Tables[0].Rows[i]["ContentName"].ToString() + "</td><td  class=\"td2\" >" + dy8.Tables[0].Rows[i]["Score"].ToString() + "</td><td  class=\"td2\" >" + dy8.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");

                }
                text.Append("<tr><td rowspan=\"" + (dy9.Tables[0].Rows.Count + 1).ToString() + "\">教学工作量转化教研分</td><td colspan=\"10\">转分课程数</td><td>转分总分</td><td>备注</td></tr>");

                for (int i = 0; i < dy9.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td  class=\"td2\" colspan=\"10\">" + dy9.Tables[0].Rows[i]["Quantity"].ToString() + "</td><td  class=\"td2\" >" + dy9.Tables[0].Rows[i]["TotalScore"].ToString() + "</td><td  class=\"td2\" >" + dy9.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");

                }

                text.Append("<tr><td colspan=\"12\"  style=\" border-left:1px solid #000000;   border-bottom:1px solid #000000;   border-right:1px solid #000000;\">已完成教学建设工作量总分值</td><td >" + dy7.Tables[0].Rows[0]["实际完成教学建设工作量"].ToString() + "</td><td ></td></tr>");

                text.Append("</table>");
                MenuStr = text.ToString();
                #endregion
            }
        }
        public void jianbiao()
        {
            UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
            ApplyYearId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyYearId"], "asdfasdf"));
     
            string ReportFileName = Server.MapPath("out.xls");
     
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");  //获取工作表

        
            #region 获取源数据内数据
            dy1 = bus.SelectByApplyUserCardId("T_Teaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy1.Tables[0].Rows.Count < 2)
            {
                dy1.Tables[0].Rows.Add(dy1.Tables[0].NewRow());
            }

            dy2 = bus.SelectByApplyUserCardId("Teaching_Team_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy2.Tables[0].Rows.Count < 2)
            {
                dy2.Tables[0].Rows.Add(dy2.Tables[0].NewRow());
            }
            dy3 = bus.SelectByApplyUserCardId("P_construction_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy3.Tables[0].Rows.Count < 2)
            {
                dy3.Tables[0].Rows.Add(dy3.Tables[0].NewRow());
            }


            dy4 = bus.SelectByApplyUserCardId("C_construction_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy4.Tables[0].Rows.Count < 2)
            {
                dy4.Tables[0].Rows.Add(dy4.Tables[0].NewRow());
            }

            dy5 = bus.SelectByApplyUserCardId("C_winners_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy5.Tables[0].Rows.Count < 2)
            {
                dy5.Tables[0].Rows.Add(dy5.Tables[0].NewRow());
            }

            dy6 = bus.SelectByApplyUserCardId("Results_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy6.Tables[0].Rows.Count < 2)
            {
                dy6.Tables[0].Rows.Add(dy6.Tables[0].NewRow());
            }

            dy8 = bus.SelectByApplyUserCardId("Special_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy8.Tables[0].Rows.Count < 2)
            {
                dy8.Tables[0].Rows.Add(dy8.Tables[0].NewRow());
            }

            dy9 = bus.SelectByApplyUserCardId("TeachToTeaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
            while (dy9.Tables[0].Rows.Count < 2)
            {
                dy9.Tables[0].Rows.Add(dy9.Tables[0].NewRow());
            }

            dy7 = bus.SelectByApplyUserCardId("AssessValue_SelectByApplyYearId", UserCardId, ApplyYearId);
            #endregion
            #region 第一行
            SetCellRangeAddress(mySheet, 0, 0, 0, 13);
            mySheet.CreateRow(0).CreateCell(0).SetCellValue(dy7.Tables[0].Rows[0]["年份"].ToString() + "年度福建卫生职业技术学院教研工作量核算表");//插入年份


            HSSFCellStyle style6 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();


            style6.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style6.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style6.WrapText = true;//自动换行

            NPOI.SS.UserModel.Font f = hssfworkbook.CreateFont();  //定义文字
            f.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD; //文字加粗
            f.FontHeightInPoints = 16;  //文字大小

            f.FontName = "Times New Roman"; //字体
            style6.SetFont(f);
            mySheet.GetRow(0).GetCell(0).CellStyle = style6;
            #endregion
            //单元格样式
            HSSFCellStyle style7 = setCellStyle(hssfworkbook, "宋体", 10, false, true);


            int RowCount = 8 + dy1.Tables[0].Rows.Count + dy2.Tables[0].Rows.Count + dy3.Tables[0].Rows.Count + dy4.Tables[0].Rows.Count + dy5.Tables[0].Rows.Count + dy6.Tables[0].Rows.Count + dy8.Tables[0].Rows.Count + dy9.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, 1, 1 + RowCount, 0, 0);

            for (int i = 0; i <= RowCount; i++)
            {
                mySheet.CreateRow(1 + i).CreateCell(0).CellStyle = style7;  //加边框
            }
            mySheet.GetRow(1).GetCell(0).SetCellValue("教n学n建n设n项n目n工n作n量".Replace("n", Environment.NewLine));
          
            #region 设置行高列宽
            mySheet.SetColumnWidth(0, 865);
            mySheet.SetColumnWidth(1, 1697);
            mySheet.SetColumnWidth(2, 13 * 256);
            mySheet.SetColumnWidth(3, 2112);
            mySheet.SetColumnWidth(4, 1953);
            mySheet.SetColumnWidth(5, 2112);
            mySheet.SetColumnWidth(6, 2880);
            mySheet.SetColumnWidth(7, 10 * 256);
            mySheet.SetColumnWidth(8, 2273);
            mySheet.SetColumnWidth(9, 2688);
            mySheet.SetColumnWidth(10, 3392);
            mySheet.SetColumnWidth(11, 1633);
            mySheet.SetColumnWidth(12, 2368);
            mySheet.SetColumnWidth(13, 2017);
            mySheet.GetRow(0).Height = 2 * 165;
            #endregion

            #region 教材建设
            int StartRow = 1, EndRow = StartRow + 1 + dy1.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("教n材n建n设".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("书名");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("出版类别");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("出版社");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("出版时间");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("版次");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("主编字数");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("主编名次");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("主编基础分得分（基础分*系数）");
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("参编着编写字数");
            mySheet.GetRow(StartRow).GetCell(11).SetCellValue("字数配套得分");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");
            for (int i = 0; i < dy1.Tables[0].Rows.Count; i++)
            {

                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy1.Tables[0].Rows[i]["T_TeachingName"].ToString());//书名
                mySheet.GetRow(StartRow + 1 + i).GetCell(3).SetCellValue(dy1.Tables[0].Rows[i]["CateGory"].ToString());//出版类别
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy1.Tables[0].Rows[i]["Press"].ToString());//出版社
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy1.Tables[0].Rows[i]["Time"].ToString());//出版时间
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy1.Tables[0].Rows[i]["Edition"].ToString());//版次
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy1.Tables[0].Rows[i]["Compiledwords"].ToString());//主编字数
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy1.Tables[0].Rows[i]["EditorRanking"].ToString());//主编名次
                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy1.Tables[0].Rows[i]["Score"].ToString());//主编基础分得分（基础分*系数）
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy1.Tables[0].Rows[i]["Reference"].ToString());//参编着编写字数
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy1.Tables[0].Rows[i]["Totalscore"].ToString());//字数配套得分
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy1.Tables[0].Rows[i]["PartnerValue"].ToString());//工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy1.Tables[0].Rows[i]["Remarks"].ToString());//备注
            }

            #endregion
            #region 教材团队建设
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy2.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("教n学n团n队n建n设".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("项目名称");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("级别");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("负责人");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("完成情况");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("项目起止时间");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("项目总分值");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("目总分值说明");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("本年度项目总分值");
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("本年度项目总分值说明");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 10, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("本年度个人工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy2.Tables[0].Rows.Count; i++)
            {

                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy2.Tables[0].Rows[i]["Teaching_TeamName"].ToString());//项目名称
                mySheet.GetRow(StartRow + 1 + i).GetCell(3).SetCellValue(dy2.Tables[0].Rows[i]["Leve"].ToString());//级别
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy2.Tables[0].Rows[i]["Principal"].ToString());//负责人
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy2.Tables[0].Rows[i]["Completion"].ToString());//完成情况
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy2.Tables[0].Rows[i]["StartEndDate"].ToString());//项目起止时间
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy2.Tables[0].Rows[i]["Total_Project"].ToString());//项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy2.Tables[0].Rows[i]["Description_Project"].ToString());//项目总分值说明
                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy2.Tables[0].Rows[i]["Annual"].ToString());//本年度项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy2.Tables[0].Rows[i]["Description_year"].ToString());//本年度项目总分值说明
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 10, 11);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy2.Tables[0].Rows[i]["Teaching_TeamValue"].ToString());//本年度个人工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy2.Tables[0].Rows[i]["Remarks"].ToString());//备注    

            }
            #endregion
            #region 专业建设
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy3.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("专n业n建n设".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("项目名称");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("级别");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("负责人");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("完成情况");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("项目起止时间");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("项目总分值");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("目总分值说明");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("本年度项目总分值");
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("本年度项目总分值说明");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 10, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("本年度个人工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy3.Tables[0].Rows.Count; i++)
            {

                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy3.Tables[0].Rows[i]["P_constructionName"].ToString());//项目名称
                mySheet.GetRow(StartRow + 1 + i).GetCell(3).SetCellValue(dy3.Tables[0].Rows[i]["Leve"].ToString());//级别
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy3.Tables[0].Rows[i]["Principal"].ToString());//负责人
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy3.Tables[0].Rows[i]["Completion"].ToString());//完成情况
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy3.Tables[0].Rows[i]["StartEndDate"].ToString());//项目起止时间
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy3.Tables[0].Rows[i]["Total_Project"].ToString());//项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy3.Tables[0].Rows[i]["Description_Project"].ToString());//项目总分值说明
                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy3.Tables[0].Rows[i]["Annual"].ToString());//本年度项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy3.Tables[0].Rows[i]["Description_year"].ToString());//本年度项目总分值说明
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 10, 11);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy3.Tables[0].Rows[i]["PartnerValue"].ToString());//本年度个人工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy3.Tables[0].Rows[i]["Remarks"].ToString());//备注    

            }
            #endregion
            #region 课程建设
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy4.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("课n程n建n设".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("项目名称");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("级别");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("负责人");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("完成情况");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("项目起止时间");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("项目总分值");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("目总分值说明");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("本年度项目总分值");
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("本年度项目总分值说明");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 10, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("本年度个人工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy4.Tables[0].Rows.Count; i++)
            {
                string s = dy4.Tables[0].Rows[i]["C_constructionName"].ToString();
                
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy4.Tables[0].Rows[i]["C_constructionName"].ToString());//项目名称
               
                mySheet.GetRow(StartRow + 1 + i).GetCell(3).SetCellValue(dy4.Tables[0].Rows[i]["Leve"].ToString());//级别
                mySheet.GetRow(StartRow + 1 + i).GetCell(4).SetCellValue(dy4.Tables[0].Rows[i]["Principal"].ToString());//负责人
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy4.Tables[0].Rows[i]["Completion"].ToString());//完成情况
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy4.Tables[0].Rows[i]["StartEndDate"].ToString());//项目起止时间
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy4.Tables[0].Rows[i]["Total_Project"].ToString());//项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy4.Tables[0].Rows[i]["Description_Project"].ToString());//项目总分值说明
                mySheet.GetRow(StartRow + 1 + i).GetCell(9).SetCellValue(dy4.Tables[0].Rows[i]["Annual"].ToString());//本年度项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy4.Tables[0].Rows[i]["Description_year"].ToString());//本年度项目总分值说明
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 10, 11);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy4.Tables[0].Rows[i]["PartnerValue"].ToString());//本年度个人工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy4.Tables[0].Rows[i]["Remarks"].ToString());//备注    
                int rows = StartRow + 1 + i;
            }
            #endregion
            #region 竞赛获奖
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy5.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("竞n赛n获n奖".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("获奖项目名称");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("获奖项目级别");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 3, 4);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("获奖时间");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("获奖等级");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("组织单位");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("项目总分值");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 8, 9);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("项目总分值说明");
            mySheet.GetRow(StartRow).GetCell(11).SetCellValue("排名");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("本年度个人工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy5.Tables[0].Rows.Count; i++)
            {

                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy5.Tables[0].Rows[i]["C_winnersName"].ToString());//获奖项目名称		
                mySheet.GetRow(StartRow + 1 + i).GetCell(3).SetCellValue(dy5.Tables[0].Rows[i]["Leve"].ToString());//获奖项目级别
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 3, 4);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(5).SetCellValue(dy5.Tables[0].Rows[i]["Time"].ToString());//获奖时间
                mySheet.GetRow(StartRow + 1 + i).GetCell(6).SetCellValue(dy5.Tables[0].Rows[i]["Award_level"].ToString());//获奖等级
                mySheet.GetRow(StartRow + 1 + i).GetCell(7).SetCellValue(dy5.Tables[0].Rows[i]["Organizational_Unit"].ToString());//组织单位
                mySheet.GetRow(StartRow + 1 + i).GetCell(8).SetCellValue(dy5.Tables[0].Rows[i]["C_winnersTotal"].ToString());//项目总分值
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 8, 9);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy5.Tables[0].Rows[i]["C_winnersDescription"].ToString());//项目总分值说明		
                mySheet.GetRow(StartRow + 1 + i).GetCell(11).SetCellValue(dy5.Tables[0].Rows[i]["Ranking"].ToString());//排名
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy5.Tables[0].Rows[i]["PartnerValue"].ToString());//个人工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy5.Tables[0].Rows[i]["Remarks"].ToString());//排名

            }
            #endregion
            #region 教学成果获奖 
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy6.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("教n学n成n果n获n奖".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("项目名称");
            mySheet.GetRow(StartRow).GetCell(3).SetCellValue("类别");
            mySheet.GetRow(StartRow).GetCell(4).SetCellValue("奖级");
            mySheet.GetRow(StartRow).GetCell(5).SetCellValue("负责人");
            mySheet.GetRow(StartRow).GetCell(6).SetCellValue("颁奖单位");
            mySheet.GetRow(StartRow).GetCell(7).SetCellValue("获奖时间");
            mySheet.GetRow(StartRow).GetCell(8).SetCellValue("完成情况");
            mySheet.GetRow(StartRow).GetCell(9).SetCellValue("项目总分值");
            mySheet.GetRow(StartRow).GetCell(10).SetCellValue("项目总分值说明");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 10, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("个人工作量分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy6.Tables[0].Rows.Count; i++)
            {
                mySheet.GetRow(StartRow + 1+ i).GetCell(2).SetCellValue(dy6.Tables[0].Rows[i]["ResultsName"].ToString());//项目名称
                mySheet.GetRow(StartRow + 1+ i).GetCell(3).SetCellValue(dy6.Tables[0].Rows[i]["Category"].ToString());//类别
                mySheet.GetRow(StartRow + 1+ i).GetCell(4).SetCellValue(dy6.Tables[0].Rows[i]["Awardlevel"].ToString());//奖级
                mySheet.GetRow(StartRow + 1+ i).GetCell(5).SetCellValue(dy6.Tables[0].Rows[i]["ResultsPrincipal"].ToString());//负责人
                mySheet.GetRow(StartRow + 1+ i).GetCell(6).SetCellValue(dy6.Tables[0].Rows[i]["Awarding_unit"].ToString());//颁奖单位
                mySheet.GetRow(StartRow + 1+ i).GetCell(7).SetCellValue(dy6.Tables[0].Rows[i]["Time"].ToString());//获奖时间
                mySheet.GetRow(StartRow + 1+ i).GetCell(8).SetCellValue(dy6.Tables[0].Rows[i]["Completion"].ToString());//完成情况
                mySheet.GetRow(StartRow + 1+ i).GetCell(9).SetCellValue(dy6.Tables[0].Rows[i]["ResultsTotal"].ToString());//项目总分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(10).SetCellValue(dy6.Tables[0].Rows[i]["ResultsDescription"].ToString());//项目总分值说明
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 10, 11);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy6.Tables[0].Rows[i]["ResultsValue"].ToString());//个人工作量分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy6.Tables[0].Rows[i]["Remarks"].ToString());//备注    

            }
            #endregion
            #region 专项分值
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy8.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("专n项n分n值".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("内容");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("分值");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy8.Tables[0].Rows.Count; i++)
            {
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy8.Tables[0].Rows[i]["ContentName"].ToString());//内容
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 11);   //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy8.Tables[0].Rows[i]["Score"].ToString());//分值
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy8.Tables[0].Rows[i]["Remarks"].ToString());//备注    

            }
            #endregion
        
            #region 教学工作量转化教研分
            StartRow = EndRow + 1;
            EndRow = EndRow + 1 + dy9.Tables[0].Rows.Count;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 1, 1);   //合并单元格
            for (int i = StartRow; i <= EndRow; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }

            mySheet.GetRow(StartRow).GetCell(1).SetCellValue("教n学n工n作n量n转n化n教n研n分".Replace("n", Environment.NewLine));
            mySheet.GetRow(StartRow).GetCell(2).SetCellValue("转分课程数");
            SetCellRangeAddress(mySheet, StartRow, StartRow, 2, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue("转分总分");
            mySheet.GetRow(StartRow).GetCell(13).SetCellValue("备注");

            for (int i = 0; i < dy9.Tables[0].Rows.Count; i++)
            {
                mySheet.GetRow(StartRow + 1 + i).GetCell(2).SetCellValue(dy9.Tables[0].Rows[i]["Quantity"].ToString());//转分课程数
                SetCellRangeAddress(mySheet, StartRow + 1 + i, StartRow + 1 + i, 2, 11);    //合并单元格
                mySheet.GetRow(StartRow + 1 + i).GetCell(12).SetCellValue(dy9.Tables[0].Rows[i]["TotalScore"].ToString());//转分总分
                mySheet.GetRow(StartRow + 1 + i).GetCell(13).SetCellValue(dy9.Tables[0].Rows[i]["Remarks"].ToString());//备注    

            }
            #endregion
            StartRow = EndRow + 1;
            EndRow = EndRow + 1;
            
            for (int i = StartRow; i <= EndRow; i++)
            {
                mySheet.CreateRow(i);
                for (int j = 0; j <= 13; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style7; //加边框
                }
            }
            SetCellRangeAddress(mySheet, StartRow, StartRow, 0, 11);   //合并单元格
            mySheet.GetRow(StartRow).GetCell(0).SetCellValue("已完成教学建设工作量总分值");
            mySheet.GetRow(StartRow).GetCell(12).SetCellValue(dy7.Tables[0].Rows[0]["实际完成教学建设工作量"].ToString());

            #region 尾部说明
            StartRow = EndRow + 1;
            EndRow = EndRow + 1;
            SetCellRangeAddress(mySheet, StartRow, EndRow, 0, 13);   //合并单元格
            mySheet.CreateRow(StartRow).CreateCell(0).SetCellValue("填表说明：1.请根据《福建卫生职业技术学院教学建设及科研工作量计算办法》的相关规定填写和审核本科研工作量核算表。\n"
                + "2.课程单元案例和精品课程均为精品开放课程建设项目的部分建设内容，课程单元案例按精品开放课程40%计分，精品课程按精品开放课程50%计分，均参照精品开放课程分二次计分，且不得重复计算。例如：某课程完成了课程单元案例和精品课程建设，其得分为精品开放课程50% 。当其完成精品开放课程建设时，需扣除已得的50%得分，其得分为剩余的50%。以此类推。\n"
                + " 3.工作量分值指项目负责人实际分配给填表教师的分值。");
            HSSFCellStyle style9 = setCellStyle(hssfworkbook, "宋体", 10, false, false);
            mySheet.GetRow(StartRow).GetCell(0).CellStyle = style9;
            #endregion



            System.Data.DataTable dt = new System.Data.DataTable();

            #region 项目流出
            mySheet.ForceFormulaRecalculation = true;

            using (FileStream filess = File.OpenWrite(ReportFileName))
            {
                hssfworkbook.Write(filess);
            }

            //filess.Close();  


            System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("教研工作量.xls"));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
            Response.AddHeader("Content-Length", filet.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载   
            Response.ContentType = "application/ms-excel";
            // 把文件流发送到客户端   
            Response.WriteFile(filet.FullName);
            // 停止页面的执行   

            Response.End();
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            jianbiao();

        }






        //合并单元格
        public static void SetCellRangeAddress(HSSFSheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        //
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
        /// 合作单元格样式
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