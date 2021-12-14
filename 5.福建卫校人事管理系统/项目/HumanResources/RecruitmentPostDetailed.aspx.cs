using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RecruitmentPostDetailed : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int RecruitmentId;
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
            
                if (Request.QueryString["Recruitment"] != null)
                {
                    try
                    {
                        RecruitmentId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Recruitment"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByRecruitmentId("RecruitmentPost_SelectByRecruitmentPostId", RecruitmentId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtPostName.Text = dt.Tables[0].Rows[0]["PostName"].ToString();
                    txtProfessional.Text = dt.Tables[0].Rows[0]["Professional"].ToString();
                    txtEducation.Text = dt.Tables[0].Rows[0]["Education"].ToString();
                    txtOther.Text = dt.Tables[0].Rows[0]["Other"].ToString();
                    txtNumber.Text = dt.Tables[0].Rows[0]["Number"].ToString();
                    txtMoney.Text = dt.Tables[0].Rows[0]["Money"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
              
                txtUserCardId.Text = UserCardId;
               
            }
        }
    }
}