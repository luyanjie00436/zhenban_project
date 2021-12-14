using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment
{
    public partial class imgs : System.Web.UI.Page
    {
        Recruitment_Data.GetData bus = new Recruitment_Data.GetData();
        Recruitment_Data.pwd pwds = new Recruitment_Data.pwd();
        string Number;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                if (Request.QueryString["id"] != null)
                {
                    Number = Request.QueryString["id"];
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                DataSet ds = bus.SelectByNumber("CandidatesInfo_SelectByNumber", Number);
                if (ds.Tables[0].Rows[0]["Photo"].ToString().Length>0)
                {
                    WritePhoto(((Byte[])ds.Tables[0].Rows[0]["Photo"]));
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