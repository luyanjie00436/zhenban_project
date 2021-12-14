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
   public class MDBCon
    {

        protected static string conStr = ConfigurationManager.AppSettings["Scien_ConStr2"];
        #region 岗位信息
        /// <summary>
        /// 岗位添加
        /// </summary>
        /// <returns></returns>
        public bool JobMangeInsert(string proc, string JobCode, string JobName, string Enrollment, string Age, string Education,
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
        /// 岗位修改
        /// </summary>
        /// <returns></returns>
        public bool JobMangeUpdate(string proc, int JobMangeId, string JobCode, string JobName, string Enrollment, string Age, string Education,
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
        /// 岗位删除
        /// </summary>
        /// <returns></returns>
        public bool JobMangeDelete(string proc, int JobMangeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        /// 岗位统计查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet JobMange_SelectByYear(string proc, string Year)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(proc, con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar,50).Value = Year;
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
        /// 岗位查询查询
        /// </summary>
        public DataSet JobMange_Selects(string proc, string JobName, string SubjectName, string Culture, string Political, string Recruitment, string Gender, string Should, string Nation, string Degree, string Position, string Education, string Age, string Profession, string Sort,string Years)
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
                    sda.SelectCommand.Parameters.Add("@Years", SqlDbType.VarChar, 50).Value = Years;
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
                    sda.SelectCommand.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number;
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
        #region 岗位信息
        /// <summary>
        /// 岗位报名
        /// </summary>
        /// <returns></returns>
        public bool JobInsert(string proc, int JobMangeId, string Number )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobMangeId", SqlDbType.Int).Value = JobMangeId;
                    com.Parameters.Add("@Number", SqlDbType.VarChar, 20).Value = Number;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        } 
        /// <summary>
           /// 岗位审核
           /// </summary>
           /// <returns></returns>
        public bool Job_Update(string proc, int JobId, string Transfer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.VarChar, 20).Value = JobId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = Transfer;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 岗位审核
        /// </summary>
        /// <returns></returns>
        public bool Job_Update2(string proc, int JobId, string Transfer,string Contents)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.VarChar, 20).Value = JobId;
                    com.Parameters.Add("@TransferStatus", SqlDbType.VarChar, 20).Value = Transfer;
                    com.Parameters.Add("@Contents", SqlDbType.VarChar, 20).Value = Contents;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 岗位审核
        /// </summary>
        /// <returns></returns>
        public bool JobGrade_Update(string proc, int JobId, string Grade)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand com = new SqlCommand(proc, con);
                    com.CommandText = proc;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@JobId", SqlDbType.VarChar, 20).Value = JobId;
                    com.Parameters.Add("@Grade", SqlDbType.VarChar, 20).Value = Grade;
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 岗位报名查询
        /// </summary>
        /// <returns></returns>
        public DataSet Job_Selects(string proc, string Number, string Name, string IdCard, string Phone, string Email, string Institutions, string ProfessionName, string Sort,int JobMangeId)
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
                    sda.SelectCommand.Parameters.Add("@JobMangeId", SqlDbType.VarChar, 50).Value = JobMangeId;
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
        /// 岗位报名编号查询
        /// </summary>
        /// <returns></returns>
        public DataSet Job_SelectByJobId(string proc,int JobId)
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
        #endregion
    }
}
