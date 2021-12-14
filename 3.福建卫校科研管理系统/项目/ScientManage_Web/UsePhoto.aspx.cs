using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScientManage_Web
{
    public partial class UsePhoto : System.Web.UI.Page
    {
        ScientManage_Data.GetData bus = new ScientManage_Data.GetData();
        ScientManage_Data.pwd pwds = new ScientManage_Data.pwd();
        string UserCardId;
        int UseOfficeId;
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
                if (Request.QueryString["UseOffice"] != null)
                {
                    try
                    {
                        UseOfficeId = Convert.ToInt32(Request.QueryString["UseOffice"]);
                    }
                    catch (Exception)
                    {

                        Response.Redirect("Login.aspx");
                    }
                    DataSet ds = bus.SelectByUseOfficeId("UseOffice_SelectByUseOfficeId", UseOfficeId);
                    WritePhoto(((Byte[])ds.Tables[0].Rows[0]["CertificatePhoto"]));
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