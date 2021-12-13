using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class TypeActivityAdd : System.Web.UI.Page
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
                } if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TypeActivityManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string TypeActivityName = txtTypeActivityName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (TypeActivityName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写活动类型名称");
                return;
            }
            if (CapitalItemIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的活动类型已存在");
                return;
            }
            if (bus.TypeActivityInsert("TypeActivity_Insert", TypeActivityName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtTypeActivityName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }
        }
        public bool CapitalItemIf()
        {
            DataSet department = bus.Select("TypeActivity_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {
                if (item["TypeActivityName"].ToString() == txtTypeActivityName.Text.Trim().ToString())
                {
                    return true;
                }
            }
            return false;
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
            txtTypeActivityName.Text = "";
        }
    }
}