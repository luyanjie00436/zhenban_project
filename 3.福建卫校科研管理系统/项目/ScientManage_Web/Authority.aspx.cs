using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class Authority : System.Web.UI.Page
    {
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
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
                    Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'<" + "/script>");
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
            this.CBPersonal.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2).Tables[0].DefaultView;
            this.CBPersonal.DataBind();

            this.CBT_Teaching.DataTextField = "ModelName";
            this.CBT_Teaching.DataValueField = "ModelId";
            this.CBT_Teaching.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 108).Tables[0].DefaultView;
            this.CBT_Teaching.DataBind();

            this.CBTeaching_Team.DataTextField = "ModelName";
            this.CBTeaching_Team.DataValueField = "ModelId";
            this.CBTeaching_Team.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 145).Tables[0].DefaultView;
            this.CBTeaching_Team.DataBind();

            this.CBP_construction.DataTextField = "ModelName";
            this.CBP_construction.DataValueField = "ModelId";
            this.CBP_construction.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 149).Tables[0].DefaultView;
            this.CBP_construction.DataBind();

            this.CBC_construction.DataTextField = "ModelName";
            this.CBC_construction.DataValueField = "ModelId";
            this.CBC_construction.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 146).Tables[0].DefaultView;
            this.CBC_construction.DataBind();

            this.CBC_winners.DataTextField = "ModelName";
            this.CBC_winners.DataValueField = "ModelId";
            this.CBC_winners.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 147).Tables[0].DefaultView;
            this.CBC_winners.DataBind();

            this.CBResults.DataTextField = "ModelName";
            this.CBResults.DataValueField = "ModelId";
            this.CBResults.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 148).Tables[0].DefaultView;
            this.CBResults.DataBind();

            this.CBSpecial.DataTextField = "ModelName";
            this.CBSpecial.DataValueField = "ModelId";
            this.CBSpecial.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 320).Tables[0].DefaultView;
            this.CBSpecial.DataBind();

            this.CBTeachToTeaching.DataTextField = "ModelName";
            this.CBTeachToTeaching.DataValueField = "ModelId";
            this.CBTeachToTeaching.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 327).Tables[0].DefaultView;
            this.CBTeachToTeaching.DataBind();

            this.CBWinning.DataTextField = "ModelName";
            this.CBWinning.DataValueField = "ModelId";
            this.CBWinning.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 118).Tables[0].DefaultView;
            this.CBWinning.DataBind();

            this.CBTeaching.DataTextField = "ModelName";
            this.CBTeaching.DataValueField = "ModelId";
            this.CBTeaching.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 117).Tables[0].DefaultView;
            this.CBTeaching.DataBind();

            this.CBDeclare.DataTextField = "ModelName";
            this.CBDeclare.DataValueField = "ModelId";
            this.CBDeclare.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 91).Tables[0].DefaultView;
            this.CBDeclare.DataBind();


            this.CBWorkLoad.DataTextField = "ModelName";
            this.CBWorkLoad.DataValueField = "ModelId";
            this.CBWorkLoad.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 119).Tables[0].DefaultView;
            this.CBWorkLoad.DataBind();

            this.CBPaper.DataTextField = "ModelName";
            this.CBPaper.DataValueField = "ModelId";
            this.CBPaper.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 134).Tables[0].DefaultView;
            this.CBPaper.DataBind();

            this.CBShort.DataTextField = "ModelName";
            this.CBShort.DataValueField = "ModelId";
            this.CBShort.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 92).Tables[0].DefaultView;
            this.CBShort.DataBind();

            this.CBLongCapital.DataTextField = "ModelName";
            this.CBLongCapital.DataValueField = "ModelId";
            this.CBLongCapital.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 178).Tables[0].DefaultView;
            this.CBLongCapital.DataBind();

            this.CBShortCapital.DataTextField = "ModelName";
            this.CBShortCapital.DataValueField = "ModelId";
            this.CBShortCapital.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 179).Tables[0].DefaultView;
            this.CBShortCapital.DataBind();

            //this.CBResults.DataTextField = "ModelName";
            //this.CBResults.DataValueField = "ModelId";
            //this.CBResults.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 94).Tables[0].DefaultView;
            //this.CBResults.DataBind();

            this.CBSituation.DataTextField = "ModelName";
            this.CBSituation.DataValueField = "ModelId";
            this.CBSituation.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 95).Tables[0].DefaultView;
            this.CBSituation.DataBind();

            this.CBExpert.DataTextField = "ModelName";
            this.CBExpert.DataValueField = "ModelId";
            this.CBExpert.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 317).Tables[0].DefaultView;
            this.CBExpert.DataBind();

            this.CBGuidance.DataTextField = "ModelName";
            this.CBGuidance.DataValueField = "ModelId";
            this.CBGuidance.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 150).Tables[0].DefaultView;
            this.CBGuidance.DataBind();

            this.CBWorkLoadProjects.DataTextField = "ModelName";
            this.CBWorkLoadProjects.DataValueField = "ModelId";
            this.CBWorkLoadProjects.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 161).Tables[0].DefaultView;
            this.CBWorkLoadProjects.DataBind();

            this.CBHarvest.DataTextField = "ModelName";
            this.CBHarvest.DataValueField = "ModelId";
            this.CBHarvest.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 258).Tables[0].DefaultView;
            this.CBHarvest.DataBind();

            this.CBSystem.DataTextField = "ModelName";
            this.CBSystem.DataValueField = "ModelId";
            this.CBSystem.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 1).Tables[0].DefaultView;
            this.CBSystem.DataBind();

            #endregion
            #region 选中项
            for (int i = 0; i < this.CBT_Teaching.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBT_Teaching.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBT_Teaching.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBTeaching_Team.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBTeaching_Team.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBTeaching_Team.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBP_construction.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBP_construction.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBP_construction.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBC_construction.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBC_construction.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBC_construction.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBC_winners.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBC_winners.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBC_winners.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBResults.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBResults.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBResults.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBSpecial.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSpecial.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSpecial.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBTeachToTeaching.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBTeachToTeaching.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBTeachToTeaching.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBPersonal.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBPersonal.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBPersonal.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBHarvest.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBHarvest.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBHarvest.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBWorkLoadProjects.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBWorkLoadProjects.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBWorkLoadProjects.Items[i].Selected = true;
                }
            }
         
            for (int i = 0; i < this.CBShort.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBShort.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBShort.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBWinning.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBWinning.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBWinning.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBSituation.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSituation.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSituation.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBExpert.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBExpert.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBExpert.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBDeclare.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBDeclare.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBDeclare.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBTeaching.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBTeaching.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBTeaching.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBLongCapital.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBLongCapital.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBLongCapital.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBShortCapital.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBShortCapital.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBShortCapital.Items[i].Selected = true;
                }
            }
            //for (int i = 0; i < this.CBResults.Items.Count; i++)
            //{
            //    DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBResults.Items[i].Value));
            //    if (dr.Length > 0)
            //    {
            //        this.CBResults.Items[i].Selected = true;
            //    }
            //}
            for (int i = 0; i < this.CBSituation.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSituation.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSituation.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBExpert.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBExpert.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBExpert.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBWorkLoad.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBWorkLoad.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBWorkLoad.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBPaper.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBPaper.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBPaper.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < this.CBGuidance.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBGuidance.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBGuidance.Items[i].Selected = true;
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
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            bus.RoleDelete("Authority_Delete", RoleId,UserCardId);
            #region 插入选中项
            for (int i = 0; i < this.CBT_Teaching.Items.Count; i++)
            {
                if (this.CBT_Teaching.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBT_Teaching.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBTeaching_Team.Items.Count; i++)
            {
                if (this.CBTeaching_Team.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBTeaching_Team.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBP_construction.Items.Count; i++)
            {
                if (this.CBP_construction.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBP_construction.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBC_construction.Items.Count; i++)
            {
                if (this.CBC_construction.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBC_construction.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBC_winners.Items.Count; i++)
            {
                if (this.CBC_winners.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBC_winners.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBResults.Items.Count; i++)
            {
                if (this.CBResults.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBResults.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBSpecial.Items.Count; i++)
            {
                if (this.CBSpecial.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSpecial.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBTeachToTeaching.Items.Count; i++)
            {
                if (this.CBTeachToTeaching.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBTeachToTeaching.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBPersonal.Items.Count; i++)
            {
                if (this.CBPersonal.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBPersonal.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBHarvest.Items.Count; i++)
            {
                if (this.CBHarvest.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBHarvest.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBWorkLoadProjects.Items.Count; i++)
            {
                if (this.CBWorkLoadProjects.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBWorkLoadProjects.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBDeclare.Items.Count; i++)
            {
                if (this.CBDeclare.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBDeclare.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBWinning.Items.Count; i++)
            {
                if (this.CBWinning.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBWinning.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBShort.Items.Count; i++)
            {
                if (this.CBShort.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBShort.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBWorkLoad.Items.Count; i++)
            {
                if (this.CBWorkLoad.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBWorkLoad.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBPaper.Items.Count; i++)
            {
                if (this.CBPaper.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBPaper.Items[i].Value));
                }
            }
         
            for (int i = 0; i < this.CBTeaching.Items.Count; i++)
            {
                if (this.CBTeaching.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBTeaching.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBSituation.Items.Count; i++)
            {
                if (this.CBSituation.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSituation.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBExpert.Items.Count; i++)
            {
                if (this.CBExpert.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBExpert.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBLongCapital.Items.Count; i++)
            {
                if (this.CBLongCapital.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBLongCapital.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBShortCapital.Items.Count; i++)
            {
                if (this.CBShortCapital.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBShortCapital.Items[i].Value));
                }
            }
            //for (int i = 0; i < this.CBResults.Items.Count; i++)
            //{
            //    if (this.CBResults.Items[i].Selected == true)
            //    {
            //        bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBResults.Items[i].Value));
            //    }
            //}
            for (int i = 0; i < this.CBGuidance.Items.Count; i++)
            {
                if (this.CBGuidance.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBGuidance.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBSystem.Items.Count; i++)
            {
                if (this.CBSystem.Items[i].Selected == true)
                {
                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSystem.Items[i].Value));
                }
            }
            #endregion
            Response.Redirect("RankManage.aspx");
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("RankManage.aspx");
        }
    }
}