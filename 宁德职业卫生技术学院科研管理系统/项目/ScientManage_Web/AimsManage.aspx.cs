using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class AimsManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                    Response.Redirect("Login.aspx");
                   
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/AimsManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId",0);
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims1.Items.Add(li);
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            int AimsId;
            if (DlAims2.Items.Count>0)
            {
                if (DlAims2.SelectedValue!="0")
                {
                    AimsId = Convert.ToInt32(DlAims2.SelectedValue);
                }
                else
                {
                    AimsId = Convert.ToInt32(DlAims1.SelectedValue);
                }
            }
            else
            {
                AimsId = Convert.ToInt32(DlAims1.SelectedValue);
            }
            GridView1.DataSource = bus.SelectByAimsId("Aims_SelectByFatherId", AimsId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.AimsDelete("Aims_Delete", Convert.ToInt32(e.CommandArgument.ToString()), UserCardId))
            {
                Response.Write("<script>alert('删除成功')</script>");
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
            Response.Cookies["selectAimsId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("AimsManage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }

        protected void DlAims1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlAims2.Items.Clear();
            if (DlAims1.SelectedValue!="0")
            {
                ListItem li2 = new ListItem("请选择", "0");
                DlAims2.Items.Add(li2);
                int AimsId = Convert.ToInt32( DlAims1.SelectedValue.ToString());

                DataSet Aims = bus.SelectByAimsId("Aims_SelectByFatherId", AimsId);
                foreach (DataRow dr in Aims.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["AimsName"].ToString(), dr["Id"].ToString());
                    DlAims2.Items.Add(li);
                }

            }
            dataGriviewBD();




        }

        protected void DlAims2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}