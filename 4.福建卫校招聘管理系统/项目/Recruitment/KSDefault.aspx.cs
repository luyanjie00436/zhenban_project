using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class KSDefault : System.Web.UI.Page
    {
        string Number;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Number = HttpUtility.UrlDecode(Request.Cookies["Number"].Value);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='index.aspx'<" + "/script>");
            }
        }
    }
}