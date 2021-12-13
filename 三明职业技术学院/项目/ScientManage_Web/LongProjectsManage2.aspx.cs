﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class LongProjectsManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                #region
                DataTable dt = bus.SelectByRankId("Rank_SelectByRankId", RankId).Tables[0];
                if (dt.Rows[0]["RBL2"].ToString() == "是")
                {
                    DataSet department = bus.Select("Department_Select");
                    foreach (DataRow dr in department.Tables[0].Rows)
                    {
                        ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentName"].ToString());
                        DlDepartment.Items.Add(li);
                    }
                }
                else
                {
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    DlDepartment.Items.Clear();
                    ListItem li = new ListItem(dt.Rows[0]["DepartmentName"].ToString(), dt.Rows[0]["UserDepartmentName"].ToString());
                    DlDepartment.Items.Add(li);
                }
                DataSet Apply = bus.Select("ApplyYear_Select");
                foreach (DataRow dr in Apply.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ReportDate"].ToString());
                    DLApply.Items.Add(li);
                }
                DataSet Subject = bus.Select("ProjectsSubject_Select");
                foreach (DataRow dr in Subject.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsSubjectExplain"].ToString(), dr["ProjectsSubjectExplain"].ToString());
                    DLSubject.Items.Add(li);
                }
                DataSet From = bus.Select("ProjectsFrom_Select");
                foreach (DataRow dr in From.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromExplain"].ToString());
                    DLFrom.Items.Add(li);
                }
                DataSet Level = bus.Select("ProjectsLevel_Select");
                foreach (DataRow dr in Level.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsLevelExplain"].ToString(), dr["ProjectsLevelExplain"].ToString());
                    DLLevel.Items.Add(li);
                }
             
                #endregion

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
            string ProjectsId = txtProjectsId.Text.Trim();
            string ProjectsName = txtProjectsName.Text.Trim();
            string UserName = txtUserName.Text.Trim().ToString();
            string DepartmentName = DlDepartment.SelectedValue.ToString();
            string ApplyYear = DLApply.SelectedValue.ToString();
            string Subject = DLSubject.SelectedValue.ToString();
            string Level = DLLevel.SelectedValue.ToString();
            string From = DLFrom.SelectedValue.ToString();

            string Declare = "0";
            string Stand = "审批通过";
            string Inspect = "0";
            string Ends="未结题";
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
            if (DepartmentName == "0")
            {
                DepartmentName = "";
            }
            if (ApplyYear == "0")
            {
                ApplyYear = "";
            } if (Subject == "0")
            {
                Subject = "";
            } if (Level == "0")
            {
                Level = "";
            } if (From == "0")
            {
                From = "";
            } if (Declare == "0")
            {
                Declare = "";
            } if (Stand == "0")
            {
                Stand = "";
            } if (Inspect == "0")
            {
                Inspect = "";
            } if (Ends == "0")
            {
                Ends = "";
            }
            
            DataTable dt = bus.SelectsLongProjects("LongProjectsView_Selects", ProjectsId, ProjectsName, UserName, DepartmentName,ApplyYear,Subject,Level,From,Declare,Stand,Inspect,Ends,Year,Month).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                try
                {
                    Label Status2 = (Label)GridView1.Rows[i].FindControl("LDeclareStatus");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton6");
                        lb.Visible = true;

                    }
                    Status2 = (Label)GridView1.Rows[i].FindControl("LStandStatus");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton7");
                        lb.Visible = true;

                    }
                    Status2 = (Label)GridView1.Rows[i].FindControl("LInspectStatus");  //获取gridview中的编号控件
                    if (Status2.Text == "审批通过" || Status2.Text == "审批未通过")
                    {
                        LinkButton lb = (LinkButton)GridView1.Rows[i].FindControl("LinkButton8");
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
            string url = "/LongProjectsDeclareDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsStandDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);
        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            string url = "/LongProjectsInspectDetailed.aspx?LongProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");   
            Response.Redirect(url);
        }
        /// <summary>
        /// 跳过中检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {  
            bus.LongProjectsUpdatinspectStatus("LongProjects_UpdateInspectStatus", e.CommandArgument.ToString(), "审批通过");   
            Response.AddHeader("Refresh", "0");   // 刷新页面
        }
        /// <summary>
        /// 中检重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string url = pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            bus.LongProjectsUpdatinspectStatus("LongProjects_UpdateInspectStatus", e.CommandArgument.ToString(), "未中检");   //存储过程,项目id,项目状态
            Response.AddHeader("Refresh", "0");   // 刷新页面

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
            Response.Redirect("LongProjectsManage2.aspx");
        }

    }
}