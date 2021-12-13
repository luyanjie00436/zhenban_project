using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class MyHarvestManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/MyHarvestManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("Harvest_SelectByPartnerUser", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label Status2 = (Label)GridView1.Rows[i].FindControl("LTransferStatus");  //获取gridview中的编号控件
                    if (Status2.Text == "同意")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        lb.Visible = false;
                        LinkButton lb2 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton9");
                        lb2.Visible = false;
                    }

                }
                catch
                {

                }
            }
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("HarvestDetailed.aspx?HarvestId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            DataSet dt = bus.SelectByHarvestId("Harvest_SelectByHarvestId", Convert.ToInt32(e.CommandArgument.ToString()));
            string TransferStatus = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
            if (TransferStatus != "同意")
            {
                Response.Redirect("HarvestAdd.aspx?HarvestId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批已通过，禁止修改");
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            if (bus.HarvestDelete("Harvest_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "审批已通过，禁止删除");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("MyHarvestManage.aspx");
        }
    }
}