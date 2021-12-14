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
    public partial class WinningAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int WinningId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WinningAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["WinningId"] != null)
                {
                    try
                    {
                        WinningId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WinningId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByWinningId("Winning_SelectByWinningId", WinningId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtWinningName.Text = dt.Tables[0].Rows[0]["WinningName"].ToString();
                    txtWinningCategory.Text = dt.Tables[0].Rows[0]["WinningCategory"].ToString();
                    txtWinningLevel.Text = dt.Tables[0].Rows[0]["WinningLevel"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["WinningUrl"].ToString();
                    txtWinningValue.Value = dt.Tables[0].Rows[0]["WinningValue"].ToString();
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
            string Remarks = txtRemarks.Text;
            string WinningName = txtWinningName.Text.Trim();
            string WinningCategory = txtWinningCategory.Text.Trim();
            string WinningLevel = txtWinningLevel.Text.Trim();

            double WinningValue;
            double PartnerValue;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (WinningName == "")
            {
                AlertMsgAndNoFlush( "请输入获奖项目名称");
                return;
            }
            if (WinningCategory == "")
            {
                AlertMsgAndNoFlush( "请输入获奖项目时间、类别");
                return;
            }
          
            if (txtWinningValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入成果分值");
                return;
            }
            try
            {
                WinningValue = Convert.ToDouble(txtWinningValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (WinningValue <= 0)
            {
                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (txtPartnerValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush( "本人得分应为正数");
                return;
            }

            if (txtPartnerRank.Value == "==请选择==")
            {
                AlertMsgAndNoFlush( "请选择个人排名");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){AlertMsgAndNoFlush("本人排名应为正数");return;}
            if (WinningValue < PartnerValue)
            {
                AlertMsgAndNoFlush( "本人得分应小于成果分值");
                return;
            }
            if (!fupFileSend.HasFile)
            {
                if (bus.WinningInsert("Winning_Insert", UserCardId, DepartmentId, WinningName, WinningCategory, WinningLevel, WinningValue, PartnerRank, PartnerValue, Remarks, ""))
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
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\" + Dates + nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\" + Dates + nameLast;

                    if (bus.WinningInsert("Winning_Insert", UserCardId, DepartmentId, WinningName, WinningCategory, WinningLevel, WinningValue, PartnerRank, PartnerValue, Remarks, path))
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
        public  void AlertMsgAndNoFlush( string message)
        {
           // ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
            Response.Write("<script>alert('"+message+"！')</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string WinningName = txtWinningName.Text;
            double WinningValue;
            string WinningCategory = txtWinningCategory.Text.Trim();
            string WinningLevel = txtWinningLevel.Text.Trim();
            string Remarks = txtRemarks.Text;
            double PartnerValue;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }

            if (WinningName == "")
            {
                AlertMsgAndNoFlush( "请输入获奖项目名称");
                return;
            }
            if (WinningCategory == "")
            {
                AlertMsgAndNoFlush( "请输入获奖项目时间、类别");
                return;
            }
        

            if (txtWinningValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入成果分值");
                return;
            }
            try
            {
                WinningValue = Convert.ToDouble(txtWinningValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (WinningValue <= 0)
            {
                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (txtPartnerValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "本人得分应为正数");
                return;
            }
            if (PartnerValue <= 0)
            {
                AlertMsgAndNoFlush( "本人得分应为正数");
                return;
            }

            if (txtPartnerRank.Value == "==请选择==")
            {
                AlertMsgAndNoFlush( "请选择个人排名");
                return;
            }
            try{PartnerRank = Convert.ToInt32(txtPartnerRank.Value);}catch (Exception){AlertMsgAndNoFlush("本人排名应为正数");return;}
            if (WinningValue < PartnerValue)
            {
                AlertMsgAndNoFlush( "本人得分应小于成果分值");
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\Winning\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            WinningId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["WinningId"], "asdfasdf"));
            if (bus.WinningUpdate("Winning_Update",  WinningId, DepartmentId, WinningName, WinningCategory, WinningLevel, WinningValue, PartnerRank, PartnerValue, Remarks,path))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyWinningManage.aspx'}</script>");
                
               
            }
            else
            {
                AlertMsgAndNoFlush( "修改失败！");
            }
        }
    }
}