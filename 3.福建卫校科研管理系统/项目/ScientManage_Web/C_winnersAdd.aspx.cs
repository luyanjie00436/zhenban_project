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
    public partial class C_winnersAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int C_winnersId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/C_winnersAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["C_winnersId"] != null)
                {
                    try
                    {
                        C_winnersId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["C_winnersId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByC_winnersId("C_winners_SelectByC_winnersId", C_winnersId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtC_winnersName.Text = dt.Tables[0].Rows[0]["C_winnersName"].ToString();
                    DlLeve.Text = dt.Tables[0].Rows[0]["Leve"].ToString();
                    txtTime.Value = dt.Tables[0].Rows[0]["Time"].ToString();
                    txtAward_level.Text = dt.Tables[0].Rows[0]["Award_level"].ToString();
                    txtOrganizational_Unit.Text = dt.Tables[0].Rows[0]["Organizational_Unit"].ToString();
                    txtC_winnersTotal.Value = dt.Tables[0].Rows[0]["C_winnersTotal"].ToString();
                    txtC_winnersDescription.Text = dt.Tables[0].Rows[0]["C_winnersDescription"].ToString();
                    DlRanking.Text = dt.Tables[0].Rows[0]["Ranking"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtC_winnersValue.Value = dt.Tables[0].Rows[0]["C_winnersValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["C_winnersUrl"].ToString();
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

            string C_winnersName = txtC_winnersName.Text.Trim();
            string Leve = DlLeve.Text.Trim();
            string Time = txtTime.Value;
            string Award_level = txtAward_level.Text.Trim();
            string Organizational_Unit = txtOrganizational_Unit.Text.Trim();
            double C_winnersTotal;
            string C_winnersDescription = txtC_winnersDescription.Text.Trim();
            string Ranking = DlRanking.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            double C_winnersValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (C_winnersName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (DlLeve.Text == "请选择项目级别")
            {
                AlertMsgAndNoFlush("请输入获奖项目级别");
                return;
            }
            if (Time == "")
            {
                AlertMsgAndNoFlush("请输入获奖时间");
                return;
            }
            if (Award_level == "")
            {
                AlertMsgAndNoFlush("请输入获奖等级");
                return;
            }
            if (Organizational_Unit == "")
            {
                AlertMsgAndNoFlush("请输入组织单位");
                return;
            }

            if (txtC_winnersTotal.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                C_winnersTotal = Convert.ToDouble(txtC_winnersTotal.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (C_winnersDescription == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }
            if (Convert.ToInt32(this.DlRanking.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("请选择排名");
                return;
            }

            if (txtC_winnersValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入个人工作量分值");
                return;
            }
            try
            {
                C_winnersValue = Convert.ToDouble(txtC_winnersValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("人工作量分值应为正数");
                return;
            }

            if (C_winnersValue <= 0)
            {
                AlertMsgAndNoFlush("工作量分值应为正数");
                return;
            }
            if (C_winnersValue > C_winnersTotal)
            {
                AlertMsgAndNoFlush("个人工作量分值应小于项目总分值");
                return;
            }

            if (!fupFileSend.HasFile)
            {
                if (bus.C_winnersInsert("C_winners_Insert", UserCardId,DepartmentId, C_winnersName, Leve, Time, Award_level, Organizational_Unit, C_winnersTotal, C_winnersDescription, Ranking, "", C_winnersValue, Remarks))
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
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\" +Dates  + nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\" + Dates+ nameLast;
                    if (bus.C_winnersInsert("C_winners_Insert", UserCardId,DepartmentId, C_winnersName, Leve, Time, Award_level, Organizational_Unit, C_winnersTotal, C_winnersDescription, Ranking, path, C_winnersValue, Remarks))
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
            string C_winnersName = txtC_winnersName.Text.Trim();
            string Leve = DlLeve.Text.Trim();
            string Time = txtTime.Value;
            string Award_level = txtAward_level.Text.Trim();
            string Organizational_Unit = txtOrganizational_Unit.Text.Trim();
            double C_winnersTotal;
            string C_winnersDescription = txtC_winnersDescription.Text.Trim();
            string Ranking = DlRanking.Text.Trim();
            string Remarks = txtRemarks.Text.Trim();
            double C_winnersValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (C_winnersName == "")
            {
                AlertMsgAndNoFlush("请输入项目名称");
                return;
            }
            if (Leve == "")
            {
                AlertMsgAndNoFlush("请输入级别");
                return;
            }
            if (Time == "")
            {
                AlertMsgAndNoFlush("请输入获奖时间");
                return;
            }
            if (Award_level == "")
            {
                AlertMsgAndNoFlush("请输入获奖等级");
                return;
            }
            if (Organizational_Unit == "")
            {
                AlertMsgAndNoFlush("请输入组织单位");
                return;
            }

            if (txtC_winnersTotal.Value == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值");
                return;
            }
            try
            {
                C_winnersTotal = Convert.ToDouble(txtC_winnersTotal.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("项目总分值应为正数");
                return;
            }
            if (C_winnersDescription == "")
            {
                AlertMsgAndNoFlush("请输入项目总分值说明");
                return;
            }
            if (DlRanking.Text == "==请选择==")
            {
                AlertMsgAndNoFlush("请选择排名");
                return;
            }

            if (txtC_winnersValue.Value == "")
            {
                AlertMsgAndNoFlush("请输入个人工作量分值");
                return;
            }
            try
            {
                C_winnersValue = Convert.ToDouble(txtC_winnersValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush("人工作量分值应为正数");
                return;
            }

            if (C_winnersValue <= 0)
            {
                AlertMsgAndNoFlush("工作量分值应为正数");
                return;
            }
            if (C_winnersValue > C_winnersTotal)
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\C_winners\\" + UserCardId + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
              
            }
            C_winnersId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["C_winnersId"], "asdfasdf"));
            if (bus.C_winnersUpdate("C_winners_Update", C_winnersId, DepartmentId, C_winnersName, Leve, Time, Award_level, Organizational_Unit, C_winnersTotal, C_winnersDescription, Ranking, path, C_winnersValue, Remarks))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyC_winnersManage.aspx'}</script>");


            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}