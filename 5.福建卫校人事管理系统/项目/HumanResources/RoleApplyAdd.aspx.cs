using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RoleApplyAdd : System.Web.UI.Page
    {

        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int RoleApplyId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/RoleApplyAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleId"].ToString());
                    DlRole.Items.Add(li);
                }
              
                DataSet FollDate = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in FollDate.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DlFollDate.Items.Add(li);
                }
                if (Request.QueryString["RoleApply"] != null)
                {
                    try
                    {
                        RoleApplyId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["RoleApply"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByRoleApplyId("RoleApply_SelectByRoleApplyId", RoleApplyId);
                    DlRole.SelectedValue = dt.Tables[0].Rows[0]["ApplyRole"].ToString();
                    txtAssessmentName.Text = dt.Tables[0].Rows[0]["AssessmentName"].ToString();
                    txtApplyDetailed.Text = dt.Tables[0].Rows[0]["ApplyDetailed"].ToString();
                    txtApplyContent.Text = dt.Tables[0].Rows[0]["ApplyContent"].ToString();
                    DlFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());

                }
                else
                {
                    //txtStartDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //txtStartVoteDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //txtEndVoteDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
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
            int RoleId = Convert.ToInt16(DlRole.SelectedItem.Value);
            int ApplyYearId = Convert.ToInt16(DlFollDate.SelectedValue);
            string AssessmentName = txtAssessmentName.Text.Trim();
            string ApplyDetailed = txtApplyDetailed.Text.Trim();
            string ApplyContent = txtApplyContent.Text.Trim();
       
            if (RoleId == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择职务");
                return;
            }
          
            if (AssessmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入考核名称");
                return;
            }
            if (ApplyDetailed == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申报详细");
                return;
            }
            if (ApplyContent == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申报内容");
                return;
            }
            if (bus.RoleApplyInsert("RoleApply_Insert", UserCardId, AssessmentName, RoleId, ApplyContent,ApplyDetailed, ApplyYearId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int RoleId = Convert.ToInt16(DlRole.SelectedItem.Value);
            int ApplyYearId = Convert.ToInt16(DlFollDate.SelectedValue);
            string AssessmentName = txtAssessmentName.Text.Trim();
            string ApplyDetailed = txtApplyDetailed.Text.Trim();
            string ApplyContent = txtApplyContent.Text.Trim();
          
            if (RoleId == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择职务");
                return;
            }

         
            if (AssessmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入考核名称");
                return;
            }
            if (ApplyDetailed == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申报详细");
                return;
            }
            if (ApplyContent == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申报内容");
                return;
            }
            RoleApplyId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["RoleApply"], "asdfasdf"));
            if (bus.RoleApplyUpdate("RoleApply_Update", RoleApplyId, AssessmentName, RoleId, ApplyContent, ApplyDetailed, ApplyYearId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("RoleApplyManage.aspx");
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