using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class DepartmentUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        int DepartmentId;
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
                DepartmentId = Convert.ToInt32(Request.QueryString["Department"]);
                DataSet ds = bus.SelectByDepartmentId("Department_SelectByDepartmentId", DepartmentId);
                txtDepartmentName.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
            
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string DepartmentName = txtDepartmentName.Text.Trim().ToString();
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DepartmentId = Convert.ToInt32(Request.QueryString["Department"]);
           
            if (DepartmentName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写系(部)名称");
                return;
            }
                     


            if (bus.DepartmentUpdate("Department_Update", DepartmentId, DepartmentName,UserCardId))
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