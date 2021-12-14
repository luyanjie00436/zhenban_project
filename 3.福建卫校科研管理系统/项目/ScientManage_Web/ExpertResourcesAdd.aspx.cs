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
    public partial class ExpertResourcesAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        int ExpertResourcesId;
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
                if (RSchoolOutside.SelectedValue == "校外")
                {
                    qiyong();
                }
                if (Request.QueryString["ExpertResourcesId"] != null)
                {
                    try
                    {
                        ExpertResourcesId = Convert.ToInt32(Request.QueryString["ExpertResourcesId"]);
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }

                    DataSet ds = bus.SelectByExpertResourcesId("ExpertResources_SelectByExpertResourcesId", ExpertResourcesId);
                    txtExpertNumber.Text = ds.Tables[0].Rows[0]["ExpertNumber"].ToString();
                    txtExpertName.Text = ds.Tables[0].Rows[0]["ExpertName"].ToString();
                    txtExpertPassword.Text = ds.Tables[0].Rows[0]["ExpertPassword"].ToString();
                    RSchoolOutside.SelectedValue = ds.Tables[0].Rows[0]["SchoolOutside"].ToString();
                    Button1.Visible = false;
                }
                else
                {
                    Button2.Visible = false;
                }
            }
                if (RSchoolOutside.SelectedValue != null)
            {
                if (RSchoolOutside.SelectedValue == "校内")
                {
                    Button3.Style.Add("visibility", "visible");
                    xuanze.Style.Add("display","block");
                    xuanze2.Style.Add("display", "none");

                }
                else
                {
                    Button3.Style.Add("visibility", "hidden");
                    xuanze.Style.Add("display", "none");
                    xuanze2.Style.Add("display", "block");
                }
            }
            
        }
        public void qiyong()
        {
            RSchoolOutside.Enabled = false;
            txtExpertNumber.Enabled = false;
            Button1.Visible= false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RSchoolOutside.SelectedValue == "校内")
            {
                string ExpertName = txtExpertName.Text.Trim().ToString();
                string ExpertNumber = txtExpertNumber.Text.Trim().ToString();
                string ExpertPassword = "";
                string SchoolOutside = RSchoolOutside.SelectedValue;
                UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

                if (ExpertName == "")
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "请填写姓名");
                    return;
                }
                if (ExpertNumber == "")
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "请填写账号");
                    return;
                }
                ExpertPassword = txtExpertPassword.Text.Trim();

                if (bus.ExpertResourcesInsert("ExpertResources_Insert", ExpertNumber, ExpertName,  ExpertPassword,SchoolOutside, UserCardId))
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                }
                else
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加失败,检查账号是否已存在专家权限");
                }
            }
            else if (RSchoolOutside.SelectedValue == "校外")
            {
                string ExpertName = txtExpertName.Text.Trim().ToString();
                string ExpertNumber = txtExpertNumber.Text.Trim().ToString();
                string ExpertPassword = txtExpertPassword.Text.Trim().ToString();
                string SchoolOutside = RSchoolOutside.SelectedValue;
                UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);


                if (ExpertName == "")
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "请填写姓名");
                    return;
                }
                if (ExpertNumber == "")
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "请填写账号");
                    return;
                }
                if (ExpertPassword == "")
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "请填写密码");
                    return;
                }
                 ExpertPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtExpertPassword.Text.Trim(), "MD5");

                if (bus.ExpertResourcesInsert("ExpertResources_Insert", ExpertNumber, ExpertName,  ExpertPassword, SchoolOutside, UserCardId))
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                }
                else
                {
                    AlertMsgAndNoFlush(UpdatePanel1, "添加失败,检查账号是否已存在");
                }
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string ExpertName = txtExpertName.Text.Trim().ToString();
            string ExpertPassword = txtExpertPassword.Text.Trim().ToString();
            ExpertResourcesId = Convert.ToInt32(Request.QueryString["ExpertResourcesId"]);
            string ExpertNumber = txtExpertNumber.Text.Trim().ToString();
        
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (ExpertName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写姓名");
                return;
            }
            if (ExpertPassword == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写密码");
                return;
            }
            ExpertPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtExpertPassword.Text.Trim(), "MD5");

            if (bus.ExpertResourcesUpdate("ExpertResources_Update", ExpertResourcesId, ExpertName, ExpertPassword, ExpertNumber, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtExpertName.Text;

            DataTable dt = bus.SelectByUserName("UserInfo_SelectByUserName", UserName).Tables[0];
            DlName.Items.Clear();
            DlName.Items.Add("请选择");
            DlName.Items[0].Value = "0";
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["行政隶属"].ToString() + "-" + dr["姓名"].ToString(), dr["工号"].ToString());
                DlName.Items.Add(li);
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlName.SelectedValue != "0")
            {
                txtExpertNumber.Text = DlName.SelectedValue;
                int a = DlName.SelectedItem.Text.LastIndexOf("-");
                txtExpertName.Text = DlName.SelectedItem.Text.Substring(a + 1);
            }
        }
    }
}