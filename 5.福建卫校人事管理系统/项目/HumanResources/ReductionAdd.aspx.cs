using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ReductionAdd : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        string UserCardId;
        int ReductionId;
        protected static string type;
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
                //DataSet UserRole = bus.SelectByUserCardId("UserRole_SelectByUserCardId", UserCardId);
                //foreach (DataRow dr in UserRole.Tables[0].Rows)
                //{
                //    ListItem li = new ListItem(dr["DepartmentName"].ToString() + dr["RoleName"].ToString(), dr["UserRoleId"].ToString());
                //    RBUserRole.Items.Add(li);
                //}
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ReductionAdd.aspx") == 0)
                //{
                //    Response.Redirect("Login.aspx");
                //}


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
                    Button1.Visible = false;
                    //DataSet dt = bus.SelectByReductionId("Reduction_SelectByReductionId", ReductionId);
                    DataSet dt = bus.SelectByReductionId("Reduction_SelectByReductionId", ReductionId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtRatedOne.Value = dt.Tables[0].Rows[0]["RatedOne"].ToString();
                    txtReductionOne.Value = dt.Tables[0].Rows[0]["ReductionOne"].ToString();
                    txtProportionOne.Value = dt.Tables[0].Rows[0]["ProportionOne"].ToString();

                    txtRatedTwo.Value = dt.Tables[0].Rows[0]["RatedTwo"].ToString();
                    txtReductionTwo.Value = dt.Tables[0].Rows[0]["ReductionTwo"].ToString();
                    txtProportionTwo.Value = dt.Tables[0].Rows[0]["ProportionTwo"].ToString();

                    txtRatedThree.Value = dt.Tables[0].Rows[0]["RatedThree"].ToString();
                    txtReductionThree.Value = dt.Tables[0].Rows[0]["ReductionThree"].ToString();
                    txtProportionThree.Value = dt.Tables[0].Rows[0]["ProportionThree"].ToString();
                   
                    txtWhetherStop.Text = dt.Tables[0].Rows[0]["WhetherStop"].ToString();
                    txtStopProportion.Value = dt.Tables[0].Rows[0]["StopProportion"].ToString();
                    txtStopDate.Text = dt.Tables[0].Rows[0]["StopDate"].ToString();
                    txtReason.Text = dt.Tables[0].Rows[0]["Reason"].ToString();

                    dt = bus.SelectByUserCardId("UseJobPostView_SelectByUserCardIdCurrent", UserCardId);
                    txtUserName.Text = dt.Tables[0].Rows[0]["姓名"].ToString();
                     huoqu(dt.Tables[0].Rows[0]["工号"].ToString());
                }
                else
                {
                    Button2.Visible = false;
                }
            }
        }
        protected void huoqu(string UserCardId)
        {
            DataSet dt = bus.Select("ApplyYear_SelectisApply");
            txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
            txtStopDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = txtUserCardId.Text;
            string ApplyYear = txtApplyYear.Text;

            string RatedOne = txtRatedOne.Value;
            string ReductionOne = txtReductionOne.Value;
            string ProportionOne = txtProportionOne.Value;

            string RatedTwo = txtRatedTwo.Value;
            string ReductionTwo = txtReductionTwo.Value;
            string ProportionTwo = txtProportionTwo.Value;

            string RatedThree = txtRatedThree.Value;
            string ReductionThree = txtReductionThree.Value;
            string ProportionThree = txtProportionThree.Value;

            string WhetherStop = txtWhetherStop.Text;
            string StopProportion = txtStopProportion.Value;
            string StopDate = txtStopDate.Text;
            string Reason = txtReason.Text;
         
            if (RatedOne == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学额定工作量");
                return;
            }

            if (ReductionOne == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学减免后工作量");
                return;
            }
            if (RatedTwo == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学建设与研究类额定工作量");
                return;
            }

            if (ReductionTwo == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学建设与研究类减免后工作量");
                return;
            }
            if (RatedThree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入社会额定工作量");
                return;
            }

            if (ReductionThree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入社会减免后工作量");
                return;
            }
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入减免工作量理由");
                return;
            }



            if (bus.ReductionInsert("Reduction_Insert", UserCardId, Reason, RatedOne, ReductionOne, ProportionOne, RatedTwo, ReductionTwo, ProportionTwo, RatedThree, ReductionThree, ProportionThree, WhetherStop, StopProportion, StopDate))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！");
            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ApplyYear = txtApplyYear.Text;

            string RatedOne = txtRatedOne.Value;
            string ReductionOne = txtReductionOne.Value;
            string ProportionOne = txtProportionOne.Value;

            string RatedTwo = txtRatedTwo.Value;
            string ReductionTwo = txtReductionTwo.Value;
            string ProportionTwo = txtProportionTwo.Value;

            string RatedThree = txtRatedThree.Value;
            string ReductionThree = txtReductionThree.Value;
            string ProportionThree = txtProportionThree.Value;

            string WhetherStop = txtWhetherStop.Text;
            string StopProportion = txtStopProportion.Value;
            string StopDate = txtStopDate.Text;
            string Reason = txtReason.Text;
           
            if (RatedOne == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学额定工作量");
                return;
            }

            if (ReductionOne == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学减免后工作量");
                return;
            }
            if (RatedTwo == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学建设与研究类额定工作量");
                return;
            }

            if (ReductionTwo == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入教学建设与研究类减免后工作量");
                return;
            }
            if (RatedThree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入社会额定工作量");
                return;
            }

            if (ReductionThree == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入社会减免后工作量");
                return;
            }
            if (Reason == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入减免工作量理由");
                return;
            }
            ReductionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Reduction"], "asdfasdf"));
            if (bus.ReductionUpdate("Reduction_Update", ReductionId, Reason, RatedOne, ReductionOne, ProportionOne, RatedTwo, ReductionTwo, ProportionTwo, RatedThree, ReductionThree, ProportionThree, WhetherStop, StopProportion, StopDate))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("ReductionManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;

            DataTable dt = bus.SelectByUserName("UserInfo_SelectByUserName", UserName).Tables[0];
            DlName.Items.Clear();
            DlName.Items.Add("请选择");
            DlName.Items[0].Value = "0";
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["姓名"].ToString(), dr["工号"].ToString());
                DlName.Items.Add(li);
            }
        }
        protected void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DlName.SelectedValue != "0")
            {
                txtUserCardId.Text = DlName.SelectedValue;
              
                txtUserName.Text = DlName.SelectedItem.Text;
                huoqu(DlName.SelectedValue);
            }
        }
    }
}