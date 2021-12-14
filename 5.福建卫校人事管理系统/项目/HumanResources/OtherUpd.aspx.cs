using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class OtherUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
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
               
                if (Request.QueryString["UserInfo"] != null)
                {
                    try
                    {
                        UserCardId = Request.QueryString["UserInfo"];
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    DataSet ds = bus.UseOfficeViewSelects("UserInfo_SelectByUserCardId", UserCardId);
                    DlUserSource.SelectedValue = ds.Tables[0].Rows[0]["UserSource"].ToString();
                    txtSchoolDate.Text = ds.Tables[0].Rows[0]["SchoolDate"].ToString();
                    DlWorkLeave.SelectedValue = ds.Tables[0].Rows[0]["WorkLeave"].ToString();
                    RlPrepared.Text = ds.Tables[0].Rows[0]["Prepared"].ToString();
                    RlForeignStaff.Text = ds.Tables[0].Rows[0]["ForeignStaff"].ToString();
                }
                else
                {
                    Button2.Visible = false;
                }
            }
        }




        protected void Button2_Click(object sender, EventArgs e)
        {

           // string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            UserCardId = Request.QueryString["UserInfo"];
            string UserSource = DlUserSource.SelectedValue;
            string SchoolDate = txtSchoolDate.Text.Trim();
            string WorkLeave = DlWorkLeave.SelectedValue;
            string Prepared = RlPrepared.SelectedValue;
            string ForeignStaff = RlForeignStaff.SelectedValue;

         /*   if (UserSource == "")
            {
                Response.Write("<script>alert('请选择来源信息！')</script>");
                return;
            }
            if (SchoolDate == "")
            {
                Response.Write("<script>alert('请填写离校时间！')</script>");
                return;
            }
           
            if (WorkLeave == "")
            {
                Response.Write("<script>alert('请选择离校原因！')</script>");
                return;
            }
            if (Prepared == "")
            {
                Response.Write("<script>alert('请选择编制信息！')</script>");
                return;
            }
            if (ForeignStaff =="")
            {
                Response.Write("<script>alert('请选择是否外籍人员！')</script>");
            }
            */
            if (bus.OtherUpdate("Other_Update", UserCardId,UserSource, SchoolDate, WorkLeave, Prepared, ForeignStaff))
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