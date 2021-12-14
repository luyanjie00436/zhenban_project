using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class T_AssessValueReserve : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int AssessValueId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessValueId = Convert.ToInt32(Request.QueryString["AssessValue"]);
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

                DataSet ds = bus.SelectByAssessValueId("T_AssessValue_SelectByT_AssessValueId", AssessValueId);
                txtReserveValue.Text = ds.Tables[0].Rows[0]["NowReserve"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string tReserveValue = txtReserveValue.Text.Trim().ToString();
            if (tReserveValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写预留分值");
                return;
            }
            try
            {
                Convert.ToDouble(tReserveValue);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "预留分值请输入数字");
                return;
            }
            double ReserveValue = Convert.ToDouble(tReserveValue);
            if (ReserveValue < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "预留分值应大于0");
                return;
            }

            AssessValueId = Convert.ToInt32(Request.QueryString["AssessValue"]);
            if (bus.AssessValueUpdateReserve("T_AssessValue_UpdateReserve", AssessValueId, ReserveValue))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                //Response.Redirect("AssessValueManage.aspx");
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