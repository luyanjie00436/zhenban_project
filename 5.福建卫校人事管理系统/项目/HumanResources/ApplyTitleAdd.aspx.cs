using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ApplyTitleAdd : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ApplyTitleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//remain

                    LBApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }
            
              
                if (Request.QueryString["ApplyTitle"] != null)
                {
                    try
                    {
                        ApplyTitleId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyTitle"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    BtnAdd.Visible = false;
                    DataSet dt = bus.SelectByApplyTitleIdId("ApplyTitle_SelectByApplyTitleId", ApplyTitleId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtApplyReason.Text = dt.Tables[0].Rows[0]["ApplyReason"].ToString();
                   
                    DLDepartment.SelectedItem.Text = dt.Tables[0].Rows[0]["DepartmentName"].ToString();
                    DLDepartment.SelectedItem.Value = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    DLApplyTitle.SelectedItem.Text = dt.Tables[0].Rows[0]["Job"].ToString();
                    DLPost.SelectedItem.Text = dt.Tables[0].Rows[0]["Post"].ToString();
                    LBApplyDate.Text = dt.Tables[0].Rows[0]["ApplyDate"].ToString();
                    txtTitleSeries.Value = dt.Tables[0].Rows[0]["TitleSeries"].ToString();
                    txtMajor.Value = dt.Tables[0].Rows[0]["Major"].ToString();
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());

                }
                else
                {
                    BtnSave.Visible = false;
                }
               
            }
        }
        protected void huoqu(string UserCardId)
        {
            DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
            txtUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
            LStartWork.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
            LBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
             
            LGender.Text = ds.Tables[0].Rows[0]["性别"].ToString();
             

            LNation.Text = ds.Tables[0].Rows[0]["民族"].ToString();
            LPolitical.Text = ds.Tables[0].Rows[0]["政治面貌"].ToString();
            LEducation.Text = ds.Tables[0].Rows[0]["第一学历"].ToString();
            LDegree.Text = ds.Tables[0].Rows[0]["第一学位"].ToString();
           // LBApplyYear.Text = bus.GetUserMessage("ApplyPeriodManage_GetUserMessage", UserCardId).Tables[1].Rows[0][0].ToString() + "年度";
            DropDownListBD();
        }
        protected void DropDownListBD()
        {
            DataSet Department = bus.Select("Department_Select");
            foreach (DataRow dr in Department.Tables[0].Rows)
            {
                ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                DLDepartment.Items.Add(li);
            }
           
            DLApplyTitle.DataSource = bus.ApplyTitle("Job_Select").Tables[0].DefaultView;
            DLApplyTitle.DataTextField = "JobName";
            DLApplyTitle.DataBind();

            DLPost.DataSource = bus.Post("Post_Select").Tables[0].DefaultView;
            DLPost.DataTextField = "PostName";
            DLPost.DataBind();



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Reason = txtApplyReason.Text.Trim().ToString();
            int DepartmentId = Convert.ToInt32(DLDepartment.SelectedItem.Value);
            string ApplyTitle = DLApplyTitle.SelectedItem.Text;
            string Post = DLPost.SelectedItem.Text;
            string TitleSeries = txtTitleSeries.Value;
            string Major = txtMajor.Value;
            string ApplyYear = LBApplyYear.Text;
            if (DLDepartment.Text == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择职称所属部门");
                return;
            }
            if (DLApplyTitle.Text == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择职称");
                return;
            }
            if (DLPost.Text == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择职级");
                return;
            }
            if (txtTitleSeries.Value.Trim() == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入职称系列");
                return;
            }
            if (txtMajor.Value.Trim() == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入专业");
                return;
            }
          
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申请理由");
                return;
            }
            if (bus.ApplyTitleInsert("ApplyTitle_Insert", UserCardId, Reason,  DepartmentId, ApplyTitle, Post, TitleSeries, Major))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！可能是您已申请过职称");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Reason = txtApplyReason.Text.Trim().ToString();
            int DepartmentId = Convert.ToInt32(DLDepartment.SelectedItem.Value);
            string ApplyTitle = DLApplyTitle.SelectedItem.Text;
            string Post = DLPost.SelectedItem.Text;
            string TitleSeries = txtTitleSeries.Value;
            string Major = txtMajor.Value;

            if (txtTitleSeries.Value.Trim() == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入职称系列");
                return;
            }
            if (txtMajor.Value.Trim() == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入专业");
                return;
            }
           
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入申请理由");
                return;
            }
            ApplyTitleId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyTitle"], "asdfasdf"));
            if (bus.ApplyTitleUpdate("ApplyTitle_Update", ApplyTitleId, Reason, DepartmentId, ApplyTitle, Post, TitleSeries, Major))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;

            DataTable dt = bus.SelectByUserName("UserInfo_SelectByUserName", UserName).Tables[0];
            DlName.Items.Clear();
            DlName.Items.Add("请选择");
            DlName.Items[0].Value = "0";
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["姓名"].ToString(), dr["工号"].ToString());
                DlName.Items.Add(li);
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlName.SelectedValue != "0")
            {
                txtUserCardId.Text = DlName.SelectedValue;
              
                txtUserName.Text = DlName.SelectedItem.Text;
                huoqu(DlName.SelectedValue);
            }
        }
    }
}