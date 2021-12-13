using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class CompanyUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        int CompanyId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/CompanyManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                CompanyId = Convert.ToInt32(Request.QueryString["Company"]);
                DataSet ds = bus.SelectByCompanyId("Company_SelectByCompanyId", CompanyId);
                txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CompanyName = txtCompanyName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            CompanyId = Convert.ToInt32(Request.QueryString["Company"]);

            if (CompanyName == "")
            {
                AlertMsgAndNoFlush(txtCompanyName, "请填写单位名称");
                return;
            }



            if (bus.CompanyUpdate("Company_Update", CompanyId, CompanyName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
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