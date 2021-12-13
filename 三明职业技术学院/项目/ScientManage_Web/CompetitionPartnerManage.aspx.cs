using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class CompetitionPartnerManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Panel2.Visible = false;
                Button2.Visible = false;
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/CompetitionPartnerManage.aspx") == 0)
                //{
                //      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                //}


                DataTable dt = bus.SelectCompetitionByUserCardId("Competition_SelectByPartnerUserNo", UserCardId).Tables[0];
                DlCompetition.Items.Clear();
                DlCompetition.Items.Add("==请选择==");
                DlCompetition.Items[0].Value = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["CompetitionName"].ToString(), dr["CompetitionId"].ToString());
                    DlCompetition.Items.Add(li);
                }
                dt.Dispose();
            }

        }
        public void dataGriviewBD(int CompetitionId)
        {

            GridView1.DataSource = bus.SelectByCompetitionId("CompetitionPartner_SelectByCompetitionId", CompetitionId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double PartnerValue;
            if (DlCompetition.SelectedIndex.Equals(0))
            {
                UpdatePanelAlert("请选择要添加的学术活动名称！");
                return;
            }
            int CompetitionId = Convert.ToInt32(DlCompetition.SelectedValue);
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Text.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
            }
            catch (Exception)
            {

                UpdatePanelAlert("分值请输入正数！");
                return;
            }
            if (PartnerValue <= 0)
            {
                UpdatePanelAlert("分值请输入正数！");
                return;
            }
            if (bus.UserSum("UserInfo_SelectUserSum", UserCardId, UserName) == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "合作者信息错误！");
                return;
            }
            if (bus.CompetitionPartnerInsert("CompetitionPartner_Insert", CompetitionId, UserCardId, PartnerRank, PartnerValue))
            {

                UpdatePanelAlert("添加成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                dataGriviewBD(CompetitionId);
            }
            else
            {
                UpdatePanelAlert("添加失败！");
            }



        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double PartnerValue;
            int CompetitionId = Convert.ToInt32(DlCompetition.SelectedValue);
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Text.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
            }
            catch (Exception)
            {

                UpdatePanelAlert("分值请输入正数！");
                return;
            }
            if (PartnerValue <= 0)
            {
                UpdatePanelAlert("分值请输入正数！");
                return;
            }
            if (bus.UserSum("UserInfo_SelectUserSum", UserCardId, UserName) == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "合作者信息错误！");
                return;
            }
            int CompetitionPartnerId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["CompetitionPartnerId"].Value));
            if (bus.CompetitionPartnerUpdate("CompetitionPartner_Update", CompetitionPartnerId, UserCardId, PartnerRank, PartnerValue))
            {

                UpdatePanelAlert("修改成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD(CompetitionId);
            }
            else
            {
                UpdatePanelAlert("修改失败！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD(CompetitionId);
            }



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Partner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            dataGriviewBD(Convert.ToInt32(DlCompetition.SelectedValue));
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
            dataGriviewBD(Convert.ToInt32(DlCompetition.SelectedValue));
        }
        //删除
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            int CompetitionId = Convert.ToInt32(DlCompetition.SelectedValue);
            if (bus.CompetitionPartnerDelete("CompetitionPartner_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                UpdatePanelAlert("删除成功！");
                dataGriviewBD(CompetitionId);
            }
        }
        //编辑
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = true;
            DataTable dt = bus.SelectByCompetitionPartnerId("CompetitionPartner_SelectByCompetitionPartnerId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            Response.Cookies["CompetitionPartnerId"].Value = e.CommandArgument.ToString();
            txtUserCardId.Text = dt.Rows[0]["PartnerUserCardId"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtPartnerValue.Text = dt.Rows[0]["PartnerValue"].ToString();
            DlPartnerRank.SelectedValue = dt.Rows[0]["PartnerRank"].ToString();

        }

        protected void UpdatePanelAlert(string str_Message)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + str_Message + "')", true);
        }
    }
}