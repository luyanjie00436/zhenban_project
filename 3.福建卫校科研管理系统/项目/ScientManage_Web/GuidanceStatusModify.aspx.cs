using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class GuidanceStatusModify : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int RankId;
        int GuidanceId;
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
                if (Request.QueryString["GuidanceId"] != null)
                {
                    try
                    {
                        GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    DataSet dt = bus.SelectByGuidanceId("Guidance_SelectByGuidanceId", GuidanceId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    LGuidanceName.Text = dt.Tables[0].Rows[0]["GuidanceName"].ToString();
                    LRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LGuidanceLevel.Text = dt.Tables[0].Rows[0]["GuidanceLevel"].ToString();
                    LGuidanceValue.Text = dt.Tables[0].Rows[0]["GuidanceValue"].ToString();
                    LTransferStatus.Text = dt.Tables[0].Rows[0]["TransferStatus"].ToString();
                    
                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataTable Partdt = bus.SelectByGuidanceId("GuidancePartner_SelectByGuidanceId", GuidanceId).Tables[0];
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
               
            }
        }
        public void dataGriviewBD()
        {
            GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
            DataSet dy = bus.SelectByGuidanceId("GuidanceExamine_Select", GuidanceId);
            dataOfYear.DataSource = dy;
            if (dy != null)
            {
                dataOfYear.DataBind();
                dy.Dispose();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.GuidanceStatusModifyInsert("GuidanceStatusModify_Insert", GuidanceId, ExamineOpinion, UserCardId, "同意"))
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
            GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
            RankId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["RankId"].Value));
            string ExamineOpinion = txtExamineOpinion.Text.Trim().ToString();
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.GuidanceStatusModifyInsert("GuidanceStatusModify_Insert", GuidanceId, ExamineOpinion, UserCardId, "拒绝"))
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