using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class AbroadAdd : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AbroadAdd.aspx") == 0)
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
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByAbroadId("Abroad_SelectByAbroadId", AbroadId);
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
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());

                }
                else
                {
                    Button2.Visible = false;
                }
                
            }
        }
        protected void huoqu(string UserCardId)
        {
            DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
            txtUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
            LStartWork.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
            LBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
            LGender.Text = ds.Tables[0].Rows[0]["性别"].ToString();
            LNation.Text = ds.Tables[0].Rows[0]["民族"].ToString();
            LPolitical.Text = ds.Tables[0].Rows[0]["政治面貌"].ToString();
            LEducation.Text = ds.Tables[0].Rows[0]["第一学历"].ToString();
            LDegree.Text = ds.Tables[0].Rows[0]["第一学位"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Professional = txtProfessional.Text.Trim();
            string Direction = txtDirection.Text.Trim();
            string OneLanguage = txtOneLanguage.Text.Trim();
            string OneLanguageDegree = txtOneLanguageDegree.Text.Trim();
            string TwoLanguage = txtTwoLanguage.Text.Trim();
            string TwoLanguageDegree = txtTwoLanguageDegree.Text.Trim();
            string MainWord = txtMainWord.Text.Trim();
            string CountryName = txtCountryName.Text.Trim();
            string CountryDate = txtCountryDate.Value;
            string Reward = txtReward.Text.Trim();
            string AbroadPlan = txtAbroadPlan.Text.Trim();
          
            if (Professional == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写专业名称");
                return;
            }
            if (Direction == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写研究方向");
                return;
            }
            if (OneLanguage == "" && TwoLanguage == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请至少填写一门外语");
                return;
            }
            if (OneLanguageDegree == "" && TwoLanguageDegree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请至少填写一门外语水平");
                return;
            }
            if (CountryDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国（境）时间");
                return;
            }
            if (CountryName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写国家地区");
                return;
            }
            if (MainWord == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国（境）项目名称");
                return;
            }
            if (Reward == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写预期取得成果");
                return;
            }
            if (AbroadPlan == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国计划");
                return;
            }
            if (bus.AbroadInsert("Abroad_Insert", UserCardId, Professional, Direction, OneLanguage, OneLanguageDegree, TwoLanguage, TwoLanguageDegree, MainWord, CountryName, CountryDate, Reward, AbroadPlan))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Professional = txtProfessional.Text.Trim();
            string Direction = txtDirection.Text.Trim();
            string OneLanguage = txtOneLanguage.Text.Trim();
            string OneLanguageDegree = txtOneLanguageDegree.Text.Trim();
            string TwoLanguage = txtTwoLanguage.Text.Trim();
            string TwoLanguageDegree = txtTwoLanguageDegree.Text.Trim();
            string MainWord = txtMainWord.Text.Trim();
            string CountryName = txtCountryName.Text.Trim();
            string CountryDate = txtCountryDate.Value;
            string Reward = txtReward.Text.Trim();
            string AbroadPlan = txtAbroadPlan.Text.Trim();
           
            if (Professional == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写专业名称");
                return;
            }
            if (Direction == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写研究方向");
                return;
            }
            if (OneLanguage == "" && TwoLanguage == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请至少填写一门外语");
                return;
            }
            if (OneLanguageDegree == "" && TwoLanguageDegree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请至少填写一门外语水平");
                return;
            }
            if (CountryDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国（境）时间");
                return;
            }
            if (CountryName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写国家地区");
                return;
            }
            if (MainWord == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国（境）项目名称");
                return;
            }
            if (Reward == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写预期取得成果");
                return;
            }
            if (AbroadPlan == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写出国计划");
                return;
            }
            AbroadId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Abroad"], "asdfasdf"));
            if (bus.AbroadUpdate("Abroad_Update", UserCardId,AbroadId, Professional, Direction, OneLanguage, OneLanguageDegree, TwoLanguage, TwoLanguageDegree, MainWord, CountryName, CountryDate, Reward, AbroadPlan))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("AbroadManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            DataTable dt = bus.SelectByUserName("UserInfo_SelectByUserName", UserName).Tables[0];
            DlName.Items.Clear();
            DlName.Items.Add("请选择");
            DlName.Items[0].Value = "0";
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["姓名"].ToString(), dr["工号"].ToString());
                DlName.Items.Add(li);
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlName.SelectedValue != "0")
            {
                txtUserCardId.Text = DlName.SelectedValue;
                txtUserName.Text = DlName.SelectedItem.Text;
                huoqu(DlName.SelectedValue);
            }
        }
    }
}