using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ServiceIndustryAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        string UserCardId;
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
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ServiceIndustryManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                clearIfo();
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
            if (CapitalItemIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的服务的国民经济行业已存在");
                return;
            }
            if (bus.ServiceIndustryInsert("ServiceIndustry_Insert", ServiceIndustryName,Id,FatherId, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                clearIfo();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }
        }
        public bool CapitalItemIf()
        {
            DataSet department = bus.Select("ServiceIndustry_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {
                if (item["ServiceIndustryName"].ToString() == txtServiceIndustryName.Text.Trim().ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();
        }
        public void clearIfo()
        {
            txtFatherId.Text = "";
            txtId.Text = "";
            txtServiceIndustryName.Text = "";
        }
    }
}