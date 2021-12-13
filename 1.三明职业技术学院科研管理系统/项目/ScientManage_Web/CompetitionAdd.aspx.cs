using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class CompetitionAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int CompetitionId;
        protected static string type;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/CompetitionAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "技能竞赛").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }

                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
                if (Request.QueryString["CompetitionId"] != null)
                {
                    try
                    {
                        CompetitionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["CompetitionId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByCompetitionId("Competition_SelectByCompetitionId", CompetitionId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();      
                    txtCompetitionName.Text = dt.Tables[0].Rows[0]["CompetitionName"].ToString();
                    txtCompetitionDate.Value = dt.Tables[0].Rows[0]["CompetitionDate"].ToString();
                    txtAppraisalCompany.Text = dt.Tables[0].Rows[0]["AppraisalCompany"].ToString();
                    txtTeacherName.Text = dt.Tables[0].Rows[0]["TeacherName"].ToString();
                    txtStudentName.Text = dt.Tables[0].Rows[0]["StudentName"].ToString();
                    txtMentor.Text = dt.Tables[0].Rows[0]["Mentor"].ToString();

                    txtCompetitionValue.Text = dt.Tables[0].Rows[0]["CompetitionValue"].ToString();
                    DlPartnerRank.SelectedValue = dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                    txtPartnerValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                    txtCompetitionValue.Text = dt.Tables[0].Rows[0]["CompetitionValue"].ToString();
                    for (int i = 0; i < DLCategory.Items.Count; i++)
                    {
                        if (DLCategory.Items[i].Text == dt.Tables[0].Rows[0]["DCategory"].ToString())
                        {
                            DLCategory.Items[i].Selected = true;
                            break;
                        }
                    }
                    CategoryChange();
                    for (int i = 0; i < DLLevel.Items.Count; i++)
                    {
                        if (DLLevel.Items[i].Text == dt.Tables[0].Rows[0]["DLevel"].ToString())
                        {
                            DLLevel.Items[i].Selected = true;
                            break;
                        }
                    }
                    txtCompetitionValue.Text = dt.Tables[0].Rows[0]["CompetitionValue"].ToString();
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);

                    txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                }

                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();      
                    //txtStartDate.Text = dt.Tables[0].Rows[0]["StartDate"].ToString();
                    //txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                    Button2.Visible = false;
                }


            }

        }
        public void CategoryChange()
        {

            int FatherId = Convert.ToInt32(DLCategory.SelectedValue);
            DataTable ds = bus.SelectByWorkCategoryId("WorkCategory_SelectWorkValue", FatherId).Tables[0];
            if (ds.Rows.Count > 0 && ds.Columns.Count > 1)
            {
                DLLevel.Items.Add("==请选择==");
                DLLevel.Items[0].Value = "0";
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLLevel.Items.Add(li);
                }
                txtCompetitionValue.Text = "0";
            }
            else
            {
                txtCompetitionValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime NowDate = Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime StartDate = Convert.ToDateTime(LStartDate.Text);
            DateTime EndDate = Convert.ToDateTime(LEndDate.Text);
            if (NowDate < StartDate || NowDate > EndDate)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "未在申报的有效时间内，禁止申报。");
                return;
            }
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            
            string CompetitionName = txtCompetitionName.Text.Trim();
            string CompetitionDate = txtCompetitionDate.Value;
            string AppraisalCompany = txtAppraisalCompany.Text.Trim();
            string TeacherName = txtTeacherName.Text.Trim();
            string StudentName = txtStudentName.Text.Trim();
            string Mentor = txtMentor.Text.Trim();

            double CompetitionValue;
            double PartnerValue;
            int PartnerRank;

            if (CompetitionName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入技能竞赛名称");
                return;
            }
            if (CompetitionDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果获得时间");
                return;
            }
            if (AppraisalCompany == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入竞赛组织单位");
                return;
            }
            if (TeacherName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参赛教师");
                return;
            }
            if (StudentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参赛学生");
                return;
            }
            if (Mentor == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入指导教师");
                return;
            }

            if (txtCompetitionValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                CompetitionValue = Convert.ToDouble(txtCompetitionValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }

            if (txtPartnerValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }

            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择个人排名");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (CompetitionValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }


            if (bus.CompetitionInsert("Competition_Insert", UserCardId, CompetitionName, AppraisalCompany, TeacherName, StudentName, Mentor, CompetitionValue, PartnerRank, PartnerValue, DCategory, DLevel,CompetitionDate))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'CompetitionPartnerManage.aspx'}else {window.location = 'CompetitionAdd.aspx'}", true);
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！可能是没有您的审批流程");
            }

        }
        protected void DLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DLLevel.Items.Clear();
            if (DLCategory.SelectedValue != "0")
            {
                CategoryChange();
            }
        }
        protected void DLLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DLLevel.SelectedValue != "0")
            {
                int FatherId = Convert.ToInt32(DLLevel.SelectedValue);
                DataTable ds = bus.SelectByWorkCategoryId("WorkCategory_SelectWorkValue", FatherId).Tables[0];
                txtCompetitionValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string CompetitionName = txtCompetitionName.Text.Trim();
            string CompetitionDate = txtCompetitionDate.Value;
            string AppraisalCompany = txtAppraisalCompany.Text.Trim();
            string TeacherName = txtTeacherName.Text.Trim();
            string StudentName = txtStudentName.Text.Trim();
            string Mentor = txtMentor.Text.Trim();

            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            double CompetitionValue;
            double PartnerValue;
            int PartnerRank;


            if (CompetitionName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入技能竞赛名称");
                return;
            }
            if (CompetitionDate== "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果获得时间");
                return;
            }
            if (AppraisalCompany == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入竞赛组织单位");
                return;
            }
            if (TeacherName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参赛教师");
                return;
            }
            if (StudentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参赛学生");
                return;
            }
            if (Mentor == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入指导教师");
                return;
            }

            if (txtCompetitionValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                CompetitionValue = Convert.ToDouble(txtCompetitionValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }

            if (txtPartnerValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }
            if (txtPartnerValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应为正数");
                return;
            }

            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择个人排名");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (CompetitionValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }

            CompetitionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["CompetitionId"], "asdfasdf"));
            if (bus.CompetitionUpdate("Competition_Update", CompetitionId, CompetitionName, AppraisalCompany, TeacherName, StudentName, Mentor, CompetitionValue, PartnerRank, PartnerValue, DCategory, DLevel,CompetitionDate))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyCompetitionManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}