using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LctureExamineDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int LctureId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["LctureId"] != null)
                {
                    try
                    {
                        LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByLctureId("Lcture_SelectByLctureId", LctureId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LDLevel.Text = dt.Tables[0].Rows[0]["DLevel"].ToString();
                    LLctureName.Text = dt.Tables[0].Rows[0]["LctureName"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    LLctureDate.Text = dt.Tables[0].Rows[0]["LctureDate"].ToString();
                    LAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                     LLctureNumber.Text = dt.Tables[0].Rows[0]["LctureNumber"].ToString();
                    LLctureExplain.Text = dt.Tables[0].Rows[0]["LctureExplain"].ToString();
                    LEquipment.Text = dt.Tables[0].Rows[0]["Equipment"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LOrganName.Text = dt.Tables[0].Rows[0]["OrganName"].ToString();
                    LPhoneNumber.Text = dt.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    LCapital.Text = dt.Tables[0].Rows[0]["Capital"].ToString();
                    LUserName.Text = dt.Tables[0].Rows[0]["LctureUserName"].ToString();
                    LUserGender.Text = dt.Tables[0].Rows[0]["LctureUserGender"].ToString();
                    LUserJob.Text = dt.Tables[0].Rows[0]["LctureUserJob"].ToString();
                    LUserRole.Text = dt.Tables[0].Rows[0]["LctureUserRole"].ToString();
                    LUserCompany.Text = dt.Tables[0].Rows[0]["LctureUserCompany"].ToString();


                       
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
      
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            DataSet dy = bus.SelectByLctureId("LctureExamine_Select", LctureId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.LctureExamineInsert("LctureExamine_Insert", LctureId, ExamineOpinion, UserCardId, "同意", RankId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批失败");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.LctureExamineInsert("LctureExamine_Insert", LctureId, ExamineOpinion, UserCardId, "拒绝", RankId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批失败");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}