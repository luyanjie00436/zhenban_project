using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UserInfoAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        string UserCardId;
        int RankId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }


                #region bd

             
                DataSet Rank = bus.Select("Rank_Select");
                foreach (DataRow dr in Rank.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                    LBRank1.Items.Add(li);
                }
                #endregion

            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
         string   UserCardId2 = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string UserCardId = txtUserCardId.Text.Trim().ToString();
            string UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPwd.Text.Trim(), "MD5");
            string UserName = txtUserName.Text.Trim().ToString();
            string UserSource = DlUserSource.SelectedValue;
            if (UserCardId == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写用户工号");
                return;
            }
            if (UserCardId.Length < 6||UserCardId.Length>18)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "用户工号长度应为6~18位");
                return;
            }
            if (txtUserPwd.Text.Trim().ToString() == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写用户密码");
                return;
            }
            if (txtUserPwd.Text.Trim().ToString().Length < 6||txtUserPwd.Text.Trim().ToString().Length >18)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "密码长度应为6到18位");
                return;
            }
            if (UserName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写姓名");
                return;
            }
           
            if (bus.UserInfoInsert("UserInfo_Insert", UserCardId, UserPwd, UserSource, UserName,UserCardId2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败,请检查用户工号是否已存在！");
                return;

            }           
            foreach (ListItem li in LBRank2.Items)
            {
                bus.UserRankInsert("UserRank_Insert", txtUserCardId.Text, Convert.ToInt32(li.Value),UserCardId2);
            }
            AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
            clearIfo();
        }
        public void clearIfo()
        {
            txtUserCardId.Text = "";
            txtUserName.Text = "";
            txtUserPwd.Text = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (LBRank1.SelectedItem != null)
            {
                if (!LBRank2.Items.Contains(LBRank1.SelectedItem))
                {
                    LBRank2.Items.Add(LBRank1.SelectedItem);
                }
            }



        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfoManage.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            if (LBRank2.SelectedItem != null)
            {
                LBRank2.Items.Remove(LBRank2.SelectedItem);
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}