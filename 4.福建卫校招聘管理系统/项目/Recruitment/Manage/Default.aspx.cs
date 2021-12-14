using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class Default : System.Web.UI.Page
    {
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('您没有权限访问此页面！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
            }
        }
    }
}