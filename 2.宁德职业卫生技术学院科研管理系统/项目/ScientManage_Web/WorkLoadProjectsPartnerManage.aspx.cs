using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class WorkLoadProjectsPartnerManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        string UserCardId;
        int WorkLoadProjectsId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Panel2.Visible = false;
                Button2.Visible = false;
                try
                {
                    UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
                }
                catch (Exception)
                {

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/WorkLoadProjectsPartnerManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

               
                DataTable dt = bus.SelectWorkLoadProjectsByUserCardId("WorkLoadProjects_SelectByPartnerUserNo", UserCardId).Tables[0];
              
                if (dt.Rows.Count > 0 && dt.Columns.Count > 1)
                {
                   
                    DlWorkLoadProjects.Items.Add("==请选择==");
                    DlWorkLoadProjects.Items[0].Value = "0";
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem li = new ListItem(dr["WorkLoadProjectsName"].ToString(), dr["WorkLoadProjectsId"].ToString());
                        DlWorkLoadProjects.Items.Add(li);
                    }
                    txtWorkLoadProjectsValue.Text = "0";
                }
                else
                    {
                       
                        //txtWorkLoadProjectsValue.Text = dt.Rows[0]["WorkValue"].ToString();
                    }
            }

        }
     
        public void dataGriviewBD(int WorkLoadProjectsId)
        {
            DataTable dt=bus.SelectByWorkLoadProjectsId("WorkLoadProjectsPartner_SelectByWorkLoadProjectsId", WorkLoadProjectsId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            if (dt.Rows.Count>0)
            {
                txtWorkLoadProjectsValue.Text = dt.Rows[0]["WorkLoadProjectsValue"].ToString();
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double WorkLoadProjectsValue = Convert.ToDouble(txtWorkLoadProjectsValue.Text.Trim());

            string PartnerValue = txtPartnerValue.Text.Trim();
            string ConcludingValue = txtConcludingValue.Text.Trim();

            if (DlWorkLoadProjects.SelectedIndex.Equals(0))
            {
                UpdatePanelAlert("请选择要添加的科研项目！");
                return;
            }
            int WorkLoadProjectsId = Convert.ToInt32(DlWorkLoadProjects.SelectedValue);
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Text.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (PartnerValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项分值");
                return;
            }
            try
            {
                Convert.ToDouble(PartnerValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "立项分值请输入数字！");
                return;
            }
            if (ConcludingValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题分值");
                return;
            }
            try
            {
                Convert.ToDouble(ConcludingValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "结题分值请输入数字！");
                return;
            }
            double ProjectsValue = Convert.ToDouble(PartnerValue) + Convert.ToDouble(ConcludingValue);
            if (ProjectsValue > WorkLoadProjectsValue)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "个人获得总分值应小于项目总分值！");
                return;
            }
            if (bus.UserSum("UserInfo_SelectUserSum", UserCardId, UserName) == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "合作者信息错误！");
                return;
            }
            if (bus.WorkLoadProjectsPartnerInsert("WorkLoadProjectsPartner_Insert", WorkLoadProjectsId, UserCardId, PartnerRank, Convert.ToDouble(PartnerValue), Convert.ToDouble(ProjectsValue), Convert.ToDouble(ConcludingValue)))
            {

                UpdatePanelAlert("添加成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                txtPartnerValue.Text="";
                txtConcludingValue.Text="";
                dataGriviewBD(WorkLoadProjectsId);
            }
            else
            {
                UpdatePanelAlert("添加失败！");
            }



        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string UserCardId = txtUserCardId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            int PartnerRank;
            double WorkLoadProjectsValue = Convert.ToDouble(txtWorkLoadProjectsValue.Text.Trim());
            string PartnerValue = txtPartnerValue.Text.Trim();
            string ConcludingValue = txtConcludingValue.Text.Trim(); 
            int WorkLoadProjectsId = Convert.ToInt32(DlWorkLoadProjects.SelectedValue);
              
            if (txtUserName.Text.Trim() == "" || txtUserCardId.Text.Trim() == "" || txtPartnerValue.Text.Trim() == "")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            if (DlPartnerRank.SelectedItem.Text == "==请选择==")
            {
                UpdatePanelAlert("合作者信息不完善！");
                return;
            }
            PartnerRank = Convert.ToInt32(DlPartnerRank.SelectedItem.Text);
            if (PartnerValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入立项分值");
                return;
            }
            try
            {
                Convert.ToDouble(PartnerValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "立项分值请输入数字！");
                return;
            }
            if (ConcludingValue == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请输入结题分值");
                return;
            }
            try
            {
                Convert.ToDouble(ConcludingValue);
            }
            catch (Exception)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "结题分值请输入数字！");
                return;
            }
            double ProjectsValue = Convert.ToDouble(PartnerValue) + Convert.ToDouble(ConcludingValue);
            if (bus.UserSum("UserInfo_SelectUserSum", UserCardId, UserName) == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "合作者信息错误！");
                return;
            }
            int WorkLoadProjectsPartnerId = Convert.ToInt32(HttpUtility.UrlDecode(Request.Cookies["WorkLoadProjectsPartnerId"].Value));
            if (bus.WorkLoadProjectsPartnerUpdate("WorkLoadProjectsPartner_Update", WorkLoadProjectsPartnerId, UserCardId, PartnerRank, Convert.ToDouble(PartnerValue), Convert.ToDouble(ConcludingValue),ProjectsValue))
            {

                UpdatePanelAlert("修改成功！");
                txtUserCardId.Text = "";
                txtUserName.Text = "";
                txtPartnerValue.Text = "";
                txtPartnerValue.Text = "";
                txtConcludingValue.Text = "";
                Button1.Visible = true;
                Button2.Visible = false;
                dataGriviewBD(WorkLoadProjectsId);
            }
            else
            {
                UpdatePanelAlert("修改失败！可能是分配分值大于项目总分值！");
            }



        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Partner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            dataGriviewBD(Convert.ToInt32(DlWorkLoadProjects.SelectedValue));
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
            dataGriviewBD(Convert.ToInt32(DlWorkLoadProjects.SelectedValue));
        }
        //删除
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {
            int WorkLoadProjectsId = Convert.ToInt32(DlWorkLoadProjects.SelectedValue);
            if (bus.WorkLoadProjectsPartnerDelete("WorkLoadProjectsPartner_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
            {
                UpdatePanelAlert("删除成功！");
                dataGriviewBD(WorkLoadProjectsId);
            }
        }
        //编辑
        protected void LinkButton6_Command(object sender, CommandEventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = true;
            DataTable dt = bus.SelectByWorkLoadProjectsPartnerId("WorkLoadProjectsPartner_SelectByWorkLoadProjectsPartnerId", Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            Response.Cookies["WorkLoadProjectsPartnerId"].Value = e.CommandArgument.ToString();
            txtUserCardId.Text = dt.Rows[0]["PartnerUserCardId"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtPartnerValue.Text = dt.Rows[0]["PartnerValue"].ToString();
            DlPartnerRank.SelectedValue= dt.Rows[0]["PartnerRank"].ToString();
            txtConcludingValue.Text = dt.Rows[0]["ConcludingValue"].ToString();
            

        }

        protected void UpdatePanelAlert(string str_Message)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + str_Message + "')", true);
        }
    }
}