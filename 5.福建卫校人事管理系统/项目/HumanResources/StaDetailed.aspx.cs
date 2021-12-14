using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources
{
    public partial class StaDetailed : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["biao"] == null|| Request.QueryString["biao"].Length<2)
            {
                Response.Redirect("Login.aspx");
            }
            bangding();
        }
        public void bangding()
        {
            string biao = Request.QueryString["biao"];
            DataSet ds = new DataSet() ;
            string TongjiValue = biao;
            GridView Gv = new GridView();
            ds = bus.tongjiSelect("tongjia1", TongjiValue );
            Gv.Width = 350;
            Gv.DataSource = ds.Tables[0].DefaultView;
            Gv.DataBind();
            div_Detailed.Controls.Add(Gv);
        }
    }
}