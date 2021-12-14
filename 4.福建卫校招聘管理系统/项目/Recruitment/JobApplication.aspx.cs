using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class JobApplication : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.MGetData Mbus = new Recruitment_Data.MGetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string Number;
        int JobMangeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='index.aspx'<" + "/script>");
                }


                if (Request.QueryString["JobMangeId"] != null)
                {
                    try
                    {
                        JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.JobMange_SelectByJobMangeId("JobMange_SelectByJobMangeId", JobMangeId);
                    LAJobCode.Text = dt.Tables[0].Rows[0]["JobCode"].ToString();
                    LAJobName.Text = dt.Tables[0].Rows[0]["JobName"].ToString();
                    LAEnrollment.Text = dt.Tables[0].Rows[0]["Enrollment"].ToString();
                    LAAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                    LAEducation.Text = dt.Tables[0].Rows[0]["Education"].ToString();
                    LACulture.Text = dt.Tables[0].Rows[0]["Culture"].ToString();
                    LADegree.Text = dt.Tables[0].Rows[0]["Degree"].ToString();
                    LAGender.Text = dt.Tables[0].Rows[0]["Gender"].ToString();
                    LANation.Text = dt.Tables[0].Rows[0]["Nation"].ToString();
                    LAPolitical.Text = dt.Tables[0].Rows[0]["Political"].ToString();
                    LAShould.Text = dt.Tables[0].Rows[0]["Should"].ToString();
                    LARecruitment.Text = dt.Tables[0].Rows[0]["Recruitment"].ToString();
                    LAPosition.Text = dt.Tables[0].Rows[0]["Position"].ToString();
                    LAJobsYears.Text = dt.Tables[0].Rows[0]["JobsYears"].ToString();
                    LASubject.Text = dt.Tables[0].Rows[0]["SubjectName"].ToString();
                   LAApplyCost.Text = dt.Tables[0].Rows[0]["ApplyCost"].ToString();
                   LAProfession.Text = dt.Tables[0].Rows[0]["Profession"].ToString();
                   LAOthers.Text = dt.Tables[0].Rows[0]["Others"].ToString();
                   LARemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                }
                DataSet ds = bus.SelectByNumber("CandidatesInfo_SelectByNumber", Number);
                LNumber.Text = ds.Tables[0].Rows[0]["Number"].ToString();
                LName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                LCardId.Text = ds.Tables[0].Rows[0]["CardID"].ToString();
                LBirthday.Text = ds.Tables[0].Rows[0]["Birthday"].ToString();
                LGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                 LEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                 LContactPhone.Text = ds.Tables[0].Rows[0]["ContactPhone"].ToString();
                 LOrigin.Text = ds.Tables[0].Rows[0]["Origin"].ToString();
                LNation.Text = ds.Tables[0].Rows[0]["Nation"].ToString();
                Lcensus.Text = ds.Tables[0].Rows[0]["census"].ToString();
                LPolitical.Text = ds.Tables[0].Rows[0]["Political"].ToString();
                LSource.Text = ds.Tables[0].Rows[0]["Sources"].ToString();
               LFamilyPhone.Text = ds.Tables[0].Rows[0]["FamilyPhone"].ToString();
               LOtherPhone.Text = ds.Tables[0].Rows[0]["OtherPhone"].ToString();
               LFamilyAddress.Text = ds.Tables[0].Rows[0]["FamilyAddress"].ToString();
               LZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                LCulture.Text = ds.Tables[0].Rows[0]["Culture"].ToString();
                LDegree.Text = ds.Tables[0].Rows[0]["Degree"].ToString();
                LEducation.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                LMarriage.Text = ds.Tables[0].Rows[0]["Marriage"].ToString();
                LInstitutions.Text = ds.Tables[0].Rows[0]["Institutions"].ToString();
                LProfessionName.Text = ds.Tables[0].Rows[0]["ProfessionName"].ToString();
                LGraduationData.Text = ds.Tables[0].Rows[0]["GraduationData"].ToString();
                LJobsData.Text = ds.Tables[0].Rows[0]["JobsData"].ToString();
                LExpertise.Text = ds.Tables[0].Rows[0]["Expertise"].ToString();
                LResume.Text = ds.Tables[0].Rows[0]["Resumes"].ToString();
                LFamilyMember.Text = ds.Tables[0].Rows[0]["FamilyMember"].ToString();
                LPerformance.Text = ds.Tables[0].Rows[0]["Performance"].ToString();
                LRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                if (ds.Tables[0].Rows[0]["Photo"].ToString().Length == 0)
                {
                    Image2.Src = "";
                    

                }
                else
                {
                    Image2.Src = "imgs.aspx?id=" + Number;
                  
                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
         //   string JobCodeId = LAJobCode.Text;
            string Number = LNumber.Text;
            if (Mbus.JobInsert("Job_Insert", JobMangeId, Number))
            {
                AlertMsgAndNoFlush("申请成功！");
            }
            else
            {
                AlertMsgAndNoFlush("添加失败！可能是已经报名过");
            }
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }
    }
}