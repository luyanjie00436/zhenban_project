using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class WorkExperienceAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int WorkExperienceId;
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
                DataSet Department = bus.Select("Department_Select");
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }
                DataSet Role = bus.Select("Role_Select");
                foreach (DataRow dr in Role.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RoleName"].ToString(), dr["RoleId"].ToString());
                    DlRoleId.Items.Add(li);
                }

                if (Request.QueryString["WorkExperience"] != null)
                {
                    try
                    {
                        WorkExperienceId = Convert.ToInt32(Request.QueryString["WorkExperience"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    DataSet ds = bus.SelectByWorkExperienceId("WorkExperience_SelectByWorkExperienceId", WorkExperienceId);
                    txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                    txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate"].ToString();
                    DlDepartmentId.SelectedValue = ds.Tables[0].Rows[0]["DepartmentId"].ToString();
                    DlRoleId.SelectedValue= ds.Tables[0].Rows[0]["RoleId"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    RlIsNow.SelectedValue= ds.Tables[0].Rows[0]["IsNow"].ToString();


                }
                else
                {                   
                    Button2.Visible = false;                  
                }


            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);
            int RoleId = Convert.ToInt32(DlRoleId.SelectedValue);
            string Remarks = txtRemarks.Text.Trim();
            string IsNow = RlIsNow.SelectedValue;    


            if (bus.WorkExperienceInsert("WorkExperience_Insert", UserCardId, StartDate, EndDate, DepartmentId, RoleId, Remarks, IsNow))
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");

            }
        }
      

        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            WorkExperienceId = Convert.ToInt32(Request.QueryString["WorkExperience"]);
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);
            int RoleId = Convert.ToInt32(DlRoleId.SelectedValue);
            string Remarks = txtRemarks.Text.Trim();
            string IsNow = RlIsNow.SelectedValue;

            if (bus.WorkExperienceUpdateNoTransferStatus("WorkExperience_Update_NoTransferStatus", WorkExperienceId,  StartDate, EndDate, DepartmentId, RoleId, Remarks, IsNow))
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");

            }
        }
    }
}