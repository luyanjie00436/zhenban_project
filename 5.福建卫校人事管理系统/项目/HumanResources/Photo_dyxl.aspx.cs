using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class Photo_dyxl : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        string leibie,proc,ColName;
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
                }
                leibie = Request.QueryString["leibie"];
                if (leibie == "FirstProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "DYXL_Photo";
                }
                else if (leibie == "HeighestProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "ZGXL_Photo";
                }

                else if (leibie == "FirstDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "DYXW_Photo";
                }
                else if (leibie == "HeighestDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "ZGXW_Photo";
                }
                else if (leibie == "Photo")
                {
                    proc = "UserInfo_SelectByMyImage";
                    ColName = "Photo";
                    div3.Style.Add("width", "75px");
                    Image2.Style.Add("width", "71px");
                    Image2.Style.Add("height", "99px");
                }


                DataSet ds = bus.SelectByUserCardId(proc, UserCardId);

                if (ds.Tables[0].Rows[0][ColName].ToString().Length == 0)
                {
                    Image2.Src = "";
                    FileUpload1.Visible = true;
                }
                else
                {
                    Image2.Src = "imga_dyxl.aspx?id=" + UserCardId + "&leibie=" + leibie;
                }
            }
        }

        #region 图片保存成二进制
        public byte[] GetPictureData(string imagepath)
        {
            FileStream fs = new FileStream(imagepath, FileMode.Open);//可以是其他重载方法 
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            return byData;
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
         //   string UserCardId = "119999";
            byte[] imgbyte = null;
            #region 保存照片
            if (FileUpload1.HasFile)
            {
              
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    bool fileIsValid = false;
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsValid = true;
                    }
                    if (fileIsValid == true)
                    {
                        //上传文件是否大于1M
                        if (FileUpload1.PostedFile.ContentLength > (1024 * 1024))
                        {
                            Response.Write("<script>alert('上传照片不能大于1M！')</script>");
                            return;
                        }
                        try
                        {

                            FileUpload1.SaveAs(Server.MapPath("~/yl") + FileUpload1.FileName);
                         //    Image2.Src = Server.MapPath("~/File/Images/") + FileUpload1.FileName;
                            //   Response.Write("<script>alert('文件上传成功！')</script>");

                        }
                        catch
                        {
                            Response.Write("<script>alert('文件照片失败！')</script>");
                            return;

                        }
                    }
                }


               
            }
         
            else
            {
                Response.Write("<script>alert('上传照片不能为空！')</script>");
                return;
            }
            #endregion
            imgbyte = GetPictureData(Server.MapPath("~/yl") + FileUpload1.FileName);
            leibie = Request.QueryString["leibie"];
            if (leibie == "FirstProfession")
            {
                proc = "UserEducation_InsertByPhotodyxl";
            }
            else if (leibie == "HeighestProfession")
            {
                proc = "UserEducation_InsertByPhotozgxl";
            }

            else if (leibie == "FirstDegree")
            {
                proc = "UserDegree_InsertByPhotodyxw";
            }
            else if (leibie == "HeighestDegree")
            {
                proc = "UserDegree_InsertByPhotozgxw";
            }
            else if (leibie == "Photo")
            {
                proc = "UserInfo_InsertMyImage";
            }
            if (bus.UserEducationInsertByPhotodyxl(proc, UserCardId, imgbyte))
            {

                Response.Write("<script>alert('上传成功！');document.URL=location.href; </script>");

                ClearDateOutImg();
            }
            else
            {

                Response.Write("<script>alert('上传失败！');document.URL=location.href; </script>");
                ClearDateOutImg();
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
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
        //public void AlertMsgAndNoFlush(string message)
        //{
        //    Response.Write("<script>alert('" + message + "！')</script>");
        //    Response.Redirect(Request.Url.ToString());//刷新当前页面
        //}
    }
}