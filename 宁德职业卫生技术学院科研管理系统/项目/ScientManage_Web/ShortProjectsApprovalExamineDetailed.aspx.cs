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
    public partial class ShortProjectsApprovalExamineDetailed : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        string ShortProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["ShortProjectsId"] != null)
                {
                    try
                    {
                        ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByShortProjectsId("ShortProjects_SelectByShortProjectsId", ShortProjectsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LContractDate.Text = dt.Tables[0].Rows[0]["ContractDate"].ToString();
                    LContractId.Text = dt.Tables[0].Rows[0]["ContractId"].ToString();
                    LContractMoney.Text = dt.Tables[0].Rows[0]["ContractMoney"].ToString();
                    LContractName.Text = dt.Tables[0].Rows[0]["ContractName"].ToString();
                    LAAddress.Text = dt.Tables[0].Rows[0]["AAddress"].ToString();
                    LACompany.Text = dt.Tables[0].Rows[0]["ACompany"].ToString();
                    LAUserName.Text = dt.Tables[0].Rows[0]["AUserName"].ToString();
                    LAPhoneNumber.Text = dt.Tables[0].Rows[0]["APhoneNumber"].ToString();
                    LBAddress.Text = dt.Tables[0].Rows[0]["BAddress"].ToString();
                    LBCompany.Text = dt.Tables[0].Rows[0]["BCompany"].ToString();
                    LBPhoneNumber.Text = dt.Tables[0].Rows[0]["BPhoneNumber"].ToString();
                    LBUserName.Text = dt.Tables[0].Rows[0]["BUserName"].ToString();
                    LExplain.Text = dt.Tables[0].Rows[0]["Explain"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["FileUrl"].ToString();
                    
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
            DataSet dy = bus.SelectByShortProjectsId("ShortProjectsApprovalExamine_Select", ShortProjectsId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }
           

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.ShortProjectsDeclareExamineInsert("ShortProjectsApprovalExamine_Insert", ShortProjectsId, ExamineOpinion, UserCardId, "审批通过", RankId))
            {
                Response.Write("<script>alert('审批成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('审批失败！')</script>");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.ShortProjectsDeclareExamineInsert("ShortProjectsApprovalExamine_Insert", ShortProjectsId, ExamineOpinion, UserCardId, "审批未通过", RankId))
            {
                Response.Write("<script>alert('审批成功！')</script>");
                dataGriviewBD();
            }
            else
            {
                Response.Write("<script>alert('审批失败！')</script>");
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (LFileUrl.Text != "null")
            {
                string path = Server.MapPath("./") + LFileUrl.Text;
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
                Response.Write("<script>alert('未上传附件，无法下载！')</script>");
                return;
            }
        }
    
    }
}