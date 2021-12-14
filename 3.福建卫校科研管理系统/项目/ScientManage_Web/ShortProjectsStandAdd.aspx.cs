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
    public partial class ShortProjectsStandAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        string ShortProjectsId;
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
                DataSet Department = bus.SelectByUserCardId("WorkExperience_SelectByUserCardId",UserCardId);
                foreach (DataRow dr in Department.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentId"].ToString());
                    DlDepartmentId.Items.Add(li);
                }
                DataTable dt2 = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "横向项目立项").Tables[0];
                foreach (DataRow dr in dt2.Rows)
                {
                    ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                    DlCategory.Items.Add(li);
                }
                if (Request.QueryString["ShortProjectsId"] != null)
                {
                    try
                    {
                        ShortProjectsId = pwds.DecryptDES(Request.QueryString["ShortProjectsId"], "asdfasdf");
                    }
                    catch (Exception)
                    {

                        Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
                    }
                    Button1.Visible = false;
                    RBL1.Visible = true;
                    Lxiugai.Visible = true;
                  
                    DataSet ds = bus.SelectByShortProjectsId("ShortProjects_SelectByShortProjectsId", ShortProjectsId);
                    LShortProjectsId.Text = ds.Tables[0].Rows[0]["ShortProjectsId"].ToString();
                    txtContractId.Text = ds.Tables[0].Rows[0]["ContractId"].ToString();
                    txtContractName.Text = ds.Tables[0].Rows[0]["ContractName"].ToString();
                    txtContractMoney.Value = ds.Tables[0].Rows[0]["ContractMoney"].ToString();
                    DlDepartmentId.SelectedValue = ds.Tables[0].Rows[0]["DepartmentId"].ToString();
                    UserCardId = ds.Tables[0].Rows[0]["UserCardId"].ToString();
                    txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                    LFileUrl.Text = ds.Tables[0].Rows[0]["StandUrl"].ToString();
                   
                    DataTable dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["ZY_JobSeries"].ToString();
                    txtUserPost.Text = dt.Rows[0]["ZY_TitleLevelName"].ToString();
                    txtUserCardId.Text = UserCardId;
                }
                else
                {
                    
                    RBL1.Visible = false;
                    DataTable dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    DlDepartmentId.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    txtUserJob.Text = dt.Rows[0]["ZY_JobSeries"].ToString();
                    txtUserPost.Text = dt.Rows[0]["ZY_TitleLevelName"].ToString();
                    txtUserCardId.Text = UserCardId;
                    LShortProjectsId.Text = DateTime.Now.ToString("yyyyMMddhhMMss") + DateTime.Now.Millisecond.ToString();
                    Button2.Visible = false;
                }
            }
        }
        //下载模板
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (DlCategory.SelectedValue != "0")
            {
                string path = Server.MapPath("./") + DlCategory.SelectedValue;
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
                Response.Write("<script>alert('请选择类别！')</script>");
                return;
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
            string ShortProjectsId = LShortProjectsId.Text;
            string ContractId=txtContractId.Text;
            string ContractName=txtContractName.Text;
            string ContractMoney = txtContractMoney.Value;
            string Company = txtCompany.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (ContractId == null)
            {
                Response.Write("<script>alert('请输入合同编号！')</script>");
                return;
            }
            if (ContractName == null)
            {
                Response.Write("<script>alert('请输入合同名称！')</script>");
                return;
            }
            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                Response.Write("<script>alert('请选择所在院系！')</script>");
                return;
            }
            if (ContractMoney == null)
            {
                Response.Write("<script>alert('请输入合同金额！')</script>");
                return;
            }
            try
            {
                Convert.ToDouble(ContractMoney);
            }
            catch (Exception)
            {
                
                 Response.Write("<script>alert('合同金额请输入不小于0的数字！')</script>");
                return;
            }
            if (Convert.ToDouble(ContractMoney)<0)
            {
                  Response.Write("<script>alert('合同金额请输入不小于0的数字！')</script>");
                return;
            }
            if (Company== null)
            {
                Response.Write("<script>alert('请输入合作单位！')</script>");
                return;
            }
            if (!fupFileSend.HasFile)
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                return;
            }
            try
            {
                //获取上传文件的名称
                string upName = fupFileSend.FileName;
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                //创建文件夹
                string sPath = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\" + upName;
                LFileUrl.Text = path;
                if (bus.ShortProjectsInsert("ShortProjects_Insert", ShortProjectsId, UserCardId, DepartmentId, ContractId,ContractName,Convert.ToDouble( ContractMoney),Company, path))
                {
                    Response.Write("<script>alert('添加成功！');window.history.go(-2);</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ShortProjectsId = LShortProjectsId.Text;
            string ContractId = txtContractId.Text;
            string ContractName = txtContractName.Text;
            string ContractMoney = txtContractMoney.Value;
            string Company = txtCompany.Text;
            int DepartmentId = Convert.ToInt32(DlDepartmentId.SelectedValue);

            if (ContractId == null)
            {
                Response.Write("<script>alert('请输入合同编号！')</script>");
                return;
            }
            if (ContractName == null)
            {
                Response.Write("<script>alert('请输入合同名称！')</script>");
                return;
            }
            if (Convert.ToInt32(this.DlDepartmentId.SelectedValue) == 0)
            {
                Response.Write("<script>alert('请选择所在院系！')</script>");
                return;
            }
            if (ContractMoney == null)
            {
                Response.Write("<script>alert('请输入合同金额！')</script>");
                return;
            }
            try
            {
                Convert.ToDouble(ContractMoney);
            }
            catch (Exception)
            {

                Response.Write("<script>alert('合同金额请输入不小于0的数字！')</script>");
                return;
            }
            if (Convert.ToDouble(ContractMoney) < 0)
            {
                Response.Write("<script>alert('合同金额请输入不小于0的数字！')</script>");
                return;
            }
            if (Company == null)
            {
                Response.Write("<script>alert('请输入合作单位！')</script>");
                return;
            }
            string path = LFileUrl.Text;
            string RBL = RBL1.SelectedItem.Value;
            if (RBL == "是")
            {
                if (!fupFileSend.HasFile)
                {
                    Response.Write("<script>alert('暂未上传文件，请上传文件后添加！')</script>");
                    return;
                }
                try
                {
                    //获取上传文件的名称
                    string upName = fupFileSend.FileName;
                    //获取上传文件的后缀名
                    string nameLast = upName.Substring(upName.LastIndexOf("."));
                    //创建文件夹
                    string sPath = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\";
                    Directory.CreateDirectory(Server.MapPath("./") + sPath);
                    //设置要保存的路径
                    path = Server.MapPath("./") + "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\" + upName;
                    //将文件保存到指定路径下
                    fupFileSend.PostedFile.SaveAs(path);
                    path = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\Stand\\" + upName;
                    LFileUrl.Text = path;
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    Response.Write("<script>alert('上传失败！')</script>");
                }
            }
            if (bus.ShortProjectsInsert("ShortProjects_Update", ShortProjectsId, UserCardId, DepartmentId, ContractId,ContractName,Convert.ToDouble(ContractMoney), Company, path))
            {
                Response.Write("<script>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
            }

        }
    }
}