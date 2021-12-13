using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class AssessRankUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int AssessRankId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessRankId = Convert.ToInt32(Request.QueryString["AssessRank"]);
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
                TeachingChange();
                DataSet ds = bus.SelectByAssessRankId("AssessRank_SelectByAssessRankId", AssessRankId);        
                DLTeaching.SelectedValue= ds.Tables[0].Rows[0]["JobId"].ToString();
                txtRankName.Text = ds.Tables[0].Rows[0]["RankName"].ToString();
                txtMinValue.Text = ds.Tables[0].Rows[0]["RankMinValue"].ToString();
                txtMaxValue.Text = ds.Tables[0].Rows[0]["RankMaxValue"].ToString();
                txtExplain.Text = ds.Tables[0].Rows[0]["RankExplain"].ToString();
                
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            AssessRankId = Convert.ToInt32(Request.QueryString["AssessRank"]);
            string Teaching = DLTeaching.SelectedItem.Text.Trim().ToString();
           int JobId =Convert.ToInt32( DLTeaching.SelectedValue);  //JobId,用于输入
            string RankName = txtRankName.Text.Trim();
            string RankMinValue = txtMinValue.Text.Trim();
            string RankMaxValue = txtMaxValue.Text.Trim();
            string Explain = txtExplain.Text.Trim();
            double MinValue = 0;
            double MaxValue = 0;
            if(Teaching == "==请选择=="){
                AlertMsgAndNoFlush(UpdatePanel1, "请填写职称");
                return;
            }
            if (RankName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写考核等级名称");
                return;
            }
            if (RankMinValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写最小需求分值");
                return;
            }
            try
            {
                MinValue = Convert.ToDouble(RankMinValue);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "最小需求分值请输入正整数");
                return;
            }
            if (MinValue < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最小需求分值请输入正整数");
                return;
            }
            if (RankMaxValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写最大需求分值");
                return;
            }
            try
            {
                MaxValue = Convert.ToDouble(RankMaxValue);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "最大需求分值请输入正整数");
                return;
            }
            if (MaxValue < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "最大需求分值请输入正整数");
                return;
            }
            if(MinValue > MaxValue){
                AlertMsgAndNoFlush(UpdatePanel1, "最大需求分值应该不小于最小需求分值");
                return;
            }


            if (Explain == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写说明");
                return;
            }
            if (bus.AssessRankUpdate("AssessRank_Update", AssessRankId, JobId, RankName, MinValue, MaxValue, Explain,UserCardId))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");

            }
        }        

        private void TeachingChange()
        {
            DLTeaching.Items.Add("==请选择==");
            DLTeaching.Items[0].Value = "0";
            DataTable ds = bus.Select("Job_Select").Tables[0];
            if (ds.Rows.Count > 0 && ds.Columns.Count > 1)
            {
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["JobName"].ToString(), dr["JobId"].ToString());   //添加数据
                    DLTeaching.Items.Add(li);
                }
            }        
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
       
    }
}