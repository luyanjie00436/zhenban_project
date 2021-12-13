using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ApplyYearUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int ApplyYearId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyYearId = Convert.ToInt32(Request.QueryString["ApplyYear"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ApplyYearManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet ds = bus.SelectByApplyYearId("ApplyYear_SelectByApplyYearId", ApplyYearId);
                txtStartDate.Value = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtEndDate.Value = ds.Tables[0].Rows[0]["EndDate"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            ApplyYearId = Convert.ToInt32(Request.QueryString["ApplyYear"]);
            string StartDate = txtStartDate.Value;
            string EndDate = txtEndDate.Value;
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写起始时间");
                return;
            }
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写终止时间");
                return;
            }
            if (bus.ApplyYearUpdate("ApplyYear_Update", ApplyYearId, StartDate, EndDate,UserCardId))
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