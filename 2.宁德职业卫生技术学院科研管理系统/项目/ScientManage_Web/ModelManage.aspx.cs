using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ModelManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
        ningdeScientManage_Data.pwd pwds = new ningdeScientManage_Data.pwd();
        string UserCardId;
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ModelManage.aspx") == 0)
                {
                      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                }

                DataSet Model = bus.Select("ModelFather_Select");
                foreach (DataRow dr in Model.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ModelName"].ToString(), dr["ModelId"].ToString());
                    DlModel.Items.Add(li);
                }
                dataGriviewBD();
            }
        }
        public void dataGriviewBD()
        {
            int ModelId = Convert.ToInt32(DlModel.SelectedItem.Value);
            if (ModelId == 0)
            {
                GridView1.DataSource = bus.Select("Model_Select").Tables[0].DefaultView;
                GridView1.DataBind();
                return;
            }
            if (ModelId == 9999)
            {
                ModelId = 0;
            }

            GridView1.DataSource = bus.ModelSelect("Model_SelectByModelFatherId", ModelId).Tables[0].DefaultView;
            GridView1.DataBind();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();

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
            Response.Cookies["selectModelId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ModelManage.aspx");
        }


      
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {

            int countjob = bus.ModelSum("Model_SelectModelSum", Convert.ToInt32(e.CommandArgument.ToString()));
            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);


            if (countjob > 0)
            {
                
                Response.Write("<script>alert('您要删除的目录中已有" + countjob + "个子目录，不能删除该目录！');</script>");
            }
            else if (bus.ModelDelete("Model_Delete", Convert.ToInt32(e.CommandArgument.ToString()),UserCardId))
            {
                Response.Write("<script>alert('删除成功');</script>");
                dataGriviewBD();
            }
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
    }
}