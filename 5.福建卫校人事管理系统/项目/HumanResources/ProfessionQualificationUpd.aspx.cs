using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ProfessionQualificationUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        int ProfessionQualificationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfessionQualificationId = Convert.ToInt32(Request.QueryString["ProfessionQualification"]);
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

                DataSet ds = bus.SelectByProfessionQualificationId("ProfessionQualification_SelectByProfessionQualificationId", ProfessionQualificationId);
                txtProfessionQualificationName.Text = ds.Tables[0].Rows[0]["ProfessionQualificationName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProfessionQualificationName = txtProfessionQualificationName.Text.Trim().ToString();
            if (ProfessionQualificationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写专业技术资格名称");
                return;
            }
            ProfessionQualificationId = Convert.ToInt32(Request.QueryString["ProfessionQualification"]);
            if (bus.ProfessionQualificationUpdate("ProfessionQualification_Update", ProfessionQualificationId, ProfessionQualificationName))
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