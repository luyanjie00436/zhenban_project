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
    public partial class LongProjectsDeclareAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                #region 绑定
                ListItem li1 = new ListItem("--请选择--", "0");
                DLFrom.Items.Add(li1);
                DLSubject.Items.Add(li1);
                DLLevel.Items.Add(li1);
                DataTable dt = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "纵向项目申报").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                    DlCategory.Items.Add(li);
                }

                DataSet dt2 = bus.Select("ProjectsDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                dt.Clear();
                dt = bus.Select("ProjectsFrom_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                { 
                ListItem li =new ListItem(dr["ProjectsFromExplain"].ToString(),dr["ProjectsFromId"].ToString());
                    DLFrom.Items.Add(li);
                }
                dt.Clear();
                dt = bus.Select("ProjectsLevel_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsLevelExplain"].ToString(), dr["ProjectsLevelId"].ToString());
                    DLLevel.Items.Add(li);
                }
                dt.Clear();
                dt = bus.Select("ProjectsSubject_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsSubjectExplain"].ToString(), dr["ProjectsSubjectId"].ToString());
                    DLSubject.Items.Add(li);
                }
                #endregion
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
                    Button1.Visible = false;
                    RBL1.Visible = true;
                    Lxiugai.Visible = true;
                    DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    LLongProjectsId.Text = ds.Tables[0].Rows[0]["LongProjectsId"].ToString();
                    txtLongProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                    DLFrom.SelectedValue = ds.Tables[0].Rows[0]["ProjectsFromId"].ToString();
                    DLSubject.SelectedValue = ds.Tables[0].Rows[0]["ProjectsSubjectId"].ToString();
                    DLLevel.SelectedValue = ds.Tables[0].Rows[0]["ProjectsLevelId"].ToString();
                    UserCardId = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = ds.Tables[0].Rows[0]["DeclareUrl"].ToString();
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    txtDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["JobName"].ToString();
                    txtUserPost.Text = dt.Rows[0]["PostName"].ToString();
                    txtUserCardId.Text = UserCardId;
                }
                else
                {
                    RBL1.Visible = false;
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    txtDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["JobName"].ToString();
                    txtUserPost.Text = dt.Rows[0]["PostName"].ToString();
                    txtUserCardId.Text = UserCardId;
                    LLongProjectsId.Text = DateTime.Now.ToString("yyyyMMddhhMMss") + DateTime.Now.Millisecond.ToString();
                    Button2.Visible = false;
                }
            }
        }
        //下载模板
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (DlCategory.SelectedValue!="0")
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime NowDate = Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime StartDate = Convert.ToDateTime(LStartDate.Text);
            DateTime EndDate = Convert.ToDateTime(LEndDate.Text);
            if (NowDate < StartDate || NowDate > EndDate)
            {
                Response.Write("<script>alert('未在申报的有效时间内，禁止申报！')</script>");
                return;
            }
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId=LLongProjectsId.Text;
            string LongProjectsName = txtLongProjectsName.Text;
            int ProjectsFrom = Convert.ToInt32(DLFrom.SelectedItem.Value);
            int ProjectsLevel = Convert.ToInt32(DLLevel.SelectedItem.Value);
            int ProjectsSubject = Convert.ToInt32(DLSubject.SelectedItem.Value);
             string Company = txtCompany.Text;
        
            if (LongProjectsName== null)
            {
                Response.Write("<script>alert('请输入项目名称！')</script>");
                return;
            }
            if (ProjectsSubject == 0)
            {
                Response.Write("<script>alert('请选择项目类别！')</script>");
                return;
            }
            if (ProjectsLevel == 0)
            {
                Response.Write("<script>alert('请选择项目级别！')</script>");
                return;
            }
            if (ProjectsFrom == 0)
            {
                Response.Write("<script>alert('请选择项目来源！')</script>");
                return;
            }
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
                string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                LFileUrl.Text = path;
                if (bus.LongProjectsInsert("LongProjects_Insert", LongProjectsId, UserCardId, LongProjectsName,ProjectsFrom,ProjectsSubject,ProjectsLevel,Company, path))
                {
                    Response.Write("<script>alert('添加成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = LLongProjectsId.Text;
            string LongProjectsName = txtLongProjectsName.Text;
            int ProjectsFrom = Convert.ToInt32( DLFrom.SelectedItem.Value);
            int ProjectsLevel = Convert.ToInt32(DLLevel.SelectedItem.Value);
            int ProjectsSubject = Convert.ToInt32(DLSubject.SelectedItem.Value);
            string Company = txtCompany.Text;
            string LongProjectsCategory = DlCategory.SelectedItem.Text;

            if (LongProjectsName == null)
            {
                Response.Write("<script>alert('请输入项目名称！')</script>");
                return;
            }
            if (ProjectsSubject== 0)
            {
                Response.Write("<script>alert('请选择项目类别！')</script>");
                return;
            }
            if (ProjectsLevel == 0)
            {
                Response.Write("<script>alert('请选择项目级别！')</script>");
                return;
            }
            if (ProjectsFrom == 0)
            {
                Response.Write("<script>alert('请选择项目来源！')</script>");
                return;
            }
            string path=LFileUrl.Text;
            string RBL = RBL1.SelectedItem.Value;
            if (RBL=="是")
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
                string sPath = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                path = Server.MapPath("./") + "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "LongProjects" + "\\" + LongProjectsId + "\\Declare\\" + upName;
                LFileUrl.Text = path;
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
            }
            }
            if (bus.LongProjectsInsert("LongProjects_Update", LongProjectsId, UserCardId, LongProjectsName, ProjectsFrom, ProjectsSubject, ProjectsLevel, Company, path))
            {
                Response.Write("<script>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
            }

        }
    }
}