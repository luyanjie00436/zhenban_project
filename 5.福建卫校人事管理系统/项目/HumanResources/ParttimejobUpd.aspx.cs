using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class ParttimejobUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int ParttimejobId;
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

                if (Request.QueryString["Parttimejob"] != null)
                {
                    try
                    {
                        ParttimejobId = Convert.ToInt32(Request.QueryString["Parttimejob"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    DataSet ds = bus.SelectByParttimejobId("Parttimejob_SelectByParttimejobId", ParttimejobId);
                    txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                    txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate"].ToString();
                    txtDepartmentName.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                    txtRoleName.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    txtUnitName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    try
                    {
                        RlTransferStatus.SelectedValue = ds.Tables[0].Rows[0]["TransferStatus"].ToString();
                    }
                    catch
                    {


                    }

                }
                else
                {
                    Button2.Visible = false;
                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            ParttimejobId = Convert.ToInt32(Request.QueryString["Parttimejob"]);
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            string DepartmentName = txtDepartmentName.Text.Trim();
            string RoleName = txtRoleName.Text.Trim();
            string UnitName = txtUnitName.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedValue;
           

            if (bus.ParttimejobStayusUpdate("Parttimejob_Update", ParttimejobId,UserCardId, StartDate, EndDate, DepartmentName, RoleName, Remarks, UnitName, TransferStatus))
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