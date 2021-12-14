using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Manage
{
    public partial class JobMangeCount : System.Web.UI.Page
    {
        Recruitment_Data.MGetData bus = new Recruitment_Data.MGetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Years = TextBox1.Text;
            DataSet dt = bus.JobMange_SelectByYear("Job_SelectCount", Years);

            GridView1.DataSource = dt.Tables[0];
            GridView1.DataBind();
        }
    }
}