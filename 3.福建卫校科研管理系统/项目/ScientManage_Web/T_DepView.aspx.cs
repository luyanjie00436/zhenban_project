using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class T_DepView : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/DepView.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
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
                    dt = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    ListItem li = new ListItem(dt.Rows[0]["DepartmentName"].ToString(), dt.Rows[0]["DepartmentId"].ToString());
                    DlDepartment.Items.Add(li);
                }
                DataSet AppplyYear = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in AppplyYear.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DLApplyYear.Items.Add(li);
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
            string UserName = txtUserName.Text.Trim().ToString();
            string ApplyYearName = DLApplyYear.SelectedItem.Text;
            string DepartmentName = DlDepartment.SelectedItem.Text;
            DataTable dt = bus.SelectsByApplyValue("T_AssessValueView_Selects", UserName, DepartmentName, ApplyYearName).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            gvExcel.DataMember = dt.TableName;
            gvExcel.DataSource = dt;
            gvExcel.DataBind();
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            DataTable dt = bus.SelectByAssessValueId("T_AssessValue_SelectByT_AssessValueId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            string UserCardId = dt.Rows[0]["UserCardId"].ToString();
            string ApplyYearId = dt.Rows[0]["ApplyYearId"].ToString();
            string url = "/T_AssessDetailed.aspx?ApplyYearId=" + pwds.EncryptDES(ApplyYearId, "asdfasdf") + "&UserCardId=" + pwds.EncryptDES(UserCardId, "asdfasdf");
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
            // Response.Redirect("GuidanceManage.aspx");
        }
    }
}