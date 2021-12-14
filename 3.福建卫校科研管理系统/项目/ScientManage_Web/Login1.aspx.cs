using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();

        string serverUrl = "/Login.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUser = Request.QueryString["currentUserCookie"];//工号参数

            if (Request.Cookies[currentUser] != null)
            {
                currentUser = Request.Cookies[currentUser].Value;//获取工号值


                if (string.IsNullOrEmpty(currentUser) || string.IsNullOrEmpty(currentUser.Trim()))
                {
                    Response.Write("<script>alert('您的账号暂时无法登陆科研系统，请与科研处联系！！');" + "location.href='" + serverUrl + "'<" + "/script>");
                    return;
                }


                string cwaccount = getCWAccountByGh(currentUser);

                if (string.IsNullOrEmpty(cwaccount) || string.IsNullOrEmpty(cwaccount.Trim()))
                {
                    Response.Write("<script>alert('您的账号暂时无法登陆科研系统，请与科研处联系！！');" + "location.href='" + serverUrl + "'<" + "/script>");
                    return;
                }
                else
                {

                    Login1_Authenticate(cwaccount);
                }
            }
            else
            {
                Response.Write("<script>location.href='" + serverUrl + "'<" + "/script>");
            }

        }
        /// <summary>
        /// 通过工号，查询对照表，得到科研系统账号
        /// </summary>
        /// <param name="gh"></param>
        /// <returns></returns>
        protected string getCWAccountByGh(string currentUser)
        {
            System.Data.DataTable ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", currentUser).Tables[0];
            string UserCardId = "";
            if (ds.Rows.Count > 0 && ds.Rows[0]["UserEnable"].ToString() == "已启用")
            {
                UserCardId = ds.Rows[0]["UserCardId"].ToString();
            }
            return UserCardId;
        }


        // login
        protected void Login1_Authenticate(string cwaccount)
        {
            string pagenames = Request.QueryString["pagenames"];
            pagenames = Request.Cookies[pagenames].Value;
            pagenames = pagenames + ".aspx";
            Response.Cookies["UserCardId"].Value = HttpUtility.UrlEncode(cwaccount);
            Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
            //HttpCookie cok3 = new HttpCookie("RankId");
            //cok3.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cok3);
            //  base.Response.Redirect("/Default.aspx");
            Response.Redirect(pagenames);
            // Response.Write("<script>location.href='Default.aspx'<" + "/script>");
        }
    }
}