using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class SpecialDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int SpecialId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["SpecialId"] != null)
                {
                    try
                    {
                        SpecialId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["SpecialId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectBySpecialId("Special_SelectBySpecialId", SpecialId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LContentName.Text = dt.Tables[0].Rows[0]["ContentName"].ToString();
                    LScore.Text = dt.Tables[0].Rows[0]["Score"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();

                DataSet dy = bus.SelectBySpecialId("SpecialExamine_Select", SpecialId);
                if (dy != null)
                {
                    dataOfYear.DataSource = dy;
                    dataOfYear.DataBind();
                    dy.Dispose();
                }
            }
        }
     
    }
}