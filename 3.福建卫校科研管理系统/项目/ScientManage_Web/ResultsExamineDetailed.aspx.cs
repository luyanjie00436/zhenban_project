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
    public partial class ResultsExamineDetailed : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int ResultsId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (Request.QueryString["ResultsId"] != null)
                {
                    try
                    {
                        ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByResultsId("Results_SelectByResultsId", ResultsId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LResultsName.Text = dt.Tables[0].Rows[0]["ResultsName"].ToString();
                    LCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    LAwardlevel.Text = dt.Tables[0].Rows[0]["Awardlevel"].ToString();
                    LResultsPrincipal.Text = dt.Tables[0].Rows[0]["ResultsPrincipal"].ToString();
                    LAwarding_unit.Text = dt.Tables[0].Rows[0]["Awarding_unit"].ToString();
                    Ltime.Text = dt.Tables[0].Rows[0]["time"].ToString();
                    LCompletion.Text = dt.Tables[0].Rows[0]["Completion"].ToString();
                    LResultsTotal.Text = dt.Tables[0].Rows[0]["ResultsTotal"].ToString();
                    LResultsDescription.Text = dt.Tables[0].Rows[0]["ResultsDescription"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LResultsValue.Text = dt.Tables[0].Rows[0]["ResultsValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["ResultsUrl"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable Partdt = bus.SelectByResultsId("ResultsPartner_SelectByResultsId", ResultsId).Tables[0];
               // 合作者列表
                if (Partdt.Rows.Count == 0)
                {
                    LPartner.Text = "无";
                }
                else
                {
                    for (int i = 0; i < Partdt.Rows.Count; i++)
                    {
                        if (i == Partdt.Rows.Count - 1)
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")";
                        }
                        else
                        {
                            LPartner.Text += Partdt.Rows[i]["UserName"] + "(" + Partdt.Rows[i]["PartnerValue"] + ")" + ",";
                        }
                    }
                }
                DataTable dt1 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                LUserName.Text = dt1.Rows[0]["UserName"].ToString();
                if (LFileUrl.Text == "")
                {
                    LinkButton1.Visible = false;
                }
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
            DataSet dy = bus.SelectByResultsId("ResultsExamine_Select", ResultsId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.ResultsExamineInsert("ResultsExamine_Insert", ResultsId, ExamineOpinion, UserCardId, "同意", RankId))
            {
                AlertMsgAndNoFlush("审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush("审批失败");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.ResultsExamineInsert("ResultsExamine_Insert", ResultsId, ExamineOpinion, UserCardId, "拒绝", RankId))
            {
                AlertMsgAndNoFlush("审批成功");
                dataGriviewBD();
            }
            else
            {
                AlertMsgAndNoFlush("审批失败");
            }

        }
        public void AlertMsgAndNoFlush(string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
            //ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
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