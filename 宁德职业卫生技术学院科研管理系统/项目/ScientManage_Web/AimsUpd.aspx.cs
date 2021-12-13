using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AimsUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        int AimsId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AimsId = Convert.ToInt32(Request.QueryString["Aims"]);
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AimsManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByAimsId("Aims_SelectByAimsId", AimsId);
                txtAimsName.Text = ds.Tables[0].Rows[0]["AimsName"].ToString();
                txtExplain.Text = ds.Tables[0].Rows[0]["Explain"].ToString();
                txtFatherId.Text = ds.Tables[0].Rows[0]["FatherId"].ToString();
                txtId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string AimsName = txtAimsName.Text.Trim().ToString();
            string Id = txtId.Text.Trim().ToString();
            string Explain = txtExplain.Text.Trim().ToString();
            string FatherId = txtFatherId.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (AimsName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写社会经济目标名称");
                return;
            }
            if (Id == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写社会经济目标编号");
                return;
            }
            if (FatherId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写上级编号，没有则为0");
                return;
            }
            AimsId = Convert.ToInt32(Request.QueryString["Aims"]);
            if (bus.AimsUpdate("Aims_Update", AimsId, AimsName, Id, Explain, FatherId, UserCardId))
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