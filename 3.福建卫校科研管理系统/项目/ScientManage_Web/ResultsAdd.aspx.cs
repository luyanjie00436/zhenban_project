using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ResultsAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int ResultsId;
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ResultsAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["ResultsId"] != null)
                {
                    try
                    {
                        ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByResultsId("Results_SelectByResultsId", ResultsId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtResultsName.Text = dt.Tables[0].Rows[0]["ResultsName"].ToString();
                    DlCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    DlAwardlevel.Text = dt.Tables[0].Rows[0]["Awardlevel"].ToString();
                    txtResultsPrincipal.Text = dt.Tables[0].Rows[0]["ResultsPrincipal"].ToString();
                    txtAwarding_unit.Text= dt.Tables[0].Rows[0]["Awarding_unit"].ToString();
                    txttime.Value = dt.Tables[0].Rows[0]["time"].ToString();
                    DlCompletion.Text = dt.Tables[0].Rows[0]["Completion"].ToString();
                    txtResultsTotal.Value = dt.Tables[0].Rows[0]["ResultsTotal"].ToString();
                    txtResultsDescription.Text = dt.Tables[0].Rows[0]["ResultsDescription"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtResultsValue.Value = dt.Tables[0].Rows[0]["ResultsValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["ResultsUrl"].ToString();
                }
                else
                {
                    RBL1.Visible = false;
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Button2.Visible = false;
                }
                if (LFileUrl.Text == "")
                {
                    LinkButton2.Visible = false;
                }

            }

        }
        //下载附件
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (LFileUrl.Text != "")
            {
                string path = Server.MapPath("./") + LFileUrl.Text;
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Length", fi.Length.ToString());
                    Response.ContentType = "application/application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                    Response.WriteFile(fi.FullName);
                    Response.End();
                    Response.Flush();
                    Response.Clear();

                }
            }
            else
            {
                Response.Write("<script>alert('未上传附件，无法下载！')</script>");
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ResultsName = txtResultsName.Text.Trim();
            string Category = DlCategory.Text.Trim();
            string Awardlevel = DlAwardlevel.Text.Trim();
            string ResultsPrincipal = txtResultsPrincipal.Text.Trim();
            string Awarding_unit = txtAwarding_unit.Text.Trim();
            string time = txttime.Value;
            string Completion = DlCompletion.Text.Trim();
            double ResultsTotal;
            string ResultsDescription = txtResultsDescription.Text;
            string Remarks = txtRemarks.Text;
            double ResultsValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (ResultsName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (DlCategory.Text == "请选择项目类别")
            {
                AlertMsgAndNoFlush("请输入项目类别");
                return;
            }
            if (DlAwardlevel.Text == "请选择项目奖级")
            {
                AlertMsgAndNoFlush("请输入项目奖级");
                return;
            }
            if (ResultsPrincipal == "")
            {
                AlertMsgAndNoFlush("请输入负责人");
                return;
            }
            if (Awarding_unit == "")
            {
                AlertMsgAndNoFlush("请输入颁奖单位");
                return;
            }
            if (time == "")
            {
                AlertMsgAndNoFlush("请输入获奖时间");
                return;
            }
            if (DlCompletion.Text == "请选择完成情况")
            {
                AlertMsgAndNoFlush("请输入完成情况");
                return;
            }
            if (txtResultsTotal.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                ResultsTotal = Convert.ToDouble(txtResultsTotal.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (ResultsDescription == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }

            if (txtResultsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入个人工作量分值");
                return;
            }
            try
            {
                ResultsValue = Convert.ToDouble(txtResultsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("个人工作量分值应为正数");
                return;
            }

            if (ResultsValue <= 0)
            {
                AlertMsgAndNoFlush("个人工作量分值应为正数");
                return;
            }
            if (ResultsValue > ResultsTotal)
            {
                AlertMsgAndNoFlush("个人工作量分值应小于项目总分值");
                return;
            }

            if (!fupFileSend.HasFile)
            {
                if (bus.ResultsInsert("Results_Insert", UserCardId,DepartmentId, ResultsName, Category, Awardlevel, ResultsPrincipal, Awarding_unit, time, Completion, ResultsTotal, ResultsDescription, "", ResultsValue, Remarks))
                {
                    AlertMsgAndNoFlush("申请成功");
                }
                else
                {
                    AlertMsgAndNoFlush("申请失败！可能是没有您的审批流程");
                }
            }
            else
            {
                try
                {
                    //获取上传文件的名称
                    string upName = fupFileSend.FileName;
                    //获取上传文件的后缀名
                    string nameLast = upName.Substring(upName.LastIndexOf("."));
                    //创建文件夹
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\" + Dates + nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\" + Dates + nameLast;

                    if (bus.ResultsInsert("Results_Insert", UserCardId,DepartmentId, ResultsName, Category, Awardlevel, ResultsPrincipal, Awarding_unit, time, Completion, ResultsTotal, ResultsDescription, path, ResultsValue, Remarks))
                    {
                        AlertMsgAndNoFlush("申请成功");
                    }
                    else
                    {
                        AlertMsgAndNoFlush("申请失败！可能是没有您的审批流程");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    Response.Write("<script>alert('上传失败！')</script>");
                }
            }
          
        }
        public void AlertMsgAndNoFlush(string message)
        {
            // ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
            Response.Write("<script>alert('" + message + "！')</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ResultsName = txtResultsName.Text.Trim();
            string Category = DlCategory.Text.Trim();
            string Awardlevel = DlAwardlevel.Text.Trim();
            string ResultsPrincipal = txtResultsPrincipal.Text.Trim();
            string Awarding_unit = txtAwarding_unit.Text.Trim();
            string time = txttime.Value;
            string Completion = DlCompletion.Text.Trim();
            double ResultsTotal;
            string ResultsDescription = txtResultsDescription.Text;
            string Remarks = txtRemarks.Text;
            double ResultsValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (ResultsName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (Category == "")
            {
                AlertMsgAndNoFlush("请输入类别");
                return;
            }
            if (Awardlevel == "")
            {
                AlertMsgAndNoFlush("请输入奖级");
                return;
            }
            if (ResultsPrincipal == "")
            {
                AlertMsgAndNoFlush("请输入负责人");
                return;
            }
            if (Awarding_unit == "")
            {
                AlertMsgAndNoFlush("请输入颁奖单位");
                return;
            }
            if (time == "")
            {
                AlertMsgAndNoFlush("请输入获奖时间");
                return;
            }
            if (Completion == "")
            {
                AlertMsgAndNoFlush("请输入完成情况");
                return;
            }
            if (txtResultsTotal.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                ResultsTotal = Convert.ToDouble(txtResultsTotal.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (ResultsDescription == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }

            if (txtResultsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入个人工作量分值");
                return;
            }
            try
            {
                ResultsValue = Convert.ToDouble(txtResultsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("个人工作量分值应为正数");
                return;
            }

            if (ResultsValue <= 0)
            {
                AlertMsgAndNoFlush("个人工作量分值应为正数");
                return;
            }
            if (ResultsValue > ResultsTotal)
            {
                AlertMsgAndNoFlush("个人工作量分值应小于项目总分值");
                return;
            }
            string path = LFileUrl.Text;
            string RBL = RBL1.SelectedItem.Value;
            if (RBL == "是")
            {
                if (!fupFileSend.HasFile)
                {
                    path = "";
                }
                else
                {
                    try
                    {
                        //获取上传文件的名称
                        string upName = fupFileSend.FileName;
                        //获取上传文件的后缀名
                        string nameLast = upName.Substring(upName.LastIndexOf("."));
                        //创建文件夹
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\Results\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            ResultsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ResultsId"], "asdfasdf"));
            if (bus.ResultsUpdate("Results_Update", ResultsId,DepartmentId, ResultsName, Category, Awardlevel, ResultsPrincipal, Awarding_unit, time, Completion, ResultsTotal, ResultsDescription, path, ResultsValue, Remarks))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyResultsManage.aspx'}</script>");


            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}