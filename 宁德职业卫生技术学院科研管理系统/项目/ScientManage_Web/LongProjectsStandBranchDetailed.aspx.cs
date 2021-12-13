using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LongProjectsStandBranchDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        string LongProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["LongProjectsId"] != null)
                {
                    try
                    {
                        LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LLongProjectsId.Text = dt.Tables[0].Rows[0]["LongProjectsId"].ToString();
                    LLongProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsSubject.Text = dt.Tables[0].Rows[0]["ProjectsSubjectExplain"].ToString();
                    LProjectsLevel.Text = dt.Tables[0].Rows[0]["ProjectsLevelExplain"].ToString();
                    LProjectsFrom.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["StandBranchUrl"].ToString();
               

LProjectsContent.Text = dt.Tables[0].Rows[0]["ProjectsContent"].ToString();
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

               
                dataGriviewBD();
            }
        }

        public void dataGriviewBD()
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DataSet dy = bus.SelectByLongUser("LongProjectsStandBranch_SelectByUserCardId", LongProjectsId, UserCardId);
            if (dy.Tables[0].Rows.Count > 0)
            {
                txtOpinion.Text = dy.Tables[0].Rows[0]["Opinion"].ToString();
               
                txtBranch.Text = dy.Tables[0].Rows[0]["Branch"].ToString();
                LFileUrl1.Text = dy.Tables[0].Rows[0]["url"].ToString();
                if (dy.Tables[0].Rows[0]["url"].ToString().Length == 0)
                {
                    LinkButton3.Visible = false;
                }
                else
                {
                    LinkButton3.Visible = true;
                }
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (LFileUrl.Text != "null")
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
        //下载模板
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (DlCategory.SelectedValue != "0")
            {
                string path = Server.MapPath("./") + DlCategory.SelectedValue;
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
                Response.Write("<script>alert('请选择类别！')</script>");
                return;
            }
        }
        //下载附件
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (LFileUrl1.Text != "")
            {
                string path = Server.MapPath("./") + LFileUrl1.Text;
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string path = LFileUrl.Text;
            string Opinion = txtOpinion.Text;
            try
            {
                Convert.ToDouble(txtBranch.Text);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            double Branch = Convert.ToDouble(txtBranch.Text);
            if (Branch <= 0 || Branch > 100)
            {
                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            if (LFileUrl1.Text.Trim().Length > 0)
            {
                path = LFileUrl1.Text;
                if (fupFileSend.HasFile)
                {
                    try
                    {
                        //获取上传文件的名称
                        string upName = DateTime.Now.ToString("yyyyMMddHHmmss") + fupFileSend.FileName;
                        //获取上传文件的后缀名
                        string nameLast = upName.Substring(upName.LastIndexOf("."));
                        //创建文件夹
                        string sPath = "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                        LFileUrl1.Text = path;
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('文件上传失败！')</script>");
                    }
                }
            }
            else
            {
                if (!fupFileSend.HasFile)
                {
                    Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                    return;
                }
                try
                {
                    //获取上传文件的名称
                    string upName = DateTime.Now.ToString("yyyyMMddHHmmss") + fupFileSend.FileName;
                    //获取上传文件的后缀名
                    string nameLast = upName.Substring(upName.LastIndexOf("."));
                    //创建文件夹
                    string sPath = "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    path = Server.MapPath("./") + "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File" + "\\" + "LongProjectsStandBranch" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                    LFileUrl1.Text = path;
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('文件上传失败！')</script>");
                }
            }

            if (path == "")
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后保存！')</script>");
                return;
            }
            if (bus.LongProjectsApprovalBranchInsert("LongProjectsStandBranch_Insert", LongProjectsId, UserCardId, Branch, path,Opinion))
            {
                Response.Write("<script>alert('评审成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('评审失败！')</script>");
            }
        }
    }
}