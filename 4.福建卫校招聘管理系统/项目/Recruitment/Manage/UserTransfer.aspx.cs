using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Manage
{
    public partial class UserTransfer : System.Web.UI.Page
    {
        Recruitment_Data.MGetData bus = new Recruitment_Data.MGetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        int JobMangeId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobMangeId"] != null)
                {
                    try
                    {
                        UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    try
                    {
                        JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    chaxun();
                }
            }
        }
        public void chaxun()
        {
            string Sort = DSort.SelectedValue;
            string Number = txtNumber.Text.Trim();
            string Name = txtName.Text.Trim();
            string IdCard = txtIdCard.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Institutions = txtInstitutions.Text.Trim();
            string Profession = txtProfessionName.Text.Trim();
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
            DataSet dy = bus.Job_Selects("Job_Selects", Number, Name, IdCard, Phone, Email, Institutions, Profession, Sort,JobMangeId);
            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();

        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            chaxun();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            string i = e.CommandArgument.ToString();
            Response.Redirect("JobApproval.aspx?JobId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        //删除
    }
}