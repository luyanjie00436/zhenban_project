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
    public partial class WorkLoadProjectsDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int WorkLoadProjectsId;
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
                if (Request.QueryString["WorkLoadProjectsId"] != null)
                {
                    try
                    {
                        WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByWorkLoadProjectsId("WorkLoadProjects_SelectByWorkLoadProjectsId", WorkLoadProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LDepartmentName.Text = dt.Tables[0].Rows[0]["DepartmentName"].ToString();
                    LCateGory.Text = dt.Tables[0].Rows[0]["CateGory"].ToString();
                    LProjectsId.Text = dt.Tables[0].Rows[0]["ProjectsId"].ToString();
                    LWorkLoadProjectsFrom.Text = dt.Tables[0].Rows[0]["WorkLoadFrom"].ToString();
                    LWorkLoadProjectsName.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsName"].ToString();
                    LStartEndDate.Text = dt.Tables[0].Rows[0]["StartEndDate"].ToString();

                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LWorkLoadProjectsCapital.Text = dt.Tables[0].Rows[0]["WorkLoadCapital"].ToString();
                    LWorkLoadProjectsValue.Text = dt.Tables[0].Rows[0]["ProjectsValue"].ToString();
                    LSumProjectsValue.Text = dt.Tables[0].Rows[0]["SumProjectsValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsUrl"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable Partdt = bus.SelectByWorkLoadProjectsId("WorkLoadProjectsPartner_SelectByWorkLoadProjectsId", WorkLoadProjectsId).Tables[0];
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
                 DataSet dy = bus.SelectByWorkLoadProjectsId("WorkLoadProjectsExamine_Select", WorkLoadProjectsId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }
                if (LFileUrl.Text == "")
                {
                    LinkButton1.Visible = false;
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