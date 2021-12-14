using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class QuitAdd : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int QuitId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/QuitAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

                #region bd
              
                #endregion

                if (Request.QueryString["Quit"] != null)
                {
                    try
                    {
                        QuitId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Quit"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByQuitId("Quit_SelectByQuitId", QuitId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    DlStatus.SelectedItem.Text = dt.Tables[0].Rows[0]["Status"].ToString();
                    txtQuitDate.Value = dt.Tables[0].Rows[0]["QuitDate"].ToString();
                    txtQuitReason.Text = dt.Tables[0].Rows[0]["QuitReason"].ToString();
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());

                }
                else
                {
                    txtQuitDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
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
            string Status = DlStatus.SelectedItem.ToString();
            string Date = txtQuitDate.Value;
            string Reason = txtQuitReason.Text.Trim().ToString();
           
            if (Status == "请选择离职/退休")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择离职/退休");
                return;
            }
            if (Date == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入离职/退休时间");
                return;
            }
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入离职/退休理由");
                return;
            }
            if (bus.QuitInsert("Quit_Insert", UserCardId, Status, Date, Reason))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功！");
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
            string Status = DlStatus.SelectedItem.ToString();
            string Date = txtQuitDate.Value;
            string Reason = txtQuitReason.Text.Trim().ToString();
          
            if (Status == "请选择离职/退休")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择离职/退休");
                return;
            }
            if (Date == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入离职时间");
                return;
            }
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入离职理由");
                return;
            }
            QuitId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Quit"], "asdfasdf"));
            if (bus.QuitUpdate("Quit_Update", UserCardId, QuitId, Status, Date, Reason))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功！");
                Response.Redirect("QuitManage.aspx");
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