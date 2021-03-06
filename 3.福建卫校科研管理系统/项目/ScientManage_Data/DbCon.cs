using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientManage_Data
{
    public class DbCon
    {
        protected static string conStr = ConfigurationManager.AppSettings["Scien_ConStr2"];
        #region 基础信息
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
                    cmd.Parameters.Add("@userPwd", SqlDbType.VarChar, 150).Value = userPwd;
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
        #region 日志查询
        /// <summary>
        /// 日志查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectJournal(string proc, string UserName, string Year, string Month, string Day, string Position, string Evens)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.VarChar, 50).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Day", SqlDbType.VarChar, 50).Value = Day;
                    sda.SelectCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50).Value = Position;
                    sda.SelectCommand.Parameters.Add("@Events", SqlDbType.VarChar, 50).Value = Evens;
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

        #endregion
        #region 按用户年份查询
        /// <summary>
        /// 按用户年份查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByApplyUserCardId(string proc, string UserCardId, int ApplyYearId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
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
        /// <summary>
        /// 按考核编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByAssessValueId(string proc, int AssessValueId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda.SelectCommand.Parameters.Add("@AssessValueId", SqlDbType.Int).Value = AssessValueId;
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
        /// <summary>
        /// 按用户年份查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsByApplyValue(string proc, string UserName, string DepartmentName, string ApplyYearName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentName;
                    sda.SelectCommand.Parameters.Add("@AssessYear", SqlDbType.VarChar, 50).Value = ApplyYearName;
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
        /// <summary>
        ///修改考核备注
        /// </summary>
        /// <returns>dataset</returns>
        /// 
        public bool AssessValueUpdate(string proc, int AssessValueId, string Remarks, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessValueId", SqlDbType.Int).Value = AssessValueId;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;

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
        #region
        /// <summary>
        /// 预留分值修改添加
        /// </summary>
        /// <returns></returns>
        public bool AssessValueUpdateReserve(string proc, int AssessValueId, double Reserve)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessValueId", SqlDbType.Int).Value = AssessValueId;
                    com.Parameters.Add("@NowReserve", SqlDbType.Float).Value = Reserve;
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
        #region 任职历程
        /// <summary>
        /// 任职历程信息添加
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeInsert(string proc, string UserCardId, string DepartmentName, string RoleName, string LevelName, string StartDate, string EndDate, string IsCurrent, string IsAgent)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@LevelName", SqlDbType.VarChar, 50).Value = LevelName;
                    com.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@IsCurrent", SqlDbType.VarChar, 50).Value = IsCurrent;
                    com.Parameters.Add("@IsAgent", SqlDbType.VarChar, 50).Value = IsAgent;
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
        /// 任职历程信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByUseOfficeId(string proc, int UseOfficeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UseOfficeId", SqlDbType.Int, 32).Value = UseOfficeId;
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
        /// 任职历程信息修改
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeUpdate(string proc, int UseOfficeId, string UserCardId, string DepartmentName, string RoleName, string LevelName, string StartDate, string EndDate, string IsCurrent, string IsAgent)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseOfficeId", SqlDbType.Int, 32).Value = UseOfficeId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@LevelName", SqlDbType.VarChar, 50).Value = LevelName;
                    com.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@IsCurrent", SqlDbType.VarChar, 50).Value = IsCurrent;
                    com.Parameters.Add("@IsAgent", SqlDbType.VarChar, 50).Value = IsAgent;
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
        /// 任职历程信息删除
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeDelete(string proc, int UseOfficeId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseOfficeId", SqlDbType.Int, 32).Value = UseOfficeId;
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

        #region 职称职级历程
        /// <summary>
        /// 职称职级历程信息添加
        /// </summary>
        /// <returns></returns>
        public bool UseJobPostInsert(string proc, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    com.Parameters.Add("@JobId", SqlDbType.VarChar, 50).Value = JobId;
                    com.Parameters.Add("@PostId", SqlDbType.VarChar, 50).Value = PostId;
                    com.Parameters.Add("@JobDate", SqlDbType.VarChar, 50).Value = JobDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@JobSeries", SqlDbType.VarChar, 50).Value = JobSeries;
                    com.Parameters.Add("@WorkLevel", SqlDbType.VarChar, 50).Value = WorkLevel;
                    com.Parameters.Add("@IsCurrent", SqlDbType.VarChar, 50).Value = IsCurrent;
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
        /// 职称职级历程信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet UseJobPostSelectByUseJobPostId(string proc, int UseJobPostId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UseJobPostId ", SqlDbType.Int, 32).Value = UseJobPostId;
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
        /// 职称职级历程信息修改
        /// </summary>
        /// <returns></returns>
        public bool UseJobPostUpdate(string proc, int UseJobPostId, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseJobPostId", SqlDbType.Int, 32).Value = UseJobPostId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    com.Parameters.Add("@JobId", SqlDbType.VarChar, 50).Value = JobId;
                    com.Parameters.Add("@PostId", SqlDbType.VarChar, 50).Value = PostId;
                    com.Parameters.Add("@JobDate", SqlDbType.VarChar, 50).Value = JobDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@JobSeries", SqlDbType.VarChar, 50).Value = JobSeries;
                    com.Parameters.Add("@WorkLevel", SqlDbType.VarChar, 50).Value = WorkLevel;
                    com.Parameters.Add("@IsCurrent", SqlDbType.VarChar, 50).Value = IsCurrent;
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
        /// 任职历程信息删除
        /// </summary>
        /// <returns></returns>
        public bool UseJobPostDelete(string proc, int UseJobPostId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseJobPostId", SqlDbType.Int, 32).Value = UseJobPostId;
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
        #region 行政职级历程
        /// <summary>
        /// 行政职级历程信息添加
        /// </summary>
        /// <returns></returns>
        public bool UseRemunerationInsert(string proc, string UserCardId, string RoleName, string Remuneration, string StartDate, string EndDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@Remuneration", SqlDbType.VarChar, 50).Value = Remuneration;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
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
        /// 行政职级历程信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet UseRemunerationSelectByUseRemunerationId(string proc, int UseRemunerationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UseRemunerationId ", SqlDbType.Int).Value = UseRemunerationId;
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
        /// 行政职级历程信息修改
        /// </summary>
        /// <returns></returns>
        public bool UseRemunerationUpdate(string proc, int UseRemunerationId, string UserCardId, string RoleName, string Remuneration, string StartDate, string EndDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseRemunerationId", SqlDbType.Int).Value = UseRemunerationId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@Remuneration", SqlDbType.VarChar, 50).Value = Remuneration;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
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
        /// 任职历程信息删除
        /// </summary>
        /// <returns></returns>
        public bool UseRemunerationDelete(string proc, int UseRemunerationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseRemunerationId", SqlDbType.Int).Value = UseRemunerationId;
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

        public bool UserEnableUpdate(string proc, string UserCardId, string UserEnable)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserEnable", SqlDbType.VarChar, 50).Value = UserEnable;
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
        public bool UserWorkValueUpdate(string proc, string UserCardId, string WorkValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserValue", SqlDbType.Float).Value = WorkValue;
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
        #region 职称
        /// <summary>
        /// 职称信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByJobId(string proc, int JobId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobId", SqlDbType.VarChar, 50).Value = JobId;
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
        ///<summary>
        ///职称职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int JobSum(string proc, int JobId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    SqlParameter JobSum = new SqlParameter("@JobSum", SqlDbType.Int);
                    JobSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(JobSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(JobSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 职称信息添加
        /// </summary>
        /// <returns></returns>
        public bool JobInsert(string proc, string JobName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobName", SqlDbType.VarChar, 50).Value = JobName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 职称信息修改
        /// </summary>
        /// <returns></returns>
        public bool JobUpdate(string proc, int JobId, string JobName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    com.Parameters.Add("@JobName", SqlDbType.VarChar, 50).Value = JobName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 职称信息删除
        /// </summary>
        /// <returns></returns>
        public bool JobDelete(string proc, int JobId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 职称信息删除
        /// </summary>
        /// <returns></returns>
        public bool ExpertResourcesDelete(string proc, int ExpertResourcesId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertResourcesId", SqlDbType.Int).Value = ExpertResourcesId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 专家资源库
        /// <summary>
        /// 专家资源信息添加
        /// </summary>
        /// <returns></returns>
        public bool ExpertResourcesInsert(string proc, string ExpertNumber, string ExpertName, string ExpertPassword, string SchoolOutside,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertNumber", SqlDbType.VarChar, 50).Value = ExpertNumber;
                    com.Parameters.Add("@ExpertName", SqlDbType.VarChar, 50).Value = ExpertName;
                    com.Parameters.Add("@ExpertPassword", SqlDbType.VarChar, 50).Value = ExpertPassword;
                    com.Parameters.Add("@SchoolOutside", SqlDbType.VarChar, 50).Value = SchoolOutside;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家资源信息修改
        /// </summary>
        /// <returns></returns>
        public bool ExpertResourcesUpdate(string proc, int ExpertResourcesId, string ExpertName, string ExpertPassword,string ExpertNumber, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertResourcesId", SqlDbType.Int).Value = ExpertResourcesId;
                    com.Parameters.Add("@ExpertName", SqlDbType.VarChar, 50).Value = ExpertName;
                    com.Parameters.Add("@ExpertPassword", SqlDbType.VarChar, 160).Value = ExpertPassword;

                    com.Parameters.Add("@ExpertNumber", SqlDbType.VarChar, 50).Value = ExpertNumber;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByExpertResourcesId(string proc, int ExpertResourcesId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ExpertResourcesId", SqlDbType.Int).Value = ExpertResourcesId;
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
        /// 按专家姓名信息查询
        /// </summary>
        /// <param name="userCardId">userCardId</param>
        /// <returns>dataset</returns>
        public DataSet SelectByExpertReviewName(string proc, string ExpertName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ExpertName", SqlDbType.VarChar, 50).Value = ExpertName;
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
        #endregion
        #region 专家评审组
        /// <summary>
        /// 专家评审组添加
        /// </summary>
        /// <returns></returns>
        public bool ExpertReviewInsert(string proc, string ExpertReviewName, string LeaderNumber,string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertReviewName", SqlDbType.VarChar, 50).Value = ExpertReviewName;
                    com.Parameters.Add("@LeaderNumber", SqlDbType.VarChar, 50).Value = LeaderNumber;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家评审组信息修改
        /// </summary>
        /// <returns></returns>
        public bool ExpertReviewUpdate(string proc, int ExpertReviewId, string ExpertReviewName, string LeaderNumber, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertReviewId", SqlDbType.Int).Value = ExpertReviewId;
                    com.Parameters.Add("@ExpertReviewName", SqlDbType.VarChar, 50).Value = ExpertReviewName;
                    com.Parameters.Add("@LeaderNumber", SqlDbType.VarChar, 50).Value = LeaderNumber;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家评审组信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByExpertReviewId(string proc, int ExpertReviewId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ExpertReviewId", SqlDbType.Int).Value = ExpertReviewId;
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
        /// 专家评审组信息删除
        /// </summary>
        /// <returns></returns>
        public bool ExpertReviewDelete(string proc, int ExpertReviewId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertReviewId", SqlDbType.Int).Value = ExpertReviewId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家评审组成员信息删除
        /// </summary>
        /// <returns></returns>
        public bool ExpertReviewMembersDelete(string proc, string ExpertReviewMembersId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertReviewMembersId", SqlDbType.VarChar,50).Value = ExpertReviewMembersId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专家评审组成员添加
        /// </summary>
        /// <returns></returns>
        public bool ExpertReviewMembersInsert(string proc,int ExpertReviewId,string ExpertNumber)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ExpertReviewId", SqlDbType.Int).Value = ExpertReviewId;
                    com.Parameters.Add("@ExpertNumber", SqlDbType.VarChar, 50).Value = ExpertNumber;
                  
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
        #region 职级
        /// <summary>
        /// 职级信息添加
        /// </summary>
        /// <returns></returns>
        public bool PostInsert(string proc, string PostName, string  PlanPeople,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostName", SqlDbType.VarChar, 50).Value = PostName;
                    com.Parameters.Add("@PlanPeople", SqlDbType.VarChar, 50).Value = PlanPeople;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 职级信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPostId(string proc, int PostId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
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
        /// 职称信息修改
        /// </summary>
        /// <returns></returns>
        public bool PostUpdate(string proc, int PostId, string PostName, string PlanPeople,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    com.Parameters.Add("@PostName", SqlDbType.VarChar, 50).Value = PostName;
                    com.Parameters.Add("@PlanPeople", SqlDbType.VarChar, 50).Value = PlanPeople;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///职级职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int PostSum(string proc, int PostId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    SqlParameter PostSum = new SqlParameter("@PostSum", SqlDbType.Int);
                    PostSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(PostSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(PostSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 职级信息删除
        /// </summary>
        /// <returns></returns>
        public bool PostDelete(string proc, int PostId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 职务
        /// <summary>
        /// 职务信息添加
        /// </summary>
        /// <returns></returns>
        public bool RoleInsert(string proc, string RoleName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;

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
        /// 职务信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRoleId(string proc, int RoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
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
        /// 职务信息修改
        /// </summary>
        /// <returns></returns>
        public bool RoleUpdate(string proc, int RoleId, string RoleName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int RoleSum(string proc, int RoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    SqlParameter RoleSum = new SqlParameter("@RoleSum", SqlDbType.Int);
                    RoleSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(RoleSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(RoleSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 职务信息删除
        /// </summary>
        /// <returns></returns>
        public bool RoleDelete(string proc, int RoleId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 学位
        /// <summary>
        /// 学位信息添加
        /// </summary>
        /// <returns></returns>
        public bool DegreeInsert(string proc, string DegreeName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DegreeName", SqlDbType.VarChar, 50).Value = DegreeName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 学位信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByDegreeId(string proc, int DegreeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@DegreeId", SqlDbType.Int).Value = DegreeId;
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
        /// 学位信息修改
        /// </summary>
        /// <returns></returns>
        public bool DegreeUpdate(string proc, int DegreeId, string DegreeName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DegreeId", SqlDbType.Int).Value = DegreeId;
                    com.Parameters.Add("@DegreeName", SqlDbType.VarChar, 50).Value = DegreeName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///学位职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int DegreeSum(string proc, int DegreeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DegreeId", SqlDbType.Int).Value = DegreeId;
                    SqlParameter DegreeSum = new SqlParameter("@DegreeSum", SqlDbType.Int);
                    DegreeSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(DegreeSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(DegreeSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 学位信息删除
        /// </summary>
        /// <returns></returns>
        public bool DegreeDelete(string proc, int DegreeId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DegreeId", SqlDbType.Int).Value = DegreeId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 学历
        /// <summary>
        /// 学历信息添加
        /// </summary>
        /// <returns></returns>
        public bool EducationInsert(string proc, string EducationName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationName", SqlDbType.VarChar, 50).Value = EducationName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 学历信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByEducationId(string proc, int EducationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
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
        /// 学历信息修改
        /// </summary>
        /// <returns></returns>
        public bool EducationUpdate(string proc, int EducationId, string EducationName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    com.Parameters.Add("@EducationName", SqlDbType.VarChar, 50).Value = EducationName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///学历职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int EducationSum(string proc, int EducationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    SqlParameter EducationSum = new SqlParameter("@EducationSum", SqlDbType.Int);
                    EducationSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(EducationSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(EducationSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 学历信息删除
        /// </summary>
        /// <returns></returns>
        public bool EducationDelete(string proc, int EducationId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 状态
        /// <summary>
        /// 状态信息添加
        /// </summary>
        /// <returns></returns>
        public bool StatusInsert(string proc, string StatusName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StatusName", SqlDbType.VarChar, 50).Value = StatusName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 状态信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByStatusId(string proc, int StatusId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@StatusId", SqlDbType.Int).Value = StatusId;
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
        /// 状态信息修改
        /// </summary>
        /// <returns></returns>
        public bool StatusUpdate(string proc, int StatusId, string StatusName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StatusId", SqlDbType.Int).Value = StatusId;
                    com.Parameters.Add("@StatusName", SqlDbType.VarChar, 50).Value = StatusName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///状态职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int StatusSum(string proc, int StatusId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = StatusId;
                    SqlParameter StatusSum = new SqlParameter("@StatusSum", SqlDbType.Int);
                    StatusSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(StatusSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 状态信息删除
        /// </summary>
        /// <returns></returns>
        public bool StatusDelete(string proc, int StatusId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StatusId", SqlDbType.Int).Value = StatusId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 民族
        /// <summary>
        /// 民族信息添加
        /// </summary>
        /// <returns></returns>
        public bool NationInsert(string proc, string NationName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@NationName", SqlDbType.VarChar, 50).Value = NationName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 民族信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByNationId(string proc, int NationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@NationId", SqlDbType.Int).Value = NationId;
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
        /// 民族信息修改
        /// </summary>
        /// <returns></returns>
        public bool NationUpdate(string proc, int NationId, string NationName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@NationId", SqlDbType.Int).Value = NationId;
                    com.Parameters.Add("@NationName", SqlDbType.VarChar, 50).Value = NationName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///民族职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int NationSum(string proc, int NationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NationId", SqlDbType.Int).Value = NationId;
                    SqlParameter NationSum = new SqlParameter("@NationSum", SqlDbType.Int);
                    NationSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(NationSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(NationSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 民族信息删除
        /// </summary>
        /// <returns></returns>
        public bool NationDelete(string proc, int NationId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@NationId", SqlDbType.Int).Value = NationId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 政治面貌
        /// <summary>
        /// 政治面貌信息添加
        /// </summary>
        /// <returns></returns>
        public bool PoliticalInsert(string proc, string PoliticalName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PoliticalName", SqlDbType.VarChar, 50).Value = PoliticalName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 政治面貌信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPoliticalId(string proc, int PoliticalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PoliticalId", SqlDbType.Int).Value = PoliticalId;
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
        /// 政治面貌信息修改
        /// </summary>
        /// <returns></returns>
        public bool PoliticalUpdate(string proc, int PoliticalId, string PoliticalName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PoliticalId", SqlDbType.Int).Value = PoliticalId;
                    com.Parameters.Add("@PoliticalName", SqlDbType.VarChar, 50).Value = PoliticalName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///政治面貌职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int PoliticalSum(string proc, int PoliticalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PoliticalId", SqlDbType.Int).Value = PoliticalId;
                    SqlParameter PoliticalSum = new SqlParameter("@PoliticalSum", SqlDbType.Int);
                    PoliticalSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(PoliticalSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(PoliticalSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 政治面貌信息删除
        /// </summary>
        /// <returns></returns>
        public bool PoliticalDelete(string proc, int PoliticalId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PoliticalId", SqlDbType.Int).Value = PoliticalId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 目录
        /// <summary>
        /// 按上级目录查询
        /// </summary>
        /// <returns></returns>
        public DataSet ModelSelect(string proc, int ModelId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ModelFatherId", SqlDbType.Int).Value = ModelId;
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
        ///<summary>
        ///子目录数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int ModelSum(string proc, int ModelId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ModelId", SqlDbType.Int).Value = ModelId;
                    SqlParameter ModelSum = new SqlParameter("@ModelSum", SqlDbType.Int);
                    ModelSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ModelSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(ModelSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 目录信息删除
        /// </summary>
        /// <returns></returns>
        public bool ModelDelete(string proc, int ModelId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ModelId", SqlDbType.Int).Value = ModelId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 目录信息添加
        /// </summary>
        /// <returns></returns>
        public bool ModelInsert(string proc, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, string UserCardId, int ModelNum)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ModelName", SqlDbType.VarChar, 50).Value = ModelName;
                    com.Parameters.Add("@ModelUrl", SqlDbType.VarChar, 50).Value = ModelUrl;
                    com.Parameters.Add("@ModelFatherId", SqlDbType.Int).Value = FatherModelId;
                    com.Parameters.Add("@ModelNum", SqlDbType.Int).Value = ModelNum;
                    com.Parameters.Add("@ModelFatherName", SqlDbType.VarChar, 50).Value = FatherModelName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 目录信息修改
        /// </summary>
        /// <returns></returns>
        public bool ModelUpdate(string proc, int ModelId, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, string UserCardId, int ModelNum)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ModelId", SqlDbType.Int).Value = ModelId;
                    com.Parameters.Add("@ModelName", SqlDbType.VarChar, 50).Value = ModelName;
                    com.Parameters.Add("@ModelUrl", SqlDbType.VarChar, 50).Value = ModelUrl;
                    com.Parameters.Add("@ModelFatherId", SqlDbType.Int).Value = FatherModelId;
                    com.Parameters.Add("@ModelNum", SqlDbType.Int).Value = ModelNum;
                    com.Parameters.Add("@ModelFatherName", SqlDbType.VarChar, 50).Value = FatherModelName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 目录信息查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByModelId(string proc, int ModelId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ModelId", SqlDbType.Int).Value = ModelId;
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
        #region 资金项目
        /// <summary>
        /// 资金项目信息添加
        /// </summary>
        /// <returns></returns>
        public bool CapitalItemInsert(string proc, string CapitalItemName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@CapitalItemName", SqlDbType.VarChar, 50).Value = CapitalItemName;
                     com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 资金项目信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByCapitalItemId(string proc, int CapitalItemId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
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
        /// 资金项目信息修改
        /// </summary>
        /// <returns></returns>
        public bool CapitalItemUpdate(string proc, int CapitalItemId, string CapitalItemName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@CapitalItemName", SqlDbType.VarChar, 50).Value = CapitalItemName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 资金项目信息删除
        /// </summary>
        /// <returns></returns>
        public bool CapitalItemDelete(string proc, int CapitalItemId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
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
        #region 申报时间
        /// <summary>
        /// 申报时间信息添加
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearInsert(string proc, string StartDate, string EndDate,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 申报时间信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByApplyYearId(string proc, int ApplyYearId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
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
        /// 申报时间信息修改
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearUpdate(string proc, int ApplyYearId, string StartDate, string EndDate,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 申报时间信息删除
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearDelete(string proc, int ApplyYearId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 考核等级
        /// <summary>
        /// 考核等级信息添加
        /// </summary>
        /// <returns></returns>
        public bool AssessRankInsert(string proc, string RankName, double MinValue, double MaxValue, string RankExplain,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RankName", SqlDbType.VarChar, 50).Value = RankName;
                    com.Parameters.Add("@RankMinValue", SqlDbType.Float, 500).Value = MinValue;
                    com.Parameters.Add("@RankMaxValue", SqlDbType.Float, 500).Value = MaxValue;
                    com.Parameters.Add("@RankExplain", SqlDbType.VarChar, 100).Value = RankExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;

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
        /// 考核等级信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByAssessRankId(string proc, int AssessRankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AssessRankId", SqlDbType.Int).Value = AssessRankId;
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
        /// 考核等级信息修改
        /// </summary>
        /// <returns></returns>
        public bool AssessRankUpdate(string proc, int AssessRankId, string RankName, double MinValue, double MaxValue, string RankExplain,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessRankId", SqlDbType.Int).Value = AssessRankId;
                    com.Parameters.Add("@RankName", SqlDbType.VarChar, 50).Value = RankName;
                    com.Parameters.Add("@RankMinValue", SqlDbType.Float, 500).Value = MinValue;
                    com.Parameters.Add("@RankMaxValue", SqlDbType.Float, 500).Value = MaxValue;
                    com.Parameters.Add("@RankExplain", SqlDbType.VarChar, 100).Value = RankExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 考核等级信息删除
        /// </summary>
        /// <returns></returns>
        public bool AssessRankDelete(string proc, int AssessRankId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessRankId", SqlDbType.Int).Value = AssessRankId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 部门
        /// <summary>
        /// 部门信息添加
        /// </summary>
        /// <returns></returns>
        public bool DepartmentInsert(string proc, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                   
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 部门信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByDepartmentId(string proc, int DepartmentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
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
        /// <summary>
        /// 部门信息修改
        /// </summary>
        /// <returns></returns>
        public bool DepartmentUpdate(string proc, int DepartmentId, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///部门职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int DepartmentSum(string proc, int DepartmentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    SqlParameter DepartmentSum = new SqlParameter("@DepartmentSum", SqlDbType.Int);
                    DepartmentSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(DepartmentSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(DepartmentSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 部门信息删除
        /// </summary>
        /// <returns></returns>
        public bool DepartmentDelete(string proc, int DepartmentId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 角色
        /// <summary>
        /// 角色信息添加
        /// </summary>
        /// <returns></returns>
        public bool RankInsert(string proc, string RankName, string UserCardId, string RBL1,string RBL2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RankName", SqlDbType.VarChar, 50).Value = RankName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RBL", SqlDbType.VarChar, 50).Value = RBL1;
                    com.Parameters.Add("@RBL2", SqlDbType.VarChar, 50).Value = RBL2;
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
        /// 角色信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRankId(string proc, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 角色信息修改
        /// </summary>
        /// <returns></returns>
        public bool RankUpdate(string proc, int RankId, string RankName,string UserCardId,string RBL1,string RBL2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
                    com.Parameters.Add("@RankName", SqlDbType.VarChar, 50).Value = RankName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RBL", SqlDbType.VarChar, 50).Value = RBL1;
                    com.Parameters.Add("@RBL2", SqlDbType.VarChar, 50).Value = RBL2;
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
        ///<summary>
        ///角色职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int RankSum(string proc, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
                    SqlParameter RankSum = new SqlParameter("@RankSum", SqlDbType.Int);
                    RankSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(RankSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(RankSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 角色信息删除
        /// </summary>
        /// <returns></returns>
        public bool RankDelete(string proc, int RankId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 用户角色信息添加
        /// </summary>
        /// <returns></returns>
        public bool UserRankInsert(string proc, string UserCardId, int RankId,string UserCardId2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        #region  行政系列
        /// <summary>
        /// 行政系列添加
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesName"></param>
        /// <returns></returns>
        public bool AdminSeriesInsert(string proc, string AdminSeriesName,string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminSeriesName", SqlDbType.VarChar, 50).Value = AdminSeriesName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 行政系列修改
        /// </summary>
      
        /// <returns></returns>
        public bool AdminSeriesUpdate(string proc, int AdminSeriesId, string AdminSeriesName,string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminSeriesId", SqlDbType.Int).Value = AdminSeriesId;
                    com.Parameters.Add("@AdminSeriesName", SqlDbType.VarChar, 50).Value = AdminSeriesName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 行政系列删除
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesId"></param>
        /// <returns></returns>
        public bool AdminSeriesDelete(string proc, int AdminSeriesId,string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminSeriesId", SqlDbType.Int).Value = AdminSeriesId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 按行政系列编号查询
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesId"></param>
        /// <returns></returns>
        public DataSet SelectByAdminSeriesId(string proc, int AdminSeriesId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AdminSeriesId", SqlDbType.Int).Value = AdminSeriesId;
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
        #region 用户
        ///<summary>
        ///用户数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int UserSum(string proc, string UserCardId, string UserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {


                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    int y = result.Tables[0].Rows.Count;
                    return y;



                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 用户信息查询
        /// </summary>
        /// <returns></returns>
        public DataSet UserInfoSelect(string proc, string UserName,string DepartmentId,  string StatusId, string StartYear, string EndYear, string Gender, string PoliticalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@StatusId", SqlDbType.VarChar, 50).Value = StatusId;
                    sda.SelectCommand.Parameters.Add("@StartYear", SqlDbType.VarChar, 50).Value = StartYear;
                    sda.SelectCommand.Parameters.Add("@EndYear", SqlDbType.VarChar, 50).Value = EndYear;
                    sda.SelectCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 4).Value = Gender;
                    sda.SelectCommand.Parameters.Add("@PoliticalId", SqlDbType.VarChar, 50).Value = PoliticalId;
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
        /// 个人密码修改
        /// </summary>
        /// <returns></returns>
        public bool UserPwdUpdate(string proc, string UserCardId, string OldPwd, string NewPwd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@OldUserPwd", SqlDbType.VarChar, 160).Value = OldPwd;
                    com.Parameters.Add("@NewUserPwd", SqlDbType.VarChar, 160).Value = NewPwd;
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
        public bool UserInfoPwdUpdate(string proc, string UserCardId, string UserIdCard, string NewPwd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserIdCard", SqlDbType.VarChar, 50).Value = UserIdCard;
                    com.Parameters.Add("@NewUserPwd", SqlDbType.VarChar, 160).Value = NewPwd;
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
        /// 用户信息添加
        /// </summary>
        /// <returns></returns>
        public bool UserInfoInsert(string proc, string UserCardId, string UserPwd, string UserSource, string UserName, string UserCardId2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserPwd", SqlDbType.VarChar, 160).Value = UserPwd;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserSource", SqlDbType.VarChar,50).Value = UserSource;                 
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
                   
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
      /// 按用户工号删除
      /// </summary>
      /// <param name="proc"></param>
      /// <param name="UserCardId"></param>
      /// <returns></returns>
        public bool DeleteByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
      /// 用户行政系列分配
      /// </summary>
      /// <param name="proc"></param>
      /// <param name="UserCardId"></param>
      /// <param name="AdminSeriesId"></param>
      /// <returns></returns>
        public bool UserAdminSeriesInsert(string proc, string UserCardId, int AdminSeriesId,string UserCardId2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AdminSeriesId", SqlDbType.Int).Value = AdminSeriesId;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        /// 按用户工号信息查询
        /// </summary>
        /// <param name="userCardId">userCardId</param>
        /// <returns>dataset</returns>
        public DataSet SelectByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// <summary>
        /// 按用户姓名信息查询
        /// </summary>
        /// <param name="userCardId">userCardId</param>
        /// <returns>dataset</returns>
        public DataSet SelectByUserName(string proc, string UserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
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
        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserInfoUpdate(string proc, string UserCardId, string UserName, string UserGender, string IdCardNo,
            string NationName, string PoliticalName, string PartyDate, string TakeWorkDate, string EntryDate, string Origin, string Address,
            string StatusName, string GL_Management, string GL_CadreLevelName, string GL_RoleName, string GL_DepartmentName, string GL_StartDate,
            string GL_ManagerLevelName, string ZY_SkillTitle, string ZY_JobSeries, string ZY_TitleLevelName, string ZY_SpecialSkills, string ZY_DepartmentName,
            string ZY_StartDate, string JS_TeachersSeries, string JS_TeacherCategory, string JS_CertificateDate, string JS_MajorLeading, string JS_BoneTeacher,
            string JS_DoubleTeacher, string GQ_WorkersPeople, string GQ_PostName, string GQ_Appointment, string GQ_StartDate, string GQ_DepartmentName, string DYXL_Name,
            string DYXL_Date, string DYXL_School, string DYXL_Profession, string ZGXL_Name, string ZGXL_Date, string ZGXL_School, string ZGXL_Profession,
            string DYXW_Name, string DYXW_Date, string DYXW_School, string DYXW_Profession, string ZGXW_Name, string ZGXW_Date,
            string ZGXW_School, string ZGXW_Profession)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserGender", SqlDbType.VarChar, 10).Value = UserGender;
                    com.Parameters.Add("@IdCardNo", SqlDbType.VarChar, 50).Value = IdCardNo;
                    com.Parameters.Add("@NationName", SqlDbType.VarChar, 50).Value = NationName;
                    com.Parameters.Add("@PoliticalName", SqlDbType.VarChar, 50).Value = PoliticalName;
                    com.Parameters.Add("@PartyDate", SqlDbType.VarChar, 50).Value = PartyDate;
                    com.Parameters.Add("@TakeWorkDate", SqlDbType.VarChar, 50).Value = TakeWorkDate;
                    com.Parameters.Add("@EntryDate", SqlDbType.VarChar, 50).Value = EntryDate;
                    com.Parameters.Add("@Origin", SqlDbType.VarChar, 100).Value = Origin;
                    com.Parameters.Add("@Address", SqlDbType.VarChar, 200).Value = Address;
                    com.Parameters.Add("@StatusName", SqlDbType.VarChar, 50).Value = StatusName;
                    com.Parameters.Add("@GL_Management", SqlDbType.VarChar, 10).Value = GL_Management;
                    com.Parameters.Add("@GL_CadreLevelName", SqlDbType.VarChar, 50).Value = GL_CadreLevelName;
                    com.Parameters.Add("@GL_RoleName", SqlDbType.VarChar, 50).Value = GL_RoleName;
                    com.Parameters.Add("@GL_DepartmentName", SqlDbType.VarChar, 50).Value = GL_DepartmentName;
                    com.Parameters.Add("@GL_StartDate", SqlDbType.VarChar, 50).Value = GL_StartDate;
                    com.Parameters.Add("@GL_ManagerLevelName", SqlDbType.VarChar, 50).Value = GL_ManagerLevelName;
                    com.Parameters.Add("@ZY_SkillTitle", SqlDbType.VarChar, 50).Value = ZY_SkillTitle;
                    com.Parameters.Add("@ZY_JobSeries", SqlDbType.VarChar, 50).Value = ZY_JobSeries;
                    com.Parameters.Add("@ZY_TitleLevelName", SqlDbType.VarChar, 50).Value = ZY_TitleLevelName;
                    com.Parameters.Add("@ZY_SpecialSkills", SqlDbType.VarChar, 50).Value = ZY_SpecialSkills;
                    com.Parameters.Add("@ZY_DepartmentName", SqlDbType.VarChar, 50).Value = ZY_DepartmentName;
                    com.Parameters.Add("@ZY_StartDate", SqlDbType.VarChar, 50).Value = ZY_StartDate;
                    com.Parameters.Add("@JS_TeachersSeries", SqlDbType.VarChar, 10).Value = JS_TeachersSeries;
                    com.Parameters.Add("@JS_TeacherCategory", SqlDbType.VarChar, 50).Value = JS_TeacherCategory;
                    com.Parameters.Add("@JS_CertificateDate", SqlDbType.VarChar, 50).Value = JS_CertificateDate;
                    com.Parameters.Add("@JS_MajorLeading", SqlDbType.VarChar, 50).Value = JS_MajorLeading;
                    com.Parameters.Add("@JS_BoneTeacher", SqlDbType.VarChar, 50).Value = JS_BoneTeacher;
                    com.Parameters.Add("@JS_DoubleTeacher", SqlDbType.VarChar, 50).Value = JS_DoubleTeacher;
                    com.Parameters.Add("@GQ_WorkersPeople", SqlDbType.VarChar, 50).Value = GQ_WorkersPeople;
                    com.Parameters.Add("@GQ_PostName", SqlDbType.VarChar, 50).Value = GQ_PostName;
                    com.Parameters.Add("@GQ_Appointment", SqlDbType.VarChar, 50).Value = GQ_Appointment;
                    com.Parameters.Add("@GQ_StartDate", SqlDbType.VarChar, 50).Value = GQ_StartDate;
                    com.Parameters.Add("@GQ_DepartmentName", SqlDbType.VarChar, 50).Value = GQ_DepartmentName;
                    com.Parameters.Add("@DYXL_Name", SqlDbType.VarChar, 50).Value = DYXL_Name;
                    com.Parameters.Add("@DYXL_Date", SqlDbType.VarChar, 50).Value = DYXL_Date;
                    com.Parameters.Add("@DYXL_School", SqlDbType.VarChar, 100).Value = DYXL_School;
                    com.Parameters.Add("@DYXL_Profession", SqlDbType.VarChar, 50).Value = DYXL_Profession;
                    com.Parameters.Add("@ZGXL_Name", SqlDbType.VarChar, 50).Value = ZGXL_Name;
                    com.Parameters.Add("@ZGXL_Date", SqlDbType.VarChar, 50).Value = ZGXL_Date;
                    com.Parameters.Add("@ZGXL_School", SqlDbType.VarChar, 100).Value = ZGXL_School;
                    com.Parameters.Add("@ZGXL_Profession", SqlDbType.VarChar, 50).Value = ZGXL_Profession;
                    com.Parameters.Add("@DYXW_Name", SqlDbType.VarChar, 50).Value = DYXW_Name;
                    com.Parameters.Add("@DYXW_Date", SqlDbType.VarChar, 50).Value = DYXW_Date;
                    com.Parameters.Add("@DYXW_School", SqlDbType.VarChar, 100).Value = DYXW_School;
                    com.Parameters.Add("@DYXW_Profession", SqlDbType.VarChar, 50).Value = DYXW_Profession;
                    com.Parameters.Add("@ZGXW_Name", SqlDbType.VarChar, 50).Value = ZGXW_Name;
                    com.Parameters.Add("@ZGXW_Date", SqlDbType.VarChar, 50).Value = ZGXW_Date;
                    com.Parameters.Add("@ZGXW_School", SqlDbType.VarChar, 100).Value = ZGXW_School;
                    com.Parameters.Add("@ZGXW_Profession", SqlDbType.VarChar, 50).Value = ZGXW_Profession;

                    // com.Parameters.Add("@myimage", SqlDbType.Image).Value = imgbyte;
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
        /// 用户学历信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserEducationSave(string proc, string UserCardId, int FirstEducationId, string FirstDate, string FirstSchool, string FirstProfession, int HighestEducationId, string HighestDate, string HighestSchool, string HighestProfession)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FirstEducationId", SqlDbType.Int).Value = FirstEducationId;
                    com.Parameters.Add("@FirstDate", SqlDbType.VarChar, 50).Value = FirstDate;
                    com.Parameters.Add("@FirstSchool", SqlDbType.VarChar, 50).Value = FirstSchool;
                    com.Parameters.Add("@FirstProfession", SqlDbType.VarChar, 50).Value = FirstProfession;
                    com.Parameters.Add("@HighestEducationId", SqlDbType.Int).Value = HighestEducationId;
                    com.Parameters.Add("@HighestDate", SqlDbType.VarChar, 50).Value = HighestDate;
                    com.Parameters.Add("@HighestSchool", SqlDbType.VarChar, 50).Value = HighestSchool;
                    com.Parameters.Add("@HighestProfession", SqlDbType.VarChar, 50).Value = HighestProfession;
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
        /// 用户学位信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserDegreeSave(string proc, string UserCardId, int FirstDegreeId, string FirstDate, string FirstSchool, string FirstProfession, int HighestDegreeId, string HighestDate, string HighestSchool, string HighestProfession)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FirstDegreeId", SqlDbType.Int).Value = FirstDegreeId;
                    com.Parameters.Add("@FirstDate", SqlDbType.VarChar, 50).Value = FirstDate;
                    com.Parameters.Add("@FirstSchool", SqlDbType.VarChar, 50).Value = FirstSchool;
                    com.Parameters.Add("@FirstProfession", SqlDbType.VarChar, 50).Value = FirstProfession;
                    com.Parameters.Add("@HighestDegreeId", SqlDbType.Int).Value = HighestDegreeId;
                    com.Parameters.Add("@HighestDate", SqlDbType.VarChar, 50).Value = HighestDate;
                    com.Parameters.Add("@HighestSchool", SqlDbType.VarChar, 50).Value = HighestSchool;
                    com.Parameters.Add("@HighestProfession", SqlDbType.VarChar, 50).Value = HighestProfession;
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
        /// 邮箱信息修改
        /// </summary>
        /// <returns></returns>
        public bool EmailUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3,string UserCardId2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardIdId;
                    com.Parameters.Add("@IndividuaNumber", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@WorkNumber", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        /// 电话信息修改
        /// </summary>
        /// <returns></returns>
        public bool PhoneUpdate(string proc, string UserCardId, string Number1, string Number2, string Number3,string UserCardId2)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@WorkNumber", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        #region 用户证书添加
        /// <summary>
        /// 证书添加
        /// </summary>
        /// <returns></returns>
        public bool UserEducationInsertByPhotodyxl(string proc, string UserCardId, byte[] imgbyte)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@myimage", SqlDbType.Image).Value = imgbyte;
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
        #endregion
        #region 用户职务
        /// <summary>
        /// 用户职务信息添加
        /// </summary>    
        /// <returns></returns>
        public bool UserRoleInsert(string proc, string UserCardId, int DepartmentId, int RoleId,string UserCardId2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        /// 用户职务信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserRoleUpdate(string proc, int UserRoleId, int DepartmentId, int RoleId,string UserCardId2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@UserCardId2", SqlDbType.VarChar, 50).Value = UserCardId2;
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
        /// 用户职务信息删除
        /// </summary>
        public bool UserRoleDelete(string proc, int UserRoleId,string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 用户职务信息单个查询
        /// </summary>
        public DataSet UserRoleSelect(string proc, int UserRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
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
        #region 项目来源
        /// <summary>
        /// 项目来源信息添加
        /// </summary>
        /// <returns></returns>
        public bool ProjectsFromInsert(string proc, string ProjectsFromExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsFromExplain", SqlDbType.VarChar, 50).Value = ProjectsFromExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目来源信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByProjectsFromId(string proc, int ProjectsFromId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
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
        /// 项目来源信息修改
        /// </summary>
        /// <returns></returns>
        public bool ProjectsFromUpdate(string proc, int ProjectsFromId, string ProjectsFromExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
                    com.Parameters.Add("@ProjectsFromExplain", SqlDbType.VarChar, 50).Value = ProjectsFromExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///项目来源职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int ProjectsFromSum(string proc, int ProjectsFromId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
                    SqlParameter ProjectsFromSum = new SqlParameter("@ProjectsFromSum", SqlDbType.Int);
                    ProjectsFromSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ProjectsFromSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(ProjectsFromSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 项目来源信息删除
        /// </summary>
        /// <returns></returns>
        public bool ProjectsFromDelete(string proc, int ProjectsFromId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 项目级别
        /// <summary>
        /// 项目级别信息添加
        /// </summary>
        /// <returns></returns>
        public bool ProjectsLevelInsert(string proc, string ProjectsLevelExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsLevelExplain", SqlDbType.VarChar, 50).Value = ProjectsLevelExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目级别信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByProjectsLevelId(string proc, int ProjectsLevelId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
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
        /// 项目级别信息修改
        /// </summary>
        /// <returns></returns>
        public bool ProjectsLevelUpdate(string proc, int ProjectsLevelId, string ProjectsLevelExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
                    com.Parameters.Add("@ProjectsLevelExplain", SqlDbType.VarChar, 50).Value = ProjectsLevelExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///项目级别职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int ProjectsLevelSum(string proc, int ProjectsLevelId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
                    SqlParameter ProjectsLevelSum = new SqlParameter("@ProjectsLevelSum", SqlDbType.Int);
                    ProjectsLevelSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ProjectsLevelSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(ProjectsLevelSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 项目级别信息删除
        /// </summary>
        /// <returns></returns>
        public bool ProjectsLevelDelete(string proc, int ProjectsLevelId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 项目类别
        /// <summary>
        /// 项目类别信息添加
        /// </summary>
        /// <returns></returns>
        public bool ProjectsSubjectInsert(string proc, string ProjectsSubjectExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsSubjectExplain", SqlDbType.VarChar, 50).Value = ProjectsSubjectExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目类别信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByProjectsSubjectId(string proc, int ProjectsSubjectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
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
        /// 项目类别信息修改
        /// </summary>
        /// <returns></returns>
        public bool ProjectsSubjectUpdate(string proc, int ProjectsSubjectId, string ProjectsSubjectExplain, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
                    com.Parameters.Add("@ProjectsSubjectExplain", SqlDbType.VarChar, 50).Value = ProjectsSubjectExplain;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        ///<summary>
        ///项目类别职务数量查询
        ///</summary>
        ///<returns>数量</returns>
        public int ProjectsSubjectSum(string proc, int ProjectsSubjectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
                    SqlParameter ProjectsSubjectSum = new SqlParameter("@ProjectsSubjectSum", SqlDbType.Int);
                    ProjectsSubjectSum.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ProjectsSubjectSum);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    return Convert.ToInt32(ProjectsSubjectSum.Value);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        /// <summary>
        /// 项目类别信息删除
        /// </summary>
        /// <returns></returns>
        public bool ProjectsSubjectDelete(string proc, int ProjectsSubjectId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #region 项目模板
        /// <summary>
        /// 项目模板信息添加
        /// </summary>
        /// <returns></returns>
        public bool ProjectsTemplateInsert(string proc, string Category, string TemplateName, string FileUrl, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@TemplateName", SqlDbType.VarChar, 50).Value = TemplateName;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目模板信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByProjectsTemplateId(string proc, int TemplateId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TemplateId", SqlDbType.Int).Value = TemplateId;
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
        /// 项目模板按项目类别查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByProjectsTemplateCategory(string proc, string Category)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
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
        /// 项目模板信息修改
        /// </summary>
        /// <returns></returns>
        public bool ProjectsTemplateUpdate(string proc, int TemplateId, string Category, string TemplateName, string FileUrl, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TemplateId", SqlDbType.Int).Value = TemplateId;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@TemplateName", SqlDbType.VarChar, 50).Value = TemplateName;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目模板信息删除
        /// </summary>
        /// <returns></returns>
        public bool ProjectsTemplateDelete(string proc, int TemplateId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TemplateId", SqlDbType.Int).Value = TemplateId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        #endregion
        #region 科研工作量
        #region 获奖
        /// <summary>
        /// 获奖申请
        /// </summary>
        /// <returns></returns>
        public bool WinningInsert(string proc, string UserCardId, int DepartmentId, string WinningName, string WinningCategory, string WinningLevel,  double WinningValue, int PartnerRank, double PartnerValue,string Remarks,string WinningUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@WinningName", SqlDbType.VarChar, 200).Value = WinningName;
                    com.Parameters.Add("@WinningCategory", SqlDbType.VarChar, 50).Value = WinningCategory;
                    com.Parameters.Add("@WinningLevel", SqlDbType.VarChar, 50).Value = WinningLevel;                  
                    com.Parameters.Add("@WinningValue", SqlDbType.Float, 500).Value = WinningValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@WinningUrl", SqlDbType.Text).Value = WinningUrl;
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
        /// 竞赛获奖可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet ExamineSelectUser(string proc, string UserCardId, int RankId, string text)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
                    sda.SelectCommand.Parameters.Add("@Text", SqlDbType.VarChar, 50).Value = text;
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
        /// 获奖合作者添加
        /// </summary>
        /// <returns></returns>
        public bool WinningPartnerInsert(string proc, int WinningId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 获奖单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByWinningId(string proc, int WinningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
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
        /// 获奖合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByWinningPartnerId(string proc, int WinningPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WinningPartnerId", SqlDbType.Int).Value = WinningPartnerId;
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
        /// 获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWinning(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWinningByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 获奖可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet WinningExamineSelectUser(string proc, string UserCardId,int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 获奖修改
        /// </summary>
        /// <returns></returns>
        public bool WinningUpdate(string proc, int WinningId,int DepartmentId, string WinningName, string WinningCategory, string WinningLevel,  double WinningValue, int PartnerRank, double PartnerValue,string Remarks,string WinningUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@WinningName", SqlDbType.VarChar, 200).Value = WinningName;
                    com.Parameters.Add("@WinningCategory", SqlDbType.VarChar, 50).Value = WinningCategory;
                    com.Parameters.Add("@WinningLevel", SqlDbType.VarChar, 50).Value = WinningLevel;
                    com.Parameters.Add("@WinningValue", SqlDbType.Float, 500).Value = WinningValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@WinningUrl", SqlDbType.Text).Value = WinningUrl;
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
        /// 获奖合作者修改
        /// </summary>
        /// <returns></returns>
        public bool WinningPartnerUpdate(string proc, int WinningPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningPartnerId", SqlDbType.Int).Value = WinningPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 获奖删除
        /// </summary>
        /// <returns></returns>
        public bool WinningDelete(string proc, int WinningId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
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
        /// 获奖合作者删除
        /// </summary>
        /// <returns></returns>
        public bool WinningPartnerDelete(string proc, int WinningPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningPartnerId", SqlDbType.Int).Value = WinningPartnerId;
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
        /// 获奖审批添加
        /// </summary>
        /// <returns></returns>
        public bool WinningExamineInsert(string proc, int WinningId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult,int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 获奖审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWinningExamine(string proc, int WinningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
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
        /// 获奖审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool WinningProcessInsert(string proc,  int ProcessRoleId, int ProcessOrder, string DepartmentName,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;                    
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 获奖审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool WinningProcessDelete(string proc, int WinningProcessId,string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningProcessId", SqlDbType.Int).Value = WinningProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 获奖记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsWinning(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string WinningName,string WinningForm,string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@WinningForm", SqlDbType.VarChar, 50).Value = WinningForm;
                    sda.SelectCommand.Parameters.Add("@WinningName", SqlDbType.VarChar, 50).Value = WinningName;
                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 论文
        /// <summary>
        /// 论文申请
        /// </summary>
        /// <returns></returns>
        public bool PaperInsert(string proc, string UserCardId,int DepartmentId, string PaperName, string PaperSubject, string PaperLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears, string Remarks, string PaperUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@PaperName", SqlDbType.VarChar, 200).Value = PaperName;
                    com.Parameters.Add("@PaperSubject", SqlDbType.VarChar, 50).Value = PaperSubject;
                    com.Parameters.Add("@PaperYears", SqlDbType.VarChar, 50).Value = PaperYears;
                    com.Parameters.Add("@PaperLevel", SqlDbType.VarChar, 50).Value = PaperLevel;
                    com.Parameters.Add("@PaperValue", SqlDbType.Float, 500).Value = PaperValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@PaperUrl", SqlDbType.Text).Value = PaperUrl;
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
        /// 论文合作者添加
        /// </summary>
        /// <returns></returns>
        public bool PaperPartnerInsert(string proc, int PaperId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 论文单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPaperId(string proc, int PaperId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
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
        /// 论文合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPaperPartnerId(string proc, int PaperPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PaperPartnerId", SqlDbType.Int).Value = PaperPartnerId;
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
        /// 论文查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPaper(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人论文查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPaperByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 论文可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet PaperExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 论文修改
        /// </summary>
        /// <returns></returns>
        public bool PaperUpdate(string proc, int PaperId,int DepartmentId, string PaperName, string PaperSubject, string PaperLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears, string Remarks, string PaperUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@PaperName", SqlDbType.VarChar, 200).Value = PaperName;
                    com.Parameters.Add("@PaperSubject", SqlDbType.VarChar, 50).Value = PaperSubject;
                    com.Parameters.Add("@PaperYears", SqlDbType.VarChar, 50).Value = PaperYears;
                    com.Parameters.Add("@PaperLevel", SqlDbType.VarChar, 50).Value = PaperLevel;
                    com.Parameters.Add("@PaperValue", SqlDbType.Float, 500).Value = PaperValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@PaperUrl", SqlDbType.Text).Value = PaperUrl;
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
        /// 论文合作者修改
        /// </summary>
        /// <returns></returns>
        public bool PaperPartnerUpdate(string proc, int PaperPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperPartnerId", SqlDbType.Int).Value = PaperPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 论文删除
        /// </summary>
        /// <returns></returns>
        public bool PaperDelete(string proc, int PaperId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
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
        /// 论文合作者删除
        /// </summary>
        /// <returns></returns>
        public bool PaperPartnerDelete(string proc, int PaperPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperPartnerId", SqlDbType.Int).Value = PaperPartnerId;
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
        /// 论文审批添加
        /// </summary>
        /// <returns></returns>
        public bool PaperExamineInsert(string proc, int PaperId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 论文审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPaperExamine(string proc, int PaperId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
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
        /// 论文审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool PaperProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 论文审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool PaperProcessDelete(string proc, int PaperProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperProcessId", SqlDbType.Int).Value = PaperProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 论文记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsPaper(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string PaperSubject, string PaperName, string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@PaperName", SqlDbType.VarChar, 50).Value = PaperName;
                    sda.SelectCommand.Parameters.Add("@PaperSubject", SqlDbType.VarChar, 50).Value = PaperSubject;

                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 工作量项目
        /// <summary>
        /// 工作量项目申请
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsInsert(string proc, string ProjectsId, string UserCardId, int DepartmentId, string WorkLoadProjectsName, string WorkLoadForm, string StartEndDate, string WorkLoadCapital, string CateGory, double WorkLoadProjectsValue, int PartnerRank, double PartnerValue,string Remarks,string WorkLoadProjectsUrl,double SumProjectsValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProjectsId", SqlDbType.VarChar, 50).Value = ProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@WorkLoadProjectsName", SqlDbType.VarChar,200).Value = WorkLoadProjectsName;
                    com.Parameters.Add("@WorkLoadForm", SqlDbType.VarChar, 200).Value = WorkLoadForm;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@WorkLoadCapital", SqlDbType.Float).Value = WorkLoadCapital;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = CateGory;
                    com.Parameters.Add("@WorkLoadProjectsValue", SqlDbType.Float).Value = WorkLoadProjectsValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float).Value = PartnerValue;
                    com.Parameters.Add("@SumProjectsValue", SqlDbType.Float).Value = SumProjectsValue;
                    
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@WorkLoadProjectsUrl", SqlDbType.Text).Value = WorkLoadProjectsUrl;


                    
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
        /// 工作量项目合作者添加
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsPartnerInsert(string proc, int WorkLoadProjectsId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 工作量项目单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByWorkLoadProjectsId(string proc, int WorkLoadProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
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
        /// 工作量项目合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByWorkLoadProjectsPartnerId(string proc, int WorkLoadProjectsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WorkLoadProjectsPartnerId", SqlDbType.Int).Value = WorkLoadProjectsPartnerId;
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
        /// 工作量项目查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWorkLoadProjects(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人工作量项目查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWorkLoadProjectsByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 工作量项目可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet WorkLoadProjectsExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 工作量项目修改
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsUpdate(string proc, int WorkLoadProjectsId, string ProjectsId,int DepartmentId, string WorkLoadProjectsName, string WorkLoadForm, string StartEndDate, string WorkLoadCapital, string CateGory, double WorkLoadProjectsValue, int PartnerRank, double PartnerValue,string Remarks,string WorkLoadProjectsUrl,double SumProjectsValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
                    com.Parameters.Add("@ProjectsId", SqlDbType.VarChar, 50).Value = ProjectsId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@WorkLoadProjectsName", SqlDbType.VarChar, 200).Value = WorkLoadProjectsName;
                    com.Parameters.Add("@WorkLoadFrom", SqlDbType.VarChar,200).Value = WorkLoadForm;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@WorkLoadCapital", SqlDbType.Float).Value = WorkLoadCapital;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = CateGory;
                    com.Parameters.Add("@WorkLoadProjectsValue", SqlDbType.Float).Value = WorkLoadProjectsValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float).Value = PartnerValue;
                    com.Parameters.Add("@SumProjectsValue", SqlDbType.Float).Value = SumProjectsValue;
                    
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@WorkLoadProjectsUrl", SqlDbType.Text).Value = WorkLoadProjectsUrl;


                    
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
        /// 工作量项目合作者修改
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsPartnerUpdate(string proc, int WorkLoadProjectsPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsPartnerId", SqlDbType.Int).Value = WorkLoadProjectsPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 工作量项目删除
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsDelete(string proc, int WorkLoadProjectsId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
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
        /// 工作量项目合作者删除
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsPartnerDelete(string proc, int WorkLoadProjectsPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsPartnerId", SqlDbType.Int).Value = WorkLoadProjectsPartnerId;
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
        /// 工作量项目审批添加
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsExamineInsert(string proc, int WorkLoadProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 工作量项目审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectWorkLoadProjectsExamine(string proc, int WorkLoadProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
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
        /// 工作量项目审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 工作量项目审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsProcessDelete(string proc, int WorkLoadProjectsProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsProcessId", SqlDbType.Int).Value = WorkLoadProjectsProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 工作量项目记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsWorkLoadProjects(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string ProjectsName,string ProjectsForm,string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 50).Value = ProjectsName;
                    sda.SelectCommand.Parameters.Add("@ProjectsForm", SqlDbType.VarChar, 50).Value = ProjectsForm;
                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 著作
        /// <summary>
        /// 著作申请
        /// </summary>
        /// <returns></returns>
        public bool TeachingInsert(string proc, string UserCardId,int DepartmentId, string BookName, string PressCategory, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, int PartnerRank, double PartnerValue, string Remarks, string TeachingUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@BookName", SqlDbType.VarChar,200).Value = BookName;
                    com.Parameters.Add("@PressCategory", SqlDbType.VarChar, 50).Value = PressCategory;
                    com.Parameters.Add("@PressName", SqlDbType.VarChar, 50).Value = PressName;
                    com.Parameters.Add("@PressDate", SqlDbType.VarChar, 50).Value = PressDate;
                    com.Parameters.Add("@Revision", SqlDbType.VarChar, 50).Value = Revision;
                    com.Parameters.Add("@TotalNumber", SqlDbType.VarChar, 50).Value = TotalNumber;
                    com.Parameters.Add("@TeachingValue", SqlDbType.Float, 500).Value = TeachingValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TeachingUrl", SqlDbType.Text).Value = TeachingUrl;
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
        /// 著作合作者添加
        /// </summary>
        /// <returns></returns>
        public bool TeachingPartnerInsert(string proc, int TeachingId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 著作单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTeachingId(string proc, int TeachingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
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
        /// 著作合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTeachingPartnerId(string proc, int TeachingPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TeachingPartnerId", SqlDbType.Int).Value = TeachingPartnerId;
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
        /// 著作查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeaching(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人著作查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeachingByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 著作可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet TeachingExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 著作修改
        /// </summary>
        /// <returns></returns>
        public bool TeachingUpdate(string proc, int TeachingId,int DepartmentId, string BookName, string PressCategory, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, int PartnerRank, double PartnerValue, string Remarks, string TeachingUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@BookName", SqlDbType.VarChar, 200).Value = BookName;
                    com.Parameters.Add("@PressCategory", SqlDbType.VarChar, 50).Value = PressCategory;
                    com.Parameters.Add("@PressName", SqlDbType.VarChar, 50).Value = PressName;
                    com.Parameters.Add("@PressDate", SqlDbType.VarChar, 50).Value = PressDate;
                    com.Parameters.Add("@Revision", SqlDbType.VarChar, 50).Value = Revision;
                    com.Parameters.Add("@TotalNumber", SqlDbType.VarChar, 50).Value = TotalNumber;
                    com.Parameters.Add("@TeachingValue", SqlDbType.Float, 500).Value = TeachingValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TeachingUrl", SqlDbType.Text).Value = TeachingUrl;
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
        /// 著作合作者修改
        /// </summary>
        /// <returns></returns>
        public bool TeachingPartnerUpdate(string proc, int TeachingPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingPartnerId", SqlDbType.Int).Value = TeachingPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 著作删除
        /// </summary>
        /// <returns></returns>
        public bool TeachingDelete(string proc, int TeachingId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
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
        /// 著作合作者删除
        /// </summary>
        /// <returns></returns>
        public bool TeachingPartnerDelete(string proc, int TeachingPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingPartnerId", SqlDbType.Int).Value = TeachingPartnerId;
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
        /// 著作审批添加
        /// </summary>
        /// <returns></returns>
        public bool TeachingExamineInsert(string proc, int TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 著作审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeachingExamine(string proc, int TeachingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
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
        /// 著作审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool TeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 著作审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool TeachingProcessDelete(string proc, int TeachingProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingProcessId", SqlDbType.Int).Value = TeachingProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 著作记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsTeaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string BookName, string PressName, string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@BookName", SqlDbType.VarChar, 50).Value = BookName;
                    sda.SelectCommand.Parameters.Add("@PressName", SqlDbType.VarChar, 50).Value = PressName;
                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 成果
        /// <summary>
        /// 成果申请
        /// </summary>
        /// <returns></returns>
        public bool HarvestInsert(string proc, string UserCardId, int DepartmentId, string HarvestName, string AppraisalCompany, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue,string Remarks,string HarvestUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@HarvestName", SqlDbType.VarChar, 200).Value = HarvestName;
                    com.Parameters.Add("@AppraisalCompany", SqlDbType.VarChar, 50).Value = AppraisalCompany;
                    com.Parameters.Add("@AppraisalLevel", SqlDbType.VarChar, 50).Value = AppraisalLevel;
                    com.Parameters.Add("@HarvestValue", SqlDbType.Float, 500).Value = HarvestValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@HarvestUrl", SqlDbType.Text).Value = HarvestUrl;
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
        /// 成果合作者添加
        /// </summary>
        /// <returns></returns>
        public bool HarvestPartnerInsert(string proc, int HarvestId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 成果单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByHarvestId(string proc, int HarvestId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
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
        /// 成果合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByHarvestPartnerId(string proc, int HarvestPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@HarvestPartnerId", SqlDbType.Int).Value = HarvestPartnerId;
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
        /// 成果查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectHarvest(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人成果查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectHarvestByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 成果可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet HarvestExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 成果修改
        /// </summary>
        /// <returns></returns>
        public bool HarvestUpdate(string proc, int HarvestId, int DepartmentId, string HarvestName, string AppraisalCompany, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue,string Remarks,string HarvestUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@HarvestName", SqlDbType.VarChar, 200).Value = HarvestName;
                    com.Parameters.Add("@AppraisalCompany", SqlDbType.VarChar, 50).Value = AppraisalCompany;
                    com.Parameters.Add("@AppraisalLevel", SqlDbType.VarChar, 50).Value = AppraisalLevel;
                    com.Parameters.Add("@HarvestValue", SqlDbType.Float, 500).Value = HarvestValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@HarvestUrl", SqlDbType.Text).Value = HarvestUrl;

                    

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
        /// 成果合作者修改
        /// </summary>
        /// <returns></returns>
        public bool HarvestPartnerUpdate(string proc, int HarvestPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestPartnerId", SqlDbType.Int).Value = HarvestPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 成果删除
        /// </summary>
        /// <returns></returns>
        public bool HarvestDelete(string proc, int HarvestId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
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
        /// 成果合作者删除
        /// </summary>
        /// <returns></returns>
        public bool HarvestPartnerDelete(string proc, int HarvestPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestPartnerId", SqlDbType.Int).Value = HarvestPartnerId;
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
        /// 成果审批添加
        /// </summary>
        /// <returns></returns>
        public bool HarvestExamineInsert(string proc, int HarvestId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 成果审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectHarvestExamine(string proc, int HarvestId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
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
        /// 成果审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool HarvestProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 成果审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool HarvestProcessDelete(string proc, int HarvestProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestProcessId", SqlDbType.Int).Value = HarvestProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 成果记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsHarvest(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string HarvestName, string Company, string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@HarvestName", SqlDbType.VarChar, 50).Value = HarvestName;
                    sda.SelectCommand.Parameters.Add("@AppraisalCompany", SqlDbType.VarChar, 50).Value = Company;
                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 专利
        /// <summary>
        /// 专利申请
        /// </summary>
        /// <returns></returns>
        public bool PatentInsert(string proc, string UserCardId,int DepartmentId, string PatentName, string PatentCateGory, string PatentLevel, double PatentValue, int PartnerRank, double PartnerValue, string Prizes, string Remarks, string PatentUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@PatentName", SqlDbType.VarChar, 200).Value = PatentName;
                    com.Parameters.Add("@PatentCateGory", SqlDbType.VarChar, 50).Value = PatentCateGory;
                    com.Parameters.Add("@PatentPrizes", SqlDbType.VarChar, 50).Value = Prizes;
                    com.Parameters.Add("@PatentLevel", SqlDbType.VarChar, 50).Value = PatentLevel;
                    com.Parameters.Add("@PatentValue", SqlDbType.Float, 500).Value = PatentValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@PatentUrl", SqlDbType.Text).Value = PatentUrl;
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
        /// 专利合作者添加
        /// </summary>
        /// <returns></returns>
        public bool PatentPartnerInsert(string proc, int PatentId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 专利单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPatentId(string proc, int PatentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
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
        /// 专利合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPatentPartnerId(string proc, int PatentPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PatentPartnerId", SqlDbType.Int).Value = PatentPartnerId;
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
        /// 专利查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPatent(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人专利查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPatentByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专利可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet PatentExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 专利修改
        /// </summary>
        /// <returns></returns>
        public bool PatentUpdate(string proc, int PatentId, int DepartmentId, string PatentName, string PatentCateGory, string PatentLevel, double PatentValue, int PartnerRank, double PartnerValue, string Prizes, string Remarks, string PatentUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@PatentName", SqlDbType.VarChar, 200).Value = PatentName;
                    com.Parameters.Add("@PatentCateGory", SqlDbType.VarChar, 50).Value = PatentCateGory;
                    com.Parameters.Add("@PatentPrizes", SqlDbType.VarChar, 50).Value = Prizes;
                    com.Parameters.Add("@PatentLevel", SqlDbType.VarChar, 50).Value = PatentLevel;
                    com.Parameters.Add("@PatentValue", SqlDbType.Float, 500).Value = PatentValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@PatentUrl", SqlDbType.Text).Value = PatentUrl;
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
        /// 专利合作者修改
        /// </summary>
        /// <returns></returns>
        public bool PatentPartnerUpdate(string proc, int PatentPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentPartnerId", SqlDbType.Int).Value = PatentPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 专利删除
        /// </summary>
        /// <returns></returns>
        public bool PatentDelete(string proc, int PatentId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
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
        /// 专利合作者删除
        /// </summary>
        /// <returns></returns>
        public bool PatentPartnerDelete(string proc, int PatentPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentPartnerId", SqlDbType.Int).Value = PatentPartnerId;
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
        /// 专利审批添加
        /// </summary>
        /// <returns></returns>
        public bool PatentExamineInsert(string proc, int PatentId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 专利审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPatentExamine(string proc, int PatentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
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
        /// 专利审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool PatentProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专利审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool PatentProcessDelete(string proc, int PatentProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentProcessId", SqlDbType.Int).Value = PatentProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专利记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsPatent(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string PatentName, string PatentCateGory, string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@PatentName", SqlDbType.VarChar, 50).Value = PatentName;
                    sda.SelectCommand.Parameters.Add("@PatentCateGory", SqlDbType.VarChar, 50).Value = PatentCateGory;

                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #region 指导学生
        /// <summary>
        /// 指导学生申请
        /// </summary>
        /// <returns></returns>
        public bool GuidanceInsert(string proc, string UserCardId, int DepartmentId, string GuidanceName, string GuidanceLevel, double GuidanceValue, int PartnerRank, double PartnerValue,string Remarks,string GuidanceUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@GuidanceName", SqlDbType.VarChar, 200).Value = GuidanceName;
                    com.Parameters.Add("@GuidanceLevel", SqlDbType.VarChar, 50).Value = GuidanceLevel;
                    com.Parameters.Add("@GuidanceValue", SqlDbType.Float, 500).Value = GuidanceValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@GuidanceUrl", SqlDbType.Text).Value = GuidanceUrl;

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
        /// 指导学生合作者添加
        /// </summary>
        /// <returns></returns>
        public bool GuidancePartnerInsert(string proc, int GuidanceId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 指导学生单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByGuidanceId(string proc, int GuidanceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
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
        /// 指导学生合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByGuidancePartnerId(string proc, int GuidancePartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@GuidancePartnerId", SqlDbType.Int).Value = GuidancePartnerId;
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
        /// 指导学生查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectGuidance(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人指导学生查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectGuidanceByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 指导学生可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet GuidanceExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 指导学生修改
        /// </summary>
        /// <returns></returns>
        public bool GuidanceUpdate(string proc, int GuidanceId,int DepartmentId, string GuidanceName, string GuidanceLevel, double GuidanceValue, int PartnerRank, double PartnerValue,string Remarks,string GuidanceUrl)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@GuidanceName", SqlDbType.VarChar, 200).Value = GuidanceName;
                    com.Parameters.Add("@GuidanceLevel", SqlDbType.VarChar, 50).Value = GuidanceLevel;
                    com.Parameters.Add("@GuidanceValue", SqlDbType.Float, 500).Value = GuidanceValue;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@GuidanceUrl", SqlDbType.Text).Value = GuidanceUrl;
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
        /// 指导学生合作者修改
        /// </summary>
        /// <returns></returns>
        public bool GuidancePartnerUpdate(string proc, int GuidancePartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidancePartnerId", SqlDbType.Int).Value = GuidancePartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 指导学生删除
        /// </summary>
        /// <returns></returns>
        public bool GuidanceDelete(string proc, int GuidanceId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
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
        /// 指导学生合作者删除
        /// </summary>
        /// <returns></returns>
        public bool GuidancePartnerDelete(string proc, int GuidancePartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidancePartnerId", SqlDbType.Int).Value = GuidancePartnerId;
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
        /// 指导学生审批添加
        /// </summary>
        /// <returns></returns>
        public bool GuidanceExamineInsert(string proc, int GuidanceId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 指导学生审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectGuidanceExamine(string proc, int GuidanceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
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
        /// 指导学生审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool GuidanceProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 指导学生审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool GuidanceProcessDelete(string proc, int GuidanceProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceProcessId", SqlDbType.Int).Value = GuidanceProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 指导学生记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsGuidance(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string GuidanceName, string GuidanceLevel, string WinningYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar,50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@GuidanceName", SqlDbType.VarChar, 50).Value = GuidanceName;
                    sda.SelectCommand.Parameters.Add("@GuidanceLevel", SqlDbType.VarChar, 50).Value = GuidanceLevel;
                    sda.SelectCommand.Parameters.Add("@WinningYear", SqlDbType.VarChar, 50).Value = WinningYear;
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
        #endregion
        #region 项目
        #region 纵向项目
        /// <summary>
        /// 纵向项目保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsInsert(string proc, string LongProjectsId, string UserCardId,int DepartmentId, string ProjectsName, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company, string DeclareUrl,string IsSchool)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 100).Value = ProjectsName;
                    com.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
                    com.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
                    com.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@DeclareUrl", SqlDbType.Text).Value = DeclareUrl;
                    com.Parameters.Add("@IsSchool", SqlDbType.VarChar, 50).Value = IsSchool;
                    

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
        /// 纵向项目保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsSumInsert(string proc, string LongProjectsId, string UserCardId,int DepartmentId, string ProjectsName, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company,string IsSchool,int ApplyYearId,string DeclareStatus,string StandStatus,string InspectStatus,string EndStatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 100).Value = ProjectsName;
                    com.Parameters.Add("@ProjectsFromId", SqlDbType.Int).Value = ProjectsFromId;
                    com.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
                    com.Parameters.Add("@ProjectsLevelId", SqlDbType.Int).Value = ProjectsLevelId;
                    com.Parameters.Add("@ProjectsSubjectId", SqlDbType.Int).Value = ProjectsSubjectId;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@IsSchool", SqlDbType.VarChar, 50).Value = IsSchool;
                    com.Parameters.Add("@DeclareStatus", SqlDbType.VarChar, 50).Value = DeclareStatus;
                    com.Parameters.Add("@StandStatus", SqlDbType.VarChar, 50).Value = StandStatus;
                    com.Parameters.Add("@InspectStatus", SqlDbType.VarChar, 50).Value = InspectStatus;
                    com.Parameters.Add("@EndStatus", SqlDbType.VarChar, 50).Value = EndStatus;

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
        /// 纵向项目立项保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsApprovalInsert(string proc, string LongProjectsId, string FileUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;

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
        /// 纵向项目保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsEndInsert(string proc, string LongProjectsId, string UserCardId, string LongProjectsName, string LongProjectsCateGory, string Company, string SmallCateGory, string PhoneNumber, string StartDate, string EndDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@LongProjectsName", SqlDbType.VarChar, 50).Value = LongProjectsName;
                    com.Parameters.Add("@LongProjectsCateGory", SqlDbType.VarChar, 50).Value = LongProjectsCateGory;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@LongProjectsSmallCateGory", SqlDbType.VarChar, 50).Value = SmallCateGory;
                    com.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = PhoneNumber;
                    com.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
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
        /// 纵向项目结题基本信息保存
        /// </summary>
        public bool LongProjectsEndUpdate(string proc, string LongProjectsId, string EndDate, double ActualCapital)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@ActualCapital", SqlDbType.Float).Value = ActualCapital;
                    com.Parameters.Add("@ActualDate", SqlDbType.Date).Value = EndDate;
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
        /// 纵向项目问题保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsProblemInsert(string proc, string LongProjectsId, string ProblemOne, string Expected, string Number)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@ProblemOne", SqlDbType.Text).Value = ProblemOne;
                    com.Parameters.Add("@Expected", SqlDbType.VarChar, 50).Value = Expected;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
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
        /// 项目立项操作
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsStandUpdate(string proc, string LongProjectsId, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    con.Open();
                    var i = com.ExecuteNonQuery();
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
        /// 项目记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsLongProjects(string proc, string ProjectsId, string ProjectsName, string UserName, string DepartmentName, string ApplyYear, string Subject, string Level, string From, string Declare, string Stand, string Inspect, string Ends)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProjectsId", SqlDbType.VarChar, 50).Value = ProjectsId;
                    sda.SelectCommand.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 100).Value = ProjectsName;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    sda.SelectCommand.Parameters.Add("@ApplyYear", SqlDbType.VarChar, 50).Value = ApplyYear;
                    sda.SelectCommand.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = Subject;
                    sda.SelectCommand.Parameters.Add("@Level", SqlDbType.VarChar, 50).Value = Level;
                    sda.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar, 50).Value = From;
                    sda.SelectCommand.Parameters.Add("@Declare", SqlDbType.VarChar, 50).Value = Declare;
                    sda.SelectCommand.Parameters.Add("@Stand", SqlDbType.VarChar, 50).Value = Stand;
                    sda.SelectCommand.Parameters.Add("@Inspect", SqlDbType.VarChar, 50).Value = Inspect;
                    sda.SelectCommand.Parameters.Add("@Ends", SqlDbType.VarChar, 50).Value = Ends;
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
        /// 纵向项目删除
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsDelete(string proc, string LongProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;

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
        /// 纵向项目删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteByFileId(string proc, int FileId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@FileId", SqlDbType.Int, 32).Value = FileId;

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
        /// 上传附件
        /// </summary>
        public bool FileInsert(string proc, string LongProjectsId, string FileName, string FileUrl, string FileType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@FileName", SqlDbType.VarChar, 50).Value = FileName;
                    com.Parameters.Add("@FileType", SqlDbType.VarChar, 50).Value = FileType;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
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

        #region 获得成果
        /// <summary>
        /// 论著添加
        /// </summary>    
        public bool LongProjectsPaperInsert(string proc, string LongProjectsId, string PaperName, string UserName, string PaperCateGory, string Explain)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@PaperName", SqlDbType.VarChar, 50).Value = PaperName;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@PaperCateGory", SqlDbType.VarChar, 50).Value = PaperCateGory;
                    com.Parameters.Add("@Explain", SqlDbType.VarChar, 500).Value = Explain;
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
        /// 论著修改
        /// </summary>    
        public bool LongProjectsPaperUpdate(string proc, int LongProjectsPaperId, string PaperName, string UserName, string PaperCateGory, string Explain)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPaperId", SqlDbType.Int).Value = LongProjectsPaperId;
                    com.Parameters.Add("@PaperName", SqlDbType.VarChar, 50).Value = PaperName;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@PaperCateGory", SqlDbType.VarChar, 50).Value = PaperCateGory;
                    com.Parameters.Add("@Explain", SqlDbType.VarChar, 500).Value = Explain;
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
        /// 论著删除 
        /// </summary>
        public bool LongProjectsPaperDelete(string proc, int LongProjectsPaperId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPaperId", SqlDbType.Int).Value = LongProjectsPaperId;

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
        /// 按纵向项目论著编号查询
        /// </summary>
        public DataSet SelectByLongProjectsPaperId(string proc, int LongProjectsPaperId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsPaperId", SqlDbType.Int).Value = LongProjectsPaperId;
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


        /// <summary>
        /// 成员添加
        /// </summary>    
        public bool NaturalPartnerInsert(string proc, string LongProjectsId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserJob", SqlDbType.VarChar, 50).Value = UserJob;
                    com.Parameters.Add("@UserProfession", SqlDbType.VarChar, 50).Value = UserProfession;
                    com.Parameters.Add("@UserWork", SqlDbType.VarChar, 50).Value = UserWork;
                    com.Parameters.Add("@UserCompany", SqlDbType.VarChar, 50).Value = UserCompany;

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
        /// 成员修改
        /// </summary>    
        public bool NaturalPartnerUpdate(string proc, int LongProjectsPartnerId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPartnerId", SqlDbType.Int).Value = LongProjectsPartnerId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserJob", SqlDbType.VarChar, 50).Value = UserJob;
                    com.Parameters.Add("@UserProfession", SqlDbType.VarChar, 50).Value = UserProfession;
                    com.Parameters.Add("@UserWork", SqlDbType.VarChar, 50).Value = UserWork;
                    com.Parameters.Add("@UserCompany", SqlDbType.VarChar, 50).Value = UserCompany;

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
        /// 成员删除 
        /// </summary>
        public bool NaturalPartnerDelete(string proc, int LongProjectsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPartnerId", SqlDbType.Int).Value = LongProjectsPartnerId;

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
        /// 按项目成员编号查询
        /// </summary>
        public DataSet SelectByLongProjectsPartnerId(string proc, int LongProjectsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsPartnerId", SqlDbType.Int).Value = LongProjectsPartnerId;
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
        /// <summary>
        /// 专利添加
        /// </summary>    
        public bool LongProjectsPatentInsert(string proc, string LongProjectsId, string PatentName, string PatentNumber, string PatentAuthorize)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@PatentName", SqlDbType.VarChar, 50).Value = PatentName;
                    com.Parameters.Add("@PatentNumber", SqlDbType.VarChar, 50).Value = PatentNumber;
                    com.Parameters.Add("@PatentAuthorize", SqlDbType.VarChar, 50).Value = PatentAuthorize;
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
        /// 专利修改
        /// </summary>    
        public bool LongProjectsPatentUpdate(string proc, int LongProjectsPatentId, string PatentName, string PatentNumber, string PatentAuthorize)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPatentId", SqlDbType.Int).Value = LongProjectsPatentId;
                    com.Parameters.Add("@PatentName", SqlDbType.VarChar, 50).Value = PatentName;
                    com.Parameters.Add("@PatentNumber", SqlDbType.VarChar, 50).Value = PatentNumber;
                    com.Parameters.Add("@PatentAuthorize", SqlDbType.VarChar, 50).Value = PatentAuthorize;
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
        /// 专利删除 
        /// </summary>
        public bool LongProjectsPatentDelete(string proc, int LongProjectsPatentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsPatentId", SqlDbType.Int).Value = LongProjectsPatentId;

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
        /// 按纵向项目专利编号查询
        /// </summary>
        public DataSet SelectByLongProjectsPatentId(string proc, int LongProjectsPatentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsPatentId", SqlDbType.Int).Value = LongProjectsPatentId;
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
        /// <summary>
        /// 获奖添加
        /// </summary>    
        public bool LongProjectsWinningInsert(string proc, string LongProjectsId, string WinningProjectsName, string Company, string WinningName, string WinningLevel, string WinningDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@WinningProjectsName", SqlDbType.VarChar, 50).Value = WinningProjectsName;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@WinningName", SqlDbType.VarChar, 50).Value = WinningName;
                    com.Parameters.Add("@WinningLevel", SqlDbType.VarChar, 50).Value = WinningLevel;
                    com.Parameters.Add("@WinningDate", SqlDbType.VarChar, 50).Value = WinningDate;
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
        /// 获奖修改
        /// </summary>    
        public bool LongProjectsWinningUpdate(string proc, int LongProjectsWinningId, string WinningProjectsName, string Company, string WinningName, string WinningLevel, string WinningDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsWinningId", SqlDbType.Int).Value = LongProjectsWinningId;
                    com.Parameters.Add("@WinningProjectsName", SqlDbType.VarChar, 50).Value = WinningProjectsName;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@WinningName", SqlDbType.VarChar, 50).Value = WinningName;
                    com.Parameters.Add("@WinningLevel", SqlDbType.VarChar, 50).Value = WinningLevel;
                    com.Parameters.Add("@WinningDate", SqlDbType.VarChar, 50).Value = WinningDate;
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
        /// 获奖删除 
        /// </summary>
        public bool LongProjectsWinningDelete(string proc, int LongProjectsWinningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsWinningId", SqlDbType.Int).Value = LongProjectsWinningId;

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
        /// 按纵向项目获奖编号查询
        /// </summary>
        public DataSet SelectByLongProjectsWinningId(string proc, int LongProjectsWinningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsWinningId", SqlDbType.Int).Value = LongProjectsWinningId;
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
        /// <summary>
        /// 经济效益添加
        /// </summary>    
        public bool LongProjectsBenefitInsert(string proc, string LongProjectsId, double TransferFee, double ConsultingFee, int Doctor, int Master, string Upgrading)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@TransferFee", SqlDbType.VarChar, 50).Value = TransferFee;
                    com.Parameters.Add("@ConsultingFee", SqlDbType.VarChar, 50).Value = ConsultingFee;
                    com.Parameters.Add("@doctor", SqlDbType.VarChar, 50).Value = Doctor;
                    com.Parameters.Add("@master", SqlDbType.VarChar, 50).Value = Master;
                    com.Parameters.Add("@upgrading", SqlDbType.VarChar, 50).Value = Upgrading;
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
        /// 总结添加
        /// </summary>    
        public bool LongProjectsSummaryInsert(string proc, string LongProjectsId, string ProblemOne, string ProblemTwo, string ProblemThree)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@ProblemOne", SqlDbType.Text).Value = ProblemOne;
                    com.Parameters.Add("@ProblemTwo", SqlDbType.Text).Value = ProblemTwo;
                    com.Parameters.Add("@ProblemThree", SqlDbType.Text).Value = ProblemThree;
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
        #region 经费决算
        public bool LongProjectsTotalCapitalInsert(string proc, string LongProjectsId, string ProjectsTotalCapital, double SumCome, double SchoolCome, double OtherCome, double SumExpenditure, double OneExpenditure, double TwoExpenditure, double ThreeExpenditure, double ForeExpenditure, double FiveExpenditure, double SixExpenditure, double SevenExpenditure, double EightExpenditure, double NightExpenditure, double TenExpenditure, double EleventExpenditure, double TwelveExpenditure, double SurplusCapital)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@ProjectsTotalCapital", SqlDbType.VarChar, 50).Value = ProjectsTotalCapital;
                    com.Parameters.Add("@SumCome", SqlDbType.Float).Value = SumCome;
                    com.Parameters.Add("@SchoolCome", SqlDbType.Float).Value = SchoolCome;
                    com.Parameters.Add("@OtherCome", SqlDbType.Float).Value = OtherCome;
                    com.Parameters.Add("@SumExpenditure", SqlDbType.Float).Value = SumExpenditure;
                    com.Parameters.Add("@OneExpenditure", SqlDbType.Float).Value = OneExpenditure;
                    com.Parameters.Add("@TwoExpenditure", SqlDbType.Float).Value = TwoExpenditure;
                    com.Parameters.Add("@ThreeExpenditure", SqlDbType.Float).Value = ThreeExpenditure;
                    com.Parameters.Add("@ForeExpenditure", SqlDbType.Float).Value = ForeExpenditure;
                    com.Parameters.Add("@FiveExpenditure", SqlDbType.Float).Value = FiveExpenditure;
                    com.Parameters.Add("@SixExpenditure", SqlDbType.Float).Value = SixExpenditure;
                    com.Parameters.Add("@SevenExpenditure", SqlDbType.Float).Value = SevenExpenditure;
                    com.Parameters.Add("@EightExpenditure", SqlDbType.Float).Value = EightExpenditure;
                    com.Parameters.Add("@NightExpenditure", SqlDbType.Float).Value = NightExpenditure;
                    com.Parameters.Add("@TenExpenditure", SqlDbType.Float).Value = TenExpenditure;
                    com.Parameters.Add("@EleventExpenditure", SqlDbType.Float).Value = EleventExpenditure;
                    com.Parameters.Add("@TwelveExpenditure", SqlDbType.Float).Value = TwelveExpenditure;
                    com.Parameters.Add("@SurplusCapital", SqlDbType.Float).Value = SurplusCapital;

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


        public bool LongProjectsBranchCapitalInsert(string proc, string LongProjectsId, string Years, double SumCome, double SchoolCome, double OtherCome, double SumExpenditure, double OneExpenditure, double TwoExpenditure, double ThreeExpenditure, double ForeExpenditure, double FiveExpenditure, double SixExpenditure, double SevenExpenditure, double EightExpenditure, double NightExpenditure, double TenExpenditure, double EleventExpenditure, double TwelveExpenditure, double SurplusCapital)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@Years", SqlDbType.VarChar, 50).Value = Years;
                    com.Parameters.Add("@SumCome", SqlDbType.Float).Value = SumCome;
                    com.Parameters.Add("@SchoolCome", SqlDbType.Float).Value = SchoolCome;
                    com.Parameters.Add("@OtherCome", SqlDbType.Float).Value = OtherCome;
                    com.Parameters.Add("@SumExpenditure", SqlDbType.Float).Value = SumExpenditure;
                    com.Parameters.Add("@OneExpenditure", SqlDbType.Float).Value = OneExpenditure;
                    com.Parameters.Add("@TwoExpenditure", SqlDbType.Float).Value = TwoExpenditure;
                    com.Parameters.Add("@ThreeExpenditure", SqlDbType.Float).Value = ThreeExpenditure;
                    com.Parameters.Add("@ForeExpenditure", SqlDbType.Float).Value = ForeExpenditure;
                    com.Parameters.Add("@FiveExpenditure", SqlDbType.Float).Value = FiveExpenditure;
                    com.Parameters.Add("@SixExpenditure", SqlDbType.Float).Value = SixExpenditure;
                    com.Parameters.Add("@SevenExpenditure", SqlDbType.Float).Value = SevenExpenditure;
                    com.Parameters.Add("@EightExpenditure", SqlDbType.Float).Value = EightExpenditure;
                    com.Parameters.Add("@NightExpenditure", SqlDbType.Float).Value = NightExpenditure;
                    com.Parameters.Add("@TenExpenditure", SqlDbType.Float).Value = TenExpenditure;
                    com.Parameters.Add("@EleventExpenditure", SqlDbType.Float).Value = EleventExpenditure;
                    com.Parameters.Add("@TwelveExpenditure", SqlDbType.Float).Value = TwelveExpenditure;
                    com.Parameters.Add("@SurplusCapital", SqlDbType.Float).Value = SurplusCapital;

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
        /// 按纵向项目编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByLongProjectsId(string proc, string LongProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
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
        /// <summary>
        /// 按纵向项目编号,用户工号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByLongUser(string proc, string LongProjectsId, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;

                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// <summary>
        /// 按纵向项目经费预算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByLongProjectsCapitalPlanId(string proc, int LongProjectsCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsCapitalPlanId", SqlDbType.Int).Value = LongProjectsCapitalPlanId;
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
        /// <summary>
        /// 按纵向项目经费到位编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByLongProjectsCapitalPlaceId(string proc, int LongCapitalPlaceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsCapitalPlaceId", SqlDbType.Int).Value = LongCapitalPlaceId;
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
        /// <summary>
        /// 自然科学项目申报经费预算保存
        /// </summary>

        /// <returns></returns>
        public bool NaturalCapitalInsert(string proc, string LongProjectsId, double OneCapital, double TwoCapital, double ThreeCapital, double ForeCapital, double FiveCapital, double SixCapital, double SevenCapital, double EightCapital, double NightCapital, double TenCapital, double EleventCapital, double TwelveCapital, string OneExplain, string TwoExplain, string ThreeExplain, string ForeExplain, string FiveExplain, string SixExplain, string SevenExplain, string EightExplain, string NightExplain, string TenExplain, string EleventExplain, string TwelveExplain, double TotalCapital, double ApplyCapital, double Support)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = OneCapital;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 50).Value = OneExplain;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = TwoCapital;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = ThreeCapital;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = ForeCapital;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = FiveCapital;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = SixCapital;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = SevenCapital;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = EightCapital;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = NightCapital;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = TenCapital;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = EleventCapital;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = TwelveCapital;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 50).Value = TwoExplain;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 50).Value = ThreeExplain;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 50).Value = ForeExplain;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 50).Value = FiveExplain;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 50).Value = SixExplain;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 50).Value = SevenExplain;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 50).Value = EightExplain;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 50).Value = NightExplain;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 50).Value = TenExplain;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 50).Value = EleventExplain;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 50).Value = TwelveExplain;
                    com.Parameters.Add("@TotalCapital", SqlDbType.Float).Value = TotalCapital;
                    com.Parameters.Add("@ApplyCapital", SqlDbType.Float).Value = ApplyCapital;
                    com.Parameters.Add("@Support", SqlDbType.Float).Value = Support;
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
        /// 自然科学项目成员保存
        /// </summary>

        /// <returns></returns>
        public bool NaturalPartnerInsert(string proc, string LongProjectsId, string OneCompany, string OneJob, string OneName, string OneProfession, string OneWork, string TwoCompany, string TwoJob, string TwoName, string TwoProfession, string TwoWork, string ThreeCompany, string ThreeJob, string ThreeName, string ThreeProfession, string ThreeWork, string ForeCompany, string ForeJob, string ForeName, string ForeProfession, string ForeWork, string FiveCompany, string FiveJob, string FiveName, string FiveProfession, string FiveWork, string SixCompany, string SixJob, string SixName, string SixProfession, string SixWork)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;



                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@OneCompany", SqlDbType.VarChar, 50).Value = OneCompany;
                    com.Parameters.Add("@OneJob", SqlDbType.VarChar, 50).Value = OneJob;
                    com.Parameters.Add("@OneName", SqlDbType.VarChar, 50).Value = OneName;
                    com.Parameters.Add("@OneProfession", SqlDbType.VarChar, 50).Value = OneProfession;
                    com.Parameters.Add("@OneWork", SqlDbType.VarChar, 50).Value = OneWork;
                    com.Parameters.Add("@TwoCompany", SqlDbType.VarChar, 50).Value = TwoCompany;
                    com.Parameters.Add("@TwoJob", SqlDbType.VarChar, 50).Value = TwoJob;
                    com.Parameters.Add("@TwoName", SqlDbType.VarChar, 50).Value = TwoName;
                    com.Parameters.Add("@TwoProfession", SqlDbType.VarChar, 50).Value = TwoProfession;
                    com.Parameters.Add("@TwoWork", SqlDbType.VarChar, 50).Value = TwoWork;
                    com.Parameters.Add("@ThreeCompany", SqlDbType.VarChar, 50).Value = ThreeCompany;
                    com.Parameters.Add("@ThreeJob", SqlDbType.VarChar, 50).Value = ThreeJob;
                    com.Parameters.Add("@ThreeName", SqlDbType.VarChar, 50).Value = ThreeName;
                    com.Parameters.Add("@ThreeProfession", SqlDbType.VarChar, 50).Value = ThreeProfession;
                    com.Parameters.Add("@ThreeWork", SqlDbType.VarChar, 50).Value = ThreeWork;
                    com.Parameters.Add("@ForeCompany", SqlDbType.VarChar, 50).Value = ForeCompany;
                    com.Parameters.Add("@ForeJob", SqlDbType.VarChar, 50).Value = ForeJob;
                    com.Parameters.Add("@ForeName", SqlDbType.VarChar, 50).Value = ForeName;
                    com.Parameters.Add("@ForeProfession", SqlDbType.VarChar, 50).Value = ForeProfession;
                    com.Parameters.Add("@ForeWork", SqlDbType.VarChar, 50).Value = ForeWork;
                    com.Parameters.Add("@FiveCompany", SqlDbType.VarChar, 50).Value = FiveCompany;
                    com.Parameters.Add("@FiveJob", SqlDbType.VarChar, 50).Value = FiveJob;
                    com.Parameters.Add("@FiveName", SqlDbType.VarChar, 50).Value = FiveName;
                    com.Parameters.Add("@FiveProfession", SqlDbType.VarChar, 50).Value = FiveProfession;
                    com.Parameters.Add("@FiveWork", SqlDbType.VarChar, 50).Value = FiveWork;
                    com.Parameters.Add("@SixCompany", SqlDbType.VarChar, 50).Value = SixCompany;
                    com.Parameters.Add("@SixJob", SqlDbType.VarChar, 50).Value = SixJob;
                    com.Parameters.Add("@SixName", SqlDbType.VarChar, 50).Value = SixName;
                    com.Parameters.Add("@SixProfession", SqlDbType.VarChar, 50).Value = SixProfession;
                    com.Parameters.Add("@SixWork", SqlDbType.VarChar, 50).Value = SixWork;

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
        /// 纵向项目审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRankId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 纵向项目审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsProcessDelete(string proc, int LongProjectsProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsProcessId", SqlDbType.Int).Value = LongProjectsProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目申报经费预算添加
        /// </summary>

        public bool LongProjectsCapitalPlanInsert(string proc, string LongProjectsId, string UserCardId, int CapitalItemId, double Money, string Explan)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@Money", SqlDbType.Float).Value = Money;
                    com.Parameters.Add("@Explan", SqlDbType.Text).Value = Explan;
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
        /// 项目申报经费预算修改
        /// </summary>

        public bool LongProjectsCapitalPlanUpdate(string proc, int LongProjectsCapitalPlanId, string UserCardId, int CapitalItemId, double Money, string Explan)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsCapitalPlanId", SqlDbType.VarChar, 50).Value = LongProjectsCapitalPlanId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@Money", SqlDbType.Float).Value = Money;
                    com.Parameters.Add("@Explan", SqlDbType.Text).Value = Explan;
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
        /// 项目申报经费预算删除

        public bool LongProjectsCapitalPlanDelete(string proc, int LongProjectsCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsCapitalPlanId", SqlDbType.VarChar, 50).Value = LongProjectsCapitalPlanId;

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
        /// 纵向项目审批添加
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsExamineInsert(string proc, string LongProjectsId, string ExamineUserCardId, int RankId, string OneContent, string OneProcess, string OneName, string OneDate, string TwoContent, string TwoProcess, string TwoName, string TwoDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@OneContent", SqlDbType.Text).Value = OneContent;
                    com.Parameters.Add("@OneProcess", SqlDbType.VarChar, 50).Value = OneProcess;
                    com.Parameters.Add("@OneName ", SqlDbType.VarChar, 50).Value = OneName;
                    com.Parameters.Add("@OneDate ", SqlDbType.VarChar, 50).Value = OneDate;
                    com.Parameters.Add("@TwoContent", SqlDbType.Text).Value = TwoContent;
                    com.Parameters.Add("@TwoProcess", SqlDbType.VarChar, 50).Value = TwoProcess;
                    com.Parameters.Add("@TwoName ", SqlDbType.VarChar, 50).Value = TwoName;
                    com.Parameters.Add("@TwoDate ", SqlDbType.VarChar, 50).Value = TwoDate;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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

        #region 项目经费
        #endregion
        /// <summary>
        /// 纵向项目审批添加
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsDeclareExamineInsert(string proc, string LongProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 纵向项目评审添加
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsApprovalBranchInsert(string proc, string LongProjectsId, string UserCardId, double Branch)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Branch", SqlDbType.Float).Value = Branch;
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
        #region 横向项目
        /// <summary>
        /// 纵向项目删除
        /// </summary>
        /// <returns></returns>
        public bool ShortProjectsDelete(string proc, string ShortProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;

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
        /// 横向项目立项保存
        /// </summary>
        /// <returns></returns>
        public bool ShortProjectsApprovalInsert(string proc, string ShortProjectsId, string FileUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;

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
        /// 基础信息添加
        /// </summary>

        public bool ShortProjectsInsert(string proc, string ShortProjectsId, string UserCardId,int DepartmentId, string ContractId, string ContractName, double ContractMoney, string Company, string FileUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ContractId", SqlDbType.VarChar, 50).Value = ContractId;
                    com.Parameters.Add("@ContractName", SqlDbType.VarChar, 100).Value = ContractName;
                    com.Parameters.Add("@ContractMoney", SqlDbType.Float).Value = ContractMoney;                   
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 100).Value = Company;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
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
        /// 单位信息添加
        /// </summary>

        public bool ShortProjectsCompanyInsert(string proc, string ShortId, string CompanyName, string Address, string Nature, string Nature1, string Nature2, string Nature3, string Nature4, string Nature5)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortId", SqlDbType.VarChar, 50).Value = ShortId;
                    com.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50).Value = CompanyName;
                    com.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;
                    com.Parameters.Add("@Natural", SqlDbType.VarChar, 50).Value = Nature;
                    com.Parameters.Add("@Natural1", SqlDbType.VarChar, 50).Value = Nature1;
                    com.Parameters.Add("@Natural2", SqlDbType.VarChar, 50).Value = Nature2;
                    com.Parameters.Add("@Natural3", SqlDbType.VarChar, 50).Value = Nature3;
                    com.Parameters.Add("@Natural4", SqlDbType.VarChar, 50).Value = Nature4;
                    com.Parameters.Add("@Natural5", SqlDbType.VarChar, 50).Value = Nature5;

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



        }/// <summary>
        /// 按横向项目编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByShortId(string proc, string ShortId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortId", SqlDbType.VarChar, 50).Value = ShortId;
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
        /// <summary>
        /// 按横向项目编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByShortProjectsId(string proc, string ShortProjectsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
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
        /// <summary>
        /// 项目记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsShortProjects(string proc, string UserName, string DepartmentName, string ApplyYear, string ContractId, string ContractName, string Company, double Money1, double Money2, string Stand, string Ends)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    sda.SelectCommand.Parameters.Add("@ApplyYear", SqlDbType.VarChar, 50).Value = ApplyYear;
                    sda.SelectCommand.Parameters.Add("@ContractId", SqlDbType.VarChar, 50).Value = ContractId;
                    sda.SelectCommand.Parameters.Add("@ContractName", SqlDbType.VarChar, 50).Value = ContractName;
                    sda.SelectCommand.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    sda.SelectCommand.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
                    sda.SelectCommand.Parameters.Add("@Stand", SqlDbType.VarChar, 50).Value = Stand;
                    sda.SelectCommand.Parameters.Add("@Ends", SqlDbType.VarChar, 50).Value = Ends;
                    sda.SelectCommand.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
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
        /// 成员添加
        /// </summary>    
        public bool ShortProjectsDeclarePartnerInsert(string proc, string ShortId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortId", SqlDbType.VarChar, 50).Value = ShortId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserJob", SqlDbType.VarChar, 50).Value = UserJob;
                    com.Parameters.Add("@UserProfession", SqlDbType.VarChar, 50).Value = UserProfession;
                    com.Parameters.Add("@UserWork", SqlDbType.VarChar, 50).Value = UserWork;
                    com.Parameters.Add("@UserCompany", SqlDbType.VarChar, 50).Value = UserCompany;

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
        /// 成员修改
        /// </summary>    
        public bool ShortProjectsDeclarePartnerUpdate(string proc, int ShortProjectsPartnerId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsPartnerId", SqlDbType.Int).Value = ShortProjectsPartnerId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserJob", SqlDbType.VarChar, 50).Value = UserJob;
                    com.Parameters.Add("@UserProfession", SqlDbType.VarChar, 50).Value = UserProfession;
                    com.Parameters.Add("@UserWork", SqlDbType.VarChar, 50).Value = UserWork;
                    com.Parameters.Add("@UserCompany", SqlDbType.VarChar, 50).Value = UserCompany;

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
        /// 成员删除 
        /// </summary>
        public bool ShortProjectsDeclarePartnerDelete(string proc, int ShortProjectsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsPartnerId", SqlDbType.Int).Value = ShortProjectsPartnerId;

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
        /// 按项目成员编号查询
        /// </summary>
        public DataSet SelectByShortProjectsPartnerId(string proc, int ShortProjectsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortProjectsPartnerId", SqlDbType.Int).Value = ShortProjectsPartnerId;
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
        /// <summary>
        /// 横向项目审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool ShortProjectsProcessDelete(string proc, int ShortProjectsProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsProcessId", SqlDbType.Int).Value = ShortProjectsProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 横向项目审批添加
        /// </summary>
        /// <returns></returns>
        public bool ShortProjectsDeclareExamineInsert(string proc, string ShortProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 成果添加
        /// </summary>    
        public bool ShortHarvestInsert(string proc, string ShortId, string UserName, string HarvestName, string CateGory, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortId", SqlDbType.VarChar, 50).Value = ShortId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@HarvestName", SqlDbType.VarChar, 50).Value = HarvestName;
                    com.Parameters.Add("@CateGory", SqlDbType.VarChar, 50).Value = CateGory;
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
        /// 成果修改
        /// </summary>    
        public bool ShortHarvestUpdate(string proc, int ShortHarvestId, string UserName, string HarvestName, string CateGory, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortHarvestId", SqlDbType.Int).Value = ShortHarvestId;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@HarvestName", SqlDbType.VarChar, 50).Value = HarvestName;
                    com.Parameters.Add("@CateGory", SqlDbType.VarChar, 50).Value = CateGory;
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
        /// 成果删除 
        /// </summary>
        public bool ShortHarvestDelete(string proc, int ShortHarvestId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortHarvestId", SqlDbType.Int).Value = ShortHarvestId;

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
        /// 问题修改 
        /// </summary>
        public bool ShortProjectsEndUpdate(string proc, string ShortId, string ProblemOne, string ProblemTwo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortId", SqlDbType.VarChar, 50).Value = ShortId;
                    com.Parameters.Add("@Problem1", SqlDbType.Text).Value = ProblemOne;
                    com.Parameters.Add("@Problem2", SqlDbType.Text).Value = ProblemTwo;
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
        /// 按项目成果编号查询
        /// </summary>
        public DataSet SelectByShortHarvestId(string proc, int ShortHarvestId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortHarvestId", SqlDbType.Int).Value = ShortHarvestId;
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
        #endregion
        #endregion

        #region 经费
        #region 纵向
        /// <summary>
        /// 纵向经费基本情况保存
        /// </summary>
        public bool LongCapitalBasicSituationInsert(string proc, string LongProjectsId, double BidMoney, double SupportMoney, double OtherMoney, string SuedCompany, string Servicelife)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@BidMoney", SqlDbType.Float).Value = BidMoney;
                    com.Parameters.Add("@SupportMoney", SqlDbType.Float).Value = SupportMoney;
                    com.Parameters.Add("@OtherMoney", SqlDbType.Float).Value = OtherMoney;
                    com.Parameters.Add("@SuedCompany", SqlDbType.VarChar, 50).Value = SuedCompany;
                    com.Parameters.Add("@Servicelife", SqlDbType.VarChar, 50).Value = Servicelife;

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
        /// 纵向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlanProcessDelete(string proc, int LongCapitalPlanProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanProcessId", SqlDbType.Int).Value = LongCapitalPlanProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 纵向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalChangeProcessDelete(string proc, int LongCapitalChangeProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalChangeProcessId", SqlDbType.Int).Value = LongCapitalChangeProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 纵向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalCloseProcessDelete(string proc, int LongCapitalCloseProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalCloseProcessId", SqlDbType.Int).Value = LongCapitalCloseProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目经费预算删除

        public bool LongCapitalPlanDelete(string proc, int LongCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanId", SqlDbType.VarChar, 50).Value = LongCapitalPlanId;

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
        /// 经费预算添加
        /// </summary>
        public bool LongCapitalPlanInsert(string proc, string LongProjectsId, string UserCardId, string FileUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
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
        /// 经费预算修改添加
        /// </summary>
        public bool LongCapitalPlanAdjustInsert(string proc, string LongProjectsId, string UserCardId, double CapitalDial, double CapitalUse,
        double SumCapital, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12,
        string SumAdjust, string Adjust1, string Adjust2, string Adjust3, string Adjust4, string Adjust5, string Adjust6, string Adjust7, string Adjust8, string Adjust9, string Adjust10, string Adjust11, string Adjust12,
            double SumFinal, double Final1, double Final2, double Final3, double Final4, double Final5, double Final6, double Final7, double Final8, double Final9, double Final10, double Final11, double Final12,
            string SumExplain, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@CapitalDial", SqlDbType.Float).Value = CapitalDial;
                    com.Parameters.Add("@CapitalUse", SqlDbType.Float).Value = CapitalUse;

                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;

                    com.Parameters.Add("@SumAdjust", SqlDbType.VarChar, 50).Value = SumAdjust;
                    com.Parameters.Add("@OneAdjust", SqlDbType.VarChar, 50).Value = Adjust1;
                    com.Parameters.Add("@TwoAdjust", SqlDbType.VarChar, 50).Value = Adjust2;
                    com.Parameters.Add("@ThreeAdjust", SqlDbType.VarChar, 50).Value = Adjust3;
                    com.Parameters.Add("@ForeAdjust", SqlDbType.VarChar, 50).Value = Adjust4;
                    com.Parameters.Add("@FiveAdjust", SqlDbType.VarChar, 50).Value = Adjust5;
                    com.Parameters.Add("@SixAdjust", SqlDbType.VarChar, 50).Value = Adjust6;
                    com.Parameters.Add("@SevenAdjust", SqlDbType.VarChar, 50).Value = Adjust7;
                    com.Parameters.Add("@EightAdjust", SqlDbType.VarChar, 50).Value = Adjust8;
                    com.Parameters.Add("@NightAdjust", SqlDbType.VarChar, 50).Value = Adjust9;
                    com.Parameters.Add("@TenAdjust", SqlDbType.VarChar, 50).Value = Adjust10;
                    com.Parameters.Add("@EleventAdjust", SqlDbType.VarChar, 50).Value = Adjust11;
                    com.Parameters.Add("@TwelveAdjust", SqlDbType.VarChar, 50).Value = Adjust12;

                    com.Parameters.Add("@SumFinal", SqlDbType.Float).Value = SumFinal;
                    com.Parameters.Add("@OneFinal", SqlDbType.Float).Value = Final1;
                    com.Parameters.Add("@TwoFinal", SqlDbType.Float).Value = Final2;
                    com.Parameters.Add("@ThreeFinal", SqlDbType.Float).Value = Final3;
                    com.Parameters.Add("@ForeFinal", SqlDbType.Float).Value = Final4;
                    com.Parameters.Add("@FiveFinal", SqlDbType.Float).Value = Final5;
                    com.Parameters.Add("@SixFinal", SqlDbType.Float).Value = Final6;
                    com.Parameters.Add("@SevenFinal", SqlDbType.Float).Value = Final7;
                    com.Parameters.Add("@EightFinal", SqlDbType.Float).Value = Final8;
                    com.Parameters.Add("@NightFinal", SqlDbType.Float).Value = Final9;
                    com.Parameters.Add("@TenFinal", SqlDbType.Float).Value = Final10;
                    com.Parameters.Add("@EleventFinal", SqlDbType.Float).Value = Final11;
                    com.Parameters.Add("@TwelveFinal", SqlDbType.Float).Value = Final12;


                    com.Parameters.Add("@SumExplain", SqlDbType.VarChar, 100).Value = SumExplain;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 经费预算修改修改
        /// </summary>
        public bool LongCapitalPlanAdjustUpdate(string proc, int LongCapitalPlanAdjustId, double CapitalDial, double CapitalUse,
            double SumCapital, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12,
        string SumAdjust, string Adjust1, string Adjust2, string Adjust3, string Adjust4, string Adjust5, string Adjust6, string Adjust7, string Adjust8, string Adjust9, string Adjust10, string Adjust11, string Adjust12,
            double SumFinal, double Final1, double Final2, double Final3, double Final4, double Final5, double Final6, double Final7, double Final8, double Final9, double Final10, double Final11, double Final12,
            string SumExplain, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanAdjustId", SqlDbType.Int).Value = LongCapitalPlanAdjustId;
                    com.Parameters.Add("@CapitalDial", SqlDbType.Float).Value = CapitalDial;
                    com.Parameters.Add("@CapitalUse", SqlDbType.Float).Value = CapitalUse;

                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;

                    com.Parameters.Add("@SumAdjust", SqlDbType.VarChar, 50).Value = SumAdjust;
                    com.Parameters.Add("@OneAdjust", SqlDbType.VarChar, 50).Value = Adjust1;
                    com.Parameters.Add("@TwoAdjust", SqlDbType.VarChar, 50).Value = Adjust2;
                    com.Parameters.Add("@ThreeAdjust", SqlDbType.VarChar, 50).Value = Adjust3;
                    com.Parameters.Add("@ForeAdjust", SqlDbType.VarChar, 50).Value = Adjust4;
                    com.Parameters.Add("@FiveAdjust", SqlDbType.VarChar, 50).Value = Adjust5;
                    com.Parameters.Add("@SixAdjust", SqlDbType.VarChar, 50).Value = Adjust6;
                    com.Parameters.Add("@SevenAdjust", SqlDbType.VarChar, 50).Value = Adjust7;
                    com.Parameters.Add("@EightAdjust", SqlDbType.VarChar, 50).Value = Adjust8;
                    com.Parameters.Add("@NightAdjust", SqlDbType.VarChar, 50).Value = Adjust9;
                    com.Parameters.Add("@TenAdjust", SqlDbType.VarChar, 50).Value = Adjust10;
                    com.Parameters.Add("@EleventAdjust", SqlDbType.VarChar, 50).Value = Adjust11;
                    com.Parameters.Add("@TwelveAdjust", SqlDbType.VarChar, 50).Value = Adjust12;

                    com.Parameters.Add("@SumFinal", SqlDbType.Float).Value = SumFinal;
                    com.Parameters.Add("@OneFinal", SqlDbType.Float).Value = Final1;
                    com.Parameters.Add("@TwoFinal", SqlDbType.Float).Value = Final2;
                    com.Parameters.Add("@ThreeFinal", SqlDbType.Float).Value = Final3;
                    com.Parameters.Add("@ForeFinal", SqlDbType.Float).Value = Final4;
                    com.Parameters.Add("@FiveFinal", SqlDbType.Float).Value = Final5;
                    com.Parameters.Add("@SixFinal", SqlDbType.Float).Value = Final6;
                    com.Parameters.Add("@SevenFinal", SqlDbType.Float).Value = Final7;
                    com.Parameters.Add("@EightFinal", SqlDbType.Float).Value = Final8;
                    com.Parameters.Add("@NightFinal", SqlDbType.Float).Value = Final9;
                    com.Parameters.Add("@TenFinal", SqlDbType.Float).Value = Final10;
                    com.Parameters.Add("@EleventFinal", SqlDbType.Float).Value = Final11;
                    com.Parameters.Add("@TwelveFinal", SqlDbType.Float).Value = Final12;


                    com.Parameters.Add("@SumExplain", SqlDbType.VarChar, 100).Value = SumExplain;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 经费预算修改
        /// </summary>
        public bool LongCapitalPlanUpdate(string proc, int LongCapitalPlanId, string CapitalCome, double SumCapital, double SumCapitalTwo, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanId", SqlDbType.Int, 32).Value = LongCapitalPlanId;
                    com.Parameters.Add("@CapitalCome", SqlDbType.VarChar, 50).Value = CapitalCome;
                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@SumCapitalTwo", SqlDbType.Float).Value = SumCapitalTwo;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 资金预算审批添加
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlanExamineInsert(string proc, int LongCapitalPlanId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanId", SqlDbType.Int).Value = LongCapitalPlanId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 资金预算审批添加
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlanAdjustExamineInsert(string proc, int LongCapitalPlanAdjustId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlanAdjustId", SqlDbType.Int).Value = LongCapitalPlanAdjustId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 资金到位添加
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlaceInsert(string proc, string LongProjectsId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@PlaceMoney", SqlDbType.Float).Value = PlaceMoney;
                    com.Parameters.Add("@PlaceDate", SqlDbType.VarChar, 50).Value = PlaceDate;
                    com.Parameters.Add("@PlaceExplain", SqlDbType.VarChar, 100).Value = PlaceExplain;
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
        /// 资金到位修改
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlaceUpdate(string proc, int LongCapitalPlaceId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlaceId", SqlDbType.Int).Value = LongCapitalPlaceId;
                    com.Parameters.Add("@PlaceMoney", SqlDbType.Float).Value = PlaceMoney;
                    com.Parameters.Add("@PlaceDate", SqlDbType.VarChar, 50).Value = PlaceDate;
                    com.Parameters.Add("@PlaceExplain", SqlDbType.VarChar, 100).Value = PlaceExplain;
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
        /// 资金到位删除
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalPlaceDelete(string proc, int LongCapitalPlaceId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalPlaceId", SqlDbType.Int).Value = LongCapitalPlaceId;
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
        /// 按经费到位编号查询
        /// </summary>
        public DataSet SelectLongCapitalPlaceId(string proc, int LongCapitalPlaceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongCapitalPlaceId", SqlDbType.VarChar, 50).Value = LongCapitalPlaceId;
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

        /// <summary>
        /// 资金明细添加
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalDetailedInsert(string proc, string LongProjectsId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@CapitalContent", SqlDbType.VarChar, 50).Value = CapitalContent;
                    com.Parameters.Add("@CapitalMoney", SqlDbType.Float).Value = CapitalMoney;
                    com.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// 资金明细修改
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalDetailedUpdate(string proc, int LongCapitalDetailedId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalDetailedId", SqlDbType.Int).Value = LongCapitalDetailedId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@CapitalContent", SqlDbType.VarChar, 50).Value = CapitalContent;
                    com.Parameters.Add("@CapitalMoney", SqlDbType.Float).Value = CapitalMoney;
                    com.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// 资金明细删除
        /// </summary>
        /// <returns></returns>
        public bool LongCapitalDetailedDelete(string proc, int LongCapitalDetailedId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongCapitalDetailedId", SqlDbType.Int).Value = LongCapitalDetailedId;
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
        /// 按经费明细编号查询
        /// </summary>
        public DataSet SelectLongCapitalDetailedId(string proc, int LongCapitalDetailedId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongCapitalDetailedId", SqlDbType.VarChar, 50).Value = LongCapitalDetailedId;
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
        /// <summary>
        /// 按经费明细查询
        /// </summary>
        public DataSet SelectLongCapitalDetailed(string proc, string LongProjectsId, int CapitalItemId, string CapitalDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    sda.SelectCommand.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    sda.SelectCommand.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// <summary>
        /// 按经费预算编号查询
        /// </summary>
        public DataSet SelectLongCapitalPlanId(string proc, int LongCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongCapitalPlanId", SqlDbType.VarChar, 50).Value = LongCapitalPlanId;
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
        /// <summary>
        /// 按经费预算变更编号查询
        /// </summary>
        public DataSet SelectLongCapitalPlanAdjustId(string proc, int LongCapitalPlanAdjustId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongCapitalPlanAdjustId", SqlDbType.VarChar, 50).Value = LongCapitalPlanAdjustId;
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
        /// <summary>
        /// 经费决算添加
        /// </summary>


        public bool LongFinalCapitalInsert(string proc, string UserCardId, string FollDate, string LongProjectsId, string LongProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17, string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7,
            string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17, string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8,
            string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8, string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@LongProjectsName", SqlDbType.VarChar, 50).Value = LongProjectsName;
                    com.Parameters.Add("@Contract", SqlDbType.VarChar, 50).Value = Contract;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@OneCome", SqlDbType.VarChar, 50).Value = Come1;
                    com.Parameters.Add("@TwoCome", SqlDbType.VarChar, 50).Value = Come2;
                    com.Parameters.Add("@ThreeCome", SqlDbType.VarChar, 50).Value = Come3;
                    com.Parameters.Add("@ForeCome", SqlDbType.VarChar, 50).Value = Come4;
                    com.Parameters.Add("@FiveCome", SqlDbType.VarChar, 50).Value = Come5;
                    com.Parameters.Add("@SumCome", SqlDbType.VarChar, 50).Value = ComeSum;
                    com.Parameters.Add("@OnePlace", SqlDbType.VarChar, 50).Value = Place1;
                    com.Parameters.Add("@TwoPlace", SqlDbType.VarChar, 50).Value = Place2;
                    com.Parameters.Add("@ThreePlace", SqlDbType.VarChar, 50).Value = Place3;
                    com.Parameters.Add("@ForePlace", SqlDbType.VarChar, 50).Value = Place4;
                    com.Parameters.Add("@FivePlace", SqlDbType.VarChar, 50).Value = Place5;
                    com.Parameters.Add("@SumPlace", SqlDbType.VarChar, 50).Value = PlaceSum;
                    com.Parameters.Add("@OneCapital1", SqlDbType.VarChar, 50).Value = OneCapital1;
                    com.Parameters.Add("@OneCapital2", SqlDbType.VarChar, 50).Value = OneCapital2;
                    com.Parameters.Add("@OneCapital3", SqlDbType.VarChar, 50).Value = OneCapital3;
                    com.Parameters.Add("@OneCapital4", SqlDbType.VarChar, 50).Value = OneCapital4;
                    com.Parameters.Add("@OneCapital5", SqlDbType.VarChar, 50).Value = OneCapital5;
                    com.Parameters.Add("@OneCapital6", SqlDbType.VarChar, 50).Value = OneCapital6;
                    com.Parameters.Add("@OneCapital7", SqlDbType.VarChar, 50).Value = OneCapital7;
                    com.Parameters.Add("@OneCapital8", SqlDbType.VarChar, 50).Value = OneCapital8;
                    com.Parameters.Add("@OneCapital9", SqlDbType.VarChar, 50).Value = OneCapital9;
                    com.Parameters.Add("@OneCapital10", SqlDbType.VarChar, 50).Value = OneCapital10;
                    com.Parameters.Add("@OneCapital11", SqlDbType.VarChar, 50).Value = OneCapital11;
                    com.Parameters.Add("@OneCapital12", SqlDbType.VarChar, 50).Value = OneCapital12;
                    com.Parameters.Add("@OneCapital13", SqlDbType.VarChar, 50).Value = OneCapital13;
                    com.Parameters.Add("@OneCapital14", SqlDbType.VarChar, 50).Value = OneCapital14;
                    com.Parameters.Add("@OneCapital15", SqlDbType.VarChar, 50).Value = OneCapital15;
                    com.Parameters.Add("@OneCapital16", SqlDbType.VarChar, 50).Value = OneCapital16;
                    com.Parameters.Add("@OneCapital17", SqlDbType.VarChar, 50).Value = OneCapital17;
                    com.Parameters.Add("@TwoCapital1", SqlDbType.VarChar, 50).Value = TwoCapital1;
                    com.Parameters.Add("@TwoCapital2", SqlDbType.VarChar, 50).Value = TwoCapital2;
                    com.Parameters.Add("@TwoCapital3", SqlDbType.VarChar, 50).Value = TwoCapital3;
                    com.Parameters.Add("@TwoCapital4", SqlDbType.VarChar, 50).Value = TwoCapital4;
                    com.Parameters.Add("@TwoCapital5", SqlDbType.VarChar, 50).Value = TwoCapital5;
                    com.Parameters.Add("@TwoCapital6", SqlDbType.VarChar, 50).Value = TwoCapital6;
                    com.Parameters.Add("@TwoCapital7", SqlDbType.VarChar, 50).Value = TwoCapital7;
                    com.Parameters.Add("@TwoCapital8", SqlDbType.VarChar, 50).Value = TwoCapital8;
                    com.Parameters.Add("@TwoCapital9", SqlDbType.VarChar, 50).Value = TwoCapital9;
                    com.Parameters.Add("@TwoCapital10", SqlDbType.VarChar, 50).Value = TwoCapital10;
                    com.Parameters.Add("@TwoCapital11", SqlDbType.VarChar, 50).Value = TwoCapital11;
                    com.Parameters.Add("@TwoCapital12", SqlDbType.VarChar, 50).Value = TwoCapital12;
                    com.Parameters.Add("@TwoCapital13", SqlDbType.VarChar, 50).Value = TwoCapital13;
                    com.Parameters.Add("@TwoCapital14", SqlDbType.VarChar, 50).Value = TwoCapital14;
                    com.Parameters.Add("@TwoCapital15", SqlDbType.VarChar, 50).Value = TwoCapital15;
                    com.Parameters.Add("@TwoCapital16", SqlDbType.VarChar, 50).Value = TwoCapital16;
                    com.Parameters.Add("@TwoCapital17", SqlDbType.VarChar, 50).Value = TwoCapital17;
                    com.Parameters.Add("@ThreeCapital1", SqlDbType.VarChar, 50).Value = ThreeCapital1;
                    com.Parameters.Add("@ThreeCapital2", SqlDbType.VarChar, 50).Value = ThreeCapital2;
                    com.Parameters.Add("@ThreeCapital3", SqlDbType.VarChar, 50).Value = ThreeCapital3;
                    com.Parameters.Add("@ThreeCapital4", SqlDbType.VarChar, 50).Value = ThreeCapital4;
                    com.Parameters.Add("@ThreeCapital5", SqlDbType.VarChar, 50).Value = ThreeCapital5;
                    com.Parameters.Add("@ThreeCapital6", SqlDbType.VarChar, 50).Value = ThreeCapital6;
                    com.Parameters.Add("@ThreeCapital7", SqlDbType.VarChar, 50).Value = ThreeCapital7;
                    com.Parameters.Add("@ThreeCapital8", SqlDbType.VarChar, 50).Value = ThreeCapital8;
                    com.Parameters.Add("@ThreeCapital9", SqlDbType.VarChar, 50).Value = ThreeCapital9;
                    com.Parameters.Add("@ThreeCapital10", SqlDbType.VarChar, 50).Value = ThreeCapital10;
                    com.Parameters.Add("@ThreeCapital11", SqlDbType.VarChar, 50).Value = ThreeCapital11;
                    com.Parameters.Add("@ThreeCapital12", SqlDbType.VarChar, 50).Value = ThreeCapital12;
                    com.Parameters.Add("@ThreeCapital13", SqlDbType.VarChar, 50).Value = ThreeCapital13;
                    com.Parameters.Add("@ThreeCapital14", SqlDbType.VarChar, 50).Value = ThreeCapital14;
                    com.Parameters.Add("@ThreeCapital15", SqlDbType.VarChar, 50).Value = ThreeCapital15;
                    com.Parameters.Add("@ThreeCapital16", SqlDbType.VarChar, 50).Value = ThreeCapital16;
                    com.Parameters.Add("@ThreeCapital17", SqlDbType.VarChar, 50).Value = ThreeCapital17;
                    com.Parameters.Add("@ForeCapital1", SqlDbType.VarChar, 50).Value = ForeCapital1;
                    com.Parameters.Add("@ForeCapital2", SqlDbType.VarChar, 50).Value = ForeCapital2;
                    com.Parameters.Add("@ForeCapital3", SqlDbType.VarChar, 50).Value = ForeCapital3;
                    com.Parameters.Add("@ForeCapital4", SqlDbType.VarChar, 50).Value = ForeCapital4;
                    com.Parameters.Add("@ForeCapital5", SqlDbType.VarChar, 50).Value = ForeCapital5;
                    com.Parameters.Add("@ForeCapital6", SqlDbType.VarChar, 50).Value = ForeCapital6;
                    com.Parameters.Add("@ForeCapital7", SqlDbType.VarChar, 50).Value = ForeCapital7;
                    com.Parameters.Add("@ForeCapital8", SqlDbType.VarChar, 50).Value = ForeCapital8;
                    com.Parameters.Add("@ForeCapital9", SqlDbType.VarChar, 50).Value = ForeCapital9;
                    com.Parameters.Add("@ForeCapital10", SqlDbType.VarChar, 50).Value = ForeCapital10;
                    com.Parameters.Add("@ForeCapital11", SqlDbType.VarChar, 50).Value = ForeCapital11;
                    com.Parameters.Add("@ForeCapital12", SqlDbType.VarChar, 50).Value = ForeCapital12;
                    com.Parameters.Add("@ForeCapital13", SqlDbType.VarChar, 50).Value = ForeCapital13;
                    com.Parameters.Add("@ForeCapital14", SqlDbType.VarChar, 50).Value = ForeCapital14;
                    com.Parameters.Add("@ForeCapital15", SqlDbType.VarChar, 50).Value = ForeCapital15;
                    com.Parameters.Add("@ForeCapital16", SqlDbType.VarChar, 50).Value = ForeCapital16;
                    com.Parameters.Add("@ForeCapital17", SqlDbType.VarChar, 50).Value = ForeCapital17;
                    com.Parameters.Add("@Equipment1", SqlDbType.VarChar, 50).Value = Equipment1;
                    com.Parameters.Add("@Equipment2", SqlDbType.VarChar, 50).Value = Equipment2;
                    com.Parameters.Add("@Equipment3", SqlDbType.VarChar, 50).Value = Equipment3;
                    com.Parameters.Add("@Equipment4", SqlDbType.VarChar, 50).Value = Equipment4;
                    com.Parameters.Add("@Equipment5", SqlDbType.VarChar, 50).Value = Equipment5;
                    com.Parameters.Add("@Equipment6", SqlDbType.VarChar, 50).Value = Equipment6;
                    com.Parameters.Add("@Equipment7", SqlDbType.VarChar, 50).Value = Equipment7;
                    com.Parameters.Add("@Equipment8", SqlDbType.VarChar, 50).Value = Equipment8;
                    com.Parameters.Add("@Company1", SqlDbType.VarChar, 50).Value = Company1;
                    com.Parameters.Add("@Company2", SqlDbType.VarChar, 50).Value = Company2;
                    com.Parameters.Add("@Company3", SqlDbType.VarChar, 50).Value = Company3;
                    com.Parameters.Add("@Company4", SqlDbType.VarChar, 50).Value = Company4;
                    com.Parameters.Add("@Company5", SqlDbType.VarChar, 50).Value = Company5;
                    com.Parameters.Add("@Company6", SqlDbType.VarChar, 50).Value = Company6;
                    com.Parameters.Add("@Company7", SqlDbType.VarChar, 50).Value = Company7;
                    com.Parameters.Add("@Company8", SqlDbType.VarChar, 50).Value = Company8;
                    com.Parameters.Add("@Number1", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@Number2", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@Number3", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@Number4", SqlDbType.VarChar, 50).Value = Number4;
                    com.Parameters.Add("@Number5", SqlDbType.VarChar, 50).Value = Number5;
                    com.Parameters.Add("@Number6", SqlDbType.VarChar, 50).Value = Number6;
                    com.Parameters.Add("@Number7", SqlDbType.VarChar, 50).Value = Number7;
                    com.Parameters.Add("@Number8", SqlDbType.VarChar, 50).Value = Number8;
                    com.Parameters.Add("@Price1", SqlDbType.VarChar, 50).Value = Price1;
                    com.Parameters.Add("@Price2", SqlDbType.VarChar, 50).Value = Price2;
                    com.Parameters.Add("@Price3", SqlDbType.VarChar, 50).Value = Price3;
                    com.Parameters.Add("@Price4", SqlDbType.VarChar, 50).Value = Price4;
                    com.Parameters.Add("@Price5", SqlDbType.VarChar, 50).Value = Price5;
                    com.Parameters.Add("@Price6", SqlDbType.VarChar, 50).Value = Price6;
                    com.Parameters.Add("@Price7", SqlDbType.VarChar, 50).Value = Price7;
                    com.Parameters.Add("@Price8", SqlDbType.VarChar, 50).Value = Price8;
                    com.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    com.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
                    com.Parameters.Add("@Money3", SqlDbType.VarChar, 50).Value = Money3;
                    com.Parameters.Add("@Money4", SqlDbType.VarChar, 50).Value = Money4;
                    com.Parameters.Add("@Money5", SqlDbType.VarChar, 50).Value = Money5;
                    com.Parameters.Add("@Money6", SqlDbType.VarChar, 50).Value = Money6;
                    com.Parameters.Add("@Money7", SqlDbType.VarChar, 50).Value = Money7;
                    com.Parameters.Add("@Money8", SqlDbType.VarChar, 50).Value = Money8;
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
        /// 经费决算修改
        /// </summary>


        public bool LongFinalCapitalUpdate(string proc, int LongFinalCapitalId, string LongProjectsId, string LongProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17,
            string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7, string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17,
            string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8, string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8,
            string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongFinalCapitalId", SqlDbType.Int).Value = LongFinalCapitalId;
                    com.Parameters.Add("@LongProjectsId", SqlDbType.VarChar, 50).Value = LongProjectsId;
                    com.Parameters.Add("@LongProjectsName", SqlDbType.VarChar, 50).Value = LongProjectsName;
                    com.Parameters.Add("@Contract", SqlDbType.VarChar, 50).Value = Contract;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@OneCome", SqlDbType.VarChar, 50).Value = Come1;
                    com.Parameters.Add("@TwoCome", SqlDbType.VarChar, 50).Value = Come2;
                    com.Parameters.Add("@ThreeCome", SqlDbType.VarChar, 50).Value = Come3;
                    com.Parameters.Add("@ForeCome", SqlDbType.VarChar, 50).Value = Come4;
                    com.Parameters.Add("@FiveCome", SqlDbType.VarChar, 50).Value = Come5;
                    com.Parameters.Add("@SumCome", SqlDbType.VarChar, 50).Value = ComeSum;
                    com.Parameters.Add("@OnePlace", SqlDbType.VarChar, 50).Value = Place1;
                    com.Parameters.Add("@TwoPlace", SqlDbType.VarChar, 50).Value = Place2;
                    com.Parameters.Add("@ThreePlace", SqlDbType.VarChar, 50).Value = Place3;
                    com.Parameters.Add("@ForePlace", SqlDbType.VarChar, 50).Value = Place4;
                    com.Parameters.Add("@FivePlace", SqlDbType.VarChar, 50).Value = Place5;
                    com.Parameters.Add("@SumPlace", SqlDbType.VarChar, 50).Value = PlaceSum;
                    com.Parameters.Add("@OneCapital1", SqlDbType.VarChar, 50).Value = OneCapital1;
                    com.Parameters.Add("@OneCapital2", SqlDbType.VarChar, 50).Value = OneCapital2;
                    com.Parameters.Add("@OneCapital3", SqlDbType.VarChar, 50).Value = OneCapital3;
                    com.Parameters.Add("@OneCapital4", SqlDbType.VarChar, 50).Value = OneCapital4;
                    com.Parameters.Add("@OneCapital5", SqlDbType.VarChar, 50).Value = OneCapital5;
                    com.Parameters.Add("@OneCapital6", SqlDbType.VarChar, 50).Value = OneCapital6;
                    com.Parameters.Add("@OneCapital7", SqlDbType.VarChar, 50).Value = OneCapital7;
                    com.Parameters.Add("@OneCapital8", SqlDbType.VarChar, 50).Value = OneCapital8;
                    com.Parameters.Add("@OneCapital9", SqlDbType.VarChar, 50).Value = OneCapital9;
                    com.Parameters.Add("@OneCapital10", SqlDbType.VarChar, 50).Value = OneCapital10;
                    com.Parameters.Add("@OneCapital11", SqlDbType.VarChar, 50).Value = OneCapital11;
                    com.Parameters.Add("@OneCapital12", SqlDbType.VarChar, 50).Value = OneCapital12;
                    com.Parameters.Add("@OneCapital13", SqlDbType.VarChar, 50).Value = OneCapital13;
                    com.Parameters.Add("@OneCapital14", SqlDbType.VarChar, 50).Value = OneCapital14;
                    com.Parameters.Add("@OneCapital15", SqlDbType.VarChar, 50).Value = OneCapital15;
                    com.Parameters.Add("@OneCapital16", SqlDbType.VarChar, 50).Value = OneCapital16;
                    com.Parameters.Add("@OneCapital17", SqlDbType.VarChar, 50).Value = OneCapital17;
                    com.Parameters.Add("@TwoCapital1", SqlDbType.VarChar, 50).Value = TwoCapital1;
                    com.Parameters.Add("@TwoCapital2", SqlDbType.VarChar, 50).Value = TwoCapital2;
                    com.Parameters.Add("@TwoCapital3", SqlDbType.VarChar, 50).Value = TwoCapital3;
                    com.Parameters.Add("@TwoCapital4", SqlDbType.VarChar, 50).Value = TwoCapital4;
                    com.Parameters.Add("@TwoCapital5", SqlDbType.VarChar, 50).Value = TwoCapital5;
                    com.Parameters.Add("@TwoCapital6", SqlDbType.VarChar, 50).Value = TwoCapital6;
                    com.Parameters.Add("@TwoCapital7", SqlDbType.VarChar, 50).Value = TwoCapital7;
                    com.Parameters.Add("@TwoCapital8", SqlDbType.VarChar, 50).Value = TwoCapital8;
                    com.Parameters.Add("@TwoCapital9", SqlDbType.VarChar, 50).Value = TwoCapital9;
                    com.Parameters.Add("@TwoCapital10", SqlDbType.VarChar, 50).Value = TwoCapital10;
                    com.Parameters.Add("@TwoCapital11", SqlDbType.VarChar, 50).Value = TwoCapital11;
                    com.Parameters.Add("@TwoCapital12", SqlDbType.VarChar, 50).Value = TwoCapital12;
                    com.Parameters.Add("@TwoCapital13", SqlDbType.VarChar, 50).Value = TwoCapital13;
                    com.Parameters.Add("@TwoCapital14", SqlDbType.VarChar, 50).Value = TwoCapital14;
                    com.Parameters.Add("@TwoCapital15", SqlDbType.VarChar, 50).Value = TwoCapital15;
                    com.Parameters.Add("@TwoCapital16", SqlDbType.VarChar, 50).Value = TwoCapital16;
                    com.Parameters.Add("@TwoCapital17", SqlDbType.VarChar, 50).Value = TwoCapital17;
                    com.Parameters.Add("@ThreeCapital1", SqlDbType.VarChar, 50).Value = ThreeCapital1;
                    com.Parameters.Add("@ThreeCapital2", SqlDbType.VarChar, 50).Value = ThreeCapital2;
                    com.Parameters.Add("@ThreeCapital3", SqlDbType.VarChar, 50).Value = ThreeCapital3;
                    com.Parameters.Add("@ThreeCapital4", SqlDbType.VarChar, 50).Value = ThreeCapital4;
                    com.Parameters.Add("@ThreeCapital5", SqlDbType.VarChar, 50).Value = ThreeCapital5;
                    com.Parameters.Add("@ThreeCapital6", SqlDbType.VarChar, 50).Value = ThreeCapital6;
                    com.Parameters.Add("@ThreeCapital7", SqlDbType.VarChar, 50).Value = ThreeCapital7;
                    com.Parameters.Add("@ThreeCapital8", SqlDbType.VarChar, 50).Value = ThreeCapital8;
                    com.Parameters.Add("@ThreeCapital9", SqlDbType.VarChar, 50).Value = ThreeCapital9;
                    com.Parameters.Add("@ThreeCapital10", SqlDbType.VarChar, 50).Value = ThreeCapital10;
                    com.Parameters.Add("@ThreeCapital11", SqlDbType.VarChar, 50).Value = ThreeCapital11;
                    com.Parameters.Add("@ThreeCapital12", SqlDbType.VarChar, 50).Value = ThreeCapital12;
                    com.Parameters.Add("@ThreeCapital13", SqlDbType.VarChar, 50).Value = ThreeCapital13;
                    com.Parameters.Add("@ThreeCapital14", SqlDbType.VarChar, 50).Value = ThreeCapital14;
                    com.Parameters.Add("@ThreeCapital15", SqlDbType.VarChar, 50).Value = ThreeCapital15;
                    com.Parameters.Add("@ThreeCapital16", SqlDbType.VarChar, 50).Value = ThreeCapital16;
                    com.Parameters.Add("@ThreeCapital17", SqlDbType.VarChar, 50).Value = ThreeCapital17;
                    com.Parameters.Add("@ForeCapital1", SqlDbType.VarChar, 50).Value = ForeCapital1;
                    com.Parameters.Add("@ForeCapital2", SqlDbType.VarChar, 50).Value = ForeCapital2;
                    com.Parameters.Add("@ForeCapital3", SqlDbType.VarChar, 50).Value = ForeCapital3;
                    com.Parameters.Add("@ForeCapital4", SqlDbType.VarChar, 50).Value = ForeCapital4;
                    com.Parameters.Add("@ForeCapital5", SqlDbType.VarChar, 50).Value = ForeCapital5;
                    com.Parameters.Add("@ForeCapital6", SqlDbType.VarChar, 50).Value = ForeCapital6;
                    com.Parameters.Add("@ForeCapital7", SqlDbType.VarChar, 50).Value = ForeCapital7;
                    com.Parameters.Add("@ForeCapital8", SqlDbType.VarChar, 50).Value = ForeCapital8;
                    com.Parameters.Add("@ForeCapital9", SqlDbType.VarChar, 50).Value = ForeCapital9;
                    com.Parameters.Add("@ForeCapital10", SqlDbType.VarChar, 50).Value = ForeCapital10;
                    com.Parameters.Add("@ForeCapital11", SqlDbType.VarChar, 50).Value = ForeCapital11;
                    com.Parameters.Add("@ForeCapital12", SqlDbType.VarChar, 50).Value = ForeCapital12;
                    com.Parameters.Add("@ForeCapital13", SqlDbType.VarChar, 50).Value = ForeCapital13;
                    com.Parameters.Add("@ForeCapital14", SqlDbType.VarChar, 50).Value = ForeCapital14;
                    com.Parameters.Add("@ForeCapital15", SqlDbType.VarChar, 50).Value = ForeCapital15;
                    com.Parameters.Add("@ForeCapital16", SqlDbType.VarChar, 50).Value = ForeCapital16;
                    com.Parameters.Add("@ForeCapital17", SqlDbType.VarChar, 50).Value = ForeCapital17;
                    com.Parameters.Add("@Equipment1", SqlDbType.VarChar, 50).Value = Equipment1;
                    com.Parameters.Add("@Equipment2", SqlDbType.VarChar, 50).Value = Equipment2;
                    com.Parameters.Add("@Equipment3", SqlDbType.VarChar, 50).Value = Equipment3;
                    com.Parameters.Add("@Equipment4", SqlDbType.VarChar, 50).Value = Equipment4;
                    com.Parameters.Add("@Equipment5", SqlDbType.VarChar, 50).Value = Equipment5;
                    com.Parameters.Add("@Equipment6", SqlDbType.VarChar, 50).Value = Equipment6;
                    com.Parameters.Add("@Equipment7", SqlDbType.VarChar, 50).Value = Equipment7;
                    com.Parameters.Add("@Equipment8", SqlDbType.VarChar, 50).Value = Equipment8;
                    com.Parameters.Add("@Company1", SqlDbType.VarChar, 50).Value = Company1;
                    com.Parameters.Add("@Company2", SqlDbType.VarChar, 50).Value = Company2;
                    com.Parameters.Add("@Company3", SqlDbType.VarChar, 50).Value = Company3;
                    com.Parameters.Add("@Company4", SqlDbType.VarChar, 50).Value = Company4;
                    com.Parameters.Add("@Company5", SqlDbType.VarChar, 50).Value = Company5;
                    com.Parameters.Add("@Company6", SqlDbType.VarChar, 50).Value = Company6;
                    com.Parameters.Add("@Company7", SqlDbType.VarChar, 50).Value = Company7;
                    com.Parameters.Add("@Company8", SqlDbType.VarChar, 50).Value = Company8;
                    com.Parameters.Add("@Number1", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@Number2", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@Number3", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@Number4", SqlDbType.VarChar, 50).Value = Number4;
                    com.Parameters.Add("@Number5", SqlDbType.VarChar, 50).Value = Number5;
                    com.Parameters.Add("@Number6", SqlDbType.VarChar, 50).Value = Number6;
                    com.Parameters.Add("@Number7", SqlDbType.VarChar, 50).Value = Number7;
                    com.Parameters.Add("@Number8", SqlDbType.VarChar, 50).Value = Number8;
                    com.Parameters.Add("@Price1", SqlDbType.VarChar, 50).Value = Price1;
                    com.Parameters.Add("@Price2", SqlDbType.VarChar, 50).Value = Price2;
                    com.Parameters.Add("@Price3", SqlDbType.VarChar, 50).Value = Price3;
                    com.Parameters.Add("@Price4", SqlDbType.VarChar, 50).Value = Price4;
                    com.Parameters.Add("@Price5", SqlDbType.VarChar, 50).Value = Price5;
                    com.Parameters.Add("@Price6", SqlDbType.VarChar, 50).Value = Price6;
                    com.Parameters.Add("@Price7", SqlDbType.VarChar, 50).Value = Price7;
                    com.Parameters.Add("@Price8", SqlDbType.VarChar, 50).Value = Price8;
                    com.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    com.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
                    com.Parameters.Add("@Money3", SqlDbType.VarChar, 50).Value = Money3;
                    com.Parameters.Add("@Money4", SqlDbType.VarChar, 50).Value = Money4;
                    com.Parameters.Add("@Money5", SqlDbType.VarChar, 50).Value = Money5;
                    com.Parameters.Add("@Money6", SqlDbType.VarChar, 50).Value = Money6;
                    com.Parameters.Add("@Money7", SqlDbType.VarChar, 50).Value = Money7;
                    com.Parameters.Add("@Money8", SqlDbType.VarChar, 50).Value = Money8;
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
        /// 经费决算删除
        /// </summary>
        public bool LongFinalCapitalDelete(string proc, int LongFinalCapitalId, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LongFinalCapitalId", SqlDbType.Int).Value = LongFinalCapitalId;

                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar).Value = UserCardId;
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
        /// 按经费决算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongFinalCapitalId(string proc, int LongFinalCapitalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LongFinalCapitalId", SqlDbType.VarChar, 50).Value = LongFinalCapitalId;
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

        /// <summary>
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsLongCapital(string proc, string ProjectsId, string ProjectsName, string Company, double Money1, double Money2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 50).Value = ProjectsName;
                    sda.SelectCommand.Parameters.Add("@ProjectsId", SqlDbType.VarChar, 50).Value = ProjectsId;
                    sda.SelectCommand.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    sda.SelectCommand.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    sda.SelectCommand.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
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
        /// <summary>
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsLongCapitalPlan(string proc, string UserName, string DepartmentName, string ProjectsName, string ProjectsId, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentName;
                    sda.SelectCommand.Parameters.Add("@ProjectsName", SqlDbType.VarChar, 50).Value = ProjectsName;
                    sda.SelectCommand.Parameters.Add("@ProjectsId", SqlDbType.VarChar, 50).Value = ProjectsId;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        #endregion
        #region 横向
        /// <summary>
        /// 纵向经费基本情况保存
        /// </summary>
        public bool ShortCapitalBasicSituationInsert(string proc, string ShortProjectsId, double BidMoney, double SupportMoney, double OtherMoney, string SuedCompany, string Servicelife)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@BidMoney", SqlDbType.Float).Value = BidMoney;
                    com.Parameters.Add("@SupportMoney", SqlDbType.Float).Value = SupportMoney;
                    com.Parameters.Add("@OtherMoney", SqlDbType.Float).Value = OtherMoney;
                    com.Parameters.Add("@SuedCompany", SqlDbType.VarChar, 50).Value = SuedCompany;
                    com.Parameters.Add("@Servicelife", SqlDbType.VarChar, 50).Value = Servicelife;

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
        /// 横向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlanProcessDelete(string proc, int ShortCapitalPlanProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanProcessId", SqlDbType.Int).Value = ShortCapitalPlanProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 横向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalCloseProcessDelete(string proc, int ShortCapitalCloseProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalCloseProcessId", SqlDbType.Int).Value = ShortCapitalCloseProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 横向经费流程流程删除
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalChangeProcessDelete(string proc, int ShortCapitalChangeProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalChangeProcessId", SqlDbType.Int).Value = ShortCapitalChangeProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 项目经费预算删除

        public bool ShortCapitalPlanDelete(string proc, int ShortCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanId", SqlDbType.VarChar, 50).Value = ShortCapitalPlanId;

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
        /// 经费预算添加
        /// </summary>
        public bool ShortCapitalPlanInsert(string proc, string ShortProjectsId, string UserCardId, string FileUrl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FileUrl", SqlDbType.Text).Value = FileUrl;
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
        /// 经费预算修改添加
        /// </summary>
        public bool ShortCapitalPlanAdjustInsert(string proc, string ShortProjectsId, string UserCardId, double CapitalDial, double CapitalUse,
        double SumCapital, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12,
        string SumAdjust, string Adjust1, string Adjust2, string Adjust3, string Adjust4, string Adjust5, string Adjust6, string Adjust7, string Adjust8, string Adjust9, string Adjust10, string Adjust11, string Adjust12,
            double SumFinal, double Final1, double Final2, double Final3, double Final4, double Final5, double Final6, double Final7, double Final8, double Final9, double Final10, double Final11, double Final12,
            string SumExplain, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@CapitalDial", SqlDbType.Float).Value = CapitalDial;
                    com.Parameters.Add("@CapitalUse", SqlDbType.Float).Value = CapitalUse;

                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;

                    com.Parameters.Add("@SumAdjust", SqlDbType.VarChar, 50).Value = SumAdjust;
                    com.Parameters.Add("@OneAdjust", SqlDbType.VarChar, 50).Value = Adjust1;
                    com.Parameters.Add("@TwoAdjust", SqlDbType.VarChar, 50).Value = Adjust2;
                    com.Parameters.Add("@ThreeAdjust", SqlDbType.VarChar, 50).Value = Adjust3;
                    com.Parameters.Add("@ForeAdjust", SqlDbType.VarChar, 50).Value = Adjust4;
                    com.Parameters.Add("@FiveAdjust", SqlDbType.VarChar, 50).Value = Adjust5;
                    com.Parameters.Add("@SixAdjust", SqlDbType.VarChar, 50).Value = Adjust6;
                    com.Parameters.Add("@SevenAdjust", SqlDbType.VarChar, 50).Value = Adjust7;
                    com.Parameters.Add("@EightAdjust", SqlDbType.VarChar, 50).Value = Adjust8;
                    com.Parameters.Add("@NightAdjust", SqlDbType.VarChar, 50).Value = Adjust9;
                    com.Parameters.Add("@TenAdjust", SqlDbType.VarChar, 50).Value = Adjust10;
                    com.Parameters.Add("@EleventAdjust", SqlDbType.VarChar, 50).Value = Adjust11;
                    com.Parameters.Add("@TwelveAdjust", SqlDbType.VarChar, 50).Value = Adjust12;

                    com.Parameters.Add("@SumFinal", SqlDbType.Float).Value = SumFinal;
                    com.Parameters.Add("@OneFinal", SqlDbType.Float).Value = Final1;
                    com.Parameters.Add("@TwoFinal", SqlDbType.Float).Value = Final2;
                    com.Parameters.Add("@ThreeFinal", SqlDbType.Float).Value = Final3;
                    com.Parameters.Add("@ForeFinal", SqlDbType.Float).Value = Final4;
                    com.Parameters.Add("@FiveFinal", SqlDbType.Float).Value = Final5;
                    com.Parameters.Add("@SixFinal", SqlDbType.Float).Value = Final6;
                    com.Parameters.Add("@SevenFinal", SqlDbType.Float).Value = Final7;
                    com.Parameters.Add("@EightFinal", SqlDbType.Float).Value = Final8;
                    com.Parameters.Add("@NightFinal", SqlDbType.Float).Value = Final9;
                    com.Parameters.Add("@TenFinal", SqlDbType.Float).Value = Final10;
                    com.Parameters.Add("@EleventFinal", SqlDbType.Float).Value = Final11;
                    com.Parameters.Add("@TwelveFinal", SqlDbType.Float).Value = Final12;


                    com.Parameters.Add("@SumExplain", SqlDbType.VarChar, 100).Value = SumExplain;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 经费预算修改修改
        /// </summary>
        public bool ShortCapitalPlanAdjustUpdate(string proc, int ShortCapitalPlanAdjustId, double CapitalDial, double CapitalUse,
            double SumCapital, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12,
        string SumAdjust, string Adjust1, string Adjust2, string Adjust3, string Adjust4, string Adjust5, string Adjust6, string Adjust7, string Adjust8, string Adjust9, string Adjust10, string Adjust11, string Adjust12,
            double SumFinal, double Final1, double Final2, double Final3, double Final4, double Final5, double Final6, double Final7, double Final8, double Final9, double Final10, double Final11, double Final12,
            string SumExplain, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanAdjustId", SqlDbType.Int).Value = ShortCapitalPlanAdjustId;
                    com.Parameters.Add("@CapitalDial", SqlDbType.Float).Value = CapitalDial;
                    com.Parameters.Add("@CapitalUse", SqlDbType.Float).Value = CapitalUse;

                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;

                    com.Parameters.Add("@SumAdjust", SqlDbType.VarChar, 50).Value = SumAdjust;
                    com.Parameters.Add("@OneAdjust", SqlDbType.VarChar, 50).Value = Adjust1;
                    com.Parameters.Add("@TwoAdjust", SqlDbType.VarChar, 50).Value = Adjust2;
                    com.Parameters.Add("@ThreeAdjust", SqlDbType.VarChar, 50).Value = Adjust3;
                    com.Parameters.Add("@ForeAdjust", SqlDbType.VarChar, 50).Value = Adjust4;
                    com.Parameters.Add("@FiveAdjust", SqlDbType.VarChar, 50).Value = Adjust5;
                    com.Parameters.Add("@SixAdjust", SqlDbType.VarChar, 50).Value = Adjust6;
                    com.Parameters.Add("@SevenAdjust", SqlDbType.VarChar, 50).Value = Adjust7;
                    com.Parameters.Add("@EightAdjust", SqlDbType.VarChar, 50).Value = Adjust8;
                    com.Parameters.Add("@NightAdjust", SqlDbType.VarChar, 50).Value = Adjust9;
                    com.Parameters.Add("@TenAdjust", SqlDbType.VarChar, 50).Value = Adjust10;
                    com.Parameters.Add("@EleventAdjust", SqlDbType.VarChar, 50).Value = Adjust11;
                    com.Parameters.Add("@TwelveAdjust", SqlDbType.VarChar, 50).Value = Adjust12;

                    com.Parameters.Add("@SumFinal", SqlDbType.Float).Value = SumFinal;
                    com.Parameters.Add("@OneFinal", SqlDbType.Float).Value = Final1;
                    com.Parameters.Add("@TwoFinal", SqlDbType.Float).Value = Final2;
                    com.Parameters.Add("@ThreeFinal", SqlDbType.Float).Value = Final3;
                    com.Parameters.Add("@ForeFinal", SqlDbType.Float).Value = Final4;
                    com.Parameters.Add("@FiveFinal", SqlDbType.Float).Value = Final5;
                    com.Parameters.Add("@SixFinal", SqlDbType.Float).Value = Final6;
                    com.Parameters.Add("@SevenFinal", SqlDbType.Float).Value = Final7;
                    com.Parameters.Add("@EightFinal", SqlDbType.Float).Value = Final8;
                    com.Parameters.Add("@NightFinal", SqlDbType.Float).Value = Final9;
                    com.Parameters.Add("@TenFinal", SqlDbType.Float).Value = Final10;
                    com.Parameters.Add("@EleventFinal", SqlDbType.Float).Value = Final11;
                    com.Parameters.Add("@TwelveFinal", SqlDbType.Float).Value = Final12;


                    com.Parameters.Add("@SumExplain", SqlDbType.VarChar, 100).Value = SumExplain;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 经费预算修改
        /// </summary>
        public bool ShortCapitalPlanUpdate(string proc, int ShortCapitalPlanId, string CapitalCome, double SumCapital, double SumCapitalTwo, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanId", SqlDbType.Int).Value = ShortCapitalPlanId;
                    com.Parameters.Add("@CapitalCome", SqlDbType.VarChar, 50).Value = CapitalCome;
                    com.Parameters.Add("@SumCapital", SqlDbType.Float).Value = SumCapital;
                    com.Parameters.Add("@SumCapitalTwo", SqlDbType.Float).Value = SumCapitalTwo;
                    com.Parameters.Add("@OneCapital", SqlDbType.Float).Value = Capital1;
                    com.Parameters.Add("@TwoCapital", SqlDbType.Float).Value = Capital2;
                    com.Parameters.Add("@ThreeCapital", SqlDbType.Float).Value = Capital3;
                    com.Parameters.Add("@ForeCapital", SqlDbType.Float).Value = Capital4;
                    com.Parameters.Add("@FiveCapital", SqlDbType.Float).Value = Capital5;
                    com.Parameters.Add("@SixCapital", SqlDbType.Float).Value = Capital6;
                    com.Parameters.Add("@SevenCapital", SqlDbType.Float).Value = Capital7;
                    com.Parameters.Add("@EightCapital", SqlDbType.Float).Value = Capital8;
                    com.Parameters.Add("@NightCapital", SqlDbType.Float).Value = Capital9;
                    com.Parameters.Add("@TenCapital", SqlDbType.Float).Value = Capital10;
                    com.Parameters.Add("@EleventCapital", SqlDbType.Float).Value = Capital11;
                    com.Parameters.Add("@TwelveCapital", SqlDbType.Float).Value = Capital12;
                    com.Parameters.Add("@OneExplain", SqlDbType.VarChar, 100).Value = Explain1;
                    com.Parameters.Add("@TwoExplain", SqlDbType.VarChar, 100).Value = Explain2;
                    com.Parameters.Add("@ThreeExplain", SqlDbType.VarChar, 100).Value = Explain3;
                    com.Parameters.Add("@ForeExplain", SqlDbType.VarChar, 100).Value = Explain4;
                    com.Parameters.Add("@FiveExplain", SqlDbType.VarChar, 100).Value = Explain5;
                    com.Parameters.Add("@SixExplain", SqlDbType.VarChar, 100).Value = Explain6;
                    com.Parameters.Add("@SevenExplain", SqlDbType.VarChar, 100).Value = Explain7;
                    com.Parameters.Add("@EightExplain", SqlDbType.VarChar, 100).Value = Explain8;
                    com.Parameters.Add("@NightExplain", SqlDbType.VarChar, 100).Value = Explain9;
                    com.Parameters.Add("@TenExplain", SqlDbType.VarChar, 100).Value = Explain10;
                    com.Parameters.Add("@EleventExplain", SqlDbType.VarChar, 100).Value = Explain11;
                    com.Parameters.Add("@TwelveExplain", SqlDbType.VarChar, 100).Value = Explain12;
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
        /// 资金预算审批添加
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlanExamineInsert(string proc, int ShortCapitalPlanId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanId", SqlDbType.Int).Value = ShortCapitalPlanId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 资金预算审批添加
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlanAdjustExamineInsert(string proc, int ShortCapitalPlanAdjustId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlanAdjustId", SqlDbType.Int).Value = ShortCapitalPlanAdjustId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsShortCapital(string proc, string ContractId, string ContractName, string Company, double Money1, double Money2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ContractName", SqlDbType.VarChar, 50).Value = ContractName;
                    sda.SelectCommand.Parameters.Add("@ContractId", SqlDbType.VarChar, 50).Value = ContractId;
                    sda.SelectCommand.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    sda.SelectCommand.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    sda.SelectCommand.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
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

        /// <summary>
        /// 资金到位添加
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlaceInsert(string proc, string ShortProjectsId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@PlaceMoney", SqlDbType.Float).Value = PlaceMoney;
                    com.Parameters.Add("@PlaceDate", SqlDbType.VarChar, 50).Value = PlaceDate;
                    com.Parameters.Add("@PlaceExplain", SqlDbType.VarChar, 100).Value = PlaceExplain;
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
        /// 资金到位修改
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlaceUpdate(string proc, int ShortCapitalPlaceId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlaceId", SqlDbType.Int).Value = ShortCapitalPlaceId;
                    com.Parameters.Add("@PlaceMoney", SqlDbType.Float).Value = PlaceMoney;
                    com.Parameters.Add("@PlaceDate", SqlDbType.VarChar, 50).Value = PlaceDate;
                    com.Parameters.Add("@PlaceExplain", SqlDbType.VarChar, 100).Value = PlaceExplain;
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
        /// 资金到位删除
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalPlaceDelete(string proc, int ShortCapitalPlaceId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalPlaceId", SqlDbType.Int).Value = ShortCapitalPlaceId;
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
        /// 按经费到位编号查询
        /// </summary>
        public DataSet SelectShortCapitalPlaceId(string proc, int ShortCapitalPlaceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortCapitalPlaceId", SqlDbType.VarChar, 50).Value = ShortCapitalPlaceId;
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

        /// <summary>
        /// 资金明细添加
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalDetailedInsert(string proc, string ShortProjectsId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@CapitalContent", SqlDbType.VarChar, 50).Value = CapitalContent;
                    com.Parameters.Add("@CapitalMoney", SqlDbType.Float).Value = CapitalMoney;
                    com.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// 资金明细修改
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalDetailedUpdate(string proc, int ShortCapitalDetailedId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalDetailedId", SqlDbType.Int).Value = ShortCapitalDetailedId;
                    com.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    com.Parameters.Add("@CapitalContent", SqlDbType.VarChar, 50).Value = CapitalContent;
                    com.Parameters.Add("@CapitalMoney", SqlDbType.Float).Value = CapitalMoney;
                    com.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// 资金明细删除
        /// </summary>
        /// <returns></returns>
        public bool ShortCapitalDetailedDelete(string proc, int ShortCapitalDetailedId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortCapitalDetailedId", SqlDbType.Int).Value = ShortCapitalDetailedId;
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
        /// 按经费明细编号查询
        /// </summary>
        public DataSet SelectShortCapitalDetailedId(string proc, int ShortCapitalDetailedId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortCapitalDetailedId", SqlDbType.VarChar, 50).Value = ShortCapitalDetailedId;
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
        /// <summary>
        /// 按经费明细查询
        /// </summary>
        public DataSet SelectShortCapitalDetailed(string proc, string ShortProjectsId, int CapitalItemId, string CapitalDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    sda.SelectCommand.Parameters.Add("@CapitalItemId", SqlDbType.Int).Value = CapitalItemId;
                    sda.SelectCommand.Parameters.Add("@CapitalDate", SqlDbType.VarChar, 50).Value = CapitalDate;
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
        /// <summary>
        /// 按经费预算编号查询
        /// </summary>
        public DataSet SelectShortCapitalPlanId(string proc, int ShortCapitalPlanId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortCapitalPlanId", SqlDbType.VarChar, 50).Value = ShortCapitalPlanId;
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
        /// <summary>
        /// 按经费预算变更编号查询
        /// </summary>
        public DataSet SelectShortCapitalPlanAdjustId(string proc, int ShortCapitalPlanAdjustId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortCapitalPlanAdjustId", SqlDbType.VarChar, 50).Value = ShortCapitalPlanAdjustId;
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
        /// <summary>
        /// 经费决算添加
        /// </summary>


        public bool ShortFinalCapitalInsert(string proc, string UserCardId, string FollDate, string ShortProjectsId, string ShortProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17, string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7,
            string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17, string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8,
            string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8, string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@ShortProjectsName", SqlDbType.VarChar, 50).Value = ShortProjectsName;
                    com.Parameters.Add("@Contract", SqlDbType.VarChar, 50).Value = Contract;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@OneCome", SqlDbType.VarChar, 50).Value = Come1;
                    com.Parameters.Add("@TwoCome", SqlDbType.VarChar, 50).Value = Come2;
                    com.Parameters.Add("@ThreeCome", SqlDbType.VarChar, 50).Value = Come3;
                    com.Parameters.Add("@ForeCome", SqlDbType.VarChar, 50).Value = Come4;
                    com.Parameters.Add("@FiveCome", SqlDbType.VarChar, 50).Value = Come5;
                    com.Parameters.Add("@SumCome", SqlDbType.VarChar, 50).Value = ComeSum;
                    com.Parameters.Add("@OnePlace", SqlDbType.VarChar, 50).Value = Place1;
                    com.Parameters.Add("@TwoPlace", SqlDbType.VarChar, 50).Value = Place2;
                    com.Parameters.Add("@ThreePlace", SqlDbType.VarChar, 50).Value = Place3;
                    com.Parameters.Add("@ForePlace", SqlDbType.VarChar, 50).Value = Place4;
                    com.Parameters.Add("@FivePlace", SqlDbType.VarChar, 50).Value = Place5;
                    com.Parameters.Add("@SumPlace", SqlDbType.VarChar, 50).Value = PlaceSum;
                    com.Parameters.Add("@OneCapital1", SqlDbType.VarChar, 50).Value = OneCapital1;
                    com.Parameters.Add("@OneCapital2", SqlDbType.VarChar, 50).Value = OneCapital2;
                    com.Parameters.Add("@OneCapital3", SqlDbType.VarChar, 50).Value = OneCapital3;
                    com.Parameters.Add("@OneCapital4", SqlDbType.VarChar, 50).Value = OneCapital4;
                    com.Parameters.Add("@OneCapital5", SqlDbType.VarChar, 50).Value = OneCapital5;
                    com.Parameters.Add("@OneCapital6", SqlDbType.VarChar, 50).Value = OneCapital6;
                    com.Parameters.Add("@OneCapital7", SqlDbType.VarChar, 50).Value = OneCapital7;
                    com.Parameters.Add("@OneCapital8", SqlDbType.VarChar, 50).Value = OneCapital8;
                    com.Parameters.Add("@OneCapital9", SqlDbType.VarChar, 50).Value = OneCapital9;
                    com.Parameters.Add("@OneCapital10", SqlDbType.VarChar, 50).Value = OneCapital10;
                    com.Parameters.Add("@OneCapital11", SqlDbType.VarChar, 50).Value = OneCapital11;
                    com.Parameters.Add("@OneCapital12", SqlDbType.VarChar, 50).Value = OneCapital12;
                    com.Parameters.Add("@OneCapital13", SqlDbType.VarChar, 50).Value = OneCapital13;
                    com.Parameters.Add("@OneCapital14", SqlDbType.VarChar, 50).Value = OneCapital14;
                    com.Parameters.Add("@OneCapital15", SqlDbType.VarChar, 50).Value = OneCapital15;
                    com.Parameters.Add("@OneCapital16", SqlDbType.VarChar, 50).Value = OneCapital16;
                    com.Parameters.Add("@OneCapital17", SqlDbType.VarChar, 50).Value = OneCapital17;
                    com.Parameters.Add("@TwoCapital1", SqlDbType.VarChar, 50).Value = TwoCapital1;
                    com.Parameters.Add("@TwoCapital2", SqlDbType.VarChar, 50).Value = TwoCapital2;
                    com.Parameters.Add("@TwoCapital3", SqlDbType.VarChar, 50).Value = TwoCapital3;
                    com.Parameters.Add("@TwoCapital4", SqlDbType.VarChar, 50).Value = TwoCapital4;
                    com.Parameters.Add("@TwoCapital5", SqlDbType.VarChar, 50).Value = TwoCapital5;
                    com.Parameters.Add("@TwoCapital6", SqlDbType.VarChar, 50).Value = TwoCapital6;
                    com.Parameters.Add("@TwoCapital7", SqlDbType.VarChar, 50).Value = TwoCapital7;
                    com.Parameters.Add("@TwoCapital8", SqlDbType.VarChar, 50).Value = TwoCapital8;
                    com.Parameters.Add("@TwoCapital9", SqlDbType.VarChar, 50).Value = TwoCapital9;
                    com.Parameters.Add("@TwoCapital10", SqlDbType.VarChar, 50).Value = TwoCapital10;
                    com.Parameters.Add("@TwoCapital11", SqlDbType.VarChar, 50).Value = TwoCapital11;
                    com.Parameters.Add("@TwoCapital12", SqlDbType.VarChar, 50).Value = TwoCapital12;
                    com.Parameters.Add("@TwoCapital13", SqlDbType.VarChar, 50).Value = TwoCapital13;
                    com.Parameters.Add("@TwoCapital14", SqlDbType.VarChar, 50).Value = TwoCapital14;
                    com.Parameters.Add("@TwoCapital15", SqlDbType.VarChar, 50).Value = TwoCapital15;
                    com.Parameters.Add("@TwoCapital16", SqlDbType.VarChar, 50).Value = TwoCapital16;
                    com.Parameters.Add("@TwoCapital17", SqlDbType.VarChar, 50).Value = TwoCapital17;
                    com.Parameters.Add("@ThreeCapital1", SqlDbType.VarChar, 50).Value = ThreeCapital1;
                    com.Parameters.Add("@ThreeCapital2", SqlDbType.VarChar, 50).Value = ThreeCapital2;
                    com.Parameters.Add("@ThreeCapital3", SqlDbType.VarChar, 50).Value = ThreeCapital3;
                    com.Parameters.Add("@ThreeCapital4", SqlDbType.VarChar, 50).Value = ThreeCapital4;
                    com.Parameters.Add("@ThreeCapital5", SqlDbType.VarChar, 50).Value = ThreeCapital5;
                    com.Parameters.Add("@ThreeCapital6", SqlDbType.VarChar, 50).Value = ThreeCapital6;
                    com.Parameters.Add("@ThreeCapital7", SqlDbType.VarChar, 50).Value = ThreeCapital7;
                    com.Parameters.Add("@ThreeCapital8", SqlDbType.VarChar, 50).Value = ThreeCapital8;
                    com.Parameters.Add("@ThreeCapital9", SqlDbType.VarChar, 50).Value = ThreeCapital9;
                    com.Parameters.Add("@ThreeCapital10", SqlDbType.VarChar, 50).Value = ThreeCapital10;
                    com.Parameters.Add("@ThreeCapital11", SqlDbType.VarChar, 50).Value = ThreeCapital11;
                    com.Parameters.Add("@ThreeCapital12", SqlDbType.VarChar, 50).Value = ThreeCapital12;
                    com.Parameters.Add("@ThreeCapital13", SqlDbType.VarChar, 50).Value = ThreeCapital13;
                    com.Parameters.Add("@ThreeCapital14", SqlDbType.VarChar, 50).Value = ThreeCapital14;
                    com.Parameters.Add("@ThreeCapital15", SqlDbType.VarChar, 50).Value = ThreeCapital15;
                    com.Parameters.Add("@ThreeCapital16", SqlDbType.VarChar, 50).Value = ThreeCapital16;
                    com.Parameters.Add("@ThreeCapital17", SqlDbType.VarChar, 50).Value = ThreeCapital17;
                    com.Parameters.Add("@ForeCapital1", SqlDbType.VarChar, 50).Value = ForeCapital1;
                    com.Parameters.Add("@ForeCapital2", SqlDbType.VarChar, 50).Value = ForeCapital2;
                    com.Parameters.Add("@ForeCapital3", SqlDbType.VarChar, 50).Value = ForeCapital3;
                    com.Parameters.Add("@ForeCapital4", SqlDbType.VarChar, 50).Value = ForeCapital4;
                    com.Parameters.Add("@ForeCapital5", SqlDbType.VarChar, 50).Value = ForeCapital5;
                    com.Parameters.Add("@ForeCapital6", SqlDbType.VarChar, 50).Value = ForeCapital6;
                    com.Parameters.Add("@ForeCapital7", SqlDbType.VarChar, 50).Value = ForeCapital7;
                    com.Parameters.Add("@ForeCapital8", SqlDbType.VarChar, 50).Value = ForeCapital8;
                    com.Parameters.Add("@ForeCapital9", SqlDbType.VarChar, 50).Value = ForeCapital9;
                    com.Parameters.Add("@ForeCapital10", SqlDbType.VarChar, 50).Value = ForeCapital10;
                    com.Parameters.Add("@ForeCapital11", SqlDbType.VarChar, 50).Value = ForeCapital11;
                    com.Parameters.Add("@ForeCapital12", SqlDbType.VarChar, 50).Value = ForeCapital12;
                    com.Parameters.Add("@ForeCapital13", SqlDbType.VarChar, 50).Value = ForeCapital13;
                    com.Parameters.Add("@ForeCapital14", SqlDbType.VarChar, 50).Value = ForeCapital14;
                    com.Parameters.Add("@ForeCapital15", SqlDbType.VarChar, 50).Value = ForeCapital15;
                    com.Parameters.Add("@ForeCapital16", SqlDbType.VarChar, 50).Value = ForeCapital16;
                    com.Parameters.Add("@ForeCapital17", SqlDbType.VarChar, 50).Value = ForeCapital17;
                    com.Parameters.Add("@Equipment1", SqlDbType.VarChar, 50).Value = Equipment1;
                    com.Parameters.Add("@Equipment2", SqlDbType.VarChar, 50).Value = Equipment2;
                    com.Parameters.Add("@Equipment3", SqlDbType.VarChar, 50).Value = Equipment3;
                    com.Parameters.Add("@Equipment4", SqlDbType.VarChar, 50).Value = Equipment4;
                    com.Parameters.Add("@Equipment5", SqlDbType.VarChar, 50).Value = Equipment5;
                    com.Parameters.Add("@Equipment6", SqlDbType.VarChar, 50).Value = Equipment6;
                    com.Parameters.Add("@Equipment7", SqlDbType.VarChar, 50).Value = Equipment7;
                    com.Parameters.Add("@Equipment8", SqlDbType.VarChar, 50).Value = Equipment8;
                    com.Parameters.Add("@Company1", SqlDbType.VarChar, 50).Value = Company1;
                    com.Parameters.Add("@Company2", SqlDbType.VarChar, 50).Value = Company2;
                    com.Parameters.Add("@Company3", SqlDbType.VarChar, 50).Value = Company3;
                    com.Parameters.Add("@Company4", SqlDbType.VarChar, 50).Value = Company4;
                    com.Parameters.Add("@Company5", SqlDbType.VarChar, 50).Value = Company5;
                    com.Parameters.Add("@Company6", SqlDbType.VarChar, 50).Value = Company6;
                    com.Parameters.Add("@Company7", SqlDbType.VarChar, 50).Value = Company7;
                    com.Parameters.Add("@Company8", SqlDbType.VarChar, 50).Value = Company8;
                    com.Parameters.Add("@Number1", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@Number2", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@Number3", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@Number4", SqlDbType.VarChar, 50).Value = Number4;
                    com.Parameters.Add("@Number5", SqlDbType.VarChar, 50).Value = Number5;
                    com.Parameters.Add("@Number6", SqlDbType.VarChar, 50).Value = Number6;
                    com.Parameters.Add("@Number7", SqlDbType.VarChar, 50).Value = Number7;
                    com.Parameters.Add("@Number8", SqlDbType.VarChar, 50).Value = Number8;
                    com.Parameters.Add("@Price1", SqlDbType.VarChar, 50).Value = Price1;
                    com.Parameters.Add("@Price2", SqlDbType.VarChar, 50).Value = Price2;
                    com.Parameters.Add("@Price3", SqlDbType.VarChar, 50).Value = Price3;
                    com.Parameters.Add("@Price4", SqlDbType.VarChar, 50).Value = Price4;
                    com.Parameters.Add("@Price5", SqlDbType.VarChar, 50).Value = Price5;
                    com.Parameters.Add("@Price6", SqlDbType.VarChar, 50).Value = Price6;
                    com.Parameters.Add("@Price7", SqlDbType.VarChar, 50).Value = Price7;
                    com.Parameters.Add("@Price8", SqlDbType.VarChar, 50).Value = Price8;
                    com.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    com.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
                    com.Parameters.Add("@Money3", SqlDbType.VarChar, 50).Value = Money3;
                    com.Parameters.Add("@Money4", SqlDbType.VarChar, 50).Value = Money4;
                    com.Parameters.Add("@Money5", SqlDbType.VarChar, 50).Value = Money5;
                    com.Parameters.Add("@Money6", SqlDbType.VarChar, 50).Value = Money6;
                    com.Parameters.Add("@Money7", SqlDbType.VarChar, 50).Value = Money7;
                    com.Parameters.Add("@Money8", SqlDbType.VarChar, 50).Value = Money8;
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
        /// 经费决算修改
        /// </summary>


        public bool ShortFinalCapitalUpdate(string proc, int ShortFinalCapitalId, string ShortProjectsId, string ShortProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17,
            string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7, string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17,
            string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8, string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8,
            string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortFinalCapitalId", SqlDbType.Int).Value = ShortFinalCapitalId;
                    com.Parameters.Add("@ShortProjectsId", SqlDbType.VarChar, 50).Value = ShortProjectsId;
                    com.Parameters.Add("@ShortProjectsName", SqlDbType.VarChar, 50).Value = ShortProjectsName;
                    com.Parameters.Add("@Contract", SqlDbType.VarChar, 50).Value = Contract;
                    com.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = Company;
                    com.Parameters.Add("@OneCome", SqlDbType.VarChar, 50).Value = Come1;
                    com.Parameters.Add("@TwoCome", SqlDbType.VarChar, 50).Value = Come2;
                    com.Parameters.Add("@ThreeCome", SqlDbType.VarChar, 50).Value = Come3;
                    com.Parameters.Add("@ForeCome", SqlDbType.VarChar, 50).Value = Come4;
                    com.Parameters.Add("@FiveCome", SqlDbType.VarChar, 50).Value = Come5;
                    com.Parameters.Add("@SumCome", SqlDbType.VarChar, 50).Value = ComeSum;
                    com.Parameters.Add("@OnePlace", SqlDbType.VarChar, 50).Value = Place1;
                    com.Parameters.Add("@TwoPlace", SqlDbType.VarChar, 50).Value = Place2;
                    com.Parameters.Add("@ThreePlace", SqlDbType.VarChar, 50).Value = Place3;
                    com.Parameters.Add("@ForePlace", SqlDbType.VarChar, 50).Value = Place4;
                    com.Parameters.Add("@FivePlace", SqlDbType.VarChar, 50).Value = Place5;
                    com.Parameters.Add("@SumPlace", SqlDbType.VarChar, 50).Value = PlaceSum;
                    com.Parameters.Add("@OneCapital1", SqlDbType.VarChar, 50).Value = OneCapital1;
                    com.Parameters.Add("@OneCapital2", SqlDbType.VarChar, 50).Value = OneCapital2;
                    com.Parameters.Add("@OneCapital3", SqlDbType.VarChar, 50).Value = OneCapital3;
                    com.Parameters.Add("@OneCapital4", SqlDbType.VarChar, 50).Value = OneCapital4;
                    com.Parameters.Add("@OneCapital5", SqlDbType.VarChar, 50).Value = OneCapital5;
                    com.Parameters.Add("@OneCapital6", SqlDbType.VarChar, 50).Value = OneCapital6;
                    com.Parameters.Add("@OneCapital7", SqlDbType.VarChar, 50).Value = OneCapital7;
                    com.Parameters.Add("@OneCapital8", SqlDbType.VarChar, 50).Value = OneCapital8;
                    com.Parameters.Add("@OneCapital9", SqlDbType.VarChar, 50).Value = OneCapital9;
                    com.Parameters.Add("@OneCapital10", SqlDbType.VarChar, 50).Value = OneCapital10;
                    com.Parameters.Add("@OneCapital11", SqlDbType.VarChar, 50).Value = OneCapital11;
                    com.Parameters.Add("@OneCapital12", SqlDbType.VarChar, 50).Value = OneCapital12;
                    com.Parameters.Add("@OneCapital13", SqlDbType.VarChar, 50).Value = OneCapital13;
                    com.Parameters.Add("@OneCapital14", SqlDbType.VarChar, 50).Value = OneCapital14;
                    com.Parameters.Add("@OneCapital15", SqlDbType.VarChar, 50).Value = OneCapital15;
                    com.Parameters.Add("@OneCapital16", SqlDbType.VarChar, 50).Value = OneCapital16;
                    com.Parameters.Add("@OneCapital17", SqlDbType.VarChar, 50).Value = OneCapital17;
                    com.Parameters.Add("@TwoCapital1", SqlDbType.VarChar, 50).Value = TwoCapital1;
                    com.Parameters.Add("@TwoCapital2", SqlDbType.VarChar, 50).Value = TwoCapital2;
                    com.Parameters.Add("@TwoCapital3", SqlDbType.VarChar, 50).Value = TwoCapital3;
                    com.Parameters.Add("@TwoCapital4", SqlDbType.VarChar, 50).Value = TwoCapital4;
                    com.Parameters.Add("@TwoCapital5", SqlDbType.VarChar, 50).Value = TwoCapital5;
                    com.Parameters.Add("@TwoCapital6", SqlDbType.VarChar, 50).Value = TwoCapital6;
                    com.Parameters.Add("@TwoCapital7", SqlDbType.VarChar, 50).Value = TwoCapital7;
                    com.Parameters.Add("@TwoCapital8", SqlDbType.VarChar, 50).Value = TwoCapital8;
                    com.Parameters.Add("@TwoCapital9", SqlDbType.VarChar, 50).Value = TwoCapital9;
                    com.Parameters.Add("@TwoCapital10", SqlDbType.VarChar, 50).Value = TwoCapital10;
                    com.Parameters.Add("@TwoCapital11", SqlDbType.VarChar, 50).Value = TwoCapital11;
                    com.Parameters.Add("@TwoCapital12", SqlDbType.VarChar, 50).Value = TwoCapital12;
                    com.Parameters.Add("@TwoCapital13", SqlDbType.VarChar, 50).Value = TwoCapital13;
                    com.Parameters.Add("@TwoCapital14", SqlDbType.VarChar, 50).Value = TwoCapital14;
                    com.Parameters.Add("@TwoCapital15", SqlDbType.VarChar, 50).Value = TwoCapital15;
                    com.Parameters.Add("@TwoCapital16", SqlDbType.VarChar, 50).Value = TwoCapital16;
                    com.Parameters.Add("@TwoCapital17", SqlDbType.VarChar, 50).Value = TwoCapital17;
                    com.Parameters.Add("@ThreeCapital1", SqlDbType.VarChar, 50).Value = ThreeCapital1;
                    com.Parameters.Add("@ThreeCapital2", SqlDbType.VarChar, 50).Value = ThreeCapital2;
                    com.Parameters.Add("@ThreeCapital3", SqlDbType.VarChar, 50).Value = ThreeCapital3;
                    com.Parameters.Add("@ThreeCapital4", SqlDbType.VarChar, 50).Value = ThreeCapital4;
                    com.Parameters.Add("@ThreeCapital5", SqlDbType.VarChar, 50).Value = ThreeCapital5;
                    com.Parameters.Add("@ThreeCapital6", SqlDbType.VarChar, 50).Value = ThreeCapital6;
                    com.Parameters.Add("@ThreeCapital7", SqlDbType.VarChar, 50).Value = ThreeCapital7;
                    com.Parameters.Add("@ThreeCapital8", SqlDbType.VarChar, 50).Value = ThreeCapital8;
                    com.Parameters.Add("@ThreeCapital9", SqlDbType.VarChar, 50).Value = ThreeCapital9;
                    com.Parameters.Add("@ThreeCapital10", SqlDbType.VarChar, 50).Value = ThreeCapital10;
                    com.Parameters.Add("@ThreeCapital11", SqlDbType.VarChar, 50).Value = ThreeCapital11;
                    com.Parameters.Add("@ThreeCapital12", SqlDbType.VarChar, 50).Value = ThreeCapital12;
                    com.Parameters.Add("@ThreeCapital13", SqlDbType.VarChar, 50).Value = ThreeCapital13;
                    com.Parameters.Add("@ThreeCapital14", SqlDbType.VarChar, 50).Value = ThreeCapital14;
                    com.Parameters.Add("@ThreeCapital15", SqlDbType.VarChar, 50).Value = ThreeCapital15;
                    com.Parameters.Add("@ThreeCapital16", SqlDbType.VarChar, 50).Value = ThreeCapital16;
                    com.Parameters.Add("@ThreeCapital17", SqlDbType.VarChar, 50).Value = ThreeCapital17;
                    com.Parameters.Add("@ForeCapital1", SqlDbType.VarChar, 50).Value = ForeCapital1;
                    com.Parameters.Add("@ForeCapital2", SqlDbType.VarChar, 50).Value = ForeCapital2;
                    com.Parameters.Add("@ForeCapital3", SqlDbType.VarChar, 50).Value = ForeCapital3;
                    com.Parameters.Add("@ForeCapital4", SqlDbType.VarChar, 50).Value = ForeCapital4;
                    com.Parameters.Add("@ForeCapital5", SqlDbType.VarChar, 50).Value = ForeCapital5;
                    com.Parameters.Add("@ForeCapital6", SqlDbType.VarChar, 50).Value = ForeCapital6;
                    com.Parameters.Add("@ForeCapital7", SqlDbType.VarChar, 50).Value = ForeCapital7;
                    com.Parameters.Add("@ForeCapital8", SqlDbType.VarChar, 50).Value = ForeCapital8;
                    com.Parameters.Add("@ForeCapital9", SqlDbType.VarChar, 50).Value = ForeCapital9;
                    com.Parameters.Add("@ForeCapital10", SqlDbType.VarChar, 50).Value = ForeCapital10;
                    com.Parameters.Add("@ForeCapital11", SqlDbType.VarChar, 50).Value = ForeCapital11;
                    com.Parameters.Add("@ForeCapital12", SqlDbType.VarChar, 50).Value = ForeCapital12;
                    com.Parameters.Add("@ForeCapital13", SqlDbType.VarChar, 50).Value = ForeCapital13;
                    com.Parameters.Add("@ForeCapital14", SqlDbType.VarChar, 50).Value = ForeCapital14;
                    com.Parameters.Add("@ForeCapital15", SqlDbType.VarChar, 50).Value = ForeCapital15;
                    com.Parameters.Add("@ForeCapital16", SqlDbType.VarChar, 50).Value = ForeCapital16;
                    com.Parameters.Add("@ForeCapital17", SqlDbType.VarChar, 50).Value = ForeCapital17;
                    com.Parameters.Add("@Equipment1", SqlDbType.VarChar, 50).Value = Equipment1;
                    com.Parameters.Add("@Equipment2", SqlDbType.VarChar, 50).Value = Equipment2;
                    com.Parameters.Add("@Equipment3", SqlDbType.VarChar, 50).Value = Equipment3;
                    com.Parameters.Add("@Equipment4", SqlDbType.VarChar, 50).Value = Equipment4;
                    com.Parameters.Add("@Equipment5", SqlDbType.VarChar, 50).Value = Equipment5;
                    com.Parameters.Add("@Equipment6", SqlDbType.VarChar, 50).Value = Equipment6;
                    com.Parameters.Add("@Equipment7", SqlDbType.VarChar, 50).Value = Equipment7;
                    com.Parameters.Add("@Equipment8", SqlDbType.VarChar, 50).Value = Equipment8;
                    com.Parameters.Add("@Company1", SqlDbType.VarChar, 50).Value = Company1;
                    com.Parameters.Add("@Company2", SqlDbType.VarChar, 50).Value = Company2;
                    com.Parameters.Add("@Company3", SqlDbType.VarChar, 50).Value = Company3;
                    com.Parameters.Add("@Company4", SqlDbType.VarChar, 50).Value = Company4;
                    com.Parameters.Add("@Company5", SqlDbType.VarChar, 50).Value = Company5;
                    com.Parameters.Add("@Company6", SqlDbType.VarChar, 50).Value = Company6;
                    com.Parameters.Add("@Company7", SqlDbType.VarChar, 50).Value = Company7;
                    com.Parameters.Add("@Company8", SqlDbType.VarChar, 50).Value = Company8;
                    com.Parameters.Add("@Number1", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@Number2", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@Number3", SqlDbType.VarChar, 50).Value = Number3;
                    com.Parameters.Add("@Number4", SqlDbType.VarChar, 50).Value = Number4;
                    com.Parameters.Add("@Number5", SqlDbType.VarChar, 50).Value = Number5;
                    com.Parameters.Add("@Number6", SqlDbType.VarChar, 50).Value = Number6;
                    com.Parameters.Add("@Number7", SqlDbType.VarChar, 50).Value = Number7;
                    com.Parameters.Add("@Number8", SqlDbType.VarChar, 50).Value = Number8;
                    com.Parameters.Add("@Price1", SqlDbType.VarChar, 50).Value = Price1;
                    com.Parameters.Add("@Price2", SqlDbType.VarChar, 50).Value = Price2;
                    com.Parameters.Add("@Price3", SqlDbType.VarChar, 50).Value = Price3;
                    com.Parameters.Add("@Price4", SqlDbType.VarChar, 50).Value = Price4;
                    com.Parameters.Add("@Price5", SqlDbType.VarChar, 50).Value = Price5;
                    com.Parameters.Add("@Price6", SqlDbType.VarChar, 50).Value = Price6;
                    com.Parameters.Add("@Price7", SqlDbType.VarChar, 50).Value = Price7;
                    com.Parameters.Add("@Price8", SqlDbType.VarChar, 50).Value = Price8;
                    com.Parameters.Add("@Money1", SqlDbType.VarChar, 50).Value = Money1;
                    com.Parameters.Add("@Money2", SqlDbType.VarChar, 50).Value = Money2;
                    com.Parameters.Add("@Money3", SqlDbType.VarChar, 50).Value = Money3;
                    com.Parameters.Add("@Money4", SqlDbType.VarChar, 50).Value = Money4;
                    com.Parameters.Add("@Money5", SqlDbType.VarChar, 50).Value = Money5;
                    com.Parameters.Add("@Money6", SqlDbType.VarChar, 50).Value = Money6;
                    com.Parameters.Add("@Money7", SqlDbType.VarChar, 50).Value = Money7;
                    com.Parameters.Add("@Money8", SqlDbType.VarChar, 50).Value = Money8;
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
        /// 经费决算删除
        /// </summary>
        public bool ShortFinalCapitalDelete(string proc, int ShortFinalCapitalId, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ShortFinalCapitalId", SqlDbType.Int).Value = ShortFinalCapitalId;

                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar).Value = UserCardId;
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
        /// 按经费决算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortFinalCapitalId(string proc, int ShortFinalCapitalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ShortFinalCapitalId", SqlDbType.VarChar, 50).Value = ShortFinalCapitalId;
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








        #endregion
        #endregion

        #region 教科研工作管理
        #region 教材建设
        /// <summary>
        /// 教材建设申请
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingInsert(string proc, string UserCardId,int DepartmentId, string T_TeachingName, string Category, string Press, string Time, string Edition, string Compiledwords, string EditorRanking, string Score, string Reference, string Totalscore, string T_TeachingUrl, double PartnerValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@T_TeachingName", SqlDbType.VarChar, 200).Value = T_TeachingName;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@Press", SqlDbType.VarChar, 50).Value = Press;
                    com.Parameters.Add("@Time", SqlDbType.VarChar, 50).Value = Time;
                    com.Parameters.Add("@Edition", SqlDbType.VarChar, 50).Value = Edition;
                    com.Parameters.Add("@Compiledwords", SqlDbType.VarChar, 50).Value = Compiledwords;
                    com.Parameters.Add("@EditorRanking", SqlDbType.VarChar, 50).Value = EditorRanking;
                    com.Parameters.Add("@Score", SqlDbType.VarChar, 50).Value = Score;
                    com.Parameters.Add("@Reference", SqlDbType.VarChar, 50).Value = Reference;
                    com.Parameters.Add("@Totalscore", SqlDbType.VarChar, 50).Value = Totalscore;
                    com.Parameters.Add("@T_TeachingUrl", SqlDbType.Text).Value = T_TeachingUrl;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教材建设单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByT_TeachingId(string proc, int T_TeachingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
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
        /// 教材建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectT_Teaching(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人教材建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectT_TeachingByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教材建设可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet T_TeachingExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 教材建设修改
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingUpdate(string proc, int T_TeachingId,int DepartmentId, string T_TeachingName, string Category, string Press, string Time, string Edition, string Compiledwords, string EditorRanking, string Score, string Reference, string Totalscore, string T_TeachingUrl, double PartnerValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@T_TeachingName", SqlDbType.VarChar, 200).Value = T_TeachingName;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@Press", SqlDbType.VarChar, 50).Value = Press;
                    com.Parameters.Add("@Time", SqlDbType.VarChar, 50).Value = Time;
                    com.Parameters.Add("@Edition", SqlDbType.VarChar, 50).Value = Edition;
                    com.Parameters.Add("@Compiledwords", SqlDbType.VarChar, 50).Value = Compiledwords;
                    com.Parameters.Add("@EditorRanking", SqlDbType.VarChar, 50).Value = EditorRanking;
                    com.Parameters.Add("@Score", SqlDbType.VarChar, 50).Value = Score;
                    com.Parameters.Add("@Reference", SqlDbType.VarChar, 50).Value = Reference;
                    com.Parameters.Add("@Totalscore", SqlDbType.VarChar, 50).Value = Totalscore;
                    com.Parameters.Add("@T_TeachingUrl", SqlDbType.Text).Value = T_TeachingUrl;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教材建设删除
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingDelete(string proc, int T_TeachingId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
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
        /// 教材建设审批添加
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingExamineInsert(string proc, int T_TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 教材建设审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectT_TeachingExamine(string proc, int T_TeachingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
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
        /// 教材建设审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教材建设审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingProcessDelete(string proc, int T_TeachingProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@T_TeachingProcessId", SqlDbType.Int).Value = T_TeachingProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教材建设记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsT_Teaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string T_TeachingName, string Category, string T_TeachingYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@T_TeachingName", SqlDbType.VarChar, 50).Value = T_TeachingName;
                    sda.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    sda.SelectCommand.Parameters.Add("@T_TeachingYear", SqlDbType.VarChar, 50).Value = T_TeachingYear;
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
        #region 教学团队建设
        /// <summary>
        /// 教学团队建设申请
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamInsert(string proc, string UserCardId,int DepartmentId, string Teaching_TeamName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string Teaching_TeamUrl, double Teaching_TeamValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@Teaching_TeamName", SqlDbType.VarChar, 200).Value = Teaching_TeamName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@Teaching_TeamUrl", SqlDbType.Text).Value = Teaching_TeamUrl;
                    com.Parameters.Add("@Teaching_TeamValue", SqlDbType.Float, 500).Value = Teaching_TeamValue;
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
        /// 教学团队建设合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTeaching_TeamPartnerId(string proc, int Teaching_TeamPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Teaching_TeamPartnerId", SqlDbType.Int).Value = Teaching_TeamPartnerId;
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
        /// 教学团队建设合作者添加
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamPartnerInsert(string proc, int Teaching_TeamId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教学团队建设合作者修改
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamPartnerUpdate(string proc, int Teaching_TeamPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamPartnerId", SqlDbType.Int).Value = Teaching_TeamPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教学团队建设合作者删除
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamPartnerDelete(string proc, int Teaching_TeamPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("Teaching_TeamPartnerId", SqlDbType.Int).Value = Teaching_TeamPartnerId;
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
        /// 教学团队建设单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTeaching_TeamId(string proc, int Teaching_TeamId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
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
        /// 教学团队建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeaching_Team(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人教学团队建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeaching_TeamByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学团队建设可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet Teaching_TeamExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 教学团队建设修改
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamUpdate(string proc, int Teaching_TeamId, int DepartmentId, string Teaching_TeamName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string Teaching_TeamUrl, double Teaching_TeamValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@Teaching_TeamName", SqlDbType.VarChar,200).Value = Teaching_TeamName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@Teaching_TeamUrl", SqlDbType.Text).Value = Teaching_TeamUrl;
                    com.Parameters.Add("@Teaching_TeamValue", SqlDbType.Float, 500).Value = Teaching_TeamValue;
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
        /// 教学团队建设删除
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamDelete(string proc, int Teaching_TeamId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
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
        /// 教学团队建设审批添加
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamExamineInsert(string proc, int Teaching_TeamId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 教学团队建设审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTeaching_TeamExamine(string proc, int Teaching_TeamId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
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
        /// 教学团队建设审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学团队建设审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamProcessDelete(string proc, int Teaching_TeamProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamProcessId", SqlDbType.Int).Value = Teaching_TeamProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学团队建设记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsTeaching_Team(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string Teaching_TeamName, string Leve, string Teaching_TeamYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@Teaching_TeamName", SqlDbType.VarChar, 50).Value = Teaching_TeamName;
                    sda.SelectCommand.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    sda.SelectCommand.Parameters.Add("@Teaching_TeamYear", SqlDbType.VarChar, 50).Value = Teaching_TeamYear;
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
        #region 专业建设
        /// <summary>
        /// 专业建设申请
        /// </summary>
        /// <returns></returns>
        public bool P_constructionInsert(string proc, string UserCardId,int DepartmentId, string P_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string P_constructionUrl, double P_constructionValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@P_constructionName", SqlDbType.VarChar,200).Value = P_constructionName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@P_constructionUrl", SqlDbType.Text).Value = P_constructionUrl;
                    com.Parameters.Add("@P_constructionValue", SqlDbType.Float, 500).Value = P_constructionValue;
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
        /// 专业建设合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByP_constructionPartnerId(string proc, int P_constructionPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@P_constructionPartnerId", SqlDbType.Int).Value = P_constructionPartnerId;
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
        /// 专业建设合作者添加
        /// </summary>
        /// <returns></returns>
        public bool P_constructionPartnerInsert(string proc, int P_constructionId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 专业建设合作者修改
        /// </summary>
        /// <returns></returns>
        public bool P_constructionPartnerUpdate(string proc, int P_constructionPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionPartnerId", SqlDbType.Int).Value = P_constructionPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 专业建设合作者删除
        /// </summary>
        /// <returns></returns>
        public bool P_constructionPartnerDelete(string proc, int P_constructionPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("P_constructionPartnerId", SqlDbType.Int).Value = P_constructionPartnerId;
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
        /// 专业建设单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByP_constructionId(string proc, int P_constructionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
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
        /// 专业建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectP_construction(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人专业建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectP_constructionByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专业建设可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet P_constructionExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 专业建设修改
        /// </summary>
        /// <returns></returns>
        public bool P_constructionUpdate(string proc, int P_constructionId,int DepartmentId, string P_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string P_constructionUrl, double P_constructionValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@P_constructionName", SqlDbType.VarChar, 200).Value = P_constructionName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@P_constructionUrl", SqlDbType.Text).Value = P_constructionUrl;
                    com.Parameters.Add("@P_constructionValue", SqlDbType.Float, 500).Value = P_constructionValue;
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
        /// 专业建设删除
        /// </summary>
        /// <returns></returns>
        public bool P_constructionDelete(string proc, int P_constructionId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
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
        /// 专业建设审批添加
        /// </summary>
        /// <returns></returns>
        public bool P_constructionExamineInsert(string proc, int P_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 专业建设审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectP_constructionExamine(string proc, int P_constructionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
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
        /// 专业建设审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool P_constructionProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专业建设审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool P_constructionProcessDelete(string proc, int P_constructionProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionProcessId", SqlDbType.Int).Value = P_constructionProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专业建设记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsP_construction(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string P_constructionName, string Leve, string P_constructionYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@P_constructionName", SqlDbType.VarChar, 50).Value = P_constructionName;
                    sda.SelectCommand.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    sda.SelectCommand.Parameters.Add("@P_constructionYear", SqlDbType.VarChar, 50).Value = P_constructionYear;
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
        #region 课程建设
        /// <summary>
        /// 课程建设申请
        /// </summary>
        /// <returns></returns>
        public bool C_constructionInsert(string proc, string UserCardId,int DepartmentId, string C_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string C_constructionUrl, double C_constructionValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@C_constructionName", SqlDbType.VarChar,200).Value = C_constructionName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@C_constructionUrl", SqlDbType.Text).Value = C_constructionUrl;
                    com.Parameters.Add("@C_constructionValue", SqlDbType.Float, 500).Value = C_constructionValue;
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
        /// 课程建设合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByC_constructionPartnerId(string proc, int C_constructionPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_constructionPartnerId", SqlDbType.Int).Value = C_constructionPartnerId;
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
        /// 课程建设合作者添加
        /// </summary>
        /// <returns></returns>
        public bool C_constructionPartnerInsert(string proc, int C_constructionId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 课程建设合作者修改
        /// </summary>
        /// <returns></returns>
        public bool C_constructionPartnerUpdate(string proc, int C_constructionPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionPartnerId", SqlDbType.Int).Value = C_constructionPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 课程建设合作者删除
        /// </summary>
        /// <returns></returns>
        public bool C_constructionPartnerDelete(string proc, int C_constructionPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("C_constructionPartnerId", SqlDbType.Int).Value = C_constructionPartnerId;
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
        /// 课程建设单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByC_constructionId(string proc, int C_constructionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
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
        /// 课程建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_construction(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人课程建设查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_constructionByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 课程建设可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet C_constructionExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 课程建设修改
        /// </summary>
        /// <returns></returns>
        public bool C_constructionUpdate(string proc, int C_constructionId,int DepartmentId, string C_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string C_constructionUrl, double C_constructionValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@C_constructionName", SqlDbType.VarChar,200).Value = C_constructionName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Principal", SqlDbType.VarChar, 50).Value = Principal;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@StartEndDate", SqlDbType.VarChar, 50).Value = StartEndDate;
                    com.Parameters.Add("@Total_Project", SqlDbType.Float, 500).Value = Total_Project;
                    com.Parameters.Add("@Description_Project", SqlDbType.VarChar, 50).Value = Description_Project;
                    com.Parameters.Add("@Annual", SqlDbType.Float, 500).Value = Annual;
                    com.Parameters.Add("@Description_year", SqlDbType.VarChar, 50).Value = Description_year;
                    com.Parameters.Add("@C_constructionUrl", SqlDbType.Text).Value = C_constructionUrl;
                    com.Parameters.Add("@C_constructionValue", SqlDbType.Float, 500).Value = C_constructionValue;
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
        /// 课程建设删除
        /// </summary>
        /// <returns></returns>
        public bool C_constructionDelete(string proc, int C_constructionId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
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
        /// 课程建设审批添加
        /// </summary>
        /// <returns></returns>
        public bool C_constructionExamineInsert(string proc, int C_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 课程建设审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_constructionExamine(string proc, int C_constructionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
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
        /// 课程建设审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool C_constructionProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 课程建设审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool C_constructionProcessDelete(string proc, int C_constructionProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionProcessId", SqlDbType.Int).Value = C_constructionProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 课程建设记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsC_construction(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string C_constructionName, string Leve, string C_constructionYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@C_constructionName", SqlDbType.VarChar, 50).Value = C_constructionName;
                    sda.SelectCommand.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    sda.SelectCommand.Parameters.Add("@C_constructionYear", SqlDbType.VarChar, 50).Value = C_constructionYear;
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
        #region 竞赛获奖
        /// <summary>
        /// 竞赛获奖申请
        /// </summary>
        /// <returns></returns>
        public bool C_winnersInsert(string proc, string UserCardId,int DepartmentId, string C_winnersName, string Leve, string Time, string Award_level, string Organizational_Unit, double C_winnersTotal, string C_winnersDescription, string Ranking, string C_winnersUrl, double C_winnersValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@C_winnersName", SqlDbType.VarChar, 200).Value = C_winnersName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Time", SqlDbType.VarChar, 50).Value = Time;
                    com.Parameters.Add("@Award_level", SqlDbType.VarChar, 50).Value = Award_level;
                    com.Parameters.Add("@Organizational_Unit", SqlDbType.VarChar, 50).Value = Organizational_Unit;
                    com.Parameters.Add("@C_winnersTotal", SqlDbType.Float, 500).Value = C_winnersTotal;
                    com.Parameters.Add("@C_winnersDescription", SqlDbType.VarChar, 50).Value = C_winnersDescription;
                    com.Parameters.Add("@Ranking", SqlDbType.VarChar, 50).Value = Ranking;
                    com.Parameters.Add("@C_winnersUrl", SqlDbType.Text).Value = C_winnersUrl;
                    com.Parameters.Add("@C_winnersValue", SqlDbType.Float, 500).Value = C_winnersValue;
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
        /// 课程建设合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByC_winnersPartnerId(string proc, int C_winnersPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_winnersPartnerId", SqlDbType.Int).Value = C_winnersPartnerId;
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
        /// 竞赛获奖合作者添加
        /// </summary>
        /// <returns></returns>
        public bool C_winnersPartnerInsert(string proc, int C_winnersId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 竞赛获奖合作者修改
        /// </summary>
        /// <returns></returns>
        public bool C_winnersPartnerUpdate(string proc, int C_winnersPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersPartnerId", SqlDbType.Int).Value = C_winnersPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 竞赛获奖合作者删除
        /// </summary>
        /// <returns></returns>
        public bool C_winnersPartnerDelete(string proc, int C_winnersPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("C_winnersPartnerId", SqlDbType.Int).Value = C_winnersPartnerId;
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
        /// 竞赛获奖单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByC_winnersId(string proc, int C_winnersId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
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
        /// 竞赛获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_winners(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人竞赛获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_winnersByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 竞赛获奖可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet C_winnersExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 竞赛获奖修改
        /// </summary>
        /// <returns></returns>
        public bool C_winnersUpdate(string proc, int C_winnersId,int DepartmentId, string C_winnersName, string Leve, string Time, string Award_level, string Organizational_Unit, double C_winnersTotal, string C_winnersDescription, string Ranking, string C_winnersUrl, double C_winnersValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@C_winnersName", SqlDbType.VarChar, 200).Value = C_winnersName;
                    com.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    com.Parameters.Add("@Time", SqlDbType.VarChar, 50).Value = Time;
                    com.Parameters.Add("@Award_level", SqlDbType.VarChar, 50).Value = Award_level;
                    com.Parameters.Add("@Organizational_Unit", SqlDbType.VarChar, 50).Value = Organizational_Unit;
                    com.Parameters.Add("@C_winnersTotal", SqlDbType.Float, 500).Value = C_winnersTotal;
                    com.Parameters.Add("@C_winnersDescription", SqlDbType.VarChar, 50).Value = C_winnersDescription;
                    com.Parameters.Add("@Ranking", SqlDbType.VarChar, 50).Value = Ranking;
                    com.Parameters.Add("@C_winnersUrl", SqlDbType.Text).Value = C_winnersUrl;
                    com.Parameters.Add("@C_winnersValue", SqlDbType.Float, 500).Value = C_winnersValue;
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
        /// 竞赛获奖删除
        /// </summary>
        /// <returns></returns>
        public bool C_winnersDelete(string proc, int C_winnersId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
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
        /// 竞赛获奖审批添加
        /// </summary>
        /// <returns></returns>
        public bool C_winnersExamineInsert(string proc, int C_winnersId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 竞赛获奖审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectC_winnersExamine(string proc, int C_winnersId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
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
        /// 竞赛获奖审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool C_winnersProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 竞赛获奖审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool C_winnersProcessDelete(string proc, int C_winnersProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersProcessId", SqlDbType.Int).Value = C_winnersProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 竞赛获奖记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsC_winners(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string C_winnersName, string Leve, string C_winnersYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@C_winnersName", SqlDbType.VarChar, 50).Value = C_winnersName;
                    sda.SelectCommand.Parameters.Add("@Leve", SqlDbType.VarChar, 50).Value = Leve;
                    sda.SelectCommand.Parameters.Add("@C_winnersYear", SqlDbType.VarChar, 50).Value = C_winnersYear;
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
        #region 教学成果获奖
        /// <summary>
        /// 教学成果获奖申请
        /// </summary>
        /// <returns></returns>
        public bool ResultsInsert(string proc, string UserCardId,int DepartmentId, string ResultsName, string Category, string Awardlevel, string ResultsPrincipal, string Awarding_unit, string time, string Completion, double ResultsTotal, string ResultsDescription, string ResultsUrl, double ResultsValue, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ResultsName", SqlDbType.VarChar, 200).Value = ResultsName;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@Awardlevel", SqlDbType.VarChar, 50).Value = Awardlevel;
                    com.Parameters.Add("@ResultsPrincipal", SqlDbType.VarChar, 50).Value = ResultsPrincipal;
                    com.Parameters.Add("@Awarding_unit", SqlDbType.VarChar, 50).Value = Awarding_unit;
                    com.Parameters.Add("@time", SqlDbType.VarChar, 50).Value = time;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@ResultsTotal", SqlDbType.Float, 500).Value = ResultsTotal;
                    com.Parameters.Add("@ResultsDescription", SqlDbType.VarChar, 50).Value = ResultsDescription;
                    com.Parameters.Add("@ResultsUrl", SqlDbType.Text).Value = ResultsUrl;
                    com.Parameters.Add("@ResultsValue", SqlDbType.Float, 500).Value = ResultsValue;
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
        /// 教学成果获奖合作者单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByResultsPartnerId(string proc, int ResultsPartnerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ResultsPartnerId", SqlDbType.Int).Value = ResultsPartnerId;
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
        /// 教学成果获奖合作者添加
        /// </summary>
        /// <returns></returns>
        public bool ResultsPartnerInsert(string proc, int ResultsId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教学成果获奖合作者修改
        /// </summary>
        /// <returns></returns>
        public bool ResultsPartnerUpdate(string proc, int ResultsPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsPartnerId", SqlDbType.Int).Value = ResultsPartnerId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PartnerRank", SqlDbType.Int).Value = PartnerRank;
                    com.Parameters.Add("@PartnerValue", SqlDbType.Float, 500).Value = PartnerValue;
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
        /// 教学成果获奖合作者删除
        /// </summary>
        /// <returns></returns>
        public bool ResultsPartnerDelete(string proc, int ResultsPartnerId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("ResultsPartnerId", SqlDbType.Int).Value = ResultsPartnerId;
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
        /// 教学成果获奖单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByResultsId(string proc, int ResultsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
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
        /// 教学成果获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectResults(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
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
        /// 个人教学成果获奖查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectResultsByUserCardId(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学成果获奖可审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet ResultsExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RankId", SqlDbType.VarChar, 50).Value = RankId;
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
        /// 教学成果获奖修改
        /// </summary>
        /// <returns></returns>
        public bool ResultsUpdate(string proc, int ResultsId,int DepartmentId, string ResultsName, string Category, string Awardlevel, string ResultsPrincipal, string Awarding_unit, string time, string Completion, double ResultsTotal, string ResultsDescription, string ResultsUrl, double ResultsValue, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ResultsName", SqlDbType.VarChar, 200).Value = ResultsName;
                    com.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category;
                    com.Parameters.Add("@Awardlevel", SqlDbType.VarChar, 50).Value = Awardlevel;
                    com.Parameters.Add("@ResultsPrincipal", SqlDbType.VarChar, 50).Value = ResultsPrincipal;
                    com.Parameters.Add("@Awarding_unit", SqlDbType.VarChar, 50).Value = Awarding_unit;
                    com.Parameters.Add("@time", SqlDbType.VarChar, 50).Value = time;
                    com.Parameters.Add("@Completion", SqlDbType.VarChar, 50).Value = Completion;
                    com.Parameters.Add("@ResultsTotal", SqlDbType.Float, 500).Value = ResultsTotal;
                    com.Parameters.Add("@ResultsDescription", SqlDbType.VarChar, 50).Value = ResultsDescription;
                    com.Parameters.Add("@ResultsUrl", SqlDbType.Text).Value = ResultsUrl;
                    com.Parameters.Add("@ResultsValue", SqlDbType.Float, 500).Value = ResultsValue;
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
        /// 教学成果获奖删除
        /// </summary>
        /// <returns></returns>
        public bool ResultsDelete(string proc, int ResultsId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
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
        /// 教学成果获奖审批添加
        /// </summary>
        /// <returns></returns>
        public bool ResultsExamineInsert(string proc, int ResultsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 教学成果获奖审批查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectResultsExamine(string proc, int ResultsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
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
        /// 教学成果获奖审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool ResultsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学成果获奖审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool ResultsProcessDelete(string proc, int ResultsProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsProcessId", SqlDbType.Int).Value = ResultsProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学成果获奖记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsResults(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string ResultsName, string Awardlevel, string ResultsYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@ResultsName", SqlDbType.VarChar, 50).Value = ResultsName;
                    sda.SelectCommand.Parameters.Add("@Awardlevel", SqlDbType.VarChar, 50).Value = Awardlevel;
                    sda.SelectCommand.Parameters.Add("@ResultsYear", SqlDbType.VarChar, 50).Value = ResultsYear;
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
        #region 专项分值

        /// <summary>
        /// 专项分值申请
        /// </summary>
        /// <returns></returns>
        public bool SpecialInsert(string proc, string UserCardId, int DepartmentId, string ContentName, string Score, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ContentName", SqlDbType.VarChar, 100).Value = ContentName;
                    com.Parameters.Add("@Score", SqlDbType.VarChar, 50).Value = Score;
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
        /// 专项分值修改
        /// </summary>
        /// <returns></returns>
        public bool SpecialUpdate(string proc, int SpecialId, int DepartmentId, string ContentName, string Score, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@SpecialId", SqlDbType.Int).Value = SpecialId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ContentName", SqlDbType.VarChar, 100).Value = ContentName;
                    com.Parameters.Add("@Score", SqlDbType.VarChar, 50).Value = Score;
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
        /// 专项分值单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectBySpecialId(string proc, int SpecialId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@SpecialId", SqlDbType.Int).Value = SpecialId;
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
        /// 专项分值删除
        /// </summary>
        /// <returns></returns>
        public bool SpecialDelete(string proc, int SpecialId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@SpecialId", SqlDbType.Int).Value = SpecialId;
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
        /// 专项分值审批添加
        /// </summary>
        /// <returns></returns>
        public bool SpecialExamineInsert(string proc, int SpecialId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@SpecialId", SqlDbType.Int).Value = SpecialId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 专项分值审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool SpecialProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专项分值审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool SpecialProcessDelete(string proc, int SpecialProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@SpecialProcessId", SqlDbType.Int).Value = SpecialProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 专项分值记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsSpecial(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string ContentName, string SpecialYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@ContentName", SqlDbType.VarChar, 50).Value = ContentName;
                    sda.SelectCommand.Parameters.Add("@SpecialYear", SqlDbType.VarChar, 50).Value = SpecialYear;
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
        #region 教学工作量转化教研分

        /// <summary>
        /// 教学工作量转化教研分申请
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingInsert(string proc, string UserCardId, int DepartmentId, string Quantity, string TotalScore, string Remarks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@Quantity", SqlDbType.VarChar, 50).Value = Quantity;
                    com.Parameters.Add("@TotalScore", SqlDbType.VarChar, 50).Value = TotalScore;
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
        /// 教学工作量转化教研分修改
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingUpdate(string proc, int TeachToTeachingId, int DepartmentId, string Quantity, string TotalScore, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachToTeachingId", SqlDbType.Int).Value = TeachToTeachingId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@Quantity", SqlDbType.VarChar, 50).Value = Quantity;
                    com.Parameters.Add("@TotalScore", SqlDbType.VarChar, 50).Value = TotalScore;
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
        /// 教学工作量转化教研分单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTeachToTeachingId(string proc, int TeachToTeachingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TeachToTeachingId", SqlDbType.Int).Value = TeachToTeachingId;
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
        /// 教学工作量转化教研分删除
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingDelete(string proc, int TeachToTeachingId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachToTeachingId", SqlDbType.Int).Value = TeachToTeachingId;
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
        /// 教学工作量转化教研分审批添加
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingExamineInsert(string proc, int TeachToTeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachToTeachingId", SqlDbType.Int).Value = TeachToTeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
                    com.Parameters.Add("@RankId", SqlDbType.Int).Value = RankId;
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
        /// 教学工作量转化教研分审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学工作量转化教研分审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingProcessDelete(string proc, int TeachToTeachingProcessId, string UserCardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachToTeachingProcessId", SqlDbType.Int).Value = TeachToTeachingProcessId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
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
        /// 教学工作量转化教研分记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsTeachToTeaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string Quantity, string TotalScore, string TeachToTeachingYear)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                    sda.SelectCommand.Parameters.Add("@Quantity", SqlDbType.VarChar, 50).Value = Quantity;
                    sda.SelectCommand.Parameters.Add("@TotalScore", SqlDbType.VarChar, 50).Value = TotalScore;
                    sda.SelectCommand.Parameters.Add("@TeachToTeachingYear", SqlDbType.VarChar, 50).Value = TeachToTeachingYear;
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
        #endregion

        #region
        /// <summary>
        /// 获奖审批修改
        /// </summary>
        /// <returns></returns>
        public bool WinningStatusModifyInsert(string proc, int WinningId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WinningId", SqlDbType.Int).Value = WinningId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 论文审批修改
        /// </summary>
        /// <returns></returns>
        public bool PaperStatusModifyInsert(string proc, int PaperId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PaperId", SqlDbType.Int).Value = PaperId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 工作量项目审批修改
        /// </summary>
        /// <returns></returns>
        public bool WorkLoadProjectsStatusModifyInsert(string proc, int WorkLoadProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkLoadProjectsId", SqlDbType.Int).Value = WorkLoadProjectsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 著作审批修改
        /// </summary>
        /// <returns></returns>
        public bool TeachingStatusModifyInsert(string proc, int TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachingId", SqlDbType.Int).Value = TeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 成果审批修改
        /// </summary>
        /// <returns></returns>
        public bool HarvestStatusModifyInsert(string proc, int HarvestId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HarvestId", SqlDbType.Int).Value = HarvestId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 专利审批修改
        /// </summary>
        /// <returns></returns>
        public bool PatentStatusModifyInsert(string proc, int PatentId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PatentId", SqlDbType.Int).Value = PatentId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 指导学生审批修改
        /// </summary>
        /// <returns></returns>
        public bool GuidanceStatusModifyInsert(string proc, int GuidanceId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@GuidanceId", SqlDbType.Int).Value = GuidanceId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
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
        /// 教材建设审批修改
        /// </summary>
        /// <returns></returns>
        public bool T_TeachingStatusModifyInsert(string proc, int T_TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@T_TeachingId", SqlDbType.Int).Value = T_TeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 教学团队建设审批修改
        /// </summary>
        /// <returns></returns>
        public bool Teaching_TeamStatusModifyInsert(string proc, int Teaching_TeamId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Teaching_TeamId", SqlDbType.Int).Value = Teaching_TeamId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 专业建设审批修改
        /// </summary>
        /// <returns></returns>
        public bool P_constructionStatusModifyInsert(string proc, int P_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@P_constructionId", SqlDbType.Int).Value = P_constructionId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 课程建设审批修改
        /// </summary>
        /// <returns></returns>
        public bool C_constructionStatusModifyInsert(string proc, int C_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_constructionId", SqlDbType.Int).Value = C_constructionId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
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
        /// 竞赛获奖审批修改
        /// </summary>
        /// <returns></returns>
        public bool C_winnersStatusModifyInsert(string proc, int C_winnersId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@C_winnersId", SqlDbType.Int).Value = C_winnersId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;
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
        /// 教学成果获奖审批修改
        /// </summary>
        /// <returns></returns>
        public bool ResultsStatusModifyInsert(string proc, int ResultsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ResultsId", SqlDbType.Int).Value = ResultsId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 专项分值审批修改
        /// </summary>
        /// <returns></returns>
        public bool SpecialStatusModifyInsert(string proc, int SpecialId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@SpecialId", SqlDbType.Int).Value = SpecialId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        /// 教学工作量转化教研分审批修改
        /// </summary>
        /// <returns></returns>
        public bool TeachToTeachingStatusModifyInsert(string proc, int TeachToTeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TeachToTeachingId", SqlDbType.Int).Value = TeachToTeachingId;
                    com.Parameters.Add("@ExamineOpinion", SqlDbType.VarChar, 400).Value = ExamineOpinion;
                    com.Parameters.Add("@ExamineUserCardId", SqlDbType.VarChar, 50).Value = ExamineUserCardId;
                    com.Parameters.Add("@ExamineResult", SqlDbType.VarChar, 50).Value = ExamineResult;

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
        #region 其他
        /// <summary>
        /// 职业资格单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByJobCertificateId(string proc, int JobCertificateId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobCertificateId", SqlDbType.Int, 32).Value = JobCertificateId;
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
        /// 历年获奖单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPastAwardsId(string proc, int PastAwardsId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PastAwardsId", SqlDbType.Int, 32).Value = PastAwardsId;
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
        /// 培训进修单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByStudyTrainId(string proc, int StudyTrainId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@StudyTrainId", SqlDbType.Int, 32).Value = StudyTrainId;
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


        public DataSet UserViewSelects(string proc, string Selects, string Wheres)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@SelectText", SqlDbType.VarChar).Value = Selects;
                    sda.SelectCommand.Parameters.Add("@WhereText", SqlDbType.VarChar).Value = Wheres;
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
