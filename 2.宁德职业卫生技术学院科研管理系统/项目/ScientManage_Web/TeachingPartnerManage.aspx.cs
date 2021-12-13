using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class TeachingPartnerManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        public static string myuserCardId = "";
        public static string indetify = "";
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TeachingPartnerManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }


                DataTable dt = bus.SelectTeachingByUserCardId("Teaching_SelectByPartnerUserNO", UserCardId).Tables[0];
                DlTeaching.Items.Clear();
                DlTeaching.Items.Add("==请选择==");
                DlTeaching.Items[0].Value = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["BookName"].ToString(), dr["TeachingId"].ToString());
                    DlTeaching.Items.Add(li);
                }
                dt.Dispose();
            }

        }
        public void dataGriviewBD(int TeachingId)
        {

            GridView1.DataSource = bus.SelectByTeachingId("TeachingPartner_SelectByTeachingId", TeachingId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double PartnerValue;
            string EditedSequence = DlEditedSequence.SelectedValue;
            if (DlTeaching.SelectedIndex.Equals(0))
            {
                UpdatePanelAlert("请选择要添加的著作教材成果！");
                return;
            }
            int TeachingId = Convert.ToInt32(DlTeaching.SelectedValue);
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
            if (bus.TeachingPartnerInsert("TeachingPartner_Insert", TeachingId, UserCardId, PartnerRank, PartnerValue, EditedSequence))
            {

                UpdatePanelAlert("添加成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                dataGriviewBD(TeachingId);
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
            int TeachingId = Convert.ToInt32(DlTeaching.SelectedValue);
            string EditedSequence = DlEditedSequence.SelectedValue;
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
            if (bus.TeachingPartnerUpdate("TeachingPartner_Update", Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["TeachingPartnerId"].Value)), UserCardId, PartnerRank, PartnerValue, EditedSequence))
            {

                UpdatePanelAlert("修改成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD(TeachingId);
            }
            else
            {
                UpdatePanelAlert("修改失败！");
            }



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Partner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            dataGriviewBD(Convert.ToInt32(DlTeaching.SelectedValue));
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
            dataGriviewBD(Convert.ToInt32(DlTeaching.SelectedValue));
        }
        //删除
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            int TeachingId = Convert.ToInt32(DlTeaching.SelectedValue);
            if (bus.TeachingPartnerDelete("TeachingPartner_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                UpdatePanelAlert("删除成功！");
                dataGriviewBD(TeachingId);
            }
        }
        //编辑
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = true;
            DataTable dt = bus.SelectByTeachingPartnerId("TeachingPartner_SelectByTeachingPartnerId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            Response.Cookies["TeachingPartnerId"].Value = e.CommandArgument.ToString();
            txtUserCardId.Text = dt.Rows[0]["PartnerUserCardId"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            DlEditedSequence.SelectedValue = dt.Rows[0]["EditedSequence"].ToString();
            
            txtPartnerValue.Text = dt.Rows[0]["PartnerValue"].ToString();
            DlPartnerRank.SelectedValue = dt.Rows[0]["PartnerRank"].ToString();

        }

        protected void UpdatePanelAlert(string str_Message)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + str_Message + "')", true);
        }
    }
}