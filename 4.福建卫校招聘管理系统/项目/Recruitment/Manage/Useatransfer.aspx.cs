using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Manage
{
    public partial class Useatransfer : System.Web.UI.Page
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
            DataSet dy = bus.Job_Selects("JobS_Selects", Number, Name, IdCard, Phone, Email, Institutions, Profession, Sort, JobMangeId);
            dataOfYear.DataSource = dy;
            dataOfYear.DataBind();

        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            chaxun();
        }
      
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
      
          
        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        //专业不符合
        protected void dataOfYear_DeleteCommand(object source, DataListCommandEventArgs e)
        {

          
        }
      
        protected void dataOfYear_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string KjName = e.CommandName;
            string TransferStatus;
            int JobId = Convert.ToInt32(e.CommandArgument.ToString());
            //全部合格
            if (KjName=="qbhg")
            {
                TransferStatus = "全部合格";             
                if (bus.Job_Update("Job_Update", JobId, TransferStatus))
                {
                    AlertMsgAndNoFlush("审批成功！");
                }
                else
                {
                    AlertMsgAndNoFlush("审批失败！");
                }
            }
            //条件合格，照片不合格
            else if (KjName == "zpbhg")
            {
               TransferStatus = "条件合格照片不合格";
                if (bus.Job_Update("Job_Update", JobId, TransferStatus))
                {
                    AlertMsgAndNoFlush("审批成功！");
                }
                else
                {
                    AlertMsgAndNoFlush("审批失败！");
                }
            }  //专业不符合
            else if(KjName == "zybfh")
            {
              TransferStatus = "专业不符合";
              
                if (bus.Job_Update("Job_Update", JobId, TransferStatus))
                {
                    AlertMsgAndNoFlush("审批成功！");
                }
                else
                {
                    AlertMsgAndNoFlush("审批失败！");
                }
            }  //资料不全，退回补充
            else if (KjName == "zlbqthbc")
            {
                TextBox txt1 = e.Item.FindControl("TextBox2") as TextBox;
                string Content1 = txt1.Text;
              TransferStatus = "资料补全退回补全";
             
                if (bus.Job_Update2("Job_Update2", JobId, TransferStatus, Content1))
                {
                    AlertMsgAndNoFlush("审批成功！");
                }
                else
                {
                    AlertMsgAndNoFlush("审批失败！");
                }
            }
            //条件不符合
            else if (KjName == "tjbfh")
            {
                TextBox txt1 = e.Item.FindControl("TextBox1") as TextBox;
                string Content1 = txt1.Text;
             TransferStatus = "条件不符合";
                if (bus.Job_Update2("Job_Update2", JobId, TransferStatus, Content1))
                {
                    AlertMsgAndNoFlush("审批成功！");
                }
                else
                {
                    AlertMsgAndNoFlush("审批失败！");
                }
            }
            chaxun();


        }
        //资料不全，退回补充
        protected void dataOfYear_CancelCommand(object source, DataListCommandEventArgs e)
        {
          
        }
        //条件合格，照片不合格
        protected void dataOfYear_EditCommand(object source, DataListCommandEventArgs e)
        {

           
        }
     
    }
}