using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class RankAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与人事处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                clearIfo();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string RankName = txtRankName.Text.Trim().ToString();
            string RBL1 = RBList1.SelectedValue;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (RankName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写角色名称");
                return;
            }
            if (RBL1 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择是否可修改个人信息");
                return;
            }
            if (RankIf())
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败，你要添加的角色已存在");
                return;
            }
            if (bus.RankInsert("Rank_Insert", RankName, UserCardId, RBL1))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                txtRankName.Text = "";
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }
        }
        public bool RankIf()
        {
            DataSet department = bus.Select("Rank_Select");
            foreach (DataRow item in department.Tables[0].Rows)
            {

                if (item["RankName"].ToString() == txtRankName.Text.Trim().ToString())
                {

                    return true;
                }


            }
            return false;
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();

        }
        public void clearIfo()
        {
            txtRankName.Text = "";

        }

    }
}