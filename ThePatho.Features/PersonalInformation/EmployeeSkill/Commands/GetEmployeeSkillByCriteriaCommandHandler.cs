using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetEmployeeSkillByCriteriaCommandHandler : IRequestHandler<GetEmployeeSkillByCriteriaCommand, ApiResponse<EmployeeSkillItemDto>>
    {
        private readonly IEmployeeSkillService Service;

        public GetEmployeeSkillByCriteriaCommandHandler(IEmployeeSkillService _employeeskillService)
        {
            Service = _employeeskillService;
        }

        public async Task<ApiResponse<EmployeeSkillItemDto>> Handle(GetEmployeeSkillByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeSkillByCriteria(request);
        }
    }
}

