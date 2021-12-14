using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RewardDetailed : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int RewardId;
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

                if (Request.QueryString["Reward"] != null)
                {
                    try
                    {
                        RewardId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Reward"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByRewardId("Reward_SelectByRewardId", RewardId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    DlReward.SelectedValue = dt.Tables[0].Rows[0]["RewardStatus"].ToString();
                    txtRewardContent.Text = dt.Tables[0].Rows[0]["RewardContent"].ToString();
                    txtRewardCompany.Text = dt.Tables[0].Rows[0]["RewardCompany"].ToString();
                    txtRewardDates.Value = dt.Tables[0].Rows[0]["RewardDates"].ToString();
                    txtRewardForm.Text = dt.Tables[0].Rows[0]["RewardForm"].ToString();
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