using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetSingleEmployeeSkillCommandHandler : IRequestHandler<GetSingleEmployeeSkillCommand, ApiResponse<EmployeeSkillDto>>
    {
        private readonly IEmployeeSkillService Service;

        public GetSingleEmployeeSkillCommandHandler(IEmployeeSkillService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeSkillDto>> Handle(GetSingleEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeSkill(request);
        }
    }
}
