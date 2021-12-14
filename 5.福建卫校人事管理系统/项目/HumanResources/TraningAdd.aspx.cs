using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class TraningAdd : System.Web.UI.Page
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
                    txtProfessional.Text = dt.Tables[0].Rows[0]["ProfessionalName"].ToString();
                    huoqu(dt.Tables[0].Rows[0]["UserCardId"].ToString());
                }
                
            }
        }
        protected void huoqu(string UserCardId)
        {
            DataSet ds = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId);
            txtUserName.Text = ds.Tables[0].Rows[0]["姓名"].ToString();
            txtSex.Text = ds.Tables[0].Rows[0]["性别"].ToString();
            txtBirthday.Text = ds.Tables[0].Rows[0]["出生年月"].ToString();
            txtUserEducation.Text = ds.Tables[0].Rows[0]["最高学历"].ToString();//学历
            txtUserSpecialty.Text = ds.Tables[0].Rows[0]["最高学历专业"].ToString();//专业
            txtUserSchool.Text = ds.Tables[0].Rows[0]["最高学历毕业院校"].ToString();//毕业学校
            txtUserSchoolTime.Text = ds.Tables[0].Rows[0]["入职院校时间"].ToString();//入校时间
            dataGriviewBD();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            UserSave();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = txtUserCardId.Text;
            TraningFurTime = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurTime2")).Text.ToString();
            // TraningFurTime=((HTML.Input)GridViewEmployee.FooterRow.FindControl("TextTraningFurTime2")).Value.ToString();
            TraningFurUnit = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurUnit2")).Text.ToString();
            TraningFurContent = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurContent2")).Text.ToString();
            TraningFurShape = ((TextBox)GridViewEmployee.FooterRow.FindControl("TextTraningFurShape2")).Text.ToString();
            if (TraningFurTime.Length<1)
            {
                Response.Write("<script>alert('请输入进修时间');</script>");
             
                return;
            }
            if (TraningFurUnit.Length < 1)
            {
                Response.Write("<script>alert('请输入进修单位');</script>");

                return;
            }
            if (TraningFurContent.Length < 1)
            {
                Response.Write("<script>alert('请输入进修内容');</script>");

                return;
            }
            if (TraningFurShape.Length < 1)
            {
                Response.Write("<script>alert('请输入进修形式');</script>");

                return;
            }
            try
            {
                DateTime.Parse(TraningFurTime);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('您输入的时间有误');</script>");
              
                return;
            }
           
            if (bus.AddTraningFurByUserCardId("TraningFur_AddByUserCardId", UserCardId, TraningFurTime,
        TraningFurUnit, TraningFurContent, TraningFurShape))
            {
              
                Response.Write("<script>alert('添加成功');</script>");
              
            }
            else
            {
                Response.Write("<script>alert('添加失败');</script>");
            }
            dataGriviewBD();

        }
        public void dataGriviewBD()
        {
            DataTable dt;
            UserCardId = txtUserCardId.Text;
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
            TraningFurUnit = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurUnit")).Text;
            TraningFurContent = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurContent")).Text;
            TraningFurShape = ((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurShape")).Text;
            TraningFurId = int.Parse(((Label)GridViewEmployee.Rows[e.RowIndex].FindControl("TextTraningFurId")).Text);
            UserCardId = txtUserCardId.Text;
          
           
            if (TraningFurTime.Length < 1)
            {
                Response.Write("<script>alert('请输入进修时间');</script>");

                return;
            }
            try
            {
                DateTime.Parse(TraningFurTime);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('您输入的时间有误');</script>");
                return;
            }
            if (TraningFurUnit.Length < 1)
            {
                Response.Write("<script>alert('请输入进修单位');</script>");

                return;
            }
            if (TraningFurContent.Length < 1)
            {
                Response.Write("<script>alert('请输入进修内容');</script>");

                return;
            }
            if (TraningFurShape.Length < 1)
            {
                Response.Write("<script>alert('请输入进修形式');</script>");

                return;
            }

            if (bus.AlterTraningFurByUserCardId("TraningFur_AlterByUserCardId", TraningFurId, UserCardId, TraningFurTime,
                TraningFurUnit, TraningFurContent, TraningFurShape))
            {
                Response.Write("<script>alert('更新成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败');</script>");
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
                Response.Write("<script>alert('删除成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');</script>");
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
                Response.Write("<script>alert('请选择进修学习类型');</script>");
                return;
            }
            if (RadioButtonList2.SelectedValue == "")
            {
                Response.Write("<script>alert('请输入请选择进修学习方式');</script>");
                return;
            }
            if (IsCertficateOrUnit1.SelectedValue == "")
            {
                Response.Write("<script>alert('请输入请选择是否取得高校教师资格证或参加管理课程进修班');</script>");
                return;
            }
            if (txtLearningUnit.Text.ToString() == "")
            {
                Response.Write("<script>alert('请输入拟前往进修学习单位名称');</script>");
                return;
            }
            if (txtStartDate.Value.ToString() == "")
            {
                Response.Write("<script>alert('请选择进修开始时间');</script>");
                return;
            }
            if (txtEndDate.Value.ToString() == "")
            {
                Response.Write("<script>alert('请选择进修结束时间');</script>");
                return;
            }
            try
            {
                float.Parse(txtclFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                
                Response.Write("<script>alert('您输入的差旅住宿费数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtpyFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
               
                Response.Write("<script>alert('您输入的培养费数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtysFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
             
                Response.Write("<script>alert('您输入的预算费数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtotFee.Text.Trim().ToString());
            }
            catch (Exception)
            {
                
                Response.Write("<script>alert('您输入的其他费用数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund1.Text.Trim().ToString());
            }
            catch (Exception)
            {
      
                Response.Write("<script>alert('您输入的上级部门资助数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund2.Text.Trim().ToString());
            }
            catch (Exception)
            {
               
                Response.Write("<script>alert('您输入的学院资助数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund3.Text.Trim().ToString());
            }
            catch (Exception)
            {
            
                Response.Write("<script>alert('您输入的部门资助数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund3.Text.Trim().ToString());
            }
            catch (Exception)
            {
           
                Response.Write("<script>alert('您输入的部门资助数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund4.Text.Trim().ToString());
            }
            catch (Exception)
            {
             
                Response.Write("<script>alert('您输入的本人自理数据有误,请重新输入');</script>");
                return;
            }
            try
            {
                float.Parse(txtFund5.Text.Trim().ToString());
            }
            catch (Exception)
            {
               
                Response.Write("<script>alert('您输入的其他渠道数据有误,请重新输入');</script>");
                return;
            }
            UserCardId = txtUserCardId.Text;
            UserCardId = int.Parse(UserCardId.ToString()).ToString();
            LearningType = RadioButtonList1.SelectedValue.ToString();
            LearningStyle = RadioButtonList2.SelectedValue.ToString();
            IsCertficateOrUnit = IsCertficateOrUnit1.SelectedValue.ToString();
            LearningUnit = txtLearningUnit.Text.ToString();
            StartDate = txtStartDate.Value.ToString();
            EndDate = txtEndDate.Value.ToString();
            Fund1 = float.Parse(txtysFee.Text.ToString());
            Fund2= float.Parse(txtpyFee.Text.ToString());
            Fund3= float.Parse(txtclFee.Text.ToString());
            Fund4 = float.Parse(txtotFee.Text.ToString());
            FunOri1= float.Parse(txtFund1.Text.ToString());
            FunOri2= float.Parse(txtFund2.Text.ToString());
            FunOri3= float.Parse(txtFund3.Text.ToString());
            FunOri4= float.Parse(txtFund4.Text.ToString());
            FunOri5 = float.Parse(txtFund5.Text.ToString());
            if (bus.FurtherFormInsert("Traning_Insert", UserCardId, LearningType, LearningStyle, LearningUnit, StartDate, EndDate, Fund1, Fund2, Fund3, Fund4,
FunOri1, FunOri2, FunOri3, FunOri4, FunOri5, IsCertficateOrUnit))
            {
                Response.Write("<script>alert('申请成功');</script>");
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