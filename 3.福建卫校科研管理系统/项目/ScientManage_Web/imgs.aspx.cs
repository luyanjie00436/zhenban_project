using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class imgs : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
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

                DataSet ds = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId);
                WritePhoto(((Byte[])ds.Tables[0].Rows[0]["myimage"]));

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