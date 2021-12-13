using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class ActivityAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int ActivityId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ActivityAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "学术活动").Tables[0];
              
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }

                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                if (Request.QueryString["ActivityId"] != null)
                {
                    try
                    {
                        ActivityId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ActivityId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByActivityId("Activity_SelectByActivityId", ActivityId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();      
                    txtStartDate.Text = dt.Tables[0].Rows[0]["StartDate"].ToString();
                    txtActivityName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                    txtCompanyName.Text = dt.Tables[0].Rows[0]["CompanyName"].ToString();
                    txtEndDate.Text = dt.Tables[0].Rows[0]["EndDate"].ToString();
                    txtActivitntyValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                    DlPartnerRank.SelectedValue = dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                  
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
                    txtActivityValue.Text = dt.Tables[0].Rows[0]["ActivityValue"].ToString();
                }
                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();      
                    txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                txtActivityValue.Text = "0";
            }
            else
            {
                txtActivityValue.Text = ds.Rows[0]["WorkValue"].ToString();
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
          string StartDate2 = txtStartDate.Text.Trim();
          string EndDate2 = txtEndDate.Text.Trim();
            string AssociationName = txtActivityName.Text.Trim();
            string CompanyName = txtCompanyName.Text;
            double ActivityValue;
            double PartnerValue;
            int PartnerRank;

            if (AssociationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术活动名称");
                return;
            }
            if (CompanyName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入主办单位");
                return;
            }
            if (StartDate2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入开始时间");
                return;
            }
            if (EndDate2 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结束时间");
                return;
            }
            if (txtActivityValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                ActivityValue = Convert.ToDouble(txtActivityValue.Text);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (ActivityValue <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (txtActivitntyValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtActivitntyValue.Text);
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
            if (ActivityValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }
            if (bus.ActivityInsert("Activity_Insert", UserCardId, AssociationName, StartDate2, EndDate2, ActivityValue, PartnerRank, PartnerValue,DCategory,DLevel,CompanyName))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'ActivityPartnerManage.aspx'}else {window.location = 'ActivityAdd.aspx'}", true);

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
                txtActivityValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            string AssociationName = txtActivityName.Text.Trim();
            string CompanyName = txtCompanyName.Text;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            double ActivityValue;
            double PartnerValue;
            int PartnerRank;

            if (AssociationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术活动名称");
                return;
            }
            if (CompanyName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入主办单位");
                return;
            }
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入开始时间");
                return;
            }
            if (EndDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结束时间");
                return;
            }
            if (txtActivityValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                ActivityValue = Convert.ToDouble(txtActivityValue.Text);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (ActivityValue <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (txtActivitntyValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtActivitntyValue.Text);
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
            if (ActivityValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }
            ActivityId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ActivityId"], "asdfasdf"));
            if (bus.AcitvityUpdate("Activity_Update", ActivityId, AssociationName, StartDate, EndDate, ActivityValue, PartnerRank, PartnerValue,DCategory,DLevel,CompanyName))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyAcitivityManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}