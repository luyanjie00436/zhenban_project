using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class ModelAdd : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
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

                    Response.Redirect("Login.aspx");
                }
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/ModelManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                DataSet Model = bus.Select("ModelFather_Select");
                foreach (DataRow dr in Model.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["ModelName"].ToString(), dr["ModelId"].ToString());
                    DlModel.Items.Add(li);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
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
            if (bus.ModelInsert("Model_Insert", ModelName, ModelUrl, FatherModelId, FatherModelName, ModelNum))
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加成功");

                clearIfo();
            }
            else
            {
                AlertMsgAndNoFlush(UpdatePanel1, "添加失败");

            }

        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            clearIfo();
        }
        public void clearIfo()
        {
            txtModelName.Text = "";
            txtModelUrl.Text = "";
        }
    }
}