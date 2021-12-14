using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ApplyTitleManagePersonal : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//remain

                }
                catch (Exception)
                {

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ApplyTitleManagePersonal.aspx") == 0)//remain
                {
                    Response.Redirect("Login.aspx");
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        protected void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//remain

            DataTable dt = bus.SelectByUserCardId("ApplyTitle_SelectByApplyTitleUserCardId", UserCardId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label LStatus = (Label)GridView1.Rows[i].FindControl("LStatus");  //获取gridview中的编号控件
                    if (LStatus.Text != "同意")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        LinkButton lb2 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton9");
                        LinkButton lb3 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton1");
                        lb.Visible = true;
                        lb2.Visible = true;
                        lb3.Visible = true;
                    }
                    else
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        LinkButton lb2 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton9");
                        LinkButton lb3 = (LinkButton)GridView1.Rows[i].FindControl("LinkButton1");
                        lb.Visible = false;
                        lb2.Visible = false;
                        lb3.Visible = false;
                    }

                }
                catch
                {

                }
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ApplyTitleManagePersonal.aspx");
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

        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ApplyTitleDetailed.aspx?ApplyTitle=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }

        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            DataSet dt = bus.SelectByApplyTitleId("ApplyTitle_SelectByApplyTitleId", Convert.ToInt32(e.CommandArgument.ToString()));
            string TransferStatus = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
            if (TransferStatus == "未审批")
            {
                Response.Redirect("ApplyTitleAdd.aspx?ApplyTitle=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请假流程已经启动，禁止修改");
            }
        }

        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            if (bus.ApplyTitleDelete("ApplyTitle_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请流程已经启动，禁止删除");
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ApplyTitleAppendix.aspx?ApplyTitleId=" + e.CommandArgument.ToString());
        }
    }
}