using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ServiceIndustryManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ServiceIndustryManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", "0");
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlSerivice1.Items.Add(li);
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            string ServiceId;
            if (DlSerivice3.Items.Count>0)
            {
                if (DlSerivice3.SelectedValue!="0")
                {
                    ServiceId = DlSerivice3.SelectedValue;
                }
                else
                {
                    ServiceId = DlSerivice2.SelectedValue;
                }
            }
            else if (DlSerivice2.Items.Count>0)
            {
                if (DlSerivice2.SelectedValue != "0")
                {
                    ServiceId = DlSerivice2.SelectedValue;
                }
                else
                {
                    ServiceId = DlSerivice1.SelectedValue;
                }
            }
            else
            {
                ServiceId = DlSerivice1.SelectedValue;
            }


            GridView1.DataSource = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", ServiceId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.ServiceIndustryDelete("ServiceIndustry_Delete", Convert.ToInt32(e.CommandArgument.ToString()), UserCardId))
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
            Response.Cookies["selectServiceIndustryId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ServiceIndustryManage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void DlSerivice1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlSerivice2.Items.Clear();
            DlSerivice3.Items.Clear();
            if (DlSerivice1.SelectedValue != "0")
            {
                ListItem li2 = new ListItem("请选择", "0");
                DlSerivice2.Items.Add(li2);
                string SeriviceId = DlSerivice1.SelectedValue.ToString();

                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", SeriviceId);
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlSerivice2.Items.Add(li);
                }

            }
            dataGriviewBD();




        }

        protected void DlSerivice2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlSerivice3.Items.Clear();
            if (DlSerivice1.SelectedValue != "0")
            {
                ListItem li2 = new ListItem("请选择", "0");
                DlSerivice3.Items.Add(li2);
                string SeriviceId = DlSerivice2.SelectedValue.ToString();

                DataSet Serivice = bus.SelectByServiceIndustryIds("ServiceIndustry_SelectByFatherId", SeriviceId);
                foreach (DataRow dr in Serivice.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ServiceIndustryName"].ToString(), dr["Id"].ToString());
                    DlSerivice3.Items.Add(li);
                }

            }
            dataGriviewBD();
        }
        protected void DlSerivice3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}