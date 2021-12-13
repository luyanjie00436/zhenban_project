
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AssciationDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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
                    LCapital.Text = dt.Tables[0].Rows[0]["Capital"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
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

        protected void buttom2_Click(object sender, EventArgs e)
        {
            AssociationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
            DataSet dy = bus.SelectByAssciationId("AssociationExamine_Select", AssociationId);
           
          Microsoft.Office.Interop.Word._Application appWord= new Microsoft.Office.Interop.Word.ApplicationClass();
          Microsoft.Office.Interop.Word._Document docFile = null;
          try
          {
              appWord.Visible = false;
              object objTrue = true;
               object objFalse = false;
               object objTemplate = Server.MapPath("File/Template/Assciation.dot");
               object objDocType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
               docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
              //第一步生成word文档<br />
              //定义书签变量<br />
               object obDD_AssciationName = "AssciationName";//姓 名<br />
               object obDD_Company = "Company";
               object obDD_Capital = "Capital";
               object obDD_Explain = "Explain";
               object obDD_Opinion1 = "Opinion1";
               object obDD_Opinion2 = "Opinion2";
               object obDD_Opinion3 = "Opinion3";
               object obDD_Day1 = "Day1";
               object obDD_Day2 = "Day2";
               object obDD_Day3 = "Day3";
               object obDD_Year1 = "Year1";
               object obDD_Year2 = "Year2";
               object obDD_Year3 = "Year3";
               object obDD_Month1 = "Month1";
               object obDD_Month2 = "Month2";
               object obDD_Month3 = "Month3";
               object obDD_Name1 = "Name1";
               object obDD_Name2 = "Name2";
               object obDD_Name3 = "Name3";       
              //给书签赋值
               docFile.Bookmarks.get_Item(ref obDD_AssciationName).Range.Text = LUserName.Text;
               docFile.Bookmarks.get_Item(ref obDD_Company).Range.Text = LCompany.Text;
               docFile.Bookmarks.get_Item(ref obDD_Capital).Range.Text = LCapital.Text;
               docFile.Bookmarks.get_Item(ref obDD_Explain).Range.Text = LExplain.Text;
               if (dy.Tables[0].Rows.Count > 0)
               {
                   docFile.Bookmarks.get_Item(ref obDD_Opinion1).Range.Text = dy.Tables[0].Rows[0]["ExamineOpinion"].ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Name1).Range.Text = dy.Tables[0].Rows[0]["UserName"].ToString();                   
                   docFile.Bookmarks.get_Item(ref obDD_Year1).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Year.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Month1).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Month.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Day1).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[0]["ExamineDate"].ToString()).Day.ToString();

               }
               if (dy.Tables[0].Rows.Count > 1)
               {
                   docFile.Bookmarks.get_Item(ref obDD_Opinion2).Range.Text = dy.Tables[0].Rows[1]["ExamineOpinion"].ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Name2).Range.Text = dy.Tables[0].Rows[1]["UserName"].ToString();          
                   docFile.Bookmarks.get_Item(ref obDD_Year2).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Year.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Month2).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Month.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Day2).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[1]["ExamineDate"].ToString()).Day.ToString();

               }
               if (dy.Tables[0].Rows.Count > 2)
               {
                   docFile.Bookmarks.get_Item(ref obDD_Opinion3).Range.Text = dy.Tables[0].Rows[2]["ExamineOpinion"].ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Name2).Range.Text = dy.Tables[0].Rows[2]["UserName"].ToString();          
                   docFile.Bookmarks.get_Item(ref obDD_Year3).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Year.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Month3).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Month.ToString();
                   docFile.Bookmarks.get_Item(ref obDD_Day3).Range.Text = Convert.ToDateTime(dy.Tables[0].Rows[2]["ExamineDate"].ToString()).Day.ToString();

               }
              object filename = Server.MapPath("团体学会.doc");
            object miss = System.Reflection.Missing.Value;
            docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            object missingValue = Type.Missing;
            object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
            appWord.Quit(ref miss, ref miss, ref miss);
            docFile = null;
            appWord = null;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("团体学会.doc"));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
            string ReportFileName = Server.MapPath("团体学会.doc"); 
              System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
              Response.AddHeader("Content-Length", filet.Length.ToString());

            // 指定返回的是一个不能被客户端读取的流，必须被下载   
            Response.ContentType = "application/ms-excel";

            // 把文件流发送到客户端   
            Response.WriteFile(filet.FullName);


          }
          catch 
          {
              
           //捕捉异常，如果出现异常则清空实例，退出word,同时释放资源<br />
            string aa = e.ToString();
            object miss = System.Reflection.Missing.Value;
            object missingValue = Type.Missing;
            object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
            appWord.Quit(ref miss, ref miss, ref miss);
            docFile = null;
            appWord = null;

          }

        
        }
    }
}