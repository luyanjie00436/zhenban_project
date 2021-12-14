using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace HumanManage_Data
{
   
   public class GetData
    {
        DbCon human = new DbCon();
        #region 基础信息
        #region 用户
        ///<summary>
        ///登录验证
        ///</summary>
        ///
        public int Login(string userCardId, string userPwd,Page p)
        {
            string message;
            int num = -1;
                num = human.Login(userCardId, userPwd);
               
                return num;
           

        }
        /// <summary>
        /// 用户信息单个查询
        /// </summary>
        /// <param name="userCardId"></param>
        /// <returns></returns>
        public DataSet userInfoS(string userCardId)
        {
            return human.UserInfoS(userCardId);

        }
        #endregion
        #region  用户管理
        /// <summary>
        /// 用户添加
        /// </summary>
        public bool Abc_UserInsert(string proc, string UserName, string UserPwd)
        {
            return human.Abc_UserInsert(proc, UserName, UserPwd);

        }
        /// <summary>
        /// 用户修改
        /// </summary>
        public bool Abc_UserUpdate(string proc, int Id,string UserName, string UserPwd)
        {
            return human.Abc_UserUpdate(proc,Id, UserName, UserPwd);

        }
        /// <summary>
        /// 用户信息单个查询
        /// </summary>
        public DataSet Abc_UserById(string proc, int Id)
        {
            return human.Abc_UserById(proc, Id);

        }
        /// <summary>
        /// 用户信息删除
        /// </summary>
        public bool A_UserDelete(string proc, int Id)
        {
            return human.A_UserDelete(proc, Id);

        }
        #endregion
        #region
        public DataSet UserViewSelects(string proc, string Selects, string Wheres)
        {
            return human.UserViewSelects(proc, Selects, Wheres);
        }
        #endregion
        #region 个人基础信息
        public DataSet UseOfficeViewSelects(string proc, string UserCardId)
        {
            return human.UseOfficeViewSelects(proc, UserCardId);
        }
     
        #endregion
        #region 职称
        /// <summary>
        /// 职称信息单个查询
        /// </summary>
        public DataSet SelectByJobId(string proc,int JobId)
        {
            return human.SelectByJobId(proc,JobId);

        }
        /// <summary>
        /// 职称职务数量查询
        /// </summary>
        public int JobSum(string proc, int JobId)
        {
            return human.JobSum(proc, JobId);

        }
        /// <summary>
        /// 职称信息添加
        /// </summary>
        public bool JobInsert(string proc,string JobName)
        {
            return human.JobInsert(proc,JobName);

        }
        /// <summary>
        /// 职称信息修改
        /// </summary>
        public bool JobUpdate(string proc,int JobId, string JobName)
        {
            return human.JobUpdate(proc,JobId, JobName);

        }
        /// <summary>
        /// 职称信息删除
        /// </summary>
        public bool JobDelete(string proc, int JobId)
        {
            return human.JobDelete(proc, JobId);

        }
        /// <summary>
        /// 职级信息添加
        /// </summary>
        public bool PostInsert(string proc, string PostName,string PlanPeople)
        {
            return human.PostInsert(proc, PostName, PlanPeople);

        }
        /// <summary>
        /// 职级信息单个查询
        /// </summary>
        public DataSet SelectByPostId(string proc, int PostId)
        {
            return human.SelectByPostId(proc, PostId);

        }
        /// <summary>
        /// 职级信息修改
        /// </summary>
        public bool PostUpdate(string proc, int PostId, string PostName, string PlanPeople )
        {
            return human.PostUpdate(proc, PostId, PostName,PlanPeople);

        }
        /// <summary>
        /// 职级职务数量查询
        /// </summary>
        public int PostSum(string proc, int PostId)
        {
            return human.PostSum(proc, PostId);

        }
        /// <summary>
        /// 职级信息删除
        /// </summary>
        public bool PostDelete(string proc, int PostId)
        {
            return human.PostDelete(proc, PostId);

        }
        #endregion
        #region 职务
        /// <summary>
        /// 职务信息添加
        /// </summary>
        public bool RoleInsert(string proc, string RoleName)
        {
            return human.RoleInsert(proc, RoleName);

        }
        /// <summary>
        /// 职务信息单个查询
        /// </summary>
        public DataSet SelectByRoleId(string proc, int RoleId)
        {
            return human.SelectByRoleId(proc, RoleId);

        }
        /// <summary>
        /// 职务信息修改
        /// </summary>
        public bool RoleUpdate(string proc, int RoleId, string RoleName)
        {
            return human.RoleUpdate(proc, RoleId, RoleName);

        }
        /// <summary>
        /// 职务数量查询
        /// </summary>
        public int RoleSum(string proc, int RoleId)
        {
            return human.RoleSum(proc, RoleId);

        }
        /// <summary>
        /// 职务信息删除
        /// </summary>
        public bool RoleDelete(string proc, int RoleId)
        {
            return human.RoleDelete(proc, RoleId);

        }
#endregion
        #region 部门
        /// <summary>
        /// 行政隶属信息添加
        /// </summary>
        public bool DepartmentInsert(string proc, string DepartmentName,string PreparedNumber, string PreparedPost, string PreparedProfession, string PreparedWorkers)
        {
            return human.DepartmentInsert(proc, DepartmentName, PreparedNumber, PreparedPost, PreparedProfession, PreparedWorkers);

        }
        /// <summary>
        /// 行政隶属信息单个查询
        /// </summary>
        public DataSet SelectByDepartmentId(string proc, int DepartmentId)
        {
            return human.SelectByDepartmentId(proc, DepartmentId);

        }
        /// <summary>
        /// 行政隶属信息修改
        /// </summary>
        public bool DepartmentUpdate(string proc, int DepartmentId, string DepartmentName,string PreparedNumber,string PreparedPost,string PreparedProfession,string PreparedWorkers)
        {
            return human.DepartmentUpdate(proc, DepartmentId, DepartmentName,PreparedNumber, PreparedPost, PreparedProfession, PreparedWorkers);

        }
        /// <summary>
        /// 行政隶属职务数量查询
        /// </summary>
        public int DepartmentSum(string proc, int DepartmentId)
        {
            return human.DepartmentSum(proc, DepartmentId);

        }
        /// <summary>
        /// 行政隶属信息删除
        /// </summary>
        public bool DepartmentDelete(string proc, int DepartmentId)
        {
            return human.DepartmentDelete(proc, DepartmentId);

        }
        /// <summary>
        /// 按行政隶属查询行政隶属变动信息
        /// </summary>
        public DataSet SelectDepartmentChange(string proc, int DepartmentId)
        {
            return human.SelectDepartmentChange(proc, DepartmentId);

        }
        #endregion
        #region 学位
        /// <summary>
        /// 学位信息添加
        /// </summary>
        public bool DegreeInsert(string proc, string DegreeName)
        {
            return human.DegreeInsert(proc, DegreeName);

        }
        /// <summary>
        /// 学位信息单个查询
        /// </summary>
        public DataSet SelectByDegreeId(string proc, int DegreeId)
        {
            return human.SelectByDegreeId(proc, DegreeId);

        }
        /// <summary>
        /// 学位信息修改
        /// </summary>
        public bool DegreeUpdate(string proc, int DegreeId, string DegreeName)
        {
            return human.DegreeUpdate(proc, DegreeId, DegreeName);

        }
        /// <summary>
        /// 学位职务数量查询
        /// </summary>
        public int DegreeSum(string proc, int DegreeId)
        {
            return human.DegreeSum(proc, DegreeId);

        }
        /// <summary>
        /// 学位信息删除
        /// </summary>
        public bool DegreeDelete(string proc, int DegreeId)
        {
            return human.DegreeDelete(proc, DegreeId);

        }

        #endregion
        #region 角色
        /// <summary>
        /// 角色信息添加
        /// </summary>
        public bool RankInsert(string proc, string RankName, string UserCardId, string RBL1)
        {
            return human.RankInsert(proc, RankName, UserCardId, RBL1);

        }
        /// <summary>
        /// 角色信息单个查询
        /// </summary>
        public DataSet SelectByRankId(string proc, int RankId)
        {
            return human.SelectByRankId(proc, RankId);

        }
        /// <summary>
        /// 角色信息修改
        /// </summary>
        public bool RankUpdate(string proc, int RankId, string RankName, string UserCardId, string RBL1)
        {
            return human.RankUpdate(proc, RankId, RankName, UserCardId, RBL1);

        }
        /// <summary>
        /// 角色职务数量查询
        /// </summary>
        public int RankSum(string proc, int RankId)
        {
            return human.RankSum(proc, RankId);

        }
        /// <summary>
        /// 角色信息删除
        /// </summary>
        public bool RankDelete(string proc, int RankId)
        {
            return human.RankDelete(proc, RankId);

        }
        /// <summary>
        /// 用户角色添加
        /// </summary>
        public bool UserRankInsert(string proc,string UserCardId, int RankId)
        {
            return human.UserRankInsert(proc,UserCardId, RankId);

        }
        /// <summary>
        /// 用户角色添加
        /// </summary>
        public bool UserEnableUpdate(string proc, string UserCardId, string UserEnable, string UserLock)
        {
            return human.UserEnableUpdate(proc, UserCardId, UserEnable, UserLock);

        }

        #endregion
        #region 学历
        /// <summary>
        /// 学历信息添加
        /// </summary>
        public bool EducationInsert(string proc, string EducationName)
        {
            return human.EducationInsert(proc, EducationName);

        }
     
        /// <summary>
        /// 学历信息单个查询
        /// </summary>
        public DataSet SelectByEducationId(string proc, int EducationId)
        {
            return human.SelectByEducationId(proc, EducationId);

        }
        /// <summary>
        /// 学历信息修改
        /// </summary>
        public bool EducationUpdate(string proc, int EducationId, string EducationName)
        {
            return human.EducationUpdate(proc, EducationId, EducationName);

        }
        /// <summary>
        /// 学历职务数量查询
        /// </summary>
        public int EducationSum(string proc, int EducationId)
        {
            return human.EducationSum(proc, EducationId);

        }
        /// <summary>
        /// 学历信息删除
        /// </summary>
        public bool EducationDelete(string proc, int EducationId)
        {
            return human.EducationDelete(proc, EducationId);

        }
        #endregion
        #region 状态
        /// <summary>
        /// 在职信息添加
        /// </summary>
        public bool StatusInsert(string proc, string StatusName)
        {
            return human.StatusInsert(proc, StatusName);

        }
        /// <summary>
        /// 在职信息单个查询
        /// </summary>
        public DataSet SelectByStatusId(string proc, int StatusId)
        {
            return human.SelectByStatusId(proc, StatusId);

        }
        /// <summary>
        /// 在职信息修改
        /// </summary>
        public bool StatusUpdate(string proc, int StatusId, string StatusName)
        {
            return human.StatusUpdate(proc, StatusId, StatusName);

        }
        /// <summary>
        /// 在职职务数量查询
        /// </summary>
        public int StatusSum(string proc, int StatusId)
        {
            return human.StatusSum(proc, StatusId);

        }
        /// <summary>
        /// 在职信息删除
        /// </summary>
        public bool StatusDelete(string proc, int StatusId)
        {
            return human.StatusDelete(proc, StatusId);

        }
        #endregion
        #region 民族
        /// <summary>
        /// 民族信息添加
        /// </summary>
        public bool NationInsert(string proc, string NationName)
        {
            return human.NationInsert(proc, NationName);

        }
        /// <summary>
        /// 民族信息单个查询
        /// </summary>
        public DataSet SelectByNationId(string proc, int NationId)
        {
            return human.SelectByNationId(proc, NationId);

        }
        /// <summary>
        /// 民族信息修改
        /// </summary>
        public bool NationUpdate(string proc, int NationId, string NationName)
        {
            return human.NationUpdate(proc, NationId, NationName);

        }
        /// <summary>
        /// 民族职务数量查询
        /// </summary>
        public int NationSum(string proc, int NationId)
        {
            return human.NationSum(proc, NationId);

        }
        /// <summary>
        /// 民族信息删除
        /// </summary>
        public bool NationDelete(string proc, int NationId)
        {
            return human.NationDelete(proc, NationId);

        }
        #endregion
        #region 政治面貌
        /// <summary>
        /// 政治面貌信息添加
        /// </summary>
        public bool PoliticalInsert(string proc, string PoliticalName)
        {
            return human.PoliticalInsert(proc, PoliticalName);

        }
        /// <summary>
        /// 政治面貌信息单个查询
        /// </summary>
        public DataSet SelectByPoliticalId(string proc, int PoliticalId)
        {
            return human.SelectByPoliticalId(proc, PoliticalId);

        }
        /// <summary>
        /// 政治面貌信息修改
        /// </summary>
        public bool PoliticalUpdate(string proc, int PoliticalId, string PoliticalName)
        {
            return human.PoliticalUpdate(proc, PoliticalId, PoliticalName);

        }
        /// <summary>
        /// 政治面貌职务数量查询
        /// </summary>
        public int PoliticalSum(string proc, int PoliticalId)
        {
            return human.PoliticalSum(proc, PoliticalId);

        }
        /// <summary>
        /// 政治面貌信息删除
        /// </summary>
        public bool PoliticalDelete(string proc, int PoliticalId)
        {
            return human.PoliticalDelete(proc, PoliticalId);

        }
        #endregion
        #region 用户信息
        /// <summary>
        /// 用户信息添加
        /// </summary>
        public bool UserInfoInsert(string proc, string UserCardId, string UserPwd, string UserName, string UserSource)
        {
            return human.UserInfoInsert(proc, UserCardId, UserPwd, UserName, UserSource);
        }

        /// <summary>
        /// 用户信息修改
        /// </summary>
        public bool UserInfoUpdate(string proc, string UserCardId, string UserName, string UserGender,string IdCardNo,
            string NationName, string PoliticalName, string PartyDate, string TakeWorkDate, string EntryDate, string Origin, string Address,
            string StatusName, string GL_Management, string GL_CadreLevelName, string GL_RoleName, string GL_DepartmentName, string GL_StartDate,
            string GL_ManagerLevelName, string ZY_SkillTitle, string ZY_JobSeries, string ZY_TitleLevelName, string ZY_SpecialSkills, string ZY_DepartmentName,
            string ZY_StartDate, string JS_TeachersSeries, string JS_TeacherCategory, string JS_CertificateDate, string JS_MajorLeading, string JS_BoneTeacher,
            string JS_DoubleTeacher, string GQ_WorkersPeople, string GQ_PostName, string GQ_Appointment, string GQ_StartDate, string GQ_DepartmentName, string DYXL_Name,
            string DYXL_Date, string DYXL_School, string DYXL_Profession, string ZGXL_Name, string ZGXL_Date, string ZGXL_School, string ZGXL_Profession,
            string DYXW_Name, string DYXW_Date, string DYXW_School, string DYXW_Profession, string ZGXW_Name, string ZGXW_Date,
            string ZGXW_School, string ZGXW_Profession)
        {
            return human.UserInfoUpdate(proc, UserCardId, UserName, UserGender, IdCardNo, NationName, PoliticalName, PartyDate, 
                TakeWorkDate, EntryDate, Origin, Address, StatusName, GL_Management, GL_CadreLevelName, GL_RoleName, GL_DepartmentName,
                GL_StartDate, GL_ManagerLevelName, ZY_SkillTitle, ZY_JobSeries, ZY_TitleLevelName, ZY_SpecialSkills, ZY_DepartmentName,
                ZY_StartDate, JS_TeachersSeries, JS_TeacherCategory, JS_CertificateDate, JS_MajorLeading, JS_BoneTeacher, JS_DoubleTeacher,
                GQ_WorkersPeople, GQ_PostName, GQ_Appointment, GQ_StartDate, GQ_DepartmentName, DYXL_Name, DYXL_Date, DYXL_School,
                DYXL_Profession, ZGXL_Name, ZGXL_Date, ZGXL_School, ZGXL_Profession, DYXW_Name, DYXW_Date, DYXW_School, DYXW_Profession,
                ZGXW_Name, ZGXW_Date, ZGXW_School, ZGXW_Profession);

        }


        /// <summary>
        /// 用户学历信息修改
        /// </summary>
        public bool UserEducationSave(string proc, string UserCardId, int FirstEducationId, string FirstDate, string FirstSchool, string FirstProfession, int HighestEducationId, string HighestDate, string HighestSchool, string HighestProfession)
        {
            return human.UserEducationSave(proc, UserCardId, FirstEducationId, FirstDate, FirstSchool, FirstProfession, HighestEducationId, HighestDate, HighestSchool, HighestProfession);

        }


        /// <summary>
        /// 用户学位信息修改
        /// </summary>
        public bool UserDegreeSave(string proc, string UserCardId, int FirstDegreeId, string FirstDate, string FirstSchool, string FirstProfession, int HighestDegreeId, string HighestDate, string HighestSchool, string HighestProfession)
        {
            return human.UserDegreeSave(proc, UserCardId, FirstDegreeId, FirstDate, FirstSchool, FirstProfession, HighestDegreeId, HighestDate, HighestSchool, HighestProfession);

        }

       /// <summary>
       /// 用户信息查询
       /// </summary>
        public DataSet UserInfoSelect(string proc, string UserName, string StatusId, string StartYear,string EndYear,string Gender,string PoliticalId)
        {
            return human.UserInfoSelect(proc, UserName,StatusId,StartYear,EndYear,Gender,PoliticalId);

        }
        /// <summary>
        /// 个人密码修改
        /// </summary>
        public bool UserPwdUpdate(string proc, string UserCardId, string OldPwd,string NewPwd)
        {
            return human.UserPwdUpdate(proc, UserCardId,OldPwd,NewPwd);

        }
        /// <summary>
        /// 用户密码修改
        /// </summary>
        public bool UserInfoPwdUpdate(string proc, string UserCardId, string UserIdCard, string NewPwd)
        {
            return human.UserInfoPwdUpdate(proc, UserCardId, UserIdCard, NewPwd);

        }
        #endregion
        #region 证书信息
        /// <summary>
        /// 证书添加
        /// </summary>
        public bool UserEducationInsertByPhotodyxl(string proc, string UserCardId, byte[] imgbyte)
        {
            return human.UserEducationInsertByPhotodyxl(proc, UserCardId, imgbyte);
        }
        #endregion
        #region 职称聘任
        /// <summary>
        /// 职称聘任添加
        /// </summary>
        public bool UseOfficeInsert(string proc, string UserCardId,string AppointmentDate,string  Profession,int ProfessionQualificationId,string Remarks, byte[] CertificatePhoto)
        {
            return human.UseOfficeInsert(proc, UserCardId, AppointmentDate, Profession, ProfessionQualificationId, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 职称聘任单个查询
        /// </summary>
        public DataSet SelectByUseOfficeId(string proc, int UseOfficeId)
        {
            return human.SelectByUseOfficeId(proc, UseOfficeId);

        }
     
        /// <summary>
        /// 职称聘任查询
        /// </summary>
        public DataSet UseOfficeViewSelectsTexe(string proc, string Text)
        {
            return human.UseOfficeViewSelectsTexe(proc, Text);

        }
      
        /// <summary>
        /// 职称聘任管理员修改
        /// </summary>
        public bool UseOfficeUpdate(string proc, int UseOfficeId, string AppointmentDate, string Profession, int ProfessionQualificationId, string Remarks, byte[] CertificatePhoto)
        {
            return human.UseOfficeUpdate(proc, UseOfficeId,  AppointmentDate, Profession, ProfessionQualificationId, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 职称聘任信息修改
        /// </summary>
        public bool UseOfficeStatusUpdate(string proc, int UseOfficeId, string UserCardId, string AppointmentDate, string Profession, int ProfessionQualificationId, string Remarks, string TransferStatus)
        {
            return human.UseOfficeStatusUpdate(proc, UseOfficeId, UserCardId, AppointmentDate, Profession, ProfessionQualificationId, Remarks, TransferStatus);

        }
        /// <summary>
        /// 职称聘任删除
        /// </summary>
        public bool UseOfficeDelete(string proc, int UseOfficeId)
        {
            return human.UseOfficeDelete(proc, UseOfficeId);

        }
        /// <summary>
        /// 职称聘任审批添加
        /// </summary>
        public bool UseOfficeExamineInsert(string proc, string UserCardId, int UseOfficeId, string TransferStatus)
        {
            return human.UseOfficeExamineInsert(proc, UserCardId, UseOfficeId, TransferStatus);

        }
        #endregion
        #region   职业资格证书
        /// <summary>
        /// 职业资格添加
        /// </summary>
        public bool JobCertificateInsert(string proc, string UserCardId,string JobQualificationName,string IsssueUnit,string JobDate, string Remarks, byte[] CertificatePhoto)
        {
            return human.JobCertificateInsert(proc, UserCardId, JobQualificationName, IsssueUnit, JobDate, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 职业资格修改
        /// </summary>
        public bool JobCertificateUpdate(string proc, int JobCertificateId, string JobQualificationName, string IsssueUnit, string JobDate, string Remarks, byte[] CertificatePhoto)
        {
            return human.JobCertificateUpdate(proc, JobCertificateId,  JobQualificationName, IsssueUnit, JobDate, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 职业资格信息修改
        /// </summary>
        public bool JobCertificateStayusUpdate(string proc, int JobCertificateId, string UserCardId, string JobQualificationName, string IsssueUnit, string JobDate, string Remarks, string TransferStatus)
        {
            return human.JobCertificateStayusUpdate(proc, JobCertificateId, UserCardId, JobQualificationName, IsssueUnit, JobDate, Remarks, TransferStatus);

        }
        /// <summary>
        /// 职业资格单个查询
        /// </summary>
        public DataSet SelectByJobCertificateId(string proc, int JobCertificateId)
        {
            return human.SelectByJobCertificateId(proc, JobCertificateId);

        }
        /// <summary>
        /// 职业资格删除
        /// </summary>
        public bool JobCertificateDelete(string proc, int JobCertificateId)
        {
            return human.JobCertificateDelete(proc, JobCertificateId);

        }
        /// <summary>
        /// 职业资格审批添加
        /// </summary>
        public bool JobCertificateExamineInsert(string proc, string UserCardId, int JobCertificateId, string TransferStatus)
        {
            return human.JobCertificateExamineInsert(proc, UserCardId, JobCertificateId, TransferStatus);

        }
        #endregion
        #region 工作经历

        /// <summary>
        /// 工作经历添加
        /// </summary>
        /// 
        public bool WorkExperienceInsert(string proc, string UserCardId, string StartDate, string EndDate, int DepartmentId, int RoleId, string Remarks, string IsNow)
        {
            return human.WorkExperienceInsert(proc, UserCardId, StartDate, EndDate, DepartmentId, RoleId, Remarks, IsNow);

        }

        /// <summary>
        /// 工作经历单个查询
        /// </summary>
        public DataSet SelectByWorkExperienceId(string proc, int WorkExperienceId)
        {
            return human.SelectByWorkExperienceId(proc, WorkExperienceId);

        }
        /// <summary>
        /// 工作经历修改
        /// </summary>
        public bool WorkExperienceUpdateNoTransferStatus(string proc, int WorkExperienceId, string StartDate, string EndDate, int DepartmentId, int RoleId, string Remarks, string IsNow)
        {
            return human.WorkExperienceUpdateNoTransferStatus(proc, WorkExperienceId, StartDate, EndDate, DepartmentId, RoleId, Remarks, IsNow);

        }
      

        /// <summary>
        /// 工作经历管理员修改
        /// </summary>
        public bool WorkExperienceStatusUpdate(string proc,int WorkExperienceId,string UserCardId,string StartDate,string EndDate,int DepartmentId,int RoleId,string Remarks,string IsNow,string TransferStatus)
        {
            return human.WorkExperienceStatusUpdate(proc, WorkExperienceId, UserCardId, StartDate, EndDate, DepartmentId, RoleId, Remarks, IsNow, TransferStatus);

        }
        /// <summary>
        /// 工作经历删除
        /// </summary>
        public bool WorkExperienceDelete(string proc, int WorkExperienceId)
        {
            return human.WorkExperienceDelete(proc, WorkExperienceId);

        }
        /// <summary>
        /// 工作经历审批添加
        /// </summary>
        public bool WorkExperienceUpdateTransferStatus(string proc, string UserCardId, int WorkExperienceId, string TransferStatus)
        {
            return human.WorkExperienceUpdateTransferStatus(proc, UserCardId, WorkExperienceId, TransferStatus);

        }
        #endregion
        #region 社会兼职情况
        /// <summary>
        /// 社会兼职单个查询
        /// </summary>
        public DataSet SelectByParttimejobId(string proc, int ParttimejobId)
        {
            return human.SelectByParttimejobId(proc, ParttimejobId);
        }
        /// <summary>
        /// 社会兼职情况查询
        /// </summary>
        public DataSet ParttimejobViewSelectsTexe(string proc, string Text)
        {
            return human.ParttimejobViewSelectsTexe(proc, Text);
        }
        /// <summary>
        /// 社会兼职情况添加
        /// </summary>
        public bool ParttimejobInsert(string proc, string UserCardId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName)
        {
            return human.ParttimejobInsert(proc, UserCardId, StartDate, EndDate, DepartmentName, RoleName, Remarks, UnitName);
        }
        /// <summary>
        /// 社会兼职情况管理员修改
        /// </summary>
        public bool ParttimejobUpdate(string proc, int ParttimejobId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName)
        {
            return human.ParttimejobUpdate(proc, ParttimejobId, StartDate, EndDate, DepartmentName, RoleName, Remarks, UnitName);

        }
        /// <summary>
        /// 社会兼职情况信息修改
        /// </summary>
        public bool ParttimejobStayusUpdate(string proc, int ParttimejobId, string UserCardId, string StartDate, string EndDate, string DepartmentName, string RoleName, string Remarks, string UnitName, string TransferStatus)
        {
            return human.ParttimejobStayusUpdate(proc, ParttimejobId, UserCardId, StartDate, EndDate, DepartmentName, RoleName, Remarks, UnitName, TransferStatus);
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        public bool ParttimejobDelete(string proc, int ParttimejobId)
        {
            return human.ParttimejobDelete(proc, ParttimejobId);
        }
        /// <summary>
        /// 社会兼职审批添加
        /// </summary>
        /// <returns></returns>
        public bool ParttimejobExamineInsert(string proc, string UserCardId, int ParttimejobId, string TransferStatus)
        {
            return human.ParttimejobExamineInsert(proc, UserCardId, ParttimejobId, TransferStatus);

        }
        /// <summary>
        /// 信息
        /// </summary>
        public DataSet ParttimejobViewSelects(string proc, string UserCardId)
        {
            return human.ParttimejobViewSelects(proc, UserCardId);

        }
        #endregion
        #region 培训进修情况
        /// <summary>
        /// 培训进修情况添加
        /// </summary>
        public bool StudyTrainInsert(string proc, string UserCardId, string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks, byte[] CertificatePhoto)
        {
            return human.StudyTrainInsert(proc, UserCardId, TrainProjectName, TrainStartDate, TrainEndDate, TrainUnit, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 培训进修修改
        /// </summary>
        public bool StudyTrainUpdateNoTransferStatus(string proc, int StudyTrainId, string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks, byte[] CertificatePhoto)
        {
            return human.StudyTrainUpdateNoTransferStatus(proc, StudyTrainId, TrainProjectName, TrainStartDate, TrainEndDate, TrainUnit, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 培训进修管理员修改
        /// </summary>
        public bool StudyTrainUpdate(string proc, int StudyTrainId, string UserCardId , string TrainProjectName, string TrainStartDate,string TrainEndDate, string TrainUnit, string Remarks, string TransferStatus)
        {
            return human.StudyTrainUpdate(proc, StudyTrainId, UserCardId, TrainProjectName, TrainStartDate, TrainEndDate, TrainUnit, Remarks, TransferStatus);

        }
        /// <summary>
        ///培训进修审批添加
        /// </summary>
        public bool StudyTrainUpdateTransferStatus(string proc, string UserCardId, int StudyTrainId, string TransferStatus)
        {
            return human.StudyTrainUpdateTransferStatus(proc, UserCardId, StudyTrainId, TransferStatus);

        }

        /// <summary>
        /// 培训进修删除
        /// </summary>
        public bool StudyTrainDelete(string proc, int StudyTrainId)
        {
            return human.StudyTrainDelete(proc, StudyTrainId);

        }
        /// <summary>
        /// 培训进修单个查询
        /// </summary>
        public DataSet SelectByStudyTrainId(string proc, int StudyTrainId)
        {
            return human.SelectByStudyTrainId(proc, StudyTrainId);

        }

        #endregion
        #region 历年获奖
        /// <summary>
        /// 历年获奖情况添加
        /// </summary>
        public bool PastAwardsInsert(string proc, string UserCardId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, byte[] CertificatePhoto)
        {
            return human.PastAwardsInsert(proc, UserCardId, AwardProjectName, AwardDate, GrantUnit, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 历年获奖修改
        /// </summary>
        public bool PastAwardsUpdateNoTransferStatus(string proc, int PastAwardsId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, byte[] CertificatePhoto)
        {
            return human.PastAwardsUpdateNoTransferStatus(proc, PastAwardsId, AwardProjectName, AwardDate, GrantUnit, Remarks, CertificatePhoto);

        }
        /// <summary>
        /// 历年获奖管理员修改
        /// </summary>
        public bool PastAwardsUpdate(string proc, int PastAwardsId, string UserCardId, string AwardProjectName, string AwardDate, string GrantUnit, string Remarks, string TransferStatus)
        {
            return human.PastAwardsUpdate(proc, PastAwardsId, UserCardId, AwardProjectName, AwardDate, GrantUnit, Remarks, TransferStatus);

        }
        /// <summary>
        /// 历年获奖单个查询
        /// </summary>
        public DataSet SelectByPastAwardsId(string proc, int PastAwardsId)
        {
            return human.SelectByPastAwardsId(proc, PastAwardsId);

        }
        /// <summary>
        ///历年获奖审批添加
        /// </summary>
        public bool PastAwardsUpdateTransferStatus(string proc, string UserCardId, int PastAwardsId, string TransferStatus)
        {
            return human.PastAwardsUpdateTransferStatus(proc, UserCardId, PastAwardsId, TransferStatus);

        }
        /// <summary>
        /// 历年获奖删除
        /// </summary>
        public bool PastAwardsDelete(string proc, int PastAwardsId)
        {
            return human.PastAwardsDelete(proc, PastAwardsId);

        }
        #endregion
        #region 年度考核

        /// <summary>
        /// 年度考核添加
        /// </summary>
        /// 
        public bool YearAssessmentInsert(string proc, string UserCardId, string Year,string WorkCompletion, string AssessmentGrade, string Remarks)
        {
            return human.YearAssessmentInsert(proc, UserCardId, Year, WorkCompletion, AssessmentGrade, Remarks );

        }

        /// <summary>
        /// 年度考核单个查询
        /// </summary>
        public DataSet SelectByYearAssessmentId(string proc, int YearAssessmentId)
        {
            return human.SelectByYearAssessmentId(proc, YearAssessmentId);

        }
        /// <summary>
        /// 年度考核修改
        /// </summary>
        public bool YearAssessmentUpdateNoTransferStatus(string proc, int YearAssessmentId, string Year, string WorkCompletion, string AssessmentGrade, string Remarks)
        {
            return human.YearAssessmentUpdateNoTransferStatus(proc, YearAssessmentId, Year, WorkCompletion, AssessmentGrade, Remarks);

        }
       
        /// <summary>
        /// 年度考核管理员修改
        /// </summary>
        public bool YearAssessmentUpdate(string proc,int YearAssessmentId,string UserCardId,string Year,string WorkCompletion,string AssessmentGrade,string Remarks,string TransferStatus)
        {
            return human.YearAssessmentUpdate(proc, YearAssessmentId, UserCardId, Year, WorkCompletion, AssessmentGrade, Remarks, TransferStatus);

        }
        /// <summary>
        /// 年度考核删除
        /// </summary>
        public bool YearAssessmentDelete(string proc, int YearAssessmentId)
        {
            return human.YearAssessmentDelete(proc, YearAssessmentId);

        }
        /// <summary>
        /// 年度考核审批添加
        /// </summary>
        public bool YearAssessmentUpdateTransferStatus(string proc, string UserCardId, int YearAssessmentId, string TransferStatus)
        {
            return human.YearAssessmentUpdateTransferStatus(proc, UserCardId, YearAssessmentId, TransferStatus);

        }
        #endregion
        #region 其他信息
        /// <summary>
        /// 其他信息修改
        /// </summary>
        public bool OtherUpdate(string proc, string UserCardId, string UserSource, string SchoolDate, string WorkLeave,string Prepared,string ForeignStaff)
        {
            return human.OtherUpdate(proc, UserCardId, UserSource,SchoolDate,WorkLeave, Prepared, ForeignStaff);

        }
        #endregion
        #region 职称职级历程
        /// <summary>
        /// 职称职级历程信息添加
        /// </summary>
        public bool UseJobPostInsert(string proc, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate,string EndDate, string JobSeries, string WorkLevel, string IsCurrent,string UserProfessional)
        {
            return human.UseJobPostInsert(proc, UserCardId, DepartmentId, JobId, PostId, JobDate,EndDate, JobSeries, WorkLevel, IsCurrent, UserProfessional);

        }
        /// <summary>
        /// 职称职级历程信息单个查询
        /// </summary>
        public DataSet UseJobPostSelectByUseJobPostId(string proc, int UseJobPostId)
        {
            return human.UseJobPostSelectByUseJobPostId(proc, UseJobPostId);

        }
        /// <summary>
        /// 职称职级历程信息修改
        /// </summary>
        public bool UseJobPostUpdate(string proc, int UseJobPostId, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate,string EndDate, string JobSeries, string WorkLevel, string IsCurrent,string UserProfessional)
        {
            return human.UseJobPostUpdate(proc, UseJobPostId, UserCardId, DepartmentId, JobId, PostId, JobDate,EndDate, JobSeries, WorkLevel, IsCurrent, UserProfessional);

        }
        /// <summary>
        /// 职称职级历程信息删除
        /// </summary>
        public bool UseJobPostDelete(string proc, int UseJobPostId)
        {
            return human.UseJobPostDelete(proc, UseJobPostId);

        }
        #endregion
        #region 行政职级历程
        /// <summary>
        /// 行政职级历程信息添加
        /// </summary>
        public bool UseRemunerationInsert(string proc, string UserCardId, string RoleName, string Remuneration, string StartDate, string EndDate)
        {
            return human.UseRemunerationInsert(proc, UserCardId, RoleName, Remuneration, StartDate, EndDate);

        }
        /// <summary>
        /// 行政职级历程信息单个查询
        /// </summary>
        public DataSet UseRemunerationSelectByUseRemunerationId(string proc, int UseRemunerationId)
        {
            return human.UseRemunerationSelectByUseRemunerationId(proc, UseRemunerationId);

        }
        /// <summary>
        /// 行政职级历程信息修改
        /// </summary>
        public bool UseRemunerationUpdate(string proc, int UseRemunerationId, string UserCardId, string RoleName, string Remuneration, string StartDate, string EndDate)
        {
            return human.UseRemunerationUpdate(proc, UseRemunerationId, UserCardId, RoleName, Remuneration, StartDate, EndDate);

        }
        /// <summary>
        /// 行政职级历程信息删除
        /// </summary>
        public bool UseRemunerationDelete(string proc, int UseRemunerationId)
        {
            return human.UseRemunerationDelete(proc, UseRemunerationId);

        }
        #endregion 
        #region 目录
        /// <summary>
       /// 按父目录查询
       /// </summary>
       /// <returns></returns>
        public DataSet ModelSelect(string proc, int ModelId)
        {
            return human.ModelSelect(proc, ModelId);

        }
        /// <summary>
        /// 子目录数量查询
        /// </summary>
        public int ModelSum(string proc, int ModelId)
        {
            return human.ModelSum(proc, ModelId);

        }
        /// <summary>
        /// 用户目录信息删除
        /// </summary>
        public bool ModelDelete(string proc, int ModelId)
        {
            return human.ModelDelete(proc, ModelId);

        }
        /// <summary>
        /// 目录信息添加
        /// </summary>
        public bool ModelInsert(string proc, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName,  int ModelNum)
        {
            return human.ModelInsert(proc, ModelName, ModelUrl, FatherModelId, FatherModelName,  ModelNum);

        }
        /// <summary>
        /// 目录信息修改
        /// </summary>
        public bool ModelUpdate(string proc, int ModelId, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName,  int ModelNum)
        {
            return human.ModelUpdate(proc, ModelId, ModelName, ModelUrl, FatherModelId, FatherModelName,  ModelNum);

        }
        /// <summary>
        /// 目录信息单个查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByModelId(string proc, int ModelId)
        {
            return human.SelectByModelId(proc, ModelId);

        }
        #endregion
        #region 其他
        /// <summary>
        /// 职务权限添加
        /// </summary>
        public bool AuthorityInsert(string proc, int RoleId,int ModelId)
        {
            return human.AuthroityInsert(proc, RoleId,ModelId);

        }
        /// <summary>
        /// 职务权限查询
        /// </summary>
        public int AuthoritySelect(string proc, string UserCardId, string ModelUrl)
        {
            return human.AuthroitySelect(proc, UserCardId, ModelUrl);

        }
        /// <summary>
        /// 按用户工号查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByUserCardId(string proc, string UserCardId)
        {
            return human.SelectByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 邮箱信息修改
        /// </summary>
        public bool EmailUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3)
        {
            return human.EmailUpdate(proc, UserCardIdId,Number1,Number2,Number3);

        }
        /// <summary>
        /// 电话信息修改
        /// </summary>
        public bool PhoneUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3)
        {
            return human.PhoneUpdate(proc, UserCardIdId, Number1, Number2, Number3);

        }
        /// <summary>
        /// 教职工通讯录查询
        /// </summary>
        public DataSet AddressBookSelect(string proc, string UserName, string DepartmentId,string StatusId, string Gender,string Phone,string Email)
        {
            return human.AddressBookSelect(proc, UserName, DepartmentId, StatusId, Gender,Phone,Email);

        }
       /// <summary>
       /// 用户职务信息添加
       /// </summary>
        public bool UserRoleInsert(string proc, string UserCardId, int DepartmentId, int RoleId)
        {
            return human.UserRoleInsert(proc, UserCardId, DepartmentId, RoleId);
        }
       /// <summary>
       /// 用户职务信息删除
       /// </summary>
        public bool UserRoleDelete(string proc, int UserRoleIdId)
        { 
        return human.UserRoleDelete(proc,UserRoleIdId);
        }
        /// <summary>
        /// 用户职务信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserRoleUpdate(string proc, int UserRoleIdId, int DepartmentId, int RoleId) 
        {
            return human.UserRoleUpdate(proc, UserRoleIdId, DepartmentId, RoleId);
        }
       /// <summary>
       /// 用户职务信息单个查询
       /// </summary>
        public DataSet UserRoleSelect(string proc, int UserRoleIdId)
        {
            return human.UserRoleSelect(proc, UserRoleIdId);
        }
        public bool AdminSeriesInsert(string proc, string AdminSeriesName)
        {
            return human.AdminSeriesInsert(proc, AdminSeriesName);
        }

        public bool ProfessionQualificationInsert(string proc, string ProfessionQualificationName)
        {
            return human.ProfessionQualificationInsert(proc, ProfessionQualificationName);
        }
        public bool ProfessionQualificationDelete(string proc, int ProfessionQualificationId)
        {
            return human.ProfessionQualificationDelete(proc, ProfessionQualificationId);
        }
        public DataSet SelectByProfessionQualificationId(string proc, int ProfessionQualificationId)
        {
            return human.SelectByProfessionQualificationId(proc, ProfessionQualificationId);
        }
        public bool ProfessionQualificationUpdate(string proc, int ProfessionQualificationId, string ProfessionQualificationName)
        {
            return human.ProfessionQualificationUpdate(proc, ProfessionQualificationId, ProfessionQualificationName);
        }
        public bool AdminSeriesUpdate(string proc, int AdminSeriesId, string AdminSeriesName)
        {
            return human.AdminSeriesUpdate(proc, AdminSeriesId, AdminSeriesName);
        }
        public bool AdminSeriesDelete(string proc, int AdminSeriesId)
        {
            return human.AdminSeriesDelete(proc, AdminSeriesId);
        }
        public DataSet SelectByAdminSeriesId(string proc, int AdminSeriesId)
        {
            return human.SelectByAdminSeriesId(proc, AdminSeriesId);
        }
        public bool DeleteByUserCardId(string proc, string UserCardId)
        {
            return human.DeleteByUserCardId(proc, UserCardId);
        }
      
        #endregion
       
        #endregion
        #region 人员调配
        /// <summary>
        /// 人员调配申请
        /// </summary>
        public bool TransferInsert(string proc, string UserCardId,int UseDepartmentId, int NewDepartmentId, string TransferDate, string TransferReason)
        {
            return human.TransferInsert(proc, UserCardId, UseDepartmentId, NewDepartmentId, TransferDate, TransferReason);

        }
        /// <summary>
        /// 人员调配单个查询
        /// </summary>
        public DataSet SelectByTransferId(string proc, int TransferId)
        {
            return human.SelectByTransferId(proc, TransferId);

        }
        /// <summary>
        /// 人员调配查询
        /// </summary>
        public DataSet SelectTransfer(string proc, string UserName,int Year,int Month)
        {
            return human.SelectTransfer(proc, UserName,Year,Month);

        }
        /// <summary>
        /// 人员调配查询
        /// </summary>
        public DataSet SelectTransfers(string proc, string UserName, int DepartmentId,int DepartmentId1, int Year, int Month)
        {
            return human.SelectTransfers(proc, UserName, DepartmentId,DepartmentId1, Year, Month);

        }
       

        /// <summary>
        /// 人员调配修改
        /// </summary>
        public bool TransferUpdate(string proc,string UserCardId, int TransferId,int UseDepartmentId, int NewDepartmentId, string TransferDate, string TransferReason)
        {
            return human.TransferUpdate(proc, UserCardId, TransferId, UseDepartmentId, NewDepartmentId, TransferDate, TransferReason);

        }

        /// <summary>
        /// 人员调配删除
        /// </summary>
        public bool TransferDelete(string proc, int TransferId)
        {
            return human.TransferDelete(proc, TransferId);

        }
     

        #endregion
        #region 离职退休
        /// <summary>
        /// 离职退休申请
        /// </summary>
        public bool QuitInsert(string proc, string UserCardId, string Status, string QuitDate, string QuitReason)
        {
            return human.QuitInsert(proc, UserCardId, Status, QuitDate, QuitReason);

        }

        /// <summary>
        /// 离职退休修改
        /// </summary>
        public bool QuitUpdate(string proc, string UserCardId,int QuitId, string Status, string QuitDate, string QuitReason)
        {
            return human.QuitUpdate(proc, UserCardId, QuitId, Status, QuitDate, QuitReason);

        }
        /// <summary>
        /// 离职退休单个查询
        /// </summary>
        public DataSet SelectByQuitId(string proc, int QuitId)
        {
            return human.SelectByQuitId(proc, QuitId);

        }
        /// <summary>
        /// 离职退休删除
        /// </summary>
        public bool QuitDelete(string proc, int QuitId)
        {
            return human.QuitDelete(proc, QuitId);

        }
      
      
        #endregion
        #region 延迟退休
        /// <summary>
        /// 延迟退休申请
        /// </summary>
        public bool DelayQuitInsert(string proc, string UserCardId,  string DelayQuitReason)
        {
            return human.DelayQuitInsert(proc, UserCardId,DelayQuitReason);

        }

        /// <summary>
        /// 延迟退休修改
        /// </summary>
        public bool DelayQuitUpdate(string proc, string UserCardId,int DelayQuitId, string DelayQuitReason)
        {
            return human.DelayQuitUpdate(proc, UserCardId,DelayQuitId, DelayQuitReason);

        }
        /// <summary>
        /// 延迟退休单个查询
        /// </summary>
        public DataSet SelectByDelayQuitId(string proc, int DelayQuitId)
        {
            return human.SelectByDelayQuitId(proc, DelayQuitId);

        }
        /// <summary>
        /// 延迟退休删除
        /// </summary>
        public bool DelayQuitDelete(string proc, int DelayQuitId)
        {
            return human.DelayQuitDelete(proc, DelayQuitId);

        }
      
        #endregion
        #region 奖惩
        /// <summary>
        /// 奖惩申请
        /// </summary>
        public bool RewardInsert(string proc, string UserCardId, string RewardStatus,string RewardContent, string RewardCompany, string RewardDates,string RewardForm)
        {
            return human.RewardInsert(proc, UserCardId, RewardStatus,RewardContent, RewardCompany, RewardDates,RewardForm);
        }

        /// <summary>
        /// 奖惩修改
        /// </summary>
        public bool RewardUpdate(string proc,string UserCardId, int RewardId, string RewardStatus, string RewardContent, string RewardCompany, string RewardDates, string RewardForm)
        {
            return human.RewardUpdate(proc, UserCardId, RewardId, RewardStatus, RewardContent, RewardCompany, RewardDates, RewardForm);

        }
        /// <summary>
        /// 奖惩单个查询
        /// </summary>
        public DataSet SelectByRewardId(string proc, int RewardId)
        {
            return human.SelectByRewardId(proc, RewardId);

        }
        /// <summary>
        /// 奖惩删除
        /// </summary>
        public bool RewardDelete(string proc, int RewardId)
        {
            return human.RewardDelete(proc, RewardId);

        }
      
        /// <summary>
        /// 人员奖惩查询
        /// </summary>
        public DataSet SelectReward(string proc, string UserName, int Year, int Month, string Reward)
        {
            return human.SelectReward(proc, UserName, Year, Month, Reward);

        }
        #endregion
        #region 请假
        /// <summary>
        /// 请假申请
        /// </summary>
        public bool LeaveInsert(string proc, string UserCardId, string LeaveReason, string StartDate, string EndDate)
        {
            return human.LeaveInsert(proc, UserCardId, LeaveReason,StartDate,EndDate);

        }

        /// <summary>
        /// 请假修改
        /// </summary>
        public bool LeaveUpdate(string proc,string UserCardId, int LeaveId, string LeaveReason, string StartDate, string EndDate)
        {
            return human.LeaveUpdate(proc, UserCardId, LeaveId, LeaveReason, StartDate, EndDate);

        }
        /// <summary>
        /// 请假单个查询
        /// </summary>
        public DataSet SelectByLeaveId(string proc, int LeaveId)
        {
            return human.SelectByLeaveId(proc, LeaveId);

        }
        /// <summary>
        /// 请假删除
        /// </summary>
        public bool LeaveDelete(string proc, int LeaveId)
        {
            return human.LeaveDelete(proc, LeaveId);

        }
       
        #endregion
        #region 职称申报
        /// <summary>
        /// 人员申报信息
        /// </summary>
        public DataSet SelectByApplyTitleIdId(string proc, int ApplyTitleId)
        {
            return human.SelectByApplyTitleIdId(proc, ApplyTitleId);

        }
       

        /// <summary>
        /// 职称下拉框绑定
        /// </summary>
        public DataSet ApplyTitle(string proc)
        {
            return human.ApplyTitle(proc);
        }
        /// <summary>
        /// 职级下拉框
        /// </summary>
        public DataSet Post(string proc)
        {
            return human.Post(proc);
        }
        /// <summary>
        /// 职称申请
        /// </summary>
        public bool ApplyTitleInsert(string proc, string UserCardId, string ApplyReason,int DepartmentId, string ApplyTitle, string Post, string TitleSeries, string Major)
        {
            return human.ApplyTitleInsert(proc, UserCardId, ApplyReason,DepartmentId, ApplyTitle, Post, TitleSeries, Major);

        }
      
        /// <summary>
        /// 申请职称单个查询
        /// </summary>
        public DataSet SelectByApplyTitleId(string proc, int ApplyTitleId)
        {
            return human.SelectByApplyTitleId(proc, ApplyTitleId);

        }
        /// <summary>
        /// 单个职称删除
        /// </summary>
        public bool ApplyTitleDelete(string proc, int ApplyTitleId)
        {
            return human.ApplyTitleDelete(proc, ApplyTitleId);

        }
        /// <summary>
        /// 申请职称修改
        /// </summary>
        public bool ApplyTitleUpdate(string proc, int ApplyTitleId, string ApplyReason, int DepartmentId, string ApplyTitle, string Post, string TitleSeries, string Major)
        {
            return human.ApplyTitleUpdate(proc, ApplyTitleId, ApplyReason, DepartmentId, ApplyTitle, Post, TitleSeries, Major);

        }
        /// <summary>
        /// 人员申请记录查询
        /// </summary>
        public DataSet SelectTitleApplyer(string proc, string UserName, int Year, int Month)
        {
            return human.SelectTitleApplyer(proc, UserName, Year, Month);

        }

       

        /// <summary>
        /// 上传附件
        /// </summary>
        public bool Scdw(string proc, string filename, string filetype, string fileurl, int ApplyTitleId)
        {
            return human.Scdw(proc, filename, filetype, fileurl, ApplyTitleId);
        }
        public bool ApplyFileDelete(string proc, int FileId)
        {
            return human.ApplyFileDelete(proc, FileId);
        }
        /// <summary>
        /// 附件管理
        /// </summary>
        public DataSet Scdwcx(string proc, int ApplyTitleId)
        {
            return human.Scdwcx(proc, ApplyTitleId);
        }
        /// <summary>
        /// 附件编号查询
        /// </summary>
        public DataSet SelectByApplyTitleFileId(string proc, int FileId)
        {
            return human.SelectByApplyTitleFileId(proc, FileId);
        }
        /// <summary>
        /// 平均分值以及人数
        /// </summary>
        public DataSet ApplyTitleFractionAandN(string proc, int ApplyTitleId)
        {
            return human.ApplyTitleFractionAandN(proc, ApplyTitleId);
        }

        #endregion
        #region 人员聘任管理
        /// <summary>
        /// 人员聘任管理信息添加
        /// </summary>
        public bool UsePerAppInsert(string proc, string UserCardId,string DepartmentId, string AppJobId, string AppPostId, string StartDate, string EndDate, string AppSeries, string AppLevel, string IsCurrentApp,string UserCompact)
        {
            return human.UsePerAppInsert(proc, UserCardId,DepartmentId, AppJobId, AppPostId, StartDate, EndDate, AppSeries, AppLevel, IsCurrentApp, UserCompact);

        }
        /// <summary>
        /// 人员聘任管理信息单个查询
        /// </summary>
        public DataSet UsePerAppSelectByUsePerAppId(string proc, int UsePerAppId)
        {
            return human.UsePerAppSelectByUsePerAppId(proc, UsePerAppId);

        }
      
        /// <summary>
        /// 人员聘任管理信息修改
        /// </summary>
        public bool UsePerAppUpdate(string proc, int UsePerAppId, string UserCardId, string DepartmentId, string AppJobId, string AppPostId, string StartDate, string EndDate, string AppSeries, string AppLevel, string IsCurrentApp,string UserCompact)
        {
            return human.UsePerAppUpdate(proc, UsePerAppId, UserCardId, DepartmentId, AppJobId, AppPostId, StartDate, EndDate, AppSeries, AppLevel, IsCurrentApp, UserCompact);

        }
        /// <summary>
        /// 人员聘任管理信息删除
        /// </summary>
        public bool UsePerAppDelete(string proc, int UsePerAppId)
        {
            return human.UsePerAppDelete(proc, UsePerAppId);

        }
        #endregion
        #region 进修培训
        /// <summary>
        /// 进修培训申请
        /// </summary>
      
        public bool FurtherFormInsert(string proc, string UserCardId, string LearningType, string LearningStyle, string LearningUnit,string StartDate,string EndDate, float Fund1, float Fund2, float Fund3,
               float Fund4, float FunOri1, float FunOri2, float FunOri3, float FunOri4, float FunOri5, string IsCertficateOrUnit)
        {
            return human.FurtherFormInsert(proc, UserCardId, LearningType, LearningStyle, LearningUnit, StartDate, EndDate, Fund1, Fund2, Fund3,
            Fund4, FunOri1, FunOri2, FunOri3, FunOri4, FunOri5, IsCertficateOrUnit);

        }
        public bool FurtherFormInsert2(string proc, int TraningId, string UserCardId, string LearningType, string LearningStyle, string LearningUnit, string StartDate, string EndDate, float Fund1, float Fund2, float Fund3,
               float Fund4, float FunOri1, float FunOri2, float FunOri3, float FunOri4, float FunOri5, string IsCertficateOrUnit)
        {
            return human.FurtherFormInsert2(proc, TraningId, UserCardId, LearningType, LearningStyle, LearningUnit, StartDate, EndDate, Fund1, Fund2, Fund3,
            Fund4, FunOri1, FunOri2, FunOri3, FunOri4, FunOri5, IsCertficateOrUnit);


        }

      
        /// <summary>
        /// 进修培训单个查询
        /// </summary>
        public DataSet SelectByTraningId(string proc, int TraningId)
        {
            return human.SelectByTraningId(proc, TraningId);

        }
        /// <summary>
        /// 进修培训删除
        /// </summary>
        public bool TraningDelete(string proc, int TransferId)
        {
            return human.TraningDelete(proc, TransferId);

        }



        public DataSet userInfoS2(int TraningId)
        {
            return human.UserInfoS2(TraningId);

        }


        public bool AddTraningFurByUserCardId(string proc, string UserCardId, string TraningFurTime,
    string TraningFurUnit, string TraningFurContent, string TraningFurShape)
        {
            return human.AddTraningFurByUserCardId(proc, UserCardId, TraningFurTime,
            TraningFurUnit, TraningFurContent, TraningFurShape);

        }



        public DataSet SelectTraningFurByUserCardId(string proc, string UserCardId)
        {
            return human.SelectTraningFurByUserCardId(proc, UserCardId);

        }


     
        public bool AlterTraningFurByUserCardId(string proc, int TraningFurId, string UserCardId, string TraningFurTime,
            string TraningFurUnit, string TraningFurContent, string TraningFurShape)
        {
            return human.AlterTraningFurByUserCardId(proc, TraningFurId, UserCardId, TraningFurTime,
            TraningFurUnit, TraningFurContent, TraningFurShape);

        }


        public bool deleteTraningFurByUserCardId(string proc, int TraningFurId)
        {
            return human.deleteTraningFurByUserCardId(proc, TraningFurId);

        }

        #endregion

        #region 出国
        /// <summary>
        /// 出国申请
        /// </summary>
        public bool AbroadInsert(string proc, string UserCardId, string ProfessionalName, string Direction, string OneLanguage, string OneLanguageDegree, string TwoLanguage, string TwoLanguageDegree, string MainWord, string CountryName,string CountryDate, string Reward, string AbroadPlan)
        {
            return human.AbroadInsert(proc, UserCardId,ProfessionalName,Direction,OneLanguage,OneLanguageDegree,TwoLanguage,TwoLanguageDegree,MainWord, CountryName, CountryDate, Reward,AbroadPlan);

        }

        /// <summary>
        /// 出国修改
        /// </summary>
        public bool AbroadUpdate(string proc,string UserCardId, int AbroadId, string ProfessionalName, string Direction, string OneLanguage, string OneLanguageDegree, string TwoLanguage, string TwoLanguageDegree, string MainWord,string CountryName,string CountryDate, string Reward, string AbroadPlan)
        {
            return human.AbroadUpdate(proc, UserCardId, AbroadId, ProfessionalName, Direction, OneLanguage, OneLanguageDegree, TwoLanguage, TwoLanguageDegree, MainWord, CountryName, CountryDate, Reward, AbroadPlan);

        }
        /// <summary>
        /// 出国单个查询
        /// </summary>
        public DataSet SelectByAbroadId(string proc, int AbroadId)
        {
            return human.SelectByAbroadId(proc, AbroadId);

        }
        /// <summary>
        /// 出国删除
        /// </summary>
        public bool AbroadDelete(string proc, int AbroadId)
        {
            return human.AbroadDelete(proc, AbroadId);

        }
      
        #endregion
      
        #region 干部考核
        /// <summary>
        /// 干部考核申请
        /// </summary>
        public bool RoleApplyInsert(string proc, string UserCardId, string AssessmentName, int ApplyRoleId, string ApplyContent,string ApplyDetailed,int ApplyYearId)
        {
            return human.RoleApplyInsert(proc, UserCardId, AssessmentName, ApplyRoleId, ApplyContent,ApplyDetailed, ApplyYearId);

        }

        /// <summary>
        /// 干部考核修改
        /// </summary>
        public bool RoleApplyUpdate(string proc, int RoleApplyId, string AssessmentName, int ApplyRoleId, string ApplyContent, string ApplyDetailed,int ApplyYearId)
        {
            return human.RoleApplyUpdate(proc, RoleApplyId, AssessmentName, ApplyRoleId, ApplyContent,  ApplyDetailed, ApplyYearId);

        }
        /// <summary>
        /// 干部考核单个查询
        /// </summary>
        public DataSet SelectByRoleApplyId(string proc, int RoleApplyId)
        {
            return human.SelectByRoleApplyId(proc, RoleApplyId);

        }
        /// <summary>
        /// 干部考核查询
        /// </summary>
        public DataSet SelectRoleApply(string proc, string AssessmentName, int RoleId ,int ApplyYearId,string UserName)
        {
            return human.SelectRoleApply(proc, AssessmentName, RoleId, ApplyYearId,UserName);

        }

        /// <summary>
        /// 干部考核删除
        /// </summary>
        public bool RoleApplyDelete(string proc, int RoleApplyId)
        {
            return human.RoleApplyDelete(proc, RoleApplyId);

        }
       
        #endregion
        #region 简历
        /// <summary>
        /// 简历单个查询
        /// </summary>
        public DataSet SelectByResumeId(string proc, int ResumeId)
        {
            return human.SelectByResumeId(proc, ResumeId);

        }
        /// <summary>
        /// 投递简历单个查询
        /// </summary>
        public DataSet SelectByResumeDeliveryId(string proc, int ResumeDeliveryId)
        {
            return human.SelectByResumeDeliveryId(proc, ResumeDeliveryId);

        }
        /// <summary>
        /// 投递简历查询
        /// </summary>
        public DataSet SelectResumeDelivery(string proc, string UserCardId,string Name,int Year,int Month)
        {
            return human.SelectResumeDelivery(proc, UserCardId,Name,Year,Month);

        }


     

        /// <summary>
        /// 简历添加
        /// </summary>
        public bool ResumeInsert(string proc,string UserCardId,string Name,string Gender,string Nation,string Origin,string BirthDay,string Marriage,string Education,string Degree,string political,string Height,string Professional,string Healthy,string Jobintention,string Graduated,string Phone,string Email,string Course,string Ability,string Certificate, string Practice,string Hobbies,string Reward,string Criticism,string Evaluation)
        {
            return human.ResumeInsert(proc,UserCardId,Name,Gender,Nation,Origin,BirthDay,Marriage,Education,Degree,political,Height,Professional,Healthy, Jobintention, Graduated, Phone, Email, Course, Ability, Certificate, Practice, Hobbies, Reward, Criticism, Evaluation);
        }
        /// <summary>
        /// 简历修改
        /// </summary>
        public bool ResumeUpdate(string proc,int ResumeId,string Marriage, string Education, string Degree, string political, string Height, string Professional, string Healthy, string Jobintention, string Graduated, string Phone, string Email, string Course, string Ability, string Certificate, string Practice, string Hobbies, string Reward, string Criticism, string Evaluation)
        {
            return human.ResumeUpdate(proc, ResumeId, Marriage, Education, Degree, political, Height, Professional, Healthy, Jobintention, Graduated, Phone, Email, Course, Ability, Certificate, Practice, Hobbies, Reward, Criticism, Evaluation);
            

        }
       /// <summary>
       /// 简历查询
       /// </summary>
              /// <returns></returns>
        public DataSet SelectResume(string proc, string UserName,string Education,string Political,string Professional)
        {
            return human.SelectResume(proc, UserName,Education,Political,Professional);

        }
        #endregion
        #region 职级招聘
        /// <summary>
        /// 职级招聘申请
        /// </summary>
        public bool RecruitmentInsert(string proc, string UserCardId, string PostName, string Professional, string Education, string Other, string Number, string Money)
        {
            return human.RecruitmentInsert(proc, UserCardId, PostName, Professional, Education, Other, Number, Money);

        }

        /// <summary>
        /// 职级招聘修改
        /// </summary>
        public bool RecruitmentUpdate(string proc,string UserCardId, int RecruitmentId, string PostName,string Professional,string Education,string Other ,string Number,string Money)
        {
            return human.RecruitmentUpdate(proc, UserCardId,RecruitmentId, PostName,Professional,Education,Other,Number,Money);

        }
        /// <summary>
        /// 职级招聘单个查询
        /// </summary>
        public DataSet SelectByRecruitmentId(string proc, int RecruitmentId)
        {
            return human.SelectByRecruitmentId(proc, RecruitmentId);

        }
        /// <summary>
        /// 职级招聘删除
        /// </summary>
        public bool RecruitmentDelete(string proc, int RecruitmentId)
        {
            return human.RecruitmentDelete(proc, RecruitmentId);

        }
      
        #endregion
        #region 减免工作量
        /// <summary>
        /// 减免工作量添加
        /// </summary>

        public bool ReductionInsert(string proc, string UserCardId, string Reason, string RatedOne, string ReductionOne, string ProportionOne, string RatedTwo, string ReductionTwo, string ProportionTwo, string RatedThree, string ReductionThree, string ProportionThree, string WhetherStop, string StopProportion, string StopDate)
        {
            return human.ReductionInsert(proc, UserCardId, Reason, RatedOne, ReductionOne, ProportionOne, RatedTwo, ReductionTwo, ProportionTwo, RatedThree, ReductionThree, ProportionThree, WhetherStop, StopProportion, StopDate);
        }
        /// <summary>
        /// 减免工作量修改
        /// </summary>

        public bool ReductionUpdate(string proc, int ReductionId, string Reason, string RatedOne, string ReductionOne, string ProportionOne, string RatedTwo, string ReductionTwo, string ProportionTwo, string RatedThree, string ReductionThree, string ProportionThree, string WhetherStop, string StopProportion, string StopDate)
        {
            return human.ReductionUpdate(proc, ReductionId, Reason, RatedOne, ReductionOne, ProportionOne, RatedTwo, ReductionTwo, ProportionTwo, RatedThree, ReductionThree, ProportionThree, WhetherStop, StopProportion, StopDate);
        }
     
        /// <summary>
        /// 按减免工作量编号查询
        /// </summary>

        public DataSet SelectByReductionId(string proc, int ReductionId)
        {
            return human.SelectByReductionId(proc, ReductionId);
        }
      
    
        /// <summary>
        /// 减免工作量记录查询
        /// </summary>
        public DataSet SelectsReduction(string proc, string UserName)
        {
            return human.SelectsReduction(proc, UserName);

        }
        #endregion

        #region 申报时间

        /// <summary>
        /// 申报时间信息修改
        /// </summary>
        public bool ApplyYearUpdate(string proc, int ApplyYearId, string StartDate, string EndDate, string UserCardId)
        {
            return human.ApplyYearUpdate(proc, ApplyYearId, StartDate, EndDate, UserCardId);

        }

        /// <summary>
        /// 申报时间信息添加
        /// </summary>
        public bool ApplyYearInsert(string proc, string StartDate, string EndDate, string UserCardId)
        {
            return human.ApplyYearInsert(proc, StartDate, EndDate, UserCardId);

        }

        /// <summary>
        /// 申报时间信息单个查询
        /// </summary>
        public DataSet SelectByApplyYearId(string proc, int ApplyYearId)
        {
            return human.SelectByApplyYearId(proc, ApplyYearId);

        }

        /// <summary>
        /// 申报时间信息删除
        /// </summary>
        public bool ApplyYearDelete(string proc, int ApplyYearId, string UserCardId)
        {
            return human.ApplyYearDelete(proc, ApplyYearId, UserCardId);

        }

        #endregion

        /// <summary>
        /// 按用户姓名查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByUserName(string proc, string UserName)
        {
            return human.SelectByUserName(proc, UserName);

        }
        /// <summary>
        /// 统计查询
        /// </summary>
        public DataSet tongjiSelect(string proc,string TongjiValue)
        {
            return human.tongjiSelect(proc, TongjiValue);

        }


        #region 技术员继续教育学时统计

        /// <summary>
        /// 获取学时表内容
        /// </summary>
        public DataSet TechnicianEducationSelectByUserCardId(string proc, string UserCardId, int ApplyYearId)
        {
            return human.TechnicianEducationSelectByUserCardId(proc, UserCardId, ApplyYearId);
        }
    
        /// <summary>
        /// 删除
        /// </summary>
        public bool TechnicianEducationDeleting(string proc,int EducationId)
        {
            return human.TechnicianEducationDeleting(proc, EducationId);
        }
        /// <summary>
        /// 学时记录删除
        /// </summary>
        public bool ApplyPeriodViewDeleting(string proc, int bianhao)
        {
            return human.ApplyPeriodViewDeleting(proc, bianhao);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public DataSet TechnicianEducationUpdate(string proc, int EducationId, string Project, string EducationSituation, int DeclarePeriod, int InspectPeriod)
        {
            return human.TechnicianEducationUpdate(proc, EducationId, Project, EducationSituation, DeclarePeriod, InspectPeriod);
        }
        /// <summary>
        /// 获取人员信息
        /// </summary>
        public DataSet GetUserMessage(string proc, string UserCardId)
        {
            return human.GetUserMessage(proc, UserCardId);
        }
     
        /// <summary>
        /// 增加申报记录
        /// </summary>
        public DataSet TechnicianEducationAdd(string proc, string UserCardId, int ApplyYearId, string Project, string EducationSituation, int DeclarePeriod, int InspectPeriod)
        {
            return human.GetUserMessage(proc, UserCardId, ApplyYearId, Project, EducationSituation, DeclarePeriod, InspectPeriod);
        }
      
    

        /// <summary>
        /// 获取年份编号
        /// </summary>
        public DataSet GetYearId(string proc, string Year)
        {
            return human.GetYearId(proc, Year);
        }

        /// <summary>
        /// 获取所有人的申报学时信息
        /// </summary>
        public DataSet TechnicianEducationGetAll(string proc,string UserName,string Year)
        {
            return human.TechnicianEducationGetAll(proc,UserName,Year);
        }

        #endregion

















        /// <summary>
       /// 执行查询的存储过程
       /// </summary>
       /// <param name="proc"></param>
       /// <returns></returns>
        public DataSet Select(string proc)
        {
            return human.select(proc);

        }
        /// <summary>
        /// 执行修改的存储过程
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public bool Update(string proc)
        {
            return human.Update(proc);

        }

    }
}
