
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public interface IJobLevelService
    {
        Task<List<JobLevelDto>> GetJobLevel(GetJobLevelCommand request);
        Task<JobLevelDto> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request);
        Task<bool> SubmitJobLevel(SubmitJobLevelCommand request);
        Task<bool> DeleteJobLevel(DeleteJobLevelCommand request);
    }
}
