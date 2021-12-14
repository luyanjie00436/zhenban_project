using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ProjectsTemplateAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectsTemplateManage.aspx") == 0)
                //{
                //    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                //}
                clearIfo();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string Category = DLCategory.SelectedValue;
            string TemplateName = txtTemplateName.Text.Trim();
            if (TemplateName=="")
            {
                Response.Write("<script>alert('请输入名称')</script>");
                return;
            }
            try
            {
                //获取上传文件的名称
                string upName = fupFileSend.FileName;
              
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                upName = TemplateName + nameLast;
                //创建文件夹
              //  string sPath = "File" + "\\" + "Template" + "\\" + proid + "\\" + Cate + "\\";
               // Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "Template" + "\\" + upName;
                FileInfo file = new FileInfo(path);//指定文件路径
                if (file.Exists)//判断文件是否存在
                {
                    Response.Write("<script>alert('上传失败！文件已存在，请选用其他名称')</script>");
                    return;
                }
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "Template" + "\\" + upName;
                if (bus.ProjectsTemplateInsert("ProjectsTemplate_Insert",Category,TemplateName,path,UserCardId))
                {
                    Response.Write("<script>alert('保存成功！')</script>");
                 }
                else
                {
                    Response.Write("<script>alert('保存失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();

        }
        public void clearIfo()
        {
            txtTemplateName.Text = "";
            
        }
    }
}