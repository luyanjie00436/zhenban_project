using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class Photo : System.Web.UI.Page
    {
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        protected void Page_Load(object sender, EventArgs e)
        {
         //  string srcs=Server.MapPath("./")+ pwds.DecryptDES(Request.QueryString["Url"], "asdfasdf");

            string path =  pwds.DecryptDES(Request.QueryString["Url"], "asdfasdf");
            FileInfo fi = new FileInfo(path);
            png.Src = fi.ToString() ;
        }
    }
}