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
    public partial class UserViewManage : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = bus.UserViewSelects("UserView_Selects", "*", "").Tables[0];
                foreach (DataColumn dc in dt.Columns)
                {
                    ListItem li = new ListItem(dc.ColumnName, dc.ColumnName);
                    DLlie.Items.Add(li);
                }
            }
        }
        protected void CBlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.CBlist1.Items.Count; i++)
            //{
            //    if (this.CBlist1.Items[i].Selected == true)
            //    {

            //        var c = CBlist1.Items[i].Value;
            //    }
            //}
        }


        public void ExportToExcel(System.Web.UI.Page page, GridView excel, string fileName)
        {
            try
            {


                //foreach (GridViewRow row in excel.Rows)
                //{
                //    for (int i = 0; i < row.Cells.Count; i++)
                //    {
                //        excel.HeaderRow.Cells[i].BackColor = System.Drawing.Color.Yellow;
                //    }
                //}
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
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void Button12_Click(object sender, EventArgs e)
        {

            string Selects = Text1.Value;
            string Wheres = Text2.Value;
            DataTable dt = bus.UserViewSelects("UserView_Selects", Selects, Wheres).Tables[0];
            string strExcelName = "MyExcel";
            strExcelName = strExcelName.Replace(@"/", "");
            DataTableToExcel(dt, strExcelName);

        }
        public static void DataTableToExcel(System.Data.DataTable dtData, String FileName)
        {

            GridView dgExport = null;

            HttpContext curContext = HttpContext.Current;

            StringWriter strWriter = null;

            HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {

                HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8);

                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");

                curContext.Response.ContentType = "application/vnd.ms-excel";

                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");

                curContext.Response.Charset = "GB2312";

                strWriter = new StringWriter();

                htmlWriter = new HtmlTextWriter(strWriter);

                dgExport = new GridView();

                dgExport.RowDataBound += (GridViewFormat); //在GridView绑定数据时，将数据格式化

                dgExport.DataSource = dtData.DefaultView;

                dgExport.AllowPaging = false;

                dgExport.DataBind();

                dgExport.RenderControl(htmlWriter);

                curContext.Response.Write(strWriter.ToString());

                curContext.Response.End();

            }

        }

        protected static void GridViewFormat(object sender, GridViewRowEventArgs e)
        {

            //1）  文本：vnd.ms-excel.numberformat:@

            //2）  日期：vnd.ms-excel.numberformat:yyyy/mm/dd

            //3）  数字：vnd.ms-excel.numberformat:#,##0.00

            //4）  货币：vnd.ms-excel.numberformat:￥#,##0.00

            //5）  百分比：vnd.ms-excel.numberformat: #0.00%

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    e.Row.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");

                }

            }

        }

    }
}