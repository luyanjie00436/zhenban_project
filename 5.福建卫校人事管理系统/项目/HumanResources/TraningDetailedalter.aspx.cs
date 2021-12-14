using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class TraningDetailedalter : System.Web.UI.Page
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
        string IsCertficateOrUnit;
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
                 RadioButtonList1.SelectedValue = ds2.Tables[0].Rows[0]["LearningType"].ToString();
                RadioButtonList2.SelectedValue = ds2.Tables[0].Rows[0]["LearningStyle"].ToString();
                DTtxtLearningUnit.Text = ds2.Tables[0].Rows[0]["LearningUnit"].ToString();
                DTtxtStartDate.Value = ds2.Tables[0].Rows[0]["StartDate"].ToString();
                DTtxtEndDate.Value = ds2.Tables[0].Rows[0]["EndDate"].ToString();
                IsCertficateOrUnit1.SelectedValue = ds2.Tables[0].Rows[0]["IsCertficateOrUnit"].ToString();
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            UserSave();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            TraningFurTime = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurTime2")).Text.ToString();
            try
            {
                DateTime.Parse(TraningFurTime);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(GridViewEmployee, "你输入的时间有误");
                dataGriviewBD();
                return;
            }
            TraningFurUnit = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurUnit2")).Text.ToString();
            TraningFurContent = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurContent2")).Text.ToString();
            TraningFurShape = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurShape2")).Text.ToString();
            if (bus.AddTraningFurByUserCardId("TraningFur_AddByUserCardId", UserCardId, TraningFurTime,
        TraningFurUnit, TraningFurContent, TraningFurShape))
            {
                AlertMsgAndNoFlush(GridViewEmployee, "添加成功");
            }
            else
            {
                AlertMsgAndNoFlush(GridViewEmployee, "添加失败了！");
            }
            dataGriviewBD();

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
        /// <summary>
        /// 编辑近三年的情况，编辑数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployee.EditIndex = e.NewEditIndex;
            dataGriviewBD(); // 
        }
        protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TraningFurTime = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurTime")).Text;
            try
            {
                DateTime.Parse(TraningFurTime);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(GridViewEmployee, "你输入的时间有误");
                return;
            }
            TraningFurUnit = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurUnit")).Text;
            TraningFurContent = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurContent")).Text;
            TraningFurShape = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurShape")).Text;
            TraningFurId = int.Parse(((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurId")).Text);
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            if (bus.AlterTraningFurByUserCardId("TraningFur_AlterByUserCardId", TraningFurId, UserCardId, TraningFurTime,
                TraningFurUnit, TraningFurContent, TraningFurShape))
            {
                AlertMsgAndNoFlush(GridViewEmployee, "更新成功");
            }
            else
            {
                AlertMsgAndNoFlush(GridViewEmployee, "更新失败了！");
            }
            dataGriviewBD();




        }
        protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployee.EditIndex = -1;
            dataGriviewBD(); // 
        }
        protected void GridViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TraningFurId = int.Parse(((Label)GridViewEmployee.Rows[e.RowIndex].FindControl("LabelTraningFurId")).Text);
            if (bus.deleteTraningFurByUserCardId("TraningFur_deleteByUserCardId", TraningFurId))
            {
                AlertMsgAndNoFlush(GridViewEmployee, "删除成功");
            }
            else
            {
                AlertMsgAndNoFlush(GridViewEmployee, "删除失败了！");
            }
            dataGriviewBD();

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        public void UserSave()
        {
            dataGriviewBD();
            if (RadioButtonList1.SelectedValue == "")
            {
                AlertMsgAndNoFlush(RadioButtonList1, "请选择进修学习类型");
                return;
            }
            if (RadioButtonList2.SelectedValue == "")
            {
                AlertMsgAndNoFlush(RadioButtonList2, "请选择进修学习方式");
                return;
            }
            if (IsCertficateOrUnit1.SelectedValue == "")
            {
                Response.Write("<script>alert('请输入请选择是否取得高校教师资格证或参加管理课程进修班');</script>");
                return;
            }
            if (DTtxtLearningUnit.Text.ToString() == "")
            {
                AlertMsgAndNoFlush(DTtxtLearningUnit, "拟前往进修学习单位名称");
                return;
            }
            if (DTtxtStartDate.Value.ToString() == "")
            {
                AlertMsgAndNoFlush(DTtxtStartDate, "进修开始时间");
                return;
            }
            if (DTtxtEndDate.Value.ToString() == "")
            {
                AlertMsgAndNoFlush(DTtxtEndDate, "进修结束时间");
                return;
            }
            try
            {
                float.Parse(DTtxtclFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtclFee, "你输入的差旅住宿费数据有误,请重新输入");
                return;
            }
            //TraningId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["Traning"], "asdfasdf"));
            try
            {
                float.Parse(DTtxtpyFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtpyFee, "你输入的培养费数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtysFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtysFee, "你输入的预算费数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtotFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtotFee, "你输入的其他费用数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund1.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund1, "你输入的上级部门资助数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund2.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund2, "你输入的学院资助数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund3.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund3, "你输入的部门资助数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund3.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund3, "你输入的部门资助数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund4.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund4, "你输入的本人自理数据有误,请重新输入");
                return;
            }
            try
            {
                float.Parse(DTtxtFund5.Text.Trim().ToString());
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(DTtxtFund5, "你输入的其他渠道数据有误,请重新输入");
                return;
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
            }
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            UserCardId = int.Parse(UserCardId.ToString()).ToString();
            LearningType = RadioButtonList1.SelectedValue.ToString();
            LearningStyle = RadioButtonList2.SelectedValue.ToString();
            IsCertficateOrUnit = IsCertficateOrUnit1.SelectedValue.ToString();
            LearningUnit = DTtxtLearningUnit.Text.ToString();
            StartDate = DTtxtStartDate.Value.ToString();
            EndDate = DTtxtEndDate.Value.ToString();
            Fund1 = float.Parse(DTtxtysFee.Text.ToString());
            Fund2 = float.Parse(DTtxtpyFee.Text.ToString());
            Fund3 = float.Parse(DTtxtclFee.Text.ToString());
            Fund4 = float.Parse(DTtxtotFee.Text.ToString());
            FunOri1 = float.Parse(DTtxtFund1.Text.ToString());
            FunOri2 = float.Parse(DTtxtFund2.Text.ToString());
            FunOri3 = float.Parse(DTtxtFund3.Text.ToString());
            FunOri4 = float.Parse(DTtxtFund4.Text.ToString());
            FunOri5 = float.Parse(DTtxtFund5.Text.ToString());
            if (bus.FurtherFormInsert2("Traning_Update", TraningId, UserCardId, LearningType, LearningStyle, LearningUnit, StartDate, EndDate, Fund1, Fund2, Fund3, Fund4,
FunOri1, FunOri2, FunOri3, FunOri4, FunOri5, IsCertficateOrUnit))                                                                        
            {                                                                                                                             
                AlertMsgAndNoFlush(Button1, "修改成功");                                                                                 
            }
        }
    }

}