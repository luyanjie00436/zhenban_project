using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class CapitalItemUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int CapitalItemId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            CapitalItemId = Convert.ToInt32(Request.QueryString["CapitalItem"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/CapitalItemManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet ds = bus.SelectByCapitalId("CapitalItem_SelectByCapitalItemId", CapitalItemId);
                txtCapitalItemName.Text = ds.Tables[0].Rows[0]["CapitalItemName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CapitalItemName = txtCapitalItemName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (CapitalItemName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写经费项目名称");
                return;
            }
            CapitalItemId = Convert.ToInt32(Request.QueryString["CapitalItem"]);
            if (bus.CapitalUpdate("CapitalItem_Update", CapitalItemId, CapitalItemName, UserCardId))
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