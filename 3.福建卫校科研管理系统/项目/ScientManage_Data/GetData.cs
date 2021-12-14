using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientManage_Data
{
    public class GetData
    {
        DbCon human = new DbCon();

        #region 基础信息

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
        #endregion
        #region 日志查看
        /// <summary>
        /// 日志查询
        /// </summary>
        public DataSet SelectJournal(string proc, string UserName, string Year,string Month,string Day,string Position,string Evens)
        {
            return human.SelectJournal(proc, UserName,Year,Month,Day,Position,Evens);

        }
#endregion
        #region 按用户年份查询
        /// <summary>
        /// 按用户年份查询
        /// </summary>
        public DataSet SelectByApplyUserCardId(string proc, string UserCardId, int ApplyYearId)
        {
            return human.SelectByApplyUserCardId(proc, UserCardId, ApplyYearId);

        }
        /// <summary>
        /// 按用户部门年份查询
        /// </summary>
        public DataSet SelectsByApplyValue(string proc, string UserName, string DepartmentName,string ApplyYearName)
        {
            return human.SelectsByApplyValue(proc, UserName, DepartmentName, ApplyYearName);

        }
        /// <summary>
        /// 修改考核备注
        /// </summary>
        public bool AssessValueUpdate(string proc, int AssessValueId, string Remarks, string UserCardId)
        {
            return human.AssessValueUpdate(proc, AssessValueId, Remarks, UserCardId);

        }

        /// <summary>
        /// 按考核编号查询
        /// </summary>
        public DataSet SelectByAssessValueId(string proc, int AssessValueId)
        {
            return human.SelectByAssessValueId(proc, AssessValueId);

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
        /// <summary>
        /// 角色权限添加
        /// </summary>
        public bool AuthorityInsert(string proc, int RoleId, int ModelId)
        {
            return human.AuthroityInsert(proc, RoleId, ModelId);

        }
        #endregion
        #region 预留分值修改
        /// <summary>
        /// 角色权限添加
        /// </summary>
        public bool AssessValueUpdateReserve(string proc, int AssessValueId,double Reserve)
        {
            return human.AssessValueUpdateReserve(proc, AssessValueId,Reserve);

        }
        #endregion
        #region 职称
        /// <summary>
        /// 职称信息单个查询
        /// </summary>
        public DataSet SelectByJobId(string proc, int JobId)
        {
            return human.SelectByJobId(proc, JobId);

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
        public bool JobInsert(string proc, string JobName,string UserCardId)
        {
            return human.JobInsert(proc, JobName,UserCardId);

        }
      
        /// <summary>
        /// 职称信息修改
        /// </summary>
        public bool JobUpdate(string proc, int JobId, string JobName,string UserCardId)
        {
            return human.JobUpdate(proc, JobId, JobName,UserCardId);

        }
        /// <summary>
        /// 职称信息删除
        /// </summary>
        public bool JobDelete(string proc, int JobId,string UserCardId)
        {
            return human.JobDelete(proc, JobId,UserCardId);

        }
        /// <summary>
        /// 职称信息删除
        /// </summary>
        public bool ExpertResourcesDelete(string proc, int ExpertResourcesId, string UserCardId)
        {
            return human.ExpertResourcesDelete(proc, ExpertResourcesId, UserCardId);

        }

        #endregion
        #region 专家资源库
        /// <summary>
        /// 专家资源信息添加
        /// </summary>
        public bool ExpertResourcesInsert(string proc, string ExpertNumber, string ExpertName, string ExpertPassword, string SchoolOutside,string UserCardId)
        {
            return human.ExpertResourcesInsert(proc, ExpertNumber, ExpertName, ExpertPassword, SchoolOutside, UserCardId);

        }
       
        /// <summary>
        /// 专家资源信息修改
        /// </summary>
        public bool ExpertResourcesUpdate(string proc,int ExpertResourcesId,string ExpertName,string ExpertPassword, string ExpertNumber, string UserCardId)
        {
            return human.ExpertResourcesUpdate(proc, ExpertResourcesId, ExpertName, ExpertPassword, ExpertNumber, UserCardId);

        }
        /// <summary>
        /// 专家信息单个查询
        /// </summary>
        public DataSet SelectByExpertResourcesId(string proc, int ExpertResourcesId)
        {
            return human.SelectByExpertResourcesId(proc, ExpertResourcesId);

        }
        /// <summary>
        /// 按专家姓名查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByExpertReviewName(string proc, string ExpertName)
        {
            return human.SelectByExpertReviewName(proc, ExpertName);

        }
        #endregion
        #region 专家评审组
        /// <summary>
        /// 专家评审组信息添加
        /// </summary>
        public bool ExpertReviewInsert(string proc, string ExpertReviewName, string LeaderNumber, string UserCardId)
        {
            return human.ExpertReviewInsert(proc, ExpertReviewName,LeaderNumber, UserCardId);

        }
        /// <summary>
        /// 专家评审组信息修改
        /// </summary>
        public bool ExpertReviewUpdate(string proc, int ExpertReviewId, string ExpertReviewName,string LeaderNumber, string UserCardId)
        {
            return human.ExpertReviewUpdate(proc, ExpertReviewId, ExpertReviewName, LeaderNumber, UserCardId);

        }
        /// <summary>
        /// 专家评审组信息单个查询
        /// </summary>
        public DataSet SelectByExpertReviewId(string proc, int ExpertReviewId)
        {
            return human.SelectByExpertReviewId(proc, ExpertReviewId);

        }
        /// <summary>
        /// 专家评审组信息删除
        /// </summary>
        public bool ExpertReviewDelete(string proc, int ExpertReviewId, string UserCardId)
        {
            return human.ExpertReviewDelete(proc, ExpertReviewId, UserCardId);

        }
        /// <summary>
        /// 专家评审组成员信息删除
        /// </summary>
        public bool ExpertReviewMembersDelete(string proc, string ExpertReviewMembersId, string UserCardId)
        {
            return human.ExpertReviewMembersDelete(proc, ExpertReviewMembersId, UserCardId);

        }
        /// <summary>
        /// 专家评审组成员信息添加
        /// </summary>
        public bool ExpertReviewMembersInsert(string proc,int ExpertReviewId,string ExpertNumber)
        {
            return human.ExpertReviewMembersInsert(proc, ExpertReviewId, ExpertNumber);

        }
        #endregion
        #region 任职历程
        /// <summary>
        /// 任职历程信息添加
        /// </summary>
        public bool UseOfficeInsert(string proc, string UserCardId, string DepartmentName, string RoleName, string LevelName, string StartDate, string EndDate, string IsCurrent, string IsAgent)
        {
            return human.UseOfficeInsert(proc, UserCardId, DepartmentName, RoleName, LevelName, StartDate, EndDate, IsCurrent, IsAgent);

        }
        /// <summary>
        /// 任职历程信息单个查询
        /// </summary>
        public DataSet SelectByUseOfficeId(string proc, int UseOfficeId)
        {
            return human.SelectByUseOfficeId(proc, UseOfficeId);

        }
        /// <summary>
        /// 任职历程信息修改
        /// </summary>
        public bool UseOfficeUpdate(string proc, int UseOfficeId, string UserCardId, string DepartmentName, string RoleName, string LevelName, string StartDate, string EndDate, string IsCurrent, string IsAgent)
        {
            return human.UseOfficeUpdate(proc, UseOfficeId, UserCardId, DepartmentName, RoleName, LevelName, StartDate, EndDate, IsCurrent, IsAgent);

        }
        /// <summary>
        /// 任职历程信息删除
        /// </summary>
        public bool UseOfficeDelete(string proc, int UseOfficeId)
        {
            return human.UseOfficeDelete(proc, UseOfficeId);

        }
        #endregion
        #region 职称职级历程
        /// <summary>
        /// 职称职级历程信息添加
        /// </summary>
        public bool UseJobPostInsert(string proc, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent)
        {
            return human.UseJobPostInsert(proc, UserCardId, DepartmentId, JobId, PostId, JobDate, EndDate, JobSeries, WorkLevel, IsCurrent);

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
        public bool UseJobPostUpdate(string proc, int UseJobPostId, string UserCardId, string DepartmentId, string JobId, string PostId, string JobDate, string EndDate, string JobSeries, string WorkLevel, string IsCurrent)
        {
            return human.UseJobPostUpdate(proc, UseJobPostId, UserCardId, DepartmentId, JobId, PostId, JobDate, EndDate, JobSeries, WorkLevel, IsCurrent);

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
        /// <summary>
        /// 用户角色添加
        /// </summary>
        public bool UserEnableUpdate(string proc, string UserCardId, string UserEnable)
        {
            return human.UserEnableUpdate(proc, UserCardId, UserEnable);

        }
        /// <summary>
        /// 用户角色添加
        /// </summary>
        public bool UserWorkValueUpdate(string proc, string UserCardId, string WorkValue)
        {
            return human.UserWorkValueUpdate(proc, UserCardId, WorkValue);

        }
        #endregion 
        #region 职级
        /// <summary>
        /// 职级信息添加
        /// </summary>
        public bool PostInsert(string proc, string PostName, string  PlanPeople,string UserCardId)
        {
            return human.PostInsert(proc, PostName, PlanPeople,UserCardId);

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
        public bool PostUpdate(string proc, int PostId, string PostName, string PlanPeople,string UserCardId)
        {
            return human.PostUpdate(proc, PostId, PostName, PlanPeople,UserCardId);

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
        public bool PostDelete(string proc, int PostId,string UserCardId)
        {
            return human.PostDelete(proc, PostId,UserCardId);

        }

        #endregion
        #region 职务
        /// <summary>
        /// 职务信息添加
        /// </summary>
        public bool RoleInsert(string proc, string RoleName,string UserCardId)
        {
            return human.RoleInsert(proc, RoleName,UserCardId);

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
        public bool RoleUpdate(string proc, int RoleId, string RoleName,string UserCardId)
        {
            return human.RoleUpdate(proc, RoleId, RoleName,UserCardId);

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
        public bool RoleDelete(string proc, int RoleId,string UserCardId)
        {
            return human.RoleDelete(proc, RoleId,UserCardId);

        }
        #endregion
        #region 学位
        /// <summary>
        /// 学位信息添加
        /// </summary>
        public bool DegreeInsert(string proc, string DegreeName,string UserCardId)
        {
            return human.DegreeInsert(proc, DegreeName,UserCardId);

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
        public bool DegreeUpdate(string proc, int DegreeId, string DegreeName,string UserCardId)
        {
            return human.DegreeUpdate(proc, DegreeId, DegreeName,UserCardId);

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
        public bool DegreeDelete(string proc, int DegreeId,string UserCardId)
        {
            return human.DegreeDelete(proc, DegreeId,UserCardId);

        }

        #endregion
        #region 学历
        /// <summary>
        /// 学历信息添加
        /// </summary>
        public bool EducationInsert(string proc, string EducationName,string UserCardId)
        {
            return human.EducationInsert(proc, EducationName,UserCardId);

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
        public bool EducationUpdate(string proc, int EducationId, string EducationName,string UserCardId)
        {
            return human.EducationUpdate(proc, EducationId, EducationName,UserCardId);

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
        public bool EducationDelete(string proc, int EducationId,string UserCardId)
        {
            return human.EducationDelete(proc, EducationId,UserCardId);

        }
        #endregion
        #region 状态
        /// <summary>
        /// 状态信息添加
        /// </summary>
        public bool StatusInsert(string proc, string StatusName,string UserCardId)
        {
            return human.StatusInsert(proc, StatusName,UserCardId);

        }
        /// <summary>
        /// 状态信息单个查询
        /// </summary>
        public DataSet SelectByStatusId(string proc, int StatusId)
        {
            return human.SelectByStatusId(proc, StatusId);

        }
        /// <summary>
        /// 状态信息修改
        /// </summary>
        public bool StatusUpdate(string proc, int StatusId, string StatusName,string UserCardId)
        {
            return human.StatusUpdate(proc, StatusId, StatusName,UserCardId);

        }
        /// <summary>
        /// 状态职务数量查询
        /// </summary>
        public int StatusSum(string proc, int StatusId)
        {
            return human.StatusSum(proc, StatusId);

        }
        /// <summary>
        /// 状态信息删除
        /// </summary>
        public bool StatusDelete(string proc, int StatusId,string UserCardId)
        {
            return human.StatusDelete(proc, StatusId,UserCardId);

        }

        #endregion
        #region 民族
        /// <summary>
        /// 民族信息添加
        /// </summary>
        public bool NationInsert(string proc, string NationName,string UserCardId)
        {
            return human.NationInsert(proc, NationName,UserCardId);

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
        public bool NationUpdate(string proc, int NationId, string NationName,string UserCardId)
        {
            return human.NationUpdate(proc, NationId, NationName,UserCardId);

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
        public bool NationDelete(string proc, int NationId,string UserCardId)
        {
            return human.NationDelete(proc, NationId,UserCardId);

        }
        #endregion
        #region 政治面貌
        /// <summary>
        /// 政治面貌信息添加
        /// </summary>
        public bool PoliticalInsert(string proc, string PoliticalName,string UserCardId)
        {
            return human.PoliticalInsert(proc, PoliticalName,UserCardId);

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
        public bool PoliticalUpdate(string proc, int PoliticalId, string PoliticalName,string UserCardId)
        {
            return human.PoliticalUpdate(proc, PoliticalId, PoliticalName,UserCardId);

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
        public bool PoliticalDelete(string proc, int PoliticalId,string UserCardId)
        {
            return human.PoliticalDelete(proc, PoliticalId,UserCardId);

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
        public bool ModelDelete(string proc, int ModelId,string UserCardId)
        {
            return human.ModelDelete(proc, ModelId,UserCardId);

        }
        /// <summary>
        /// 目录信息添加
        /// </summary>
        public bool ModelInsert(string proc, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, string UserCardId, int ModelNum)
        {
            return human.ModelInsert(proc, ModelName, ModelUrl, FatherModelId, FatherModelName, UserCardId, ModelNum);

        }
        /// <summary>
        /// 目录信息修改
        /// </summary>
        public bool ModelUpdate(string proc, int ModelId, string ModelName, string ModelUrl, int FatherModelId, string FatherModelName, string UserCardId, int ModelNum)
        {
            return human.ModelUpdate(proc, ModelId, ModelName, ModelUrl, FatherModelId, FatherModelName, UserCardId, ModelNum);

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
        #region 资金项目
        /// <summary>
        /// 资金项目信息添加
        /// </summary>
        public bool CapitalInsert(string proc, string CapitalName,string UserCardId)
        {
            return human.CapitalItemInsert(proc, CapitalName,UserCardId);

        }
        /// <summary>
        /// 资金项目信息单个查询
        /// </summary>
        public DataSet SelectByCapitalId(string proc, int CapitalItemId)
        {
            return human.SelectByCapitalItemId(proc, CapitalItemId);

        }
        /// <summary>
        /// 资金项目信息修改
        /// </summary>
        public bool CapitalUpdate(string proc, int CapitalItemId, string CapitalName,string UserCardId)
        {
            return human.CapitalItemUpdate(proc, CapitalItemId, CapitalName,UserCardId);

        }
        /// <summary>
        /// 资金项目信息删除
        /// </summary>
        public bool CapitalDelete(string proc, int CapitalItemId,string UserCardId)
        {
            return human.CapitalItemDelete(proc, CapitalItemId,UserCardId);

        }
        #endregion
        #region  申报时间
        /// <summary>
        /// 申报时间信息添加
        /// </summary>
        public bool ApplyYearInsert(string proc, string StartDate, string EndDate,string UserCardId)
        {
            return human.ApplyYearInsert(proc, StartDate, EndDate,UserCardId);

        }
        /// <summary>
        /// 申报时间信息单个查询
        /// </summary>
        public DataSet SelectByApplyYearId(string proc, int ApplyYearId)
        {
            return human.SelectByApplyYearId(proc, ApplyYearId);

        }
        /// <summary>
        /// 申报时间信息修改
        /// </summary>
        public bool ApplyYearUpdate(string proc, int ApplyYearId, string StartDate, string EndDate,string UserCardId)
        {
            return human.ApplyYearUpdate(proc, ApplyYearId, StartDate, EndDate,UserCardId);

        }

        /// <summary>
        /// 申报时间信息删除
        /// </summary>
        public bool ApplyYearDelete(string proc, int ApplyYearId,string UserCardId)
        {
            return human.ApplyYearDelete(proc, ApplyYearId,UserCardId);

        }
        #endregion
        #region 考核等级
        /// <summary>
        /// 考核等级信息添加
        /// </summary>
        public bool AssessRankInsert(string proc, string RankName, double MinValue, double MaxValue, string RankExplain,string UserCardId)
        {
            return human.AssessRankInsert(proc, RankName, MinValue, MaxValue, RankExplain,UserCardId);

        }
        /// <summary>
        /// 按考核等级编号查询
        /// </summary>
        public DataSet SelectByAssessRankId(string proc, int AssessRankId)
        {
            return human.SelectByAssessRankId(proc, AssessRankId);

        }
        /// <summary>
        /// 考核等级信息修改
        /// </summary>
        public bool AssessRankUpdate(string proc, int AssessRankId, string RankName, double MinValue, double MaxValue, string RankExplain,string UserCardId)
        {
            return human.AssessRankUpdate(proc, AssessRankId, RankName, MinValue, MaxValue, RankExplain,UserCardId);

        }

        /// <summary>
        /// 考核等级信息删除
        /// </summary>
        public bool AssessRankDelete(string proc, int AssessRankId,string UserCardId)
        {
            return human.AssessRankDelete(proc, AssessRankId,UserCardId);

        }
        #endregion
        #region 部门
        /// <summary>
        /// 部门信息添加
        /// </summary>
        public bool DepartmentInsert(string proc, string DepartmentName, string UserCardId)
        {
            return human.DepartmentInsert(proc, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 部门信息单个查询
        /// </summary>
        public DataSet SelectByDepartmentId(string proc, int DepartmentId)
        {
            return human.SelectByDepartmentId(proc, DepartmentId);

        }
        /// <summary>
        /// 部门信息修改
        /// </summary>
        public bool DepartmentUpdate(string proc, int DepartmentId, string DepartmentName, string UserCardId)
        {
            return human.DepartmentUpdate(proc, DepartmentId, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 行政隶属职务数量查询
        /// </summary>
        public int DepartmentSum(string proc, int DepartmentId)
        {
            return human.DepartmentSum(proc, DepartmentId);

        }
        /// <summary>
        /// 部门信息删除
        /// </summary>
        public bool DepartmentDelete(string proc, int DepartmentId,string UserCardId)
        {
            return human.DepartmentDelete(proc, DepartmentId,UserCardId);

        }
      
        #endregion
        #region 角色
        /// <summary>
        /// 角色信息添加
        /// </summary>
        public bool RankInsert(string proc, string RankName, string UserCardId, string RBL1,string RBL2)
        {
            return human.RankInsert(proc, RankName, UserCardId, RBL1, RBL2);

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
        public bool RankUpdate(string proc, int RankId, string RankName, string UserCardId, string RBL1,string RBL2)
        {
            return human.RankUpdate(proc, RankId, RankName,UserCardId,RBL1, RBL2);

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
        public bool RankDelete(string proc, int RankId,string UserCardId)
        {
            return human.RankDelete(proc, RankId,UserCardId);

        }
        /// <summary>
        /// 用户角色添加
        /// </summary>
        public bool UserRankInsert(string proc, string UserCardId, int RankId,string UserCardId2)
        {
            return human.UserRankInsert(proc, UserCardId, RankId,UserCardId2);

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
            return human.AdminSeriesInsert(proc, AdminSeriesName,UserCardId);
        }
        /// <summary>
        /// 行政系列修改
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesId"></param>
        /// <param name="AdminSeriesName"></param>
        /// <returns></returns>
        public bool AdminSeriesUpdate(string proc, int AdminSeriesId, string AdminSeriesName,string UserCardId)
        {
            return human.AdminSeriesUpdate(proc, AdminSeriesId, AdminSeriesName,UserCardId);
        }
        /// <summary>
        /// 行政系列删除
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesId"></param>
        /// <param name="UserCardId"></param>
        /// <returns></returns>
        public bool AdminSeriesDelete(string proc, int AdminSeriesId,string UserCardId)
        {
            return human.AdminSeriesDelete(proc, AdminSeriesId,UserCardId);
        }
        /// <summary>
        /// 按行政系列编号查询
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="AdminSeriesId"></param>
        /// <returns></returns>
        public DataSet SelectByAdminSeriesId(string proc, int AdminSeriesId)
        {
            return human.SelectByAdminSeriesId(proc, AdminSeriesId);
        }
      
        #endregion
        #region 用户
        /// <summary>
        /// 用户数量查询
        /// </summary>
        /// <returns></returns>

        public int UserSum(string proc, string UserCardId, string UserName)
        {
            return human.UserSum(proc, UserCardId, UserName);
        }
        /// <summary>
        /// 用户信息查询
        /// </summary>
        public DataSet UserInfoSelect(string proc, string UserName,string DepartmentId, string StatusId, string StartYear, string EndYear, string Gender, string PoliticalId)
        {
            return human.UserInfoSelect(proc, UserName,DepartmentId,  StatusId, StartYear, EndYear, Gender, PoliticalId);

        }
        /// <summary>
        /// 个人密码修改
        /// </summary>
        public bool UserPwdUpdate(string proc, string UserCardId, string OldPwd, string NewPwd)
        {
            return human.UserPwdUpdate(proc, UserCardId, OldPwd, NewPwd);

        }
        /// <summary>
        /// 用户密码修改
        /// </summary>
        public bool UserInfoPwdUpdate(string proc, string UserCardId, string UserIdCard, string NewPwd)
        {
            return human.UserInfoPwdUpdate(proc, UserCardId, UserIdCard, NewPwd);

        }
        /// <summary>
        /// 用户信息添加
        /// </summary>
        public bool UserInfoInsert(string proc, string UserCardId, string UserPwd, string UserSource, string UserName,string UserCardId2)
        {
            return human.UserInfoInsert(proc, UserCardId, UserPwd, UserSource, UserName,UserCardId2);
        }
        /// <summary>
        /// 按用户工号删除
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="UserCardId"></param>
        /// <returns></returns>
        public bool DeleteByUserCardId(string proc, string UserCardId)
        {
            return human.DeleteByUserCardId(proc, UserCardId);
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
            return human.UserAdminSeriesInsert(proc, UserCardId, AdminSeriesId,UserCardId2);
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
        /// 按用户姓名查询
        /// </summary>
        /// <returns></returns>
        public DataSet SelectByUserName(string proc, string UserName)
        {
            return human.SelectByUserName(proc, UserName);

        }
        /// <summary>
        /// 用户信息修改
        /// </summary>
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
        /// 邮箱信息修改
        /// </summary>
        public bool EmailUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3,string UserCardId2)
        {
            return human.EmailUpdate(proc, UserCardIdId, Number1, Number2, Number3,UserCardId2);

        }
        /// <summary>
        /// 电话信息修改
        /// </summary>
        public bool PhoneUpdate(string proc, string UserCardIdId, string Number1, string Number2, string Number3,string UserCardId2)
        {
            return human.PhoneUpdate(proc, UserCardIdId, Number1, Number2, Number3,UserCardId2);

        }
        #region 证书信息
        /// <summary>
        /// 证书添加
        /// </summary>
        public bool UserEducationInsertByPhotodyxl(string proc, string UserCardId, byte[] imgbyte)
        {
            return human.UserEducationInsertByPhotodyxl(proc, UserCardId, imgbyte);
        }
        #endregion
        #endregion
        #region 用户职务
        /// <summary>
        /// 用户职务信息添加
        /// </summary>
        public bool UserRoleInsert(string proc, string UserCardId, int DepartmentId, int RoleId,string UserCardId2)
        {
            return human.UserRoleInsert(proc, UserCardId, DepartmentId, RoleId,UserCardId2);
        }
        /// <summary>
        /// 用户职务信息删除
        /// </summary>
        public bool UserRoleDelete(string proc, int UserRoleId,string UserCardId)
        {
            return human.UserRoleDelete(proc, UserRoleId,UserCardId);
        }
        /// <summary>
        /// 用户职务信息修改
        /// </summary>
        /// <returns></returns>
        public bool UserRoleUpdate(string proc, int UserRoleIdId, int DepartmentId, int RoleId,string UserCardId2)
        {
            return human.UserRoleUpdate(proc, UserRoleIdId, DepartmentId, RoleId,UserCardId2);
        }
        /// <summary>
        /// 用户职务信息单个查询
        /// </summary>
        public DataSet UserRoleSelect(string proc, int UserRoleIdId)
        {
            return human.UserRoleSelect(proc, UserRoleIdId);
        }

        #endregion
        #region 项目来源
        /// <summary>
        /// 项目来源信息添加
        /// </summary>
        public bool ProjectsFromInsert(string proc, string ProjectsFromExplain, string UserCardId)
        {
            return human.ProjectsFromInsert(proc, ProjectsFromExplain, UserCardId);

        }
        /// <summary>
        /// 项目来源信息单个查询
        /// </summary>
        public DataSet SelectByProjectsFromId(string proc, int ProjectsFromId)
        {
            return human.SelectByProjectsFromId(proc, ProjectsFromId);

        }
        /// <summary>
        /// 项目来源信息修改
        /// </summary>
        public bool ProjectsFromUpdate(string proc, int ProjectsFromId, string ProjectsFromExplain, string UserCardId)
        {
            return human.ProjectsFromUpdate(proc, ProjectsFromId, ProjectsFromExplain, UserCardId);

        }
        /// <summary>
        /// 项目来源职务数量查询
        /// </summary>
        public int ProjectsFromSum(string proc, int ProjectsFromId)
        {
            return human.ProjectsFromSum(proc, ProjectsFromId);

        }
        /// <summary>
        /// 项目来源信息删除
        /// </summary>
        public bool ProjectsFromDelete(string proc, int ProjectsFromId, string UserCardId)
        {
            return human.ProjectsFromDelete(proc, ProjectsFromId, UserCardId);

        }

        #endregion
        #region 项目级别
        /// <summary>
        /// 项目级别信息添加
        /// </summary>
        public bool ProjectsLevelInsert(string proc, string ProjectsLevelExplain, string UserCardId)
        {
            return human.ProjectsLevelInsert(proc, ProjectsLevelExplain, UserCardId);

        }
        /// <summary>
        /// 项目级别信息单个查询
        /// </summary>
        public DataSet SelectByProjectsLevelId(string proc, int ProjectsLevelId)
        {
            return human.SelectByProjectsLevelId(proc, ProjectsLevelId);

        }
        /// <summary>
        /// 项目级别信息修改
        /// </summary>
        public bool ProjectsLevelUpdate(string proc, int ProjectsLevelId, string ProjectsLevelExplain, string UserCardId)
        {
            return human.ProjectsLevelUpdate(proc, ProjectsLevelId, ProjectsLevelExplain, UserCardId);

        }
        /// <summary>
        /// 项目级别职务数量查询
        /// </summary>
        public int ProjectsLevelSum(string proc, int ProjectsLevelId)
        {
            return human.ProjectsLevelSum(proc, ProjectsLevelId);

        }
        /// <summary>
        /// 项目级别信息删除
        /// </summary>
        public bool ProjectsLevelDelete(string proc, int ProjectsLevelId, string UserCardId)
        {
            return human.ProjectsLevelDelete(proc, ProjectsLevelId, UserCardId);

        }

        #endregion
        #region 项目类别
        /// <summary>
        /// 项目类别信息添加
        /// </summary>
        public bool ProjectsSubjectInsert(string proc, string ProjectsSubjectExplain, string UserCardId)
        {
            return human.ProjectsSubjectInsert(proc, ProjectsSubjectExplain, UserCardId);

        }
        /// <summary>
        /// 项目类别信息单个查询
        /// </summary>
        public DataSet SelectByProjectsSubjectId(string proc, int ProjectsSubjectId)
        {
            return human.SelectByProjectsSubjectId(proc, ProjectsSubjectId);

        }
        /// <summary>
        /// 项目类别信息修改
        /// </summary>
        public bool ProjectsSubjectUpdate(string proc, int ProjectsSubjectId, string ProjectsSubjectExplain, string UserCardId)
        {
            return human.ProjectsSubjectUpdate(proc, ProjectsSubjectId, ProjectsSubjectExplain, UserCardId);

        }
        /// <summary>
        /// 项目类别职务数量查询
        /// </summary>
        public int ProjectsSubjectSum(string proc, int ProjectsSubjectId)
        {
            return human.ProjectsSubjectSum(proc, ProjectsSubjectId);

        }
        /// <summary>
        /// 项目类别信息删除
        /// </summary>
        public bool ProjectsSubjectDelete(string proc, int ProjectsSubjectId, string UserCardId)
        {
            return human.ProjectsSubjectDelete(proc, ProjectsSubjectId, UserCardId);

        }

        #endregion
        #region 项目模板
        /// <summary>
        /// 项目模板信息添加
        /// </summary>
        public bool ProjectsTemplateInsert(string proc, string Category, string TemplateName, string FileUrl, string UserCardId)
        {
            return human.ProjectsTemplateInsert(proc, Category, TemplateName, FileUrl, UserCardId);

        }
        /// <summary>
        /// 项目模板信息单个查询
        /// </summary>
        public DataSet SelectByProjectsTemplateId(string proc, int TemplateId)
        {
            return human.SelectByProjectsTemplateId(proc, TemplateId);

        }
        /// <summary>
        /// 按类型查询
        /// </summary>
        public DataSet SelectByProjectsTemplateCategory(string proc, string Category)
        {
            return human.SelectByProjectsTemplateCategory(proc, Category);

        }
        /// <summary>
        /// 项目模板信息修改
        /// </summary>
        public bool ProjectsTemplateUpdate(string proc, int TemplateId, string Category, string TemplateName, string FileUrl, string UserCardId)
        {
            return human.ProjectsTemplateUpdate(proc, TemplateId, Category, TemplateName, FileUrl, UserCardId);

        }

        /// <summary>
        /// 项目模板信息删除
        /// </summary>
        public bool ProjectsTemplateDelete(string proc, int TemplateId, string UserCardId)
        {
            return human.ProjectsTemplateDelete(proc, TemplateId, UserCardId);

        }
        #endregion
        #endregion
        public DataSet UserViewSelects(string proc, string Selects, string Wheres)
        {
            return human.UserViewSelects(proc, Selects, Wheres);
        }
        #region 科研工作量
        #region 获奖
        /// <summary>
        /// 获奖申请
        /// </summary>
        public bool WinningInsert(string proc, string UserCardId, int DepartmentId, string WinningName, string WinningCategory, string WinningLevel,  double WinningValue, int PartnerRank, double PartnerValue,string  Remarks,string WiningUrl)
        {
            return human.WinningInsert(proc, UserCardId, DepartmentId, WinningName, WinningCategory, WinningLevel,  WinningValue, PartnerRank, PartnerValue, Remarks,WiningUrl);

        }
        /// <summary>
        /// 竞赛获奖可审批查询
        /// </summary>
        public DataSet ExamineSelectUser(string proc, string UserCardId, int RankId, string text)
        {
            return human.ExamineSelectUser(proc, UserCardId, RankId, text);

        }



        /// <summary>
        /// 获奖合作者添加
        /// </summary>
        public bool WinningPartnerInsert(string proc, int WinningId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.WinningPartnerInsert(proc, WinningId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 获奖单个查询
        /// </summary>
        public DataSet SelectByWinningId(string proc, int WinningId)
        {
            return human.SelectByWinningId(proc, WinningId);

        }
        /// <summary>
        /// 获奖合作者单个查询
        /// </summary>
        public DataSet SelectByWinningPartnerId(string proc, int WinningPartnerId)
        {
            return human.SelectByWinningPartnerId(proc, WinningPartnerId);

        }
        /// <summary>
        /// 获奖查询
        /// </summary>
        public DataSet SelectWinning(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectWinning(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人获奖查询
        /// </summary>
        public DataSet SelectWinningByUserCardId(string proc, string UserCardId)
        {
            return human.SelectWinningByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 获奖可审批查询
        /// </summary>
        public DataSet WinningExamineSelectUser(string proc, string UserCardId,int RankId)
        {
            return human.WinningExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 获奖修改
        /// </summary>
        public bool WinningUpdate(string proc, int WinningId,int DepartmentId, string WinningName, string WinningCategory, string WinningLevel,  double WinningValue, int PartnerRank, double PartnerValue,string Remarks,string WinningUrl)
        {
            return human.WinningUpdate(proc, WinningId, DepartmentId, WinningName, WinningCategory, WinningLevel, WinningValue, PartnerRank, PartnerValue, Remarks,WinningUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool WinningPartnerUpdate(string proc, int WinningPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.WinningPartnerUpdate(proc, WinningPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 获奖删除
        /// </summary>
        public bool WinningDelete(string proc, int WinningId)
        {
            return human.WinningDelete(proc, WinningId);

        }
        /// <summary>
        /// 获奖合作者删除
        /// </summary>
        public bool WinningPartnerDelete(string proc, int WinningPartnerId)
        {
            return human.WinningPartnerDelete(proc, WinningPartnerId);

        }
        /// <summary>
        /// 获奖审批添加
        /// </summary>
        public bool WinningExamineInsert(string proc, int WinningId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult,int RankId)
        {
            return human.WinningExamineInsert(proc, WinningId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 获奖审批查询
        /// </summary>
        public DataSet SelectWinningExamine(string proc, int WinningId)
        {
            return human.SelectWinningExamine(proc, WinningId);

        }
        /// <summary>
        /// 获奖审批流程添加
        /// </summary>
        public bool WinningProcessInsert(string proc,  int ProcessRoleId, int ProcessOrder, string DepartmentName,string UserCardId)
        {
            return human.WinningProcessInsert(proc,  ProcessRoleId, ProcessOrder, DepartmentName,UserCardId);

        }
        /// <summary>
        /// 获奖审批流程删除
        /// </summary>
        public bool WinningProcessDelete(string proc, int WinningProcessId,string UserCardId)
        {
            return human.WinningProcessDelete(proc, WinningProcessId,UserCardId);

        }
        /// <summary>
        /// 获奖记录查询
        /// </summary>
        public DataSet SelectsWinning(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string WinningName,string WinningForm,string WinningYear)
        {
            return human.SelectsWinning(proc, UserName, DepartmentId, Year, Month, Status,WinningName,WinningForm,WinningYear);

        }
        #endregion
        #region 工作量项目
        /// <summary>
        /// 工作量项目申请
        /// </summary>
        public bool WorkLoadProjectsInsert(string proc, string ProjectsId, string UserCardId, int DepartmentId, string WorkLoadProjectsName, string WorkLoadForm, string StartEndDate, string WorkLoadCapital, string CateGory, double WorkLoadProjectsValue, int PartnerRank, double PartnerValue,string Remarks,string WorkLoadProjectsUrl,double SumProjectsValue)
        {
            return human.WorkLoadProjectsInsert(proc, ProjectsId, UserCardId, DepartmentId, WorkLoadProjectsName, WorkLoadForm, StartEndDate, WorkLoadCapital, CateGory, WorkLoadProjectsValue, PartnerRank, PartnerValue, Remarks, WorkLoadProjectsUrl, SumProjectsValue);

        }
        /// <summary>
        /// 工作量项目合作者添加
        /// </summary>
        public bool WorkLoadProjectsPartnerInsert(string proc, int WorkLoadProjectsId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.WorkLoadProjectsPartnerInsert(proc, WorkLoadProjectsId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 工作量项目单个查询
        /// </summary>
        public DataSet SelectByWorkLoadProjectsId(string proc, int WorkLoadProjectsId)
        {
            return human.SelectByWorkLoadProjectsId(proc, WorkLoadProjectsId);

        }
        /// <summary>
        /// 工作量项目合作者单个查询
        /// </summary>
        public DataSet SelectByWorkLoadProjectsPartnerId(string proc, int WorkLoadProjectsPartnerId)
        {
            return human.SelectByWorkLoadProjectsPartnerId(proc, WorkLoadProjectsPartnerId);

        }
        /// <summary>
        /// 工作量项目查询
        /// </summary>
        public DataSet SelectWorkLoadProjects(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectWorkLoadProjects(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人工作量项目查询
        /// </summary>
        public DataSet SelectWorkLoadProjectsByUserCardId(string proc, string UserCardId)
        {
            return human.SelectWorkLoadProjectsByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 工作量项目可审批查询
        /// </summary>
        public DataSet WorkLoadProjectsExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.WorkLoadProjectsExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 工作量项目修改
        /// </summary>
        public bool WorkLoadProjectsUpdate(string proc, int WorkLoadProjectsId, string ProjectsId, int DepartmentId, string WorkLoadProjectsName, string WorkLoadForm, string StartEndDate, string WorkLoadCapital, string CateGory, double WorkLoadProjectsValue, int PartnerRank, double PartnerValue,string Remarks,string WorkLoadProjectsUrl,double SumProjectsValue)
        {
            return human.WorkLoadProjectsUpdate(proc, WorkLoadProjectsId, ProjectsId, DepartmentId, WorkLoadProjectsName, WorkLoadForm, StartEndDate, WorkLoadCapital, CateGory, WorkLoadProjectsValue, PartnerRank, PartnerValue, Remarks, WorkLoadProjectsUrl, SumProjectsValue);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool WorkLoadProjectsPartnerUpdate(string proc, int WorkLoadProjectsPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.WorkLoadProjectsPartnerUpdate(proc, WorkLoadProjectsPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 工作量项目删除
        /// </summary>
        public bool WorkLoadProjectsDelete(string proc, int WorkLoadProjectsId)
        {
            return human.WorkLoadProjectsDelete(proc, WorkLoadProjectsId);

        }
        /// <summary>
        /// 工作量项目合作者删除
        /// </summary>
        public bool WorkLoadProjectsPartnerDelete(string proc, int WorkLoadProjectsPartnerId)
        {
            return human.WorkLoadProjectsPartnerDelete(proc, WorkLoadProjectsPartnerId);

        }
        /// <summary>
        /// 工作量项目审批添加
        /// </summary>
        public bool WorkLoadProjectsExamineInsert(string proc, int WorkLoadProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.WorkLoadProjectsExamineInsert(proc, WorkLoadProjectsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 工作量项目审批查询
        /// </summary>
        public DataSet SelectWorkLoadProjectsExamine(string proc, int WorkLoadProjectsId)
        {
            return human.SelectWorkLoadProjectsExamine(proc, WorkLoadProjectsId);

        }
        /// <summary>
        /// 工作量项目审批流程添加
        /// </summary>
        public bool WorkLoadProjectsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.WorkLoadProjectsProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 工作量项目审批流程删除
        /// </summary>
        public bool WorkLoadProjectsProcessDelete(string proc, int WorkLoadProjectsProcessId, string UserCardId)
        {
            return human.WorkLoadProjectsProcessDelete(proc, WorkLoadProjectsProcessId, UserCardId);

        }
        /// <summary>
        /// 工作量项目记录查询
        /// </summary>
        public DataSet SelectsWorkLoadProjects(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string ProjectsName,string ProjectsForm,string WinningYear)
        {
            return human.SelectsWorkLoadProjects(proc, UserName, DepartmentId, Year, Month, Status,ProjectsName,ProjectsForm,WinningYear);

        }
        #endregion
        #region 论文
        /// <summary>
        /// 论文申请
        /// </summary>
        public bool PaperInsert(string proc, string UserCardId,int DepartmentId, string PaperName, string PaperSubject, string PaperLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears,string Remarks,string PaperUrl)
        {
            return human.PaperInsert(proc, UserCardId, DepartmentId, PaperName, PaperSubject, PaperLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks, PaperUrl);

        }
        /// <summary>
        /// 论文合作者添加
        /// </summary>
        public bool PaperPartnerInsert(string proc, int PaperId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.PaperPartnerInsert(proc, PaperId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 论文单个查询
        /// </summary>
        public DataSet SelectByPaperId(string proc, int PaperId)
        {
            return human.SelectByPaperId(proc, PaperId);

        }
        /// <summary>
        /// 论文合作者单个查询
        /// </summary>
        public DataSet SelectByPaperPartnerId(string proc, int PaperPartnerId)
        {
            return human.SelectByPaperPartnerId(proc, PaperPartnerId);

        }
        /// <summary>
        /// 论文查询
        /// </summary>
        public DataSet SelectPaper(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectPaper(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人论文查询
        /// </summary>
        public DataSet SelectPaperByUserCardId(string proc, string UserCardId)
        {
            return human.SelectPaperByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 论文可审批查询
        /// </summary>
        public DataSet PaperExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.PaperExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 论文修改
        /// </summary>
        public bool PaperUpdate(string proc, int PaperId,int DepartmentId, string PaperName, string PaperSubject, string PaperLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears,string Remarks,string PaperUrl)
        {
            return human.PaperUpdate(proc, PaperId, DepartmentId, PaperName, PaperSubject, PaperLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks, PaperUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool PaperPartnerUpdate(string proc, int PaperPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.PaperPartnerUpdate(proc, PaperPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 论文删除
        /// </summary>
        public bool PaperDelete(string proc, int PaperId)
        {
            return human.PaperDelete(proc, PaperId);

        }
        /// <summary>
        /// 论文合作者删除
        /// </summary>
        public bool PaperPartnerDelete(string proc, int PaperPartnerId)
        {
            return human.PaperPartnerDelete(proc, PaperPartnerId);

        }
        /// <summary>
        /// 论文审批添加
        /// </summary>
        public bool PaperExamineInsert(string proc, int PaperId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.PaperExamineInsert(proc, PaperId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 论文审批查询
        /// </summary>
        public DataSet SelectPaperExamine(string proc, int PaperId)
        {
            return human.SelectPaperExamine(proc, PaperId);

        }
        /// <summary>
        /// 论文审批流程添加
        /// </summary>
        public bool PaperProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.PaperProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 论文审批流程删除
        /// </summary>
        public bool PaperProcessDelete(string proc, int PaperProcessId, string UserCardId)
        {
            return human.PaperProcessDelete(proc, PaperProcessId, UserCardId);

        }
        /// <summary>
        /// 论文记录查询
        /// </summary>
        public DataSet SelectsPaper(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string PaperSubject, string PaperName, string WinningYear)
        {
            return human.SelectsPaper(proc, UserName, DepartmentId, Year, Month, Status, PaperSubject, PaperName, WinningYear);

        }
        #endregion
        #region 著作
        /// <summary>
        /// 著作申请
        /// </summary>
        public bool TeachingInsert(string proc, string UserCardId,int DepartmentId, string BookName, string PressCategory, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, int PartnerRank, double PartnerValue, string Remarks, string TeachingUrl)
        {
            return human.TeachingInsert(proc, UserCardId, DepartmentId, BookName, PressCategory, PressName, PressDate, Revision, TotalNumber, TeachingValue, PartnerRank, PartnerValue, Remarks, TeachingUrl);

        }
        /// <summary>
        /// 著作合作者添加
        /// </summary>
        public bool TeachingPartnerInsert(string proc, int TeachingId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.TeachingPartnerInsert(proc, TeachingId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 著作单个查询
        /// </summary>
        public DataSet SelectByTeachingId(string proc, int TeachingId)
        {
            return human.SelectByTeachingId(proc, TeachingId);

        }
        /// <summary>
        /// 著作合作者单个查询
        /// </summary>
        public DataSet SelectByTeachingPartnerId(string proc, int TeachingPartnerId)
        {
            return human.SelectByTeachingPartnerId(proc, TeachingPartnerId);

        }
        /// <summary>
        /// 著作查询
        /// </summary>
        public DataSet SelectTeaching(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectTeaching(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人著作查询
        /// </summary>
        public DataSet SelectTeachingByUserCardId(string proc, string UserCardId)
        {
            return human.SelectTeachingByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 著作可审批查询
        /// </summary>
        public DataSet TeachingExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.TeachingExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 著作修改
        /// </summary>
        public bool TeachingUpdate(string proc, int TeachingId,int DepartmentId, string BookName, string PressCategory, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, int PartnerRank, double PartnerValue, string Remarks, string TeachingUrl)
        {
            return human.TeachingUpdate(proc, TeachingId, DepartmentId, BookName, PressCategory, PressName, PressDate, Revision, TotalNumber, TeachingValue, PartnerRank, PartnerValue, Remarks, TeachingUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool TeachingPartnerUpdate(string proc, int TeachingPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.TeachingPartnerUpdate(proc, TeachingPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 著作删除
        /// </summary>
        public bool TeachingDelete(string proc, int TeachingId)
        {
            return human.TeachingDelete(proc, TeachingId);

        }
        /// <summary>
        /// 著作合作者删除
        /// </summary>
        public bool TeachingPartnerDelete(string proc, int TeachingPartnerId)
        {
            return human.TeachingPartnerDelete(proc, TeachingPartnerId);

        }
        /// <summary>
        /// 著作审批添加
        /// </summary>
        public bool TeachingExamineInsert(string proc, int TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.TeachingExamineInsert(proc, TeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 著作审批查询
        /// </summary>
        public DataSet SelectTeachingExamine(string proc, int TeachingId)
        {
            return human.SelectTeachingExamine(proc, TeachingId);

        }
        /// <summary>
        /// 著作审批流程添加
        /// </summary>
        public bool TeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.TeachingProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 著作审批流程删除
        /// </summary>
        public bool TeachingProcessDelete(string proc, int TeachingProcessId, string UserCardId)
        {
            return human.TeachingProcessDelete(proc, TeachingProcessId, UserCardId);

        }
        /// <summary>
        /// 著作记录查询
        /// </summary>
        public DataSet SelectsTeaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string BookName, string PressName, string WinningYear)
        {
            return human.SelectsTeaching(proc, UserName, DepartmentId, Year, Month, Status, BookName, PressName, WinningYear);

        }
        #endregion
        #region 成果
        /// <summary>
        /// 成果申请
        /// </summary>
        public bool HarvestInsert(string proc, string UserCardId,int DepartmentId, string HarvestName, string AppraisalCompany, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue,string Remarks,string HarvestUrl)
        {
            return human.HarvestInsert(proc, UserCardId, DepartmentId, HarvestName, AppraisalCompany, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue, Remarks,HarvestUrl);

        }
        /// <summary>
        /// 成果合作者添加
        /// </summary>
        public bool HarvestPartnerInsert(string proc, int HarvestId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.HarvestPartnerInsert(proc, HarvestId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 成果单个查询
        /// </summary>
        public DataSet SelectByHarvestId(string proc, int HarvestId)
        {
            return human.SelectByHarvestId(proc, HarvestId);

        }
        /// <summary>
        /// 成果合作者单个查询
        /// </summary>
        public DataSet SelectByHarvestPartnerId(string proc, int HarvestPartnerId)
        {
            return human.SelectByHarvestPartnerId(proc, HarvestPartnerId);

        }
        /// <summary>
        /// 成果查询
        /// </summary>
        public DataSet SelectHarvest(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectHarvest(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人成果查询
        /// </summary>
        public DataSet SelectHarvestByUserCardId(string proc, string UserCardId)
        {
            return human.SelectHarvestByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 成果可审批查询
        /// </summary>
        public DataSet HarvestExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.HarvestExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 成果修改
        /// </summary>
        public bool HarvestUpdate(string proc, int HarvestId,int DepartmentId, string HarvestName, string AppraisalCompany, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue,string Remarks,string HarvestUrl)
        {
            return human.HarvestUpdate(proc, HarvestId, DepartmentId, HarvestName, AppraisalCompany, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue, Remarks, HarvestUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool HarvestPartnerUpdate(string proc, int HarvestPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.HarvestPartnerUpdate(proc, HarvestPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 成果删除
        /// </summary>
        public bool HarvestDelete(string proc, int HarvestId)
        {
            return human.HarvestDelete(proc, HarvestId);

        }
        /// <summary>
        /// 成果合作者删除
        /// </summary>
        public bool HarvestPartnerDelete(string proc, int HarvestPartnerId)
        {
            return human.HarvestPartnerDelete(proc, HarvestPartnerId);

        }
        /// <summary>
        /// 成果审批添加
        /// </summary>
        public bool HarvestExamineInsert(string proc, int HarvestId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.HarvestExamineInsert(proc, HarvestId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 成果审批查询
        /// </summary>
        public DataSet SelectHarvestExamine(string proc, int HarvestId)
        {
            return human.SelectHarvestExamine(proc, HarvestId);

        }
        /// <summary>
        /// 成果审批流程添加
        /// </summary>
        public bool HarvestProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.HarvestProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 成果审批流程删除
        /// </summary>
        public bool HarvestProcessDelete(string proc, int HarvestProcessId, string UserCardId)
        {
            return human.HarvestProcessDelete(proc, HarvestProcessId, UserCardId);

        }
        /// <summary>
        /// 成果记录查询
        /// </summary>
        public DataSet SelectsHarvest(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string HarvestName, string Company, string WinningYear)
        {
            return human.SelectsHarvest(proc, UserName, DepartmentId, Year, Month, Status, HarvestName, Company, WinningYear);

        }
        #endregion
        #region 专利
        /// <summary>
        /// 专利申请
        /// </summary>
        public bool PatentInsert(string proc, string UserCardId,int DepartmentId, string PatentName, string PatentCateGory, string PatentLevel, double PatentValue, int PartnerRank, double PartnerValue, string PatentPrizes,string Remarks,string PatentUrl)
        {
            return human.PatentInsert(proc, UserCardId, DepartmentId, PatentName, PatentCateGory, PatentLevel, PatentValue, PartnerRank, PartnerValue, PatentPrizes, Remarks, PatentUrl);

        }
        /// <summary>
        /// 专利合作者添加
        /// </summary>
        public bool PatentPartnerInsert(string proc, int PatentId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.PatentPartnerInsert(proc, PatentId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 专利单个查询
        /// </summary>
        public DataSet SelectByPatentId(string proc, int PatentId)
        {
            return human.SelectByPatentId(proc, PatentId);

        }
        /// <summary>
        /// 专利合作者单个查询
        /// </summary>
        public DataSet SelectByPatentPartnerId(string proc, int PatentPartnerId)
        {
            return human.SelectByPatentPartnerId(proc, PatentPartnerId);

        }
        /// <summary>
        /// 专利查询
        /// </summary>
        public DataSet SelectPatent(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectPatent(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人专利查询
        /// </summary>
        public DataSet SelectPatentByUserCardId(string proc, string UserCardId)
        {
            return human.SelectPatentByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 专利可审批查询
        /// </summary>
        public DataSet PatentExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.PatentExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 专利修改
        /// </summary>
        public bool PatentUpdate(string proc, int PatentId, int DepartmentId, string PatentName, string PatentCateGory, string PatentLevel, double PatentValue, int PartnerRank, double PartnerValue, string Prizes, string Remarks, string PatentUrl)
        {
            return human.PatentUpdate(proc, PatentId, DepartmentId, PatentName, PatentCateGory, PatentLevel, PatentValue, PartnerRank, PartnerValue, Prizes, Remarks, PatentUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool PatentPartnerUpdate(string proc, int PatentPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.PatentPartnerUpdate(proc, PatentPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 专利删除
        /// </summary>
        public bool PatentDelete(string proc, int PatentId)
        {
            return human.PatentDelete(proc, PatentId);

        }
        /// <summary>
        /// 专利合作者删除
        /// </summary>
        public bool PatentPartnerDelete(string proc, int PatentPartnerId)
        {
            return human.PatentPartnerDelete(proc, PatentPartnerId);

        }
        /// <summary>
        /// 专利审批添加
        /// </summary>
        public bool PatentExamineInsert(string proc, int PatentId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.PatentExamineInsert(proc, PatentId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 专利审批查询
        /// </summary>
        public DataSet SelectPatentExamine(string proc, int PatentId)
        {
            return human.SelectPatentExamine(proc, PatentId);

        }
        /// <summary>
        /// 专利审批流程添加
        /// </summary>
        public bool PatentProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.PatentProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 专利审批流程删除
        /// </summary>
        public bool PatentProcessDelete(string proc, int PatentProcessId, string UserCardId)
        {
            return human.PatentProcessDelete(proc, PatentProcessId, UserCardId);

        }
        /// <summary>
        /// 专利记录查询
        /// </summary>
        public DataSet SelectsPatent(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string PatentName, string PatentCateGory, string WinningYear)
        {
            return human.SelectsPatent(proc, UserName, DepartmentId, Year, Month, Status, PatentName, PatentCateGory, WinningYear);

        }
        #endregion
        #region 指导学生
        /// <summary>
        /// 指导学生申请
        /// </summary>
        public bool GuidanceInsert(string proc, string UserCardId,int DepartmentId, string GuidanceName, string GuidanceLevel, double GuidanceValue, int PartnerRank, double PartnerValue ,string Remarks,string GuidanceUrl)
        {
            return human.GuidanceInsert(proc, UserCardId, DepartmentId, GuidanceName, GuidanceLevel, GuidanceValue, PartnerRank, PartnerValue,Remarks, GuidanceUrl);

        }
        /// <summary>
        /// 指导学生合作者添加
        /// </summary>
        public bool GuidancePartnerInsert(string proc, int GuidanceId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.GuidancePartnerInsert(proc, GuidanceId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 指导学生单个查询
        /// </summary>
        public DataSet SelectByGuidanceId(string proc, int GuidanceId)
        {
            return human.SelectByGuidanceId(proc, GuidanceId);

        }
        /// <summary>
        /// 指导学生合作者单个查询
        /// </summary>
        public DataSet SelectByGuidancePartnerId(string proc, int GuidancePartnerId)
        {
            return human.SelectByGuidancePartnerId(proc, GuidancePartnerId);

        }
        /// <summary>
        /// 指导学生查询
        /// </summary>
        public DataSet SelectGuidance(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectGuidance(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人指导学生查询
        /// </summary>
        public DataSet SelectGuidanceByUserCardId(string proc, string UserCardId)
        {
            return human.SelectGuidanceByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 指导学生可审批查询
        /// </summary>
        public DataSet GuidanceExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.GuidanceExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 指导学生修改
        /// </summary>
        public bool GuidanceUpdate(string proc, int GuidanceId,int DepartmentId, string GuidanceName, string GuidanceLevel, double GuidanceValue, int PartnerRank, double PartnerValue,string Remarks,string GuidanceUrl)
        {
            return human.GuidanceUpdate(proc, GuidanceId, DepartmentId, GuidanceName, GuidanceLevel, GuidanceValue, PartnerRank, PartnerValue, Remarks,GuidanceUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool GuidancePartnerUpdate(string proc, int GuidancePartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.GuidancePartnerUpdate(proc, GuidancePartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 指导学生删除
        /// </summary>
        public bool GuidanceDelete(string proc, int GuidanceId)
        {
            return human.GuidanceDelete(proc, GuidanceId);

        }
        /// <summary>
        /// 指导学生合作者删除
        /// </summary>
        public bool GuidancePartnerDelete(string proc, int GuidancePartnerId)
        {
            return human.GuidancePartnerDelete(proc, GuidancePartnerId);

        }
        /// <summary>
        /// 指导学生审批添加
        /// </summary>
        public bool GuidanceExamineInsert(string proc, int GuidanceId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.GuidanceExamineInsert(proc, GuidanceId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 指导学生审批查询
        /// </summary>
        public DataSet SelectGuidanceExamine(string proc, int GuidanceId)
        {
            return human.SelectGuidanceExamine(proc, GuidanceId);

        }
        /// <summary>
        /// 指导学生审批流程添加
        /// </summary>
        public bool GuidanceProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.GuidanceProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 指导学生审批流程删除
        /// </summary>
        public bool GuidanceProcessDelete(string proc, int GuidanceProcessId, string UserCardId)
        {
            return human.GuidanceProcessDelete(proc, GuidanceProcessId, UserCardId);

        }
        /// <summary>
        /// 指导学生记录查询
        /// </summary>
        public DataSet SelectsGuidance(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string GuidanceName, string GuidanceLevel, string WinningYear)
        {
            return human.SelectsGuidance(proc, UserName, DepartmentId, Year, Month, Status,GuidanceName,GuidanceLevel, WinningYear);

        }
        #endregion
        #endregion
        #region 项目
        #region 纵向项目
        /// <summary>
        /// 纵向项目基础信息保存
        /// </summary>
        public bool LongProjectsInsert(string proc, string LongProjectsId, string UserCardId,int DepartmentId, string ProjectsName, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company, string DeclareUrl,string IsSchool)
        {
            return human.LongProjectsInsert(proc, LongProjectsId, UserCardId, DepartmentId, ProjectsName, ProjectsFromId, ProjectsSubjectId, ProjectsLevelId, Company, DeclareUrl, IsSchool);

        }
        /// <summary>
        /// 纵向项目保存
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsSumInsert(string proc, string LongProjectsId, string UserCardId, int DepartmentId, string ProjectsName, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company, string IsSchool, int ApplyYearId, string DeclareStatus, string StandStatus, string InspectStatus, string EndStatus)
        {
            return human.LongProjectsSumInsert(proc, LongProjectsId, UserCardId, DepartmentId, ProjectsName, ProjectsFromId, ProjectsSubjectId, ProjectsLevelId, Company, IsSchool, ApplyYearId, DeclareStatus, StandStatus, InspectStatus, EndStatus);
        }
        /// <summary>
        /// 纵向项目立项保存
        /// </summary>
        public bool LongProjectsApprovalInsert(string proc, string LongProjectsId, string FileUrl)
        {
            return human.LongProjectsApprovalInsert(proc, LongProjectsId, FileUrl);

        }
        /// <summary>
        /// 纵向项目结题基础信息保存
        /// </summary>
        public bool LongProjectsEndInsert(string proc, string LongProjectsId, string UserCardId, string LongProjectsName, string LongProjectsCateGory, string Company, string SmallCateGory, string PhoneNumber, string StartDate, string EndDate)
        {
            return human.LongProjectsEndInsert(proc, LongProjectsId, UserCardId, LongProjectsName, LongProjectsCateGory, Company, SmallCateGory, PhoneNumber, StartDate, EndDate);

        }

        /// <summary>
        /// 纵向项目查询
        /// </summary>
        public DataSet SelectsLongProjects(string proc, string ProjectsId, string ProjectsName, string UserName, string DepartmentName, string ApplyYear, string Subject, string Level, string From, string Declare, string Stand, string Inspect, string Ends)
        {
            return human.SelectsLongProjects(proc, ProjectsId, ProjectsName, UserName, DepartmentName, ApplyYear, Subject, Level, From, Declare, Stand, Inspect, Ends);

        }
        /// <summary>
        /// 纵向项目结题基本信息保存
        /// </summary>
        public bool LongProjectsEndUpdate(string proc, string LongProjectsId, string EndDate, double ActualCapital)
        {
            return human.LongProjectsEndUpdate(proc, LongProjectsId, EndDate, ActualCapital);

        }

        /// <summary>
        /// 纵向项目问题保存
        /// </summary>
        public bool LongProjectsProblemInsert(string proc, string LongProjectsId, string ProblemOne, string Expected, string Number)
        {
            return human.LongProjectsProblemInsert(proc, LongProjectsId, ProblemOne, Expected, Number);

        }
        /// <summary>
        /// 项目立项操作
        /// </summary>
        /// <returns></returns>
        public bool LongProjectsStandUpdate(string proc, string LongProjectsId, string UserCardId)
        {
            return human.LongProjectsStandUpdate(proc, LongProjectsId, UserCardId);
        }
        /// <summary>
        /// 项目删除
        /// </summary>
        public bool LongProjectsDelete(string proc, string LongProjectsId)
        {
            return human.LongProjectsDelete(proc, LongProjectsId);
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        public bool DeleteByFileId(string proc, int FileId)
        {
            return human.DeleteByFileId(proc, FileId);
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        public bool FileInsert(string proc, string LongProjectsId, string FileName, string FileUrl, string FileType)
        {
            return human.FileInsert(proc, LongProjectsId, FileName, FileUrl, FileType);
        }

        #region  获得成果


        /// <summary>
        /// 项目总计添加
        /// </summary>    
        public bool LongProjectsSummaryInsert(string proc, string LongProjectsId, string ProblemOne, string ProblemTwo, string ProblemThree)
        {
            return human.LongProjectsSummaryInsert(proc, LongProjectsId, ProblemOne, ProblemTwo, ProblemThree);
        }
        #endregion
        #region 经费决算
        public bool LongProjectsTotalCapitalInsert(string proc, string LongProjectsId, string ProjectsTotalCapital, double SumCome, double SchoolCome, double OtherCome, double SumExpenditure, double OneExpenditure, double TwoExpenditure, double ThreeExpenditure, double ForeExpenditure, double FiveExpenditure, double SixExpenditure, double SevenExpenditure, double EightExpenditure, double NightExpenditure, double TenExpenditure, double EleventExpenditure, double TwelveExpenditure, double SurplusCapital)
        {
            return human.LongProjectsTotalCapitalInsert(proc, LongProjectsId, ProjectsTotalCapital, SumCome, SchoolCome, OtherCome, SumExpenditure, OneExpenditure, TwoExpenditure, ThreeExpenditure, ForeExpenditure, FiveExpenditure, SixExpenditure, SevenExpenditure, EightExpenditure, NightExpenditure, TenExpenditure, EleventExpenditure, TwelveExpenditure, SurplusCapital);
        }


        public bool LongProjectsBranchCapitalInsert(string proc, string LongProjectsId, string Years, double SumCome, double SchoolCome, double OtherCome, double SumExpenditure, double OneExpenditure, double TwoExpenditure, double ThreeExpenditure, double ForeExpenditure, double FiveExpenditure, double SixExpenditure, double SevenExpenditure, double EightExpenditure, double NightExpenditure, double TenExpenditure, double EleventExpenditure, double TwelveExpenditure, double SurplusCapital)
        {
            return human.LongProjectsBranchCapitalInsert(proc, LongProjectsId, Years, SumCome, SchoolCome, OtherCome, SumExpenditure, OneExpenditure, TwoExpenditure, ThreeExpenditure, ForeExpenditure, FiveExpenditure, SixExpenditure, SevenExpenditure, EightExpenditure, NightExpenditure, TenExpenditure, EleventExpenditure, TwelveExpenditure, SurplusCapital);
        }
        #endregion
        /// <summary>
        /// 按纵向项目编号查询
        /// </summary>
        public DataSet SelectByLongProjectsId(string proc, string LongProjectsId)
        {
            return human.SelectByLongProjectsId(proc, LongProjectsId);

        }
        /// <summary>
        /// 按纵向项目编号,用户工号查询
        /// </summary>
        public DataSet SelectByLongUser(string proc, string LongProjectsId, string UserCardId)
        {
            return human.SelectByLongUser(proc, LongProjectsId, UserCardId);

        }
        /// <summary>
        /// 按纵向项目经费预算编号查询
        /// </summary>
        public DataSet SelectByLongProjectsCapitalPlanId(string proc, int LongProjectsCapitalPlanId)
        {
            return human.SelectByLongProjectsCapitalPlanId(proc, LongProjectsCapitalPlanId);

        }
        /// <summary>
        /// 按纵向项目经费预算编号查询
        /// </summary>
        public DataSet SelectByLongProjectsCapitalPlaceId(string proc, int LongCapitalPlaceId)
        {
            return human.SelectByLongProjectsCapitalPlaceId(proc, LongCapitalPlaceId);

        }
        /// <summary>
        /// 自然科学项目申请经费预算添加
        /// </summary>
        public bool NaturalCapitalInsert(string proc, string LongProjectsId, double OneCapital, double TwoCapital, double ThreeCapital, double ForeCapital, double FiveCapital, double SixCapital, double SevenCapital, double EightCapital, double NightCapital, double TenCapital, double ElevenCapital, double TwelveCapital, string OneExplain, string TwoExplain, string ThreeExplain, string ForeExplain, string FiveExplain, string SixExplain, string SevenExplain, string EightExplain, string NightExplain, string TenExplain, string ElevenExplain, string TwelveExplain, double TotalCapital, double ApplyCapital, double Support)
        {
            return human.NaturalCapitalInsert(proc, LongProjectsId, OneCapital, TwoCapital, ThreeCapital, ForeCapital, FiveCapital, SixCapital, SevenCapital, EightCapital, NightCapital, TenCapital, ElevenCapital, TwelveCapital, OneExplain, TwoExplain, ThreeExplain, ForeExplain, FiveExplain, SixExplain, SevenExplain, EightExplain, NightExplain, TenExplain, ElevenExplain, TwelveExplain, TotalCapital, ApplyCapital, Support);

        }
        /// <summary>
        /// 自然科学项目成员添加
        /// </summary>
        public bool NaturalPartnerInsert(string proc, string LongProjectsId, string OneCompany, string OneJob, string OneName, string OneProfession, string OneWork, string TwoCompany, string TwoJob, string TwoName, string TwoProfession, string TwoWork, string ThreeCompany, string ThreeJob, string ThreeName, string ThreeProfession, string ThreeWork, string ForeCompany, string ForeJob, string ForeName, string ForeProfession, string ForeWork, string FiveCompany, string FiveJob, string FiveName, string FiveProfession, string FiveWork, string SixCompany, string SixJob, string SixName, string SixProfession, string SixWork)
        {
            return human.NaturalPartnerInsert(proc, LongProjectsId, OneCompany, OneJob, OneName, OneProfession, OneWork, TwoCompany, TwoJob, TwoName, TwoProfession, TwoWork, ThreeCompany, ThreeJob, ThreeName, ThreeProfession, ThreeWork, ForeCompany, ForeJob, ForeName, ForeProfession, ForeWork, FiveCompany, FiveJob, FiveName, FiveProfession, FiveWork, SixCompany, SixJob, SixName, SixProfession, SixWork);

        }
        /// <summary>
        /// 纵向项目审批流程添加
        /// </summary>
        public bool LongProjectsProcessInsert(string proc, int ProcessRankId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.LongProjectsProcessInsert(proc, ProcessRankId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 纵向项目审批流程删除
        /// </summary>
        public bool LongProjectsProcessDelete(string proc, int LongProjectsProcessId, string UserCardId)
        {
            return human.LongProjectsProcessDelete(proc, LongProjectsProcessId, UserCardId);

        }
        /// <summary>
        /// 项目申报经费预算添加
        /// </summary>

        public bool LongProjectsCapitalPlanInsert(string proc, string LongProjectsId, string UserCardId, int CapitalItemId, double Money, string Explan)
        {
            return human.LongProjectsCapitalPlanInsert(proc, LongProjectsId, UserCardId, CapitalItemId, Money, Explan);
        }
        /// <summary>
        /// 项目申报经费预算修改
        /// </summary>

        public bool LongProjectsCapitalPlanUpdate(string proc, int LongProjectsCapitalPlanId, string UserCardId, int CapitalItemId, double Money, string Explan)
        {
            return human.LongProjectsCapitalPlanUpdate(proc, LongProjectsCapitalPlanId, UserCardId, CapitalItemId, Money, Explan);
        }
        /// <summary>
        /// 项目申报经费预算删除

        public bool LongProjectsCapitalPlanDelete(string proc, int LongProjectsCapitalPlanId)
        {
            return human.LongProjectsCapitalPlanDelete(proc, LongProjectsCapitalPlanId);
        }



        /// <summary>
        /// 纵向项目审批添加
        /// </summary>
        public bool LongProjectsDeclareExamineInsert(string proc, string LongProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.LongProjectsDeclareExamineInsert(proc, LongProjectsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 纵向项目评审添加
        /// </summary>
        public bool LongProjectsApprovalBranchInsert(string proc, string LongProjectsId, string UserCardId, double Branch)
        {
            return human.LongProjectsApprovalBranchInsert(proc, LongProjectsId, UserCardId, Branch);

        }
        /// <summary>
        /// 纵向项目审批添加
        /// </summary>
        public bool LongProjectsExamineInsert(string proc, string LongProjectsId, string ExamineUserCardId, int RankId, string OneContent, string OneProcess, string OneName, string OneDate, string TwoContent, string TwoProcess, string TwoName, string TwoDate)
        {
            return human.LongProjectsExamineInsert(proc, LongProjectsId, ExamineUserCardId, RankId, OneContent, OneProcess, OneName, OneDate, TwoContent, TwoProcess, TwoName, TwoDate);

        }

        #endregion
        #region 横向项目

        /// <summary>
        /// 项目删除
        /// </summary>
        public bool ShortProjectsDelete(string proc, string ShortProjectsId)
        {
            return human.ShortProjectsDelete(proc, ShortProjectsId);
        }
        /// <summary>
        /// 横向项目立项保存
        /// </summary>
        public bool ShortProjectsApprovalInsert(string proc, string ShortProjectsId, string FileUrl)
        {
            return human.ShortProjectsApprovalInsert(proc, ShortProjectsId, FileUrl);

        }
        /// <summary>
        /// 按横向项目编号查询
        /// </summary>
        public DataSet SelectByShortId(string proc, string ShortId)
        {
            return human.SelectByShortId(proc, ShortId);

        }
        /// <summary>
        /// 横向项目查询
        /// </summary>
        public DataSet SelectsShortProjects(string proc, string UserName, string DepartmentName, string ApplyYear, string ContractId, string ContractName, string Company, double Money1, double Money2, string Stand, string Ends)
        {
            return human.SelectsShortProjects(proc, UserName, DepartmentName, ApplyYear, ContractId, ContractName, Company, Money1, Money2, Stand, Ends);

        }

        /// <summary>
        /// 基础信息添加
        /// </summary>

        public bool ShortProjectsInsert(string proc, string ShortProjectsId, string UserCardId,int DepartmentId, string ContractId, string ContractName, double ContractMoney, string Company, string FileUrl)
        {
            return human.ShortProjectsInsert(proc, ShortProjectsId, UserCardId, DepartmentId, ContractId, ContractName, ContractMoney, Company, FileUrl);
        }
        /// <summary>
        /// 单位信息添加
        /// </summary>

        public bool ShortProjectsCompanyInsert(string proc, string ShortId, string CompanyName, string Address, string Nature, string Nature1, string Nature2, string Nature3, string Nature4, string Nature5)
        {
            return human.ShortProjectsCompanyInsert(proc, ShortId, CompanyName, Address, Nature, Nature1, Nature2, Nature3, Nature4, Nature5);
        }
        /// <summary>
        /// 成员添加
        /// </summary>    
        public bool ShortProjectsDeclarePartnerInsert(string proc, string ShortId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            return human.ShortProjectsDeclarePartnerInsert(proc, ShortId, UserName, UserJob, UserProfession, UserWork, UserCompany);
        }
        /// <summary>
        /// 成员修改
        /// </summary>    
        public bool ShortProjectsDeclarePartnerUpdate(string proc, int ShortProjectsPartnerId, string UserName, string UserJob, string UserProfession, string UserWork, string UserCompany)
        {
            return human.ShortProjectsDeclarePartnerUpdate(proc, ShortProjectsPartnerId, UserName, UserJob, UserProfession, UserWork, UserCompany);
        }
        /// <summary>
        /// 成员删除 
        /// </summary>
        public bool ShortProjectsDeclarePartnerDelete(string proc, int ShortProjectsPartnerId)
        {
            return human.ShortProjectsDeclarePartnerDelete(proc, ShortProjectsPartnerId);
        }
        /// <summary>
        /// 按项目成员编号查询
        /// </summary>
        public DataSet SelectByShortProjectsPartnerId(string proc, int ShortProjectsPartnerId)
        {
            return human.SelectByShortProjectsPartnerId(proc, ShortProjectsPartnerId);

        }
        /// <summary>
        /// 成果添加
        /// </summary>    
        public bool ShortHarvestInsert(string proc, string ShortId, string UserName, string HarvestName, string CateGory, string Remarks)
        {
            return human.ShortHarvestInsert(proc, ShortId, UserName, HarvestName, CateGory, Remarks);
        }
        /// <summary>
        /// 成果修改
        /// </summary>    
        public bool ShortHarvestUpdate(string proc, int ShortHarvestId, string UserName, string HarvestName, string CateGory, string Remarks)
        {
            return human.ShortHarvestUpdate(proc, ShortHarvestId, UserName, HarvestName, CateGory, Remarks);
        }
        /// <summary>
        /// 成果删除 
        /// </summary>
        public bool ShortHarvestDelete(string proc, int ShortHarvestId)
        {
            return human.ShortHarvestDelete(proc, ShortHarvestId);
        }

        /// <summary>
        /// 问题修改 
        /// </summary>
        public bool ShortProjectsEndUpdate(string proc, string ShortId, string ProblemOne, string ProblemTwo)
        {
            return human.ShortProjectsEndUpdate(proc, ShortId, ProblemOne, ProblemTwo);
        }
        /// <summary>
        /// 按项目成果编号查询
        /// </summary>
        public DataSet SelectByShortHarvestId(string proc, int ShortHarvestId)
        {
            return human.SelectByShortHarvestId(proc, ShortHarvestId);

        }
        /// <summary>
        /// 横向项目审批添加
        /// </summary>
        public bool ShortProjectsDeclareExamineInsert(string proc, string ShortProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ShortProjectsDeclareExamineInsert(proc, ShortProjectsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 横向项目审批流程删除
        /// </summary>
        public bool ShortProjectsProcessDelete(string proc, int ShortProjectsProcessId, string UserCardId)
        {
            return human.ShortProjectsProcessDelete(proc, ShortProjectsProcessId, UserCardId);

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
            return human.LongCapitalBasicSituationInsert(proc, LongProjectsId, BidMoney, SupportMoney, OtherMoney, SuedCompany, Servicelife);

        }
        /// <summary>
        /// 纵向经费预算流程删除
        /// </summary>
        public bool LongCapitalPlanProcessDelete(string proc, int LongCapitalPlanProcessId, string UserCardId)
        {
            return human.LongCapitalPlanProcessDelete(proc, LongCapitalPlanProcessId, UserCardId);

        }
        /// <summary>
        /// 纵向经费预算修改流程删除
        /// </summary>
        public bool LongCapitalChangeProcessDelete(string proc, int LongCapitalChangeProcessId, string UserCardId)
        {
            return human.LongCapitalChangeProcessDelete(proc, LongCapitalChangeProcessId, UserCardId);

        }
        /// <summary>
        /// 纵向经费结算流程删除
        /// </summary>
        public bool LongCapitalCloseProcessDelete(string proc, int LongCapitalCloseProcessId, string UserCardId)
        {
            return human.LongCapitalCloseProcessDelete(proc, LongCapitalCloseProcessId, UserCardId);

        }
        /// <summary>
        /// 经费预算删除
        /// </summary>
        public bool LongCapitalPlanDelete(string proc, int LongCapitalPlanId)
        {
            return human.LongCapitalPlanDelete(proc, LongCapitalPlanId);
        }
        /// <summary>
        /// 经费预算添加
        /// </summary>
        public bool LongCapitalPlanInsert(string proc, string LongProjectsId, string UserCardId, string FileUrl)
        {
            return human.LongCapitalPlanInsert(proc, LongProjectsId, UserCardId, FileUrl);
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
            return human.LongCapitalPlanAdjustInsert(proc, LongProjectsId, UserCardId, CapitalDial, CapitalUse,
                SumCapital, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12,
                SumAdjust, Adjust1, Adjust2, Adjust3, Adjust4, Adjust5, Adjust6, Adjust7, Adjust8, Adjust9, Adjust10, Adjust11, Adjust12,
                SumFinal, Final1, Final2, Final3, Final4, Final5, Final6, Final7, Final8, Final9, Final10, Final11, Final12,
               SumExplain, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
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
            return human.LongCapitalPlanAdjustUpdate(proc, LongCapitalPlanAdjustId, CapitalDial, CapitalUse,
                  SumCapital, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12,
                SumAdjust, Adjust1, Adjust2, Adjust3, Adjust4, Adjust5, Adjust6, Adjust7, Adjust8, Adjust9, Adjust10, Adjust11, Adjust12,
                SumFinal, Final1, Final2, Final3, Final4, Final5, Final6, Final7, Final8, Final9, Final10, Final11, Final12,
               SumExplain, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
        }
        /// <summary>
        /// 经费预算审批
        /// </summary>


        public bool LongCapitalPlanExamineInsert(string proc, int LongCapitalPlanId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.LongCapitalPlanExamineInsert(proc, LongCapitalPlanId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);
        }
        /// <summary>
        /// 经费预算修改审批
        /// </summary>


        public bool LongCapitalPlanAdjustExamineInsert(string proc, int LongCapitalPlanAdjustId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.LongCapitalPlanAdjustExamineInsert(proc, LongCapitalPlanAdjustId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);
        }
        /// <summary>
        /// 经费到位信息添加
        /// </summary>


        public bool LongCapitalPlaceInsert(string proc, string LongProjectsId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {
            return human.LongCapitalPlaceInsert(proc, LongProjectsId, PlaceMoney, PlaceDate, PlaceExplain);
        }
        /// <summary>
        /// 经费到位信息修改
        /// </summary>


        public bool LongCapitalPlaceUpdate(string proc, int LongCapitalPlaceId, double PlaceMoney, string PlaceDate, string PlaceExlain)
        {
            return human.LongCapitalPlaceUpdate(proc, LongCapitalPlaceId, PlaceMoney, PlaceDate, PlaceExlain);
        }

        /// <summary>
        /// 经费到位信息删除
        /// </summary>
        public bool LongCapitalPlaceDelete(string proc, int LongCapitalPlaceId)
        {
            return human.LongCapitalPlaceDelete(proc, LongCapitalPlaceId);
        }

        /// <summary>
        /// 按经费到位编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongCapitalPlaceId(string proc, int LongCapitalPlaceId)
        {
            return human.SelectLongCapitalPlaceId(proc, LongCapitalPlaceId);
        }

        /// <summary>
        /// 经费明细添加
        /// </summary>


        public bool LongCapitalDetailedInsert(string proc, string LongProjectsId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {
            return human.LongCapitalDetailedInsert(proc, LongProjectsId, CapitalItemId, CapitalContent, CapitalMoney, CapitalDate);
        }
        /// <summary>
        /// 经费明细修改
        /// </summary>


        public bool LongCapitalDetailedUpdate(string proc, int LongCapitalDetailedId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {
            return human.LongCapitalDetailedUpdate(proc, LongCapitalDetailedId, CapitalItemId, CapitalContent, CapitalMoney, CapitalDate);
        }

        /// <summary>
        /// 经费明细删除
        /// </summary>
        public bool LongCapitalDetailedDelete(string proc, int LongCapitalDetailedId)
        {
            return human.LongCapitalDetailedDelete(proc, LongCapitalDetailedId);
        }














        /// <summary>
        /// 按经费明细编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongCapitalDetailedId(string proc, int LongCapitalDetailedId)
        {
            return human.SelectLongCapitalDetailedId(proc, LongCapitalDetailedId);
        }
        /// <summary>
        /// 按经费使用查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongCapitalDetailed(string proc, string LongProjectsId, int CapitalItemId, string CapitalDate)
        {
            return human.SelectLongCapitalDetailed(proc, LongProjectsId, CapitalItemId, CapitalDate);
        }
        /// <summary>
        /// 经费预算修改
        /// </summary>
        public bool LongCapitalPlanUpdate(string proc, int LongCapitalPlanId, string CapitalCome, double SumCapital, double SumCapitalTwo, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            return human.LongCapitalPlanUpdate(proc, LongCapitalPlanId, CapitalCome, SumCapital, SumCapitalTwo, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
        }
        /// <summary>
        /// 按经费预算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongCapitalPlanId(string proc, int LongCapitalPlanId)
        {
            return human.SelectLongCapitalPlanId(proc, LongCapitalPlanId);
        }

        /// <summary>
        /// 按经费预算变更编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongCapitalPlanAdjustId(string proc, int LongCapitalPlanAdjustId)
        {
            return human.SelectLongCapitalPlanAdjustId(proc, LongCapitalPlanAdjustId);
        }




        /// <summary>
        /// 经费决算添加
        /// </summary>


        public bool LongFinalCapitalInsert(string proc, string UserCardId, string FollDate, string LongProjectsId, string LongProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17,
            string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7, string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17,
            string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8, string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8,
            string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            return human.LongFinalCapitalInsert(proc, UserCardId, FollDate, LongProjectsId, LongProjectsName, Contract, Company, Come1, Place1, Come2, Place2, Come3, Place3, Come4, Place4, Come5, Place5, ComeSum, PlaceSum,
                OneCapital1, OneCapital2, OneCapital3, OneCapital4, OneCapital5, OneCapital6, OneCapital7, OneCapital8, OneCapital9, OneCapital10, OneCapital11, OneCapital12, OneCapital13, OneCapital14, OneCapital15, OneCapital16, OneCapital17
               , TwoCapital1, TwoCapital2, TwoCapital3, TwoCapital4, TwoCapital5, TwoCapital6, TwoCapital7, TwoCapital8, TwoCapital9, TwoCapital10, TwoCapital11, TwoCapital12, TwoCapital13, TwoCapital14, TwoCapital15, TwoCapital16, TwoCapital17
               , ThreeCapital1, ThreeCapital2, ThreeCapital3, ThreeCapital4, ThreeCapital5, ThreeCapital6, ThreeCapital7, ThreeCapital8, ThreeCapital9, ThreeCapital10, ThreeCapital11, ThreeCapital12, ThreeCapital13, ThreeCapital14, ThreeCapital15, ThreeCapital16, ThreeCapital17
               , ForeCapital1, ForeCapital2, ForeCapital3, ForeCapital4, ForeCapital5, ForeCapital6, ForeCapital7, ForeCapital8, ForeCapital9, ForeCapital10, ForeCapital11, ForeCapital12, ForeCapital13, ForeCapital14, ForeCapital15, ForeCapital16, ForeCapital17
               , Equipment1, Equipment2, Equipment3, Equipment4, Equipment5, Equipment6, Equipment7, Equipment8, Company1, Company2, Company3, Company4, Company5, Company6, Company7, Company8
               , Number1, Number2, Number3, Number4, Number5, Number6, Number7, Number8, Price1, Price2, Price3, Price4, Price5, Price6, Price7, Price8, Money1, Money2, Money3, Money4, Money5, Money6, Money7, Money8);
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
            return human.LongFinalCapitalUpdate(proc, LongFinalCapitalId, LongProjectsId, LongProjectsName, Contract, Company, Come1, Place1, Come2, Place2, Come3, Place3, Come4, Place4, Come5, Place5, ComeSum, PlaceSum,
                OneCapital1, OneCapital2, OneCapital3, OneCapital4, OneCapital5, OneCapital6, OneCapital7, OneCapital8, OneCapital9, OneCapital10, OneCapital11, OneCapital12, OneCapital13, OneCapital14, OneCapital15, OneCapital16, OneCapital17
               , TwoCapital1, TwoCapital2, TwoCapital3, TwoCapital4, TwoCapital5, TwoCapital6, TwoCapital7, TwoCapital8, TwoCapital9, TwoCapital10, TwoCapital11, TwoCapital12, TwoCapital13, TwoCapital14, TwoCapital15, TwoCapital16, TwoCapital17
               , ThreeCapital1, ThreeCapital2, ThreeCapital3, ThreeCapital4, ThreeCapital5, ThreeCapital6, ThreeCapital7, ThreeCapital8, ThreeCapital9, ThreeCapital10, ThreeCapital11, ThreeCapital12, ThreeCapital13, ThreeCapital14, ThreeCapital15, ThreeCapital16, ThreeCapital17
               , ForeCapital1, ForeCapital2, ForeCapital3, ForeCapital4, ForeCapital5, ForeCapital6, ForeCapital7, ForeCapital8, ForeCapital9, ForeCapital10, ForeCapital11, ForeCapital12, ForeCapital13, ForeCapital14, ForeCapital15, ForeCapital16, ForeCapital17
               , Equipment1, Equipment2, Equipment3, Equipment4, Equipment5, Equipment6, Equipment7, Equipment8, Company1, Company2, Company3, Company4, Company5, Company6, Company7, Company8
               , Number1, Number2, Number3, Number4, Number5, Number6, Number7, Number8, Price1, Price2, Price3, Price4, Price5, Price6, Price7, Price8, Money1, Money2, Money3, Money4, Money5, Money6, Money7, Money8);
        }

        /// <summary>
        /// 经费决算删除
        /// </summary>
        public bool LongFinalCapitalDelete(string proc, int LongFinalCapitalId, string UserCardId)
        {
            return human.LongFinalCapitalDelete(proc, LongFinalCapitalId, UserCardId);
        }



        /// <summary>
        /// 按经费决算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectLongFinalCapitalId(string proc, int LongFinalCapitalId)
        {
            return human.SelectLongFinalCapitalId(proc, LongFinalCapitalId);
        }

        /// <summary>
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsLongCapital(string proc, string ProjectsId, string ProjectsName, string Company, double Money1, double Money2)
        {
            return human.SelectsLongCapital(proc, ProjectsId, ProjectsName, Company, Money1, Money2);
        }
        /// <summary>
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsLongCapitalPlan(string proc, string UserName, string DepartmentName, string ProjectsName, string ProjectsId, string Status)
        {
            return human.SelectsLongCapitalPlan(proc, UserName, DepartmentName, ProjectsName, ProjectsId, Status);
        }





        #endregion
        #region 横向
        /// <summary>
        /// 横向经费基本情况保存
        /// </summary>

        public bool ShortCapitalBasicSituationInsert(string proc, string ShortProjectsId, double BidMoney, double SupportMoney, double OtherMoney, string SuedCompany, string Servicelife)
        {
            return human.ShortCapitalBasicSituationInsert(proc, ShortProjectsId, BidMoney, SupportMoney, OtherMoney, SuedCompany, Servicelife);

        }
        /// <summary>
        /// 按横向项目编号查询
        /// </summary>
        public DataSet SelectByShortProjectsId(string proc, string ShortProjectsId)
        {
            return human.SelectByShortProjectsId(proc, ShortProjectsId);

        }
        /// <summary>
        /// 横向经费预算流程删除
        /// </summary>
        public bool ShortCapitalPlanProcessDelete(string proc, int ShortCapitalPlanProcessId, string UserCardId)
        {
            return human.ShortCapitalPlanProcessDelete(proc, ShortCapitalPlanProcessId, UserCardId);

        }
        /// <summary>
        /// 横向经费预算流程删除
        /// </summary>
        public bool ShortCapitalCloseProcessDelete(string proc, int ShortCapitalCloseProcessId, string UserCardId)
        {
            return human.ShortCapitalCloseProcessDelete(proc, ShortCapitalCloseProcessId, UserCardId);

        }
        /// <summary>
        /// 横向经费预算流程删除
        /// </summary>
        public bool ShortCapitalChangeProcessDelete(string proc, int ShortCapitalChangeProcessId, string UserCardId)
        {
            return human.ShortCapitalChangeProcessDelete(proc, ShortCapitalChangeProcessId, UserCardId);

        }
        /// <summary>
        /// 经费预算删除
        /// </summary>
        public bool ShortCapitalPlanDelete(string proc, int ShortCapitalPlanId)
        {
            return human.ShortCapitalPlanDelete(proc, ShortCapitalPlanId);
        }
        /// <summary>
        /// 经费预算添加
        /// </summary>
        public bool ShortCapitalPlanInsert(string proc, string ShortProjectsId, string UserCardId, string FileUrl)
        {
            return human.ShortCapitalPlanInsert(proc, ShortProjectsId, UserCardId, FileUrl);
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
            return human.ShortCapitalPlanAdjustInsert(proc, ShortProjectsId, UserCardId, CapitalDial, CapitalUse,
                SumCapital, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12,
                SumAdjust, Adjust1, Adjust2, Adjust3, Adjust4, Adjust5, Adjust6, Adjust7, Adjust8, Adjust9, Adjust10, Adjust11, Adjust12,
                SumFinal, Final1, Final2, Final3, Final4, Final5, Final6, Final7, Final8, Final9, Final10, Final11, Final12,
               SumExplain, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
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
            return human.ShortCapitalPlanAdjustUpdate(proc, ShortCapitalPlanAdjustId, CapitalDial, CapitalUse,
                  SumCapital, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12,
                SumAdjust, Adjust1, Adjust2, Adjust3, Adjust4, Adjust5, Adjust6, Adjust7, Adjust8, Adjust9, Adjust10, Adjust11, Adjust12,
                SumFinal, Final1, Final2, Final3, Final4, Final5, Final6, Final7, Final8, Final9, Final10, Final11, Final12,
               SumExplain, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
        }
        /// <summary>
        /// 经费预算审批
        /// </summary>


        public bool ShortCapitalPlanExamineInsert(string proc, int ShortCapitalPlanId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ShortCapitalPlanExamineInsert(proc, ShortCapitalPlanId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);
        }
        /// <summary>
        /// 经费预算修改审批
        /// </summary>


        public bool ShortCapitalPlanAdjustExamineInsert(string proc, int ShortCapitalPlanAdjustId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ShortCapitalPlanAdjustExamineInsert(proc, ShortCapitalPlanAdjustId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);
        }
        /// <summary>
        /// 经费到位信息添加
        /// </summary>


        public bool ShortCapitalPlaceInsert(string proc, string ShortProjectsId, double PlaceMoney, string PlaceDate, string PlaceExplain)
        {
            return human.ShortCapitalPlaceInsert(proc, ShortProjectsId, PlaceMoney, PlaceDate, PlaceExplain);
        }
        /// <summary>
        /// 经费到位信息修改
        /// </summary>


        public bool ShortCapitalPlaceUpdate(string proc, int ShortCapitalPlaceId, double PlaceMoney, string PlaceDate, string PlaceExlain)
        {
            return human.ShortCapitalPlaceUpdate(proc, ShortCapitalPlaceId, PlaceMoney, PlaceDate, PlaceExlain);
        }

        /// <summary>
        /// 经费到位信息删除
        /// </summary>
        public bool ShortCapitalPlaceDelete(string proc, int ShortCapitalPlaceId)
        {
            return human.ShortCapitalPlaceDelete(proc, ShortCapitalPlaceId);
        }

        /// <summary>
        /// 按经费到位编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortCapitalPlaceId(string proc, int ShortCapitalPlaceId)
        {
            return human.SelectShortCapitalPlaceId(proc, ShortCapitalPlaceId);
        }

        /// <summary>
        /// 经费明细添加
        /// </summary>


        public bool ShortCapitalDetailedInsert(string proc, string ShortProjectsId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {
            return human.ShortCapitalDetailedInsert(proc, ShortProjectsId, CapitalItemId, CapitalContent, CapitalMoney, CapitalDate);
        }
        /// <summary>
        /// 经费明细修改
        /// </summary>


        public bool ShortCapitalDetailedUpdate(string proc, int ShortCapitalDetailedId, int CapitalItemId, string CapitalContent, double CapitalMoney, string CapitalDate)
        {
            return human.ShortCapitalDetailedUpdate(proc, ShortCapitalDetailedId, CapitalItemId, CapitalContent, CapitalMoney, CapitalDate);
        }

        /// <summary>
        /// 按经费综合查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectsShortCapital(string proc, string ContractId, string ContractName, string Company, double Money1, double Money2)
        {
            return human.SelectsShortCapital(proc, ContractId, ContractName, Company, Money1, Money2);
        }
        /// <summary>
        /// 经费明细删除
        /// </summary>
        public bool ShortCapitalDetailedDelete(string proc, int ShortCapitalDetailedId)
        {
            return human.ShortCapitalDetailedDelete(proc, ShortCapitalDetailedId);
        }

        /// <summary>
        /// 按经费明细编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortCapitalDetailedId(string proc, int ShortCapitalDetailedId)
        {
            return human.SelectShortCapitalDetailedId(proc, ShortCapitalDetailedId);
        }
        /// <summary>
        /// 按经费使用查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortCapitalDetailed(string proc, string ShortProjectsId, int CapitalItemId, string CapitalDate)
        {
            return human.SelectShortCapitalDetailed(proc, ShortProjectsId, CapitalItemId, CapitalDate);
        }
        /// <summary>
        /// 经费预算修改
        /// </summary>
        public bool ShortCapitalPlanUpdate(string proc, int ShortCapitalPlanId, string CapitalCome, double SumCapital, double SumCapitalTwo, double Capital1, double Capital2, double Capital3, double Capital4, double Capital5, double Capital6, double Capital7, double Capital8, double Capital9, double Capital10, double Capital11, double Capital12, string Explain1, string Explain2, string Explain3, string Explain4, string Explain5, string Explain6, string Explain7, string Explain8, string Explain9, string Explain10, string Explain11, string Explain12)
        {
            return human.ShortCapitalPlanUpdate(proc, ShortCapitalPlanId, CapitalCome, SumCapital, SumCapitalTwo, Capital1, Capital2, Capital3, Capital4, Capital5, Capital6, Capital7, Capital8, Capital9, Capital10, Capital11, Capital12, Explain1, Explain2, Explain3, Explain4, Explain5, Explain6, Explain7, Explain8, Explain9, Explain10, Explain11, Explain12);
        }
        /// <summary>
        /// 按经费预算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortCapitalPlanId(string proc, int ShortCapitalPlanId)
        {
            return human.SelectShortCapitalPlanId(proc, ShortCapitalPlanId);
        }

        /// <summary>
        /// 按经费预算变更编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortCapitalPlanAdjustId(string proc, int ShortCapitalPlanAdjustId)
        {
            return human.SelectShortCapitalPlanAdjustId(proc, ShortCapitalPlanAdjustId);
        }

        /// <summary>
        /// 经费决算添加
        /// </summary>


        public bool ShortFinalCapitalInsert(string proc, string UserCardId, string FollDate, string ShortProjectsId, string ShortProjectsName, string Contract, string Company, string Come1, string Place1, string Come2, string Place2, string Come3, string Place3, string Come4, string Place4, string Come5, string Place5, string ComeSum, string PlaceSum,
            string OneCapital1, string OneCapital2, string OneCapital3, string OneCapital4, string OneCapital5, string OneCapital6, string OneCapital7, string OneCapital8, string OneCapital9, string OneCapital10, string OneCapital11, string OneCapital12, string OneCapital13, string OneCapital14, string OneCapital15, string OneCapital16, string OneCapital17,
            string TwoCapital1, string TwoCapital2, string TwoCapital3, string TwoCapital4, string TwoCapital5, string TwoCapital6, string TwoCapital7, string TwoCapital8, string TwoCapital9, string TwoCapital10, string TwoCapital11, string TwoCapital12, string TwoCapital13, string TwoCapital14, string TwoCapital15, string TwoCapital16, string TwoCapital17,
            string ThreeCapital1, string ThreeCapital2, string ThreeCapital3, string ThreeCapital4, string ThreeCapital5, string ThreeCapital6, string ThreeCapital7, string ThreeCapital8, string ThreeCapital9, string ThreeCapital10, string ThreeCapital11, string ThreeCapital12, string ThreeCapital13, string ThreeCapital14, string ThreeCapital15, string ThreeCapital16, string ThreeCapital17,
            string ForeCapital1, string ForeCapital2, string ForeCapital3, string ForeCapital4, string ForeCapital5, string ForeCapital6, string ForeCapital7, string ForeCapital8, string ForeCapital9, string ForeCapital10, string ForeCapital11, string ForeCapital12, string ForeCapital13, string ForeCapital14, string ForeCapital15, string ForeCapital16, string ForeCapital17,
            string Equipment1, string Equipment2, string Equipment3, string Equipment4, string Equipment5, string Equipment6, string Equipment7, string Equipment8, string Company1, string Company2, string Company3, string Company4, string Company5, string Company6, string Company7, string Company8, string Number1, string Number2, string Number3, string Number4, string Number5, string Number6, string Number7, string Number8,
            string Price1, string Price2, string Price3, string Price4, string Price5, string Price6, string Price7, string Price8, string Money1, string Money2, string Money3, string Money4, string Money5, string Money6, string Money7, string Money8)
        {
            return human.ShortFinalCapitalInsert(proc, UserCardId, FollDate, ShortProjectsId, ShortProjectsName, Contract, Company, Come1, Place1, Come2, Place2, Come3, Place3, Come4, Place4, Come5, Place5, ComeSum, PlaceSum,
                OneCapital1, OneCapital2, OneCapital3, OneCapital4, OneCapital5, OneCapital6, OneCapital7, OneCapital8, OneCapital9, OneCapital10, OneCapital11, OneCapital12, OneCapital13, OneCapital14, OneCapital15, OneCapital16, OneCapital17
               , TwoCapital1, TwoCapital2, TwoCapital3, TwoCapital4, TwoCapital5, TwoCapital6, TwoCapital7, TwoCapital8, TwoCapital9, TwoCapital10, TwoCapital11, TwoCapital12, TwoCapital13, TwoCapital14, TwoCapital15, TwoCapital16, TwoCapital17
               , ThreeCapital1, ThreeCapital2, ThreeCapital3, ThreeCapital4, ThreeCapital5, ThreeCapital6, ThreeCapital7, ThreeCapital8, ThreeCapital9, ThreeCapital10, ThreeCapital11, ThreeCapital12, ThreeCapital13, ThreeCapital14, ThreeCapital15, ThreeCapital16, ThreeCapital17
               , ForeCapital1, ForeCapital2, ForeCapital3, ForeCapital4, ForeCapital5, ForeCapital6, ForeCapital7, ForeCapital8, ForeCapital9, ForeCapital10, ForeCapital11, ForeCapital12, ForeCapital13, ForeCapital14, ForeCapital15, ForeCapital16, ForeCapital17
               , Equipment1, Equipment2, Equipment3, Equipment4, Equipment5, Equipment6, Equipment7, Equipment8, Company1, Company2, Company3, Company4, Company5, Company6, Company7, Company8
               , Number1, Number2, Number3, Number4, Number5, Number6, Number7, Number8, Price1, Price2, Price3, Price4, Price5, Price6, Price7, Price8, Money1, Money2, Money3, Money4, Money5, Money6, Money7, Money8);
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
            return human.ShortFinalCapitalUpdate(proc, ShortFinalCapitalId, ShortProjectsId, ShortProjectsName, Contract, Company, Come1, Place1, Come2, Place2, Come3, Place3, Come4, Place4, Come5, Place5, ComeSum, PlaceSum,
                OneCapital1, OneCapital2, OneCapital3, OneCapital4, OneCapital5, OneCapital6, OneCapital7, OneCapital8, OneCapital9, OneCapital10, OneCapital11, OneCapital12, OneCapital13, OneCapital14, OneCapital15, OneCapital16, OneCapital17
               , TwoCapital1, TwoCapital2, TwoCapital3, TwoCapital4, TwoCapital5, TwoCapital6, TwoCapital7, TwoCapital8, TwoCapital9, TwoCapital10, TwoCapital11, TwoCapital12, TwoCapital13, TwoCapital14, TwoCapital15, TwoCapital16, TwoCapital17
               , ThreeCapital1, ThreeCapital2, ThreeCapital3, ThreeCapital4, ThreeCapital5, ThreeCapital6, ThreeCapital7, ThreeCapital8, ThreeCapital9, ThreeCapital10, ThreeCapital11, ThreeCapital12, ThreeCapital13, ThreeCapital14, ThreeCapital15, ThreeCapital16, ThreeCapital17
               , ForeCapital1, ForeCapital2, ForeCapital3, ForeCapital4, ForeCapital5, ForeCapital6, ForeCapital7, ForeCapital8, ForeCapital9, ForeCapital10, ForeCapital11, ForeCapital12, ForeCapital13, ForeCapital14, ForeCapital15, ForeCapital16, ForeCapital17
               , Equipment1, Equipment2, Equipment3, Equipment4, Equipment5, Equipment6, Equipment7, Equipment8, Company1, Company2, Company3, Company4, Company5, Company6, Company7, Company8
               , Number1, Number2, Number3, Number4, Number5, Number6, Number7, Number8, Price1, Price2, Price3, Price4, Price5, Price6, Price7, Price8, Money1, Money2, Money3, Money4, Money5, Money6, Money7, Money8);
        }

        /// <summary>
        /// 经费决算删除
        /// </summary>
        public bool ShortFinalCapitalDelete(string proc, int ShortFinalCapitalId, string UserCardId)
        {
            return human.ShortFinalCapitalDelete(proc, ShortFinalCapitalId, UserCardId);
        }



        /// <summary>
        /// 按经费决算编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectShortFinalCapitalId(string proc, int ShortFinalCapitalId)
        {
            return human.SelectShortFinalCapitalId(proc, ShortFinalCapitalId);
        }
        #endregion
        #endregion
        #region 教科研工作管理
        #region 教材建设
        /// <summary>
        /// 教材建设申请
        /// </summary>
        public bool T_TeachingInsert(string proc, string UserCardId,int DepartmentId, string T_TeachingName, string Category, string Press, string Time, string Edition, string Compiledwords, string EditorRanking, string Score, string Reference, string Totalscore, string T_TeachingUrl, double PartnerValue, string Remarks)
        {
            return human.T_TeachingInsert(proc, UserCardId, DepartmentId, T_TeachingName, Category, Press, Time, Edition, Compiledwords, EditorRanking, Score, Reference, Totalscore, T_TeachingUrl, PartnerValue, Remarks);

        }
        /// <summary>
        /// 教材建设单个查询
        /// </summary>
        public DataSet SelectByT_TeachingId(string proc, int T_TeachingId)
        {
            return human.SelectByT_TeachingId(proc, T_TeachingId);

        }
        /// <summary>
        /// 教材建设查询
        /// </summary>
        public DataSet SelectT_Teaching(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectT_Teaching(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人教材建设查询
        /// </summary>
        public DataSet SelectT_TeachingByUserCardId(string proc, string UserCardId)
        {
            return human.SelectT_TeachingByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 教材建设可审批查询
        /// </summary>
        public DataSet T_TeachingExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.T_TeachingExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 教材建设修改
        /// </summary>
        public bool T_TeachingUpdate(string proc, int T_TeachingId, int DepartmentId, string T_TeachingName, string Category, string Press, string Time, string Edition, string Compiledwords, string EditorRanking, string Score, string Reference, string Totalscore, string T_TeachingUrl, double PartnerValue, string Remarks)
        {
            return human.T_TeachingUpdate(proc, T_TeachingId, DepartmentId, T_TeachingName, Category, Press, Time, Edition, Compiledwords, EditorRanking, Score, Reference, Totalscore, T_TeachingUrl, PartnerValue, Remarks);

        }


        /// <summary>
        /// 教材建设删除
        /// </summary>
        public bool T_TeachingDelete(string proc, int T_TeachingId)
        {
            return human.T_TeachingDelete(proc, T_TeachingId);

        }

        /// <summary>
        /// 教材建设审批添加
        /// </summary>
        public bool T_TeachingExamineInsert(string proc, int T_TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.T_TeachingExamineInsert(proc, T_TeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 教材建设审批查询
        /// </summary>
        public DataSet SelectT_TeachingExamine(string proc, int T_TeachingId)
        {
            return human.SelectT_TeachingExamine(proc, T_TeachingId);

        }
        /// <summary>
        /// 教材建设审批流程添加
        /// </summary>
        public bool T_TeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.T_TeachingProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 教材建设审批流程删除
        /// </summary>
        public bool T_TeachingProcessDelete(string proc, int T_TeachingProcessId, string UserCardId)
        {
            return human.T_TeachingProcessDelete(proc, T_TeachingProcessId, UserCardId);

        }
        /// <summary>
        /// 教材建设记录查询
        /// </summary>
        public DataSet SelectsT_Teaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string T_TeachingName, string Category, string T_TeachingYear)
        {
            return human.SelectsT_Teaching(proc, UserName, DepartmentId, Year, Month, Status, T_TeachingName, Category, T_TeachingYear);

        }
        #endregion
        #region 教学团队建设
        /// <summary>
        /// 教学团队建设申请
        /// </summary>
        public bool Teaching_TeamInsert(string proc, string UserCardId,int DepartmentId, string Teaching_TeamName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string Teaching_TeamUrl, double Teaching_TeamValue, string Remarks)
        {
            return human.Teaching_TeamInsert(proc, UserCardId, DepartmentId, Teaching_TeamName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, Teaching_TeamUrl, Teaching_TeamValue, Remarks);

        }
        /// <summary>
        /// 教学团队建设合作者单个查询
        /// </summary>
        public DataSet SelectByTeaching_TeamPartnerId(string proc, int Teaching_TeamPartnerId)
        {
            return human.SelectByTeaching_TeamPartnerId(proc, Teaching_TeamPartnerId);

        }
        /// <summary>
        /// 教学团队建设合作者添加
        /// </summary>
        public bool Teaching_TeamPartnerInsert(string proc, int Teaching_TeamId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.Teaching_TeamPartnerInsert(proc, Teaching_TeamId, UserCardId, PartnerRank, PartnerValue);

        }
        /// 合作者信息修改
        /// </summary>
        public bool Teaching_TeamPartnerUpdate(string proc, int Teaching_TeamPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.Teaching_TeamPartnerUpdate(proc, Teaching_TeamPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 教学团队建设合作者删除
        /// </summary>
        public bool Teaching_TeamPartnerDelete(string proc, int Teaching_TeamPartnerId)
        {
            return human.Teaching_TeamPartnerDelete(proc, Teaching_TeamPartnerId);

        }
        /// <summary>
        /// 教学团队建设单个查询
        /// </summary>
        public DataSet SelectByTeaching_TeamId(string proc, int Teaching_TeamId)
        {
            return human.SelectByTeaching_TeamId(proc, Teaching_TeamId);

        }
        /// <summary>
        /// 教学团队建设查询
        /// </summary>
        public DataSet SelectTeaching_Team(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectTeaching_Team(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人教学团队建设查询
        /// </summary>
        public DataSet SelectTeaching_TeamByUserCardId(string proc, string UserCardId)
        {
            return human.SelectTeaching_TeamByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 教学团队建设可审批查询
        /// </summary>
        public DataSet Teaching_TeamExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.Teaching_TeamExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 教学团队建设修改
        /// </summary>
        public bool Teaching_TeamUpdate(string proc, int Teaching_TeamId, int DepartmentId, string Teaching_TeamName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string Teaching_TeamUrl, double Teaching_TeamValue, string Remarks)
        {
            return human.Teaching_TeamUpdate(proc, Teaching_TeamId, DepartmentId, Teaching_TeamName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, Teaching_TeamUrl, Teaching_TeamValue, Remarks);

        }


        /// <summary>
        /// 教学团队建设删除
        /// </summary>
        public bool Teaching_TeamDelete(string proc, int Teaching_TeamId)
        {
            return human.Teaching_TeamDelete(proc, Teaching_TeamId);

        }

        /// <summary>
        /// 教学团队建设审批添加
        /// </summary>
        public bool Teaching_TeamExamineInsert(string proc, int Teaching_TeamId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.Teaching_TeamExamineInsert(proc, Teaching_TeamId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 教学团队建设审批查询
        /// </summary>
        public DataSet SelectTeaching_TeamExamine(string proc, int Teaching_TeamId)
        {
            return human.SelectTeaching_TeamExamine(proc, Teaching_TeamId);

        }
        /// <summary>
        /// 教学团队建设审批流程添加
        /// </summary>
        public bool Teaching_TeamProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.Teaching_TeamProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 教学团队建设审批流程删除
        /// </summary>
        public bool Teaching_TeamProcessDelete(string proc, int Teaching_TeamProcessId, string UserCardId)
        {
            return human.Teaching_TeamProcessDelete(proc, Teaching_TeamProcessId, UserCardId);

        }
        /// <summary>
        /// 教学团队建设记录查询
        /// </summary>
        public DataSet SelectsTeaching_Team(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string Teaching_TeamName, string Leve, string Teaching_TeamYear)
        {
            return human.SelectsTeaching_Team(proc, UserName, DepartmentId, Year, Month, Status, Teaching_TeamName, Leve, Teaching_TeamYear);

        }
        #endregion
        #region 专业建设
        /// <summary>
        /// 专业建设申请
        /// </summary>
        public bool P_constructionInsert(string proc, string UserCardId,int DepartmentId, string P_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string P_constructionUrl, double P_constructionValue, string Remarks)
        {
            return human.P_constructionInsert(proc, UserCardId, DepartmentId, P_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, P_constructionUrl, P_constructionValue, Remarks);

        }

        /// <summary>
        /// 专业建设合作者单个查询
        /// </summary>
        public DataSet SelectByP_constructionPartnerId(string proc, int P_constructionPartnerId)
        {
            return human.SelectByP_constructionPartnerId(proc, P_constructionPartnerId);

        }
        /// <summary>
        /// 专业建设合作者添加
        /// </summary>
        public bool P_constructionPartnerInsert(string proc, int P_constructionId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.P_constructionPartnerInsert(proc, P_constructionId, UserCardId, PartnerRank, PartnerValue);

        }
        /// 合作者信息修改
        /// </summary>
        public bool P_constructionPartnerUpdate(string proc, int P_constructionPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.P_constructionPartnerUpdate(proc, P_constructionPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 专业建设合作者删除
        /// </summary>
        public bool P_constructionPartnerDelete(string proc, int P_constructionPartnerId)
        {
            return human.P_constructionPartnerDelete(proc, P_constructionPartnerId);

        }
        /// <summary>
        /// 专业建设单个查询
        /// </summary>
        public DataSet SelectByP_constructionId(string proc, int P_constructionId)
        {
            return human.SelectByP_constructionId(proc, P_constructionId);

        }
        /// <summary>
        /// 专业建设查询
        /// </summary>
        public DataSet SelectP_construction(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectP_construction(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人专业建设查询
        /// </summary>
        public DataSet SelectP_constructionByUserCardId(string proc, string UserCardId)
        {
            return human.SelectP_constructionByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 专业建设可审批查询
        /// </summary>
        public DataSet P_constructionExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.P_constructionExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 专业建设修改
        /// </summary>
        public bool P_constructionUpdate(string proc, int P_constructionId,int DepartmentId, string P_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string P_constructionUrl, double P_constructionValue, string Remarks)
        {
            return human.P_constructionUpdate(proc, P_constructionId, DepartmentId, P_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, P_constructionUrl, P_constructionValue, Remarks);

        }


        /// <summary>
        /// 专业建设删除
        /// </summary>
        public bool P_constructionDelete(string proc, int P_constructionId)
        {
            return human.P_constructionDelete(proc, P_constructionId);

        }

        /// <summary>
        /// 专业建设审批添加
        /// </summary>
        public bool P_constructionExamineInsert(string proc, int P_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.P_constructionExamineInsert(proc, P_constructionId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 专业建设审批查询
        /// </summary>
        public DataSet SelectP_constructionExamine(string proc, int P_constructionId)
        {
            return human.SelectP_constructionExamine(proc, P_constructionId);

        }
        /// <summary>
        /// 专业建设审批流程添加
        /// </summary>
        public bool P_constructionProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.P_constructionProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 专业建设审批流程删除
        /// </summary>
        public bool P_constructionProcessDelete(string proc, int P_constructionProcessId, string UserCardId)
        {
            return human.P_constructionProcessDelete(proc, P_constructionProcessId, UserCardId);

        }
        /// <summary>
        /// 专业建设记录查询
        /// </summary>
        public DataSet SelectsP_construction(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string P_constructionName, string Leve, string P_constructionYear)
        {
            return human.SelectsP_construction(proc, UserName, DepartmentId, Year, Month, Status, P_constructionName, Leve, P_constructionYear);

        }
        #endregion
        #region 课程建设
        /// <summary>
        /// 课程建设申请
        /// </summary>
        public bool C_constructionInsert(string proc, string UserCardId,int DepartmentId, string C_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string C_constructionUrl, double C_constructionValue, string Remarks)
        {
            return human.C_constructionInsert(proc, UserCardId, DepartmentId, C_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, C_constructionUrl, C_constructionValue, Remarks);

        }
        /// <summary>
        /// 课程建设合作者单个查询
        /// </summary>
        public DataSet SelectByC_constructionPartnerId(string proc, int C_constructionPartnerId)
        {
            return human.SelectByC_constructionPartnerId(proc, C_constructionPartnerId);

        }
        /// <summary>
        /// 课程建设合作者添加
        /// </summary>
        public bool C_constructionPartnerInsert(string proc, int C_constructionId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.C_constructionPartnerInsert(proc, C_constructionId, UserCardId, PartnerRank, PartnerValue);

        }
        /// 合作者信息修改
        /// </summary>
        public bool C_constructionPartnerUpdate(string proc, int C_constructionPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.C_constructionPartnerUpdate(proc, C_constructionPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 课程建设合作者删除
        /// </summary>
        public bool C_constructionPartnerDelete(string proc, int C_constructionPartnerId)
        {
            return human.C_constructionPartnerDelete(proc, C_constructionPartnerId);

        }
        /// <summary>
        /// 课程建设单个查询
        /// </summary>
        public DataSet SelectByC_constructionId(string proc, int C_constructionId)
        {
            return human.SelectByC_constructionId(proc, C_constructionId);

        }
        /// <summary>
        /// 课程建设查询
        /// </summary>
        public DataSet SelectC_construction(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectC_construction(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人课程建设查询
        /// </summary>
        public DataSet SelectC_constructionByUserCardId(string proc, string UserCardId)
        {
            return human.SelectC_constructionByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 课程建设可审批查询
        /// </summary>
        public DataSet C_constructionExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.C_constructionExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 课程建设修改
        /// </summary>
        public bool C_constructionUpdate(string proc, int C_constructionId,int DepartmentId, string C_constructionName, string Leve, string Principal, string Completion, string StartEndDate, double Total_Project, string Description_Project, double Annual, string Description_year, string C_constructionUrl, double C_constructionValue, string Remarks)
        {
            return human.C_constructionUpdate(proc, C_constructionId, DepartmentId, C_constructionName, Leve, Principal, Completion, StartEndDate, Total_Project, Description_Project, Annual, Description_year, C_constructionUrl, C_constructionValue, Remarks);

        }


        /// <summary>
        /// 课程建设删除
        /// </summary>
        public bool C_constructionDelete(string proc, int C_constructionId)
        {
            return human.C_constructionDelete(proc, C_constructionId);

        }

        /// <summary>
        /// 课程建设审批添加
        /// </summary>
        public bool C_constructionExamineInsert(string proc, int C_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.C_constructionExamineInsert(proc, C_constructionId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 课程建设审批查询
        /// </summary>
        public DataSet SelectC_constructionExamine(string proc, int C_constructionId)
        {
            return human.SelectC_constructionExamine(proc, C_constructionId);

        }
        /// <summary>
        /// 课程建设审批流程添加
        /// </summary>
        public bool C_constructionProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.C_constructionProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 课程建设审批流程删除
        /// </summary>
        public bool C_constructionProcessDelete(string proc, int C_constructionProcessId, string UserCardId)
        {
            return human.C_constructionProcessDelete(proc, C_constructionProcessId, UserCardId);

        }
        /// <summary>
        /// 课程建设记录查询
        /// </summary>
        public DataSet SelectsC_construction(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string C_constructionName, string Leve, string C_constructionYear)
        {
            return human.SelectsC_construction(proc, UserName, DepartmentId, Year, Month, Status, C_constructionName, Leve, C_constructionYear);

        }
        #endregion
        #region 竞赛获奖
        /// <summary>
        /// 竞赛获奖申请
        /// </summary>
        public bool C_winnersInsert(string proc, string UserCardId,int DepartmentId, string C_winnersName, string Leve, string Time, string Award_level, string Organizational_Unit, double C_winnersTotal, string C_winnersDescription, string Ranking, string C_winnersUrl, double C_winnersValue, string Remarks)
        {
            return human.C_winnersInsert(proc, UserCardId, DepartmentId, C_winnersName, Leve, Time, Award_level, Organizational_Unit, C_winnersTotal, C_winnersDescription, Ranking, C_winnersUrl, C_winnersValue, Remarks);

        }
        /// <summary>
        /// 竞赛获奖合作者单个查询
        /// </summary>
        public DataSet SelectByC_winnersPartnerId(string proc, int C_winnersPartnerId)
        {
            return human.SelectByC_winnersPartnerId(proc, C_winnersPartnerId);
        }
        /// <summary>
        /// 竞赛获奖合作者添加
        /// </summary>
        public bool C_winnersPartnerInsert(string proc, int C_winnersId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.C_winnersPartnerInsert(proc, C_winnersId, UserCardId, PartnerRank, PartnerValue);
        }
        /// 合作者信息修改
        /// </summary>
        public bool C_winnersPartnerUpdate(string proc, int C_winnersPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.C_winnersPartnerUpdate(proc, C_winnersPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 竞赛获奖合作者删除
        /// </summary>
        public bool C_winnersPartnerDelete(string proc, int C_winnersPartnerId)
        {
            return human.C_winnersPartnerDelete(proc, C_winnersPartnerId);

        }
        /// <summary>
        /// 竞赛获奖单个查询
        /// </summary>
        public DataSet SelectByC_winnersId(string proc, int C_winnersId)
        {
            return human.SelectByC_winnersId(proc, C_winnersId);

        }
        /// <summary>
        /// 竞赛获奖查询
        /// </summary>
        public DataSet SelectC_winners(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectC_winners(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人竞赛获奖查询
        /// </summary>
        public DataSet SelectC_winnersByUserCardId(string proc, string UserCardId)
        {
            return human.SelectC_winnersByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 竞赛获奖可审批查询
        /// </summary>
        public DataSet C_winnersExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.C_winnersExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 竞赛获奖修改
        /// </summary>
        public bool C_winnersUpdate(string proc, int C_winnersId,int DepartmentId, string C_winnersName, string Leve, string Time, string Award_level, string Organizational_Unit, double C_winnersTotal, string C_winnersDescription, string Ranking, string C_winnersUrl, double C_winnersValue, string Remarks)
        {
            return human.C_winnersUpdate(proc, C_winnersId, DepartmentId, C_winnersName, Leve, Time, Award_level, Organizational_Unit, C_winnersTotal, C_winnersDescription, Ranking, C_winnersUrl, C_winnersValue, Remarks);

        }


        /// <summary>
        /// 竞赛获奖删除
        /// </summary>
        public bool C_winnersDelete(string proc, int C_winnersId)
        {
            return human.C_winnersDelete(proc, C_winnersId);

        }

        /// <summary>
        /// 竞赛获奖审批添加
        /// </summary>
        public bool C_winnersExamineInsert(string proc, int C_winnersId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.C_winnersExamineInsert(proc, C_winnersId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 竞赛获奖审批查询
        /// </summary>
        public DataSet SelectC_winnersExamine(string proc, int C_winnersId)
        {
            return human.SelectC_winnersExamine(proc, C_winnersId);

        }
        /// <summary>
        /// 竞赛获奖审批流程添加
        /// </summary>
        public bool C_winnersProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.C_winnersProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 竞赛获奖审批流程删除
        /// </summary>
        public bool C_winnersProcessDelete(string proc, int C_winnersProcessId, string UserCardId)
        {
            return human.C_winnersProcessDelete(proc, C_winnersProcessId, UserCardId);

        }
        /// <summary>
        /// 竞赛获奖记录查询
        /// </summary>
        public DataSet SelectsC_winners(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string C_winnersName, string Leve, string C_winnersYear)
        {
            return human.SelectsC_winners(proc, UserName, DepartmentId, Year, Month, Status, C_winnersName, Leve, C_winnersYear);

        }
        #endregion
        #region 教学成果获奖
        /// <summary>
        /// 教学成果获奖申请
        /// </summary>
        public bool ResultsInsert(string proc, string UserCardId,int DepartmentId, string ResultsName, string Category, string Awardlevel, string ResultsPrincipal, string Awarding_unit, string time, string Completion, double ResultsTotal, string ResultsDescription, string ResultsUrl, double ResultsValue, string Remarks)
        {
            return human.ResultsInsert(proc, UserCardId, DepartmentId, ResultsName, Category, Awardlevel, ResultsPrincipal, Awarding_unit, time, Completion, ResultsTotal, ResultsDescription, ResultsUrl, ResultsValue, Remarks);

        }
        /// <summary>
        /// 教学成果获奖合作者单个查询
        /// </summary>
        public DataSet SelectByResultsPartnerId(string proc, int ResultsPartnerId)
        {
            return human.SelectByResultsPartnerId(proc, ResultsPartnerId);

        }
        /// <summary>
        /// 教学成果获奖合作者添加
        /// </summary>
        public bool ResultsPartnerInsert(string proc, int ResultsId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.ResultsPartnerInsert(proc, ResultsId, UserCardId, PartnerRank, PartnerValue);

        }
        /// 合作者信息修改
        /// </summary>
        public bool ResultsPartnerUpdate(string proc, int ResultsPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.ResultsPartnerUpdate(proc, ResultsPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 教学成果获奖合作者删除
        /// </summary>
        public bool ResultsPartnerDelete(string proc, int ResultsPartnerId)
        {
            return human.ResultsPartnerDelete(proc, ResultsPartnerId);

        }
        /// <summary>
        /// 教学成果获奖单个查询
        /// </summary>
        public DataSet SelectByResultsId(string proc, int ResultsId)
        {
            return human.SelectByResultsId(proc, ResultsId);

        }
        /// <summary>
        /// 教学成果获奖查询
        /// </summary>
        public DataSet SelectResults(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectResults(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人教学成果获奖查询
        /// </summary>
        public DataSet SelectResultsByUserCardId(string proc, string UserCardId)
        {
            return human.SelectResultsByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 教学成果获奖可审批查询
        /// </summary>
        public DataSet ResultsExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.ResultsExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 教学成果获奖修改
        /// </summary>
        public bool ResultsUpdate(string proc, int ResultsId, int DepartmentId, string ResultsName, string Category, string Awardlevel, string ResultsPrincipal, string Awarding_unit, string time, string Completion, double ResultsTotal, string ResultsDescription, string ResultsUrl, double ResultsValue, string Remarks)
        {
            return human.ResultsUpdate(proc, ResultsId, DepartmentId, ResultsName, Category, Awardlevel, ResultsPrincipal, Awarding_unit, time, Completion, ResultsTotal, ResultsDescription, ResultsUrl, ResultsValue, Remarks);

        }


        /// <summary>
        /// 教学成果获奖删除
        /// </summary>
        public bool ResultsDelete(string proc, int ResultsId)
        {
            return human.ResultsDelete(proc, ResultsId);

        }

        /// <summary>
        /// 教学成果获奖审批添加
        /// </summary>
        public bool ResultsExamineInsert(string proc, int ResultsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ResultsExamineInsert(proc, ResultsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 教学成果获奖审批查询
        /// </summary>
        public DataSet SelectResultsExamine(string proc, int ResultsId)
        {
            return human.SelectResultsExamine(proc, ResultsId);

        }
        /// <summary>
        /// 教学成果获奖审批流程添加
        /// </summary>
        public bool ResultsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.ResultsProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 教学成果获奖审批流程删除
        /// </summary>
        public bool ResultsProcessDelete(string proc, int ResultsProcessId, string UserCardId)
        {
            return human.ResultsProcessDelete(proc, ResultsProcessId, UserCardId);

        }
        /// <summary>
        /// 教学成果获奖记录查询
        /// </summary>
        public DataSet SelectsResults(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string ResultsName, string Awardlevel, string ResultsYear)
        {
            return human.SelectsResults(proc, UserName, DepartmentId, Year, Month, Status, ResultsName, Awardlevel, ResultsYear);

        }
        #endregion
        #region 专项分值

        /// <summary>
        /// 专项分值申请
        /// </summary>
        public bool SpecialInsert(string proc, string UserCardId, int DepartmentId, string ContentName, string Score, string Remarks)
        {
            return human.SpecialInsert(proc, UserCardId, DepartmentId, ContentName, Score, Remarks);

        }
        /// <summary>
        /// 专项分值修改
        /// </summary>
        public bool SpecialUpdate(string proc, int SpecialId, int DepartmentId, string ContentName, string Score, string Remarks)
        {
            return human.SpecialUpdate(proc, SpecialId, DepartmentId, ContentName, Score, Remarks);

        }

        /// <summary>
        /// 专项分值单个查询
        /// </summary>
        public DataSet SelectBySpecialId(string proc, int SpecialId)
        {
            return human.SelectBySpecialId(proc, SpecialId);

        }
        /// <summary>
        /// 专项分值删除
        /// </summary>
        public bool SpecialDelete(string proc, int SpecialId)
        {
            return human.SpecialDelete(proc, SpecialId);

        }
        /// <summary>
        /// 专项分值审批添加
        /// </summary>
        public bool SpecialExamineInsert(string proc, int SpecialId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.SpecialExamineInsert(proc, SpecialId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 专项分值审批流程添加
        /// </summary>
        public bool SpecialProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.SpecialProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 专项分值审批流程删除
        /// </summary>
        public bool SpecialProcessDelete(string proc, int SpecialProcessId, string UserCardId)
        {
            return human.SpecialProcessDelete(proc, SpecialProcessId, UserCardId);

        }
        /// <summary>
        /// 专项分值记录查询
        /// </summary>
        public DataSet SelectsSpecial(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string ContentName, string SpecialYear)
        {
            return human.SelectsSpecial(proc, UserName, DepartmentId, Year, Month, Status, ContentName, SpecialYear);

        }
        #endregion
        #region 教学工作量转化教研分

        /// <summary>
        /// 教学工作量转化教研分申请
        /// </summary>
        public bool TeachToTeachingInsert(string proc, string UserCardId, int DepartmentId, string Quantity, string TotalScore, string Remarks)
        {
            return human.TeachToTeachingInsert(proc, UserCardId, DepartmentId, Quantity, TotalScore, Remarks);

        }
        /// <summary>
        /// 教学工作量转化教研分修改
        /// </summary>
        public bool TeachToTeachingUpdate(string proc, int TeachToTeachingId, int DepartmentId, string Quantity, string TotalScore, string Remarks)
        {
            return human.TeachToTeachingUpdate(proc, TeachToTeachingId, DepartmentId, Quantity, TotalScore, Remarks);

        }

        /// <summary>
        /// 教学工作量转化教研分单个查询
        /// </summary>
        public DataSet SelectByTeachToTeachingId(string proc, int TeachToTeachingId)
        {
            return human.SelectByTeachToTeachingId(proc, TeachToTeachingId);

        }
        /// <summary>
        /// 教学工作量转化教研分删除
        /// </summary>
        public bool TeachToTeachingDelete(string proc, int TeachToTeachingId)
        {
            return human.TeachToTeachingDelete(proc, TeachToTeachingId);

        }
        /// <summary>
        /// 教学工作量转化教研分审批添加
        /// </summary>
        public bool TeachToTeachingExamineInsert(string proc, int TeachToTeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.TeachToTeachingExamineInsert(proc, TeachToTeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 教学工作量转化教研分审批流程添加
        /// </summary>
        public bool TeachToTeachingProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.TeachToTeachingProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 教学工作量转化教研分审批流程删除
        /// </summary>
        public bool TeachToTeachingProcessDelete(string proc, int TeachToTeachingProcessId, string UserCardId)
        {
            return human.TeachToTeachingProcessDelete(proc, TeachToTeachingProcessId, UserCardId);

        }
        /// <summary>
        /// 教学工作量转化教研分记录查询
        /// </summary>
        public DataSet SelectsTeachToTeaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string Quantity, string TotalScore, string TeachToTeachingYear)
        {
            return human.SelectsTeachToTeaching(proc, UserName, DepartmentId, Year, Month, Status, Quantity, TotalScore, TeachToTeachingYear);

        }
        #endregion
        #endregion

        #region
        /// <summary>
        /// 获奖审批修改
        /// </summary>
        public bool WinningStatusModifyInsert(string proc, int WinningId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.WinningStatusModifyInsert(proc, WinningId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }
      

        /// <summary>
        /// 工作量项目审批修改
        /// </summary>
        public bool WorkLoadProjectsStatusModifyInsert(string proc, int WorkLoadProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.WorkLoadProjectsStatusModifyInsert(proc, WorkLoadProjectsId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 论文审批修改
        /// </summary>
        public bool PaperStatusModifyInsert(string proc, int PaperId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.PaperStatusModifyInsert(proc, PaperId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 著作审批修改
        /// </summary>
        public bool TeachingStatusModifyInsert(string proc, int TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.TeachingStatusModifyInsert(proc, TeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 成果审批修改
        /// </summary>
        public bool HarvestStatusModifyInsert(string proc, int HarvestId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.HarvestStatusModifyInsert(proc, HarvestId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 专利审批修改
        /// </summary>
        public bool PatentStatusModifyInsert(string proc, int PatentId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.PatentStatusModifyInsert(proc, PatentId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 指导学生审批修改
        /// </summary>
        public bool GuidanceStatusModifyInsert(string proc, int GuidanceId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.GuidanceStatusModifyInsert(proc, GuidanceId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 教材建设审批修改
        /// </summary>
        public bool T_TeachingStatusModifyInsert(string proc, int T_TeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.T_TeachingStatusModifyInsert(proc, T_TeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 教学团队建设审批修改
        /// </summary>
        public bool Teaching_TeamStatusModifyInsert(string proc, int Teaching_TeamId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.Teaching_TeamStatusModifyInsert(proc, Teaching_TeamId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 专业建设审批修改
        /// </summary>
        public bool P_constructionStatusModifyInsert(string proc, int P_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.P_constructionStatusModifyInsert(proc, P_constructionId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 课程建设审批修改
        /// </summary>
        public bool C_constructionStatusModifyInsert(string proc, int C_constructionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.C_constructionStatusModifyInsert(proc, C_constructionId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 竞赛获奖审批修改
        /// </summary>
        public bool C_winnersStatusModifyInsert(string proc, int C_winnersId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.C_winnersStatusModifyInsert(proc, C_winnersId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }


        /// <summary>
        /// 教学成果获奖审批修改
        /// </summary>
        public bool ResultsStatusModifyInsert(string proc, int ResultsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.ResultsStatusModifyInsert(proc, ResultsId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }
        /// <summary>
        /// 专项分值审批修改
        /// </summary>
        public bool SpecialStatusModifyInsert(string proc, int SpecialId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.SpecialStatusModifyInsert(proc, SpecialId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }
        /// <summary>
        /// 教学工作量转化教研分审批修改
        /// </summary>
        public bool TeachToTeachingStatusModifyInsert(string proc, int TeachToTeachingId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult)
        {
            return human.TeachToTeachingStatusModifyInsert(proc, TeachToTeachingId, ExamineOpinion, ExamineUserCardId, ExamineResult);

        }
        #endregion
        #region 其他
        /// <summary>
        /// 职业资格单个查询
        /// </summary>
        public DataSet SelectByJobCertificateId(string proc, int JobCertificateId)
        {
            return human.SelectByJobCertificateId(proc, JobCertificateId);

        }
        /// <summary>
        /// 历年获奖单个查询
        /// </summary>
        public DataSet SelectByPastAwardsId(string proc, int PastAwardsId)
        {
            return human.SelectByPastAwardsId(proc, PastAwardsId);

        }
        /// <summary>
        /// 培训进修单个查询
        /// </summary>
        public DataSet SelectByStudyTrainId(string proc, int StudyTrainId)
        {
            return human.SelectByStudyTrainId(proc, StudyTrainId);

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
    }
}