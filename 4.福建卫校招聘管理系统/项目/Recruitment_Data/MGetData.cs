using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Data
{
   
   public class MGetData
    {
        MDBCon human = new MDBCon();
        #region 岗位信息
        /// <summary>
        /// 岗位添加
        /// </summary>
        public bool JobMangeInsert(string proc, string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree, string Gender, string Nation, string Political, string Should,
                                   string Recruitment, string Position, string JobsYears, string SubjectName,
                                   string ApplyCost, string Profession, string Others, string Remarks)
        {
            return human.JobMangeInsert(proc, JobCode, JobName, Enrollment, Age, Education, Culture, Degree, Gender, Nation,
                                         Political, Should, Recruitment, Position, JobsYears, SubjectName, ApplyCost,
                                         Profession, Others, Remarks);
        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        public bool JobMangeUpdate(string proc, int JobMangeId, string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree, string Gender, string Nation, string Political, string Should,
                                   string Recruitment, string Position, string JobsYears, string SubjectName,
                                   string ApplyCost, string Profession, string Others, string Remarks)
        {
            return human.JobMangeUpdate(proc, JobMangeId, JobCode, JobName, Enrollment, Age, Education, Culture, Degree, Gender, Nation,
                                         Political, Should, Recruitment, Position, JobsYears, SubjectName, ApplyCost,
                                         Profession, Others, Remarks);
        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        public bool JobMangeDelete(string proc, int JobMangeId)
        {
            return human.JobMangeDelete(proc, JobMangeId);
        }
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_SelectByJobMangeId(string proc, int JobMangeId)
        {
            return human.JobMange_SelectByJobMangeId(proc, JobMangeId);

        }
        /// <summary>
        /// 岗位统计查询
        /// </summary>
        public DataSet JobMange_SelectByYear(string proc, string Year)
        {
            return human.JobMange_SelectByYear(proc, Year);

        }
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_Selects(string proc, string JobName, string SubjectName, string Culture, string Political, string Recruitment, string Gender, string Should, string Nation, string Degree, string Position, string Education, string Age, string Profession, string Sort,string Years)
        {
            return human.JobMange_Selects(proc, JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort,Years);

        }
        /// <summary>
        /// 考生信息单个查询
        /// </summary>
        public DataSet SelectByNumber(string proc, string Number)
        {
            return human.SelectByNumber(proc, Number);
        }

        #endregion
        #region 岗位报名
        /// <summary>
        /// 岗位报名
        /// </summary>
        public bool JobInsert(string proc, int JobMangeId, string Number)
        {
            return human.JobInsert(proc, JobMangeId, Number);
        }
        /// <summary>
        /// 岗位报名查询
        /// </summary>
        public DataSet Job_Selects(string proc, string Number, string Name, string IdCard, string Phone, string Email, string Institutions, string ProfessionName, string Sort,int JobMangeId)
        {
            return human.Job_Selects(proc, Number, Name, IdCard, Phone, Email, Institutions, ProfessionName, Sort,JobMangeId);

        }
        /// <summary>
        /// 岗位报名编号查询
        /// </summary>
        public DataSet Job_SelectByJobId(string proc,  int JobId)
        {
            return human.Job_SelectByJobId(proc,  JobId);

        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        public bool Job_Update(string proc, int JobId,  string Transfer)
        {
            return human.Job_Update(proc, JobId, Transfer);
        }
        public bool Job_Update2(string proc, int JobId, string Transfer,string Contents)
        {
            return human.Job_Update2(proc, JobId, Transfer,Contents);
        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        public bool JobGrade_Update(string proc, int JobId, string Grade)
        {
            return human.JobGrade_Update(proc, JobId, Grade);
        }
        #endregion
    }
}
