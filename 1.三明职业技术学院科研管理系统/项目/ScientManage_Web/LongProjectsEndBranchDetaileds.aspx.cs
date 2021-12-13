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
    public partial class LongProjectsEndBranchDetaileds : System.Web.UI.Page
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
                    LProjectsSubject.Text = dt.Tables[0].Rows[0]["ProjectsSubjectExplain"].ToString();
                    LProjectsLevel.Text = dt.Tables[0].Rows[0]["ProjectsLevelExplain"].ToString();
                    LProjectsFrom.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["StandBranchUrl"].ToString();
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
            DataTable dt = bus.SelectByLongProjectsId("LongProjectsEndBranch_SelectsByLongProjectsId", LongProjectsId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("LongProjectsManage.aspx");
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            UserCardId = e.CommandArgument.ToString();
            DataSet dt1 = bus.SelectByLongUser("LongProjectsEndBranch_SelectByUserCardId", LongProjectsId, UserCardId);

            DataSet dt = bus.SelectByLongProjectsId("LongProjectsEndBranch_SelectsByLongProjectsId", LongProjectsId);

            //DataSet dy = bus.SelectByDuesId("DuesExamine_Select", DuesId);
            //DataSet dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
            try
            {
                string tempPath = Server.MapPath("File/Template/科研项目专家评审表.doc");
                string tempcopy = Server.MapPath("科研项目专家评审表.doc");
                string FileNameOut = "科研项目专家评审表.doc";
                Document doc = new Document(tempPath);

                BookmarksNavigator bookmark = new BookmarksNavigator(doc);
                bookmark.MoveToBookmark("LongProjectsName");
                bookmark.InsertText(LLongProjectsName.Text);

                bookmark.MoveToBookmark("ProjectsFrom");
                bookmark.InsertText(LProjectsFrom.Text);

                bookmark.MoveToBookmark("ProjectsSubject");
                bookmark.InsertText(LProjectsSubject.Text);

                bookmark.MoveToBookmark("ExamineOpinion");
                bookmark.InsertText(dt1.Tables[0].Rows[0]["ExamineOpinion"].ToString());

                bookmark.MoveToBookmark("UserName");
                bookmark.InsertText(dt1.Tables[0].Rows[0]["UserName"].ToString());

                bookmark.MoveToBookmark("FollDate");
                if (dt1.Tables[0].Rows[0]["FollDate"].ToString().Length!= 0)
                {
                    bookmark.InsertText(Convert.ToDateTime(dt1.Tables[0].Rows[0]["FollDate"].ToString()).ToString("yyyy-MM-dd"));
                }
               

                bookmark.MoveToBookmark("Branch");
                bookmark.InsertText(dt1.Tables[0].Rows[0]["Branch"].ToString());


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
            }
            catch
            {
            }
        }
    }
}