using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class TeachingAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();

        string UserCardId;
        int TeachingId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TeachingAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "著作教材").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }
                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                if (Request.QueryString["TeachingId"] != null)
                {

                    try
                    {
                        TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByTeachingId("Teaching_SelectByTeachingId", TeachingId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    txtBookName.Text = dt.Tables[0].Rows[0]["BookName"].ToString();
                    txtPressName.Text = dt.Tables[0].Rows[0]["PressName"].ToString();
                    txtPressDate.Text = dt.Tables[0].Rows[0]["PressDate"].ToString();
                    txtRevision.Text = dt.Tables[0].Rows[0]["Revision"].ToString();
                    txtRemarks.Text= dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtTotalNumber.Text = dt.Tables[0].Rows[0]["TotalNumber"].ToString();
                    txtTeachingDate.Value = dt.Tables[0].Rows[0]["TeachingDate"].ToString();
                  
                    DlEditedSequence.SelectedValue = dt.Tables[0].Rows[0]["EditedSequence"].ToString();
                    DlPartnerRank.SelectedValue = dt.Tables[0].Rows[0]["PartnerRank"].ToString();

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

                    txtTeachingValue.Text = dt.Tables[0].Rows[0]["TeachingValue"].ToString();
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
                txtTeachingValue.Text = "0";
            }
            else
            {
                txtTeachingValue.Text = ds.Rows[0]["WorkValue"].ToString();
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
           
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);            
            string BookName = txtBookName.Text;
            string TeachingDate = txtTeachingDate.Value;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }      
            string PressName = txtPressName.Text;
            string PressDate = txtPressDate.Text;
            string Revision = txtRevision.Text;
            string TotalNumber = txtTotalNumber.Text;
            double TeachingValue;
            double PartnerValue;
            int PartnerRank;
            string EditedSequence;
            string Remarks = txtRemarks.Text;


            if (BookName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入著作教材名称");
                return;
            }
          
            if (PressName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入出版社");
                return;
            }
            if (PressDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入出版日期");
                return;
            }
            if (DlEditedSequence.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择主编顺序");
                return;
            }
            EditedSequence = Convert.ToString(DlEditedSequence.SelectedItem.Text);
            if (TeachingDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果获得时间");
                return;
            }
            if (Revision == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入版次");
                return;
            }
            if (TotalNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入字数");
                return;
            }
            if (txtTeachingValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                TeachingValue = Convert.ToDouble(txtTeachingValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (TeachingValue <= 0)
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
            if (TeachingValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }


            if (bus.TeachingInsert("Teaching_Insert", UserCardId, BookName,DCategory, DLevel, PressName, PressDate, Revision, TotalNumber, TeachingValue,EditedSequence, PartnerRank, PartnerValue, Remarks,TeachingDate))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'TeachingPartnerManage.aspx'}else {window.location = 'TeachingAdd.aspx'}", true);
            
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
                txtTeachingValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string BookName = txtBookName.Text;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            string PressName = txtPressName.Text;
            string PressDate = txtPressDate.Text;
            string Revision = txtRevision.Text;
            string TotalNumber = txtTotalNumber.Text;
            double TeachingValue;
            double PartnerValue;
            string Remarks = txtRemarks.Text;
            int PartnerRank;
            string EditedSequence;
            string TeachingDate = txtTeachingDate.Value;
            if (BookName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入著作教材名称");
                return;
            }
          
            if (PressName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入出版社");
                return;
            }
            if (PressDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入出版日期");
                return;
            }
            if (DlEditedSequence.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择主编顺序");
                return;
            }
            EditedSequence = Convert.ToString(DlEditedSequence.SelectedItem.Text);
            if (Revision == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入版次");
                return;
            }

            if (TeachingDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果获得时间");
                return;
            }
            if (TotalNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入字数");
                return;
            }
            if (txtTeachingValue.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入成果分值");
                return;
            }
            try
            {
                TeachingValue = Convert.ToDouble(txtTeachingValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "成果分值应为正数");
                return;
            }
            if (TeachingValue <= 0)
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
            if (TeachingValue < PartnerValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "本人得分应小于成果分值");
                return;
            }


            if (bus.TeachingUpdate("Teaching_Update", Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf")), BookName, DCategory, DLevel, PressName, PressDate, Revision, TotalNumber, TeachingValue, EditedSequence, PartnerRank, PartnerValue, Remarks, TeachingDate))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyTeachingManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}