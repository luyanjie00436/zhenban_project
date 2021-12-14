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
    public partial class LongCapitalChangeAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
        protected static string type;
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
                    DataTable dt2 = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "经费预算变更").Tables[0];
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                        DlCategory.Items.Add(li);
                    }
                    DataSet dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    LProjectsId.Text = LongProjectsId;
                    LProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsFromExplain.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalBasic_SelectByLongProjectsId", LongProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        LBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                        LSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                        LOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                        LSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                        LServicelife.Text = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                        LSumMoney.Text = dt.Tables[0].Rows[0]["SumMoney"].ToString();
                    }
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalChange_SelectByLongProjectsId", LongProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        LFileUrl.Text = dt.Tables[0].Rows[0]["LongCapitalChangeUrl"].ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }


            }

        }
        //下载模板
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (DlCategory.SelectedValue != "0")
            {
                string path = Server.MapPath("./") + DlCategory.SelectedValue;
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
                Response.Write("<script>alert('请选择类别！')</script>");
                return;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = LProjectsId.Text;
            string path = LFileUrl.Text;
            if (!fupFileSend.HasFile)
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                return;
            }
            try
            {
                //获取上传文件的名称
                string upName = fupFileSend.FileName;
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                //创建文件夹
                string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalChange\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalChange\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\CapitalChange\\" + upName;
                LFileUrl.Text = path;
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('文件上传失败！')</script>");
            }

            if (path == "")
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后保存！')</script>");
                return;
            }
            if (bus.LongCapitalPlanInsert("LongCapitalChange_Insert", LongProjectsId, UserCardId, path))
            {
                Response.Write("<script>alert('保存成功！');window.history.go(-2);</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (LFileUrl.Text != "")
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