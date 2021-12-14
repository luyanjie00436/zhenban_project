using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class UserInfoManage : System.Web.UI.Page
    {
        HumanManage_Data.pwd pwds = new HumanManage_Data.pwd();
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
                if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/UserInfoManage.aspx") == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                #region bd
              
                DataSet Status = bus.Select("Status_Select");
                foreach (DataRow dr in Status.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["StatusName"].ToString(), dr["StatusName"].ToString());
                    DlStatus.Items.Add(li);
                }
                DataSet Political = bus.Select("Political_Select");
                foreach (DataRow dr in Political.Tables[0].Rows)
                {
                    ListItem li = new ListItem(dr["PoliticalName"].ToString(), dr["PoliticalName"].ToString());
                    DlPolitical.Items.Add(li);
                }
                #endregion
                GridView1.AutoGenerateColumns = false;
                dataGriviewBD();

            }

        }
        public void dataGriviewBD()
        {
            string UserName = txtUserName.Text.Trim().ToString();
          
            string StatusId = DlStatus.SelectedItem.Value;
            if (StatusId == "0")
            {
                StatusId = "";
            }
            string PoliticalId = DlPolitical.SelectedItem.Value;
            if (PoliticalId == "0")
            {
                PoliticalId = "";
            }
            string Gender = DlGender.SelectedItem.Text;
            string StartYear = txtStartYear.Text.Trim().ToString();
            string EndYear = txtEndYear.Text.Trim().ToString();
            if (Gender == "请选择")
            {
                Gender = "";
            }
            if (StartYear != "")
            {
                try
                {
                    int Start = Convert.ToInt32(StartYear);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('年龄请输入数字');</script>");
                    return;
                }
            }
            if (EndYear != "")
            {
                try
                {
                    int End = Convert.ToInt32(EndYear);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('年龄请输入数字');</script>");
                    return;
                }
            }
            DataTable dt = bus.UserInfoSelect("UserMailList_Select", UserName, StatusId, StartYear, EndYear, Gender, PoliticalId).Tables[0];
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            foreach (DataColumn dc in dt.Columns)
            {
                var c = dc.ColumnName.ToString();
                var c2 = c;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dataGriviewBD();
        }
        public static void AlertMsgAndNoFlush(Control controlName, string message)
        {
            ScriptManager.RegisterClientScriptBlock(controlName, typeof(UpdatePanel), "提示", "alert('" + message + "');", true);
        }

        protected void LinkButton8_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("UserInfoUpd.aspx?UserCardId=" + pwds.EncryptDES(e.CommandArgument.ToString(), "asdfasdf") + "");
        }
        protected void LinkButton9_Command(object sender, CommandEventArgs e)
        {
            string UserCardId = e.CommandArgument.ToString();
            DataTable dt1, dt2, dt3, dt4, dt5, dt6,dt7,dt8,dt9 ; //dt1 个人信息  dt2 职称聘任  dt3 职业资格 dt4 工作经历 dt5 社会兼职 dt6 培训进修 dt7 历年获奖 dt8 年度考核
            dt1 = bus.SelectByUserCardId("UserView_SelectByUserCardId", UserCardId).Tables[0];
            dt2 = bus.SelectByUserCardId("UseOffice_SelectByUserCardId", UserCardId).Tables[0];
            while (dt2.Rows.Count < 1)
            {
                dt2.Rows.Add(dt2.NewRow());
            }
            dt3 = bus.SelectByUserCardId("JobCertificate_SelectUserCardId", UserCardId).Tables[0];
            while (dt3.Rows.Count < 1)
            {
                dt3.Rows.Add(dt3.NewRow());
            }
            dt4 = bus.SelectByUserCardId("WorkExperience_SelectUserCardId", UserCardId).Tables[0];
            while (dt4.Rows.Count < 1)
            {
                dt4.Rows.Add(dt4.NewRow());
            }
            dt5 = bus.SelectByUserCardId("Parttimejob_SelectUserCardId", UserCardId).Tables[0];
            while (dt5.Rows.Count < 1)
            {
                dt5.Rows.Add(dt5.NewRow());
            }
            dt6 = bus.SelectByUserCardId("StudyTrain_SelectUserCardId", UserCardId).Tables[0];
            while (dt6.Rows.Count < 1)
            {
                dt6.Rows.Add(dt6.NewRow());
            }
            dt7 = bus.SelectByUserCardId("PastAwards_SelectUserCardId", UserCardId).Tables[0];
            while (dt7.Rows.Count < 1)
            {
                dt7.Rows.Add(dt7.NewRow());
            }
            dt8 = bus.SelectByUserCardId("YearAssessment_SelectUserCardId", UserCardId).Tables[0];
            while (dt8.Rows.Count < 1)
            {
                dt8.Rows.Add(dt8.NewRow());
            }

            dt9 = bus.SelectByUserCardId("UserInfo_SelectByUserCardId", UserCardId).Tables[0];
            string ReportFileName = Server.MapPath("out.xls");
            string TempletFileName = Server.MapPath("File/UserInfo.xls");
            FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet mySheet = (HSSFSheet)hssfworkbook.GetSheet("Sheet1");
            #region dt1

            int pictureIdx = 0;
            if (dt9.Rows[0]["Photo"].ToString().Length == 0)
            {
                mySheet.GetRow(1).GetCell(2).SetCellValue("");
            }
            else
            {
                pictureIdx = hssfworkbook.AddPicture((byte[])dt9.Rows[0]["Photo"], PictureType.JPEG);
                HSSFPatriarch patriarch = (HSSFPatriarch)mySheet.CreateDrawingPatriarch();
                HSSFClientAnchor anchor = new HSSFClientAnchor(1, 1, 0, 0, 1, 1, 2, 4);
                //##处理照片位置，【图片左上角为（col, row）第row+1行col+1列，右下角为（ col +1, row +1）第 col +1+1行row +1+1列，第三个参数为宽，第四个参数为高

                HSSFPicture pict = (HSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);
                // pict.Resize();//这句话一定不要，这是用图片原始大小来显示
            }
            mySheet.GetRow(1).GetCell(4).SetCellValue(dt1.Rows[0]["工号"].ToString());
            mySheet.GetRow(1).GetCell(6).SetCellValue(dt1.Rows[0]["性别"].ToString());
            mySheet.GetRow(1).GetCell(8).SetCellValue(dt1.Rows[0]["出生年月"].ToString());
            mySheet.GetRow(1).GetCell(10).SetCellValue(dt1.Rows[0]["身份证号"].ToString());
            mySheet.GetRow(1).GetCell(12).SetCellValue(dt1.Rows[0]["民族"].ToString());

            mySheet.GetRow(2).GetCell(4).SetCellValue(dt1.Rows[0]["姓名"].ToString());
            mySheet.GetRow(2).GetCell(6).SetCellValue(dt1.Rows[0]["政治面貌"].ToString());
            mySheet.GetRow(2).GetCell(8).SetCellValue(dt1.Rows[0]["入党时间"].ToString());
            mySheet.GetRow(2).GetCell(10).SetCellValue(dt1.Rows[0]["参加工作时间"].ToString());
            mySheet.GetRow(2).GetCell(12).SetCellValue(dt1.Rows[0]["入职院校时间"].ToString());

            mySheet.GetRow(3).GetCell(4).SetCellValue(dt1.Rows[0]["籍贯"].ToString());
            mySheet.GetRow(3).GetCell(6).SetCellValue(dt1.Rows[0]["家庭地址"].ToString());
            mySheet.GetRow(3).GetCell(12).SetCellValue(dt1.Rows[0]["在职状态"].ToString());

            mySheet.GetRow(4).GetCell(2).SetCellValue(dt1.Rows[0]["是否管理干部"].ToString());
            mySheet.GetRow(4).GetCell(4).SetCellValue(dt1.Rows[0]["干部职级"].ToString());
            mySheet.GetRow(4).GetCell(6).SetCellValue(dt1.Rows[0]["现任职务"].ToString());
            mySheet.GetRow(4).GetCell(8).SetCellValue(dt1.Rows[0]["所在部门"].ToString());
            mySheet.GetRow(4).GetCell(10).SetCellValue(dt1.Rows[0]["任现职务时间"].ToString());
            mySheet.GetRow(4).GetCell(12).SetCellValue(dt1.Rows[0]["管理职级"].ToString());

            mySheet.GetRow(5).GetCell(2).SetCellValue(dt1.Rows[0]["有无具有专业技术职称"].ToString());
            mySheet.GetRow(5).GetCell(4).SetCellValue(dt1.Rows[0]["职称系列"].ToString());
            mySheet.GetRow(5).GetCell(6).SetCellValue(dt1.Rows[0]["职称等级"].ToString());
            mySheet.GetRow(5).GetCell(8).SetCellValue(dt1.Rows[0]["专技职级"].ToString());
            mySheet.GetRow(5).GetCell(10).SetCellValue(dt1.Rows[0]["所属部门"].ToString());
            mySheet.GetRow(5).GetCell(12).SetCellValue(dt1.Rows[0]["任现职称时间"].ToString());

            mySheet.GetRow(6).GetCell(2).SetCellValue(dt1.Rows[0]["是否属于教师系列"].ToString());
            mySheet.GetRow(6).GetCell(4).SetCellValue(dt1.Rows[0]["教师类别"].ToString());
            mySheet.GetRow(6).GetCell(6).SetCellValue(dt1.Rows[0]["高校教师资格证书获取时间"].ToString());
            mySheet.GetRow(6).GetCell(8).SetCellValue(dt1.Rows[0]["现是否为专业带头人或负责人"].ToString());
            mySheet.GetRow(6).GetCell(10).SetCellValue(dt1.Rows[0]["现是否为骨干教师"].ToString());
            mySheet.GetRow(6).GetCell(12).SetCellValue(dt1.Rows[0]["现是否为双师型教师"].ToString());

            mySheet.GetRow(7).GetCell(2).SetCellValue(dt1.Rows[0]["是否工勤人员"].ToString());
            mySheet.GetRow(7).GetCell(4).SetCellValue(dt1.Rows[0]["职级"].ToString());
            mySheet.GetRow(7).GetCell(6).SetCellValue(dt1.Rows[0]["任现职级"].ToString());
            mySheet.GetRow(7).GetCell(8).SetCellValue(dt1.Rows[0]["任现职级时间"].ToString());
            mySheet.GetRow(7).GetCell(10).SetCellValue(dt1.Rows[0]["工勤人员所在部门"].ToString());

            mySheet.GetRow(8).GetCell(2).SetCellValue(dt1.Rows[0]["第一学历"].ToString());
            mySheet.GetRow(8).GetCell(4).SetCellValue(dt1.Rows[0]["第一学历获得时间"].ToString());
            mySheet.GetRow(8).GetCell(6).SetCellValue(dt1.Rows[0]["第一学历毕业院校"].ToString());
            mySheet.GetRow(8).GetCell(10).SetCellValue(dt1.Rows[0]["第一学历专业"].ToString());

            mySheet.GetRow(9).GetCell(2).SetCellValue(dt1.Rows[0]["最高学历"].ToString());
            mySheet.GetRow(9).GetCell(4).SetCellValue(dt1.Rows[0]["最高学历获得时间"].ToString());
            mySheet.GetRow(9).GetCell(6).SetCellValue(dt1.Rows[0]["最高学历毕业院校"].ToString());
            mySheet.GetRow(9).GetCell(10).SetCellValue(dt1.Rows[0]["最高学历专业"].ToString());

            mySheet.GetRow(10).GetCell(2).SetCellValue(dt1.Rows[0]["第一学位"].ToString());
            mySheet.GetRow(10).GetCell(4).SetCellValue(dt1.Rows[0]["第一学位获得时间"].ToString());
            mySheet.GetRow(10).GetCell(6).SetCellValue(dt1.Rows[0]["第一学位毕业院校"].ToString());
            mySheet.GetRow(10).GetCell(10).SetCellValue(dt1.Rows[0]["第一学位专业"].ToString());

            mySheet.GetRow(11).GetCell(2).SetCellValue(dt1.Rows[0]["最高学位"].ToString());
            mySheet.GetRow(11).GetCell(4).SetCellValue(dt1.Rows[0]["最高学位获得时间"].ToString());
            mySheet.GetRow(11).GetCell(6).SetCellValue(dt1.Rows[0]["最高学位毕业院校"].ToString());
            mySheet.GetRow(11).GetCell(10).SetCellValue(dt1.Rows[0]["最高学位专业"].ToString());

        

            #endregion
            #region dt2
            HSSFCellStyle style6 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            style6.BorderBottom = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style6.BorderLeft = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style6.BorderRight = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style6.BorderTop = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style6.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style6.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style6.WrapText = true;//自动换行
            NPOI.SS.UserModel.Font f = hssfworkbook.CreateFont();  //定义文字
           // f.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD; //文字加粗
            f.FontHeightInPoints = 12;  //文字大小
            f.FontName = "宋体"; //字体
            style6.SetFont(f);
            int dt2count = dt2.Rows.Count;

            for (int j = 0; j <= dt2count; j++)
            {
                mySheet.CreateRow(12 + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, 12, 12 + dt2count, 0, 0);
            mySheet.GetRow(12).GetCell(0).SetCellValue("职称聘任情况");

            #region 表头
            HSSFCellStyle style7 = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            style7.BorderBottom = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderLeft = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderRight = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.BorderTop = (NPOI.SS.UserModel.CellBorderType)NPOI.SS.UserModel.BorderStyle.THIN;
            style7.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平居中  
            style7.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直居中  
            style7.WrapText = true;//自动换行
            NPOI.SS.UserModel.Font f1 = hssfworkbook.CreateFont();  //定义文字
            f1.FontHeightInPoints = 12;  //文字大小
            f1.FontName = "宋体"; //字体
            style7.SetFont(f1);
            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(12).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, 12, 12, 1,1);
            mySheet.GetRow(12).GetCell(1).SetCellValue("聘任时间");
            SetCellRangeAddress(mySheet, 12, 12, 2,2);
            mySheet.GetRow(12).GetCell(2).SetCellValue("专业");
            SetCellRangeAddress(mySheet, 12, 12, 3, 3);
            mySheet.GetRow(12).GetCell(3).SetCellValue("专业技术资格名称");
            SetCellRangeAddress(mySheet, 12, 12, 4, 4);
            mySheet.GetRow(12).GetCell(4).SetCellValue("备注");
           
            #endregion

            for (int i = 0; i < dt2count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(13 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, 13 + i, 13 + i, 1, 1);
                mySheet.GetRow(13 + i).GetCell(1).SetCellValue(dt2.Rows[i]["AppointmentDate"].ToString());
                SetCellRangeAddress(mySheet, 13 + i, 13 + i, 2, 2);
                mySheet.GetRow(13 + i).GetCell(2).SetCellValue(dt2.Rows[i]["Profession"].ToString());
                SetCellRangeAddress(mySheet, 13 + i, 13 + i, 3, 3);
                mySheet.GetRow(13 + i).GetCell(3).SetCellValue(dt2.Rows[i]["ProfessionQualificationName"].ToString());
                SetCellRangeAddress(mySheet, 13 + i, 13 + i, 4, 4);
                mySheet.GetRow(13 + i).GetCell(4).SetCellValue(dt2.Rows[i]["Remarks"].ToString());


            }
            #endregion
            #region dt3

            int NewStart = 12 + dt2count + 1;
            int dt3count = dt3.Rows.Count;

            for (int j = 0; j <= dt3count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt3count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("职业资格证书");

            #region 表头

            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("职业资格名称");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("发证单位");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("获取时间");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");
          
            #endregion

            for (int i = 0; i < dt3count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt3.Rows[i]["JobQualificationName"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt3.Rows[i]["IsssueUnit"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue(dt3.Rows[i]["JobDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                //mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt3.Rows[i]["Remarks"].ToString());
            }
            #endregion
            #region dt4

            NewStart = NewStart + dt3count + 1;
            int dt4count = dt4.Rows.Count;

            for (int j = 0; j <= dt4count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt4count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("工作经历");

            #region 表头

            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("自何年何月");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("至何年何月");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("在何部门担任何职务");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");
            #endregion

            for (int i = 0; i < dt4count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt4.Rows[i]["StartDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt4.Rows[i]["EndDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue(dt4.Rows[i]["DepartmentName"].ToString()+ "担任"+dt4.Rows[i]["RoleName"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt4.Rows[i]["Remarks"].ToString());

            }
            #endregion
            #region dt5

            NewStart = NewStart + dt4count + 1;
            int dt5count = dt5.Rows.Count;

            for (int j = 0; j <= dt5count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt5count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("社会兼职情况");

            #region 表头

            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("自何年何月");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("至何年何月");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("在何单位、部门、担任何职务");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");

            #endregion
            for (int i = 0; i < dt5count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt5.Rows[i]["StartDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt5.Rows[i]["EndDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue("在" + dt5.Rows[i]["UnitName"].ToString() + "、" + dt5.Rows[i]["DepartmentName"].ToString() + "担任" + dt5.Rows[i]["RoleName"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt5.Rows[i]["Remarks"].ToString());

            }
            #endregion
            #region dt6

            NewStart = NewStart + dt5count + 1;
            int dt6count = dt6.Rows.Count;

            for (int j = 0; j <= dt6count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt6count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("培训进修情况");

            #region 表头

            for (int i= 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("培训时间");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("培训项目名称");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("培训单位");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");
          
            #endregion

            for (int i = 0; i < dt6count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt6.Rows[i]["TrainStartDate"].ToString()+"-"+ dt6.Rows[i]["TrainEndDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt6.Rows[i]["TrainProjectName"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue(dt6.Rows[i]["TrainUnit"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt6.Rows[i]["Remarks"].ToString());
                
            }
            #endregion
            #region dt7

            NewStart = NewStart + dt6count + 1;
            int dt7count = dt7.Rows.Count;

            for (int j = 0; j <= dt7count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt7count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("历年获奖情况");

            #region 表头

            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("获奖时间");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("获奖项目名称");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("授予单位");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");
           

            #endregion

            for (int i = 0; i < dt7count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt7.Rows[i]["AwardDate"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt7.Rows[i]["AwardProjectName"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue(dt7.Rows[i]["GrantUnit"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt7.Rows[i]["Remarks"].ToString());
               

            }
            #endregion
            #region dt8

            NewStart = NewStart + dt7count + 1;
            int dt8count = dt8.Rows.Count;

            for (int j = 0; j <= dt8count; j++)
            {
                mySheet.CreateRow(NewStart + j).CreateCell(0).CellStyle = style6;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart + dt8count, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("年度考核情况");

            #region 表头

            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 1);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("年度");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 2, 2);
            mySheet.GetRow(NewStart).GetCell(2).SetCellValue("工作量完成情况");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 3, 3);
            mySheet.GetRow(NewStart).GetCell(3).SetCellValue("考核等次");
            SetCellRangeAddress(mySheet, NewStart, NewStart, 4, 4);
            mySheet.GetRow(NewStart).GetCell(4).SetCellValue("备注");
            

            #endregion

            for (int i = 0; i < dt8count; i++)
            {

                for (int j = 1; j <= 4; j++)
                {
                    mySheet.GetRow(NewStart + 1 + i).CreateCell(j).CellStyle = style7;
                }
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 1, 1);
                mySheet.GetRow(NewStart + 1 + i).GetCell(1).SetCellValue(dt8.Rows[i]["Year"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 2, 2);
                mySheet.GetRow(NewStart + 1 + i).GetCell(2).SetCellValue(dt8.Rows[i]["WorkCompletion"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 3, 3);
                mySheet.GetRow(NewStart + 1 + i).GetCell(3).SetCellValue(dt8.Rows[i]["AssessmentGrade"].ToString());
                SetCellRangeAddress(mySheet, NewStart + 1 + i, NewStart + 1 + i, 4, 4);
                mySheet.GetRow(NewStart + 1 + i).GetCell(4).SetCellValue(dt8.Rows[i]["Remarks"].ToString());
               
            }
            #endregion
            #region dt9

            NewStart = NewStart + dt8count + 1;
            mySheet.CreateRow(NewStart ).CreateCell(0).CellStyle = style6;
            SetCellRangeAddress(mySheet, NewStart, NewStart, 0, 0);
            mySheet.GetRow(NewStart).GetCell(0).SetCellValue("其他情况");
            for (int i = 1; i <= 4; i++)
            {
                mySheet.GetRow(NewStart).CreateCell(i).CellStyle = style7;
            }
            SetCellRangeAddress(mySheet, NewStart, NewStart, 1, 4);
            mySheet.GetRow(NewStart).GetCell(1).SetCellValue("来源信息："+ dt1.Rows[0]["来源信息"].ToString() + "，离校时间："+ dt1.Rows[0]["离校时间"].ToString() + "，离校原因："+ dt1.Rows[0]["离校原因"].ToString() + "，编制信息："+ dt1.Rows[0]["编制信息"].ToString() + "，是否外籍人员："+ dt1.Rows[0]["是否外籍人员"].ToString());
   
            
            #endregion
            mySheet.ForceFormulaRecalculation = true;

            using (FileStream filess = File.OpenWrite(ReportFileName))
            {
                hssfworkbook.Write(filess);
            }
            //filess.Close();  
            System.IO.FileInfo filet = new System.IO.FileInfo(ReportFileName);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("人员信息.xls"));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度   
            Response.AddHeader("Content-Length", filet.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载   
            Response.ContentType = "application/ms-excel";
            // 把文件流发送到客户端   
            Response.WriteFile(filet.FullName);
            // 停止页面的执行   
            Response.End();

        }

        //合并单元格
        public static void SetCellRangeAddress(HSSFSheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
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
            Response.Redirect("UserInfoManage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (bus.Update("UserInfo_UserLockAll"))
            {
                AlertMsgAndNoFlush(Button2, "人员信息锁定成功");
            }
            else
            {
                AlertMsgAndNoFlush(Button2, "人员信息锁定失败");
            }
        }
    }
}