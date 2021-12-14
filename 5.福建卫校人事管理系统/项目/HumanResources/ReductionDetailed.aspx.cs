using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ReductionDetailed : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ReductionId;
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
                    Response.Redirect("Login.aspx");
                }

                if (Request.QueryString["Reduction"] != null)
                {
                    try
                    {
                        ReductionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Reduction"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }

                    //DataSet dt = bus.SelectByReductionId("Reduction_SelectByReductionId", ReductionId);
                    //UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    //txtStopDate.Value = dt.Tables[0].Rows[0]["StopDate"].ToString();
                    //txtReason.Text = dt.Tables[0].Rows[0]["Reason"].ToString();

                    DataSet ds = bus.SelectByReductionId("ReductionView_SelectByUserCardId", ReductionId);
                    ReductionId = ds.Tables[0].Rows[0]["编号"].GetHashCode();
                    LApplyYear.Text = ds.Tables[0].Rows[0]["年份"].ToString();
                    LUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                
                    LRatedOne.Text = ds.Tables[0].Rows[0]["教学额定工作量"].ToString();
                    LReductionOne.Text = ds.Tables[0].Rows[0]["教学减免后工作量"].ToString();
                    LProportionOne.Text = ds.Tables[0].Rows[0]["教学减免比例"].ToString();

                    LRatedTwo.Text = ds.Tables[0].Rows[0]["教学建设额定工作量"].ToString();
                    LReductionTwo.Text = ds.Tables[0].Rows[0]["教学建设减免后工作量"].ToString();
                    LProportionTwo.Text = ds.Tables[0].Rows[0]["教学建设减免比例"].ToString();

                    LRatedThree.Text = ds.Tables[0].Rows[0]["社会额定工作量"].ToString();
                    LReductionThree.Text = ds.Tables[0].Rows[0]["社会减免后工作量"].ToString();
                    LProportionThree.Text = ds.Tables[0].Rows[0]["社会减免比例"].ToString();

                    LWhetherStop.Text = ds.Tables[0].Rows[0]["是否停发相应岗位津贴"].ToString();
                    LStopProportion.Text = ds.Tables[0].Rows[0]["停发比例"].ToString();
                    txtStopDate.Value = ds.Tables[0].Rows[0]["停发时间"].ToString();
                    txtReason.Text = ds.Tables[0].Rows[0]["理由"].ToString();

                }
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}

            }
        }

        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}