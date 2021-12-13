using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LctureDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int LctureId;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["LctureId"] != null)
                {
                    try
                    {
                        LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByLctureId("Lcture_SelectByLctureId", LctureId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    LLctureName.Text = dt.Tables[0].Rows[0]["LctureName"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LLctureDate.Text = Convert.ToDateTime( dt.Tables[0].Rows[0]["LctureDate"].ToString()).ToString("yyyy 年 MM 月 dd 日");
                    LAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                    LLctureNumber.Text = dt.Tables[0].Rows[0]["LctureNumber"].ToString();
                    LLctureExplain.Text = dt.Tables[0].Rows[0]["LctureExplain"].ToString();
                    LEquipment.Text = dt.Tables[0].Rows[0]["Equipment"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LOrganName.Text = dt.Tables[0].Rows[0]["OrganName"].ToString();
                    LPhoneNumber.Text = dt.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    LCapital.Text = dt.Tables[0].Rows[0]["Capital"].ToString();
                    LUserName.Text = dt.Tables[0].Rows[0]["LctureUserName"].ToString();
                    LUserGender.Text = dt.Tables[0].Rows[0]["LctureUserGender"].ToString();
                    LUserJob.Text = dt.Tables[0].Rows[0]["LctureUserJob"].ToString();
                    LUserRole.Text = dt.Tables[0].Rows[0]["LctureUserRole"].ToString();
                    LUserCompany.Text = dt.Tables[0].Rows[0]["LctureUserCompany"].ToString();


                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
           
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            DataSet dy = bus.SelectByLctureId("LctureExamine_Select", LctureId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }

        protected void buttom2_Click(object sender, EventArgs e)
        {
            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            DataSet dy = bus.SelectByLctureId("LctureExamine_Select", LctureId);
            DataSet dt = bus.SelectByLctureId("Lcture_SelectByLctureId", LctureId);
            UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
            DataTable dt1 = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId).Tables[0];
            string TempletFileName = Server.MapPath("File/Template/Lcture.xls");
            //导出文件  
            string ReportFileName = Server.MapPath("out.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet ws = (HSSFSheet)hssfworkbook.GetSheet("附件一");
            //添加或修改WorkSheet里的数据  
            ws.GetRow(1).GetCell(1).SetCellValue(LLctureName.Text);
            ws.GetRow(2).GetCell(1).SetCellValue(LCompany.Text);
            ws.GetRow(3).GetCell(2).SetCellValue(LUserName.Text);
            ws.GetRow(3).GetCell(4).SetCellValue(LUserGender.Text);
            ws.GetRow(3).GetCell(6).SetCellValue(LUserJob.Text);
            ws.GetRow(4).GetCell(2).SetCellValue(LUserRole.Text);
            ws.GetRow(4).GetCell(4).SetCellValue(LCompany.Text);

            ws.GetRow(5).GetCell(1).SetCellValue(LDLevel.Text);

            ws.GetRow(5).GetCell(4).SetCellValue(LLctureDate.Text);
            ws.GetRow(6).GetCell(1).SetCellValue(LAddress.Text);
            ws.GetRow(6).GetCell(4).SetCellValue(LLctureNumber.Text);
            ws.GetRow(7).GetCell(1).SetCellValue(LLctureExplain.Text);
            ws.GetRow(11).GetCell(1).SetCellValue(LEquipment.Text);
            ws.GetRow(13).GetCell(1).SetCellValue(LOrganName.Text);
            ws.GetRow(13).GetCell(4).SetCellValue(LPhoneNumber.Text);
            ws.GetRow(14).GetCell(1).SetCellValue(LCapital.Text);
            ws.GetRow(19).GetCell(1).SetCellValue(LRemarks.Text);

            if (dy.Tables[0].Rows.Count > 0)
            {
                ws.GetRow(15).GetCell(0).SetCellValue(dy.Tables[0].Rows[0]["DepartmentName"].ToString()+dy.Tables[0].Rows[0]["RankName"].ToString()+"审批:");
                ws.GetRow(15).GetCell(1).SetCellValue("意见:"+dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                ws.GetRow(16).GetCell(2).SetCellValue(dy.Tables[0].Rows[0]["UserName"].ToString());
                ws.GetRow(16).GetCell(4).SetCellValue(dy.Tables[0].Rows[0]["ExamineDate"].ToString());
                ws.GetRow(16).GetCell(6).SetCellValue(dy.Tables[0].Rows[0]["ExamineResult"].ToString());   
            }
            if (dy.Tables[0].Rows.Count > 1)
            {
                ws.GetRow(17).GetCell(0).SetCellValue(dy.Tables[0].Rows[1]["DepartmentName"].ToString() + dy.Tables[0].Rows[1]["RankName"].ToString() + "审批:");
                ws.GetRow(17).GetCell(1).SetCellValue("意见:" + dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
                ws.GetRow(18).GetCell(2).SetCellValue(dy.Tables[0].Rows[1]["UserName"].ToString());
                ws.GetRow(18).GetCell(4).SetCellValue(dy.Tables[0].Rows[1]["ExamineDate"].ToString());
                ws.GetRow(18).GetCell(6).SetCellValue(dy.Tables[0].Rows[1]["ExamineResult"].ToString()); 
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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("学术讲座.xls"));
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