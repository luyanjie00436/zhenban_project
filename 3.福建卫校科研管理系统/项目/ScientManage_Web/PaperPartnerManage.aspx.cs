using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class PaperPartnerManage : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/PaperPartnerManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }


                DataTable dt = bus.SelectPaperByUserCardId("Paper_SelectByMyUserCardId", UserCardId).Tables[0];
                DlPaper.Items.Clear();
                DlPaper.Items.Add("==请选择==");
                DlPaper.Items[0].Value = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["PaperName"].ToString(), dr["PaperId"].ToString());
                    DlPaper.Items.Add(li);
                }
                dt.Dispose();
            }

        }
        public void dataGriviewBD(int PaperId)
        {

            GridView1.DataSource = bus.SelectByPaperId("PaperPartner_SelectByPaperId", PaperId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double PartnerValue;
            if (DlPaper.SelectedIndex.Equals(0))
            {
                UpdatePanelAlert("请选择要添加的论文成果！");
                return;
            }
            int PaperId = Convert.ToInt32(DlPaper.SelectedValue);
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Value.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (txtPartnerRank.Value == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){ UpdatePanelAlert("本人排名应为正数");return;}
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
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
            if (bus.PaperPartnerInsert("PaperPartner_Insert", PaperId, UserCardId, PartnerRank, PartnerValue))
            {

                UpdatePanelAlert("添加成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Value = "";
                dataGriviewBD(PaperId);
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
            int PaperId = Convert.ToInt32(DlPaper.SelectedValue);
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Value.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (txtPartnerRank.Value == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){ UpdatePanelAlert("本人排名应为正数");return;}
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
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
            int PaperPartnerId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["PaperPartnerId"].Value));
            if (bus.PaperPartnerUpdate("PaperPartner_Update", PaperPartnerId, UserCardId, PartnerRank, PartnerValue))
            {

                UpdatePanelAlert("修改成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Value = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD(PaperId);
            }



        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;

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
                txtUserCardId.Text = DlName.SelectedValue;
                int a = DlName.SelectedItem.Text.LastIndexOf("-");
                txtUserName.Text = DlName.SelectedItem.Text.Substring(a + 1);
            }
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Partner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            dataGriviewBD(Convert.ToInt32(DlPaper.SelectedValue));
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
            dataGriviewBD(Convert.ToInt32(DlPaper.SelectedValue));
        }
        //删除
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            int PaperId = Convert.ToInt32(DlPaper.SelectedValue);
            if (bus.PaperPartnerDelete("PaperPartner_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                UpdatePanelAlert("删除成功！");
                dataGriviewBD(PaperId);
            }
        }
        //编辑
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            Button1.Visible = false;
            Button2.Visible = true;
            DataTable dt = bus.SelectByPaperPartnerId("PaperPartner_SelectByPaperPartnerId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            Response.Cookies["PaperPartnerId"].Value = e.CommandArgument.ToString();
            txtUserCardId.Text = dt.Rows[0]["PartnerUserCardId"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtPartnerValue.Value = dt.Rows[0]["PartnerValue"].ToString();
            txtPartnerRank.Value = dt.Rows[0]["PartnerRank"].ToString();

        }

        protected void UpdatePanelAlert(string str_Message)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + str_Message + "')", true);
        }
    }
}