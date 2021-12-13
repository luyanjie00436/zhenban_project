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
    public partial class LongProjectsEndDetailed : System.Web.UI.Page
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
                    LLongProjectsId.Text = dt.Tables[0].Rows[0]["NewLongProjectsId"].ToString();
                    LLongProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsSubject.Text = dt.Tables[0].Rows[0]["ProjectsSubjectExplain"].ToString();
                    LProjectsLevel.Text = dt.Tables[0].Rows[0]["ProjectsLevelExplain"].ToString();
                    LProjectsFrom.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["EndUrl"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongProjectsEndBranch_SelectByLongProjectsId", LongProjectsId);
                    LSumBranch.Text = dt.Tables[0].Rows[0]["SUMBranch"].ToString();
                    LAvgBranch.Text = dt.Tables[0].Rows[0]["AVGBranch"].ToString();
                    LCountNum.Text = dt.Tables[0].Rows[0]["COUNTNUM"].ToString();

                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserCardId.Text = UserCardId;
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LUserJob.Text = dt1.Rows[0]["JobName"].ToString();
                LDepartmentName.Text = dt1.Rows[0]["DepartmentName"].ToString();
                LUserPost.Text = dt1.Rows[0]["PostName"].ToString();
                LBirthday.Text = Convert.ToDateTime(dt1.Rows[0]["Birthday"].ToString()).ToString("yyyy年MM月dd日");
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            DataSet dy = bus.SelectByLongProjectsId("LongProjectsEndExamine_Select", LongProjectsId);
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
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string url = "/LongProjectsDeclareDetailed.aspx?LongProjectsId=" + Request.QueryString["LongProjectsId"];
            Response.Redirect(url);

        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string url = "/LongProjectsStandDetailed.aspx?LongProjectsId=" + Request.QueryString["LongProjectsId"];
            Response.Redirect(url);

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string url = "/LongProjectsInspectDetailed.aspx?LongProjectsId=" + Request.QueryString["LongProjectsId"];
            Response.Redirect(url);

        }

        protected void buttom2_Click(object sender, EventArgs e)
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            DataSet dy = bus.SelectByLongProjectsId("LongProjectsEndExamine_Select", LongProjectsId);

           
            //   Microsoft.Office.Interop.Word._Application appWord = new Microsoft.Office.Interop.Word.ApplicationClass();
            //  Microsoft.Office.Interop.Word._Document docFile = null;
            try
            {
                string tempPath = Server.MapPath("File/Template/LongProjectsEndDetailed.docx");
                string tempcopy = Server.MapPath("三明医学科技职业学院教科研项目结题审批表.docx");
                string FileNameOut= "三明医学科技职业学院教科研项目结题审批表.docx";
                Document doc = new Document(tempPath);

                BookmarksNavigator bookmark = new BookmarksNavigator(doc);
                bookmark.MoveToBookmark("UserCardId");
                bookmark.InsertText(LUserCardId.Text);

                bookmark.MoveToBookmark("UserName");
                bookmark.InsertText(LUserName.Text);

                bookmark.MoveToBookmark("DepartmentName");
                bookmark.InsertText(LDepartmentName.Text);

                bookmark.MoveToBookmark("UserJob");
                bookmark.InsertText(LUserJob.Text);

                bookmark.MoveToBookmark("LongProjectsId");
                bookmark.InsertText(LLongProjectsId.Text);

                bookmark.MoveToBookmark("LongProjectsName");
                bookmark.InsertText(LLongProjectsName.Text);

                bookmark.MoveToBookmark("ProjectsLevel");
                bookmark.InsertText(LProjectsLevel.Text);

                bookmark.MoveToBookmark("ProjectsFrom");
                bookmark.InsertText(LProjectsFrom.Text);
             
                object obDD_ExamineOpinion2 = "ExamineOpinion2";
                object obDD_UserName2 = "UserName2";
                object obDD_ExamineDate2 = "ExamineDate2";
                object obDD_ExamineResult2 = "ExamineResult2";
                object obDD_Shenpi2 = "Shenpi2";
                
              
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
                    bookmark.MoveToBookmark("Shenpi1");
                    bookmark.InsertText(dy.Tables[0].Rows[0]["DepartmentName"].ToString() + dy.Tables[0].Rows[0]["RankName"].ToString());
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
                    bookmark.MoveToBookmark("Shenpi2");
                    bookmark.InsertText(dy.Tables[0].Rows[1]["DepartmentName"].ToString() + dy.Tables[0].Rows[1]["RankName"].ToString());
                   
                }
                #region 项目流出
                doc.SaveToFile(tempcopy);
                System.IO.FileInfo filet = new System.IO.FileInfo(tempcopy);
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
                #endregion
                //object filename = Server.MapPath("三明医学科技职业学院教科研项目结题审批表.doc");
                //object miss = System.Reflection.Missing.Value;
                //docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                //object missingValue = Type.Missing;
                //object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                //docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                //appWord.Quit(ref miss, ref miss, ref miss);
                //docFile = null;
                //appWord = null;
                //// 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("三明医学科技职业学院教科研项目结题审批表.doc"));
                //// 添加头信息，指定文件大小，让浏览器能够显示下载进度   
                //string ReportFileName = Server.MapPath("三明医学科技职业学院教科研项目结题审批表.doc");
                //System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
                //Response.AddHeader("Content-Length", filet.Length.ToString());

                //// 指定返回的是一个不能被客户端读取的流，必须被下载   
                //Response.ContentType = "application/ms-excel";

                //// 把文件流发送到客户端   
                //Response.WriteFile(filet.FullName);


            }
            catch
            {

                ////捕捉异常，如果出现异常则清空实例，退出word,同时释放资源<br />
                //string aa = e.ToString();
                //object miss = System.Reflection.Missing.Value;
                //object missingValue = Type.Missing;
                //object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                //docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                //appWord.Quit(ref miss, ref miss, ref miss);
                //docFile = null;
                //appWord = null;

            }
            }
    }
}