using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class UserInfoUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoUpd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                int RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                DataTable dtb = bus.SelectByRankId("Rank_SelectByRankId", RankId).Tables[0];
                if (dtb.Rows[0]["RBL"].ToString() == "是")
                {
                    qiyong();
                }
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
                #region bd
                this.CBAdminSeries.DataTextField = "AdminSeriesName";
                this.CBAdminSeries.DataValueField = "AdminSeriesId";
                this.CBAdminSeries.DataSource = bus.Select("AdminSeries_Select").Tables[0].DefaultView;
                this.CBAdminSeries.DataBind();

                DataSet department = bus.Select("Department_Select");
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartment2.Items.Add(li);
                }
                DataSet Status = bus.Select("Status_Select");
                foreach (DataRow dr in Status.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["StatusName"].ToString(), dr["StatusId"].ToString());
                    DlStatus.Items.Add(li);
                }
                DataSet Job = bus.Select("Job_Select");
                foreach (DataRow dr in Job.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["JobName"].ToString(), dr["JobId"].ToString());
                    DlJob.Items.Add(li);
                }
                DataSet Post = bus.Select("Post_Select");
                foreach (DataRow dr in Post.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PostName"].ToString(), dr["PostId"].ToString());
                    DlPost.Items.Add(li);
                }
                DataSet Nation = bus.Select("Nation_Select");
                foreach (DataRow dr in Nation.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["NationName"].ToString(), dr["NationId"].ToString());
                    DlNation.Items.Add(li);
                }
                DataSet Political = bus.Select("Political_Select");
                foreach (DataRow dr in Political.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalId"].ToString());
                    DlPolitical.Items.Add(li);
                }
                DataSet Education = bus.Select("Education_Select");
                foreach (DataRow dr in Education.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["EducationName"].ToString(), dr["EducationId"].ToString());
                    DlEducation.Items.Add(li);
                }
                DataSet Degree = bus.Select("Degree_Select");
                foreach (DataRow dr in Degree.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DegreeName"].ToString(), dr["DegreeId"].ToString());
                    DlDegree.Items.Add(li);
                }

                #endregion
                DataSet ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                DataSet de = bus.SelectByUserCardId("Email_SelectByUserCardId", UserCardId);
                DataSet dp = bus.SelectByUserCardId("Phone_SelectByUserCardId", UserCardId);
                txtUserCardId.Text = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                try
                {
                    txtStartWork.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["StartWorkDate"].ToString()).ToString("yyyy-MM-dd");
                }
                catch (Exception)
                {
                    
                
                }
              

                txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                try
                {
                    txtBirthday.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"].ToString()).ToString("yyyy-MM-dd");
                }
                catch (Exception)
                {
                    
             
                }
               
                txtUserIdCard.Text = ds.Tables[0].Rows[0]["UserIdCard"].ToString();
                txtOrigin.Text = ds.Tables[0].Rows[0]["Origin"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtIntroDucation.Text = ds.Tables[0].Rows[0]["UserIntroDucation"].ToString();
                if (dp.Tables[0].Rows.Count > 0)
                {
                    txtPhone.Text = dp.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                }
                else
                {
                    txtPhone.Text = "";
                }
                if (de.Tables[0].Rows.Count > 0)
                {
                    txtEmail.Text = de.Tables[0].Rows[0]["IndividuaNumber"].ToString();
                }
                else
                {
                    txtEmail.Text = "";
                }
                radioGender.SelectedValue = ds.Tables[0].Rows[0]["UserGender"].ToString();
                DlMarriage.SelectedValue = ds.Tables[0].Rows[0]["Marriage"].ToString();
                DlStatus.SelectedValue = ds.Tables[0].Rows[0]["UserStatusId"].ToString();
                DlDepartment.SelectedValue = ds.Tables[0].Rows[0]["UserDepartmentId"].ToString();
                DlJob.SelectedValue = ds.Tables[0].Rows[0]["UserJobId"].ToString();
                DlPost.SelectedValue = ds.Tables[0].Rows[0]["UserPostId"].ToString();
                DlNation.SelectedValue = ds.Tables[0].Rows[0]["UserNationId"].ToString();
                DlPolitical.SelectedValue = ds.Tables[0].Rows[0]["UserPoliticalId"].ToString();
                DlEducation.SelectedValue = ds.Tables[0].Rows[0]["UserEducationId"].ToString();
                DlDegree.SelectedValue = ds.Tables[0].Rows[0]["UserDegreeId"].ToString();
                DlDepartment2.SelectedValue = ds.Tables[0].Rows[0]["TeachersDepartmentId"].ToString();
                txtRemuneration.Text = ds.Tables[0].Rows[0]["Remuneration"].ToString();
                if (ds.Tables[0].Rows[0]["Ranktime"].ToString().Length > 2)
                {
                    txtRanktime.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["Ranktime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtRanktime.Value = "";
                }
                if (ds.Tables[0].Rows[0]["PostTime"].ToString().Length > 2)
                {
                    txtPostTime.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["PostTime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtPostTime.Value = "";
                }
                if (ds.Tables[0].Rows[0]["JobTime"].ToString().Length > 2)
                {
                    txtJobTime.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["JobTime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtJobTime.Value = "";
                } txtJobSeries.Text = ds.Tables[0].Rows[0]["JobSeries"].ToString();
                radioTeachers.SelectedValue = ds.Tables[0].Rows[0]["TeachersSeries"].ToString();
                radioManagement.SelectedValue = ds.Tables[0].Rows[0]["Management"].ToString();
                txtWorkLevel.Text = ds.Tables[0].Rows[0]["WorkLevel"].ToString();
                DataTable dt = bus.SelectByUserCardId("UserAdminSeries_SelectByUserCardId", UserCardId).Tables[0];
                for (int i = 0; i < this.CBAdminSeries.Items.Count; i++)
                {
                    DataRow[] dr = dt.Select("AdminSeriesId=" + Convert.ToInt32(this.CBAdminSeries.Items[i].Value));
                    if (dr.Length > 0)
                    {
                        this.CBAdminSeries.Items[i].Selected = true;
                    }

                }
                #endregion
                AOtherPhone.HRef = AOtherPhone.HRef + "?UserCardId=" + pwds.EncryptDES(UserCardId, "asdfasdf") + "&keepThis=true&TB_iframe=true&height=300&width=500";
                AOtherEmail.HRef = AOtherEmail.HRef + "?UserCardId=" + pwds.EncryptDES(UserCardId, "asdfasdf") + "&keepThis=true&TB_iframe=true&height=300&width=500";
               
                dataGriviewBD();
            }


        }
        public void qiyong()
        {
           
            DlDepartment.Enabled = true;  
            txtUserName.ReadOnly = false;
            Button5.Enabled = true;
            GridView1.Visible = true;
            GridView2.Visible = false;
        }
        public void dataGriviewBD()
        {
            UserCardId = txtUserCardId.Text;
            DataTable dt2 = bus.SelectByUserCardId("UserRole_SelectByUserCardId", UserCardId).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                txtUserRole.Visible = false;
                Button5.Visible = false;
            }
            GridView1.DataSource = dt2.DefaultView;
            GridView1.DataBind();
            GridView2.DataSource = dt2.DefaultView;
            GridView2.DataBind();

        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            UserCardId = pwds.EncryptDES(txtUserCardId.Text, "asdfasdf");
            string UserName = pwds.EncryptDES(txtUserName.Text, "asdfasdf");
            Response.Redirect("UserRole.aspx?UserCardId=" + UserCardId + "&UserName=" + UserName);
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            UserCardId = pwds.EncryptDES(txtUserCardId.Text, "asdfasdf");
            string UserName = pwds.EncryptDES(txtUserName.Text, "asdfasdf");
            Response.Redirect("UserRole.aspx?UserCardId=" + UserCardId + "&UserName=" + UserName);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string  UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string UserIdCard = txtUserIdCard.Text.Trim().ToString();
            UserCardId = txtUserCardId.Text.Trim().ToString();
            int PoliticalId = Convert.ToInt32(DlPolitical.SelectedItem.Value);
            int EducationId = Convert.ToInt32(DlEducation.SelectedItem.Value);
            int DegreeId = Convert.ToInt32(DlDegree.SelectedItem.Value);
            string Marriage = DlMarriage.SelectedItem.Value;
            string Origin = txtOrigin.Text.Trim().ToString();
            string Address = txtAddress.Text.Trim().ToString();
            string IntroDucation = txtIntroDucation.Text.Trim().ToString();
            string PhoneNumber = txtPhone.Text.Trim().ToString();
            string EmailNumber = txtEmail.Text.Trim().ToString();
            string emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
            //邮箱正则表达式对象
            Regex emailReg = new Regex(emailStr);
            int StatusId = Convert.ToInt32(DlStatus.SelectedValue);
            int DepartmentId = Convert.ToInt32(DlDepartment.SelectedValue);
            int JobId = Convert.ToInt32(DlJob.SelectedValue);
            int PostId = Convert.ToInt32(DlPost.SelectedValue);
            string UserName = txtUserName.Text.Trim();
            string Gender = radioGender.SelectedValue;
            string Birthday = txtBirthday.Value;
            int NationId = Convert.ToInt32(DlNation.SelectedValue);
            string Remuneration = txtRemuneration.Text;
            string Ranktime = txtRanktime.Value;
            int TeachersDepartmentId = Convert.ToInt32(DlDepartment2.SelectedValue);
            string JobTime = txtJobTime.Value;
            string PostTime = txtPostTime.Value;
            string JobSeries = txtJobSeries.Text;
            string TeachersSeries = radioTeachers.SelectedValue;
            string WorkLevel = txtWorkLevel.Text;
            string Management = radioManagement.SelectedValue;
            if (EmailNumber!="")
            {
                if (!emailReg.IsMatch(EmailNumber))
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "邮箱格式不正确！");
                    return;
                }
            }
           
            if (UserName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "姓名不能为空");
                return;

            }
            if (   Birthday =="")
            {
                  AlertMsgAndNoFlush(UpdatePanel1, "出生日期不能为空！");
                    return;
            }
            if (UserIdCard != "")
            {
                if (!CheckIDCard(UserIdCard))
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "身份证格式输入错误");
                    return;
                }
            }
          
            bus.DeleteByUserCardId("UserAdminSeries_Delete", UserCardId);
            for (int i = 0; i < this.CBAdminSeries.Items.Count; i++)
            {
                if (this.CBAdminSeries.Items[i].Selected == true)
                {

                    bus.UserAdminSeriesInsert("UserAdminSeries_Insert", UserCardId, Convert.ToInt32(this.CBAdminSeries.Items[i].Value),UserCardId2);
                }
            }
            if (bus.UserInfoUpdate("UserInfo_Update", UserCardId, DegreeId, PoliticalId, EducationId, IntroDucation, Origin, Address, Marriage, PhoneNumber, EmailNumber, StatusId, DepartmentId, JobId, PostId, UserName, Gender, Birthday, UserIdCard, NationId, Remuneration, Ranktime, TeachersDepartmentId, JobTime, PostTime, JobSeries, TeachersSeries, WorkLevel, Management,UserCardId2))
            {

                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");

            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfoManage.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEmail.aspx?UserCardId=" + pwds.EncryptDES(txtUserCardId.Text, "asdfasdf") + "");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPhone.aspx?UserCardId=" + pwds.EncryptDES(txtUserCardId.Text, "asdfasdf") + "");
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
    }
}