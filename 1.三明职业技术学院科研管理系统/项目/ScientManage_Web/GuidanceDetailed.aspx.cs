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
    public partial class GuidanceDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int GuidanceId;
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
                if (Request.QueryString["GuidanceId"] != null)
                {
                    try
                    {
                        GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByGuidanceId("Guidance_SelectByGuidanceId", GuidanceId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();                   
                    LGuidanceName.Text = dt.Tables[0].Rows[0]["GuidanceName"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LGuidanceDate.Text = dt.Tables[0].Rows[0]["GuidanceDate"].ToString();
                    LDCategory.Text = dt.Tables[0].Rows[0]["DCateGory"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();

                    LGuidanceValue.Text = dt.Tables[0].Rows[0]["GuidanceValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable Partdt = bus.SelectByGuidanceId("GuidancePartner_SelectByGuidanceId", GuidanceId).Tables[0];
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
                DataSet dy = bus.SelectByGuidanceId("GuidanceExamine_Select", GuidanceId);
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
            GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
            DataSet dy = bus.SelectByGuidanceId("GuidanceExamine_Select", GuidanceId);
            DataSet dt = bus.SelectByGuidanceId("Guidance_SelectByGuidanceId", GuidanceId);
            UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
            string TempletFileName = Server.MapPath("File/Template/Guidance.xls");
            //导出文件  
            string ReportFileName = Server.MapPath("out.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet ws = (HSSFSheet)hssfworkbook.GetSheet("Sheet1");
            //添加或修改WorkSheet里的数据  


            ws.GetRow(1).GetCell(1).SetCellValue(LGuidanceName.Text);
            ws.GetRow(2).GetCell(1).SetCellValue(LUserName.Text);
            ws.GetRow(2).GetCell(3).SetCellValue(LUserJob.Text);
            ws.GetRow(2).GetCell(5).SetCellValue(LUserPost.Text);
            ws.GetRow(3).GetCell(1).SetCellValue(LDCategory.Text);
            ws.GetRow(3).GetCell(4).SetCellValue(LDLevel.Text);
            ws.GetRow(4).GetCell(1).SetCellValue(LTransferStatus.Text);
            ws.GetRow(4).GetCell(4).SetCellValue(LGuidanceValue.Text);
            ws.GetRow(5).GetCell(1).SetCellValue(LPartner.Text);
            ws.GetRow(12).GetCell(1).SetCellValue(LRemarks.Text);
            if (dy.Tables[0].Rows.Count > 0)
            {
                ws.GetRow(6).GetCell(1).SetCellValue(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                ws.GetRow(7).GetCell(2).SetCellValue(dy.Tables[0].Rows[0]["UserName"].ToString());
                ws.GetRow(7).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(7).GetCell(6).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
            }
            if (dy.Tables[0].Rows.Count > 1)
            {
                ws.GetRow(8).GetCell(1).SetCellValue(dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
                ws.GetRow(9).GetCell(2).SetCellValue(dy.Tables[0].Rows[1]["UserName"].ToString());
                ws.GetRow(9).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(9).GetCell(6).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
            }
            if (dy.Tables[0].Rows.Count > 2)
            {
                ws.GetRow(10).GetCell(1).SetCellValue(dy.Tables[0].Rows[2]["ExamineOpinion"].ToString());
                ws.GetRow(11).GetCell(2).SetCellValue(dy.Tables[0].Rows[2]["UserName"].ToString());
                ws.GetRow(11).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                ws.GetRow(11).GetCell(4).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());
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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("教学质量工程.xls"));
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