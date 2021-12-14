using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class StatusUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int StatusId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            StatusId = Convert.ToInt32(Request.QueryString["Status"]);
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

                DataSet ds = bus.SelectByStatusId("Status_SelectByStatusId", StatusId);
                txtStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string StatusName = txtStatusName.Text.Trim().ToString();
            if (StatusName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写状态名称");
                return;
            }
            StatusId = Convert.ToInt32(Request.QueryString["Status"]);
            if (bus.StatusUpdate("Status_Update", StatusId, StatusName))
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