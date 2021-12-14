using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Rank_User : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        int RankId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(Request.QueryString["Rank"]);
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable dt = bus.SelectByRankId("UserRank_SelectByRankId", RankId).Tables[0];
                GridView Gv = new GridView();
             
                Gv.Width = 350;
                Gv.DataSource = dt.DefaultView;
                Gv.DataBind();
                div_Detailed.Controls.Add(Gv);

            }
        }
    }
}