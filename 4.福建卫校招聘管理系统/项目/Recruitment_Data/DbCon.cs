using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Data
{
    public class DbCon
    {
        protected static string conStr = ConfigurationManager.AppSettings["Scien_ConStr2"];

        #region 登录
        ///<summary>
        ///登录验证
        ///</summary>
        ///<param name="userCardId">用户工号</param>
        ///<param name="userPwd">密码</param>
        ///<returns>验证结果</returns>
        public int Login(string userCardId, string userPwd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("UserInfo_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userCardId", SqlDbType.VarChar, 50).Value = userCardId;
                    cmd.Parameters.Add("@userPwd", SqlDbType.VarChar, 100).Value = userPwd;
                    SqlParameter isSuccess = new SqlParameter("@isSuccess", SqlDbType.Int);
                    isSuccess.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(isSuccess);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(isSuccess.Value);
                }
            }
            catch (Exception ex)
            {
                return 3;
            }
        }
        ///<summary>
        ///登录验证
        ///</summary>
        ///<param name="userCardId">用户工号</param>
        ///<param name="userPwd">密码</param>
        ///<returns>验证结果</returns>
        public int KSLogin(string userCardId, string userPwd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("CandidatesInfo__Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = userCardId;
                    cmd.Parameters.Add("@Pwd", SqlDbType.VarChar, 100).Value = userPwd;
                    SqlParameter isSuccess = new SqlParameter("@isSuccess", SqlDbType.Int);
                    isSuccess.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(isSuccess);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(isSuccess.Value);
                }
            }
            catch (Exception ex)
            {
                return 3;
            }
        }
        #endregion
        #region 权限

        /// <summary>
        /// 职务权限信息查询
        /// </summary>
        /// <returns></returns>
        public int AuthroitySelect(string proc, string UserCardId, string ModelUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@ModelUrl", SqlDbType.VarChar, 100).Value = ModelUrl;

                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return y;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 角色权限信息添加
        /// </summary>
        /// <returns></returns>
        public bool AuthroityInsert(string proc, int RoleId, int ModelId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@ModelId", SqlDbType.Int).Value = ModelId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion
        #region 用户管理
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        public bool UserInfoInsert(string proc, string UserCardId1, string UserName,string Pwd1)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId1;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserPwd", SqlDbType.NVarChar, 160).Value = Pwd1;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 考生信息单个查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByUserInfoId(string proc, string UserInfoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserInfoId", SqlDbType.VarChar, 50).Value = UserInfoId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns>
        public bool UserInfoUpdate(string proc, int UserInfoId,string UserCardId1, string UserName, string Pwd1)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserInfoId", SqlDbType.Int).Value = UserInfoId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId1;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserPwd", SqlDbType.NVarChar, 160).Value = Pwd1;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户删除
        /// </summary>
        /// <returns></returns>
        public bool UserInfoDelete(string proc, int UserInfoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserInfoId", SqlDbType.Int).Value = UserInfoId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region 岗位信息
        /// <summary>
        /// 岗位添加
        /// </summary>
        /// <returns></returns>
        public bool JobMangeInsert(string proc, string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree,string Gender,string Nation ,string Political,string Should,
                                   string Recruitment,string Position , string JobsYears , string SubjectName , 
                                   string ApplyCost ,string  Profession ,string  Others, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobCode", SqlDbType.VarChar,20).Value = JobCode;
                    com.Parameters.Add("@JobName", SqlDbType.VarChar, 20).Value = JobName;
                    com.Parameters.Add("@Enrollment", SqlDbType.VarChar, 20).Value = Enrollment;
                    com.Parameters.Add("@Age", SqlDbType.VarChar, 20).Value = Age;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Culture", SqlDbType.VarChar, 50).Value = Culture;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    com.Parameters.Add("@Should", SqlDbType.VarChar, 50).Value = Should;
                    com.Parameters.Add("@Recruitment", SqlDbType.VarChar, 50).Value = Recruitment;
                    com.Parameters.Add("@Position", SqlDbType.VarChar, 50).Value = Position;
                    com.Parameters.Add("@JobsYears", SqlDbType.VarChar, 50).Value = JobsYears;
                    com.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50).Value = SubjectName;
                    com.Parameters.Add("@ApplyCost", SqlDbType.VarChar, 50).Value = ApplyCost;
                    com.Parameters.Add("@Profession", SqlDbType.VarChar, 200).Value = Profession;
                    com.Parameters.Add("@Others", SqlDbType.VarChar, 500).Value = Others;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        /// <returns></returns>
        public bool JobMangeUpdate(string proc,int JobMangeId, string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree, string Gender, string Nation, string Political, string Should,
                                   string Recruitment, string Position, string JobsYears, string SubjectName,
                                   string ApplyCost, string Profession, string Others, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    com.Parameters.Add("@JobCode", SqlDbType.VarChar, 20).Value = JobCode;
                    com.Parameters.Add("@JobName", SqlDbType.VarChar, 20).Value = JobName;
                    com.Parameters.Add("@Enrollment", SqlDbType.VarChar, 20).Value = Enrollment;
                    com.Parameters.Add("@Age", SqlDbType.VarChar, 20).Value = Age;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Culture", SqlDbType.VarChar, 50).Value = Culture;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    com.Parameters.Add("@Should", SqlDbType.VarChar, 50).Value = Should;
                    com.Parameters.Add("@Recruitment", SqlDbType.VarChar, 50).Value = Recruitment;
                    com.Parameters.Add("@Position", SqlDbType.VarChar, 50).Value = Position;
                    com.Parameters.Add("@JobsYears", SqlDbType.VarChar, 50).Value = JobsYears;
                    com.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50).Value = SubjectName;
                    com.Parameters.Add("@ApplyCost", SqlDbType.VarChar, 50).Value = ApplyCost;
                    com.Parameters.Add("@Profession", SqlDbType.VarChar, 200).Value = Profession;
                    com.Parameters.Add("@Others", SqlDbType.VarChar, 500).Value = Others;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


        /// <summary>
        /// 修改考室
        /// </summary>
        /// <returns></returns>
        public bool JobMangeUpdateTestAdd(string proc, int JobMangeId, string TestAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    com.Parameters.Add("@TestAddress", SqlDbType.VarChar, 20).Value = TestAddress;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 修改注意事项
        /// </summary>
        /// <returns></returns>
        public bool JobMangeUpdatezhuyi(string proc, int JobMangeId, string zhuyi)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    com.Parameters.Add("@zhuyi", SqlDbType.Text).Value = zhuyi;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet JobMange_SelectByJobMangeId(string proc, int JobMangeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_Selects(string proc, string JobName, string SubjectName, string Culture, string Political, string Recruitment, string Gender, string Should, string Nation, string Degree, string Position, string Education, string Age, string Profession, string Sort)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobName", SqlDbType.VarChar,50).Value = JobName;
                    sda.SelectCommand.Parameters.Add("@SubjectName", SqlDbType.VarChar,50).Value = SubjectName;
                    sda.SelectCommand.Parameters.Add("@Culture", SqlDbType.VarChar,50).Value = Culture;
                    sda.SelectCommand.Parameters.Add("@Political", SqlDbType.VarChar,50).Value = Political;
                    sda.SelectCommand.Parameters.Add("@Recruitment", SqlDbType.VarChar,50).Value = Recruitment;
                    sda.SelectCommand.Parameters.Add("@Gender", SqlDbType.VarChar,50).Value = Gender;
                    sda.SelectCommand.Parameters.Add("@Should", SqlDbType.VarChar,50).Value = Should;
                    sda.SelectCommand.Parameters.Add("@Nation", SqlDbType.VarChar,50).Value = Nation;
                    sda.SelectCommand.Parameters.Add("@Degree", SqlDbType.VarChar,50).Value = Degree;
                    sda.SelectCommand.Parameters.Add("@Position", SqlDbType.VarChar,50).Value = Position;
                    sda.SelectCommand.Parameters.Add("@Education", SqlDbType.VarChar,50).Value = Education;
                    sda.SelectCommand.Parameters.Add("@Age", SqlDbType.VarChar,50).Value = Age;
                    sda.SelectCommand.Parameters.Add("@Profession", SqlDbType.VarChar,50).Value = Profession;
                    sda.SelectCommand.Parameters.Add("@Sort", SqlDbType.VarChar,50).Value = Sort;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 考试科目添加
        /// </summary>
        /// <returns></returns>
        public bool ExamInfoInsert(string proc, int JobMangeId,string ExamSubject,string ExamDate,string ExamTime)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value =  JobMangeId;
                    com.Parameters.Add("@ExamSubject", SqlDbType.VarChar, 50).Value = ExamSubject;
                    com.Parameters.Add("@ExamDate", SqlDbType.VarChar, 50).Value =ExamDate;
                    com.Parameters.Add("@ExamTime", SqlDbType.VarChar, 50).Value = ExamTime;                 
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 考试科目修改
        /// </summary>
        /// <returns></returns>
        public bool ExamInfoUpdate(string proc, int ExamInfoId, string ExamSubject, string ExamDate, string ExamTime)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExamInfoId", SqlDbType.Int).Value = ExamInfoId;
                    com.Parameters.Add("@ExamSubject", SqlDbType.VarChar, 50).Value = ExamSubject;
                    com.Parameters.Add("@ExamDate", SqlDbType.VarChar, 50).Value = ExamDate;
                    com.Parameters.Add("@ExamTime", SqlDbType.VarChar, 50).Value = ExamTime;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 考试科目删除
        /// </summary>
        /// <returns></returns>
        public bool ExamInfoDelete(string proc, int ExamInfoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExamInfoId", SqlDbType.Int).Value = ExamInfoId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        /// <summary>
        /// 岗位查询查询
        /// </summary>
        public DataSet JobMange_ksSelects(string proc, string JobName, string SubjectName, string Culture, string Political, string Recruitment, string Gender, string Should, string Nation, string Degree, string Position, string Education, string Age, string Profession, string Sort)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobName", SqlDbType.VarChar, 50).Value = JobName;
                    sda.SelectCommand.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50).Value = SubjectName;
                    sda.SelectCommand.Parameters.Add("@Culture", SqlDbType.VarChar, 50).Value = Culture;
                    sda.SelectCommand.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    sda.SelectCommand.Parameters.Add("@Recruitment", SqlDbType.VarChar, 50).Value = Recruitment;
                    sda.SelectCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    sda.SelectCommand.Parameters.Add("@Should", SqlDbType.VarChar, 50).Value = Should;
                    sda.SelectCommand.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    sda.SelectCommand.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    sda.SelectCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50).Value = Position;
                    sda.SelectCommand.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    sda.SelectCommand.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = Age;
                    sda.SelectCommand.Parameters.Add("@Profession", SqlDbType.VarChar, 50).Value = Profession;
                    sda.SelectCommand.Parameters.Add("@Sort", SqlDbType.VarChar, 50).Value = Sort;
                   // sda.SelectCommand.Parameters.Add("@Years", SqlDbType.VarChar, 50).Value = Years;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region 考生信息

        /// <summary>
        /// 考生信息修改
        /// </summary>
        /// <returns></returns>
        public bool CandidatesInfoUpdate(string proc, int CandidatesInfoId,string Number, byte[] Photo, string Email, string Name,
                                         string Gender, string Origin, string Nation, string Birthday, string CardID,
                                         string census, string Political, string Sources, string ContactPhone, string FamilyPhone,
                                         string OtherPhone, string FamilyAddress, string ZipCode, string Culture, string Degree,
                                         string Education, string Institutions, string ProfessionName, string GraduationData,
                                         string JobsData, string Expertise, string Resumes, string FamilyMember, string Performance,
                                         string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@CandidatesInfoId",SqlDbType.Int).Value = CandidatesInfoId;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    com.Parameters.Add("@Photo", SqlDbType.Image).Value = Photo;
                    com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    com.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Origin", SqlDbType.VarChar, 50).Value = Origin;
                    com.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    com.Parameters.Add("@Birthday", SqlDbType.VarChar, 50).Value = Birthday;
                    com.Parameters.Add("@CardID", SqlDbType.VarChar, 50).Value = CardID;
                    com.Parameters.Add("@census", SqlDbType.VarChar, 50).Value = census;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    com.Parameters.Add("@Sources", SqlDbType.VarChar, 50).Value = Sources;
                    com.Parameters.Add("@ContactPhone", SqlDbType.VarChar, 50).Value = ContactPhone;
                    com.Parameters.Add("@FamilyPhone", SqlDbType.VarChar, 50).Value = FamilyPhone;
                    com.Parameters.Add("@OtherPhone", SqlDbType.VarChar, 50).Value = OtherPhone;
                    com.Parameters.Add("@FamilyAddress", SqlDbType.VarChar, 50).Value = FamilyAddress;
                    com.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = ZipCode;
                    com.Parameters.Add("@Culture", SqlDbType.VarChar, 50).Value = Culture;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Institutions", SqlDbType.VarChar, 50).Value = Institutions;
                    com.Parameters.Add("@ProfessionName", SqlDbType.VarChar, 50).Value = ProfessionName;
                    com.Parameters.Add("@GraduationData", SqlDbType.VarChar, 50).Value = GraduationData;
                    com.Parameters.Add("@JobsData", SqlDbType.VarChar, 50).Value = JobsData;
                    com.Parameters.Add("@Expertise", SqlDbType.VarChar, 50).Value = Expertise;
                    com.Parameters.Add("@Resumes", SqlDbType.VarChar, 50).Value = Resumes;
                    com.Parameters.Add("@FamilyMember", SqlDbType.VarChar, 50).Value = FamilyMember;
                    com.Parameters.Add("@Performancet", SqlDbType.VarChar, 50).Value = Performance;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 考生信息单个查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByNumber(string proc, string Number)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Number", SqlDbType.VarChar,50).Value = Number;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 考生信息查询
        /// </summary>
        /// <returns></returns>
        public DataSet CandidatesInfo_Selects(string proc, string Number, string Name, string IdCard, string Phone, string Email, string Institutions, string ProfessionName, string Sort)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    sda.SelectCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    sda.SelectCommand.Parameters.Add("@IdCard", SqlDbType.VarChar, 50).Value = IdCard;
                    sda.SelectCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = Phone;
                    sda.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    sda.SelectCommand.Parameters.Add("@Institutions", SqlDbType.VarChar, 50).Value = Institutions;
                    sda.SelectCommand.Parameters.Add("@ProfessionName", SqlDbType.VarChar, 50).Value = ProfessionName;
                    sda.SelectCommand.Parameters.Add("@Sort", SqlDbType.VarChar, 50).Value = Sort;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        #region 考生登录
        /// <summary>
        /// 考生注册
        /// </summary>
        /// <returns></returns>
        public int RegisterdeInsert(string proc,string Number,string Name,string CardId,string Birthday,string Gender,string Email,string ContactPhone,string UserPwd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    com.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    com.Parameters.Add("@CardId", SqlDbType.VarChar, 50).Value = CardId;
                    com.Parameters.Add("@Birthday", SqlDbType.VarChar, 50).Value = Birthday;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    com.Parameters.Add("@ContactPhone", SqlDbType.VarChar, 50).Value = ContactPhone;
                    com.Parameters.Add("@Pwd", SqlDbType.VarChar, 50).Value = UserPwd;

                    SqlParameter isSuccess = new SqlParameter("@isSuccess", SqlDbType.Int);
                    isSuccess.Direction = ParameterDirection.Output;
                    com.Parameters.Add(isSuccess);

                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(isSuccess.Value);
                }
            }
            catch (Exception ex)
            {
                return 5;
            }
        }
        #endregion
        #region 考生个人信息添加
        /// <summary>
        /// 考生信息添加
        /// </summary>
        /// <returns></returns>
        public bool CandidatesInfoInsert(string proc, string Number, string Email, string Name,
                                         string Gender, string Origin, string Nation, string Birthday, string CardID,
                                         string census, string Political, string Sources, string ContactPhone, string FamilyPhone,
                                         string OtherPhone, string FamilyAddress, string ZipCode, string Culture, string Degree,
                                         string Education, string Marriage,string Institutions, string ProfessionName, string GraduationData,
                                         string JobsData, string Expertise, string Resumes, string FamilyMember, string Performance,
                                         string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    //com.Parameters.Add("@Photo", SqlDbType.Image).Value = Photo;
                    com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    com.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Origin", SqlDbType.VarChar, 50).Value = Origin;
                    com.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    com.Parameters.Add("@Birthday", SqlDbType.VarChar, 50).Value = Birthday;
                    com.Parameters.Add("@CardID", SqlDbType.VarChar, 50).Value = CardID;
                    com.Parameters.Add("@census", SqlDbType.VarChar, 50).Value = census;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    com.Parameters.Add("@Sources", SqlDbType.VarChar, 50).Value = Sources;
                    com.Parameters.Add("@ContactPhone", SqlDbType.VarChar, 50).Value = ContactPhone;
                    com.Parameters.Add("@FamilyPhone", SqlDbType.VarChar, 50).Value = FamilyPhone;
                    com.Parameters.Add("@OtherPhone", SqlDbType.VarChar, 50).Value = OtherPhone;
                    com.Parameters.Add("@FamilyAddress", SqlDbType.VarChar, 50).Value = FamilyAddress;
                    com.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = ZipCode;
                    com.Parameters.Add("@Culture", SqlDbType.VarChar, 50).Value = Culture;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Marriage", SqlDbType.VarChar, 50).Value = Marriage;
                    com.Parameters.Add("@Institutions", SqlDbType.VarChar, 50).Value = Institutions;
                    com.Parameters.Add("@ProfessionName", SqlDbType.VarChar, 50).Value = ProfessionName;
                    com.Parameters.Add("@GraduationData", SqlDbType.VarChar, 50).Value = GraduationData;
                    com.Parameters.Add("@JobsData", SqlDbType.VarChar, 50).Value = JobsData;
                    com.Parameters.Add("@Expertise", SqlDbType.VarChar, 50).Value = Expertise;
                    com.Parameters.Add("@Resumes", SqlDbType.VarChar, 50).Value = Resumes;
                    com.Parameters.Add("@FamilyMember", SqlDbType.VarChar, 50).Value = FamilyMember;
                    com.Parameters.Add("@Performanc", SqlDbType.VarChar, 50).Value = Performance;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region 考生照片添加
        /// <summary>
        /// 考生照片添加
        /// </summary>
        /// <returns></returns>
        public bool CandidatesInfoInsertByPhoto(string proc, string Number, byte[] imgbyte)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    com.Parameters.Add("@Photo", SqlDbType.Image).Value = imgbyte;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region 岗位信息申请
        #endregion
        /// <summary>
        /// 用户密码修改
        /// </summary>
        /// <returns></returns>
        public bool UserInfoPwdUpdate(string proc, string Number, string Pwd,string Pwd2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
                    com.Parameters.Add("@Pwd", SqlDbType.NVarChar, 160).Value = Pwd;
                    com.Parameters.Add("@Pwd2", SqlDbType.NVarChar, 160).Value = Pwd2;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户密码修改
        /// </summary>
        /// <returns></returns>
        public bool UserInfoUpdatePwd(string proc, string Number, string Pwd, string Pwd2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = Number;
                    com.Parameters.Add("@Pwd", SqlDbType.NVarChar, 160).Value = Pwd;
                    com.Parameters.Add("@Pwd2", SqlDbType.NVarChar, 160).Value = Pwd2;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 执行查询存储过程
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public DataSet select(string proc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
