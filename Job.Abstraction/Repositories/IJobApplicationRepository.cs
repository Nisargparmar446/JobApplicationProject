using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<ResponseMessage> AddUpdateJobApplicationDetails(JobApplicationDetails jobApplicationDetails);
        Task<DashBoard> GetJobApplicationList(DashBoard dashBoard);
        Task<JobApplicationDetails> GetJobApplicationById(int JobApplicationId);
        Task<ResponseMessage> DeleteJobApplication(JobApplicationDetails jobApplicationDetails);
    }
}
