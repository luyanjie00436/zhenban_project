using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class NoticeUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int NoticeId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            NoticeId = Convert.ToInt32(Request.QueryString["Notice"]);
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

                DataSet ds = bus.SelectByNoticeId("Notice_SelectByNoticeId", NoticeId);
                txtNoticeExplain.Text = ds.Tables[0].Rows[0]["NoticeExplain"].ToString();
               LFileUrl.Text = ds.Tables[0].Rows[0]["FileUrl"].ToString();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (LFileUrl.Text != "")
            {
                string path = Server.MapPath("./") + LFileUrl.Text;
                FileInfo fi = new FileInfo(path);
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
            }
            else
            {
                Response.Write("<script>alert('未上传附件，无法下载！');</script>");
                return;
            }
        }

        protected void RBL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBL1.SelectedItem.Value=="是")
            {
                fupFileSend.Visible = true;
            }
            else
            {
                fupFileSend.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoticeExplain = txtNoticeExplain.Text.Trim().ToString();
            string FileUrl = LFileUrl.Text;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (NoticeExplain == "")
            {
                Response.Write("<script>alert('请填写内容！')</script>");
                return;
            }
            if (RBL1.SelectedValue=="是")
            {
                 if (!fupFileSend.HasFile)
                 {
                Response.Write("<script>alert('请选择上传文件！')</script>");
                  }
                  else
                  {
                      try
                      {
                    //获取上传文件的名称
                    string upName = fupFileSend.FileName;
                    //获取上传文件的后缀名
                    string nameLast = upName.Substring(upName.LastIndexOf("."));
                    //创建文件夹
                    string sPath = "File" + "\\" + "Notice" + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File" + "\\" + "Notice" + "\\" + upName;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    FileUrl = "File" + "\\" + "Notice" + "\\" + upName;
                        }
                       catch (Exception ex)
                       {
                    Response.Write(ex.Message.ToString());
                    Response.Write("<script>alert('上传失败！')</script>");
                       }
                  }
            }
            NoticeId = Convert.ToInt32(Request.QueryString["Notice"]);
            if (bus.NoticeUpdate("Notice_Update", NoticeId, NoticeExplain,FileUrl, UserCardId))
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");

            }
        }


    }
}