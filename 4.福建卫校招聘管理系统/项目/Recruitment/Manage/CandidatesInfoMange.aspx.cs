using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class CandidatesInfoMange : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string UserCardId;
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
                chaxun();
            }
        }
        public void chaxun()
        {
            string Sort = DSort.SelectedValue;
            string Number = txtNumber.Text.Trim();
            string Name = txtName.Text.Trim();
            string IdCard = txtIdCard.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Institutions = txtInstitutions.Text.Trim();
            string Profession = txtProfessionName.Text.Trim();
            DataSet dy = bus.CandidatesInfo_Selects("CandidatesInfo_Selects", Number, Name, IdCard, Phone, Email, Institutions, Profession, Sort);

            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();

        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            chaxun();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            string i = e.CommandArgument.ToString();
            Response.Redirect("CandidatesInfoUpd.aspx?NumberId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
      

        protected void dataOfYear_EditCommand(object source, DataListCommandEventArgs e)
        {
            // Number = pwds.DecryptDES(Request.QueryString["NumberId"], "asdfasdf");
            Number = e.CommandArgument.ToString();
            //Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
            DataSet ds = bus.SelectByNumber("CandidatesInfo_SelectByNumber", Number);
            string TempletFileName = Server.MapPath("File/Template/CandidatesInfo.xls");
            //导出文件  
            string ReportFileName = Server.MapPath("out.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet ws = (HSSFSheet)hssfworkbook.GetSheet("Sheet1");
            //添加或修改WorkSheet里的数据  

            ws.GetRow(1).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Number"].ToString());//报名序号
            ws.GetRow(1).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Email"].ToString());//电子邮箱


          
            int pictureIdx = 0;
            if (ds.Tables[0].Rows[0]["Photo"].ToString().Length==0)
            {
                ws.GetRow(1).GetCell(5).SetCellValue("");
            }
            else
            {
                pictureIdx = hssfworkbook.AddPicture((byte[])ds.Tables[0].Rows[0]["Photo"], PictureType.JPEG);
                HSSFPatriarch patriarch = (HSSFPatriarch)ws.CreateDrawingPatriarch();
                HSSFClientAnchor anchor = new HSSFClientAnchor(1, 1, 0, 0, 5, 1, 7, 8);
                //##处理照片位置，【图片左上角为（col, row）第row+1行col+1列，右下角为（ col +1, row +1）第 col +1+1行row +1+1列，第三个参数为宽，第四个参数为高

                HSSFPicture pict = (HSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);
                // pict.Resize();//这句话一定不要，这是用图片原始大小来显示

            }






            ws.GetRow(2).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Name"].ToString());//姓名
            ws.GetRow(2).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Gender"].ToString());//性别
            ws.GetRow(3).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Origin"].ToString());//籍贯
            ws.GetRow(3).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Nation"].ToString());//民族
            ws.GetRow(4).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Birthday"].ToString());//出生日期
            ws.GetRow(4).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["CardID"].ToString());//身份证号
            ws.GetRow(5).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["census"].ToString());//户籍所在地
            ws.GetRow(5).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Political"].ToString());//政治面貌
            ws.GetRow(6).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Sources"].ToString());//考生来源
            ws.GetRow(6).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["ContactPhone"].ToString());//联系电话
            ws.GetRow(7).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["FamilyPhone"].ToString());//家庭电话
            ws.GetRow(7).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["OtherPhone"].ToString());//其他电话
            ws.GetRow(8).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["ZipCode"].ToString());//邮编
            ws.GetRow(8).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["FamilyAddress"].ToString());//家庭住址
            ws.GetRow(9).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Culture"].ToString());//学历
            ws.GetRow(9).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Degree"].ToString());//学位
            ws.GetRow(10).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Education"].ToString());//学历类别
            ws.GetRow(10).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["Marriage"].ToString());//婚姻状况
            ws.GetRow(11).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Institutions"].ToString());//毕业院校
            ws.GetRow(12).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["ProfessionName"].ToString());//专业名称
            ws.GetRow(13).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["GraduationData"].ToString());//毕业时间
            ws.GetRow(13).GetCell(4).SetCellValue(ds.Tables[0].Rows[0]["JobsData"].ToString());//参加工作时间
            ws.GetRow(14).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Expertise"].ToString());//有何专长
            ws.GetRow(15).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Resumes"].ToString());//主要简历
            ws.GetRow(16).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["FamilyMember"].ToString());//家庭成员
            ws.GetRow(17).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Performance"].ToString());//主要业绩
            ws.GetRow(18).GetCell(1).SetCellValue(ds.Tables[0].Rows[0]["Remarks"].ToString());//备注


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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("考生信息.xls"));
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