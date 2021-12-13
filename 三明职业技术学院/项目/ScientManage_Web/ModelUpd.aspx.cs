using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sanmingScientManage_Web
{
    public partial class ModelUpd : System.Web.UI.Page
    {
        sanmingScientManage_Data.GetData bus = new sanmingScientManage_Data.GetData();
        sanmingScientManage_Data.pwd pwds = new sanmingScientManage_Data.pwd();
        int ModelId;
        string UserCardId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ModelId = Convert.ToInt32(Request.QueryString["Model"]);
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
                DataSet ds = bus.SelectByModelId("Model_SelectByModelId", ModelId);
                DataSet Model = bus.Select("ModelFather_Select");
                foreach (DataRow dr in Model.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ModelName"].ToString(), dr["ModelId"].ToString());
                    DlModel.Items.Add(li);
                }
                txtModelName.Text = ds.Tables[0].Rows[0]["ModelName"].ToString();
                txtModelUrl.Text = ds.Tables[0].Rows[0]["ModelUrl"].ToString();
                txtModelNum.Text = ds.Tables[0].Rows[0]["ModelNum"].ToString();
                DlModel.SelectedValue = ds.Tables[0].Rows[0]["ModelFatherId"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            UserCardId = HttpUtility.UrlDecode(Request.Cookies["UserCardId"].Value);
            string ModelName = txtModelName.Text.Trim().ToString();
            string ModelUrl = txtModelUrl.Text.Trim().ToString();
            int FatherModelId = Convert.ToInt32(DlModel.SelectedItem.Value);
            string FatherModelName = DlModel.SelectedItem.Text.ToString();
            string ModelNum1 = txtModelNum.Text;
            if (ModelName == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写目录名称");
                return;
            }
            if (ModelNum1 == "")
            {
                AlertMsgAndNoFlush(UpdatePanel1, "请填写同级排序");
                return;
            }
            try
            {
                Convert.ToInt32(ModelNum1);
            }
            catch (Exception)
            {

                AlertMsgAndNoFlush(UpdatePanel1, "同级排序请输入正整数");
                return;
            }
            int ModelNum = Convert.ToInt32(ModelNum1);
            if (ModelNum <= 0)
            {
                AlertMsgAndNoFlush(UpdatePanel1, "同级排序请输入正整数");
                return;
            }
            if (bus.ModelUpdate("Model_Update", ModelId, ModelName, ModelUrl, FatherModelId, FatherModelName,UserCardId,ModelNum))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改成功");

            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "修改失败");

            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {


            Response.Redirect("ModelManage.aspx");
        }
    }
}