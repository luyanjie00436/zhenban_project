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
    public partial class GuidanceAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int GuidanceId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/GuidanceAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["GuidanceId"] != null)
                {
                    try
                    {
                        GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByGuidanceId("Guidance_SelectByGuidanceId", GuidanceId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtGuidanceName.Text = dt.Tables[0].Rows[0]["GuidanceName"].ToString();
                    txtGuidanceLevel.Text = dt.Tables[0].Rows[0]["GuidanceLevel"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtGuidanceValue.Value = dt.Tables[0].Rows[0]["GuidanceValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["GuidanceUrl"].ToString();
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
            string GuidanceName = txtGuidanceName.Text.Trim();
            string Remarks = txtRemarks.Text;
            string GuidanceLevel = txtGuidanceLevel.Text.Trim();

            double GuidanceValue;
            double PartnerValue;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (GuidanceName == "")
            {
                AlertMsgAndNoFlush("请输入成果或调研报告名称");
                return;
            }
            if (GuidanceLevel == "")
            {
                AlertMsgAndNoFlush("请输入成果或采用级别");
                return;
            }
            if (txtGuidanceValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入成果分值");
                return;
            }
            try
            {
                GuidanceValue = Convert.ToDouble(txtGuidanceValue.Value);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush("成果分值应为正数");
                return;
            }
            if (GuidanceValue <= 0)
            {
                AlertMsgAndNoFlush("成果分值应为正数");
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
            if (GuidanceValue < PartnerValue)
            {
                AlertMsgAndNoFlush("本人得分应小于成果分值");
                return;
            }
            if (!fupFileSend.HasFile)
            {
                if (bus.GuidanceInsert("Guidance_Insert", UserCardId, DepartmentId, GuidanceName, GuidanceLevel, GuidanceValue, PartnerRank, PartnerValue, Remarks, ""))
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
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\" + Dates+ nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + nameLast;

                    if (bus.GuidanceInsert("Guidance_Insert", UserCardId, DepartmentId, GuidanceName, GuidanceLevel, GuidanceValue, PartnerRank, PartnerValue, Remarks, path))
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
            string GuidanceName = txtGuidanceName.Text;
            double GuidanceValue;
            string GuidanceLevel = txtGuidanceLevel.Text.Trim();
            string Remarks = txtRemarks.Text;
            double PartnerValue;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text; int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (GuidanceName == "")
            {
                AlertMsgAndNoFlush("请输入成果或调研报告名称");
                return;
            }
            if (GuidanceLevel == "")
            {
                AlertMsgAndNoFlush("请输入成果或采用级别");
                return;
            }
            if (txtGuidanceValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入成果分值");
                return;
            }
            try
            {
                GuidanceValue = Convert.ToDouble(txtGuidanceValue.Value);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush("成果分值应为正数");
                return;
            }
            if (GuidanceValue <= 0)
            {
                AlertMsgAndNoFlush("成果分值应为正数");
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
            if (GuidanceValue < PartnerValue)
            {
                AlertMsgAndNoFlush("本人得分应小于成果分值");
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\" + Dates+ nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\Guidance\\" + UserCardId + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            GuidanceId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["GuidanceId"], "asdfasdf"));
            if (bus.GuidanceUpdate("Guidance_Update", GuidanceId, DepartmentId, GuidanceName, GuidanceLevel, GuidanceValue, PartnerRank, PartnerValue, Remarks,path))
            {
              
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyGuidanceManage.aspx'}</script>");

            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}