using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RecruitmentPostAdd : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/RecruitmentPostAdd.aspx") == 0)
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
                    Button1.Visible = false;
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

                    Button2.Visible = false;
                }

                DataSet ds = bus.userInfoS(UserCardId);
                txtUserCardId.Text = ds.Tables[0].Rows[0]["UserCardId"].ToString();
              
               
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string PostName = txtPostName.Text;
            string Professional = txtProfessional.Text;
            string Education = txtEducation.Text;
            string Other = txtOther.Text;
            string Number = txtNumber.Text;
            string Money = txtMoney.Text;
          
            if (Money == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入月薪");
                return;
            }
            if (PostName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入岗位名称");
                return;
            }
            if (Number == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入招聘人数");
                return;
            }
            if (bus.RecruitmentInsert("RecruitmentPost_Insert", UserCardId, PostName, Professional, Education, Other, Number, Money))
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
            string PostName = txtPostName.Text;
            string Professional = txtProfessional.Text;
            string Education = txtEducation.Text;
            string Other = txtOther.Text;
            string Number = txtNumber.Text;
            string Money = txtMoney.Text;
            if (Money == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入月薪");
                return;
            }
            if (PostName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入岗位名称");
                return;
            }
            if (Number == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入招聘人数");
                return;
            }
            RecruitmentId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Recruitment"], "asdfasdf"));
            if (bus.RecruitmentUpdate("RecruitmentPost_Update", UserCardId,RecruitmentId, PostName, Professional, Education, Other, Number, Money))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("RecruitmentPostManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}