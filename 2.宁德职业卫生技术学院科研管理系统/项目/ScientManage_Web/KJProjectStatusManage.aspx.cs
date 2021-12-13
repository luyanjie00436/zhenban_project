using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class KJprojectManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/KJProjectStatusManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                //DataSet department = bus.Select("KJProjectName_Select");
                //foreach (DataRow dr in department.Tables[0].Rows)
                //{
                //    ListItem li = new ListItem(dr["KJProjectName"].ToString(), dr["KJProjectId"].ToString());
                //    txtKJProjectName.Items.Add(li);
                //}
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
            string strExcelName = "MyExcel.xls";
            strExcelName = strExcelName.Replace(@"/", "");

            ExportToExcel(this.Page, gvExcel, strExcelName);
        }
        public void ExportToExcel(System.Web.UI.Page page, GridView excel, string fileName)
        {
            try
            {
                foreach (GridViewRow row in excel.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        excel.HeaderRow.Cells[i].BackColor = System.Drawing.Color.Yellow;
                    }
                }
                excel.Font.Size = 10;
                excel.AlternatingRowStyle.BackColor = System.Drawing.Color.LightCyan;
                excel.RowStyle.Height = 25;
                page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                page.Response.Charset = "utf-8";
                page.Response.ContentType = "application/vnd.ms-excel";
                page.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
                excel.Page.EnableViewState = false;
                excel.Visible = true;
                excel.HeaderStyle.Reset();
                excel.AlternatingRowStyle.Reset();
                System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                excel.RenderControl(oHtmlTextWriter);
                page.Response.Write(oStringWriter.ToString());
                page.Response.End();
                excel.DataSource = null;
                excel.Visible = false;
            }
            catch (Exception e)
            {

            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string UserName = txtUserName.Text.Trim().ToString();
            string KJProjectName = txtKJProjectName.Text.Trim();
            string ApprovalDate = txtApprovalDate.Text.Trim();
            string ApplyYear = txtApplyYear.Text.Trim();

            string TransferStatus = DlStatus.SelectedItem.Text;
            if (TransferStatus == "审批状态")
            {
                TransferStatus = "";
            }
            DataTable dt = bus.SelectsKJProjectStatus("KJProjectStatus_Selects", UserName, ApprovalDate, ApplyYear, TransferStatus, KJProjectName).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            gvExcel.DataMember = dt.TableName;
            gvExcel.DataSource = dt;
            gvExcel.DataBind();
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("KJProjectStatusDetailed.aspx?KJProjectStatusId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
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
            Response.Redirect("KJProjectStatusManage.aspx");
        }
    }
}