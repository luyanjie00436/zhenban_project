using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Left : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        DataTable dt;
        int RankId;
        string UserCardId;
        int pid;
        protected string MenuStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    pid = Convert.ToInt32(Request.QueryString["pid"]);
                    if (pid > 0)
                    {
                        menu_bind(pid);
                    }
                    else
                    {
                        pid = 2;
                        menu_bind(pid);
                    }
                }
                catch
                {
                    pid = 2;
                    menu_bind(pid);
                }
            }
        }
        public void menu_bind(int pid)
        {
            try
            {
                RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                dt = bus.SelectByRankId("AuthorityView_Select", RankId).Tables[0];
                StringBuilder text = new StringBuilder();
                DataRow[] rows = dt.Select("ModelFatherId=" + pid);
                if (rows.Length > 0)
                {
                    text.Append("<ul class=\"yiji\">");
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (rows[i]["ModelUrl"].ToString().Length > 3)
                        {
                            text.Append("<li ><a  class=\"inactive\" target=\"center\"  href=\"" + rows[i]["ModelUrl"].ToString().Substring(rows[i]["ModelUrl"].ToString().LastIndexOf("/")) + "\">" + rows[i]["ModelName"].ToString() + "</a>\r\n");

                        }
                        else
                        {
                            text.Append("<li ><a  class=\"inactive\" >" + rows[i]["ModelName"].ToString() + "</a>\r\n");

                        }
                       
                        pid = Convert.ToInt32(rows[i]["ModelId"]);
                        this.FillMenu(text, pid);
                        text.Append("</li>");
                    }
                    text.Append("</ul>");
                }
                MenuStr = text.ToString();
            }
            catch
            {

            }
        }
        protected void FillMenu(StringBuilder text, int pid)
        {
            DataRow[] rows = dt.Select("ModelFatherId=" + pid + "");
            if (rows.Length > 0)
            {
                text.Append("<ul style=\"display:none;\">");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i]["ModelUrl"].ToString().Length > 3)
                    {
                        text.Append("<li ><a class=\"inactive active\" target=\"center\"  href=\"" + rows[i]["ModelUrl"].ToString().Substring(rows[i]["ModelUrl"].ToString().LastIndexOf("/")) + "\">" + rows[i]["ModelName"].ToString() + "</a>\r\n");

                    }
                    else
                    {
                        text.Append("<li ><a class=\"inactive active\" >" + rows[i]["ModelName"].ToString() + "</a>\r\n");


                    }

                
                    pid = Convert.ToInt32(rows[i]["ModelId"]);
                  
                    FillMenu2(text, pid);
                    text.Append("</li>");
                }
                text.Append("</ul>");
            }
        }
        protected void FillMenu2(StringBuilder text, int pid)
        {
            DataRow[] rows = dt.Select("ModelFatherId=" + pid + "");
            if (rows.Length > 0)
            {
                text.Append("<ul>");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i]["ModelUrl"].ToString().Length > 3)
                    {
                        text.Append("<li ><a  target=\"center\"  href=\"" + rows[i]["ModelUrl"].ToString().Substring(rows[i]["ModelUrl"].ToString().LastIndexOf("/")) + "\"><span class=\"ico1\">" + rows[i]["ModelName"].ToString() + "</span></a>\r\n");

                    }
                    else
                    {
                        text.Append("<li  >" + rows[i]["ModelName"].ToString() + "\r\n");

                    }
                  
                    text.Append("</li>");
                }
                text.Append("</ul>");
            }
        }

    }
  
}