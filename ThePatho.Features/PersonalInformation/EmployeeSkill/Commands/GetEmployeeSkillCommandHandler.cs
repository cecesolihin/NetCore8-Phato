using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetEmployeeSkillCommandHandler : IRequestHandler<GetEmployeeSkillCommand, ApiResponse<EmployeeSkillItemDto>>
    {
        private readonly IEmployeeSkillService Service;

        public GetEmployeeSkillCommandHandler(IEmployeeSkillService _employeeskillService)
        {
            Service = _employeeskillService;
        }

        public async Task<ApiResponse<EmployeeSkillItemDto>> Handle(GetEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeSkill(request);
        }
    }
}

