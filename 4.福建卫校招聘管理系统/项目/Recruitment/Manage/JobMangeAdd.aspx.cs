using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class JobMangeAdd : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string UserCardId;
        int JobMangeId;
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

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
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
                    Button1.Visible = false;
                    DataSet dt = bus.JobMange_SelectByJobMangeId("JobMange_SelectByJobMangeId", JobMangeId);
                    txtJobCode.Text = dt.Tables[0].Rows[0]["JobCode"].ToString();
                    txtJobName.Text = dt.Tables[0].Rows[0]["JobName"].ToString();
                    txtEnrollment.Text = dt.Tables[0].Rows[0]["Enrollment"].ToString();
                    txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                    DEducation.SelectedValue = dt.Tables[0].Rows[0]["Education"].ToString();
                    DCulture.SelectedValue = dt.Tables[0].Rows[0]["Culture"].ToString();
                    DDegree.SelectedValue = dt.Tables[0].Rows[0]["Degree"].ToString();
                    DGender.SelectedValue = dt.Tables[0].Rows[0]["Gender"].ToString();
                    DNation.SelectedValue = dt.Tables[0].Rows[0]["Nation"].ToString();
                    DPolitical.SelectedValue = dt.Tables[0].Rows[0]["Political"].ToString();
                    DShould.SelectedValue = dt.Tables[0].Rows[0]["Should"].ToString();
                    DRecruitment.SelectedValue = dt.Tables[0].Rows[0]["Recruitment"].ToString();
                    DPosition.SelectedValue = dt.Tables[0].Rows[0]["Position"].ToString();
                    DJobsYears.SelectedValue = dt.Tables[0].Rows[0]["JobsYears"].ToString();
                    DSubject.SelectedValue = dt.Tables[0].Rows[0]["SubjectName"].ToString();
                    txtApplyCost.Text = dt.Tables[0].Rows[0]["ApplyCost"].ToString();
                    txtProfession.Text = dt.Tables[0].Rows[0]["Profession"].ToString();
                    txtOthers.Text = dt.Tables[0].Rows[0]["Others"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {
                    Button2.Visible = false;
                    Button3.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string JobCode = txtJobCode.Text;
            string JobName = txtJobName.Text;
            string Enrollment = txtEnrollment.Text;
            string Age = txtAge.Text;
            string Education = DEducation.SelectedItem.Value;
            string Culture = DCulture.SelectedItem.Value;
            string Degree = DDegree.SelectedItem.Value;
            string Gender = DGender.SelectedItem.Value;
            string Nation = DNation.SelectedItem.Value;
            string Political = DPolitical.SelectedItem.Value;
            string Should = DShould.SelectedItem.Value;
            string Recruitment = DRecruitment.SelectedItem.Value;
            string Position = DPosition.SelectedItem.Value;
            string JobsYears = DJobsYears.SelectedItem.Value;
            string SubjectName = DSubject.SelectedItem.Value;
            string ApplyCost = txtApplyCost.Text;
            string Profession = txtProfession.Text;
            string Others = txtOthers.Text;
            string Remarks = txtRemarks.Text;

            if(JobCode=="")
            {
                AlertMsgAndNoFlush("请填写岗位代码");
                return;
            }
            if (JobName == "")
            {
                AlertMsgAndNoFlush("请填写岗位名称");
                return;
            }
            if (Enrollment == "")
            {
                AlertMsgAndNoFlush("请填写招收人数");
                return;
            }
            if (Age == "")
            {
                AlertMsgAndNoFlush("请填写年龄");
                return;
            }
            if (ApplyCost == "")
            {
                AlertMsgAndNoFlush("请填写报考费用");
                return;
            }
            if (Profession == "")
            {
                AlertMsgAndNoFlush("请填写专业要求");
                return;
            }
            if (Others == "")
            {
                AlertMsgAndNoFlush("请填写其他要求");
                return;
            }

            if (bus.JobMangeInsert("JobMange_Insert", JobCode, JobName, Enrollment, Age, Education, Culture, Degree, Gender, Nation,Political, Should, Recruitment, Position, JobsYears, SubjectName, ApplyCost, Profession, Others, Remarks))
            {
                AlertMsgAndNoFlush("添加成功！");
            }
            else
            {
                AlertMsgAndNoFlush("添加失败！");
            }
            
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string JobCode = txtJobCode.Text;
            string JobName = txtJobName.Text;
            string Enrollment = txtEnrollment.Text;
            string Age = txtAge.Text;
            string Education = DEducation.SelectedItem.Value;
            string Culture = DCulture.SelectedItem.Value;
            string Degree = DDegree.SelectedItem.Value;
            string Gender = DGender.SelectedItem.Value;
            string Nation = DNation.SelectedItem.Value;
            string Political = DPolitical.SelectedItem.Value;
            string Should = DShould.SelectedItem.Value;
            string Recruitment = DRecruitment.SelectedItem.Value;
            string Position = DPosition.SelectedItem.Value;
            string JobsYears = DJobsYears.SelectedItem.Value;
            string SubjectName = DSubject.SelectedItem.Value;
            string ApplyCost = txtApplyCost.Text;
            string Profession = txtProfession.Text;
            string Others = txtOthers.Text;
            string Remarks = txtRemarks.Text;
            if (JobCode == "")
            {
                AlertMsgAndNoFlush("请填写岗位代码");
                return;
            }
            if (JobName == "")
            {
                AlertMsgAndNoFlush("请填写岗位名称");
                return;
            }
            if (Enrollment == "")
            {
                AlertMsgAndNoFlush("请填写招收人数");
                return;
            }
            if (Age == "")
            {
                AlertMsgAndNoFlush("请填写年龄");
                return;
            }
            if (ApplyCost == "")
            {
                AlertMsgAndNoFlush("请填写报考费用");
                return;
            }
            if (Profession == "")
            {
                AlertMsgAndNoFlush("请填写专业要求");
                return;
            }
            if (Others == "")
            {
                AlertMsgAndNoFlush("请填写其他要求");
                return;
            }
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
            if (bus.JobMangeUpdate("JobMange_Update", JobMangeId, JobCode, JobName, Enrollment, Age, Education, Culture, Degree, Gender, Nation, Political, Should, Recruitment, Position, JobsYears, SubjectName, ApplyCost, Profession, Others, Remarks))
            {
                AlertMsgAndNoFlush("修改成功！");
            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}