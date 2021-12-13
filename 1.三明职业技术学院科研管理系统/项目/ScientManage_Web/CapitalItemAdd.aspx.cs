using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class CapitalItemAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CapitalItemName = txtCapitalItemName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (CapitalItemName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写经费项目名称");
                return;
            }
            if (CapitalItemIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的经费项目已存在");
                return;
            }
            if (bus.CapitalInsert("CapitalItem_Insert", CapitalItemName, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtCapitalItemName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool CapitalItemIf()
        {
            DataSet department = bus.Select("CapitalItem_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["CapitalItemName"].ToString() == txtCapitalItemName.Text.Trim().ToString())
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
            txtCapitalItemName.Text = "";

        }
    }
}