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
    public partial class WorkLoadProjectsAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int WorkLoadProjectsId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WorkLoadProjectsAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["WorkLoadProjectsId"] != null)
                {
                    try
                    {
                        WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }

                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByWorkLoadProjectsId("WorkLoadProjects_SelectByWorkLoadProjectsId", WorkLoadProjectsId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    radioCateGory.SelectedValue = dt.Tables[0].Rows[0]["CateGory"].ToString();
                    txtWorkLoadProjectsName.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsName"].ToString();
                    txtProjectsId.Text= dt.Tables[0].Rows[0]["ProjectsId"].ToString();
                    txtWorkLoadForm.Text = dt.Tables[0].Rows[0]["WorkLoadFrom"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["WorkLoadProjectsUrl"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtStartEndDate.Text = dt.Tables[0].Rows[0]["StartEndDate"].ToString();
                    txtWorkLoadCapital.Value= dt.Tables[0].Rows[0]["WorkLoadCapital"].ToString();
                    txtSumProjectsValue.Value = dt.Tables[0].Rows[0]["SumProjectsValue"].ToString();
                    txtProjectsValue.Value = dt.Tables[0].Rows[0]["ProjectsValue"].ToString();
                    txtPartnerRank.Value = dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                    txtPartnerValue.Value = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                }
                else
                {
                    RBL1.Visible = false;
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Button2.Visible = false;
                }


            }
            if (LFileUrl.Text == "")
            {
                LinkButton2.Visible = false;
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
            string CateGory = radioCateGory.SelectedValue.ToString();
            string WorkLoadProjectsName = txtWorkLoadProjectsName.Text.Trim();
            string ProjectsId = txtProjectsId.Text.Trim();
            string WorkLoadForm = txtWorkLoadForm.Text.Trim();
            string StartEndDate = txtStartEndDate.Text.Trim();
            string WorkLoadCapital = txtWorkLoadCapital.Value.Trim();
            double ProjectsValue;
            double PartnerValue;
            double SumProjectsValue;
            int PartnerRank;
            string Remarks = txtRemarks.Text;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (CateGory == "")
            {
                AlertMsgAndNoFlush("请选择项目类别");
                return;
            }
            if (WorkLoadProjectsName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
           
            if (WorkLoadForm == "")
            {
                AlertMsgAndNoFlush("请输入来源及类别");
                return;
            }
            if (StartEndDate == "")
            {
                AlertMsgAndNoFlush("请输入起止时间");
                return;
            }
            if (WorkLoadCapital == "")
            {
                AlertMsgAndNoFlush("请输入到校经费");
                return;
            }
            try
            {
                Convert.ToDouble(WorkLoadCapital);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("到校经费请输入数字！");
                return;
            }

            if (txtSumProjectsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                SumProjectsValue = Convert.ToDouble(txtSumProjectsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (txtProjectsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本年度可分配分值");
                return;
            }
            try
            {
                ProjectsValue = Convert.ToDouble(txtProjectsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本年度可分配分值应为正数");
                return;
            }
            if (ProjectsValue <= 0)
            {
             
                AlertMsgAndNoFlush("本年度可分配分值应为正数");
                return;
            }
            if (txtPartnerValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush("本人得分应为正数");
                return;
            }

            if (txtPartnerRank.Value == "==请选择==")
            {
                AlertMsgAndNoFlush("请选择个人排名");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){AlertMsgAndNoFlush("本人排名应为正数");return;}
            if (ProjectsValue < PartnerValue)
            {
                AlertMsgAndNoFlush("本人得分应小于本年度可分配分值");
                return;
            }
             if (!fupFileSend.HasFile)
            {
                if (bus.WorkLoadProjectsInsert("WorkLoadProjects_Insert", ProjectsId, UserCardId,DepartmentId, WorkLoadProjectsName, WorkLoadForm, StartEndDate, WorkLoadCapital, CateGory, ProjectsValue, PartnerRank, PartnerValue, Remarks, "", SumProjectsValue))

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
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //创建文件夹
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\" + Dates+ nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\" + Dates + nameLast;


                    if (bus.WorkLoadProjectsInsert("WorkLoadProjects_Insert", ProjectsId, UserCardId,DepartmentId, WorkLoadProjectsName, WorkLoadForm, StartEndDate, WorkLoadCapital, CateGory, ProjectsValue, PartnerRank, PartnerValue, Remarks, path, SumProjectsValue))

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
            Response.Write("<script>alert('" + message + "！')</script>");
            //ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string CateGory = radioCateGory.SelectedValue.ToString();
            string WorkLoadProjectsName = txtWorkLoadProjectsName.Text.Trim();
            string ProjectsId = txtProjectsId.Text.Trim();
            string Remarks = txtRemarks.Text;
            string WorkLoadForm = txtWorkLoadForm.Text.Trim();
            string StartEndDate = txtStartEndDate.Text.Trim();
            string WorkLoadCapital = txtWorkLoadCapital.Value.Trim();
            double SumProjectsValue;
            double ProjectsValue;
            double PartnerValue;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (CateGory == "")
            {
                AlertMsgAndNoFlush("请选择项目类别");
                return;
            }
            if (WorkLoadProjectsName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
         
            if (WorkLoadForm == "")
            {
                AlertMsgAndNoFlush("请输入来源及类别");
                return;
            }
            if (StartEndDate == "")
            {
                AlertMsgAndNoFlush("请输入起止时间");
                return;
            }
            if (WorkLoadCapital == "")
            {
                AlertMsgAndNoFlush("请输入到校经费");
                return;
            }
            try
            {
                Convert.ToDouble(WorkLoadCapital);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("到校经费请输入数字！");
                return;
            }
            if (txtSumProjectsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                SumProjectsValue = Convert.ToDouble(txtSumProjectsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (txtProjectsValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本年度可分配分值");
                return;
            }
            try
            {
                ProjectsValue = Convert.ToDouble(txtProjectsValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本年度可分配分值应为正数");
                return;
            }
            if (ProjectsValue <= 0)
            {

                AlertMsgAndNoFlush("本年度可分配分值应为正数");
                return;
            }
            if (txtPartnerValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush("本人得分应为正数");
                return;
            }

            if (txtPartnerRank.Value == "==请选择==")
            {
                AlertMsgAndNoFlush("请选择个人排名");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){AlertMsgAndNoFlush("本人排名应为正数");return;}
            if (ProjectsValue < PartnerValue)
            {
                AlertMsgAndNoFlush("本人得分应小于本年度可分配分值");
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\WorkLoadProjects\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            WorkLoadProjectsId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WorkLoadProjectsId"], "asdfasdf"));
            if (bus.WorkLoadProjectsUpdate("WorkLoadProjects_Update",WorkLoadProjectsId,ProjectsId,DepartmentId, WorkLoadProjectsName,WorkLoadForm,StartEndDate,WorkLoadCapital,CateGory,ProjectsValue, PartnerRank, PartnerValue, Remarks,path, SumProjectsValue))
            {

                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyWorkLoadProjectsManage.aspx'}</script>");
            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}