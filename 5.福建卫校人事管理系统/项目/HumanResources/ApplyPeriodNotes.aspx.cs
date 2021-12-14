using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ApplyPeriodNotes : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["Human_ConStr"].ToString();
        DataTable dt = new DataTable();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int ApplyYearId;
        int bianhao;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ApplyPeriodNotes.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

                DataTable dt1 = bus.Select("ApplyYear_Select").Tables[0];
                DlYear.Items.Clear();
                DlYear.Items.Add("请选择");
                DlYear.Items[0].Value = "0";
                foreach (DataRow dr in dt1.Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DlYear.Items.Add(li);
                }
              
                dataGridviewBD();
            }
        }



        protected void dataGridviewBD()
        {
          string   UserName = txtUserName.Text.Trim();
            string Year=DlYear.SelectedItem.Text;
            DataSet ds = bus.TechnicianEducationGetAll("AuthorityView_Selects",UserName,Year);
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }


        protected void ReturnApply_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("ApplyPeriodManage.aspx?Year=" + e.CommandArgument.ToString());
        }

        protected void ReturnItem_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ApplyPeriodItem.aspx?Year=" + e.CommandArgument.ToString());
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
          //  DataSet ds = bus.TechnicianEducationGetAll("AuthorityView_Selects");
            bianhao =Convert.ToInt32( e.CommandArgument.ToString());
            if (bus.ApplyPeriodViewDeleting("ApplyPeriodView_Deleting",bianhao))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGridviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败！请联系系统管理员解决问题");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGridviewBD();
        }
    }
}