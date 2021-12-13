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
    public partial class ActivityDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int ActivityId;
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
                if (Request.QueryString["ActivityId"] != null)
                {
                    try
                    {
                        ActivityId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ActivityId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByActivityId("Activity_SelectByActivityId", ActivityId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    AssociationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                    CompanyName.Text = dt.Tables[0].Rows[0]["CompanyName"].ToString();
                    LDCategory.Text = dt.Tables[0].Rows[0]["DCateGory"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    StartDate.Text = dt.Tables[0].Rows[0]["StartDate"].ToString();
                    EndDate.Text = dt.Tables[0].Rows[0]["EndDate"].ToString();
                    ActivityValue.Text = dt.Tables[0].Rows[0]["ActivityValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable Partdt = bus.SelectByActivityId("ActivityPartner_SelectByActivityId", ActivityId).Tables[0];
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
                DataSet dy = bus.SelectByActivityId("ActivityExamine_Select", ActivityId);
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
            ActivityId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ActivityId"], "asdfasdf"));
            DataSet dy = bus.SelectByActivityId("ActivityExamine_Select", ActivityId);
            DataSet dt = bus.SelectByActivityId("Activity_SelectByActivityId", ActivityId);
            UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
            DataTable dt1 = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId).Tables[0];
            string DepartmentId = dt1.Rows[0]["UserDepartmentId"].ToString();
            DataTable dt2 = bus.SelectByDepartmentId("Department_SelectByDepartmentId", Convert.ToInt32(DepartmentId)).Tables[0];
            string TempletFileName = Server.MapPath("File/Template/Activity.xls");
            //导出文件  
            string ReportFileName = Server.MapPath("out.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet ws = (HSSFSheet)hssfworkbook.GetSheet("Sheet1");
            //添加或修改WorkSheet里的数据  
            ws.GetRow(1).GetCell(1).SetCellValue(LUserName.Text);
            ws.GetRow(1).GetCell(3).SetCellValue(dt1.Rows[0]["UserGender"].ToString());
            ws.GetRow(1).GetCell(5).SetCellValue(dt1.Rows[0]["Birthday"].ToString());
            ws.GetRow(2).GetCell(1).SetCellValue(dt1.Rows[0]["DepartmentName"].ToString());
            ws.GetRow(2).GetCell(3).SetCellValue(LUserJob.Text);
            ws.GetRow(2).GetCell(5).SetCellValue(dt1.Rows[0]["EducationName"].ToString());
            ws.GetRow(3).GetCell(1).SetCellValue(AssociationName.Text+","+CompanyName.Text);
            ws.GetRow(4).GetCell(1).SetCellValue(LPartner.Text);
            ws.GetRow(5).GetCell(1).SetCellValue(StartDate.Text+"至"+EndDate.Text);

               if (dy.Tables[0].Rows.Count > 0)
               {
                   ws.GetRow(7).GetCell(0).SetCellValue(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                   ws.GetRow(8).GetCell(4).SetCellValue(dy.Tables[0].Rows[0]["UserName"].ToString());
                   ws.GetRow(9).GetCell(4).SetCellValue(Convert.ToDateTime( dy.Tables[0].Rows[0]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
                  
               }
               if (dy.Tables[0].Rows.Count > 1)
               {
                   ws.GetRow(11).GetCell(0).SetCellValue(dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
                   ws.GetRow(12).GetCell(2).SetCellValue(dy.Tables[0].Rows[1]["UserName"].ToString());
                   ws.GetRow(13).GetCell(1).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));

               }
               if (dy.Tables[0].Rows.Count > 2)
               {
                   ws.GetRow(11).GetCell(3).SetCellValue(dy.Tables[0].Rows[2]["ExamineOpinion"].ToString());
                   ws.GetRow(12).GetCell(5).SetCellValue(dy.Tables[0].Rows[2]["UserName"].ToString());
                   ws.GetRow(13).GetCell(4).SetCellValue(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).ToString("yyyy 年 MM 月 dd 日"));
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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("学术活动.xls"));
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