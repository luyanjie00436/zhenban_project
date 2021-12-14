using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ExpertReviewMembersAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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
                  
                if (Request.QueryString["ExpertReviewId"] != null)
                {
                    ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    return;
                }
                DataTable dt = bus.Select("ExpertResources_SelectBy").Tables[0];

                DlName.Items.Clear();
                DlName.Items.Add("请选择");
                DlName.Items[0].Value = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ExpertName"].ToString() + '-' + dr["ExpertNumber"].ToString(), dr["ExpertNumber"].ToString());
                    DlName.Items.Add(li);
                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DlName.SelectedValue=="0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择人员");return;
            }
            string ExpertNumber = DlName.SelectedValue;
            ExpertReviewId = Convert.ToInt32(Request.QueryString["ExpertReviewId"]);

            if (bus.ExpertReviewMembersInsert("ExpertReviewMembers_Insert", ExpertReviewId, ExpertNumber))
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
                }
                else
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加失败，检查是否添加重复人员");
                }
         
           

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
     
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DlName.SelectedValue != "0")
            {
                //txtExpertReviewName.Text = DlName.SelectedValue;
                //int a = DlName.SelectedItem.Text.LastIndexOf("-");
                //txtExpertName.Text = DlName.SelectedItem.Text.Substring(a + 1);
            }
        }
    }
}