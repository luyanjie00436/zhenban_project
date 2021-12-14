using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class NationUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int NationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            NationId = Convert.ToInt32(Request.QueryString["Nation"]);
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

                DataSet ds = bus.SelectByNationId("Nation_SelectByNationId", NationId);
                txtNationName.Text = ds.Tables[0].Rows[0]["NationName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string NationName = txtNationName.Text.Trim().ToString();
            if (NationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写民族名称");
                return;
            }
            NationId = Convert.ToInt32(Request.QueryString["Nation"]);
            if (bus.NationUpdate("Nation_Update", NationId, NationName))
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