using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class TeachToTeachingAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int TeachToTeachingId;
        protected static string type;
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/T_TeachingAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId", UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }
                if (Request.QueryString["TeachToTeachingId"] != null)
                {
                    try
                    {
                        TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByTeachToTeachingId("TeachToTeaching_SelectByTeachToTeachingId", TeachToTeachingId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtQuantity.Text = dt.Tables[0].Rows[0]["Quantity"].ToString();
                    txtTotalScore.Text = dt.Tables[0].Rows[0]["TotalScore"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Button2.Visible = false;
                }
            }
        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string Quantity = txtQuantity.Text.Trim();
            string TotalScore = txtTotalScore.Text;
            string Remarks = txtRemarks.Text;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (Quantity == "")
            {
                AlertMsgAndNoFlush("请输入转分课程数");
                return;
            }
            if (TotalScore == "")
            {
                AlertMsgAndNoFlush("请输入转分总分");
                return;
            }
            if (bus.TeachToTeachingInsert("TeachToTeaching_Insert", UserCardId, DepartmentId, Quantity, TotalScore, Remarks))
            {
                AlertMsgAndNoFlush("申请成功");
            }
            else
            {
                AlertMsgAndNoFlush("申请失败！可能是没有您的审批流程");
            }
        }
        public void AlertMsgAndNoFlush(string message)
        {
            // ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Quantity = txtQuantity.Text.Trim();
            string TotalScore = txtTotalScore.Text;
            string ApplyYearName = txtApplyYear.Text;
            string Remarks = txtRemarks.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);
            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (Quantity == "")
            {
                AlertMsgAndNoFlush("请输入转分课程数");
                return;
            }
            if (TotalScore == "")
            {
                AlertMsgAndNoFlush("请输入转分总分");
                return;
            }
            TeachToTeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachToTeachingId"], "asdfasdf"));
            if (bus.TeachToTeachingUpdate("TeachToTeaching_Update", TeachToTeachingId, DepartmentId, Quantity, TotalScore, Remarks))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyTeachToTeachingManage.aspx'}</script>");
            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}