using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class KJprojectDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int KJProjectStatusId;
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
                    DataSet dt = bus.SelectByKJProjectStatusId("KJProjectStatus_SelectByKJProjectStatusId", KJProjectStatusId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LApplyYear.Text = dt.Tables[0].Rows[0]["ApplyYear"].ToString();
                    LKJProjectName.Text = dt.Tables[0].Rows[0]["KJProjectName"].ToString();
                    LKJProjectId.Text = dt.Tables[0].Rows[0]["KJProjectId"].ToString();
                    LApprovalDate.Text = dt.Tables[0].Rows[0]["ApprovalDate"].ToString();
                    LFunding1.Text = dt.Tables[0].Rows[0]["Funding1"].ToString();
                    LFunding2.Text = dt.Tables[0].Rows[0]["Funding2"].ToString();
                    LFunding3.Text = dt.Tables[0].Rows[0]["Funding3"].ToString();
                    LFunding4.Text = dt.Tables[0].Rows[0]["Funding4"].ToString();
                    LFunding5.Text = dt.Tables[0].Rows[0]["Funding5"].ToString();
                    LFunding6.Text = dt.Tables[0].Rows[0]["Funding6"].ToString();
                    LFunding7.Text = dt.Tables[0].Rows[0]["Funding7"].ToString();
                    LFunding8.Text = dt.Tables[0].Rows[0]["Funding8"].ToString();
                    LFunding9.Text = dt.Tables[0].Rows[0]["Funding9"].ToString();
                    LFunding10.Text = dt.Tables[0].Rows[0]["Funding10"].ToString();
                    LFunding11.Text = dt.Tables[0].Rows[0]["Funding11"].ToString();
                    LFunding12.Text = dt.Tables[0].Rows[0]["Funding12"].ToString();
                    LPersonnel1.Text = dt.Tables[0].Rows[0]["Personnel1"].ToString();
                    LPersonnel2.Text = dt.Tables[0].Rows[0]["Personnel2"].ToString();
                    LPersonnel3.Text = dt.Tables[0].Rows[0]["Personnel3"].ToString();
                    LPersonnel4.Text = dt.Tables[0].Rows[0]["Personnel4"].ToString();
                    LPersonnel5.Text = dt.Tables[0].Rows[0]["Personnel5"].ToString();
                    LPersonnel6.Text = dt.Tables[0].Rows[0]["Personnel6"].ToString();
                    LQuantity1.Text = dt.Tables[0].Rows[0]["Quantity1"].ToString();
                    LQuantity2.Text = dt.Tables[0].Rows[0]["Quantity2"].ToString();
                    LQuantity3.Text = dt.Tables[0].Rows[0]["Quantity3"].ToString();
                    LClass1.Text = dt.Tables[0].Rows[0]["Class1"].ToString();
                    LClass2.Text = dt.Tables[0].Rows[0]["Class2"].ToString();
                    LClass3.Text = dt.Tables[0].Rows[0]["Class3"].ToString();
                    LClass4.Text = dt.Tables[0].Rows[0]["TypeActivityName"].ToString();
                    LClass5.Text = dt.Tables[0].Rows[0]["Class5"].ToString();
                    LClass6.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    LClass7.Text = dt.Tables[0].Rows[0]["Class7"].ToString();
                    LClass8.Text = dt.Tables[0].Rows[0]["OrganizationName"].ToString();
                    LClass9.Text = dt.Tables[0].Rows[0]["Class9"].ToString();
                    LClass10.Text = dt.Tables[0].Rows[0]["CooperationName"].ToString();
                    LAims1.Text = dt.Tables[0].Rows[0]["Aims1"].ToString();
                    LAims2.Text = dt.Tables[0].Rows[0]["Aims2"].ToString();
                    LAims3.Text = dt.Tables[0].Rows[0]["Aims3"].ToString();
                    LServiceIndustry1.Text = dt.Tables[0].Rows[0]["Service2"].ToString();
                    LServiceIndustry2.Text = dt.Tables[0].Rows[0]["Service3"].ToString();
                    LServiceIndustry3.Text = dt.Tables[0].Rows[0]["Service4"].ToString();

                }
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];

                LUserName.Text = dt1.Rows[0]["UserName"].ToString();

               
                DataSet dy = bus.SelectByKJProjectStatusId("KJProjectStatusExamine_Select", KJProjectStatusId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }
            }
        }
    }
}