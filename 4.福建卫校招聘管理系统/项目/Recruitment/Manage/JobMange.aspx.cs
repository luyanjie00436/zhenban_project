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
    public partial class JobMange : System.Web.UI.Page
    {
        Recruitment_Data.MGetData bus = new Recruitment_Data.MGetData();
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
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            
            string Sort = DSort.SelectedValue;
            string Years = txtYears.Text.Trim();
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

            DataSet dy = bus.JobMange_Selects("JobManage_Selects", JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort,Years);
           
            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
           string i = e.CommandArgument.ToString();
            Response.Redirect("JobMangeAdd.aspx?JobMangeId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        //删除
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            if (bus.JobMangeDelete("JobMange_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                AlertMsgAndNoFlush("删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush("审批流程已经启动，禁止删除");
            }

        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

       
    }
}