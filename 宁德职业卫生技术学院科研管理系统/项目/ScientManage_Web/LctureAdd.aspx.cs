using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class LctureAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int LctureId;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LctureAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DLLevel.Items.Add("==请选择==");
                DLLevel.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "学术讲座").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLLevel.Items.Add(li);
                }
                DLCompany.Items.Add("==请选择==");
                DLCompany.Items[0].Value = "0";
                 ds = bus.Select("Company_Select").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["CompanyName"].ToString(), dr["CompanyName"].ToString());
                    DLCompany.Items.Add(li);
                }
                if (Request.QueryString["LctureId"] != null)
                {
                    try
                    {
                        LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByLctureId("Lcture_SelectByLctureId", LctureId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    txtLctureName.Text = dt.Tables[0].Rows[0]["LctureName"].ToString();
                    DLCompany.Text= dt.Tables[0].Rows[0]["Company"].ToString();
                    txtLctureDate.Value=  dt.Tables[0].Rows[0]["LctureDate"].ToString();
                    txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                    txtLctureNumber.Text = dt.Tables[0].Rows[0]["LctureNumber"].ToString();
                    txtLctureExplain.Text = dt.Tables[0].Rows[0]["LctureExplain"].ToString();
                    txtEquipment.Text = dt.Tables[0].Rows[0]["Equipment"].ToString();
                    txtOrganName.Text = dt.Tables[0].Rows[0]["OrganName"].ToString();
                    txtPhoneNumber.Text = dt.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    txtCapital.Text = dt.Tables[0].Rows[0]["Capital"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtLctureUserName.Text = dt.Tables[0].Rows[0]["LctureUserName"].ToString();
                    RBLctureUserGender.SelectedValue = dt.Tables[0].Rows[0]["LctureUserGender"].ToString();
                    txtLctureUserRole.Text = dt.Tables[0].Rows[0]["LctureUserRole"].ToString();
                    txtLctureUserJob.Text = dt.Tables[0].Rows[0]["LctureUserJob"].ToString();
                    txtLctureUserCompany.Text = dt.Tables[0].Rows[0]["LctureUserCompany"].ToString();

                    for (int i = 0; i < DLLevel.Items.Count; i++)
                    {
                        if (DLLevel.Items[i].Text == dt.Tables[0].Rows[0]["DLevel"].ToString())
                        {
                            DLLevel.SelectedValue = DLLevel.Items[i].Value;
                            break;
                        }
                    }
                }
                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Button2.Visible = false;
                }


            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
             string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LctureName = txtLctureName.Text.Trim();
            string Company = DLCompany.SelectedValue;
            string LctureDate = txtLctureDate.Value;
            string Address = txtAddress.Text;
            string LctureNumber = txtLctureNumber.Text;
            string LctureExplain=txtLctureExplain.Text;
            string Equipment = txtEquipment.Text;
            string OrganName = txtOrganName.Text;
            string Capital = txtCapital.Text;
            string PhoneNumber = txtPhoneNumber.Text;
            string Remarks = txtRemarks.Text;
            string LctureUserName = txtLctureUserName.Text;
            string LctureUserJob = txtLctureUserJob.Text;
            string LctureUserRole = txtLctureUserRole.Text;
            string LctureUserCompany = txtLctureUserCompany.Text;
            string LctureUserGender = RBLctureUserGender.SelectedValue;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }           
            if (LctureName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座（报告）题目");
                return;
            }

            if (Company== "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择承办单位");
                return;
            } if (LctureDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座时间");
                return;
            }
            if (Address == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座地点");
                return;
            }
            if (LctureNumber== "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参加人数");
                return;
            }

         
            if (bus.LctureInsert("Lcture_Insert", UserCardId, LctureName,Company,LctureDate,Address,LctureNumber,LctureExplain,Equipment,OrganName,PhoneNumber,Capital, DLevel,Remarks,LctureUserName,LctureUserGender,LctureUserJob,LctureUserRole,LctureUserCompany))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请成功");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "申请失败！可能是没有您的审批流程");
            }

        }
      
       
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string LctureName = txtLctureName.Text.Trim();
            string Company = DLCompany.Text.Trim();
            string LctureDate = txtLctureDate.Value;
            string Address = txtAddress.Text;
            string LctureNumber = txtLctureNumber.Text;
            string LctureExplain = txtLctureExplain.Text;
            string Equipment = txtEquipment.Text;
            string OrganName = txtOrganName.Text;
            string Capital = txtCapital.Text;
            string PhoneNumber = txtPhoneNumber.Text;
            string Remarks = txtRemarks.Text;
            string LctureUserName = txtLctureUserName.Text;
            string LctureUserJob = txtLctureUserJob.Text;
            string LctureUserRole = txtLctureUserRole.Text;
            string LctureUserCompany = txtLctureUserCompany.Text;
            string LctureUserGender = RBLctureUserGender.SelectedValue;
            string DLevel = "";
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            if (LctureName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座（报告）题目");
                return;
            }

            if (Company == "0")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择承办单位");
                return;
            } if (LctureDate == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座时间");
                return;
            }
            if (Address == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入讲座地点");
                return;
            }
            if (LctureNumber == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入参加人数");
                return;
            }

            LctureId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["LctureId"], "asdfasdf"));
            if (bus.LctureUpdate("Lcture_Update", LctureId, LctureName,Company,LctureDate,Address,LctureNumber,LctureExplain,Equipment,OrganName,PhoneNumber,Capital, DLevel,Remarks,LctureUserName,LctureUserGender,LctureUserJob,LctureUserRole,LctureUserCompany))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                Response.Redirect("MyLctureManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}