using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class StudyTrainUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int StudyTrainId;
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
            
                if (Request.QueryString["StudyTrain"] != null)
                {
                    try
                    {
                        StudyTrainId = Convert.ToInt32(Request.QueryString["StudyTrain"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                   
                    DataSet ds = bus.SelectByStudyTrainId("StudyTrain_SelectByStudyTrainId", StudyTrainId);
                    txtTrainProjectName.Text = ds.Tables[0].Rows[0]["TrainProjectName"].ToString();
                    txtTrainStartDate.Text = ds.Tables[0].Rows[0]["TrainStartDate"].ToString();
                    txtTrainEndDate.Text = ds.Tables[0].Rows[0]["TrainEndDate"].ToString();
                    txtTrainUnit.Text = ds.Tables[0].Rows[0]["TrainUnit"].ToString();
                    txtRemarks.Text= ds.Tables[0].Rows[0]["Remarks"].ToString();
                    try
                    {
                        RlTransferStatus.SelectedValue = ds.Tables[0].Rows[0]["TransferStatus"].ToString();
                    }
                    catch 
                    {

                       
                    }
                    tr_sczp.Visible = false;
                    tr_sfzg.Visible = false;

                }
                else
                {                   
                    Button2.Visible= false;
                    RlGL_Management.Visible = false;
                }

               
            }
        }
      

      
      
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value); 
            StudyTrainId = Convert.ToInt32(Request.QueryString["StudyTrain"]);
            string TrainProjectName = txtTrainProjectName.Text.Trim();
            string TrainStartDate = txtTrainStartDate.Text.Trim();
            string TrainEndDate = txtTrainEndDate.Text.Trim();
            string TrainUnit = txtTrainUnit.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedValue;

            if (bus.StudyTrainUpdate("StudyTrain_Update", StudyTrainId, UserCardId, TrainProjectName, TrainStartDate, TrainEndDate, TrainUnit, Remarks, TransferStatus))
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