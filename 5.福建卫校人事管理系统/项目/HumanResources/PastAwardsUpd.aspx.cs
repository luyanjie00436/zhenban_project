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
    public partial class PastAwardsUpd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int PastAwardsId;
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
            
                if (Request.QueryString["PastAwards"] != null)
                {
                    try
                    {
                        PastAwardsId = Convert.ToInt32(Request.QueryString["PastAwards"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                   
                    DataSet ds = bus.SelectByPastAwardsId("PastAwards_SelectByPastAwardsId", PastAwardsId);
                    txtAwardProjectName.Text = ds.Tables[0].Rows[0]["AwardProjectName"].ToString();
                    txtAwardDate.Text = ds.Tables[0].Rows[0]["AwardDate"].ToString();
                    txtGrantUnit.Text = ds.Tables[0].Rows[0]["GrantUnit"].ToString();
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

            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value); ;
            PastAwardsId = Convert.ToInt32(Request.QueryString["PastAwards"]);
            string AwardProjectName = txtAwardProjectName.Text.Trim();
            string AwardDate = txtAwardDate.Text.Trim();
            string GrantUnit = txtGrantUnit.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            string TransferStatus = RlTransferStatus.SelectedItem.Value;


          
            if (bus.PastAwardsUpdate("PastAwards_Update", PastAwardsId, UserCardId, AwardProjectName, AwardDate, GrantUnit, Remarks, TransferStatus))
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