﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ningdeScientManage_Web
{
    public partial class ResearchManage : System.Web.UI.Page
    {
        ningdeScientManage_Data.GetData bus = new ningdeScientManage_Data.GetData();
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ResearchManagement.aspx") == 0)
                //{
                //      Response.Write("<script>alert('您暂时无法访问此页面，请与科研处联系！！');" + "window.parent.parent.location.href='Login.aspx'</script>");
                //}
                DataTable dt = bus.Select("WorkCategory_SelectContent").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                    DLContent.Items.Add(li);
                }
                dataGriviewBD();

            }
        }
        public void dataGriviewBD()
        {
            int FatherId = Convert.ToInt32(DLContent.SelectedValue);
         
            if (DLCategory.Items.Count > 0&&DLCategory.SelectedValue!="0")
            {
                FatherId = Convert.ToInt32(DLCategory.SelectedValue);
            }
            DataTable dt = bus.SelectByWorkCategoryId("WorkCategory_SelectByWorkCategory", FatherId).Tables[0];
            if (dt.Rows.Count>0)
            {
                GridView1.DataSource = dt.DefaultView;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected void DLContent_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DLCategory.Items.Clear();
          
            dataGriviewBD();
            int FatherId = Convert.ToInt32(DLContent.SelectedValue);
            DataTable dt = bus.SelectByWorkCategoryId("WorkCategory_SelectByWorkCategory", FatherId).Tables[0];
            if (dt.Rows.Count>0)
            {
            DLCategory.Items.Add("==请选择==");
            DLCategory.Items[0].Value = "0";
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr["WorkCategoryName"].ToString(), dr["WorkCategoryId"].ToString());
                DLCategory.Items.Add(li);
            }
            }

        }

        protected void DLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            dataGriviewBD();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResearchContentAdd.aspx?Rank=1&Father=0");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int FatherId = Convert.ToInt32(DLContent.SelectedValue);
            if (FatherId == 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择内容");
                return;
            }
            else
            {
                Response.Redirect("ResearchCategoryAdd.aspx?Rank=2&Father=" + FatherId);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DLCategory.Items.Count >1&& DLCategory.SelectedValue!="0")
            {
                int FatherId = Convert.ToInt32(DLCategory.SelectedValue);
                Response.Redirect("ResearchCategoryAdd.aspx?Rank=3&Father=" + FatherId);
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请选择类别");
                return;
            }
        }
        protected void LinkButton7_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("ResearchInformationUpd.aspx?CategoryId=" + e.CommandArgument.ToString() + "");
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        //删除
        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {
            if (bus.WorkCategoryDelete("WorkCategory_Delete", Convert.ToInt32(e.CommandArgument.ToString())))
	        {
                AlertMsgAndNoFlush(UpdatePanel1, "删除成功");
                dataGriviewBD();
	        }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "删除失败");
                dataGriviewBD();
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
            Response.Cookies["selectUserCardId"].Value = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            Response.Redirect("ResearchManage.aspx");
        }
    }
}