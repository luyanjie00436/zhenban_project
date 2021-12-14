using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ApplyRemarksUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int AssessValueId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessValueId = Convert.ToInt32(Request.QueryString["AssessValue1"]);
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

                DataSet ds = bus.SelectByAssessValueId("AssessValue_SelectByAssessValueId", AssessValueId);
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string Remarks = txtRemarks.Text.Trim().ToString();
            if (Remarks == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写备注");
                return;
            }
            AssessValueId = Convert.ToInt32(Request.QueryString["AssessValue1"]);
            if (bus.AssessValueUpdate("AssessValue_Update", AssessValueId, Remarks, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                //Response.Redirect("AdminSeriesManage.aspx");
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