using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Data
{
    public class GetData
    {
        DbCon human = new DbCon();

        #region 登录
        ///<summary>
        ///登录验证
        ///</summary>
        ///
        public int Login(string userCardId, string userPwd)
        {

            int num = -1;
            num = human.Login(userCardId, userPwd);
            return num;
        }
        ///<summary>
        ///登录验证
        ///</summary>
        ///
        public int KSLogin(string userCardId, string userPwd)
        {

            int num = -1;
            num = human.KSLogin(userCardId, userPwd);
            return num;
        }
        #endregion
        #region 权限
        /// <summary>
        /// 用户权限查询
        /// </summary>
        public int AuthoritySelect(string proc, string UserCardId, string ModelUrl)
        {
            return human.AuthroitySelect(proc, UserCardId, ModelUrl);

        }

        public int Login(object p, string pwd)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region 用户管理
        /// <summary>
        /// 用户添加
        /// </summary>
        public bool UserInfoInsert(string proc,string UserCardId1, string UserName, string Pwd)
        {
            return human.UserInfoInsert(proc, UserCardId1,UserName, Pwd);

        }
        /// <summary>
        /// 用户修改
        /// </summary>
        public bool UserInfoUpdate(string proc,int UserInfoId, string UserCardId1, string UserName, string Pwd)
        {
            return human.UserInfoUpdate(proc, UserInfoId, UserCardId1, UserName, Pwd);

        }

        /// <summary>
        /// 用户单个查询
        /// </summary>
        public DataSet SelectByUserInfoId(string proc, string UserInfoId)
        {
            return human.SelectByUserInfoId(proc, UserInfoId);
        }
        /// <summary>
        /// 用户删除
        /// </summary>
        public bool UserInfoDelete(string proc, int UserInfoId)
        {
            return human.UserInfoDelete(proc, UserInfoId);
        }
        #endregion
        #region 岗位信息
        /// <summary>
        /// 岗位添加
        /// </summary>
        public bool JobMangeInsert(string proc, string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree, string Gender, string Nation, string Political, string Should,
                                   string Recruitment, string Position, string JobsYears, string SubjectName,
                                   string ApplyCost, string Profession, string Others, string Remarks)
        {
            return human.JobMangeInsert( proc, JobCode, JobName, Enrollment, Age, Education,Culture,  Degree,Gender, Nation,
                                         Political, Should, Recruitment, Position, JobsYears, SubjectName,ApplyCost, 
                                         Profession, Others, Remarks);
        }
        /// <summary>
        /// 岗位修改
        /// </summary>
        public bool JobMangeUpdate(string proc, int JobMangeId,string JobCode, string JobName, string Enrollment, string Age, string Education,
                                   string Culture, string Degree, string Gender, string Nation, string Political, string Should,
                                   string Recruitment, string Position, string JobsYears, string SubjectName,
                                   string ApplyCost, string Profession, string Others, string Remarks)
        {
            return human.JobMangeUpdate(proc, JobMangeId, JobCode, JobName, Enrollment, Age, Education, Culture, Degree, Gender, Nation,
                                         Political, Should, Recruitment, Position, JobsYears, SubjectName, ApplyCost,
                                         Profession, Others, Remarks);
        }
        /// <summary>
        /// 修改考室
        /// </summary>
        public bool JobMangeUpdateTestAdd(string proc, int JobMangeId,string TestAddress)
        {
            return human.JobMangeUpdateTestAdd(proc, JobMangeId, TestAddress);
        }
        /// <summary>
        /// 修改注意事项
        /// </summary>
        public bool JobMangeUpdatezhuyi(string proc, int JobMangeId, string zhuyi)
        {
            return human.JobMangeUpdatezhuyi(proc, JobMangeId,zhuyi);
        }
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_SelectByJobMangeId(string proc, int JobMangeId)
        {
            return human.JobMange_SelectByJobMangeId(proc, JobMangeId);

        }
        /// <summary>
        /// 考试科目添加
        /// </summary>
        public bool ExamInfoInsert(string proc,int JobMangeId,string ExamSubject,string ExamDate,string ExamTime)
        {
            return human.ExamInfoInsert(proc,JobMangeId,ExamSubject,ExamDate,ExamTime);
        }
        /// <summary>
        /// 考试科目修改
        /// </summary>
        public bool ExamInfoUpdate(string proc, int ExamInfoId, string ExamSubject, string ExamDate, string ExamTime)
        {
            return human.ExamInfoUpdate(proc, ExamInfoId, ExamSubject, ExamDate, ExamTime);
        }
        /// <summary>
        /// 考试科目修改
        /// </summary>
        public bool ExamInfoDelete(string proc, int ExamInfoId)
        {
            return human.ExamInfoDelete(proc, ExamInfoId);
        }

        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_Selects(string proc,string JobName,string SubjectName,string Culture,string Political,string Recruitment,string Gender,string Should,string Nation,string Degree,string Position,string Education,string Age,string Profession,string Sort)
        {
            return human.JobMange_Selects(proc, JobName,SubjectName,Culture,Political, Recruitment, Gender,Should,Nation,Degree,Position,Education,Age,Profession,Sort);

        }
       
        #endregion
        #region 考生信息

        /// <summary>
        /// 考生信息修改
        /// </summary>
        public bool CandidatesInfoUpdate(string proc, int CandidatesInfoId, string Number, byte[] Photo, string Email, string Name,
                                         string Gender, string Origin, string Nation, string Birthday, string CardID,
                                         string census, string Political, string Sources, string ContactPhone, string FamilyPhone,
                                         string OtherPhone, string FamilyAddress, string ZipCode, string Culture, string Degree,
                                         string Education, string Institutions, string ProfessionName, string GraduationData,
                                         string JobsData, string Expertise, string Resumes, string FamilyMember, string Performance,
                                         string Remarks)
        {
            return human.CandidatesInfoUpdate(proc, CandidatesInfoId, Number, Photo, Email, Name, Gender, Origin, Nation, Birthday, CardID, census,
                                         Political, Sources, ContactPhone, FamilyPhone, OtherPhone, FamilyAddress, ZipCode,
                                         Culture, Degree, Education, Institutions, ProfessionName, GraduationData, JobsData,
                                         Expertise, Resumes, FamilyMember, Performance, Remarks);
        }
        /// <summary>
        /// 考生信息单个查询
        /// </summary>
        public DataSet SelectByNumber(string proc,  string Number)
        {
            return human.SelectByNumber(proc,Number);
        }

        /// <summary>
        /// 考生信息查询
        /// </summary>
        public DataSet CandidatesInfo_Selects(string proc,string Number,string Name,string IdCard,string Phone,string Email,string Institutions,string ProfessionName,string Sort)
        {
            return human.CandidatesInfo_Selects(proc,Number,Name,IdCard,Phone,Email,Institutions,ProfessionName,Sort);

        }

        #endregion
        /// <summary>
        /// 岗位单个查询
        /// </summary>
        public DataSet JobMange_ksSelects(string proc, string JobName, string SubjectName, string Culture, string Political, string Recruitment, string Gender, string Should, string Nation, string Degree, string Position, string Education, string Age, string Profession, string Sort)
        {
            return human.JobMange_ksSelects(proc, JobName, SubjectName, Culture, Political, Recruitment, Gender, Should, Nation, Degree, Position, Education, Age, Profession, Sort);

        }


        #region 考生登录
        /// <summary>
        /// 考生注册
        /// </summary>
        public int RegisterdeInsert(string proc, string Number,string  Name,string CardId,string Birthday,string Gender,string Email,string ContactPhone,string UserPwd)
        {
            return human.RegisterdeInsert(proc, Number, Name, CardId, Birthday, Gender, Email, ContactPhone, UserPwd);
        }
        #endregion
        #region 考生个人信息添加
        /// <summary>
        /// 考生信息添加
        /// </summary>
        public bool CandidatesInfoInsert(string proc,string Number, string Email, string Name,
                                         string Gender, string Origin, string Nation, string Birthday, string CardID,
                                         string census, string Political, string Sources, string ContactPhone, string FamilyPhone,
                                         string OtherPhone, string FamilyAddress, string ZipCode, string Culture, string Degree,
                                         string Education,string Marriage, string Institutions, string ProfessionName, string GraduationData,
                                         string JobsData, string Expertise, string Resumes, string FamilyMember, string Performance,
                                         string Remarks)
        {
            return human.CandidatesInfoInsert(proc,Number, Email, Name, Gender, Origin, Nation, Birthday, CardID, census,
                                         Political, Sources, ContactPhone, FamilyPhone, OtherPhone, FamilyAddress, ZipCode,
                                         Culture, Degree, Education, Marriage, Institutions, ProfessionName, GraduationData, JobsData,
                                         Expertise, Resumes, FamilyMember, Performance, Remarks);
        }
        #endregion
        #region 考生照片添加
        /// <summary>
        /// 考生照片添加
        /// </summary>
        public bool CandidatesInfoInsertByPhoto(string proc, string Number, byte[] imgbyte)
        {
            return human.CandidatesInfoInsertByPhoto(proc, Number,imgbyte);
        }
        #endregion
        #region 岗位信息申请
        #endregion
        /// <summary>
        /// 用户密码修改
        /// </summary>
        public bool UserInfoPwdUpdate(string proc,string Number, string Pwd,string Pwd2)
        {
            return human.UserInfoPwdUpdate(proc, Number, Pwd,Pwd2);

        }
        /// <summary>
        /// 用户密码修改
        /// </summary>
        public bool UserInfoUpdatePwd(string proc, string Number, string Pwd, string Pwd2)
        {
            return human.UserInfoUpdatePwd(proc, Number, Pwd, Pwd2);

        }
        /// <summary>
        /// 执行查询的存储过程
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public DataSet Select(string proc)
        {
            return human.select(proc);

        }
    }
}
