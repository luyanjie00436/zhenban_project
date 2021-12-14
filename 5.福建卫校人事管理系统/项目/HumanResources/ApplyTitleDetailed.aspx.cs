using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ApplyTitleDetailed : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        int ApplyTitleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);//remain

                }
                catch (Exception)
                {

                    Response.Redirect("Login.aspx");
                }

                if (Request.QueryString["ApplyTitle"] != null)
                {
                    try
                    {
                        ApplyTitleId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyTitle"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByApplyTitleIdId("ApplyTitle_SelectByApplyTitleId", ApplyTitleId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtApplyReason.Text = dt.Tables[0].Rows[0]["ApplyReason"].ToString();
                    DLDepartment.Text = dt.Tables[0].Rows[0]["DepartmentName"].ToString();
                    DLApplyTitle.Text = dt.Tables[0].Rows[0]["Job"].ToString();
                    DLPost.Text = dt.Tables[0].Rows[0]["Post"].ToString();
                    LBApplyDate.Text = dt.Tables[0].Rows[0]["ApplyDate"].ToString();
                    txtTitleSeries.Value = dt.Tables[0].Rows[0]["TitleSeries"].ToString();
                    txtMajor.Value = dt.Tables[0].Rows[0]["Major"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
                LUserCardId.Text = ds.Tables[0].Rows[0]["工号"].ToString();
                LStartWork.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();
                LUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                LBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
                 
                LGender.Text = ds.Tables[0].Rows[0]["性别"].ToString();
                 

                LNation.Text = ds.Tables[0].Rows[0]["民族"].ToString();
                LPolitical.Text = ds.Tables[0].Rows[0]["政治面貌"].ToString();
                LEducation.Text = ds.Tables[0].Rows[0]["第一学历"].ToString();
                LDegree.Text = ds.Tables[0].Rows[0]["第一学位"].ToString();
                ApplyTitleId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyTitle"], "asdfasdf"));
                txtAverageFraction.Text = bus.ApplyTitleFractionAandN("ApplyTitle_FractionAandN", ApplyTitleId).Tables[0].Rows[0]["AvgNum"].ToString();
                textScorePerNum.Text = bus.ApplyTitleFractionAandN("ApplyTitle_FractionAandN", ApplyTitleId).Tables[0].Rows[0]["PersonNum"].ToString();
                if (txtAverageFraction.Text == "")
                {
                    txtAverageFraction.Text = "0";
                }
                DataSet dy = bus.SelectByApplyTitleId("ApplyTitle_SelectByApplyTitleId", ApplyTitleId);
                //dataOfYear.DataSource = dy;
                //dataOfYear.DataBind();
                dy.Dispose();
               
                dataGriviewBD();
            }

        }
        public void dataGriviewBD()
        {
            ApplyTitleId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyTitle"], "asdfasdf"));
            DataTable dt = bus.Scdwcx("ApplyTitle_AppendixByApplyTitleId", ApplyTitleId).Tables[0];
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            int imagesurl1 = int.Parse(e.CommandArgument.ToString());
            Response.Write("<script>window.open('yl.aspx?fileid=" + imagesurl1 + "');</script>");
            //  Response.Redirect("yl.aspx?fileid=" + imagesurl1);
        }
    }
}