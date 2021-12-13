using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace ningdeScientManage_Web
{
    public partial class PaperAdd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        int PaperId;
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/PaperAdd.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DLCategory.Items.Add("==请选择==");
                DLCategory.Items[0].Value = "0";
                DataTable ds = bus.SelectByWorkCategoryName("WorkCategory_SelectByWorkCategoryName", "论文").Tables[0];
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLCategory.Items.Add(li);
                }
                DataSet dt2 = bus.Select("HarvestDate_SelectisApply");
                LStartDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                LEndDate.Text = Convert.ToDateTime(dt2.Tables[0].Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
               
                if (Request.QueryString["PaperId"] != null)
                {
                    try
                    {
                        PaperId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["PaperId"], "asdfasdf"));
                    }
                    catch (Exception)
                    {

                          Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                    }
                    Button1.Visible = false;
                    DataSet dt = bus.SelectByPaperId("Paper_SelectByPaperId", PaperId);
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtPaperSubject.Text = dt.Tables[0].Rows[0]["PaperSubject"].ToString();
                    txtFollDate.Text = dt.Tables[0].Rows[0]["FollDate"].ToString();
                    txtPaperName.Text = dt.Tables[0].Rows[0]["PaperName"].ToString();
                    txtPaperDate.Value = dt.Tables[0].Rows[0]["PaperDate"].ToString();
                    txtPaperYears.Text = dt.Tables[0].Rows[0]["PaperYears"].ToString();
                    txtRemarks.Text = dt.Tables[0].Rows[0]["Remarks"].ToString();
                    txtPublicationName.Text = dt.Tables[0].Rows[0]["PublicationName"].ToString();
                    DlAuthorsOrder.SelectedValue = dt.Tables[0].Rows[0]["AuthorsOrder"].ToString();
                    txtPaperValue.Text = dt.Tables[0].Rows[0]["PaperValue"].ToString();

                    DlPartnerRank.SelectedValue= dt.Tables[0].Rows[0]["PartnerRank"].ToString();
                    txtPartnerValue.Text = dt.Tables[0].Rows[0]["PartnerValue"].ToString();
                    for (int i = 0; i < DLCategory.Items.Count; i++)
                    {
                        if (DLCategory.Items[i].Text == dt.Tables[0].Rows[0]["DCategory"].ToString())
                        {
                            DLCategory.Items[i].Selected = true;
                            break;
                        }
                    }
                    CategoryChange();
                    for (int i = 0; i < DLLevel.Items.Count; i++)
                    {
                        if (DLLevel.Items[i].Text == dt.Tables[0].Rows[0]["DLevel"].ToString())
                        {
                            DLLevel.Items[i].Selected = true;
                            break;
                        }
                    }
                    txtPaperValue.Text = dt.Tables[0].Rows[0]["PaperValue"].ToString();
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                }
                else
                {
                    DataSet dt = bus.Select("ApplyYear_SelectisApply");
                    txtApplyYear.Text = dt.Tables[0].Rows[0]["ReportDate"].ToString();
                    txtFollDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                    dt = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                    txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                    Button2.Visible = false;
                }


            }

        }
        public void CategoryChange()
        {

            int FatherId = Convert.ToInt32(DLCategory.SelectedValue);
            DataTable ds = bus.SelectByWorkCategoryId("WorkCategory_SelectWorkValue", FatherId).Tables[0];
            if (ds.Rows.Count > 0 && ds.Columns.Count > 1)
            {
                DLLevel.Items.Add("==请选择==");
                DLLevel.Items[0].Value = "0";
                foreach (DataRow dr in ds.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLLevel.Items.Add(li);
                }
                txtPaperValue.Text = "0";
            }
            else
            {
                txtPaperValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           DateTime NowDate = Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime StartDate = Convert.ToDateTime(LStartDate.Text);
            DateTime EndDate = Convert.ToDateTime(LEndDate.Text);
            if (NowDate < StartDate || NowDate > EndDate)
            {
                AlertMsgAndNoFlush( "未在申报的有效时间内，禁止申报。");
                return;
            }
           
           
            string UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string PaperDate = txtPaperDate.Value;
            string PaperSubject = txtPaperSubject.Text.Trim();
            string PaperYears = txtPaperYears.Text.Trim();
            string PaperName = txtPaperName.Text.Trim();
            string Remarks = txtRemarks.Text;
            string PublicationName = txtPublicationName.Text;
            string DCategory = DLCategory.SelectedItem.Text;
            string DLevel = "";
            string AuthorsOrder;
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }        

            double PaperValue;
            double PartnerValue;
            int PartnerRank;

            if (PaperSubject == "")
            {
                AlertMsgAndNoFlush( "请输入论文题目");
                return;
            }
            if (PublicationName == "")
            {
                AlertMsgAndNoFlush( "请输入刊物名称");
                return;
            }
            if (PaperName == "")
            {
                AlertMsgAndNoFlush( "请输入论文刊号");
                return;
            }
            if (PaperDate == "")
            {
                AlertMsgAndNoFlush( "请输入成果获得时间");
                return;
            }
            if (PaperYears == "")
            {
                AlertMsgAndNoFlush( "请输入论文刊物期数");
                return;
            }
            if (DlAuthorsOrder.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush( "请选择作者顺序");
                return;
            }
            AuthorsOrder = Convert.ToString(DlAuthorsOrder.SelectedItem.Text);

          

            if (txtPaperValue.Text == "")
                {
                    AlertMsgAndNoFlush( "请输入成果分值");
                    return;
                }
                try
                {
                    PaperValue = Convert.ToDouble(txtPaperValue.Text);
                }
                catch (Exception)
                {

                    AlertMsgAndNoFlush( "成果分值应为正数");
                    return;
                }
                if (PaperValue <= 0)
                {
                    AlertMsgAndNoFlush( "成果分值应为正数");
                    return;
                }
                if (txtPartnerValue.Text == "")
                {
                    AlertMsgAndNoFlush( "请输入本人得分");
                    return;
                }
                try
                {
                    PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
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

                if (DlPartnerRank.SelectedItem.Text == "==请选择==")
                {
                    AlertMsgAndNoFlush( "请选择个人排名");
                    return;
                }
                PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
                if (PaperValue < PartnerValue)
                {
                    AlertMsgAndNoFlush( "本人得分应小于成果分值");
                    return;
                }
            try
            {
                //获取上传文件的名称
               
                string upName = FileUpload1.FileName;

              
                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                upName = PaperName + nameLast;
                //创建文件夹
                string sPath = "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\" + upName;
                FileInfo file = new FileInfo(path);//指定文件路径
                if (file.Exists)//判断文件是否存在
                {
                    Response.Write("<script>alert('上传失败！文件已存在，请选用其他名称')</script>");
                    return;
                }
                //将文件保存到指定路径下
                FileUpload1.PostedFile.SaveAs(path);
                path = "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\" + upName;
         

            if (bus.PaperInsert("Paper_Insert", UserCardId, PaperName, PaperSubject, AuthorsOrder, DCategory, DLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks, PublicationName, PaperDate, path))
                {
                  
                    Response.Write("<script>if (confirm('已申请成功！是否继续分配成员分值？')) { window.location = 'PaperPartnerManage.aspx'}</script>");
                }
                else
                {
                    AlertMsgAndNoFlush( "申请失败！可能是没有您的审批流程");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
                return;
            }
        }

        protected void DLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DLLevel.Items.Clear();
            if (DLCategory.SelectedValue != "0")
            {
                CategoryChange();
            }
        }
        protected void DLLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DLLevel.SelectedValue != "0")
            {
                int FatherId = Convert.ToInt32(DLLevel.SelectedValue);
                DataTable ds = bus.SelectByWorkCategoryId("WorkCategory_SelectWorkValue", FatherId).Tables[0];
                txtPaperValue.Text = ds.Rows[0]["WorkValue"].ToString();
            }
        }
        public  void AlertMsgAndNoFlush( string message)
        {
            Response.Write("<script>alert('"+ message + "')</script>");
         }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DateTime NowDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            string PaperName = txtPaperName.Text;
            double PaperValue;
            string PaperDate = txtPaperDate.Value;
            string PaperSubject = txtPaperSubject.Text.Trim();
            string PaperYears = txtPaperYears.Text.Trim();
            string DCategory = DLCategory.SelectedItem.Text;
            string PublicationName = txtPublicationName.Text;
            string DLevel = "";
            string AuthorsOrder;
            if (DLLevel.Items.Count > 0)
            {
                DLevel = DLLevel.SelectedItem.Text;
            }
            string Remarks = txtRemarks.Text;
            double PartnerValue;
            int PartnerRank;


            if (PaperSubject == "")
            {
                AlertMsgAndNoFlush( "请输入论文题目");
                return;
            }
            if (PublicationName == "")
            {
                AlertMsgAndNoFlush( "请输入刊物名称");
                return;
            }
            if (PaperName == "")
            {
                AlertMsgAndNoFlush( "请输入论文刊号");
                return;
            }

            if (PaperDate == "")
            {
                AlertMsgAndNoFlush( "请输入成果获得时间");
                return;
            }
            if (PaperYears == "")
            {
                AlertMsgAndNoFlush( "请输入论文刊物期数");
                return;
            }
            if (DlAuthorsOrder.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush( "请选择作者顺序");
                return;
            }
            AuthorsOrder = Convert.ToString(DlAuthorsOrder.SelectedItem.Text);
          
            if (txtPaperValue.Text == "")
            {
                AlertMsgAndNoFlush( "请输入成果分值");
                return;
            }
            try
            {
                PaperValue = Convert.ToDouble(txtPaperValue.Text);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (PaperValue <= 0)
            {
                AlertMsgAndNoFlush( "成果分值应为正数");
                return;
            }
            if (txtPartnerValue.Text == "")
            {
                AlertMsgAndNoFlush( "请输入本人得分");
                return;
            }
            try
            {
                PartnerValue = Convert.ToDouble(txtPartnerValue.Text);
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

            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush( "请选择个人排名");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (PaperValue < PartnerValue)
            {
                AlertMsgAndNoFlush( "本人得分应小于成果分值");
                return;
            }

            PaperId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["PaperId"], "asdfasdf"));



            try
            {
                //获取上传文件的名称

                string upName = FileUpload1.FileName;


                //获取上传文件的后缀名
                string nameLast = upName.Substring(upName.LastIndexOf("."));
                upName = PaperName + nameLast;
                //创建文件夹
                string sPath = "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\";
                Directory.CreateDirectory(Server.MapPath("./") + sPath);
                //设置要保存的路径
                string path = Server.MapPath("./") + "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\" + upName;
                FileInfo file = new FileInfo(path);//指定文件路径
                if (file.Exists)//判断文件是否存在
                {
                    Response.Write("<script>alert('上传失败！文件已存在，请选用其他名称')</script>");
                    return;
                }
                //将文件保存到指定路径下
                FileUpload1.PostedFile.SaveAs(path);
                path = "File" + "\\" + "Paper" + "\\" + NowDate.ToString("YYYYMM") + "\\" + UserCardId + "\\" + upName;


                
                if (bus.PaperUpdate("Paper_Update", PaperId, PaperName, PaperSubject, AuthorsOrder, DCategory, DLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks, PublicationName, PaperDate,path))
                {

                    Response.Redirect("MyPaperManage.aspx");
                }
                else
                {
                    AlertMsgAndNoFlush("修改失败！");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write("<script>alert('上传失败！')</script>");
                return;
            }


          
        }
    }
}