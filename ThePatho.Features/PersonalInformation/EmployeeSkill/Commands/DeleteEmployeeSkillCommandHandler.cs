using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class DeleteEmployeeSkillCommandHandler : IRequestHandler<DeleteEmployeeSkillCommand, ApiResponse>
    {
        private readonly IEmployeeSkillService Service;

        public DeleteEmployeeSkillCommandHandler(IEmployeeSkillService _employeeskillService)
        {
            Service = _employeeskillService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeSkill(request);
        }
    }
}

