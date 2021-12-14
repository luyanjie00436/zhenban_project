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
    public partial class C_constructionAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int C_constructionId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/C_constructionAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["C_constructionId"] != null)
                {
                    try
                    {
                        C_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["C_constructionId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByC_constructionId("C_construction_SelectByC_constructionId", C_constructionId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtC_constructionName.Text = dt.Tables[0].Rows[0]["C_constructionName"].ToString();
                    DlLeve.Text = dt.Tables[0].Rows[0]["Leve"].ToString();
                    txtPrincipal.Text = dt.Tables[0].Rows[0]["Principal"].ToString();
                    DlCompletion.Text = dt.Tables[0].Rows[0]["Completion"].ToString();
                    txtStartEndDate.Text = dt.Tables[0].Rows[0]["StartEndDate"].ToString();
                    txtTotal_Project.Value = dt.Tables[0].Rows[0]["Total_Project"].ToString();
                    txtDescription_Project.Text = dt.Tables[0].Rows[0]["Description_Project"].ToString();
                    txtAnnual.Value = dt.Tables[0].Rows[0]["Annual"].ToString();
                    txtDescription_year.Text = dt.Tables[0].Rows[0]["Description_year"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtC_constructionValue.Value = dt.Tables[0].Rows[0]["C_constructionValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["C_constructionUrl"].ToString();
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
            string C_constructionName = txtC_constructionName.Text.Trim();
            string Leve = DlLeve.Text.Trim();
            string Principal = txtPrincipal.Text;
            string Completion = DlCompletion.Text.Trim();
            string StartEndDate = txtStartEndDate.Text.Trim();
            double Total_Project;
            string Description_Project = txtDescription_Project.Text;
            double Annual = 0;
            string Description_year = txtDescription_year.Text;
            string Remarks = txtRemarks.Text;
            double C_constructionValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (C_constructionName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (Leve == "")
            {
                AlertMsgAndNoFlush("请输入级别");
                return;
            }
            if (Principal == "")
            {
                AlertMsgAndNoFlush("请输入负责人");
                return;
            }
            if (Completion == "")
            {
                AlertMsgAndNoFlush("请输入完成情况");
                return;
            }
            if (StartEndDate == "")
            {
                AlertMsgAndNoFlush("请输入迄止时间");
                return;
            }

            if (txtTotal_Project.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                Total_Project = Convert.ToDouble(txtTotal_Project.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (Description_Project == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }
                if (txtAnnual.Value == "")
                {
                    AlertMsgAndNoFlush("请输入本年度项目总分值");
                    return;
                }
                try
                {
                    Annual = Convert.ToDouble(txtAnnual.Value);
                }
                catch (Exception)
                {

                    AlertMsgAndNoFlush("本年度项目总分值应为正数");
                    return;
                }

                if (Annual <= 0)
                {
                    AlertMsgAndNoFlush("本年度项目总分值应为正数");
                    return;
                }
                if (Annual > Total_Project)
                {
                    AlertMsgAndNoFlush("本年度项目总分值应小于项目总分值");
                    return;
                }

                if (Description_year == "")
                {
                    AlertMsgAndNoFlush("请输入本年度项目总分值说明");
                    return;
                }

            

            if (txtC_constructionValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本年度个人工作量分值");
                return;
            }
            try
            {
                C_constructionValue = Convert.ToDouble(txtC_constructionValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本年度个人工作量分值应为正数");
                return;
            }

            if (C_constructionValue <= 0)
            {
                AlertMsgAndNoFlush("本年度个人工作量分值应为正数");
                return;
            }
            if (C_constructionValue > Annual)
            {
                AlertMsgAndNoFlush("本年度个人工作量分值应小于本年度项目总分值");
                return;
            }

            if (!fupFileSend.HasFile)
            {
                if (bus.C_constructionInsert("C_construction_Insert", UserCardId,DepartmentId, C_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, "", C_constructionValue, Remarks))
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
                string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\" + Dates + nameLast;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\" + Dates + nameLast;

                if (bus.C_constructionInsert("C_construction_Insert", UserCardId,DepartmentId, C_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, path, C_constructionValue, Remarks))
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
            string C_constructionName = txtC_constructionName.Text.Trim();
            string Leve = DlLeve.Text.Trim();
            string Principal = txtPrincipal.Text;
            string Completion = DlCompletion.Text.Trim();
            string StartEndDate = txtStartEndDate.Text.Trim();
            double Total_Project;
            string Description_Project = txtDescription_Project.Text;
            double Annual = 0;
            string Description_year = txtDescription_year.Text;
            string Remarks = txtRemarks.Text;
            double C_constructionValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (C_constructionName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (Leve == "")
            {
                AlertMsgAndNoFlush("请输入级别");
                return;
            }
            if (Principal == "")
            {
                AlertMsgAndNoFlush("请输入负责人");
                return;
            }
            if (Completion == "")
            {
                AlertMsgAndNoFlush("请输入完成情况");
                return;
            }
            if (StartEndDate == "")
            {
                AlertMsgAndNoFlush("请输入迄止时间");
                return;
            }

            if (txtTotal_Project.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                Total_Project = Convert.ToDouble(txtTotal_Project.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (Description_Project == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }
                if (txtAnnual.Value == "")
                {
                    AlertMsgAndNoFlush("请输入本年度项目总分值");
                    return;
                }
                try
                {
                    Annual = Convert.ToDouble(txtAnnual.Value);
                }
                catch (Exception)
                {

                    AlertMsgAndNoFlush("本年度项目总分值应为正数");
                    return;
                }

                if (Annual <= 0)
                {
                    AlertMsgAndNoFlush("本年度项目总分值应为正数");
                    return;
                }
                if (Annual > Total_Project)
                {
                    AlertMsgAndNoFlush("本年度项目总分值应小于项目总分值");
                    return;
                }

                if (Description_year == "")
                {
                    AlertMsgAndNoFlush("请输入本年度项目总分值说明");
                    return;
                }

            

            if (txtC_constructionValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本年度个人工作量分值");
                return;
            }
            try
            {
                C_constructionValue = Convert.ToDouble(txtC_constructionValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本年度个人工作量分值应为正数");
                return;
            }

            if (C_constructionValue <= 0)
            {
                AlertMsgAndNoFlush("本年度个人工作量分值应为正数");
                return;
            }
            if (C_constructionValue > Annual)
            {
                AlertMsgAndNoFlush("本年度个人工作量分值应小于本年度项目总分值");
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
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\C_construction\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            C_constructionId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["C_constructionId"], "asdfasdf"));
            if (bus.C_constructionUpdate("C_construction_Update", C_constructionId,DepartmentId, C_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, path, C_constructionValue, Remarks))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyC_constructionManage.aspx'}</script>");
            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}