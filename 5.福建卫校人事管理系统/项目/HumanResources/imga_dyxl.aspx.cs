using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class imga_dyxl : System.Web.UI.Page
    {
        HumanManage_Data.GetData bus = new HumanManage_Data.GetData();
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
        string UserCardId;
        string leibie, proc, ColName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    UserCardId = Request.QueryString["id"];
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                leibie = Request.QueryString["leibie"];
                if (leibie == "FirstProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "DYXL_Photo";
                }
                else if (leibie == "HeighestProfession")
                {
                    proc = "UserEducation_SelectByPhotodyxl";
                    ColName = "ZGXL_Photo";
                }
                else if (leibie == "FirstDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "DYXW_Photo";
                }
                else if (leibie == "HeighestDegree")
                {
                    proc = "UserDegree_SelectByPhotodyxw";
                    ColName = "ZGXW_Photo";
                }
                else if (leibie == "Photo")
                {
                    proc = "UserInfo_SelectByMyImage";
                    ColName = "Photo";
                }

                DataSet ds = bus.SelectByUserCardId(proc, UserCardId);
               
                if (ds.Tables[0].Rows[0][ColName].ToString().Length > 0)
                {
                    WritePhoto(((Byte[])ds.Tables[0].Rows[0][ColName]));
                }
            }
        }
        public void WritePhoto(byte[] streamByte)
        {
            // Response.ContentType 的默认值为默认值为“text/html”
            Response.ContentType = "image/GIF";
            //图片输出的类型有: image/GIF  image/JPEG
            Response.BinaryWrite(streamByte);

        }
    }
}