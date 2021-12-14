using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ExpertReviewAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int ExpertReviewId;
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
               
                             
                DataTable dt = bus.Select("ExpertResources_SelectBy").Tables[0];
                DlLeaderNumber.Items.Clear();
                DlLeaderNumber.Items.Add("请选择");
                DlLeaderNumber.Items[0].Value = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ExpertName"].ToString() + '-' + dr["ExpertNumber"].ToString(), dr["ExpertNumber"].ToString());
                    DlLeaderNumber.Items.Add(li);
                }


                if (Request.QueryString["ExpertReviewId"] != null)
                {
                    try
                    {
                        ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                   
                    DataSet ds = bus.SelectByExpertReviewId("ExpertReview_SelectByExpertReviewId", ExpertReviewId);
                    txtExpertReviewName.Text = ds.Tables[0].Rows[0]["ExpertReviewName"].ToString();
                    if (ds.Tables[0].Rows[0]["LeaderNumber"].ToString().Length>0)
                    {
                        DlLeaderNumber.SelectedValue = ds.Tables[0].Rows[0]["LeaderNumber"].ToString();
                    }
                    Button1.Visible = false;
                }
                else
                {
                    Button2.Visible = false;
                }
                }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ExpertReviewName = txtExpertReviewName.Text.Trim().ToString();
            string LeaderNumber = DlLeaderNumber.SelectedValue;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
           
            if (ExpertReviewName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写名称");

                return;
            }
            if (LeaderNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择组长账号");

                return;
            }
            if (bus.ExpertReviewInsert("ExpertReview_Insert", ExpertReviewName, LeaderNumber, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");                
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ExpertReviewName = txtExpertReviewName.Text.Trim().ToString();
            string LeaderNumber = DlLeaderNumber.Text.Trim().ToString();
            ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (ExpertReviewName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写名称");
                return;
            }
            if (LeaderNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写组长账号");
                return;
            }

            if (bus.ExpertReviewUpdate("ExpertReview_Update", ExpertReviewId,ExpertReviewName, LeaderNumber, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DlLeaderNumber.SelectedValue != "0")
            {
                DlLeaderNumber.Text = DlLeaderNumber.SelectedValue;
                //int a = DlLeaderNumber.SelectedItem.Text.LastIndexOf("-");
                //DlLeaderNumber.Text = DlLeaderNumber.SelectedItem.Text.Substring(a + 1);
            }
        }

    }
}