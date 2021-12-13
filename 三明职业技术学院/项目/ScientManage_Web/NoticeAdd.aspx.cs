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
    public partial class NoticeAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        string UserCardId;
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

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoticeExplain = txtNoticeExplain.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string FileUrl="";
            if (NoticeExplain == "")
            {
                Response.Write("<script>alert('请填写内容！')</script>");
                return;
            }
            if (!fupFileSend.HasFile)
            {
                FileUrl = "";
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
            if (bus.NoticeInsert("Notice_Insert", NoticeExplain,FileUrl, UserCardId))
            {
                Response.Write("<script>alert('添加成功！')</script>");
                txtNoticeExplain.Text = "";
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");

            }
        }
     
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();
        }
        public void clearIfo()
        {
            txtNoticeExplain.Text = "";
        }
    }
}