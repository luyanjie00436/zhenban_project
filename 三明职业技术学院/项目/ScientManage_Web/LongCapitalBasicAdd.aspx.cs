using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web2
{
    public partial class LongCapitalBasicAdd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsAdd.aspx") == 0)
                //{
                //      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                //}
                #region 绑定
                ListItem li1 = new ListItem("--请选择--", "0");
                DLFrom.Items.Add(li1);
                DataTable dt2 = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "纵向项目申报").Tables[0];
                dt2.Clear();
                dt2 = bus.Select("ProjectsFrom_Select").Tables[0];
                foreach (DataRow dr in dt2.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromId"].ToString());
                    DLFrom.Items.Add(li);
                }
                #endregion

                if (Request.QueryString["LongProjectsId"] != null)
                {
                    try
                    {
                        LongProjectsId =pwds.DecryptDES(Request.QueryString["LongProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                    LProjectsId.Text = LongProjectsId;
                    LProjectsName.Text = dt.Tables[0].Rows[0]["ProjectsName"].ToString();
                    LProjectsFromExplain.Text = dt.Tables[0].Rows[0]["ProjectsFromExplain"].ToString();
                    dt.Clear();
                    dt = bus.SelectByLongProjectsId("LongCapitalBasic_SelectByLongProjectsId", LongProjectsId);
                    if (dt.Tables[0].Rows.Count>0)
                    {
                        txtBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                        txtSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                        txtOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                        DLFrom.SelectedValue = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                        //txtSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                        txtServicelife.Value = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                    }
                  
                }
                else
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }


            }

        }

         public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string LongProjectsId = LProjectsId.Text;
            try
            {
                Convert.ToDouble(txtBidMoney.Text);
            }
            catch (Exception)
            {
                 AlertMsgAndNoFlush(UpdatePanel1, "中标金额请输入正数或0");
                return;
            }
            double BidMoney = Convert.ToDouble(txtBidMoney.Text);
            if (BidMoney<0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "中标金额请输入正数或0");
                return;
            }

            try
            {
                Convert.ToDouble(txtSupportMoney.Text);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "配套金额请输入正数或0");
                return;
            }
            double SupportMoney = Convert.ToDouble(txtSupportMoney.Text);
            if (SupportMoney < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "配套金额请输入正数或0");
                return;
            }

            try
            {
                Convert.ToDouble(txtOtherMoney.Text);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "其他金额请输入正数或0");
                return;
            }
            double OtherMoney = Convert.ToDouble(txtOtherMoney.Text);
            if (OtherMoney < 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "其他金额请输入正数或0");
                return;
            }
            string SuedCompany = DLFrom.Text;
            string Servicelife = txtServicelife.Value;

            if (Servicelife=="")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入经费使用期限");
                return;
            }


            if (bus.LongCapitalBasicSituationInsert("LongCapitalBasic_Insert", LongProjectsId,BidMoney,SupportMoney,OtherMoney,SuedCompany,Servicelife))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
               // Response.Redirect("MyLongProjectsManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}