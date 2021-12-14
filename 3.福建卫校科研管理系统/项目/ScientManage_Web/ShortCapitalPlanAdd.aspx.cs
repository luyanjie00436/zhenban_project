﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class ShortCapitalPlanAdd : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
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

                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
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
                    DataTable dt2 = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "经费预算").Tables[0];
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListItem li = new ListItem(dr["TemplateName"].ToString(), dr["FileUrl"].ToString());
                        DlCategory.Items.Add(li);
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
                        LBidMoney.Text = dt.Tables[0].Rows[0]["BidMoney"].ToString();
                        LSupportMoney.Text = dt.Tables[0].Rows[0]["SupportMoney"].ToString();
                        LOtherMoney.Text = dt.Tables[0].Rows[0]["OtherMoney"].ToString();
                        LSuedCompany.Text = dt.Tables[0].Rows[0]["SuedCompany"].ToString();
                        LServicelife.Text = dt.Tables[0].Rows[0]["Servicelife"].ToString();
                        LSumMoney.Text = dt.Tables[0].Rows[0]["SumMoney"].ToString();
                    }
                    dt.Clear();
                    dt = bus.SelectByShortProjectsId("ShortCapitalPlan_SelectByShortProjectsId", ShortProjectsId);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        LFileUrl.Text = dt.Tables[0].Rows[0]["ShortCapitalPlanUrl"].ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ShortProjectsId = LProjectsId.Text;
            string path = LFileUrl.Text;
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
                string sPath = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\CapitalPlan\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                path = Server.MapPath("./") + "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\CapitalPlan\\" + upName;
                //将文件保存到指定路径下
                fupFileSend.PostedFile.SaveAs(path);
                path = "File" + "\\" + "ShortProjects" + "\\" + ShortProjectsId + "\\CapitalPlan\\" + upName;
                LFileUrl.Text = path;
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('文件上传失败！')</script>");
            }

            if (path == "")
            {
                Response.Write("<script>alert('暂未上传文件，请上传文件后保存！')</script>");
                return;
            }
            if (bus.ShortCapitalPlanInsert("ShortCapitalPlan_Insert", ShortProjectsId, UserCardId, path))
           {
               Response.Write("<script>alert('保存成功！');window.history.go(-2);</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
            }

        }

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
    }
}