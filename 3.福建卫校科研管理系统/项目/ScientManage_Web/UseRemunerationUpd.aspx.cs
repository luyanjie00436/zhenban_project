using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UseRemunerationUpd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int UseRemunerationId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            UseRemunerationId = Convert.ToInt32(Request.QueryString["UserRemuneration"]);
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
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleName"].ToString());
                    txtRole.Items.Add(li);
                }


                DataSet ds = bus.UseRemunerationSelectByUseRemunerationId("UseRemuneration_SelectByUseRemunerationId", UseRemunerationId);

                LUserCardId.Text = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                txtRole.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                txtRemuneration.Text = ds.Tables[0].Rows[0]["Remuneration"].ToString();
                txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate"].ToString();



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
            UseRemunerationId = Convert.ToInt32(Request.QueryString["UserRemuneration"]);
            if (bus.UseRemunerationUpdate("UseRemuneration_Update", UseRemunerationId, UserCardId, RoleName, Remuneration, StartDate, EndDate))
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