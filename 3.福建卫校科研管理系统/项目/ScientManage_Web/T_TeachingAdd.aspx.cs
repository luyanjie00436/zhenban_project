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
    public partial class T_TeachingAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int T_TeachingId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/T_TeachingAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["T_TeachingId"] != null)
                {
                    try
                    {
                        T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByT_TeachingId("T_Teaching_SelectByT_TeachingId", T_TeachingId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtT_TeachingName.Text = dt.Tables[0].Rows[0]["T_TeachingName"].ToString();
                    DlCategory.Text = dt.Tables[0].Rows[0]["Category"].ToString();
                    txtPress.Text = dt.Tables[0].Rows[0]["Press"].ToString();
                    txtTime.Value = dt.Tables[0].Rows[0]["Time"].ToString();
                    txtEdition.Text = dt.Tables[0].Rows[0]["Edition"].ToString();
                    txtCompiledwords.Text = dt.Tables[0].Rows[0]["Compiledwords"].ToString();
                    txtEditorRanking.Text = dt.Tables[0].Rows[0]["EditorRanking"].ToString();
                    txtScore.Text = dt.Tables[0].Rows[0]["Score"].ToString();
                    txtReference.Text = dt.Tables[0].Rows[0]["Reference"].ToString();
                    txtTotalscore.Text = dt.Tables[0].Rows[0]["Totalscore"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                  
                    txtPartnerValue.Value = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["T_TeachingUrl"].ToString();
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
            
            string T_TeachingName = txtT_TeachingName.Text.Trim();
            string Category = DlCategory.Text.Trim();
            string Press = txtPress.Text;
            string Time = txtTime.Value.Trim();
            string Edition = txtEdition.Text;
            string Compiledwords = txtCompiledwords.Text;
            string EditorRanking = txtEditorRanking.Text;
            string Score = txtScore.Text;
            string Reference = txtReference.Text;
            string Totalscore = txtTotalscore.Text;
            string Remarks = txtRemarks.Text;
            double PartnerValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (T_TeachingName == "")
            {
                AlertMsgAndNoFlush("请输入书名");
                return;
            }
            if (Category == "")
            {
                AlertMsgAndNoFlush("请输入出版类别");
                return;
            }
            if (Press == "")
            {
                AlertMsgAndNoFlush("请输入出版社");
                return;
            }
            if ( Time== "")
            {
                AlertMsgAndNoFlush("请输入出版时间");
                return;
            }
            if ( Edition== "")
            {
                AlertMsgAndNoFlush("请输入版次");
                return;
            }
            if ( Compiledwords== "")
            {
                AlertMsgAndNoFlush("请输入主编字数");
                return;
            }
            if (EditorRanking == "")
            {
                AlertMsgAndNoFlush("请输入主编名次");
                return;
            if ( Score== "")
            {
                AlertMsgAndNoFlush("请输入主编基础分得分");
                return;
            }
            if (Reference == "")
            {
                AlertMsgAndNoFlush("请输入参编者编写字数");
                return;
            }
            if (Totalscore == "")
            {
                AlertMsgAndNoFlush("字数配套得分");
                return;
            }
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
          
            if (!fupFileSend.HasFile)
            {
                if (bus.T_TeachingInsert("T_Teaching_Insert", UserCardId,DepartmentId, T_TeachingName, Category, Press, Time, Edition, Compiledwords, EditorRanking, Score, Reference, Totalscore, "", PartnerValue, Remarks))
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
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\" + Dates+ nameLast;

                    if (bus.T_TeachingInsert("T_Teaching_Insert", UserCardId,DepartmentId, T_TeachingName, Category, Press, Time, Edition, Compiledwords, EditorRanking, Score, Reference, Totalscore, path, PartnerValue, Remarks))
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
            string T_TeachingName = txtT_TeachingName.Text.Trim();
            string Category = DlCategory.Text.Trim();
            string Press = txtPress.Text;
            string Time = txtTime.Value;
            string Edition = txtEdition.Text;
            string Compiledwords = txtCompiledwords.Text;
            string EditorRanking = txtEditorRanking.Text;
            string Score = txtScore.Text;
            string Reference = txtReference.Text;
            string Totalscore = txtTotalscore.Text;
            string Remarks = txtRemarks.Text;
            double T_TeachingValue;
            double PartnerValue;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (T_TeachingName == "")
            {
                AlertMsgAndNoFlush("请输入书名");
                return;
            }
            if (Category == "")
            {
                AlertMsgAndNoFlush("请输入出版类别");
                return;
            }
            if (Press == "")
            {
                AlertMsgAndNoFlush("请输入出版社");
                return;
            }
            if (Time == "")
            {
                AlertMsgAndNoFlush("请输入出版时间");
                return;
            }
            if (Edition == "")
            {
                AlertMsgAndNoFlush("请输入版次");
                return;
            }
            if (Compiledwords == "")
            {
                AlertMsgAndNoFlush("请输入主编字数");
                return;
            }
            if (EditorRanking == "")
            {
                AlertMsgAndNoFlush("请输入主编名次");
                return;
                if (Score == "")
                {
                    AlertMsgAndNoFlush("请输入主编基础分得分");
                    return;
                }
                if (Reference == "")
                {
                    AlertMsgAndNoFlush("请输入参编者编写字数");
                    return;
                }
                if (Totalscore == "")
                {
                    AlertMsgAndNoFlush("字数配套得分");
                    return;
                }
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\T_Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
               
            }
            T_TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["T_TeachingId"], "asdfasdf"));
            if (bus.T_TeachingUpdate("T_Teaching_Update", T_TeachingId,DepartmentId, T_TeachingName, Category, Press, Time, Edition, Compiledwords, EditorRanking, Score, Reference, Totalscore,path, PartnerValue, Remarks))
            {
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyT_TeachingManage.aspx'}</script>");


            }
            else
            {
                AlertMsgAndNoFlush("修改失败！");
            }
        }
    }
}