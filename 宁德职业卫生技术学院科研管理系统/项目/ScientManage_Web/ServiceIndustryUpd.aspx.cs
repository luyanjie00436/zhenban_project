using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ServiceIndustryUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int ServiceIndustryId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceIndustryId = Convert.ToInt32(Request.QueryString["ServiceIndustry"]);
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ServiceIndustryManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByServiceIndustryId("ServiceIndustry_SelectByServiceIndustryId", ServiceIndustryId);
                txtServiceIndustryName.Text = ds.Tables[0].Rows[0]["ServiceIndustryName"].ToString();
                txtId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtFatherId.Text = ds.Tables[0].Rows[0]["FatherId"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ServiceIndustryName = txtServiceIndustryName.Text.Trim().ToString();
            string Id = txtId.Text.Trim();
            string FatherId = txtFatherId.Text.Trim();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (Id == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写服务的国民经济行业代码");
                return;
            }
            if (FatherId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写服务的国民经济行业上级代码");
                return;
            }
            if (ServiceIndustryName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写服务的国民经济行业名称");
                return;
            }
            ServiceIndustryId = Convert.ToInt32(Request.QueryString["ServiceIndustry"]);
            if (bus.ServiceIndustryUpdate("ServiceIndustry_Update", ServiceIndustryId, ServiceIndustryName,Id,FatherId, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("ServiceIndustryManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}