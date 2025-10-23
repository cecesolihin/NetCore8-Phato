using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class SubmitEmployeeSkillCommandHandler : IRequestHandler<SubmitEmployeeSkillCommand, ApiResponse>
    {
        private readonly IEmployeeSkillService Service;

        public SubmitEmployeeSkillCommandHandler(IEmployeeSkillService _employeeskillService)
        {
            Service = _employeeskillService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeSkill(request);
        }
    }
}

