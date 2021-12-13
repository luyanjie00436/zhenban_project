using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class UserRankManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
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
                if (Request.QueryString["UserCardId"] != null)
                {
                    UserCardId = Request.QueryString["UserCardId"];
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet Rank = bus.Select("Rank_Select");
                foreach (DataRow dr in Rank.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                    LBRank1.Items.Add(li);
                }
                DataSet Rank2 = bus.SelectByUserCardId("UserRank_SelectByUserCardId", UserCardId);
                foreach (DataRow dr in Rank2.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                    LBRank2.Items.Add(li);
                }
                DataTable dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                txtUserCardId.Text = dt.Rows[0]["UserCardId"].ToString();
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LBRank1.SelectedItem != null)
            {
                if (!LBRank2.Items.Contains(LBRank1.SelectedItem))
                {
                    LBRank2.Items.Add(LBRank1.SelectedItem);
                }
            }



        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (LBRank2.SelectedItem != null)
            {
                LBRank2.Items.Remove(LBRank2.SelectedItem);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string  UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            bus.DeleteByUserCardId("UserRank_Delete", txtUserCardId.Text);
            foreach (ListItem li in LBRank2.Items)
            {
                bus.UserRankInsert("UserRank_Insert", txtUserCardId.Text, Convert.ToInt32(li.Value),UserCardId2);
            }
            AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
            Response.Redirect("UserInfoManage.aspx");
            return;
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfoManage.aspx");
        }
    }
}