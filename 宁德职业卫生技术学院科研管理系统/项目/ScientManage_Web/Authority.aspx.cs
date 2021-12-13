using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class Authority : System.Web.UI.Page
    {
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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

                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
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

            this.CBResources.DataTextField = "ModelName";
            this.CBResources.DataValueField = "ModelId";
            this.CBResources.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2291).Tables[0].DefaultView;
            this.CBResources.DataBind();


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

            this.CBProjectsStatus.DataTextField = "ModelName";
            this.CBProjectsStatus.DataValueField = "ModelId";
            this.CBProjectsStatus.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2313).Tables[0].DefaultView;
            this.CBProjectsStatus.DataBind();

            this.CBKJProjectsStatus.DataTextField = "ModelName";
            this.CBKJProjectsStatus.DataValueField = "ModelId";
            this.CBKJProjectsStatus.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2314).Tables[0].DefaultView;
            this.CBKJProjectsStatus.DataBind();


            this.CBLongCapital.DataTextField = "ModelName";
            this.CBLongCapital.DataValueField = "ModelId";
            this.CBLongCapital.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 178).Tables[0].DefaultView;
            this.CBLongCapital.DataBind();

            this.CBShortCapital.DataTextField = "ModelName";
            this.CBShortCapital.DataValueField = "ModelId";
            this.CBShortCapital.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 179).Tables[0].DefaultView;
            this.CBShortCapital.DataBind();

            this.CBResults.DataTextField = "ModelName";
            this.CBResults.DataValueField = "ModelId";
            this.CBResults.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 94).Tables[0].DefaultView;
            this.CBResults.DataBind();

            
            this.CBGuidance.DataTextField = "ModelName";
            this.CBGuidance.DataValueField = "ModelId";
            this.CBGuidance.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 150).Tables[0].DefaultView;
            this.CBGuidance.DataBind();


            this.CBSituation.DataTextField = "ModelName";
            this.CBSituation.DataValueField = "ModelId";
            this.CBSituation.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 95).Tables[0].DefaultView;
            this.CBSituation.DataBind();

           

            this.CBSystem.DataTextField = "ModelName";
            this.CBSystem.DataValueField = "ModelId";
            this.CBSystem.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 1).Tables[0].DefaultView;
            this.CBSystem.DataBind();

            this.CBSysPro.DataTextField = "ModelName";
            this.CBSysPro.DataValueField = "ModelId";
            this.CBSysPro.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2281).Tables[0].DefaultView;
            this.CBSysPro.DataBind();

            this.CBSysOrd.DataTextField = "ModelName";
            this.CBSysOrd.DataValueField = "ModelId";
            this.CBSysOrd.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2283).Tables[0].DefaultView;
            this.CBSysOrd.DataBind();

            this.CBSysHar.DataTextField = "ModelName";
            this.CBSysHar.DataValueField = "ModelId";
            this.CBSysHar.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", 2282).Tables[0].DefaultView;
            this.CBSysHar.DataBind();


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
          

            for (int i = 0; i < this.CBResources.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBResources.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBResources.Items[i].Selected = true;
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


            for (int i = 0; i < this.CBProjectsStatus.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBProjectsStatus.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBProjectsStatus.Items[i].Selected = true;
                }

            }

            for (int i = 0; i < this.CBKJProjectsStatus.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBKJProjectsStatus.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBKJProjectsStatus.Items[i].Selected = true;
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

            for (int i = 0; i < this.CBResults.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBResults.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBResults.Items[i].Selected = true;
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


            for (int i = 0; i < this.CBSysPro.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSysPro.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSysPro.Items[i].Selected = true;
                }

            }

            for (int i = 0; i < this.CBSysHar.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSysHar.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSysHar.Items[i].Selected = true;
                }

            }

            for (int i = 0; i < this.CBSysOrd.Items.Count; i++)
            {
                DataRow[] dr = dt.Select("ModelId=" + Convert.ToInt32(this.CBSysOrd.Items[i].Value));
                if (dr.Length > 0)
                {
                    this.CBSysOrd.Items[i].Selected = true;
                }

            }

            #endregion
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            bus.RoleDelete("Authority_Delete", RoleId,UserCardId);
            #region 插入选中项
            for (int i = 0; i < this.CBPersonal.Items.Count; i++)
            {
                if (this.CBPersonal.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBPersonal.Items[i].Value));
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

            for (int i = 0; i < this.CBProjectsStatus.Items.Count; i++)
            {
                if (this.CBProjectsStatus.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBProjectsStatus.Items[i].Value));
                }
            }
            for (int i = 0; i < this.CBKJProjectsStatus.Items.Count; i++)
            {
                if (this.CBKJProjectsStatus.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBKJProjectsStatus.Items[i].Value));
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

            for (int i = 0; i < this.CBResources.Items.Count; i++)
            {
                if (this.CBResources.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBResources.Items[i].Value));
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


            for (int i = 0; i < this.CBResults.Items.Count; i++)
            {
                if (this.CBResults.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBResults.Items[i].Value));
                }
            }

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

            for (int i = 0; i < this.CBSysOrd.Items.Count; i++)
            {
                if (this.CBSysOrd.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSysOrd.Items[i].Value));
                }
            }

            for (int i = 0; i < this.CBSysPro.Items.Count; i++)
            {
                if (this.CBSysPro.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSysPro.Items[i].Value));
                }
            }

            for (int i = 0; i < this.CBSysHar.Items.Count; i++)
            {
                if (this.CBSysHar.Items[i].Selected == true)
                {

                    bus.AuthorityInsert("Authority_Insert", RoleId, Convert.ToInt32(this.CBSysHar.Items[i].Value));
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