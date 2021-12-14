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
    public partial class Default : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int pid;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Rank2 = bus.SelectByUserCardId("UserRank_SelectByUserCardId", UserCardId);
                foreach (DataRow dr in Rank2.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["RankName"].ToString(), dr["RankId"].ToString());
                    DlRank.Items.Add(li);
                }

                try
                {
                   // RankId = Convert.ToInt32(DlRank.SelectedValue);
                    //  Response.Cookies["RankId"].Value = HttpUtility.UrlEncode(RankId.ToString());
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                    DlRank.SelectedValue = RankId.ToString();

                }
                catch (Exception)
                {

                    RankId = Convert.ToInt32(DlRank.SelectedValue);
                    Response.Cookies["RankId"].Value = HttpUtility.UrlEncode(RankId.ToString());
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

                        if (rows[i]["ModelUrl"].ToString()=="")
                        {
                            pNode.NavigateUrl = "javascript:void(0)";
                        }
                        else
                        {
                            pNode.NavigateUrl = rows[i]["ModelUrl"].ToString();
                        }
                       
                        pNode.Enabled = true;
                        pNode.Target = "center";
                      
                        top_menu.Items.Add(pNode);
                        // mnuleftMenu.Items.Add(pNode);

                        pid = Convert.ToInt32(rows[i]["ModelId"]);
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

                    if (rows[i]["ModelUrl"].ToString() == "")
                    {
                        cNode.NavigateUrl = "javascript:void(0)";
                    }
                    else
                    {
                        cNode.NavigateUrl = rows[i]["ModelUrl"].ToString();
                    }
                   
                    cNode.Enabled = true;
                    cNode.Target = "center";
                    pNode.ChildItems.Add(cNode);
                    pid = Convert.ToInt32(rows[i]["ModelId"]);
                    FillMenu(cNode, pid);
                }
            }
        }

        protected void DlRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankId = Convert.ToInt32(DlRank.SelectedValue);
            Response.Cookies["RankId"].Value = HttpUtility.UrlEncode(RankId.ToString());
            Response.Cookies["RankId"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("Default.aspx");
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

        protected void top_menu_Load(object sender, EventArgs e)
        {
            Response.Write("<script>  iFrameHeight() <" + "/script>");
              
          
        }
    }
}