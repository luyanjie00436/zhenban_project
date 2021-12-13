using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ProjectStatusAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int ProjectStatusId;
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

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ProjectStatusAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Subject = bus.Select("Subject_Select");
                foreach (DataRow dr in Subject.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["SubjectName"].ToString(), dr["SubjectId"].ToString());
                    DlSubject.Items.Add(li);
                }
                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId", 0);
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString()+"-"+dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims1.Items.Add(li);
                }
                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", "0");
             
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-"+dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlServiceIndustry1.Items.Add(li);
                }



                if (Request.QueryString["ProjectStatusId"] != null)
                {
                    try
                    {
                        ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    #region 绑定

                    DataSet dt = bus.SelectProjectStatusId("ProjectStatus_SelectByProjectStatusId", ProjectStatusId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    DataSet dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Value = dt1.Tables[0].Rows[0]["UserName"].ToString();
                    txtDepartment.Value = dt1.Tables[0].Rows[0]["DepartmentName"].ToString();
                    txtProjectStatusName.Value= dt.Tables[0].Rows[0]["ProjectStatusName"].ToString();
                    txtProjectId.Value = dt.Tables[0].Rows[0]["ProjectId"].ToString();
                    txtSource.Value = dt.Tables[0].Rows[0]["Source"].ToString();
                    
                    txtPersonnel.Value = dt.Tables[0].Rows[0]["Personnel"].ToString();
                    DlSubject.Text = dt.Tables[0].Rows[0]["SubjectName"].ToString();
                    DlCooperation.Text = dt.Tables[0].Rows[0]["Cooperation"].ToString();
                  
                    txtFunding1.Value = dt.Tables[0].Rows[0]["Funding1"].ToString();
                    txtFunding2.Value = dt.Tables[0].Rows[0]["Funding2"].ToString();
                    txtFunding3.Value = dt.Tables[0].Rows[0]["Funding3"].ToString();
                    txtFunding4.Value = dt.Tables[0].Rows[0]["Funding4"].ToString();
                  
                    DlCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    DlResults.Text = dt.Tables[0].Rows[0]["Results"].ToString();
                    txtProjectDate.Value = dt.Tables[0].Rows[0]["ProjectDate"].ToString();
                    txtResultsDate.Value = dt.Tables[0].Rows[0]["ResultsDate"].ToString();
                    DlStatus.Text = dt.Tables[0].Rows[0]["Status"].ToString();
                    txtTransferUnit.Value = dt.Tables[0].Rows[0]["TransferUnit"].ToString();
                    txtTransferName.Value = dt.Tables[0].Rows[0]["TransferName"].ToString();
                    txtCost1.Value = dt.Tables[0].Rows[0]["Cost1"].ToString();
                    txtCost2.Value = dt.Tables[0].Rows[0]["Cost2"].ToString();
                    txtCost3.Value = dt.Tables[0].Rows[0]["Cost3"].ToString();
                    txtCost4.Value = dt.Tables[0].Rows[0]["Cost4"].ToString();
                    txtCost5.Value = dt.Tables[0].Rows[0]["Cost5"].ToString();
                    txtCost6.Value = dt.Tables[0].Rows[0]["Cost6"].ToString();
                    txtCost7.Value = dt.Tables[0].Rows[0]["Cost7"].ToString();
                    DlSubject.SelectedValue = dt.Tables[0].Rows[0]["SubjectId"].ToString();
                    DlAims1.SelectedValue = dt.Tables[0].Rows[0]["AimsId1"].ToString();
                    if (dt.Tables[0].Rows[0]["AimsId2"].ToString()!="")
                    {
                        Aims1();
                        DlAims2.SelectedValue = dt.Tables[0].Rows[0]["AimsId2"].ToString();

                    }
                    if (dt.Tables[0].Rows[0]["AimsId3"].ToString() != "")
                    {
                        Aims2();
                        DlAims3.SelectedValue = dt.Tables[0].Rows[0]["AimsId3"].ToString();
                    }
                    DlServiceIndustry1.SelectedValue = dt.Tables[0].Rows[0]["ServiceIndustryId1"].ToString();
                    if (dt.Tables[0].Rows[0]["ServiceIndustryId2"].ToString() != "")
                    {
                        DlSerivice1();
                        DlServiceIndustry2.SelectedValue = dt.Tables[0].Rows[0]["ServiceIndustryId2"].ToString();
                    }
                    if (dt.Tables[0].Rows[0]["ServiceIndustryId3"].ToString() != "")
                    {
                        DlSerivice2();
                        DlServiceIndustry3.SelectedValue = dt.Tables[0].Rows[0]["ServiceIndustryId3"].ToString();
                    }
                    if (dt.Tables[0].Rows[0]["ServiceIndustryId4"].ToString() != "")
                    {
                        DlSerivice3();
                        DlServiceIndustry4.SelectedValue = dt.Tables[0].Rows[0]["ServiceIndustryId4"].ToString();
                    }
                  

                    #endregion
                }
                else
                {
                    DataSet ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Value = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtDepartment.Value = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                    Button2.Visible = false;
                }
              
            }
        }
        protected void DlAims1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aims1();
        }
        protected void DlAims2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aims2();
        }
        public void Aims1()
        {
            DlAims2.Items.Clear();
            DlAims3.Items.Clear();
            if (DlAims1.SelectedValue != "0")
            {
                int AimsId = Convert.ToInt32(DlAims1.SelectedValue.ToString());

                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId", AimsId);

                if (Aims.Tables[0].Rows.Count > 0)
                {
                    ListItem li2 = new ListItem("请选择", "0");
                    DlAims2.Items.Add(li2);

                }
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims2.Items.Add(li);
                }

            }
        }
        public void Aims2()
        {
            DlAims3.Items.Clear();
            if (DlAims2.SelectedValue != "0")
            {
                int AimsId = Convert.ToInt32(DlAims2.SelectedValue.ToString());

                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId", AimsId);
                if (Aims.Tables[0].Rows.Count > 0)
                {
                    ListItem li2 = new ListItem("请选择", "0");
                    DlAims3.Items.Add(li2);
                }
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims3.Items.Add(li);
                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ProjectId = txtProjectId.Value;
            string ProjectStatusName = txtProjectStatusName.Value;
            string Source = txtSource.Value;
            string Personnel = txtPersonnel.Value;
            int SubjectId = Convert.ToInt32(DlSubject.SelectedItem.Value);
            string Cooperation = DlCooperation.Text.ToString();
            string AimsId1 = DlAims1.SelectedValue;
            string AimsId2 = DlAims2.SelectedValue;
            string AimsId3 = DlAims3.SelectedValue;
            string ServiceIndustry1 = DlServiceIndustry1.SelectedValue;
            string ServiceIndustry2 = DlServiceIndustry2.SelectedValue;
            string ServiceIndustry3 = DlServiceIndustry3.SelectedValue;
            string ServiceIndustry4 = DlServiceIndustry4.SelectedValue;
            string Category = DlCategory.Text.ToString();
            string ProjectDate = txtProjectDate.Value;
            string ResultsDate = txtResultsDate.Value;
            string Results = DlResults.Text.ToString();
            string Status = DlStatus.Text.ToString();
            string Funding1 = txtFunding1.Value;
            string Funding2 = txtFunding2.Value;
            string Funding3 = txtFunding3.Value;
            string Funding4 = txtFunding4.Value;
            string TransferUnit = txtTransferUnit.Value;
            string TransferName = txtTransferName.Value;
            string Cost1 = txtCost1.Value;
            string Cost2 = txtCost2.Value;
            string Cost3 = txtCost3.Value;
            string Cost4 = txtCost4.Value;
            string Cost5 = txtCost5.Value;
            string Cost6 = txtCost6.Value;
            string Cost7 = txtCost7.Value;
            if (bus.ProjectStatusInsert("ProjectStatus_Insert", UserCardId, ProjectId, ProjectStatusName,
                Source,Personnel, SubjectId, Cooperation, AimsId1, AimsId2, AimsId3, ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4, Category, ProjectDate,
                ResultsDate, Results, Status, Funding1, Funding2, Funding3, Funding4, TransferUnit, TransferName,
                Cost1, Cost2, Cost3, Cost4, Cost5, Cost6, Cost7))
            {
                RegisterStartupScript("true", "<script>alert('添加成功')</script>");
                return;
            }
            else
            {
                RegisterStartupScript("true", "<script>alert('添加失败')</script>");
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            ProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ProjectStatusId"], "asdfasdf"));
            string ProjectId = txtProjectId.Value;
            string ProjectStatusName = txtProjectStatusName.Value;
            string Source = txtSource.Value;
            string Personnel = txtPersonnel.Value;
            int SubjectId = Convert.ToInt32(DlSubject.SelectedItem.Value);
            string Cooperation = DlCooperation.Text.ToString();
            string AimsId1 = DlAims1.SelectedValue;
            string AimsId2 = DlAims2.SelectedValue;
            string AimsId3 = DlAims3.SelectedValue;
            string ServiceIndustry1 = DlServiceIndustry1.SelectedValue;
            string ServiceIndustry2 = DlServiceIndustry2.SelectedValue;
            string ServiceIndustry3 = DlServiceIndustry3.SelectedValue;
            string ServiceIndustry4 = DlServiceIndustry4.SelectedValue;
            string Category = DlCategory.Text.ToString();
            string ProjectDate = txtProjectDate.Value;
            string ResultsDate = txtResultsDate.Value;
            string Results = DlResults.Text.ToString();
            string Status = DlStatus.Text.ToString();
            string Funding1 = txtFunding1.Value;
            string Funding2 = txtFunding2.Value;
            string Funding3 = txtFunding3.Value;
            string Funding4 = txtFunding4.Value;
            string TransferUnit = txtTransferUnit.Value;
            string TransferName = txtTransferName.Value;
            string Cost1 = txtCost1.Value;
            string Cost2 = txtCost2.Value;
            string Cost3 = txtCost3.Value;
            string Cost4 = txtCost4.Value;
            string Cost5 = txtCost5.Value;
            string Cost6 = txtCost6.Value;
            string Cost7 = txtCost7.Value;
            if (bus.ProjectStatusUpdate("ProjectStatus_Update", ProjectStatusId, ProjectId, ProjectStatusName,
               Source, Personnel, SubjectId, Cooperation, AimsId1, AimsId2, AimsId3, ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4, Category, ProjectDate,
               ResultsDate, Results, Status, Funding1, Funding2, Funding3, Funding4, TransferUnit, TransferName,
               Cost1, Cost2, Cost3, Cost4, Cost5, Cost6, Cost7))
            {
                RegisterStartupScript("true", "<script>alert('保存成功')</script>");
                return;
            }
            else
            {
                RegisterStartupScript("true", "<script>alert('保存失败')</script>");
                return;
            }
        }

        protected void DlServiceIndustry_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DlSerivice1();
        }
        public void DlSerivice1()
        {
            DlServiceIndustry2.Items.Clear();
            DlServiceIndustry3.Items.Clear();
            DlServiceIndustry4.Items.Clear();
            if (DlServiceIndustry1.SelectedValue != "0")
            {

                string SeriviceId = DlServiceIndustry1.SelectedValue.ToString();
                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", SeriviceId);
                if (Serivice.Tables[0].Rows.Count > 0)
                {
                    ListItem li2 = new ListItem("请选择", "0");
                    DlServiceIndustry2.Items.Add(li2);

                }
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlServiceIndustry2.Items.Add(li);
                }

            }
        }
        protected void DlServiceIndustry_SelectedIndexChanged2(object sender, EventArgs e)
        {
            DlSerivice2();
        }
        public void DlSerivice2()
        {
            DlServiceIndustry3.Items.Clear();
            DlServiceIndustry4.Items.Clear();
            if (DlServiceIndustry2.SelectedValue != "0")
            {
                string SeriviceId = DlServiceIndustry2.SelectedValue.ToString();

                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", SeriviceId);
                if (Serivice.Tables[0].Rows.Count > 0)
                {
                    ListItem li2 = new ListItem("请选择", "0");
                    DlServiceIndustry3.Items.Add(li2);

                }
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlServiceIndustry3.Items.Add(li);
                }

            }
        }
        public void DlSerivice3()
        {
            DlServiceIndustry4.Items.Clear();
            if (DlServiceIndustry3.SelectedValue != "0")
            {
                string SeriviceId = DlServiceIndustry3.SelectedValue.ToString();

                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", SeriviceId);
                if (Serivice.Tables[0].Rows.Count > 0)
                {
                    ListItem li2 = new ListItem("请选择", "0");
                    DlServiceIndustry4.Items.Add(li2);

                }
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlServiceIndustry4.Items.Add(li);
                }

            }
        }
        protected void DlServiceIndustry_SelectedIndexChanged3(object sender, EventArgs e)
        {
            DlSerivice3();
        }
    }
}