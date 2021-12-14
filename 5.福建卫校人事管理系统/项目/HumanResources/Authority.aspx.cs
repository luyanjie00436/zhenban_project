using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class Authority : System.Web.UI.Page
    {
       HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
       HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
    int RoleId;
    string UserCardId;
    DataTable dt = new DataTable();
    DataTable ds = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        RoleId = Convert.ToInt32(Request.QueryString["Rank"]);
        if (!IsPostBack)
        {
            try
            {
                UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            }
            catch (Exception)
            {

                Response.Redirect("Login.aspx");
            }

            
           
            ds = bus.SelectByRankId("Rank_SelectByRankId", RoleId).Tables[0];
            dt = bus.SelectByRoleId("Authority_SelectByRoleId", RoleId).Tables[0];
            txtRoleName.Text = ds.Rows[0]["RankName"].ToString();
            LoadBind();
        }
    }
    private void LoadBind()
    {
        #region 绑定多选框
        this.CBPersonal.DataTextField = "ModelName";
        this.CBPersonal.DataValueField = "ModelId";
        this.CBPersonal.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 34).Tables[0].DefaultView;
        this.CBPersonal.DataBind();

        this.CBTransfer.DataTextField = "ModelName";
        this.CBTransfer.DataValueField = "ModelId";
        this.CBTransfer.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 37).Tables[0].DefaultView;
        this.CBTransfer.DataBind();

        this.CBQuit.DataTextField = "ModelName";
        this.CBQuit.DataValueField = "ModelId";
        this.CBQuit.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 43).Tables[0].DefaultView;
        this.CBQuit.DataBind();

        this.CBAbroad.DataTextField = "ModelName";
        this.CBAbroad.DataValueField = "ModelId";
        this.CBAbroad.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 73).Tables[0].DefaultView;
        this.CBAbroad.DataBind();

        this.CBReward.DataTextField = "ModelName";
        this.CBReward.DataValueField = "ModelId";
        this.CBReward.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 55).Tables[0].DefaultView;
        this.CBReward.DataBind();

        this.CBLeave.DataTextField = "ModelName";
        this.CBLeave.DataValueField = "ModelId";
        this.CBLeave.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 61).Tables[0].DefaultView;
        this.CBLeave.DataBind();

        this.CBApplyPeriod.DataTextField = "ModelName";
        this.CBApplyPeriod.DataValueField = "ModelId";
        this.CBApplyPeriod.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 133).Tables[0].DefaultView;
        this.CBApplyPeriod.DataBind();

        this.CBReduction.DataTextField = "ModelName";
        this.CBReduction.DataValueField = "ModelId";
        this.CBReduction.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 137).Tables[0].DefaultView;
        this.CBReduction.DataBind();

            this.CBUse1.DataTextField = "ModelName";
            this.CBUse1.DataValueField = "ModelId";
            this.CBUse1.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 173).Tables[0].DefaultView;
            this.CBUse1.DataBind();

            this.CBUse2.DataTextField = "ModelName";
            this.CBUse2.DataValueField = "ModelId";
            this.CBUse2.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 174).Tables[0].DefaultView;
            this.CBUse2.DataBind();

            this.CBUse3.DataTextField = "ModelName";
            this.CBUse3.DataValueField = "ModelId";
            this.CBUse3.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 175).Tables[0].DefaultView;
            this.CBUse3.DataBind();

        this.CBzonghe.DataTextField = "ModelName";
        this.CBzonghe.DataValueField = "ModelId";
        this.CBzonghe.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 127).Tables[0].DefaultView;
        this.CBzonghe.DataBind();

        this.CBTraning.DataTextField = "ModelName";
        this.CBTraning.DataValueField = "ModelId";
        this.CBTraning.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 67).Tables[0].DefaultView;
        this.CBTraning.DataBind();

        this.CBResume.DataTextField = "ModelName";
        this.CBResume.DataValueField = "ModelId";
        this.CBResume.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 106).Tables[0].DefaultView;
        this.CBResume.DataBind();

        this.CBDelayQuit.DataTextField = "ModelName";
        this.CBDelayQuit.DataValueField = "ModelId";
        this.CBDelayQuit.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 49).Tables[0].DefaultView;
        this.CBDelayQuit.DataBind();

        this.CBSystem.DataTextField = "ModelName";
        this.CBSystem.DataValueField = "ModelId";
        this.CBSystem.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 4).Tables[0].DefaultView;
        this.CBSystem.DataBind();

        this.CBRecruitment.DataTextField = "ModelName";
        this.CBRecruitment.DataValueField = "ModelId";
        this.CBRecruitment.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 110).Tables[0].DefaultView;
        this.CBRecruitment.DataBind();

        this.CBPostApply.DataTextField = "ModelName";
        this.CBPostApply.DataValueField = "ModelId";
        this.CBPostApply.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 80).Tables[0].DefaultView;
        this.CBPostApply.DataBind();

        this.CBStaffing.DataTextField = "ModelName";
        this.CBStaffing.DataValueField = "ModelId";
        this.CBStaffing.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 117).Tables[0].DefaultView;
        this.CBStaffing.DataBind();

        this.CBUsePerApp.DataTextField = "ModelName";
        this.CBUsePerApp.DataValueField = "ModelId";
        this.CBUsePerApp.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 145).Tables[0].DefaultView;
        this.CBUsePerApp.DataBind();

            this.CBJobApply.DataTextField = "ModelName";
        this.CBJobApply.DataValueField = "ModelId";
        this.CBJobApply.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 88).Tables[0].DefaultView;
        this.CBJobApply.DataBind();

        this.CBRoleApply.DataTextField = "ModelName";
        this.CBRoleApply.DataValueField = "ModelId";
        this.CBRoleApply.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 96).Tables[0].DefaultView;
        this.CBRoleApply.DataBind();

        #endregion
        #region 选中项
        for (int i = 0; i < this.CBPersonal.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBPersonal.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBPersonal.Items[i].Selected = true;
            }

        }
        for (int i = 0; i < this.CBTransfer.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBTransfer.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBTransfer.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBTraning.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBTraning.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBTraning.Items[i].Selected = true;
            }

        }
        for (int i = 0; i < this.CBQuit.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBQuit.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBQuit.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBzonghe.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBzonghe.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBzonghe.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBDelayQuit.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBDelayQuit.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBDelayQuit.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBApplyPeriod.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBApplyPeriod.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBApplyPeriod.Items[i].Selected = true;
            }

        }
        for (int i = 0; i < this.CBReduction.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBReduction.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBReduction.Items[i].Selected = true;
            }

        }
            #region 基本信息
            for (int i = 0; i < this.CBUse1.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBUse1.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBUse1.Items[i].Selected = true;
                }

            }
            for (int i = 0; i < this.CBUse2.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBUse2.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBUse2.Items[i].Selected = true;
                }

            }
            for (int i = 0; i < this.CBUse3.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBUse3.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBUse3.Items[i].Selected = true;
                }

            }
           
            #endregion

            for (int i = 0; i < this.CBResume.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBResume.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBResume.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBRecruitment.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBRecruitment.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBRecruitment.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBLeave.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBLeave.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBLeave.Items[i].Selected = true;
            }

        }
       
        for (int i = 0; i < this.CBPostApply.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBPostApply.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBPostApply.Items[i].Selected = true;
            }

        }
        for (int i = 0; i < this.CBStaffing.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBStaffing.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBStaffing.Items[i].Selected = true;
            }

        }

            for (int i = 0; i < this.CBUsePerApp.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBUsePerApp.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBUsePerApp.Items[i].Selected = true;
                }

            }

            for (int i = 0; i < this.CBJobApply.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBJobApply.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBJobApply.Items[i].Selected = true;
            }

        }


        for (int i = 0; i < this.CBRoleApply.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBRoleApply.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBRoleApply.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBAbroad.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBAbroad.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBAbroad.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBReward.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBReward.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBReward.Items[i].Selected = true;
            }

        }

        for (int i = 0; i < this.CBSystem.Items.Count; i++)
        {
            DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSystem.Items[i].Value));
            if (dr.Length > 0)
            {
                this.CBSystem.Items[i].Selected = true;
            }

        }
      
        #endregion
    }
    protected void Save_Click(object sender, EventArgs e)
    {
      
        bus.RoleDelete("Authority_Delete", RoleId);
        #region 插入选中项
       

        for (int i = 0; i < this.CBTransfer.Items.Count; i++)
        {
            if (this.CBTransfer.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBTransfer.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBQuit.Items.Count; i++)
        {
            if (this.CBQuit.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBQuit.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBStaffing.Items.Count; i++)
        {
            if (this.CBStaffing.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBStaffing.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBUsePerApp.Items.Count; i++)
        {
            if (this.CBUsePerApp.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBUsePerApp.Items[i].Value));
            }
        }
            for (int i = 0; i < this.CBPostApply.Items.Count; i++)
        {
            if (this.CBPostApply.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBPostApply.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBApplyPeriod.Items.Count; i++)
        {
            if (this.CBApplyPeriod.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBApplyPeriod.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBReduction.Items.Count; i++)
        {
            if (this.CBReduction.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBReduction.Items[i].Value));
            }
        }
            #region 基本信息
            for (int i = 0; i < this.CBUse1.Items.Count; i++)
            {
                if (this.CBUse1.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBUse1.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBUse2.Items.Count; i++)
            {
                if (this.CBUse2.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBUse2.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBUse3.Items.Count; i++)
            {
                if (this.CBUse3.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBUse3.Items[i].Value));
                }
            }
          
            #endregion
            for (int i = 0; i < this.CBJobApply.Items.Count; i++)
        {
            if (this.CBJobApply.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBJobApply.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBRoleApply.Items.Count; i++)
        {
            if (this.CBRoleApply.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBRoleApply.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBRecruitment.Items.Count; i++)
        {
            if (this.CBRecruitment.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBRecruitment.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBzonghe.Items.Count; i++)
        {
            if (this.CBzonghe.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBzonghe.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBResume.Items.Count; i++)
        {
            if (this.CBResume.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBResume.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBTraning.Items.Count; i++)
        {
            if (this.CBTraning.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBTraning.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBAbroad.Items.Count; i++)
        {
            if (this.CBAbroad.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBAbroad.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBLeave.Items.Count; i++)
        {
            if (this.CBLeave.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBLeave.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBReward.Items.Count; i++)
        {
            if (this.CBReward.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBReward.Items[i].Value));
            }
        }

        for (int i = 0; i < this.CBDelayQuit.Items.Count; i++)
        {
            if (this.CBDelayQuit.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBDelayQuit.Items[i].Value));
            }
        }
        for (int i = 0; i < this.CBSystem.Items.Count; i++)
        {
            if (this.CBSystem.Items[i].Selected == true)
            {
             
                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSystem.Items[i].Value));
            }
        }
        
        for (int i = 0; i < this.CBPersonal.Items.Count; i++)
        {
            if (this.CBPersonal.Items[i].Selected == true)
            {

                bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBPersonal.Items[i].Value));
            }
        }
        #endregion
        Response.Redirect("RankManage.aspx");
    }
    protected void Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleManage.aspx");
    }

    }
}