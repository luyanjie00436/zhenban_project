using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Login : System.Web.UI.Page
   {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtLoginUserPwd.Value.Trim().ToString(), "MD5");
        int message = bus.Login(txtLoginUserCardId.Value.Trim(), pwd);
        if (message.Equals(0)) //登陆成功
        {
            //DataSet ds = bus.userInfoS(txtLoginUserCardId.Text);
            //Response.Cookies["selectUserCardId"].Value = txtLoginUserCardId.Text.Trim();
            //Response.Cookies["UserRoleId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
            //Response.Cookies["UserCardId"].Value = txtLoginUserCardId.Text.Trim();
            //Response.Cookies["UserRoleId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
            //Response.Cookies["UserName"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserName"].ToString());
            //Response.Cookies["UserDepartmentId"].Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["UserDepartmentId"].ToString());
            //Response.Cookies["selectUserCardId"].Expires = DateTime.Now.AddDays(1);
            //Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
            //Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
            HttpCookie cok3 = new HttpCookie("RankId");
            cok3.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cok3);
            Response.Cookies["UserCardId"].Value = HttpUtility.UrlEncode(txtLoginUserCardId.Value);
            Response.Cookies["UserCardId"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("Default.aspx");
        }
        else //登陆失败
        {
            if (message.Equals(1))
            {

                Response.Write("<script>alert('密码错误')</script>");
            }
            else if (message.Equals(2))
            {
                Response.Write("<script>alert('用户不存在')</script>");
            }
            else if (message.Equals(3))
            {

                Response.Write("<script>alert('用户已被锁定，禁止登陆')</script>");
            }
            else if (message.Equals(5))
            {
                Response.Write("<script>alert('您的账号禁止登陆此系统，请联系科研处进行登陆！')</script>");

            }
            else
            {
                Response.Write("<script>alert('系统错误')</script>");
            }
            txtLoginUserPwd.Value = "";
        }
    }
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {

            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明 - 普通教职工.docx";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();
            }

        }
        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明 - 系部管理员.docx";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明 - 学院领导.docx";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明 - 系统管理员.docx";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
        protected void LinkButton5_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明 - 专家.docx";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.WriteFile(fi.FullName);
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
        protected void LinkButton10_Click(object sender, EventArgs e)
    {
        txtLoginUserCardId.Value = "";
        txtLoginUserPwd.Value = "";
    }
 
}
}

 