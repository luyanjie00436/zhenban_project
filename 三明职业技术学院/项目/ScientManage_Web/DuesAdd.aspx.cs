using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class DuesAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int DuesId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DuesAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DLAssciationName.Items.Add("==请选择==");
                DLAssciationName.Items[0].Value = "0";
                DataTable ds = bus.SelectByUserCardId("Dues_SelectByUserCardId",UserCardId).Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["AssociationName"].ToString());
                    DLAssciationName.Items.Add(li);
                }

                if (Request.QueryString["DuesId"] != null)
                {
                    try
                    {
                        DuesId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["DuesId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByDuesId("Dues_SelectByDuesId", DuesId);
                    DLAssciationName.Text = dt.Tables[0].Rows[0]["AssociationName"].ToString();
                    txtCost.Text = dt.Tables[0].Rows[0]["Cost"].ToString();

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
            string AssciationName = DLAssciationName.Text;
            string Cost = txtCost.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择学术团体(学会)名称");
                return;
            }
            if (Cost == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入费用");
                return;
            }
            if (bus.DuesInsert("Dues_Insert", AssciationName, Cost, UserCardId))
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
            string AssciationName = DLAssciationName.Text.Trim();
            string Cost = txtCost.Text;

            if (AssciationName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择学术团体(学会)名称");
                return;
            }
            if (Cost == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入费用");
                return;
            }
            DuesId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["DuesId"], "asdfasdf"));
            if (bus.DuesUpdate("Dues_Update", DuesId, AssciationName, Cost))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyDuesManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}