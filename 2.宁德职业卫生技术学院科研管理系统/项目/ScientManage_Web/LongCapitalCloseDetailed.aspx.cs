using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LongCapitalCloseDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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