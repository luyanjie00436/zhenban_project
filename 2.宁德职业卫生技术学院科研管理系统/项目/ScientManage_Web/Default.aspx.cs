using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class Default : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        DataTable dt;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                menu_bind();
            }
        }
        public void menu_bind()
        {
            try
            {

                RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                dt = bus.SelectByRankId("AuthorityView_Select", RankId).Tables[0];
                DataRow[] rows = dt.Select("ModelFatherId=" + 0);
                if (rows.Length > 0)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        MenuItem pNode = new MenuItem();
                        pNode.Value = rows[i]["ModelId"].ToString();
                        pNode.Text = rows[i]["ModelName"].ToString();
                        pNode.NavigateUrl = rows[i]["ModelUrl"].ToString();
                        pNode.Enabled = true;
                        pNode.Target = "center";
                        top_menu.Items.Add(pNode);
                        int pid = Convert.ToInt32(rows[i]["ModelId"]);
                        this.FillMenu(pNode, pid);

                    }
                }
            }
            catch
            {

            }
        }
        protected void FillMenu(MenuItem pNode, int pid)
        {
            DataRow[] rows = dt.Select("ModelFatherId=" + pid + "");
            if (rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    MenuItem cNode = new MenuItem();
                    cNode.Value = rows[i]["ModelId"].ToString();
                    cNode.Text = rows[i]["ModelName"].ToString();
                    cNode.NavigateUrl = rows[i]["ModelUrl"].ToString();
                    cNode.Enabled = true;
                    cNode.Target = "center";
                    pNode.ChildItems.Add(cNode);
                    pid = Convert.ToInt32(rows[i]["ModelId"]);
                    FillMenu(cNode, pid);
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            HttpCookie cok1 = new HttpCookie("UserCardId");
            HttpCookie cok2 = new HttpCookie("UserName");

            cok1.Expires = DateTime.Now.AddHours(-1);
            cok2.Expires = DateTime.Now.AddHours(-1);

            Response.Cookies.Add(cok1);
            Response.Cookies.Add(cok2);
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "e", "<script language=javascript>history.go(-1);</script>", true);
            // RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
              Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
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
            string path = Server.MapPath("./") + "InstructionsForUse/科研工作管理系统使用说明  - 系统管理员.docx";
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
    }
}