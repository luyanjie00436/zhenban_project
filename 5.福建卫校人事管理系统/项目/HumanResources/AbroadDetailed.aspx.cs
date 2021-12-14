using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class AbroadDetailed : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int AbroadId;
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

                if (Request.QueryString["Abroad"] != null)
                {
                    try
                    {
                        AbroadId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Abroad"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    DataSet dt = bus.SelectByAbroadId("Abroad_SelectByAbroadId", AbroadId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtProfessional.Text = dt.Tables[0].Rows[0]["ProfessionalName"].ToString();
                    txtDirection.Text = dt.Tables[0].Rows[0]["Direction"].ToString();
                    txtOneLanguage.Text = dt.Tables[0].Rows[0]["OneLanguage"].ToString();
                    txtTwoLanguage.Text = dt.Tables[0].Rows[0]["TwoLanguage"].ToString();
                    txtOneLanguageDegree.Text = dt.Tables[0].Rows[0]["OneLanguageDegree"].ToString();
                    txtTwoLanguageDegree.Text = dt.Tables[0].Rows[0]["TwoLanguageDegree"].ToString();
                    txtMainWord.Text = dt.Tables[0].Rows[0]["MainWord"].ToString();
                    txtCountryName.Text = dt.Tables[0].Rows[0]["CountryName"].ToString();
                    txtCountryDate.Value = dt.Tables[0].Rows[0]["CountryDate"].ToString();
                    txtReward.Text = dt.Tables[0].Rows[0]["Reward"].ToString();
                    txtAbroadPlan.Text = dt.Tables[0].Rows[0]["AbroadPlan"].ToString();

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
                LUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
                LStartWork.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();
                LUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                LBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
                 
                LGender.Text = ds.Tables[0].Rows[0]["性别"].ToString();
                 

                LNation.Text = ds.Tables[0].Rows[0]["民族"].ToString();
                LPolitical.Text = ds.Tables[0].Rows[0]["政治面貌"].ToString();
                LEducation.Text = ds.Tables[0].Rows[0]["第一学历"].ToString();
                LDegree.Text = ds.Tables[0].Rows[0]["第一学位"].ToString();

               
            }
        }
    }
}