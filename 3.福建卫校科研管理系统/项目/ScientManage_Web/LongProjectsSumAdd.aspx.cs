using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class LongProjectsSumAdd : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsSumManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                #region 绑定
                ListItem li1 = new ListItem("--请选择--", "0");
                DLFrom.Items.Add(li1);
                DLSubject.Items.Add(li1);
                DLLevel.Items.Add(li1);
                DataTable dt = bus.Select("ProjectsFrom_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromId"].ToString());
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
                DataSet Apply = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in Apply.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DLApply.Items.Add(li);
                }
                #endregion
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
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
                    Button1.Visible = false;
                    dt.Clear();
                    DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    txtLongProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                    DlIsSchool.SelectedValue = ds.Tables[0].Rows[0]["IsSchool"].ToString();
                    DLFrom.SelectedValue = ds.Tables[0].Rows[0]["ProjectsFromId"].ToString();
                    DLSubject.SelectedValue = ds.Tables[0].Rows[0]["ProjectsSubjectId"].ToString();
                    DlDepartmentId.SelectedValue = ds.Tables[0].Rows[0]["DepartmentId"].ToString();
                    DLLevel.SelectedValue = ds.Tables[0].Rows[0]["ProjectsLevelId"].ToString();
                    DLDeclare.SelectedValue= ds.Tables[0].Rows[0]["DeclareStatus"].ToString();
                    DLStand.SelectedValue = ds.Tables[0].Rows[0]["StandStatus"].ToString();
                    DLInspect.SelectedValue = ds.Tables[0].Rows[0]["InspectStatus"].ToString();
                    DLEnd.SelectedValue = ds.Tables[0].Rows[0]["EndStatus"].ToString();
                    UserCardId = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                   
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["ZY_JobSeries"].ToString();
                    txtUserPost.Text = dt.Rows[0]["ZY_TitleLevelName"].ToString();
                    txtUserCardId.Text = UserCardId;
                }
                else
                {
                   
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    DlDepartmentId.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["ZY_JobSeries"].ToString();
                    txtUserPost.Text = dt.Rows[0]["ZY_TitleLevelName"].ToString();
                    txtUserCardId.Text = UserCardId;
                   Button2.Visible = false;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = DateTime.Now.ToString("yyyyMMddhhMMss") + DateTime.Now.Millisecond.ToString();
            string LongProjectsName = txtLongProjectsName.Text;
            int ProjectsFrom = Convert.ToInt32(DLFrom.SelectedItem.Value);
            int ProjectsLevel = Convert.ToInt32(DLLevel.SelectedItem.Value);
            int ProjectsSubject = Convert.ToInt32(DLSubject.SelectedItem.Value);
            string IsSchool = DlIsSchool.SelectedValue;
            string Company = txtCompany.Text;
            int ApplyYearId = Convert.ToInt32(DLApply.SelectedValue);
            string DeclareStatus = DLDeclare.SelectedValue;
            string InspectStatus = DLInspect.SelectedValue;
            string StandStatus = DLStand.SelectedValue;
            string EndStatus = DLEnd.SelectedValue;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);
            if (LongProjectsName == null)
            {
                Response.Write("<script>alert('请输入项目名称！')</script>");
                return;
            }
            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                Response.Write("<script>alert('请选择所在院系！')</script>");
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
           
            if (bus.LongProjectsSumInsert("LongProjectsSum_Insert", LongProjectsId, UserCardId, DepartmentId, LongProjectsName, ProjectsFrom, ProjectsSubject, ProjectsLevel, Company, IsSchool,ApplyYearId,DeclareStatus,StandStatus,InspectStatus,EndStatus))
            {
                Response.Write("<script>alert('添加成功！');window.history.go(-1);</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
            string LongProjectsName = txtLongProjectsName.Text;
            int ProjectsFrom = Convert.ToInt32(DLFrom.SelectedItem.Value);
            int ProjectsLevel = Convert.ToInt32(DLLevel.SelectedItem.Value);
            int ProjectsSubject = Convert.ToInt32(DLSubject.SelectedItem.Value);
            string Company = txtCompany.Text;
            string IsSchool = DlIsSchool.SelectedValue;
            int ApplyYearId = Convert.ToInt32(DLApply.SelectedValue);
            string DeclareStatus = DLDeclare.SelectedValue;
            string InspectStatus = DLInspect.SelectedValue;
            string StandStatus = DLStand.SelectedValue;
            string EndStatus = DLEnd.SelectedValue;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);
            if (LongProjectsName == null)
            {
                Response.Write("<script>alert('请输入项目名称！')</script>");
                return;
            }
            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                Response.Write("<script>alert('请选择所在院系！')</script>");
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

            if (bus.LongProjectsSumInsert("LongProjectsSum_Update", LongProjectsId, UserCardId, DepartmentId, LongProjectsName, ProjectsFrom, ProjectsSubject, ProjectsLevel, Company, IsSchool, ApplyYearId, DeclareStatus, StandStatus, InspectStatus, EndStatus))
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