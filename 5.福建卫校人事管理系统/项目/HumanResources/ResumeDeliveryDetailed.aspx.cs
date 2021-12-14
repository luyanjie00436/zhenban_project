using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ResumeDeliveryDetailed : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ResumeDeliveryId;
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

                if (Request.QueryString["ResumeDelivery"] != null)
                {
                    try
                    {
                        ResumeDeliveryId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResumeDelivery"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByResumeDeliveryId("ResumeDelivery_SelectByResumeDeliveryId", ResumeDeliveryId);
                    txtJobIntention.Text = dt.Tables[0].Rows[0]["Jobintention"].ToString();
                    txtCourse.Text = dt.Tables[0].Rows[0]["Course"].ToString();
                    txtAbility.Text = dt.Tables[0].Rows[0]["Ability"].ToString();
                    txtCertificate.Text = dt.Tables[0].Rows[0]["Certificate"].ToString();
                    txtPractice.Text = dt.Tables[0].Rows[0]["Practice"].ToString();
                    txtHobbies.Text = dt.Tables[0].Rows[0]["Hobbies"].ToString();
                    txtReward.Text = dt.Tables[0].Rows[0]["Reward"].ToString();
                    txtCriticism.Text = dt.Tables[0].Rows[0]["Criticism"].ToString();
                    txtEvaluation.Text = dt.Tables[0].Rows[0]["Evaluation"].ToString();
                    txtResumeName.Text = dt.Tables[0].Rows[0]["ResumeName"].ToString();
                    txtName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                    txtBirthday.Value = dt.Tables[0].Rows[0]["Birthday"].ToString();
                    txtOrigin.Text = dt.Tables[0].Rows[0]["Origin"].ToString();
                    txtEducation.Text = dt.Tables[0].Rows[0]["Education"].ToString();
                    txtWorkLife.Text = dt.Tables[0].Rows[0]["WorkLife"].ToString();
                    txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                    txtPhone.Text = dt.Tables[0].Rows[0]["Phone"].ToString();
                    txtEmail.Text = dt.Tables[0].Rows[0]["Email"].ToString();

                    if (dt.Tables[0].Rows[0]["Gender"].ToString() != "")
                    {
                        DlGender.SelectedItem.Text = dt.Tables[0].Rows[0]["Gender"].ToString();
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}