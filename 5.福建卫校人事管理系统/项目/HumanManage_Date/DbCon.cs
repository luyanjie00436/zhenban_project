using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManage_Data
{
    public class DbCon
    {
        protected static string conStr = ConfigurationManager.AppSettings["Human_ConStr"];
        #region 基础信息

        #region 基础
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
        /// <summary>
        /// 单个用户信息查询
        /// </summary>
        /// <param name="userCardId">userCardId</param>
        /// <returns>dataset</returns>
        public DataSet UserInfoS(string userCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter("UserInfo_SelectByUserCardId", con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = userCardId;
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
        #region 用户管理
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        public bool Abc_UserInsert(string proc, string UserName, string UserPwd)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserPwd", SqlDbType.VarChar,1999).Value = UserPwd;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns>
        public bool Abc_UserUpdate(string proc,int Id, string UserName, string UserPwd)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Id", SqlDbType.Int).Value =Id;
                    com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    com.Parameters.Add("@UserPwd", SqlDbType.VarChar,1999).Value = UserPwd;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet Abc_UserById(string proc, int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
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
        /// 用户信息删除
        /// </summary>
        /// <returns></returns>
        public bool A_UserDelete(string proc, int Id)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 整合查询
        /// <summary>
        /// 职称信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
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
        #endregion
        #region 个人基础信息

        public DataSet UseOfficeViewSelects(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar).Value = UserCardId;
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
        public bool JobInsert(string proc, string JobName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobName", SqlDbType.VarChar, 50).Value = JobName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool JobUpdate(string proc, int JobId, string JobName)
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

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool JobDelete(string proc, int JobId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级信息添加
        /// </summary>
        /// <returns></returns>
        public bool PostInsert(string proc, string PostName, string PlanPeople)
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

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool PostUpdate(string proc, int PostId, string PostName, string PlanPeople)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool PostDelete(string proc, int PostId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool RoleInsert(string proc, string RoleName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool RoleUpdate(string proc, int RoleId, string RoleName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool RoleDelete(string proc, int RoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        /// 行政隶属信息添加
        /// </summary>
        /// <returns></returns>
        public bool DepartmentInsert(string proc, string DepartmentName,string PreparedNumber,string PreparedPost,string PreparedProfession,string PreparedWorkers)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@PreparedNumber", SqlDbType.VarChar, 50).Value = PreparedNumber;
                    com.Parameters.Add("@PreparedPost", SqlDbType.VarChar, 50).Value = PreparedPost;
                    com.Parameters.Add("@PreparedProfession", SqlDbType.VarChar, 50).Value = PreparedProfession;
                    com.Parameters.Add("@PreparedWorkers", SqlDbType.VarChar, 50).Value = PreparedWorkers;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 行政隶属信息单个查询
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
        /// 行政隶属信息修改
        /// </summary>
        /// <returns></returns>
        public bool DepartmentUpdate(string proc, int DepartmentId, string DepartmentName,string PreparedNumber,string PreparedPost,string PreparedProfession,string PreparedWorkers)
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
                    com.Parameters.Add("@PreparedNumber", SqlDbType.VarChar, 50).Value = PreparedNumber;
                    com.Parameters.Add("@PreparedPost", SqlDbType.VarChar, 50).Value = PreparedPost;
                    com.Parameters.Add("@PreparedProfession", SqlDbType.VarChar, 50).Value = PreparedProfession;
                    com.Parameters.Add("@PreparedWorkers", SqlDbType.VarChar, 50).Value = PreparedWorkers;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        ///行政隶属职务数量查询
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
        /// 行政隶属信息删除
        /// </summary>
        /// <returns></returns>
        public bool DepartmentDelete(string proc, int DepartmentId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 按行政隶属查询行政隶属变动信息
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectDepartmentChange(string proc, int DepartmentId)
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
        #endregion
        #region 学位
        /// <summary>
        /// 学位信息添加
        /// </summary>
        /// <returns></returns>
        public bool DegreeInsert(string proc, string DegreeName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DegreeName", SqlDbType.VarChar, 50).Value = DegreeName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool DegreeUpdate(string proc, int DegreeId, string DegreeName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool DegreeDelete(string proc, int DegreeId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DegreeId", SqlDbType.Int).Value = DegreeId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool RankInsert(string proc, string RankName, string UserCardId, string RBL1)
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

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool RankUpdate(string proc, int RankId, string RankName, string UserCardId, string RBL1)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool RankDelete(string proc, int RankId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
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
        /// 用户角色信息添加
        /// </summary>
        /// <returns></returns>
        public bool UserRankInsert(string proc, string UserCardId, int RankId)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool UserEnableUpdate(string proc, string UserCardId, string UserEnable, string UserLock)
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
                    com.Parameters.Add("@UserLock", SqlDbType.VarChar, 50).Value = UserLock;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool EducationInsert(string proc, string EducationName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationName", SqlDbType.VarChar, 50).Value = EducationName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool EducationUpdate(string proc, int EducationId, string EducationName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool EducationDelete(string proc, int EducationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        /// 在职信息添加
        /// </summary>
        /// <returns></returns>
        public bool StatusInsert(string proc, string StatusName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StatusName", SqlDbType.VarChar, 50).Value = StatusName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 在职信息单个查询
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
        /// 在职信息修改
        /// </summary>
        /// <returns></returns>
        public bool StatusUpdate(string proc, int StatusId, string StatusName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        ///在职职务数量查询
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
        /// 在职信息删除
        /// </summary>
        /// <returns></returns>
        public bool StatusDelete(string proc, int StatusId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StatusId", SqlDbType.Int).Value = StatusId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool NationInsert(string proc, string NationName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@NationName", SqlDbType.VarChar, 50).Value = NationName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool NationUpdate(string proc, int NationId, string NationName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool NationDelete(string proc, int NationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@NationId", SqlDbType.Int).Value = NationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool PoliticalInsert(string proc, string PoliticalName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PoliticalName", SqlDbType.VarChar, 50).Value = PoliticalName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool PoliticalUpdate(string proc, int PoliticalId, string PoliticalName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool PoliticalDelete(string proc, int PoliticalId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PoliticalId", SqlDbType.Int).Value = PoliticalId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 用户
        /// <summary>
        /// 用户信息添加
        /// </summary>
        /// <returns></returns>
        public bool UserInfoInsert(string proc, string UserCardId, string UserPwd, string UserName, string UserSource)
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
                    com.Parameters.Add("@UserSource", SqlDbType.VarChar, 50).Value = UserSource;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserInfoUpdate(string proc,string UserCardId,string UserName,string UserGender,string IdCardNo,
            string NationName,string PoliticalName,string PartyDate,string TakeWorkDate,string EntryDate,string Origin,string Address,
            string StatusName,string GL_Management,string GL_CadreLevelName,string GL_RoleName,string GL_DepartmentName,string GL_StartDate,
            string GL_ManagerLevelName,string ZY_SkillTitle,string ZY_JobSeries,string ZY_TitleLevelName,string ZY_SpecialSkills,string ZY_DepartmentName,
            string ZY_StartDate,string JS_TeachersSeries,string JS_TeacherCategory,string JS_CertificateDate,string JS_MajorLeading,string JS_BoneTeacher,
            string JS_DoubleTeacher,string GQ_WorkersPeople,string GQ_PostName,string GQ_Appointment,string GQ_StartDate,string GQ_DepartmentName,string DYXL_Name,
            string DYXL_Date,string DYXL_School,string DYXL_Profession,string ZGXL_Name,string ZGXL_Date,string ZGXL_School,string ZGXL_Profession,
            string DYXW_Name,string DYXW_Date, string DYXW_School, string DYXW_Profession, string ZGXW_Name, string ZGXW_Date,
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
                    com.Parameters.Add("@GL_Management", SqlDbType.VarChar,10).Value = GL_Management;
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
                    com.Parameters.Add("@DYXW_School", SqlDbType.VarChar,100).Value = DYXW_School;
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
        /// 用户信息查询
        /// </summary>
        /// <returns></returns>
        public DataSet UserInfoSelect(string proc, string UserName, string StatusId, string StartYear, string EndYear, string Gender, string PoliticalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
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
        #endregion
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
        #region 职称申报
        /// <summary>
        /// 申报信息
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByApplyTitleIdId(string proc, int ApplyTitleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
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
        /// 部门下拉框绑定
        /// </summary>
        public DataSet Department(string proc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))//创建一个sql连接对象sqlconn；
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);//创建一个sql适配器对象sda，并同时让其使用sqlconn对象执行一条sql查询语句；
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;//设置对象的命令类型为文本型；
                    DataSet result = new DataSet();//创建一个数据集对象result； 
                    sda.Fill(result);//将sql执行的结果填充到result中；
                    con.Open();//让sql连接对象sqlconn打开，连接sql数据库；
                    return result;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>
        /// 职务下拉框
        /// </summary>
        public DataSet ApplyTitle(string proc)
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

        /// <summary>
        /// 职级下拉框
        /// </summary>
        public DataSet Post(string proc)
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
        /// <summary>
        /// 申请职称
        /// </summary>
        public bool ApplyTitleInsert(string proc, string UserCardId, string ApplyReason,  int DepartmentId, string ApplyTitle, string Post, string TitleSeries, string Major)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@ApplyReason", SqlDbType.VarChar, 50).Value = ApplyReason;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ApplyTitle", SqlDbType.VarChar, 50).Value = ApplyTitle;
                    com.Parameters.Add("@Post", SqlDbType.VarChar, 50).Value = Post;
                    com.Parameters.Add("@TitleSeries", SqlDbType.VarChar, 50).Value = TitleSeries;
                    com.Parameters.Add("@Major", SqlDbType.VarChar, 50).Value = Major;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public DataSet ApplyTitleProcessSelect(string proc)
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
        /// <summary>
        /// 申请职称审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 申请职称审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleProcessDelete(string proc, int ApplyTitleProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyTitleProcessId", SqlDbType.Int).Value = ApplyTitleProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)//返回数据库中的几行受影响，执行成功一条数据被删除返回1>0，建表陈功返回-1
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 个人申请职称查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByApplyTitleUserCardId(string proc, string UserCardId)
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
        /// 申请职称删除
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleDelete(string proc, int ApplyTitleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 申请职称单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByApplyTitleId(string proc, int ApplyTitleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
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
        /// 申请职称修改
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleUpdate(string proc, int ApplyTitleId, string ApplyReason, int DepartmentId, string ApplyTitle, string Post, string TitleSeries, string Major)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    com.Parameters.Add("@ApplyReason", SqlDbType.VarChar, 50).Value = ApplyReason;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@ApplyTitle", SqlDbType.VarChar, 50).Value = ApplyTitle;
                    com.Parameters.Add("@Post", SqlDbType.VarChar, 50).Value = Post;
                    com.Parameters.Add("@TitleSeries", SqlDbType.VarChar, 50).Value = TitleSeries;
                    com.Parameters.Add("@Major", SqlDbType.VarChar, 50).Value = Major;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员申请记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTitleApplyer(string proc, string UserName, int Year, int Month)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
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
        /// 个人人员申请职称查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTitleApplyerByUserCardId(string proc, string UserCardId)
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
        ///获取分数
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet GetScore(string proc, int ApplyTitleId, string UserCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
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
        /// 申报职称审批添加
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleExamineInsert(string proc, int ApplyTitleId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
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
        /// 申报职称评审评分
        /// </summary>
        /// <returns></returns>
        public bool ApplyTitleFractionInsert(string proc, int ApplyTitleId,string UserCardId, int Fraction)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Fraction", SqlDbType.Int).Value = Fraction;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool Scdw(string proc, string filename, string filetype, string fileurl, int ApplyTitleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@filename", SqlDbType.VarChar, 100).Value = filename;
                    com.Parameters.Add("@filetype", SqlDbType.VarChar, 100).Value = filetype;
                    com.Parameters.Add("@fileurl", SqlDbType.VarChar, 900).Value = fileurl;
                    com.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// 删除附件
        /// </summary>

        public bool ApplyFileDelete(string proc, int FileId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("@FileId", SqlDbType.Int).Value = FileId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 附件管理
        /// </summary>
        public DataSet Scdwcx(string proc, int ApplyTitleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 附件编号查询
        /// </summary>
        public DataSet SelectByApplyTitleFileId(string proc, int FileId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@FileId", SqlDbType.Int).Value = FileId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 平均分以及人数
        /// </summary>
        public DataSet ApplyTitleFractionAandN(string proc, int ApplyTitleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ApplyTitleId", SqlDbType.Int).Value = ApplyTitleId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    con.Open();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        #region 职称聘任
        /// <summary>
        /// 职称聘任添加
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeInsert(string proc,string UserCardId,string AppointmentDate,string Profession,int ProfessionQualificationId,string Remarks,byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AppointmentDate", SqlDbType.VarChar, 50).Value = AppointmentDate;
                    com.Parameters.Add("@Profession", SqlDbType.VarChar, 50).Value = Profession;
                    com.Parameters.Add("@ProfessionQualificationId", SqlDbType.Int).Value = ProfessionQualificationId;                   
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称聘任单个查询
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
        /// 职称聘任查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet UseOfficeViewSelectsTexe(string proc, string Text)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Text", SqlDbType.VarChar,50).Value = Text;
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
        /// 职称聘任管理员修改
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeUpdate(string proc, int UseOfficeId,  string AppointmentDate, string Profession, int ProfessionQualificationId, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseOfficeId", SqlDbType.Int, 32).Value = UseOfficeId;
                    com.Parameters.Add("@AppointmentDate", SqlDbType.VarChar, 50).Value = AppointmentDate;
                    com.Parameters.Add("@Profession", SqlDbType.VarChar, 50).Value = Profession;
                    com.Parameters.Add("@ProfessionQualificationId", SqlDbType.VarChar, 50).Value = ProfessionQualificationId;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;
                   
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称聘任信息修改
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeStatusUpdate(string proc, int UseOfficeId, string UserCardId, string AppointmentDate, string Profession, int ProfessionQualificationId, string Remarks,string TransferStatus)
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
                    com.Parameters.Add("@AppointmentDate", SqlDbType.VarChar, 50).Value = AppointmentDate;
                    com.Parameters.Add("@Profession", SqlDbType.VarChar, 50).Value = Profession;
                    com.Parameters.Add("@ProfessionQualificationId", SqlDbType.VarChar, 50).Value = ProfessionQualificationId;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar,20).Value = TransferStatus;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称聘任删除
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
        /// <summary>
        /// 聘任职称审批添加
        /// </summary>
        /// <returns></returns>
        public bool UseOfficeExamineInsert(string proc, string UserCardId, int UseOfficeId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UseOfficeId", SqlDbType.Int).Value = UseOfficeId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 职业资格证书
        /// <summary>
        /// 职业资格添加
        /// </summary>
        /// <returns></returns>
        public bool JobCertificateInsert(string proc, string UserCardId, string JobQualificationName, string IsssueUnit, string JobDate, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@JobQualificationName", SqlDbType.VarChar, 50).Value = JobQualificationName;
                    com.Parameters.Add("@IsssueUnit", SqlDbType.VarChar, 50).Value = IsssueUnit;
                    com.Parameters.Add("@JobDate", SqlDbType.VarChar, 50).Value = JobDate;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职业资格修改
        /// </summary>
        /// <returns></returns>
        public bool JobCertificateUpdate(string proc, int JobCertificateId, string JobQualificationName, string IsssueUnit, string JobDate, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobCertificateId", SqlDbType.Int, 32).Value = JobCertificateId;
                    com.Parameters.Add("@JobQualificationName", SqlDbType.VarChar, 50).Value = JobQualificationName;
                    com.Parameters.Add("@IsssueUnit", SqlDbType.VarChar, 100).Value = IsssueUnit;
                    com.Parameters.Add("@JobDate", SqlDbType.VarChar, 50).Value = JobDate;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职业资格信息修改
        /// </summary>
        /// <returns></returns>
        public bool JobCertificateStayusUpdate(string proc, int JobCertificateId, string UserCardId, string JobQualificationName, string IsssueUnit, string JobDate, string Remarks, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobCertificateId", SqlDbType.Int, 32).Value = JobCertificateId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@JobQualificationName", SqlDbType.VarChar, 50).Value = JobQualificationName;
                    com.Parameters.Add("@IsssueUnit", SqlDbType.VarChar, 50).Value = IsssueUnit;
                    com.Parameters.Add("@JobDate", SqlDbType.VarChar, 50).Value = JobDate;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = TransferStatus;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
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
        /// 职业资格删除
        /// </summary>
        /// <returns></returns>
        public bool JobCertificateDelete(string proc, int JobCertificateId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobCertificateId", SqlDbType.Int, 32).Value = JobCertificateId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职业资格审批添加
        /// </summary>
        /// <returns></returns>
        public bool JobCertificateExamineInsert(string proc, string UserCardId, int JobCertificateId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobCertificateId", SqlDbType.Int).Value = JobCertificateId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 工作经历
        /// <summary>
        /// 工作经历添加
        /// </summary>
        /// <returns></returns>
        /// 
        public bool WorkExperienceInsert(string proc, string UserCardId, string StartDate, string EndDate, int DepartmentId, int RoleId, string Remarks, string IsNow)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@IsNow", SqlDbType.VarChar, 20).Value = IsNow;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 工作经历单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByWorkExperienceId(string proc, int WorkExperienceId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@WorkExperienceId", SqlDbType.Int, 32).Value = WorkExperienceId;
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
        /// 工作经历修改
        /// </summary>
        /// <returns></returns>
        public bool WorkExperienceUpdateNoTransferStatus(string proc, int WorkExperienceId, string StartDate, string EndDate, int DepartmentId, int RoleId, string Remarks, string IsNow)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkExperienceId", SqlDbType.Int, 32).Value = WorkExperienceId;

                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@IsNow", SqlDbType.VarChar, 20).Value = IsNow;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 工作经历管理员修改
        /// </summary>
        /// <returns></returns>
        public bool WorkExperienceStatusUpdate(string proc, int WorkExperienceId, string UserCardId, string StartDate, string EndDate, int DepartmentId, int RoleId, string Remarks, string IsNow, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkExperienceId", SqlDbType.Int, 32).Value = WorkExperienceId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@IsNow", SqlDbType.VarChar, 20).Value = IsNow;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = TransferStatus;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 工作经历删除
        /// </summary>
        /// <returns></returns>
        public bool WorkExperienceDelete(string proc, int WorkExperienceId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkExperienceId", SqlDbType.Int, 32).Value = WorkExperienceId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 工作经历审批添加
        /// </summary>
        /// <returns></returns>
        public bool WorkExperienceUpdateTransferStatus(string proc, string UserCardId, int WorkExperienceId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@WorkExperienceId", SqlDbType.Int).Value = WorkExperienceId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 社会兼职情况
        /// <summary>
        /// 社会兼职单个查询
        /// </summary>
        public DataSet SelectByParttimejobId(string proc, int ParttimejobId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ParttimejobId", SqlDbType.Int, 32).Value = ParttimejobId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
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
        /// 社会兼职情况查询
        /// </summary>
        public DataSet ParttimejobViewSelectsTexe(string proc, string Text)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Text", SqlDbType.VarChar, 50).Value = Text;
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
        /// 社会兼职情况添加
        /// </summary>
        public bool ParttimejobInsert(string proc, string UserCardId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@UnitName", SqlDbType.VarChar, 50).Value = UnitName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 社会兼职情况管理员修改
        /// </summary>
        public bool ParttimejobUpdate(string proc, int ParttimejobId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ParttimejobId", SqlDbType.Int, 32).Value = ParttimejobId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@UnitName", SqlDbType.VarChar, 50).Value = UnitName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 社会兼职情况信息修改
        /// </summary>
        public bool ParttimejobStayusUpdate(string proc, int ParttimejobId, string UserCardId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName, string TransferStatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ParttimejobId", SqlDbType.Int, 32).Value = ParttimejobId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@UnitName", SqlDbType.VarChar, 50).Value = UnitName;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        public bool ParttimejobDelete(string proc, int ParttimejobId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ParttimejobId", SqlDbType.Int).Value = ParttimejobId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 社会兼职审批添加
        /// </summary>
        /// <returns></returns>
        public bool ParttimejobExamineInsert(string proc, string UserCardId, int ParttimejobId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ParttimejobId", SqlDbType.Int).Value = ParttimejobId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 信息
        /// </summary>
        public DataSet ParttimejobViewSelects(string proc, string UserCardId)
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
        #endregion
        #region 培训进修情况
        /// <summary>
        /// 培训进行情况添加
        /// </summary>
        /// <returns></returns>
        public bool StudyTrainInsert(string proc, string UserCardId, string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TrainProjectName", SqlDbType.VarChar, 50).Value = TrainProjectName;
                    com.Parameters.Add("@TrainStartDate", SqlDbType.VarChar, 50).Value = TrainStartDate;
                    com.Parameters.Add("@TrainEndDate", SqlDbType.VarChar, 50).Value = TrainEndDate;
                    com.Parameters.Add("@TrainUnit", SqlDbType.VarChar,50).Value = TrainUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 培训进修修改
        /// </summary>
        /// <returns></returns>
        public bool StudyTrainUpdateNoTransferStatus(string proc, int StudyTrainId, string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StudyTrainId", SqlDbType.Int, 32).Value = StudyTrainId;
                    com.Parameters.Add("@TrainProjectName", SqlDbType.VarChar, 50).Value = TrainProjectName;
                    com.Parameters.Add("@TrainStartDate", SqlDbType.VarChar, 50).Value = TrainStartDate;
                    com.Parameters.Add("@TrainEndDate", SqlDbType.VarChar, 50).Value = TrainEndDate;
                    com.Parameters.Add("@TrainUnit", SqlDbType.VarChar, 50).Value = TrainUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 培训进修管理员修改
        /// </summary>
        /// <returns></returns>
        public bool StudyTrainUpdate(string proc, int StudyTrainId,string UserCardId, string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks,string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StudyTrainId", SqlDbType.Int, 32).Value = StudyTrainId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TrainProjectName", SqlDbType.VarChar, 50).Value = TrainProjectName;
                    com.Parameters.Add("@TrainStartDate", SqlDbType.VarChar, 50).Value = TrainStartDate;
                    com.Parameters.Add("@TrainEndDate", SqlDbType.VarChar, 50).Value = TrainEndDate;
                    com.Parameters.Add("@TrainUnit", SqlDbType.VarChar, 50).Value = TrainUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar,20).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 培训进修审批添加
        /// </summary>
        /// <returns></returns>
        public bool StudyTrainUpdateTransferStatus(string proc, string UserCardId, int StudyTrainId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@StudyTrainId", SqlDbType.Int).Value = StudyTrainId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 培训进修删除
        /// </summary>
        /// <returns></returns>
        public bool StudyTrainDelete(string proc, int StudyTrainId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@StudyTrainId", SqlDbType.Int, 32).Value = StudyTrainId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
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
        #region 历年获奖
        /// <summary>
        /// 培训进行情况添加
        /// </summary>
        /// <returns></returns>
        public bool PastAwardsInsert(string proc, string UserCardId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AwardProjectName", SqlDbType.VarChar, 50).Value = AwardProjectName;
                    com.Parameters.Add("@AwardDate", SqlDbType.VarChar, 50).Value = AwardDate;
                    com.Parameters.Add("@GrantUnit", SqlDbType.VarChar, 50).Value = GrantUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 历年获奖修改
        /// </summary>
        /// <returns></returns>
        public bool PastAwardsUpdateNoTransferStatus(string proc, int PastAwardsId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, byte[] CertificatePhoto)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PastAwardsId", SqlDbType.Int, 32).Value = PastAwardsId;
                    com.Parameters.Add("@AwardProjectName", SqlDbType.VarChar, 50).Value = AwardProjectName;
                    com.Parameters.Add("@AwardDate", SqlDbType.VarChar, 50).Value = AwardDate;
                    com.Parameters.Add("@GrantUnit", SqlDbType.VarChar, 50).Value = GrantUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@CertificatePhoto", SqlDbType.Image).Value = CertificatePhoto;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 历年获奖管理员修改
        /// </summary>
        /// <returns></returns>
        public bool PastAwardsUpdate(string proc, int PastAwardsId, string UserCardId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PastAwardsId", SqlDbType.Int, 32).Value = PastAwardsId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AwardProjectName", SqlDbType.VarChar, 50).Value = AwardProjectName;
                    com.Parameters.Add("@AwardDate", SqlDbType.VarChar, 50).Value = AwardDate;
                    com.Parameters.Add("@GrantUnit", SqlDbType.VarChar, 50).Value = GrantUnit;
                    com.Parameters.Add("@Remarks", SqlDbType.Text).Value = Remarks;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
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
        /// 历年获奖审批添加
        /// </summary>
        /// <returns></returns>
        public bool PastAwardsUpdateTransferStatus(string proc, string UserCardId, int PastAwardsId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PastAwardsId", SqlDbType.Int).Value = PastAwardsId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 历年获奖删除
        /// </summary>
        /// <returns></returns>
        public bool PastAwardsDelete(string proc, int PastAwardsId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PastAwardsId", SqlDbType.Int, 32).Value = PastAwardsId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 年度考核
        /// <summary>
        /// 年度考核添加
        /// </summary>
        /// <returns></returns>
        /// 
        public bool YearAssessmentInsert(string proc, string UserCardId, string Year, string WorkCompletion, string AssessmentGrade,  string Remarks )
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;
                    com.Parameters.Add("@WorkCompletion", SqlDbType.VarChar, 50).Value = WorkCompletion;
                    com.Parameters.Add("@AssessmentGrade", SqlDbType.VarChar, 50).Value = AssessmentGrade;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 年度考核单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByYearAssessmentId(string proc, int YearAssessmentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@YearAssessmentId", SqlDbType.Int, 32).Value = YearAssessmentId;
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
        /// 年度考核修改
        /// </summary>
        /// <returns></returns>
        public bool YearAssessmentUpdateNoTransferStatus(string proc, int YearAssessmentId, string Year, string WorkCompletion, string AssessmentGrade, string Remarks)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@YearAssessmentId", SqlDbType.Int, 32).Value = YearAssessmentId;
                    com.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;
                    com.Parameters.Add("@WorkCompletion", SqlDbType.VarChar, 50).Value = WorkCompletion;
                    com.Parameters.Add("@AssessmentGrade", SqlDbType.VarChar, 50).Value = AssessmentGrade;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
       
        /// <summary>
        /// 年度考核管理员修改
        /// </summary>
        /// <returns></returns>
        public bool YearAssessmentUpdate(string proc,int YearAssessmentId,string UserCardId,string Year,string WorkCompletion,string AssessmentGrade,string Remarks,string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@YearAssessmentId", SqlDbType.Int, 32).Value = YearAssessmentId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;
                    com.Parameters.Add("@WorkCompletion", SqlDbType.VarChar, 50).Value = WorkCompletion;
                    com.Parameters.Add("@AssessmentGrade", SqlDbType.VarChar, 50).Value = AssessmentGrade;
                    com.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = TransferStatus;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 年度考核删除
        /// </summary>
        /// <returns></returns>
        public bool YearAssessmentDelete(string proc, int YearAssessmentId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@YearAssessmentId", SqlDbType.Int, 32).Value = YearAssessmentId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 年度考核审批添加
        /// </summary>
        /// <returns></returns>
        public bool YearAssessmentUpdateTransferStatus(string proc, string UserCardId, int YearAssessmentId, string TransferStatus)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@YearAssessmentId", SqlDbType.Int).Value = YearAssessmentId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 50).Value = TransferStatus;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 其他信息
        /// <summary>
        /// 其他信息修改
        /// </summary>
        /// <returns></returns>
        public bool OtherUpdate(string proc, string UserCardId,string UserSource, string SchoolDate, string WorkLeave,string Prepared,string ForeignStaff)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UserSource", SqlDbType.VarChar, 50).Value = UserSource;
                    com.Parameters.Add("@SchoolDate", SqlDbType.VarChar, 50).Value = SchoolDate;
                    com.Parameters.Add("@WorkLeave", SqlDbType.VarChar, 50).Value = WorkLeave;
                    com.Parameters.Add("@Prepared", SqlDbType.VarChar, 50).Value = Prepared;
                    com.Parameters.Add("@ForeignStaff", SqlDbType.VarChar, 50).Value = ForeignStaff;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        public bool UseJobPostInsert(string proc, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent,string UserProfessional)
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
                    com.Parameters.Add("@UserProfessional", SqlDbType.VarChar, 50).Value = UserProfessional;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool UseJobPostUpdate(string proc, int UseJobPostId, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent,string UserProfessional)
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
                    com.Parameters.Add("@UserProfessional", SqlDbType.VarChar, 50).Value = UserProfessional;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool ModelDelete(string proc, int ModelId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
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
        /// <summary>
        /// 目录信息添加
        /// </summary>
        /// <returns></returns>
        public bool ModelInsert(string proc, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, int ModelNum)
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
                    com.Parameters.Add("@ModelFatherId", SqlDbType.Int, 32).Value = FatherModelId;
                    com.Parameters.Add("@ModelNum", SqlDbType.Int).Value = ModelNum;
                    com.Parameters.Add("@ModelFatherName", SqlDbType.VarChar, 50).Value = FatherModelName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool ModelUpdate(string proc, int ModelId, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, int ModelNum)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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

        /// <summary>
        /// 职务权限信息添加
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
        #region 其他
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
        /// 邮箱信息修改
        /// </summary>
        /// <returns></returns>
        public bool EmailUpdate(string proc, string UserCardId, string Number1, string Number2, string Number3)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@IndividuaNumber", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@WorkNumber", SqlDbType.VarChar, 50).Value = Number3;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool PhoneUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardIdId;
                    com.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar, 50).Value = Number1;
                    com.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50).Value = Number2;
                    com.Parameters.Add("@WorkNumber", SqlDbType.VarChar, 50).Value = Number3;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 教工通讯录查询
        /// </summary>
        /// <returns></returns>
        public DataSet AddressBookSelect(string proc, string UserName, string DepartmentId, string StatusId, string Gender, string Phone, string Email)
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
                    sda.SelectCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = Phone;
                    sda.SelectCommand.Parameters.Add("@EmailNumber", SqlDbType.VarChar, 50).Value = Email;
                    sda.SelectCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 4).Value = Gender;
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
        /// 用户职务信息添加
        /// </summary>    
        /// <returns></returns>
        public bool UserRoleInsert(string proc, string UserCardId, int DepartmentId, int RoleId)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool UserRoleUpdate(string proc, int UserRoleId, int DepartmentId, int RoleId)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool UserRoleDelete(string proc, int UserRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public bool AdminSeriesInsert(string proc, string AdminSeriesName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminSeriesName", SqlDbType.VarChar, 50).Value = AdminSeriesName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ProfessionQualificationInsert(string proc, string ProfessionQualificationName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProfessionQualificationName", SqlDbType.VarChar, 50).Value = ProfessionQualificationName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ProfessionQualificationDelete(string proc, int ProfessionQualificationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProfessionQualificationId", SqlDbType.Int).Value = ProfessionQualificationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataSet SelectByProfessionQualificationId(string proc, int ProfessionQualificationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ProfessionQualificationId", SqlDbType.Int).Value = ProfessionQualificationId;
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
        public bool ProfessionQualificationUpdate(string proc, int ProfessionQualificationId, string ProfessionQualificationName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProfessionQualificationId", SqlDbType.Int).Value = ProfessionQualificationId;
                    com.Parameters.Add("@ProfessionQualificationName", SqlDbType.VarChar, 50).Value = ProfessionQualificationName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool AdminSeriesUpdate(string proc, int AdminSeriesId, string AdminSeriesName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool AdminSeriesDelete(string proc, int AdminSeriesId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminSeriesId", SqlDbType.Int).Value = AdminSeriesId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
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
        public bool UserAdminSeriesInsert(string proc, string UserCardId, int AdminSeriesId)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool AdminRecordInsert(string proc, string UserCardId, int DepartmentId, int RoleId, string FollDate)
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
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool AdminRecordInsertName(string proc, string UserCardId, string UserName, string DepartmentName, string RoleName, string FollDate)
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
                    com.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50).Value = DepartmentName;
                    com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = RoleName;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool AdminRecordUpdate(string proc, int AdminRecordId, string UserCardId, int DepartmentId, int RoleId, string FollDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminRecordId", SqlDbType.Int).Value = AdminRecordId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool AdminRecordDelete(string proc, int AdminRecordId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AdminRecordId", SqlDbType.Int).Value = AdminRecordId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataSet SelectByAdminRecordId(string proc, int AdminRecordId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AdminRecordId", SqlDbType.Int).Value = AdminRecordId;
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
        public DataSet AdminRecordSelects(string proc, string UserCardId, string UserName, int DepartmentId, int RoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
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
        public bool JobRecordInsert(string proc, string UserCardId, int JobId, int PostId, string FollDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    com.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool JobRecordUpdate(string proc, int JobRecordId, string UserCardId, int JobId, int PostId, string FollDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobRecordId", SqlDbType.Int).Value = JobRecordId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
                    com.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                    com.Parameters.Add("@FollDate", SqlDbType.VarChar, 50).Value = FollDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool JobRecordDelete(string proc, int JobRecordId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobRecordId", SqlDbType.Int).Value = JobRecordId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataSet SelectByJobRecordId(string proc, int JobRecordId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobRecordId", SqlDbType.Int).Value = JobRecordId;
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
        public DataSet JobRecordSelects(string proc, string UserCardId, string UserName, int JobId, int PostId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
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
        #endregion

        #endregion
        #region 人员调配
        /// <summary>
        /// 人员调配申请
        /// </summary>
        /// <returns></returns>
        public bool TransferInsert(string proc, string UserCardId, int UseDepartmentId, int NewDepartmentId, string TransferDate, string TransferReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@UseDepartmentId", SqlDbType.Int).Value = UseDepartmentId;
                    com.Parameters.Add("@NewDepartmentId", SqlDbType.Int).Value = NewDepartmentId;
                    com.Parameters.Add("@TransferDate", SqlDbType.VarChar, 50).Value = TransferDate;
                    com.Parameters.Add("@TransferReason", SqlDbType.VarChar, 200).Value = TransferReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员调配单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTransferId(string proc, int TransferId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TransferId", SqlDbType.Int).Value = TransferId;
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
        /// 人员调配查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTransfer(string proc, string UserName, int Year, int Month)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
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
        /// 人员调配查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTransfers(string proc, string UserName, int DepartmentId, int DepartmentId1, int Year, int Month)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@DepartmentId1", SqlDbType.Int).Value = DepartmentId1;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
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
        /// 个人人员调配查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTransferByUserCardId(string proc, string UserCardId)
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
        /// 人员调配修改
        /// </summary>
        /// <returns></returns>
        public bool TransferUpdate(string proc,string UserCardId, int TransferId,int UseDepartmentId, int NewDepartmentId, string TransferDate, string TransferReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TransferId", SqlDbType.Int).Value = TransferId;
                    com.Parameters.Add("@UseDepartmentId", SqlDbType.Int).Value = UseDepartmentId;
                    com.Parameters.Add("@NewDepartmentId", SqlDbType.Int).Value = NewDepartmentId;
                    com.Parameters.Add("@TransferDate", SqlDbType.VarChar, 50).Value = TransferDate;
                    com.Parameters.Add("@TransferReason", SqlDbType.VarChar, 200).Value = TransferReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 人员调配删除
        /// </summary>
        /// <returns></returns>
        public bool TransferDelete(string proc, int TransferId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TransferId ", SqlDbType.Int).Value = TransferId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 离职退休
        /// <summary>
        /// 离职退休申请
        /// </summary>
        /// <returns></returns>
        public bool QuitInsert(string proc, string UserCardId, string Status, string QuitDate, string QuitReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = Status;
                    com.Parameters.Add("@QuitDate", SqlDbType.VarChar, 50).Value = QuitDate;
                    com.Parameters.Add("@QuitReason", SqlDbType.VarChar, 200).Value = QuitReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 离职退休修改
        /// </summary>
        /// <returns></returns>
        public bool QuitUpdate(string proc,string UserCardId, int QuitId, string Status, string QuitDate, string QuitReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@QuitId", SqlDbType.Int).Value = QuitId;
                    com.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = Status;
                    com.Parameters.Add("@QuitDate", SqlDbType.VarChar, 50).Value = QuitDate;
                    com.Parameters.Add("@QuitReason", SqlDbType.VarChar, 200).Value = QuitReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 离职退休单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByQuitId(string proc, int QuitId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@QuitId", SqlDbType.Int).Value = QuitId;
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
        /// 离职退休删除
        /// </summary>
        /// <returns></returns>
        public bool QuitDelete(string proc, int QuitId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@QuitId", SqlDbType.Int).Value = QuitId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
      
        /// <summary>
        /// 离职退休审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool QuitProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 离职退休审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectQuitProcess(string proc, int QuitRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@QuitRoleId", SqlDbType.Int).Value = QuitRoleId;
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
        /// 离职退休审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool QuitProcessDelete(string proc, int QuitProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@QuitProcessId", SqlDbType.Int).Value = QuitProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 延迟退休
        /// <summary>
        /// 延迟退休申请
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitInsert(string proc, string UserCardId, string DelayQuitReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DelayReason", SqlDbType.VarChar, 400).Value = DelayQuitReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 延迟退休修改
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitUpdate(string proc,string UserCardId, int DelayQuitId, string DelayQuitReason)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DelayQuitId", SqlDbType.Int).Value = DelayQuitId;
                    com.Parameters.Add("@DelayReason", SqlDbType.VarChar, 200).Value = DelayQuitReason;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 延迟退休单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByDelayQuitId(string proc, int DelayQuitId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@DelayQuitId", SqlDbType.Int).Value = DelayQuitId;
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
        /// 延迟退休删除
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitDelete(string proc, int DelayQuitId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DelayQuitId", SqlDbType.Int).Value = DelayQuitId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 延迟退休审批添加
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitExamineInsert(string proc, int DelayQuitId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DelayQuitId", SqlDbType.Int).Value = DelayQuitId;
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
        /// 延迟退休审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 延迟退休审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectDelayQuitProcess(string proc, int DelayQuitRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@DelayQuitRoleId", SqlDbType.Int).Value = DelayQuitRoleId;
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
        /// 延迟退休审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool DelayQuitProcessDelete(string proc, int DelayQuitProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@DelayQuitProcessId", SqlDbType.Int).Value = DelayQuitProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 奖惩
        /// <summary>
        /// 奖惩申请
        /// </summary>
        /// <returns></returns>
        public bool RewardInsert(string proc, string UserCardId, string RewardStatus, string RewardContent, string RewardCompany, string RewardDates, string RewardForm)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RewardStatus", SqlDbType.VarChar, 50).Value = RewardStatus;
                    com.Parameters.Add("@RewardContent", SqlDbType.VarChar, 50).Value = RewardContent;
                    com.Parameters.Add("@RewardCompany", SqlDbType.VarChar, 50).Value = RewardCompany;
                    com.Parameters.Add("@RewardDates", SqlDbType.VarChar, 50).Value = RewardDates;
                    com.Parameters.Add("@RewardForm", SqlDbType.VarChar, 50).Value = RewardForm;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 奖惩修改
        /// </summary>
        /// <returns></returns>
        public bool RewardUpdate(string proc,string UserCardId, int RewardId, string RewardStatus, string RewardContent, string RewardCompany, string RewardDates, string RewardForm)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RewardId", SqlDbType.Int).Value = RewardId;
                    com.Parameters.Add("@RewardStatus", SqlDbType.VarChar, 50).Value = RewardStatus;
                    com.Parameters.Add("@RewardContent", SqlDbType.VarChar, 50).Value = RewardContent;
                    com.Parameters.Add("@RewardCompany", SqlDbType.VarChar, 50).Value = RewardCompany;
                    com.Parameters.Add("@RewardDates", SqlDbType.VarChar, 50).Value = RewardDates;
                    com.Parameters.Add("@RewardForm", SqlDbType.VarChar, 50).Value = RewardForm;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 奖惩单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRewardId(string proc, int RewardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RewardId", SqlDbType.Int).Value = RewardId;
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
        /// 奖惩删除
        /// </summary>
        /// <returns></returns>
        public bool RewardDelete(string proc, int RewardId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RewardId", SqlDbType.Int).Value = RewardId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 奖惩审批添加
        /// </summary>
        /// <returns></returns>
        public bool RewardExamineInsert(string proc, int RewardId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RewardId", SqlDbType.Int).Value = RewardId;
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
        /// 奖惩审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool RewardProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 奖惩审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRewardProcess(string proc, int RewardRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RewardRoleId", SqlDbType.Int).Value = RewardRoleId;
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
        /// 奖惩审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool RewardProcessDelete(string proc, int RewardProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RewardProcessId", SqlDbType.Int).Value = RewardProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员奖惩查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectReward(string proc, string UserName, int Year, int Month,  string Reward)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                    sda.SelectCommand.Parameters.Add("@Reward", SqlDbType.VarChar, 50).Value = Reward;
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
        #region 请假
        /// <summary>
        /// 请假申请
        /// </summary>
        /// <returns></returns>
        public bool LeaveInsert(string proc, string UserCardId, string LeaveReason, string StartDate, string EndDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@LeaveReason", SqlDbType.VarChar, 400).Value = LeaveReason;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 400).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 400).Value = EndDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 请假修改
        /// </summary>
        /// <returns></returns>
        public bool LeaveUpdate(string proc,string UserCardId, int LeaveId, string LeaveReason, string StartDate, string EndDate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@LeaveId", SqlDbType.Int).Value = LeaveId;
                    com.Parameters.Add("@leaveReason", SqlDbType.VarChar, 200).Value = LeaveReason;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 400).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 400).Value = EndDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 请假单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByLeaveId(string proc, int LeaveId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LeaveId", SqlDbType.Int).Value = LeaveId;
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
        /// 请假删除
        /// </summary>
        /// <returns></returns>
        public bool LeaveDelete(string proc, int LeaveId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LeaveId", SqlDbType.Int).Value = LeaveId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 请假审批添加
        /// </summary>
        /// <returns></returns>
        public bool LeaveExamineInsert(string proc, int LeaveId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LeaveId", SqlDbType.Int).Value = LeaveId;
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
        /// 请假审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool LeaveProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 请假审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLeaveProcess(string proc, int LeaveRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@LeaveRoleId", SqlDbType.Int).Value = LeaveRoleId;
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
        /// 请假审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool LeaveProcessDelete(string proc, int LeaveProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@LeaveProcessId", SqlDbType.Int).Value = LeaveProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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

        #region 人员聘任管理
        /// <summary>
        /// 人员聘任管理信息添加
        /// </summary>
        /// <returns></returns>
        public bool UsePerAppInsert(string proc, string UserCardId, string DepartmentId, string AppJobId, string AppPostId, string StartDate, string EndDate, string AppSeries, string AppLevel, string IsCurrentApp,string UserCompact)
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
                    com.Parameters.Add("@AppJobId", SqlDbType.VarChar, 50).Value = AppJobId;
                    com.Parameters.Add("@AppPostId", SqlDbType.VarChar, 50).Value = AppPostId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@AppSeries", SqlDbType.VarChar, 50).Value = AppSeries;
                    com.Parameters.Add("@AppLevel", SqlDbType.VarChar, 50).Value = AppLevel;
                    com.Parameters.Add("@IsCurrentApp", SqlDbType.VarChar, 50).Value = IsCurrentApp;
                    com.Parameters.Add("@UserCompact", SqlDbType.VarChar, 50).Value = UserCompact;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员聘任管理信息单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet UsePerAppSelectByUsePerAppId(string proc, int UsePerAppId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UsePerAppId", SqlDbType.Int, 32).Value = UsePerAppId;
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
        /// 人员聘任管理信息修改
        /// </summary>
        /// <returns></returns>
        public bool UsePerAppUpdate(string proc, int UsePerAppId, string UserCardId, string DepartmentId, string AppJobId, string AppPostId, string StartDate, string EndDate, string AppSeries, string AppLevel, string IsCurrentApp,string UserCompact)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UsePerAppId", SqlDbType.Int, 32).Value = UsePerAppId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = DepartmentId;
                    com.Parameters.Add("@AppJobId", SqlDbType.VarChar, 50).Value = AppJobId;
                    com.Parameters.Add("@AppPostId", SqlDbType.VarChar, 50).Value = AppPostId;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@AppSeries", SqlDbType.VarChar, 50).Value = AppSeries;
                    com.Parameters.Add("@AppLevel", SqlDbType.VarChar, 50).Value = AppLevel;
                    com.Parameters.Add("@IsCurrentApp", SqlDbType.VarChar, 50).Value = IsCurrentApp;
                    com.Parameters.Add("@UserCompact", SqlDbType.VarChar, 50).Value = UserCompact;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员聘任管理信息删除
        /// </summary>
        /// <returns></returns>
        public bool UsePerAppDelete(string proc, int UsePerAppId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UsePerAppId", SqlDbType.Int, 32).Value = UsePerAppId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 进修培训
        /// <summary>
        /// 进修培训申请
        /// </summary>
        /// <returns></returns>
        public bool TraningInsert(string proc, string UserCardId, string TraningContent, string ProfessionalName, string StartDate, string EndDate, int UserRoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@ProfessionalName", SqlDbType.VarChar, 50).Value = ProfessionalName;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@TraningContent", SqlDbType.VarChar, 400).Value = TraningContent;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool FurtherFormInsert(string proc, string UserCardId, string LearningType, string LearningStyle, string LearningUnit,string StartDate,string EndDate, float Fund1, float Fund2, float Fund3,
               float Fund4, float FunOri1, float FunOri2, float FunOri3, float FunOri4, float FunOri5, string IsCertficateOrUnit)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TFUserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TFLearningType", SqlDbType.VarChar, 100).Value = LearningType;
                    com.Parameters.Add("@TFLearningStyle", SqlDbType.VarChar, 100).Value = LearningStyle;
                    com.Parameters.Add("@TFLearningUnit", SqlDbType.VarChar, 100).Value = LearningUnit;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@TFFund1", SqlDbType.Float, 10).Value = Fund1;
                    com.Parameters.Add("@TFFund2", SqlDbType.Float, 10).Value = Fund2;
                    com.Parameters.Add("@TFFund3", SqlDbType.Float, 10).Value = Fund3;
                    com.Parameters.Add("@TFFund4", SqlDbType.Float, 10).Value = Fund4;
                    com.Parameters.Add("@FunOri1", SqlDbType.VarChar, 100).Value = FunOri1;
                    com.Parameters.Add("@FunOri2", SqlDbType.VarChar, 100).Value = FunOri2;
                    com.Parameters.Add("@FunOri3", SqlDbType.VarChar, 100).Value = FunOri3;
                    com.Parameters.Add("@FunOri4", SqlDbType.VarChar, 100).Value = FunOri4;
                    com.Parameters.Add("@FunOri5", SqlDbType.VarChar, 100).Value = FunOri5;
                    com.Parameters.Add("@IsCertficateOrUnit", SqlDbType.VarChar, 10).Value = IsCertficateOrUnit;
                   
                  
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool FurtherFormInsert2(string proc, int TraningId, string UserCardId, string LearningType, string LearningStyle, string LearningUnit, string StartDate, string EndDate, float Fund1, float Fund2, float Fund3,
               float Fund4, float FunOri1, float FunOri2, float FunOri3, float FunOri4, float FunOri5, string IsCertficateOrUnit)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningId", SqlDbType.VarChar, 10).Value = TraningId;
                    com.Parameters.Add("@TFUserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@TFLearningType", SqlDbType.VarChar, 100).Value = LearningType;
                    com.Parameters.Add("@TFLearningStyle", SqlDbType.VarChar, 100).Value = LearningStyle;
                    com.Parameters.Add("@TFLearningUnit", SqlDbType.VarChar, 100).Value = LearningUnit;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@TFFund1", SqlDbType.Float, 10).Value = Fund1;
                    com.Parameters.Add("@TFFund2", SqlDbType.Float, 10).Value = Fund2;
                    com.Parameters.Add("@TFFund3", SqlDbType.Float, 10).Value = Fund3;
                    com.Parameters.Add("@TFFund4", SqlDbType.Float, 10).Value = Fund4;
                    com.Parameters.Add("@FunOri1", SqlDbType.VarChar, 100).Value = FunOri1;
                    com.Parameters.Add("@FunOri2", SqlDbType.VarChar, 100).Value = FunOri2;
                    com.Parameters.Add("@FunOri3", SqlDbType.VarChar, 100).Value = FunOri3;
                    com.Parameters.Add("@FunOri4", SqlDbType.VarChar, 100).Value = FunOri4;
                    com.Parameters.Add("@FunOri5", SqlDbType.VarChar, 100).Value = FunOri5;
                    com.Parameters.Add("@IsCertficateOrUnit", SqlDbType.VarChar, 10).Value = IsCertficateOrUnit;
                  
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 进修培训修改
        /// </summary>
        /// <returns></returns>
        public bool TraningUpdate(string proc, int TraningId, string TraningContent, string ProfessionalName, string StartDate, string EndDate, int UserRoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningId", SqlDbType.Int).Value = TraningId;
                    com.Parameters.Add("@ProfessionalName", SqlDbType.VarChar, 50).Value = ProfessionalName;
                    com.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@TraningContent", SqlDbType.VarChar, 400).Value = TraningContent;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 进修培训单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByTraningId(string proc, int TraningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TraningId", SqlDbType.Int).Value = TraningId;
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
        /// 进修培训删除
        /// </summary>
        /// <returns></returns>
        public bool TraningDelete(string proc, int TraningId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningId", SqlDbType.Int).Value = TraningId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool FurtherFormDelete(string proc, int TraningId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningId", SqlDbType.Int).Value = TraningId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 进修培训审批添加
        /// </summary>
        /// <returns></returns>
        public bool TraningExamineInsert(string proc, int TraningId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningId", SqlDbType.Int).Value = TraningId;
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
        /// 进修培训审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool TraningProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 进修培训审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectTraningProcess(string proc, int TraningRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TraningRoleId", SqlDbType.Int).Value = TraningRoleId;
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
        /// 进修培训审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool TraningProcessDelete(string proc, int TraningProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@TraningProcessId", SqlDbType.Int).Value = TraningProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public DataSet UserInfoS1(string userCardId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter("UserView_SelectByUserCardId", con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = userCardId;
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

        public DataSet UserInfoS2(int TraningId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter("Traning_SelectByTraningId", con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TraningId", SqlDbType.Int, 10).Value = TraningId;
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

        public bool AddTraningFurByUserCardId(string proc, string UserCardId, string TraningFurTime,
    string TraningFurUnit, string TraningFurContent, string TraningFurShape)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //sda.SelectCommand.Parameters.Add("@TraningFurId", SqlDbType.Int).Value = TraningFurId;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@TraningFurTime", SqlDbType.Date, 50).Value = DateTime.Parse(TraningFurTime);
                    sda.SelectCommand.Parameters.Add("@TraningFurUnit", SqlDbType.VarChar, 50).Value = TraningFurUnit;
                    sda.SelectCommand.Parameters.Add("@TraningFurContent", SqlDbType.VarChar, 50).Value = TraningFurContent;
                    sda.SelectCommand.Parameters.Add("@TraningFurShape", SqlDbType.VarChar, 50).Value = TraningFurShape;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public DataSet SelectTraningFurByUserCardId(string proc, string UserCardId)
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
        public bool AlterTraningFurByUserCardId(string proc, int TraningFurId, string UserCardId, string TraningFurTime,
            string TraningFurUnit, string TraningFurContent, string TraningFurShape)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TraningFurId", SqlDbType.Int).Value = TraningFurId;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@TraningFurTime", SqlDbType.Date, 50).Value = DateTime.Parse(TraningFurTime);
                    sda.SelectCommand.Parameters.Add("@TraningFurUnit", SqlDbType.VarChar, 50).Value = TraningFurUnit;
                    sda.SelectCommand.Parameters.Add("@TraningFurContent", SqlDbType.VarChar, 50).Value = TraningFurContent;
                    sda.SelectCommand.Parameters.Add("@TraningFurShape", SqlDbType.VarChar, 50).Value = TraningFurShape;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool deleteTraningFurByUserCardId(string proc, int TraningFurId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TraningFurId", SqlDbType.Int).Value = TraningFurId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion
        
        #region 出国
        /// <summary>
        /// 出国申请
        /// </summary>
        /// <returns></returns>
        public bool AbroadInsert(string proc, string UserCardId, string ProfessionalName, string Direction, string OneLanguage, string OneLanguageDegree, string TwoLanguage, string TwoLanguageDegree, string MainWord,string CountryName,string CountryDate, string Reward, string AbroadPlan)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@ProfessionalName", SqlDbType.VarChar, 50).Value = ProfessionalName;
                    com.Parameters.Add("@Direction", SqlDbType.VarChar, 50).Value = Direction;
                    com.Parameters.Add("@OneLanguage", SqlDbType.VarChar, 50).Value = OneLanguage;
                    com.Parameters.Add("@OneLanguageDegree", SqlDbType.VarChar, 50).Value = OneLanguageDegree;
                    com.Parameters.Add("@TwoLanguage", SqlDbType.VarChar, 50).Value = TwoLanguage;
                    com.Parameters.Add("@TwoLanguageDegree", SqlDbType.VarChar, 50).Value = TwoLanguageDegree;
                    com.Parameters.Add("@MainWord", SqlDbType.VarChar, 2000).Value = MainWord;
                    com.Parameters.Add("@CountryName", SqlDbType.VarChar, 50).Value = CountryName;
                    com.Parameters.Add("@CountryDate", SqlDbType.VarChar, 50).Value = CountryDate;
                    com.Parameters.Add("@Reward", SqlDbType.VarChar, 2000).Value = Reward;
                    com.Parameters.Add("@AbroadPlan", SqlDbType.VarChar, 2000).Value = AbroadPlan;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 出国修改
        /// </summary>
        /// <returns></returns>
        public bool AbroadUpdate(string proc,string UserCardId, int AbroadId, string ProfessionalName, string Direction, string OneLanguage, string OneLanguageDegree, string TwoLanguage, string TwoLanguageDegree, string MainWord,string CountryName,string CountryDate, string Reward, string AbroadPlan)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AbroadId", SqlDbType.Int).Value = AbroadId;
                    com.Parameters.Add("@ProfessionalName", SqlDbType.VarChar, 50).Value = ProfessionalName;
                    com.Parameters.Add("@Direction", SqlDbType.VarChar, 50).Value = Direction;
                    com.Parameters.Add("@OneLanguage", SqlDbType.VarChar, 50).Value = OneLanguage;
                    com.Parameters.Add("@OneLanguageDegree", SqlDbType.VarChar, 50).Value = OneLanguageDegree;
                    com.Parameters.Add("@TwoLanguage", SqlDbType.VarChar, 50).Value = TwoLanguage;
                    com.Parameters.Add("@TwoLanguageDegree", SqlDbType.VarChar, 50).Value = TwoLanguageDegree;
                    com.Parameters.Add("@MainWord", SqlDbType.VarChar, 2000).Value = MainWord;
                    com.Parameters.Add("@CountryName", SqlDbType.VarChar, 50).Value = CountryName;
                    com.Parameters.Add("@CountryDate", SqlDbType.VarChar, 50).Value = CountryDate;
                    com.Parameters.Add("@Reward", SqlDbType.VarChar, 2000).Value = Reward;
                    com.Parameters.Add("@AbroadPlan", SqlDbType.VarChar, 2000).Value = AbroadPlan;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 出国单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByAbroadId(string proc, int AbroadId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AbroadId", SqlDbType.Int).Value = AbroadId;
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
        /// 出国删除
        /// </summary>
        /// <returns></returns>
        public bool AbroadDelete(string proc, int AbroadId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AbroadId", SqlDbType.Int).Value = AbroadId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 出国审批添加
        /// </summary>
        /// <returns></returns>
        public bool AbroadExamineInsert(string proc, int AbroadId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AbroadId", SqlDbType.Int).Value = AbroadId;
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
        /// 出国审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool AbroadProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
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
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 出国审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectAbroadProcess(string proc, int AbroadRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AbroadRoleId", SqlDbType.Int).Value = AbroadRoleId;
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
        /// 出国审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool AbroadProcessDelete(string proc, int AbroadProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AbroadProcessId", SqlDbType.Int).Value = AbroadProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 职级考核
        /// <summary>
        /// 职级考核申请
        /// </summary>
        /// <returns></returns>
        public bool PostApplyInsert(string proc, string AssessmentName, int ApplyPostId, string ApplyContent, string StartDate, string EndDate, string ApplyDetailed)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyPost", SqlDbType.Int).Value = ApplyPostId;
                    com.Parameters.Add("@StartContent", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndContent", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级考核修改
        /// </summary>
        /// <returns></returns>
        public bool PostApplyUpdate(string proc, int PostApplyId, string AssessmentName, int ApplyPostId, string ApplyContent, string StartDate, string EndDate, string ApplyDetailed)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostApplyId", SqlDbType.Int).Value = PostApplyId;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyPost", SqlDbType.Int).Value = ApplyPostId;
                    com.Parameters.Add("@StartContent", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndContent", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级考核单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPostApplyId(string proc, int PostApplyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PostApplyId", SqlDbType.Int).Value = PostApplyId;
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
        /// 职级考核查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPostApply(string proc, string AssessmentName, int PostId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    sda.SelectCommand.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
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
        /// 职级考核删除
        /// </summary>
        /// <returns></returns>
        public bool PostApplyDelete(string proc, int PostApplyId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostApplyId", SqlDbType.Int).Value = PostApplyId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级考核报名
        /// </summary>
        /// <returns></returns>
        public bool PostRegistrationInsert(string proc, string UserCardId, int PostApplyId, int UserRoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PostApplyId", SqlDbType.Int).Value = PostApplyId;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级考核报名删除
        /// </summary>
        /// <returns></returns>
        public bool PostRegistrationDelete(string proc, int PostRegistrationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostRegistrationId", SqlDbType.Int).Value = PostRegistrationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级报名单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByPostRegistrationId(string proc, int PostRegistrationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PostRegistrationId", SqlDbType.Int).Value = PostRegistrationId;
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
        /// 职级报名审批添加
        /// </summary>
        /// <returns></returns>
        public bool PostRegistrationExamineInsert(string proc, int PostRegistrationId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostRegistrationId", SqlDbType.Int).Value = PostRegistrationId;
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
        /// 职级报名审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool PostProcessInsert(string proc, int PostRoleId, int ProcessRoleId, int ProcessOrder, string DepartmentName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostRoleId", SqlDbType.Int).Value = PostRoleId;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级报名审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPostProcess(string proc, int PostRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@PostRoleId", SqlDbType.Int).Value = PostRoleId;
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
        /// 职级报名审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool PostProcessDelete(string proc, int PostProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PostProcessId", SqlDbType.Int).Value = PostProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级历史查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectPostTransfer(string proc, string UserName, int DepartmentId, int PostId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
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
        #endregion
        #region 职称考核
        /// <summary>
        /// 职称考核申请
        /// </summary>
        /// <returns></returns>
        public bool JobApplyInsert(string proc, string AssessmentName, int ApplyJobId, string ApplyContent, string StartDate, string EndDate, string ApplyDetailed)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyJob", SqlDbType.Int).Value = ApplyJobId;
                    com.Parameters.Add("@StartContent", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndContent", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称考核修改
        /// </summary>
        /// <returns></returns>
        public bool JobApplyUpdate(string proc, int JobApplyId, string AssessmentName, int ApplyJobId, string ApplyContent, string StartDate, string EndDate, string ApplyDetailed)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobApplyId", SqlDbType.Int).Value = JobApplyId;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyJob", SqlDbType.Int).Value = ApplyJobId;
                    com.Parameters.Add("@StartContent", SqlDbType.VarChar, 50).Value = StartDate;
                    com.Parameters.Add("@EndContent", SqlDbType.VarChar, 50).Value = EndDate;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称考核单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByJobApplyId(string proc, int JobApplyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobApplyId", SqlDbType.Int).Value = JobApplyId;
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
        /// 职称考核查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectJobApply(string proc, string AssessmentName, int JobId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    sda.SelectCommand.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
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
        /// 职称考核删除
        /// </summary>
        /// <returns></returns>
        public bool JobApplyDelete(string proc, int JobApplyId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobApplyId", SqlDbType.Int).Value = JobApplyId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称考核报名
        /// </summary>
        /// <returns></returns>
        public bool JobRegistrationInsert(string proc, string UserCardId, int JobApplyId, int UserRoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@JobApplyId", SqlDbType.Int).Value = JobApplyId;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称考核报名删除
        /// </summary>
        /// <returns></returns>
        public bool JobRegistrationDelete(string proc, int JobRegistrationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobRegistrationId", SqlDbType.Int).Value = JobRegistrationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称报名单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByJobRegistrationId(string proc, int JobRegistrationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobRegistrationId", SqlDbType.Int).Value = JobRegistrationId;
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
        /// 职称报名审批添加
        /// </summary>
        /// <returns></returns>
        public bool JobRegistrationExamineInsert(string proc, int JobRegistrationId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobRegistrationId", SqlDbType.Int).Value = JobRegistrationId;
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
        /// 职称报名审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool JobProcessInsert(string proc, int JobRoleId, int ProcessRoleId, int ProcessOrder, string DepartmentName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobRoleId", SqlDbType.Int).Value = JobRoleId;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称报名审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectJobProcess(string proc, int JobRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@JobRoleId", SqlDbType.Int).Value = JobRoleId;
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
        /// 职称报名审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool JobProcessDelete(string proc, int JobProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobProcessId", SqlDbType.Int).Value = JobProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职称历史查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectJobTransfer(string proc, string UserName, int DepartmentId, int JobId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@JobId", SqlDbType.Int).Value = JobId;
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
        #endregion
        #region 干部考核
        /// <summary>
        /// 干部考核申请
        /// </summary>
        /// <returns></returns>
        public bool RoleApplyInsert(string proc,string UserCardId, string AssessmentName, int ApplyRoleId, string ApplyContent,  string ApplyDetailed,int ApplyYearId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyRole", SqlDbType.Int).Value = ApplyRoleId;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    com.Parameters.Add("@FollDate", SqlDbType.Int).Value = ApplyYearId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部考核修改
        /// </summary>
        /// <returns></returns>
        public bool RoleApplyUpdate(string proc, int RoleApplyId, string AssessmentName, int ApplyRoleId, string ApplyContent, string ApplyDetailed,int ApplyYearId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleApplyId", SqlDbType.Int).Value = RoleApplyId;
                    com.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    com.Parameters.Add("@ApplyRole", SqlDbType.Int).Value = ApplyRoleId;
                    com.Parameters.Add("@ApplyContent", SqlDbType.VarChar, 1000).Value = ApplyContent;
                    com.Parameters.Add("@ApplyDetailed", SqlDbType.VarChar, 1000).Value = ApplyDetailed;
                    com.Parameters.Add("@FollDate", SqlDbType.Int).Value = ApplyYearId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部考核单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRoleApplyId(string proc, int RoleApplyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleApplyId", SqlDbType.Int).Value = RoleApplyId;
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
        /// 干部考核查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRoleApply(string proc, string AssessmentName, int RoleId,int ApplyYearId,string UserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@AssessmentName", SqlDbType.VarChar, 50).Value = AssessmentName;
                    sda.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    sda.SelectCommand.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
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
        /// 干部考核删除
        /// </summary>
        /// <returns></returns>
        public bool RoleApplyDelete(string proc, int RoleApplyId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleApplyId", SqlDbType.Int).Value = RoleApplyId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部考核报名
        /// </summary>
        /// <returns></returns>
        public bool RoleRegistrationInsert(string proc, string UserCardId, int RoleApplyId, int UserRoleId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RoleApplyId", SqlDbType.Int).Value = RoleApplyId;
                    com.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部考核报名删除
        /// </summary>
        /// <returns></returns>
        public bool RoleRegistrationDelete(string proc, int RoleRegistrationId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleRegistrationId", SqlDbType.Int).Value = RoleRegistrationId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部报名单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRoleRegistrationId(string proc, int RoleRegistrationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleRegistrationId", SqlDbType.Int).Value = RoleRegistrationId;
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
        /// 干部报名审批添加
        /// </summary>
        /// <returns></returns>
        public bool RoleRegistrationExamineInsert(string proc, int RoleRegistrationId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleRegistrationId", SqlDbType.Int).Value = RoleRegistrationId;
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
        /// 干部报名审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool RoleProcessInsert(string proc, int RoleRoleId, int ProcessRoleId, int ProcessOrder, string DepartmentName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleRoleId;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部报名审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRoleProcess(string proc, int RoleRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleRoleId;
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
        /// 干部报名审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool RoleProcessDelete(string proc, int RoleProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleProcessId", SqlDbType.Int).Value = RoleProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 干部历史查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRoleTransfer(string proc, string UserName, int DepartmentId, int RoleId, int Year, int Month, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = DepartmentId;
                    sda.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
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
        /// 职务票数添加
        /// </summary>
        /// <returns></returns>
        public bool RoleVoteNumberInsert(string proc, int RoleId, int VoteNumber)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                    com.Parameters.Add("@VoteNumber", SqlDbType.Int).Value = VoteNumber;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职务票数单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRoleVoteId(string proc, int RoleVoteId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleVoteId", SqlDbType.Int).Value = RoleVoteId;
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
        /// 职务票数修改
        /// </summary>
        /// <returns></returns>
        public bool RoleVoteUpdate(string proc, int RoleVoteId, int VoteNumber)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleVoteId", SqlDbType.Int).Value = RoleVoteId;
                    com.Parameters.Add("@VoteNumber", SqlDbType.Int).Value = VoteNumber;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 职务投票删除
        /// </summary>
        /// <returns></returns>
        public bool RoleVoteDelete(string proc, int RoleVoteId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleVoteId", SqlDbType.Int).Value = RoleVoteId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 个人投票查询查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectVoteRecord(string proc, string UserCardId, int RoleApplyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@RoleRegistrationId", SqlDbType.Int).Value = RoleApplyId;
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
        /// 投票查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectVoteSunMary(string proc, int RoleApplyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RoleApplyId", SqlDbType.Int).Value = RoleApplyId;
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
        /// 个人投票删除
        /// </summary>
        /// <returns></returns>
        public bool VoteRecordDelete(string proc, int VoteRecordId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@VoteRecordId", SqlDbType.Int).Value = VoteRecordId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 个人投票
        /// </summary>
        /// <returns></returns>
        public bool VoteRecordInsert(string proc, int RoleRegistrationId, string UserCardId, string Support, int VoteNumber)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RoleRegistrationId", SqlDbType.Int).Value = RoleRegistrationId;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Support", SqlDbType.VarChar, 50).Value = Support;
                    com.Parameters.Add("@VoteNumber", SqlDbType.Int).Value = VoteNumber;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
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
        #region 简历
        /// <summary>
        /// 简历单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByResumeId(string proc, int ResumeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ResumeId", SqlDbType.Int).Value = ResumeId;
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
        /// 投递简历单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByResumeDeliveryId(string proc, int ResumeDeliveryId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ResumeDeliveryId", SqlDbType.Int).Value = ResumeDeliveryId;
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
        /// 投递简历查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectResumeDelivery(string proc, string UserCardId, string Name, int Year, int Month)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                    sda.SelectCommand.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
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
        /// 简历添加
        /// </summary>
        /// <returns></returns>
        public bool ResumeInsert(string proc, string UserCardId, string Name, string Gender, string Nation, string Origin, string BirthDay, string Marriage, string Education, string Degree, string political, string Height, string Professional, string Healthy, string Jobintention, string Graduated, string Phone, string Email, string Course, string Ability, string Certificate, string Practice, string Hobbies, string Reward, string Criticism, string Evaluation)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                    com.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
                    com.Parameters.Add("@Nation", SqlDbType.VarChar, 50).Value = Nation;
                    com.Parameters.Add("@Origin", SqlDbType.VarChar, 50).Value = Origin;
                    com.Parameters.Add("@Birthday", SqlDbType.VarChar, 50).Value = BirthDay;
                    com.Parameters.Add("@Marriage", SqlDbType.VarChar, 50).Value = Marriage;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = political;
                    com.Parameters.Add("@Height", SqlDbType.VarChar, 50).Value = Height;
                    com.Parameters.Add("@Professional", SqlDbType.VarChar, 50).Value = Professional;
                    com.Parameters.Add("@Healthy", SqlDbType.VarChar, 50).Value = Healthy;
                    com.Parameters.Add("@Jobintention", SqlDbType.VarChar, 50).Value = Jobintention;
                    com.Parameters.Add("@Graduated", SqlDbType.VarChar, 50).Value = Graduated;
                    com.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = Phone;
                    com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Certificate", SqlDbType.VarChar, 1000).Value = Certificate;
                    com.Parameters.Add("@Practice", SqlDbType.VarChar, 1000).Value = Practice;
                    com.Parameters.Add("@Hobbies", SqlDbType.VarChar, 1000).Value = Hobbies;
                    com.Parameters.Add("@Evaluation", SqlDbType.VarChar, 1000).Value = Evaluation;
                    com.Parameters.Add("@Reward", SqlDbType.VarChar, 1000).Value = Reward;
                    com.Parameters.Add("@Criticism", SqlDbType.VarChar, 1000).Value = Criticism;
                    com.Parameters.Add("@Ability", SqlDbType.VarChar, 1000).Value = Ability;
                    com.Parameters.Add("@Course", SqlDbType.VarChar, 1000).Value = Course;


                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


        /// <summary>
        /// 简历修改
        /// </summary>
        /// <returns></returns>
        public bool ResumeUpdate(string proc, int ResumeId, string Marriage, string Education, string Degree, string political, string Height, string Professional, string Healthy, string Jobintention, string Graduated, string Phone, string Email, string Course, string Ability, string Certificate, string Practice, string Hobbies, string Reward, string Criticism, string Evaluation)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("@ResumeId", SqlDbType.Int).Value = ResumeId;
                    com.Parameters.Add("@Marriage", SqlDbType.VarChar, 50).Value = Marriage;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = political;
                    com.Parameters.Add("@Height", SqlDbType.VarChar, 50).Value = Height;
                    com.Parameters.Add("@Professional", SqlDbType.VarChar, 50).Value = Professional;
                    com.Parameters.Add("@Healthy", SqlDbType.VarChar, 50).Value = Healthy;
                    com.Parameters.Add("@Jobintention", SqlDbType.VarChar, 50).Value = Jobintention;
                    com.Parameters.Add("@Graduated", SqlDbType.VarChar, 50).Value = Graduated;
                    com.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = Phone;
                    com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                    com.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = Degree;
                    com.Parameters.Add("@Certificate", SqlDbType.VarChar, 1000).Value = Certificate;
                    com.Parameters.Add("@Practice", SqlDbType.VarChar, 1000).Value = Practice;
                    com.Parameters.Add("@Hobbies", SqlDbType.VarChar, 1000).Value = Hobbies;
                    com.Parameters.Add("@Evaluation", SqlDbType.VarChar, 1000).Value = Evaluation;
                    com.Parameters.Add("@Reward", SqlDbType.VarChar, 1000).Value = Reward;
                    com.Parameters.Add("@Criticism", SqlDbType.VarChar, 1000).Value = Criticism;
                    com.Parameters.Add("@Ability", SqlDbType.VarChar, 1000).Value = Ability;
                    com.Parameters.Add("@Course", SqlDbType.VarChar, 1000).Value = Course;


                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 简历查询查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectResume(string proc, string UserName, string Education, string Political, string Professional)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    sda.SelectCommand.Parameters.Add("@Political", SqlDbType.VarChar, 50).Value = Political;
                    sda.SelectCommand.Parameters.Add("@Professional", SqlDbType.VarChar, 50).Value = Professional;
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
        #region 职级招聘
        /// <summary>
        /// 职级招聘申请
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentInsert(string proc, string UserCardId, string PostName, string Professional, string Education, string Other, string Number, string Money)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@PostName", SqlDbType.VarChar, 50).Value = PostName;
                    com.Parameters.Add("@Professional", SqlDbType.VarChar, 50).Value = Professional;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Other", SqlDbType.VarChar, 200).Value = Other;
                    com.Parameters.Add("@Money", SqlDbType.VarChar, 50).Value = Money;
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
        /// 职级招聘修改
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentUpdate(string proc,string UserCardId, int RecruitmentId, string PostName, string Professional, string Education, string Other, string Number, string Money)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@RecruitmentId", SqlDbType.Int).Value = RecruitmentId;
                    com.Parameters.Add("@PostName", SqlDbType.VarChar, 50).Value = PostName;
                    com.Parameters.Add("@Professional", SqlDbType.VarChar, 50).Value = Professional;
                    com.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = Education;
                    com.Parameters.Add("@Other", SqlDbType.VarChar, 200).Value = Other;
                    com.Parameters.Add("@Money", SqlDbType.VarChar, 50).Value = Money;
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
        /// 职级招聘单个查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectByRecruitmentId(string proc, int RecruitmentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RecruitmentId", SqlDbType.Int).Value = RecruitmentId;
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
        /// 职级招聘删除
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentDelete(string proc, int RecruitmentId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RecruitmentId", SqlDbType.Int).Value = RecruitmentId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级招聘审批添加
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentExamineInsert(string proc, int RecruitmentId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RecruitmentId", SqlDbType.Int).Value = RecruitmentId;
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
        /// 职级招聘审批流程添加
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentProcessInsert(string proc, int RecruitmentRoleId, int ProcessRoleId, int ProcessOrder, string DepartmentName)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RecruitmentRoleId", SqlDbType.Int).Value = RecruitmentRoleId;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 职级招聘审批流程查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRecruitmentProcess(string proc, int RecruitmentRoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@RecruitmentRoleId", SqlDbType.Int).Value = RecruitmentRoleId;
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
        /// 职级招聘审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool RecruitmentProcessDelete(string proc, int RecruitmentProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RecruitmentPostProcessId", SqlDbType.Int).Value = RecruitmentProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 人员职级招聘查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectRecruitment(string proc, string UserName, int DepartmentId, int Year, int Month, string Status, string Recruitment)
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
                    sda.SelectCommand.Parameters.Add("@Recruitment", SqlDbType.VarChar, 50).Value = Recruitment;
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
        #region 减免工作量

        /// 减免工作量添加
        /// </summary>

        public bool ReductionInsert(string proc, string UserCardId, string Reason, string RatedOne, string ReductionOne, string ProportionOne, string RatedTwo, string ReductionTwo, string ProportionTwo, string RatedThree, string ReductionThree, string ProportionThree, string WhetherStop, string StopProportion, string StopDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    com.Parameters.Add("@Reason", SqlDbType.Text).Value = Reason;
                    com.Parameters.Add("@RatedOne", SqlDbType.VarChar, 50).Value = RatedOne;
                    com.Parameters.Add("@ReductionOne", SqlDbType.VarChar, 50).Value = ReductionOne;
                    com.Parameters.Add("@ProportionOne", SqlDbType.VarChar, 50).Value = ProportionOne;
                    com.Parameters.Add("@RatedTwo", SqlDbType.VarChar, 50).Value = RatedTwo;
                    com.Parameters.Add("@ReductionTwo", SqlDbType.VarChar, 50).Value = ReductionTwo;
                    com.Parameters.Add("@ProportionTwo", SqlDbType.VarChar, 50).Value = ProportionTwo;
                    com.Parameters.Add("@RatedThree", SqlDbType.VarChar, 50).Value = RatedThree;
                    com.Parameters.Add("@ReductionThree", SqlDbType.VarChar, 50).Value = ReductionThree;
                    com.Parameters.Add("@ProportionThree", SqlDbType.VarChar, 50).Value = ProportionThree;
                    com.Parameters.Add("@WhetherStop", SqlDbType.VarChar, 50).Value = WhetherStop;
                    com.Parameters.Add("@StopProportion", SqlDbType.VarChar, 50).Value = StopProportion;
                    com.Parameters.Add("@StopDate", SqlDbType.VarChar, 50).Value = StopDate;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 减免工作量修改
        /// </summary>

        public bool ReductionUpdate(string proc, int ReductionId, string Reason, string RatedOne, string ReductionOne, string ProportionOne, string RatedTwo, string ReductionTwo, string ProportionTwo, string RatedThree, string ReductionThree, string ProportionThree, string WhetherStop, string StopProportion, string StopDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ReductionId", SqlDbType.Int).Value = ReductionId;
                    com.Parameters.Add("@Reason", SqlDbType.Text).Value = Reason;
                    com.Parameters.Add("@RatedOne", SqlDbType.VarChar, 50).Value = RatedOne;
                    com.Parameters.Add("@ReductionOne", SqlDbType.VarChar, 50).Value = ReductionOne;
                    com.Parameters.Add("@ProportionOne", SqlDbType.VarChar, 50).Value = ProportionOne;
                    com.Parameters.Add("@RatedTwo", SqlDbType.VarChar, 50).Value = RatedTwo;
                    com.Parameters.Add("@ReductionTwo", SqlDbType.VarChar, 50).Value = ReductionTwo;
                    com.Parameters.Add("@ProportionTwo", SqlDbType.VarChar, 50).Value = ProportionTwo;
                    com.Parameters.Add("@RatedThree", SqlDbType.VarChar, 50).Value = RatedThree;
                    com.Parameters.Add("@ReductionThree", SqlDbType.VarChar, 50).Value = ReductionThree;
                    com.Parameters.Add("@ProportionThree", SqlDbType.VarChar, 50).Value = ProportionThree;
                    com.Parameters.Add("@WhetherStop", SqlDbType.VarChar, 50).Value = WhetherStop;
                    com.Parameters.Add("@StopProportion", SqlDbType.VarChar, 50).Value = StopProportion;
                    com.Parameters.Add("@StopDate", SqlDbType.VarChar, 50).Value = StopDate;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 减免工作量删除
        /// </summary>

        public bool ReductionDelete(string proc, int ReductionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ReductionId", SqlDbType.Int).Value = ReductionId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 按减免工作量编号查询
        /// </summary>

        public DataSet SelectByReductionId(string proc, int ReductionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ReductionId", SqlDbType.Int, 32).Value = ReductionId;
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
        /// 按编号信息查询
        /// </summary>
        /// <param name="userCardId">userCardId</param>
        /// <returns>dataset</returns>
        public DataSet SelectByReductionId(string proc, string ReductionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@ReductionId", SqlDbType.VarChar, 50).Value = ReductionId;
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
        /// 减免工作量审批流程添加
        /// </summary>
        public bool ReductionProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ProcessRoleId", SqlDbType.Int, 32).Value = ProcessRoleId;
                    com.Parameters.Add("@ProcessOrder", SqlDbType.Int, 32).Value = ProcessOrder;
                    com.Parameters.Add("@ProcessDepartment", SqlDbType.VarChar, 50).Value = DepartmentName;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 减免工作量审批添加
        /// </summary>
        /// <returns></returns>
        public bool ReductionExamineInsert(string proc, int ReductionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ReductionId", SqlDbType.Int, 32).Value = ReductionId;
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
        /// 减免工作量审批流程删除
        /// </summary>
        public bool ReductionProcessDelete(string proc, int ReductionProcessId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@ReductionProcessId", SqlDbType.Int, 32).Value = ReductionProcessId;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 减免工作量记录查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsReduction(string proc, string UserName)
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

        #region 申报时间

        /// <summary>
        /// 申报时间信息修改
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearUpdate(string proc, int ApplyYearId, string StartDate, string EndDate, string UserCardId)
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
        /// 申报时间信息添加
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearInsert(string proc, string StartDate, string EndDate, string UserCardId)
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
        /// 申报时间信息删除
        /// </summary>
        /// <returns></returns>
        public bool ApplyYearDelete(string proc, int ApplyYearId, string UserCardId)
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



        #region 技术人员继续教育学时统计表


        /// <summary>
        /// 显示学时表
        /// </summary>
        public DataSet TechnicianEducationSelectByUserCardId(string proc, string UserCardId, int ApplyYearId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取申报年份
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public DataSet GetYear(string proc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool TechnicianEducationDeleting(string proc, int EducationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@EducationId", SqlDbType.VarChar,50).Value = EducationId;
             
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        ///学时记录 删除
        /// </summary>
        public bool ApplyPeriodViewDeleting(string proc, int bianhao)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@bianhao", SqlDbType.VarChar, 50).Value = bianhao;

                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public DataSet TechnicianEducationUpdate(string proc, int EducationId, string Project, string EducationSituation, int DeclarePeriod, int InspectPeriod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    sda.SelectCommand.Parameters.Add("@Project", SqlDbType.VarChar, 50).Value = Project;
                    sda.SelectCommand.Parameters.Add("@EducationSituation", SqlDbType.NVarChar, 50).Value = EducationSituation;
                    sda.SelectCommand.Parameters.Add("@DeclarePeriod", SqlDbType.Int).Value = DeclarePeriod;
                    sda.SelectCommand.Parameters.Add("@InspectPeriod", SqlDbType.Int).Value = InspectPeriod;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        public DataSet GetUserMessage(string proc, string UserCardId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 获取人员申请学时信息
        /// </summary>
        public DataSet SelectByHoursAppId(string proc, int HoursAppId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@HoursAppId", SqlDbType.Int).Value = HoursAppId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        public DataSet GetUserMessage(string proc, string UserCardId, int ApplyYearId, string Project, string EducationSituation, int DeclarePeriod, int InspectPeriod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@ApplyYearId", SqlDbType.Int).Value = ApplyYearId;
                    sda.SelectCommand.Parameters.Add("@Project", SqlDbType.VarChar, 50).Value = Project;
                    sda.SelectCommand.Parameters.Add("@EducationSituation", SqlDbType.NVarChar, 50).Value = EducationSituation;
                    sda.SelectCommand.Parameters.Add("@DeclarePeriod", SqlDbType.Int).Value = DeclarePeriod;
                    sda.SelectCommand.Parameters.Add("@InspectPeriod", SqlDbType.Int).Value = InspectPeriod;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 学时提交审批添加
        /// </summary>
        public DataSet HoursInsert(string proc, string UserCardId, int UserRoleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserCardId", SqlDbType.VarChar, 50).Value = UserCardId;
                    sda.SelectCommand.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = UserRoleId;
                  
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 学时申报审批流程删除
        /// </summary>
        /// <returns></returns>
        public bool ApplyPeriodManageProcessDelete(string proc, int HoursProcessId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HoursProcessId", SqlDbType.Int).Value = HoursProcessId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 学时审批添加
        /// </summary>
        /// <returns></returns>
        public bool DelayHoursExamineInsert(string proc, int HoursAppId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@HoursAppId", SqlDbType.Int).Value = HoursAppId;
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
        ///获取详情
        /// </summary>
        public DataSet TechnicianEducationGetItem(string proc, int EducationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@EducationId", SqlDbType.Int).Value = EducationId;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }
        public DataSet GetYearId(string proc, string Year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;
                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        /// <summary>
        /// 获取所有人的申报学时信息
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>

        public DataSet TechnicianEducationGetAll(string proc,string UserName,string Year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(proc, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 50).Value = Year;



                    DataSet result = new DataSet();
                    sda.Fill(result);
                    conn.Open();
                    return result;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        #endregion


        /// <summary>
        /// 统计查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet tongjiSelect(string proc, string TongjiValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@TongjiValue", SqlDbType.VarChar,50).Value = TongjiValue;
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

        /// <summary>
        /// 申报时间信息修改
        /// </summary>
        /// <returns></returns>
        public bool Update(string proc)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
