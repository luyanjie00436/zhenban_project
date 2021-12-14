using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanManage_Web
{
    public partial class StaManage : System.Web.UI.Page
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
                //if (bus.AuthoritySelect("Authority_SelectByUserCardId", UserCardId, "~/StaManage.aspx") == 0)
                //{
                //    Response.Redirect("Login.aspx");
                //}
                qingchu();
            }
        }
        public void qingchu ()
        {
            biaoa.Visible = false;
            biaob.Visible = false;
            biaoc.Visible = false;
            biaod.Visible = false;
            biaoe.Visible = false;
            biaof.Visible = false;
            biaog.Visible = false;
            biaoh.Visible = false;
            biaoi.Visible = false;
            biaoj.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoa.Visible = true;
            DataTable dt = bus.Select("Tongjia").Tables[0];
            A_a1.InnerText = dt.Rows[0]["上年末教职工总数"].ToString();
            A_a2.InnerText = dt.Rows[0]["本年度增加应届高等学校毕业生人数"].ToString();
            A_a3.InnerText = dt.Rows[0]["本年度增加应届中等专业学校毕业生"].ToString();
            A_a4.InnerText = dt.Rows[0]["本年度增加军转干部安置"].ToString();
            A_a5.InnerText = dt.Rows[0]["本年度增加调入"].ToString();
            A_a6.InnerText = dt.Rows[0]["本年度增加其他"].ToString();
            List<string> xData = new List<string>() { "应届高等学校毕业生", "应届中等专业学校毕业生", "军转干部安置", "调入", "其他" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["本年度增加应届高等学校毕业生人数"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度增加应届中等专业学校毕业生"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度增加军转干部安置"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度增加调入"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度增加其他"].ToString()) };
            Charta1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charta1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charta1.Series[0].Points.DataBindXY(xData, yData);
            A_a7.InnerText = dt.Rows[0]["本年度减少退休"].ToString();
            A_a8.InnerText = dt.Rows[0]["本年度减少辞职"].ToString();
            A_a9.InnerText = dt.Rows[0]["本年度减少辞退"].ToString();
            A_a10.InnerText = dt.Rows[0]["本年度减少开除"].ToString();
            A_a11.InnerText = dt.Rows[0]["本年度减少解聘"].ToString();
            A_a12.InnerText = dt.Rows[0]["本年度减少调出"].ToString();
            A_a13.InnerText = dt.Rows[0]["本年度减少其他"].ToString();
             xData = new List<string>() { "退休", "辞职", "辞退", "开除", "解聘", "调出", "其他" };
            yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["本年度减少退休"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少辞职"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少辞退"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少开除"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少解聘"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少调出"].ToString()), Convert.ToInt32(dt.Rows[0]["本年度减少其他"].ToString()) };
            Charta2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charta2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charta2.Series[0].Points.DataBindXY(xData, yData);
            A_a14.InnerText = dt.Rows[0]["本年末教职工实有数"].ToString();
            A_a15.InnerText = dt.Rows[0]["退休人员总数"].ToString();
            A_a16.InnerText = dt.Rows[0]["实有数与应有数之差"].ToString();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            qingchu();
            biaob.Visible = true;
            DataTable dt = bus.Select("Tongjib").Tables[0];
            B_b1.InnerText = dt.Rows[0]["现有女员工人数"].ToString();
            B_b2.InnerText = dt.Rows[0]["现有少数民族人数"].ToString();
            B_b3.InnerText = dt.Rows[0]["现有中共党员人数"].ToString();
            B_b4.InnerText = dt.Rows[0]["现有博士人数"].ToString();
            B_b5.InnerText = dt.Rows[0]["现有硕士人数"].ToString();
            B_b6.InnerText = dt.Rows[0]["现有外籍人员人数"].ToString();
            B_b7.InnerText = dt.Rows[0]["现有研究生人数"].ToString();
            B_b8.InnerText = dt.Rows[0]["现有本科人数"].ToString();
            B_b9.InnerText = dt.Rows[0]["现有大专人数"].ToString();
            B_b10.InnerText = dt.Rows[0]["现有中专人数"].ToString();
            B_b11.InnerText = dt.Rows[0]["现有高中及以下人数"].ToString();
            List<string> xData = new List<string>() { "研究生", "大学本科", "大学专科", "中专", "高中及以下" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["现有研究生人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有本科人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有大专人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有中专人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有高中及以下人数"].ToString()) };
            Chartb1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartb1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartb1.Series[0].Points.DataBindXY(xData, yData);
            B_b12.InnerText = dt.Rows[0]["现有35岁及以下人数"].ToString();
            B_b13.InnerText = dt.Rows[0]["现有36岁到40岁人数"].ToString();
            B_b14.InnerText = dt.Rows[0]["现有41岁到45岁人数"].ToString();
            B_b15.InnerText = dt.Rows[0]["现有46岁到50岁人数"].ToString();
            B_b16.InnerText = dt.Rows[0]["现有51岁到54岁人数"].ToString();
            B_b17.InnerText = dt.Rows[0]["现有55岁及以上人数"].ToString();
            xData = new List<string>() { "35岁及以下", "36~40", "41~45", "46~50", "54~54", "55岁及以上" };
            yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["现有35岁及以下人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有36岁到40岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有41岁到45岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有46岁到50岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有51岁到54岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有55岁及以上人数"].ToString()) };
            Chartb2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartb2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartb2.Series[0].Points.DataBindXY(xData, yData);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoc.Visible = true;
            DataTable dt = bus.Select("Tongjic").Tables[0];
            C_c1.InnerText = dt.Rows[0]["管理岗位编制人数"].ToString();
            C_c2.InnerText = dt.Rows[0]["管理岗位人数"].ToString();
            C_c3.InnerText = dt.Rows[0]["专业技术岗位编制人数"].ToString();
            C_c4.InnerText = dt.Rows[0]["专业技术岗位人数"].ToString();
            List<string> xData = new List<string>() { "管理岗位", "专业技术岗位", "工勤岗位" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["管理岗位编制人数"].ToString()), Convert.ToInt32(dt.Rows[0]["专业技术岗位编制人数"].ToString()), Convert.ToInt32(dt.Rows[0]["工勤岗位编制人数"].ToString())};
            Chartc1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartc1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartc1.Series[0].Points.DataBindXY(xData, yData);
            C_c5.InnerText = dt.Rows[0]["在管理岗位人数"].ToString();
            C_c6.InnerText = dt.Rows[0]["工勤岗位编制人数"].ToString();
            C_c7.InnerText = dt.Rows[0]["工勤人数"].ToString();
            xData = new List<string>() { "管理岗位", "专业技术岗位", "工勤岗位" };
            yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["管理岗位人数"].ToString()), Convert.ToInt32(dt.Rows[0]["专业技术岗位人数"].ToString()), Convert.ToInt32(dt.Rows[0]["工勤人数"].ToString())};
            Chartc2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartc2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartc2.Series[0].Points.DataBindXY(xData, yData);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            qingchu();
            biaod.Visible = true;
            DataTable dt = bus.Select("Tongjid").Tables[0];
            D_d1.InnerText = dt.Rows[0]["上年末已签订聘用合同人数"].ToString();
            D_d2.InnerText = dt.Rows[0]["新签订聘用合同人数"].ToString();
            D_d3.InnerText = dt.Rows[0]["未签订聘用合同人数"].ToString();
            D_d4.InnerText = dt.Rows[0]["本年末已签订聘用合同人数"].ToString();
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoe.Visible = true;
            DataTable dt = bus.Select("Tongjie").Tables[0];
            E_xj.Text = dt.Rows[0]["小计"].ToString();
            E_e1.InnerText = dt.Rows[0]["一级职员"].ToString();
            E_e2.InnerText = dt.Rows[0]["二级职员"].ToString();
            E_e3.InnerText = dt.Rows[0]["三级职员"].ToString();
            E_e4.InnerText = dt.Rows[0]["四级职员"].ToString();
            E_e5.InnerText = dt.Rows[0]["五级职员"].ToString();
            E_e6.InnerText = dt.Rows[0]["六级职员"].ToString();
            E_e7.InnerText = dt.Rows[0]["七级职员"].ToString();
            E_e8.InnerText = dt.Rows[0]["八级职员"].ToString();
            E_e9.InnerText = dt.Rows[0]["九级职员"].ToString();
            E_e10.InnerText = dt.Rows[0]["十级职员"].ToString();
            E_e11.InnerText = dt.Rows[0]["其他等级"].ToString();
            E_e12.InnerText = dt.Rows[0]["其他从业人员"].ToString();
            List<string> xData = new List<string>() {"一级", "二级", "三级", "四级", "五级", "六级", "七级", "八级", "九级", "十级", "其他等级", "其他从业人员" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["一级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["二级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["三级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["四级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["五级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["六级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["七级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["八级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["九级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["十级职员"].ToString()), Convert.ToInt32(dt.Rows[0]["其他等级"].ToString()), Convert.ToInt32(dt.Rows[0]["其他从业人员"].ToString()) };
            Charte1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charte1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charte1.Series[0].Points.DataBindXY(xData, yData);
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            qingchu();
            biaof.Visible = true;
            DataTable dt = bus.Select("Tongjif").Tables[0];
            F_xj.Text = dt.Rows[0]["小计"].ToString();
            F_f1.InnerText = dt.Rows[0]["一级"].ToString();
            F_f2.InnerText = dt.Rows[0]["二级"].ToString();
            F_f3.InnerText = dt.Rows[0]["三级"].ToString();
            F_f4.InnerText = dt.Rows[0]["四级"].ToString();
            F_f5.InnerText = dt.Rows[0]["五级"].ToString();
            F_f6.InnerText = dt.Rows[0]["六级"].ToString();
            F_f7.InnerText = dt.Rows[0]["七级"].ToString();
            F_f8.InnerText = dt.Rows[0]["八级"].ToString();
            F_f9.InnerText = dt.Rows[0]["九级"].ToString();
            F_f10.InnerText = dt.Rows[0]["十级"].ToString();
            F_f11.InnerText = dt.Rows[0]["初级"].ToString();
            //Labelf12.InnerText = dt.Rows[0]["十二级"].ToString();
            //Labelf13.InnerText = dt.Rows[0]["十三级"].ToString();
            F_f14.InnerText = dt.Rows[0]["其他等级"].ToString();
            F_f15.InnerText = dt.Rows[0]["其他从业人员"].ToString();
            List<string> xData = new List<string>() { "一级", "二级", "三级", "四级", "五级", "六级", "七级", "八级", "九级", "十级", "初级", "其他等级", "其他从业人员" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["一级"].ToString()), Convert.ToInt32(dt.Rows[0]["二级"].ToString()), Convert.ToInt32(dt.Rows[0]["三级"].ToString()), Convert.ToInt32(dt.Rows[0]["四级"].ToString()), Convert.ToInt32(dt.Rows[0]["五级"].ToString()), Convert.ToInt32(dt.Rows[0]["六级"].ToString()), Convert.ToInt32(dt.Rows[0]["七级"].ToString()), Convert.ToInt32(dt.Rows[0]["八级"].ToString()), Convert.ToInt32(dt.Rows[0]["九级"].ToString()), Convert.ToInt32(dt.Rows[0]["十级"].ToString()), Convert.ToInt32(dt.Rows[0]["初级"].ToString()), Convert.ToInt32(dt.Rows[0]["其他等级"].ToString()), Convert.ToInt32(dt.Rows[0]["其他从业人员"].ToString()) };
            Chartf1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartf1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartf1.Series[0].Points.DataBindXY(xData, yData);

        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            qingchu();
            biaog.Visible = true;
            DataTable dt = bus.Select("Tongjig").Tables[0];
            G_xj.Text = dt.Rows[0]["小计"].ToString();
            G_g1.InnerText = dt.Rows[0]["一级"].ToString();
            G_g2.InnerText = dt.Rows[0]["二级"].ToString();
            G_g3.InnerText = dt.Rows[0]["三级"].ToString();
            G_g4.InnerText = dt.Rows[0]["四级"].ToString();
            G_g5.InnerText = dt.Rows[0]["五级"].ToString();
            G_g6.InnerText = dt.Rows[0]["普通工"].ToString();
            G_g7.InnerText = dt.Rows[0]["其他等级人员"].ToString();
            G_g8.InnerText = dt.Rows[0]["其他从业人员"].ToString();
            List<string> xData = new List<string>() { "一级", "二级", "三级", "四级", "五级", "普通工", "其他等级", "其他从业人员" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["一级"].ToString()), Convert.ToInt32(dt.Rows[0]["二级"].ToString()), Convert.ToInt32(dt.Rows[0]["三级"].ToString()), Convert.ToInt32(dt.Rows[0]["四级"].ToString()), Convert.ToInt32(dt.Rows[0]["五级"].ToString()), Convert.ToInt32(dt.Rows[0]["普通工"].ToString()), Convert.ToInt32(dt.Rows[0]["其他等级人员"].ToString()), Convert.ToInt32(dt.Rows[0]["其他从业人员"].ToString()) };
            Chartg1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Chartg1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Chartg1.Series[0].Points.DataBindXY(xData, yData);
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoh.Visible = true;
            DataTable dt = bus.Select("Tongjih").Tables[0];
            H_h1.InnerText = dt.Rows[0]["现有研究生人数"].ToString();
            H_h2.InnerText = dt.Rows[0]["现有本科人数"].ToString();
            H_h3.InnerText = dt.Rows[0]["现有大专人数"].ToString();
            H_h4.InnerText = dt.Rows[0]["现有中专人数"].ToString();
            H_h5.InnerText = dt.Rows[0]["现有高中及以下人数"].ToString();
            List<string> xData = new List<string>() { "研究生人数", "本科人数", "大专人数","中专人数","高中及以下人数" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["现有研究生人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有本科人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有大专人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有中专人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有高中及以下人数"].ToString()) };
            Charth1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charth1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charth1.Series[0].Points.DataBindXY(xData, yData);
            H_h6.InnerText = dt.Rows[0]["现有35岁及以下人数"].ToString();
            H_h7.InnerText = dt.Rows[0]["现有36岁到40岁人数"].ToString();
            H_h8.InnerText = dt.Rows[0]["现有41岁到45岁人数"].ToString();
            H_h9.InnerText = dt.Rows[0]["现有46岁到50岁人数"].ToString();
            H_h10.InnerText = dt.Rows[0]["现有51岁到54岁人数"].ToString();
            H_h11.InnerText = dt.Rows[0]["现有55岁到59岁人数"].ToString();
            H_h12.InnerText = dt.Rows[0]["现有60岁及以上人数"].ToString();
            xData = new List<string>() { "35及以下", "36~40", "41~45","46~50","51~54","55~59","60及以上" };
            yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["现有35岁及以下人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有36岁到40岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有41岁到45岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有46岁到50岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有51岁到54岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有55岁到59岁人数"].ToString()), Convert.ToInt32(dt.Rows[0]["现有60岁及以上人数"].ToString()) };
            Charth2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charth2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charth2.Series[0].Points.DataBindXY(xData, yData);
            H_h13.InnerText = dt.Rows[0]["在管理岗位工作的"].ToString();

        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoi.Visible = true;
            DataTable dt = bus.Select("Tongjii").Tables[0];
            I_i1.InnerText = dt.Rows[0]["教师教授人数"].ToString();
            I_i2.InnerText = dt.Rows[0]["教师副教授人数"].ToString();
            I_i3.InnerText = dt.Rows[0]["教师讲师人数"].ToString();
            I_i4.InnerText = dt.Rows[0]["教师助教人数"].ToString();
            I_i5.InnerText = dt.Rows[0]["教师未定级人数"].ToString();
            List<string> xData = new List<string>() { "教授", "副教授", "讲师", "助教", "未定级" };
            List<int> yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["教师教授人数"].ToString()), Convert.ToInt32(dt.Rows[0]["教师副教授人数"].ToString()), Convert.ToInt32(dt.Rows[0]["教师讲师人数"].ToString()), Convert.ToInt32(dt.Rows[0]["教师助教人数"].ToString()), Convert.ToInt32(dt.Rows[0]["教师未定级人数"].ToString()) };
            Charti1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charti1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charti1.Series[0].Points.DataBindXY(xData, yData);
            I_i6.InnerText = dt.Rows[0]["其他类别正高人数"].ToString();
            I_i7.InnerText = dt.Rows[0]["其他类别副高人数"].ToString();
            I_i8.InnerText = dt.Rows[0]["其他类别中级人数"].ToString();
            I_i9.InnerText = dt.Rows[0]["其他类别初级人数"].ToString();
            I_i10.InnerText = dt.Rows[0]["其他类别未定级人数"].ToString();
            xData = new List<string>() { "正高", "副高", "中级", "初级", "未定级"};
            yData = new List<int>() { Convert.ToInt32(dt.Rows[0]["其他类别正高人数"].ToString()), Convert.ToInt32(dt.Rows[0]["其他类别副高人数"].ToString()), Convert.ToInt32(dt.Rows[0]["其他类别中级人数"].ToString()), Convert.ToInt32(dt.Rows[0]["其他类别初级人数"].ToString()), Convert.ToInt32(dt.Rows[0]["其他类别未定级人数"].ToString())};
            Charti2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Charti2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Charti2.Series[0].Points.DataBindXY(xData, yData);
            I_i11.InnerText = dt.Rows[0]["具有职业资格人数"].ToString();
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            qingchu();
            biaoj.Visible = true;
            DataTable dt = bus.Select("Tongjij").Tables[0];
            J_j1.InnerText = dt.Rows[0]["参加培训人员合计"].ToString();
            J_j3.InnerText = dt.Rows[0]["十五天以内"].ToString();
            J_j4.InnerText = dt.Rows[0]["十五天至不满一个月"].ToString();
            J_j5.InnerText = dt.Rows[0]["一个月至不满三个月"].ToString();
            J_j6.InnerText = dt.Rows[0]["三个月及以上"].ToString();
            J_j7.InnerText = dt.Rows[0]["管理人员"].ToString();
            J_j8.InnerText = dt.Rows[0]["工勤人员"].ToString();
            J_j9.InnerText = dt.Rows[0]["专业技术人员"].ToString();
        }
    }
}