using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class ShortProjectsApprovalManage : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
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

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("ShortProjects_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
        //项目添加
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            string url = "/ShortProjectsApprovalAdd.aspx";
        
            Response.Redirect(url);

        }

        //刷新
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        //查看项目详情
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortProjectsApprovalDetailed.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }
        //修改
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            string url = "/ShortProjectsApprovalAdd.aspx?ShortProjectsId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");
            Response.Redirect(url);

        }
        //查看下载附件
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != null)
            {
                string path = Server.MapPath("./") + e.CommandArgument.ToString();
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
            else
            {
                Response.Write("<script>alert('该项目无附件，无法下载！')</script>");
                return;
            }
        }
        //删除项目
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            if (bus.ShortProjectsDelete("ShortProjects_Delete", e.CommandArgument.ToString()))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('调配流程已经启动，禁止删除！')</script>");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ShortProjectsDeclareManage.aspx");
        }
    }
}