using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ShortCapitalPlaceAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        public static string myuserCardId = "";
        public static string indetify = "";
        string UserCardId, ShortProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Button2.Visible = false;
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                if (Request.QueryString["ShortProjectsId"] != null)
                {
                    try
                    {
                        ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByShortProjectsId("ShortProjects_SelectByShortProjectsId", ShortProjectsId);
                    LProjectsId.Text = ShortProjectsId;
                    LContractName.Text = dt.Tables[0].Rows[0]["ContractName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }

                dataGriviewBD();
            }
        }


        public void dataGriviewBD()
        {
            ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
            DataTable dt = bus.SelectByShortProjectsId("ShortCapitalPlace_SelectByShortProjectsId", ShortProjectsId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                txtSumMoney.Text = dt.Rows[0]["SumMoney"].ToString();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ShortProjectsId = LProjectsId.Text;
            double PlaceMoney;
            string PlaceDate = txtPlaceDate.Value;
            string PlaceExplain = txtPlaceExplain.Text;
            if (PlaceDate == "")
            {
                UpdatePanelAlert("请输入资金到位时间！");
                return;
            }
            try
            {
                PlaceMoney = Convert.ToDouble(txtPlaceMoney.Value);
            }
            catch (Exception)
            {

                UpdatePanelAlert("金额请输入正数！");
                return;
            }
            if (PlaceMoney <= 0)
            {
                UpdatePanelAlert("金额请输入正数！");
                return;
            }
            if (bus.ShortCapitalPlaceInsert("ShortCapitalPlace_Insert", ShortProjectsId, PlaceMoney, PlaceDate, PlaceExplain))
            {
                UpdatePanelAlert("添加成功！");
                txtPlaceDate.Value = "";
                txtPlaceMoney.Value = "";
                dataGriviewBD();
            }
            else
            {
                UpdatePanelAlert("添加失败！");
            }



        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            double PlaceMoney;
            string PlaceDate = txtPlaceDate.Value;
            string PlaceExplain = txtPlaceExplain.Text;
            if (PlaceDate == "")
            {
                UpdatePanelAlert("请输入资金到位时间！");
                return;
            }
            try
            {
                PlaceMoney = Convert.ToDouble(txtPlaceMoney.Value);
            }
            catch (Exception)
            {

                UpdatePanelAlert("金额请输入正数！");
                return;
            }
            if (PlaceMoney <= 0)
            {
                UpdatePanelAlert("金额请输入正数！");
                return;
            }
            int CapitalPlaceId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["ShortCapitalPlaceId"].Value));
            if (bus.ShortCapitalPlaceUpdate("ShortCapitalPlace_Update", CapitalPlaceId, PlaceMoney, PlaceDate, PlaceExplain))
            {

                UpdatePanelAlert("修改成功！");
                txtPlaceDate.Value = "";
                txtPlaceMoney.Value = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD();
            }



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
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
        //删除
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            if (bus.ShortCapitalPlaceDelete("ShortCapitalPlace_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                UpdatePanelAlert("删除成功！");
                dataGriviewBD();
            }
        }
        //编辑
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = true;
            DataTable dt = bus.SelectShortCapitalPlaceId("ShortCapitalPlace_SelectByShortCapitalPlaceId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            Response.Cookies["ShortCapitalPlaceId"].Value = e.CommandArgument.ToString();
            txtPlaceMoney.Value = dt.Rows[0]["PlaceMoney"].ToString();
            txtPlaceDate.Value = dt.Rows[0]["PlaceDate"].ToString();
            txtPlaceExplain.Text = dt.Rows[0]["PlaceExplain"].ToString();
        }

        protected void UpdatePanelAlert(string str_Message)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + str_Message + "')", true);
        }
    }
}