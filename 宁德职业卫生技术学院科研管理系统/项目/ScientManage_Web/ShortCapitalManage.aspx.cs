using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ShortCapitalManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ShortCapitalManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataTable dt = bus.SelectByRankId("Rank_SelectByRankId", RankId).Tables[0];
                if (dt.Rows[0]["RBL2"].ToString() == "是")
                {
                    DataSet department = bus.Select("Department_Select");
                    foreach (DataRow dr in department.Tables[0].Rows)
                    {
                        ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                        DlDepartment.Items.Add(li);
                    }
                }
                else
                {
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    ListItem li = new ListItem(dt.Rows[0]["DepartmentName"].ToString(), dt.Rows[0]["UserDepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void gvExcel_RowDataBound(object sender, GridViewRowEventArgs e)
        { }
        public override void VerifyRenderingInServerForm(Control control)
        { }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string ContractId = txtContractId.Text.Trim();
            string ContractName = txtContractName.Text.Trim();
            string DepartmentName = DlDepartment.SelectedItem.Text;
            string Company = txtCompany.Text.Trim();
            double Money1 = 0, Money2 = 999999999;
            if (txtMoney1.Text != "")
            {
                Money1 = Convert.ToDouble(txtMoney1.Text);
            }
            if (txtMoney2.Text != "")
            {
                Money2 = Convert.ToDouble(txtMoney2.Text);
            }
            DataTable dt = bus.SelectsShortCapital("ShortCapital_Selects", ContractId, ContractName, Company, Money1, Money2, DepartmentName).Tables[0];
            string strExcelName = "横向项目经费";
            strExcelName = strExcelName.Replace(@"/", "");
            DataTableToExcel(dt, strExcelName);
        }
        public static void DataTableToExcel(System.Data.DataTable dtData, String FileName)
        {
            GridView dgExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;
            if (dtData != null)
            {
                HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8);
                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                curContext.Response.Charset = "GB2312";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                dgExport = new GridView();
                dgExport.RowDataBound += (GridViewFormat); //在GridView绑定数据时，将数据格式化
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        protected static void GridViewFormat(object sender, GridViewRowEventArgs e)
        {
            //1）  文本：vnd.ms-excel.numberformat:@
            //2）  日期：vnd.ms-excel.numberformat:yyyy/mm/dd
            //3）  数字：vnd.ms-excel.numberformat:#,##0.00
            //4）  货币：vnd.ms-excel.numberformat:￥#,##0.00
            //5）  百分比：vnd.ms-excel.numberformat: #0.00%
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                }
            }
        }
     
        
       
        public void dataGriviewBD()
        {
            string ContractId = txtContractId.Text.Trim();
            string ContractName = txtContractName.Text.Trim();
            string DepartmentName = DlDepartment.SelectedItem.Text;
            string Company = txtCompany.Text.Trim();
            double Money1 = 0, Money2 = 999999999;
            if (txtMoney1.Text != "")
            {
                Money1 = Convert.ToDouble(txtMoney1.Text);
            }
            if (txtMoney2.Text != "")
            {
                Money2 = Convert.ToDouble(txtMoney2.Text);
            }
            DataTable dt = bus.SelectsShortCapital("ShortCapital_Selects", ContractId, ContractName, Company, Money1, Money2, DepartmentName).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
           
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {

                    Label Status2 = (Label)GridView1.Rows[i].FindControl("LPlace");  //获取gridview中的编号控件
                    if (Status2.Text != "")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton6");
                        lb.Visible = true;

                    }
                    Status2 = (Label)GridView1.Rows[i].FindControl("LPlan");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton7");
                        lb.Visible = true;

                    }
                    Status2 = (Label)GridView1.Rows[i].FindControl("LChange");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
                        lb.Visible = true;

                    }
                    Status2 = (Label)GridView1.Rows[i].FindControl("LClose");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton9");
                        lb.Visible = true;

                    }
                }
                catch
                {

                }
            }

        }
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortCapitalPlaceDetailed.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortCapitalPlanDetailed.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortCapitalChangeDetailed.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }

        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortCapitalCloseDetailed.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
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
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
          //  Response.Redirect("LongContractManage.aspx");
        }
    }
}