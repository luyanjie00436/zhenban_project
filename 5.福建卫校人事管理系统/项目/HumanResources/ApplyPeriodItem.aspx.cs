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
    public partial class ApplyPeriodItem : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["Human_ConStr"].ToString();
        DataTable dt = new DataTable();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
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
                string Year = Request.QueryString["Year"];
                UserCardId = Request.QueryString["UserCardId"];
                lableApplyYear.Text = Year;
                DataSet ds = bus.GetUserMessage("ApplyPeriodManage_GetUserMessage", UserCardId);
                HiddenYearId.Text = bus.GetYearId("ApplyPeriodManage_GetYearId", Year).Tables[0].Rows[0]["ApplyYearId"].ToString();
                //labelUserCardId.Text = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//保存登录cookies里的UserCarId
               labelPersonName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                labelPosition.Text = ds.Tables[0].Rows[0]["职级"].ToString() + ds.Tables[0].Rows[0]["职称"].ToString();//表里面没有职称字段
                //lableApplyYear.Text = DateTime.Now.Year.ToString();//现在时间
                dataGridviewBD();



            }

        }
        protected void dataGridviewBD()//数据源
        {
            // UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            UserCardId = Request.QueryString["UserCardId"];
            DataSet ds = bus.TechnicianEducationSelectByUserCardId("ApplyPeriodManage_SelectByUserCardId", UserCardId, Convert.ToInt32(HiddenYearId.Text));
            GridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
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
                GridView1.DataSource = ds;
                GridView1.DataBind();
                DataGridview2BD();
            }


        }
        protected void DataGridview2BD()
        {
            UserCardId = Request.QueryString["UserCardId"];
            // UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            DataSet ds = bus.TechnicianEducationSelectByUserCardId("ApplyPeriodManage_SelectByUserCardId", UserCardId, Convert.ToInt32(HiddenYearId.Text));
            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();

        }
    }
}