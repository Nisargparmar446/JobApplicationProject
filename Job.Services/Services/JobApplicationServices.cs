using Job.Abstraction.Repositories;
using Job.Abstraction.Services;
using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services
{
    public class JobApplicationServices : IJobApplicationServices
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        public JobApplicationServices(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository ?? throw new ArgumentNullException(nameof(jobApplicationRepository));
        }

        public async Task<ResponseMessage> AddUpdateJobApplicationDetails(JobApplicationDetails jobApplicationDetails)
        {
            var res = await _jobApplicationRepository.AddUpdateJobApplicationDetails(jobApplicationDetails);
            return res;
        }
        public async Task<DashBoard> GetJobApplicationList(DashBoard dashBoard)
        {
            return await _jobApplicationRepository.GetJobApplicationList(dashBoard);
        }
        public async Task<JobApplicationDetails> GetJobApplicationById(int JobApplicationId)
        {
            return await _jobApplicationRepository.GetJobApplicationById(JobApplicationId);
        }
        public async Task<ResponseMessage> DeleteJobApplication(JobApplicationDetails jobApplicationDetails)
        {
            var res = await _jobApplicationRepository.DeleteJobApplication(jobApplicationDetails);
            return res;
        }
    }
}
