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
    public partial class LongProjectsOReviewScore : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int RankId;
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
                        OReviewId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["OReviewId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByOReviewId("LongProjects_SelectByOReviewId", OReviewId);
                    //UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["ReviewFileUrl"].ToString();
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
            OReviewId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["OReviewId"], "asdfasdf"));
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DataSet dy = bus.SelectByLongUser("LongProjectsOReview_SelectByUserCardId", OReviewId, UserCardId);
            if (dy.Tables[0].Rows.Count > 0)
            {
                txtScore.Text = dy.Tables[0].Rows[0]["Score"].ToString();
                txtExamineOpinion.Text = dy.Tables[0].Rows[0]["ExamineOpinion"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            OReviewId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["OReviewId"], "asdfasdf"));
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            try
            {
                Convert.ToDouble(txtScore.Text);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            double Score = Convert.ToDouble(txtScore.Text);
            if (Score <= 0 || Score > 100)
            {
                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            string ExamineOpinion = txtExamineOpinion.Text;
            if (bus.LongProjectsOReviewScoreInsert("LongProjectsOReviewScore_Insert", OReviewId, UserCardId, Score, ExamineOpinion))
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