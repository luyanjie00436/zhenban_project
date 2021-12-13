using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AssciationAdd : System.Web.UI.Page
    {

        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int AssciationId;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AssciationAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCompany.Items.Add("==请选择==");
                DLCompany.Items[0].Value = "0";
                DataTable ds = bus.Select("Company_Select").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["CompanyName"].ToString(), dr["CompanyName"].ToString());
                    DLCompany.Items.Add(li);
                }
                if (Request.QueryString["AssciationId"] != null)
                {
                    try
                    {
                        AssciationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByAssciationId("Association_SelectByAssociationId", AssciationId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    txtAssciationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                    DLCompany.SelectedValue = dt.Tables[0].Rows[0]["Company"].ToString();
                    txtCapital.Text = dt.Tables[0].Rows[0]["Capital"].ToString();
                    txtExplain.Text = dt.Tables[0].Rows[0]["Explain"].ToString();
                   
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
            string AssciationName = txtAssciationName.Text.Trim();
            string Company = DLCompany.SelectedValue;
            string Capital = txtCapital.Text;
            string Explain = txtExplain.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术团体(学会)名称");
                return;
            }

            if (Company == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择申请单位");
                return;
            }
            try 
        	{	        
        	Convert.ToDouble(Capital);
        	}
        	catch (Exception)
        	{
        		
        		AlertMsgAndNoFlush(UpdatePanel1, "经费请输入数字");
                return;
        	}

            if (bus.AssciationInsert("Association_Insert",AssciationName,Company,Convert.ToDouble(Capital),Explain, UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！可能是没有审批流程");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string AssciationName = txtAssciationName.Text.Trim();
            string Company = DLCompany.SelectedValue;
            string Capital = txtCapital.Text;
            string Explain = txtExplain.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术团体(学会)名称");
                return;
            }

            if (Company == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择申请单位");
                return;
            }
            try
            {
                Convert.ToDouble(Capital);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "经费请输入数字");
                return;
            }
            AssciationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
            if (bus.AssciationUpdate("Association_Update", AssciationId, AssciationName,Company,Convert.ToDouble(Capital),Explain))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyAssciationManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}