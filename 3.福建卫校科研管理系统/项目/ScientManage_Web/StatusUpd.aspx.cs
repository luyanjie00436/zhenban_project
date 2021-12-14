using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class StatusUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                DataSet ds = bus.SelectByStatusId("Status_SelectByStatusId", StatusId);
                txtStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string StatusName = txtStatusName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (StatusName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写状态名称");
                return;
            }
            StatusId = Convert.ToInt32(Request.QueryString["Status"]);
            if (bus.StatusUpdate("Status_Update", StatusId, StatusName,UserCardId))
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