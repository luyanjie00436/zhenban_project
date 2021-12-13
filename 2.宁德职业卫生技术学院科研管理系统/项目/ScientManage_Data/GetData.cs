using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ningdeScientManage_Data
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
        public int Login(string userCardId, string userPwd, int RankId)
        {
        
            int num = -1;
            num = human.Login(userCardId, userPwd, RankId);
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
        /// 按用户系(部)年份查询
        /// </summary>
        public DataSet SelectsByApplyValue(string proc, string UserName, string DepartmentName,string ApplyYearName)
        {
            return human.SelectsByApplyValue(proc, UserName, DepartmentName, ApplyYearName);

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
        #region 科研内容
        /// <summary>
        /// 科研类别添加
        /// </summary>
        public bool WorkCategoryInsert(string proc, string WorkCategoryName, string WorkValue, int FatherId,int Rank)
        {
            return human.WorkCategoryInsert(proc, WorkCategoryName, WorkValue, FatherId,Rank);

        }
        public bool WorkCategoryDelete(string proc, int WorkCategoryId)
        {
            return human.WorkCategoryDelete(proc, WorkCategoryId);
        }
        public bool WorkCategoryUpdate(string proc, int WorkCategoryId,string WorkCategoryName,string WorkValue)
        {
            return human.WorkCategoryUpdate(proc, WorkCategoryId,WorkCategoryName,WorkValue);
        }
        /// <summary>
        /// 按科研内容编号查询
        /// </summary>
        public DataSet SelectByWorkCategoryId(string proc, int WorkCategoryId)
        {
            return human.SelectByWorkCategoryId(proc, WorkCategoryId);

        }
        /// <summary>
        /// 按科研内容查询
        /// </summary>
        public DataSet SelectByWorkCategoryName(string proc, string WorkCategoryName)
        {
            return human.SelectByWorkCategoryName(proc, WorkCategoryName);

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
        public bool JobInsert(string proc, string JobName, int JobValue,string UserCardId)
        {
            return human.JobInsert(proc, JobName, JobValue,UserCardId);

        }
        /// <summary>
        /// 职称信息修改
        /// </summary>
        public bool JobUpdate(string proc, int JobId, string JobName, int JobValue,string UserCardId)
        {
            return human.JobUpdate(proc, JobId, JobName, JobValue,UserCardId);

        }
        /// <summary>
        /// 职称信息删除
        /// </summary>
        public bool JobDelete(string proc, int JobId,string UserCardId)
        {
            return human.JobDelete(proc, JobId,UserCardId);

        }

        #endregion
        #region 职级
        /// <summary>
        /// 职级信息添加
        /// </summary>
        public bool PostInsert(string proc, string PostName, string  PlanPeople, int PostValue,string UserCardId)
        {
            return human.PostInsert(proc, PostName, PlanPeople, PostValue,UserCardId);

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
        public bool PostUpdate(string proc, int PostId, string PostName, string PlanPeople, int PostValue,string UserCardId)
        {
            return human.PostUpdate(proc, PostId, PostName, PlanPeople, PostValue,UserCardId);

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
        #region 单位
        /// <summary>
        /// 单位信息添加
        /// </summary>
        public bool CompanyInsert(string proc, string CompanyName, string UserCardId)
        {
            return human.CompanyInsert(proc, CompanyName, UserCardId);

        }
        /// <summary>
        /// 单位信息单个查询
        /// </summary>
        public DataSet SelectByCompanyId(string proc, int CompanyId)
        {
            return human.SelectByCompanyId(proc, CompanyId);

        }
        /// <summary>
        /// 单位信息修改
        /// </summary>
        public bool CompanyUpdate(string proc, int CompanyId, string CompanyName, string UserCardId)
        {
            return human.CompanyUpdate(proc, CompanyId, CompanyName, UserCardId);

        }
       
        /// <summary>
        /// 单位信息删除
        /// </summary>
        public bool CompanyDelete(string proc, int CompanyId, string UserCardId)
        {
            return human.CompanyDelete(proc, CompanyId, UserCardId);

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
        public bool ModelDelete(string proc, int ModelId, string UserCardId)
        {
            return human.ModelDelete(proc, ModelId, UserCardId);

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
        #region 经费项目
        /// <summary>
        /// 经费项目信息添加
        /// </summary>
        public bool CapitalInsert(string proc, string CapitalName,string UserCardId)
        {
            return human.CapitalItemInsert(proc, CapitalName,UserCardId);

        }
        /// <summary>
        /// 经费项目信息单个查询
        /// </summary>
        public DataSet SelectByCapitalId(string proc, int CapitalItemId)
        {
            return human.SelectByCapitalItemId(proc, CapitalItemId);

        }
        /// <summary>
        /// 经费项目信息修改
        /// </summary>
        public bool CapitalUpdate(string proc, int CapitalItemId, string CapitalName,string UserCardId)
        {
            return human.CapitalItemUpdate(proc, CapitalItemId, CapitalName,UserCardId);

        }
        /// <summary>
        /// 经费项目信息删除
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
        #region  成果申报时间

        /// <summary>
        /// 成果申报时间信息单个查询
        /// </summary>
        public DataSet SelectByHarvestDateId(string proc, int HarvestDateId)
        {
            return human.SelectByHarvestDateId(proc, HarvestDateId);

        }
        /// <summary>
        /// 成果申报时间信息修改
        /// </summary>
        public bool HarvestDateUpdate(string proc, int HarvestDateId, string StartDate, string EndDate, string UserCardId)
        {
            return human.HarvestDateUpdate(proc, HarvestDateId, StartDate, EndDate, UserCardId);

        }

        /// <summary>
        /// 成果申报时间信息删除
        /// </summary>
        public bool HarvestDateDelete(string proc, int HarvestDateId, string UserCardId)
        {
            return human.HarvestDateDelete(proc, HarvestDateId, UserCardId);

        }
        #endregion
        #region  项目申报时间

        /// <summary>
        /// 项目申报时间信息单个查询
        /// </summary>
        public DataSet SelectByProjectsDateId(string proc, int ProjectsDateId)
        {
            return human.SelectByProjectsDateId(proc, ProjectsDateId);

        }
        /// <summary>
        /// 项目申报时间信息修改
        /// </summary>
        public bool ProjectsDateUpdate(string proc, int ProjectsDateId, string StartDate, string EndDate, string UserCardId)
        {
            return human.ProjectsDateUpdate(proc, ProjectsDateId, StartDate, EndDate, UserCardId);

        }

        /// <summary>
        /// 项目申报时间信息删除
        /// </summary>
        public bool ProjectsDateDelete(string proc, int ProjectsDateId, string UserCardId)
        {
            return human.ProjectsDateDelete(proc, ProjectsDateId, UserCardId);

        }
        #endregion
        #region 考核等级
        /// <summary>
        /// 考核等级信息添加
        /// </summary>
        public bool AssessRankInsert(string proc, int JobId,string RankName, double MinValue, double MaxValue, string RankExplain,string UserCardId)
        {
            return human.AssessRankInsert(proc, JobId,RankName, MinValue, MaxValue, RankExplain,UserCardId);

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
        public bool AssessRankUpdate(string proc, int AssessRankId, string RankName, int JobId, double MinValue, double MaxValue, string RankExplain, string UserCardId)
        {
            return human.AssessRankUpdate(proc, AssessRankId, RankName,JobId, MinValue, MaxValue, RankExplain,UserCardId);

        }

        /// <summary>
        /// 考核等级信息删除
        /// </summary>
        public bool AssessRankDelete(string proc, int AssessRankId,string UserCardId)
        {
            return human.AssessRankDelete(proc, AssessRankId,UserCardId);

        }
        #endregion
        #region 系(部)
        /// <summary>
        /// 系(部)信息添加
        /// </summary>
        public bool DepartmentInsert(string proc, string DepartmentName, string UserCardId)
        {
            return human.DepartmentInsert(proc, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 系(部)信息单个查询
        /// </summary>
        public DataSet SelectByDepartmentId(string proc, int DepartmentId)
        {
            return human.SelectByDepartmentId(proc, DepartmentId);

        }
        /// <summary>
        /// 系(部)信息修改
        /// </summary>
        public bool DepartmentUpdate(string proc, int DepartmentId, string DepartmentName, string UserCardId)
        {
            return human.DepartmentUpdate(proc, DepartmentId, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 系(部)职务数量查询
        /// </summary>
        public int DepartmentSum(string proc, int DepartmentId)
        {
            return human.DepartmentSum(proc, DepartmentId);

        }
        /// <summary>
        /// 系(部)信息删除
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
            return human.RankInsert(proc, RankName, UserCardId, RBL1,RBL2);

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
            return human.RankUpdate(proc, RankId, RankName, UserCardId, RBL1,RBL2);

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
        public DataSet UserInfoSelect(string proc, string UserName, int DepartmentId, int JobId, int PostId, int StatusId, string StartYear, string EndYear, string Gender, int PoliticalId, int RoleId)
        {
            return human.UserInfoSelect(proc, UserName, DepartmentId, JobId, PostId, StatusId, StartYear, EndYear, Gender, PoliticalId, RoleId);

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
        public bool UserInfoInsert(string proc, string UserCardId, string UserPwd, int DepartmentId,string UserName,string UserCardId2)
        {
            return human.UserInfoInsert(proc, UserCardId, UserPwd, DepartmentId,UserName,UserCardId2);
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
        /// 用户信息修改
        /// </summary>
        public bool UserInfoUpdate(string proc, string UserCardId, int DegreeId, int PoliticalId, int Education, string IntroDucation, string Origin, string Address, string Marriage, string Phone, string Email, int StatusId, int DepartmentId, int JobId, int PostId, string UserName, string Gender, string Birthday, string UserIdCard, int NationId, string Remuneration, string Ranktime, int TeachersDepartmentId, string JobTime, string PostTime, string JobSeries, string TeachersSeries, string WorkLevel, string Management,string UserCardId2)
        {
            return human.UserInfoUpdate(proc, UserCardId, DegreeId, PoliticalId, Education, IntroDucation, Origin, Address, Marriage, Phone, Email, StatusId, DepartmentId, JobId, PostId, UserName, Gender, Birthday, UserIdCard, NationId, Remuneration, Ranktime, TeachersDepartmentId, JobTime, PostTime, JobSeries, TeachersSeries, WorkLevel, Management,UserCardId2);

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
        #region 通知
        /// <summary>
        /// 通知信息添加
        /// </summary>
        public bool NoticeInsert(string proc, string NoticeExplain, string FileUrl, string UserCardId)
        {
            return human.NoticeInsert(proc, NoticeExplain, FileUrl, UserCardId);

        }
        /// <summary>
        /// 通知信息单个查询
        /// </summary>
        public DataSet SelectByNoticeId(string proc, int NoticeId)
        {
            return human.SelectByNoticeId(proc, NoticeId);

        }
        /// <summary>
        /// 通知信息修改
        /// </summary>
        public bool NoticeUpdate(string proc, int NoticeId, string NoticeExplain, string FileUrl, string UserCardId)
        {
            return human.NoticeUpdate(proc, NoticeId, NoticeExplain, FileUrl, UserCardId);

        }
        /// <summary>
        /// 通知职务数量查询
        /// </summary>
        public int NoticeSum(string proc, int NoticeId)
        {
            return human.NoticeSum(proc, NoticeId);

        }
        /// <summary>
        /// 通知信息删除
        /// </summary>
        public bool NoticeDelete(string proc, int NoticeId, string UserCardId)
        {
            return human.NoticeDelete(proc, NoticeId, UserCardId);

        }
        #endregion
        #endregion
        #region 科研工作量
        #region 学术团体
        /// <summary>
        /// 学术团体添加
        /// </summary>

        public bool AssciationInsert(string proc, string AssciationName, string Company, double Capital, string Explain, string UserCardId)
        {
            return human.AssciationInsert(proc, AssciationName, Company, Capital, Explain, UserCardId);
        }
        /// <summary>
        /// 学术团体修改
        /// </summary>

        public bool AssciationUpdate(string proc, int AssciationId, string AssciationName, string Company, double Capital, string Explain)
        {
            return human.AssciationUpdate(proc, AssciationId, AssciationName, Company, Capital, Explain);
        }
        /// <summary>
        /// 学术团体删除
        /// </summary>
        public bool AssciationDelete(string proc, int AssciationId)
        {
            return human.AssciationDelete(proc, AssciationId);
        }
        /// <summary>
        /// 学术团体审批添加
        /// </summary>
        public bool AssciationExamineInsert(string proc, int AssciationId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.AssciationExamineInsert(proc, AssciationId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 按学术团体编号查询
        /// </summary>

        public DataSet SelectByAssciationId(string proc, int AssciationId)
        {
            return human.SelectByAssciationId(proc, AssciationId);
        }

        /// <summary>
        /// 学术团体审批流程添加
        /// </summary>
        public bool AssciationProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.AssciationProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 学术团体审批流程删除
        /// </summary>
        public bool AssciationProcessDelete(string proc, int AssciationProcessId, string UserCardId)
        {
            return human.AssciationProcessDelete(proc, AssciationProcessId, UserCardId);

        }
        /// <summary>
        /// 学术团体记录查询
        /// </summary>
        public DataSet SelectsAssociation(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string AssociationName,string Company)
        {
            return human.SelectsAssociation(proc, UserName, DepartmentId, Year, Month, Status, AssociationName,Company);

        }
        #endregion
        #region 讲座
        /// <summary>
        /// 讲座添加
        /// </summary>
        public bool LctureInsert(string proc, string UserCardId, string LctureName, string Company, string LctureDate, string Address,  string LctureNumber, string LctureExplain, string Equipment, string OrganName, string PhoneNumber, string Capital,string DLevel, string Remarks,string LctureUserName,string LctureUserGender,string LctureUserJob,string LctureUserRole,string LctureUserCompany)
        {
            return human.LctureInsert(proc, UserCardId, LctureName, Company, LctureDate, Address ,LctureNumber, LctureExplain, Equipment, OrganName, PhoneNumber, Capital, DLevel, Remarks,LctureUserName,LctureUserGender,LctureUserJob,LctureUserRole,LctureUserCompany);
        }
        /// <summary>
        /// 讲座修改
        /// </summary>
        public bool LctureUpdate(string proc, int LctureId, string LctureName, string Company, string LctureDate, string Address,string LctureNumber, string LctureExplain, string Equipment, string OrganName, string PhoneNumber, string Capital, string DLevel, string Remarks, string LctureUserName, string LctureUserGender, string LctureUserJob, string LctureUserRole, string LctureUserCompany)
        {
            return human.LctureUpdate(proc, LctureId, LctureName, Company, LctureDate, Address,  LctureNumber, LctureExplain, Equipment, OrganName, PhoneNumber, Capital,  DLevel, Remarks, LctureUserName, LctureUserGender, LctureUserJob, LctureUserRole, LctureUserCompany);
        }
        public bool LctureDelete(string proc, int LctureId)
        {
            return human.LctureDelete(proc, LctureId);
        }
        /// <summary>
        /// 讲座审批流程删除
        /// </summary>
        public bool LctureProcessDelete(string proc, int LctureProcessId, string UserCardId)
        {
            return human.LctureProcessDelete(proc, LctureProcessId, UserCardId);

        }
        /// <summary>
        /// 讲座审批添加
        /// </summary>
        public bool LctureExamineInsert(string proc, int LctureId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.LctureExamineInsert(proc, LctureId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 按讲座编号查询
        /// </summary>

        public DataSet SelectByLctureId(string proc, int LctureId)
        {
            return human.SelectByLctureId(proc, LctureId);
        }
        /// <summary>
        /// 学术团体记录查询
        /// </summary>
        public DataSet SelectsLcture(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string LctureName, string LctureSize)
        {
            return human.SelectsLcture(proc, UserName, DepartmentId, Year, Month, Status, LctureName, LctureSize);

        }
        #endregion
        #region 学术活动申请
        /// <summary>
        /// 学术申请
        /// </summary>
        /// 
        public bool ActivityInsert(string proc, string UserCardId, string AssociationName, string StartDate, string EndDate, double ActivityValue, int PartnerRank, double PartnerValue,string DCategory,string DLevel,string CompanyName)
        {
            return human.ActivityInsert(proc, UserCardId, AssociationName, StartDate, EndDate, ActivityValue, PartnerRank, PartnerValue,DCategory,DLevel,CompanyName);

        }
        /// <summary>
        /// 学术活动修改
        /// </summary>
        public bool AcitvityUpdate(string proc, int ActivityId, string AssociationName, string StartDate, string EndDate, double ActivityValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string CompanyName)
        {
            return human.AcitvityUpdate(proc, ActivityId, AssociationName, StartDate, EndDate, ActivityValue, PartnerRank, PartnerValue, DCategory, DLevel, CompanyName);

        }
        /// <summary>
        /// 学术活动单个查询
        /// </summary>
        public DataSet SelectByActivityId(string proc, int ActivityId)
        {
            return human.SelectByActivityId(proc, ActivityId);

        }
        /// <summary>
        /// 学术活动审批流程添加
        /// </summary>
        public bool ActivityProcessInsert(string proc, int ProcessRankId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.ActivityProcessInsert(proc, ProcessRankId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 学术活动审批流程删除
        /// </summary>
        public bool ActivityProcessDelete(string proc, int ActivityProcessId, string UserCardId)
        {
            return human.ActivityProcessDelete(proc, ActivityProcessId, UserCardId);

        }
        /// <summary>
        /// 学术活动删除
        /// </summary>
        public bool ActivityDelete(string proc, int ActivityId)
        {
            return human.ActivityDelete(proc, ActivityId);

        }
        /// <summary>
        /// 学术活动记录查询
        /// </summary>
        public DataSet SelectsActivity(string proc, string UserName, string DepartmentId,int Year,int Month, string TransferStatus,string AssociationName)
        {
            return human.SelectsActivity(proc, UserName, DepartmentId, Year,Month ,TransferStatus,AssociationName);

        }
        /// <summary>
        /// 个人学术活动查询
        /// </summary>
        public DataSet SelectActivityByUserCardId(string proc, string UserCardId)
        {
            return human.SelectActivityByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 学术活动合作者添加
        /// </summary>
        public bool ActivityPartnerInsert(string proc, int ActivityId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.ActivityPartnerInsert(proc, ActivityId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 学术活动合作者信息修改
        /// </summary>
        public bool ActivityPartnerUpdate(string proc, int ActivityPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.ActivityPartnerUpdate(proc, ActivityPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 学术活动合作者删除
        /// </summary>
        public bool ActivityPartnerDelete(string proc, int ActivityPartnerId)
        {
            return human.ActivityPartnerDelete(proc, ActivityPartnerId);

        }
        /// <summary>
        /// 学术活动合作者单个查询
        /// </summary>
        public DataSet SelectByActivityPartnerId(string proc, int ActivityPartnerId)
        {
            return human.SelectByActivityPartnerId(proc, ActivityPartnerId);

        }
        /// <summary>
        /// 学术活动可审批查询
        /// </summary>
        public DataSet ActivityExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.ActivityExamineSelectUser(proc, UserCardId, RankId);

        }
        /// <summary>
        /// 学术活动审批添加
        /// </summary>
        public bool ActivityExamineInsert(string proc, int ActivityId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ActivityExamineInsert(proc, ActivityId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }



        #endregion
        #region 技能竞赛
        /// <summary>
        /// 技能竞赛申请
        /// </summary>
        /// 
        public bool CompetitionInsert(string proc, string UserCardId, string CompetitionName, string AppraisalCompany, string TeacherName, string StudentName, string Mentor, double CompetitionValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string CompetitionDate)
        {
            return human.CompetitionInsert(proc, UserCardId, CompetitionName, AppraisalCompany, TeacherName, StudentName, Mentor, CompetitionValue, PartnerRank, PartnerValue, DCategory, DLevel, CompetitionDate);

        }
        /// <summary>
        /// 技能竞赛修改
        /// </summary>
        /// 
        public bool CompetitionUpdate(string proc, int CompetitionId, string CompetitionName, string AppraisalCompany, string TeacherName, string StudentName, string Mentor, double CompetitionValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string CompetitionDate)
        {
            return human.CompetitionUpdate(proc, CompetitionId, CompetitionName, AppraisalCompany, TeacherName, StudentName, Mentor, CompetitionValue, PartnerRank, PartnerValue, DCategory, DLevel, CompetitionDate);

        }
     
        /// <summary>
        /// 技能竞赛单个查询
        /// </summary>
        public DataSet SelectByCompetitionId(string proc, int CompetitionId)
        {
            return human.SelectByCompetitionId(proc, CompetitionId);

        }
        /// <summary>
        /// 技能竞赛审批流程添加
        /// </summary>
        public bool CompetitionProcessInsert(string proc, int ProcessRankId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.CompetitionProcessInsert(proc, ProcessRankId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 技能竞赛审批流程删除
        /// </summary>
        public bool CompetitionProcessDelete(string proc, int CompetitionProcessId, string UserCardId)
        {
            return human.CompetitionProcessDelete(proc, CompetitionProcessId, UserCardId);

        }
        /// <summary>
        /// 个人技能竞赛查询
        /// </summary>
        public DataSet SelectCompetitionByUserCardId(string proc, string UserCardId)
        {
            return human.SelectCompetitionByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 技能竞赛合作者添加
        /// </summary>
        public bool CompetitionPartnerInsert(string proc, int CompetitionId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.CompetitionPartnerInsert(proc, CompetitionId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 技能竞赛合作者信息修改
        /// </summary>
        public bool CompetitionPartnerUpdate(string proc, int CompetitionPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.CompetitionPartnerUpdate(proc, CompetitionPartnerId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 技能竞赛合作者删除
        /// </summary>
        public bool CompetitionPartnerDelete(string proc, int CompetitionPartnerId)
        {
            return human.CompetitionPartnerDelete(proc, CompetitionPartnerId);

        }
        /// <summary>
        /// 技能竞赛合作者单个查询
        /// </summary>
        public DataSet SelectByCompetitionPartnerId(string proc, int CompetitionPartnerId)
        {
            return human.SelectByCompetitionPartnerId(proc, CompetitionPartnerId);

        }
        /// <summary>
        /// 技能竞赛记录查询
        /// </summary>
        public DataSet SelectsCompetition(string proc, string UserName, string DepartmentId, int Year, int Month, string TransferStatus, string CompetitionName)
        {
            return human.SelectsCompetition(proc, UserName, DepartmentId, Year, Month, TransferStatus, CompetitionName);

        }
        /// <summary>
        /// 技能竞赛可审批查询
        /// </summary>
        public DataSet CompetitionExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.CompetitionExamineSelectUser(proc, UserCardId, RankId);

        }
        /// <summary>
        /// 技能竞赛审批添加
        /// </summary>
        public bool CompetitionExamineInsert(string proc, int CompetitionId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.CompetitionExamineInsert(proc, CompetitionId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 技能竞赛删除
        /// </summary>
        public bool CompetitionDelete(string proc, int CompetitionId)
        {
            return human.CompetitionDelete(proc, CompetitionId);

        }






        #endregion
        #region 获奖
        /// <summary>
        /// 获奖申请
        /// </summary>
        public bool WinningInsert(string proc, string UserCardId, string WinningName, string WinningCategory,  double WinningValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.WinningInsert(proc, UserCardId, WinningName, WinningCategory, WinningValue, PartnerRank, PartnerValue,DCategory,DLevel, Remarks);

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
        public bool WinningUpdate(string proc, int WinningId, string WinningName, string WinningCategory, double WinningValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.WinningUpdate(proc, WinningId, WinningName, WinningCategory, WinningValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks);


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
        public DataSet SelectsWinning(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string WinningName,string WinningForm)
        {
            return human.SelectsWinning(proc, UserName, DepartmentId, Year, Month, Status,WinningName,WinningForm);

        }
        #endregion
        #region 工作量项目
        /// <summary>
        /// 工作量项目申请
        /// </summary>
        public bool WorkLoadProjectsInsert(string proc, string ProjectsId, string UserCardId, string WorkLoadProjectsName, string WorkLoadForm, string ProjectDate, string ConcludingDate, double WorkLoadCapital, int PartnerRank, double ProjectsValue, double PartnerValue, double ConcludingValue, string DCategory, string DLevel, string Remarks,double WorkLoadProjectsValue)
        {
            return human.WorkLoadProjectsInsert(proc, ProjectsId, UserCardId, WorkLoadProjectsName, WorkLoadForm, ProjectDate, ConcludingDate, WorkLoadCapital, PartnerRank, ProjectsValue, PartnerValue, ConcludingValue, DCategory, DLevel, Remarks,WorkLoadProjectsValue);

        }
        /// <summary>
        /// 工作量项目合作者添加
        /// </summary>
        public bool WorkLoadProjectsPartnerInsert(string proc, int WorkLoadProjectsId, string UserCardId, int PartnerRank, double PartnerValue, double ProjectsValue, double ConcludingValue)
        {
            return human.WorkLoadProjectsPartnerInsert(proc, WorkLoadProjectsId, UserCardId, PartnerRank, PartnerValue, ProjectsValue, ConcludingValue);

        }
        /// <summary>
        /// 工作量项目单个查询
        /// </summary>
        public DataSet SelectByWorkLoadProjectsId(string proc, int WorkLoadProjectsId)
        {
            return human.SelectByWorkLoadProjectsId(proc, WorkLoadProjectsId);

        }
        /// <summary>
        /// 工作量项目编号查询
        /// </summary>
        public DataSet SelectByProjectsId(string proc, string UserCardId, string ProjectsId)
        {
            return human.SelectByProjectsId(proc, UserCardId, ProjectsId);

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
        public bool WorkLoadProjectsUpdate(string proc, int WorkLoadProjectsId, string ProjectsId, string WorkLoadProjectsName, string WorkLoadForm, double ProjectDate, double ConcludingDate, string WorkLoadCapital, double WorkLoadProjectsValue, int PartnerRank, double PartnerValue, double ProjectsValue, double ConcludingValue, string DCategory, string DLevel, string Remarks)
        {
            return human.WorkLoadProjectsUpdate(proc, WorkLoadProjectsId, ProjectsId,  WorkLoadProjectsName,WorkLoadForm, ProjectDate,  ConcludingDate, WorkLoadCapital,  WorkLoadProjectsValue,  PartnerRank,  PartnerValue, ProjectsValue, ConcludingValue,  DCategory, DLevel,Remarks);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool WorkLoadProjectsPartnerUpdate(string proc, int WorkLoadProjectsPartnerId, string UserCardId, int PartnerRank, double PartnerValue, double ConcludingValue,double ProjectsValue)
        {
            return human.WorkLoadProjectsPartnerUpdate(proc, WorkLoadProjectsPartnerId, UserCardId, PartnerRank, PartnerValue,ConcludingValue,ProjectsValue);

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
        public DataSet SelectsWorkLoadProjects(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string ProjectsName,string ProjectsForm)
        {
            return human.SelectsWorkLoadProjects(proc, UserName, DepartmentId, Year, Month, Status,ProjectsName,ProjectsForm);

        }
        #endregion
        #region 论文
        /// <summary>
        /// 论文申请
        /// </summary>
        public bool PaperInsert(string proc, string UserCardId, string PaperName, string PaperSubject,string AuthorsOrder, string DCategory, string DLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears, string Remarks,string PublicationName, string PaperDate,string FileUrl)
        {
            return human.PaperInsert(proc, UserCardId, PaperName, PaperSubject, AuthorsOrder,DCategory, DLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks,PublicationName,PaperDate, FileUrl);

        }
        /// <summary>
        /// 论文合作者添加
        /// </summary>
        public bool PaperPartnerInsert(string proc, int PaperId, string UserCardId, int PartnerRank, double PartnerValue, string AuthorsOrder)
        {
            return human.PaperPartnerInsert(proc, PaperId, UserCardId, PartnerRank, PartnerValue, AuthorsOrder);

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
        public bool PaperUpdate(string proc, int PaperId, string PaperName, string PaperSubject, string AuthorsOrder, string DCategory, string DLevel, double PaperValue, int PartnerRank, double PartnerValue, string PaperYears, string Remarks, string PublicationName, string PaperDate,string FileUrl)
        {
            return human.PaperUpdate(proc, PaperId, PaperName, PaperSubject, AuthorsOrder, DCategory, DLevel, PaperValue, PartnerRank, PartnerValue, PaperYears, Remarks, PublicationName, PaperDate,FileUrl);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool PaperPartnerUpdate(string proc, int PaperPartnerId, string UserCardId, int PartnerRank, double PartnerValue, string AuthorsOrder)
        {
            return human.PaperPartnerUpdate(proc, PaperPartnerId, UserCardId, PartnerRank, PartnerValue, AuthorsOrder);

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
        public DataSet SelectsPaper(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string PaperSubject,string PaperName)
        {
            return human.SelectsPaper(proc, UserName, DepartmentId, Year, Month, Status,PaperSubject,PaperName);

        }
        #endregion
        #region 著作
        /// <summary>
        /// 著作申请
        /// </summary>
        public bool TeachingInsert(string proc, string UserCardId, string BookName, string DCategory, string DLevel, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, string EditedSequence, int PartnerRank, double PartnerValue, string Remarks, string TeachingDate)
        {
            return human.TeachingInsert(proc, UserCardId, BookName, DCategory, DLevel, PressName, PressDate, Revision, TotalNumber, TeachingValue, EditedSequence, PartnerRank, PartnerValue, Remarks,TeachingDate);

        }
        /// <summary>
        /// 著作合作者添加
        /// </summary>
        public bool TeachingPartnerInsert(string proc, int TeachingId, string UserCardId, int PartnerRank, double PartnerValue, string EditedSequence)
        {
            return human.TeachingPartnerInsert(proc, TeachingId, UserCardId, PartnerRank, PartnerValue, EditedSequence);

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
        public bool TeachingUpdate(string proc, int TeachingId, string BookName, string DCategory, string DLevel, string PressName, string PressDate, string Revision, string TotalNumber, double TeachingValue, string EditedSequence, int PartnerRank, double PartnerValue, string Remarks, string TeachingDate)
        {
            return human.TeachingUpdate(proc, TeachingId, BookName, DCategory, DLevel, PressName, PressDate, Revision, TotalNumber, TeachingValue, EditedSequence, PartnerRank, PartnerValue, Remarks, TeachingDate);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool TeachingPartnerUpdate(string proc, int TeachingPartnerId, string UserCardId, int PartnerRank, double PartnerValue, string EditedSequence)
        {
            return human.TeachingPartnerUpdate(proc, TeachingPartnerId, UserCardId, PartnerRank, PartnerValue, EditedSequence);

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
        public DataSet SelectsTeaching(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string BookName,string PressName)
        {
            return human.SelectsTeaching(proc, UserName, DepartmentId, Year, Month, Status,BookName,PressName);

        }
        #endregion
        #region 成果
        /// <summary>
        /// 成果申请
        /// </summary>
        public bool HarvestInsert(string proc, string UserCardId, string HarvestName, string AwardsDate, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.HarvestInsert(proc, UserCardId, HarvestName, AwardsDate, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks);

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
        public bool HarvestUpdate(string proc, int HarvestId, string HarvestName, string AwardsDate, string AppraisalLevel, double HarvestValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.HarvestUpdate(proc, HarvestId, HarvestName, AwardsDate, AppraisalLevel, HarvestValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks);

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
        public DataSet SelectsHarvest(string proc, string UserName,string DepartmentId, int Year, int Month, string Status,string HarvestName,string Company)
        {
            return human.SelectsHarvest(proc, UserName, DepartmentId, Year, Month, Status,HarvestName,Company);

        }
        #endregion
        #region 其他成果
        /// <summary>
        /// 其他成果申请
        /// </summary>
        public bool OtherResultsInsert(string proc, string UserCardId, string OtherResultsName, string AwardsDate, double OtherResultsValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.OtherResultsInsert(proc, UserCardId, OtherResultsName, AwardsDate, OtherResultsValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks);

        }
        /// <summary>
        /// 其他成果合作者添加
        /// </summary>
        public bool OtherResultsPartnerInsert(string proc, int OtherResultsId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.OtherResultsPartnerInsert(proc, OtherResultsId, UserCardId, PartnerRank, PartnerValue);

        }
        /// <summary>
        /// 其他成果单个查询
        /// </summary>
        public DataSet SelectByOtherResultsId(string proc, int OtherResultsId)
        {
            return human.SelectByOtherResultsId(proc, OtherResultsId);

        }
        /// <summary>
        /// 其他成果合作者单个查询
        /// </summary>
        public DataSet SelectByOtherResultsPartnerId(string proc, int OtherResultsPartnerId)
        {
            return human.SelectByOtherResultsPartnerId(proc, OtherResultsPartnerId);

        }
        /// <summary>
        /// 其他成果查询
        /// </summary>
        public DataSet SelectOtherResults(string proc, string UserName, int DepartmentId, int Year, int Month, string Status)
        {
            return human.SelectOtherResults(proc, UserName, DepartmentId, Year, Month, Status);

        }

        /// <summary>
        /// 个人其他成果查询
        /// </summary>
        public DataSet SelectOtherResultsByUserCardId(string proc, string UserCardId)
        {
            return human.SelectOtherResultsByUserCardId(proc, UserCardId);

        }
        /// <summary>
        /// 其他成果可审批查询
        /// </summary>
        public DataSet OtherResultsExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.OtherResultsExamineSelectUser(proc, UserCardId, RankId);

        }


        /// <summary>
        /// 其他成果修改
        /// </summary>
        public bool OtherResultsUpdate(string proc, int OtherResultsId, string OtherResultsName, string AwardsDate, double OtherResultsValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks)
        {
            return human.OtherResultsUpdate(proc, OtherResultsId, OtherResultsName, AwardsDate, OtherResultsValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks);

        }
        /// <summary>
        /// 合作者信息修改
        /// </summary>
        public bool OtherResultsPartnerUpdate(string proc, int OtherResultsPartnerId, string UserCardId, int PartnerRank, double PartnerValue)
        {
            return human.OtherResultsPartnerUpdate(proc, OtherResultsPartnerId, UserCardId, PartnerRank, PartnerValue);

        }

        /// <summary>
        /// 其他成果删除
        /// </summary>
        public bool OtherResultsDelete(string proc, int OtherResultsId)
        {
            return human.OtherResultsDelete(proc, OtherResultsId);

        }
        /// <summary>
        /// 其他成果合作者删除
        /// </summary>
        public bool OtherResultsPartnerDelete(string proc, int OtherResultsPartnerId)
        {
            return human.OtherResultsPartnerDelete(proc, OtherResultsPartnerId);

        }
        /// <summary>
        /// 其他成果审批添加
        /// </summary>
        public bool OtherResultsExamineInsert(string proc, int OtherResultsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.OtherResultsExamineInsert(proc, OtherResultsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 其他成果审批查询
        /// </summary>
        public DataSet SelectOtherResultsExamine(string proc, int OtherResultsId)
        {
            return human.SelectOtherResultsExamine(proc, OtherResultsId);

        }
        /// <summary>
        /// 其他成果审批流程添加
        /// </summary>
        public bool OtherResultsProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.OtherResultsProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 其他成果审批流程删除
        /// </summary>
        public bool OtherResultsProcessDelete(string proc, int OtherResultsProcessId, string UserCardId)
        {
            return human.OtherResultsProcessDelete(proc, OtherResultsProcessId, UserCardId);

        }
        /// <summary>
        /// 其他成果记录查询
        /// </summary>
        public DataSet SelectsOtherResults(string proc, string UserName, string DepartmentId, int Year, int Month, string Status, string OtherResultsName)
        {
            return human.SelectsOtherResults(proc, UserName, DepartmentId, Year, Month, Status, OtherResultsName);

        }
        #endregion
        #region 专利
        /// <summary>
        /// 专利申请
        /// </summary>
        public bool PatentInsert(string proc, string UserCardId, string PatentName,string ApprovalDate, string DCategory, string DLevel, double PatentValue, int PartnerRank, double PartnerValue, string Remarks)
        {
            return human.PatentInsert(proc, UserCardId, PatentName,ApprovalDate, DCategory, DLevel,PatentValue, PartnerRank, PartnerValue, Remarks);

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
        public bool PatentUpdate(string proc, int PatentId, string PatentName,string ApprovalDate, string DCategory, string DLevel, double PatentValue, int PartnerRank, double PartnerValue, string Remarks)
        {
            return human.PatentUpdate(proc, PatentId, PatentName, ApprovalDate, DCategory, DLevel, PatentValue, PartnerRank, PartnerValue, Remarks);

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
        public DataSet SelectsPatent(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string PatentName,string PatentCateGory)
        {
            return human.SelectsPatent(proc, UserName,DepartmentId, Year, Month, Status, PatentName, PatentCateGory);

        }
        #endregion
        #region 指导学生
        /// <summary>
        /// 指导学生申请
        /// </summary>
        public bool GuidanceInsert(string proc, string UserCardId, string GuidanceName, double GuidanceValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks,string GuidanceDate)
        {
            return human.GuidanceInsert(proc, UserCardId, GuidanceName,GuidanceValue, PartnerRank, PartnerValue, DCategory, DLevel,Remarks,GuidanceDate);

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
        public bool GuidanceUpdate(string proc, int GuidanceId, string GuidanceName, double GuidanceValue, int PartnerRank, double PartnerValue, string DCategory, string DLevel, string Remarks,string GuidanceDate)
        {
            return human.GuidanceUpdate(proc, GuidanceId, GuidanceName,GuidanceValue, PartnerRank, PartnerValue, DCategory, DLevel, Remarks,GuidanceDate);

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
        public DataSet SelectsGuidance(string proc, string UserName, string DepartmentId, int Year, int Month, string Status,string GuidanceName,string GuidanceLevel)
        {
            return human.SelectsGuidance(proc, UserName, DepartmentId, Year, Month, Status,GuidanceName,GuidanceLevel);

        }
        #endregion
        #endregion
        #region 项目
        #region 纵向项目
        /// <summary>
        /// 纵向项目基础信息保存
        /// </summary>
        public bool LongProjectsInsert(string proc, string LongProjectsId, string UserCardId, string ProjectsName, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company, string DeclareUrl, string ProjectsContent)
        {
            return human.LongProjectsInsert(proc, LongProjectsId, UserCardId, ProjectsName, ProjectsFromId, ProjectsSubjectId, ProjectsLevelId, Company, DeclareUrl, ProjectsContent);

        }
        /// <summary>
        /// 纵向项目立项保存
        /// </summary>
        public bool LongProjectsApprovalInsert(string proc, string LongProjectsId, string FileUrl)
        {
            return human.LongProjectsApprovalInsert(proc, LongProjectsId, FileUrl);

        }
        /// <summary>
        /// 纵向项目新编号修改
        /// </summary>
        public bool NewLongProjectsIdUpdate(string proc, string LongProjectsId, string NewLongProjectsId, string UserCardId)
        {
            return human.NewLongProjectsIdUpdate(proc, LongProjectsId, NewLongProjectsId, UserCardId);

        }
        /// <summary>
        /// 纵向项目信息修改
        /// </summary>
        public bool LongProjectsInformationUpdate(string proc, string LongProjectsId, string UserCardId, string ProjectsName, string NewLongProjectsId, int ProjectsFromId, int ProjectsSubjectId, int ProjectsLevelId, string Company, string ProjectsContent, string DeclareStatus, string StandStatus, string InspectStatus, string EndStatus)
        {
            return human.LongProjectsInformationUpdate( proc,  LongProjectsId,  UserCardId,  ProjectsName,  NewLongProjectsId,  ProjectsFromId,  ProjectsSubjectId,  ProjectsLevelId,  Company,  ProjectsContent,DeclareStatus,StandStatus,InspectStatus,EndStatus);

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
        /// 纵向评审项目查询
        /// </summary>
        public DataSet SelectsBranch(string proc,string UserName,string DepartmentName, string ProjectsName)
        {
            return human.SelectsBranch(proc, UserName, DepartmentName, ProjectsName );

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
        public bool LongProjectsStandUpdate(string proc, string LongProjectsId, string UserCardId,string path)
        {
            return human.LongProjectsStandUpdate(proc, LongProjectsId, UserCardId,path);
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
        public DataSet SelectByLongProjectsCapitalPlaceId(string proc, int LongProjectsCapitalPlanId)
        {
            return human.SelectByLongProjectsCapitalPlaceId(proc, LongProjectsCapitalPlanId);

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
        /// 纵向项目立项审批添加
        /// </summary>
        public bool LongProjectsStandExamineInsert(string proc, string LongProjectsId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.LongProjectsStandExamineInsert(proc, LongProjectsId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 纵向项目评审添加
        /// </summary>
        public bool LongProjectsApprovalBranchInsert(string proc, string LongProjectsId, string UserCardId, double Branch, string path, string Opinion)
        {
            return human.LongProjectsApprovalBranchInsert(proc, LongProjectsId, UserCardId, Branch, path, Opinion);

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

        public bool ShortProjectsInsert(string proc, string ShortProjectsId, string UserCardId, string ContractId, string ContractName, double ContractMoney, string Company, string FileUrl)
        {
            return human.ShortProjectsInsert(proc, ShortProjectsId, UserCardId, ContractId, ContractName, ContractMoney, Company, FileUrl);
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
        public DataSet SelectsLongCapital(string proc, string ProjectsId, string ProjectsName, string Company, double Money1, double Money2,string DepartmentName)
        {
            return human.SelectsLongCapital(proc, ProjectsId, ProjectsName, Company, Money1, Money2,DepartmentName);
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
        public DataSet SelectsShortCapital(string proc, string ContractId, string ContractName, string Company, double Money1, double Money2,string DepartmentName)
        {
            return human.SelectsShortCapital(proc, ContractId, ContractName, Company, Money1, Money2,DepartmentName);
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
        #region 项目情况
        #region 学科分类
        /// <summary>
        /// 学科分类信息添加
        /// </summary>
        public bool SubjectInsert(string proc, string SubjectName, string UserCardId)
        {
            return human.SubjectInsert(proc, SubjectName, UserCardId);

        }
        /// <summary>
        /// 学科分类信息单个查询
        /// </summary>
        public DataSet SelectBySubjectId(string proc, int SubjectId)
        {
            return human.SelectBySubjectId(proc, SubjectId);

        }
        /// <summary>
        /// 学科分类信息修改
        /// </summary>
        public bool SubjectUpdate(string proc, int SubjectId, string SubjectName, string UserCardId)
        {
            return human.SubjectUpdate(proc, SubjectId, SubjectName, UserCardId);

        }
        /// <summary>
        /// 学科分类信息删除
        /// </summary>
        public bool SubjectDelete(string proc, int SubjectId, string UserCardId)
        {
            return human.SubjectDelete(proc, SubjectId, UserCardId);

        }
        #endregion
        #region 社会经济目标
        /// <summary>
        /// 社会经济目标信息添加
        /// </summary>
        public bool AimsInsert(string proc, string AimsName, string Id, string Explain, string FatherId, string UserCardId)
        {
            return human.AimsInsert(proc, AimsName,Id,Explain,FatherId, UserCardId);

        }
        /// <summary>
        /// 社会经济目标信息单个查询
        /// </summary>
        public DataSet SelectByAimsId(string proc, int AimsId)
        {
            return human.SelectByAimsId(proc, AimsId);

        }
        /// <summary>
        /// 社会经济目标信息修改
        /// </summary>
        public bool AimsUpdate(string proc, int AimsId, string AimsName, string Id, string Explain, string FatherId, string UserCardId)
        {
            return human.AimsUpdate(proc, AimsId, AimsName,Id,Explain,FatherId, UserCardId);

        }
        /// <summary>
        /// 社会经济目标信息删除
        /// </summary>
        public bool AimsDelete(string proc, int AimsId, string UserCardId)
        {
            return human.AimsDelete(proc, AimsId, UserCardId);

        }
        #endregion
        #region 服务的国民经济行业
        /// <summary>
        /// 服务的国民经济行业信息添加
        /// </summary>
        public bool ServiceIndustryInsert(string proc, string ServiceIndustryName,string Id,string FatherId, string UserCardId)
        {
            return human.ServiceIndustryInsert(proc, ServiceIndustryName,Id,FatherId, UserCardId);

        }
        /// <summary>
        /// 服务的国民经济行业信息单个查询
        /// </summary>
        public DataSet SelectByServiceIndustryId(string proc, int ServiceIndustryId)
        {
            return human.SelectByServiceIndustryId(proc, ServiceIndustryId);

        }
        /// <summary>
        /// 服务的国民经济行业信息单个查询
        /// </summary>
        public DataSet SelectByServiceIndustryIds(string proc, string ServiceIndustryId)
        {
            return human.SelectByServiceIndustryIds(proc, ServiceIndustryId);

        }
        /// <summary>
        /// 服务的国民经济行业信息修改
        /// </summary>
        public bool ServiceIndustryUpdate(string proc, int ServiceIndustryId, string ServiceIndustryName,string Id,string FatherId, string UserCardId)
        {
            return human.ServiceIndustryUpdate(proc, ServiceIndustryId, ServiceIndustryName,Id,FatherId, UserCardId);

        }
        /// <summary>
        /// 服务的国民经济行业信息删除
        /// </summary>
        public bool ServiceIndustryDelete(string proc, int ServiceIndustryId, string UserCardId)
        {
            return human.ServiceIndustryDelete(proc, ServiceIndustryId, UserCardId);

        }
        #endregion

        /// <summary>
        /// 项目情况添加
        /// </summary>
        public bool ProjectStatusInsert(string proc, string UserCardId, string ProjectId, string ProjectStatusName,
            string Source, string Personnel, int SubjectId, string Cooperation, string AimsId1, string AimsId2, string AimsId3,
            string ServiceIndustryId1, string ServiceIndustryId2, string ServiceIndustryId3, string ServiceIndustryId4, string Category, string ProjectDate, string ResultsDate, string Results,
            string Status, string Funding1, string Funding2, string Funding3, string Funding4, string TransferUnit,
            string TransferName, string Cost1, string Cost2, string Cost3, string Cost4, string Cost5, string Cost6,
            string Cost7)
        {
            return human.ProjectStatusInsert(proc, UserCardId, ProjectId, ProjectStatusName, Source,
                Personnel, SubjectId, Cooperation, AimsId1, AimsId2, AimsId3, ServiceIndustryId1, ServiceIndustryId2, ServiceIndustryId3, ServiceIndustryId4, Category, ProjectDate, ResultsDate,
                Results, Status, Funding1, Funding2, Funding3, Funding4, TransferUnit, TransferName, Cost1,
                Cost2, Cost3, Cost4, Cost5, Cost6, Cost7);

        }
        /// <summary>
        /// 项目情况修改
        /// </summary>
        public bool ProjectStatusUpdate(string proc, int ProjectStatusId, string ProjectId, string ProjectStatusName,
            string Source, string Personnel, int SubjectId, string Cooperation, string AimsId1, string AimsId2, string AimsId3,
            string ServiceIndustryId1, string ServiceIndustryId2, string ServiceIndustryId3, string ServiceIndustryId4, string Category, string ProjectDate, string ResultsDate, string Results,
            string Status, string Funding1, string Funding2, string Funding3, string Funding4, string TransferUnit,
            string TransferName, string Cost1, string Cost2, string Cost3, string Cost4, string Cost5, string Cost6,
            string Cost7)
        {
            return human.ProjectStatusUpdate(proc, ProjectStatusId, ProjectId, ProjectStatusName, Source,
                Personnel, SubjectId, Cooperation, AimsId1, AimsId2, AimsId3, ServiceIndustryId1, ServiceIndustryId2, ServiceIndustryId3, ServiceIndustryId4, Category, ProjectDate, ResultsDate,
                Results, Status, Funding1, Funding2, Funding3, Funding4, TransferUnit, TransferName, Cost1,
                Cost2, Cost3, Cost4, Cost5, Cost6, Cost7);

        }
        /// <summary>
        /// 项目情况单个查询
        /// </summary>
        public DataSet SelectByProjectStatusId(string proc, int ProjectStatusId)
        {
            return human.SelectByProjectStatusId(proc, ProjectStatusId);

        }
        /// <summary>
        /// 按项目情况编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectProjectStatusId(string proc, int ProjectStatusId)
        {
            return human.SelectProjectStatusId(proc, ProjectStatusId);
        }
        /// <summary>
        /// 项目情况审批流程添加
        /// </summary>
        public bool ProjectStatusProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.ProjectStatusProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 项目情况审批流程删除
        /// </summary>
        public bool ProjectStatusProcessDelete(string proc, int ProjectStatusProcessId, string UserCardId)
        {
            return human.ProjectStatusProcessDelete(proc, ProjectStatusProcessId, UserCardId);

        }
        /// <summary>
        /// 项目情况审批添加
        /// </summary>
        public bool ProjectStatusExamineInsert(string proc, int ProjectStatusId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.ProjectStatusExamineInsert(proc, ProjectStatusId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 项目情况可审批查询
        /// </summary>
        public DataSet ProjectStatusExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.ProjectStatusExamineSelectUser(proc, UserCardId, RankId);

        }
        /// <summary>
        /// 项目情况记录查询
        /// </summary>
        public DataSet SelectsProjectStatus(string proc, string UserName, string ProjectStatusName, string DepartmentId, string Source, string TransferStatus)
        {
            return human.SelectsProjectStatus(proc, UserName, ProjectStatusName, DepartmentId, Source, TransferStatus);

        }
        /// <summary>
        /// 项目情况删除
        /// </summary>
        public bool ProjectStatusDelete(string proc, int ProjectStatusId)
        {
            return human.ProjectStatusDelete(proc, ProjectStatusId);

        }



        #endregion
        #region 科技项目情况
        #region 活动类型
        /// <summary>
        /// 活动类型信息添加
        /// </summary>
        public bool TypeActivityInsert(string proc, string TypeActivityName, string UserCardId)
        {
            return human.TypeActivityInsert(proc, TypeActivityName, UserCardId);

        }
        /// <summary>
        /// 活动类型信息单个查询
        /// </summary>
        public DataSet SelectByTypeActivityId(string proc, int TypeActivityId)
        {
            return human.SelectByTypeActivityId(proc, TypeActivityId);

        }
        /// <summary>
        /// 活动类型信息修改
        /// </summary>
        public bool TypeActivityUpdate(string proc, int TypeActivityId, string TypeActivityName, string UserCardId)
        {
            return human.TypeActivityUpdate(proc, TypeActivityId, TypeActivityName, UserCardId);

        }
        /// <summary>
        /// 活动类型信息删除
        /// </summary>
        public bool TypeActivityDelete(string proc, int TypeActivityId, string UserCardId)
        {
            return human.TypeActivityDelete(proc, TypeActivityId, UserCardId);

        }
        #endregion
        #region 项目来源
        /// <summary>
        /// 项目来源信息添加
        /// </summary>
        public bool SourceInsert(string proc, string SourceName, string UserCardId)
        {
            return human.SourceInsert(proc, SourceName, UserCardId);

        }
        /// <summary>
        /// 项目来源信息单个查询
        /// </summary>
        public DataSet SelectBySourceId(string proc, int SourceId)
        {
            return human.SelectBySourceId(proc, SourceId);

        }
        /// <summary>
        /// 项目来源信息修改
        /// </summary>
        public bool SourceUpdate(string proc, int SourceId, string SourceName, string UserCardId)
        {
            return human.SourceUpdate(proc, SourceId, SourceName, UserCardId);

        }
        /// <summary>
        /// 项目来源信息删除
        /// </summary>
        public bool SourceDelete(string proc, int SourceId, string UserCardId)
        {
            return human.SourceDelete(proc, SourceId, UserCardId);

        }
        #endregion
        #region 组织形式
        /// <summary>
        /// 组织形式信息添加
        /// </summary>
        public bool OrganizationInsert(string proc, string OrganizationName, string UserCardId)
        {
            return human.OrganizationInsert(proc, OrganizationName, UserCardId);

        }
        /// <summary>
        /// 组织形式信息单个查询
        /// </summary>
        public DataSet SelectByOrganizationId(string proc, int OrganizationId)
        {
            return human.SelectByOrganizationId(proc, OrganizationId);

        }
        /// <summary>
        /// 组织形式信息修改
        /// </summary>
        public bool OrganizationUpdate(string proc, int OrganizationId, string OrganizationName, string UserCardId)
        {
            return human.OrganizationUpdate(proc, OrganizationId, OrganizationName, UserCardId);

        }
        /// <summary>
        /// 组织形式信息删除
        /// </summary>
        public bool OrganizationDelete(string proc, int OrganizationId, string UserCardId)
        {
            return human.OrganizationDelete(proc, OrganizationId, UserCardId);

        }
        #endregion
        #region 合作形式
        /// <summary>
        /// 合作形式信息添加
        /// </summary>
        public bool CooperationInsert(string proc, string CooperationName, string UserCardId)
        {
            return human.CooperationInsert(proc, CooperationName, UserCardId);

        }
        /// <summary>
        /// 合作形式信息单个查询
        /// </summary>
        public DataSet SelectByCooperationId(string proc, int CooperationId)
        {
            return human.SelectByCooperationId(proc, CooperationId);

        }
        /// <summary>
        /// 合作形式信息修改
        /// </summary>
        public bool CooperationUpdate(string proc, int CooperationId, string CooperationName, string UserCardId)
        {
            return human.CooperationUpdate(proc, CooperationId, CooperationName, UserCardId);

        }
        /// <summary>
        /// 合作形式信息删除
        /// </summary>
        public bool CooperationDelete(string proc, int CooperationId, string UserCardId)
        {
            return human.CooperationDelete(proc, CooperationId, UserCardId);

        }
        #endregion

        /// <summary>
        /// 科技项目情况添加
        /// </summary>
        public bool KJProjectStatusInsert(string proc, string UserCardId, string KJProjectId, string ApplyYear, string KJProjectName,
        string ApprovalDate, string Funding1, string Funding2, string Funding3, string Funding4, string Funding5,
        string Funding6, string Funding7, string Funding8, string Funding9, string Funding10, string Funding11,
        string Funding12, string Personnel1, string Personnel2, string Personnel3, string Personnel4, string Personnel5,
        string Personnel6, string Quantity1, string Quantity2, string Quantity3, string Class1, string Class2,
        string Class3, int TypeActivityId, string Class5, int SourceId, string Class7, int OrganizationId, string Class9,
        int CooperationId, string AimsId1, string AimsId2, string AimsId3, string ServiceIndustry1, string ServiceIndustry2, string ServiceIndustry3, string ServiceIndustry4)
        {
            return human.KJProjectStatusInsert(proc, UserCardId, KJProjectId, ApplyYear, KJProjectName, ApprovalDate, Funding1,
            Funding2, Funding3, Funding4, Funding5, Funding6, Funding7, Funding8, Funding9, Funding10, Funding11,
            Funding12, Personnel1, Personnel2, Personnel3, Personnel4, Personnel5, Personnel6, Quantity1, Quantity2,
            Quantity3, Class1, Class2, Class3, TypeActivityId, Class5, SourceId, Class7, OrganizationId, Class9,
            CooperationId, AimsId1, AimsId2, AimsId3, ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4);

        }
        /// <summary>
        /// 科技项目情况修改
        /// </summary>
        public bool KJProjectStatusUpdate(string proc, string KJProjectId, string ApplyYear, string KJProjectName,
        string ApprovalDate, string Funding1, string Funding2, string Funding3, string Funding4, string Funding5,
        string Funding6, string Funding7, string Funding8, string Funding9, string Funding10, string Funding11,
        string Funding12, string Personnel1, string Personnel2, string Personnel3, string Personnel4, string Personnel5,
        string Personnel6, string Quantity1, string Quantity2, string Quantity3, string Class1, string Class2,
        string Class3, int TypeActivityId, string Class5, int SourceId, string Class7, int OrganizationId, string Class9,
        int CooperationId, string AimsId1, string AimsId2, string AimsId3, string ServiceIndustry1, string ServiceIndustry2, string ServiceIndustry3, string ServiceIndustry4)
        {
            return human.KJProjectStatusUpdate(proc, KJProjectId, ApplyYear, KJProjectName, ApprovalDate, Funding1,
            Funding2, Funding3, Funding4, Funding5, Funding6, Funding7, Funding8, Funding9, Funding10, Funding11,
            Funding12, Personnel1, Personnel2, Personnel3, Personnel4, Personnel5, Personnel6, Quantity1, Quantity2,
            Quantity3, Class1, Class2, Class3, TypeActivityId, Class5, SourceId, Class7, OrganizationId, Class9,
            CooperationId,AimsId1,AimsId2,AimsId3,ServiceIndustry1, ServiceIndustry2, ServiceIndustry3, ServiceIndustry4);

        }
        /// <summary>
        /// 科技项目情况单个查询
        /// </summary>
        public DataSet SelectByKJProjectStatusId(string proc, int KJProjectStatusId)
        {
            return human.SelectByKJProjectStatusId(proc, KJProjectStatusId);

        }
        /// <summary>
        /// 按科技项目情况编号查询
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet SelectKJProjectStatusId(string proc, int KJProjectStatusId)
        {
            return human.SelectKJProjectStatusId(proc, KJProjectStatusId);
        }
        /// <summary>
        /// 科技项目情况审批流程添加
        /// </summary>
        public bool KJProjectStatusProcessInsert(string proc, int ProcessRoleId, int ProcessOrder, string DepartmentName, string UserCardId)
        {
            return human.KJProjectStatusProcessInsert(proc, ProcessRoleId, ProcessOrder, DepartmentName, UserCardId);

        }
        /// <summary>
        /// 科技项目情况审批流程删除
        /// </summary>
        public bool KJProjectStatusProcessDelete(string proc, int KJProjectStatusProcessId, string UserCardId)
        {
            return human.KJProjectStatusProcessDelete(proc, KJProjectStatusProcessId, UserCardId);

        }
        /// <summary>
        /// 科技项目情况审批添加
        /// </summary>
        public bool KJProjectStatusExamineInsert(string proc, int KJProjectStatusId, string ExamineOpinion, string ExamineUserCardId, string ExamineResult, int RankId)
        {
            return human.KJProjectStatusExamineInsert(proc, KJProjectStatusId, ExamineOpinion, ExamineUserCardId, ExamineResult, RankId);

        }
        /// <summary>
        /// 科技项目情况可审批查询
        /// </summary>
        public DataSet KJProjectStatusExamineSelectUser(string proc, string UserCardId, int RankId)
        {
            return human.KJProjectStatusExamineSelectUser(proc, UserCardId, RankId);

        }
        /// <summary>
        /// 科技项目情况记录查询
        /// </summary>
        public DataSet SelectsKJProjectStatus(string proc, string UserName, string ApprovalDate, string ApplyYear, string TransferStatus, string KJProjectName)
        {
            return human.SelectsKJProjectStatus(proc, UserName, ApprovalDate, ApplyYear, TransferStatus, KJProjectName);

        }
        /// <summary>
        /// 科技项目情况删除
        /// </summary>
        public bool KJProjectStatusDelete(string proc, int KJProjectStatusId)
        {
            return human.KJProjectStatusDelete(proc, KJProjectStatusId);

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