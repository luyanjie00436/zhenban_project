using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class LongProjectsEndBranchDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["LongProjectsId"] != null)
                {
                    try
                    {
                        LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LLongProjectsId.Text = dt.Tables[0].Rows[0]["LongProjectsId"].ToString();
                    LLongProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsSubject.Text = dt.Tables[0].Rows[0]["ProjectsSubjectExplain"].ToString();
                    LProjectsLevel.Text = dt.Tables[0].Rows[0]["ProjectsLevelExplain"].ToString();
                    LProjectsFrom.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["DeclareUrl"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserCardId.Text = UserCardId;
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                LUserJob.Text = dt1.Rows[0]["ZY_JobSeries"].ToString();
                //LDepartmentName.Text = dt1.Rows[0]["DepartmentName"].ToString();
                LUserPost.Text = dt1.Rows[0]["ZY_TitleLevelName"].ToString();
                LBirthday.Text = Convert.ToDateTime(dt1.Rows[0]["Birthday"].ToString()).ToString("yyyy年MM月dd日");
                dataGriviewBD();
            }
        }

        public void dataGriviewBD()
        {
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DataSet dy = bus.SelectByLongUser("LongProjectsEndBranch_SelectByUserCardId", LongProjectsId, UserCardId);
            if (dy.Tables[0].Rows.Count > 0)
            {
                txtBranch.Value= dy.Tables[0].Rows[0]["Branch"].ToString();
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
            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            try
            {
                Convert.ToDouble(txtBranch.Value);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            double Branch = Convert.ToDouble(txtBranch.Value);
            if (Branch <= 0 || Branch > 100)
            {
                Response.Write("<script>alert('分值请输入大于0 且小于等于100的数字！')</script>");
                return;
            }
            if (bus.LongProjectsApprovalBranchInsert("LongProjectsEndBranch_Insert", LongProjectsId, UserCardId, Branch))
            {
                Response.Write("<script>alert('评审成功！');window.history.go(-1);</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('评审失败！')</script>");
            }
        }
    }
}