using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class AssciationAdd : System.Web.UI.Page
    {

        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                    txtAssciationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                  
                    txtExplain.Text = dt.Tables[0].Rows[0]["Explain"].ToString();
                   
                }
                else
                {
                    Button2.Visible = false;
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string AssciationName = txtAssciationName.Text.Trim();
          
            string Explain = txtExplain.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术团体(学会)名称");
                return;
            }
            if (bus.AssciationInsert("Association_Insert",AssciationName,Explain, UserCardId))
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
            string Explain = txtExplain.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入学术团体(学会)名称");
                return;
            }
            AssciationId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["AssciationId"], "asdfasdf"));
            if (bus.AssciationUpdate("Association_Update", AssciationId, AssciationName,Explain))
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