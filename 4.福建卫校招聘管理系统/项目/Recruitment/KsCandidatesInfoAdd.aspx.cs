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
    public partial class KsCandidatesInfoAdd : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus =new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds =new Recruitment_Data.pwd();
        string Number;
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
                DataSet ds = bus.SelectByNumber("CandidatesInfo_SelectByNumber", Number);
                txtNumber.Text = ds.Tables[0].Rows[0]["Number"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtCardID.Text = ds.Tables[0].Rows[0]["CardID"].ToString();
                txtBirthday.Value = ds.Tables[0].Rows[0]["Birthday"].ToString();
                DGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtContactPhone.Text = ds.Tables[0].Rows[0]["ContactPhone"].ToString();
                txtOrigin.Text = ds.Tables[0].Rows[0]["Origin"].ToString();
                DNation.SelectedValue = ds.Tables[0].Rows[0]["Nation"].ToString();
                Dcensus.SelectedValue = ds.Tables[0].Rows[0]["census"].ToString();
                DPolitical.SelectedValue = ds.Tables[0].Rows[0]["Political"].ToString();
                DSource.SelectedValue = ds.Tables[0].Rows[0]["Sources"].ToString();
                txtFamilyPhone.Text = ds.Tables[0].Rows[0]["FamilyPhone"].ToString();
                txtOtherPhone.Text = ds.Tables[0].Rows[0]["OtherPhone"].ToString();
                txtFamilyAddress.Text = ds.Tables[0].Rows[0]["FamilyAddress"].ToString();
                txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                DCulture.SelectedValue= ds.Tables[0].Rows[0]["Culture"].ToString();
                DDegree.SelectedValue = ds.Tables[0].Rows[0]["Degree"].ToString();
                DEducation.SelectedValue = ds.Tables[0].Rows[0]["Education"].ToString();
                DMarriage.SelectedValue = ds.Tables[0].Rows[0]["Marriage"].ToString();
                txtInstitutions.Text = ds.Tables[0].Rows[0]["Institutions"].ToString();
                txtProfessionName.Text = ds.Tables[0].Rows[0]["ProfessionName"].ToString();
                txtGraduationData.Value = ds.Tables[0].Rows[0]["GraduationData"].ToString();
                txtJobsData.Value = ds.Tables[0].Rows[0]["JobsData"].ToString();
                txtExpertise.Value = ds.Tables[0].Rows[0]["Expertise"].ToString();
                txtResume.Value= ds.Tables[0].Rows[0]["Resumes"].ToString();
                txtFamilyMember.Value = ds.Tables[0].Rows[0]["FamilyMember"].ToString();
                txtPerformance.Value = ds.Tables[0].Rows[0]["Performance"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                if (ds.Tables[0].Rows[0]["Photo"].ToString().Length==0)
                {
                    Image2.Src = "";
                }
                else
                {
                    Image2.Src = "imgs.aspx?id=" + Number;
                   
                }
               
                DataSet da=bus.SelectByNumber("Job_SelectsByNumber", Number);
                if (da.Tables[0].Rows.Count>0)
                {
                    Button1.Visible = false;
                    ImageUpd.Visible = false;
                    qiyong();
                }
               
            }
        }
        public void qiyong()
        {
            txtEmail.Enabled = false;
            txtName.Enabled = false;
            DGender.Enabled = false;
            txtOrigin.Enabled = false;
            DNation.Enabled = false;
            txtBirthday.Disabled = true;
            txtCardID.Enabled = false;
            Dcensus.Enabled = false;
            DPolitical.Enabled = false;
            DSource.Enabled = false;
            txtContactPhone.Enabled = false;
            txtFamilyPhone.Enabled = false;
            txtOtherPhone.Enabled = false;
            txtFamilyAddress.Enabled = false;
            txtZipCode.Enabled = false;
            DCulture.Enabled = false;
            DDegree.Enabled = false;
            DEducation.Enabled = false;
            DMarriage.Enabled = false;
            txtInstitutions.Enabled = false;
            txtProfessionName.Enabled = false;
            txtGraduationData.Disabled = true;
            txtJobsData.Disabled = true;
            txtExpertise.Disabled = true;
            txtResume.Disabled = true;
            txtFamilyMember.Disabled = true;
            txtPerformance.Disabled = true;
            txtRemarks.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Number = txtNumber.Text;
            string Email = txtEmail.Text;
            string Name = txtName.Text;
            string Gender = DGender.SelectedItem.Value;
            string Origin = txtOrigin.Text;
            string Nation = DNation.SelectedItem.Value;
            string Birthday = txtBirthday.Value.Trim();
            string CardID = txtCardID.Text;
            string census = Dcensus.SelectedItem.Value;
            string Political = DPolitical.SelectedItem.Value;
            string Sources = DSource.SelectedItem.Value;
            string ContactPhone = txtContactPhone.Text;
            string FamilyPhone = txtFamilyPhone.Text;
            string OtherPhone = txtOtherPhone.Text;
            string FamilyAddress = txtFamilyAddress.Text;
            string ZipCode = txtZipCode.Text;
            string Culture = DCulture.SelectedItem.Value;
            string Degree = DDegree.SelectedItem.Value;
            string Education = DEducation.SelectedItem.Value;
            string Marriage = DMarriage.SelectedItem.Value;
            string Institutions = txtInstitutions.Text;
            string ProfessionName = txtProfessionName.Text;
            string GraduationData = txtGraduationData.Value.Trim();
            string JobsData = txtJobsData.Value.Trim();
            string Expertise = txtExpertise.Value;
            string Resumes = txtResume.Value;
            string FamilyMember = txtFamilyMember.Value;
            string Performance = txtPerformance.Value;
            string Remarks = txtRemarks.Text;

            if (CardID != "")
            {
                if (!CheckIDCard(CardID))
                {
                    Response.Write("<script>alert('身份证号码格式错误！')</script>");
                    return;
                }
            }

            if (Name == "")
            {
                AlertMsgAndNoFlush("请输入姓名！");
                return;
            }
            if (Gender == "")
            {
                AlertMsgAndNoFlush("请选择性别！");
                return;
            }
            if (Origin == "")
            {
                AlertMsgAndNoFlush("请输入籍贯！");
                return;
            }
            if (Nation == "")
            {
                AlertMsgAndNoFlush("请选择民族！");
                return;
            }
            if (Birthday == "")
            {
                AlertMsgAndNoFlush("请选择出生日期！");
                return;
            }
            if (CardID == "")
            {
                AlertMsgAndNoFlush("请输入身份证号！");
                return;
            }
            if (census == "")
            {
                AlertMsgAndNoFlush("请选择户籍所在地！");
                return;
            }
            if (Political == "")
            {
                AlertMsgAndNoFlush("请选择政治面貌！");
                return;
            }
            if (Sources == "")
            {
                AlertMsgAndNoFlush("请选择考生来源！");
                return;
            }
            if (ContactPhone == "")
            {
                AlertMsgAndNoFlush("请输入联系电话！");
                return;
            }
            if (FamilyAddress == "")
            {
                AlertMsgAndNoFlush("请输入家庭住址！");
                return;
            }
            if (Culture == "")
            {
                AlertMsgAndNoFlush("请选择学历！");
                return;
            }
            if (Degree == "")
            {
                AlertMsgAndNoFlush("请选择学位！");
                return;
            }
            if (Education == "")
            {
                AlertMsgAndNoFlush("请选择学历类别！");
                return;
            }
            if (Marriage == "")
            {
                AlertMsgAndNoFlush("请选择婚姻状况！");
                return;
            }
            if (Institutions == "")
            {
                AlertMsgAndNoFlush("请输入毕业院校！");
                return;
            }
            if (ProfessionName == "")
            {
                AlertMsgAndNoFlush("请输入专业名称！");
                return;
            }
            if (GraduationData == "")
            {
                AlertMsgAndNoFlush("请输入毕业时间！");
                return;
            }
            if (Resumes == "")
            {
                AlertMsgAndNoFlush("请输入主要简历！");
                return;
            }
            if (FamilyMember == "")
            {
                AlertMsgAndNoFlush("请输入家庭成员！");
                return;
            }
            if (bus.CandidatesInfoInsert("CandidatesInfo_Update",Number,Email, Name, Gender, Origin, Nation, Birthday, CardID, census,
                                         Political, Sources, ContactPhone, FamilyPhone, OtherPhone, FamilyAddress, ZipCode,
                                         Culture, Degree, Education, Marriage, Institutions, ProfessionName, GraduationData, JobsData,
                                         Expertise, Resumes, FamilyMember, Performance, Remarks))
            {
                AlertMsgAndNoFlush("保存成功！");
            }
            else
            {
                AlertMsgAndNoFlush("保存失败！");
            }

        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
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