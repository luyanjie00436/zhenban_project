using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class ZKZDetailed : System.Web.UI.Page
    {
        Recruitment_Data.MGetData bus = new Recruitment_Data.MGetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string Number;
        int JobMangeId;
        protected string MenuStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["JobId"] != null)
                {
                    try
                    {
                        JobMangeId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["JobId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                  
                    DataSet dt = bus.Job_SelectByJobId("Job_SelectByZKZ", JobMangeId);
                    LName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                    LIDCard.Text = dt.Tables[0].Rows[0]["CardID"].ToString();
                    LJobCode.Text = dt.Tables[0].Rows[0]["JobCode"].ToString();
                    LTestAddress.Text = dt.Tables[0].Rows[0]["TestAddress"].ToString();
                 //   span2.InnerText= dt.Tables[0].Rows[0]["zhuyi"].ToString().Replace("\n", " <br/> "); ;

                    StringBuilder text = new StringBuilder();
                    text.Append(dt.Tables[0].Rows[0]["zhuyi"].ToString().Replace("\n", " <br/> "));
                    MenuStr = text.ToString();
                    string s= dt.Tables[0].Rows[0]["zhuyi"].ToString();
                    string s2 = dt.Tables[0].Rows[0]["zhuyi"].ToString();
                    //   Lzhuyi.InnerText = dt.Tables[0].Rows[0]["zhuyi"].ToString();
                    //    Label1.Text = dt.Tables[0].Rows[0]["zhuyi"].ToString();
                    if (dt.Tables[0].Rows[0]["Photo"].ToString().Length == 0)
                    {
                        Image2.Src = "";
                    }
                    else
                    {
                        Image2.Src = "imgs.aspx?id=" + dt.Tables[0].Rows[0]["CandidatesInfoId"].ToString(); 

                    }
                    if (dt.Tables[1].Rows.Count == 0)
                    {
                        dt.Tables[1].Rows.Add(dt.Tables[1].NewRow());
                        GridView1.DataSource = dt.Tables[1];
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
                        GridView1.DataSource = dt.Tables[1];
                        GridView1.DataBind();
                    }
                    
                }


            }
        }
    }
}