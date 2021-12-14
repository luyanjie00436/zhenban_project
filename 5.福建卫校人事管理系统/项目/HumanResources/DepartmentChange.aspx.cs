using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class DepartmentChange : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AutoGenerateColumns = false;
            dataGriviewBD();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DepartmentChange.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }

                DataSet department = bus.Select("Department_Select");
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DropDownList1.Items.Add(li);
                }
            }

        }
        public void dataGriviewBD()
        {

            GridView1.DataSource = bus.Select("DepartmentChange_Select").Tables[0].DefaultView;
            GridView1.DataBind();
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
            Response.Redirect("DepartmentChange.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int DepartmentId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            if (DepartmentId == 0)
            { dataGriviewBD(); }
            else
            {
                GridView1.DataSource = bus.SelectDepartmentChange("DepartmentChange_SelectByDepartmentId", DepartmentId).Tables[0].DefaultView;
                GridView1.DataBind();
            }

        }
    }
}