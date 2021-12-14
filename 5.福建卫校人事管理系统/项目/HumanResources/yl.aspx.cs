using Aspose.Cells;
using Aspose.Slides;
using Aspose.Words;
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
    public partial class yl : System.Web.UI.Page
    {
        public static string filename3;
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = int.Parse(Request.QueryString["fileid"]);
                DataTable dt = bus.SelectByApplyTitleFileId("ApplyTitleFile_SelectByFileId", id).Tables[0];
                string name = dt.Rows[0]["filename"].ToString();
                string dz = dt.Rows[0]["fileurl"].ToString();
                string gs = dt.Rows[0]["filetype"].ToString();
                string filename2 = dt.Rows[0]["filename"].ToString();
                //string filename = urlconvertor(dz + "\\" + name);
                string filename = urlconvertorlocal(dz + name);
                string newname = "";
                string dz2 = "yl\\";
                //imgAboutImgUrl.ImageUrl = filename;
                if (gs == ".jpg" || gs == ".bmp" || gs == ".png" || gs == ".jpeg" || gs == ".gif" || gs == ".pdf")
                {
                    filename = urlconvertor(dz + "\\" + name);
                    FileInfo fi = new FileInfo(filename);
                    png.Src = fi.ToString();
                }
                else if (gs == ".doc" || gs == ".docx")
                {
                    Document doc = new Document(filename);
                    newname = Guid.NewGuid().ToString() + ".pdf";
                    doc.Save(urlconvertorlocal(dz2 + newname), Aspose.Words.SaveFormat.Pdf);
                    filename3 = urlconvertor(dz2 + "\\" + newname);
                    FileInfo wf = new FileInfo(filename3);
                    png.Src = wf.ToString();
                }
                else if (gs == ".xlsx")
                {
                    Workbook excel = new Workbook(filename);
                    newname = Guid.NewGuid().ToString() + ".pdf";
                    excel.Save(urlconvertorlocal(dz2 + newname), Aspose.Cells.SaveFormat.Pdf);
                    filename3 = urlconvertor(dz2 + "\\" + newname);
                    FileInfo ef = new FileInfo(filename3);
                    png.Src = ef.ToString();
                }
                else if (gs == ".pptx")
                {
                    Aspose.Slides.Pptx.PresentationEx pptx = new Aspose.Slides.Pptx.PresentationEx(filename);
                    newname = Guid.NewGuid().ToString() + ".pdf";
                    pptx.Save(urlconvertorlocal(dz2 + newname), Aspose.Slides.Export.SaveFormat.Pdf);
                    filename3 = urlconvertor(dz2 + "\\" + newname);
                    FileInfo pxf = new FileInfo(filename3);
                    png.Src = pxf.ToString();
                }
                else if (gs == ".ppt")
                {
                    Presentation ppt = new Presentation(filename);
                    newname = Guid.NewGuid().ToString() + ".pdf";
                    ppt.Save(urlconvertorlocal(dz2 + newname), Aspose.Slides.Export.SaveFormat.Pdf);
                    filename3 = urlconvertor(dz2 + "\\" + newname);
                    FileInfo pf = new FileInfo(filename3);
                    png.Src = pf.ToString();
                }
            }
            ClearDateOutImg();
            // zidongshanchu(filename3);
            //  FileInfo fi = new FileInfo(filename);
            //png.Src = fi.ToString();

        }

        private void ClearDateOutImg()
        {
            //先取得文件夹中的文件列表   
            string[] fileEntries = System.IO.Directory.GetFiles(this.Page.Server.MapPath("yl"));

            foreach (string singFiles in fileEntries)//遍历文件列表   
            {
                //将文件的生成日期与系统日期相比，如果是1小时以前生成的文件，删除它   
                if (System.DateTime.Compare(System.IO.File.GetCreationTime(singFiles).AddHours(1), System.DateTime.Now) < 0)
                {
                    System.IO.File.Delete(singFiles);
                }
            }
        }
        private string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            return imagesurl2;
        }
        private string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"/"); //转换成绝对路径
            return imagesurl2;
        }
        //Word转换成pdf
        /// <summary>
        /// 把Word文件转换成为PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>


        public void zidongshanchu(string filename4)
        {
            string pSavedPath1 = Server.MapPath(filename4);
            if (File.Exists(pSavedPath1))
            {
                FileInfo fi = new FileInfo(pSavedPath1);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;
                try
                {
                    File.Delete(pSavedPath1);
                    //Response.Write("<script>alert('删除完！');</script>");

                }
                catch
                {
                    //Response.Write("<script>alert('没删除成功！');</script>");

                }

            }
        }

        protected void word(object sender, EventArgs e)
        {
            zidongshanchu(filename3);
            Response.Write("<script language=javascript>history.go(-2);</script>");

        }
        private void EditPDF(string fpath)
        {
            string path = fpath.Replace("//", "/");
            FileStream MyFileStream = new FileStream(path, FileMode.Open);
            ViewPdf(MyFileStream);
        }
        /// <summary>
        /// 显示pdf
        /// </summary>
        /// <param name="fs"></param>
        private void ViewPdf(Stream fs)
        {
            byte[] buffer = new byte[fs.Length];
            fs.Position = 0;
            fs.Read(buffer, 0, (int)fs.Length);
            Response.Clear();
            Response.AddHeader("Content-Length", fs.Length.ToString());
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline;FileName=out.pdf");
            fs.Close();
            Response.BinaryWrite(buffer);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
        }
    }
}