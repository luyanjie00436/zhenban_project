
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class AssciationDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int AssociationId;
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
                if (Request.QueryString["AssciationId"] != null)
                {
                    try
                    {
                        AssociationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByAssciationId("Association_SelectByAssociationId", AssociationId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();

                    LAssociationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                 
                    LExplain.Text = dt.Tables[0].Rows[0]["Explain"].ToString();
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
            AssociationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
            DataSet dy = bus.SelectByAssciationId("AssociationExamine_Select", AssociationId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }

    //    protected void buttom2_Click(object sender, EventArgs e)
    //    {
    //        AssociationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
    //        DataSet dy = bus.SelectByAssciationId("AssociationExamine_Select", AssociationId);
    //        try
    //        {
    //            string tempPath = Server.MapPath("File/Template/Assciation.doc");
    //            string tempcopy = Server.MapPath("团体学会审批表.doc");
    //            string FileNameOut = "团体学会审批表.doc";
    //            Document doc = new Document(tempPath);

    //            BookmarksNavigator bookmark = new BookmarksNavigator(doc);
    //            bookmark.MoveToBookmark("AssciationName");
    //            bookmark.InsertText(LUserName.Text);
                
    //            bookmark.MoveToBookmark("Explain");
    //            bookmark.InsertText(LExplain.Text);

      

    //            if (dy.Tables[0].Rows.Count > 0)
    //            {
    //                bookmark.MoveToBookmark("Opinion1");
    //                bookmark.InsertText(dy.Tables[0].Rows[0]["ExamineOpinion"].ToString());
    //                bookmark.MoveToBookmark("Name1");
    //                bookmark.InsertText(dy.Tables[0].Rows[0]["UserName"].ToString());
    //                bookmark.MoveToBookmark("Year1");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Year.ToString()); 
    //                bookmark.MoveToBookmark("Month1");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Month.ToString());
    //                bookmark.MoveToBookmark("Day1");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Day.ToString());
    //            }
    //            if (dy.Tables[0].Rows.Count > 1)
    //            {
    //                bookmark.MoveToBookmark("Opinion2");
    //                bookmark.InsertText(dy.Tables[0].Rows[1]["ExamineOpinion"].ToString());
    //                bookmark.MoveToBookmark("Name2");
    //                bookmark.InsertText(dy.Tables[0].Rows[1]["UserName"].ToString());
    //                bookmark.MoveToBookmark("Year2");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Year.ToString());
    //                bookmark.MoveToBookmark("Month2");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Month.ToString());
    //                bookmark.MoveToBookmark("Day2");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Day.ToString());

    //            }
    //            if (dy.Tables[0].Rows.Count > 2)
    //            {
    //                bookmark.MoveToBookmark("Opinion3");
    //                bookmark.InsertText(dy.Tables[0].Rows[2]["ExamineOpinion"].ToString());
    //                bookmark.MoveToBookmark("Name3");
    //                bookmark.InsertText(dy.Tables[0].Rows[2]["UserName"].ToString());
    //                bookmark.MoveToBookmark("Year3");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Year.ToString());
    //                bookmark.MoveToBookmark("Month3");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Month.ToString());
    //                bookmark.MoveToBookmark("Day3");
    //                bookmark.InsertText(Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Day.ToString());

    //            }
    //            #region 项目流出
    //            doc.SaveToFile(tempcopy);
    //            System.IO.FileInfo filet = new System.IO.FileInfo(tempcopy);
    //            Response.Clear();
    //            //  Response.Charset = "GB2312";
    //            Response.ContentEncoding = System.Text.Encoding.UTF8;
    //            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
    //            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(FileNameOut));
    //            // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
    //            Response.AddHeader("Content-Length", filet.Length.ToString());
    //            // 指定返回的是一个不能被客户端读取的流，必须被下载   
    //            Response.ContentType = "application/ms-excel";
    //            // 把文件流发送到客户端   
    //            Response.WriteFile(filet.FullName);
    //            // 停止页面的执行   
    //            Response.End();
    //            #endregion

    //        }
    //        catch
    //        {
    //        }

         

    //    }
    }
}