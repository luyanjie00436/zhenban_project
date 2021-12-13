using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class AssessDetailed : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        string UserCardId;
        int ApplyYearId;
        protected string MenuStr = "";
        DataSet dy1, dy2, dy3, dy4, dy5, dy6, dy7, dy8,dy9,dy10,dy11,dy12;
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
                if (Request.QueryString["UserCardId"] == null)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                try
                {
                    UserCardId = pwds.DecryptDES(Request.QueryString["UserCardId"], "asdfasdf");
                }
                catch (Exception)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (Request.QueryString["ApplyYearId"] == null)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                try
                {
                    ApplyYearId = Convert.ToInt32(pwds.DecryptDES(Request.QueryString["ApplyYearId"], "asdfasdf"));
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
#region 获得数据
                //教学质量工程
                dy1 = bus.SelectByApplyUserCardId("Guidance_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy1.Tables[0].Rows.Count < 2)
                {
                    dy1.Tables[0].Rows.Add(dy1.Tables[0].NewRow());
                }
                //技能竞赛
                dy2 = bus.SelectByApplyUserCardId("Competition_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy2.Tables[0].Rows.Count < 2)
                {
                    dy2.Tables[0].Rows.Add(dy2.Tables[0].NewRow());
                }
                //著作教材
                dy3 = bus.SelectByApplyUserCardId("Teaching_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy3.Tables[0].Rows.Count < 2)
                {
                    dy3.Tables[0].Rows.Add(dy3.Tables[0].NewRow());
                }
          //论文
                dy4 = bus.SelectByApplyUserCardId("Paper_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy4.Tables[0].Rows.Count < 2)
                {
                    dy4.Tables[0].Rows.Add(dy4.Tables[0].NewRow());
                }
                //专利
                dy5 = bus.SelectByApplyUserCardId("Patent_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy5.Tables[0].Rows.Count < 2)
                {
                    dy5.Tables[0].Rows.Add(dy5.Tables[0].NewRow());
                }
                //科技成果
                dy6 = bus.SelectByApplyUserCardId("Harvest_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy6.Tables[0].Rows.Count < 2)
                {
                    dy6.Tables[0].Rows.Add(dy6.Tables[0].NewRow());
                }
                //其他成果
                dy7 = bus.SelectByApplyUserCardId("OtherResults_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy7.Tables[0].Rows.Count < 2)
                {
                    dy7.Tables[0].Rows.Add(dy7.Tables[0].NewRow());
                }
                //学术活动
                dy8 = bus.SelectByApplyUserCardId("Activity_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy8.Tables[0].Rows.Count < 2)
                {
                    dy8.Tables[0].Rows.Add(dy8.Tables[0].NewRow());
                }
              
                //获奖成果
                dy10 = bus.SelectByApplyUserCardId("Winning_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy10.Tables[0].Rows.Count < 2)
                {
                    dy10.Tables[0].Rows.Add(dy10.Tables[0].NewRow());
                }
                //科研项目
                dy11 = bus.SelectByApplyUserCardId("WorkLoadProjects_SelectByPartnerUserCardId", UserCardId, ApplyYearId);
                while (dy11.Tables[0].Rows.Count < 2)
                {
                    dy11.Tables[0].Rows.Add(dy11.Tables[0].NewRow());
                }
               
                dy12 = bus.SelectByApplyUserCardId("AssessValue_SelectByApplyYearId", UserCardId, ApplyYearId);
               string    LNowValue = dy12.Tables[0].Rows[0]["NowValue"].ToString();
               string    LYearReport = dy12.Tables[0].Rows[0]["ReportDate"].ToString() + "年度科研工作量核算表";
              string  LDepartment = dy12.Tables[0].Rows[0]["DepartmentName"].ToString();
              string  LUserName = dy12.Tables[0].Rows[0]["UserName"].ToString();
#endregion
#region 显示数据
                StringBuilder text = new StringBuilder();
                text.Append("<table width=\"80%\" border=\"0\" class=\"tablee\" cellspacing=\"0\"> <th ><tr> <td  colspan=\"4\" style=\" text-align:center;\" > "+LYearReport+"</td></tr>   <tr>  <td width=\"11%\" style=\"text-align:right;\">系部：</td>   <td width=\"65%\" style=\"text-align:left;\">" + LDepartment + "</td>    <td width=\"11%\" style=\"text-align:right;\">填表教师：</td>       <td width=\"13%\" style=\"text-align:left;\">" + LUserName + "</td> </tr> </th></table>");

                text.Append(" <table  width=\"80%\" border=\"0\" class=\"tablew\" cellspacing=\"0\">");
                text.Append(" <tr>  <td class=\"zi\" colspan=\"16\">教学质量工程申报</td> </tr>");
               text.Append(" <tr>   <td  colspan=\"4\">项目名称</td>   <td colspan=\"2\">项目类别</td>   <td colspan=\"3\">项目级别</td>   <td colspan=\"2\">获奖时间</td>   <td >教学质量工程分值</td>    <td>本人得分</td>   <td >备注</td> </tr>");
                  for (int i = 0; i < dy1.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr><td  colspan=\"4\">" + dy1.Tables[0].Rows[i]["GuidanceName"].ToString() + "</td><td colspan=\"2\">" + dy1.Tables[0].Rows[i]["DCategory"].ToString() + "</td><td colspan=\"3\">" + dy1.Tables[0].Rows[i]["DLevel"].ToString() + "</td><td colspan=\"2\">" + dy1.Tables[0].Rows[i]["GuidanceDate"].ToString() + "</td>   <td >" + dy1.Tables[0].Rows[i]["GuidanceValue"].ToString() + "</td> <td>" + dy1.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td>   <td >" + dy1.Tables[0].Rows[i]["Remarks"].ToString() + "</td> </tr>");
                }
                  text.Append(" <tr><td class=\"zi\"  colspan=\"16\">技能竞赛</td></tr>");
                text.Append("<tr><td colspan=\"4\"  >技能竞赛名称</td> <td colspan=\"4\"  >竞赛组织单位</td> <td >参赛学生姓名</td> <td>参赛教师姓名</td> <td>指导教师姓名</td> <td>总分值</td> <td>获得时间值</td> <td>本人得分</td> </tr>");
                for (int i = 0; i < dy2.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr><td colspan=\"4\"  >" + dy2.Tables[0].Rows[i]["AppraisalCompany"].ToString() + "</td> <td colspan=\"4\"  >" + dy2.Tables[0].Rows[i]["AppraisalCompany"].ToString() + "</td> <td >" + dy2.Tables[0].Rows[i]["StudentName"].ToString() + "</td> <td>" + dy2.Tables[0].Rows[i]["TeacherName"].ToString() + "</td> <td>" + dy2.Tables[0].Rows[i]["Mentor"].ToString() + "</td> <td>" + dy2.Tables[0].Rows[i]["CompetitionValue"].ToString() + "</td> <td>" + dy2.Tables[0].Rows[i]["CompetitionDate"].ToString() + "</td> <td>" + dy2.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> </tr>");
               
                }
                
                text.Append(" <tr><td class=\"zi\"  colspan=\"16\">著作教材申报</td></tr>");
                text.Append(" <tr>   <td  colspan=\"4\">著作教材名称</td>   <td>类别</td>   <td>级别</td>   <td>出版社</td>   <td>出版日期</td>   <td>主编顺序</td>   <td>字数（万）</td>   <td>备注</td>   <td>总分值</td>   <td>本人得分</td> <td>成果获得日期</td></tr>");
                for (int i = 0; i < dy3.Tables[0].Rows.Count; i++)
                {
                     text.Append(" <tr> <td  colspan=\"4\">" + dy3.Tables[0].Rows[i]["BookName"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["DCategory"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["DLevel"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["PressName"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["PressDate"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["EditedSequence"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["TotalNumber"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["Remarks"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["TeachingValue"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td>" + dy3.Tables[0].Rows[i]["TeachingDate"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td class=\"zi\"  colspan=\"16\">论文申报</td></tr>");
                text.Append(" <tr> <td  colspan=\"4\">论文题目</td>  <td>类别</td> <td>级别</td> <td>刊物名称</td> <td>刊物期数</td><td>刊号</td><td  >作者顺序</td><td>备注</td><td>总分值</td> <td>本人得分</td><td>成果获得日期</td></tr>");
                for (int i = 0; i < dy4.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr> <td  colspan=\"4\">" + dy4.Tables[0].Rows[i]["PaperSubject"].ToString() + "</td>  <td>" + dy4.Tables[0].Rows[i]["DCategory"].ToString() + "</td> <td>" + dy4.Tables[0].Rows[i]["DLevel"].ToString() + "</td> <td>" + dy4.Tables[0].Rows[i]["PublicationName"].ToString() + "</td> <td>" + dy4.Tables[0].Rows[i]["PaperYears"].ToString() + "</td><td>" + dy4.Tables[0].Rows[i]["PaperName"].ToString() + "</td><td  >" + dy4.Tables[0].Rows[i]["AuthorsOrder"].ToString() + "</td><td>" + dy4.Tables[0].Rows[i]["Remarks"].ToString() + "</td><td>" + dy4.Tables[0].Rows[i]["PaperValue"].ToString() + "</td> <td>" + dy4.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td>" + dy4.Tables[0].Rows[i]["PaperDate"].ToString() + "</td></tr>");
                }
                text.Append("<tr><td class=\"zi\"  colspan=\"16\">专利申报</td></tr>");
                text.Append(" <tr><td colspan=\"5\"   >专利名称</td><td colspan=\"2\">专利批准日期</td><td colspan=\"2\">专利类别</td><td colspan=\"2\">专利级别</td><td>总分值</td><td>本人得分</td><td>备注</td></tr>");
                for (int i = 0; i < dy5.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr><td colspan=\"5\"   >" + dy5.Tables[0].Rows[i]["PatentName"].ToString() + "</td><td colspan=\"2\">" + dy5.Tables[0].Rows[i]["ApprovalDate"].ToString() + "</td><td colspan=\"2\">" + dy5.Tables[0].Rows[i]["DCategory"].ToString() + "</td><td colspan=\"2\">" + dy5.Tables[0].Rows[i]["DLevel"].ToString() + "</td><td>" + dy5.Tables[0].Rows[i]["PatentValue"].ToString() + "</td><td>" + dy5.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td><td>" + dy5.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
               
                }
                
                text.Append("<tr><td class=\"zi\"  colspan=\"16\">科技成果申报</td></tr>");
                text.Append(" <tr>   <td colspan=\"5\">成果名称</td>   <td colspan=\"2\">类别</td>   <td>级别</td>   <td colspan=\"2\">鉴定水平</td>   <td>发奖日期</td>   <td>总分值</td>   <td>本人得分</td>    <td >备注</td></tr>");
                for (int i = 0; i < dy6.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr>   <td colspan=\"5\">" + dy6.Tables[0].Rows[i]["HarvestName"].ToString() + "</td>   <td colspan=\"2\">" + dy6.Tables[0].Rows[i]["DCategory"].ToString() + "</td>   <td>" + dy6.Tables[0].Rows[i]["DLevel"].ToString() + "</td>   <td colspan=\"2\">" + dy6.Tables[0].Rows[i]["AppraisalLevel"].ToString() + "</td>   <td>" + dy6.Tables[0].Rows[i]["AwardsDate"].ToString() + "</td>   <td>" + dy6.Tables[0].Rows[i]["HarvestValue"].ToString() + "</td>   <td>" + dy6.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td>    <td >" + dy6.Tables[0].Rows[i]["Remarks"].ToString() + "</td></tr>");
                }
                text.Append("   <tr>   <td class=\"zi\"  colspan=\"16\">其它成果申报</td> </tr>");
                text.Append("<tr>  <td colspan=\"5 \">其它成果名称</td>  <td colspan=\"3\">类别</td>  <td colspan=\"2\">级别</td>  <td>获得日期</td>  <td>总分值</td>  <td>本人得分</td>  <td >备注</td> </tr>");
                for (int i = 0; i < dy7.Tables[0].Rows.Count; i++)
                {
                    text.Append("<tr>  <td colspan=\"5 \">" + dy7.Tables[0].Rows[i]["OtherResultsName"].ToString() + "</td>  <td colspan=\"3\">" + dy7.Tables[0].Rows[i]["DCategory"].ToString() + "</td>  <td colspan=\"2\">" + dy7.Tables[0].Rows[i]["DLevel"].ToString() + "</td>  <td>" + dy7.Tables[0].Rows[i]["AwardsDate"].ToString() + "</td>  <td>" + dy7.Tables[0].Rows[i]["OtherResultsValue"].ToString() + "</td>  <td>" + dy7.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td>  <td >" + dy7.Tables[0].Rows[i]["Remarks"].ToString() + "</td> </tr>");
                }
                text.Append(" <tr>   <td class=\"zi\"  colspan=\"16\">学术活动申报</td> </tr>");
                text.Append(" <tr>  <td colspan=\"3\" >学术活动名称</td> <td colspan=\"2\" >主办单位</td>  <td colspan=\"3\">类别</td>  <td colspan=\"2\" >级别</td>  <td>开始时间</td>  <td>结束时间</td>  <td>总分值</td>  <td>本人得分</td>    </tr>");
                for (int i = 0; i < dy8.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr>  <td colspan=\"3\" >" + dy8.Tables[0].Rows[i]["AssociationName"].ToString() + "</td>  <td colspan=\"2\" >" + dy8.Tables[0].Rows[i]["CompanyName"].ToString() + "</td> <td colspan=\"3\">" + dy8.Tables[0].Rows[i]["DCategory"].ToString() + "</td>  <td colspan=\"2\" >" + dy8.Tables[0].Rows[i]["DLevel"].ToString() + "</td>  <td>" + dy8.Tables[0].Rows[i]["StartDate"].ToString() + "</td>  <td>" + dy8.Tables[0].Rows[i]["EndDate"].ToString() + "</td>  <td>" + dy8.Tables[0].Rows[i]["ActivityValue"].ToString() + "</td>  <td>" + dy8.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td>    </tr>");
                }
              
                text.Append(" <tr>   <td class=\"zi\"  colspan=\"16\">获奖成果申报</td> </tr>");
                text.Append(" <tr>  <td colspan=\"3\" >获奖成果名称</td> <td colspan=\"3\">类别</td> <td colspan=\"2\">级别</td><td colspan=\"2\">评奖部门</td> <td  colspan=\"2\">获奖时间</td> <td>总分值</td> <td>本人得分</td> </tr>");
                for (int i = 0; i < dy10.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr>  <td colspan=\"3\" >" + dy10.Tables[0].Rows[i]["WinningName"].ToString() + "</td> <td colspan=\"3\">" + dy10.Tables[0].Rows[i]["DCategory"].ToString() + "</td> <td colspan=\"2\">" + dy10.Tables[0].Rows[i]["DLevel"].ToString() + "</td><td colspan=\"2\">" + dy10.Tables[0].Rows[i]["Remarks"].ToString() + "</td> <td  colspan=\"2\">" + dy10.Tables[0].Rows[i]["WinningCategory"].ToString() + "</td> <td>" + dy10.Tables[0].Rows[i]["WinningValue"].ToString() + "</td> <td>" + dy10.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> </tr>");
                }
                text.Append("   <tr><td class=\"zi\"  colspan=\"14\">科研项目</td></tr>");
                text.Append(" <tr>  <td colspan=\"3\"  >项目名称</td> <td>类别</td> <td>级别</td> <td>项目编号</td> <td>项目来源</td> <td>立项日期</td> <td>结题日期</td> <td>到校经费（万元）</td> <td>项目总分值分</td> <td>个人立项分值</td> <td>个人结题分值</td>  <td>备注</td> </tr>");
                for (int i = 0; i < dy11.Tables[0].Rows.Count; i++)
                {
                    text.Append(" <tr>  <td colspan=\"3\"  >" + dy11.Tables[0].Rows[i]["WorkLoadProjectsName"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["DCategory"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["DLevel"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["ProjectsId"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["WorkLoadFrom"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["ProjectDate"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["ConcludingDate"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["WorkLoadCapital"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["ProjectsValue"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["PartnerValue"].ToString() + "</td> <td>" + dy11.Tables[0].Rows[i]["ConcludingValue"].ToString() + "</td>  <td>" + dy11.Tables[0].Rows[i]["Remarks"].ToString() + "</td> </tr>");
                }

                text.Append("   <tr><td class=\"zi\"  colspan=\"12\">总分值</td><td class=\"zi\"  colspan=\"2\">"+LNowValue+"</td></tr>");
              





                 text.Append(" </table>");
                 text.Append("");
                 MenuStr = text.ToString();

#endregion
            }
        }
    }
}