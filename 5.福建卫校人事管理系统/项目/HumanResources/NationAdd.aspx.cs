using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class NationAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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

                clearIfo();
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
            if (NationIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的民族已存在");
                return;
            }
            if (bus.NationInsert("Nation_Insert", NationName))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtNationName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool NationIf()
        {
            DataSet department = bus.Select("Nation_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["NationName"].ToString() == txtNationName.Text.Trim().ToString())
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
            txtNationName.Text = "";

        }

    }
}