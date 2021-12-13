using Spire.Doc;
using Spire.Doc.Documents;
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
    public partial class LongCapitalCloseAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
        protected static string type;
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
                DataTable dt2 = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "经费决算").Tables[0];
                foreach (DataRow dr in dt2.Rows)
                {
                    ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                    DlCategory.Items.Add(li);
                }
                dt2.Clear();
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
                    LProjectsId.Text = LongProjectsId;
                    LProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsFromExplain.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalBasic_SelectByLongProjectsId", LongProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        LBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                        LSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                        LOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                        LSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                        LServicelife.Text = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                        LSumMoney.Text = dt.Tables[0].Rows[0]["SumMoney"].ToString();
                    }
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalClose_SelectByLongProjectsId", LongProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        LFileUrl.Text = dt.Tables[0].Rows[0]["LongCapitalCloseUrl"].ToString();
                    }

                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }


            }

        }
        //下载模板
        protected void LinkButton1_Click(object sender, EventArgs e)
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = LProjectsId.Text;
            string path = LFileUrl.Text;
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
                string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalClose\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalClose\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalClose\\" + upName;
                LFileUrl.Text = path;
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('文件上传失败！')</script>");
                return;
            }
            if (path == "")
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后保存！')</script>");
                return;
            }
            else
            {
              string  path1 = Server.MapPath("./") + path;
                FileInfo fi = new FileInfo(path1);
                if (fi.Exists)
                {

                    LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
                    DataSet dy = bus.SelectByLongProjectsId("LongCapitalCloseExamine_Select", LongProjectsId);

                    string tempcopy = Server.MapPath("三明医学科技职业学院科研项目经费决算表.docx");
                    //  string FileNameOut = Server.MapPath("三明医学科技职业学院科研项目经费决算表.docx");
                    string FileNameOut = "三明医学科技职业学院科研项目经费决算表.docx";
                    Document doc = new Document(path1);
                    BookmarksNavigator bookmark = new BookmarksNavigator(doc);
                    try
                    {
                            bookmark.MoveToBookmark("ExamineOpinion1");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("UserName1");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("ExamineDate1");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("ExamineResult1");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("ExamineOpinion2");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("UserName2");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("ExamineDate2");
                            bookmark.InsertText("1");
                            bookmark.MoveToBookmark("ExamineResult2");
                            bookmark.InsertText("1");
                        
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('附件未使用指定模板，请使用指定模板进行填写后上传！')</script>");
                        return;
                    }
                }
            }



            if (bus.LongCapitalPlanInsert("LongCapitalClose_Insert", LongProjectsId, UserCardId, path))
            {
                Response.Write("<script>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
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