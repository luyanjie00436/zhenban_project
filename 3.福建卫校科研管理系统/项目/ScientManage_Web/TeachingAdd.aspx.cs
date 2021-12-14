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
    public partial class TeachingAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();

        string UserCardId;
        int TeachingId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/TeachingAdd.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                }
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }

                if (Request.QueryString["TeachingId"] != null)
                {

                    try
                    {
                        TeachingId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    Lxiugai.Visible = true;
                    DataSet dt = bus.SelectByTeachingId("Teaching_SelectByTeachingId", TeachingId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    DlDepartmentId.SelectedValue = dt.Tables[0].Rows[0]["DepartmentId"].ToString();
                    txtBookName.Text = dt.Tables[0].Rows[0]["BookName"].ToString();
                    txtPressCategory.Text = dt.Tables[0].Rows[0]["PressCategory"].ToString();
                    txtPressName.Text = dt.Tables[0].Rows[0]["PressName"].ToString();
                    txtPressDate.Text = dt.Tables[0].Rows[0]["PressDate"].ToString();
                    txtRevision.Text = dt.Tables[0].Rows[0]["Revision"].ToString();
                    txtRemarks.Text= dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtTotalNumber.Value= dt.Tables[0].Rows[0]["TotalNumber"].ToString();
                    LFileUrl.Text = dt.Tables[0].Rows[0]["TeachingUrl"].ToString();
                    txtTeachingValue.Value = dt.Tables[0].Rows[0]["TeachingValue"].ToString();
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
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);            
            string BookName = txtBookName.Text;
            string PressCategory = txtPressCategory.Text;
            string PressName = txtPressName.Text;
            string PressDate = txtPressDate.Text;
            string Revision = txtRevision.Text;
            string TotalNumber = txtTotalNumber.Value;
            double TeachingValue;
            double PartnerValue;
            int PartnerRank;
            string Remarks = txtRemarks.Text;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }
            if (BookName == "")
            {
                AlertMsgAndNoFlush( "请输入著作名称");
                return;
            }
            if (PressCategory == "")
            {
                AlertMsgAndNoFlush( "请输入出版类型");
                return;
            }
            if (PressName == "")
            {
                AlertMsgAndNoFlush( "请输入出版社");
                return;
            }
            if (PressDate == "")
            {
                AlertMsgAndNoFlush( "请输入出版时间");
                return;
            }
            if (Revision == "")
            {
                AlertMsgAndNoFlush( "请输入版次");
                return;
            }
            if (TotalNumber == "")
            {
                AlertMsgAndNoFlush( "请输入字数");
                return;
            }
            if (txtTeachingValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入成果分值");
                return;
            }
            try
            {
                TeachingValue = Convert.ToDouble(txtTeachingValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (TeachingValue <= 0)
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
            if (TeachingValue < PartnerValue)
            {
                AlertMsgAndNoFlush( "本人得分应小于成果分值");
                return;
            }
             if (!fupFileSend.HasFile)
            {
                if (bus.TeachingInsert("Teaching_Insert", UserCardId, DepartmentId, BookName, PressCategory, PressName, PressDate, Revision, TotalNumber, TeachingValue, PartnerRank, PartnerValue, Remarks, ""))
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
                    string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //设置要保存的路径
                    string path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\" + Dates + nameLast;


                    if (bus.TeachingInsert("Teaching_Insert", UserCardId, DepartmentId, BookName, PressCategory, PressName, PressDate, Revision, TotalNumber, TeachingValue, PartnerRank, PartnerValue, Remarks, path))
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
       
        public void AlertMsgAndNoFlush( string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string BookName = txtBookName.Text;
            string PressCategory = txtPressCategory.Text;
            string PressName = txtPressName.Text;
            string PressDate = txtPressDate.Text;
            string Revision = txtRevision.Text;
            string TotalNumber = txtTotalNumber.Value;
            double TeachingValue;
            double PartnerValue;
            string Remarks = txtRemarks.Text;
            int PartnerRank;
            string ApplyYearName = txtApplyYear.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                AlertMsgAndNoFlush("选择所在院系");
                return;
            }

            if (BookName == "")
            {
                AlertMsgAndNoFlush( "请输入教材名称");
                return;
            }
            if (PressCategory == "")
            {
                AlertMsgAndNoFlush( "请输入出版类型");
                return;
            }
            if (PressName == "")
            {
                AlertMsgAndNoFlush( "请输入出版社");
                return;
            }
            if (PressDate == "")
            {
                AlertMsgAndNoFlush( "请输入出版时间");
                return;
            }
            if (Revision == "")
            {
                AlertMsgAndNoFlush( "请输入版次");
                return;
            }
            if (TotalNumber == "")
            {
                AlertMsgAndNoFlush( "请输入字数");
                return;
            }
            if (txtTeachingValue.Value == "")
            {
                AlertMsgAndNoFlush( "请输入成果分值");
                return;
            }
            try
            {
                TeachingValue = Convert.ToDouble(txtTeachingValue.Value);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (TeachingValue <= 0)
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
            if (TeachingValue < PartnerValue)
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
                        string sPath = "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\";
                        Directory.CreateDirectory(Server.MapPath("./") + sPath);
                        string Dates = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //设置要保存的路径
                        path = Server.MapPath("./") + "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                        //将文件保存到指定路径下
                        fupFileSend.PostedFile.SaveAs(path);
                        path = "File\\WorkLoad\\" + ApplyYearName + "\\Teaching\\" + UserCardId + "\\" + Dates + nameLast;
                        LFileUrl.Text = path;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                        Response.Write("<script>alert('上传失败！')</script>");
                    }
                }
              
            }


            if (bus.TeachingUpdate("Teaching_Update", Convert.ToInt32(pwds.DecryptDES(Request.QueryString["TeachingId"], "asdfasdf")), DepartmentId, BookName, PressCategory, PressName, PressDate, Revision, TotalNumber, TeachingValue, PartnerRank, PartnerValue,Remarks,path))
            {
                //AlertMsgAndNoFlush( "修改成功");
                //Response.Redirect("MyTeachingManage.aspx");
                Response.Write("<script>if (confirm('修改成功！是否跳转到个人申请记录页面？')) { window.location = 'MyTeachingManage.aspx'}</script>");
            }
            else
            {
                AlertMsgAndNoFlush( "修改失败！");
            }
        }
    }
}