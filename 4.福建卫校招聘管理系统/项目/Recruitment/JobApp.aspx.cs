using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class JobApp : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
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

                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            string Sort = DSort.SelectedValue;
            string JobName = txtJobName.Text.Trim();
            string SubjectName = DSubjectName.SelectedValue;
            string Culture = DCulture.SelectedValue;
            string Political = DPolitical.SelectedValue;
            string Recruitment = DRecruitment.SelectedValue;
            string Gender = DGender.SelectedValue;
            string Should = DShould.SelectedValue;
            string Nation = DNation.SelectedValue;
            string Degree = DDegree.SelectedValue;
            string Position = DPosition.SelectedValue;
            string Education = DEducation.SelectedValue;
            string Age = txtAge.Text.Trim();
            string Profession = txtProfession.Text.Trim();

            DataSet dy = bus.JobMange_ksSelects("JobManage_ksSelects", JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort);

            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            
            Response.Redirect("JobApplication.aspx?JobMangeId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
    }
}