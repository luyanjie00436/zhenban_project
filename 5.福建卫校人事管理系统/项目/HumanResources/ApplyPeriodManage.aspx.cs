using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ApplyPeriodManage : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["Human_ConStr"].ToString();
        DataTable dt = new DataTable();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int EducationId;
        int ApplyYearId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ApplyPeriodManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataTable dt1 = bus.Select("ApplyYear_Select").Tables[0];
                DlYear.Items.Clear();
                foreach (DataRow dr in dt1.Rows)
                {
                    ListItem li = new ListItem(dr["ReportDate"].ToString(), dr["ApplyYearId"].ToString());
                    DlYear.Items.Add(li);
                }
                if (Request.QueryString["UserCardId"]  != null && Request.QueryString["Year"] != null)
                {
                    string Year = Request.QueryString["Year"];
                    string UserCardId = Request.QueryString["UserCardId"];
                    DataSet ds = bus.GetUserMessage("ApplyPeriodManage_GetUserMessage", UserCardId);                
                    txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                    txtUserCardId.Text = UserCardId;
                    HiddenYearId.Text = Request.QueryString["Year"];
                    for (int i = 0; i < DlYear.Items.Count; i++)
                    {
                        if (Year==DlYear.Items[i].Text)
                        {
                            DlYear.SelectedValue = DlYear.Items[i].Value;
                            break;
                        }
                    }                    
                    dataGridviewBD();
                }
            }
        }
        protected void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserCardId = txtUserCardId.Text.Trim();
            if (UserCardId!=""&&UserCardId.Length>2)
            {
                dataGridviewBD();
            }          
        }
        protected void dataGridviewBD()//数据源
        {
            UserCardId = txtUserCardId.Text;
            ApplyYearId =Convert.ToInt32(DlYear.SelectedValue);
            DataSet ds = bus.TechnicianEducationSelectByUserCardId("ApplyPeriodManage_SelectByUserCardId", UserCardId, ApplyYearId);
            GridView1.DataSource = ds.Tables[2].DefaultView;
            if (ds.Tables[2].Rows.Count == 0)
            {
                ds.Tables[2].Rows.Add(ds.Tables[2].NewRow());
                GridView1.DataSource = ds.Tables[2];
                GridView1.DataBind();
                DataGridview2BD();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "暂时没有数据信息";
                GridView1.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            }
            else
            {
                GridView1.DataSource = ds.Tables[2];
                GridView1.DataBind();
                DataGridview2BD();
            }
        }

        protected void DataGridview2BD()
        {
            UserCardId = txtUserCardId.Text;
            DataSet ds = bus.TechnicianEducationSelectByUserCardId("ApplyPeriodManage_SelectByUserCardId", UserCardId, Convert.ToInt32(DlYear.Text));
            GridView2.DataSource = ds.Tables[3];
            GridView2.DataBind();
        }

        //参数 事件源
        protected void Button1_Click(object serder, EventArgs e)
        {
            UserCardId = txtUserCardId.Text;

           // string applyYearId = HiddenYearId.Text;
            int ApplyYearId = Convert.ToInt32(DlYear.SelectedValue);
            TextBox project = (TextBox)GridView1.FooterRow.FindControl("TextBoxProject");
            TextBox educationSituation = (TextBox)GridView1.FooterRow.FindControl("TextBoxEduSituation");
            TextBox declarePeriod = (TextBox)GridView1.FooterRow.FindControl("TextBoxDeclarePeriod");
            TextBox TextBoxInspectPeriod = (TextBox)GridView1.FooterRow.FindControl("TextBoxInspectPeriod");            
            if (project.Text == "" || educationSituation.Text == "" || declarePeriod.Text == "" || TextBoxInspectPeriod.Text == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请将申报信息填写完整");
                return;
            }
            if (Convert.ToInt32(declarePeriod.Text) <= 0 )
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请按规范输入学时信息");
                return;
            }
            else
            {
                //UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                string Project = project.Text;
                string EducationSituation = educationSituation.Text;
                int DeclarePeriod = Convert.ToInt32(declarePeriod.Text);
                int InspectPeriod = Convert.ToInt32(TextBoxInspectPeriod.Text);                
                bus.TechnicianEducationAdd("ApplyPeriodManage_Add", UserCardId, ApplyYearId, Project, EducationSituation, DeclarePeriod, InspectPeriod);
                AlertMsgAndNoFlush(UpdatePanel1, "添加数据成功");
                dataGridviewBD();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)//更新数据
        {
            string educationId = ((Label)GridView1.Rows[e.RowIndex].FindControl("LabelID")).Text;
            string Project = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxEditProject")).Text;
            string EducationSituation = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxEditEduSituation")).Text;
            string declarePeriod = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxEditDeclarePeriod")).Text;
            string inspectPeriod = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxEditInspectPeriod")).Text;
            if (Project == "" || EducationSituation == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请将修改信息填写完整");
                return;
            }
            if (declarePeriod == "" || Convert.ToInt32(declarePeriod) <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请按规范输入学时信息");
                return;
            }
            else
            {
                int EducationId = Convert.ToInt32(educationId.ToString());
                int DeclarePeriod = Convert.ToInt32(declarePeriod.ToString());
                int InspectPeriod = Convert.ToInt32(inspectPeriod.ToString());
                bus.TechnicianEducationUpdate("ApplyPeriodManage_Update", EducationId, Project, EducationSituation, DeclarePeriod, InspectPeriod);
                GridView1.EditIndex = -1;
                AlertMsgAndNoFlush(UpdatePanel1, "编辑成功");
                dataGridviewBD();
            }
            //Response.Write("<script language='javascript'>alert('编辑成功')</script>");
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
            string educationId = ((Label)GridView1.Rows[e.RowIndex].FindControl("LabelID")).Text;
            int EducationId = Convert.ToInt32(educationId.ToString());
            bus.TechnicianEducationDeleting("ApplyPeriodManage_Deleting", EducationId);
            AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
            dataGridviewBD();
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            DataTable dt = bus.SelectByUserName("UserInfo_SelectByUserName", UserName).Tables[0];
            DlName.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["姓名"].ToString(), dr["工号"].ToString());
                DlName.Items.Add(li);
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlName.SelectedValue != "0")
            {
                txtUserCardId.Text = DlName.SelectedValue;
                txtUserName.Text = DlName.SelectedItem.Text;
              //  labelBranch.Text = DlName.SelectedItem.Text.Substring(0, a);
                dataGridviewBD();
            }
        }
    }
}