using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class HarvestAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int HarvestId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/HarvestAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "科技成果").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }
                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                if (Request.QueryString["HarvestId"] != null)
                {
                    try
                    {
                        HarvestId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["HarvestId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByHarvestId("Harvest_SelectByHarvestId", HarvestId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    txtHarvestName.Text = dt.Tables[0].Rows[0]["HarvestName"].ToString();
                    txtAwardsDate.Text = dt.Tables[0].Rows[0]["AwardsDate"].ToString();
                    txtAppraisalLevel.Text = dt.Tables[0].Rows[0]["AppraisalLevel"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();

                   
                    DlPartnerRank.SelectedValue= dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                    txtPartnerValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
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
                    txtHarvestValue.Text = dt.Tables[0].Rows[0]["HarvestValue"].ToString();
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                }
                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
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
                txtHarvestValue.Text = "0";
            }
            else
            {
                txtHarvestValue.Text = ds.Rows[0]["WorkValue"].ToString();
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
            string Remarks = txtRemarks.Text;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }      
            string HarvestName = txtHarvestName.Text.Trim();
            string AwardsDate = txtAwardsDate.Text.Trim();
            string AppraisalLevel = txtAppraisalLevel.Text.Trim();

            double HarvestValue;
            double PartnerValue;
            int PartnerRank;


            if (HarvestName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果项目名称");
                return;
            }
            if (AwardsDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入发奖日期");
                return;
            }
            if (AppraisalLevel == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果等级");
                return;
            }

            if (txtHarvestValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                HarvestValue = Convert.ToDouble(txtHarvestValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (HarvestValue <= 0)
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
            if (HarvestValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }


            if (bus.HarvestInsert("Harvest_Insert", UserCardId, HarvestName, AwardsDate, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue,DCategory,DLevel,Remarks))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'HarvestPartnerManage.aspx'}", true);
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
                txtHarvestValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string HarvestName = txtHarvestName.Text;
            double HarvestValue;
            string AwardsDate = txtAwardsDate.Text.Trim();
            string AppraisalLevel = txtAppraisalLevel.Text.Trim();
            string Remarks = txtRemarks.Text;
            double PartnerValue;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            int PartnerRank;


            if (HarvestName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果项目名称");
                return;
            }
            if (AwardsDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入发奖日期");
                return;
            }
            if (AppraisalLevel == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果等级");
                return;
            }

            if (txtHarvestValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                HarvestValue = Convert.ToDouble(txtHarvestValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (HarvestValue <= 0)
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
            if (HarvestValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }

            HarvestId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["HarvestId"], "asdfasdf"));
            if (bus.HarvestUpdate("Harvest_Update", HarvestId, HarvestName, AwardsDate, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue, DCategory, DLevel,Remarks))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyHarvestManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}