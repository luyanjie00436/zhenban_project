using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class UserInfoUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoUpd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
               int RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));

                string select_UserCardId = null;

                if (Request.QueryString["UserCardId"] != null)
                {
                    select_UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");

                }
                if (select_UserCardId != null)
                {
                    UserCardId = select_UserCardId;
                }
                else
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    Button2.Visible = false;
                }
                #region
                DataTable dts2 = bus.Select("Nation_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["NationName"].ToString(), dr["NationName"].ToString());
                    DlNation.Items.Add(li);
                }
                dts2 = bus.Select("Political_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalName"].ToString());
                    DlPolitical.Items.Add(li);
                }
                dts2 = bus.Select("Status_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["StatusName"].ToString(), dr["StatusName"].ToString());
                    DlStatusName.Items.Add(li);
                }
                dts2 = bus.Select("Department_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                    DlGL_Department.Items.Add(li);
                   
                }
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                   
                    DlZY_Department.Items.Add(li);
                }
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                    DlGQ_Department.Items.Add(li);
                }
                dts2 = bus.Select("Education_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["EducationName"].ToString(), dr["EducationName"].ToString());
                    Dl_DYXL.Items.Add(li);
                }
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["EducationName"].ToString(), dr["EducationName"].ToString());
                 
                    Dl_ZGXL.Items.Add(li);
                }
                dts2 = bus.Select("Degree_Select").Tables[0];
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["DegreeName"].ToString(), dr["DegreeName"].ToString());
                    Dl_DYXW.Items.Add(li);
                }
                foreach (DataRow dr in dts2.Rows)
                {
                    ListItem li = new ListItem(dr["DegreeName"].ToString(), dr["DegreeName"].ToString());
                    Dl_ZGXW.Items.Add(li);
                }
                #endregion
                DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
                txtUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
                txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                RBUserGender.SelectedValue = ds.Tables[0].Rows[0]["性别"].ToString();
                txtIdCardNo.Text = ds.Tables[0].Rows[0]["身份证号"].ToString();
                if (ds.Tables[0].Rows[0]["出生年月"].ToString() != "")
                {
                    txtBirthday.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["出生年月"].ToString()).ToString("yyyy-MM-dd");

                }

                DlNation.SelectedValue = ds.Tables[0].Rows[0]["民族"].ToString();
                DlPolitical.SelectedValue = ds.Tables[0].Rows[0]["政治面貌"].ToString();
                txtPartyDate.Value = ds.Tables[0].Rows[0]["入党时间"].ToString();
                txtTakeWorkDate.Value = ds.Tables[0].Rows[0]["参加工作时间"].ToString();
                txtEntryDate.Value = ds.Tables[0].Rows[0]["入职院校时间"].ToString();
                txtOrigin.Text = ds.Tables[0].Rows[0]["籍贯"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["家庭地址"].ToString();
                DlStatusName.SelectedValue = ds.Tables[0].Rows[0]["在职状态"].ToString();
                RlGL_Management.SelectedValue = ds.Tables[0].Rows[0]["是否管理干部"].ToString();
                DlGL_CadreLevelName.SelectedValue = ds.Tables[0].Rows[0]["干部职级"].ToString();
                txtGL_RoleName.Text = ds.Tables[0].Rows[0]["现任职务"].ToString();
                DlGL_Department.SelectedValue = ds.Tables[0].Rows[0]["所在部门"].ToString();
                txtGL_StartDate.Value = ds.Tables[0].Rows[0]["任现职务时间"].ToString();
                DlGL_ManagerLevelName.SelectedValue = ds.Tables[0].Rows[0]["管理职级"].ToString();
                RlZY_SkillTitle.SelectedValue = ds.Tables[0].Rows[0]["有无具有专业技术职称"].ToString();
                DlZY_JobSeries.SelectedValue = ds.Tables[0].Rows[0]["职称系列"].ToString();
                DlZY_TitleLevelName.SelectedValue = ds.Tables[0].Rows[0]["职称等级"].ToString();
                DlZY_SpecialSkills.SelectedValue = ds.Tables[0].Rows[0]["专技职级"].ToString();
                DlZY_Department.SelectedValue = ds.Tables[0].Rows[0]["所属部门"].ToString();
                txtZY_StartDate.Value = ds.Tables[0].Rows[0]["任现职称时间"].ToString();
                RlJS_TeachersSeries.SelectedValue = ds.Tables[0].Rows[0]["是否属于教师系列"].ToString();
                DlJS_TeacherCategory.SelectedValue = ds.Tables[0].Rows[0]["教师类别"].ToString();
                txtJS_CertificateDate.Value = ds.Tables[0].Rows[0]["高校教师资格证书获取时间"].ToString();
                RlJS_MajorLeading.SelectedValue = ds.Tables[0].Rows[0]["现是否为专业带头人或负责人"].ToString();
                RlJS_BoneTeacher.SelectedValue = ds.Tables[0].Rows[0]["现是否为骨干教师"].ToString();
                RlJS_DoubleTeacher.SelectedValue = ds.Tables[0].Rows[0]["现是否为双师型教师"].ToString();
                RlGQ_WorkersPeople.SelectedValue = ds.Tables[0].Rows[0]["是否工勤人员"].ToString();
                DlGQ_PostName.SelectedValue = ds.Tables[0].Rows[0]["职级"].ToString();
                DlGQ_Appointment.SelectedValue = ds.Tables[0].Rows[0]["任现职级"].ToString();
                txtGQ_StartDate.Value = ds.Tables[0].Rows[0]["任现职级时间"].ToString();
                DlGQ_Department.SelectedValue = ds.Tables[0].Rows[0]["工勤人员所在部门"].ToString();
                Dl_DYXL.SelectedValue = ds.Tables[0].Rows[0]["第一学历"].ToString();
                txtDYXL_Date.Value = ds.Tables[0].Rows[0]["第一学历获得时间"].ToString();
                txtDYXL_School.Text = ds.Tables[0].Rows[0]["第一学历毕业院校"].ToString();
                txtDYXL_Profession.Text = ds.Tables[0].Rows[0]["第一学历专业"].ToString();
                Dl_ZGXL.SelectedValue = ds.Tables[0].Rows[0]["最高学历"].ToString();
                txtZGXL_Date.Value = ds.Tables[0].Rows[0]["最高学历获得时间"].ToString();
                txtZGXL_School.Text = ds.Tables[0].Rows[0]["最高学历毕业院校"].ToString();
                txtZGXL_Profession.Text = ds.Tables[0].Rows[0]["最高学历专业"].ToString();
                Dl_DYXW.SelectedValue = ds.Tables[0].Rows[0]["第一学位"].ToString();
                txtDYXW_Date.Value = ds.Tables[0].Rows[0]["第一学位获得时间"].ToString();
                txtDYXW_School.Text = ds.Tables[0].Rows[0]["第一学位毕业院校"].ToString();
                txtDYXW_Profession.Text = ds.Tables[0].Rows[0]["第一学位专业"].ToString();
                Dl_ZGXW.SelectedValue = ds.Tables[0].Rows[0]["最高学位"].ToString();
                txtZGXW_Date.Value = ds.Tables[0].Rows[0]["最高学位获得时间"].ToString();
                txtZGXW_School.Text = ds.Tables[0].Rows[0]["最高学位毕业院校"].ToString();
                txtZGXW_Profession.Text = ds.Tables[0].Rows[0]["最高学位专业"].ToString();


                DataSet dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                if (dt.Tables[0].Rows[0]["Photo"] == DBNull.Value)
                {
                    Image2.Src = "";
                }
                else
                {
                    Image2.Src = "imgs.aspx?id=" + UserCardId;

                }
             
                if (dt.Tables[0].Rows[0]["UserLock"].ToString() == "锁定")
                {
                   
                    Button1.Enabled = false;
                    Panel1.Enabled = false;
                }
                #endregion
             
                dataGriviewBD(UserCardId);
            }

        }
        public void qiyong()
        {
           
        }
        public void dataGriviewBD(string UserCardId)
        {
            DataSet ds = bus.SelectByUserCardId("Total_Selects",UserCardId);
            if (ds.Tables[0].Rows.Count==0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            }
            if (ds.Tables[1].Rows.Count == 0)
            {
                ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
            }
            if (ds.Tables[2].Rows.Count == 0)
            {
                ds.Tables[2].Rows.Add(ds.Tables[2].NewRow());
            }
            if (ds.Tables[3].Rows.Count == 0)
            {
                ds.Tables[3].Rows.Add(ds.Tables[3].NewRow());
            }
            if (ds.Tables[4].Rows.Count == 0)
            {
                ds.Tables[4].Rows.Add(ds.Tables[4].NewRow());
            }
            if (ds.Tables[5].Rows.Count == 0)
            {
                ds.Tables[5].Rows.Add(ds.Tables[5].NewRow());
            }
            if (ds.Tables[6].Rows.Count == 0)
            {
                ds.Tables[6].Rows.Add(ds.Tables[6].NewRow());
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();
            GridView3.DataSource = ds.Tables[2];
            GridView3.DataBind();
            GridView4.DataSource = ds.Tables[3];
            GridView4.DataBind();
            GridView5.DataSource = ds.Tables[4];
            GridView5.DataBind();
            GridView6.DataSource = ds.Tables[5];
            GridView6.DataBind();  
            GridView7.DataSource = ds.Tables[6];
            GridView7.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD(txtUserCardId.Text.Trim());
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectDepartmentId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("YearAssessmentManage.aspx");
        }
        #region 图片保存成二进制
        public byte[] GetPictureData(string imagepath)
        {
            FileStream fs = new FileStream(imagepath, FileMode.Open);//可以是其他重载方法 
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            return byData;
        }


        #endregion
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserIdCard = txtIdCardNo.Text.Trim().ToString();
            string UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            UserCardId = txtUserCardId.Text.Trim();//工号
            string UserGender = RBUserGender.SelectedValue;//性别
            string IdCardNo = txtIdCardNo.Text;//身份证
            string NationName = DlNation.SelectedValue;//民族
            string UserName = txtUserName.Text;//姓名
            string PoliticalName = DlPolitical.SelectedValue;//政治面貌
            string PartyDate = txtPartyDate.Value.Trim();//入党时间
            string TakeWorkDate = txtTakeWorkDate.Value.Trim();//参加工作时间
            string EntryDate = txtEntryDate.Value.Trim();//入职学院时间
            //string Origin1 = txtOrigin1.Text.Trim();//省
            //string Origin2 = txtOrigin2.Text.Trim();//市
            string Origin = txtOrigin.Text.Trim();//籍贯
            string Address = txtAddress.Text.Trim();//家庭住址
            string StatusName = DlStatusName.SelectedValue; //在职状态
            string GL_Management = RlGL_Management.SelectedValue;//是否管理干部 单选
            string GL_CadreLevelName = DlGL_CadreLevelName.SelectedItem.Value;//干部职级  下拉
            string GL_RoleName = txtGL_RoleName.Text.Trim();//现任职务
            string GL_DepartmentName = DlGL_Department.SelectedValue;//所在部门
            string GL_StartDate = txtGL_StartDate.Value.Trim();//任现职务时间
            string GL_ManagerLevelName = DlGL_ManagerLevelName.SelectedItem.Value;//管理职级
            string ZY_SkillTitle = RlZY_SkillTitle.SelectedValue;//有无具有专业技术职称
            string ZY_JobSeries = DlZY_JobSeries.SelectedItem.Value;//职称系列
            string ZY_TitleLevelName = DlZY_TitleLevelName.SelectedItem.Value;//职称等级
            string ZY_SpecialSkills = DlZY_SpecialSkills.SelectedItem.Value;//专技职级
            string ZY_DepartmentName = DlZY_Department.SelectedValue;//所属部门
            string ZY_StartDate = txtZY_StartDate.Value.Trim();//任现职称时间
            string JS_TeachersSeries = RlJS_TeachersSeries.SelectedValue;//是否属于教师系列
            string JS_TeacherCategory = DlJS_TeacherCategory.SelectedItem.Value;//教师类别
            string JS_CertificateDate = txtJS_CertificateDate.Value.Trim();//高校教师资格证书获取时间
            string JS_MajorLeading = RlJS_MajorLeading.SelectedValue;//现是否为专业带头人或负责人
            string JS_BoneTeacher = RlJS_BoneTeacher.SelectedValue;//现是否为骨干教师
            string JS_DoubleTeacher = RlJS_DoubleTeacher.SelectedValue;//现是否为双师型教师
            string GQ_WorkersPeople = RlGQ_WorkersPeople.SelectedValue;//是否工勤人员
            string GQ_PostName = DlGQ_PostName.SelectedItem.Value;//职级
            string GQ_Appointment = DlGQ_Appointment.SelectedItem.Value;//任现职级
            string GQ_StartDate = txtGQ_StartDate.Value.Trim();//任现职务时间
            string GQ_DepartmentName = DlGQ_Department.SelectedValue;//所属部门
            //学历学位
            string DYXL_Name = Dl_DYXL.SelectedValue;//第一学历
            string DYXL_Date = txtDYXL_Date.Value.Trim();//获得时间
            string DYXL_School = txtDYXL_School.Text.Trim();//毕业院校
            string DYXL_Profession = txtDYXL_Profession.Text.Trim();//专业

            string ZGXL_Name = Dl_ZGXL.SelectedValue;//最高学历
            string ZGXL_Date = txtZGXL_Date.Value.Trim();//获得时间
            string ZGXL_School = txtZGXL_School.Text.Trim();//毕业院校
            string ZGXL_Profession = txtZGXL_Profession.Text.Trim();//专业

            string DYXW_Name = Dl_DYXW.SelectedValue;//第一学位
            string DYXW_Date = txtDYXW_Date.Value.Trim();//获得时间
            string DYXW_School = txtDYXW_School.Text.Trim();//毕业院校
            string DYXW_Profession = txtDYXW_Profession.Text.Trim();//专业

            string ZGXW_Name = Dl_ZGXW.SelectedValue;//最高学位
            string ZGXW_Date = txtZGXW_Date.Value.Trim();//获得时间
            string ZGXW_School = txtZGXW_School.Text.Trim();//毕业院校
            string ZGXW_Profession = txtZGXW_Profession.Text.Trim();//专业

            if (IdCardNo != "")
            {
                if (!CheckIDCard(IdCardNo))
                {
                    Response.Write("<script>alert('身份证号码格式错误！')</script>");
                    return;
                }
            }
            if (!bus.UserInfoUpdate("UserInfo_Update", UserCardId, UserName, UserGender,IdCardNo, NationName, PoliticalName, PartyDate,
                TakeWorkDate, EntryDate, Origin, Address, StatusName, GL_Management, GL_CadreLevelName, GL_RoleName, GL_DepartmentName,
                GL_StartDate, GL_ManagerLevelName, ZY_SkillTitle, ZY_JobSeries, ZY_TitleLevelName, ZY_SpecialSkills, ZY_DepartmentName,
                ZY_StartDate, JS_TeachersSeries, JS_TeacherCategory, JS_CertificateDate, JS_MajorLeading, JS_BoneTeacher, JS_DoubleTeacher,
                GQ_WorkersPeople, GQ_PostName, GQ_Appointment, GQ_StartDate, GQ_DepartmentName, DYXL_Name, DYXL_Date, DYXL_School,
                DYXL_Profession, ZGXL_Name, ZGXL_Date, ZGXL_School, ZGXL_Profession, DYXW_Name, DYXW_Date, DYXW_School, DYXW_Profession,
                ZGXW_Name, ZGXW_Date, ZGXW_School, ZGXW_Profession))
            {
                Response.Write("<script>alert('修改失败！')</script>");
                return;
            }
            Response.Write("<script>alert('修改成功！');" + "window.location.href='UserInfoUpd.aspx?" + Request.QueryString + "'</script>");
            return;

        }
     


        /// <summary>    
        /// 验证身份证号码    
        /// </summary>    
        /// <param name="Id">身份证号码</param>    
        /// <returns>验证成功为True，否则为False</returns>    
        public bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>    
        /// 验证18位身份证号    
        /// </summary>    
        /// <param name="Id">身份证号</param>    
        /// <returns>验证成功为True，否则为False</returns>   
        public bool CheckIDCard18(string Id)
        {

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证 
            }

            return true;//符合GB11643-1999标准 
        }
        /// <summary>    
        /// 验证15位身份证号    
        /// </summary>    
        /// <param name="Id">身份证号</param>    
        /// <returns>验证成功为True，否则为False</returns>  
        public bool CheckIDCard15(string Id)
        {

            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证 
            }
            return true;//符合15位身份证标准 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void RlGL_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RlGL_Management.SelectedValue=="是")
            {

                DlGL_CadreLevelName.Enabled = true;
                txtGL_RoleName.Enabled = true;
                DlGL_Department.Enabled = true;
                txtGL_StartDate.Disabled = true;
                DlGL_ManagerLevelName.Enabled = true;
            }
            else
            {
                DlGL_CadreLevelName.Enabled = false;
                DlGL_CadreLevelName.SelectedValue = "";
                txtGL_RoleName.Enabled = false;
                txtGL_RoleName.Text = "";
                DlGL_Department.Enabled = false;
                DlGL_Department.SelectedValue=null;
                txtGL_StartDate.Disabled = false;
                txtGL_StartDate.Value = "";
                DlGL_ManagerLevelName.Enabled = false;
                DlGL_ManagerLevelName.SelectedValue = "";
            }
        }

        protected void RlZY_SkillTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RlZY_SkillTitle.SelectedValue =="是")
            {
                DlZY_JobSeries.Enabled = true;
                DlZY_TitleLevelName.Enabled = true;
                DlZY_SpecialSkills.Enabled = true;
                DlZY_Department.Enabled = true;
                txtZY_StartDate.EnableViewState = true;
            }
            else
            {
                DlZY_JobSeries.Enabled = false;
                DlZY_TitleLevelName.Enabled = false;
                DlZY_SpecialSkills.Enabled = false;
                DlZY_Department.Enabled = false;
                txtZY_StartDate.EnableViewState = false;
                DlZY_JobSeries.SelectedValue = "";
                DlZY_TitleLevelName.SelectedValue = "";
                DlZY_SpecialSkills.SelectedValue = "";
                DlZY_Department.SelectedValue=null;
                txtZY_StartDate.Value ="";
            }
        }

        protected void RlJS_TeachersSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RlJS_TeachersSeries.SelectedValue == "是")
            {
                DlJS_TeacherCategory.Enabled = true;
                txtJS_CertificateDate.EnableViewState = true;
                RlJS_MajorLeading.Enabled = true;
                RlJS_BoneTeacher.Enabled = true;
                RlJS_DoubleTeacher.Enabled = true;


            }
            else
            {
                DlJS_TeacherCategory.Enabled = false;
                txtJS_CertificateDate.EnableViewState = false;
                RlJS_MajorLeading.Enabled = false;
                RlJS_BoneTeacher.Enabled = false;
                RlJS_DoubleTeacher.Enabled = false;
                DlJS_TeacherCategory.SelectedValue = null;
                txtJS_CertificateDate.Value = null;
                RlJS_MajorLeading.SelectedValue = null;
                RlJS_BoneTeacher.SelectedValue = null;
                RlJS_DoubleTeacher.SelectedValue = null;
            }
        }

        protected void RlGQ_WorkersPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RlGQ_WorkersPeople.SelectedValue == "是")
            {
                DlGQ_PostName.Enabled = true;
                DlGQ_Appointment.Enabled = true;
                txtGQ_StartDate.EnableViewState = true;
                DlGQ_Department.Enabled = true;
            }
            else
            {
                DlGQ_PostName.Enabled = false;
                DlGQ_Appointment.Enabled = false;
                txtGQ_StartDate.EnableViewState = false;
                DlGQ_Department.Enabled = false;
                DlGQ_PostName.SelectedValue = null;
                DlGQ_Appointment.SelectedValue = null;
                txtGQ_StartDate.Value = null;
                DlGQ_Department.SelectedValue = null;
            }
        }
    }

}