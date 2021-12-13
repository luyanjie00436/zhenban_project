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
    public partial class LongProjectsInformationUpd : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
        string LongProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {


            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"].ToString(), "asdfasdf");
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
               
                #region 绑定
                ListItem li1 = new ListItem("--请选择--", "0");
                DLLevel.Items.Add(li1);
                DLFrom.Items.Add(li1);
                DLSubject.Items.Add(li1);
                DataTable dt = bus.SelectByProjectsTemplateCategory("ProjectsTemplate_SelectByCategory", "纵向项目申报").Tables[0];
                dt.Clear();
                dt = bus.Select("ProjectsFrom_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsFromExplain"].ToString(), dr["ProjectsFromId"].ToString());
                    DLFrom.Items.Add(li);
                }
                dt.Clear();
                dt = bus.Select("ProjectsLevel_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsLevelExplain"].ToString(), dr["ProjectsLevelId"].ToString());
                    DLLevel.Items.Add(li);
                }
                dt.Clear();
                dt = bus.Select("ProjectsSubject_Select").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["ProjectsSubjectExplain"].ToString(), dr["ProjectsSubjectId"].ToString());
                    DLSubject.Items.Add(li);
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/LongProjectsNewIdManage.aspx") == 0)
                {
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                DataSet ds = bus.SelectByLongProjectsId("LongProjects_SelectByLongProjectsId", LongProjectsId);
                txtProjectsName.Text = ds.Tables[0].Rows[0]["ProjectsName"].ToString();
                txtProjectsNewId.Text = ds.Tables[0].Rows[0]["NewLongProjectsId"].ToString();
                txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                txtProjectsContent.InnerHtml = ds.Tables[0].Rows[0]["ProjectsContent"].ToString();
                }
                #endregion
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ProjectsName = txtProjectsName.Text;
            string NewLongProjectsId = txtProjectsNewId.Text;
           
            string Company = txtCompany.Text;
            string ProjectsContent = txtProjectsContent.InnerHtml.ToString();
            string DeclareStatus;
            string StandStatus;
            string InspectStatus;
            string EndStatus;


            if (DLLevel.SelectedItem.Text == "--请选择--")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择项目级别");
                return;
            }
            int ProjectsLevelId = Convert.ToInt32(DLLevel.SelectedItem.Value);
            if (DLSubject.SelectedItem.Text == "--请选择--")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择项目类别");
                return;
            }
            int ProjectsSubjectId = Convert.ToInt32(DLSubject.SelectedItem.Value);
            if (DLFrom.SelectedItem.Text == "--请选择--")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择项目来源");
                return;
            }
            int ProjectsFromId = Convert.ToInt32(DLFrom.SelectedItem.Value);
            if (DlDeclareStatus.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择申报状态");
                return;
            }
            DeclareStatus = Convert.ToString(DlDeclareStatus.SelectedItem.Text);
            if (DlStandStatus.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择立项状态");
                return;
            }
            StandStatus = Convert.ToString(DlStandStatus.SelectedItem.Text);
            if (DlInspectStatus.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择中检状态");
                return;
            }
            InspectStatus = Convert.ToString(DlInspectStatus.SelectedItem.Text);
            if (DlEndStatus.SelectedItem.Text == "==请选择==")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择结题状态");
                return;
            }
            EndStatus = Convert.ToString(DlEndStatus.SelectedItem.Text);

            LongProjectsId = pwds.DecryptDES(Request.QueryString["LongProjectsId"].ToString(), "asdfasdf");
            if (bus.LongProjectsInformationUpdate("LongProjectsInformation_Update", LongProjectsId, UserCardId, ProjectsName, NewLongProjectsId, ProjectsFromId, ProjectsSubjectId, ProjectsLevelId, Company, ProjectsContent, DeclareStatus, StandStatus, InspectStatus, EndStatus))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", " if (confirm('修改成功')) { window.location = 'LongProjectsNewIdManage.aspx'}", true);
                //AlertMsgAndNoFlush(UpdatePanel1, "修改成功");
                //Response.Redirect("LongProjectsNewIdManage.aspx");
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败！");
            }



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
    }
}