using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ResumeManage : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ResumeManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

               
                DataSet Education = bus.Select("Education_Select");
                foreach (DataRow dr in Education.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["EducationName"].ToString(), dr["EducationId"].ToString());
                    DlEducation.Items.Add(li);
                }
                DataSet Political = bus.Select("Political_Select");
                foreach (DataRow dr in Political.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalId"].ToString());
                    DlPolitical.Items.Add(li);
                }

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("ResumeAdd.aspx?Resume=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        public void dataGriviewBD()
        {
            string UserName = txtUserName.Text.Trim().ToString();
            string Education = DlEducation.SelectedItem.Text;
            string Political = DlPolitical.SelectedItem.Text;
            string Professional = txtProfessional.Text;
        
            if (Education == "选择学历")
            {
                Education = "";
            }
            if (Political == "选择政治面貌")
            {
                Political = "";
            }

            GridView1.DataSource = bus.SelectResume("Resume_Select", UserName, Education, Political, Professional).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("DelayRewardManage.aspx");
        }
    }
}