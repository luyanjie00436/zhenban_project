using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class MyProjectsApprovalManage : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        string proid;
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

                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            GridView1.DataSource = bus.SelectByUserCardId("LongProjectsDeclare_SelectByMyUserCardId", UserCardId).Tables[0].DefaultView;
            GridView1.DataBind();
        }
      
      
     
       
        //查看项目详情
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            DataTable dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", e.CommandArgument.ToString()).Tables[0];
            string url;
            if (dt.Rows[0]["LongProjectsCateGory"].ToString() == "自然科学类")
            {
                url = "/LongProjectsDeclareAdds.aspx?Proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");

            }
            else
            {
                url = "/LongProjectsDeclareAdd.aspx?Proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf");

            }
            Response.Redirect(url);
            //Response.Write("<script>window.open('/ProjectsAdds.aspx?proid=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "')</script>");

        }
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {
            Microsoft.Office.Interop.Word._Application appWord = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word._Document docFile = null;
           proid= e.CommandArgument.ToString();
            DataTable dt = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", proid).Tables[0];
            DataTable dt1 = bus.SelectByLongProjectsId("LongProjectsProblem_SelectByLongProjectsId", proid).Tables[0];
            DataTable dt2 = bus.SelectByLongProjectsId("NaturalCapital_SelectByLongProjectsId", proid).Tables[0];
            DataTable dt3 = bus.SelectByLongProjectsId("NaturalPartner_SelectByLongProjectsId", proid).Tables[0];
            DataTable dt4 = bus.SelectByLongProjectsId("LongProjectsDeclareExamine_Select",proid).Tables[0];
           
            if (dt.Rows[0]["LongProjectsCateGory"].ToString() == "自然科学类")
            {
                try
                {
                    appWord.Visible = false;
                    object objTrue = true;
                    object objFalse = false;
                    object objTemplate = Server.MapPath("File/Template/LongProjectsDeclareNatural.dot");
                    object objDocType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
                    docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
                    //第一步生成word文档<br />
                    //定义书签变量<br />
                    object obDD_ProjectsId = "ProjectsId";
                    object obDD_SmallCateGory = "SmallCateGory";
                    object obDD_Subject = "Subject";
                    object obDD_ProjectsName = "ProjectsName";
                    object obDD_UserName = "UserName";//姓 名<br />
                    object obDD_DepartmentName = "DepartmentName";
                    object obDD_Company = "Company";
                    object obDD_Year1 = "Year1";
                    object obDD_Month1 = "Month1";
                    object obDD_Day1 = "Day1";
                    object obDD_Problem1 = "Problem1";
                    object obDD_ApplyCapital = "ApplyCapital";
                    object obDD_Support = "Support";
                    object obDD_SumCapital = "SumCapital";
                    object obDD_Capital1 = "Capital1";
                    object obDD_Capital2 = "Capital2";
                    object obDD_Capital3 = "Capital3";
                    object obDD_Capital4 = "Capital4";
                    object obDD_Capital5 = "Capital5";
                    object obDD_Capital6 = "Capital6";
                    object obDD_Capital7 = "Capital7";
                    object obDD_Capital8 = "Capital8";
                    object obDD_Capital9 = "Capital9";
                    object obDD_Capital10 = "Capital10";
                    object obDD_Capital11 = "Capital11";
                    object obDD_Capital12 = "Capital12";
                    object obDD_Explain1 = "Explain1";
                    object obDD_Explain2 = "Explain2";
                    object obDD_Explain3 = "Explain3";
                    object obDD_Explain4 = "Explain4";
                    object obDD_Explain5 = "Explain5";
                    object obDD_Explain6 = "Explain6";
                    object obDD_Explain7 = "Explain7";
                    object obDD_Explain8 = "Explain8";
                    object obDD_Explain9 = "Explain9";
                    object obDD_Explain10 = "Explain10";
                    object obDD_Explain11 = "Explain11";
                    object obDD_Explain12 = "Explain12";
                    object obDD_Content1 = "Content1";
                    object obDD_Content2 = "Content2";
                    object obDD_Name1 = "Name1";
                    object obDD_Name2 = "Name2";
                    object obDD_Day2 = "Day2";
                    object obDD_Day3 = "Day3";
                    object obDD_Month2 = "Month2";
                    object obDD_Month3 = "Month3";
                    object obDD_Year2 = "Year2";
                    object obDD_Year3 = "Year3";
                    object obDD_PartnerNum = "PartnerNum";   
                    //给书签赋值
                    if (dt.Rows.Count>0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_ProjectsId).Range.Text = dt.Rows[0]["LongProjectsId"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_SmallCateGory).Range.Text = dt.Rows[0]["LongProjectsSmallCateGory"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Subject).Range.Text = dt.Rows[0]["LongProjectsSubject"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_ProjectsName).Range.Text = dt.Rows[0]["LongProjectsName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_UserName).Range.Text = dt.Rows[0]["UserName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_DepartmentName).Range.Text = dt.Rows[0]["DepartmentName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Company).Range.Text = dt.Rows[0]["Company"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Year1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Year.ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Month1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Month.ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Day1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Day.ToString();
                    
                    }
                  if (dt1.Rows.Count>0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Problem1).Range.Text = dt1.Rows[0]["ProblemOne"].ToString();
                      
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Capital1).Range.Text = dt2.Rows[0]["OneCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital2).Range.Text = dt2.Rows[0]["TwoCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital3).Range.Text = dt2.Rows[0]["ThreeCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital4).Range.Text = dt2.Rows[0]["ForeCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital5).Range.Text = dt2.Rows[0]["FiveCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital6).Range.Text = dt2.Rows[0]["SixCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital7).Range.Text = dt2.Rows[0]["SevenCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital8).Range.Text = dt2.Rows[0]["EightCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital9).Range.Text = dt2.Rows[0]["NightCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital10).Range.Text = dt2.Rows[0]["TenCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital11).Range.Text = dt2.Rows[0]["EleventCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital12).Range.Text = dt2.Rows[0]["TwelveCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain1).Range.Text = dt2.Rows[0]["OneExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain2).Range.Text = dt2.Rows[0]["TwoExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain3).Range.Text = dt2.Rows[0]["ThreeExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain4).Range.Text = dt2.Rows[0]["ForeExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain5).Range.Text = dt2.Rows[0]["FiveExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain6).Range.Text = dt2.Rows[0]["SixExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain7).Range.Text = dt2.Rows[0]["SevenExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain8).Range.Text = dt2.Rows[0]["EightExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain9).Range.Text = dt2.Rows[0]["NightExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain10).Range.Text = dt2.Rows[0]["TenExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain11).Range.Text = dt2.Rows[0]["EleventExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain12).Range.Text = dt2.Rows[0]["TwelveExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_SumCapital).Range.Text = dt2.Rows[0]["TotalCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_ApplyCapital).Range.Text = dt2.Rows[0]["ApplyCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Support).Range.Text = dt2.Rows[0]["Support"].ToString();
                    }

                    if (dt4.Rows.Count>0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Content1).Range.Text = dt4.Rows[0]["OneContent"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Content2).Range.Text = dt4.Rows[0]["TwoContent"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Name1).Range.Text = dt4.Rows[0]["OneName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Name2).Range.Text = dt4.Rows[0]["TwoName"].ToString();

                        if (dt4.Rows[0]["OneDate"].ToString() != "")
                        {
                            docFile.Bookmarks.get_Item(ref obDD_Year2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Year.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Month2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Month.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Day2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Day.ToString();
                        }
                        if (dt4.Rows[0]["TwoDate"].ToString() != "")
                        {
                            docFile.Bookmarks.get_Item(ref obDD_Year3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Year.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Month3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Month.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Day3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Day.ToString();
                        }
                    }
                    #region 合作者表格
                    int dt3row = dt3.Rows.Count + 1;
                    object Nothing = System.Reflection.Missing.Value;
                  //  docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range.Tables.Add(docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range, 12, 12, ref Nothing, ref Nothing);
                    Microsoft.Office.Interop.Word.Table newTable = docFile.Tables.Add(docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range, dt3row, 6, ref Nothing, ref Nothing);
                    newTable.Cell(1, 1).Range.Text = "姓名";
                    newTable.Cell(1, 2).Range.Text = "职称";
                    newTable.Cell(1, 3).Range.Text = "从事专业";
                    newTable.Cell(1, 4).Range.Text = "项目中分工";
                    newTable.Cell(1, 5).Range.Text = "所在单位或系部";
                    newTable.Cell(1, 6).Range.Text = "签章";
                    for (int i = 0; i < dt3row-1; i++)
                    {
                        newTable.Cell(i + 2, 1).Range.Text = dt3.Rows[i]["UserName"].ToString();
                        newTable.Cell(i + 2, 2).Range.Text = dt3.Rows[i]["UserJob"].ToString();
                        newTable.Cell(i + 2, 3).Range.Text = dt3.Rows[i]["UserProfession"].ToString();
                        newTable.Cell(i + 2, 4).Range.Text = dt3.Rows[i]["UserWork"].ToString();
                        newTable.Cell(i + 2, 5).Range.Text = dt3.Rows[i]["UserCompany"].ToString();
                    }
                    //  Microsoft.Office.Interop.Word.Table newTable = (Microsoft.Office.Interop.Word.Table) dt3;
                    
                    newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    #endregion

                  

                    object filename = Server.MapPath("项目立项表.doc");
                    object miss = System.Reflection.Missing.Value;
                    docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    object missingValue = Type.Missing;
                    object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                    appWord.Quit(ref miss, ref miss, ref miss);
                    docFile = null;
                    appWord = null;
                    // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("项目立项表.doc"));
                    // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
                    string ReportFileName = Server.MapPath("项目立项表.doc");
                    System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
                    Response.AddHeader("Content-Length", filet.Length.ToString());

                    // 指定返回的是一个不能被客户端读取的流，必须被下载   
                    Response.ContentType = "application/ms-excel";

                    // 把文件流发送到客户端   
                    Response.WriteFile(filet.FullName);


                }
                catch 
                {

                    //捕捉异常，如果出现异常则清空实例，退出word,同时释放资源<br />
                    string aa = e.ToString();
                    object miss = System.Reflection.Missing.Value;
                    object missingValue = Type.Missing;
                    object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                    appWord.Quit(ref miss, ref miss, ref miss);
                    docFile = null;
                    appWord = null;

                }
            }
            else
            {
                try
                {
                    appWord.Visible = false;
                    object objTrue = true;
                    object objFalse = false;
                    object objTemplate = Server.MapPath("File/Template/LongProjectsDeclareSolociogy.dot");
                    object objDocType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
                    docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
                    //第一步生成word文档<br />
                    //定义书签变量<br />
                    object obDD_ProjectsId = "ProjectsId";
                    object obDD_SmallCateGory = "SmallCateGory";
                    object obDD_Subject = "Subject";
                    object obDD_ProjectsName = "ProjectsName";
                    object obDD_UserName = "UserName";//姓 名<br />
                    object obDD_DepartmentName = "DepartmentName";
                    object obDD_Company = "Company";
                    object obDD_Year1 = "Year1";
                    object obDD_Month1 = "Month1";
                    object obDD_Day1 = "Day1";
                    object obDD_Problem1 = "Problem1";
                    object obDD_ApplyCapital = "ApplyCapital";
                    object obDD_Support = "Support";
                    object obDD_SumCapital = "SumCapital";
                    object obDD_Capital1 = "Capital1";
                    object obDD_Capital2 = "Capital2";
                    object obDD_Capital3 = "Capital3";
                    object obDD_Capital4 = "Capital4";
                    object obDD_Capital5 = "Capital5";
                    object obDD_Capital6 = "Capital6";
                    object obDD_Capital7 = "Capital7";
                    object obDD_Capital8 = "Capital8";
                    object obDD_Capital9 = "Capital9";
                    object obDD_Capital10 = "Capital10";
                    object obDD_Capital11 = "Capital11";                   
                    object obDD_Explain1 = "Explain1";
                    object obDD_Explain2 = "Explain2";
                    object obDD_Explain3 = "Explain3";
                    object obDD_Explain4 = "Explain4";
                    object obDD_Explain5 = "Explain5";
                    object obDD_Explain6 = "Explain6";
                    object obDD_Explain7 = "Explain7";
                    object obDD_Explain8 = "Explain8";
                    object obDD_Explain9 = "Explain9";
                    object obDD_Explain10 = "Explain10";
                    object obDD_Explain11 = "Explain11";                   
                    object obDD_Content1 = "Content1";
                    object obDD_Content2 = "Content2";
                    object obDD_Name1 = "Name1";
                    object obDD_Name2 = "Name2";
                    object obDD_Day2 = "Day2";
                    object obDD_Day3 = "Day3";
                    object obDD_Month2 = "Month2";
                    object obDD_Month3 = "Month3";
                    object obDD_Year2 = "Year2";
                    object obDD_Year3 = "Year3";
                    object obDD_PartnerNum = "PartnerNum";
                    //给书签赋值
                    if (dt.Rows.Count > 0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_ProjectsId).Range.Text = dt.Rows[0]["LongProjectsId"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_SmallCateGory).Range.Text = dt.Rows[0]["LongProjectsSmallCateGory"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Subject).Range.Text = dt.Rows[0]["LongProjectsSubject"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_ProjectsName).Range.Text = dt.Rows[0]["LongProjectsName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_UserName).Range.Text = dt.Rows[0]["UserName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_DepartmentName).Range.Text = dt.Rows[0]["DepartmentName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Company).Range.Text = dt.Rows[0]["Company"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Year1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Year.ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Month1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Month.ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Day1).Range.Text = Convert.ToDateTime(dt.Rows[0]["FollDate"].ToString()).Day.ToString();

                    }
                    if (dt1.Rows.Count > 0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Problem1).Range.Text = dt1.Rows[0]["ProblemOne"].ToString();

                    }
                    if (dt2.Rows.Count > 0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Capital1).Range.Text = dt2.Rows[0]["OneCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital2).Range.Text = dt2.Rows[0]["TwoCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital3).Range.Text = dt2.Rows[0]["ThreeCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital4).Range.Text = dt2.Rows[0]["ForeCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital5).Range.Text = dt2.Rows[0]["FiveCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital6).Range.Text = dt2.Rows[0]["SixCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital7).Range.Text = dt2.Rows[0]["SevenCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital8).Range.Text = dt2.Rows[0]["EightCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital9).Range.Text = dt2.Rows[0]["NightCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital10).Range.Text = dt2.Rows[0]["TenCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Capital11).Range.Text = dt2.Rows[0]["EleventCapital"].ToString();
                       docFile.Bookmarks.get_Item(ref obDD_Explain1).Range.Text = dt2.Rows[0]["OneExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain2).Range.Text = dt2.Rows[0]["TwoExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain3).Range.Text = dt2.Rows[0]["ThreeExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain4).Range.Text = dt2.Rows[0]["ForeExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain5).Range.Text = dt2.Rows[0]["FiveExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain6).Range.Text = dt2.Rows[0]["SixExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain7).Range.Text = dt2.Rows[0]["SevenExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain8).Range.Text = dt2.Rows[0]["EightExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain9).Range.Text = dt2.Rows[0]["NightExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain10).Range.Text = dt2.Rows[0]["TenExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Explain11).Range.Text = dt2.Rows[0]["EleventExplain"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_SumCapital).Range.Text = dt2.Rows[0]["TotalCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_ApplyCapital).Range.Text = dt2.Rows[0]["ApplyCapital"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Support).Range.Text = dt2.Rows[0]["Support"].ToString();
                    }

                    if (dt4.Rows.Count > 0)
                    {
                        docFile.Bookmarks.get_Item(ref obDD_Content1).Range.Text = dt4.Rows[0]["OneContent"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Content2).Range.Text = dt4.Rows[0]["TwoContent"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Name1).Range.Text = dt4.Rows[0]["OneName"].ToString();
                        docFile.Bookmarks.get_Item(ref obDD_Name2).Range.Text = dt4.Rows[0]["TwoName"].ToString();

                        if (dt4.Rows[0]["OneDate"].ToString() != "")
                        {
                            docFile.Bookmarks.get_Item(ref obDD_Year2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Year.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Month2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Month.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Day2).Range.Text = Convert.ToDateTime(dt4.Rows[0]["OneDate"].ToString()).Day.ToString();
                        }
                        if (dt4.Rows[0]["TwoDate"].ToString() != "")
                        {
                            docFile.Bookmarks.get_Item(ref obDD_Year3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Year.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Month3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Month.ToString();
                            docFile.Bookmarks.get_Item(ref obDD_Day3).Range.Text = Convert.ToDateTime(dt4.Rows[0]["TwoDate"].ToString()).Day.ToString();
                        }
                    }
                    #region 合作者表格
                    int dt3row = dt3.Rows.Count + 1;
                    object Nothing = System.Reflection.Missing.Value;
                    //  docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range.Tables.Add(docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range, 12, 12, ref Nothing, ref Nothing);
                    Microsoft.Office.Interop.Word.Table newTable = docFile.Tables.Add(docFile.Bookmarks.get_Item(ref obDD_PartnerNum).Range, dt3row, 6, ref Nothing, ref Nothing);
                    newTable.Cell(1, 1).Range.Text = "姓名";
                    newTable.Cell(1, 2).Range.Text = "职称";
                    newTable.Cell(1, 3).Range.Text = "从事专业";
                    newTable.Cell(1, 4).Range.Text = "项目中分工";
                    newTable.Cell(1, 5).Range.Text = "所在单位或系部";
                    newTable.Cell(1, 6).Range.Text = "签章";
                    for (int i = 0; i < dt3row - 1; i++)
                    {
                        newTable.Cell(i + 2, 1).Range.Text = dt3.Rows[i]["UserName"].ToString();
                        newTable.Cell(i + 2, 2).Range.Text = dt3.Rows[i]["UserJob"].ToString();
                        newTable.Cell(i + 2, 3).Range.Text = dt3.Rows[i]["UserProfession"].ToString();
                        newTable.Cell(i + 2, 4).Range.Text = dt3.Rows[i]["UserWork"].ToString();
                        newTable.Cell(i + 2, 5).Range.Text = dt3.Rows[i]["UserCompany"].ToString();
                    }
                    //  Microsoft.Office.Interop.Word.Table newTable = (Microsoft.Office.Interop.Word.Table) dt3;

                    newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    #endregion

                    object filename = Server.MapPath("项目立项表.doc");
                    object miss = System.Reflection.Missing.Value;
                    docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    object missingValue = Type.Missing;
                    object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                    appWord.Quit(ref miss, ref miss, ref miss);
                    docFile = null;
                    appWord = null;
                    // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("项目立项表.doc"));
                    // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
                    string ReportFileName = Server.MapPath("项目立项表.doc");
                    System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
                    Response.AddHeader("Content-Length", filet.Length.ToString());

                    // 指定返回的是一个不能被客户端读取的流，必须被下载   
                    Response.ContentType = "application/ms-excel";

                    // 把文件流发送到客户端   
                    Response.WriteFile(filet.FullName);


                }
                catch 
                {

                    //捕捉异常，如果出现异常则清空实例，退出word,同时释放资源<br />
                    string aa = e.ToString();
                    object miss = System.Reflection.Missing.Value;
                    object missingValue = Type.Missing;
                    object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                    appWord.Quit(ref miss, ref miss, ref miss);
                    docFile = null;
                    appWord = null;

                }
            }
             
          
           
        }
       
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (-2 == e.NewPageIndex)
            { // 点了确定触发
                string n = ((TextBox)GridView1.BottomPagerRow.FindControl("txtNewPageIndex")).Text;//此处错误，无论怎么样处理，始终得到的是空值，不是null,是"",没有得到输入的值         
                GridView1.PageIndex = int.Parse(n) - 1;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
            dataGriviewBD();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Cookies["selectRoleId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("MyProjectsApprovalManage.aspx");
        }
    }
}