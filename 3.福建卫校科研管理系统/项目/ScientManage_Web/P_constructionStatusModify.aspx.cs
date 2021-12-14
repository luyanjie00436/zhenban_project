using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class P_constructionStatusModify : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int P_constructionId;
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
                if (Request.QueryString["P_constructionId"] != null)
                {
                    try
                    {
                        P_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["P_constructionId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByP_constructionId("P_construction_SelectByP_constructionId", P_constructionId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LP_constructionName.Text = dt.Tables[0].Rows[0]["P_constructionName"].ToString();
                    LLeve.Text = dt.Tables[0].Rows[0]["Leve"].ToString();
                    LPrincipal.Text = dt.Tables[0].Rows[0]["Principal"].ToString();
                    LCompletion.Text = dt.Tables[0].Rows[0]["Completion"].ToString();
                    LTotal_Project.Text = dt.Tables[0].Rows[0]["Total_Project"].ToString();
                    LDescription_Project.Text = dt.Tables[0].Rows[0]["Description_Project"].ToString();
                    LAnnual.Text = dt.Tables[0].Rows[0]["Annual"].ToString();
                    LDescription_year.Text = dt.Tables[0].Rows[0]["Description_year"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable Partdt = bus.SelectByP_constructionId("P_constructionPartner_SelectByP_constructionId", P_constructionId).Tables[0];
                //合作者列表
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

                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            P_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["P_constructionId"], "asdfasdf"));
            DataSet dy = bus.SelectByP_constructionId("P_constructionExamine_Select", P_constructionId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            P_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["P_constructionId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.P_constructionStatusModifyInsert("P_constructionStatusModify_Insert", P_constructionId, ExamineOpinion, UserCardId, "同意"))
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
            P_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["P_constructionId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.P_constructionStatusModifyInsert("P_constructionStatusModify_Insert", P_constructionId, ExamineOpinion, UserCardId, "拒绝"))
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
       
    }
}