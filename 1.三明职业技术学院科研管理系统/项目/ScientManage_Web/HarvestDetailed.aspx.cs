using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class HarvestDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int HarvestId;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["HarvestId"] != null)
                {
                    try
                    {
                        HarvestId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["HarvestId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByHarvestId("Harvest_SelectByHarvestId", HarvestId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LDCategory.Text = dt.Tables[0].Rows[0]["DCateGory"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    LHarvestName.Text = dt.Tables[0].Rows[0]["HarvestName"].ToString();
                    LAwardsDate.Text = dt.Tables[0].Rows[0]["AwardsDate"].ToString();
                    LAppraisalLevel.Text = dt.Tables[0].Rows[0]["AppraisalLevel"].ToString();
                    LRemarks.Text= dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LHarvestValue.Text = dt.Tables[0].Rows[0]["HarvestValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable Partdt = bus.SelectByHarvestId("HarvestPartner_SelectByHarvestId", HarvestId).Tables[0];
                if (Partdt.Rows.Count == 0)
                {
                    LPartner.Text = "无";
                }
                else
                {
                    for (int i = 0; i < Partdt.Rows.Count; i++)
                    {
                        if (i == Partdt.Rows.Count - 1)
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")";
                        }
                        else
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")" + ",";
                        }
                    }
                }
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LUserJob.Text = dt1.Rows[0]["JobName"].ToString();
                LUserPost.Text = dt1.Rows[0]["PostName"].ToString();
                DataSet dy = bus.SelectByHarvestId("HarvestExamine_Select", HarvestId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }

            }
        }

        protected void buttom2_Click(object sender, EventArgs e)
        {
            HarvestId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["HarvestId"], "asdfasdf"));
            DataSet dy = bus.SelectByHarvestId("HarvestExamine_Select", HarvestId);
            DataSet dt = bus.SelectByHarvestId("Harvest_SelectByHarvestId", HarvestId);
            UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
            string TempletFileName = Server.MapPath("File/Template/Harvest.xls");
            //导出文件  
            string ReportFileName = Server.MapPath("out.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet ws = (HSSFSheet)hssfworkbook.GetSheet("Sheet1");
            //添加或修改WorkSheet里的数据  


            ws.GetRow(1).GetCell(1).SetCellValue(LHarvestName.Text);
            ws.GetRow(2).GetCell(1).SetCellValue(LUserName.Text);
            ws.GetRow(2).GetCell(3).SetCellValue(LUserJob.Text);
            ws.GetRow(2).GetCell(5).SetCellValue(LUserPost.Text);
            ws.GetRow(3).GetCell(1).SetCellValue(LDCategory.Text);
            ws.GetRow(3).GetCell(3).SetCellValue(LDLevel.Text);
            ws.GetRow(3).GetCell(5).SetCellValue(LHarvestValue.Text);
            ws.GetRow(4).GetCell(1).SetCellValue(LTransferStatus.Text);
            ws.GetRow(4).GetCell(4).SetCellValue(LAppraisalLevel.Text);
            ws.GetRow(5).GetCell(1).SetCellValue(LAwardsDate.Text);
            ws.GetRow(6).GetCell(1).SetCellValue(LPartner.Text);
            ws.GetRow(13).GetCell(1).SetCellValue(LRemarks.Text);
            if (dy.Tables[0].Rows.Count > 0)
            {
                ws.GetRow(7).GetCell(1).SetCellValue(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                ws.GetRow(8).GetCell(2).SetCellValue(dy.Tables[0].Rows[0]["UserName"].ToString());
                ws.GetRow(8).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(8).GetCell(6).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
            }
            if (dy.Tables[0].Rows.Count > 1)
            {
                ws.GetRow(9).GetCell(1).SetCellValue(dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
                ws.GetRow(10).GetCell(2).SetCellValue(dy.Tables[0].Rows[1]["UserName"].ToString());
                ws.GetRow(10).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(10).GetCell(6).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
            }
            if (dy.Tables[0].Rows.Count > 2)
            {
                ws.GetRow(11).GetCell(1).SetCellValue(dy.Tables[0].Rows[2]["ExamineOpinion"].ToString());
                ws.GetRow(12).GetCell(2).SetCellValue(dy.Tables[0].Rows[2]["UserName"].ToString());
                ws.GetRow(12).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(12).GetCell(4).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
            }

            ws.ForceFormulaRecalculation = true;

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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("成果.xls"));
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