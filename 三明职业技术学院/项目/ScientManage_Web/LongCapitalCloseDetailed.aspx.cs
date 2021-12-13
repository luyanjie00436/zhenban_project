using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ScientManage_Web2
{
    public partial class LongCapitalCloseDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                    LProjectsFrom.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalBasic_SelectByLongProjectsId", LongProjectsId);
                    LBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                    LSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                    LOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                    LSumMoney.Text = dt.Tables[0].Rows[0]["SumMoney"].ToString();
                    LSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                    LServicelife.Text = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalClose_SelectByLongProjectsId", LongProjectsId);
                    LFileUrl.Text = dt.Tables[0].Rows[0]["LongCapitalCloseUrl"].ToString();
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
            DataSet dy = bus.SelectByLongProjectsId("LongCapitalCloseExamine_Select", LongProjectsId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
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
                   
                    LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
                    DataSet dy = bus.SelectByLongProjectsId("LongCapitalCloseExamine_Select", LongProjectsId);

                    string tempcopy = Server.MapPath("三明医学科技职业学院科研项目经费决算表.docx");
                    //  string FileNameOut = Server.MapPath("三明医学科技职业学院科研项目经费决算表.docx");
                    string FileNameOut = "三明医学科技职业学院科研项目经费决算表.docx";
                    Document doc = new Document(path);
                    BookmarksNavigator bookmark = new BookmarksNavigator(doc);
                    System.IO.FileInfo filet;
                    try
                    {
                        if (dy.Tables[0].Rows.Count > 0)
                        {
                            bookmark.MoveToBookmark("ExamineOpinion1");
                            bookmark.InsertText(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                            bookmark.MoveToBookmark("UserName1");
                            bookmark.InsertText(dy.Tables[0].Rows[0]["UserName"].ToString());
                            bookmark.MoveToBookmark("ExamineDate1");
                            bookmark.InsertText(dy.Tables[0].Rows[0]["ExamineDate"].ToString());
                            bookmark.MoveToBookmark("ExamineResult1");
                            bookmark.InsertText(dy.Tables[0].Rows[0]["ExamineResult"].ToString());

                        }
                        if (dy.Tables[0].Rows.Count > 1)
                        {
                            bookmark.MoveToBookmark("ExamineOpinion2");
                            bookmark.InsertText(dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
                            bookmark.MoveToBookmark("UserName2");
                            bookmark.InsertText(dy.Tables[0].Rows[1]["UserName"].ToString());
                            bookmark.MoveToBookmark("ExamineDate2");
                            bookmark.InsertText(dy.Tables[0].Rows[1]["ExamineDate"].ToString());
                            bookmark.MoveToBookmark("ExamineResult2");
                            bookmark.InsertText(dy.Tables[0].Rows[1]["ExamineResult"].ToString());


                        }
                    }
                    catch (Exception)
                    {
                       
                        tempcopy = path;
                        doc.SaveToFile(tempcopy);
                         filet = new System.IO.FileInfo(tempcopy);
                        Response.Clear();
                        //  Response.Charset = "GB2312";
                        Response.ContentEncoding = System.Text.Encoding.UTF8;
                        // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(FileNameOut));
                        // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
                        Response.AddHeader("Content-Length", filet.Length.ToString());
                        // 指定返回的是一个不能被客户端读取的流，必须被下载   
                        Response.ContentType = "application/ms-excel";
                        // 把文件流发送到客户端   
                        Response.WriteFile(filet.FullName);
                        // 停止页面的执行   
                        Response.End();
                      //  Response.Write("<script>alert('附件未使用指定模板，无法导出审批信息！')</script>");
                        return;

                    }
                   
                    #region 项目流出
                    doc.SaveToFile(tempcopy);
                     filet = new System.IO.FileInfo(tempcopy);
                    Response.Clear();
                    //  Response.Charset = "GB2312";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(FileNameOut));
                    // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
                    Response.AddHeader("Content-Length", filet.Length.ToString());
                    // 指定返回的是一个不能被客户端读取的流，必须被下载   ,
                    Response.ContentType = "application/ms-excel";
                    // 把文件流发送到客户端   
                    Response.WriteFile(filet.FullName);
                    // 停止页面的执行   
                    Response.End();
                    #endregion

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