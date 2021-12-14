using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class LeaveAdd : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int LeaveId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

                    txtStartDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LeaveAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
             
                if (Request.QueryString["Leave"] != null)
                {
                    try
                    {
                        LeaveId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Leave"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    Button1.Visible = false;
                    DataSet dt = bus.SelectByLeaveId("Leave_SelectByLeaveId", LeaveId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtLeaveReason.Text = dt.Tables[0].Rows[0]["LeaveReason"].ToString();
                    DateTime StartDate = Convert.ToDateTime(dt.Tables[0].Rows[0]["StartDate"].ToString());
                    DateTime EndDate = Convert.ToDateTime(dt.Tables[0].Rows[0]["EndDate"].ToString());
                    txtStartDate.Value = StartDate.ToString("yyyy-MM-dd");
                    DlStartHH.SelectedItem.Text = StartDate.ToString("HH") + ":";
                    DlStartMM.SelectedItem.Text = StartDate.ToString("mm");
                    txtEndDate.Value = EndDate.ToString("yyyy-MM-dd");
                    DlEndHH.SelectedItem.Text = EndDate.ToString("HH") + ":";
                    DlEndMM.SelectedItem.Text = EndDate.ToString("mm");
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());

                }
                else
                {
                    Button2.Visible = false;
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
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Reason = txtLeaveReason.Text.Trim().ToString();
            string StartDate = txtStartDate.Value;
            string EndDate = txtEndDate.Value;
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假开始日期");
                return;
            }
            if (EndDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假结束日期");
                return;
            }
            if (check.Checked == true)
            {
                DlStartHH.SelectedItem.Text = "00:";
                DlStartMM.SelectedItem.Text = "00";
                DlEndHH.SelectedItem.Text = "00:";
                DlEndMM.SelectedItem.Text = "00";
            }
            string StartHH = DlStartHH.SelectedItem.Text;
            string StartMM = DlStartMM.SelectedItem.Text;
            string EndHH = DlEndHH.SelectedItem.Text;
            string EndMM = DlEndMM.SelectedItem.Text;
            string StartDateTime = StartDate + " " + StartHH + StartMM + ":00";
            string EndDateTime = EndDate + " " + EndHH + EndMM + ":00";
         
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假理由");
                return;
            }
            if (bus.LeaveInsert("Leave_Insert", UserCardId, Reason, StartDateTime, EndDateTime))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string Reason = txtLeaveReason.Text.Trim().ToString();
            string StartDate = txtStartDate.Value;
            string EndDate = txtEndDate.Value;
            if (StartDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假开始日期");
                return;
            }
            if (EndDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假结束日期");
                return;
            }
            if (check.Checked == true)
            {
                DlStartHH.SelectedItem.Text = "00:";
                DlStartMM.SelectedItem.Text = "00";
                DlEndHH.SelectedItem.Text = "00:";
                DlEndMM.SelectedItem.Text = "00";
            }
            string StartHH = DlStartHH.SelectedItem.Text;
            string StartMM = DlStartMM.SelectedItem.Text;
            string EndHH = DlEndHH.SelectedItem.Text;
            string EndMM = DlEndMM.SelectedItem.Text;
            string StartDateTime = StartDate + " " + StartHH + StartMM + ":00";
            string EndDateTime = EndDate + " " + EndHH + EndMM + ":00";
        
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入请假理由");
                return;
            }
            LeaveId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Leave"], "asdfasdf"));
            if (bus.LeaveUpdate("Leave_Update", UserCardId, LeaveId, Reason, StartDateTime, EndDateTime))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("LeaveManage.aspx");
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