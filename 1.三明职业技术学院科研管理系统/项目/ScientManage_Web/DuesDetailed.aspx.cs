using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class DuesDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int DuesId;
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
                if (Request.QueryString["DuesId"] != null)
                {
                    try
                    {
                        DuesId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["DuesId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByDuesId("Dues_SelectByDuesId", DuesId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LAssociationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                    LFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    LCost.Text = dt.Tables[0].Rows[0]["Cost"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LUserJob.Text = dt1.Rows[0]["JobName"].ToString();
                LUserPost.Text = dt1.Rows[0]["PostName"].ToString();
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            DuesId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["DuesId"], "asdfasdf"));
            DataSet dy = bus.SelectByDuesId("DuesExamine_Select", DuesId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }

        protected void buttom2_Click(object sender, EventArgs e)
        {
            DuesId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["DuesId"], "asdfasdf"));
            DataSet dt = bus.SelectByDuesId("Dues_SelectByDuesId", DuesId);
            UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();

            DataSet dy = bus.SelectByDuesId("DuesExamine_Select", DuesId);
            DataSet dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
            try
            {
                string tempPath = Server.MapPath("File/Template/Dues.doc");
                string tempcopy = Server.MapPath("团体学会会费审批表.doc");
                string FileNameOut = "团体学会会费审批表.doc";
                Document doc = new Document(tempPath);

                BookmarksNavigator bookmark = new BookmarksNavigator(doc);
                bookmark.MoveToBookmark("UserName");
                bookmark.InsertText(LUserName.Text);

                bookmark.MoveToBookmark("DepartmentName");
                bookmark.InsertText(dt1.Tables[0].Rows[0]["DepartmentName"].ToString());

                bookmark.MoveToBookmark("FollDate");
                bookmark.InsertText( Convert.ToDateTime(LFollDate.Text).ToString("yyyy-MM-dd"));

                bookmark.MoveToBookmark("AssciationName");
                bookmark.InsertText(LAssociationName.Text);

                bookmark.MoveToBookmark("Cost");
                bookmark.InsertText(LCost.Text);
                if (dy.Tables[0].Rows.Count > 0)
                {

                    bookmark.MoveToBookmark("ExamineOpinion1");
                    bookmark.InsertText(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
                    bookmark.MoveToBookmark("UserName1");
                    bookmark.InsertText(dy.Tables[0].Rows[0]["UserName"].ToString());
                    bookmark.MoveToBookmark("ExamineDate1");
                    bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).ToString("yyyy-MM-dd"));
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
                    bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).ToString("yyyy-MM-dd"));
                    bookmark.MoveToBookmark("ExamineResult2");
                    bookmark.InsertText(dy.Tables[0].Rows[1]["ExamineResult"].ToString());
                  

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
            }
            catch
            {
            }
        }
    }
}