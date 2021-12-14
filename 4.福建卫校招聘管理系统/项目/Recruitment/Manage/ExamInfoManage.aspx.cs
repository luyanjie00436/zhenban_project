using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class ExamInfoManage : System.Web.UI.Page
    {
     
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string UserCardId;
        int JobMangeId;
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

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
           
                    if (Request.QueryString["JobMangeId"]!=null)
                {
                    dataGridviewBD();
                }
            }
            
        }
       public void dataGridviewBD()
        {
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
            DataTable dt2 = bus.JobMange_SelectByJobMangeId("JobMange_SelectByJobMangeId", JobMangeId).Tables[0];
            LJobCode.Text = dt2.Rows[0]["JobCode"].ToString();
            LJobName.Text = dt2.Rows[0]["JobName"].ToString();


            DataSet dt = bus.JobMange_SelectByJobMangeId("ExamInfo_SelectByJobMangeId", JobMangeId);

            if (dt.Tables[0].Rows.Count==0)
            {
                dt.Tables[0].Rows.Add(dt.Tables[0].NewRow());
                GridView1.DataSource = dt.Tables[0];
                GridView1.DataBind();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "暂时没有数据信息";
                GridView1.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            }
            else
            {
                GridView1.DataSource = dt.Tables[0];
                GridView1.DataBind();
            }
           

          
        }
        //参数 事件源
        protected void Button1_Click(object serder, EventArgs e)
        {
            JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobMangeId"], "asdfasdf"));
            TextBox TxtExamSubject = (TextBox)GridView1.FooterRow.FindControl("TxtExamSubject");
            TextBox txtExamDate = (TextBox)GridView1.FooterRow.FindControl("txtExamDate");
            TextBox txtExamTime = (TextBox)GridView1.FooterRow.FindControl("txtExamTime");
            if (TxtExamSubject.Text == "" || txtExamDate.Text == "" || txtExamTime.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请将考试信息填写完整");
                return;
            }       
                //UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                string ExamSubject = TxtExamSubject.Text;
                string ExamDate = txtExamDate.Text;
                string ExamTime = txtExamTime.Text;

            //bus.TechnicianEducationAdd("ApplyPeriodManage_Add", UserCardId, ApplyYearId, Project, EducationSituation, DeclarePeriod, InspectPeriod);
           
           
            if (bus.ExamInfoInsert("ExamInfo_Insert", JobMangeId, ExamSubject, ExamDate, ExamTime))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");
                dataGridviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败请联系管理员");
            }
            

        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)//更新数据
        {
           int ExamInfoId = Convert.ToInt32( ((Label)GridView1.Rows[e.RowIndex].FindControl("LExamInfoId")).Text);
            string ExamSubject = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TxtEditExamSubject")).Text;
            string ExamDate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditExamDate")).Text;
            string ExamTime = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditExamTime")).Text;
            if (ExamSubject == "" || ExamDate == "" || ExamTime == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请将考试信息填写完整");
                return;
            }

            if (bus.ExamInfoUpdate("ExamInfo_Update", ExamInfoId, ExamSubject, ExamDate, ExamTime))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                GridView1.EditIndex = -1;
            
                dataGridviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败请联系管理员");
            }

           


        }
        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="message"></param>
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)//删除数据
        {
            int ExamInfoId=  Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("LExamInfoId")).Text);
         //   string txtExamInfoId = ((Label)GridView1.Rows[e.RowIndex].FindControl("LExamInfoId")).Text;
         //   int ExamInfoId = Convert.ToInt32(txtExamInfoId.ToString());

            if (bus.ExamInfoDelete("ExamInfo_Delete", ExamInfoId ))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGridviewBD();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败请联系管理员");
            }
           

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)//编辑数据
        {
            GridView1.EditIndex = e.NewEditIndex;
            dataGridviewBD();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
        {
            GridView1.EditIndex = -1;
            dataGridviewBD();
        }
    }
}