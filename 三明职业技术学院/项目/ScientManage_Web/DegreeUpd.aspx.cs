using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class DegreeUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int DegreeId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            DegreeId = Convert.ToInt32(Request.QueryString["Degree"]);
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

                DataSet ds = bus.SelectByDegreeId("Degree_SelectByDegreeId", DegreeId);
                txtDegreeName.Text = ds.Tables[0].Rows[0]["DegreeName"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string DegreeName = txtDegreeName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (DegreeName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写学位名称");
                return;
            }
            DegreeId = Convert.ToInt32(Request.QueryString["Degree"]);
            if (bus.DegreeUpdate("Degree_Update", DegreeId, DegreeName,UserCardId))
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