using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Manage
{
    public partial class JobExamManage : System.Web.UI.Page
    {
        Recruitment_Data.MGetData bus = new Recruitment_Data.MGetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string UserCardId;
        int JobMangeId;
        string Number;

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

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            string Sort = DSort.SelectedValue;
            string Years = txtYears.Text.Trim();
            string JobName = txtJobName.Text.Trim();
            string SubjectName = DSubjectName.SelectedValue;
            string Culture = DCulture.SelectedValue;
            string Political = DPolitical.SelectedValue;
            string Recruitment = DRecruitment.SelectedValue;
            string Gender = DGender.SelectedValue;
            string Should = DShould.SelectedValue;
            string Nation = DNation.SelectedValue;
            string Degree = DDegree.SelectedValue;
            string Position = DPosition.SelectedValue;
            string Education = DEducation.SelectedValue;
            string Age = txtAge.Text.Trim();
            string Profession = txtProfession.Text.Trim();

            DataSet dy = bus.JobMange_Selects("JobGradeManage_Selects", JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort, Years);

            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            string i = e.CommandArgument.ToString();
            Response.Redirect("ExamInfoManage.aspx?JobMangeId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }


        protected void Button10_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            jianbiao();
        }
        public void jianbiao()
        {
            string fileName = "MyExcel.xls";
            string ReportFileName = Server.MapPath("out.xls");
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");  //获取工作表
                                                                                //DataSet ds = bus.SelectByNumber("CandidatesInfo_SelectByNumber", Number);
            string Sort = DSort.SelectedValue;
            string Years = txtYears.Text.Trim();
            string JobName = txtJobName.Text.Trim();
            string SubjectName = DSubjectName.SelectedValue;
            string Culture = DCulture.SelectedValue;
            string Political = DPolitical.SelectedValue;
            string Recruitment = DRecruitment.SelectedValue;
            string Gender = DGender.SelectedValue;
            string Should = DShould.SelectedValue;
            string Nation = DNation.SelectedValue;
            string Degree = DDegree.SelectedValue;
            string Position = DPosition.SelectedValue;
            string Education = DEducation.SelectedValue;
            string Age = txtAge.Text.Trim();
            string Profession = txtProfession.Text.Trim();


            System.Data.DataTable dy1 = bus.JobMange_Selects("JobSManage_Selects", JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort, Years).Tables[0];



            #region 表格中填入数据
            int RowCount = dy1.Rows.Count + 1;
            int ColumnsCount = dy1.Columns.Count;
            HSSFCellStyle style = setCellStyle(hssfworkbook, "宋体", 12, false, true);
            for (int i = 0; i < RowCount; i++)
            {
                mySheet.CreateRow(i);
                for (int j = 0; j < ColumnsCount; j++)
                {
                    mySheet.GetRow(i).CreateCell(j).CellStyle = style;  //加边框
                }
            }

            if (ColumnsCount > 0)
            {
                int columnNum = 0;
                columnNum = dy1.Columns.Count;
                for (int i = 0; i < dy1.Columns.Count; i++)
                {
                    mySheet.GetRow(0).GetCell(i).SetCellValue(dy1.Columns[i].ColumnName.ToString());
                }
            }
            if (RowCount > 0)
            {
                for (int i = 1; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        mySheet.GetRow(i).GetCell(j).SetCellValue(dy1.Rows[i - 1][j].ToString());   //对应单元格数据
                    }
                }
            }

            #endregion

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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fileName));
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

        protected void dataOfYear_EditCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void dataOfYear_DeleteCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}