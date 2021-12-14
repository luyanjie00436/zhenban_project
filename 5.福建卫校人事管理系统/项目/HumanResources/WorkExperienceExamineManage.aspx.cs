using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class WorkExperienceExamineManage : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int WorkExperienceId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WorkExperienceExamineManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                //OfficeAdda.HRef = OfficeAdda.HRef + "?UserCardId=" + Request.QueryString["UserCardId"] + "&keepThis=true&TB_iframe=true&height=400&width=500";
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
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
            Response.Cookies["selectDepartmentId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("WorkExperienceExamineManage.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)//遍历
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("cbMore");
                if (CheckBox1.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("[WorkExperienceExamine_Select]", UserCardId).Tables[0];
            GridView1.DataBind();
        }     
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            WorkExperienceId = Convert.ToInt32(e.CommandArgument.ToString());
            if (shenpi(WorkExperienceId, "有效"))
            {
                Response.Write("<script>alert('审批成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('审批失败！')</script>");
            }
        }

        private bool shenpi(int WorkExperienceId, string TransferStatus)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            return bus.WorkExperienceUpdateTransferStatus("WorkExperience_UpdateTransferStatus", UserCardId, WorkExperienceId, TransferStatus);
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            WorkExperienceId = Convert.ToInt32(e.CommandArgument.ToString());
            if (shenpi(WorkExperienceId, "无效"))
            {
                Response.Write("<script>alert('审批成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('审批失败！')</script>");
            }
        }
        private void duoshenpi(string TransferStatus) {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    CheckBox _chk = (CheckBox)GridView1.Rows[i].FindControl("cbMore");
                    if (_chk.Checked)
                    {
                        Label LId = (Label)GridView1.Rows[i].FindControl("LOfficeId");
                        WorkExperienceId = Convert.ToInt32(LId.Text);
                        if (!shenpi(WorkExperienceId, TransferStatus))
                        {
                            Response.Write("<script>alert('部分信息审批失败！')</script>");
                            return;
                        }
                        
                    }
                }
                catch
                {

                }
            }
            Response.Write("<script>alert('审批成功！')</script>");
            dataGriviewBD();
            return;

        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {
            duoshenpi("有效");
            CheckBox1.Checked = false;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            duoshenpi("无效");
            CheckBox1.Checked = false;
        }

    }
}