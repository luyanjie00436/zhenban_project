using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class Login : System.Web.UI.Page
{

        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
    sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet Rank = bus.Select("Rank_Select");
            foreach (DataRow dr in Rank.Tables[0].Rows)
            {
                ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                DlRank.Items.Add(li);
            }
        }
    }
   


    protected void reset_Click(object sender, ImageClickEventArgs e)
    {
        txtLoginUserCardId.Value = "";
        txtLoginUserPwd.Value = "";
    }
    public static void AlertMsgAndNoFlush(Control controlName, string message)
    {
        ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
    }

  

   
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {

        string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明  - 普通教职工.docx";
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
        string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明  - 系部领导.docx";
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
        string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明  - 职能部门领导.docx";
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
        string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明  - 评审专家.docx";
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

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        int RankId = Convert.ToInt32(DlRank.SelectedItem.Value);
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtLoginUserPwd.Value.Trim().ToString(), "MD5");
        int message = bus.Login(txtLoginUserCardId.Value.Trim(), pwd, RankId);
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
            Response.Cookies["RankId"].Value = HttpUtility.UrlEncode(RankId.ToString());
            Response.Cookies["UserCardId"].Value = HttpUtility.UrlEncode(txtLoginUserCardId.Value);
            Response.Redirect("Default.aspx");
        }
        else //登陆失败
        {
            if (message.Equals(1))
            {

                AlertMsgAndNoFlush(UpdatePanel1, "密码错误");
            }
            else if (message.Equals(2))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "用户不存在");
            }
            else if (message.Equals(4))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "角色错误");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "系统错误");
            }
        }
        txtLoginUserPwd.Value = "";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        txtLoginUserCardId.Value = "";
        txtLoginUserPwd.Value = "";
    }
}
}

 