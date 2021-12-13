using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AimsAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AimsManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                clearIfo();
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
            if (Id=="")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写社会经济目标编号");
                return;
            }
            if (FatherId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写上级编号，没有则为0");
                return;
            }
         
            if (bus.AimsInsert("Aims_Insert", AimsName,Id,Explain,FatherId, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                clearIfo();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }
        }
       
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();
        }
        public void clearIfo()
        {
            txtAimsName.Text = "";
            txtFatherId.Text = "";
            txtExplain.Text = "";
            txtId.Text = "";
        }
    }
}