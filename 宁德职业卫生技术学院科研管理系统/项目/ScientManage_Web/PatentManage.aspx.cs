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
    public partial class PatentManage : System.Web.UI.Page
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/PatentManage.aspx") == 0)
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        protected void gvExcel_RowDataBound(object sender, GridViewRowEventArgs e)
        { }
        public override void VerifyRenderingInServerForm(Control control)
        { }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim().ToString();
            string PatentName = txtPatentName.Text.Trim();
            string PatentCateGory = txtPatentCateGory.Text.Trim();
            string DepartmentId = DlDepartment.SelectedItem.Text;
            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            try
            {
                Year = Convert.ToInt32(seYear);
            }
            catch (Exception)
            {

                Year = 0;
            }
            try
            {
                Month = Convert.ToInt32(seMonth);
            }
            catch (Exception)
            {

                Month = 0;
            }
            string Status = DlStatus.SelectedItem.Text;
            if (Status == "审批状态")
            {
                Status = "";
            }
            DataTable dt = bus.SelectsPatent("Patent_Selects", UserName, DepartmentId, Year, Month, Status, PatentName, PatentCateGory).Tables[0];
            string strExcelName = "专利成果";
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
            string UserName = txtUserName.Text.Trim().ToString();
            string PatentName = txtPatentName.Text.Trim();
            string PatentCateGory = txtPatentCateGory.Text.Trim();
            string DepartmentId = DlDepartment.SelectedItem.Text;
            string seYear = DlYear.SelectedItem.ToString();
            int Year;
            string seMonth = DlMonth.SelectedItem.ToString();
            int Month;
            try
            {
                Year = Convert.ToInt32(seYear);
            }
            catch (Exception)
            {

                Year = 0;
            }
            try
            {
                Month = Convert.ToInt32(seMonth);
            }
            catch (Exception)
            {

                Month = 0;
            }
            string Status = DlStatus.SelectedItem.Text;
            if (Status == "审批状态")
            {
                Status = "";
            }
            DataTable dt = bus.SelectsPatent("Patent_Selects", UserName,DepartmentId, Year, Month, Status, PatentName, PatentCateGory).Tables[0];
            GridView1.DataSource =dt.DefaultView;
            GridView1.DataBind();
           
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("PatentDetailed.aspx?PatentId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
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
            Response.Redirect("PatentManage.aspx");
        }
    }
}