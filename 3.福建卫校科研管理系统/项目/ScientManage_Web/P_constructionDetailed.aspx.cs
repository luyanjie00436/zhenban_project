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
    public partial class P_constructionDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int P_constructionId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["P_constructionId"] != null)
                {
                    try
                    {
                        P_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["P_constructionId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByP_constructionId("P_construction_SelectByP_constructionId", P_constructionId);

                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();

                    LP_constructionName.Text = dt.Tables[0].Rows[0]["P_constructionName"].ToString();
                    LLeve.Text = dt.Tables[0].Rows[0]["Leve"].ToString();
                    LPrincipal.Text = dt.Tables[0].Rows[0]["Principal"].ToString();
                    LCompletion.Text = dt.Tables[0].Rows[0]["Completion"].ToString();
                    LTotal_Project.Text = dt.Tables[0].Rows[0]["Total_Project"].ToString();
                    LDescription_Project.Text = dt.Tables[0].Rows[0]["Description_Project"].ToString();
                    LAnnual.Text = dt.Tables[0].Rows[0]["Annual"].ToString();
                    LDescription_year.Text = dt.Tables[0].Rows[0]["Description_year"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["P_constructionUrl"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable Partdt = bus.SelectByP_constructionId("P_constructionPartner_SelectByP_constructionId", P_constructionId).Tables[0];
              //  合作者列表
                if (Partdt.Rows.Count == 0)
                {
                    LPartner.Text = "无";
                }
                else
                {
                    for (int i = 0; i < Partdt.Rows.Count; i++)
                    {
                        if (i == Partdt.Rows.Count - 1)
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")";
                        }
                        else
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")" + ",";
                        }
                    }
                }
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                if (LFileUrl.Text == "")
                {
                    LinkButton1.Visible = false;
                }
                DataSet dy = bus.SelectByP_constructionId("P_constructionExamine_Select", P_constructionId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }

            }
        }
        //下载附件
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