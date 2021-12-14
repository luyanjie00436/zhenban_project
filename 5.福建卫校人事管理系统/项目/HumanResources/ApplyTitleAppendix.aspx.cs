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
    public partial class ApplyTitleAppendix : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ApplyTitleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//remain
                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }
                if (Request.QueryString["ApplyTitleId"] != null)
                {
                    dataGriviewBD();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }
        public void dataGriviewBD()
        {
            ApplyTitleId = Convert.ToInt32(Request.QueryString["ApplyTitleId"]);
            DataTable dt = bus.Scdwcx("ApplyTitle_AppendixByApplyTitleId", ApplyTitleId).Tables[0];
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                //获取上传文件的名称
                string upName = fupFileSend.FileName;
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                //创建文件夹
                string sPath = "File" + "\\" + "LongProjects" + "\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                //path = "File" + "\\" + "LongProjects" + "\\"  + upName;
                int ApplyTitleId = Convert.ToInt32(Request.QueryString["ApplyTitleId"]);

                if (bus.Scdw("ApplyTitleScxz", upName, nameLast, sPath, ApplyTitleId))
                {
                    Response.Write("<script language=javascript>alert('上传成功')</script>");
                    dataGriviewBD();
                    //RegisterStartupScript("true", "<script>alert('上传成功！')</script>");
                    //Response.Redirect("LongProjectsEnclosureManage?proid=" + Request.QueryString["proid"] + "&Cate=" + Request.QueryString["Cate"]);
                }
                else
                {
                    Response.Write("<script language=javascript>alert('上传失败')</script>");
                    //RegisterStartupScript("true", "<script>alert('上传失败！')</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script language=javascript>alert('上传失败')</script>");
                //Response.Write(ex.Message.ToString());
                //RegisterStartupScript("true", "<script>alert('上传失败！')</script>");
            }
        }

        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            int imagesurl1 = int.Parse(e.CommandArgument.ToString());
            Response.Write("<script>window.open('yl.aspx?fileid=" + imagesurl1 + "');</script>");
            //  Response.Redirect("yl.aspx?fileid=" + imagesurl1);
        }
        private string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            return imagesurl2;
        }

        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            int imagesurl1 = int.Parse(e.CommandArgument.ToString());
            DataTable dt = bus.SelectByApplyTitleFileId("ApplyTitleFile_SelectByFileId", imagesurl1).Tables[0];
            string name = dt.Rows[0]["filename"].ToString();
            string dz = dt.Rows[0]["fileurl"].ToString();
            //  string filename2 = dt.Rows[0][1].ToString();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=1");
            // string filename = urlconvertor(dz + name);
            string filename = Server.MapPath("./") + dz + name;
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();

            }
            //Response.TransmitFile(filename);
        }
        //删除附件
        protected void LinkButton10_Command(object sender, CommandEventArgs e)
        {
            int imagesurl1 = int.Parse(e.CommandArgument.ToString());
            DataTable dt = bus.SelectByApplyTitleFileId("ApplyTitleFile_SelectByFileId", imagesurl1).Tables[0];
            string name = dt.Rows[0]["filename"].ToString();
            string dz = dt.Rows[0]["fileurl"].ToString();
            string pSavedPath1 = Server.MapPath(dz + "\\" + name);

            if (File.Exists(pSavedPath1))
            {
                FileInfo fi = new FileInfo(pSavedPath1);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;
                try
                {
                    File.Delete(pSavedPath1);
                    if (bus.ApplyFileDelete("ApplyTitleFile_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
                    {
                        Response.Write("<script language=javascript>alert('删除成功')</script>");
                        dataGriviewBD();
                    }
                }
                catch
                {
                    Response.Write("<script>alert('删除失败！');</script>");

                }

            }
            else
                if (bus.ApplyFileDelete("ApplyTitleFile_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    Response.Write("<script language=javascript>alert('删除成功')</script>");
                    dataGriviewBD();
                }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}