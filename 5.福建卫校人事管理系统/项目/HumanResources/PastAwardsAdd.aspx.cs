﻿using System;
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
    public partial class PastAwardsAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int PastAwardsId;
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
                    Response.Redirect("Login.aspx");
                }
              
                if (Request.QueryString["PastAwards"] != null)
                {
                    try
                    {
                        PastAwardsId = Convert.ToInt32(Request.QueryString["PastAwards"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    DataSet ds = bus.SelectByPastAwardsId("PastAwards_SelectByPastAwardsId", PastAwardsId);
                    txtAwardProjectName.Text=ds.Tables[0].Rows[0]["AwardProjectName"].ToString();
                    txtAwardDate.Text= ds.Tables[0].Rows[0]["AwardDate"].ToString();
                    txtGrantUnit.Text= ds.Tables[0].Rows[0]["GrantUnit"].ToString();
                    txtRemarks.Text= ds.Tables[0].Rows[0]["Remarks"].ToString();
                    FileUpload1.Enabled = false;

                }
                else
                {
                    tr_sfzg.Visible = false;
                    Button2.Visible= false;
                    RlGL_Management.Visible = false;
                }

               
            }
        }
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value); ;
            string AwardProjectName = txtAwardProjectName.Text.Trim();
            string AwardDate = txtAwardDate.Text.Trim();
            string GrantUnit = txtGrantUnit.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            byte[] CertificatePhoto = null;
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
            CertificatePhoto = GetPictureData(Server.MapPath("~/yl") + FileUpload1.FileName);

         
          
            if (bus.PastAwardsInsert("PastAwards_Insert", UserCardId, AwardProjectName, AwardDate, GrantUnit, Remarks, CertificatePhoto))
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");

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
      
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value); ;
            PastAwardsId = Convert.ToInt32(Request.QueryString["PastAwards"]);
            string AwardProjectName = txtAwardProjectName.Text.Trim();
            string AwardDate = txtAwardDate.Text.Trim();
            string GrantUnit = txtGrantUnit.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            byte[] CertificatePhoto = null;

            if (RlGL_Management.SelectedValue == "是")
            {
               
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

                CertificatePhoto = GetPictureData(Server.MapPath("~/yl") + FileUpload1.FileName);
            }else
            {
                FileUpload1.Visible = false;
            }


            if (bus.PastAwardsUpdateNoTransferStatus("PastAwards_Update_NoTransferStatus", PastAwardsId, AwardProjectName, AwardDate, GrantUnit, Remarks, CertificatePhoto))
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");

            }
        }

        protected void RlGL_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RlGL_Management.SelectedValue=="是")
            {
                FileUpload1.Enabled = true;
            }
            else
            {
                FileUpload1.Enabled = false;
            }
           
        }
    }
}