using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class WorkLoadProjectsAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int WorkLoadProjectsId;
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WorkLoadProjectsAdd.aspx") == 0)
                //{
                //      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                //}
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "科研项目").Tables[0];
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }

                DataTable dt3 = bus.Select("ProjectsFrom_Select").Tables[0];
                foreach (DataRow dr in dt3.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromExplain"].ToString());
                    DLWorkLoadFrom.Items.Add(li);
                }
                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                if (Request.QueryString["WorkLoadProjectsId"] != null)
                {
                    try
                    {
                        WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                   
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByWorkLoadProjectsId("WorkLoadProjects_SelectByWorkLoadProjectsId", WorkLoadProjectsId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();                   
                    txtWorkLoadProjectsName.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsName"].ToString();
                    txtProjectsId.Text= dt.Tables[0].Rows[0]["ProjectsId"].ToString();
                    DLWorkLoadFrom.SelectedValue = dt.Tables[0].Rows[0]["WorkLoadFrom"].ToString();
                    txtProjectDate.Text = dt.Tables[0].Rows[0]["ProjectDate"].ToString();
                    txtConcludingDate.Text = dt.Tables[0].Rows[0]["ConcludingDate"].ToString();
                    txtWorkLoadCapital.Text = dt.Tables[0].Rows[0]["WorkLoadCapital"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                   
                    DlPartnerRank.Text = dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                    txtPartnerValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                    txtConcludingValue.Text = dt.Tables[0].Rows[0]["ConcludingValue"].ToString();
                    
                  
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
                    txtWorkLoadProjectsValue.Text = dt.Tables[0].Rows[0]["ProjectsValue"].ToString();
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
                txtWorkLoadProjectsValue.Text = "0";
            }
            else
            {
                txtWorkLoadProjectsValue.Text = ds.Rows[0]["WorkValue"].ToString();
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
            if (DLLevel.Items.Count>0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
       
           
            string WorkLoadProjectsName = txtWorkLoadProjectsName.Text.Trim();
            string ProjectsId = txtProjectsId.Text.Trim();
            string WorkLoadForm = DLWorkLoadFrom.SelectedValue;
            string ProjectDate = txtProjectDate.Text.Trim();
            string ConcludingDate = txtConcludingDate.Text.Trim();
            string WorkLoadCapital = txtWorkLoadCapital.Text.Trim();            
            int PartnerRank;
            double WorkLoadProjectsValue = Convert.ToDouble(txtWorkLoadProjectsValue.Text.Trim());
            
            string PartnerValue = txtPartnerValue.Text.Trim();
            string ConcludingValue = txtConcludingValue.Text.Trim();            
            string Remarks = txtRemarks.Text; 
          
            if (WorkLoadProjectsName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入项目成果名称");
                return;
            }
            if (ProjectsId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入项目编号");
                return;
            }
            if (WorkLoadForm == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入来源");
                return;
            }
            if (ProjectDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项日期");
                return;
            }
            if (ConcludingDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题日期");
                return;
            }
            if (WorkLoadCapital == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入到校经费");
                return;
            }
            try
            {
                Convert.ToDouble(WorkLoadCapital);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "到校经费请输入数字！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择个人排名");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (PartnerValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项分值");
                return;
            }
            try
            {
                 Convert.ToDouble(PartnerValue);
            }
            catch (Exception)
            {
                 AlertMsgAndNoFlush(UpdatePanel1, "立项分值请输入数字！");
                return;
            }
            if (ConcludingValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题分值");
                return;
            }
            try
            {
                Convert.ToDouble(ConcludingValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "结题分值请输入数字！");
                return;
            }
            double ProjectsValue=Convert.ToDouble(PartnerValue) + Convert.ToDouble(ConcludingValue);
            if (ProjectsValue > WorkLoadProjectsValue)
            {
                 AlertMsgAndNoFlush(UpdatePanel1, "个人获得总分值应小于项目总分值！");
                return;
            }



            if (bus.WorkLoadProjectsInsert("WorkLoadProjects_Insert",ProjectsId, UserCardId, WorkLoadProjectsName, WorkLoadForm, ProjectDate, ConcludingDate,Convert.ToDouble( WorkLoadCapital), PartnerRank,Convert.ToDouble( ProjectsValue),Convert.ToDouble( PartnerValue),Convert.ToDouble( ConcludingValue), DCategory, DLevel, Remarks,WorkLoadProjectsValue))
            
               {
                   ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'WorkLoadProjectsPartnerManage.aspx'}else {window.location = 'WorkLoadProjectsAdd.aspx'}", true);

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！可能是没有您的审批流程");
            }

        }
        protected void DLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DLLevel.Items.Clear();
            if (DLCategory.SelectedValue!="0")
            {
                CategoryChange();
            }
         
        }
        protected void DLLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DLLevel.SelectedValue!="0")
            {
                int FatherId = Convert.ToInt32(DLLevel.SelectedValue);
                DataTable ds = bus.SelectByWorkCategoryId("WorkCategory_SelectWorkValue", FatherId).Tables[0];
                txtWorkLoadProjectsValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }

            
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }


            string WorkLoadProjectsName = txtWorkLoadProjectsName.Text.Trim();
            string ProjectsId = txtProjectsId.Text.Trim();
            string WorkLoadForm = DLWorkLoadFrom.SelectedValue;
            string ProjectDate = txtProjectDate.Text.Trim();
            string ConcludingDate = txtConcludingDate.Text.Trim();
            string WorkLoadCapital = txtWorkLoadCapital.Text.Trim();
            int PartnerRank;
            double WorkLoadProjectsValue = Convert.ToDouble(txtWorkLoadProjectsValue.Text.Trim());

            string PartnerValue = txtPartnerValue.Text.Trim();
            string ConcludingValue = txtConcludingValue.Text.Trim();
            string Remarks = txtRemarks.Text; 


            if (WorkLoadProjectsName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入项目名称");
                return;
            }
            if (ProjectsId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入项目编号");
                return;
            }
            if (WorkLoadForm == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入来源");
                return;
            }
            if (ProjectDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项日期");
                return;
            }
            if (ConcludingDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题日期");
                return;
            }
            if (WorkLoadCapital == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入到校经费");
                return;
            }
            try
            {
                Convert.ToDouble(WorkLoadCapital);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "到校经费请输入数字！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择个人排名");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (PartnerValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项分值");
                return;
            }
            try
            {
                Convert.ToDouble(PartnerValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "立项分值请输入数字！");
                return;
            }
            if (ConcludingValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题分值");
                return;
            }
            try
            {
                Convert.ToDouble(ConcludingValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "结题分值请输入数字！");
                return;
            }
            double ProjectsValue = Convert.ToDouble(PartnerValue) + Convert.ToDouble(ConcludingValue);
            if (ProjectsValue > WorkLoadProjectsValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "个人获得总分值应小于项目总分值！");
                return;
            }




            WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
            if (bus.WorkLoadProjectsUpdate("WorkLoadProjects_Update", WorkLoadProjectsId, ProjectsId, WorkLoadProjectsName, WorkLoadForm, ProjectDate, ConcludingDate, WorkLoadCapital, WorkLoadProjectsValue, PartnerRank,Convert.ToDouble(PartnerValue), Convert.ToDouble(ProjectsValue), Convert.ToDouble(ConcludingValue), DCategory, DLevel, Remarks))
           // if (bus.WorkLoadProjectsInsert("WorkLoadProjects_Insert", ProjectsId, UserCardId, WorkLoadProjectsName, WorkLoadForm, ProjectDate, ConcludingDate, Convert.ToDouble(WorkLoadCapital), PartnerRank, Convert.ToDouble(ProjectsValue), Convert.ToDouble(PartnerValue), Convert.ToDouble(ConcludingValue), DCategory, DLevel, Remarks, WorkLoadProjectsValue))

            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyWorkLoadProjectsManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }

    }
}