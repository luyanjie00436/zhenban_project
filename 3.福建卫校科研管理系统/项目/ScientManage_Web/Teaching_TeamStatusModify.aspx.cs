using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Teaching_TeamStatusModify : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int Teaching_TeamId;
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
                if (Request.QueryString["Teaching_TeamId"] != null)
                {
                    try
                    {
                        Teaching_TeamId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Teaching_TeamId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByTeaching_TeamId("Teaching_Team_SelectByTeaching_TeamId", Teaching_TeamId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LTeaching_TeamName.Text = dt.Tables[0].Rows[0]["Teaching_TeamName"].ToString();
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
                DataTable Partdt = bus.SelectByTeaching_TeamId("Teaching_TeamPartner_SelectByTeaching_TeamId", Teaching_TeamId).Tables[0];
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
                
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            Teaching_TeamId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Teaching_TeamId"], "asdfasdf"));
            DataSet dy = bus.SelectByTeaching_TeamId("Teaching_TeamExamine_Select", Teaching_TeamId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Teaching_TeamId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Teaching_TeamId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.Teaching_TeamStatusModifyInsert("Teaching_TeamStatusModify_Insert", Teaching_TeamId, ExamineOpinion, UserCardId, "同意"))
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
            Teaching_TeamId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Teaching_TeamId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);

            if (bus.Teaching_TeamStatusModifyInsert("Teaching_TeamStatusModify_Insert", Teaching_TeamId, ExamineOpinion, UserCardId, "拒绝"))
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