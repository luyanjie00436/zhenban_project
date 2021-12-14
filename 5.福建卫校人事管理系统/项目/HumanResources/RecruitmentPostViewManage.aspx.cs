using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RecruitmentPostViewManage : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = bus.UserViewSelects("RecruitmentPostView_Selects", "*", "").Tables[0];
                foreach (DataColumn dc in dt.Columns)
                {
                    ListItem li = new ListItem(dc.ColumnName, dc.ColumnName);
                    DLlie.Items.Add(li);
                }
            }
        }
        protected void CBlist1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button12_Click(object sender, EventArgs e)
        {

            string Selects = Text1.Value;
            string Wheres = Text2.Value;
            DataTable dt = bus.UserViewSelects("RecruitmentPostView_Selects", Selects, Wheres).Tables[0];
            string strExcelName = "MyExcel";
            strExcelName = strExcelName.Replace(@"/", "");
            // DataTableToExcel(dt, strExcelName);

            daochu(dt, strExcelName);

        }
        public void daochu(DataTable dtData, String FileName)
        {
            string ReportFileName = Server.MapPath("out.xls");
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            #region 第一行
            HSSFCellStyle style6 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();


            style6.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style6.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
                                                                                  // style6.WrapText = true;//自动换行

            NPOI.SS.UserModel.Font f = hssfworkbook.CreateFont();  //定义文字
                                                                   //    f.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD; //文字加粗
                                                                   //    f.FontHeightInPoints = 16;  //文字大小

            f.FontName = "宋体"; //字体
            style6.SetFont(f);
            mySheet.CreateRow(0);
            for (int j = 0; j < dtData.Columns.Count; j++)
            {

                mySheet.GetRow(0).CreateCell(j).CellStyle = style6;
                mySheet.AutoSizeColumn(j);
                mySheet.GetRow(0).GetCell(j).SetCellValue(dtData.Columns[j].ColumnName);


            }

            mySheet.GetRow(0).Height = 20 * 26;



            //  mySheet.GetRow(0).GetCell(0).CellStyle = style6;

            #endregion
            #region 数据
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                mySheet.CreateRow(i + 1);
                for (int j = 0; j < dtData.Columns.Count; j++)
                {
                    mySheet.AutoSizeColumn(j);
                    mySheet.GetRow(i + 1).CreateCell(j).CellStyle = style6;
                    mySheet.GetRow(i + 1).GetCell(j).SetCellValue(dtData.Rows[i][j].ToString());
                }
            }

            mySheet.GetRow(0).Height = 20 * 26;
            #endregion

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
    }
}