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
    public partial class ShortCapitalCloseDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        string ShortProjectsId;
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
                if (Request.QueryString["ShortProjectsId"] != null)
                {
                    try
                    {
                        ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByShortProjectsId("ShortProjects_SelectByShortProjectsId", ShortProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LShortProjectsId.Text = dt.Tables[0].Rows[0]["ShortProjectsId"].ToString();
                    LContractId.Text = dt.Tables[0].Rows[0]["ContractId"].ToString();
                    LContractName.Text = dt.Tables[0].Rows[0]["ContractName"].ToString();
                    LContractMoney.Text = dt.Tables[0].Rows[0]["ContractMoney"].ToString();
                    dt.Clear();
                    dt = bus.SelectByShortProjectsId("ShortCapitalBasic_SelectByShortProjectsId", ShortProjectsId);
                    LBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                    LSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                    LOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                    LSumMoney.Text = dt.Tables[0].Rows[0]["SumMoney"].ToString();
                    LSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                    LServicelife.Text = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                    dt.Clear();
                    dt = bus.SelectByShortProjectsId("ShortCapitalClose_SelectByShortProjectsId", ShortProjectsId);
                    LFileUrl.Text = dt.Tables[0].Rows[0]["ShortCapitalCloseUrl"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }


                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
            DataSet dy = bus.SelectByShortProjectsId("ShortCapitalCloseExamine_Select", ShortProjectsId);
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