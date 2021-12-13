using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ShortCapitalBasicAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        string ShortProjectsId;
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

                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ShortCapitalBasicManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["ShortProjectsId"] != null)
                {
                    try
                    {
                        ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    DataSet dt = bus.SelectByShortProjectsId("ShortProjects_SelectByShortProjectsId", ShortProjectsId);
                    LProjectsId.Text = ShortProjectsId;
                    LContractId.Text = dt.Tables[0].Rows[0]["ContractId"].ToString();
                    LContractName.Text = dt.Tables[0].Rows[0]["ContractName"].ToString();
                    LContractMoney.Text = dt.Tables[0].Rows[0]["ContractMoney"].ToString();
                    LCompany.Text = dt.Tables[0].Rows[0]["Company"].ToString();
                    dt.Clear();
                    dt = bus.SelectByShortProjectsId("ShortCapitalBasic_SelectByShortProjectsId", ShortProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        txtBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                        txtSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                        txtOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                        txtSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
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
            string ShortProjectsId = LProjectsId.Text;
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
            if (BidMoney < 0)
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
            string SuedCompany = txtSuedCompany.Text;
            string Servicelife = txtServicelife.Value;

            if (Servicelife == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入经费使用期限");
                return;
            }


            if (bus.ShortCapitalBasicSituationInsert("ShortCapitalBasic_Insert", ShortProjectsId, BidMoney, SupportMoney, OtherMoney, SuedCompany, Servicelife))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                // Response.Redirect("MyShortProjectsManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }
        }
    }
}