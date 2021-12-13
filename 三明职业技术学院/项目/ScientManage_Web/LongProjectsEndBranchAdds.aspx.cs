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
    public partial class LongProjectsEndBranchAdds : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
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

                if (Request.QueryString["LongProjectsId"] != null)
                {
                    try
                    {
                        LongProjectsId = Request.QueryString["LongProjectsId"];
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    txtLongProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LFileUrl.Text = ds.Tables[0].Rows[0]["EndBranchUrl"].ToString();
                    if (LFileUrl.Text == "")
                    {
                        LinkButton2.Visible = false;
                    }
                }
                else
                {
                    Button2.Visible = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!fupFileSend.HasFile)
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                return;
            }
            try
            {
                //获取上传文件的名称
                string upName = fupFileSend.FileName;
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                //创建文件夹
                string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\EndBranch\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\EndBranch\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\EndBranch\\" + upName;
                LFileUrl.Text = path;

                string LongProjects = Request.QueryString["LongProjectsId"];
                UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                if (bus.LongProjectsStandUpdate("LongProjectsEnd_Update", LongProjects, UserCardId, path))
                {
                    Response.Write("<script>alert('结题成功，请进行评审和审批！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('结题失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('未上传附件，无法下载！')</script>");
                return;
            }
        }
    }
}