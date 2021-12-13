using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class KJprojectAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int KJProjectStatusId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/KJProjectStatusAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet TypeActivity = bus.Select("TypeActivity_Select");
                foreach (DataRow dr in TypeActivity.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["TypeActivityName"].ToString(), dr["TypeActivityId"].ToString());
                    DlClass4.Items.Add(li);
                }
                DataSet Source = bus.Select("ProjectsFrom_Select");
                foreach (DataRow dr in Source.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromId"].ToString());
                    DlClass6.Items.Add(li);
                }
                DataSet Organization = bus.Select("Organization_Select");
                foreach (DataRow dr in Organization.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["OrganizationName"].ToString(), dr["OrganizationId"].ToString());
                    DlClass8.Items.Add(li);
                }
                DataSet Cooperation = bus.Select("Cooperation_Select");
                foreach (DataRow dr in Cooperation.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["CooperationName"].ToString(), dr["CooperationId"].ToString());
                    DlClass10.Items.Add(li);
                }
                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId", 0);
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims1.Items.Add(li);
                }
                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", "0");

                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["Id"].ToString() + "-" + dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlServiceIndustry1.Items.Add(li);
                }

                if (Request.QueryString["KJProjectStatusId"] != null)
                {
                    try
                    {
                        KJProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["KJProjectStatusId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    #region 绑定

                    DataSet dt = bus.SelectKJProjectStatusId("KJProjectStatus_SelectByKJProjectStatusId", KJProjectStatusId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    DataSet dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Value = dt1.Tables[0].Rows[0]["UserName"].ToString();
                    txtKJProjectName.Value = dt.Tables[0].Rows[0]["KJProjectName"].ToString();
                    txtKJProjectId.Value = dt.Tables[0].Rows[0]["KJProjectId"].ToString();
                    txtApplyYear.Value = dt.Tables[0].Rows[0]["ApplyYear"].ToString();
                    txtApprovalDate.Value = dt.Tables[0].Rows[0]["ApprovalDate"].ToString();
                    txtFunding1.Value = dt.Tables[0].Rows[0]["Funding1"].ToString();
                    txtFunding2.Value = dt.Tables[0].Rows[0]["Funding2"].ToString();
                    txtFunding3.Value = dt.Tables[0].Rows[0]["Funding3"].ToString();
                    txtFunding4.Value = dt.Tables[0].Rows[0]["Funding4"].ToString();
                    txtFunding5.Value = dt.Tables[0].Rows[0]["Funding5"].ToString();
                    txtFunding6.Value = dt.Tables[0].Rows[0]["Funding6"].ToString();
                    txtFunding7.Value = dt.Tables[0].Rows[0]["Funding7"].ToString();
                    txtFunding8.Value = dt.Tables[0].Rows[0]["Funding8"].ToString();
                    txtFunding9.Value = dt.Tables[0].Rows[0]["Funding9"].ToString();
                    txtFunding10.Value = dt.Tables[0].Rows[0]["Funding10"].ToString();
                    txtFunding11.Value = dt.Tables[0].Rows[0]["Funding11"].ToString();
                    txtFunding12.Value = dt.Tables[0].Rows[0]["Funding12"].ToString();
                    txtPersonnel1.Value = dt.Tables[0].Rows[0]["Personnel1"].ToString();
                    txtPersonnel2.Value = dt.Tables[0].Rows[0]["Personnel2"].ToString();
                    txtPersonnel3.Value = dt.Tables[0].Rows[0]["Personnel3"].ToString();
                    txtPersonnel4.Value = dt.Tables[0].Rows[0]["Personnel4"].ToString();
                    txtPersonnel5.Value = dt.Tables[0].Rows[0]["Personnel5"].ToString();
                    txtPersonnel6.Value = dt.Tables[0].Rows[0]["Personnel6"].ToString();
                    txtQuantity1.Value = dt.Tables[0].Rows[0]["Quantity1"].ToString();
                    txtQuantity2.Value = dt.Tables[0].Rows[0]["Quantity2"].ToString();
                    txtQuantity3.Value = dt.Tables[0].Rows[0]["Quantity3"].ToString();
                    txtClass1.Value = dt.Tables[0].Rows[0]["Class1"].ToString();
                    txtClass2.Value = dt.Tables[0].Rows[0]["Class2"].ToString();
                    txtClass3.Value = dt.Tables[0].Rows[0]["Class3"].ToString();
                    DlClass4.Text = dt.Tables[0].Rows[0]["TypeActivityName"].ToString();
                    txtClass5.Value = dt.Tables[0].Rows[0]["Class5"].ToString();
                    DlClass6.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    txtClass7.Value = dt.Tables[0].Rows[0]["Class7"].ToString();
                    DlClass8.Text = dt.Tables[0].Rows[0]["OrganizationName"].ToString();
                    txtClass9.Value = dt.Tables[0].Rows[0]["Class9"].ToString();
                    DlClass10.Text = dt.Tables[0].Rows[0]["CooperationName"].ToString();


                    DlAims1.SelectedValue = dt.Tables[0].Rows[0]["AimsId1"].ToString();
                    if (dt.Tables[0].Rows[0]["AimsId2"].ToString() != "")
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

                    DlClass4.SelectedValue = dt.Tables[0].Rows[0]["TypeActivityId"].ToString();
                    DlClass6.SelectedValue = dt.Tables[0].Rows[0]["ProjectsFromId"].ToString();
                    DlClass8.SelectedValue = dt.Tables[0].Rows[0]["OrganizationId"].ToString();
                    DlClass10.SelectedValue = dt.Tables[0].Rows[0]["CooperationId"].ToString();
                    #endregion
                }
                else
                {

                    DataSet ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Value = ds.Tables[0].Rows[0]["UserName"].ToString();
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
            string KJProjectId = txtKJProjectId.Value;
            string ApplyYear = txtApplyYear.Value;
            string KJProjectName = txtKJProjectName.Value;
            string ApprovalDate = txtApprovalDate.Value;
            string Funding1= txtFunding1.Value;
            string Funding2= txtFunding2.Value;
            string Funding3= txtFunding3.Value;
            string Funding4= txtFunding4.Value;
            string Funding5= txtFunding5.Value;
            string Funding6= txtFunding6.Value;
            string Funding7= txtFunding7.Value;
            string Funding8= txtFunding8.Value;
            string Funding9= txtFunding9.Value;
            string Funding10= txtFunding10.Value;
            string Funding11= txtFunding11.Value;
            string Funding12= txtFunding12.Value;
            string Personnel1= txtPersonnel1.Value;
            string Personnel2= txtPersonnel2.Value;
            string Personnel3= txtPersonnel3.Value;
            string Personnel4= txtPersonnel4.Value;
            string Personnel5= txtPersonnel5.Value;
            string Personnel6= txtPersonnel6.Value;
            string Quantity1= txtQuantity1.Value;
            string Quantity2= txtQuantity2.Value;
            string Quantity3= txtQuantity3.Value;
            string Class1 = txtClass1.Value;
            string Class2 = txtClass2.Value;
            string Class3 = txtClass3.Value;
            int TypeActivityId =Convert.ToInt32(DlClass4.SelectedItem.Value);
            string Class5 = txtClass5.Value;
            int SourceId = Convert.ToInt32(DlClass6.SelectedItem.Value);
            string Class7 = txtClass7.Value;
            int OrganizationId = Convert.ToInt32(DlClass8.SelectedItem.Value);
            string Class9 = txtClass9.Value;
            int CooperationId = Convert.ToInt32(DlClass10.SelectedItem.Value);
            string AimsId1 = DlAims1.SelectedValue;
            string AimsId2 = DlAims2.SelectedValue;
            string AimsId3 = DlAims3.SelectedValue;
            string ServiceIndustry1 = DlServiceIndustry1.SelectedValue;
            string ServiceIndustry2 = DlServiceIndustry2.SelectedValue;
            string ServiceIndustry3 = DlServiceIndustry3.SelectedValue;
            string ServiceIndustry4 = DlServiceIndustry4.SelectedValue;

            if (bus.KJProjectStatusInsert("KJProjectStatus_Insert", UserCardId, KJProjectId, ApplyYear,KJProjectName, ApprovalDate, Funding1,
            Funding2, Funding3, Funding4, Funding5, Funding6, Funding7, Funding8, Funding9, Funding10, Funding11,
            Funding12, Personnel1, Personnel2, Personnel3, Personnel4, Personnel5, Personnel6, Quantity1, Quantity2,
            Quantity3, Class1, Class2, Class3, TypeActivityId, Class5, SourceId, Class7, OrganizationId, Class9,
            CooperationId, AimsId1, AimsId2, AimsId3, ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4))
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

            KJProjectStatusId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["KJProjectStatusId"], "asdfasdf"));
            string KJProjectId = txtKJProjectId.Value;
            string ApplyYear = txtApplyYear.Value;
            string KJProjectName = txtKJProjectName.Value;
            string ApprovalDate = txtApprovalDate.ToString();
            string Funding1 = txtFunding1.Value;
            string Funding2 = txtFunding2.Value;
            string Funding3 = txtFunding3.Value;
            string Funding4 = txtFunding4.Value;
            string Funding5 = txtFunding5.Value;
            string Funding6 = txtFunding6.Value;
            string Funding7 = txtFunding7.Value;
            string Funding8 = txtFunding8.Value;
            string Funding9 = txtFunding9.Value;
            string Funding10 = txtFunding10.Value;
            string Funding11 = txtFunding11.Value;
            string Funding12 = txtFunding12.Value;
            string Personnel1 = txtPersonnel1.Value;
            string Personnel2 = txtPersonnel2.Value;
            string Personnel3 = txtPersonnel3.Value;
            string Personnel4 = txtPersonnel4.Value;
            string Personnel5 = txtPersonnel5.Value;
            string Personnel6 = txtPersonnel6.Value;
            string Quantity1 = txtQuantity1.Value;
            string Quantity2 = txtQuantity2.Value;
            string Quantity3 = txtQuantity3.Value;
            string Class1 = txtClass1.Value;
            string Class2 = txtClass2.Value;
            string Class3 = txtClass3.Value;
            int TypeActivityId = Convert.ToInt32(DlClass4.SelectedItem.Value);
            string Class5 = txtClass5.Value;
            int SourceId = Convert.ToInt32(DlClass6.SelectedItem.Value);
            string Class7 = txtClass7.Value;
            int OrganizationId = Convert.ToInt32(DlClass8.SelectedItem.Value);
            string Class9 = txtClass9.Value;
            int CooperationId = Convert.ToInt32(DlClass10.SelectedItem.Value);
            string AimsId1 = DlAims1.SelectedValue;
            string AimsId2 = DlAims2.SelectedValue;
            string AimsId3 = DlAims3.SelectedValue;
            string ServiceIndustry1 = DlServiceIndustry1.SelectedValue;
            string ServiceIndustry2 = DlServiceIndustry2.SelectedValue;
            string ServiceIndustry3 = DlServiceIndustry3.SelectedValue;
            string ServiceIndustry4 = DlServiceIndustry4.SelectedValue;

            if (bus.KJProjectStatusUpdate("KJProjectStatus_Update", KJProjectId,ApplyYear, KJProjectName, ApprovalDate, Funding1,
            Funding2, Funding3, Funding4, Funding5, Funding6, Funding7, Funding8, Funding9, Funding10, Funding11,
            Funding12, Personnel1, Personnel2, Personnel3, Personnel4, Personnel5, Personnel6, Quantity1, Quantity2,
            Quantity3, Class1, Class2, Class3, TypeActivityId, Class5, SourceId, Class7, OrganizationId, Class9,
            CooperationId, AimsId1, AimsId2, AimsId3, ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4))
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