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
    public partial class LongProjectsOReviewAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int OReviewId;
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
                if (Request.QueryString["OReviewId"] != null)
                {
                    try
                    {
                        OReviewId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["OReviewId"], "asdfasdf"));                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    #region 绑定
                   
                    Button1.Visible = false;
                    RBL1.Visible = true;
                    Lxiugai.Visible = true;
                    DataSet ds = bus.SelectByOReviewId("LongProjects_SelectByOReviewId", OReviewId);
                    txtStarttime.Value = ds.Tables[0].Rows[0]["Starttime"].ToString();
                    txtEndtime.Value = ds.Tables[0].Rows[0]["Endtime"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {
                   
                    RBL1.Visible = false;
                    LOReviewId.Text = DateTime.Now.ToString("yyyyMMddhhMMss") + DateTime.Now.Millisecond.ToString();
                    Button2.Visible = false;
                }
                #endregion
            }
        }
        
        //下载附件
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string Starttime = txtStarttime.Value;
            string Endtime = txtEndtime.Value;
            string Remarks = txtRemarks.Text;

            if (Starttime == null)
            {
                Response.Write("<script>alert('请输入开始时间！')</script>");
                return;
            }
            if (Endtime == null)
            {
                Response.Write("<script>alert('请输入结束时间！')</script>");
                return;
            }
            if (!ReviewFile.HasFile)
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                return;
            }
            try
            {
                //获取上传文件的名称
                string upName = ReviewFile.FileName;
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                string times = DateTime.Now.ToString("yyyyMMddHHmmss");
                //创建文件夹
                string sPath = "File" + "\\" + "OReview" + "\\" + times + "\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "OReview\\" + times + "\\ " + upName;
                //将文件保存到指定路径下
                ReviewFile.PostedFile.SaveAs(path);
                path = "File" + "\\" + "OReview\\" + times + "\\ " + upName;
                LFileUrl.Text = path;
                if (bus.LongProjectsOReviewInsert("LongProjectsOReview_Insert", path, Starttime, Endtime, Remarks))
                {
                    Response.Write("<script>alert('添加成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！')</script>");
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
            
            string Starttime = txtStarttime.Value;
            string Endtime = txtEndtime.Value;
            string Remarks = txtRemarks.Text;
            string path = null;
            if (RBL1.SelectedValue == "是")
            {

                if (!ReviewFile.HasFile)
                {
                    Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                    return;
                }
                try
                {
                    //获取上传文件的名称
                    string upName = ReviewFile.FileName;
                    //获取上传文件的后缀名
                    string nameLast = upName.Substring(upName.LastIndexOf("."));
                    string times = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //创建文件夹
                    string sPath = "File" + "\\" + "OReview" + "\\" + times + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                     path = Server.MapPath("./") + "File" + "\\" + "OReview\\" + times + "\\ " + upName;
                    //将文件保存到指定路径下
                    ReviewFile.PostedFile.SaveAs(path);
                    path = "File" + "\\" + "OReview\\" + times + "\\ " + upName;
                    LFileUrl.Text = path;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    Response.Write("<script>alert('上传失败！')</script>");
                }

            }
            else if (RBL1.SelectedValue == "否")
            {
                ReviewFile.Visible = false;
            }
            if (Starttime == null)
            {
                Response.Write("<script>alert('请输入开始时间！')</script>");
                return;
            }
            if (Endtime == null)
            {
                Response.Write("<script>alert('请输入结束时间！')</script>");
                return;
            }
           

                OReviewId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["OReviewId"], "asdfasdf"));
                if (bus.LongProjectsOReviewUpdate("LongProjectsOReview_Update", OReviewId, path, Starttime, Endtime, Remarks))
                {
                    Response.Write("<script>alert('修改成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败！')</script>");
                }

        
          

        } 

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("LongProjectsOReviewManage.aspx");
        }
    }
}