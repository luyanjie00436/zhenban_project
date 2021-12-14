using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ResumeAdd : System.Web.UI.Page
    {

        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ResumeId;
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

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ResumeAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }



                if (Request.QueryString["Resume"] != null)
                {
                    try
                    {
                        ResumeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Resume"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    Button1.Visible = false;
                    DataSet dt = bus.SelectByResumeId("Resume_SelectByResumeId", ResumeId);
                    LUserCardId.Text = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LUserName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                    LGender.Text = dt.Tables[0].Rows[0]["Gender"].ToString();
                    LNation.Text = dt.Tables[0].Rows[0]["Nation"].ToString();
                    LOrigin.Text = dt.Tables[0].Rows[0]["Origin"].ToString();
                    LBirthday.Text = dt.Tables[0].Rows[0]["BirthDay"].ToString();
                    txtMarriage.Text = dt.Tables[0].Rows[0]["Marriage"].ToString();
                    LEducation.Text = dt.Tables[0].Rows[0]["Education"].ToString();
                    LDegree.Text = dt.Tables[0].Rows[0]["Degree"].ToString();
                    LPolitical.Text = dt.Tables[0].Rows[0]["Political"].ToString();
                    txtHeight.Text = dt.Tables[0].Rows[0]["Height"].ToString();
                    txtProfessional.Text = dt.Tables[0].Rows[0]["Professional"].ToString();
                    txtHealthy.Text = dt.Tables[0].Rows[0]["Healthy"].ToString();
                    txtJobIntention.Text = dt.Tables[0].Rows[0]["Jobintention"].ToString();
                    txtGraduated.Text = dt.Tables[0].Rows[0]["Graduated"].ToString();
                    txtPhone.Text = dt.Tables[0].Rows[0]["Phone"].ToString();
                    txtEmail.Text = dt.Tables[0].Rows[0]["Email"].ToString();
                    txtCourse.Text = dt.Tables[0].Rows[0]["Course"].ToString();
                    txtAbility.Text = dt.Tables[0].Rows[0]["Ability"].ToString();
                    txtCertificate.Text = dt.Tables[0].Rows[0]["Certificate"].ToString();
                    txtPractice.Text = dt.Tables[0].Rows[0]["Practice"].ToString();
                    txtHobbies.Text = dt.Tables[0].Rows[0]["Hobbies"].ToString();
                    txtReward.Text = dt.Tables[0].Rows[0]["Reward"].ToString();
                    txtCriticism.Text = dt.Tables[0].Rows[0]["Criticism"].ToString();
                    txtEvaluation.Text = dt.Tables[0].Rows[0]["Evaluation"].ToString();
                }
                else
                {
                    Button2.Visible = false;
                    DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
                    LUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
                    LUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                    LBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
                    LOrigin.Text = ds.Tables[0].Rows[0]["籍贯"].ToString();
                    LGender.Text = ds.Tables[0].Rows[0]["性别"].ToString();
                    LNation.Text = ds.Tables[0].Rows[0]["民族"].ToString();
                    LPolitical.Text = ds.Tables[0].Rows[0]["政治面貌"].ToString();
                    LEducation.Text = ds.Tables[0].Rows[0]["最高学历"].ToString();
                    LDegree.Text = ds.Tables[0].Rows[0]["最高学位"].ToString();
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text;
            string UserName = LUserName.Text;
            string Gender = LGender.Text;
            string Nation = LNation.Text;
            string Origin = LOrigin.Text;
            string Birthday = LBirthday.Text;
            string Marriage = txtMarriage.Text;
            string Education = LEducation.Text;
            string Degree = LDegree.Text;
            string Political = LPolitical.Text;
            string Height = txtHeight.Text.Trim();
            string Professional = txtProfessional.Text;
            string Healthy = txtHealthy.Text;
            string Jobintention = txtJobIntention.Text;
            string Graduated = txtGraduated.Text;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            string Course = txtCourse.Text;
            string Ability = txtAbility.Text;
            string Certificate = txtCertificate.Text;
            string Practice = txtPractice.Text;
            string Hobbies = txtHobbies.Text;
            string Reward = txtReward.Text;
            string Criticism = txtCriticism.Text;
            string Evaluation = txtEvaluation.Text;
            if (bus.ResumeInsert("Resume_Insert", UserCardId, UserName, Gender, Nation, Origin, Birthday, Marriage, Education, Degree, Political, Height, Professional, Healthy, Jobintention, Graduated, Phone, Email, Course, Ability, Certificate, Practice, Hobbies, Reward, Criticism, Evaluation))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text;
            string UserName = LUserName.Text;
            string Gender = LGender.Text;
            string Nation = LNation.Text;
            string Origin = LOrigin.Text;
            string Birthday = LBirthday.Text;
            string Marriage = txtMarriage.Text;
            string Education = LEducation.Text;
            string Degree = LDegree.Text;
            string Political = LPolitical.Text;
            string Height = txtHeight.Text.Trim();
            string Professional = txtProfessional.Text;
            string Healthy = txtHealthy.Text;
            string Jobintention = txtJobIntention.Text;
            string Graduated = txtGraduated.Text;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            string Course = txtCourse.Text;
            string Ability = txtAbility.Text;
            string Certificate = txtCertificate.Text;
            string Practice = txtPractice.Text;
            string Hobbies = txtHobbies.Text;
            string Reward = txtReward.Text;
            string Criticism = txtCriticism.Text;
            string Evaluation = txtEvaluation.Text;
            ResumeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Resume"], "asdfasdf"));
            if (bus.ResumeUpdate("Resume_Update", ResumeId, Marriage, Education, Degree, Political, Height, Professional, Healthy, Jobintention, Graduated, Phone, Email, Course, Ability, Certificate, Practice, Hobbies, Reward, Criticism, Evaluation))
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
    }
}