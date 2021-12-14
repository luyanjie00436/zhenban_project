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
    public partial class LongProjectsInspectAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
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
                #region 绑定
                DataTable dt = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "纵向项目中检").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                    DlCategory.Items.Add(li);
                }
                dt.Clear();
                #endregion
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
                   
                    RBL1.Visible = true;
                    Lxiugai.Visible = true;
                    DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    LLongProjectsId.Text = ds.Tables[0].Rows[0]["LongProjectsId"].ToString();
                    LLongProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LFrom.Text = ds.Tables[0].Rows[0]["ProjectsFromId"].ToString();
                    LSubject.Text = ds.Tables[0].Rows[0]["ProjectsSubjectId"].ToString();
                    LLevel.Text = ds.Tables[0].Rows[0]["ProjectsLevelId"].ToString();
                    UserCardId = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                    LCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = ds.Tables[0].Rows[0]["InspectUrl"].ToString();
                    if (LFileUrl.Text=="")
                    {
                        RBL1.SelectedValue = "是";
                    }
                    else
                    {
                        RBL1.SelectedValue = "否";
                    }
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    //txtDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["ZY_JobSeries"].ToString();
                    txtUserPost.Text = dt.Rows[0]["ZY_TitleLevelName"].ToString();
                    txtUserCardId.Text = UserCardId;
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
        //下载附件
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

     
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = LLongProjectsId.Text;
            string path = LFileUrl.Text;
            string RBL = RBL1.SelectedItem.Value;
            if (RBL == "是")
            {
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
                    string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Inspect\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Inspect\\" + upName;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Inspect\\" + upName;
                    LFileUrl.Text = path;
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    Response.Write("<script>alert('文件上传失败！')</script>");
                }
            }
            if (path=="")
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后保存！')</script>");
                return;
            }
            if (bus.LongProjectsApprovalInsert("LongProjectsInspect_Update", LongProjectsId, path))
            {
                Response.Write("<script>alert('保存成功！');window.history.go(-1);</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
            }
          

        }
    }
}