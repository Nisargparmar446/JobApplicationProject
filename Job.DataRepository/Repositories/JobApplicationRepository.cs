using Dapper;
using Job.Abstraction;
using Job.Abstraction.Repositories;
using Job.Abstraction.ViewDataModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DataRepository.Repositories
{
    public class JobApplicationRepository : BaseRepository<BaseDataTableEntity>, IJobApplicationRepository
    {
        public IConfiguration appConfig;
        public JobApplicationRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<ResponseMessage> AddUpdateJobApplicationDetails(JobApplicationDetails jobApplicationDetails)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@JobApplicationId", jobApplicationDetails.JobApplicationId);
                    queryParameters.Add("@ApplicantId", jobApplicationDetails.UserId);
                    queryParameters.Add("@ApplicantName", jobApplicationDetails.ApplicantName);
                    queryParameters.Add("@Email", jobApplicationDetails.Email);
                    queryParameters.Add("@Address", jobApplicationDetails.Address);
                    queryParameters.Add("@Gender", jobApplicationDetails.Gender);
                    queryParameters.Add("@Contact", jobApplicationDetails.Contact);
                    queryParameters.Add("@PreferredLocation", jobApplicationDetails.PreferredLocation);
                    queryParameters.Add("@ExpectedCTC", jobApplicationDetails.ExpectedCTC);
                    queryParameters.Add("@CurrentCTC", jobApplicationDetails.CurrentCTC);
                    queryParameters.Add("@NoticePeriod", jobApplicationDetails.NoticePeriod);
                    queryParameters.Add("@IPAddress", jobApplicationDetails.IPAddress);
                    queryParameters.Add("@HostName", jobApplicationDetails.HostName);
                    queryParameters.Add("@dtEducationDetails", jobApplicationDetails.dtEducationDetails, DbType.Object);
                    queryParameters.Add("@dtLanguageDetails", jobApplicationDetails.dtLanguageDetails, DbType.Object);
                    queryParameters.Add("@dtTechSkillDetails", jobApplicationDetails.dtTechSkillDetails, DbType.Object);
                    queryParameters.Add("@dtWorkExpDetails", jobApplicationDetails.dtWorkExpDetails, DbType.Object);
                    var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>("AddUpdateJobApplication", queryParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DashBoard> GetJobApplicationList(DashBoard dashBoard)
        {
            try
            {
                //DashBoard dashBoard = new DashBoard();
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    if (dashBoard != null && (dashBoard.FromDate != null && dashBoard.ToDate != null))
                    {
                        queryParameters.Add("@FromDate", Convert.ToDateTime(dashBoard.FromDate));
                        queryParameters.Add("@ToDate", Convert.ToDateTime(dashBoard.ToDate));
                    }
                    //queryParameters.Add("@UserId", jobApplicationDetails.UserId);
                    var resultSet = await conn.QueryMultipleAsync("GetJobApplicationList", queryParameters, commandType: CommandType.StoredProcedure);
                    var Dashboard = await resultSet.ReadAsync<DashBoard>();
                    dashBoard.DashboardDeatilsList = Dashboard.ToList();
                    return dashBoard;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<JobApplicationDetails> GetJobApplicationById(int JobApplicationId)
        {
            try
            {
                JobApplicationDetails objJobApplicationDetails = new JobApplicationDetails();
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@JobApplicationId", JobApplicationId);
                    var resultSet = await conn.QueryMultipleAsync("GetJobApplicationById", queryParameters, commandType: CommandType.StoredProcedure);

                    var obApplication = await resultSet.ReadAsync<JobApplicationDetails>();
                    objJobApplicationDetails = obApplication.FirstOrDefault();

                    if (resultSet.Command != null)
                    {
                        var EducationViewModel = await resultSet.ReadAsync<EducationDetails>();
                        objJobApplicationDetails.objEducationDetails = EducationViewModel.ToList();
                        var WorkViewModel = await resultSet.ReadAsync<WorkExpDetails>();
                        objJobApplicationDetails.objWorkExpDetails = WorkViewModel.ToList();
                        var LanguageViewModel = await resultSet.ReadAsync<LanguageDetails>();
                        objJobApplicationDetails.objLanguageDetails = LanguageViewModel.ToList();
                        var TechSkillViewModel = await resultSet.ReadAsync<TechSkillDetails>();
                        objJobApplicationDetails.objTechSkillDetails = TechSkillViewModel.ToList();

                    }

                    return objJobApplicationDetails;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ResponseMessage> DeleteJobApplication(JobApplicationDetails jobApplicationDetails)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@JobApplicationId", jobApplicationDetails.JobApplicationId);
                    var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>("DeleteJobApplication", queryParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
