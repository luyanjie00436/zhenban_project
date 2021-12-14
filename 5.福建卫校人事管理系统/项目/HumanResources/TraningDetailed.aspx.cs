using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class TraningDetailed : System.Web.UI.Page
    {

        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int TraningId;
        int TraningFurId;
        string LearningType;
        string LearningStyle;
        string LearningUnit;
        string StartDate;
        string EndDate;
        float Fund1;
        float Fund2;
        float Fund3;
        float Fund4;
        float FunOri1;
        float FunOri2;
        float FunOri3;
        float FunOri4;
        float FunOri5;
        string LeaveDate = DateTime.Now.ToString("yyyy-MM-dd");
        string IsCertficateOrUnit;
        string TraningFurTime;
        string TraningFurUnit;
        string TraningFurContent;
        string TraningFurShape;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                    //txtStartDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                }
                catch (Exception)
                {

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TraningAdd.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }


                if (Request.QueryString["Traning"] != null)
                {
                    try
                    {
                        TraningId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Traning"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    DataSet dt = bus.SelectByTraningId("Traning_SelectByTraningId", TraningId);
                    UserCardId = dt.Tables[0].Rows[0]["UserCardId"].ToString();

                }
                DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
                DataSet ds2 = bus.userInfoS2(TraningId);
                txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
                txtSex.Text = ds.Tables[0].Rows[0]["性别"].ToString();
                txtBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
                txtUserEducation.Text = ds.Tables[0].Rows[0]["最高学历"].ToString();//学历
                txtUserSpecialty.Text = ds.Tables[0].Rows[0]["最高学历专业"].ToString();//专业
                txtUserSchool.Text = ds.Tables[0].Rows[0]["最高学历毕业院校"].ToString();//毕业学校
                txtUserSchoolTime.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();//入校时间
                RadioButtonList1.Text = ds2.Tables[0].Rows[0]["LearningType"].ToString();
                RadioButtonList2.Text = ds2.Tables[0].Rows[0]["LearningStyle"].ToString();
                IsCertficateOrUnit1.Text = ds2.Tables[0].Rows[0]["IsCertficateOrUnit"].ToString();
                DTtxtLearningUnit.Text = ds2.Tables[0].Rows[0]["LearningUnit"].ToString();
                DTtxtStartDate.Text= ds2.Tables[0].Rows[0]["StartDate"].ToString();
                DTtxtEndDate.Text= ds2.Tables[0].Rows[0]["EndDate"].ToString();
                DTtxtysFee.Text = ds2.Tables[0].Rows[0]["Fund1"].ToString();
                DTtxtpyFee.Text = ds2.Tables[0].Rows[0]["Fund2"].ToString();
                DTtxtclFee.Text = ds2.Tables[0].Rows[0]["Fund3"].ToString();
                DTtxtotFee.Text = ds2.Tables[0].Rows[0]["Fund4"].ToString();
                DTtxtFund1.Text = ds2.Tables[0].Rows[0]["FunOri1"].ToString();
                DTtxtFund2.Text = ds2.Tables[0].Rows[0]["FunOri2"].ToString();
                DTtxtFund3.Text = ds2.Tables[0].Rows[0]["FunOri3"].ToString();
                DTtxtFund4.Text = ds2.Tables[0].Rows[0]["FunOri4"].ToString();
                DTtxtFund5.Text = ds2.Tables[0].Rows[0]["FunOri5"].ToString();
                dataGriviewBD();

            }

        }



        public void dataGriviewBD()
        {
            DataTable dt;
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            dt = bus.SelectTraningFurByUserCardId("TraningFur_SelectByUserCardId", UserCardId).Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridViewEmployee.DataSource = dt;
                GridViewEmployee.DataBind();
                int columnCount = GridViewEmployee.Rows[0].Cells.Count;
                GridViewEmployee.Rows[0].Cells.Clear();
                GridViewEmployee.Rows[0].Cells.Add(new TableCell());
                GridViewEmployee.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridViewEmployee.Rows[0].Cells[0].Text = "暂时没有数据信息";
                GridViewEmployee.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            }
            else
            {
                GridViewEmployee.DataSource = dt;
                GridViewEmployee.DataBind();

            }

        }

        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }

}