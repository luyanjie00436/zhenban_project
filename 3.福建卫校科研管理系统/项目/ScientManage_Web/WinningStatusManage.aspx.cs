using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class WinningStatusManage : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));

                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WinningManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable dt = bus.SelectByRankId("Rank_SelectByRankId", RankId).Tables[0];
                if (dt.Rows[0]["RBL2"].ToString() == "是")
                {
                    DataSet department = bus.Select("Department_Select");
                    foreach (DataRow dr in department.Tables[0].Rows)
                    {
                        ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                        DlDepartment.Items.Add(li);
                    }
                }
                else
                {
                    dt = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    ListItem li = new ListItem(dt.Rows[0]["DepartmentName"].ToString(), dt.Rows[0]["DepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                DataSet AppplyYear = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in AppplyYear.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DLApplyYear.Items.Add(li);
                }

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void gvExcel_RowDataBound(object sender, GridViewRowEventArgs e)
        { }
        public override void VerifyRenderingInServerForm(Control control)
        { }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string strExcelName = "MyExcel.xls";
            strExcelName = strExcelName.Replace(@"/", "");

            ExportToExcel(strExcelName);
        }
        public void ExportToExcel(string ExcelName) {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ReportFileName = Server.MapPath("out.xls");
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();//打开工作薄
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");  //获取工作表               
            #region 获取数据源
            DataTable dy1 = SelectBD();
            #endregion
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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(ExcelName));
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

       /* public void ExportToExcel(System.Web.UI.Page page, GridView excel, string fileName)
        {
            try
            {


                foreach (GridViewRow row in excel.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        excel.HeaderRow.Cells[i].BackColor = System.Drawing.Color.Yellow;
                    }
                }
                excel.Font.Size = 10;
                excel.AlternatingRowStyle.BackColor = System.Drawing.Color.LightCyan;
                excel.RowStyle.Height = 25;

                page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                page.Response.Charset = "utf-8";
                page.Response.ContentType = "application/vnd.ms-excel";
                page.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
                excel.Page.EnableViewState = false;
                excel.Visible = true;
                excel.HeaderStyle.Reset();
                excel.AlternatingRowStyle.Reset();

                System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                excel.RenderControl(oHtmlTextWriter);
                page.Response.Write(oStringWriter.ToString());
                page.Response.End();

                excel.DataSource = null;
                excel.Visible = false;
            }
            catch (Exception e)
            {

            }
        }
        * 
        * */
        public void dataGriviewBD()
        {
            string UserName = txtUserName.Text.Trim().ToString();
            string WinningName = txtWinningName.Text.Trim();
            string WinningForm = txtWinningForm.Text.Trim();
            string DepartmentId = DlDepartment.SelectedItem.Text;

            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            string WinningYear = DLApplyYear.SelectedItem.Text;
            if (WinningYear == "选择年份")
            {
                WinningYear = "";
            }
            try
            {
                Year = Convert.ToInt32(seYear);
            }
            catch (Exception)
            {

                Year = 0;
            }
            try
            {
                Month = Convert.ToInt32(seMonth);
            }
            catch (Exception)
            {

                Month = 0;
            }
            string Status = DlStatus.SelectedItem.Text;
            if (Status == "审批状态")
            {
                Status = "";
            }
            DataTable dt = bus.SelectsWinning("Winning_Selects", UserName, DepartmentId, Year, Month, Status, WinningName, WinningForm, WinningYear).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            gvExcel.DataMember = dt.TableName;
            gvExcel.DataSource = dt;
            gvExcel.DataBind();

        }

        public DataTable SelectBD(){
             string UserName = txtUserName.Text.Trim().ToString();
            string WinningName = txtWinningName.Text.Trim();
            string WinningForm = txtWinningForm.Text.Trim();
            string DepartmentId = DlDepartment.SelectedItem.Text;

            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            string WinningYear = DLApplyYear.SelectedItem.Text;
            if (WinningYear == "选择年份")
            {
                WinningYear = "";
            }
            try
            {
                Year = Convert.ToInt32(seYear);
            }
            catch (Exception)
            {

                Year = 0;
            }
            try
            {
                Month = Convert.ToInt32(seMonth);
            }
            catch (Exception)
            {

                Month = 0;
            }
            string Status = DlStatus.SelectedItem.Text;
            if (Status == "审批状态")
            {
                Status = "";
            }
            return bus.SelectsWinning("Winning_Selects", UserName, DepartmentId, Year, Month, Status, WinningName, WinningForm, WinningYear).Tables[0];
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("WinningStatusModify.aspx?WinningId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("WinningManage.aspx");
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
            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中对齐  
            fCellStyle.WrapText = true;         //自动换行
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