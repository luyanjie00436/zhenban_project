﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Photo_dyxl : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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
               leibie= Request.QueryString["leibie"];
                if (leibie== "FirstProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "Photo_dyxl";
                }
                else if (leibie == "HeighestProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "Photo_zgxl";
                }

                else if (leibie == "FirstDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "Photo_dyxw";
                }
                else if (leibie == "HeighestDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "Photo_zgxw";
                }
                else if (leibie == "Photo")
                {
                    proc = "UserInfo_SelectByMyImage";
                    ColName = "myimage";
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
                    Image2.Src = "imga_dyxl.aspx?id=" + UserCardId+"&leibie="+leibie;
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
           
            byte[] imgbyte = null;
            #region 保存照片
           

            if (FileUpload1.FileName != "")
            {

                #region 上传且保存
                if (FileUpload1.FileName == "")
                {

                    Response.Write("<script>alert('上传照片不能为空！')</script>");
                    return;
                  
                }
                bool fileIsValid = false;
                //如果确认了上传文件，则判断文件类型是否符合要求
                if (this.FileUpload1.HasFile)
                {
                    //获取上传文件的后缀
                    String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
                    String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
                    //判断文件类型是否符合要求
                    for (int i = 0; i < restrictExtension.Length; i++)
                    {
                        if (fileExtension == restrictExtension[i])
                        {
                            fileIsValid = true;
                        }
                        //如果文件类型符合要求,调用SaveAs方法实现上传,并显示相关信息
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

                                this.FileUpload1.SaveAs(Server.MapPath("~/File/Images") + FileUpload1.FileName);
                                this.Image2.Src = Server.MapPath("~/File/Images") + FileUpload1.FileName;
                                // Response.Write("<script>alert('文件上传成功！')</script>");
                            }
                            catch
                            {
                                Response.Write("<script>alert('文件照片失败！')</script>");
                                return;

                            }

                        }

                    }
                }

                #endregion
                imgbyte = GetPictureData(Server.MapPath("~/File/Images") + FileUpload1.FileName);

            }
            else
            {
                Response.Write("<script>alert('上传照片不能为空！')</script>");
                return;
            }
            #endregion
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
            if (bus.UserEducationInsertByPhotodyxl(proc, UserCardId,imgbyte))
            {
                AlertMsgAndNoFlush("上传成功！");
            }
            else
            {
                AlertMsgAndNoFlush("上传失败！");
            }
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
            Response.Redirect(Request.Url.ToString());//刷新当前页面
        }
    }
}