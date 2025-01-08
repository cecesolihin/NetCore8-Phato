using MediatR;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class DeleteJobCategoryCommand : IRequest<bool>
    {
        public string JobCategoryCode { get; set; }

        public DeleteJobCategoryCommand(string jobCategoryCode)
        {
            JobCategoryCode = jobCategoryCode;
        }
    }
}
