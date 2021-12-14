using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UseRemunerationAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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

                LUserCardId.Text = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleName"].ToString());
                    txtRole.Items.Add(li);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = LUserCardId.Text;
            string RoleName = txtRole.Text;
            string Remuneration = txtRemuneration.Text;
            string StartDate = txtStartDate.Text;
            string EndDate = txtEndDate.Text;

            if (Remuneration == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写行政职级");
                return;
            }
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写获得时间");
                return;
            }
            if (bus.UseRemunerationInsert("UseRemuneration_Insert", UserCardId, RoleName, Remuneration, StartDate, EndDate))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

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
            txtRemuneration.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
    }
}